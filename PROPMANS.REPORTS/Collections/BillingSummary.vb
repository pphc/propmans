Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common

Public Class BillingSummary
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "BILLING SUMMARY"
        End Get
    End Property


    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property

    Private _billingDate As Date
    Public Property BillingDate() As Date
        Get
            Return _billingDate
        End Get
        Set(ByVal value As Date)
            _billingDate = value
        End Set
    End Property


    Private _paymentCutOff As Date
    Public Property PaymentCutOff() As Date
        Get
            Return _paymentCutOff
        End Get
        Set(ByVal value As Date)
            _paymentCutOff = value
        End Set
    End Property


    Private _feeName As String
    Public Property FeeName() As String
        Get
            Return _feeName
        End Get
        Set(ByVal value As String)
            _feeName = value
        End Set
    End Property

    Private _feeID As String
    Public Property FeeID() As String
        Get
            Return _feeID
        End Get
        Set(ByVal value As String)
            _feeID = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()


        Dim query As String = "SELECT   bill_id, (SELECT cust_unit_no                                              " & _
                        "                     FROM customer_accounts                                         " & _
                        "                    WHERE account_id = bc.bill_cust_id) unit_no,                    " & _
                        "         accounts.getcustomerfullname_fml ((SELECT acct_cust_id                                  " & _
                        "                                 FROM customer_accounts                             " & _
                        "                                WHERE account_id = bc.bill_cust_id)) customer_name, " & _
                        "         amount_due, penalty_amt,                                                   " & _
                        "         billings.getpreviousbalance (bill_fee_type, bill_cust_id, bill_id) prevbal,         " & _
                        "         billings.getpaymentbymonth (bill_fee_type,                                          " & _
                        "                            bill_cust_id,                                           " & _
                        "                            bill_id,                                                " & _
                        "                            :paymentdate                                            " & _
                        "                           ) payment                                                " & _
                        "    FROM billing_charges bc                                                         " & _
                        "   WHERE bill_fee_type = :feetype AND bill_status <> 'C'                            " & _
                        "         AND bill_date = :billdate                                                  " & _
                        "ORDER BY (SELECT cust_unit_sort                                                     " & _
                        "            FROM customer_accounts                                                  " & _
                        "           WHERE account_id = bc.bill_cust_id)                                      "

        'Dim query As String = "SELECT   cust_unit_no unit_no,                                                        " & _
        '                    "         getcustfullname_fml ((SELECT acct_cust_id                            " & _
        '                    "                                 FROM customer_accounts                       " & _
        '                    "                                WHERE account_id = cs.account_id)             " & _
        '                    "                             ) customer_name,                                 " & _
        '                    "         getpreviousbalancebymonth (:feetype,                                 " & _
        '                    "                                    cs.account_id,                            " & _
        '                    "                                    :billdate                                 " & _
        '                    "                                   ) prevbal,                                " & _
        '                    "         NVL (bl.amount_due, 0) amount_due, NVL (bl.penalty_amt, 0) penalty_amt,    " & _
        '                    "         getallpaymentbymonth (:feetype, cs.account_id, :billdate) payment    " & _
        '                    "    FROM customer_accounts cs                                                 " & _
        '                    "         LEFT JOIN                                                            " & _
        '                    "         (SELECT bill_cust_id, bill_id, amount_due, penalty_amt               " & _
        '                    "            FROM billing_charges bc                                           " & _
        '                    "           WHERE bill_fee_type = :feetype                                     " & _
        '                    "             AND bill_status <> 'C'                                           " & _
        '                    "             AND bill_date = :billdate) bl ON (cs.account_id = bl.bill_cust_id" & _
        '                    "                                              )                               " & _
        '                    "   WHERE account_status = 'ACT'                                               " & _
        '                    "     AND cust_unit_type IN (SELECT unit_type_id                               " & _
        '                    "                              FROM unit_types                                 " & _
        '                    "                             WHERE unit_parking_tag = 'N')                    " & _
        '                    "ORDER BY cust_unit_sort                                                         "

        Using params As New OraParameter
            params.AddItem("feetype", FeeID, Oracle.DataAccess.Client.OracleDbType.Int32)
            params.AddItem("billdate", BillingDate, Oracle.DataAccess.Client.OracleDbType.Date)
            params.AddItem("paymentdate", PaymentCutOff, Oracle.DataAccess.Client.OracleDbType.Date)

            Using dtBill As DataTable = OraDBHelper2.GetResultSet(query, params.GetParameterCollection)

                Dim totalRows As Integer = dtBill.Rows.Count
                Dim firstPage As Integer = 22
                Dim recPerPage As Integer = 28
                Dim printNextPageHeader As String = "Y"



                If totalRows <= firstPage Then
                    printNextPageHeader = "N"
                Else
                    If (totalRows - firstPage) Mod recPerPage = 0 Then
                        printNextPageHeader = "N"
                    Else
                        printNextPageHeader = "Y"
                    End If
                End If


                ReportDoc = New rptBillingsummary
                ReportDoc.DataDefinition.FormulaFields("PrintPageHeader").Text = Format_Formula_Field(printNextPageHeader)
                ReportDoc.SetDataSource(DirectCast(dtBill, DataTable))
            End Using

        End Using
    End Sub

    Public Overrides Sub BindItems()
        With ReportDoc.ReportDefinition.Sections("SecReportHeader")

            DirectCast(.ReportObjects("txtReportTitle"), TextObject).Text = FeeName & " BILLING SUMMARY"
            DirectCast(.ReportObjects("txtProjectName"), TextObject).Text = Defaults.SiteName & " PROJECT"

            DirectCast(.ReportObjects("txtBillingMonth"), TextObject).Text = "FOR THE MONTH OF " & BillingDate.ToString("MMMM yyyy").ToUpper
            DirectCast(.ReportObjects("txtBillingStaffName"), TextObject).Text = GlobalReference.CurrentUser.UserFullName
            DirectCast(.ReportObjects("txtPropertyAdminName"), TextObject).Text = Defaults.SitePropertyAdmin
            DirectCast(.ReportObjects("txtUsername"), TextObject).Text = OraConnection.Instance.UserID

        End With

        With ReportDoc.DataDefinition
            .FormulaFields("PaymentCutOff").Text = "'" & PaymentCutOff.ToString("MMMM d, yyyy").ToUpper & "'"
        End With
    End Sub

    Private Function Format_Formula_Field(ByVal xObj As String) As String
        Format_Formula_Field = "'" & Replace(xObj, "'", "''") & "'"
    End Function



End Class
