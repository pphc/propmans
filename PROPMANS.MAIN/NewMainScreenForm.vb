'***********************************************************************
' Assembly         : PROPMANS_MAIN
' Author           : Mark Angelo Rivo
' Created          : 10-23-2012
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports PROPMANS.ACCOUNT_MANAGEMENT
Imports PROPMANS.TECHNICAL
Imports PROPMANS.ADMIN_MOD
Imports PROPMANS.UTILITIES_MOD
Imports PROPMANS.BILLINGS_MOD
Imports PROPMANS.COLLECTIONS_MOD
Imports PROPMANS.REPORTS
Imports PROPMANS.CHECK_MONITORING
Imports PROPMANS.RMS


Imports ComponentFactory.Krypton.Toolkit


Imports BCL
Imports BCL.Common
Imports BCL.Utils
Imports System.ComponentModel


Public Class NewMainScreenForm

#Region "Form and Control Events"

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UISetup()

    End Sub

    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
        Hide()
        UserAccess.LogOff()
        UserLoginFOrm.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = "Today: " & Now.ToString("MMMM dd, yyyy - h:mm:ss tt")
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        Hide()
        UserAccess.LogOff()
        UserLoginFOrm.Show()
    End Sub

    Private Sub CloseAllWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllWindowsToolStripMenuItem.Click
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
    End Sub


