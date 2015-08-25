'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Reports Viewewr
'Module Description: Previews Reports
'Date Created: 3/2/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BCL.Utils

Public Class ReportViewerForm

    Private rep As ReportDocument

    Private _reportType As ReportBase
    Private ctrlRepOptions As ReportOptionBaseControl

#Region "Form and Control Events"

    Public Sub New(ByVal report As ReportDocument)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        rep = report
    End Sub

    Public Sub New(ByVal reportType As ReportBase)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _reportType = reportType
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BillingsPreviewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click
        If ctrlRepOptions.IsEntryValid Then
            Me.Cursor = Cursors.WaitCursor
            LoadReport()
            Me.Cursor = Cursors.Default
        End If

    End Sub


    Private Sub CrystalReportViewer_Error(source As Object, e As CrystalDecisions.Windows.Forms.ExceptionEventArgs) Handles CrystalReportViewer.Error
        e.Handled = False
    End Sub
 

#End Region

#Region "Local Procedures"

    Private Sub UISetup()

        If Not _reportType Is Nothing Then
            Select Case _reportType.ReportName
                Case "COLLECTION REPORT"
                    ctrlRepOptions = New CtlCollectionReportOption
                Case "WATER METER MASTERLIST"
                    ctrlRepOptions = New CtlMeterListingReportOption
                Case "METER READINGS"
                    ctrlRepOptions = New CtlMeterReadingReportOption
                Case "DEPOSIT SUMMARY"
                    ctrlRepOptions = New CtlDepositSummaryReportOption
                Case "CUSTOMER LEDGER"
                    ctrlRepOptions = New CtlCustomerLedgerReportOption
                Case "PAYMENT APPLICATION HISTORY"
                    ctrlRepOptions = New CtlPaymentApplicationOption
                Case "BILLING SUMMARY"
                    ctrlRepOptions = New CtlAccountReceivableReportOption
                Case "COLLECTION EFFICIENCY"
                    ctrlRepOptions = New CtlCollectionEfficiencyReportOption
                Case "CANCELLED RECEIPTS"
                    ctrlRepOptions = New CtlCollectionReportOption
                Case "CREDIT MEMOS"
                    ctrlRepOptions = New CtlCollectionReportOption
                Case "UNIT INVENTORY"
                    ctrlRepOptions = New ctlUnitInventoryOption
            End Select

            Me.Text = _reportType.ReportName
            pnlReportOptions.Controls.Add(ctrlRepOptions)
        Else
            ReportOptionsGroupBox.Visible = False
            CrystalReportViewer.ReportSource = rep
        End If
    End Sub

