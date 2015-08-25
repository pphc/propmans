Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports BCL.Common
Imports BCL

Public Class RecurringBillGenerationForm

#Region "Properties"
    Private _bLoaded As Boolean
    Private _batchFeesLoaded As Boolean
    Private _unitNumber As String
    Private ReadOnly Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
    End Property

    Private _unitOwnerName As String
    Private ReadOnly Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
    End Property

    Private _accountID As String
    Private ReadOnly Property AccountID() As String
        Get
            Return _accountID
        End Get
    End Property

    Private _leaseID As String
    Private ReadOnly Property LeaseID() As String
        Get
            Return _leaseID
        End Get
    End Property

    Private _unitFeeClass As FeeUnitClass
    Private ReadOnly Property UnitFeeClass() As String
        Get
            Return _unitFeeClass
        End Get
    End Property

    Private BillHelper As New BCL.Billings.BillGenerationHelper


    Private selectedUnits As Integer
    Private activeAccounts As Integer
    Private billCount As Integer

#End Region

#Region "Form Instance"

    Private Shared aForm As RecurringBillGenerationForm

    Public Shared Function Instance() As RecurringBillGenerationForm
        If aForm Is Nothing Then
            aForm = New RecurringBillGenerationForm
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

#Region " Form and Control Events"

    Private Sub btnSearchAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccount.Click

        Using frm As AccountLookupForm = New AccountLookupForm()
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                _unitNumber = frm.UnitNumber
                _unitOwnerName = frm.CustomerFullName
                _accountID = frm.AccountID
                _leaseID = frm.LeaseID
                _unitFeeClass = frm.UnitClass

                lblUnitNumber.Text = _unitNumber
                lblCustomerName.Text = _unitOwnerName
                lblCustomerType.Text = frm.CustomerType

                PopulateRecurringBillFees()

                InvoiceDetailsGroupBox.Visible = True
            Else
                lblUnitNumber.Text = String.Empty
                lblCustomerName.Text = String.Empty


                InvoiceDetailsGroupBox.Visible = False
            End If
        End Using
    End Sub

    Private Sub IndividualBillingSchedule_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFeeType.SelectedIndexChanged, cboBillingMonth.SelectedIndexChanged, nudBillingYear.ValueChanged
        If _bLoaded Then

            Dim selectedbillMonth As Date = New Date(nudBillingYear.Value, Integer.Parse(cboBillingMonth.SelectedValue), 1)

            SetBillingSchedule(selectedbillMonth, cboFeeType, dtpStatementDate, dtpDueDate, dtpGracePeriodDate)

        End If
    End Sub

    Private Sub BatchBillingSchedule_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudBatchBillingYear.ValueChanged, cboBatchBillingMonth.SelectedIndexChanged, cboBatchFeeType.SelectedIndexChanged
        If _bLoaded Then
            selectedUnits = 0
            activeAccounts = 0
            billCount = 0
            GenerationPreviewGroupBox.Visible = False
            btnBatchGenerate.Enabled = False

            Me.Cursor = Cursors.WaitCursor

            Dim selectedbillMonth As Date = New Date(nudBatchBillingYear.Value, Integer.Parse(cboBatchBillingMonth.SelectedValue), 1)

            dgBuildingList.DataSource = GlobalReference.UnitStat.LoadStat(cboBatchFeeType.SelectedValue.ToString, selectedbillMonth)

            SetBillingSchedule(selectedbillMonth, cboBatchFeeType, dtpBatchStatementDate, dtpBatchDueDate, dtpBatchGracePeriodDate)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub dgBuildingList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBuildingList.CellValueChanged

        With dgBuildingList
            If Boolean.Parse(.Item(0, e.RowIndex).Value.ToString) Then
                selectedUnits += Integer.Parse(.Item("unit_count", e.RowIndex).Value)
                activeAccounts += Integer.Parse(.Item("unit_active", e.RowIndex).Value)
                billCount += Integer.Parse(.Item("unit_generate", e.RowIndex).Value)
            Else
                selectedUnits -= Integer.Parse(.Item("unit_count", e.RowIndex).Value)
                activeAccounts -= Integer.Parse(.Item("unit_active", e.RowIndex).Value)
                billCount -= Integer.Parse(.Item("unit_generate", e.RowIndex).Value)
            End If

        End With

        lblBatchUnits.Text = selectedUnits
        lblActiveAccounts.Text = activeAccounts
        lblBatchUnitstoGenerate.Text = billCount

        GenerationPreviewGroupBox.Visible = IIf(selectedUnits > 0, True, False)
        btnBatchGenerate.Enabled = IIf(billCount > 0, True, False)

    End Sub

    Private Sub dgBuildingList_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBuildingList.CurrentCellDirtyStateChanged
        If dgBuildingList.IsCurrentCellDirty Then
            dgBuildingList.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub


    Private Sub btnGenerateBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateBill.Click
        If ValidateEntry() Then
            If MessageBox.Show("Generate Bill?", "Bill Generation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                GenerateBill()
                SetDefault()
                MessageBox.Show("Billing was generated")
            End If
        End If

    End Sub


    Private Sub btnBatchGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchGenerate.Click
        If MessageBox.Show("Start Batch Bill Generation?", "Batch Bill Generation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            Dim recordsAffected As Decimal = BatchGenerateBill()
            MessageBox.Show("Bills Generated for " & recordsAffected & " accounts", "Batch Bill Generation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
            selectedUnits = 0
            activeAccounts = 0
            billCount = 0

            GenerationPreviewGroupBox.Visible = False
            btnBatchGenerate.Enabled = False
            BatchBillingSchedule_SelectionChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub RecurringBillTabControl_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RecurringBillTabControl.TabIndexChanged
        If RecurringBillTabControl.TabIndex = 1 And Not _batchFeesLoaded Then
            BatchBillingSchedule_SelectionChanged(Nothing, Nothing)
            _batchFeesLoaded = True
        End If

    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        AddHandler txtAmountDue.KeyPress, AddressOf Common.Decimal_KeyPress
        AddHandler txtPenalty.KeyPress, AddressOf Common.Decimal_KeyPress


        lblUnitNumber.Text = String.Empty
        lblCustomerName.Text = String.Empty
        lblCustomerType.Text = String.Empty

        Common.BindComboBoxtoList(cboBatchFeeType, New RecurringBillFees(GlobalReference.CurrentUser.CompanyAccess))

        PopulateMonthandYearList()

        InvoiceDetailsGroupBox.Visible = False
        GenerationPreviewGroupBox.Visible = False
        btnBatchGenerate.Enabled = False

        GridHelper.SetGridDisplay(dgBuildingList, New BuldingListGridDisplay)

        _bLoaded = True
        'BatchBillingSchedule_SelectionChanged(Nothing, Nothing)

        'If GlobalReference.CurrentUser.UserGroup = UserGroupType.USER Then
        gbAdminOption.Visible = False
        ' End If
    End Sub

    Private Sub PopulateMonthandYearList()

        Common.BindComboBoxtoList(cboBillingMonth, New Month)
        Common.BindComboBoxtoList(cboBatchBillingMonth, New Month)

        nudBillingYear.Minimum = 2007
        nudBillingYear.Maximum = Now.Date.Year
        nudBatchBillingYear.Minimum = 2007
        nudBatchBillingYear.Maximum = Now.Date.Year

        cboBillingMonth.SelectedIndex = Now.Date.Month - 1
        cboBatchBillingMonth.SelectedIndex = Now.Date.Month - 1

        nudBillingYear.Value = Now.Date.Year
        nudBatchBillingYear.Value = Now.Date.Year

    End Sub

    Private Sub PopulateRecurringBillFees()
        _bLoaded = False
        Common.BindComboBoxtoList(cboFeeType, New RecurringBillFees(GlobalReference.CurrentUser.CompanyAccess, Me.UnitFeeClass))
        _bLoaded = True

        IndividualBillingSchedule_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Function ValidateEntry() As Boolean
        ErrorProvider1.Clear()


        If Not BillHelper.IsAccountAllowed(cboFeeType.SelectedValue.ToString, IIf(String.IsNullOrEmpty(LeaseID), AccountID, LeaseID), New Date(nudBillingYear.Value, Integer.Parse(cboBillingMonth.SelectedValue), 1)) Then
            MessageBox.Show("Account has no schedule to generate this fee", "ACCOUNT NOT ALLOWED TO GENERATE FEE")
            Return False
        End If
        If BillHelper.IsBillingMonthExist(cboFeeType.SelectedValue.ToString, IIf(String.IsNullOrEmpty(LeaseID), AccountID, LeaseID), New Date(nudBillingYear.Value, Integer.Parse(cboBillingMonth.SelectedValue), 1)) Then
            MessageBox.Show(String.Format("{0} for the month of {1} {2} is existing", cboFeeType.Text, cboBillingMonth.Text.ToUpper, nudBillingYear.Value), "BILLING MONTH ALREADY EXISTING")
            Return False
        End If

        If pnlIndividualBillingamount.Visible Then
            If Not Common.HasValue(txtAmountDue) Then
                MessageBox.Show("Input Amount Due")
                txtAmountDue.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub GenerateBill()

        Dim billInfo As New Billings.RecurringBill

        With billInfo
            .AccountID = Me.AccountID
            .LeasedID = Me.LeaseID
            .FeeTypeID = cboFeeType.SelectedValue.ToString

            .StatementDate = dtpStatementDate.Value.Date
            .DueDate = dtpDueDate.Value.Date

            If Common.HasValue(txtAmountDue) Then
                .AmountDue = Decimal.Parse(txtAmountDue.Text.Trim)
            End If

            If Common.HasValue(txtPenalty) Then
                .Penalty = Decimal.Parse(txtPenalty.Text.Trim)
            End If
        End With
        BillHelper.GenerateBill(billInfo)

    End Sub

    Private Function BatchGenerateBill() As Decimal
        Dim selectedbillMonth As Date = New Date(nudBatchBillingYear.Value, Integer.Parse(cboBatchBillingMonth.SelectedValue), 1)

        Return BillHelper.BatchGenerateBill(selectedbillMonth, dtpBatchStatementDate.Value, dtpBatchDueDate.Value, cboBatchFeeType.SelectedValue.ToString, GetSelectedBldg)

    End Function

    Private Sub SetDefault()
        cboFeeType.SelectedIndex = 0
        'dtpStatementDate.Value = Date.Now
        txtBillingNotes.Text = String.Empty
        txtAmountDue.Text = String.Empty
    End Sub

    Private Sub SetBillingSchedule(ByVal billdate As Date, ByVal FeeType As KryptonComboBox, ByRef StatementDate As KryptonDateTimePicker, ByRef DueDate As KryptonDateTimePicker, ByRef GracePeriod As KryptonDateTimePicker)
        With BillHelper.GetBillingSchedule(FeeType.SelectedValue.ToString, billdate)
            If .StatementDate.HasValue Then
                StatementDate.Value = .StatementDate
                StatementDate.Enabled = False
            Else
                StatementDate.Value = Date.Now
                StatementDate.Enabled = True
            End If

            If .DueDate.HasValue Then
                DueDate.Value = .DueDate
            Else
                DueDate.Value = Date.Now
            End If

            GracePeriod.Enabled = False
            If .GracePeriodDate.HasValue Then
                GracePeriod.Value = .GracePeriodDate
            Else
                GracePeriod.Value = Date.Now
                GracePeriod.Checked = False
            End If

            If StatementDate.Name = "dtpStatementDate" Then
                If Not ((.StatementDate.HasValue And .DueDate.HasValue) Or .GracePeriodDate.HasValue) Then
                    pnlIndividualBillingamount.Visible = True
                    txtAmountDue.Text = String.Empty
                    txtPenalty.Text = String.Empty
                Else
                    pnlIndividualBillingamount.Visible = False
                    txtAmountDue.Text = String.Empty
                    txtPenalty.Text = String.Empty
                End If
            End If


        End With
    End Sub

    Private Function GetSelectedBldg() As Integer()
        Dim bldglists As New ArrayList

        For Each row As DataGridViewRow In dgBuildingList.Rows
            Dim Ischecked As Boolean
            Boolean.TryParse(row.Cells(0).Value, Ischecked)
            If Ischecked Then
                If Integer.Parse(row.Cells("unit_generate").Value) >= 1 Then
                    bldglists.Add(Integer.Parse(row.Cells("bldg_id").Value))
                End If
            End If
        Next

        Return DirectCast(bldglists.ToArray(GetType(Integer)), Integer())


    End Function
#End Region

End Class
