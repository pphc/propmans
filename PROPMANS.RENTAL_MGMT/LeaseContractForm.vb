Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports PROPMANS.REPORTS
Imports BCL.RentalMgmt


Imports BCL.Common

Public Class LeaseContractForm

#Region "Form Instance"

    Private Shared aForm As LeaseContractForm

    Public Shared Function Instance() As LeaseContractForm

        If aForm Is Nothing Then
            aForm = New LeaseContractForm
        End If
        Return aForm

    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        aForm = Nothing

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        UISetup()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "PROPERTIES"
    Public ReadOnly Property CurrentLeaseID() As String
        Get
            Return dgContractOfLease.CurrentRow.Cells("lease_id").Value.ToString
        End Get
    End Property

    Public ReadOnly Property CurrentLeaseInfo() As String
        Get
            Dim unitNumber As String
            Dim lesseeName As String
            Dim contractstart As String
            Dim contractend As String
            Dim status As String

            With dgContractOfLease.CurrentRow
                unitNumber = .Cells("unit_number").Value.ToString
                lesseeName = .Cells("tenant_name").Value.ToString
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
            Return dgLeaseActivities.CurrentRow.Cells("ACTIVITY_ID").Value.ToString
        End Get
    End Property

    Public ReadOnly Property CurrentVehicleID() As String
        Get
            Return dgVehicles.CurrentRow.Cells("VEHICLE_ID").Value.ToString
        End Get
    End Property

#End Region