#End Region


    Private Sub LoadReport()

        Try
            CrystalReportViewer.ShowExportButton = True

            Select Case _reportType.ReportName
                Case "COLLECTION REPORT"

                    With DirectCast(ctrlRepOptions, CtlCollectionReportOption)
                        DirectCast(_reportType, CollectionReport).StartDAte = .dtpStartDate.Value.Date
                        DirectCast(_reportType, CollectionReport).EndDate = .dtpEndDate.Value.Date
                        'TODO. move EnumHelper.GetDBValue(.cboCorporationType.SelectedValue)
                        DirectCast(_reportType, CollectionReport).CorporationTypeID = EnumHelper.GetDBValue(.cboCorporationType.SelectedValue)
                    End With
                    'Case "WATER METER MASTERLIST"
                    '    rep = soa.LoadReport("ml")
                    '    DirectCast(rep, MeterListingReport).ConnectionStatus = _
                    '    DirectCast(ctrlRepOptions, CtlMeterListingReportOption).ConnectionStatus
                Case "METER READINGS"
                    With DirectCast(ctrlRepOptions, CtlMeterReadingReportOption)
                        DirectCast(_reportType, MeterReadingReport).ReadingDate = .GetBillingMonth
                        DirectCast(_reportType, MeterReadingReport).IncludeAllUnits = .IncludeAllUnits
                    End With
                Case "CUSTOMER LEDGER"
                    With DirectCast(ctrlRepOptions, CtlCustomerLedgerReportOption)
                        DirectCast(_reportType, CustomerLedger).AccountID = .AccountID
                        DirectCast(_reportType, CustomerLedger).LeaseID = .LeaseID
                        DirectCast(_reportType, CustomerLedger).FeeTypeID = .cboFeeType.SelectedValue.ToString
                        DirectCast(_reportType, CustomerLedger).BuyerName = .UnitOwnerName
                        DirectCast(_reportType, CustomerLedger).UnitNumber = .UnitNumber
                        DirectCast(_reportType, CustomerLedger).CustType = .CustType
                        DirectCast(_reportType, CustomerLedger).FeeTypeName = .cboFeeType.Text
                        DirectCast(_reportType, CustomerLedger).TransactionCutOffDate = .dtpTransactionCutoffDate.Value.Date
                    End With
                Case "PAYMENT APPLICATION HISTORY"
                    With DirectCast(ctrlRepOptions, CtlPaymentApplicationOption)
                        DirectCast(_reportType, PaymentApplicationHistory).AccountID = .AccountID
                        DirectCast(_reportType, PaymentApplicationHistory).FeeTypeID = .cboFeeType.SelectedValue.ToString
                        DirectCast(_reportType, PaymentApplicationHistory).BuyerName = .UnitOwnerName
                        DirectCast(_reportType, PaymentApplicationHistory).UnitNumber = .UnitNumber
                        DirectCast(_reportType, PaymentApplicationHistory).FeeTypeName = .cboFeeType.Text
                        DirectCast(_reportType, PaymentApplicationHistory).CutOffDate = .dtpCutOffDate.Value.Date
                    End With
                Case "DEPOSIT SUMMARY"
                    With DirectCast(ctrlRepOptions, CtlDepositSummaryReportOption)
                        DirectCast(_reportType, DepositSummary).DepositID = .DepositID
                    End With
                    'rep.ReportPath = Application.StartupPath.Replace("bin\Debug", "") & "\Reports\"
                Case "BILLING SUMMARY"
                    With DirectCast(ctrlRepOptions, CtlAccountReceivableReportOption)
                        DirectCast(_reportType, BillingSummary).FeeID = .cboBillingFeeType.SelectedValue.ToString
                        DirectCast(_reportType, BillingSummary).FeeName = .cboBillingFeeType.Text
                        DirectCast(_reportType, BillingSummary).BillingDate = Date.Parse(.cboBillMonth.SelectedValue)
                        DirectCast(_reportType, BillingSummary).PaymentCutOff = Date.Parse(.dtpPaymentCutOff.Value.Date)
                    End With

                Case "COLLECTION EFFICIENCY"
                    With DirectCast(ctrlRepOptions, CtlCollectionEfficiencyReportOption)
                        DirectCast(_reportType, CollectionEfficiency).FeeID = .cboCERFeeType.SelectedValue.ToString
                        DirectCast(_reportType, CollectionEfficiency).FeeName = .cboCERFeeType.Text
                        DirectCast(_reportType, CollectionEfficiency).BillingDate = Date.Parse(.cboCERBillMonth.SelectedValue)
                        DirectCast(_reportType, CollectionEfficiency).StartDAte = .dtpCERStartDate.Value.Date
                        DirectCast(_reportType, CollectionEfficiency).EndDate = .dtpCEREndDate.Value.Date
                    End With
                Case "CANCELLED RECEIPTS"
                    With DirectCast(ctrlRepOptions, CtlCollectionReportOption)
                        DirectCast(_reportType, CancelledReceiptsReport).StartDate = .dtpStartDate.Value.Date
                        DirectCast(_reportType, CancelledReceiptsReport).EndDate = .dtpEndDate.Value.Date
                        'TODO. move EnumHelper.GetDBValue(.cboCorporationType.SelectedValue)
                        DirectCast(_reportType, CancelledReceiptsReport).CompanyDivision = EnumHelper.GetDBValue(.cboCorporationType.SelectedValue)
                    End With
                Case "CREDIT MEMOS"
                    With DirectCast(ctrlRepOptions, CtlCollectionReportOption)
                        DirectCast(_reportType, CreditMemoReport).StartDate = .dtpStartDate.Value.Date
                        DirectCast(_reportType, CreditMemoReport).EndDate = .dtpEndDate.Value.Date
                        'TODO. move EnumHelper.GetDBValue(.cboCorporationType.SelectedValue)
                        DirectCast(_reportType, CreditMemoReport).CompanyDivision = EnumHelper.GetDBValue(.cboCorporationType.SelectedValue)
                    End With
                Case "UNIT INVENTORY"
                    With DirectCast(ctrlRepOptions, ctlUnitInventoryOption)
                        DirectCast(_reportType, UnitInventoryReport).BldgList = .BldgList
                    End With
                Case Else
                    rep = Nothing
            End Select

            _reportType.LoadReport()


            CrystalReportViewer.ReportSource = _reportType.ReportDoc
        Catch ex As Exception
            MessageBox.Show(ex.Message & "-" & ex.StackTrace, "CANNOT VIEW REPORT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub


   
End Class
