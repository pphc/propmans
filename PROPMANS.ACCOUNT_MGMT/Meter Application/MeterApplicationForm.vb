'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Meter Application
'Module Description: parameters set up needed for the generation of billings
'Author: Mark Angelo Rivo
'Date Created: 11/5/2012
'Date Last Modified: 
'
'Change Log:
'
'*****************************************************************
Imports ComponentFactory.Krypton.Toolkit
Imports BCL

Imports PROPMANS.BASE_MOD
Imports PROPMANS


Public Class MeterApplicationForm

#Region "Form Instance"

    Private Shared aForm As MeterApplicationForm

    Public Shared Function Instance() As MeterApplicationForm

        If aForm Is Nothing Then
            aForm = New MeterApplicationForm
        End If
        Return aForm

    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        aForm = Nothing

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

#End Region

#Region "Properties"
    Private _bloaded As Boolean ' = False

    Private ReadOnly Property UnitID() As String
        Get
            Return dgMeterApplications.CurrentRow.Cells("unit_id").Value.ToString
        End Get
    End Property

    Private ReadOnly Property AccountID() As String
        Get
            Return dgMeterApplications.CurrentRow.Cells("account_id").Value.ToString
        End Get
    End Property

    Private ReadOnly Property MeterId() As String
        Get
            Return dgMeterApplications.CurrentRow.Cells("meter_id").Value.ToString
        End Get
    End Property

    Private ReadOnly Property UnitNumber() As String
        Get
            Return dgMeterApplications.CurrentRow.Cells("unit_number").Value.ToString
        End Get
    End Property

    Private ReadOnly Property UnitOwnerName() As String
        Get
            Return dgMeterApplications.CurrentRow.Cells("unit_owner").Value.ToString
        End Get
    End Property

    Private ReadOnly Property MeterStatus() As String
        Get
            Return dgMeterApplications.CurrentRow.Cells("meter_status").Value.ToString
        End Get
    End Property

    Private ReadOnly Property WaterApplicationDate() As String
        Get
            Return dgMeterApplications.CurrentRow.Cells("water_application_date").Value.ToString
        End Get
    End Property

#End Region

