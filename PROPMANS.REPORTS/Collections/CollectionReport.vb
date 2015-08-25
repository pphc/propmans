
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports DALC
Imports BCL.Common


Public Class CollectionReport
    Inherits ReportBase

    Private dtReceipts As New DataTable
    Private dtORBatch As New DataTable
    Private dtPaymentView As CollectionsDataSet.PAYMENTS_VIEWDataTable

    Private LastORNo As Integer
    Private LastORBatchID As Integer

    Private startN As Integer
    Private endN As Integer
    Private info As String

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "COLLECTION REPORT"
        End Get
    End Property

    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property

    Private _startDate As Date
    Public Property StartDAte() As Date
        Get
            Return _startDate
        End Get
        Set(ByVal value As Date)
            _startDate = value
        End Set
    End Property

    Private _endDate As Date
    Public Property EndDate() As Date
        Get
            Return _endDate
        End Get
        Set(ByVal value As Date)
            _endDate = value
        End Set
    End Property

    Private _corporationTypeID As String
    Public Property CorporationTypeID() As String
        Get
            Return _corporationTypeID
        End Get
        Set(ByVal value As String)
            _corporationTypeID = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()
        Try
            dtReceipts = LoadORReceipts()

            If dtReceipts.Rows.Count = 0 Then
                Throw New Exception("No payment transactions for the given period")
                Exit Sub
            End If

            LoadLastORInfo()

            Dim endbatchid As Integer = Integer.Parse(dtReceipts.Compute("MAX(or_batch_id)", ""))

            If LastORBatchID = 0 Then
                LastORBatchID = 1
            End If

            If LastORBatchID > endbatchid Then
                Throw New Exception("Check Receipt Date of OR# " & LastORNo)
                Exit Sub
            End If

            dtORBatch = LoadOrBatchbyRange(LastORBatchID, endbatchid)

            dtPaymentView = New CollectionsDataSet.PAYMENTS_VIEWDataTable

            Dim orSequenceNo As Integer
            Dim orSequenceBatchID As Integer
            Dim orSequenceLastOR As Integer
            Dim bPreviousDateTransactCheck As Boolean = False

            For Each dr As DataRow In dtReceipts.Rows

                Dim currentORNo As Integer = Integer.Parse(dr("or_number"))
                Dim currentBatchID As Integer = Integer.Parse(dr("or_batch_id"))
                Dim currentORDate As Date = Date.Parse(dr("payment_date"))
                ''check previous tranasction date first
                If Not bPreviousDateTransactCheck Then

                    If LastORNo = 0 Then
                        LastORNo = currentORNo
                    End If

                    If LastORBatchID = currentBatchID Then
                        If LastORNo <> currentORNo Then
                            If LastORNo < currentORNo Then
                                Dim ln As Integer = LastORNo

                                While (ln + 1) < currentORNo
                                    AddNoEntryPaymentViewRow(ln + 1, ln + 1, currentORDate)
                                    ln += 1
                                End While
                            Else
                                Throw New Exception("Check Receipt Date of OR# " & LastORNo)
                                Exit Sub
                            End If
                        End If
                    ElseIf LastORBatchID < currentBatchID Then
                        info = GetBatchInfo(LastORBatchID)
                        If Not String.IsNullOrEmpty(info) Then
                            endN = Integer.Parse(info.Split(",")(1))
                            If LastORNo < endN Then
                                Dim ln As Integer = LastORNo
                                While (ln + 1) < endN
                                    AddNoEntryPaymentViewRow(ln + 1, ln + 1, currentORDate)
                                    ln += 1
                                End While
                            End If
                        End If


                        info = GetBatchInfo(currentBatchID)
                        startN = Integer.Parse(info.Split(",")(0))

                        If startN < currentORNo Then
                            Dim ln As Integer = currentORNo
                            While (ln + 1) < startN
                                AddNoEntryPaymentViewRow(ln + 1, ln + 1, currentORDate)
                                ln += 1
                            End While
                        End If
                    Else
                        Throw New Exception("Check Receipt Date of OR# " & currentORNo)
                        Exit Sub
                    End If

                    orSequenceNo = currentORNo
                    orSequenceBatchID = currentBatchID
                    orSequenceLastOR = Integer.Parse(GetBatchInfo(currentBatchID).Split(",")(1))
                    bPreviousDateTransactCheck = True

                End If

                If currentBatchID = orSequenceBatchID Then
                    If currentORNo = orSequenceNo Then
                        AddPaymentViewRow(dr)
                        orSequenceNo += 1
                    Else
                        If currentORNo < orSequenceNo Then
                            Throw New Exception("Check Receipt Date of either OR# " & currentORNo & "dated " & currentORDate.ToShortDateString & " or last receipt of the preceeding day")
                            Exit Sub
                        End If
                        While currentORNo <> orSequenceNo
                            AddNoEntryPaymentViewRow(orSequenceNo, orSequenceNo.ToString.PadLeft(6, "0"), currentORDate)
                            orSequenceNo += 1
                        End While
                        AddPaymentViewRow(dr)
                        orSequenceNo += 1
                    End If
                Else
                    If orSequenceNo < orSequenceLastOR Then
                        While orSequenceNo <> orSequenceLastOR
                            AddNoEntryPaymentViewRow(orSequenceNo, orSequenceNo.ToString.PadLeft(6, "0"), currentORDate)
                            orSequenceNo += 1
                        End While
                    End If

                    info = GetBatchInfo(currentBatchID)
                    startN = Integer.Parse(info.Split(",")(0))
                    endN = Integer.Parse(info.Split(",")(1))
                    orSequenceNo = startN
                    orSequenceBatchID = currentBatchID
                    orSequenceLastOR = endN
                    If currentORNo > startN Then
                        While currentORNo <> startN
                            AddNoEntryPaymentViewRow(orSequenceNo, orSequenceNo.ToString.PadLeft(6, "0"), currentORDate)
                            orSequenceNo += 1
                        End While
                        AddPaymentViewRow(dr)
                        orSequenceNo += 1
                    Else
                        AddPaymentViewRow(dr)
                        orSequenceNo += 1
                    End If
                End If
            Next

            ReportDoc = New rptCollectionReport
            ReportDoc.SetDataSource(DirectCast(dtPaymentView, DataTable))
            Dim x As New ExportOptions
            x.ExportFormatType = ExportFormatType.PortableDocFormat

            ReportDoc.Export(x)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            dtReceipts.Dispose()

            dtORBatch.Dispose()

            If Not dtPaymentView Is Nothing Then
                dtPaymentView.Dispose()
            End If


        End Try
    End Sub

    Private Sub LoadLastORInfo()

        Dim query As String = "SELECT or_number, batchid, (SELECT end_number                                     " & _
                                    "                              FROM or_inventory                                   " & _
                                    "                             WHERE batch_id = bt.batchid) endor                   " & _
                                    "  FROM (SELECT DISTINCT FIRST_VALUE (or_number) OVER (ORDER BY or_batch_id DESC,  " & _
                                    "                         or_number DESC) or_number,                               " & _
                                    "                        FIRST_VALUE (or_batch_id) OVER (ORDER BY or_batch_id DESC," & _
                                    "                         or_number DESC) batchid                                  " & _
                                    "                   FROM payments                                                  " & _
                                    "                  WHERE payment_type <> 'CM'                                      " & _
                                    "                    AND payment_date =                                            " & _
                                    "                           (SELECT MAX (payment_date)                             " & _
                                    "                              FROM payments                                       " & _
                                    "                             WHERE payment_date < :paydate                        " & _
                                    "                               AND pay_company = :company)                        " & _
                                    "                    AND pay_company = :company) bt                                "
        Using params As New OraParameter
            params.AddParameter("paydate", StartDAte, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("company", CorporationTypeID)

            Try
                With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    If .Rows.Count <> 0 Then
                        LastORNo = Integer.Parse(.Rows(0)("or_number"))
                        LastORBatchID = Integer.Parse(.Rows(0)("batchid"))
                    End If
                End With
            Catch ex As NullReferenceException

            End Try

        End Using

    End Sub

    Private Function LoadORReceipts() As DataTable
        ''get payment transactions for a period
        Dim query As String = "SELECT   payment_id, payment_date, or_number, paid_amount, or_status,          " & _
                        "         accounts.getunitnumber (pay_acct_id) unit_number,                     " & _
                        "         accounts.getcustomerfullname_lfm ((SELECT acct_cust_id                " & _
                        "                                              FROM customer_accounts           " & _
                        "                                             WHERE account_id = ps.pay_acct_id)" & _
                        "                                          ) cust_name,                         " & _
                        "         lease_id,                                                             " & _
                        "         accounts.getcustomerfullname_lfm ((SELECT cust_id                     " & _
                        "                                              FROM rm_lease_contract           " & _
                        "                                             WHERE lease_id = ps.lease_id)     " & _
                        "                                          ) tenant,                            " & _
                        "         fees.getfeedescription (pay_fee_type) fee_type,                       " & _
                        "         getpaymentinvoicedescription (payment_id) particular_item,            " & _
                        "         payment_type, (SELECT bank_code                                       " & _
                        "                          FROM ref_banks                                       " & _
                        "                         WHERE bank_id = ps.pay_bank_id) bank, check_number,   " & _
                        "         check_date, pay_company, or_batch_id, pay_remarks,                    " & _
                        "         cancellation_remarks,                                                 " & _
                        "         (SELECT deposit_date                                                  " & _
                        "            FROM deposits                                                      " & _
                        "           WHERE deposit_id = ps.pay_deposit_id) deposit_date                  " & _
                        "    FROM payments ps                                                           " & _
                        "   WHERE payment_type <> 'CM'                                                  " & _
                        "     AND pay_company = :company                                                " & _
                        "     AND payment_date BETWEEN :startdate AND :enddate                          " & _
                        "ORDER BY or_batch_id, payment_date, or_number 									"

        Using params As New OraParameter
            params.AddItem("startDate", StartDAte, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("endDate", EndDate, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("company", CorporationTypeID)

            Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
        End Using

    End Function

    Private Function LoadOrBatchbyRange(ByVal startID As Integer, ByVal endID As Integer) As DataTable
        'load batchid start and end or
        Dim query As String = "SELECT batch_id,start_number,end_number     " & _
                            "  FROM or_inventory                         " & _
                            "  where batch_id between :startid and :endid" & _
                            "  and company =:company                     " & _
                            "  order by 1                                "

        Using params As New OraParameter
            params.AddParameter("startid", startID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddParameter("endid", endID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddParameter("company", CorporationTypeID)

            Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
        End Using
    End Function

    Private Function GetBatchInfo(ByVal batchID As String) As String
        Dim info As String = String.Empty
        Dim row() As DataRow = dtORBatch.Select("batch_id =" & batchID)

        If row.Length > 0 Then
            info = row(0)("start_number") & ","

            info &= row(0)("end_number")
        End If


        Return info
    End Function

    Private Sub AddNoEntryPaymentViewRow(ByVal id As String, ByVal ornumber As String, ByVal ordate As Date)
        Dim lrow As CollectionsDataSet.PAYMENTS_VIEWRow = dtPaymentView.NewRow

        lrow.PAYMENT_ID = id
        lrow.PAYMENT_DATE = ordate
        lrow.OR_NUMBER = ornumber
        lrow.CUST_NAME = "NO ENTRY"

        dtPaymentView.AddPAYMENTS_VIEWRow(lrow)

    End Sub

    Private Sub AddPaymentViewRow(ByVal row As DataRow)
        Dim lrow As CollectionsDataSet.PAYMENTS_VIEWRow = dtPaymentView.NewRow

        lrow.FEE_TYPE = row("fee_type").ToString
        lrow.PAYMENT_ID = row("payment_id").ToString
        lrow.PAYMENT_DATE = Date.Parse(row("payment_date"))
        lrow.OR_NUMBER = Integer.Parse(row("or_number")).ToString.PadLeft(6, "0")
        lrow.PAY_REMARKS = row("pay_remarks").ToString
        lrow.UNIT_NUMBER = row("unit_number").ToString
        lrow.OR_STATUS = row("or_status").ToString
        If row("or_status").ToString = "CAN" Then
            lrow.PARTICULAR_ITEM = "CANCELLED O.R: " & row("cancellation_remarks").ToString
        Else
            lrow.PARTICULAR_ITEM = FormatParticulars(row("particular_item"))

            If row("payment_type").ToString = "CSH" Then
                lrow.CASH_AMT = Decimal.Parse(row("paid_amount"))
            Else
                lrow.CHECK_AMT = Decimal.Parse(row("paid_amount"))
                lrow.CHECK_NUMBER = row("check_number").ToString
                lrow.BANK = row("bank").ToString
                lrow.CHECK_DATE = Date.Parse(row("check_date"))
            End If
        End If

        If String.IsNullOrWhiteSpace(row("lease_id").ToString) Then
            lrow.CUST_NAME = row("cust_name").ToString
        Else
            lrow.CUST_NAME = row("tenant").ToString
            lrow.PARTICULAR_ITEM &= "-TENANT"
        End If

        dtPaymentView.AddPAYMENTS_VIEWRow(lrow)
    End Sub

    Private Function FormatParticulars(ByVal str As String) As String

        If str.Contains("/") Then
            Dim split As String() = str.Split("/")
            Dim newstr As String = split(0).PadRight(30, " ") & " " & split(1).PadRight(30, " ")

            Return newstr

        Else
            Return str
        End If

    End Function

    Private Function GetCollectionPeriod() As String

        If StartDAte = EndDate Then
            Return StartDAte.ToString("MMMM dd, yyyy dddd").ToUpper
        Else
            Return StartDAte.ToString("MMMM dd, yyyy dddd").ToUpper & " - " & EndDate.ToString("MMMM dd, yyyy dddd").ToUpper
        End If
    End Function

    Public Overrides Sub BindItems()

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteLegalName & "'"
            .FormulaFields("CollectionPeriod").Text = "'" & GetCollectionPeriod() & "'"
            .FormulaFields("PreparedBy").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"
            .FormulaFields("PreparedByPosition").Text = "'" & "Billings and Collection Staff" & "'"
            .FormulaFields("UserID").Text = "'" & GlobalReference.CurrentUser.UserID & "'"


        End With
    End Sub
End Class
