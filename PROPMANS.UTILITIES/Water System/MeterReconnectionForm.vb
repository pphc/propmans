'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: Meter Disconnection
'Module Description: Disconnection of Water Meter
'Author: MTRIVO
'Date Created: 2/13/2013
'
'Change Log:
'*****************************************************************

Imports PROPMANS.BASE_MOD.Common



Imports BCL
Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD


Public Class MeterReconnectionForm

#Region "Properties"
    Private _meterID As String
    Public Property MeterID() As String
        Get
            Return _meterID
        End Get
        Private Set(ByVal value As String)
            _meterID = value
        End Set
    End Property

    Private _meterNumber As String

    Public Property MeterNumber() As String
        Get
            Return _meterNumber
        End Get
        Set(ByVal value As String)
            _meterNumber = value
        End Set
    End Property

    Private _unitNumber As String

    Public Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
        Set(ByVal value As String)
            _unitNumber = value
        End Set
    End Property

    Private _unitOwnerName As String

    Public Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
        Set(ByVal value As String)
            _unitOwnerName = value
        End Set
    End Property

    Public ReadingHelper As WaterSystem.MeterReadingHelper

#End Region

#Region "Form and Control Events"
    Public Sub New(ByVal meterID As String)
        Me.MeterID = meterID
        ReadingHelper = New WaterSystem.MeterReadingHelper(Me.MeterID)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MeterDisconnectionForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim md As New WaterSystem.WaterMeter

        md.MeterID = Me.MeterID
        md.ConnectionStatusDate = dtpReconnectionDate.Value
        md.ConnectionStatus = WaterSystem.MeterConnectionStatus.ACT

        md.ReconnectMeter()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


#End Region

#Region "Local Procedure"

    Private Sub UISetup()
        lblAccountName.Text = UnitNumber & " - " & UnitOwnerName
        lblMeterNumber.Text = "METER NO.: " & MeterNumber

        dtpReconnectionDate.MaxDate = Date.Now

        'Retrieve Disconnection Information
        With WaterSystem.WaterMeter.GetMeterDisconnectionInfo(Me.MeterID)
            lblDisconnectionType.Text = Common.ConvertEnumtoDescription(.ConnectionStatus)
            lblDisconnectionDate.Text = .ConnectionStatusDate.Value.ToString("MMM dd, yyyy").ToUpper
            lblDisconnectionReason.Text = .ConnectionStatusRamarks

            dtpReconnectionDate.MinDate = .ConnectionStatusDate.Value
        End With



    End Sub

#End Region

End Class
