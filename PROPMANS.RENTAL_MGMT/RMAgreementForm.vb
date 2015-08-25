Imports ComponentFactory.Krypton.Toolkit
Imports BCL

Imports PROPMANS.BASE_MOD
Imports BCL.RentalMgmt
Imports BCL.Common
Imports BCL.Utils

Imports PROPMANS.REPORTS


Public Class RMAgreementForm

#Region "Form Instance"

    Private Shared aForm As RMAgreementForm

    Public Shared Function Instance() As RMAgreementForm

        If aForm Is Nothing Then
            aForm = New RMAgreementForm
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

#Region "Properties"
    Private _bloaded As Boolean ' = False

    Public ReadOnly Property CurrentAgreementID() As String
        Get
            Return dgRentalMgmtAgreement.CurrentRow.Cells("agreement_id").Value.ToString
        End Get
    End Property

    Public ReadOnly Property CurrentAgreementInfo() As String
        Get
            Dim unitNumber As String
            Dim lesseeName As String
            Dim contractstart As String
            Dim contractend As String
            Dim status As String

            With dgRentalMgmtAgreement.CurrentRow
                unitNumber = .Cells("unit_number").Value.ToString
                lesseeName = .Cells("unit_owner").Value.ToString
                contractstart = Date.Parse(.Cells("contract_start").Value).ToShortDateString
                contractend = Date.Parse(.Cells("contract_end").Value.ToString).ToShortDateString
                'TODO convert to descriptive status
                status = .Cells("contract_status").Value.ToString
            End With

            Return String.Format("{0} {1} ({2} to {3}) {4}", unitNumber, lesseeName, contractstart, _
                                contractend, status)
        End Get
    End Property

    Public ReadOnly Property CurrentActivityID() As String
        Get
            Return dgActivites.CurrentRow.Cells("ACTIVITY_ID").Value.ToString
        End Get
    End Property
#End Region

