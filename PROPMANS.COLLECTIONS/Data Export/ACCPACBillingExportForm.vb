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


Public Class ACCPACBillingExportForm

#Region "Form Instance"
    Private Shared aForm As ACCPACBillingExportForm
    Public Shared Function Instance() As ACCPACBillingExportForm
        If aForm Is Nothing Then
            aForm = New ACCPACBillingExportForm
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
            Dim exp As New InvoicesExport

            exp.ExportFolderPath = txtDirectoryPath.Text.Trim

            exp.BillStartDate = New Date(dudBillingYear.Text, cboBillingMonth.SelectedIndex + 1, 1)

            exp.Export()

            MessageBox.Show("Export File Generated", "BILLING EXPORT COMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Information)

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


        For i As Integer = Now.Year - 5 To Now.Year
            dudBillingYear.Items.Add(i)
        Next

        dudBillingYear.Text = Now.Year
        dudBillingYear.ReadOnly = True


        For Each monthName As String In Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
            If Not String.IsNullOrEmpty(monthName) Then
                cboBillingMonth.Items.Add(monthName.ToUpper)
            End If
        Next

        cboBillingMonth.Text = Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Now.Month)

        txtDirectoryPath.ReadOnly = True

    End Sub

    Private Function IsEntryValid() As Boolean
        Dim valid As Boolean = True



        If Not Common.HasValue(txtDirectoryPath) Then
            txtDirectoryPath.Focus()
            valid = False
        End If

        Return valid
    End Function


#End Region

End Class
