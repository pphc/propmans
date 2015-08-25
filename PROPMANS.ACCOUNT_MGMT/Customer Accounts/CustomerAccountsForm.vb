Imports ComponentFactory.Krypton.Toolkit
Imports BCL
Imports System.Windows.Forms

Imports BCL.CustomerAccounts
Imports BCL.UnitInventory
Imports PROPMANS.BASE_MOD

Public Class CustomerAccountsForm

    Private _bloaded As Boolean ' = False

#Region "PROPERTIES"

    Private _customerId As String
    Private ReadOnly Property CustomerId() As String
        Get
            Return _customerId
        End Get
    End Property

    Private _AddressId As String
    Public ReadOnly Property AddressId() As String
        Get
            Return dgViewAddress.CurrentRow.Cells("CONTACT_ID").Value.ToString
        End Get
    End Property

    Private _contactId As String
    Public ReadOnly Property ContactId() As String
        Get
            Return dgViewContacts.CurrentRow.Cells("CONTACT_ID").Value.ToString
        End Get
    End Property

    Private _accountId As String
    Public ReadOnly Property Accountid() As String
        Get
            Return dgViewUnits.CurrentRow.Cells("ACCOUNT_ID").Value.ToString
        End Get
    End Property

    Private _memberId As String
    Public ReadOnly Property Memberid() As String
        Get
            Return dgViewHouseHoldMembers.CurrentRow.Cells("MEMBER_ID").Value.ToString
        End Get
    End Property

#End Region

#Region "Form Instance"

    Private Shared aForm As CustomerAccountsForm

    Public Shared Function Instance() As CustomerAccountsForm

        If aForm Is Nothing Then
            aForm = New CustomerAccountsForm
        End If
        Return aForm

    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        aForm = Nothing

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        UISetup()
    End Sub

#End Region

