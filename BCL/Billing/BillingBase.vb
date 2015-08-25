Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Statements
Imports BCL.Common


Namespace Billings

    Public Class BillingMonths
        Inherits ListSource

        Public Sub New(ByVal feeTypeID As String)
            Using params As New OraParameter
                params.AddItem("typeid", feeTypeID, OracleDbType.Int32)
                For Each dr As DataRow In OraDBHelper2.GetResultSet(SelectStatement.GetBillingMonths, params.GetParameterCollection).Rows
                    List.Add(New ItemLIst(Date.Parse(dr("bill_date").ToString).ToShortDateString, Date.Parse(dr("bill_date").ToString).ToString("MMMM yyyy").ToUpper))
                Next
            End Using
        End Sub

    End Class


    Public Enum BillingStatus
        <EnumDescription("Unpaid")> _
        <EnumDBValue("U")> _
        Unpaid
        <EnumDescription("Fully Paid")> _
        <EnumDBValue("F")> _
        Paid
        <EnumDescription("Partially Paid")> _
        <EnumDBValue("P")> _
        PartiallyPaid
        <EnumDescription("Cancelled")> _
        <EnumDBValue("C")> _
        Cancelled
        <EnumDescription("Hold")> _
        <EnumDBValue("H")> _
        Hold
    End Enum

    Public Class BillingSchedule
        Private _statementDate As Nullable(Of Date) '
        Public Property StatementDate() As Nullable(Of Date)
            Get
                Return _statementDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _statementDate = Value
            End Set
        End Property

        Private _dueDate As Nullable(Of Date)

        Public Property DueDate() As Nullable(Of Date)
            Get
                Return _dueDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _dueDate = Value
            End Set
        End Property


        Private _gracePeriodDate As Nullable(Of Date)

        Public Property GracePeriodDate() As Nullable(Of Date)
            Get
                Return _gracePeriodDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _gracePeriodDate = Value
            End Set
        End Property

    End Class

    Public MustInherit Class BillingBase

        Private _billID As String
        Public Property BillID() As String
            Get
                Return _billID
            End Get
            Protected Set(ByVal value As String)
                _billID = value
            End Set
        End Property

        Public ReadOnly Property BillingMonthYear() As Date
            Get
                Return New Date(_statementDate.Year, _statementDate.Month, 1)
            End Get
        End Property

        Private _statementDate As Date '
        Public Property StatementDate() As Date
            Get
                Return _statementDate
            End Get
            Set(ByVal Value As Date)
                _statementDate = Value
            End Set
        End Property

        Private _dueDate As Nullable(Of Date)

        Public Property DueDate() As Nullable(Of Date)
            Get
                Return _dueDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _dueDate = Value
            End Set
        End Property

        Private _feeTypeID As String
        Public Property FeeTypeID() As String
            Get
                Return _feeTypeID
            End Get
            Set(ByVal value As String)
                _feeTypeID = value
            End Set
        End Property

        Private _accountID As String
        Public Property AccountID() As String
            Get
                Return _accountID
            End Get
            Set(ByVal value As String)
                _accountID = value
            End Set
        End Property

        Private _ID As String
        Public Property LeasedID As String
            Get
                Return _ID
            End Get
            Set(value As String)
                _ID = value
            End Set
        End Property


        Private _amountDue As Decimal
        Public Overridable Property AmountDue() As Decimal
            Get
                Return _amountDue
            End Get
            Set(ByVal value As Decimal)
                _amountDue = value
            End Set
        End Property

        Private _penalty As Decimal
        Public Property Penalty() As Decimal
            Get
                Return _penalty
            End Get
            Set(ByVal value As Decimal)
                _penalty = value
            End Set
        End Property

        Public MustOverride Sub GenerateBill()

        Public MustOverride Function BatchGenerateBill() As Integer

        Protected MustOverride Function InsertBill() As Boolean

        Public Shared Sub UpdateBillingStatus(ByVal billID As String(), ByVal status As BillingStatus)

            Using params As New OraParameter
                params.AddParameter("billid", billID, OracleDbType.Varchar2, ParameterDirection.Input, True)
                params.AddParameter("billStatus", EnumHelper.GetDBValue(status), OracleDbType.Varchar2, ParameterDirection.Input)
                OraDBHelper2.ExecuteProcedureforInput("PROPMANS.proc_updatebillingstatus", params.GetParameterCollection)
            End Using
        End Sub

        Public Shared Sub UpdatePenaltyAdjustments(ByVal billID As String(), ByVal origpenalty As String(), ByVal penaltyadjustments As String(), ByVal remarks As String, ByVal adjustmentDate As Date)
            Using params As New OraParameter
                params.AddParameter("billid", billID, OracleDbType.Varchar2, ParameterDirection.Input, True)
                params.AddParameter("oldpenalty", origpenalty, OracleDbType.Varchar2, ParameterDirection.Input, True)
                params.AddParameter("penaltyadj", penaltyadjustments, OracleDbType.Varchar2, ParameterDirection.Input, True)
                params.AddParameter("adjremarks", remarks, OracleDbType.Varchar2, ParameterDirection.Input)
                params.AddParameter("adjustmentdate", adjustmentDate, OracleDbType.Date, ParameterDirection.Input)
                OraDBHelper2.ExecuteProcedureforInput("PROPMANS.proc_updatepenaltyadjustments", params.GetParameterCollection)
            End Using
        End Sub

        Public Shared Function GetUnpaidBillings() As DataTable

            Dim query As String = "SELECT DISTINCT cust_unit_no, cust_unit_sort,                                                 " & _
                                    "               accounts.getcustomerfullname_lfm (acct_cust_id) cust_name,                                 " & _
                                    "                MAX (bill_date) OVER (PARTITION BY account_id)                                " & _
                                    "                                                             latest_bill_date,                " & _
                                    "                FIRST_VALUE (balance) OVER (PARTITION BY account_id ORDER BY bill_date DESC)  " & _
                                    "                                                              latest_bill_amt,                " & _
                                    "                  SUM (balance) OVER (PARTITION BY account_id)                                " & _
                                    "                - FIRST_VALUE (balance) OVER (PARTITION BY account_id ORDER BY bill_date DESC)" & _
                                    "                                                              previous_unpaid,                " & _
                                    "                SUM (balance) OVER (PARTITION BY account_id) total                            " & _
                                    "           FROM customer_accounts cs                                                          " & _
                                    "                RIGHT JOIN                                                                    " & _
                                    "                (SELECT bill_id, bill_cust_id, bill_date, balance                             " & _
                                    "                   FROM billing_charges                                                       " & _
                                    "                  WHERE bill_fee_type = :feetype AND bill_status IN                           " & _
                                    "                                                                   ('U', 'P')) ua             " & _
                                    "                ON cs.account_id = ua.bill_cust_id                                            " & _
                                    "       ORDER BY cust_unit_sort                                                                "

            Using params As New OraParameter
                params.AddParameter("feetype", 25, OracleDbType.Int32)

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using
        End Function

    End Class

End Namespace

