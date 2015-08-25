'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: New Water Billing Parameters Entry
'Module Description: parameters entry needed fro the generation of water bill
'Date Created: 3/22/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports BCL.Entities
Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD.Common
Public Class DeepWellParameterForm
    Private _paramID As String
    Private _billingDate As Date
    Private _rate As Decimal
    Private _flatRateSetting As Decimal
    Private _flatRateCost As Decimal

    Private _bIsUpdate As Boolean
#Region "Form Events"

    Public Sub New(ByVal billingDate As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _billingDate = billingDate
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal paramID As String, ByVal billingDate As Date, _
    ByVal rate As Decimal, ByVal flatRateSetting As Decimal, ByVal flatRateCost As Decimal)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _paramID = paramID
        _billingDate = billingDate
        _rate = rate
        _flatRateSetting = flatRateSetting
        _flatRateCost = flatRateCost
        ' Add any initialization after the InitializeComponent() call.

        _bIsUpdate = True
    End Sub

    Private Sub NewWaterBillingParametersForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub
#End Region

#Region "Control Events"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateEntry() Then
            If MessageBox.Show("Save Entry ?", _billingDate.ToString("MMMM yyyy") & " parameters", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If _bIsUpdate Then
                    If UpdateParameter() = 1 Then
                        DialogResult = Windows.Forms.DialogResult.OK
                        Close()
                    End If
                Else
                    If SaveParameters() = 1 Then
                        DialogResult = Windows.Forms.DialogResult.OK
                        Close()
                    End If
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
        lblApplicableMonth.Text = _billingDate.ToString("MMMM yyyy").ToUpper
        AddNumericFieldEvents()

        txtWaterRate.Text = _rate
        txtFlatRateSetting.Text = _flatRateSetting
        txtFlatRateCost.Text = _flatRateCost

        If DeepWellParameters.IsBillParameterReference(_paramID) Then
            btnSave.Enabled = False
            lblPrompt.Visible = True
        End If
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

        Dim params As New DeepWellParameters
        With params
            .Period = _billingDate
            .WaterRate = Decimal.Parse(txtWaterRate.Text)
            .Flatratesetting = Decimal.Parse(txtFlatRateSetting.Text)
            .Flatrateamount = Decimal.Parse(txtFlatRateCost.Text)
        End With

        rowadded = DeepWellParameters.InsertParameter(params)

        Return rowadded
    End Function

    Private Function UpdateParameter() As Integer
        Dim rowUpdate As Integer = 0

        Dim params As New DeepWellParameters
        With params
            .ParamID = _paramID
            .Period = _billingDate
            .WaterRate = Decimal.Parse(txtWaterRate.Text)
            .Flatratesetting = Decimal.Parse(txtFlatRateSetting.Text)
            .Flatrateamount = Decimal.Parse(txtFlatRateCost.Text)
        End With

        rowUpdate = DeepWellParameters.UpdateParameter(params)

        Return rowUpdate
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
