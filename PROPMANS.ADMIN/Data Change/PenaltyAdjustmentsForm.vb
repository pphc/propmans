'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 04-16-2012
'
' Last Modified By : 
' Last Modified On : 
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************


Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports BCL.Common
Imports BCL.Payments
Imports BCL.Billings

Public Class PenaltyAdjustmentsForm

#Region "Properties"
    Private _bloaded As Boolean
    Private accountID As String
    Private leaseid As String
    Private adjustment As Double
    Private beforeadjustment As Double
#End Region

#Region "Form Instance"
    Private Shared aForm As PenaltyAdjustmentsForm
    Public Shared Function Instance() As PenaltyAdjustmentsForm
        If aForm Is Nothing Then
            aForm = New PenaltyAdjustmentsForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Forms and Controls Events"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetUIDefaults()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        InvoicePanel.Visible = False
        AdjustmentPanel.Visible = False
        Using frm As AccountLookupForm = New AccountLookupForm
            frm.ShowDialog()

            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                lblUnitOwner.Text = String.Format("{0} - {1}", frm.UnitNumber, frm.CustomerFullName)
                lblCustomerType.Text = frm.CustomerType
                accountID = frm.AccountID
                leaseid = frm.LeaseID
                LoadInvoices()
                InvoicePanel.Visible = True
            Else
                lblUnitOwner.Text = String.Empty
                accountID = String.Empty
            End If
        End Using
    End Sub

    Private Sub cboFeeTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFeeTypes.SelectedIndexChanged
        If Not String.IsNullOrEmpty(accountID) Then
            LoadInvoices()
        End If
    End Sub

    Private Sub btnSaveAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAdjustment.Click
        If Not Common.HasValue(txtRemarks) Then
            MessageBox.Show("Must Provide Remarks for Adjustments")
            txtRemarks.Focus()
            Return
        End If

        If IsAdjustmentValid() Then
            If MessageBox.Show("Save Penalty Adjustments", "Adjustments Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                SavePenaltyAdjustments()
                MessageBox.Show("Penalty Adjustments Saved")
                LoadInvoices()
            End If
        Else
            MessageBox.Show("No Adjustments Made")
        End If
    End Sub

    Private Sub OnEditControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        Dim textbox As TextBox = DirectCast(e.Control, TextBox)

        If grid.CurrentCell.ColumnIndex = grid.Columns("adjustment").Index Then
            AddHandler textbox.KeyPress, AddressOf Decimal_KeyPress
        End If

    End Sub

    Private Sub OnCurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grid.IsCurrentCellDirty Then
            grid.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub OnCellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If grid.Columns(e.ColumnIndex).Name = "select" Then
            If grid.Rows(e.RowIndex).Cells("status").Value.ToString <> "UNPAID" Then
                MessageBox.Show("Only Unpaid Invoices can be adjusted")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub OnCellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If grid.Columns(e.ColumnIndex).Name = "adjustment" Then
            If Not String.IsNullOrEmpty(grid("adjustment", e.RowIndex).Value) Then
                UpdateTotal()
                If IsAdjustmentValid() Then
                    AdjustmentPanel.Visible = True
                Else
                    AdjustmentPanel.Visible = False
                End If


            End If
        End If
    End Sub

    Private Sub OnCellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If grid.Columns(e.ColumnIndex).Name = "select" Then
            If Boolean.Parse(grid("select", e.RowIndex).Value) Then
                grid.Rows(e.RowIndex).Cells("adjustment").ReadOnly = False
                If Not String.IsNullOrEmpty(grid("penalty_amt", e.RowIndex).Value) Then
                    beforeadjustment += Decimal.Parse(grid("penalty_amt", e.RowIndex).Value)
                End If
            Else
                grid.Rows(e.RowIndex).Cells("adjustment").ReadOnly = True
                beforeadjustment -= Decimal.Parse(grid("penalty_amt", e.RowIndex).Value)
                grid("adjustment", e.RowIndex).Value = String.Empty
            End If
            UpdateTotal()
            If IsAdjustmentValid() Then
                AdjustmentPanel.Visible = True
            Else
                AdjustmentPanel.Visible = False
            End If
        End If
    End Sub

    Private Sub Decimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Common.IsNumeric(DirectCast(sender, TextBox).Text, e.KeyChar, True)
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub SetUIDefaults()

        GridHelper.SetGridDisplay(grid, New PenaltyAdjustmentsGridDisplay)

        AddHandler grid.EditingControlShowing, AddressOf OnEditControlShowing
        AddHandler grid.CurrentCellDirtyStateChanged, AddressOf OnCurrentCellDirtyStateChanged
        AddHandler grid.CellBeginEdit, AddressOf OnCellBeginEdit
        AddHandler grid.CellLeave, AddressOf OnCellLeave
        AddHandler grid.CellValueChanged, AddressOf OnCellValueChanged

        LoadFeetypes()

        InvoicePanel.Visible = False
        AdjustmentPanel.Visible = False

    End Sub

    Private Sub LoadFeetypes()

        cboFeeTypes.DropDownStyle = ComboBoxStyle.DropDownList

        Common.BindComboBoxtoList(cboFeeTypes, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))

    End Sub

    Private Sub LoadInvoices()
        adjustment = 0
        beforeadjustment = 0
        UpdateTotal()
        grid.Columns("adjustment").ReadOnly = True
        grid.DataSource = Invoices.GetAllBills(accountID, leaseid, cboFeeTypes.SelectedValue.ToString)
        AdjustmentPanel.Visible = False
    End Sub

    Private Sub UpdateTotal()
        lblbeforeAdjustments.Text = beforeadjustment.ToString("#,##0.00")
        lblAdjustments.Text = GetAdjustmentsAmount.ToString("#,##0.00")
    End Sub

    Private Sub SavePenaltyAdjustments()

        Dim billID As String() = {}
        Dim origpenalty As String() = {}
        Dim penalty As String() = {}
        Dim remarks As String = txtRemarks.Text.Trim
        Dim adjustmentDate As Date = dtpAdjustmentDate.Value.Date

        GetPenaltyAdjustments(billID, origpenalty, penalty)

        Billing.UpdatePenaltyAdjustments(billID, origpenalty, penalty, remarks, adjustmentDate)

    End Sub

    Private Sub GetPenaltyAdjustments(ByRef bills As String(), ByRef origpenalty As String(), ByRef penaltyadjustment As String())
        Dim billID As New ArrayList
        Dim m_origpenalty As New ArrayList
        Dim m_penaltyadjustment As New ArrayList

        For Each row As DataGridViewRow In grid.Rows
            Dim bOk As Boolean
            Boolean.TryParse(row.Cells("select").Value, bOk)
            If bOk Then
                If Not String.IsNullOrEmpty(row.Cells("adjustment").Value) Then
                    If Decimal.Parse(row.Cells("penalty_amt").Value) <> Decimal.Parse(row.Cells("adjustment").Value) Then
                        billID.Add(row.Cells("bill_id").Value.ToString)
                        m_origpenalty.Add(row.Cells("penalty_amt").Value.ToString)
                        m_penaltyadjustment.Add(row.Cells("adjustment").Value.ToString)
                    End If
                End If
            End If
        Next
        bills = DirectCast(billID.ToArray(GetType(String)), String())
        origpenalty = DirectCast(m_origpenalty.ToArray(GetType(String)), String())
        penaltyadjustment = DirectCast(m_penaltyadjustment.ToArray(GetType(String)), String())
    End Sub

    Private Function GetAdjustmentsAmount() As Decimal
        Dim penalty As Decimal
        Dim adjustedpenalty As Decimal

        For Each row As DataGridViewRow In grid.Rows
            Dim bOk As Boolean
            Boolean.TryParse(row.Cells("select").Value, bOk)
            If bOk Then
                If Not String.IsNullOrEmpty(row.Cells("adjustment").Value) Then
                    If Decimal.Parse(row.Cells("penalty_amt").Value) <> Decimal.Parse(row.Cells("adjustment").Value) Then
                        penalty += Decimal.Parse(row.Cells("penalty_amt").Value.ToString)
                        adjustedpenalty += Decimal.Parse(row.Cells("adjustment").Value.ToString)
                    End If
                End If
            End If
        Next

        If penalty > adjustedpenalty Then
            Return Decimal.Negate((adjustedpenalty - penalty))
        Else
            Return adjustedpenalty - penalty
        End If

    End Function

    Private Function IsAdjustmentValid() As Boolean
        For Each row As DataGridViewRow In grid.Rows
            Dim bOk As Boolean
            Boolean.TryParse(row.Cells("select").Value, bOk)
            If bOk Then
                If Not String.IsNullOrEmpty(row.Cells("adjustment").Value) Then
                    If Decimal.Parse(row.Cells("penalty_amt").Value) <> Decimal.Parse(row.Cells("adjustment").Value) Then
                        Return True
                        Exit Function
                    End If
                End If

            End If
        Next
        Return False
    End Function

#End Region


End Class
