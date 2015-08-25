'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: 
'Module Description:
'Date Created:
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory



Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class UndepositedReceiptsForm

    Private _depositType As DepositType

    Private _rowSelected As Integer
    Private _amountSelected As Decimal

    Private _receipts As New List(Of DepositDetails)

    Public ReadOnly Property UndepositedReceipts() As List(Of DepositDetails)
        Get
            Return _receipts
        End Get
    End Property



#Region "Form and Control Events"

    Public Sub New(ByVal depositType As DepositType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _depositType = depositType
    End Sub

    Private Sub UndepositedReceiptsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetUP()
    End Sub

    Private Sub btnShowReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReceipts.Click
        Dim startDate As Date = dtpStartDate.Value.Date
        Dim endDate As Date = dtpEndDate.Value.Date

        dgUndepositedReceipts.DataSource = Deposits.GetUndepositedReceipts(_depositType, startDate, endDate)

        _rowSelected = 0
        _amountSelected = 0
        UpdateLabels()
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectAll()
    End Sub

    Private Sub btnUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UnselectAll()
    End Sub

    Private Sub dgUndepositedReceipts_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUndepositedReceipts.CellValueChanged
        With dgUndepositedReceipts
            If .Item(0, e.RowIndex).Value.ToString = "True" Then
                _rowSelected += 1
                _amountSelected += Decimal.Parse(.Item("paid_amount", e.RowIndex).Value)
            Else
                _rowSelected -= 1
                _amountSelected -= Decimal.Parse(.Item("paid_amount", e.RowIndex).Value)
            End If
        End With
        UpdateLabels()
    End Sub

    Private Sub dgUndepositedReceipts_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUndepositedReceipts.CurrentCellDirtyStateChanged
        If dgUndepositedReceipts.IsCurrentCellDirty Then
            dgUndepositedReceipts.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgUndepositedReceipts_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUndepositedReceipts.Sorted
        _rowSelected = 0
        _amountSelected = 0
        UpdateLabels()
    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        GetReceipts()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "Local Procedure"

    Private Sub UISetUP()
        GridHelper.SetGridDisplay(dgUndepositedReceipts, New UndepositedReceiptsGridDisplay)

        btnOK.Visible = False

        UpdateLabels()

        dtpStartDate.Value = Now.Date
        dtpEndDate.Value = Now.Date


    End Sub

    Private Sub UpdateLabels()

        If _rowSelected = 0 Then
            lblReceiptSelection.Text = "No records selected"
        Else
            lblReceiptSelection.Text = _rowSelected & " Record(s) selected"
        End If

        If _amountSelected = 0 Then
            lblTotalAmount.Visible = False
            btnOK.Visible = False
        Else
            lblTotalAmount.Visible = True
            btnOK.Visible = True
            lblTotalAmount.Text = _amountSelected.ToString("#,###.00")
        End If

    End Sub

    Private Sub UnselectAll()
        For Each dr As DataGridViewRow In dgUndepositedReceipts.Rows
            If dr.Cells(0).Value = "True" Then
                dr.Cells(0).Value = "False"
            End If
        Next
    End Sub

    Private Sub SelectAll()
        For Each dr As DataGridViewRow In dgUndepositedReceipts.Rows
            If dr.Cells(0).Value = "False" Or dr.Cells(0).Value Is Nothing Then
                dr.Cells(0).Value = "True"
            End If
        Next
    End Sub

    Private Sub GetReceipts()
        For Each dr As DataGridViewRow In dgUndepositedReceipts.Rows
            If dr.Cells(0).Value = "True" Then
                Dim receipts As New DepositDetails
                receipts.PaymentID = dr.Cells(1).Value
                receipts.PaymentAmount = Decimal.Parse(dr.Cells("paid_amount").Value)
                _receipts.Add(receipts)
            End If
        Next
    End Sub
#End Region


End Class
