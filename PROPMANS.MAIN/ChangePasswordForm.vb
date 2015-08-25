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

Public Class ChangePasswordForm

    Public Property NewPassword As String

    Public ReadOnly Property AppVersion As String
        Get
            Return Application.ProductVersion
        End Get
    End Property

#Region "Form and Control Events"


    Private Sub ChangePasswordForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "ENTER NEW PASSWORD"
    End Sub

    Private Sub UserLoginForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtNewPassword.Text = String.Empty
        txtConfirmPassword.Text = String.Empty

        txtNewPassword.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim NewPass As String = txtNewPassword.Text.Trim
        Dim confirmpass As String = txtConfirmPassword.Text.Trim

        If String.Equals(NewPass, confirmpass) AndAlso (Not String.IsNullOrEmpty(NewPass) And Not String.IsNullOrEmpty(confirmpass)) Then
            NewPassword = confirmpass
            If ChangePassword() Then
                Me.Close()
                MessageBox.Show("Password Succesfully Changed", "PROPMANS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Password Verification Mismatch", "PROPMANS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNewPassword.SelectAll()
            txtNewPassword.Focus()
        End If

    End Sub

#End Region

#Region "Local Procedure"

    Public Function ChangePassword() As Boolean

        If UserAccess.ChangeExpiredPAssword(NewPassword) Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region

End Class
