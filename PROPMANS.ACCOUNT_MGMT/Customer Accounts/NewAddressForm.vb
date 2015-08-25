Imports ComponentFactory.Krypton.Toolkit
Imports BCL

Imports BCL.CustomerAccounts
Imports PROPMANS.BASE_MOD

Public Class NewAddressForm

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

    Private _addressLocation As AddressContactLocation

    Public Property AddressLocation() As AddressContactLocation
        Get
            Return _addressLocation
        End Get
        Set(ByVal value As AddressContactLocation)
            _addressLocation = value
        End Set
    End Property
#End Region

#Region "Form & Control Events"

    Private Sub NewAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UISetup()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtAddressInformation.Text = String.Empty Then
            MessageBox.Show("Please Input Address", "Value Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub InsertRecord()

        Dim InsertRecord As New CustomerContact

        With InsertRecord

            .CustomerId = Me.CustomerID
            .ContactLoc = ComboBoxAddressType.SelectedValue
            .Details = txtAddressInformation.Text

            If RbAddressYes.Checked Then
                .Active = Active.Yes
            Else
                .Active = Active.No
            End If

            .IsPreffered = chkMakeDefault.Checked

        End With

        CustomerContact.InsertAddress(InsertRecord)

        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()

    End Sub

    Private Sub UpdateRecord()

        Dim updateRecord As New CustomerContact

        With updateRecord

            .ContactId = Me.ContactId
            .ContactLoc = ComboBoxAddressType.SelectedValue
            .Details = txtAddressInformation.Text

            .IsPreffered = chkMakeDefault.Checked

            If RbAddressYes.Checked Then
                .Active = Active.Yes
            Else
                .Active = Active.No
                .IsPreffered = False
            End If

            CustomerContact.UpdateAddress(updateRecord)

            If RbAddressYes.Checked Then
                If chkMakeDefault.Checked Then
                    CustomerContact.MakeDefaultAddress(Me.CustomerId, Me.ContactId)
                End If
            End If


        End With

       

        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()

    End Sub

    Public Sub ViewRecord()

        Common.BindComboBoxtoList(ComboBoxAddressType, GetType(AddressContactLocation))
        ComboBoxAddressType.SelectedValue = AddressLocation

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

#End Region

    Private Sub RbAddressNo_CheckedChanged(sender As Object, e As EventArgs) Handles RbAddressNo.CheckedChanged
        chkMakeDefault.Visible = RbAddressYes.Checked
    End Sub
End Class
