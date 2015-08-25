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
Imports PROPMANS.BASE_MOD
Imports TransactionsVerifier
Imports BCL.Common



Public Class QuickbooksTransUploaderForm1

    Public ReadOnly Property UploadFolderPath()
        Get
            Return txtDirectoryPath.Text.Trim

        End Get
    End Property

#Region "Form Instance"
    Private Shared aForm As QuickbooksTransUploaderForm1
    Public Shared Function Instance() As QuickbooksTransUploaderForm1
        If aForm Is Nothing Then
            aForm = New QuickbooksTransUploaderForm1
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and Control Events"

    Private Sub QuickbooksTransUploaderForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetUP()
    End Sub

    Private Sub chkInitialSetup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInitialSetup.CheckedChanged
        pnlInitialSetup.Visible = chkInitialSetup.Checked
    End Sub

    Private Sub btnBrowseFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseFileLocation.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            txtDirectoryPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnExportAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportAccounts.Click
        If String.IsNullOrEmpty(UploadFolderPath) Then
            MessageBox.Show("Please select Folder location for Log Files", "Folder Location Not Set", MessageBoxButtons.YesNo)
            btnBrowseFileLocation_Click(Nothing, Nothing)
            Return
        End If

        If MessageBox.Show("Are you sure you want to export Interface Mapping from Quickbooks", "Export Cormation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If QBUploadHelper.ExportAccounts(UploadFolderPath) Then
                MessageBox.Show("Interface Mapping succesfully exported", "Quickbooks Interface Mapping Export Finished", MessageBoxButtons.OK)

                If chkLauchFile.Checked Then

                    Dim startinfo As New ProcessStartInfo
                    startinfo.FileName = UploadFolderPath

                    Using proc As New Process
                        proc.StartInfo = startinfo
                        proc.Start()
                    End Using

                End If

            Else
                MessageBox.Show("Interface Mapping not exported from Quickbooks", "Quickbooks Export Failed", MessageBoxButtons.OK)
            End If
        Else
            Return
        End If
    End Sub

    Private Sub btnStartQBUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartQBUpload.Click


        'If IsMappingOk() Then
        '    MessageBox.Show("Please check mapping of Chart of accounts and Fees Item List", "Accounts Mapping Incomplete", MessageBoxButtons.OK)
        '    Return
        'End If

        If String.IsNullOrEmpty(UploadFolderPath) Then
            MessageBox.Show("Please select Folder location for Upload Log Files", "Folder Location Not Set", MessageBoxButtons.YesNo)
            btnBrowseFileLocation_Click(Nothing, Nothing)
            Return
        End If
        If MessageBox.Show("Are you sure you want to upload transactions to Quickbooks", " Upload Cormation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            Dim success As Boolean = False

            If chkInitialSetup.Checked Then
                success = QBUploadHelper.StartUpload(UploadFolderPath, dtpInvoiceFromDate.Value, dtpInvoiceToDate.Value, dtpPaymentsFromDate.Value, dtpPaymentsToDate.Value)
            Else
                success = QBUploadHelper.StartUpload(UploadFolderPath)
            End If
            If success Then
                MessageBox.Show("Transactions succesfully uploaded to Quickbooks", "Quickbooks Upload Finished", MessageBoxButtons.OK)

                If chkLauchFile.Checked Then

                    Dim startinfo As New ProcessStartInfo
                    startinfo.FileName = UploadFolderPath

                    Using proc As New Process
                        proc.StartInfo = startinfo
                        proc.Start()
                    End Using

                End If

            Else
                MessageBox.Show("Transactions not uploaded to Quickbooks", "Quickbooks Upload Failed", MessageBoxButtons.OK)
            End If

            Me.Cursor = Cursors.Default

        Else
            Return
        End If

    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        If String.IsNullOrEmpty(UploadFolderPath) Then
            MessageBox.Show("Please select Folder location for Log Files", "Folder Location Not Set", MessageBoxButtons.YesNo)
            btnBrowseFileLocation_Click(Nothing, Nothing)
            Return
        End If

        If MessageBox.Show("Are you sure you want to export Transactions Verification from PROPMANS", "Transactions Verification Export Confirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If VerifierHelper.StartVerify(UploadFolderPath, dtpInvoiceFromDate.Value.Date, dtpInvoiceToDate.Value.Date) Then
                MessageBox.Show("Accounts Transaction suceesfully Verified", "Transactions Verification Finished", MessageBoxButtons.OK)

                If chkLauchFile.Checked Then

                    Dim startinfo As New ProcessStartInfo
                    startinfo.FileName = UploadFolderPath

                    Using proc As New Process
                        proc.StartInfo = startinfo
                        proc.Start()
                    End Using

                End If

            Else
                MessageBox.Show("Transactions Verification not exported", "Transactions Verification Failed", MessageBoxButtons.OK)
            End If
        Else
            Return
        End If
    End Sub

#End Region

#Region "Local Procedure"

    Private Sub UISetUP()
        GridHelper.SetGridDisplay(dgQuickBooksUpload, New QuickbooksUploadGridDisplay)

        dgQuickBooksUpload.DataSource = QBUploadHelper.GetQBUploads
    End Sub

    Private Function IsMappingOk() As Boolean
        Dim str1 As String = GlobalReference.ProjectParameters.QBDepositoryAccount
        Dim str2 As String = GlobalReference.ProjectParameters.QBPenaltyAccount
        Return String.IsNullOrEmpty(str1) Or _
        String.IsNullOrEmpty(str2)
    End Function


#End Region








End Class
