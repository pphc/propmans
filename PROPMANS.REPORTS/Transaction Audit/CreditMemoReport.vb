Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports DALC
Imports BCL.Common

Public Class CreditMemoReport
    Inherits ReportBase

#Region "PROPERTIES"

    Public CompanyDivision As String
    Public StartDate As Date
    Public EndDate As Date
    Private _companySelect As String
    'Public Sub New(ByVal CompanyDivision As String, ByVal DateFrom As Date, ByVal DateTo As Date, ByVal CompanySelect As String)
    '    _companyDivision = CompanyDivision
    '    _dateFrom = DateFrom.ToString("MMM dd, yyyy").ToUpper
    '    _dateTo = DateTo.ToString("MMM dd, yyyy").ToUpper
    '    _companySelect = CompanySelect
    'End Sub


    Private dtCancelledReceipts As CancenlledReceiptsDataSet.CancelledReceiptsDataTable

#End Region

    Public Overrides Sub BindItems()

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteLegalName & "'"
            .FormulaFields("DateFrom").Text = "'" & StartDate.ToShortDateString & "'"
            .FormulaFields("DateTo").Text = "'" & EndDate.ToShortDateString & "'"
            .FormulaFields("CompanySelect").Text = "'" & _companySelect & "'"

        End With
    End Sub

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "CREDIT MEMOS"
        End Get
    End Property
    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()

    End Sub

    Private Sub LoadData()
        Try

            Dim query As String = "SELECT   or_number cm_ref_no, to_char(payment_date,'MM/DD/YYYY') cm_date,                                            " & _
                                  "         accounts.getunitnumber (pay_acct_id) unit_number,                                     " & _
                                  "         accounts.getcustomerfullname_lfm                                                      " & _
                                  "                                      ((SELECT acct_cust_id                                    " & _
                                  "                                          FROM customer_accounts                               " & _
                                  "                                         WHERE account_id = ps.pay_acct_id)                    " & _
                                  "                                      ) customer_name,                                         " & _
                                  "         paid_amount cm_amount,                                                                " & _
                                  "         fees.getfeedescription (pay_fee_type) applied_to,                                     " & _
                                  "         pay_remarks cm_remarks, created_by, to_char(created_date,'DD-MON-YY HH:MI:SS PM') created_date                                      " & _
                                  "    FROM payments ps                                                                           " & _
                                  "   WHERE payment_type = 'CM' AND PAY_COMPANY= :companydivision                       " & _
                                  "     AND payment_date BETWEEN :startdate " & _
                                  "                          AND :enddate  " & _
                                  "ORDER BY or_number                                                                             "

            Using params As New OraParameter
                params.AddParameter("companyDivision", CompanyDivision)
                params.AddParameter("startdate", StartDate, Oracle.DataAccess.Client.OracleDbType.Date)
                params.AddParameter("enddate", EndDate, Oracle.DataAccess.Client.OracleDbType.Date)
                Using dt As DataTable = OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    ReportDoc = New rptCreditMemo
                    ReportDoc.SetDataSource(DirectCast(dt, DataTable))

                End Using

            End Using
      

            '' ''dtCancelledReceipts = ShowCancelledReceipts()

            '' ''ReportDoc = New rptCancelledReceipts
            '' ''ReportDoc.SetDataSource(DirectCast(dtCancelledReceipts, DataTable))


            '' '' '' ''Dim query As String

            '' '' '' ''Using params As New OraParameter
            '' '' '' ''    params.AddItem("companyDivision", _companyDivision, Oracle.DataAccess.Client.OracleDbType.Int32)

            '' '' '' ''    query = "SELECT   or_number, payment_date,                                                                           " & _
            '' '' '' ''            "         accounts.getunitnumber (pay_acct_id) unit_number,                                                  " & _
            '' '' '' ''            "         accounts.getcustomerfullname_lfm                                                                   " & _
            '' '' '' ''            "                                      ((SELECT acct_cust_id                                                 " & _
            '' '' '' ''            "                                          FROM customer_accounts                                            " & _
            '' '' '' ''            "                                         WHERE account_id = ps.pay_acct_id)                                 " & _
            '' '' '' ''            "                                      ) customer_name,                                                      " & _
            '' '' '' ''            "         paid_amount, fees.getfeedescription (pay_fee_type) fee_name,                                       " & _
            '' '' '' ''            "         payment_type, cancellation_remarks,edited_by cancelled_by, edited_date cancelled_on                " & _
            '' '' '' ''            "    FROM payments ps                                                                                        " & _
            '' '' '' ''            "   WHERE or_status = 'CAN' AND payment_date BETWEEN TO_DATE('01/01/2015 00:00:00', 'MM/DD/YYYY HH24:MI:SS') " & _
            '' '' '' ''            " 											   AND TO_DATE('02/28/2015 00:00:00', 'MM/DD/YYYY HH24:MI:SS') " & _
            '' '' '' ''            "         AND pay_company = :companyDivision                                                                 " & _
            '' '' '' ''            "ORDER BY payment_date, or_number                                                                            "

            '' '' '' ''    Using dt As DataTable = OraDBHelper2.GetResultSet(query)

            '' '' '' ''        ReportDoc = New rptCancelledReceipts
            '' '' '' ''        ReportDoc.SetDataSource(DirectCast(dt, DataTable))

            '' '' '' ''    End Using

            '' '' '' ''End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

        End Try
    End Sub
End Class
