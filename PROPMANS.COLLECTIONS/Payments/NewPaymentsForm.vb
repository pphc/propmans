'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Payments Entry Module
'Module Description: save and print payment transactions
'Date Created: 3/8/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************


Imports BCL.Payments

Imports ComponentFactory.Krypton
Imports PROPMANS.BASE_MOD
Imports BCL.Common
Imports BCL.Checks


Public Class NewPaymentsForm

#Region "Properties"
    Private _bloaded As Boolean

    Private currentReceiptNumber As String
    Private billInvoices As List(Of PaymentBilling)

    Private pay As Payment

    Private _unitNumber As String
    Public Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
        Set(value As String)
            _unitNumber = value
        End Set
    End Property

    Private _unitOwnerName As String
    Public Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
        Set(value As String)
            _unitOwnerName = value
        End Set
    End Property

    Private _accountID As String
    Public Property AccountID() As String
        Get
            Return _accountID
        End Get
        Set(value As String)
            _accountID = value
        End Set
    End Property

    Private _leaseID As String
    Public Property LeaseID As String
        Get
            Return _leaseID
        End Get
        Private Set(value As String)
            _leaseID = value
        End Set
    End Property


    Private _checkID As String
    Public Property CheckID As String
        Get
            Return _checkID
        End Get
        Private Set(value As String)
            _checkID = value
        End Set
    End Property

    Public ReadOnly Property IsAdvancePayment() As Boolean
        Get
            Return IIf(cboPayCategory.SelectedIndex = 1, True, False)
        End Get
    End Property

    Public ReadOnly Property IsCreditMemo() As Boolean
        Get
            Return IIf(cboPaymentType.Text = "CREDIT MEMO", True, False)
        End Get
    End Property

    Public ReadOnly Property IsCheckPayment() As Boolean
        Get
            Return IIf(cboPaymentType.Text = "CHECK", True, False)
        End Get
    End Property

    Public ReadOnly Property IsManualPaymentEntry() As Boolean
        Get
            Return chkManualTransaction.Checked
        End Get
    End Property


    Public ReadOnly Property PrintRemarks() As Boolean
        Get
            Return chkPrintRemarks.Checked
        End Get
    End Property
#End Region

