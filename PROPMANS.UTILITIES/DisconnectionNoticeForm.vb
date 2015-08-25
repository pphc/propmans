'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 05-05-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports ComponentFactory.Krypton.Toolkit
Imports BCL


Imports PROPMANS.BASE_MOD
Imports PROPMANS.REPORTS
Imports BCL.Billings

Public Class DisconnectionNoticeForm
    Private dtAccounts As DataTable
    Private isLoading As Boolean ' = False

#Region "Form Instance"
    Private Shared aForm As DisconnectionNoticeForm
    Public Shared Function Instance() As DisconnectionNoticeForm
        If aForm Is Nothing Then
            aForm = New DisconnectionNoticeForm
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

#Region "Forms and Control Events"
    Private Sub chkFilter1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFilter1.CheckedChanged
        If chkFilter1.Checked Then
            pnlCondition1.Enabled = True
            If chkFilter2.Checked Then
                cboJoiningOperator.Visible = True
            End If

            txtValue1.SelectAll()
            txtValue1.Focus()
        Else
            pnlCondition1.Enabled = False
            cboJoiningOperator.Visible = False
        End If


    End Sub

    Private Sub chkFilter2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFilter2.CheckedChanged
        If chkFilter2.Checked Then
            pnlCondition2.Enabled = True
            If chkFilter1.Checked Then
                cboJoiningOperator.Visible = True
            End If

            txtValue2.SelectAll()
            txtValue2.Focus()
        Else
            pnlCondition2.Enabled = False
            cboJoiningOperator.Visible = False
        End If
    End Sub

    Private Sub btnListAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListAccounts.Click
        isLoading = True
        chkSelectAll.Checked = False
        dgUnpaidAccounts.DataSource = GetAccountList()
        lblRecordCount.Text = dgUnpaidAccounts.Rows.Count & " Items Found."
        isLoading = False
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If Not isLoading Then
            Me.Cursor = Cursors.WaitCursor
            For Each dr As DataGridViewRow In dgUnpaidAccounts.Rows
                dr.Cells(0).Value = chkSelectAll.Checked.ToString
            Next
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click

        If HasSelection() Then
            ViewReport()
        End If

    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        cboOperator1.SelectedIndex = 0
        cboOperator2.SelectedIndex = 0
        cboJoiningOperator.SelectedIndex = 0
        cboJoiningOperator.Visible = False

        pnlCondition1.Enabled = False
        pnlCondition2.Enabled = False

        AddHandler txtValue1.KeyPress, AddressOf Common.Numeric_KeyPress
        AddHandler txtValue2.KeyPress, AddressOf Common.Numeric_KeyPress

        GridHelper.SetGridDisplay(dgUnpaidAccounts, New DisconnectionNoticeGridDisplay)
    End Sub

    Private Function HasSelection() As Boolean

        For Each row As DataGridViewRow In dgUnpaidAccounts.Rows
            If row.Cells(0).Value = "True" Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function

    Private Sub ViewReport()
        Dim dt As New BillingsDataSet.DISCONNECTIONDataTable
        Dim rw As BillingsDataSet.DISCONNECTIONRow
        If rdbDisconnectionNotice.Checked Then
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgUnpaidAccounts.Rows
                If row.Cells(0).Value = "True" Then
                    rw = dt.NewRow
                    rw.UNIT_NUMBER = row.Cells("cust_unit_no").Value.ToString
                    rw.UNIT_OWNER = row.Cells("cust_name").Value.ToString
                    rw.CURRENT_UNPAID_AMT = Decimal.Parse(row.Cells("latest_bill_amt").Value)
                    rw.CURRENT_UNPAID_DATE = Date.Parse(row.Cells("latest_bill_date").Value).ToString("MMMM yyyy").ToUpper
                    rw.PREVIOUS_UNPAID_AMT = Decimal.Parse(row.Cells("previous_unpaid").Value)

                    dt.Rows.Add(rw)
                End If
            Next
            dt.AcceptChanges()

            Using rps As New REPORTS.ReportStore
                rps.LoadReport(New REPORTS.WaterDisconnectionNotice(dt, dtpDueDate.Value.Date))
            End Using

        Else
            MessageBox.Show("Report is under Development", "REPORT NOT AVAILABLE")
        End If

    End Sub

    Private Function GetAccountList() As DataTable
        If dtAccounts Is Nothing Then
            dtAccounts = Billing.GetUnpaidBillings()
        End If

        If Not (chkFilter1.Checked Or chkFilter2.Checked) Then
            Return dtAccounts
        Else
            Dim filter As String = String.Empty
            Dim filter1 As String = String.Empty
            Dim filter2 As String = String.Empty
            Dim value As String = 0

            If chkFilter1.Checked Then
                If Not String.IsNullOrEmpty(txtValue1.Text.Trim) Then
                    value = txtValue1.Text.Trim
                Else
                    txtValue1.Text = value
                End If
                filter1 = "latest_bill_amt " & cboOperator1.Text & value
            End If

            If chkFilter2.Checked Then
                If Not String.IsNullOrEmpty(txtValue2.Text.Trim) Then
                    value = txtValue2.Text.Trim
                Else
                    txtValue2.Text = value
                End If
                filter2 = "previous_unpaid " & cboOperator2.Text & value
            End If

            If chkFilter1.Checked And chkFilter2.Checked Then
                filter = filter1 & " " & cboJoiningOperator.Text & " " & filter2
            Else
                If chkFilter1.Checked Then
                    filter = filter1
                End If

                If chkFilter2.Checked Then
                    filter = filter2
                End If
            End If

            Dim dv As New DataView(dtAccounts)

            dv.RowFilter = filter

            Return dv.ToTable()
        End If
    End Function

#End Region

End Class