Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common

Public Class PaymentApplicationHistory
    Inherits ReportBase


    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "PAYMENT APPLICATION HISTORY"
        End Get
    End Property


    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
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

    Private _feeTypeID As String
    Public Property FeeTypeID() As String
        Get
            Return _feeTypeID
        End Get
        Set(ByVal value As String)
            _feeTypeID = value
        End Set
    End Property

    Private _unitNumber As String
    Public Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
        Set(ByVal value As String)
            _unitNumber = value
        End Set
    End Property

    Private _buyerName As String
    Public Property BuyerName() As String
        Get
            Return _buyerName
        End Get
        Set(ByVal value As String)
            _buyerName = value
        End Set
    End Property

    Private _feetypeName As String
    Public Property FeeTypeName() As String
        Get
            Return _feetypeName
        End Get
        Set(ByVal value As String)
            _feetypeName = value
        End Set
    End Property
    Private _cutOffDate As Date
    Public Property CutOffDate() As Date
        Get
            Return _cutOffDate
        End Get
        Set(ByVal value As Date)
            _cutOffDate = value
        End Set
    End Property

    Private dtTemp As CollectionsDataSet.PayApplicationHistoryDataTable
    Private dtBills As DataTable
    Private dtPayments As DataTable
    Private dtPayApplication As DataTable


    Private runningBalance As Decimal = 0
    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()

        dtBills = GetBillingsByCutOff()
        dtPayments = GetPaymentsByCutOff()

        If dtBills.Rows.Count = 0 And dtPayments.Rows.Count = 0 Then
            Throw New Exception("No Transactions as of cutoff date")
            Return
        End If

        dtPayApplication = GetPaymentsApplication()

        dtTemp = New CollectionsDataSet.PayApplicationHistoryDataTable


        For Each billrow As DataRow In dtBills.Rows
            Dim billID As String = billrow("bill_id").ToString
            Dim billMOnth As Date = Date.Parse(billrow("billing_month").ToString)
            Dim statementDate As Date = Date.Parse(billrow("statement_date").ToString)
            Dim principalAmt As Decimal = Decimal.Parse(billrow("principal").ToString)
            Dim penaltyAmt As Decimal = Decimal.Parse(billrow("penalty_amt").ToString)

            If isBillhasPayments(billID) Then

                Dim bFirstHeader As Boolean = False

                For Each prow As DataRow In Getpayments(billID)

                    Dim refNo As String = prow("ornumber").ToString
                    Dim refDate As Date = Date.Parse(prow("paymentdate").ToString)
                    Dim appliedPrincipal As Decimal
                    Dim appliedPenalty As Decimal

                    Decimal.TryParse(prow("applied_amt").ToString, appliedPrincipal)
                    Decimal.TryParse(prow("penalty_amt").ToString, appliedPenalty)

                    Dim billBalance As Decimal
                    If Not bFirstHeader Then
                        billBalance = AddTempRow(billMOnth, statementDate, principalAmt, penaltyAmt, _
                                    refNo, refDate, appliedPrincipal, appliedPenalty)
                        bFirstHeader = True
                    Else
                        AddTempRow(billBalance, refNo, refDate, appliedPrincipal, appliedPenalty)
                    End If
                Next
            Else
                AddTempRow(billMOnth, statementDate, principalAmt, penaltyAmt)
            End If

        Next

        ReportDoc = New rptPaymentApplication

        ReportDoc.SetDataSource(DirectCast(dtTemp, DataTable))

        dtTemp.Dispose()
        dtBills.Dispose()
        dtPayments.Dispose()
        dtPayApplication.Dispose()

    End Sub

    Public Overrides Sub BindItems()

        With ReportDoc.ReportDefinition.Sections("SecReportHeader")

            DirectCast(.ReportObjects("txtProjectName"), TextObject).Text = Defaults.SiteName & " PROJECT"
            DirectCast(.ReportObjects("txtAccountName"), TextObject).Text = UnitNumber & " - " & BuyerName
            DirectCast(.ReportObjects("txtFeeType"), TextObject).Text = FeeTypeName
            DirectCast(.ReportObjects("txtCutOff"), TextObject).Text = "AS OF " & CutOffDate.ToString("MMMM dd, yyyy")
            DirectCast(.ReportObjects("txtBillingStaffName"), TextObject).Text = GlobalReference.CurrentUser.UserFullName
            DirectCast(.ReportObjects("txtPropertyAdminName"), TextObject).Text = Defaults.SitePropertyAdmin
            'TODO move to other class OraConnection.Instance.UserID
            DirectCast(.ReportObjects("txtUsername"), TextObject).Text = OraConnection.Instance.UserID

        End With
    End Sub

    Private Function isBillhasPayments(ByVal billID As String) As Boolean
        Dim cnt As Integer = Integer.Parse(dtPayApplication.Compute("COUNT(payment_id)", "bill_id='" & billID & "'").ToString)

        If cnt > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function Getpayments(ByVal billId As String) As DataRow()

        Return dtPayApplication.Select("bill_id ='" & billId & "'", "paymentdate,ornumber")

    End Function

    Private Sub AddTempRow(ByVal billmonth As Date, ByVal statementDate As Date, ByVal principalAmt As Decimal, ByVal penaltyAmt As Decimal)
        Dim newRow As CollectionsDataSet.PayApplicationHistoryRow = dtTemp.NewPayApplicationHistoryRow

        newRow.BILL_MONTH = billmonth.ToString("MMM yyyy").ToUpper
        newRow.STATEMENT_DATE = statementDate
        newRow.BILL_PRINCIPAL = principalAmt
        newRow.BILL_PENALTY = penaltyAmt
        newRow.BILL_TOTAL = principalAmt + penaltyAmt
        newRow.BILL_BALANCE = principalAmt + penaltyAmt

        runningBalance += principalAmt + penaltyAmt
        newRow.RUNNING_BALANCE = runningBalance

        dtTemp.Rows.Add(newRow)
    End Sub

    Private Function AddTempRow(ByVal billmonth As Date, ByVal statementDate As Date, _
                ByVal principalAmt As Decimal, ByVal penaltyAmt As Decimal, _
                ByVal refNo As String, ByVal refDate As Date, _
                ByVal principalapplied As Decimal, ByVal penaltyApplied As Decimal) As Decimal

        Dim newRow As CollectionsDataSet.PayApplicationHistoryRow = dtTemp.NewPayApplicationHistoryRow

        newRow.BILL_MONTH = billmonth.ToString("MMM yyyy").ToUpper
        newRow.STATEMENT_DATE = statementDate
        newRow.BILL_PRINCIPAL = principalAmt
        newRow.BILL_PENALTY = penaltyAmt
        newRow.BILL_TOTAL = principalAmt + penaltyAmt

        newRow.PAY_REFNO = refNo
        newRow.PAY_REFDATE = refDate
        newRow.PAY_PRINCIPAL = principalapplied
        newRow.PAY_PENALTY = penaltyApplied

        Dim AppliedAmt As Decimal = principalapplied + penaltyApplied
        newRow.PAY_TOTAL = AppliedAmt

        newRow.BILL_BALANCE = (principalAmt + penaltyAmt) - AppliedAmt

        runningBalance += (principalAmt + penaltyAmt) - AppliedAmt
        newRow.RUNNING_BALANCE = runningBalance

        dtTemp.Rows.Add(newRow)

        Return (principalAmt + penaltyAmt) - AppliedAmt
    End Function

    Private Function AddTempRow(ByVal amountDue As Decimal, _
             ByVal refNo As String, ByVal refDate As Date, _
             ByVal principalapplied As Decimal, ByVal penaltyApplied As Decimal) As Decimal

        Dim newRow As CollectionsDataSet.PayApplicationHistoryRow = dtTemp.NewPayApplicationHistoryRow

        newRow.PAY_REFNO = refNo
        newRow.PAY_REFDATE = refDate
        newRow.PAY_PRINCIPAL = principalapplied
        newRow.PAY_PENALTY = penaltyApplied

        Dim AppliedAmt As Decimal = principalapplied + penaltyApplied
        newRow.PAY_TOTAL = AppliedAmt

        newRow.BILL_BALANCE = amountDue - AppliedAmt

        runningBalance -= AppliedAmt
        newRow.RUNNING_BALANCE = runningBalance

        dtTemp.Rows.Add(newRow)

        Return amountDue - AppliedAmt
    End Function


    Private Function GetBillingsByCutOff() As DataTable
        'load Billing by Period
        Using params As New OraParameter
            params.AddItem("acctid", AccountID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("feetypeID", FeeTypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("cutoff", CutOffDate, Oracle.DataAccess.Client.OracleDbType.Date)

            Dim qry As String = "SELECT   bill_id, bill_date billing_month, bill_generate_date statement_date," & _
                                "         amount_due principal, penalty_amt,bill_status                       " & _
                                "    FROM billing_charges                                                     " & _
                                "   WHERE bill_fee_type = :feetypeID                                          " & _
                                "     AND bill_cust_id = :acctid                                              " & _
                                "     AND bill_generate_date <= :cutoff                                       " & _
                                "     AND bill_status <> 'C'                                                  " & _
                                "ORDER BY bill_date                                                           "


            Return OraDBHelper2.GetResultSet(qry, params.GetParameterCollection)

        End Using
    End Function

    Private Function GetPaymentsApplication() As DataTable

        Using params As New OraParameter
            params.AddItem("acctid", AccountID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("feetypeID", FeeTypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("cutoff", CutOffDate, Oracle.DataAccess.Client.OracleDbType.Date)

            Dim qry As String = "SELECT bill_id, payment_id, applied_amt, penalty_amt,  " & _
                                "       (SELECT or_number                               " & _
                                "          FROM payments                                " & _
                                "         WHERE payment_id = ps.payment_id) ornumber,   " & _
                                "       (SELECT payment_date                            " & _
                                "          FROM payments                                " & _
                                "         WHERE payment_id = ps.payment_id) paymentdate " & _
                                "  FROM pay_transactions ps                             " & _
                                " WHERE bill_id IN (                                    " & _
                                "          SELECT bill_id                               " & _
                                "            FROM billing_charges                       " & _
                                "           WHERE bill_fee_type = :feetypeid            " & _
                                "             AND bill_cust_id = :acctid                " & _
                                "             AND bill_generate_date <= :cutoff)        " & _
                                "   AND payment_id IN (                                 " & _
                                "          SELECT payment_id                            " & _
                                "            FROM payments                              " & _
                                "           WHERE pay_acct_id = :acctid                 " & _
                                "             AND pay_fee_type = :feetypeid             " & _
                                "             AND payment_date <= :cutoff               " & _
                                "             AND or_status = 'ISSD')                   "

            Return OraDBHelper2.GetResultSet(qry, params.GetParameterCollection)

        End Using
    End Function

    Private Function GetPaymentsByCutOff() As DataTable

        Using params As New OraParameter
            params.AddItem("acctid", AccountID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("feetypeID", FeeTypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("cutoff", CutOffDate, Oracle.DataAccess.Client.OracleDbType.Date)

            Dim qry As String = "SELECT payment_id, pay_category, paid_amount, discount_amt, pay_balance," & _
                                "       or_number, payment_date                                          " & _
                                "  FROM payments                                                         " & _
                                " WHERE pay_acct_id = :acctid                                            " & _
                                "   AND pay_fee_type = :feetypeid                                        " & _
                                "   AND payment_date <= :cutoff                                          " & _
                                "   AND or_status = 'ISSD'                                               "

            Return OraDBHelper2.GetResultSet(qry, params.GetParameterCollection)

        End Using
    End Function



End Class
