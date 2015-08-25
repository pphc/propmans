'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module:
'Module Description:
'Date Created:
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory
Imports QBooksUploader
Imports PROPMANS.BASE_MOD
Imports TransactionsVerifier
Imports BCL.Common



Public Class QuickbooksTransUploaderForm

#Region "Form Instance"
    Private Shared aForm As QuickbooksTransUploaderForm
    Public Shared Function Instance() As QuickbooksTransUploaderForm
        If aForm Is Nothing Then
            aForm = New QuickbooksTransUploaderForm()
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
        UISetUP()
    End Sub

    Private Sub btnSearchUploads_Click(sender As Object, e As EventArgs) Handles btnSearchUploads.Click
        '' btnViewUploadReport.Visible = True

    End Sub

    Private Sub btnNewUpload_Click(sender As Object, e As EventArgs) Handles btnNewUpload.Click
        If btnNewUpload.Text = "NEW UPLOAD" Then
            btnInvoices.Visible = True
            btnPayments.Visible = True
            btnCancelUpload.Visible = True
            btnNewUpload.Text = "START UPLOAD"
        Else
            If Not (dgInvoices.RowCount > 0 Or dgPayments.RowCount > 0) Then
                MessageBox.Show("Select invoices or payments to upload", "Nothing to upload", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If MessageBox.Show("Are you sure you want to upload transactions to Quickbooks", "Start Upload Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                If StartUpload() Then
                    MessageBox.Show("Transactions succesfully uploaded to Quickbooks", "Quickbooks Upload Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnNewUpload.Text = "NEW UPLOAD"
                    btnInvoices.Visible = False
                    btnPayments.Visible = False
                    btnCancelUpload.Visible = False
                    dgInvoices.DataSource = Nothing
                    dgPayments.DataSource = Nothing
                    lblTotalInvoiceAmount.Text = "0.00"
                    lblTotalPayments.Text = "0.00"
                Else
                    MessageBox.Show("Transactions not uploaded to Quickbooks", "Quickbooks Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Me.Cursor = Cursors.Default
            Else
                Return
            End If
        End If

    End Sub
    Private Sub btnCancelUpload_Click(sender As Object, e As EventArgs) Handles btnCancelUpload.Click
        If (dgInvoices.RowCount > 0) Or (dgPayments.RowCount > 0) Then
            If MessageBox.Show("Cancel For Upload to Quick Books", "Cancellation Confirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                dgInvoices.DataSource = Nothing
                dgPayments.DataSource = Nothing
                lblTotalInvoiceAmount.Text = "0.00"
                lblTotalPayments.Text = "0.00"
            Else
                Return
            End If
        End If

        btnNewUpload.Text = "NEW UPLOAD"
        btnInvoices.Visible = False
        btnPayments.Visible = False
        btnCancelUpload.Visible = False
    End Sub

    Private Sub btnInvoices_Click(sender As Object, e As EventArgs) Handles btnInvoices.Click
        Using frm As New TransactionLookUpForm(TransType.Invoices)
            frm.Text = "INVOICES"
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                dgInvoices.DataSource = frm.SelectedTransDataTable
                lblTotalInvoiceAmount.Text = Decimal.Parse(frm.SelectedTransDataTable.Compute("SUM(amount_due)", "")).ToString("#,###.00")
            End If

        End Using
    End Sub

    Private Sub btnPayments_Click(sender As Object, e As EventArgs) Handles btnPayments.Click
        Using frm As New TransactionLookUpForm(TransType.Payments)
            frm.Text = "PAYMENTS"
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                dgPayments.DataSource = frm.SelectedTransDataTable
                lblTotalPayments.Text = Decimal.Parse(frm.SelectedTransDataTable.Compute("SUM(paid_amount)", "")).ToString("#,###.00")
            End If

        End Using
    End Sub




    Private Sub btnExportInterface_Click(sender As Object, e As EventArgs) Handles btnExportInterface.Click
        If MessageBox.Show("Are you sure you want to export Reference Mapping from Quick Books", "Export Confirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If QBUploadHelper.ExportQBReferences() Then
                MessageBox.Show("QB Reference Mapping succesfully exported", "Quick Books Reference Mapping Export Finished", MessageBoxButtons.OK)
            End If

        Else
            MessageBox.Show("QB Reference Mapping exported from Quickbooks", "Quickbooks Export Failed", MessageBoxButtons.OK)
        End If
    End Sub

#End Region

#Region "Local Procedure"

    Private Sub UISetUP()
        GridHelper.SetGridDisplay(dgInvoices, New InvoicesTransactionsGridDisplay)
        GridHelper.SetGridDisplay(dgPayments, New PaymentsTransactionsGridDisplay)

        PaymentTypeFilterPanel.Visible = False
    End Sub

    Private Function StartUpload() As Boolean


        Return QBUploadHelper.StartUpload(DirectCast(dgInvoices.DataSource, DataTable), DirectCast(dgPayments.DataSource, DataTable))
    End Function


#End Region

End Class