#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        KryptonManager.GlobalPalette = KryptonPalette1

        Text &= " build " & Application.ProductVersion
        TextExtra = BCL.Common.GlobalReference.ProjectParameters.SiteName & " PROJECT"

        CurrentUserToolStripStatusLabel.Text &= " " & GlobalReference.CurrentUser.UserID
        ''TODO. display hostname
        ''CurrentUserToolStripStatusLabel.Text &= " CONNECTED TO " & Oraconnection.HostName & " DB Version: " & SessionInfo.DBVersion

        SetSubMenus(MainMenuStrip.Items)

        SetModuleAccess()
    End Sub

    Private Sub SetSubMenus(mainmenu As ToolStripItemCollection)


        For Each submenu As ToolStripItem In mainmenu
            If TypeOf (submenu) Is ToolStripMenuItem Then
                If submenu.Tag.ToString = "logoff" Then
                    AddHandler submenu.Click, AddressOf LogOffToolStripMenuItem_Click
                ElseIf submenu.Tag.ToString <> "main" Then
                    submenu.Enabled = False
                    If submenu.Tag.ToString.Substring(0, 3) = "REP" Then
                        AddHandler submenu.Click, AddressOf ShowReportDialogue
                    ElseIf submenu.Tag.ToString.Substring(0, 3) = "PAR" Then
                        AddHandler submenu.Click, AddressOf ShowReportParameters
                    Else
                        AddHandler submenu.Click, AddressOf GetToolStripMenuItem
                    End If
                End If
                SetSubMenus(DirectCast(submenu, ToolStripMenuItem).DropDownItems)
            End If
        Next

    End Sub

    Private Sub GetToolStripMenuItem(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim mnuTag As String = DirectCast(sender, ToolStripMenuItem).Tag.ToString

        Dim childform As KryptonForm = GetChildInstance(mnuTag)

        OpenMdiChild(childform)

    End Sub

    Private Sub ShowReportParameters(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnuTag As String = DirectCast(sender, ToolStripMenuItem).Tag.ToString.Remove(0, 3)
        Dim frm As New Form
        Select Case mnuTag.ToUpper
            Case "CHECKS DUE REPORT"
                frm = New ChecksDueReportForm
            Case "CHECKS BY STATUS REPORT"
                frm = New CheckStatusReportForm
        End Select
        frm.ShowDialog(Me)
    End Sub

    Private Sub ShowReportDialogue(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnuTag As String = DirectCast(sender, ToolStripMenuItem).Tag.ToString.Remove(0, 4)
        Using rps As New REPORTS.ReportStore
            rps.LoadReport(GetReportType(mnuTag))
        End Using
    End Sub

    Private Function GetReportType(ByVal menuTag As String) As REPORTS.ReportBase

        Select Case menuTag.ToUpper
            Case "UNIT INVENTORY LIST"
                Return New REPORTS.UnitInventoryReport
                'Case "Meter Masterlist"
                ' Return PeriodicReportType.MeterListing
            Case "METER READINGS"
                Return New REPORTS.MeterReadingReport
                'Case "Notice of Disconnection"
                '' Return PeriodicReportType.DisconnectionNotice

            Case "COLLECTION REPORT"
                Return New REPORTS.CollectionReport
            Case "DEPOSIT SUMMARY"
                Return New REPORTS.DepositSummary
            Case "COLLECTION EFFICIENCY"
                Return New REPORTS.CollectionEfficiency
            Case "BILLING SUMMARY"
                Return New REPORTS.BillingSummary
            Case "CUSTOMER LEDGER"
                Return New REPORTS.CustomerLedger
            Case "PAYMENT APPLICATION HISTORY"
                Return New REPORTS.PaymentApplicationHistory
            Case "FOR APPROVAL AGREEMENTS"
                Return New REPORTS.UnitUnderRentalManagementReport("FAP")
            Case "ACTIVE AGREEMENTS"
                Return New REPORTS.UnitUnderRentalManagementReport("ACT")
            Case "EXPIRED AGREEMENTS"
                Return New REPORTS.UnitUnderRentalManagementReport("EXP")
            Case "VACANT UNITS"
                Return New REPORTS.UnitUnderRentalManagementReport("OCC")
            Case "RENT ROLL"
                Return New REPORTS.RentRollReport
            Case "LEASE ENDING"
                Return New REPORTS.LeaseEndingReport
            Case "CANCELLED RECEIPTS"
                Return New REPORTS.CancelledReceiptsReport
            Case "CREDIT MEMOS"
                Return New REPORTS.CreditMemoReport
            Case Else
                Return Nothing
        End Select

    End Function

    Private Function GetChildInstance(ByVal menuTag As String) As KryptonForm

        Dim newfrm As KryptonForm = Nothing

        Select Case menuTag
            Case "Unit Inventory"
                newfrm = UnitInventory.Instance
            Case "Customer Accounts"
                newfrm = CustomerAccountsForm.Instance
            Case "Meter Application"
                newfrm = MeterApplicationForm.Instance
            Case "Move in"
                ' frm = MoveInForm.Instance

            Case "Unit Punchlisting"
                newfrm = UnitPunchlistingForm.Instance
            Case "Water System"
                newfrm = WaterSystemForm.Instance
            Case "Billing Parameters"
                newfrm = BillParametersForm.Instance
            Case "Disconnection Notice"
                newfrm = DisconnectionNoticeForm.Instance

            Case "RMAgreement"
                newfrm = RentalAgreementForm.Instance
            Case "Lease Contract"
                newfrm = LeaseAgreementForm.Instance
            Case "Contract Amendments"
                newfrm = ContractAmendmentForm.Instance
            Case "Pending Approvals"
                newfrm = AgreementsPendingApprovalForm.Instance
            Case "Remittances"
                'frm = DisconnectionNoticeForm.Instance

            Case "One Time Fees"
                newfrm = OneTimeBillGenerationForm.Instance
            Case "Recurring Bills"
                newfrm = RecurringBillGenerationForm.Instance
            Case "Billing Statements"
                newfrm = BillingStatementsForm.Instance

            Case "Payments"
                newfrm = NewPaymentsForm.Instance
            Case "Deposits"
                newfrm = DepositsForm.Instance
            Case "OR Inquiry"
                newfrm = ReceiptsLookupFOrm.Instance
            Case "OR Inventory"
                newfrm = OrinventoryForm.Instance
            Case "AC Invoices"
                newfrm = ACCPACBillingExportForm.Instance
            Case "AC Payments"
                newfrm = AccpacPaymentExportForm.Instance
            Case "Qb Interface Setup"
                'frm = QuickbooksExportForm.Instance(QBookUploadType.Customers)
            Case "Qb Transaction"
                newfrm = QuickbooksTransUploaderForm.Instance

            Case "Checks Acknowledgement Receipt"
                newfrm = ChecksARForm.Instance
            Case "Check Status Update"
                newfrm = ChecksUpdateForm.Instance

            Case "Change Billings"
                newfrm = BillingsDataChangeForm.Instance
            Case "Change Payments"
                newfrm = PaymentsDataChangeForm.Instance
            Case "Penalty Adjustments"
                newfrm = PenaltyAdjustmentsForm.Instance
            Case "User Access"
                'frm = UserManagementForm.Instance
            Case "Change Password"
                ' frm = Nothing
            Case Else
                newfrm = Nothing
        End Select

        newfrm.MdiParent = Me
        newfrm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        newfrm.Dock = DockStyle.Fill

        Return newfrm
    End Function

    Private Sub SetModuleAccess()

        If GlobalReference.CurrentUser.UserGroup = Common.UserGroupType.USER Then
            ADMINStripMenuItem.Enabled = False
        End If


        For Each modulename As KeyValuePair(Of String, ModuleAccessType) In GlobalReference.CurrentUser.ModuleAccess
            Select Case modulename.Key
                Case "AM_CUST_ACCOUNTS"
                    CustomerAccountsToolStripMenuItem.Enabled = True
                    UnitInventoryListToolStripMenuItem.Enabled = True
                Case "AM_METER_APP"
                    MeterApplicationToolStripMenuItem.Enabled = True
                Case "AM_UNIT_INVENTORY"
                    UnitInventoryToolStripMenuItem.Enabled = True

                Case "UP_PUNCHLIST"
                    UNITPUNCHLISTINGToolStripMenuItem.Enabled = True
                Case "UP_REPORTS"
                    UPREPORTSToolStripMenuItem.Enabled = True


                Case "UT_BILLING_PARAM"
                    BillingParametersToolStripMenuItem.Enabled = True
                Case "UT_NOTICE_DISCONNECTION"
                    UnpaidBillingNoticesToolStripMenuItem.Enabled = True
                Case "UT_REP_METER_LIST"
                    'MeterMasterListToolStripMenuItem.Enabled = True
                Case "UT_REP_METER_READ"
                    MeterReadingToolStripMenuItem.Enabled = True
                Case "UT_WATER_SYSTEM"
                    WaterSystemToolStripMenuItem.Enabled = True


                Case "RM_AGREEMENT"
                    RMAgreementToolStripMenuItem.Enabled = True
                Case "RM_LEASE_CONTRACT"
                    LeaseContractToolStripMenuItem.Enabled = True
                Case "RM_AMMENDMENT"
                    ContractAmmendmentToolStripMenuItem.Enabled = True
                Case "RM_APPROVAL"
                    PendingApprovalToolStripMenuItem.Enabled = True
                Case "RM_REPORTS"
                    ForApprovalAgreementsToolStripMenuItem.Enabled = True
                    ActiveAgreementsToolStripMenuItem.Enabled = True
                    ExpiredAndVoidAgreementsToolStripMenuItem.Enabled = True
                    VacantUnitsToolStripMenuItem.Enabled = True
                    RentRollToolStripMenuItem.Enabled = True

                Case "BL_ONE_BILL_GENERATION"
                    OneTimeFeesToolStripMenuItem.Enabled = True
                Case "BL_RECUR_BILL_GENERATION"
                    RecurringBillsToolStripMenuItem.Enabled = True
                Case "BL_STATEMENTS"
                    SOAPrintingToolStripMenuItem.Enabled = True
                Case "BL_REP_BILL_SUMMARY"
                    BillingSummaryToolStripMenuItem.Enabled = True

                Case "CL_DEPOSITS"
                    PaymentDepositToolStripMenuItem.Enabled = True
                Case "CL_OR_INQUIRY"
                    PaymentLookupToolStripMenuItem.Enabled = True
                Case "CL_OR_INVENTORY"
                    ORInventoryToolStripMenuItem1.Enabled = True
                Case "CL_PAYMENTS"
                    PaymentsToolStripMenuItem.Enabled = True

                Case "CL_REP_COLLECTIONS"
                    CollectionReportToolStripMenuItem.Enabled = True
                Case "CL_REP_DEPOSIT"
                    DepositSummaryToolStripMenuItem.Enabled = True
                Case "CL_REP_EFFICIENCY"
                    CollectionEfficiencyToolStripMenuItem.Enabled = True
                Case "CL_REP_LEDGER"
                    CustomerLedgerToolStripMenuItem.Enabled = True
                Case "CL_REP_PAY_HIST"
                    PaymentApplicationHistoryToolStripMenuItem.Enabled = True
                Case "CL_UPLOAD_ACCPAC"
                    ACCPACToolStripMenuItem.Enabled = True
                    ACCPACBillingsUploadToolStripMenuItem.Enabled = True
                    ACCPACPaymentsUploadToolStripMenuItem.Enabled = True
                Case "CL_UPLOAD_QBOOK"
                    QuickbookToolStripMenuItem.Enabled = True
                    BillingsToolStripMenuItem2.Enabled = True
                Case "CL_CHECKS"
                    AcknowlegementReceiptsToolStripMenuItem.Enabled = True
                    CheckStatusUpdateToolStripMenuItem.Enabled = True
                    ListOfChecksDueForAGivenPeriodToolStripMenuItem.Enabled = True
                    ListofChecksByStatusToolStripMenuItem.Enabled = True

                Case "AD_CHANGE_BILL"
                    BillingChangeToolStripMenuItem.Enabled = True
                Case "AD_CHANGE_PAYMENTS"
                    PaymentChangeToolStripMenuItem.Enabled = True
                Case "AD_CHANGE_PENALTY"
                    PenaltyAdjustmentsToolStripMenuItem.Enabled = True
                    CancelledReceiptsToolStripMenuItem.Enabled = True
                    CreditMemosToolStripMenuItem.Enabled = True
                    ' Case "AD_USER_MANAGEMENT"
                    ' UserManagementStripMenuItem.Enabled = True
            End Select
        Next

    End Sub

    Private Sub OpenMdiChild(newForm As Form)
        Dim withChild As Boolean = Me.MdiChildren.Length > 0

        If withChild Then
            For Each frm As Form In Me.MdiChildren
                If frm.GetType() Is newForm.GetType() Then
                    frm.Activate()
                    frm.Focus()
                    Exit For
                End If
            Next
        End If

    End Sub
#End Region
End Class
