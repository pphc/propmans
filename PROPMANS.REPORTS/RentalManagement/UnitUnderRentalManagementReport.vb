Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
'Imports BCL.ContractOfLease

Public Class UnitUnderRentalManagementReport
    Inherits ReportBase

    Private reportType As String

    Public Sub New(ByVal type As String)
        Me.reportType = Type
    End Sub

    Public Overrides Sub BindItems()

        With ReportDoc.DataDefinition

            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"
            .FormulaFields("AsOfDate").Text = "'" & Now.Date.ToString("M/d/yyyy").ToUpper & "'"

        End With

        With ReportDoc.ReportDefinition.Sections("SecReportHeader")

            DirectCast(.ReportObjects("txtUsername"), TextObject).Text = OraConnection.Instance.UserID

            If reportType = "ACT" Then

                DirectCast(.ReportObjects("txtStatusAccounts"), TextObject).Text = "ACTIVE AND OCCUPIED ACCOUNTS"

            ElseIf reportType = "EXP" Then

                DirectCast(.ReportObjects("txtStatusAccounts"), TextObject).Text = "EXPIRED AND VOID ACCOUNTS"

            ElseIf reportType = "FAP" Then

                DirectCast(.ReportObjects("txtStatusAccounts"), TextObject).Text = "FOR APPROVAL ACCOUNTS"

            ElseIf reportType = "OCC" Then

                DirectCast(.ReportObjects("txtStatusAccounts"), TextObject).Text = "VACANT UNITS"

            End If


        End With




    End Sub
    
    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "UNIT UNDER RENTAL MANAGEMENT"
        End Get
    End Property

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()
        Dim ContractStatus As String = String.Empty

        If reportType = "ACT" Then
            ContractStatus = "'ACT" + "','" + "OCC'"
        ElseIf reportType = "EXP" Then
            ContractStatus = "'EXP" + "','" + "VOID'"
        ElseIf reportType = "FAP" Then
            ContractStatus = "'" + "FAP" + "'"
        ElseIf reportType = "OCC" Then
            ContractStatus = "'" + "ACT" + "'"
        End If


        Dim query As String = "SELECT (SELECT cust_unit_no                                                " & _
                              "        FROM customer_accounts                                             " & _
                              "        WHERE account_id = a.ACCOUNT_ID) UNIT_NO                           " & _
                              "     , accounts.getcustomerfullname_fml ((SELECT acct_cust_id              " & _
                              "                                          FROM customer_accounts           " & _
                              "                                          WHERE account_id = a.ACCOUNT_ID) " & _
                              "                                        ) UNIT_OWNER                       " & _
                              "     , TO_CHAR(CONTRACT_START, 'MM/DD/YYYY') CONTRACT_START                " & _
                              "     , TO_CHAR(CONTRACT_END, 'MM/DD/YYYY') CONTRACT_END                    " & _
                              "     , UNIT_CLASS                                                          " & _
                              "     , RENT_AMT                                                            " & _
                              "     , CASE CONTRACT_STATUS                                                " & _
                              "WHEN 'ACT'  THEN 'ACTIVE'                                                  " & _
                              "WHEN 'VOID' THEN 'VOID'                                                    " & _
                              "WHEN 'FAP'  THEN 'FOR APPROVAL'                                            " & _
                              "WHEN 'EXP'  THEN 'EXPIRED'                                                 " & _
                              "WHEN 'OCC'  THEN 'OCCUPIED'                                                " & _
                              "END CONTRACT_STATUS                                                        " & _
                              "FROM RM_AGREEMENT a                                                        " & _
                              "WHERE CONTRACT_STATUS IN(" & ContractStatus & ")                           " & _
                              "ORDER BY a.AGREEMENT_ID ASC                                                "

        Using dt As DataTable = OraDBHelper2.GetResultSet(query)

            ReportDoc = New rptUnitUnderRentalManagementForm
            ReportDoc.SetDataSource(DirectCast(dt, DataTable))

        End Using


    End Sub

End Class
