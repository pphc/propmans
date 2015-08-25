
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports BCL.Common

Public Class WaterDisconnectionNotice
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "WATER DISCONNECTION NOTICE"
        End Get
    End Property
    Private _dtSource As DataTable

    Public Property dtAccounts() As DataTable
        Get
            Return _dtSource
        End Get
        Set(ByVal value As DataTable)
            _dtSource = value
        End Set
    End Property

    Private _disconnectionDueDate As Date
    Public Property DisconnectionDueDate() As Date
        Get
            Return _disconnectionDueDate
        End Get
        Set(ByVal value As Date)
            _disconnectionDueDate = value
        End Set
    End Property


    Public Sub New(ByVal dtSource As DataTable, ByVal dueDate As Date)
        dtAccounts = dtSource
        DisconnectionDueDate = dueDate
    End Sub

    Public Overrides Sub LoadReport()
        'LoadData()
        BindItems()
    End Sub


    Public Overrides Sub BindItems()
        ReportDoc = New rptDisconnectionNotice
        With ReportDoc.DataDefinition
            .FormulaFields("BillingStaff").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"
            .FormulaFields("PROJECT_NAME").Text = "'" & Defaults.SiteName & "'"
            .FormulaFields("DUE_DATE").Text = "'" & DisconnectionDueDate.ToString("MMMM d, yyyy") & "'"
            .FormulaFields("PROPERTY_ADMIN").Text = "'" & Defaults.SitePropertyAdmin & "'"
            .FormulaFields("CONTACT_NO").Text = "'" & Defaults.SiteContactNos & "'"
            'TODO should be not used literals
            Dim feeCOmpany As String = GlobalReference.Fee.GetFeeCompany(25).Trim

            If feeCOmpany = "P" Then
                .FormulaFields("CompanyPayee").Text = "'" & GlobalReference.ProjectParameters.SiteDeveloperName & "'"
            Else
                .FormulaFields("CompanyPayee").Text = "'" & GlobalReference.ProjectParameters.SiteLegalName & "'"
            End If

        End With
        ReportDoc.SetDataSource(dtAccounts)
    End Sub
End Class


