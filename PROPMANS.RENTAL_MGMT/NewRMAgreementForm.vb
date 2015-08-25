Imports ComponentFactory.Krypton.Toolkit
Imports BCL
Imports BCL.Common

Imports BCL.Utils

Imports BCL.RentalMgmt
Imports PROPMANS.BASE_MOD

Public Class NewRentalManagementAgrreementFrom

    Private _bLoaded As Boolean

    Private _accountID As String
    Public Property AccountID() As String
        Get
            Return _accountID
        End Get
        Private Set(ByVal value As String)
            _accountID = value
        End Set
    End Property


#Region "Form Instance"

    Private Shared aForm As NewRentalManagementAgrreementFrom

    Public Shared Function Instance() As NewRentalManagementAgrreementFrom
        If aForm Is Nothing Then
            aForm = New NewRentalManagementAgrreementFrom
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub

#End Region

#Region " Form and Control Events"

    Private Sub NewRentalManagementAgrreementFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UISetup()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Using frm As AccountLookupForm = New AccountLookupForm(GridDisplayType.Full, CustomerType.UnitOwner, False)
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then

                If Not IsAccountWithActiveContract(frm.AccountID) Then
                    AccountID = frm.AccountID

                    txtUnitNumber.Text = frm.UnitNumber
                    txtunitOwner.Text = frm.CustomerFullName
                    txtunitType.Text = Common.ConvertEnumtoDescription(frm.UnitClass)
                Else
                    AccountID = String.Empty
                    txtUnitNumber.Text = String.Empty
                    txtunitOwner.Text = String.Empty
                    txtunitType.Text = String.Empty

                    MessageBox.Show("Selected Account with existing for approval, active or expired contract", "Account with existing contract", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    btnSearch.Focus()
                End If
              
            Else
                AccountID = String.Empty
                txtUnitNumber.Text = String.Empty
                txtunitOwner.Text = String.Empty
                txtunitType.Text = String.Empty
            End If
        End Using
    End Sub

    Private Sub cboUnitClassification_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnitClassification.SelectedIndexChanged
        If _bLoaded Then
            If DirectCast(cboUnitClassification.SelectedValue, UnitClassification) = RentalMgmt.UnitClassification.DormType Then
                txtCashBond.Enabled = True
            Else
                txtCashBond.Enabled = False
                txtCashBond.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub dtpAgreementDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAgreementDate.ValueChanged
        dtpContractStart.Value = dtpAgreementDate.Value
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub nudNoOfMonths_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNoOfMonths.ValueChanged
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub txtRentAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRentAmount.TextChanged

        If Common.HasValue(txtRentAmount) Then
            Dim rentAmount As Decimal = Decimal.Parse(txtRentAmount.Text)

            txtPrepaidRent.Text = rentAmount
            txtSecurityDeposit.Text = rentAmount * 2
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If IsEntryValid() Then
            If MessageBox.Show("Save New Unit Rental Management Agreement?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
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
        AddHandler txtRentAmount.KeyPress, AddressOf Common.Decimal_KeyPress
        AddHandler txtPrepaidRent.KeyPress, AddressOf Common.Decimal_KeyPress
        AddHandler txtSecurityDeposit.KeyPress, AddressOf Common.Decimal_KeyPress
        AddHandler txtCashBond.KeyPress, AddressOf Common.Decimal_KeyPress

        Common.BindComboBoxtoList(cboUnitClassification, GetType(UnitClassification))
        Common.BindComboBoxtoList(cboCondoDuesPayment, GetType(CondoDuesPayment))
        Common.BindComboBoxtoList(cboRemittanceRelease, GetType(RemittanceRelease))

        dtpAgreementDate.MaxDate = Date.Now
        _bLoaded = True

        cboUnitClassification_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Function IsEntryValid() As Boolean
        Dim bValid As Boolean = True

        If String.IsNullOrEmpty(AccountID) Then
            MessageBox.Show("Select Unit Owner account", "Select Account")
            bValid = False
        End If

        ErrorProvider1.Clear()

        If Not Common.HasValue(txtRentAmount) Then
            ErrorProvider1.SetError(txtRentAmount, "Enter value for Rent")
            bValid = False
        Else
            ErrorProvider1.SetError(txtRentAmount, "")
        End If

        If Not Common.HasValue(txtMaxOccupant) Then
            ErrorProvider1.SetError(txtMaxOccupant, "Enter value for Max Occupant")
            bValid = False
        Else
            ErrorProvider1.SetError(txtMaxOccupant, "")
        End If

        If DirectCast(cboUnitClassification.SelectedValue, UnitClassification) = RentalMgmt.UnitClassification.DormType Then
            If Not Common.HasValue(txtCashBond) Then
                ErrorProvider1.SetError(txtCashBond, "Enter value for Cash Bond")
                bValid = False
            Else
                ErrorProvider1.SetError(txtCashBond, "")
            End If
        End If

        Return bValid
    End Function

    Private Function SaveContract() As Boolean

        Dim newContract As New RentalMgmtAgreement

        With newContract
            .AccountId = Me.AccountID
            .AgreementDate = dtpAgreementDate.Value.Date
            .UnitClassification = cboUnitClassification.SelectedValue

            .ContractStartDate = dtpContractStart.Value.Date
            .ContractEndDate = dtpContractEnd.Value.Date
            .MonthsTerm = nudNoOfMonths.Value

            .MaxOccupant = Integer.Parse(txtMaxOccupant.Text)
            .RentAmount = Decimal.Parse(txtRentAmount.Text)
            .PrepaidRent = Decimal.Parse(txtPrepaidRent.Text)
            .SecurityDeposit = Decimal.Parse(txtSecurityDeposit.Text)

            If Common.HasValue(txtCashBond) Then
                .CashBond = Decimal.Parse(txtCashBond.Text)
            End If

            .RentUp = Decimal.Parse(txtRentUp.Text)
            .MgmtRate = Decimal.Parse(txtMgmtRate.Text)

            .RemittanceRelease = cboRemittanceRelease.SelectedValue
            .CondoDuesPayment = cboCondoDuesPayment.SelectedValue
        End With

        Return RentalMgmtAgreementDAL.InsertRentalAgreement(newContract) > 1

    End Function

    Private Function IsAccountWithActiveContract(accountID As String) As Boolean
        Dim x As Integer = RentalMgmtAgreementDAL.WithActiveContract(accountID)
        Return x
    End Function

#End Region


End Class