#Region "Form Instance"
    Private Shared aForm As NewPaymentsForm
    Public Shared Function Instance() As NewPaymentsForm
        If aForm Is Nothing Then
            aForm = New NewPaymentsForm
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

    Private Sub btnSearchAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccount.Click
        Using frm As AccountLookupForm = New AccountLookupForm()
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                AccountID = frm.AccountID
                LeaseID = frm.LeaseID

                UnitNumber = frm.UnitNumber
                UnitOwnerName = frm.CustomerFullName

                lblUnitNumber.Text = UnitNumber
                lblCustomerName.Text = UnitOwnerName
                lblCustomerType.Text = frm.CustomerType

                PaymentDetailsGroupBox.Visible = True
                ActionPanel.Visible = True

                cboPaymentType_SelectedIndexChanged(Nothing, Nothing)

                cboPayCategory.SelectedIndex = 0
                cboPayCategory_SelectedIndexChanged(Nothing, Nothing)

            Else
                AccountID = String.Empty
                LeaseID = String.Empty

                lblUnitNumber.Text = String.Empty
                lblCustomerName.Text = String.Empty

                PaymentDetailsGroupBox.Visible = False
                ActionPanel.Visible = False
            End If
        End Using
    End Sub

    Private Sub cboPayCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPayCategory.SelectedIndexChanged
        If _bloaded Then
            btnViewInvoice.Visible = False
            btnSavePayment.Visible = IsAdvancePayment
            pnlDiscounts.Visible = IsAdvancePayment

            txtReceiptAmount.Text = String.Empty
            txtReceiptAmount.ReadOnly = Not IsAdvancePayment

            If IsAdvancePayment Then
                _bloaded = False
                PopulateFeeTypes()
                _bloaded = True

                txtReceiptAmount.SelectAll()
                txtReceiptAmount.Focus()
                cboInvoiceFeeType_SelectedIndexChanged(Nothing, Nothing)
                lblAmountPrompt.Text = "ADVANCE AMOUNT"
            Else
                _bloaded = False
                PopulateUnpaidInvoice()
                _bloaded = True
                cboInvoiceFeeType_SelectedIndexChanged(Nothing, Nothing)

                If cboInvoiceFeeType.Items.Count > 0 Then
                    btnViewInvoice.Visible = True
                    btnViewInvoice.Focus()
                End If
                lblAmountPrompt.Text = "INVOICE AMOUNT"
            End If

            pnlReceiptNumber.Visible = Not IsCreditMemo

        End If
    End Sub

    Private Sub cboInvoiceFeeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceFeeType.SelectedIndexChanged
        If _bloaded Then
            If Not IsAdvancePayment Then
                txtReceiptAmount.Text = String.Empty
                btnSavePayment.Visible = False
                btnViewInvoice.Focus()
            Else
                txtReceiptAmount.SelectAll()
                txtReceiptAmount.Focus()
            End If

            'Get Correct OR Series
            currentReceiptNumber = GetReceiptNumber()
            txtReceiptNumber.Text = currentReceiptNumber
            ClearCheckDetails()
        End If
    End Sub

    Private Sub cboPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentType.SelectedIndexChanged
        If _bloaded Then
            pnlReceiptNumber.Visible = Not IsCreditMemo
            chkManualTransaction.Visible = Not IsCreditMemo

            If IsCreditMemo Or IsManualPaymentEntry Then
                btnSavePayment.Text = "SAVE PAYMENT"
            Else
                btnSavePayment.Text = "PRINT RECEIPT"
            End If

            If IsCheckPayment Then
                pnlCheckDetails.Height = 130
                txtCheckNumber.SelectAll()
                txtCheckNumber.Focus()
            Else
                pnlCheckDetails.Height = 0
            End If
            ClearCheckDetails()

        End If
    End Sub

    Private Sub chkManualTransaction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManualTransaction.CheckedChanged
        txtReceiptNumber.ReadOnly = Not IsManualPaymentEntry

        If IsCreditMemo Or IsManualPaymentEntry Then
            btnSavePayment.Text = "SAVE PAYMENT"
            txtReceiptNumber.SelectAll()
            txtReceiptNumber.Focus()

        Else
            btnSavePayment.Text = "PRINT RECEIPT"
            txtReceiptNumber.Text = currentReceiptNumber
        End If

        pnlManualEntryReason.Visible = IsManualPaymentEntry
    End Sub

    Private Sub btnViewInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewInvoice.Click
        Using frm As New UnpaidInvoicessForm
            frm.AccountID = AccountID
            frm.LeaseID = LeaseID
            frm.FeeCode = cboInvoiceFeeType.SelectedValue.ToString

            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim receiptAmount As Decimal = frm.ReceiptAmount

                If receiptAmount > 0 Then
                    txtReceiptAmount.Text = receiptAmount
                    txtReceiptNumber.Text = currentReceiptNumber

                    pnlReceiptNumber.Visible = Not IsCreditMemo
                    pnlReceiptDate.Visible = True
                    btnSavePayment.Visible = True
                    btnSavePayment.Focus()

                    billInvoices = frm.BillInvoices
                End If
            Else
                txtReceiptAmount.Text = String.Empty

                pnlReceiptNumber.Visible = False
                'pnlReceiptDate.Visible = False
                btnSavePayment.Visible = False
            End If
        End Using
    End Sub

    Private Sub txtDiscountPercentage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPercentage.TextChanged

        If Common.HasValue(txtReceiptAmount) Then
            Dim amountDue As Decimal = Decimal.Parse(txtReceiptAmount.Text)
            Dim percentage As Decimal = 0

            Decimal.TryParse(txtDiscountPercentage.Text, percentage)

            If percentage > 0 Then
                Dim discountAmount As Decimal = (amountDue * (percentage / 100)).ToString("#,###.00")
                txtDiscountAmount.Text = discountAmount
                txtNetofDiscount.Text = amountDue - discountAmount
            Else
                txtDiscountAmount.Text = String.Empty
                txtNetofDiscount.Text = String.Empty
            End If
        Else
            txtDiscountPercentage.Text = String.Empty
            txtDiscountAmount.Text = String.Empty
            txtNetofDiscount.Text = String.Empty
        End If


    End Sub

    Private Sub txtReceiptAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptAmount.TextChanged
        txtDiscountPercentage.Text = String.Empty
        txtDiscountAmount.Text = String.Empty
    End Sub

    Private Sub btnSavePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePayment.Click
        If ValidateEntry() Then
            SavePaymentEntry()
        End If
    End Sub

    Private Sub btnShowPDC_Click(sender As Object, e As EventArgs) Handles btnShowPDC.Click

        If cboPaymentType.SelectedValue = "CHK" Then
            Using frm As New ViewPostDatedChecksForm
                frm.AccountID = Me.AccountID
                frm.FeeTypeID = Me.cboInvoiceFeeType.SelectedValue
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    pnlCheckDetails.Enabled = False
                    With frm.SelectedCheckInfo.CheckInfo
                        txtCheckNumber.Text = .CheckNumber
                        dtpCheckDate.Value = .CheckDate
                        cboCheckBank.SelectedValue = .Bank.BankID
                        cboCheckBranch.SelectedValue = .Branch.BranchID
                    End With
                    txtCheckAmount.Text = frm.SelectedCheckInfo.CheckAmount
                    Me.CheckID = frm.SelectedCheckInfo.CheckInfo.CheckID

                Else
                    ClearCheckDetails()
                End If
            End Using
        End If

    End Sub
