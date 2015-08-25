'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Deposits
'Module Description: Payments Deposits
'Date Created: 5/5/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton.Toolkit


Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class DepositsForm

    Private _bloaded As Boolean
    Private _undepositedreceipts As List(Of DepositDetails)

#Region "Form Instance"
    Private Shared aForm As DepositsForm
    Public Shared Function Instance() As DepositsForm
        If aForm Is Nothing Then
            aForm = New DepositsForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and Control Events"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

    'Private Sub dgDeposits_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgDeposits.CellFormatting
    '    If dgDeposits.Columns(e.ColumnIndex).Name = "deposit_type" Then
    '        If e.Value.ToString = "CSH" Then
    '            e.Value = "CASH"
    '        Else
    '            e.Value = "CHECK"
    '        End If
    '    End If
    'End Sub

    Private Sub cboSearchType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchType.SelectedIndexChanged
        pnlDateRange.Visible = False
        cboSearchvalue.Visible = False

        Select Case cboSearchType.SelectedIndex
            Case 0
                pnlDateRange.Visible = True
            Case 1
                PopulateDepositTypes(cboSearchvalue)
                cboSearchvalue.Visible = True
            Case 2
                PopulateDepositoryAccounts(cboSearchvalue)
                cboSearchvalue.Visible = True
        End Select
    End Sub

    Private Sub btnSearchDeposit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDeposit.Click
        btnViewDetails.Visible = False

        Select Case cboSearchType.SelectedIndex
            Case 0
                Dim startDate As Date = dtpStartDate.Value.Date
                Dim endDate As Date = dtpEndDate.Value.Date

                dgDeposits.DataSource = Deposits.GetDepositsbyDateRange(startDate, endDate)
            Case 1
                dgDeposits.DataSource = Deposits.GetDepositsbyDepositType(DepositTypeSource.GetDepositType(cboSearchvalue.SelectedValue.ToString))
            Case 2
                dgDeposits.DataSource = Deposits.GetDepositsbyDepositoryBank(cboSearchvalue.SelectedValue.ToString)
        End Select

        UpdateLabelText()

        If dgDeposits.RowCount > 0 Then
            btnViewDetails.Visible = True
        End If

    End Sub


    Private Sub cboDepositType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepositType.SelectedIndexChanged
        pnlBottom.Visible = False

    End Sub

    Private Sub cboAccountNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccountNumber.SelectedIndexChanged
        If _bloaded Then
            lblDepositoryBank.Text = DepositoryAccountsSource.GetBankName(cboAccountNumber.SelectedValue.ToString)
        End If
    End Sub

    Private Sub btnViewReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReceipts.Click

        Dim frm As New UndepositedReceiptsForm(DepositTypeSource.GetDepositType(cboDepositType.SelectedValue.ToString))

        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            _undepositedreceipts = frm.UndepositedReceipts

            ShowSavePanel()
        Else
            pnlBottom.Visible = False
        End If
    End Sub

    Private Sub btnViewDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDetails.Click
        Dim id As String = dgDeposits.CurrentRow.Cells("deposit_id").Value.ToString

        Dim frm As New DepositedReceiptsForm(id)

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            btnSearchDeposit_Click(Nothing, Nothing)
        End If


    End Sub

    Private Sub btnSaveDeposits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveDeposits.Click
        If MessageBox.Show("Save Deposit", "Save New Deposit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            SaveDeposits()
            pnlBottom.Visible = False
            MessageBox.Show("Deposits Saved")
        End If

    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        pnlDateRange.Visible = False
        cboSearchvalue.Visible = False
        pnlBottom.Visible = False
        btnViewDetails.Visible = False

        dtpDepositDate.Value = Now.Date

        PopulateDepositoryAccounts(cboAccountNumber)
        PopulateDepositTypes(cboDepositType)

        GridHelper.SetGridDisplay(dgDeposits, New DepositsGridDisplay)

        _bloaded = True

        cboSearchType.SelectedIndex = 0
        cboAccountNumber_SelectedIndexChanged(Nothing, Nothing)

        UpdateLabelText()
    End Sub

    Private Sub PopulateDepositoryAccounts(ByRef cbo As KryptonComboBox)
        Common.BindComboBoxtoList(cbo, New DepositoryAccountsSource)

    End Sub

    Private Sub PopulateDepositTypes(ByRef cbo As KryptonComboBox)
        Common.BindComboBoxtoList(cbo, New DepositTypeSource)
    End Sub

    Private Sub UpdateLabelText()

        If dgDeposits.RowCount > 0 Then
            lblRecordCount.Text = dgDeposits.RowCount & " Record(s) Found"
        Else
            lblRecordCount.Text = "No records found"
        End If

    End Sub

    Private Sub ShowSavePanel()
        pnlBottom.Visible = True

        Dim undepositedAmount As Decimal = 0

        For Each rec As DepositDetails In _undepositedreceipts
            undepositedAmount += rec.PaymentAmount
        Next

        lblUndepositedAmount.Text = undepositedAmount.ToString("#,###.00")
        lblReceiptCount.Text = _undepositedreceipts.Count

    End Sub

    Private Sub SaveDeposits()

        Dim newDeposits As New Deposits

        With newDeposits
            .DepositBankID = Integer.Parse(cboAccountNumber.SelectedValue)
            .DepositDate = dtpDepositDate.Value.Date
            .DepositType = DepositTypeSource.GetDepositType(cboDepositType.SelectedValue.ToString)
            .DepositDetails = _undepositedreceipts
            .DepositRemarks = txtDepositRemarks.Text.Trim
        End With

        Deposits.SaveDeposit(newDeposits)
    End Sub

#End Region

End Class
