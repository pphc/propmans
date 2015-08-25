Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common
Imports BCL.Technical

Public Class UnitPunchlistDetail
    Public Property ParticularName As String
    Public Property ClassType As String
    Public Property InAcceptableCondition As String
    Public Property Remarks As String
End Class

Public Class UnitPunchlistReport
    Inherits ReportBase

    Private Const CMDPunchlist As String = "UNIT PUNCHLISTING FORM WITH QA/QC"
    Private Const OwnerPunchlist As String = "UNIT PUNCHLISTING FORM WITH OWNER"
    Public PunchlistType As String
    Private repsrc As List(Of UnitPunchlistDetailReportInfo)
    Public Overrides ReadOnly Property ReportName() As String
        Get
            If punchlistType = "CMD" Then
                Return CMDPunchlist
            Else
                Return OwnerPunchlist
            End If
        End Get
    End Property

    Public ReadOnly Property InspectionInstance As String
        Get
            Return "FIRST INSTANCE"
        End Get
    End Property
    Public Property InspectionDate As Date
    Public Property UnitNumber As String


    Public Property PPMGPersonnel As String
    Public Property PPMGSupervisor As String
    Public Property CMDPersonnel As String


    Public Sub New(punchlistdetail As List(Of UnitPunchlistDetailReportInfo))
        repsrc = punchlistdetail
    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()
        Try
   
            Dim punchlistDetail As New List(Of UnitPunchlistDetail)

            For Each item As UnitPunchlistDetailReportInfo In repsrc
                punchlistDetail.Add(New UnitPunchlistDetail With {.ParticularName = item.ParticularName,
                                                            .ClassType = item.ClassType,
                                                            .InAcceptableCondition = item.InAcceptableCondition,
                                                            .Remarks = item.Remarks})
            Next

            ReportDoc = New rptPunchlistingForm
            ReportDoc.SetDataSource(punchlistDetail)
            ReportDoc.Database.Tables("CompanyLogo").SetDataSource(DirectCast(Me.LoadCompanyLogo, DataTable))
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub


    Public Overrides Sub BindItems()

        PPMGSupervisor = "ARCH. FRITZIE OLASO"

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteLegalName & "'"
            .FormulaFields("ProjectLocation").Text = "'" & Defaults.SiteAddress & "'"
            .FormulaFields("PunchlistHeader").Text = "'" & ReportName & "'"
            .FormulaFields("InspectionInstance").Text = "'" & InspectionInstance & "'"
            .FormulaFields("CustomerAccount").Text = "'" & UnitNumber & "'"
            .FormulaFields("InspectionDate").Text = "'" & InspectionDate.ToString("MMMM dd, yyyy") & "'"
            .FormulaFields("PPMGPersonnel").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"
            .FormulaFields("PPMGSupervisor").Text = "'" & PPMGSupervisor & "'"
            .FormulaFields("CMDPersonnel").Text = "'" & CMDPersonnel & "'"
        End With
    End Sub
End Class

