'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: User Log In Form
'Module Description: 
'Date Created:
'Date Last Modified: 10/10/2012
'
'Change Log:
'
'*****************************************************************


Imports ExceptionHandler
Imports BCL.Common
Imports BCL.Utils

Public Class UserLoginFOrm


    Public ReadOnly Property AppVersion As String
        Get
            Return Application.ProductVersion
        End Get
    End Property
    Public ReadOnly Property UserID As String
        Get
            Return txtUserID.Text.Trim.ToUpper
        End Get
    End Property
#Region "Form and Control Events"

    Private Sub UserLoginForm_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F11 Then
            Using frm As New ConnectionSettingForm
                frm.ShowDialog(Me)
            End Using
        End If

    End Sub

    Private Sub UserLoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = Me.Text & " ver. " & AppVersion
    End Sub

    Private Sub UserLoginForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtUserID.Text = String.Empty
        txtPassword.Text = String.Empty

        txtUserID.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If LogUser() Then
            UnhandledExceptionManager.AddHandler()
            LoadReferences()

            Dim frm As New NewMainScreenForm
            frm.Show()
            Hide()
        Else
            If UserAccess.ErrNumber = 28001 Then
                MessageBox.Show(UserAccess.Err, "PROPMANS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Using frm As New ChangePasswordForm
                    frm.ShowDialog()
                End Using
                Return
            End If
            MessageBox.Show(UserAccess.Err, "PROPMANS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserID.SelectAll()
            txtUserID.Focus()
        End If

    End Sub

#End Region

#Region "Local Procedure"

    Public Function LogUser() As Boolean


        Dim userName As String = txtUserID.Text.Trim.ToUpper
        Dim password As String = txtPassword.Text.Trim
        Dim user As New SystemUser()
        user.UserID = userName
        user.UserPassword = password

        If UserAccess.IsUserValid(user) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub LoadReferences()
        '  AccountInfo.InitializeInstance()
        ' FeeTypeInfo.InitializeInstance()
        GlobalReference.InitializeInstance(UserID)
    End Sub

#End Region


End Class