#Region "Form & Control Events"

    Private Sub btnRefreshAgreement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshAgreement.Click
        dgRentalMgmtAgreement.DataSource = RentalMgmtAgreementDAL.GetAllRentalAgreements
        UpdateRMCount()
    End Sub

    Private Sub dgUnitRentalManagement_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRentalMgmtAgreement.SelectionChanged

        If dgRentalMgmtAgreement.RowCount > 0 Then
            DisplayAgreementInformation()
            DisplayActivities()
            DisplayLeaseHistory()
        End If

    End Sub

    Private Sub btnNewContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewContract.Click
        Dim result As DialogResult

        Using frm As New NewRentalManagementAgrreementFrom
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            dgRentalMgmtAgreement.DataSource = RentalMgmtAgreementDAL.GetAllRentalAgreements
            UpdateRMCount()
            MessageBox.Show("Successfully Save", "Contract Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cboUnitClassification_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnitClassification.SelectedIndexChanged

        If _bloaded Then
            If DirectCast(cboUnitClassification.SelectedValue, UnitClassification) = RentalMgmt.UnitClassification.DormType Then
                txtCashBond.Enabled = True
            Else
                txtCashBond.Enabled = False
                txtCashBond.Text = String.Empty
            End If
        End If

    End Sub

    Private Sub txtRentAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRentAmount.TextChanged

        If Common.HasValue(txtRentAmount) Then
            Dim rentAmount As Decimal = Decimal.Parse(txtRentAmount.Text)

            txtPrepaidRent.Text = rentAmount
            txtSecurityDeposit.Text = rentAmount * 2
        End If

    End Sub

    Private Sub dtpAgreementDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAgreementDate.ValueChanged
        dtpContractStart.Value = dtpAgreementDate.Value
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub nudNoOfMonths_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNoOfMonths.ValueChanged
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateRentalAgreement.Click

        If MessageBox.Show("Update Rental Management Agreement", "Agreement Update Confirmation", _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If UpdateRentalAgreement() Then
                dgRentalMgmtAgreement.DataSource = RentalMgmtAgreementDAL.GetAllRentalAgreements
                MessageBox.Show("Rental Management Agreement Update Successfull", "Agreement Updated")
            End If

        End If
    End Sub

    Private Sub btnNewActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewActivity.Click

        Dim result As DialogResult

        Using frm As New NewActivityForm
            frm.Text = "NEW RENTAL AGREEMENT ACTIVITY"
            frm.AgreementID = CurrentAgreementID
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Rental Agreement Activity Saved", "New Activity Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayActivities()
        End If

    End Sub

    Private Sub btnUpdateActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateActivity.Click

        Dim result As DialogResult

        Using frm As New NewActivityForm
            frm.Text = "UPDATE RENTAL AGREEMENT ACTIVITY"
            frm.ActivityID = Me.CurrentActivityID
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Rental Agreement Activity Updated", "Activity Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayActivities()
        End If
    End Sub

    Private Sub btnEndRMAContract_Click(sender As Object, e As EventArgs) Handles btnEndRMAContract.Click
        If MessageBox.Show("End Rental Mangement Agreement Contract?", "Make Contract Inactive Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If EndRMAContract() Then
                dgRentalMgmtAgreement.DataSource = RentalMgmtAgreementDAL.GetAllRentalAgreements
                MessageBox.Show("RMA Contract is now inactive", "RMA Contract Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnPreviewForms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewForm.Click
        KryptonContextMenu1.Show(sender)
    End Sub

    Private Sub PreviewRMA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewRMA.Click
        Using rps As New REPORTS.ReportStore
            Dim rep As New RentalManagementAgreementReport(CurrentAgreementID)
            rps.LoadReport(rep)
        End Using
    End Sub

    Private Sub PreviewSPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewSPA.Click
        Using rps As New REPORTS.ReportStore
            Dim rep As New SpecialPowerOfAttorneyReport(CurrentAgreementID)
            rps.LoadReport(rep)
        End Using
    End Sub

    Private Sub PreviewKeyTurnOver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewKeyTurnOver.Click
        Using rps As New REPORTS.ReportStore
            Dim rep As New KeyTurnOverReport(CurrentAgreementID)
            rps.LoadReport(rep)
        End Using
    End Sub


#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        lblName.Text = String.Empty

        GridHelper.SetGridDisplay(dgRentalMgmtAgreement, New RentalManagementAgreementGridDisplay)
        GridHelper.SetGridDisplay(dgActivites, New ActivitiesGridDisplay)
        GridHelper.SetGridDisplay(dgLeases, New LeasesGridDisplay)

        Common.BindComboBoxtoList(cboUnitClassification, GetType(UnitClassification))
        Common.BindComboBoxtoList(cboCondoDuesPayment, GetType(CondoDuesPayment))
        Common.BindComboBoxtoList(cboRemittanceRelease, GetType(RemittanceRelease))
        Common.BindComboBoxtoList(cboApprovalStatus, GetType(ApprovalStatus))

        'Set Access
        cboApprovalStatus.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
        btnUpdateRentalAgreement.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)

        dgRentalMgmtAgreement.DataSource = RentalMgmtAgreementDAL.GetAllRentalAgreements
        UpdateRMCount()

        _bloaded = True
        cboUnitClassification_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub DisplayAgreementInformation()
        lblName.Text = Me.CurrentAgreementInfo

        With RentalMgmtAgreementDAL.GetRentalAgreementByID(Me.CurrentAgreementID)
            lblAgreementStatus.Text = "CONTRACT IS " & Common.ConvertEnumtoDescription(.ContractStatus)

            lblContractNumber.Text = .ContractNo

            dtpAgreementDate.Value = .AgreementDate
            nudNoOfMonths.Value = .MonthsTerm
            dtpContractStart.Value = .ContractStartDate
            dtpContractEnd.Value = .ContractEndDate

            cboUnitClassification.SelectedValue = .UnitClassification
            txtMaxOccupant.Text = .MaxOccupant

            txtRentAmount.Text = .RentAmount
            txtPrepaidRent.Text = .PrepaidRent
            txtSecurityDeposit.Text = .SecurityDeposit
            txtCashBond.Text = .CashBond

            txtRentUp.Text = .RentUp
            txtMgmtRate.Text = .MgmtRate

            cboCondoDuesPayment.SelectedValue = .CondoDuesPayment
            cboRemittanceRelease.SelectedValue = .RemittanceRelease

            If .ApprovalStatus.HasValue Then
                cboApprovalStatus.SelectedValue = .ApprovalStatus.Value
                'cboApprovalStatus.Enabled = (.ApprovalStatus.Value = ApprovalStatus.Approved) And (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
                'btnUpdateRentalAgreement.Enabled = (.ApprovalStatus.Value = ApprovalStatus.Approved) And (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)

                cboApprovalStatus.Enabled = False
                btnUpdateRentalAgreement.Enabled = False
            Else
                cboApprovalStatus.SelectedIndex = 0
                cboApprovalStatus.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
                btnUpdateRentalAgreement.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
            End If

            btnEndRMAContract.Enabled = .ContractStatus = MgmtContractStatus.Expired

           
        End With
    End Sub

    Private Sub DisplayActivities()
        dgActivites.DataSource = RentalActivityDAL.GetActivitiesByAgreementID(Me.CurrentAgreementID)
        btnUpdateActivity.Enabled = dgActivites.RowCount > 0
    End Sub

    Private Sub DisplayLeaseHistory()
        dgLeases.DataSource = LeaseContractDAL.GetLeaseByAgreementID(Me.CurrentAgreementID)
    End Sub

    Private Function UpdateRentalAgreement() As Boolean
        Dim contract As New RentalMgmtAgreement

        With contract
            .AgreemenId = Me.CurrentAgreementID

            .AgreementDate = dtpAgreementDate.Value.Date
            .MonthsTerm = nudNoOfMonths.Value

            .ContractStartDate = dtpContractStart.Value.Date
            .ContractEndDate = dtpContractEnd.Value.Date

            .UnitClassification = cboUnitClassification.SelectedValue
            .MaxOccupant = Integer.Parse(txtMaxOccupant.Text)

            .RentAmount = Decimal.Parse(txtRentAmount.Text)
            .PrepaidRent = Decimal.Parse(txtPrepaidRent.Text)
            .SecurityDeposit = Decimal.Parse(txtSecurityDeposit.Text)

            If Common.HasValue(txtCashBond) Then
                .CashBond = Decimal.Parse(txtCashBond.Text)
            End If
            .RemittanceRelease = cboRemittanceRelease.SelectedValue
            .CondoDuesPayment = cboCondoDuesPayment.SelectedValue

            If cboApprovalStatus.SelectedIndex > 0 Then
                .ApprovalStatus = cboApprovalStatus.SelectedValue
            End If

        End With

        Return RentalMgmtAgreementDAL.UpdateRentalAgreement(contract) > 0

    End Function

    Private Function EndRMAContract() As Boolean
        Return RentalMgmtAgreementDAL.EndContract(Me.CurrentAgreementID)
    End Function

    Private Sub UpdateRMCount()
        lblRecordCount.Text = IIf(dgRentalMgmtAgreement.RowCount > 0, dgRentalMgmtAgreement.RowCount & " Record/s Found", "No Record/s Found")
    End Sub

#End Region
 

    Private Sub dgRentalMgmtAgreement_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRentalMgmtAgreement.CellContentClick

    End Sub
End Class
