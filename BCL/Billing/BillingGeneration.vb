'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 05-12-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************

Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Statements
Imports System.Text
Imports BCL.Utils
Imports BCL.Billings
Imports BCL.WaterSystem
Imports System.ComponentModel

Namespace Billings

    Public Class Parameter
        Private _paramName As String
        Public Property ParameterName() As String
            Get
                Return _paramName
            End Get
            Set(ByVal value As String)
                _paramName = value
            End Set
        End Property

        Private _paramValue As Object
        Public Property ParameterValue() As Object
            Get
                Return _paramValue
            End Get
            Set(ByVal value As Object)
                _paramValue = value
            End Set
        End Property

        Public Sub New(ByVal paramName As String, ByVal paramvalue As Object)
            Me._paramName = paramName
            Me._paramValue = paramvalue
        End Sub
    End Class
    <CLSCompliant(True)>
    Public Class AccountBilling

        Public Const VATMultiplier As Decimal = 1.12
        Public Const VATRate As Decimal = 0.12

        <DisplayName(" ")>
        Public Property IsSelected As Boolean
        <Browsable(False)>
        Public Property AccountID As String
        <Browsable(False)>
        Public Property LesseeID As String
        <Browsable(False)>
        Public Property BillID As String
        <DisplayName("UNIT NUMBER")>
        Public Property UnitNumber As String
        <DisplayName("CUSTOMER NAME")>
        Public Property CustomerName As String
        <Browsable(False)>
        Public Property RateClass As String
        <DisplayName("BILLING MONTH")>
        Public Property BillDate As Date
        <Browsable(False)>
        Public Property StatemenDate As Date
        <Browsable(False)>
        Public Property DueDate As Date
        <Browsable(False)>
        Public Property PreviousBalance As Decimal
        <Browsable(False)>
        Public Property PreviousDiscount As Decimal
        <Browsable(False)>
        Public Property PreviousPayment As Decimal
        <Browsable(False)>
        Public Property CurrentDiscount As Decimal

        <DisplayName("PREVIOUS BALANCE")>
        Public ReadOnly Property PreviousStatementBalance As Decimal
            Get

                Return PreviousBalance - (PreviousDiscount + PreviousPayment)
            End Get
        End Property

        <DisplayName("REMAINING ADVANCE")>
        Public Property RemainingAdvance As Decimal

        <DisplayName("CURRENT CHARGE")>
        Public Property CurrentCharges As Decimal
        <DisplayName("CURRENT PENALTY")>
        Public Property CurrentPenalty As Decimal

        <Browsable(False)>
        Public ReadOnly Property CurrentChargesExclusiveofVAT As Decimal
            Get
                Return CurrentCharges / VATMultiplier
            End Get
        End Property

        <Browsable(False)>
        Public ReadOnly Property CurrentPenaltyExclusiveofVAT As Decimal
            Get
                If CurrentPenalty > 0 Then
                    Return CurrentPenalty / VATMultiplier
                Else
                    Return CurrentPenalty
                End If
            End Get
        End Property

        <Browsable(False)>
        Public ReadOnly Property CurrentSubtotal As Decimal
            Get
                Return (CurrentChargesExclusiveofVAT + CurrentPenaltyExclusiveofVAT) - CurrentDiscount - RemainingAdvance
            End Get
        End Property

        <Browsable(False)>
        Public ReadOnly Property VATAmount As Decimal
            Get
                Return ((CurrentChargesExclusiveofVAT + CurrentPenaltyExclusiveofVAT) - CurrentDiscount) * VATRate
            End Get
        End Property

        <Browsable(False)>
        Public ReadOnly Property TotalAmountDue As Decimal
            Get
                Dim previousBalance As Decimal = 0

                If PreviousStatementBalance > 0 Then
                    previousBalance = PreviousStatementBalance
                End If

                Return previousBalance + CurrentSubtotal + VATAmount
            End Get
        End Property
        <DisplayName("TOTAL AMOUNT DUE")>
        Public ReadOnly Property BillAmountDue As Decimal
            Get
                Dim due As Decimal = 0

                If TotalAmountDue > 0 Then
                    due = TotalAmountDue
                End If

                Return due
            End Get
        End Property
        Public Sub New()

        End Sub

    End Class



    Public MustInherit Class Billing
        Private _bldgList As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        Public Property BldgNoList() As String
            Get
                Return _bldgList
            End Get
            Set(ByVal Value As String)
                _bldgList = Value
            End Set
        End Property
        Private _params As New List(Of Parameter)
        Public Property ParamList() As List(Of Parameter)
            Get
                Return _params
            End Get
            Protected Set(ByVal value As List(Of Parameter))
                _params = value
            End Set
        End Property

        Private _feeID As String
        Public Property FeeID() As String
            Get
                Return _feeID
            End Get
            Protected Set(ByVal value As String)
                _feeID = value
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

        Private _readingID As Decimal
        Public Property ReadingID() As Decimal
            Get
                Return _readingID
            End Get
            Protected Set(ByVal value As Decimal)
                _readingID = value
            End Set
        End Property

        Private _billingPeriod As Nullable(Of Date) ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property BillingPeriod() As Nullable(Of Date)
            Get
                Return _billingPeriod
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _billingPeriod = Value
            End Set
        End Property
        Private _statementDate As Date ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property StatementDate() As Date
            Get
                Return _statementDate
            End Get
            Set(ByVal Value As Date)
                _statementDate = Value
            End Set
        End Property
        Private _dueDate As Nullable(Of Date) ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property DueDate() As Nullable(Of Date)
            Get
                Return _dueDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _dueDate = Value
            End Set
        End Property

        Public MustOverride ReadOnly Property ManualAmountInput() As Boolean
        Public MustOverride ReadOnly Property StatementDateOnly() As Boolean


        Private _lastStatementDate As Nullable(Of Date)
        Public Property LastStatementDate() As Nullable(Of Date)
            Get
                Return _lastStatementDate
            End Get
            Protected Set(ByVal value As Nullable(Of Date))
                _lastStatementDate = value
            End Set
        End Property

        Public MustOverride Sub GenerateBill()

        Public MustOverride Function BatchGenerateBill() As Integer

        Protected Friend Overridable Function InsertBill() As Integer
            Using params As New OraParameter
                'TODO. bill date must not be nullable
                If BillingPeriod.HasValue Then
                    params.AddParameter("billDate", BillingPeriod.Value, OracleDbType.Date)
                Else
                    params.AddParameter("billDate", DBNull.Value, OracleDbType.Date)
                End If
                If DueDate.HasValue Then
                    params.AddParameter("billDueDate", DueDate.Value, OracleDbType.Date)
                Else
                    params.AddParameter("billDueDate", DBNull.Value, OracleDbType.Date)
                End If

                params.AddParameter("billgenerateDate", StatementDate, OracleDbType.Date)

                params.AddParameter("billfeeType", FeeID, OracleDbType.Int32)
                params.AddParameter("amountDue", AmountDue, OracleDbType.Decimal)
                If Penalty <> 0 Then
                    params.AddParameter("penalty", Penalty, OracleDbType.Decimal)
                Else
                    params.AddParameter("penalty", DBNull.Value, OracleDbType.Decimal)
                End If

                If ReadingID > 0 Then
                    params.AddParameter("billReadID", ReadingID, OracleDbType.Int32)
                Else
                    params.AddParameter("billReadID", DBNull.Value, OracleDbType.Int32)
                End If

                params.AddItem("acctID", AccountID, OracleDbType.Int32)

                Return OraDBHelper2.SqlExecute(InsertStatement.NewBillingCharges, params.GetParameterCollection)

            End Using
        End Function

        Protected Function HasBillings() As Boolean

            Using params As New OraParameter
                params.AddItem("feecode", FeeID, ParameterDirection.Input, OracleDbType.Int32)
                params.AddItem("acctid", AccountID, ParameterDirection.Input, OracleDbType.Int32)
                params.AddItem("exist", "", ParameterDirection.ReturnValue, OracleDbType.Int32)
                Try
                    Dim recCount As Integer = DirectCast(OraDBHelper2.ExecuteFunction("hasbilling", params.GetParameterCollection), OracleDecimal).ToInt32

                    If recCount > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception

                End Try

            End Using
        End Function

        'Public Shared Function GetBillingStatement(ByVal feeTypeID As String, ByVal billdate As Date) As DataTable
        '    Using params As New OraParameter
        '        params.AddParameter("feetypeid", feeTypeID, OracleDbType.Int32)
        '        params.AddParameter("billDate", billdate, OracleDbType.Date)
        '        Dim query As String = "SELECT   bill_id, bill_cust_id account_id, lease_id, bill_date,                 " & _
        '                        "         bill_generate_date, bill_due_date,                                     " & _
        '                        "         accounts.getunitnumber (bill_cust_id) unit_number,                     " & _
        '                        "         NVL2                                                                   " & _
        '                        "            (lease_id,                                                          " & _
        '                        "             accounts.getcustomerfullname_lfm ((SELECT cust_id                  " & _
        '                        "                                                  FROM rm_lease_contract        " & _
        '                        "                                                 WHERE lease_id = bc.lease_id))," & _
        '                        "             accounts.getcustomerfullname_lfm ((SELECT acct_cust_id             " & _
        '                        "                                                  FROM customer_accounts        " & _
        '                        "                                                 WHERE account_id =             " & _
        '                        "                                                               bc.bill_cust_id) " & _
        '                        "                                              )                                 " & _
        '                        "            ) cust_name,                                                        " & _
        '                        "         amount_due, penalty_amt,                                               " & _
        '                        "         billings.getpreviousbalance (bill_fee_type,                            " & _
        '                        "                                      bill_cust_id,                             " & _
        '                        "                                      bill_id                                   " & _
        '                        "                                     ) previous_balance,                        " & _
        '                        "         billings.getadvancesbalance (bill_fee_type,                            " & _
        '                        "                                      bill_cust_id,                             " & _
        '                        "                                      bill_id                                   " & _
        '                        "                                     ) advances,                                " & _
        '                        "         (SELECT cust_unit_sort                                                 " & _
        '                        "            FROM customer_accounts                                              " & _
        '                        "           WHERE account_id = bc.bill_cust_id) unit_sort                        " & _
        '                        "    FROM billing_charges bc                                                     " & _
        '                        "   WHERE bill_fee_type = :feetypeid                                             " & _
        '                        "     AND bill_date = :billdate                                                  " & _
        '                        "     AND bill_status <> 'C'                                                     " & _
        '                        "ORDER BY 13                                                                     "

        '        Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
        '    End Using

        'End Function

        Public Shared Function GetBillingStatement(ByVal feeTypeID As String, ByVal billdate As Date) As List(Of AccountBilling)
            Dim bs As New List(Of AccountBilling)
            Using params As New OraParameter
                params.AddParameter("feetypeid", feeTypeID, OracleDbType.Int32)
                params.AddParameter("billdate", billdate, OracleDbType.Date)
                Dim query As String = "SELECT   bill_id,bill_cust_id, lease_id,accounts.getunitnumber (bill_cust_id) unit_number,          " & _
                                "         nvl2(lease_id, accounts.getcustomerfullname_lfm                      " & _
                                "                                      ((SELECT cust_id                        " & _
                                "                                          FROM rm_lease_contract              " & _
                                "                                         WHERE lease_id = bc.lease_id)        " & _
                                "                                      ), accounts.getcustomerfullname_lfm     " & _
                                "                                      ((SELECT acct_cust_id                   " & _
                                "                                          FROM customer_accounts              " & _
                                "                                         WHERE account_id = bc.bill_cust_id)  " & _
                                "                                      ) ) customer_name,                      " & _
                                "         (SELECT unit_subclass                                                " & _
                                "            FROM am_unit                                                      " & _
                                "           WHERE unit_id IN (SELECT unit_id                                   " & _
                                "                               FROM customer_accounts                         " & _
                                "                              WHERE account_id = bc.bill_cust_id)) rate_class," & _
                                "         bill_date, bill_generate_date, bill_due_date, amount_due,            " & _
                                "         penalty_amt,                                                         " & _
                                "         bs.getpreviousstatementbalance (bill_id) previous_statement_balance, " & _
                                "         bs.getpreviousapplieddiscount (bill_id) previous_discount,           " & _
                                "         bs.getpreviousmonthpayment (bill_id) previous_payment,               " & _
                                "         bs.getcurrentdiscount (bill_id) current_discount,                    " & _
                                "         bs.getremainingadvances (bill_id) remaining_advances                 " & _
                                "    FROM billing_charges bc                                                   " & _
                                "   WHERE bill_date = :billdate AND bill_fee_type = :feetypeid AND bill_status <>'C'    " & _
                                "ORDER BY (SELECT cust_unit_sort                                               " & _
                                "            FROM customer_accounts                                            " & _
                                "           WHERE account_id = bc.bill_cust_id)                                "

                For Each dr As DataRow In OraDBHelper2.GetResultSet(query, params.GetParameterCollection).Rows
                    bs.Add(New AccountBilling With {.BillID = dr("bill_id").ToString,
                                                      .UnitNumber = dr("unit_number").ToString,
                                                      .AccountID = dr("bill_cust_id").ToString,
                                                      .LesseeID = dr("lease_id").ToString,
                                                      .CustomerName = dr("customer_name").ToString,
                                                      .RateClass = dr("rate_class").ToString,
                                                      .BillDate = Date.Parse(dr("bill_date")),
                                                      .StatemenDate = Date.Parse(dr("bill_generate_date")),
                                                      .DueDate = Date.Parse(dr("bill_due_date")),
                                                      .PreviousBalance = Decimal.Round(Decimal.Parse(dr("previous_statement_balance")), 2),
                                                      .PreviousDiscount = Decimal.Round(Decimal.Parse(dr("previous_discount")), 2),
                                                      .PreviousPayment = Decimal.Round(Decimal.Parse(dr("previous_payment")), 2),
                                                      .CurrentCharges = Decimal.Round(Decimal.Parse(dr("amount_due")), 2),
                                                      .CurrentPenalty = Decimal.Round(Decimal.Parse(dr("penalty_amt")), 2),
                                                      .CurrentDiscount = Decimal.Round(Decimal.Parse(dr("current_discount")), 2),
                                                      .RemainingAdvance = Decimal.Round(Decimal.Parse(dr("remaining_advances")), 2)})

                Next
            End Using

            Return bs

        End Function

        Public Shared Function GetBillingStatement(ByVal accountID As String, ByVal feeTypeID As String) As List(Of AccountBilling)
            Dim bs As New List(Of AccountBilling)
            Using params As New OraParameter
                params.AddParameter("accountid", accountID, OracleDbType.Int32)
                params.AddParameter("feetypeid", feeTypeID, OracleDbType.Int32)
                Dim query As String = "SELECT   bill_id,bill_cust_id,lease_id, accounts.getunitnumber (bill_cust_id) unit_number,          " & _
                                "         nvl2(lease_id, accounts.getcustomerfullname_lfm                      " & _
                                "                                      ((SELECT cust_id                        " & _
                                "                                          FROM rm_lease_contract              " & _
                                "                                         WHERE lease_id = bc.lease_id)        " & _
                                "                                      ), accounts.getcustomerfullname_lfm     " & _
                                "                                      ((SELECT acct_cust_id                   " & _
                                "                                          FROM customer_accounts              " & _
                                "                                         WHERE account_id = bc.bill_cust_id)  " & _
                                "                                      ) ) customer_name,                      " & _
                                "         (SELECT unit_subclass                                                " & _
                                "            FROM am_unit                                                      " & _
                                "           WHERE unit_id IN (SELECT unit_id                                   " & _
                                "                               FROM customer_accounts                         " & _
                                "                              WHERE account_id = bc.bill_cust_id)) rate_class," & _
                                "         bill_date, bill_generate_date, bill_due_date, amount_due,            " & _
                                "         penalty_amt,                                                         " & _
                                "         bs.getpreviousstatementbalance (bill_id) previous_statement_balance, " & _
                                "         bs.getpreviousapplieddiscount (bill_id) previous_discount,           " & _
                                "         bs.getpreviousmonthpayment (bill_id) previous_payment,               " & _
                                "         bs.getcurrentdiscount (bill_id) current_discount,                    " & _
                                "         bs.getremainingadvances (bill_id) remaining_advances                 " & _
                                "    FROM billing_charges bc                                                   " & _
                                "   WHERE bill_cust_id = :accountid AND bill_fee_type = :feetypeid AND bill_status <>'C'    " & _
                                "ORDER BY bill_date  desc                                            "
                               

                For Each dr As DataRow In OraDBHelper2.GetResultSet(query, params.GetParameterCollection).Rows
                    bs.Add(New AccountBilling With {.BillID = dr("bill_id").ToString,
                                                      .UnitNumber = dr("unit_number").ToString,
                                                      .LesseeID = dr("lease_id").ToString,
                                                      .AccountID = dr("bill_cust_id").ToString,
                                                      .CustomerName = dr("customer_name").ToString,
                                                      .RateClass = dr("rate_class").ToString,
                                                      .BillDate = Date.Parse(dr("bill_date")),
                                                      .StatemenDate = Date.Parse(dr("bill_generate_date")),
                                                      .DueDate = Date.Parse(dr("bill_due_date")),
                                                      .PreviousBalance = Decimal.Round(Decimal.Parse(dr("previous_statement_balance")), 2),
                                                      .PreviousDiscount = Decimal.Round(Decimal.Parse(dr("previous_discount")), 2),
                                                      .PreviousPayment = Decimal.Round(Decimal.Parse(dr("previous_payment")), 2),
                                                      .CurrentCharges = Decimal.Round(Decimal.Parse(dr("amount_due")), 2),
                                                      .CurrentPenalty = Decimal.Round(Decimal.Parse(dr("penalty_amt")), 2),
                                                      .CurrentDiscount = Decimal.Round(Decimal.Parse(dr("current_discount")), 2),
                                                      .RemainingAdvance = Decimal.Round(Decimal.Parse(dr("remaining_advances")), 2)})

                Next
            End Using

            Return bs

        End Function

        Public Shared Function GetLastPaymentInfo(ByVal accountID As String, ByVal feetypeid As String, ByVal billID As String) As DataTable
            Dim query As String = "SELECT distinct pay_acct_id,                                                                     " & _
                            "                FIRST_VALUE (or_number) OVER (PARTITION BY pay_acct_id ORDER BY payment_date DESC,    " & _
                            "                 or_number DESC) or_number,                                                      " & _
                            "                FIRST_VALUE (payment_date) OVER (PARTITION BY pay_acct_id ORDER BY payment_date DESC, " & _
                            "                 or_number DESC) payment_date,                                                   " & _
                            "                FIRST_VALUE (paid_amount) OVER (PARTITION BY pay_acct_id ORDER BY payment_date DESC,  " & _
                            "                 or_number DESC) amount                                                          " & _
                            "           FROM payments                                                                         " & _
                            "          WHERE pay_fee_type = :feetypeid                                                        " & _
                            "            AND or_status = 'ISSD'                                                               " & _
                            "            AND pay_acct_id = :accountid                                                         " & _
                            "            AND payment_date < (SELECT bill_generate_date                                        " & _
                            "                                  FROM billing_charges                                           " & _
                            "                                 WHERE bill_id = :billid)                                        "

            Using params As New OraParameter
                params.AddParameter("accountid", accountID, OracleDbType.Int32)
                params.AddParameter("feetypeid", feetypeid, OracleDbType.Int32)
                params.AddParameter("billid", billID)


                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetUnpaidBillingsByFeeType(ByVal feeTypeID As String, ByVal accountid As String, ID As String) As DataTable
            Dim query As String

            If String.IsNullOrEmpty(ID) Then
                query = "SELECT   bill_id, (SELECT fee_description                                     " & _
                       "                     FROM ref_fee_types                                       " & _
                       "                    WHERE fee_type_id = bc.bill_fee_type) fee_name, bill_date," & _
                       "         bill_generate_date, amount_due, penalty_amt, bill_status             " & _
                       "    FROM billing_charges bc                                                   " & _
                       "   WHERE bill_cust_id = :acctid and lease_id is null                                              " & _
                       "     AND bill_status IN ('U', 'H')                                            " & _
                       "     AND bill_fee_type = :feetypeid                                           " & _
                       "ORDER BY bill_generate_date DESC                                              "
            Else
                query = "SELECT   bill_id, (SELECT fee_description                                     " & _
                       "                     FROM ref_fee_types                                       " & _
                       "                    WHERE fee_type_id = bc.bill_fee_type) fee_name, bill_date," & _
                       "         bill_generate_date, amount_due, penalty_amt, bill_status             " & _
                       "    FROM billing_charges bc                                                   " & _
                       "   WHERE lease_id = :ID                                               " & _
                       "     AND bill_status IN ('U', 'H')                                            " & _
                       "     AND bill_fee_type = :feetypeid                                           " & _
                       "ORDER BY bill_generate_date DESC                                              "
            End If

            Using params As New OraParameter
                params.AddItem("feetypeid", feeTypeID, OracleDbType.Int32)

                If String.IsNullOrEmpty(ID) Then
                    params.AddItem(":acctid", accountid, OracleDbType.Int32)
                Else
                    params.AddItem(":ID", ID, OracleDbType.Int32)
                End If

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Sub UpdateBillStatus(ByVal billID As String(), ByVal status As BillingStatus)
            Dim billstatus As String = String.Empty
            Select Case status
                Case BillingStatus.Cancelled
                    billstatus = "C"
                Case BillingStatus.Hold
                    billstatus = "H"
                Case BillingStatus.Unpaid
                    billstatus = "U"
            End Select
            Using params As New OraParameter
                params.AddParameter("billid", billID, OracleDbType.Varchar2, ParameterDirection.Input, True)
                params.AddParameter("billStatus", billstatus, OracleDbType.Varchar2, ParameterDirection.Input)
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
                                    "                accounts.getcustomerfullname_lfm (acct_cust_id) cust_name,                                 " & _
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


        Public MustOverride Function GetUnits() As DataTable
    End Class

    Public Class TemporaryPower
        Inherits Billing

        Public Overrides ReadOnly Property StatementDateOnly() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property ManualAmountInput() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub New(ByVal feeID As String)
            feeID = feeID
        End Sub

        Public Sub New(ByVal accountID As String, ByVal feeID As String)
            Me.AccountID = accountID
            Me.FeeID = feeID
        End Sub

        Public Overrides Sub GenerateBill()
            BillingPeriod = DateSerial(StatementDate.Year, StatementDate.Month, 1)
            DueDate = StatementDate.Date
            If InsertBill() <> 1 Then
                Throw New Exception("Bill not succesfully generated")
            End If
        End Sub

        Public Overrides Function BatchGenerateBill() As Integer
            Throw New Exception("Not Implemented")
        End Function

        Public Overrides Function GetUnits() As System.Data.DataTable
            Throw New Exception("Not Implemented")
        End Function


    End Class

    Public Class OnDemandFees
        Inherits Billing

        Public Overrides ReadOnly Property StatementDateOnly() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property ManualAmountInput() As Boolean
            Get
                Return True
            End Get
        End Property

        Private Sub New()

        End Sub

        Public Sub New(ByVal accountID As String, ByVal feeID As String)
            Me.AccountID = accountID
            Me.FeeID = feeID

        End Sub

   
        Public Overrides Sub GenerateBill()

            If InsertBill() <> 1 Then
                Throw New Exception("Bill not succesfully generated")
            End If
        End Sub

        Public Overrides Function BatchGenerateBill() As Integer
            Throw New Exception("Not Implemented")
        End Function

        Public Overrides Function GetUnits() As System.Data.DataTable
            Throw New Exception("Not Implemented")
        End Function
    End Class

End Namespace


