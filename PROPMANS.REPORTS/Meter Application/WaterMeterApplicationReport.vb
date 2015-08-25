
Imports BCL
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common


Public Class WaterMeterApplicationReport
    Inherits ReportBase


    Private MeterInfo As WaterSystem.WaterMeter

    Private UnitNumber As String

    Private UnitOwnerName As String
    <CLSCompliant(False)> _
    Public Sub New(ByVal meterInfo As WaterSystem.WaterMeter, ByVal unitNumber As String, ByVal unitOwnerName As String)
        Me.MeterInfo = meterInfo
        Me.UnitNumber = unitNumber
        Me.UnitOwnerName = unitOwnerName
    End Sub

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "WATER METER APPLICATION REPORT"
        End Get
    End Property

    Public Overrides Sub BindItems()

        ReportDoc = New rptPreviewApplicationForm


        With ReportDoc.ReportDefinition.Sections("Section1")

            DirectCast(.ReportObjects("ProjectName"), TextObject).Text = Defaults.SiteName
            DirectCast(.ReportObjects("ApplicationNumber"), TextObject).Text = MeterInfo.ApplicationNumber
            DirectCast(.ReportObjects("ApplicationDate"), TextObject).Text = MeterInfo.ApplicationDate.ToString("MMMM d,yyyy").ToUpper
            DirectCast(.ReportObjects("UnitNumber"), TextObject).Text = UnitNumber
            DirectCast(.ReportObjects("UnitOwner"), TextObject).Text = UnitOwnerName
        End With


        With ReportDoc.ReportDefinition.Sections("Section3")
            If Not String.IsNullOrEmpty(MeterInfo.MeterNumber) Then
                DirectCast(.ReportObjects("MeterNumber"), TextObject).Text = MeterInfo.MeterNumber
                DirectCast(.ReportObjects("MeterReading"), TextObject).Text = MeterInfo.StartReading
                DirectCast(.ReportObjects("InstallationDate"), TextObject).Text = MeterInfo.InstallationDate.ToString("MMMM d,yyyy").ToUpper
                DirectCast(.ReportObjects("InstalledBy"), TextObject).Text = MeterInfo.InstalledBy
            End If

            DirectCast(.ReportObjects("PreparedBy"), TextObject).Text = GlobalReference.CurrentUser.UserFullName.ToUpper
        End With



        With ReportDoc.ReportDefinition.Sections("Section4")

            DirectCast(.ReportObjects("ProjectName2"), TextObject).Text = Defaults.SiteName
            DirectCast(.ReportObjects("ApplicationNumber2"), TextObject).Text = MeterInfo.ApplicationNumber
            DirectCast(.ReportObjects("ApplicationDate2"), TextObject).Text = MeterInfo.ApplicationDate.ToString("MMMM d,yyyy").ToUpper
            DirectCast(.ReportObjects("UnitNumber2"), TextObject).Text = UnitNumber
            DirectCast(.ReportObjects("UnitOwner2"), TextObject).Text = UnitOwnerName

            If Not String.IsNullOrEmpty(MeterInfo.MeterNumber) Then
                DirectCast(.ReportObjects("MeterNumber2"), TextObject).Text = MeterInfo.MeterNumber
                DirectCast(.ReportObjects("MeterReading2"), TextObject).Text = MeterInfo.StartReading
                DirectCast(.ReportObjects("InstallationDate2"), TextObject).Text = MeterInfo.InstallationDate.ToString("MMMM d,yyyy").ToUpper
                DirectCast(.ReportObjects("InstalledBy2"), TextObject).Text = MeterInfo.InstalledBy
            End If


        End With


        With ReportDoc.ReportDefinition.Sections("Section5")

            DirectCast(.ReportObjects("PreparedBy2"), TextObject).Text = GlobalReference.CurrentUser.UserFullName.ToUpper

        End With

    End Sub
End Class


