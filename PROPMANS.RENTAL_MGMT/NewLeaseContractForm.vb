Imports ComponentFactory.Krypton.Toolkit
Imports BCL

Imports PROPMANS.BASE_MOD
Imports BCL.Common
Imports BCL.Utils

Imports BCL.RentalMgmt
Imports PROPMANS.REPORTS

Public Class NewLeaseContractForm
    Private _bLoaded As Boolean

#Region "PROPERTIES"

    Private _custId As String
    Private Property CustId() As String
        Get
            Return _custId
        End Get
        Set(ByVal value As String)
            _custId = value
        End Set
    End Property


    Private _lastName As String
    Private ReadOnly Property LastName() As String
        Get
            Return _lastName
        End Get
    End Property

    Private _firstName As String
    Private ReadOnly Property FirstName() As String
        Get
            Return _firstName
        End Get
    End Property

    Private _middleName As String
    Private ReadOnly Property MiddleName() As String
        Get
            Return _middleName
        End Get
    End Property


    Private _RMAgreementInfo As RentalMgmtAgreement
    Public Property RMAgreementInfo() As RentalMgmtAgreement
        Get
            Return _RMAgreementInfo
        End Get
        Private Set(ByVal value As RentalMgmtAgreement)
            _RMAgreementInfo = value
        End Set
    End Property



#End Region

