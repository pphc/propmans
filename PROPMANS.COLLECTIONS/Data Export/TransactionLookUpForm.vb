'***********************************************************************
' Assembly         : Transaction Lookup
' Author           : Mark Angelo Rivo
' Created On       : 10/9/2013
'
' Last Modified By : 
' Last Modified On : 
' Description      : 
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports System.Windows.Forms
Imports ComponentFactory.Krypton.Toolkit
Imports BCL.Common
Imports QBooksUploader
Imports PROPMANS.BASE_MOD

Public Enum TransType
    Invoices
    Payments
End Enum
Public Class TransactionLookUpForm
    Public SelectedTransDataTable As DataTable

    Private _bloaded As Boolean
    Private TransType As TransType

    Public Sub New(transType As TransType)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.TransType = transType
        SetUIDefaults()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        btnSelect.Visible = False

        Dim startDate As Date = dtpTransactionStartDate.Value.Date
        Dim endDate As Date = dtpTransactionEndDate.Value.Date

        If Me.TransType = TransType.Invoices Then
            dgTransactions.DataSource = QBUploadHelper.GetInvoices(startDate, endDate)
        Else
            dgTransactions.DataSource = QBUploadHelper.GetPayments(startDate, endDate)
        End If

        If dgTransactions.RowCount > 0 Then
            ResultCountLabel.Text = dgTransactions.RowCount & " RECORD(S) FOUND"
            btnSelect.Visible = True
        Else
            ResultCountLabel.Text = "NO RECORD(S) FOUND"
        End If

    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        If _bloaded Then
            Me.Cursor = Cursors.WaitCursor
            For Each dr As DataGridViewRow In dgTransactions.Rows
                dr.Cells(0).Value = chkSelectAll.Checked.ToString
            Next
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If HasSelection() Then
            BuildSelection()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub SetUIDefaults()
        Me.CancelButton = btnCancel
        Me.AcceptButton = btnSelect


        If Me.TransType = TransType.Invoices Then
            GridHelper.SetGridDisplay(dgTransactions, New InvoicesTransactionsGridDisplay)
            chkShowUndepositedPayments.Visible = False
        Else
            GridHelper.SetGridDisplay(dgTransactions, New PaymentsTransactionsGridDisplay)
            chkShowUndepositedPayments.Visible = True
        End If

        'Uncomment this
        chkShowUndepositedPayments.Visible = False
        btnSelect.Visible = False
        _bloaded = True
    End Sub

    Private Function HasSelection() As Boolean

        For Each row As DataGridViewRow In dgTransactions.Rows
            If row.Cells(0).Value = "True" Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function

    Private Sub BuildSelection()
        SelectedTransDataTable = DirectCast(dgTransactions.DataSource, DataTable).Clone

        For Each row As DataGridViewRow In dgTransactions.Rows
            If row.Cells(0).Value = "True" Then
                Dim rw As DataRow
                rw = SelectedTransDataTable.NewRow
                If Me.TransType = COLLECTIONS_MOD.TransType.Invoices Then
                    rw("bill_id") = row.Cells("bill_id").Value.ToString
                    rw("list_id") = row.Cells("list_id").Value.ToString
                    rw("unit_number") = row.Cells("unit_number").Value.ToString
                    rw("customer_name") = row.Cells("customer_name").Value.ToString
                    rw("list_item") = row.Cells("list_item").Value.ToString
                    rw("ar_item") = row.Cells("ar_item").Value.ToString
                    rw("class_name") = row.Cells("class_name").Value.ToString
                    rw("fee_name") = row.Cells("fee_name").Value.ToString
                    rw("bill_date") = Date.Parse(row.Cells("bill_date").Value)
                    rw("bill_generate_date") = Date.Parse(row.Cells("bill_generate_date").Value)
                    rw("bill_due_date") = Date.Parse(row.Cells("bill_due_date").Value)
                    rw("amount_due") = Decimal.Parse(row.Cells("amount_due").Value)
                    rw("w_vat") = row.Cells("w_vat").Value.ToString
                Else
                    rw("payment_id") = row.Cells("payment_id").Value.ToString
                    rw("list_id") = row.Cells("list_id").Value.ToString
                    rw("or_number") = row.Cells("or_number").Value.ToString
                    rw("list_item") = row.Cells("list_item").Value.ToString
                    rw("ar_item") = row.Cells("ar_item").Value.ToString
                    rw("class_name") = row.Cells("class_name").Value.ToString
                    rw("upload_type") = row.Cells("upload_type").Value.ToString
                    rw("fee_name") = row.Cells("fee_name").Value.ToString
                    rw("payment_date") = Date.Parse(row.Cells("payment_date").Value)
                    rw("paid_amount") = Decimal.Parse(row.Cells("paid_amount").Value)
                    rw("pay_category") = row.Cells("pay_category").Value.ToString
                    rw("payment_type") = row.Cells("payment_type").Value.ToString
                End If
                SelectedTransDataTable.Rows.Add(rw)
            End If
        Next
        SelectedTransDataTable.AcceptChanges()

    End Sub

    Private Sub chkShowUndepositedPayments_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowUndepositedPayments.CheckedChanged
        btnSelect.Enabled = Not chkShowUndepositedPayments.Checked
    End Sub
End Class