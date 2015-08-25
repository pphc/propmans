'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Billing Parameters
'Module Description: parameters set up needed for the generation of billings
'Date Created: 3/22/2010
'Date Last Modified: 11/5/20121
'
'Change Log:
'
'*****************************************************************


Imports BCL.Utilities
Imports PROPMANS.BASE_MOD
Imports ComponentFactory.Krypton.Toolkit
Imports PROPMAns.BASE_MOD.Common

Public Class BillParametersForm

    Private _paramID As String
    Private _effectiveDate As Date
    Private _loaded As Boolean

#Region "Form Instance"
    Private Shared aForm As BillParametersForm
    Public Shared Function Instance() As BillParametersForm
        If aForm Is Nothing Then
            aForm = New BillParametersForm
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

        AddNumericFieldEvents()
    End Sub
#End Region

#Region "Form and Control Events"

    Private Sub btnNewParameter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewParameter.Click

        Using frm As New NewWaterBillParametersForm(WaterBillParameter.GetNextEffectiveMonth)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgBillParameterRates.DataSource = WaterBillParameter.GetAllWaterBillParameters
                MessageBox.Show("Water Billing Parameter was saved", "New Parameter Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using

    End Sub

    Private Sub btnUpdateParameter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateParameter.Click

        If MessageBox.Show("Update Billing Parameter?", _effectiveDate.ToString("MMMM yyyy") & " Parameter Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If UpdateParameter() = 1 Then
                dgBillParameterRates.DataSource = WaterBillParameter.GetAllWaterBillParameters
                MessageBox.Show("Water Bill Parameter has been updated", "Parameter Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub dgBillParameterRates_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBillParameterRates.SelectionChanged

        With dgBillParameterRates.CurrentRow

            _paramID = .Cells("bill_param_id").Value.ToString

            _effectiveDate = Date.Parse(.Cells("effective_date").Value)
            lblBillingMonth.Text = _effectiveDate.ToString("MMMM yyyy").ToUpper

            txtMinimumConsumption.Text = Decimal.Parse(.Cells("min_consumption").Value).ToString("###0.00")
            txtMinimumCharge.Text = Decimal.Parse(.Cells("min_charge").Value).ToString("###0.00")
            txtRate.Text = Decimal.Parse(.Cells("rate").Value).ToString("###0.00")

            chkWithConsumptionBlock.Checked = (.Cells("w_cons_table").Value.ToString = "Y")

            WaterConsumptionBlockKryptonGroupBox.Visible = chkWithConsumptionBlock.Checked

            btnUpdateParameter.Enabled = Not WaterBillParameter.IsParameterReferenced(_paramID)
        End With

     
    End Sub

    Private Sub cboRateClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRateClass.SelectedIndexChanged
        If _loaded Then
            dgConsumptionBlocks.DataSource = WaterConsumptionBlock.GetConsumptionTables(_paramID, cboRateClass.SelectedValue)
            btnUpdateRates.Enabled = dgConsumptionBlocks.RowCount > 0

        End If

    End Sub

    Private Sub btnNewRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRates.Click

    End Sub

    Private Sub NumericField_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = IsNumeric(DirectCast(sender, KryptonTextBox).Text, e.KeyChar, True)
    End Sub

    Private Sub NumericField_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If HasValue(DirectCast(sender, KryptonTextBox)) Then
            DirectCast(sender, KryptonTextBox).Text = Decimal.Parse(DirectCast(sender, KryptonTextBox).Text).ToString("###0.00")
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        GridHelper.SetGridDisplay(dgBillParameterRates, New WaterBillParametersGridDisplay)

        dgBillParameterRates.DataSource = WaterBillParameter.GetAllWaterBillParameters

        Common.BindComboBoxtoList(cboRateClass, GetType(RateClass))

        _loaded = True
    End Sub

    Private Sub AddNumericFieldEvents()

        For Each ctrl As Control In KryptonGroupBox1.Panel.Controls
            If TypeOf ctrl Is KryptonTextBox Then
                Dim txtctrl As KryptonTextBox = DirectCast(ctrl, KryptonTextBox)

                AddHandler txtctrl.KeyPress, AddressOf NumericField_KeyPress
                AddHandler txtctrl.Leave, AddressOf NumericField_Leave
            End If
        Next

    End Sub

    Private Function UpdateParameter() As Integer
        Dim rowUpdate As Integer = 0

        Dim params As New WaterBillParameter
        With params
            .ParamID = _paramID
            .EffectiveDate = _effectiveDate
            '.EffectiveUntil =

            .MinConsumption = Decimal.Parse(txtMinimumConsumption.Text)
            .MinCharge = Decimal.Parse(txtMinimumCharge.Text)
            .Rate = Decimal.Parse(txtRate.Text)
            .WithConsumptionBlock = chkWithConsumptionBlock.Checked
        End With

        rowUpdate = params.UpdateParameter()

        Return rowUpdate
    End Function

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
#End Region

End Class
