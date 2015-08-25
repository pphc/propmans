
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports DALC
Imports BCL.Common
Imports BCL.Checks
Imports PROPMANS.BASE_MOD


Public Class CheckByStatusReport
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "CHECKS BY STATUS REPORT"
        End Get
    End Property

    Public Property StartDate As Date
    Public Property EnDate As Date

    Public Property CheckStatus As New CheckStatus


    Public Sub New()

    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()
        Try

            Dim query As String = "SELECT   check_id, checks.getcheckcustomername (check_id) cust_name,                " & _
                                "         checks.getcheckcustomerunit (check_id) unit_no,                            " & _
                                "         checks.getbankname (bank_id) bank_name,                                    " & _
                                "         checks.getbankbranchname (branch_id) branch_name, rt_number,               " & _
                                "         check_number, check_date, check_amount, check_status,status_remarks   " & _
                                "    FROM ck_check cc                                                                " & _
                                "   WHERE check_date BETWEEN :startdate AND :enddate                                 " & _
                                "     AND check_status = :checkstatus                                                " & _
                                "ORDER BY check_date, cust_name                                                      "


            Dim chkinfo As New List(Of CheckDueDetails)
            Using param As New OraParameter
                param.AddParameter("startdate", Me.StartDate, Oracle.DataAccess.Client.OracleDbType.Date)
                param.AddParameter("enddate", Me.EnDate, Oracle.DataAccess.Client.OracleDbType.Date)
                param.AddParameter("checkstatus", Common.ConvertEnumtoDBValue(CheckStatus))
                Dim idx As Integer = 1
                For Each row As DataRow In OraDBHelper2.GetResultSet(query, param.GetParameterCollection).Rows
                    chkinfo.Add(New CheckDueDetails With {.ItemNumber = idx,
                                                           .CustomerName = row("cust_name").ToString,
                                                           .CustomerUnit = row("unit_no").ToString,
                                                           .BankName = row("bank_name").ToString,
                                                           .BranchName = row("branch_name").ToString,
                                                           .RTNumber = row("rt_number").ToString,
                                                           .CheckNumber = row("check_number").ToString,
                                                           .CheckAmount = Decimal.Parse(row("check_amount").ToString),
                                                           .CheckDate = Date.Parse(row("check_date").ToString),
                                                           .CheckStatus = row("check_status").ToString,
                                                           .CheckRemarks = row("status_remarks").ToString}
                                                           )
                    idx += 1
                Next

            End Using

            If chkinfo.Count = 0 Then
                Throw New Exception("No Checks for the given period")
            End If

            ReportDoc = New rptChecksByStatusReport
            ReportDoc.SetDataSource(chkinfo)
            ReportDoc.Database.Tables("CompanyLogo").SetDataSource(DirectCast(Me.LoadCompanyLogo, DataTable))
            ''  ReportDoc.SetDataSource(DirectCast(Me.LoadCompanyLogo, DataTable))
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub


    Public Overrides Sub BindItems()

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteLegalName & "'"
            .FormulaFields("CheckStatus").Text = "'" & Common.ConvertEnumtoDescription(Me.CheckStatus) & "'"
            ''.FormulaFields("ReceivedBy").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"

            .FormulaFields("DatePeriod").Text = "'" & GetDatePeriod() & "'"



        End With
    End Sub

    Public Function GetDatePeriod() As String
        Return StartDate.ToString("MMMM dd,yyyy") & " to " & EnDate.ToString("MMMM dd,yyyy")
    End Function
End Class

