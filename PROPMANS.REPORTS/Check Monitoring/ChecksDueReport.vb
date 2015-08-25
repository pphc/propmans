
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports DALC
Imports BCL.Common
Imports BCL.Checks

Public Class CheckDueDetails
    Public Property ItemNumber As Integer
    Public Property CustomerName As String
    Public Property CustomerUnit As String
    Public Property BankName As String
    Public Property BranchName As String
    Public Property RTNumber As String
    Public Property CheckNumber As String
    Public Property CheckDate As Date
    Public Property CheckAmount As Decimal
    Public Property CheckStatus As String
    Public Property CheckRemarks As String
End Class

Public Class ChecksDueReport
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "CHECKS DUE REPORT"
        End Get
    End Property

    Public Property StartDate As Date
    Public Property EnDate As Date



    Public Sub New()

    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()
        Try

            Dim query As String = "SELECT check_id, checks.getcheckcustomername (check_id) cust_name,      " & _
                            "               checks.getcheckcustomerunit (check_id) unit_no,          " & _
                            "       checks.getbankname (bank_id) bank_name,                          " & _
                            "       checks.getbankbranchname (branch_id) branch_name, rt_number,     " & _
                            "       check_number, check_date, check_amount, check_status             " & _
                            "  FROM ck_check cc                                                      " & _
                            " WHERE ar_id IS NOT NULL AND check_date BETWEEN :startdate AND :enddate " & _
                            " and check_status ='ACT'                            " & _
                            " ORDER BY CHECK_DATE,CUST_NAME                                          "


            Dim chkinfo As New List(Of CheckDueDetails)
            Using param As New OraParameter
                param.AddParameter("startdate", Me.StartDate, Oracle.DataAccess.Client.OracleDbType.Date)
                param.AddParameter("enddate", Me.EnDate, Oracle.DataAccess.Client.OracleDbType.Date)

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
                                                           .CheckStatus = row("check_status").ToString}
                                                           )
                    idx += 1
                Next


            End Using

            If chkinfo.Count = 0 Then
                Throw New Exception("No Checks Due for the given period")
            End If

            ReportDoc = New rptChecksDueReport
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
            ''.FormulaFields("ReceivedBy").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"

            .FormulaFields("DatePeriod").Text = "'" & GetDatePeriod()& "'"



        End With
    End Sub

    Public Function GetDatePeriod() As String
        Return StartDate.ToString("MMMM dd,yyyy") & " to " & EnDate.ToString("MMMM dd,yyyy")
    End Function
End Class

