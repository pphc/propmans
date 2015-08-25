Imports ComponentFactory.Krypton.Toolkit
Imports BCL


Imports BCL.CustomerAccounts
Imports PROPMANS.BASE_MOD

Public Class NewContact

#Region "Properties"

    Public _customerId As String

    Public Property CustomerId() As String
        Get
            Return _customerId
        End Get
        Set(ByVal Value As String)
            _customerId = Value
        End Set
    End Property

    Public _contactId As String

    Public Property ContactId() As String
        Get
            Return _contactId
        End Get
        Set(ByVal Value As String)
            _contactId = Value
        End Set
    End Property

    Private _contactLocation As ContactLocation
    Public Property ContactLocation() As ContactLocation
        Get
            Return _contactLocation
        End Get
        Set(ByVal value As ContactLocation)
            _contactLocation = value
        End Set
    End Property

    Private _contactType As ContactType
    Public Property ContactType() As ContactType
        Get
            Return _contactType
        End Get
        Set(ByVal value As ContactType)
            _contactType = value
        End Set
    End Property

#End Region

#Region "Form & Control Events"

    Private Sub NewContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UISetup()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtContact.Text = String.Empty Then

            MessageBox.Show("Please Input Contact", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            If btnSave.Text = "&UPDATE" Then
                UpdateRecord()
            Else
                InsertRecord()
            End If

        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "Local Procedures"

    Private Sub UISetup()

    End Sub

    Private Sub InsertRecord()

        Dim InsertContact As New CustomerContact

        With InsertContact

            .CustomerId = Me.CustomerId
            .ContactType = ComboBoxContactType.SelectedValue
            .ContactLoc = ComboBoxContactSubType.SelectedValue
            .Details = txtContact.Text

            If RbContactYes.Checked Then
                .Active = Active.Yes
            Else
                .Active = Active.No
            End If


        End With
        CustomerContact.InsertContact(InsertContact)

        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()

    End Sub

    Private Sub UpdateRecord()

        Dim UpdateContact As New CustomerContact

        With UpdateContact

            .CustomerId = Me.CustomerId
            .ContactId = Me.ContactId
            .ContactType = ComboBoxContactSubType.SelectedValue
            .ContactLoc = ComboBoxContactType.SelectedValue
            .Details = txtContact.Text

            If RbContactYes.Checked Then

                .Active = Active.Yes

            Else

                .Active = Active.No

            End If

        End With

        CustomerContact.UpdateContact(UpdateContact)

        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()

    End Sub

    Private Sub DisplayRecord()

        Common.BindComboBoxtoList(ComboBoxContactType, GetType(ContactType))
        Common.BindComboBoxtoList(ComboBoxContactSubType, GetType(ContactLocation))

    End Sub

    Public Sub ViewRecord()

        Common.BindComboBoxtoList(ComboBoxContactType, GetType(ContactType))
        ComboBoxContactType.SelectedValue = ContactType

        Common.BindComboBoxtoList(ComboBoxContactSubType, GetType(ContactLocation))
        ComboBoxContactSubType.SelectedValue = ContactLocation

    End Sub

#End Region

End Class