#Region "Form & Control Events"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Using frm As AccountLookupForm = New AccountLookupForm
            frm.ShowDialog()

            If frm.DialogResult = Windows.Forms.DialogResult.OK Then

                _customerId = frm.CustomerID
                txtLastName.Text = frm.CustomerLastName
                txtFirstName.Text = frm.CustomerFirstName
                txtMiddleName.Text = frm.CustomerMiddleName
                lblDisplayName.Text = frm.CustomerFullName
                'enable groupbox
                KryptonGroupBox3.Enabled = True
                DisplayPersonalDetail()
                DisplayAddress()
                DisplayContacts()
                DisplayUnitInformation()
            Else
                ClearField()
            End If

        End Using

    End Sub

    Private Sub btnUpdateCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateCustomer.Click

        If MessageBox.Show("Update Customer Personal Details?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            UpdateCustomerInformation()
            DisplayPersonalDetail()
        End If

    End Sub

    Private Sub btnNewContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewContact.Click

        Dim result As DialogResult
        If CATabControlCustomerProfile.SelectedTab Is TabAddresses Then

            Using frm As New NewAddressForm

                frm.btnSave.Text = "&SAVE"
                frm.Text = "NEW ADDRESS"

                Common.BindComboBoxtoList(frm.ComboBoxAddressType, GetType(AddressContactLocation))
                frm._customerId = Me.CustomerId


                result = frm.ShowDialog(Me)
            End Using

        Else

            Using frm As New NewContact

                frm.btnSave.Text = "&SAVE"
                frm.Text = "NEW CONTACT"

                Common.BindComboBoxtoList(frm.ComboBoxContactType, GetType(ContactType))
                Common.BindComboBoxtoList(frm.ComboBoxContactSubType, GetType(ContactLocation))
                frm._customerId = Me.CustomerId

                result = frm.ShowDialog(Me)

            End Using

        End If

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("New Contact Save", "Contact Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayAddress()
            DisplayContacts()

        End If


    End Sub

    Private Sub btnUpdateContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateContact.Click
        Dim result As DialogResult

        If CATabControlCustomerProfile.SelectedTab Is TabAddresses Then

            Using frm As New NewAddressForm

                Common.BindComboBoxtoList(frm.ComboBoxAddressType, GetType(AddressContactLocation))

                frm.AddressLocation = Common.ConvertDescriptionValueToEnum(Of AddressContactLocation)(dgViewAddress.CurrentRow.Cells(1).Value.ToString)

                frm._customerId = Me.CustomerId
                frm._contactId = Me.AddressId

                frm.btnSave.Text = "&UPDATE"
                frm.Text = "UPDATE ADDRESS"
                frm.ViewRecord()

                frm.txtAddressInformation.Text = dgViewAddress.CurrentRow.Cells(2).Value.ToString
                If dgViewAddress.CurrentRow.Cells(3).Value.ToString = "Y" Then

                    frm.RbAddressYes.Checked = True

                Else
                    frm.RbAddressNo.Checked = True
                End If

                result = frm.ShowDialog(Me)

            End Using

        Else
            Using frm As New NewContact
                Common.BindComboBoxtoList(frm.ComboBoxContactType, GetType(ContactType))
                Common.BindComboBoxtoList(frm.ComboBoxContactSubType, GetType(ContactLocation))

                frm.ContactType = Common.ConvertDescriptionValueToEnum(Of ContactType)(dgViewContacts.CurrentRow.Cells(1).Value.ToString)

                frm.ContactLocation = (Common.ConvertDescriptionValueToEnum(Of ContactLocation)(dgViewContacts.CurrentRow.Cells(2).Value.ToString))

                frm._customerId = Me.CustomerId
                frm._contactId = Me.ContactId

                frm.btnSave.Text = "&UPDATE"
                frm.Text = "UPDATE CONTACT"
                frm.ViewRecord()
                frm.txtContact.Text = dgViewContacts.CurrentRow.Cells(3).Value.ToString

                If dgViewContacts.CurrentRow.Cells(4).Value.ToString = "Y" Then

                    frm.RbContactYes.Checked = True

                Else
                    frm.RbContactNo.Checked = True
                End If

                result = frm.ShowDialog(Me)

            End Using

        End If

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Contact Saved", "Contacts Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayAddress()
            DisplayContacts()

        End If

    End Sub

    Private Sub btnUnitUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitUpdate.Click


        If MessageBox.Show("Update Unit Information?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            updateUnitInformation()

        End If



    End Sub

    Private Sub btnNewHouseholdMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewHouseholdMember.Click
        Dim result As DialogResult

        Using frm As New NewHouseHoldMemberForm
            frm.btnSave.Text = "&SAVE"
            frm.Text = "NEW HOUSE HOLD MEMBER"
            frm.BirthDate.Checked = False

            Common.BindComboBoxtoList(frm.ComboBoxRelation, GetType(OwnerRelation))
            frm._accountId = Me.Accountid

            frm.MoveInDate.Checked = False
            frm.MoveOutDate.Checked = False

            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then

            MessageBox.Show("New Household Member", "Household Member Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayHouseHoldMember()

        End If
    End Sub

    Private Sub btnUpdateHouseHoldMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateHouseHoldMember.Click
        Dim result As DialogResult

        Using frm As New NewHouseHoldMemberForm

            Common.BindComboBoxtoList(frm.ComboBoxRelation, GetType(OwnerRelation))
            frm.OwnerRelation = (Common.ConvertDescriptionValueToEnum(Of OwnerRelation)(dgViewHouseHoldMembers.CurrentRow.Cells(2).Value.ToString))

            frm._memberId = Me.Memberid


            frm.btnSave.Text = "&UPDATE"
            frm.Text = "UPDATE HOUSE HOLD MEMBER"

            frm.ViewRecord()

            frm.txtHouseHoldName.Text = dgViewHouseHoldMembers.CurrentRow.Cells(1).Value.ToString()

            If dgViewHouseHoldMembers.CurrentRow.Cells(3).Value.ToString() = String.Empty Then
                frm.BirthDate.Checked = False
            Else
                frm.BirthDate.Value = dgViewHouseHoldMembers.CurrentRow.Cells(3).Value.ToString()
            End If

            frm.txtOccupation.Text = dgViewHouseHoldMembers.CurrentRow.Cells(4).Value.ToString()


            If dgViewHouseHoldMembers.CurrentRow.Cells(5).Value.ToString() = String.Empty Then
                frm.MoveInDate.Checked = False
            Else
                frm.MoveInDate.Value = dgViewHouseHoldMembers.CurrentRow.Cells(5).Value.ToString()
            End If

            If dgViewHouseHoldMembers.CurrentRow.Cells(6).Value.ToString() = String.Empty Then
                frm.MoveOutDate.Checked = False
            Else
                frm.MoveOutDate.Value = dgViewHouseHoldMembers.CurrentRow.Cells(6).Value.ToString()
            End If


            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("House Hold Member Updated", "Update Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            DisplayHouseHoldMember()
        End If

    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        'List of Common.BindComboBoxtoList
        Common.BindComboBoxtoList(ComboboxNameSake, GetType(NameSake))
        Common.BindComboBoxtoList(ComboBoxGender, GetType(GenderList))
        Common.BindComboBoxtoList(ComboBoxCivilStatus, GetType(CivilStatus))
        Common.BindComboBoxtoList(cboPaymentScheme, GetType(PaymentSchemeList))

        'List of Gridview
        GridHelper.SetGridDisplay(dgViewAddress, New CustomerAddressGridDisplay)
        GridHelper.SetGridDisplay(dgViewContacts, New CustomerContactsGridDisplay)
        GridHelper.SetGridDisplay(dgViewUnits, New CustomerUnitsGridDisplay)
        GridHelper.SetGridDisplay(dgViewHouseHoldMembers, New AccountHouseMemberGridDisplay)

        'hide Activies Tab  TabPageActivities
        TabControlUnits.TabPages.Remove(TabPageActivities)

        'disable groupbox
        KryptonGroupBox3.Enabled = False

    End Sub

    Private Sub ClearField()

        lblCustomerCode.Text = String.Empty
        lblAge.Text = String.Empty
        BirthDate.Checked = False
        txtCitizenship.Text = String.Empty
        txtReligion.Text = String.Empty
        txtCompany.Text = String.Empty
        txtOccupation.Text = String.Empty

        dgViewAddress.DataSource = Nothing
        dgViewContacts.DataSource = Nothing

    End Sub

    Private Sub UpdateCustomerInformation()

        Dim updateRecord As New CustomerAccounts.Customer

        With updateRecord

            .CustomerId = Me.CustomerId
            .Gender = ComboBoxGender.SelectedValue
            .MaritalStatus = ComboBoxCivilStatus.SelectedValue

            If BirthDate.Checked Then
                .Birthdate = BirthDate.Value
            End If

            .Citizenship = txtCitizenship.Text
            .Religion = txtReligion.Text
            .Company = txtCompany.Text
            .Occupation = txtOccupation.Text

        End With
        CustomerAccounts.Customer.UpdatePersonalDetail(updateRecord)
        MessageBox.Show("Personal Details Updated", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub updateUnitInformation()
        Dim updateUnitInformation As New CustomerAccounts.CustAccount

        With updateUnitInformation

            .AccountId = Me.Accountid

            If cboPaymentScheme.SelectedIndex <> -1 Then
                .PaymentScheme = cboPaymentScheme.SelectedValue
            End If

            If dtpOrientationDate.Checked Then
                .OrientationDate = dtpOrientationDate.Value.Date
            End If

            If dtpLastOwnerInspectionDate.Checked Then
                .InspectionDate = dtpLastOwnerInspectionDate.Value.Date
            End If

            If dtpOwnerAcceptanceDate.Checked Then
                .AcceptanceDate = dtpOwnerAcceptanceDate.Value.Date
            End If

            If dtpKeyTurnOverDate.Checked Then
                .KeyTurnOverDate = dtpKeyTurnOverDate.Value.Date
            End If

            If dtpDuesStartDate.Checked Then
                .CdStartDate = dtpDuesStartDate.Value.Date
            End If

            If dtpPowerApplicationDate.Checked Then
                .PowerApplicationDate = dtpPowerApplicationDate.Value.Date
            End If

            If dtpTakeOutDate.Checked Then
                .TakeOutDate = dtpTakeOutDate.Value.Date
            End If

            If dtpMoveinFeePaymentDate.Checked Then
                .MoveInFeePaymentDate = dtpMoveinFeePaymentDate.Value.Date
            End If

            If dtpATMDate.Checked Then
                .AtmDate = dtpATMDate.Value.Date
            End If

            If dtpEarlyMoveinRequest.Checked Then
                .EarlyMoveinRequestDate = dtpEarlyMoveinRequest.Value.Date
            End If


        End With
        CustomerAccounts.CustAccount.UpdateUnitInformation(updateUnitInformation)
        MessageBox.Show("Successfully Update", "UPDATE RECORD", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub DisplayPersonalDetail()


        With CustomerAccounts.Customer.GetCustomerInfoByCustomerID(CustomerId)

            ComboboxNameSake.SelectedValue = .NameSake

            If .Birthdate.HasValue Then
                BirthDate.Value = .Birthdate.Value.ToString("MMMM dd, yyyy")
                Dim Age As Integer = Math.Floor(DateDiff(DateInterval.Month, BirthDate.Value, System.DateTime.Now) / 12)
                lblAge.Text = Age & " Year(s) Old"
            Else
                BirthDate.Checked = False
            End If

            lblCustomerCode.Text = .CustomerCode.ToString


            ComboBoxGender.SelectedValue = .Gender


            ComboBoxCivilStatus.SelectedValue = .MaritalStatus



            txtCitizenship.Text = .Citizenship.ToString
            txtReligion.Text = .Religion.ToString
            txtCompany.Text = .Company.ToString
            txtOccupation.Text = .Occupation.ToString

        End With

    End Sub

    Private Sub DisplayAddress()

        dgViewAddress.DataSource = CustomerAccounts.Customer.GetCustomerAddressByCustomerID(CustomerId)

        If dgViewAddress.RowCount > 0 Then
            btnUpdateContact.Enabled = True
        Else
            btnUpdateContact.Enabled = False
        End If
    End Sub

    Private Sub DisplayContacts()

        dgViewContacts.DataSource = CustomerAccounts.Customer.GetCustomerContactsByCustomerID(CustomerId)
        If dgViewContacts.RowCount > 0 Then

            btnUpdateContact.Enabled = True
        Else
            btnUpdateContact.Enabled = False
        End If
    End Sub

    Private Sub DisplayUnitInformation()

        dgViewUnits.DataSource = CustomerAccounts.CustAccount.GetAccountsByCustomerId(CustomerId)

    End Sub

    Private Sub dgViewUnits_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgViewUnits.SelectionChanged

        btnUpdateHouseHoldMember.Enabled = dgViewUnits.RowCount > 0
        btnNewHouseholdMember.Enabled = dgViewUnits.RowCount > 0
        btnUnitUpdate.Enabled = dgViewUnits.RowCount > 0
        If dgViewUnits.RowCount > 0 Then

            With CustomerAccounts.CustAccount.GetAccountInfoByAccountId(Accountid)
                lblUnitNumber.Text = .UnitNo
                lblUnitClass.Text = .AccountClass
                lblUnitArea.Text = .UnitArea
                If .OrientationDate.HasValue Then
                    dtpOrientationDate.Value = .OrientationDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpOrientationDate.Checked = False
                End If

                If .InspectionDate.HasValue Then
                    dtpLastOwnerInspectionDate.Value = .InspectionDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpLastOwnerInspectionDate.Checked = False
                End If

                If .AcceptanceDate.HasValue Then
                    dtpOwnerAcceptanceDate.Value = .AcceptanceDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpOwnerAcceptanceDate.Checked = False
                End If

                If .AtmDate.HasValue Then

                    dtpATMDate.Value = .AtmDate
                Else
                    dtpATMDate.Checked = False
                End If

                If .KeyTurnOverDate.HasValue Then
                    dtpKeyTurnOverDate.Value = .KeyTurnOverDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpKeyTurnOverDate.Checked = False
                End If

                If .TakeOutDate.HasValue Then

                    dtpTakeOutDate.Value = .TakeOutDate
                Else
                    dtpTakeOutDate.Checked = False
                End If


                If .PaymentScheme.HasValue Then
                    cboPaymentScheme.SelectedValue = .PaymentScheme
                Else
                    cboPaymentScheme.SelectedIndex = -1
                End If



                If .CondoDuesRate = String.Empty Then

                    lblDuesRate.Text = "NOT AVAILABLE"
                Else
                    lblDuesRate.Text = .CondoDuesRate & ".00"
                End If


                If .CdStartDate.HasValue Then
                    dtpDuesStartDate.Value = .CdStartDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpDuesStartDate.Checked = False
                End If

                If .MoveInFeePaymentDate.HasValue Then
                    dtpMoveinFeePaymentDate.Value = .MoveInFeePaymentDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpMoveinFeePaymentDate.Checked = False
                End If

                If .EarlyMoveinRequestDate.HasValue Then
                    dtpEarlyMoveinRequest.Value = .EarlyMoveinRequestDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpEarlyMoveinRequest.Checked = False
                End If


                If .PowerApplicationDate.HasValue Then
                    dtpPowerApplicationDate.Value = .PowerApplicationDate.Value.ToString("MMMM dd, yyyy")
                Else
                    dtpPowerApplicationDate.Checked = False
                End If

                If .WaterApplicationDate.HasValue Then

                    lblMeterApplicationDate.Text = .WaterApplicationDate.Value.ToString("MMMM dd, yyyy")
                Else
                    lblMeterApplicationDate.Text = "NOT AVAILABLE"
                End If

                If dgViewUnits.CurrentRow.Cells(4).Value.ToString = "ACTIVE" Then
                    btnUpdateHouseHoldMember.Enabled = True
                    btnUnitUpdate.Enabled = True
                    btnNewHouseholdMember.Enabled = True

                Else
                    btnUpdateHouseHoldMember.Enabled = False
                    btnUnitUpdate.Enabled = False
                    btnNewHouseholdMember.Enabled = False

                End If

            End With
            DisplayHouseHoldMember()

        End If
    End Sub

    Private Sub DisplayHouseHoldMember()

        dgViewHouseHoldMembers.DataSource = CustomerAccounts.CustAccount.GetHouseholdMemberByAccountId(Accountid)

        If dgViewHouseHoldMembers.RowCount = 0 Then

            btnUpdateHouseHoldMember.Enabled = False
        Else
            btnUpdateHouseHoldMember.Enabled = True

        End If

        If dgViewUnits.CurrentRow.Cells(4).Value.ToString = "INACTIVE" Then
            btnUpdateHouseHoldMember.Enabled = False
        End If


    End Sub

    Private Sub BirthDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BirthDate.ValueChanged

        If BirthDate.Checked Then
            Dim Age As Integer = Math.Floor(DateDiff(DateInterval.Month, BirthDate.Value, System.DateTime.Now) / 12)
            lblAge.Text = Age & " Year(s) Old"
        Else
            lblAge.Text = String.Empty
        End If

    End Sub

#End Region



End Class