#End Region

#Region "Local Procedures"
    Private Sub ClearCheckDetails()
        txtCheckNumber.Text = String.Empty
        dtpCheckDate.Value = Date.Now
        cboCheckBank.SelectedIndex = 0
        cboCheckBranch.SelectedIndex = 0
        txtCheckAmount.Text = String.Empty
        Me.CheckID = String.Empty
        pnlCheckDetails.Enabled = True
    End Sub

    Private Sub UISetup()

        PopulatePaymentCat()
        PopulatePaymentTypes()
        PopulateBanks()
        PopulateBankBranch()

        AddHandler txtReceiptAmount.KeyPress, AddressOf Common.Decimal_KeyPress
        AddHandler txtCheckAmount.KeyPress, AddressOf Common.Decimal_KeyPress
        AddHandler txtReceiptNumber.KeyPress, AddressOf Common.Numeric_KeyPress

        lblUnitNumber.Text = String.Empty
        lblCustomerName.Text = String.Empty
        lblCustomerType.Text = String.Empty

        dtpReceiptDate.Value = Now.Date
        dtpReceiptDate.MaxDate = Now.Date
        txtReceiptNumber.ReadOnly = True

        PaymentDetailsGroupBox.Visible = False
        ActionPanel.Visible = False
        pnlManualEntryReason.Visible = False
        'btnViewInvoice.Visible = False
        'btnSavePayment.Visible = False

        _bloaded = True
    End Sub

    Private Sub PopulateUnpaidInvoice()
        If String.IsNullOrEmpty(LeaseID) Then
            Common.BindComboBoxtoList(cboInvoiceFeeType, New UnpaidFeeTypes(AccountID, GlobalReference.CurrentUser.CompanyAccess))
        Else
            Common.BindComboBoxtoList(cboInvoiceFeeType, New UnpaidFeeTypes(AccountID, LeaseID, GlobalReference.CurrentUser.CompanyAccess))
        End If

    End Sub

    Private Sub PopulateFeeTypes()
        Common.BindComboBoxtoList(cboInvoiceFeeType, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))
    End Sub

    Private Sub PopulateBanks()
        Common.BindComboBoxtoList(cboCheckBank, New BankNamesSource)
    End Sub

    Private Sub PopulateBankBranch()
        Common.BindComboBoxtoList(cboCheckBranch, New BankBranch)
    End Sub

    Private Sub PopulatePaymentTypes()
        Common.BindComboBoxtoList(cboPaymentType, New PaymentTypeSource(GlobalReference.CurrentUser.UserGroup))
    End Sub

    Private Sub PopulatePaymentCat()
        Common.BindComboBoxtoList(cboPayCategory, New PaymentCatSource)
    End Sub

    Private Function GetReceiptNumber() As String
        If cboInvoiceFeeType.Items.Count > 0 Then
            Dim nextOR As String

            Dim feeid As String = cboInvoiceFeeType.SelectedValue.ToString
            nextOR = Payment.GetCurrentReceiptNo(feeid)

            If nextOR.Equals("null") Then
                Return String.Empty
            Else
                Return nextOR.ToString.PadLeft(6, "0")
            End If
        Else
            Return String.Empty
        End If
    End Function

    Private Function SavePayment(Optional ByVal bManual As Boolean = False) As Boolean
        Dim bSuccess As Boolean = True
        pay = New Payment

        With pay
            .AccountID = AccountID
            .LeaseID = LeaseID

            .PayCategory = cboPayCategory.SelectedValue.ToString
            .PaymentType = cboPaymentType.SelectedValue.ToString

            If .PaymentType = "CHK" Then
                .CheckBankId = cboCheckBank.SelectedValue.ToString
                .CheckNumber = txtCheckNumber.Text
                .CheckDate = dtpCheckDate.Value.Date
                .BankBranchID = cboCheckBranch.SelectedValue.ToString
            End If


            If Common.HasValue(txtDiscountAmount) Then
                .DiscountAmount = Decimal.Parse(txtDiscountAmount.Text)
                .DiscountRate = Decimal.Parse(txtDiscountPercentage.Text)
            End If
            .FeetypeID = cboInvoiceFeeType.SelectedValue.ToString

            .ReceiptDate = dtpReceiptDate.Value.Date
            .ReceiptNumber = txtReceiptNumber.Text
            .PaidAmount = GetReceiptAmount()
            .Remarks = txtRemarks.Text.Trim
            .CheckID = Me.CheckID
            If bManual Then
                .IssueType = PayIssueType.Manual
                .ManualReason = txtManualReason.Text.Trim
            Else
                .IssueType = PayIssueType.System
            End If
        End With

        Dim paymentID As String = String.Empty

        Try
            paymentID = Payment.Insertpayment(pay)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cannot Saved Transaction")
            Return False
        End Try


        If pay.PayCategory = "REG" Then

            For Each bill As PaymentBilling In billInvoices
                With bill
                    If .Penalty = 0 Then
                        Payment.InsertPayTransactions(.BillID, paymentID, .Appliedamount, 0)
                    Else
                        If .Balance = (.AmountDue + .Penalty) Then
                            If .Balance = .Appliedamount Then
                                Payment.InsertPayTransactions(.BillID, paymentID, .AmountDue, .Penalty)
                            Else
                                If .Penalty >= .Appliedamount Then
                                    Payment.InsertPayTransactions(.BillID, paymentID, 0, .Appliedamount)
                                Else

                                    Payment.InsertPayTransactions(.BillID, paymentID, .Appliedamount - .Penalty, .Penalty)
                                End If

                            End If
                        Else
                            Dim paidAmount As Decimal = (.AmountDue + .Penalty) - .Balance

                            If paidAmount < .Penalty Then
                                If .Penalty >= .Appliedamount Then
                                    Payment.InsertPayTransactions(.BillID, paymentID, 0, .Appliedamount)
                                Else
                                    'Payment.InsertPayTransactions(.billID, paymentID, .appliedamount - .penalty, .penalty)
                                    Payment.InsertPayTransactions(.BillID, paymentID, .Appliedamount - (.Penalty - paidAmount), .Penalty - paidAmount)
                                End If
                            Else
                                Payment.InsertPayTransactions(bill.BillID, paymentID, .Appliedamount, 0)
                            End If

                        End If
                    End If

                End With

            Next

        End If
        Return bSuccess

    End Function

    Private Function ValidateEntry() As Boolean
        Dim bValid As Boolean = True
        ErrorProvider1.Clear()

        If Not Common.HasValue(txtReceiptNumber) Then
            If Not IsManualPaymentEntry Then
                MessageBox.Show("Update Current Receipt Number", "NO AVAILABLE RECEIPTS")
            End If
            bValid = False
        End If

        If IsManualPaymentEntry Then
            If Common.HasValue(txtReceiptNumber) Then
                If Not Payment.IsORinInventory(txtReceiptNumber.Text.Trim, cboInvoiceFeeType.SelectedValue.ToString) Then
                    MessageBox.Show("O.R. Number not in Inventory", "Invalid Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bValid = False
                End If
            End If
        End If

        If cboPayCategory.SelectedIndex = 1 Then
            For Each list As BCL.Common.ItemLIst In ListHelper.CreateList(New UnpaidFeeTypes(_accountID, GlobalReference.CurrentUser.CompanyAccess))
                If list.DisplayValue = cboInvoiceFeeType.SelectedValue.ToString Then
                    ErrorProvider1.SetError(cboPayCategory, "Settle Unpaid Invoices First")
                    cboPayCategory.Focus()
                    bValid = False
                    Exit For
                End If
            Next
        End If

        If Not Common.HasValue(txtReceiptAmount) Then
            ErrorProvider1.SetError(txtReceiptAmount, "Enter value for receipt amount")
            txtReceiptAmount.Focus()
            bValid = False
            Return bValid
        End If

        If IsManualPaymentEntry Then
            If Not Common.HasValue(txtManualReason) Then
                ErrorProvider1.SetError(txtManualReason, "Enter reason for manual issuance of receipt")
                txtManualReason.Focus()
                bValid = False
            End If

        End If

        If cboPaymentType.Text = "CHECK" Then
            If Not Common.HasValue(txtCheckNumber) Then
                ErrorProvider1.SetError(txtCheckNumber, "Enter value for check number")
                txtCheckNumber.Focus()
                bValid = False
            End If

            If Not Common.HasValue(txtCheckAmount) Then
                ErrorProvider1.SetError(txtCheckAmount, "Enter value for check amount")
                txtCheckAmount.Focus()
                bValid = False
            Else
                If cboPayCategory.SelectedIndex = 0 Then
                    If Decimal.Parse(txtReceiptAmount.Text) <> Decimal.Parse(txtCheckAmount.Text) Then
                        ErrorProvider1.SetError(txtCheckAmount, "Check amount not match with receipt amount")
                        txtCheckAmount.Focus()
                        bValid = False
                    End If
                Else
                    If Common.HasValue(txtDiscountPercentage) Then
                        If Decimal.Parse(txtNetofDiscount.Text) <> Decimal.Parse(txtCheckAmount.Text) Then
                            ErrorProvider1.SetError(txtCheckAmount, "Check amount not match with Net of Discount Amount")
                            txtCheckAmount.Focus()
                            bValid = False
                        End If
                    Else
                        If Decimal.Parse(txtReceiptAmount.Text) <> Decimal.Parse(txtCheckAmount.Text) Then
                            ErrorProvider1.SetError(txtCheckAmount, "Check amount not match with receipt amount")
                            txtCheckAmount.Focus()
                            bValid = False
                        End If
                    End If

                End If
            End If

            'Remove validation. Can issue receipt even for checks whose due date falls on weekend or holidays.
            'If dtpCheckDate.Value.Date > dtpReceiptDate.Value.Date Then
            '    ErrorProvider1.SetError(dtpCheckDate, "Check is not yet due")
            '    bValid = False
            'End If
        End If


        Return bValid
    End Function

    Private Sub SavePaymentEntry()
        Try

            If IsCreditMemo Then
                If MessageBox.Show("Save Transaction as Credit Memo", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    SavePayment()
                    MessageBox.Show("Credit Memo Saved")
                End If

            Else
                If IsManualPaymentEntry Then
                    If MessageBox.Show("Save Manual Transaction", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        SavePayment(True)
                        MessageBox.Show("Manual Issued Payment Saved")
                    End If
                Else
                    Using frm As New ReceiptVerificationForm
                        frm.UnitOwner = _unitNumber & "-" & _unitOwnerName

                        frm.ReceiptNumber = currentReceiptNumber
                        frm.ReceiptDate = dtpReceiptDate.Value.Date
                        frm.ReceiptAmount = GetReceiptAmount()
                        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                            txtReceiptNumber.Text = frm.ReceiptNumber
                            If SavePayment() Then
                                Payment.UpdateCurrentReceipt(frm.ReceiptNumber.TrimStart("0"), cboInvoiceFeeType.SelectedValue.ToString)
                                PrintReceipt()
                                MessageBox.Show("Transaction Payment Saved")
                            End If
                        End If

                    End Using
                End If

            End If

            LoadDefaults()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub PrintReceipt()

        Dim feeID As String = cboInvoiceFeeType.SelectedValue.ToString

        Dim particulars As ReceiptParticulars
        If pay.PayCategory = "REG" Then
            particulars = New RegularParticulars(feeID, billInvoices)
        Else
            Dim discountRate As Decimal
            If Common.HasValue(txtDiscountAmount) Then
                discountRate = Decimal.Parse(txtDiscountPercentage.Text)
            End If

            particulars = New AdvanceParticulars(feeID, pay.PaidAmount, discountRate)
        End If

        If Not String.IsNullOrEmpty(txtRemarks.Text.Trim) Then
            If chkPrintRemarks.Checked Then
                particulars.Remarks = txtRemarks.Text
            End If
        End If
        particulars.Process()


        Dim receipt As New ReceiptDoc(particulars)

        If String.IsNullOrEmpty(LeaseID) Then
            receipt.CustomerName = _unitOwnerName
        Else
            receipt.CustomerName = _unitOwnerName & " (TENANT)"
        End If

        receipt.UnitNumber = _unitNumber

        receipt.ReceiptNumber = pay.ReceiptNumber
        receipt.ReceiptDate = pay.ReceiptDate
        receipt.ReceiptAmount = pay.PaidAmount

        If pay.PaymentType = "CHK" Then
            receipt.PaymentType = ReceiptDoc.PayType.Check
            receipt.CheckBank = Banks.GetBankCode(cboCheckBank.SelectedValue.ToString)
            receipt.CheckNumber = pay.CheckNumber
            receipt.CheckDate = pay.CheckDate
        Else
            receipt.PaymentType = ReceiptDoc.PayType.Cash
        End If


        receipt.PrintReceipt2()

    End Sub

    Private Sub LoadDefaults()
        dtpReceiptDate.Value = Now.Date
        txtCheckNumber.Text = String.Empty
        dtpCheckDate.Value = Now.Date
        txtRemarks.Text = String.Empty

        chkManualTransaction.Checked = False
        chkPrintRemarks.Checked = False

        cboPaymentType.SelectedIndex = 0
        cboPayCategory.SelectedIndex = 0
        cboPayCategory_SelectedIndexChanged(Nothing, Nothing)


    End Sub

    Private Function GetReceiptAmount() As Decimal
        Dim receiptAmount As Decimal = Decimal.Parse(txtReceiptAmount.Text)

        If Common.HasValue(txtDiscountAmount) Then
            Dim discountAmount As Decimal = Decimal.Parse(txtDiscountAmount.Text)

            Return receiptAmount - discountAmount
        Else
            Return receiptAmount
        End If

    End Function

#End Region


End Class
