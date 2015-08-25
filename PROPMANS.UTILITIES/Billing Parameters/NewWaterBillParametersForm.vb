'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: New Water Billing Parameters Entry
'Module Description: parameters entry needed fro the generation of water bill
'Date Created: 3/22/2010
'Date Last Modified: 2/26/2013
'
'Change Log:
'2/26/2013-renamed prompts, added consumption block (MTRIVO)
'*****************************************************************

Imports BCL.Utilities
Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD.Common

Public Class NewWaterBillParametersForm

    Private _billingDate As Nullable(Of Date)

#Region "Form Events"

    Public Sub New(ByVal billingDate As Nullable(Of Date))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _billingDate = billingDate
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub NewWaterBillParametersForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub
#End Region

#Region "Control Events"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateEntry() Then
            If MessageBox.Show("Save New Water Bill Parameter?", "New Water Bill Parameter Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If SaveParameters() = 1 Then
                    DialogResult = Windows.Forms.DialogResult.OK
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()

    End Sub

    Private Sub NumericField_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = IsNumeric(DirectCast(sender, KryptonTextBox).Text, e.KeyChar, True)
    End Sub

    Private Sub NumericField_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If HasValue(DirectCast(sender, KryptonTextBox)) Then
            DirectCast(sender, KryptonTextBox).Text = Decimal.Parse(DirectCast(sender, KryptonTextBox).Text).ToString("###0.00")
        End If
    End Sub

    Private Sub chkWithConsumptionBlock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWithConsumptionBlock.CheckedChanged
        If chkWithConsumptionBlock.Checked Then
            StandardPanel.Enabled = False
            txtMinimumConsumption.Text = "0.00"
            txtMinimumCost.Text = "0.00"
            txtRate.Text = "0.00"
        Else
            StandardPanel.Enabled = True
            txtMinimumConsumption.Text = String.Empty
            txtMinimumCost.Text = String.Empty
            txtRate.Text = String.Empty
            txtMinimumConsumption.Focus()
        End If

    End Sub

#End Region

#Region "Local Procedure"

    Private Sub UISetup()

        If _billingDate.HasValue Then
            lblEffectiveMonth.Text = _billingDate.Value.ToString("MMMM yyyy").ToUpper

            dtpEfffectiveUntil.MinDate = _billingDate.Value.AddMonths(1)
        Else
            dtpEffectiveOn.Visible = True
            dtpEffectiveOn.Value = Date.Now
        End If
 

        AddNumericFieldEvents()

    End Sub

    Private Function ValidateEntry() As Boolean
        Dim bValid As Boolean = True
        ErrorProvider1.Clear()
        For Each ctrl As Control In KryptonPanel.Controls
            If TypeOf ctrl Is KryptonTextBox Then
                If Not HasValue(DirectCast(ctrl, KryptonTextBox)) Then
                    bValid = False
                    ErrorProvider1.SetError(ctrl, "Enter value")
                    DirectCast(ctrl, KryptonTextBox).Focus()

                End If
            End If
        Next

        Return bValid
    End Function

    Private Function SaveParameters() As Integer
        Dim rowadded As Integer = 0

        Dim params As New WaterBillParameter
        With params
            If _billingDate.HasValue Then
                .EffectiveDate = _billingDate
            Else
                .EffectiveDate = dtpEffectiveOn.Value
            End If


            If dtpEfffectiveUntil.Checked Then
                With dtpEfffectiveUntil.Value
                    params.EffectiveUntil = New Date(.Year, .Month, 1)
                End With
            End If

            .MinConsumption = Decimal.Parse(txtMinimumConsumption.Text)
            .MinCharge = Decimal.Parse(txtMinimumCost.Text)
            .Rate = Decimal.Parse(txtRate.Text)
            .WithConsumptionBlock = chkWithConsumptionBlock.Checked
        End With

        rowadded = params.InsertParameter()

        Return rowadded
    End Function


    Private Sub AddNumericFieldEvents()
        AddHandler txtMinimumConsumption.KeyPress, AddressOf NumericField_KeyPress
        AddHandler txtMinimumCost.KeyPress, AddressOf NumericField_KeyPress
        AddHandler txtRate.KeyPress, AddressOf NumericField_KeyPress

        AddHandler txtMinimumConsumption.Leave, AddressOf NumericField_Leave
        AddHandler txtMinimumCost.Leave, AddressOf NumericField_Leave
        AddHandler txtRate.Leave, AddressOf NumericField_Leave


    End Sub
#End Region


End Class
