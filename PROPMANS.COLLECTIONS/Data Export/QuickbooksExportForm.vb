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

Imports BCL.Export.Quickbooks
Imports QBooksUploader
Imports BCL.Export



Public Class QuickbooksExportForm

    Private _uploadType As QBookUploadType

    Private _qbook As QBookUpload

#Region "Form Instance"
    Private Shared aForm As QuickbooksExportForm
    Public Shared Function Instance(ByVal uploadTYpe As QBookUploadType) As QuickbooksExportForm
        If aForm Is Nothing Then
            aForm = New QuickbooksExportForm(uploadTYpe)
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and Control Events"

    Public Sub New(ByVal uploadType As QBookUploadType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _uploadType = uploadType

        Select Case _uploadType
            Case QBookUploadType.Customers
                Me.Text = "Customers Upload"
            Case QBookUploadType.Invoices
                Me.Text = "Invoices Upload"
            Case QBookUploadType.Payments
                Me.Text = "Payments Upload"
            Case QBookUploadType.JournalEntry
                Me.Text = "Journal Entry Upload"
        End Select
    End Sub

    Private Sub btnBrowseFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseFileLocation.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            txtDirectoryPath.Text = FolderBrowserDialog1.SelectedPath
            SetFileDirectory()

        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click


        'Dim inv As New Invoice
        'inv.UploadInvoices()
        'MessageBox.Show("Invoice Upload Done")

        'Dim pay As New Payment

        'pay.DepositFrom = 1358
        'pay.DepositTo = 1358
        'pay.UploadPayments()

        'Dim cust As New Customer
        'cust.UploadCustomer()
        'MessageBox.Show("Upload Done " & cust.UploadCount)

        'Dim acct As New ChartAccounts
        'acct.ExportChartAccounts()
        'acct.ExportItemLists()
        'MessageBox.Show("Upload Done")




        'If Not _qbook Is Nothing Then
        '    _qbook.Export()
        '    If chkLauchFile.Checked Then

        '        Dim startinfo As New ProcessStartInfo
        '        startinfo.FileName = _qbook.FullExportPathName

        '        Using proc As New Process
        '            proc.StartInfo = startinfo
        '            proc.Start()
        '        End Using

        '    End If

        'End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

#End Region

#Region "Local Procedure"

    Private Sub SetFileDirectory()

        Dim exportPath As String = txtDirectoryPath.Text.Trim
        Select Case _uploadType
            Case QBookUploadType.Customers
                '' _qbook = New Customers(exportPath)
            Case QBookUploadType.Invoices
                _qbook = New Invoices(exportPath)
                DirectCast(_qbook, Invoices).StartDate = dtpFromDate.Value.Date
                DirectCast(_qbook, Invoices).EndDate = dtpToDate.Value.Date
            Case QBookUploadType.Payments
                _qbook = New Payments(exportPath)
                DirectCast(_qbook, Payments).StartDate = dtpFromDate.Value.Date
                DirectCast(_qbook, Payments).EndDate = dtpToDate.Value.Date
            Case QBookUploadType.JournalEntry
        End Select

        lblFileName.Text = _qbook.FileName
    End Sub

#End Region

End Class
