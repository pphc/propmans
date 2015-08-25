'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: New Water Billing Parameters Entry
'Module Description: parameters entry needed fro the generation of water bill
'Date Created: 3/22/2010
'Date Last Modified: 1/27/2011
'
'Change Log:
'
'*****************************************************************

Imports BCL.Entities
Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD.Common

Public Class MayniladParametersForm

    Private _applicationDate As Date

#Region "Form Events"

    Public Sub New(ByVal applicationDate As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _applicationDate = applicationDate
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub NewWaterBillingParametersForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub
#End Region

#Region "Control Events"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidateEntry() Then
            If MessageBox.Show("Save Entry?", _applicationDate.ToString("MMMM yyyy") & " parameters", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
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

#End Region

#Region "Local Procedure"

    Private Sub UISetup()
        lblApplicableMonth.Text = _applicationDate.ToString("MMMM yyyy").ToUpper
        AddNumericFieldEvents()
    End Sub

    Private Function ValidateEntry() As Boolean
        Dim bValid As Boolean = True

        For Each ctrl As Control In KryptonPanel.Controls
            If TypeOf ctrl Is KryptonTextBox Then
                If Not HasValue(DirectCast(ctrl, KryptonTextBox)) Then
                    bValid = False
                    DirectCast(ctrl, KryptonTextBox).Focus()
                    Exit For
                End If
            End If
        Next

        Return bValid
    End Function

    Private Function SaveParameters() As Integer
        Dim rowadded As Integer = 0

        Dim params As New MayniladParameters
        With params
            .Period = _applicationDate
            .BulkReading = Decimal.Parse(txtBulkReading.Text)
            .BulkCost = Decimal.Parse(txtBulkCost.Text)
            .TotalReading = Decimal.Parse(txtTotalReading.Text)
            .Powercost = Decimal.Parse(txtPowerCost.Text)
            .Admincost = Decimal.Parse(txtadminCost.Text)
            .Capexfund = Decimal.Parse(txtCapexFund.Text)
            .Mgmtrate = Decimal.Parse(txtMgmtRate.Text)
            .Profitrate = Decimal.Parse(txtProfitRate.Text)
            .Vatrate = Decimal.Parse(txtVATRate.Text)
            .Flatratesetting = Decimal.Parse(txtFlatRateSetting.Text)
        End With

        rowadded = MayniladParameters.InsertParameter(params)

        Return rowadded
    End Function

    Private Sub AddNumericFieldEvents()

        For Each ctrl As Control In KryptonPanel.Controls
            If TypeOf ctrl Is KryptonTextBox Then
                Dim txtctrl As KryptonTextBox = DirectCast(ctrl, KryptonTextBox)

                AddHandler txtctrl.KeyPress, AddressOf NumericField_KeyPress
                AddHandler txtctrl.Leave, AddressOf NumericField_Leave
            End If
        Next

    End Sub
#End Region

End Class
