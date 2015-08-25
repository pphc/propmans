'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 04-28-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports ComponentFactory.Krypton.Toolkit

Imports PROPMANS.BASE_MOD
Imports BCL.Common
Imports BCL.Payments

Public Class PaymentsDataChangeForm

#Region "Properties"
    Private Property PaymentID As String
    Private Enum ActionSet
        Set1
        Set3
    End Enum
#End Region

#Region "Form Instance"
    Private Shared aForm As PaymentsDataChangeForm
    Public Shared Function Instance() As PaymentsDataChangeForm
        If aForm Is Nothing Then
            aForm = New PaymentsDataChangeForm
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
        UISetup()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        chkEntryCancelledReceipt.Checked = False
        If Common.HasValue(txtReceiptNumber) Then
            If FindReceipt() Then
                pnlPaymentsInfo.Visible = True
            Else
                pnlPaymentsInfo.Visible = False
                chkEntryCancelledReceipt.Visible = True
                MessageBox.Show("Receipt Number not existing", "Receipt not existing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub


    Private Sub txtReceiptNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiptNumber.TextChanged
        chkEntryCancelledReceipt.Visible = False
        pnlPaymentsInfo.Visible = False
    End Sub

    Private Sub rdbCondocorp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCondocorp.CheckedChanged
        chkEntryCancelledReceipt.Visible = False
        pnlPaymentsInfo.Visible = False

        txtReceiptNumber.SelectAll()
        txtReceiptNumber.Focus()
    End Sub

    Private Sub chkEntryCancelledReceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEntryCancelledReceipt.CheckedChanged
        pnlPaymentsInfo.Visible = False
        If chkEntryCancelledReceipt.Checked Then
            pnlPaymentsInfo.Visible = True

            lblUnitOwner.Text = String.Empty
            lblUnitNumber.Text = String.Empty

            lblOrNumber.Text = txtReceiptNumber.Text.Trim
            lblReceiptAmount.Text = "0.00"

            lblPayCategory.Text = "REGULAR"

            cboPaymentType.SelectedIndex = 0
            cboPaymentType.Enabled = False
            pnlCheckDetails.Visible = False
            lblDepositedPrompt.Visible = False

            lblIssuedBy.Text = String.Empty
            lblIssuedDate.Text = String.Empty
            txtDataChangeRemarks.Text = String.Empty
            txtCancellationRemarks.Text = String.Empty
            txtCancellationRemarks.Enabled = True
            lblCancelledReceipt.Visible = False
            lblDepositedPrompt.Visible = False
            btnDoAction.Enabled = True
            LoadActions(cboActions, ActionSet.Set3)
        End If
    End Sub

    Private Sub btnDoAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoAction.Click

        If lblDepositedPrompt.Visible Then
            MessageBox.Show(" Official receipt is already deposited", "Cannot change Payment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReceiptNumber.SelectAll()
            txtReceiptNumber.Focus()
            Return
        End If

        If Not IsEntryValid() Then
            Return
        End If

        Dim prompt As String = String.Empty
        Dim caption As String = String.Empty

        Select Case cboActions.Text
            Case "CANCEL RECEIPT"
                caption = "Cancel Receipt Confirmation"
                prompt = "Do you want to cancel receipt?"
            Case "PAYMENT UPDATE"
                caption = "Payment Details Update Confirmation"
                prompt = "Save changes to receipt?"
            Case "SAVE AS CANCELLED RECEIPT"
                caption = "Cancelled Receipt Entry Confirmation"
                prompt = "Save receipt as cancelled?"
        End Select

        If MessageBox.Show(prompt, _
                         caption, _
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 _
                           ) = Windows.Forms.DialogResult.Yes Then
            SaveChanges()

            txtReceiptNumber.Text = String.Empty
            txtReceiptNumber.Focus()
            MessageBox.Show("Changes Saved", "Payments Update Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cboPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentType.SelectedIndexChanged
        pnlCheckDetails.Visible = False
        If cboPaymentType.SelectedIndex = 1 Then
            pnlCheckDetails.Visible = True

            txtCheckNumber.Text = String.Empty
            txtCheckNumber.Focus()
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        pnlPaymentsInfo.Visible = False
        chkEntryCancelledReceipt.Visible = False

        lblCancelledReceipt.Visible = False
        lblDepositedPrompt.Visible = False

        'populate fee types, payment type, check bank
        cboPaymentType.Items.Add("CASH")
        cboPaymentType.Items.Add("CHECK")

        Common.BindComboBoxtoList(cboCheckBank, New BankNamesSource())

        AddHandler txtReceiptNumber.KeyPress, AddressOf Common.Numeric_KeyPress
    End Sub

    Private Function FindReceipt() As Boolean
        Dim ps As List(Of Payment) = Payment.GetReceiptInfo(txtReceiptNumber.Text.Trim, _
                  IIf(rdbUtilities.Checked, ReceiptCompany.Utilities, ReceiptCompany.CondoCorp))
        If ps.Count = 0 Then
            Return False
        Else
            Dim paydetails As New Payment
            Dim idx As Integer = 0
            If ps.Count > 1 Then
                Using frm As New DisplayReceipts(ps)
                    frm.ShowDialog()
                    idx = frm.SelectedReceiptIdx
                End Using
            End If

            paydetails = ps(idx)

            'Display Receipt Info information
            With paydetails
                txtDataChangeRemarks.Text = String.Empty
                txtCancellationRemarks.Text = String.Empty
                Me.PaymentID = .PaymentID
                txtReceiptNumber.Text = .ReceiptNumber
                lblOrNumber.Text = .ReceiptNumber

                lblFeeType.Visible = True
                lblFeeType.Text = GlobalReference.Fee.GetFeeInfobyFeeID(.FeetypeID).FeeDescription
                lblPayCategory.Text = .PayCategory

                lblReceiptAmount.Text = .PaidAmount.ToString("#,##0.00")
                dtpPaymentDate.Value = .ReceiptDate

                cboPaymentType.Enabled = True

                If .PaymentType = "CSH" Then
                    cboPaymentType.SelectedIndex = 0
                    pnlCheckDetails.Visible = False
                Else
                    cboPaymentType.SelectedIndex = 1

                    txtCheckNumber.Text = .CheckNumber
                    dtpCheckDate.Value = .CheckDate
                    cboCheckBank.SelectedValue = .CheckBankId
                    pnlCheckDetails.Visible = True
                End If

                lblUnitNumber.Text = .UnitNumber
                lblUnitOwner.Text = .UnitOwner

                lblCancelledReceipt.Visible = .Status = "CAN"
                btnDoAction.Enabled = .Status <> "CAN"
                cboActions.Enabled = .Status <> "CAN"
                txtDataChangeRemarks.Enabled = .Status <> "CAN"
                txtCancellationRemarks.Enabled = .Status <> "CAN"

                If .Status <> "CAN" Then
                    LoadActions(cboActions, ActionSet.Set1)
                    txtDataChangeRemarks.Text = .ChangeRemarks
                Else
                    txtDataChangeRemarks.Text = .ChangeRemarks
                    txtCancellationRemarks.Text = .CancelledRemarks
                End If

                lblIssuedBy.Text = .IssuedBy
                lblIssuedDate.Text = .IssuedDateTime.ToString
                'TODO last edited by and date

                lblDepositedPrompt.Visible = True

                lblDepositedPrompt.Visible = .IsDeposited

            End With

            Return True
        End If
    End Function

    Private Sub LoadActions(ByRef cbo As KryptonComboBox, ByVal type As ActionSet)
        cbo.Items.Clear()
        If type = ActionSet.Set1 Then
            cbo.Items.Add("PAYMENT UPDATE")
            cbo.Items.Add("CANCEL RECEIPT")
        Else
            cbo.Items.Add("SAVE AS CANCELLED RECEIPT")
        End If
        cbo.SelectedIndex = 0
    End Sub

    Private Sub SaveChanges()
        Dim breissue As Boolean = False
        Select Case cboActions.Text
            Case "CANCEL RECEIPT"
                Payment.CancelPayment(Me.PaymentID, txtCancellationRemarks.Text.Trim)
            Case "PAYMENT UPDATE"
                Dim payinfo As New Payment
                With payinfo
                    .PaymentID = Me.PaymentID
                    '.ReceiptNumber = txtReceiptNumber.Text.Trim
                    .ReceiptDate = dtpPaymentDate.Value.Date
                    .ChangeRemarks = txtDataChangeRemarks.Text.Trim
                    If cboPaymentType.SelectedIndex = 0 Then
                        .PaymentType = "CSH"
                    Else
                        .PaymentType = "CHK"
                        .CheckNumber = txtCheckNumber.Text.Trim
                        .CheckDate = dtpCheckDate.Value.Date
                        'TODO POPULATE CHECKBANK
                        .CheckBankId = cboCheckBank.SelectedValue.ToString
                    End If
                End With

                Payment.UpdateReceiptInfo(payinfo)

            Case "SAVE AS CANCELLED RECEIPT"
                Dim payinfo As New Payment
                With payinfo

                    .AccountID = 1
                    .PaidAmount = 0
                    .PayCategory = "REG"
                    .PaymentType = "CSH"
                    .ReceiptNumber = txtReceiptNumber.Text.Trim
                    .ReceiptDate = dtpPaymentDate.Value.Date
                    .Status = "CAN"
                    If rdbUtilities.Checked Then
                        .PayCompany = ReceiptCompany.Utilities
                        .FeetypeID = 25
                    Else
                        .PayCompany = ReceiptCompany.CondoCorp
                        .FeetypeID = 13
                    End If
                    .CancelledRemarks = txtDataChangeRemarks.Text.Trim

                End With
                Payment.InsertCancelledReceipt(payinfo)

        End Select


    End Sub

    Private Function IsEntryValid() As Boolean
        ErrorProvider1.Clear()

        Dim valid As Boolean = True

        If cboActions.Text = "PAYMENT UPDATE" Then
            If cboPaymentType.Text = "CHECK" Then
                If Not Common.HasValue(txtCheckNumber) Then
                    txtCheckNumber.Focus()
                    valid = False
                End If
            End If
            If Not Common.HasValue(txtDataChangeRemarks) Then
                txtDataChangeRemarks.Focus()
                valid = False
                ErrorProvider1.SetError(lblChangeRemarks, "Enter Value for Change Remarks")
            End If
        Else
            If Not Common.HasValue(txtCancellationRemarks) Then
                txtCancellationRemarks.Focus()
                valid = False
                ErrorProvider1.SetError(lblCancellationRemarks, "Enter Value for Cancellation Remarks")
            End If
        End If

        Return valid

    End Function

#End Region

End Class

