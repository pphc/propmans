


Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Statements
Imports System.Text

Imports BCL.Utils
Imports BCL.Common


Namespace Payments


    Public Class PaymentTypeSource
        Inherits ListSource

        Public Sub New()
            List.Add(New ItemLIst("CSH", "CASH"))
            List.Add(New ItemLIst("CHK", "CHECK"))
            List.Add(New ItemLIst("CM", "CREDIT MEMO"))
        End Sub

        Public Sub New(ByVal userGroup As Common.UserGroupType)
            List.Add(New ItemLIst("CSH", "CASH"))
            List.Add(New ItemLIst("CHK", "CHECK"))

            If userGroup = Common.UserGroupType.ADMINISTARTOR Then
                List.Add(New ItemLIst("CM", "CREDIT MEMO"))
            End If

        End Sub
    End Class

    Public Enum BillingStatus
        Unpaid
        Paid
        PartiallyPaid
        Cancelled
        Hold
    End Enum

    Public Enum PayIssueType
        System
        Manual
    End Enum

    Public Class PaymentCatSource
        Inherits ListSource
        Public Sub New()
            List.Add(New ItemLIst("REG", "REGULAR"))
            List.Add(New ItemLIst("ADV", "ADVANCE"))
        End Sub


    End Class

    Public Enum ReceiptCompany
        Utilities
        CondoCorp
    End Enum



    Public Enum CompanyDivision
        <EnumDescriptionAttribute("PHINMA PROPERTIES")> _
        <EnumDBValueAttribute("P")> _
        PPHC
        <EnumDescriptionAttribute("CONDO CORP")> _
        <EnumDBValueAttribute("C")> _
        CondoCorp
    End Enum


    Public Class BankNamesSource
        Inherits ListSource
        Public Sub New()
            For Each dr As DataRow In OraDBHelper2.GetResultSet(SelectStatement.GetBanks).Rows
                List.Add(New ItemLIst(dr("bank_id").ToString, dr("bank_name").ToString))
            Next
        End Sub
    End Class

    Public Class PaymentBilling
        Private _billID As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property BillID() As String
            Get
                Return _billID
            End Get
            Set(ByVal Value As String)
                _billID = Value
            End Set
        End Property
        Private _billPeriodDate As Nullable(Of Date) ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property BillPeriodDate() As Nullable(Of Date)
            Get
                Return _billPeriodDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _billPeriodDate = Value
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
        Private _amountDue As Decimal ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property AmountDue() As Decimal
            Get
                Return _amountDue
            End Get
            Set(ByVal Value As Decimal)
                _amountDue = Value
            End Set
        End Property
        Private _penalty As Decimal ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property Penalty() As Decimal
            Get
                Return _penalty
            End Get
            Set(ByVal Value As Decimal)
                _penalty = Value
            End Set
        End Property
        Private _balance As Decimal ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property Balance() As Decimal
            Get
                Return _balance
            End Get
            Set(ByVal Value As Decimal)
                _balance = Value
            End Set
        End Property

        Public ReadOnly Property Newbalance() As Decimal
            Get
                Return Balance - Appliedamount
            End Get
        End Property

        Private _appliedamount As Decimal ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property Appliedamount() As Decimal
            Get
                Return _appliedamount
            End Get
            Set(ByVal Value As Decimal)
                _appliedamount = Value
            End Set
        End Property

        Private _vatable As Boolean
        Public Property Vatable() As Boolean
            Get
                Return _vatable
            End Get
            Set(ByVal value As Boolean)
                _vatable = value
            End Set
        End Property
    End Class

    Public Class Payment
        Private _paymentID As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        <System.ComponentModel.Browsable(False)>
        Public Property PaymentID() As String
            Get
                Return _paymentID
            End Get
            Set(ByVal Value As String)
                _paymentID = Value
            End Set
        End Property
        Private _feetypeID As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        <System.ComponentModel.Browsable(False)>
        Public Property FeetypeID() As String
            Get
                Return _feetypeID
            End Get
            Set(ByVal Value As String)
                _feetypeID = Value
            End Set
        End Property

        Private _payCategory As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        <System.ComponentModel.Browsable(False)>
        Public Property PayCategory() As String
            Get
                Return _payCategory
            End Get
            Set(ByVal Value As String)
                _payCategory = Value
            End Set
        End Property

        <System.ComponentModel.DisplayName("UNIT NUMBER")>
        Public Property UnitNumber As String

        <System.ComponentModel.DisplayName("CUSTOMER NAME")>
        Public Property UnitOwner As String

        Private _receiptNumber As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.DisplayName("RECEIPT NUMBER")>
        Public Property ReceiptNumber() As String
            Get
                Return _receiptNumber
            End Get
            Set(ByVal Value As String)
                _receiptNumber = Value
            End Set
        End Property

        Private _receiptDate As Date ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.DisplayName("RECEIPT DATE")>
        Public Property ReceiptDate() As Date
            Get
                Return _receiptDate
            End Get
            Set(ByVal Value As Date)
                _receiptDate = Value
            End Set
        End Property

        Private _paymentType As String
        <System.ComponentModel.DisplayName("MODE OF PAYMENT")>
        Public Property PaymentType() As String
            Get
                Return _paymentType
            End Get
            Set(ByVal Value As String)
                _paymentType = Value
            End Set
        End Property


        Private _paidAmount As Decimal
        <System.ComponentModel.DisplayName("RECEIPT AMOUNT")>
        Public Property PaidAmount() As Decimal
            Get
                Return _paidAmount
            End Get
            Set(ByVal value As Decimal)
                _paidAmount = value
            End Set
        End Property

        Private _discountRate As Nullable(Of Decimal) ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property DiscountRate() As Nullable(Of Decimal)
            Get
                Return _discountRate
            End Get
            Set(ByVal Value As Nullable(Of Decimal))
                _discountRate = Value
            End Set
        End Property
        Private _discountAmount As Nullable(Of Decimal) ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                Return _discountAmount
            End Get
            Set(ByVal Value As Nullable(Of Decimal))
                _discountAmount = Value
            End Set
        End Property

        Private _checkNumber As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property CheckNumber() As String
            Get
                Return _checkNumber
            End Get
            Set(ByVal Value As String)
                _checkNumber = Value
            End Set
        End Property
        Private _checkDate As Nullable(Of Date) ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property CheckDate() As Nullable(Of Date)
            Get
                Return _checkDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _checkDate = Value
            End Set
        End Property
        Private _checkBankId As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property CheckBankId() As String
            Get
                Return _checkBankId
            End Get
            Set(ByVal Value As String)
                _checkBankId = Value
            End Set
        End Property



        Private _accountID As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property AccountID() As String
            Get
                Return _accountID
            End Get
            Set(ByVal Value As String)
                _accountID = Value
            End Set
        End Property
        <System.ComponentModel.Browsable(False)>
        Public Property LeaseID As String

        Private _status As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.DisplayName("STATUS")>
        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal Value As String)
                _status = Value
            End Set
        End Property

        Private _remarks As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property Remarks() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
            End Set
        End Property

        Private _issuedBy As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property IssuedBy() As String
            Get
                Return _issuedBy
            End Get
            Set(ByVal Value As String)
                _issuedBy = Value
            End Set
        End Property
        Private _issuedDateTime As DateTime ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        <System.ComponentModel.Browsable(False)>
        Public Property IssuedDateTime() As DateTime
            Get
                Return _issuedDateTime
            End Get
            Set(ByVal Value As DateTime)
                _issuedDateTime = Value
            End Set
        End Property
        Private _issueType As PayIssueType ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property IssueType() As PayIssueType
            Get
                Return _issueType
            End Get
            Set(ByVal Value As PayIssueType)
                _issueType = Value
            End Set
        End Property

        Private _payCompany As ReceiptCompany ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property PayCompany() As ReceiptCompany
            Get
                Return _payCompany
            End Get
            Set(ByVal Value As ReceiptCompany)
                _payCompany = Value
            End Set
        End Property

        Private _depositDate As Date ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property DepositDate() As Date
            Get
                Return _depositDate
            End Get
            Set(ByVal Value As Date)
                _depositDate = Value
            End Set
        End Property
        Private _depositoryAccount As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property DepositoryAccount() As String
            Get
                Return _depositoryAccount
            End Get
            Set(ByVal Value As String)
                _depositoryAccount = Value
            End Set
        End Property

        Private _isDeposited As Boolean ' ENCAPSULATE FIELD BY CODEIT.RIGHT
        <System.ComponentModel.Browsable(False)>
        Public Property IsDeposited() As Boolean
            Get
                Return _isDeposited
            End Get
            Set(ByVal Value As Boolean)
                _isDeposited = Value
            End Set
        End Property


        <System.ComponentModel.Browsable(False)>
        Public Property CancelledRemarks As String

        <System.ComponentModel.Browsable(False)>
        Public Property ChangeRemarks As String

        Public Property ManualReason As String

        Public Property CheckID As String
        Public Property BankBranchID As String

        Public Shared Function Insertpayment(ByVal trans As Payment) As String
            Using params As New OraParameter
                With trans
                    params.AddItem("feetypeid", .FeetypeID, ParameterDirection.Input, OracleDbType.Int32)

                    params.AddItem("paycategory", .PayCategory, ParameterDirection.Input, OracleDbType.Varchar2)
                    params.AddItem("paymenttype", .PaymentType, ParameterDirection.Input, OracleDbType.Varchar2)

                    params.AddItem("paidamount", .PaidAmount, ParameterDirection.Input, OracleDbType.Decimal)
                    If .DiscountRate.HasValue Then
                        params.AddItem("discountrate", .DiscountRate.Value, ParameterDirection.Input, OracleDbType.Decimal)
                    Else
                        params.AddItem("discountrate", "", ParameterDirection.Input, OracleDbType.Decimal, True)
                    End If

                    If .DiscountAmount.HasValue Then
                        params.AddItem("discountamount", .DiscountAmount.Value, ParameterDirection.Input, OracleDbType.Decimal)
                    Else
                        params.AddItem("discountamount", "", ParameterDirection.Input, OracleDbType.Decimal, True)
                    End If

                    If Not String.IsNullOrEmpty(.CheckNumber) Then
                        params.AddItem("checknumber", .CheckNumber, ParameterDirection.Input, OracleDbType.Varchar2)
                    Else
                        params.AddItem("checknumber", "", ParameterDirection.Input, OracleDbType.Varchar2, True)
                    End If

                    If .CheckDate.HasValue Then
                        params.AddItem("checkdate", .CheckDate.Value, ParameterDirection.Input, OracleDbType.Date)
                    Else
                        params.AddItem("checkdate", "", ParameterDirection.Input, OracleDbType.Date, True)
                    End If



                    If Not String.IsNullOrEmpty(.ReceiptNumber) Then
                        params.AddItem("ornumber", .ReceiptNumber, ParameterDirection.Input, OracleDbType.Varchar2)
                    Else
                        params.AddItem("ornumber", "", ParameterDirection.Input, OracleDbType.Varchar2, True)
                    End If

                    If Not String.IsNullOrEmpty(.CheckBankId) Then
                        params.AddItem("bankid", .CheckBankId, ParameterDirection.Input, OracleDbType.Int32)
                    Else
                        params.AddItem("bankid", "", ParameterDirection.Input, OracleDbType.Int32, True)
                    End If

                    If Not String.IsNullOrEmpty(.BankBranchID) Then
                        params.AddItem("bankbranchid", .BankBranchID, ParameterDirection.Input, OracleDbType.Int32)
                    End If


                    If Not String.IsNullOrEmpty(.Remarks) Then
                        params.AddItem("payremarks", .Remarks, ParameterDirection.Input, OracleDbType.Varchar2)
                    Else
                        params.AddItem("payremarks", "", ParameterDirection.Input, OracleDbType.Varchar2, True)
                    End If

                    If .IssueType = PayIssueType.System Then
                        params.AddItem("payissuetype", "S", ParameterDirection.Input, OracleDbType.Varchar2)
                    Else
                        params.AddItem("payissuetype", "M", ParameterDirection.Input, OracleDbType.Varchar2)
                        params.AddItem("manualreason", .ManualReason, ParameterDirection.Input, OracleDbType.Varchar2)
                    End If

                    params.AddItem("paymentdate", .ReceiptDate, ParameterDirection.Input, OracleDbType.Date)
                    params.AddItem("acctid", .AccountID, ParameterDirection.Input, OracleDbType.Int32)

                    If Not String.IsNullOrEmpty(trans.LeaseID) Then
                        params.AddItem("leaseid", .LeaseID, ParameterDirection.Input, OracleDbType.Int32)
                    End If

                    If Not String.IsNullOrEmpty(trans.CheckID) Then
                        params.AddItem("checkid", .CheckID, ParameterDirection.Input, OracleDbType.Int32)
                    End If

                    params.AddItem("paymentid", "", ParameterDirection.ReturnValue, OracleDbType.Varchar2, False, 30)
                End With
                Try
                    Return OraDBHelper2.ExecuteFunction("insertnewpayment", params.GetParameterCollection).ToString
                Catch ex As Exception
                    Throw ex
                End Try

            End Using

        End Function

        Public Shared Sub InsertPayTransactions(ByVal billID As String, ByVal paymentID As String, ByVal appliedAmt As Decimal, ByVal penaltyAmt As Decimal)

            Using params As New OraParameter
                params.AddItem(":billid", billID, OracleDbType.Varchar2)
                params.AddItem(":paymentid", paymentID, OracleDbType.Varchar2)
                params.AddItem(":appliedamt", appliedAmt, OracleDbType.Decimal)
                params.AddItem(":penaltyamt", penaltyAmt, OracleDbType.Decimal)

                OraDBHelper2.SqlExecute(InsertStatement.NewPayTransaction, params.GetParameterCollection)
            End Using
        End Sub

        Public Shared Function UpdateBillAmountpaid(ByVal billID As String, ByVal amountpaid As Decimal) As Integer
            Using params As New OraParameter
                params.AddItem(":amountpaid", amountpaid, OracleDbType.Decimal)
                params.AddItem(":billid", billID, OracleDbType.Varchar2)

                Return OraDBHelper2.SqlExecute(UpdateStatement.UpdatebillAmountPaid, params.GetParameterCollection)
            End Using
        End Function

        Public Shared Function GetPayments(ByVal accountID As String) As DataTable
            Using params As New OraParameter
                params.AddItem(":acctid", accountID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(SelectStatement.GetPayments, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetFeeVatInfo(ByVal feeid As String) As DataTable
            Using params As New OraParameter
                params.AddItem(":feeid", feeid, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(SelectStatement.GetFeeVatInfo, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetCurrentReceiptNo(ByVal feeid As String) As String
            Using params As New OraParameter
                'params.AddItem("feeid", feeid, ParameterDirection.Input, OracleDbType.Int32)
                'params.AddItem("nextor", "", ParameterDirection.ReturnValue, OracleDbType.Varchar2, False, 100)

                params.AddParameter("feeid", feeid, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("nextor", "", OracleDbType.Varchar2, ParameterDirection.ReturnValue)

                Return OraDBHelper2.ExecuteFunction("getnextreceiptno", params.GetParameterCollection).ToString
                'Return DirectCast(OraDBHelper2.FunctionExecute("getnextreceiptno", params.getParameterCollection), OracleString).ToString
            End Using
        End Function

        Public Shared Sub UpdateCurrentReceipt(ByVal receiptNo As String, ByVal feeID As String)

            Using params As New OraParameter
                params.AddItem("receiptno", receiptNo, ParameterDirection.Input, OracleDbType.Varchar2)
                params.AddItem("feeid", feeID, ParameterDirection.Input, OracleDbType.Int32)
                OraDBHelper2.ExecuteProcedureforInput("UPDATERECEIPTNO", params.GetParameterCollection)
            End Using

        End Sub


        Public Shared Function GetReceiptInfo(ByVal receiptnumber As String, ByVal type As ReceiptCompany) As IList(Of Payment)

            Dim query As String = "SELECT payment_id,or_number, pay_fee_type, paid_amount, payment_date, pay_category,    " & _
                                    "       payment_type, check_number, check_date, pay_bank_id, or_status,      " & _
                                    "       pay_acct_id, created_by, created_date,pay_deposit_id,cancellation_remarks, change_remarks,                               " & _
                                    "                     accounts.getunitnumber(pay_acct_id) unit_no,            " & _
                                    "       accounts.getcustomerfullname_lfm ((SELECT acct_cust_id                              " & _
                                    "                               FROM customer_accounts                         " & _
                                    "                              WHERE account_id = ps.pay_acct_id)) unit_owner  " & _
                                    "  FROM payments ps                                                            " & _
                                    " WHERE pay_company = :receipttype AND or_number = LPAD (:receiptno, 7, '0') "


            Using params As New OraParameter
                Dim ortype As String

                If type = ReceiptCompany.Utilities Then
                    ortype = "P"
                Else
                    ortype = "C"
                End If

                params.AddParameter("receiptno", receiptnumber, OracleDbType.Varchar2, ParameterDirection.Input)
                params.AddParameter("receipttype", ortype, OracleDbType.Varchar2, ParameterDirection.Input)
                'params.AddParameter("refcursor1", DBNull.Value, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                Using dt As DataTable = OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    Dim pays As New List(Of Payment)

                    If dt Is Nothing Then
                        Return pays
                    End If
                    If dt.Rows.Count > 0 Then
                        For Each rw As DataRow In dt.Rows
                            Dim ps As New Payment
                            ps.UnitNumber = rw.Item("unit_no").ToString
                            ps.UnitOwner = rw.Item("unit_owner").ToString
                            ps.PaymentID = rw.Item("payment_id").ToString
                            ps.ReceiptNumber = rw.Item("or_number").ToString
                            ps.FeetypeID = rw.Item("pay_fee_type").ToString
                            ps.PaidAmount = Decimal.Parse(rw.Item("paid_amount"))
                            ps.ReceiptDate = Date.Parse(rw.Item("payment_date"))
                            ps.PayCategory = rw.Item("pay_category").ToString
                            ps.PaymentType = rw.Item("payment_type").ToString
                            If ps.PaymentType = "CHK" Then
                                ps.CheckNumber = rw.Item("check_number").ToString
                                ps.CheckDate = Date.Parse(rw.Item("check_date"))
                                ps.CheckBankId = rw.Item("pay_bank_id").ToString

                            End If

                            ps.Status = rw.Item("or_status").ToString
                            ps.AccountID = rw.Item("pay_acct_id").ToString
                            ps.IssuedBy = rw.Item("created_by").ToString
                            ps.IssuedDateTime = DateTime.Parse(rw.Item("created_date"))

                            If Convert.IsDBNull(rw.Item("pay_deposit_id")) Then
                                ps.IsDeposited = False
                            Else
                                ps.IsDeposited = True
                            End If

                            ps.CancelledRemarks = rw.Item("cancellation_remarks").ToString
                            ps.ChangeRemarks = rw.Item("change_remarks").ToString

                            pays.Add(ps)
                        Next

                        Return pays
                    Else
                        Return pays
                    End If
                End Using


            End Using
        End Function

        Public Shared Sub CancelPayment(ByVal paymentID As String, cancelRemarks As String)

            Dim query As String = "  UPDATE payments          " & _
                                "   SET or_status = 'CAN', cancellation_remarks = :cancelremarks " & _
                                " WHERE payment_id = :payid "


            Using params As New OraParameter
                params.AddParameter("payid", paymentID, OracleDbType.Varchar2, ParameterDirection.Input)
                params.AddParameter("cancelremarks", cancelRemarks, OracleDbType.Varchar2, ParameterDirection.Input)
                OraDBHelper2.SqlExecute(query, params.GetParameterCollection)
            End Using


        End Sub

        Public Shared Sub UpdateReceiptInfo(ByVal info As Payment)


            Dim query As String = "UPDATE payments                    " & _
                               "   SET payment_date = :paymentdate, " & _
                               "       payment_type = :paymenttype, " & _
                               "       check_number = :checknumber, " & _
                               "       check_date = :checkdate,     " & _
                               "       pay_bank_id = :checkbank,    " & _
                               "       change_remarks = :changeremarks    " & _
                               " WHERE payment_id = :paymentid         "


            Using params As New OraParameter
                params.AddParameter("paymentid", info.PaymentID, OracleDbType.Varchar2, ParameterDirection.Input)
                params.AddParameter("paymentdate", info.ReceiptDate, OracleDbType.Date, ParameterDirection.Input)
                params.AddParameter("paymenttype", info.PaymentType, OracleDbType.Varchar2, ParameterDirection.Input)
                If info.PaymentType = "CSH" Then
                    params.AddParameter("checknumber", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("checkdate", DBNull.Value, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("checkbank", DBNull.Value, OracleDbType.Int32, ParameterDirection.Input)
                Else
                    params.AddParameter("checknumber", info.CheckNumber, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("checkdate", info.CheckDate.Value, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("checkbank", info.CheckBankId, OracleDbType.Int32, ParameterDirection.Input)
                End If
                params.AddParameter("changeremarks", info.ChangeRemarks, OracleDbType.Varchar2, ParameterDirection.Input)
                OraDBHelper2.SqlExecute(query, params.GetParameterCollection)
            End Using

        End Sub

        Public Shared Sub InsertCancelledReceipt(ByVal payinfo As Payment)
            Dim query As String = "INSERT INTO payments                                                          " & _
                                    "            (pay_fee_type, payment_type, paid_amount, pay_category,           " & _
                                    "             or_number, or_status, payment_date, pay_acct_id, pay_issue_type, " & _
                                    "             pay_company,cancellation_remarks                                                      " & _
                                    "            )                                                                 " & _
                                    "     VALUES (:payfeetype, :paymenttype, :paidamount, :paycategory,            " & _
                                    "             :ornumber, :orstatus, :paymentdate, :payacctid, :payissuetype,   " & _
                                    "             :paycompany,:cancelremarks                                                      " & _
                                    "            )                                                                 "

            Using params As New OraParameter
                With payinfo
                    params.AddParameter("payfeetype", .FeetypeID, OracleDbType.Int32)
                    params.AddParameter("paymenttype", .PaymentType, OracleDbType.Varchar2)
                    params.AddParameter("paidamount", .PaidAmount, OracleDbType.Decimal)
                    params.AddParameter("paycategory", .PayCategory, OracleDbType.Varchar2)
                    params.AddParameter("ornumber", .ReceiptNumber, OracleDbType.Varchar2)
                    params.AddParameter("orstatus", .Status, OracleDbType.Varchar2)
                    params.AddParameter("paymentdate", .ReceiptDate, OracleDbType.Date)
                    params.AddParameter("payacctid", .AccountID, OracleDbType.Int32)
                    params.AddParameter("payissuetype", "M", OracleDbType.Varchar2)
                    If .PayCompany = ReceiptCompany.Utilities Then
                        params.AddParameter("paycompany", "P", OracleDbType.Varchar2)
                    Else
                        params.AddParameter("paycompany", "C", OracleDbType.Varchar2)
                    End If
                    params.AddParameter("cancelremarks", .CancelledRemarks, OracleDbType.Varchar2)

                End With

                OraDBHelper2.SqlExecute(query, params.GetParameterCollection)
            End Using

        End Sub

        Public Shared Function IsORinInventory(ByVal ornumber As String, ByVal feeid As String) As Boolean
            Dim query As String = "SELECT COUNT (batch_id)                                 " & _
                                "  FROM or_inventory                                     " & _
                                " WHERE company = (SELECT fee_company                    " & _
                                "                    FROM ref_fee_types                  " & _
                                "                   WHERE fee_type_id = :feeid)          " & _
                                "   AND TO_NUMBER (start_number) <= TO_NUMBER (:ornumber)" & _
                                "   AND TO_NUMBER (end_number) >= TO_NUMBER (:ornumber) "


            Using params As New OraParameter
                params.AddParameter("ornumber", ornumber)
                params.AddParameter("feeid", feeid)

                If Integer.Parse(OraDBHelper2.SqlExecuteScalar(query, params.GetParameterCollection)) = 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using

        End Function


    End Class

    Public Class ReceiptInfo
        Inherits Payment

        Private _payeeUnit As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property PayeeUnit() As String
            Get
                Return _payeeUnit
            End Get
            Set(ByVal Value As String)
                _payeeUnit = Value
            End Set
        End Property
        Private _payeeName As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property PayeeName() As String
            Get
                Return _payeeName
            End Get
            Set(ByVal Value As String)
                _payeeName = Value
            End Set
        End Property

        Private _feeName As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property FeeName() As String
            Get
                Return _feeName
            End Get
            Set(ByVal Value As String)
                _feeName = Value
            End Set
        End Property
        Private _checkBank As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property CheckBank() As String
            Get
                Return _checkBank
            End Get
            Set(ByVal Value As String)
                _checkBank = Value
            End Set
        End Property

        Public Overloads Shared Function GetReceiptInfo1(ByVal receiptNumber As String, ByVal corporationName As String) As ReceiptInfo

            Using params As New OraParameter
                params.AddItem(":receiptNumber", receiptNumber)
                params.AddItem(":corporation", corporationName)

                With OraDBHelper2.GetResultSet(SelectStatement.GetReceiptDetails, params.GetParameterCollection)
                    If .Rows.Count = 0 Then
                        Return Nothing
                    Else
                        Dim rcpt As New ReceiptInfo
                        rcpt.PaymentID = .Rows(0)("payment_id").ToString
                        rcpt.ReceiptNumber = receiptNumber.PadLeft(6, "0")
                        rcpt.ReceiptDate = Date.Parse(.Rows(0)("payment_date"))
                        rcpt.PaidAmount = Decimal.Parse(.Rows(0)("paid_amount"))
                        rcpt.IssuedBy = .Rows(0)("created_by").ToString
                        rcpt.IssuedDateTime = Date.Parse(.Rows(0)("created_date"))
                        If .Rows(0)("pay_issue_type").ToString = "S" Then
                            rcpt.IssueType = PayIssueType.System
                        Else
                            rcpt.IssueType = PayIssueType.Manual
                        End If

                        rcpt.PaymentType = .Rows(0)("payment_type").ToString
                        rcpt.PayCategory = .Rows(0)("pay_category").ToString
                        rcpt.Remarks = .Rows(0)("pay_remarks").ToString

                        If rcpt.PaymentType = "CHK" Then
                            rcpt.CheckNumber = .Rows(0)("check_number").ToString
                            rcpt.CheckDate = Date.Parse(.Rows(0)("check_date"))
                            rcpt.CheckBank = .Rows(0)("check_bank").ToString
                        End If

                        rcpt.FeeName = .Rows(0)("fee_name").ToString

                        If Not Convert.IsDBNull(.Rows(0)("discount_rate")) Then
                            rcpt.DiscountRate = Decimal.Parse(.Rows(0)("discount_rate"))
                            rcpt.DiscountAmount = Decimal.Parse(.Rows(0)("discount_amt"))
                        End If

                        rcpt.PayeeUnit = .Rows(0)("unit_no").ToString()
                        rcpt.PayeeName = .Rows(0)("owner").ToString()


                        rcpt.Status = .Rows(0)("or_status").ToString()

                        If Not Convert.IsDBNull(.Rows(0)("deposit_date")) Then
                            rcpt.DepositDate = Date.Parse(.Rows(0)("deposit_date"))
                            rcpt.DepositoryAccount = .Rows(0)("deposit_bank").ToString
                        End If

                        Return rcpt
                    End If

                End With
            End Using
        End Function

        Public Shared Function GetReceiptInvoices(ByVal paymentID As String) As DataTable
            Using params As New OraParameter
                params.AddItem(":payid", paymentID)

                Return OraDBHelper2.GetResultSet(SelectStatement.GetReceiptInvoces, params.GetParameterCollection)
            End Using




        End Function
    End Class

    Public NotInheritable Class Invoices
        Public Shared Function GetUnpaidBills(ByVal accountID As String, ByVal feeCode As String) As DataTable
            Dim query As String = "SELECT   bill_id, (SELECT fee_description                                      " & _
                            "                     FROM ref_fee_types                                        " & _
                            "                    WHERE fee_type_id = bc.bill_fee_type) fee_name, bill_date, " & _
                            "         bill_generate_date, bill_due_date, amount_due, penalty_amt, balance,  " & _
                            "         DECODE (bill_status,                                                  " & _
                            "                 'U', 'UNPAID',                                                " & _
                            "                 'P', 'PARTIALLY PAID',                                        " & _
                            "                 'N/A/'                                                        " & _
                            "                ) status,                                                      " & _
                            "         NVL(w_vat,'N') vatable          " & _
                            "    FROM billing_charges bc                                                    " & _
                            "   WHERE bill_cust_id = :acctid  AND lease_id is null                          " & _
                            "     AND bill_status <> 'F'                                                    " & _
                            "     AND bill_fee_type = :feecode                                              " & _
                            "     AND bill_status <> 'C'                                                    " & _
                            "ORDER BY bill_date                                                             "

            Using params As New OraParameter
                params.AddItem(":acctid", accountID, OracleDbType.Int32)
                params.AddItem(":feecOde", feeCode, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetUnpaidBills(ByVal accountID As String, ID As String, ByVal feeCode As String) As DataTable
            Dim query As String = "SELECT   bill_id, (SELECT fee_description                                      " & _
                            "                     FROM ref_fee_types                                        " & _
                            "                    WHERE fee_type_id = bc.bill_fee_type) fee_name, bill_date, " & _
                            "         bill_generate_date, bill_due_date, amount_due, penalty_amt, balance,  " & _
                            "         DECODE (bill_status,                                                  " & _
                            "                 'U', 'UNPAID',                                                " & _
                            "                 'P', 'PARTIALLY PAID',                                        " & _
                            "                 'N/A/'                                                        " & _
                            "                ) status,                                                      " & _
                            "         NVL(w_vat,'N') vatable          " & _
                            "    FROM billing_charges bc                                                    " & _
                            "   WHERE (bill_cust_id = :acctid  and lease_id = :ID)                        " & _
                            "     AND bill_status <> 'F'                                                    " & _
                            "     AND bill_fee_type = :feecode                                              " & _
                            "     AND bill_status <> 'C'                                                    " & _
                            "ORDER BY bill_date                                                             "

            Using params As New OraParameter
                params.AddItem(":acctid", accountID, OracleDbType.Int32)
                params.AddItem(":ID", ID, OracleDbType.Int32)
                params.AddItem(":feecOde", feeCode, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function


        Public Shared Function GetAllBills(ByVal accountID As String, ByVal ID As String, ByVal feeCode As String) As DataTable
            Dim query As String

            If String.IsNullOrEmpty(ID) Then
                query = "SELECT bill_id, (SELECT fee_description                                     " & _
                    "                   FROM ref_fee_types                                       " & _
                    "                  WHERE fee_type_id = bc.bill_fee_type) fee_name, bill_date," & _
                    "       bill_generate_date,bill_due_date, amount_due, penalty_amt, balance, " & _
                    "       DECODE (bill_status,                                                 " & _
                    "               'U', 'UNPAID',                                               " & _
                    "               'P', 'PARTIALLY PAID'," & _
                    "               'F', 'FULLY PAID',    " & _
                    "               'N/A/'                                                       " & _
                    "              ) status                                                      " & _
                    "  FROM billing_charges bc                                                   " & _
                    " WHERE bill_cust_id = :acctid  and lease_id is null                       " & _
                    "   AND bill_fee_type = :feecode      " & _
                    "   AND bill_status <> 'C' " & _
                    " ORDER BY bill_date "
            Else
                query = "SELECT bill_id, (SELECT fee_description                                     " & _
                                "                   FROM ref_fee_types                                       " & _
                                "                  WHERE fee_type_id = bc.bill_fee_type) fee_name, bill_date," & _
                                "       bill_generate_date,bill_due_date, amount_due, penalty_amt, balance, " & _
                                "       DECODE (bill_status,                                                 " & _
                                "               'U', 'UNPAID',                                               " & _
                                "               'P', 'PARTIALLY PAID'," & _
                                "               'F', 'FULLY PAID',    " & _
                                "               'N/A/'                                                       " & _
                                "              ) status                                                      " & _
                                "  FROM billing_charges bc                                                   " & _
                                " WHERE lease_id = :ID                        " & _
                                "   AND bill_fee_type = :feecode      " & _
                                "   AND bill_status <> 'C' " & _
                                " ORDER BY bill_date "
            End If



            Using params As New OraParameter

                params.AddItem(":feecOde", feeCode, OracleDbType.Int32)
                If String.IsNullOrEmpty(ID) Then
                    params.AddItem("acctid", accountID, OracleDbType.Int32)
                Else
                    params.AddItem("ID", ID, OracleDbType.Int32)
                End If

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function
    End Class

    Public Class Banks
        Private _bankID As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property BankID() As String
            Get
                Return _bankID
            End Get
            Set(ByVal Value As String)
                _bankID = Value
            End Set
        End Property
        Private _bankCode As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property BankCode() As String
            Get
                Return _bankCode
            End Get
            Set(ByVal Value As String)
                _bankCode = Value
            End Set
        End Property
        Private _bankName As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

        Public Property BankName() As String
            Get
                Return _bankName
            End Get
            Set(ByVal Value As String)
                _bankName = Value
            End Set
        End Property

        Private Sub New()

        End Sub

        Public Shared Function GetBankCode(ByVal bankID As String) As String
            Dim bank As New Banks

            bank.BankID = bankID
            bank.LoadDetails()


            Return bank.BankCode
        End Function

        Private Sub LoadDetails()
            Using params As New OraParameter
                params.AddItem(":bankid", BankID, OracleDbType.Int32)

                With OraDBHelper2.GetResultSet(SelectStatement.GetbankInfo, params.GetParameterCollection)
                    BankCode = .Rows(0)("bank_code").ToString
                    BankName = .Rows(0)("bank_name").ToString
                End With


            End Using
        End Sub

    End Class

End Namespace