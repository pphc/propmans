'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Billing Statement Printing
'Module Description: View and Print generated bills
'Date Created: 3/2/2010
'Date Last Modified: 5/25/2014
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton


Imports PROPMANS.BASE_MOD
Imports PROPMANS.REPORTS
Imports BCL.Common
Imports BCL.Billings

Public Class BillingStatementsForm

#Region "Properties"
    Private _bLoaded As Boolean ' = False

    Private SelectedFeeTypeID As String

    Private SelectedFeeType As String

    Private AccountID As String
#End Region

#Region "Form Instance"
    Private Shared aForm As BillingStatementsForm
    Public Shared Function Instance() As BillingStatementsForm
        If aForm Is Nothing Then
            aForm = New BillingStatementsForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and  Control Events"

    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()
    End Sub


    Private Sub btnViewStatementsAllAccounts_Click(sender As Object, e As EventArgs) Handles btnViewStatementsAllAccounts.Click
        If cboBillingMonth.SelectedIndex <> 0 Then
            Me.Cursor = Cursors.WaitCursor

            SelectedFeeTypeID = cboFeeType.SelectedValue.ToString
            SelectedFeeType = cboFeeType.Text
            Dim selectedMonth As Integer = cboBillingMonth.SelectedIndex
            Dim selectedYear As Integer = nudBillingYear.Value
            Dim billdate As Date = New DateTime(selectedYear, selectedMonth, 1)


            dgBillingStatements.DataSource = Billing.GetBillingStatement(SelectedFeeTypeID, billdate)


            Me.Cursor = Cursors.Default
            UpdateLabelText()
            pnlPrintCommand.Visible = True
        Else
            pnlPrintCommand.Visible = False
        End If

        UpdateBillingHeader()
    End Sub

    Private Sub btnViewStatementsByAccount_Click(sender As Object, e As EventArgs) Handles btnViewStatementsByAccount.Click
        If Not String.IsNullOrEmpty(Me.AccountID) Then
            Me.Cursor = Cursors.WaitCursor

            SelectedFeeTypeID = cboFeeTypeIndividual.SelectedValue.ToString
            SelectedFeeType = cboFeeTypeIndividual.Text

            dgBillingStatements.DataSource = Billing.GetBillingStatement(Me.AccountID, SelectedFeeTypeID)

            Me.Cursor = Cursors.Default
            UpdateLabelText()

            pnlPrintCommand.Visible = True

            UpdateBillingHeader()
        End If
    End Sub

    Private Sub btnViewBilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cboBillingMonth.SelectedIndex <> 0 Then
            Me.Cursor = Cursors.WaitCursor

            Dim feetypeid As String = cboFeeType.SelectedValue.ToString
            Dim selectedMonth As Integer = cboBillingMonth.SelectedValue
            Dim selectedYear As Integer = nudBillingYear.Value
            Dim billdate As Date = New DateTime(selectedYear, selectedMonth, 1)


            dgBillingStatements.DataSource = Billing.GetBillingStatement(feetypeid, billdate)

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

    Private Sub btnSelectAccount_Click(sender As Object, e As EventArgs) Handles btnSelectAccount.Click
        Using frm As New AccountLookupForm()
            If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Me.AccountID = frm.AccountID
                txtAccountName.Text = String.Format("{0}-{1}", frm.UnitNumber, frm.CustomerFullName)

                ''Common.BindComboBoxtoList(cboFeeType, New RecurringBillFees(Me.FeeDivision, frm.UnitClass))
            End If
        End Using
    End Sub

    Private Sub chkPrintNotes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

        Common.BindComboBoxtoList(cboFeeType, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))
        Common.BindComboBoxtoList(cboFeeTypeIndividual, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))

        cboBillingMonth.SelectedIndex = 0

        UpdateLabelText()

        _bLoaded = True

        pnlPrintCommand.Visible = False
        txtBillingNotes.Visible = False

    End Sub

    Private Sub UpdateLabelText()
        lblRecordCount.Text = dgBillingStatements.RowCount & " Record(s) Found"
    End Sub

    Private Sub UpdateBillingHeader()
        If TabControl1.SelectedTab.Text = "ALL ACCOUNTS" Then
            If cboBillingMonth.SelectedIndex <> 0 Then
                StatementsGroupBox.Values.Heading = String.Format("{0} {1} {2} BILLING STATEMENTS", cboBillingMonth.Text, nudBillingYear.Value.ToString, cboFeeType.Text)
            Else
                StatementsGroupBox.Values.Heading = "BILLING STATEMENTS"
            End If
        Else
            StatementsGroupBox.Values.Heading = String.Format("{0} {1} BILLING STATEMENTS", txtAccountName.Text, cboFeeTypeIndividual.Text)

        End If

    End Sub

    Private Sub ViewReport()
        Dim bs As BillingStatement


        Select Case SelectedFeeType
            Case "CONDO DUES"
                bs = New CondoDuesBillingStatement(GetSelectedBillings())
            Case "CONDO DUES*"
                bs = New CondoDuesBillingStatement(GetSelectedBillings())
            Case "PARKING DUES"
                bs = New ParkingDuesBillingStatement(GetSelectedBillings())
            Case "PARKING DUES*"
                bs = New ParkingDuesBillingStatement(GetSelectedBillings())
            Case "WATER BILL"
                bs = New WaterBillingStatement(GetSelectedBillings())
            Case "UNIT RENTAL"
                bs = New RentalBillingStatement(GetSelectedBillings())
            Case "PARKING RENTAL"
                bs = New ParkingRentalBillingStatement(GetSelectedBillings())
            Case "TEMPORARY POWER"
                bs = New TemporaryPowerBillingStatement(GetSelectedBillings())
            Case Else
                bs = New CondoDuesBillingStatement(GetSelectedBillings())
        End Select

        bs.FeeID = SelectedFeeTypeID
        bs.LoadReport()
        Using frm As New PreviewBillingStatementForm(bs.ReportDoc)
            frm.ShowDialog()
        End Using

        chkSelectAll.Checked = False

    End Sub

    Private Function GetSelectedBillings() As List(Of AccountBilling)
        Dim bs As New List(Of AccountBilling)

        For Each row As DataGridViewRow In dgBillingStatements.Rows
            With DirectCast(row.DataBoundItem, AccountBilling)
                If .IsSelected Then
                    bs.Add(row.DataBoundItem)
                End If
            End With
        Next

        Return bs
    End Function

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
