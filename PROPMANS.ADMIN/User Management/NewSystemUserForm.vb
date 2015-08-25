'*****************************************************************
'Property Management System ver. 2.0
'
'Module: User Management Group
'Module Description: manage user and module access
'Date Created: 5/30/2011
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton.Toolkit

Imports BCL.ReferenceList
Imports BCL.Entities
Imports BCL
Imports BCL.Common
Imports PROPMANS.BASE_MOD

Public Class NewSystemUserForm

#Region "Form and Control Events"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

    Private Sub NewSystemUserForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Tag = "new" Then
            btnChangePassword.Visible = False
            chkActivateUser.Checked = True
        Else
            txtUserID.Enabled = False
        End If
    End Sub

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        btnChangePassword.Visible = False
        txtUserPassword.Focus()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If IsEntryValid() Then
            If Me.Tag = "new" Then
                SaveUser()
            Else
                UpdateUser()
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Local Procedures"
    Private Sub UISetup()
        cboUserGroup.DisplayMember = "value"
        cboUserGroup.ValueMember = "key"
        cboUserGroup.DataSource = Utils.EnumHelper.ToEnumValueList(GetType(UserGroupType))

        cboCompany.DisplayMember = "value"
        cboCompany.ValueMember = "key"
        cboCompany.DataSource = Utils.EnumHelper.ToEnumValueList(GetType(SiteDivision))

    End Sub

    Private Function IsEntryValid() As Boolean
        ErrorProvider1.Clear()

        If Not Common.HasValue(txtUserID) Then
            txtUserID.Focus()
            Return False
        ElseIf Not Common.HasValue(txtUserFullName) Then
            txtUserFullName.Focus()
            Return False
        ElseIf Not Common.HasValue(txtUserPosition) Then
            txtUserPosition.Focus()
            Return False
        End If

        If Me.Tag = "new" Then
            If Not Common.HasValue(txtUserPassword) Then
                txtUserPassword.Focus()
                Return False
            End If
        Else
            If btnChangePassword.Visible = False Then
                If Not Common.HasValue(txtUserPassword) Then
                    txtUserPassword.Focus()
                    Return False
                End If
            End If
        End If

        Return True

    End Function

    Private Sub SaveUser()
        Dim usr As New SystemUser

        With usr 
            .UserID = txtUserID.Text.Trim
            .UserPassword = txtUserPassword.Text.Trim
            .UserFullName = txtUserFullName.Text.Trim
            .UserPosition = txtUserPosition.Text.Trim
            .CompanyAccess = cboCompany.SelectedValue
            .UserGroup = cboUserGroup.SelectedValue
            .IsActive = chkActivateUser.Checked

            UserAccess.SaveNewUser(usr)
        End With
    End Sub

    Private Sub UpdateUser()
        Dim usr As New SystemUser

        With usr
            .UserID = txtUserID.Text.Trim
            .UserFullName = txtUserFullName.Text.Trim
            .UserPosition = txtUserPosition.Text.Trim
            .CompanyAccess = cboCompany.SelectedValue
            .UserGroup = cboUserGroup.SelectedValue
            .IsActive = chkActivateUser.Checked

            If Not btnChangePassword.Visible Then
                .UserPassword = txtUserPassword.Text.Trim
            End If

            UserAccess.UpdateUserInfo(usr)
        End With
    End Sub
#End Region



End Class
