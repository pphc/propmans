'*****************************************************************
'Property Management System ver. 2.0
'
'Module:  Customer Unpaid invoices
'Module Description: list all unpaid invoices for payment application for specific customer
'Date Created: 3/8/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports BCL

Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class UnpaidInvoicessForm
    Private _bLoaded As Boolean

    Private __accountID As String

    Public Property AccountID() As String
        Get
            Return __accountID
        End Get
        Set(ByVal Value As String)
            __accountID = Value
        End Set
    End Property

    Public Property LeaseID As String

    Private __feeCode As String

    Public Property FeeCode() As String
        Get
            Return __feeCode
        End Get
        Set(ByVal Value As String)
            __feeCode = Value
        End Set
    End Property

    Private _receiptAmount As Decimal
    Public ReadOnly Property ReceiptAmount() As Decimal
        Get
            Return _receiptAmount
        End Get
    End Property

    Private _invoices As New List(Of PaymentBilling)
    Public ReadOnly Property BillInvoices() As List(Of PaymentBilling)
        Get
            Return _invoices
        End Get
    End Property


    Private _billAmount As Decimal
    Private bPartialPayment As Boolean

#Region "Form Events"

    Private Sub PaymentTransactionsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub


#End Region

#Region "Control Events"

    Private Sub dgUnpaidInvoices_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUnpaidInvoices.CellValueChanged
        Try

            If dgUnpaidInvoices.Columns(e.ColumnIndex).Name <> "appliedamount" Then

                If dgUnpaidInvoices.Item(0, e.RowIndex).Value = "True" Then
                    _billAmount += dgUnpaidInvoices.Item("balance", e.RowIndex).Value
                    If bPartialPayment Then
                        With dgUnpaidInvoices
                            Dim appliedamount As Decimal = Decimal.Parse(.Item("balance", e.RowIndex).Value)
                            Dim givenAmount As Decimal = Decimal.Parse(txtAmountGiven.Text)
                            If _billAmount < givenAmount Then
                                .Item("appliedamount", e.RowIndex).Value = appliedamount
                            Else
                                If Decimal.Parse(lblAmount.Text) > 0 Then
                                    .Item("appliedamount", e.RowIndex).Value = Decimal.Parse(lblAmount.Text)
                                Else
                                    .Item("appliedamount", e.RowIndex).Value = 0
                                End If

                            End If
                        End With
                    End If
                Else
                    _billAmount -= dgUnpaidInvoices.Item("balance", e.RowIndex).Value
                    If bPartialPayment Then
                        dgUnpaidInvoices.Item("appliedamount", e.RowIndex).Value = Nothing
                    End If
                End If
                UpdateRunningTotals()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgUnpaidInvoices_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUnpaidInvoices.CurrentCellDirtyStateChanged
        If dgUnpaidInvoices.IsCurrentCellDirty Then
            dgUnpaidInvoices.CommitEdit(DataGridViewDataErrorContexts.Commit)
            ValidateSelection()
        End If
    End Sub

    Private Sub dgUnpaidInvoices_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUnpaidInvoices.Sorted
        _billAmount = 0
        btnSave.Visible = False
        UpdateRunningTotals()
    End Sub



    Private Sub txtAmountGiven_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountGiven.TextChanged

        If Common.HasValue(txtAmountGiven) Then
            lblAmount.Text = txtAmountGiven.Text
            UnselectAll()
            btnSave.Visible = False
            bPartialPayment = True
            lblAmountPrompt.Text = "Remaining Amount:"
        Else
            bPartialPayment = False
            lblAmountPrompt.Text = "Total Amount Due:"
            lblAmount.Text = String.Empty
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        GetInvoices()
        If bPartialPayment Then
            _receiptAmount = Decimal.Parse(txtAmountGiven.Text)
        Else
            _receiptAmount = Decimal.Parse(lblAmount.Text)
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        GridHelper.SetGridDisplay(dgUnpaidInvoices, New UnpaidInvoicesGridDisplay)
        dgUnpaidInvoices.RowHeadersVisible = False
        If String.IsNullOrEmpty(LeaseID) Then
            dgUnpaidInvoices.DataSource = Invoices.GetUnpaidBills(AccountID, FeeCode)
        Else
            dgUnpaidInvoices.DataSource = Invoices.GetUnpaidBills(AccountID, LeaseID, FeeCode)
        End If

        AddHandler txtAmountGiven.KeyPress, AddressOf Common.Decimal_KeyPress

        lblAmount.Text = String.Empty
        lblAmountPrompt.Text = "Total Amount Due:"
        btnSave.Visible = False
    End Sub

    Private Sub UpdateRunningTotals()

        If bPartialPayment Then
            Dim givenAmount As Decimal = Decimal.Parse(txtAmountGiven.Text)
            If _billAmount < givenAmount Then
                lblAmount.Text = (givenAmount - _billAmount).ToString("#,###.00")
            Else
                lblAmount.Text = "0.00"
            End If

        Else
            If _billAmount > 0 Then
                lblAmount.Text = _billAmount.ToString("#,###.00")
            Else
                lblAmount.Text = String.Empty
            End If

        End If
    End Sub

    Private Sub UnselectAll()
        For Each dr As DataGridViewRow In dgUnpaidInvoices.Rows
            If dr.Cells(0).Value = "True" Then
                dr.Cells(0).Value = "False"
            End If
        Next
    End Sub

    Private Sub SelectAll()
        For Each dr As DataGridViewRow In dgUnpaidInvoices.Rows
            If dr.Cells(0).Value = "False" Or dr.Cells(0).Value Is Nothing Then
                dr.Cells(0).Value = "True"
            End If
        Next
    End Sub

    Private Function GetInvoices() As Integer

        For Each dr As DataGridViewRow In dgUnpaidInvoices.Rows
            If dr.Cells(0).Value = "True" Then
                If bPartialPayment Then
                    If Decimal.Parse(dr.Cells("appliedamount").Value) = 0 Then
                        Continue For
                    End If
                End If
                Dim bill As New PaymentBilling
                bill.BillID = dr.Cells("bill_id").Value.ToString
                If Not Convert.IsDBNull(dr.Cells("bill_date").Value) Then
                    bill.BillPeriodDate = Date.Parse(dr.Cells("bill_date").Value)
                End If
                bill.AmountDue = Decimal.Parse(dr.Cells("amount_due").Value)
                bill.Penalty = Decimal.Parse(dr.Cells("penalty_amt").Value)
                bill.Balance = Decimal.Parse(dr.Cells("balance").Value)
                If bPartialPayment Then
                    bill.Appliedamount = Decimal.Parse(dr.Cells("appliedamount").Value)
                Else
                    bill.Appliedamount = Decimal.Parse(dr.Cells("balance").Value)
                End If
                bill.Vatable = IIf(dr.Cells("vatable").Value.ToString.Trim = "Y", True, False)
                _invoices.Add(bill)
            End If
        Next

        GetInvoices = _invoices.Count

    End Function


    Public Sub ValidateSelection()

        Dim valid As Boolean = True

        If bPartialPayment Then

            If Not Common.HasValue(txtAmountGiven) Then
                valid = False
            Else
                If lblAmount.Text > 0 Then
                    valid = False
                End If
            End If
        Else
            If String.IsNullOrEmpty(lblAmount.Text) Then
                valid = False
            End If
        End If

        btnSave.Visible = valid
    End Sub
#End Region




End Class