#Region "Form & Control Events"

    Private Sub cboSearchType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtSearchvalue.SelectAll()
        txtSearchvalue.Focus()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtSearchvalue.Text = String.Empty
        txtSearchvalue.Focus()
    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        If Common.HasValue(txtSearchvalue) Then
            Dim searchvalue As String = txtSearchvalue.Text.Trim

            _bloaded = False
            Select Case cboSearchType.SelectedIndex
                Case 0 ' search by Unit Number
                    dgMeterApplications.DataSource = WaterSystem.WaterMeter.GetAllUnitsMeterApplicationsByUnitNumber(searchvalue)
                Case 1 ' search by Meter Number
            End Select

            _bloaded = True

            dgMeterApplications_SelectionChanged(Nothing, Nothing)
        Else
            txtSearchvalue.Focus()
        End If
    End Sub

    Private Sub btnViewAllCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAllCustomer.Click
        _bloaded = False
        dgMeterApplications.DataSource = WaterSystem.WaterMeter.GetAllUnitsMeterApplications

        _bloaded = True

        dgMeterApplications_SelectionChanged(Nothing, Nothing)
        'UpdateLabelText()
    End Sub

    Private Sub dgMeterApplications_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMeterApplications.SelectionChanged
        If _bloaded Then
            If dgMeterApplications.RowCount > 0 Then
                NewEntryDefaults()

                Dim hasUnitOwner As Boolean = Not String.IsNullOrEmpty(Me.UnitOwnerName)

                If hasUnitOwner Then
                    lblAccountName.Text = String.Format("{0} - {1}", Me.UnitNumber, Me.UnitOwnerName)
                    lblApplicationNumber.Text = "WS-" & Me.AccountID.PadLeft(4, "0")
                Else
                    lblAccountName.Text = Me.UnitNumber
                    lblApplicationNumber.Text = String.Empty
                End If

                Select Case Me.MeterStatus
                    Case "NOT INSTALLED"
                        btnUpdateApplication.Text = "SAVE NEW METER APPLICATION"
                        btnUpdateApplication.Enabled = hasUnitOwner

                        lblApplicationNumber.Text = String.Empty
                    Case "PENDING"
                        dtpApplicationDate.Value = Me.WaterApplicationDate
                        btnUpdateApplication.Text = "UPDATE METER APPLICATION"
                        btnUpdateApplication.Enabled = True
                    Case "INSTALLED"
                        dtpApplicationDate.Value = Me.WaterApplicationDate
                        Dim ApplicationUpdatable As Boolean

                        btnUpdateApplication.Text = "UPDATE METER APPLICATION"
                        DisplayMeterApplicationDetails(ApplicationUpdatable)

                        btnUpdateApplication.Enabled = ApplicationUpdatable
                End Select

                PreviewFormDropButton.Enabled = IIf(Me.MeterStatus <> "NOT INSTALLED", True, False)
            Else
                NewEntryDefaults()
                btnUpdateApplication.Enabled = False
                PreviewFormDropButton.Enabled = False
            End If

        End If
    End Sub

    Private Sub btnUpdateApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateApplication.Click

        Dim updateSuccess As Boolean
        If btnUpdateApplication.Text = "SAVE NEW METER APPLICATION" Then
            If MessageBox.Show("Save Meter Application", "New Meter Application", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                If IsEntryValid() Then
                    SaveNewMeterApplication()
                    updateSuccess = True

                End If
            End If
        Else
            If MessageBox.Show("Update Meter Application", "Update Meter Application", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                If IsEntryValid() Then
                    UpdateMeterApplication()
                    updateSuccess = True
                End If

            End If
        End If

        If updateSuccess Then
            MessageBox.Show("Meter Application Saved")
            txtSearchvalue.Text = Me.UnitNumber
            btnSearchCustomer_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub PreviewMeterApplicationContextMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewMeterApplicationContextMenu.Click

        Using rps As New REPORTS.ReportStore

            Dim ms As New WaterSystem.WaterMeter
            ms.ApplicationDate = dtpApplicationDate.Value
            ms.WaterApplicationNumber = lblApplicationNumber.Text

            If HasMeterDetails() Then
                ms.MeterNumber = txtMeterNumber.Text
                ms.InstallationDate = dtpInstallationDate.Value
                ms.StartReading = txtStartReading.Text
                ms.InstalledBy = txtInstalledBy.Text
            End If

            With dgMeterApplications.CurrentRow
                rps.LoadReport(New REPORTS.WaterMeterApplicationReport(ms, .Cells("unit_number").Value.ToString, .Cells("unit_owner").Value.ToString))
            End With


        End Using

    End Sub

    Private Sub PreviewFormDropButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewFormDropButton.Click
        KryptonContextMenu1.Show(sender)
    End Sub

    Private Sub PreviewWSAgreementContextMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewWSAgreementContextMenu.Click
        Using rps As New REPORTS.ReportStore
            With dgMeterApplications.CurrentRow
                rps.LoadReport(New REPORTS.WaterServicesAgreementReport(Me.AccountID))
            End With

        End Using
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        'set default search type
        cboSearchType.SelectedIndex = 0
        cboSearchType.Enabled = False
        txtSearchvalue.CharacterCasing = CharacterCasing.Upper

        AddHandler txtMeterNumber.KeyPress, AddressOf Common.Numeric_KeyPress
        AddHandler txtStartReading.KeyPress, AddressOf Common.Decimal_KeyPress

        'set datagridview column display
        GridHelper.SetGridDisplay(dgMeterApplications, New MeterApplicationGridDisplay)

        PreviewFormDropButton.Enabled = False
        btnUpdateApplication.Enabled = False


        lblApplicationNumber.Text = String.Empty
        lblAccountName.Text = String.Empty
        NewEntryDefaults()




    End Sub

    Private Sub NewEntryDefaults()
        dtpApplicationDate.Value = Date.Today
        lblApplicationNumber.Text = String.Empty
        txtMeterNumber.Text = String.Empty
        dtpInstallationDate.Value = Date.Today
        dtpInstallationDate.Checked = False
        txtStartReading.Text = String.Empty
        txtInstalledBy.Text = String.Empty
        txtMeterRemarks.Text = String.Empty
    End Sub

    Private Sub DisplayMeterApplicationDetails(ByRef isUpdatable As Boolean)

        With WaterSystem.WaterMeter.GetMeterInfoByMeterID(Me.MeterId)
            txtMeterNumber.Text = .MeterNumber
            dtpInstallationDate.Value = .InstallationDate
            txtStartReading.Text = .StartReading
            txtInstalledBy.Text = .InstalledBy
            txtMeterRemarks.Text = .MeterRemarks
        End With

        isUpdatable = False
    End Sub

    Private Sub SaveNewMeterApplication()

        'TODO Move UpdateMeterApplicationDate to Customer Accounts
        WaterSystem.WaterMeter.UpdateMeterApplicationDate(Me.AccountID, dtpApplicationDate.Value)

        If HasMeterDetails() Then
             
        End If

    End Sub

    Private Sub UpdateMeterApplication()

        If HasMeterDetails() Then

            Dim meterInfo As New WaterSystem.WaterMeter

            If Not String.IsNullOrEmpty(Me.MeterId) Then
                meterInfo.MeterID = Me.MeterId
            Else
                meterInfo.UnitID = Me.UnitID
            End If

            With meterInfo
                .MeterNumber = txtMeterNumber.Text.Trim

                If dtpInstallationDate.Checked Then
                    .InstallationDate = dtpInstallationDate.Value.Date
                End If

                If Common.HasValue(txtStartReading) Then
                    meterInfo.StartReading = Decimal.Parse(txtStartReading.Text.Trim)
                End If

                .InstalledBy = txtInstalledBy.Text.Trim
                .MeterRemarks = txtMeterRemarks.Text.Trim

            End With


            If String.IsNullOrEmpty(Me.MeterId) Then
                WaterSystem.WaterMeter.InsertNewMeterApplication(meterInfo)
            Else
                WaterSystem.WaterMeter.UpdateMeterApplication(meterInfo)
            End If

        End If

    End Sub

    Private Function HasMeterDetails() As Boolean
        Return Common.HasValue(txtMeterNumber) Or Common.HasValue(txtStartReading) Or dtpInstallationDate.Checked
    End Function

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
#End Region

End Class
