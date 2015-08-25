'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Billing Statement Printing
'Module Description: View and Print generated bills
'Date Created: 3/2/2010
'Date Last Modified: 5/12/2011
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton


Imports PROPMANS.BASE_MOD
Imports PROPMANS.REPORTS
Imports BCL.Common
Imports BCL.Billings

Public Class BillingPrintingForm

    Private _bLoaded As Boolean ' = False

#Region "Form Instance"
    Private Shared aForm As BillingPrintingForm
    Public Shared Function Instance() As BillingPrintingForm
        If aForm Is Nothing Then
            aForm = New BillingPrintingForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and  Control Events"

    Private Sub BillingPrintingForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub

    Private Sub cboFeeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFeeType.SelectedIndexChanged
        If _bLoaded Then
            PopulateBillingMonth()
        End If
    End Sub

    Private Sub btnViewBilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewBilling.Click
        If cboBillingMonth.SelectedIndex <> -1 Then

            _bLoaded = False
            Dim feetypeid As String = cboFeeType.SelectedValue.ToString
            'Dim billdate As Date = Date.Parse(cboBillingMonth.SelectedValue.ToString)
            Dim selectedBillMonth As Date = Date.Parse(cboBillingMonth.SelectedValue.ToString)
            Dim billdate As Date = New DateTime(selectedBillMonth.Year, selectedBillMonth.Month, 1)
            Me.Cursor = Cursors.WaitCursor

            dgBillingStatements.DataSource = Billing.GetBillingStatement(feetypeid, billdate)
            _bLoaded = True
            Me.Cursor = Cursors.Default
            UpdateLabelText()
            pnlPrintCommand.Visible = True
        Else
            pnlPrintCommand.Visible = False
        End If

        UpdateBillingHeader()
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If _bLoaded Then
            Me.Cursor = Cursors.WaitCursor
            For Each dr As DataGridViewRow In dgBillingStatements.Rows
                dr.Cells(0).Value = chkSelectAll.Checked.ToString
            Next
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub chkPrintNotes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintNotes.CheckedChanged
        If chkPrintNotes.Checked Then
            txtBillingNotes.Visible = True
        Else
            txtBillingNotes.Visible = False
        End If
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        If HasSelection() Then
            Me.Cursor = Cursors.WaitCursor
            ViewReport()
            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        GridHelper.SetGridDisplay(dgBillingStatements, New BillingStatementsGridDisplay)
        PopulateFeeTypeList()
        UpdateLabelText()

        _bLoaded = True
        pnlPrintCommand.Visible = False
        txtBillingNotes.Visible = False
    End Sub

    Private Sub PopulateFeeTypeList()
        Common.BindComboBoxtoList(cboFeeType, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))

        cboFeeType.SelectedIndex = -1
    End Sub

    Private Sub PopulateBillingMonth()
        Common.BindComboBoxtoList(cboBillingMonth, New BillingMonths(cboFeeType.SelectedValue))

    End Sub

    Private Sub UpdateLabelText()
        lblRecordCount.Text = dgBillingStatements.RowCount & " Record(s) Found"
    End Sub

    Private Sub UpdateBillingHeader()
        If cboBillingMonth.SelectedIndex <> -1 Then
            StatementsGroupBox.Values.Heading = cboBillingMonth.Text & " " & cboFeeType.Text & " BILLING STATEMENTS"
        Else
            StatementsGroupBox.Values.Heading = "BILLING STATEMENTS"
        End If
    End Sub

    Private Sub ViewReport()
        Me.Cursor = Cursors.WaitCursor

        Using dt As New BillingsDataSet.COMMONBILLINGDataTable
            Dim rw As BillingsDataSet.COMMONBILLINGRow

            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgBillingStatements.Rows
                If row.Cells(0).Value = "True" Then

                    rw = dt.NewRow
                    rw.BILL_ID = row.Cells("bill_id").Value.ToString
                    rw.ACCOUNT_ID = row.Cells("account_id").Value.ToString
                    rw.UNIT_NUMBER = row.Cells("unit_number").Value.ToString
                    rw.UNIT_OWNER = row.Cells("cust_name").Value.ToString
                    rw.CURRENT_CHARGES = Decimal.Parse(row.Cells("amount_due").Value)
                    rw.PREVIOUS_CHARGES = Decimal.Parse(row.Cells("previous_balance").Value)
                    rw.PENALTY = Decimal.Parse(row.Cells("penalty_amt").Value)
                    rw.ADVANCES = Decimal.Parse(row.Cells("advances").Value)
                    rw.BILLING_MONTH = Date.Parse(row.Cells("bill_date").Value).ToString("MMMM yyyy").ToUpper
                    rw.STATEMENT_DATE = Date.Parse(row.Cells("bill_generate_date").Value)
                    rw.STATEMENT_DUE_DATE = Date.Parse(row.Cells("bill_due_date").Value)

                    Dim currenttotal As Decimal = rw.CURRENT_CHARGES + rw.PREVIOUS_CHARGES + rw.PENALTY
                    If rw.ADVANCES > currenttotal Then
                        rw.TOTAL_CHARGES = (rw.ADVANCES - currenttotal).ToString("#,##0.00") & " CR"
                    Else
                        rw.TOTAL_CHARGES = (currenttotal - rw.ADVANCES).ToString("#,##0.00")
                    End If

                    With Billing.GetLastPaymentInfo(rw.ACCOUNT_ID, cboFeeType.SelectedValue.ToString, rw.BILL_ID)
                        If .Rows.Count <> 0 Then
                            If Not Convert.IsDBNull(.Rows(0)("payment_date")) Then
                                rw.LAST_PAYMENT_DATE = Date.Parse(.Rows(0)("payment_date"))
                                rw.LAST_PAYMENT_AMOUNT = Decimal.Parse(.Rows(0)("amount"))
                                rw.REF_NO = .Rows(0)("or_number").ToString
                            End If
                        End If
                    End With
                    dt.Rows.Add(rw)
                End If
            Next
            dt.AcceptChanges()
            Using rps As New REPORTS.ReportStore
                Dim rep As RecurringBillReportBase

                Select Case cboFeeType.Text
                    Case "CONDO DUES"
                        rep = New REPORTS.CondoDuesBillingReport
                    Case "PARKING DUES"
                        rep = New REPORTS.ParkingDuesBillingReport
                    Case "UNIT RENTAL"
                        rep = New REPORTS.UnitRentalBillingReport
                    Case "PARKING RENTAL"
                        rep = New REPORTS.ParkingRentalBillingReport
                    Case "WATER BILL"
                        rep = New REPORTS.WaterBillingReport
                        'Case "TEMPORARY POWER"
                    Case Else
                        rep = Nothing
                End Select

                rep.FeeID = cboFeeType.SelectedValue.ToString
                rep.StatementDate = Date.Parse(cboBillingMonth.SelectedValue.ToString)
                rep.dtAccounts = dt

                rps.LoadReport(rep)
            End Using
        End Using


     


        Me.Cursor = Cursors.Default
        chkSelectAll.Checked = False

    End Sub

    Private Function HasSelection() As Boolean

        For Each row As DataGridViewRow In dgBillingStatements.Rows
            If row.Cells(0).Value = "True" Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function


#End Region

End Class