#Region "Form & Control Events"

    Private Sub RMLeaseOfContractForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgContractOfLease_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContractOfLease.SelectionChanged

        If dgContractOfLease.RowCount > 0 Then
            DisplayContractInformation()
            DisplayActivities()
            DisplayVehicles()
            DisplayBillings()
            DisplayDeposits()
        End If
    End Sub

    Private Sub btnNewContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewContract.Click
        Dim result As DialogResult

        Using frm As New NewLeaseContractForm
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            dgContractOfLease.DataSource = LeaseContractDAL.GetAllLeaseContract
            UpdateLeaseCount()
            MessageBox.Show("Successfully Save", "Contract Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dtpApplicationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpApplicationDate.ValueChanged
        dtpContractStart.Value = dtpApplicationDate.Value
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub nudNoOfMonths_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNoOfMonths.ValueChanged
        dtpContractEnd.Value = dtpContractStart.Value.AddMonths(Integer.Parse(nudNoOfMonths.Value)).AddDays(-1)
    End Sub

    Private Sub btnUpdateContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateLeaseContract.Click

        If MessageBox.Show("Update Lease Contract", "Contract Update Confirmation", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) Then
            If UpdateContract() Then
                dgContractOfLease.DataSource = LeaseContractDAL.GetAllLeaseContract
                MessageBox.Show("Lease Contract Update Successfull", "Contract Updated")
            End If

        End If
    End Sub


    Private Sub btnEndLeaseContract_Click(sender As Object, e As EventArgs) Handles btnEndLeaseContract.Click
        If MessageBox.Show("End Expired Lease Contract?", "Make Contract Inactive Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If EndLeaseContract() Then
                dgContractOfLease.DataSource = LeaseContractDAL.GetAllLeaseContract
                MessageBox.Show("Lease Contract is now inactive", "Lease Contract Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnNewActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewActivity.Click
        Dim result As DialogResult

        Using frm As New NewActivityForm
            frm.Text = "NEW LEASE ACTIVITY"
            frm.LeaseID = CurrentLeaseID
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Lease Activity Saved", "New Activity Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayActivities()
        End If

    End Sub

    Private Sub btnUpdateActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateActivity.Click
        Dim result As DialogResult

        Using frm As New NewActivityForm
            frm.Text = "UPDATE LEASE ACTIVITY"
            frm.ActivityID = Me.CurrentActivityID
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Lease Activity Updated", "Activity Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayActivities()
        End If
    End Sub

    Private Sub btnNewVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewVehicle.Click
        Dim result As DialogResult

        Using frm As New NewVehicleForm
            frm.Text = "NEW VEHICLE"
            frm.LeaseID = CurrentLeaseID
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("New Vehicle Saved", "Vehicle Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayVehicles()
        End If
    End Sub

    Private Sub btnUpdateVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateVehicle.Click
        Dim result As DialogResult

        Using frm As New NewVehicleForm
            frm.Text = "UPDATE VEHICLE"
            frm.VehicleID = Me.CurrentVehicleID
            result = frm.ShowDialog(Me)
        End Using

        If result = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Vehicle Updated", "Vehicle Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayVehicles()
        End If
    End Sub

    Private Sub btnPreviewForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewForm.Click
        KryptonContextMenu1.Show(sender)
    End Sub


    Private Sub PreviewLeaseContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewLeaseContract.Click
        Using rps As New REPORTS.ReportStore
            Dim rep As New ContractOfLeaseReport(Me.CurrentLeaseID)
            rps.LoadReport(rep)
        End Using
    End Sub

    Private Sub PreviewKeyTurnOver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewKeyTurnOver.Click
        Using rps As New REPORTS.ReportStore
            Dim rep As New KeyTenantTurnOverReport(Me.CurrentLeaseID)
            rps.LoadReport(rep)
        End Using
    End Sub


#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        lblName.Text = String.Empty

        GridHelper.SetGridDisplay(dgContractOfLease, New LeaseContractGridDisplay)
        GridHelper.SetGridDisplay(dgVehicles, New VehiclesGridDisplay)
        GridHelper.SetGridDisplay(dgBillings, New BillingsGridDisplay)
        GridHelper.SetGridDisplay(dgLeaseActivities, New ActivitiesGridDisplay)
        GridHelper.SetGridDisplay(dgDeposits, New LeaseDepositsGridDisplay)

        Common.BindComboBoxtoList(cboApprovalStatus, GetType(ApprovalStatus))
        dgContractOfLease.DataSource = LeaseContractDAL.GetAllLeaseContract
        UpdateLeaseCount()

        'Set Access
        cboApprovalStatus.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
        btnUpdateLeaseContract.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)

    End Sub

    Private Sub DisplayContractInformation()

        lblName.Text = Me.CurrentLeaseInfo

        With LeaseContractDAL.GetLeaseContractByLeaseID(Me.CurrentLeaseID)
            lblContractNumber.Text = .ContractNo

            dtpApplicationDate.Value = .ApplicationDate
            nudNoOfMonths.Value = .MonthTerm
            dtpContractStart.Value = .ContractStartDate
            dtpContractEnd.Value = .ContractEndDate

            txtRentAmount.Text = .RentAmount
            txtPrepaidRent.Text = .PrepaidRent
            txtSecurityDeposit.Text = .SecurityDeposit
            txtCashBond.Text = .CashBond

            lblTotalDepositHeld.Text = .TotalDeposit

            If .ApprovalStatus.HasValue Then
                cboApprovalStatus.SelectedValue = .ApprovalStatus.Value
                'cboApprovalStatus.Enabled = (.ApprovalStatus.Value = ApprovalStatus.Approved) And (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
                'btnUpdateLeaseContract.Enabled = (.ApprovalStatus.Value = ApprovalStatus.Approved) And (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)

                cboApprovalStatus.Enabled = False
                btnUpdateLeaseContract.Enabled = False
            Else
                cboApprovalStatus.SelectedIndex = 0
                cboApprovalStatus.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
                btnUpdateLeaseContract.Enabled = (GlobalReference.CurrentUser.UserGroup = UserGroupType.ADMINISTARTOR)
            End If

            btnEndLeaseContract.Enabled = .ContractStatus = LeaseContractStatus.Expired

            lblContractStatus.Text = "CONTRACT IS " & Common.ConvertEnumtoDescription(.ContractStatus)

        End With
    End Sub

    Private Sub DisplayVehicles()
        dgVehicles.DataSource = VehicleDAL.GetVehiclesByLeaseID(Me.CurrentLeaseID)
        btnUpdateVehicle.Enabled = dgVehicles.RowCount > 0
    End Sub

    Private Sub DisplayActivities()
        dgLeaseActivities.DataSource = RentalActivityDAL.GetActivitiesByLeaseID(Me.CurrentLeaseID)
        btnUpdateActivity.Enabled = dgLeaseActivities.RowCount > 0
    End Sub

    Private Sub DisplayBillings()
        dgBillings.DataSource = LeaseContractDTO.GetRentalBillings(Me.CurrentLeaseID)
    End Sub

    Private Sub DisplayDeposits()
        dgDeposits.DataSource = LeaseContractDTO.GetDeposits(Me.CurrentLeaseID)
    End Sub


    Private Function UpdateContract() As Boolean
        Dim contract As New LeaseContract

        With contract
            .LeaseID = Me.CurrentLeaseID
            .ApplicationDate = dtpApplicationDate.Value.Date
            .MonthTerm = nudNoOfMonths.Value
            .ContractStartDate = dtpContractStart.Value.Date
            .ContractEndDate = dtpContractEnd.Value.Date
            If cboApprovalStatus.SelectedIndex > 0 Then
                .ApprovalStatus = cboApprovalStatus.SelectedValue
            End If

        End With

        Return LeaseContractDAL.UpdateLeaseContract(contract) > 0
    End Function

    Public Sub RefreshRentalAgreements()

    End Sub

    Private Sub UpdateLeaseCount()
        lblRecordCount.Text = IIf(dgContractOfLease.RowCount > 0, dgContractOfLease.RowCount & " Record/s Found", "No Record/s Found")
    End Sub

    Private Function EndLeaseContract() As Boolean
        Return LeaseContractDAL.EndContract(Me.CurrentLeaseID)
    End Function

#End Region

End Class
