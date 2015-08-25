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

Public Class UserManagementForm

    Private selectedUserID As String
    Private isLoading As Boolean

#Region "Form Instance"
    Private Shared aForm As UserManagementForm
    Public Shared Function Instance() As UserManagementForm
        If aForm Is Nothing Then
            aForm = New UserManagementForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and Control Events"

    Private Sub UserManagementForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub dgUserRoles_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgUserRoles.DataError
        If e.Context = DataGridViewDataErrorContexts.Formatting Then
            e.Cancel = True
        End If
    End Sub

    Private Sub dgUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUsers.DoubleClick
        Using frm As New NewSystemUserForm
            frm.Text = "UPDATE USER INFO"
            frm.Tag = "update"

            With dgUsers.CurrentRow
                DirectCast(frm, NewSystemUserForm).txtUserID.Text = .Cells("user_id").Value.ToString
                DirectCast(frm, NewSystemUserForm).txtUserFullName.Text = .Cells("user_fullname").Value.ToString
                DirectCast(frm, NewSystemUserForm).txtUserPosition.Text = .Cells("user_position").Value.ToString
                DirectCast(frm, NewSystemUserForm).chkActivateUser.Checked = IIf(.Cells("active").Value.ToString = "Y", True, False)
                DirectCast(frm, NewSystemUserForm).cboCompany.SelectedValue = Utils.EnumHelper.GetEnumValueFromDBValue(Of SiteDivision)(.Cells("company").Value.ToString)
                DirectCast(frm, NewSystemUserForm).cboUserGroup.SelectedValue = Utils.EnumHelper.GetEnumValueFromDBValue(Of UserGroupType)(.Cells("user_group").Value.ToString)
            End With

            frm.ShowDialog(Me)
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("User Info has been Updated")
                dgUsers.DataSource = UserAccess.GetUsers(GlobalReference.CurrentUser.UserID)
            End If
        End Using
    End Sub

    Private Sub dgUsers_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUsers.SelectionChanged
        If isLoading Then
            Return
        End If

        If dgUsers.RowCount <= 0 Then
            Return
            lblUserID.Text = String.Empty
        End If

        PopulateGrid()
    End Sub

    Private Sub btnCreateNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewUser.Click
        Using frm As New NewSystemUserForm
            frm.Text = "CREATE NEW USER"
            frm.Tag = "new"
            frm.ShowDialog(Me)
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("System User Created Succesfully")
                dgUsers.DataSource = UserAccess.GetUsers(GlobalReference.CurrentUser.UserID)
            End If
        End Using
    End Sub

    Private Sub btnApplyAccessChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyAccessChanges.Click
        If HasChanges() Then
            If MessageBox.Show("Update User Access", "MODULE ACCESS UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                SaveChanges()
            End If
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        tabUserMgmt.TabPages(1).Hide()
        isLoading = True
        GridHelper.SetGridDisplay(dgUsers, New UserListGridDisplay)
        GridHelper.SetGridDisplay(dgUserRoles, New UserRolesGridDisplay)

        dgUsers.DataSource = UserAccess.GetUsers(GlobalReference.CurrentUser.UserID)
        isLoading = False


    End Sub

    '  COMMENTED BY CODEIT.RIGHT
    '    Private Sub PopulateComboboxValue()
    '
    '        For i As Integer = 0 To dgUserRoles.Rows.Count - 1
    '            dgUserRoles.Rows(i).Cells("ac_type").Value = Utils.EnumHelper.GetEnumValueFromDBValue(Of ReferenceList.UserAccessType)(dgUserRoles.Rows(i).Cells("access_type").Value.ToString)
    '            dgUserRoles.Update()
    '        Next
    '
    '    End Sub

    Private Sub PopulateGrid()

        selectedUserID = dgUsers.CurrentRow.Cells("user_id").Value.ToString
        lblUserID.Text = "MODULE ACCESS FOR USER " & selectedUserID
        tabUserMgmt.TabPages(1).Show()

        Using dt As DataTable = UserAccess.GetModuleAccess(selectedUserID)
            dgUserRoles.Rows.Clear()
            For Each row As DataRow In dt.Rows
                Dim dr As New DataGridViewRow
                dr.CreateCells(dgUserRoles)

                With dr.Cells
                    .Item(0).Value = row("module_id").ToString
                    .Item(1).Value = row("module_name").ToString
                    .Item(2).Value = row("access_type").ToString
                    .Item(3).Value = Utils.EnumHelper.GetEnumValueFromDBValue(Of ReferenceList.UserAccessType)(row("access_type").ToString)

                End With

                dgUserRoles.Rows.Add(dr)
            Next

        End Using

    End Sub

    Private Function HasChanges() As Boolean
        For Each row As DataGridViewRow In dgUserRoles.Rows
            If row.Cells("ac_type").Value.ToString <> row.Cells("access_type").Value Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub SaveChanges()
        Dim modules As New ArrayList
        Dim accesstype As New ArrayList

        For Each row As DataGridViewRow In dgUserRoles.Rows
            If row.Cells("ac_type").Value.ToString <> row.Cells("access_type").Value Then
                modules.Add(row.Cells("module_id").Value.ToString)
                accesstype.Add(Utils.EnumHelper.GetDBValue(row.Cells("ac_type").Value))
            End If
        Next

        UserAccess.UpdateModuleAccess(DirectCast(modules.ToArray(GetType(String)), String()), _
                                DirectCast(accesstype.ToArray(GetType(String)), String()), _
                               selectedUserID)
    End Sub

#End Region

  
End Class
