'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: New Meter Reading  
'Module Description: Create, validates reading
'Author: MTRIVO
'Date Created: 8/2/2012
'
'Change Log:
'*****************************************************************

Imports PROPMANS.BASE_MOD.Common



Imports BCL
Imports ComponentFactory.Krypton.Toolkit



Public Class NewMeterReadingForm

    Private UpdateReading As Boolean

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

    Public _bLoaded As Boolean = False

#Region "Form and Control Events"

    Public Sub New(ByVal meterID As String)
        Me.MeterID = meterID
        ReadingHelper = New WaterSystem.MeterReadingHelper(Me.MeterID)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal meterID As String, ByVal readingID As String)
        Me.MeterID = meterID

        UpdateReading = True
        ReadingHelper = New WaterSystem.MeterReadingHelper(Me.MeterID, readingID)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub NewMeterReadingForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub cboPresentStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPresentStatus.SelectedIndexChanged
        If _bLoaded Then
            If cboPresentStatus.Text = "NORMAL" Then
                If Not UpdateReading Then
                    txtPresentReading.Text = String.Empty
                    txtPresentReading.Enabled = True
                    txtPresentReading.Focus()

                    ReadingHelper.PresentReadingInfo.Reading = 0
                    ReadingHelper.PresentReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.NORMAL
                Else
                    txtPresentReading.Text = ReadingHelper.PresentReadingInfo.Reading
                    txtPresentReading.Enabled = True
                    txtPresentReading.Focus()

                    ReadingHelper.PresentReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.NORMAL
                End If

            Else
                txtPresentReading.Text = String.Empty
                txtPresentReading.Enabled = False

                ReadingHelper.PresentReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.AVERAGE
                ReadingHelper.PresentReadingInfo.ReadingCu = ReadingHelper.AverageConsumption
            End If

            UpdateTotalConsumption()
        End If

    End Sub

    Private Sub btnAddAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAdjustments.Click
        btnSubtractAdjustments.Checked = ButtonCheckState.Unchecked

        txtPresentAdjustments_TextChanged(Nothing, Nothing)

        txtPresentAdjustments.SelectAll()
        txtPresentAdjustments.Focus()
    End Sub

    Private Sub btnSubtractAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubtractAdjustments.Click
        btnAddAdjustments.Checked = ButtonCheckState.Unchecked

        txtPresentAdjustments_TextChanged(Nothing, Nothing)

        txtPresentAdjustments.SelectAll()
        txtPresentAdjustments.Focus()
    End Sub

    Private Sub Numeric_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPresentReading.KeyPress, txtPresentAdjustments.KeyPress
        e.Handled = IsNumeric(DirectCast(sender, KryptonTextBox).Text, e.KeyChar, True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsEntryValid() Then

            If Not UpdateReading Then
                ReadingHelper.PresentReadingInfo.ReadingDate = DirectCast(cboPresentReadingMonth.SelectedItem, WaterSystem.ReadingMonth).ReadingDate
                Dim id As String
                id = ReadingHelper.SaveReading()

            Else
                If MessageBox.Show("UPDATE CONFIRMATION", "Update Reading", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ReadingHelper.UpdateReading()
                End If

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtPresentReading_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If HasValue(DirectCast(sender, KryptonTextBox)) Then
            ReadingHelper.PresentReadingInfo.Reading = Decimal.Parse(txtPresentReading.Text)
        Else
            ReadingHelper.PresentReadingInfo.Reading = 0
        End If

        UpdateTotalConsumption()
    End Sub

    Private Sub txtPresentAdjustments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPresentAdjustments.TextChanged
        If HasValue(txtPresentAdjustments) Then
            If btnAddAdjustments.Checked = ButtonCheckState.Checked Then
                ReadingHelper.PresentReadingInfo.ReadingAdjustment = Decimal.Parse(txtPresentAdjustments.Text)
            Else
                ReadingHelper.PresentReadingInfo.ReadingAdjustment = Decimal.Negate(Decimal.Parse(txtPresentAdjustments.Text))
            End If
        Else
            ReadingHelper.PresentReadingInfo.ReadingAdjustment = 0
        End If

        UpdateTotalConsumption()
    End Sub

    Private Sub btnClearReading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPresentReading.Click
        txtPresentReading.Text = String.Empty
        txtPresentReading.Focus()
    End Sub

    Private Sub btnClearAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAdjustments.Click
        txtPresentAdjustments.Text = String.Empty
        txtPresentAdjustments.Focus()
    End Sub

#End Region

#Region "Local Procedure"

    Private Sub UISetup()

        lblAccountName.Text = UnitNumber & " - " & UnitOwnerName
        lblMeterNumber.Text = "METER NO.: " & MeterNumber


        AddHandler txtPresentReading.TextChanged, AddressOf txtPresentReading_TextChanged
        AddHandler cboPresentStatus.SelectedIndexChanged, AddressOf cboPresentStatus_SelectedIndexChanged



        If ReadingHelper.PreviousReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.START Then
            lblAverageConsumption.Visible = False
            cboPresentStatus.Items.Add("NORMAL")
        Else
            lblAverageConsumption.Visible = True
            lblAverageConsumption.Text = "AVERAGE CONSUMPTION - LAST " & _
                        ReadingHelper.AverageConsumptionMonths & " MONTHS: " & _
                        ReadingHelper.AverageConsumption
            cboPresentStatus.Items.Add("NORMAL")
            cboPresentStatus.Items.Add("AVERAGE")
        End If

        If Me.UpdateReading Then
            Me.Text = "UPDATE METER READING"
            DisplayPresentReadingInfo()
            _bLoaded = True
        Else
            lblPresentConsumption.Text = String.Empty
            lblPresentReadingFlag.Text = String.Empty

            'Automatically Get the Next Reading Date in MMMM dd, yyyy format
            cboPresentReadingMonth.DataSource = ReadingHelper.GetValidReadingMonths
            cboPresentReadingMonth.ValueMember = "MonthYear"
            cboPresentReadingMonth.DisplayMember = "MonthYearDescription"

            cboPresentStatus.SelectedIndex = 0

            lblPresentReadingFlag.Text = ReadingHelper.ReadingFlagDescription
            _bLoaded = True
            cboPresentStatus_SelectedIndexChanged(Nothing, Nothing)
        End If

        'Display Last Reading Information
        DisplayPreviousReadingInfo()

        btnSave.Visible = False

    End Sub

    Private Sub UpdateTotalConsumption()
        lblPresentConsumption.Text = ReadingHelper.Consumption
        lblPresentReadingFlag.Text = ReadingHelper.ReadingFlagDescription

        btnSave.Visible = ReadingHelper.IsEntryValid

    End Sub

    Private Sub DisplayPreviousReadingInfo()
        With ReadingHelper.PreviousReadingInfo
            lblPreviousReadingDate.Text = .ReadingDate.ToString("MMMM dd, yyyy")
            lblPreviousStatus.Text = .ReadingStatusName
            lblPreviousReading.Text = .Reading.ToString("###0.0000")
            lblPreviousAdjustments.Text = .ReadingAdjustment.ToString("###0.0000")
            lblPreviousConsumption.Text = .ReadingCu.ToString("###0.0000")
            lblPreviousReadingFlag.Text = .ReadingFlagDescription
            txtPreviousRemarks.Text = .ReadingRemarks
            txtPreviousRemarks.ReadOnly = True
        End With
    End Sub

    Private Sub DisplayPresentReadingInfo()
        With ReadingHelper.PresentReadingInfo
            cboPresentReadingMonth.Items.Add(.ReadingDate.ToString("MMMM dd, yyyy"))
            cboPresentReadingMonth.SelectedIndex = 0
            cboPresentStatus.Text = .ReadingStatusName
            If .ReadingStatus = WaterSystem.MeterReadingStatus.AVERAGE Then
                txtPresentReading.Enabled = False
                txtPresentReading.Text = String.Empty
            End If
            txtPresentReading.Text = .Reading.ToString("###0.0000")
            If .ReadingAdjustment <> 0 Then
                If .ReadingAdjustment < 0 Then
                    btnAddAdjustments.Checked = ButtonCheckState.Unchecked
                    btnSubtractAdjustments.Checked = ButtonCheckState.Checked
                End If
                txtPresentAdjustments.Text = Math.Abs(.ReadingAdjustment).ToString("###0.0000")
            End If
            lblPresentConsumption.Text = .ReadingCu.ToString("###0.0000")
            lblPresentReadingFlag.Text = .ReadingFlagDescription
            txtPresentRemarks.Text = .ReadingRemarks
        End With
    End Sub

    Private Function IsEntryValid() As Boolean
        Dim isValid As Boolean
        ErrorProvider1.Clear()

        If HasValue(txtPresentAdjustments) Or cboPresentStatus.SelectedIndex = 1 Then

            If HasValue(txtPresentRemarks) Then
                ErrorProvider1.SetError(txtPresentRemarks, "")
                ReadingHelper.PresentReadingInfo.ReadingRemarks = txtPresentRemarks.Text.Trim
                isValid = True

            Else
                ErrorProvider1.SetError(txtPresentRemarks, "Pls Provide Remarks on Adjustments")
            End If
        Else
            ReadingHelper.PresentReadingInfo.ReadingRemarks = String.Empty
            ErrorProvider1.SetError(txtPresentRemarks, "")
            isValid = True
        End If

        Return isValid
    End Function

#End Region

  
End Class