#Region " Form and Control Events"

    Private Sub NewLeaseContractForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UISetup()
    End Sub

    Private Sub cboUnitType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnitClass.SelectedIndexChanged
        If _bLoaded Then
            _bLoaded = False
            Common.BindComboBoxtoList(cboUnitInfo, New AvailableUnits(cboUnitClass.Text))
            _bLoaded = True
            If cboUnitInfo.Items.Count > 0 Then
                cboUnitInfo_SelectedIndexChanged(Nothing, Nothing)
            Else
                btnSave.Visible = False
                btnSearch.Enabled = False
            End If
        End If
    End Sub

    Private Sub cboUnitInfo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnitInfo.SelectedIndexChanged
        If _bLoaded Then
            txtCashBond.Text = String.Empty

            RMAgreementInfo = RentalMgmtAgreementDAL.GetRentalAgreementByID(cboUnitInfo.SelectedValue)

            With RMAgreementInfo
                If .UnitClassification = UnitClassification.DormType Then
                    txtRentAmount.Text = .RentAmount / .MaxOccupant
                    txtPrepaidRent.Text = .PrepaidRent / .MaxOccupant
                    txtSecurityDeposit.Text = .SecurityDeposit / .MaxOccupant
                    txtCashBond.Text = .CashBond
                Else
                    txtRentAmount.Text = .RentAmount
                    txtPrepaidRent.Text = .PrepaidRent
                    txtSecurityDeposit.Text = .SecurityDeposit
                End If

                dtpApplicationDate.MinDate = .ContractStartDate
            End With

        End If


    End Sub

    Private Sub rdbExistingLessee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExistingLessee.CheckedChanged
        If rdbExistingLessee.Checked Then
            txtLastName.Enabled = False
            txtFirstName.Enabled = False
            txtMiddleName.Enabled = False

            btnSearch.Text = "SEARCH"
        End If
    End Sub

    Private Sub rdbNewLessse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewLessse.CheckedChanged
        If rdbNewLessse.Checked Then
            txtLastName.Enabled = True
            txtFirstName.Enabled = True
            txtMiddleName.Enabled = True

            txtLastName.Text = String.Empty
            txtFirstName.Text = String.Empty
            txtMiddleName.Text = String.Empty

            btnSearch.Text = "SAVE"

            txtLastName.Focus()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If rdbExistingLessee.Checked Then
            Using frm As AccountLookupForm = New AccountLookupForm(GridDisplayType.NameOnly)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    If Not IsAccountWithActiveContract(frm.CustomerID) Then
                        CustId = frm.CustomerID

                        txtFirstName.Text = frm.CustomerFirstName
                        txtMiddleName.Text = frm.CustomerMiddleName
                        txtLastName.Text = frm.CustomerLastName
                    Else
                        CustId = String.Empty

                        txtFirstName.Text = String.Empty
                        txtMiddleName.Text = String.Empty
                        txtLastName.Text = String.Empty

                        MessageBox.Show("Selected Tenant with existing for approval, active or expired contract", "Tenant with existing contract", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        btnSearch.Focus()
                    End If

                Else
                    CustId = String.Empty
                    txtFirstName.Text = String.Empty
                    txtMiddleName.Text = String.Empty
                    txtLastName.Text = String.Empty
                End If
            End Using
        Else
            If IsEntryValid(True) Then
                If MessageBox.Show("Save New Lessee", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    CustId = LeaseContractDAL.SaveNewLessee(txtLastName.Text.Trim, _
                    txtFirstName.Text.Trim, _
                    txtMiddleName.Text.Trim)

                    MessageBox.Show("Lessee Saved", "New Lesee saved")

                    rdbExistingLessee.Checked = True

                End If
            End If

        End If
    End Sub

    Private Sub dtpApplicationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpApplicationDate.ValueChanged
        dtpContractStart.Value = dtpApplicationDate.Value
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub nudNoOfMonths_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNoOfMonths.ValueChanged
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If IsEntryValid() Then
            If MessageBox.Show("Save New Contract of Lease?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If SaveContract() Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
                Me.Close()
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

        Common.BindComboBoxtoList(cboUnitClass, New AvailableUnitClassification)

        _bLoaded = True

        cboUnitType_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Private Function SaveContract() As Boolean
        Dim newContract As New LeaseContract

        With newContract
            .AgreementID = RMAgreementInfo.AgreemenId
            .CustId = Me.CustId

            .ApplicationDate = dtpApplicationDate.Value.Date
            .MonthTerm = Integer.Parse(nudNoOfMonths.Value)
            .ContractStartDate = dtpContractStart.Value.Date
            .ContractEndDate = dtpContractEnd.Value.Date

            If RMAgreementInfo.UnitClassification = UnitClassification.DormType Then
                .RentAmount = RMAgreementInfo.RentAmount / RMAgreementInfo.MaxOccupant
                .PrepaidRent = RMAgreementInfo.PrepaidRent / RMAgreementInfo.MaxOccupant
                .SecurityDeposit = RMAgreementInfo.SecurityDeposit / RMAgreementInfo.MaxOccupant
                .CashBond = RMAgreementInfo.CashBond
            Else
                .RentAmount = RMAgreementInfo.RentAmount
                .PrepaidRent = RMAgreementInfo.PrepaidRent
                .SecurityDeposit = RMAgreementInfo.SecurityDeposit
            End If


        End With

        Return LeaseContractDAL.InsertLeaseContract(newContract) > 1

    End Function

    Private Function IsEntryValid(Optional NewLesseeEntry As Boolean = False) As Boolean
        Dim bValid As Boolean = True

        ErrorProvider1.Clear()

        If rdbExistingLessee.Checked Then

            If String.IsNullOrEmpty(CustId) Then
                MessageBox.Show("Select Lessee", "Select Tenant")
                bValid = False
            End If

        Else
            If Not NewLesseeEntry Then
                If String.IsNullOrEmpty(CustId) Then
                    MessageBox.Show("Save New Lessee first", "Save Lesee")
                    bValid = False
                End If
            End If

            If Not Common.HasValue(txtLastName) Then
                ErrorProvider1.SetError(txtLastName, "Enter value for Last Name")
                bValid = False
            Else
                ErrorProvider1.SetError(txtLastName, "")
            End If

            If Not Common.HasValue(txtFirstName) Then
                ErrorProvider1.SetError(txtFirstName, "Enter value for First Name")
                bValid = False
            Else
                ErrorProvider1.SetError(txtFirstName, "")
            End If

            If Not Common.HasValue(txtMiddleName) Then
                ErrorProvider1.SetError(txtMiddleName, "Enter value for Middle Name")
                bValid = False
            Else
                ErrorProvider1.SetError(txtMiddleName, "")
            End If
        End If

        Return bValid

    End Function

    Private Function IsAccountWithActiveContract(customerID As String) As Boolean
        Dim x As Integer = LeaseContractDAL.WithActiveContract(customerID)
        Return x
    End Function
#End Region

  
End Class
