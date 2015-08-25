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


Public Class MeterDisconnectionForm


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

    Private Sub cboDisconnectionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDisconnectionType.SelectedIndexChanged
        pnlOtherReason.Visible = False
        pnlReasonforDisconnection.Visible = cboDisconnectionType.SelectedIndex.Equals(1)
    End Sub

    Private Sub cboDisconnectionReason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDisconnectionReason.SelectedIndexChanged
        pnlOtherReason.Visible = cboDisconnectionReason.SelectedIndex.Equals(2)
        txtDisconnectionOtherReason.Focus()
    End Sub

    Private Sub btnAddAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAdjustments.Click
        btnSubtractAdjustments.Checked = ButtonCheckState.Unchecked

        txtDisconnectionAdjustments_TextChanged(Nothing, Nothing)

        txtDisconnectionAdjustments.SelectAll()
        txtDisconnectionAdjustments.Focus()
    End Sub

    Private Sub btnSubtractAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubtractAdjustments.Click
        btnAddAdjustments.Checked = ButtonCheckState.Unchecked

        txtDisconnectionAdjustments_TextChanged(Nothing, Nothing)

        txtDisconnectionAdjustments.SelectAll()
        txtDisconnectionAdjustments.Focus()
    End Sub

    Private Sub btnClearReading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPresentReading.Click
        txtDisconnectionReading.Text = String.Empty
        txtDisconnectionReading.Focus()
    End Sub

    Private Sub btnClearAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAdjustments.Click
        txtDisconnectionAdjustments.Text = String.Empty
        txtDisconnectionAdjustments.Focus()
    End Sub

    Private Sub txtDisconnectionReading_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisconnectionReading.TextChanged
        If HasValue(DirectCast(sender, KryptonTextBox)) Then
            ReadingHelper.PresentReadingInfo.Reading = Decimal.Parse(txtDisconnectionReading.Text)
        Else
            ReadingHelper.PresentReadingInfo.Reading = 0
        End If

        UpdateTotalConsumption()
    End Sub

    Private Sub txtDisconnectionAdjustments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisconnectionAdjustments.TextChanged
        If HasValue(txtDisconnectionAdjustments) Then
            If btnAddAdjustments.Checked = ButtonCheckState.Checked Then
                ReadingHelper.PresentReadingInfo.ReadingAdjustment = Decimal.Parse(txtDisconnectionAdjustments.Text)
            Else
                ReadingHelper.PresentReadingInfo.ReadingAdjustment = Decimal.Negate(Decimal.Parse(txtDisconnectionAdjustments.Text))
            End If
        Else
            ReadingHelper.PresentReadingInfo.ReadingAdjustment = 0
        End If

        UpdateTotalConsumption()
    End Sub

    Private Sub cboDisconnectionReadingCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDisconnectionReadingCategory.SelectedIndexChanged
        If cboDisconnectionReadingCategory.Text = "NORMAL" Then
            txtDisconnectionReading.Text = String.Empty
            txtDisconnectionReading.Enabled = True
            txtDisconnectionReading.Focus()

            ReadingHelper.PresentReadingInfo.Reading = 0
            ReadingHelper.PresentReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.NORMAL
        Else
            txtDisconnectionReading.Text = String.Empty
            txtDisconnectionReading.Enabled = False

            ReadingHelper.PresentReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.AVERAGE
            ReadingHelper.PresentReadingInfo.ReadingCu = ReadingHelper.AverageConsumption
        End If

        UpdateTotalConsumption()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsEntryValid() Then
            ReadingHelper.PresentReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.DISCONNECTION
            ReadingHelper.PresentReadingInfo.ReadingDate = dtpDisconnectionReadingDate.Value
            Dim id As String

            id = ReadingHelper.SaveReading()

            Dim md As New WaterSystem.WaterMeter

            md.MeterID = Me.MeterID
            md.ConnectionStatusDate = dtpDisconnectionReadingDate.Value
            md.ConnectionStatus = Common.ConvertDBValueToEnum(Of WaterSystem.MeterConnectionStatus)(Common.ConvertEnumtoDBValue(cboDisconnectionType.SelectedValue))


            If cboDisconnectionType.SelectedIndex = 1 Then
                If cboDisconnectionReason.SelectedIndex <> 2 Then
                    md.ConnectionStatusRamarks = Common.ConvertEnumtoDescription(cboDisconnectionReason.SelectedValue)
                Else
                    md.ConnectionStatusRamarks = txtDisconnectionOtherReason.Text.Trim
                End If
            Else
                md.ConnectionStatusRamarks = Common.ConvertEnumtoDescription(cboDisconnectionType.SelectedValue)
            End If

            md.DisconnectMeter()

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
        lblMeterNumber.Text = "METER NO.: " & MeterNumber
        lblAverageConsumption.Text = ""

        BindComboBoxtoList(cboDisconnectionType, GetType(WaterSystem.DisconnectionType))
        BindComboBoxtoList(cboDisconnectionReason, GetType(WaterSystem.DisconnectionReason))

        'pnlReasonforDisconnection.Visible= False 
        'pnlOtherReason .Visible =False 

        With ReadingHelper.PreviousReadingInfo
            lblPreviousReadingMonth.Text = .ReadingDate.ToString("MMMM dd, yyyy")
            lblPreviousReading.Text = .Reading.ToString("###0.0000")
            lblPreviousReadingStatus.Text = .ReadingStatusName
            lblPreviousReadingConsumption.Text = .ReadingCu.ToString("###0.0000")
            lblPreviousReadingAdjustment.Text = .ReadingAdjustment.ToString("###0.0000")
            lblPreviousReadingFlag.Text = .ReadingFlagDescription
            'txtPreviousRemarks.Text = .ReadingRemarks
            dtpDisconnectionReadingDate.MinDate = .ReadingDate
            dtpDisconnectionReadingDate.MaxDate = Now.Date
        End With


        If ReadingHelper.PreviousReadingInfo.ReadingStatus = WaterSystem.MeterReadingStatus.START Then
            lblAverageConsumption.Visible = False
            cboDisconnectionReadingCategory.Items.Add("NORMAL")
        Else
            lblAverageConsumption.Visible = True
            lblAverageConsumption.Text = "AVERAGE CONSUMPTION - LAST " & _
                        ReadingHelper.AverageConsumptionMonths & " MONTHS: " & _
                        ReadingHelper.AverageConsumption
            cboDisconnectionReadingCategory.Items.Add("NORMAL")
            cboDisconnectionReadingCategory.Items.Add("AVERAGE")
        End If

        cboDisconnectionReadingCategory.SelectedIndex = 0

        ForwardConsumptionCheckBox.Visible = False
    End Sub

    Private Sub UpdateTotalConsumption()
        lblDisconnectionConsumption.Text = ReadingHelper.Consumption & " " & ReadingHelper.ReadingFlagDescription
        ' lblPresentReadingFlag.Text = ReadingHelper.ReadingFlagDescription

        ForwardConsumptionCheckBox.Visible = ReadingHelper.Consumption > 0

        btnSave.Visible = ReadingHelper.IsEntryValid

    End Sub

    Private Function IsEntryValid() As Boolean
        Dim isValid As Boolean
        ErrorProvider1.Clear()

        If cboDisconnectionReason.SelectedIndex = 2 Then
            If HasValue(txtDisconnectionOtherReason) Then
                ErrorProvider1.SetError(txtDisconnectionOtherReason, "")
                isValid = True
            Else
                ErrorProvider1.SetError(txtDisconnectionOtherReason, "Pls Specify Disconnection Reason")
                Return isValid
            End If
        End If

        If HasValue(txtDisconnectionAdjustments) Then

            If HasValue(txtAdjustmentRemarks) Then
                ErrorProvider1.SetError(txtAdjustmentRemarks, "")
                ReadingHelper.PresentReadingInfo.ReadingRemarks = txtAdjustmentRemarks.Text.Trim
                isValid = True

            Else
                ErrorProvider1.SetError(txtAdjustmentRemarks, "Pls Provide Remarks on Adjustments")
            End If
        Else
            ReadingHelper.PresentReadingInfo.ReadingRemarks = String.Empty
            ErrorProvider1.SetError(txtAdjustmentRemarks, "")
            isValid = True
        End If

        Return isValid
    End Function
#End Region






End Class
