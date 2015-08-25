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


Public Class MetertReplacementForm

#Region "Properties"
    Private _accountID As String
    Public Property AccountID() As String
        Get
            Return _accountID
        End Get
        Private Set(ByVal value As String)
            _accountID = value
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

    Private _unitID As String

    Public Property UnitID() As String
        Get
            Return _unitID
        End Get
        Set(ByVal value As String)
            _unitID = value
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

#End Region

#Region "Form and Control Events"
    Public Sub New(ByVal accountID As String)
        Me.AccountID = accountID

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MeterDisconnectionForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If IsEntryValid() Then
            Dim meterInfo As New WaterSystem.WaterMeter

            With meterInfo
                .UnitID = Me.UnitID
                .MeterNumber = txtMeterNumber.Text.Trim

                .InstallationDate = dtpInstallationDate.Value.Date

                .StartReading = Decimal.Parse(txtStartReading.Text.Trim)

                .InstalledBy = txtInstalledBy.Text.Trim
                .MeterRemarks = txtMeterRemarks.Text.Trim

            End With

            WaterSystem.WaterMeter.InsertNewMeterApplication(meterInfo)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


#End Region

#Region "Local Procedure"

    Private Sub UISetup()
        lblAccountName.Text = UnitNumber & " - " & UnitOwnerName

        dtpInstallationDate.MaxDate = Date.Now
        AddHandler txtStartReading.KeyPress, AddressOf Common.Decimal_KeyPress

    End Sub

    Private Function IsEntryValid() As Boolean
        Dim bValid As Boolean = True
        If HasMeterDetails() Then

            ErrorProvider1.Clear()


            If Common.HasValue(txtMeterNumber) = 0 Then
                ErrorProvider1.SetError(txtMeterNumber, "Enter value for Meter No")
                bValid = False
            Else
                ErrorProvider1.SetError(txtMeterNumber, "")
            End If

            If Not dtpInstallationDate.Checked Then
                ErrorProvider1.SetError(dtpInstallationDate, "Enter value for Installation Date")
                bValid = False
            Else
                ErrorProvider1.SetError(dtpInstallationDate, "")
            End If

            If Common.HasValue(txtStartReading) = 0 Then
                ErrorProvider1.SetError(txtStartReading, "Enter value for Start Reading")
                bValid = False
            Else
                ErrorProvider1.SetError(txtStartReading, "")
            End If
        End If

        Return bValid


    End Function

    Private Function HasMeterDetails() As Boolean
        Return Common.HasValue(txtMeterNumber) Or Common.HasValue(txtStartReading) Or dtpInstallationDate.Checked
    End Function



#End Region

End Class
