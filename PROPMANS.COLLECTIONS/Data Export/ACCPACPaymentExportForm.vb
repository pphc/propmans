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

Imports BCL.Export
Imports PROPMANS.BASE_MOD

Public Class AccpacPaymentExportForm

#Region "Form Instance"
    Private Shared aForm As AccpacPaymentExportForm
    Public Shared Function Instance() As AccpacPaymentExportForm
        If aForm Is Nothing Then
            aForm = New AccpacPaymentExportForm
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
    Private Sub btnBrowseFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseFile.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            txtDirectoryPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If IsEntryValid() Then

            Cursor = Cursors.WaitCursor
            Dim exp As New BatchDepositExport

            exp.ExportFolderPath = txtDirectoryPath.Text.Trim
            exp.DepositIDStart = txtDepositStart.Text.Trim
            exp.DepositIDend = txtDepositEnd.Text.Trim

            exp.Export()

            MessageBox.Show("Export File Generated", "PAYMENTS EXPORT COMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Cursor = Cursors.Default

            If chkLauchFile.Checked Then
                Dim startinfo As New ProcessStartInfo
                startinfo.FileName = exp.ExportFolderPath

                Using proc As New Process
                    proc.StartInfo = startinfo
                    proc.Start()
                End Using
            End If
        End If
    End Sub

#End Region

#Region "Local Procedure"


    Private Sub UISetup()
        AddHandler txtDepositStart.KeyPress, AddressOf Common.Numeric_KeyPress
        AddHandler txtDepositEnd.KeyPress, AddressOf Common.Numeric_KeyPress

        txtDirectoryPath.ReadOnly = True

    End Sub

    Private Function IsEntryValid() As Boolean
        Dim valid As Boolean = True

        If Not Common.HasValue(txtDepositStart) Then
            valid = False
            txtDepositStart.Focus()
        End If

        If Common.HasValue(txtDepositStart) And Common.HasValue(txtDepositEnd) Then
            If Decimal.Parse(txtDepositEnd.Text) < Decimal.Parse(txtDepositStart.Text) Then
                txtDepositEnd.SelectAll()
                txtDepositEnd.Focus()
                valid = False
            End If
        End If

        If Not Common.HasValue(txtDirectoryPath) Then
            txtDirectoryPath.Focus()
            valid = False
        End If

        Return valid
    End Function


#End Region

End Class
