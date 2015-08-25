'***********************************************************************
' Assembly         : PROPMANS.ADMIN
' Author           : Mark Angelo Rivo
' Created          : 09-24-2013
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

Public Class NewPaymentsDataChangeForm

#Region "Form Instance"
    Private Shared aForm As NewPaymentsDataChangeForm
    Public Shared Function Instance() As NewPaymentsDataChangeForm
        If aForm Is Nothing Then
            aForm = New NewPaymentsDataChangeForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Forms and Controls Events"

    Private Sub PaymentsDataChangeForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblSearchStatus.Visible = False
        chkEntryCancelledReceipt.Checked = False
        If Common.HasValue(txtReceiptNumber) Then
            If FindReceipt() Then
                pnlPaymentsInfo.Visible = True
            Else
                pnlPaymentsInfo.Visible = False
                lblSearchStatus.Visible = True
                chkEntryCancelledReceipt.Visible = True
            End If
        Else
            txtUnitNumber.Focus()
        End If
    End Sub


    Private Sub txtReceiptNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiptNumber.TextChanged
        lblSearchStatus.Visible = False
        chkEntryCancelledReceipt.Visible = False
        pnlPaymentsInfo.Visible = False
    End Sub

    Private Sub rdbCondocorp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCondocorp.CheckedChanged
        lblSearchStatus.Visible = False
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
            txtUnitNumber.Visible = True
            txtUnitNumber.Text = String.Empty
            txtUnitNumber.Focus()
            lblUnitNumber.Visible = True

            cboFeeType.Visible = True
            lblFeeType.Visible = False

            lblPayCategory.Text = "REGULAR"

            cboPaymentType.SelectedIndex = 0
            cboPaymentType.Enabled = False

            lblOrNumber.Text = txtReceiptNumber.Text.Trim
            lblReceiptAmount.Text = "0.00"

            pnlCheckDetails.Visible = False

            lblDepositedPrompt.Visible = False

            LoadActions(cboActions, ActionSet.Set3)
        End If
    End Sub

    Private Sub btnDoAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoAction.Click

        If lblDepositedPrompt.Visible Then
            MessageBox.Show("Cannot Proceed, Receipt is deposited", "Receipt is Deposited")
            txtReceiptNumber.SelectAll()
            txtReceiptNumber.Focus()
            Return
        End If

        If Not IsEntryValid() Then
            Return
        End If

        Dim prompt As String = String.Empty

        Select Case cboActions.Text
            Case "CANCEL RECEIPT"
                prompt = "Do you want to cancel receipt?"
            Case "REENTRY RECEIPT"
                prompt = "Do you want to reissue receipt?"
            Case "SAVE CHANGES"
                prompt = "Save changes to receipt?"
            Case "SAVE RECEIPT"
                prompt = "Save receipt as cancelled?"
                If String.IsNullOrEmpty(lblUnitOwner.Text.Trim) Or lblUnitOwner.Text.Trim = "UNIT NUMBER NOT EXISTING" Then
                    txtUnitNumber.SelectAll()
                    txtUnitNumber.Focus()
                    Return
                End If
        End Select


        If MessageBox.Show(prompt, _
                          cboActions.Text, _
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 _
                           ) = Windows.Forms.DialogResult.Yes Then
            SaveChanges()

            txtReceiptNumber.Text = String.Empty
            txtReceiptNumber.Focus()
            MessageBox.Show("Changes Save")
        End If
    End Sub

    Private Sub ButtonSpecAny1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSpecAny1.Click

        If Common.HasValue(txtUnitNumber) Then
            'AccountInfo.Instance.LoadUnitInfoByUnitNo(txtUnitNumber.Text.Trim)
            'If Not AccountInfo.Instance.AccountInfo Is Nothing Then
            '    lblUnitOwner.Text = AccountInfo.Instance.AccountInfo.CustomerFullName(CustInfo.CustomerNameOrder.FirstNameFirst)
            'Else
            '    lblUnitOwner.Text = "UNIT NUMBER NOT EXISTING"
            'End If


        Else
            lblUnitOwner.Text = "UNIT NUMBER NOT EXISTING"
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

        lblSearchStatus.Visible = False
        chkEntryCancelledReceipt.Visible = False

        lblCancelledReceipt.Visible = False
        lblDepositedPrompt.Visible = False

        'populate fee types, payment type, check bank
        cboPaymentType.Items.Add("CASH")
        cboPaymentType.Items.Add("CHECK")

        Common.BindComboBoxtoList(cboFeeType, New ActiveFeeTypes(GlobalReference.CurrentUser.CompanyAccess))

        Common.BindComboBoxtoList(cboCheckBank, New BankNamesSource())

        AddHandler txtReceiptNumber.KeyPress, AddressOf Common.Numeric_KeyPress
    End Sub

    Private Function FindReceipt() As Boolean
        Dim ps As Payment = Payment.GetReceiptInfo(txtReceiptNumber.Text.Trim, _
                  IIf(rdbUtilities.Checked, ReceiptCompany.Utilities, ReceiptCompany.CondoCorp))
        If ps Is Nothing Then
            Return False
        Else
            'place information
            With ps
                txtReceiptNumber.Text = .ReceiptNumber
                lblOrNumber.Text = .ReceiptNumber

                cboFeeType.SelectedValue = .FeetypeID
                cboFeeType.Visible = False
                lblFeeType.Visible = True
                lblFeeType.Text = cboFeeType.Text


                lblReceiptAmount.Text = .PaidAmount
                dtpPaymentDate.Value = .ReceiptDate
                lblPayCategory.Text = .PayCategory

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

                If .Status = "CAN" Then
                    lblCancelledReceipt.Visible = True
                Else
                    lblCancelledReceipt.Visible = False
                End If

                ' ''pay acctid
                'AccountInfo.Instance.LoadUnitInfoByID(.AccountID)

                'txtUnitNumber.Text = AccountInfo.Instance.AccountInfo.UnitNumber
                'txtUnitNumber.Visible = False
                'lblUnitNumber.Visible = True
                'lblUnitNumber.Text = txtUnitNumber.Text

                'lblUnitOwner.Text = AccountInfo.Instance.AccountInfo.CustomerFullName(CustInfo.CustomerNameOrder.FirstNameFirst)


                lblIssuedBy.Text = .IssuedBy
                lblIssuedDate.Text = .IssuedDateTime.ToString
                'TODO last edited by and date

                If .Status = "CAN" Then
                    LoadActions(cboActions, ActionSet.Set2)
                Else
                    LoadActions(cboActions, ActionSet.Set1)
                End If

                If .IsDeposited Then
                    lblDepositedPrompt.Visible = True
                Else
                    lblDepositedPrompt.Visible = False
                End If

            End With

            Return True
        End If
    End Function

    Private Sub LoadActions(ByRef cbo As KryptonComboBox, ByVal type As ActionSet)
        cbo.Items.Clear()
        If type = ActionSet.Set1 Then
            cbo.Items.Add("SAVE CHANGES")
            cbo.Items.Add("CANCEL RECEIPT")
        ElseIf type = ActionSet.Set2 Then
            cbo.Items.Add("SAVE CHANGES")
            cbo.Items.Add("REENTRY RECEIPT")
        Else
            cbo.Items.Add("SAVE RECEIPT")
        End If
        cbo.SelectedIndex = 0
    End Sub

    Private Sub SaveChanges()
        Dim breissue As Boolean = False
        Select Case cboActions.Text
            Case "CANCEL RECEIPT"
                Payment.CancelPayment(txtReceiptNumber.Text.Trim, _
                                         IIf(rdbUtilities.Checked, ReceiptCompany.Utilities, ReceiptCompany.CondoCorp), _
                                         breissue)
            Case "REENTRY RECEIPT"
                breissue = True
                Payment.CancelPayment(txtReceiptNumber.Text.Trim, _
                                           IIf(rdbUtilities.Checked, ReceiptCompany.Utilities, ReceiptCompany.CondoCorp), _
                                           breissue)
            Case "SAVE CHANGES"
                Dim payinfo As New Payment
                With payinfo
                    .ReceiptNumber = txtReceiptNumber.Text.Trim
                    .ReceiptDate = dtpPaymentDate.Value.Date
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

                'TODO: new receipt number
                Payment.UpdateReceiptInfo(payinfo, _
                IIf(rdbUtilities.Checked, ReceiptCompany.Utilities, ReceiptCompany.CondoCorp), _
                 "")

            Case "SAVE RECEIPT"
                Dim payinfo As New Payment
                With payinfo
                    '    .AccountID = AccountInfo.Instance.AccountInfo.AccountID
                    .FeetypeID = cboFeeType.SelectedValue.ToString
                    .PaidAmount = 0
                    .PayCategory = "REG"
                    .PaymentType = "CSH"
                    .ReceiptNumber = txtReceiptNumber.Text.Trim
                    .ReceiptDate = dtpPaymentDate.Value.Date
                    .Status = "CAN"
                    If rdbUtilities.Checked Then
                        .PayCompany = ReceiptCompany.Utilities
                    Else
                        .PayCompany = ReceiptCompany.CondoCorp
                    End If

                End With
                Payment.InsertCancelledReceipt(payinfo)

        End Select


    End Sub

    Private Function IsEntryValid() As Boolean

        Dim valid As Boolean = True

        If cboActions.Text = "SAVE CHANGES" Then
            If cboPaymentType.Text = "CHECK" Then
                If Not Common.HasValue(txtCheckNumber) Then
                    txtCheckNumber.Focus()
                    valid = False
                End If
            End If
        End If

        Return valid

    End Function

#End Region

    Private Enum ActionSet
        Set1
        Set2
        Set3
    End Enum

End Class

