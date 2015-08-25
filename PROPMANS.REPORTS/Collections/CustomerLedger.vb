Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common

Public Class CustomerLedger
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "CUSTOMER LEDGER"
        End Get
    End Property

    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property


    Private _transactionCutOffDate As Date
    Public Property TransactionCutOffDate() As Date
        Get
            Return _transactionCutOffDate
        End Get
        Set(ByVal value As Date)
            _transactionCutOffDate = value
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

    Private _leaseID As String
    Public Property LeaseID() As String
        Get
            Return _leaseID
        End Get
        Set(ByVal value As String)
            _leaseID = value
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

    Private _custType As String
    Public Property CustType() As String
        Get
            Return _custType
        End Get
        Set(ByVal value As String)
            _custType = value
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
    Private startPeriod As Date
    Private endPeriod As Date



    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()

        Using dtBill As DataTable = GetBillingsByPeriod()

            Dim bwithBill As Boolean = False
            Dim bwithPayments As Boolean = False

            If dtBill.Rows.Count > 0 Then
                startPeriod = Date.Parse(dtBill.Compute("MIN(startperiod)", ""))
                endPeriod = Date.Parse(dtBill.Compute("MAX(endperiod)", ""))
                bwithBill = True
            Else
                Throw New Exception("ACCOUNT HAS NO BILLINGS AND PAYMENTS FOR THE GIVEN PERIOD")
                Return
            End If

            Using dtPayments As DataTable = GetpaymentsByPeriod()

                If dtPayments.Rows.Count > 0 Then
                    bwithPayments = True
                End If

                Using ledger As New CollectionsDataSet.LedgerDataTable
                    Dim lrow As CollectionsDataSet.LedgerRow
                    Dim runBalance As Decimal

                    If bwithBill Then
                        Dim firstBill As Boolean = True
                        For Each brow As DataRow In dtBill.Rows
                            lrow = ledger.NewLedgerRow
                            lrow.BILL_PERIOD = Date.Parse(brow("bill_date")).ToString("MMM yyyy").ToUpper
                            lrow.BILL_STATEMENT_DATE = Date.Parse(brow("bill_generate_date"))

                            Dim amountDue As Decimal = Decimal.Parse(brow("amount_due"))
                            Dim penalty As Decimal = Decimal.Parse(brow("penalty_amt"))

                            lrow.AMOUNT_DUE = amountDue
                            lrow.PENALTY = penalty

                            runBalance += (amountDue + penalty)

                            Dim prow As DataRow() = Nothing

                            If firstBill Then

                                prow = dtPayments.Select("payment_date <= '" & Date.Parse(brow("endPeriod")).ToShortDateString & "'", "payment_date, or_number")
                                firstBill = False
                            Else
                                prow = dtPayments.Select("payment_date >= '" & Date.Parse(brow("startPeriod")).ToShortDateString & _
                                                   "' AND payment_date <= '" & Date.Parse(brow("endPeriod")).ToShortDateString & "'", "payment_date, or_number")
                            End If
                           
                            If prow.Length > 0 Then
                                Dim bNewrow As Boolean = False
                                For Each rw As DataRow In prow
                                    If bNewrow Then
                                        lrow = ledger.NewLedgerRow

                                        Select Case rw("payment_type").ToString
                                            Case "CSH"
                                                lrow.PAY_MODE = "CASH"
                                            Case "CHK"
                                                lrow.PAY_MODE = "CHECK"
                                                lrow.CHECK_NO = rw("check_number").ToString
                                                lrow.CHECK_BANK = rw("check_bank").ToString
                                                lrow.CHECK_DATE = rw("check_date")
                                            Case "CM"
                                                lrow.PAY_MODE = "CM"
                                        End Select

                                        lrow.REF_NO = rw("or_number").ToString
                                        lrow.REF_DATE = Date.Parse(rw("payment_date"))

                                        If rw("or_status").ToString = "CAN" Then

                                            If rw("pay_category").ToString = "REG" Then
                                                lrow.PAID_AMT = 0
                                            Else
                                                lrow.ADV_AMT = 0
                                            End If

                                            If String.IsNullOrEmpty(rw("pay_remarks").ToString) Then
                                                lrow.REMARKS = "**CANCELLED PAYMENT"
                                            Else
                                                lrow.REMARKS = String.Format("{0} **CANCELLED PAYMENT:{1}", rw("pay_remarks").ToString, rw("cancellation_remarks").ToString)
                                            End If





                                        Else
                                            If rw("pay_category").ToString = "REG" Then
                                                lrow.PAID_AMT = Decimal.Parse(rw("paid_amount"))
                                            Else
                                                If Not Convert.IsDBNull(rw("discount_amt")) Then
                                                    lrow.DISCOUNT = Decimal.Parse(rw("discount_amt"))
                                                End If
                                                lrow.ADV_AMT = Decimal.Parse(rw("paid_amount")) + lrow.DISCOUNT
                                            End If

                                            If Not Convert.IsDBNull(rw("pay_remarks")) Then
                                                lrow.REMARKS = rw("pay_remarks").ToString
                                            End If

                                            If Convert.IsDBNull(rw("discount_amt")) Then
                                                runBalance -= Decimal.Parse(rw("paid_amount"))
                                            Else
                                                runBalance -= Decimal.Parse(rw("paid_amount")) + Decimal.Parse(rw("discount_amt"))
                                            End If
                                        End If

                                        lrow.BALANCE = runBalance
                                        ledger.AddLedgerRow(lrow)

                                    Else
                                        Select Case rw("payment_type").ToString
                                            Case "CSH"
                                                lrow.PAY_MODE = "CASH"
                                            Case "CHK"
                                                lrow.PAY_MODE = "CHECK"
                                                lrow.CHECK_NO = rw("check_number").ToString
                                                lrow.CHECK_BANK = rw("check_bank").ToString
                                                lrow.CHECK_DATE = rw("check_date")
                                            Case "CM"
                                                lrow.PAY_MODE = "CM"
                                        End Select

                                        lrow.REF_NO = rw("or_number").ToString
                                        lrow.REF_DATE = Date.Parse(rw("payment_date"))

                                        If rw("or_status").ToString = "CAN" Then

                                            If rw("pay_category").ToString = "REG" Then
                                                lrow.PAID_AMT = 0
                                            Else
                                                lrow.ADV_AMT = 0
                                            End If


                                            If String.IsNullOrEmpty(rw("pay_remarks").ToString) Then
                                                lrow.REMARKS = "**CANCELLED PAYMENT"
                                            Else
                                                lrow.REMARKS = String.Format("{0} **CANCELLED PAYMENT:{1}", rw("pay_remarks").ToString, rw("cancellation_remarks").ToString)
                                            End If
                                        Else
                                            If rw("pay_category").ToString = "REG" Then
                                                lrow.PAID_AMT = Decimal.Parse(rw("paid_amount"))
                                            Else
                                                If Not Convert.IsDBNull(rw("discount_amt")) Then
                                                    lrow.DISCOUNT = Decimal.Parse(rw("discount_amt"))
                                                End If
                                                lrow.ADV_AMT = Decimal.Parse(rw("paid_amount")) + lrow.DISCOUNT
                                            End If

                                            If Not Convert.IsDBNull(rw("pay_remarks")) Then
                                                lrow.REMARKS = rw("pay_remarks").ToString
                                            End If

                                            If Convert.IsDBNull(rw("discount_amt")) Then
                                                runBalance -= Decimal.Parse(rw("paid_amount"))
                                            Else
                                                runBalance -= Decimal.Parse(rw("paid_amount")) + Decimal.Parse(rw("discount_amt"))
                                            End If
                                        End If

                                        lrow.BALANCE = runBalance
                                        ledger.AddLedgerRow(lrow)

                                        bNewrow = True
                                    End If

                                Next

                            Else
                                lrow.BALANCE = runBalance
                                ledger.AddLedgerRow(lrow)
                            End If

                        Next
                    Else
                        If bwithPayments Then
                            lrow = ledger.NewLedgerRow

                            Dim prow As DataRow() = dtPayments.Select("payment_date >= '" & startPeriod.ToShortDateString & _
                                                                    "' AND payment_date <= '" & endPeriod.ToShortDateString & "'", "payment_date, or_number")
                            Dim bNewrow As Boolean = False
                            For Each rw As DataRow In prow
                                If bNewrow Then
                                    lrow = ledger.NewLedgerRow

                                    Select Case rw("payment_type").ToString
                                        Case "CSH"
                                            lrow.PAY_MODE = "CASH"
                                        Case "CHK"
                                            lrow.PAY_MODE = "CHECK"
                                            lrow.CHECK_NO = rw("check_number").ToString
                                            lrow.CHECK_BANK = rw("check_bank").ToString
                                            lrow.CHECK_DATE = rw("check_date")
                                        Case "CM"
                                            lrow.PAY_MODE = "CM"
                                    End Select

                                    lrow.REF_NO = rw("or_number").ToString
                                    lrow.REF_DATE = Date.Parse(rw("payment_date"))

                                    If rw("or_status").ToString = "CAN" Then

                                        If rw("pay_category").ToString = "REG" Then
                                            lrow.PAID_AMT = 0
                                        Else
                                            lrow.ADV_AMT = 0
                                        End If


                                        If String.IsNullOrEmpty(rw("pay_remarks").ToString) Then
                                            lrow.REMARKS = "**CANCELLED PAYMENT"
                                        Else
                                            lrow.REMARKS = String.Format("{0} **CANCELLED PAYMENT:{1}", rw("pay_remarks").ToString, rw("cancellation_remarks").ToString)
                                        End If
                                    Else

                                        If rw("pay_category").ToString = "REG" Then
                                            lrow.PAID_AMT = Decimal.Parse(rw("paid_amount"))
                                        Else
                                            If Not Convert.IsDBNull(rw("discount_amt")) Then
                                                lrow.DISCOUNT = Decimal.Parse(rw("discount_amt"))
                                            End If
                                            lrow.ADV_AMT = Decimal.Parse(rw("paid_amount")) + lrow.DISCOUNT
                                        End If

                                        If Not Convert.IsDBNull(rw("pay_remarks")) Then
                                            lrow.REMARKS = rw("pay_remarks").ToString
                                        End If

                                        If Convert.IsDBNull(rw("discount_amt")) Then
                                            runBalance -= Decimal.Parse(rw("paid_amount"))
                                        Else
                                            runBalance -= Decimal.Parse(rw("paid_amount")) + Decimal.Parse(rw("discount_amt"))
                                        End If
                                    End If


                                    lrow.BALANCE = runBalance
                                    ledger.AddLedgerRow(lrow)

                                Else
                                    Select Case rw("payment_type").ToString
                                        Case "CSH"
                                            lrow.PAY_MODE = "CASH"
                                        Case "CHK"
                                            lrow.PAY_MODE = "CHECK"
                                            lrow.CHECK_NO = rw("check_number").ToString
                                            lrow.CHECK_BANK = rw("check_bank").ToString
                                            lrow.CHECK_DATE = rw("check_date")
                                        Case "CM"
                                            lrow.PAY_MODE = "CM"
                                    End Select

                                    lrow.REF_NO = rw("or_number").ToString
                                    lrow.REF_DATE = Date.Parse(rw("payment_date"))

                                    If rw("or_status").ToString = "CAN" Then

                                        If rw("pay_category").ToString = "REG" Then
                                            lrow.PAID_AMT = 0
                                        Else
                                            lrow.ADV_AMT = 0
                                        End If


                                        If String.IsNullOrEmpty(rw("pay_remarks").ToString) Then
                                            lrow.REMARKS = "**CANCELLED PAYMENT"
                                        Else
                                            lrow.REMARKS = String.Format("{0} **CANCELLED PAYMENT:{1}", rw("pay_remarks").ToString, rw("cancellation_remarks").ToString)
                                        End If
                                    Else
                                        If rw("pay_category").ToString = "REG" Then
                                            lrow.PAID_AMT = Decimal.Parse(rw("paid_amount"))
                                        Else
                                            If Not Convert.IsDBNull(rw("discount_amt")) Then
                                                lrow.DISCOUNT = Decimal.Parse(rw("discount_amt"))
                                            End If
                                            lrow.ADV_AMT = Decimal.Parse(rw("paid_amount")) + lrow.DISCOUNT
                                        End If

                                        If Not Convert.IsDBNull(rw("pay_remarks")) Then
                                            lrow.REMARKS = rw("pay_remarks").ToString
                                        End If

                                        If Convert.IsDBNull(rw("discount_amt")) Then
                                            runBalance -= Decimal.Parse(rw("paid_amount"))
                                        Else
                                            runBalance -= Decimal.Parse(rw("paid_amount")) + Decimal.Parse(rw("discount_amt"))
                                        End If
                                    End If

                                    lrow.BALANCE = runBalance
                                    ledger.AddLedgerRow(lrow)

                                    bNewrow = True
                                End If
                            Next

                        End If
                    End If

                    ReportDoc = New rptCustomerLedger

                    ReportDoc.SetDataSource(DirectCast(ledger, DataTable))

                End Using
            End Using
        End Using
    End Sub

    Public Overrides Sub BindItems()

        'With ReportDoc.ReportDefinition.Sections("SecReportHeader")

        '    DirectCast(.ReportObjects("txtProjectName"), TextObject).Text = Defaults.SiteName & " PROJECT"
        '    DirectCast(.ReportObjects("txtAccountName"), TextObject).Text =
        '    DirectCast(.ReportObjects("TXTcUSTtyPE"), TextObject).Text = CustType
        '    DirectCast(.ReportObjects("txtFeeType"), TextObject).Text = FeeTypeName
        '    DirectCast(.ReportObjects("txtCutOffdate"), TextObject).Text = TransactionCutOffDate
        '    DirectCast(.ReportObjects("txtBillingStaffName"), TextObject).Text = GlobalReference.CurrentUser.UserFullName
        '    DirectCast(.ReportObjects("txtPropertyAdminName"), TextObject).Text = Defaults.SitePropertyAdmin
        '    DirectCast(.ReportObjects("txtUsername"), TextObject).Text = GlobalReference.CurrentUser.UserID

        'End With

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteLegalName & "'"
            .FormulaFields("AccountName").Text = "'" & UnitNumber & " - " & BuyerName & "'"
            .FormulaFields("CustomerType").Text = "'" & CustType & "'"
            .FormulaFields("FeeTypeName").Text = "'" & FeeTypeName & "'"
            .FormulaFields("CutoffDate").Text = "'" & TransactionCutOffDate.ToString("MMMM d, yyyy") & "'"
            .FormulaFields("PreparedBy").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"
            .FormulaFields("PreparedByPosition").Text = "'" & "Billings and Collection Staff" & "'"
            .FormulaFields("UserID").Text = "'" & GlobalReference.CurrentUser.UserID & "'"



        End With

    End Sub


    Private Function GetBillingsByPeriod() As DataTable
        'load Billing by Period
        Dim query As String

        If String.IsNullOrEmpty(LeaseID) Then
            query = "SELECT   bill_id, bill_date, bill_generate_date, amount_due, penalty_amt," & _
                           "         billings.getcutoffstartdate (bill_id) startperiod,              " & _
                           "         billings.getcutoffenddate (bill_id) endperiod                   " & _
                           "    FROM billing_charges                                                 " & _
                           "   WHERE bill_fee_type = :feetypeid                                      " & _
                           "     AND bill_cust_id = :accountid                                       " & _
                           "     AND bill_status <> 'C'                                              " & _
                           "     AND bill_generate_date <= :transactiondate                          " & _
                           "ORDER BY bill_date                                                       "
        Else
            query = "SELECT   bill_id, bill_date, bill_generate_date, amount_due, penalty_amt," & _
               "         billings.getcutoffstartdate (bill_id) startperiod,              " & _
               "         billings.getcutoffenddate (bill_id) endperiod                   " & _
               "    FROM billing_charges                                                 " & _
               "   WHERE bill_fee_type = :feetypeid                                      " & _
               "     AND lease_id = :leaseid                                       " & _
               "     AND bill_status <> 'C'                                              " & _
               "     AND bill_generate_date <= :transactiondate                          " & _
               "ORDER BY bill_date                                                       "
        End If
       

        Using params As New OraParameter
            If String.IsNullOrEmpty(LeaseID) Then
                params.AddItem("accountid", AccountID, Oracle.DataAccess.Client.OracleDbType.Int32)
            Else
                params.AddItem("leaseid", LeaseID, Oracle.DataAccess.Client.OracleDbType.Int32)
            End If

            params.AddItem("feetypeid", FeeTypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("transactiondate", TransactionCutOffDate, Oracle.DataAccess.Client.OracleDbType.Date)
            Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)

        End Using
    End Function

    Private Function GetpaymentsByPeriod() As DataTable
        'load Payments by Period
        Dim query As String

        If String.IsNullOrEmpty(LeaseID) Then
            query = "SELECT   payment_id, payment_type, pay_category, pay_remarks, or_number,   " & _
                      "         payment_date, paid_amount, discount_amt, check_number, check_date," & _
                      "         (SELECT bank_code                                                 " & _
                      "            FROM ref_banks                                                 " & _
                      "           WHERE bank_id = ps.pay_bank_id) check_bank, or_status,cancellation_remarks           " & _
                      "    FROM payments ps                                                       " & _
                      "   WHERE pay_fee_type = :feetypeid                                           " & _
                      "     AND pay_acct_id = :accountid                                            " & _
                      "     AND payment_date <= :enddate                      " & _
                      "ORDER BY payment_date                                                      "
        Else
            query = "SELECT   payment_id, payment_type, pay_category, pay_remarks, or_number,   " & _
                               "         payment_date, paid_amount, discount_amt, check_number, check_date," & _
                               "         (SELECT bank_code                                                 " & _
                               "            FROM ref_banks                                                 " & _
                               "           WHERE bank_id = ps.pay_bank_id) check_bank, or_status,cancellation_remarks           " & _
                               "    FROM payments ps                                                       " & _
                               "   WHERE pay_fee_type = :feetypeid                                           " & _
                               "     AND lease_id = :leaseid                                             " & _
                               "     AND payment_date <= :enddate                      " & _
                               "ORDER BY payment_date                                                      "
        End If
      

        Using params As New OraParameter
            If String.IsNullOrEmpty(LeaseID) Then
                params.AddItem("accountid", AccountID, Oracle.DataAccess.Client.OracleDbType.Int32)
            Else
                params.AddItem("leaseid", LeaseID, Oracle.DataAccess.Client.OracleDbType.Int32)
            End If
            params.AddItem("feetypeid", FeeTypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            'params.AddItem("startDate", startPeriod, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("endDate", endPeriod, Oracle.DataAccess.Client.OracleDbType.Date)

            Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
        End Using

    End Function

    <Obsolete("DO NOT USE", False)> _
    Private Function GetOpeningBalance() As Decimal
        'get opening balance if any
        Using params As New OraParameter
            params.AddItem("acctid", AccountID, ParameterDirection.Input, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("feeType", FeeTypeID, ParameterDirection.Input, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("startDate", startPeriod, ParameterDirection.Input, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("balance", "", ParameterDirection.ReturnValue, Oracle.DataAccess.Client.OracleDbType.Decimal)

            Return DirectCast(OraDBHelper2.ExecuteFunction("cl_getopeningbalance", params.GetParameterCollection), Oracle.DataAccess.Types.OracleDecimal).ToSingle()
        End Using
    End Function

    '<Obsolete("Do Not Use", True)> _
    'Private Function GetCollectionPeriod() As String

    '    'If TransactionCutOffDate = EndDate Then
    '    '    Return TransactionCutOffDate.ToString("MMMM dd, yyyy dddd")
    '    'Else
    '    '    Return TransactionCutOffDate.ToString("MM/dd/yyyy") & " - " & EndDate.ToString("MM/dd/yyyy")
    '    'End If
    'End Function


End Class
