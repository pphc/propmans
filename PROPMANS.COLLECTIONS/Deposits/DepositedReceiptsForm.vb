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

Public Class DepositedReceiptsForm

#Region "Properties"
    Private depID As String
#End Region

#Region "Form and Control Events"

    Public Sub New(ByVal id As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        depID = id
        UISetUP()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If MessageBox.Show("Cancel Deposit?", "Cancel Deposit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Deposits.CancelDeposit(depID)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region

#Region "Local Procedure"

    Private Sub UISetUP()
        GridHelper.SetGridDisplay(dgDepositedReceipts, New DepositedReceiptsGridDisplay)

        LoadDepositDetails()
        LoadDepositedReceipts()

        UpdateLabels()
    End Sub

    Private Sub UpdateLabels()
        lblRecordCount.Text = dgDepositedReceipts.RowCount & " Records Found"
    End Sub

    Private Sub LoadDepositDetails()

        With Deposits.GetDepositDetails(depID)
            lblDepositDate.Text = .DepositDate.ToString("MMMM dd, yyyy")
            lblAccountNumber.Text = .DepositoryAccountNumber
            lblDepositoryBank.Text = .DepositoryBankName
            lblDepositType.Text = DepositTypeSource.GetDepositTypeName(.DepositType)
            lblDepositAmount.Text = .DepositAmount.ToString("#,###.00")
            lblRemarks.Text = .DepositRemarks
        End With
    End Sub

    Private Sub LoadDepositedReceipts()
        dgDepositedReceipts.DataSource = Deposits.GetDepositedReceipts(depID)
    End Sub

#End Region

End Class
