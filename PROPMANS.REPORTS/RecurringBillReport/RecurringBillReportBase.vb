
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports DALC
Imports BCL.Common

Public MustInherit Class RecurringBillReportBase
    Inherits ReportBase

#Region "Properties"

    Private _dtSource As DataTable

    Public Property dtAccounts() As DataTable
        Get
            Return _dtSource
        End Get
        Set(ByVal value As DataTable)
            _dtSource = value
        End Set
    End Property

    Private _dtMeterReading As BillingsDataSet.WATERACCOUNTDataTable
    Public Property dtMeterReading() As BillingsDataSet.WATERACCOUNTDataTable
        Get
            Return _dtMeterReading
        End Get
        Protected Set(ByVal value As BillingsDataSet.WATERACCOUNTDataTable)
            _dtMeterReading = value
        End Set
    End Property

    Public MustOverride ReadOnly Property StatementHeader() As String

    Public MustOverride ReadOnly Property WaterMarkText() As String


    Public ReadOnly Property ProjectName() As String
        Get
            Return Defaults.SiteName
        End Get

    End Property

    Public ReadOnly Property ProjectLocation() As String
        Get
            Return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Defaults.SiteAddress.ToLower)
        End Get
    End Property

    Public ReadOnly Property CorporationName() As String
        Get
            Return GetCorporateName()
        End Get
    End Property

    Public ReadOnly Property UserFullName() As String
        Get
            Return GlobalReference.CurrentUser.UserFullName
        End Get
    End Property

    Public ReadOnly Property PropertyAdministrator() As String
        Get
            Return Defaults.SitePropertyAdmin
        End Get
    End Property

    Public ReadOnly Property OfficeLocation() As String
        Get
            Return Defaults.SiteOfficeLocation
        End Get
    End Property

    Public ReadOnly Property OfficeCOntact() As String
        Get
            Return Defaults.SiteContactNos
        End Get
    End Property

    Private _statementDate As Date
    Public Property StatementDate() As Date
        Get
            Return _statementDate
        End Get
        Set(ByVal value As Date)
            _statementDate = value
        End Set
    End Property

    Private _dueDate As Date
    Public Property DueDate() As Date
        Get
            Return _dueDate
        End Get
        Protected Set(ByVal value As Date)
            _dueDate = value
        End Set
    End Property

    Private _billingPeriodDate As Date
    Public Property BillingPeriodDate() As Date
        Get
            Return _billingPeriodDate
        End Get
        Set(ByVal value As Date)
            _billingPeriodDate = value
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

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

#End Region

 
    Protected Function GetCorporateName() As String

        If GlobalReference.Fee.GetFeeInfobyFeeID(FeeID).FeeCompany = SiteDivision.CondoCorp Then
            Return GlobalReference.ProjectParameters.SiteLegalName
        Else
            Return GlobalReference.ProjectParameters.SiteDeveloperName
        End If

       
    End Function

    Public Overrides Sub LoadReport()
        BindItems()
    End Sub

    Public Overrides Sub BindItems()

        ReportDoc = New rptCommonBilling

        ' ReportDoc.ReportDefinition.Sections("SecWater").SectionFormat.EnableSuppress = True

        With ReportDoc.DataDefinition
            .FormulaFields("Supress").Text = "'" & "Water" & "'"

            .FormulaFields("Watermark").Text = "'" & WaterMarkText & "'"

            .FormulaFields("ProjectName").Text = "'" & ProjectName & "'"
            .FormulaFields("ProjectLocation").Text = "'" & ProjectLocation & "'"
            .FormulaFields("ProjectOffice").Text = "'" & OfficeLocation & "'"
            .FormulaFields("ProjectContactNo").Text = "'" & OfficeCOntact & "'"

            .FormulaFields("CorporationName").Text = "'" & CorporationName & "'"
            .FormulaFields("StatementName").Text = "'" & StatementHeader & "'"

            .FormulaFields("PropertyAdminName").Text = "'" & PropertyAdministrator & "'"
            .FormulaFields("UserFullName").Text = "'" & UserFullName & "'"

            .FormulaFields("Remarks").Text = "'" & Remarks & "'"

        End With

        dtMeterReading = New BillingsDataSet.WATERACCOUNTDataTable
        ReportDoc.Database.Tables("COMMONBILLING").SetDataSource(dtAccounts)
        ReportDoc.Database.Tables("WATERACCOUNT").SetDataSource(DirectCast(dtMeterReading, DataTable))
        'ReportDoc.Refresh()

    End Sub


End Class
