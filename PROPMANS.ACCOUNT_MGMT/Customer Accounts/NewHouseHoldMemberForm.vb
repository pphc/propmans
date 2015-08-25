Imports ComponentFactory.Krypton.Toolkit
Imports BCL


Imports BCL.CustomerAccounts
Imports PROPMANS.BASE_MOD

Public Class NewHouseHoldMemberForm

#Region "Properties"


    Public _accountId As String

    Public Property AccountId() As String
        Get
            Return _accountId
        End Get
        Set(ByVal Value As String)
            _accountId = Value
        End Set
    End Property

    Public _memberId As String

    Public Property MemberId() As String
        Get
            Return _memberId
        End Get
        Set(ByVal Value As String)
            _memberId = Value
        End Set
    End Property

    Private _ownerRelation As OwnerRelation
    Public Property OwnerRelation() As OwnerRelation
        Get
            Return _ownerRelation
        End Get
        Set(ByVal value As OwnerRelation)
            _ownerRelation = value
        End Set
    End Property

#End Region

#Region "Form & Control Events"

    Private Sub NewHouseHoldMember_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UISetup()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ComboBoxRelation.SelectedValue = OwnerRelation.Select Then

            MessageBox.Show("Please Select the correct Relation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            If btnSave.Text = "&UPDATE" Then

                UpdateRecord()

            Else

                InsertRecord()

            End If

        End If

    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()

    End Sub

    Private Sub UpdateRecord()

        Dim UpdateHouseHoldMember As New HouseHoldMember

        With UpdateHouseHoldMember

            .MemberId = Me.MemberId

            .HouseHoldName = txtHouseHoldName.Text

            If BirthDate.Checked Then
                .BirthDate = BirthDate.Value
            End If
            If MoveInDate.Checked Then
                .MoveInDate = MoveInDate.Value
            End If
            If MoveOutDate.Checked Then
                .MoveOutDate = MoveOutDate.Value
            End If
            .Occupation = txtOccupation.Text

            .OwnerRelation = ComboBoxRelation.SelectedValue

        End With

        HouseHoldMember.UpdateHouseHoldMember(UpdateHouseHoldMember)

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub

    Private Sub InsertRecord()

        Dim InsertHouseHoldMember As New HouseHoldMember

        With InsertHouseHoldMember

            .AccountId = Me.AccountId
            .HouseHoldName = txtHouseHoldName.Text

            If BirthDate.Checked Then
                .BirthDate = BirthDate.Value
            End If

            If MoveInDate.Checked Then
                .MoveInDate = MoveInDate.Value
            End If

            If MoveOutDate.Checked Then
                .MoveOutDate = MoveOutDate.Value
            End If

            .Occupation = txtOccupation.Text

            .OwnerRelation = ComboBoxRelation.SelectedValue

        End With
        HouseHoldMember.InsertHouseHoldMember(InsertHouseHoldMember)


        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Public Sub ViewRecord()

        Common.BindComboBoxtoList(ComboBoxRelation, GetType(OwnerRelation))
        ComboBoxRelation.SelectedValue = OwnerRelation

    End Sub

#End Region

End Class
