'*****************************************************************
'Property Management System ver. 2.0
'
'Module:  Customer Unpaid invoices
'Module Description: list all unpaid invoices for payment application for specific customer
'Date Created: 3/8/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports BCL

Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports BCL.Payments
Imports BCL.Checks

Public Class ViewPostDatedChecksForm
    Private _bLoaded As Boolean

    Private _accountID As String

    Public Property AccountID() As String
        Get
            Return _accountID
        End Get
        Set(ByVal Value As String)
            _accountID = Value
        End Set
    End Property

    Public Property LeaseID As String

    Private _feeTypeID As String

    Public Property FeeTypeID() As String
        Get
            Return _feeTypeID
        End Get
        Set(ByVal Value As String)
            _feeTypeID = Value
        End Set
    End Property

    Private selectedCheck As Check
    Public ReadOnly Property SelectedCheckInfo() As ChecksDueDTC
        Get
            Return DirectCast(dgPostDatedChecks.CurrentRow.DataBoundItem, ChecksDueDTC)
        End Get
    End Property

#Region "Form and Control Events"

    Private Sub ViewPostDatedChecksForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region


#Region "Local Procedures"

    Private Sub UISetup()

        dgPostDatedChecks.DataSource = ChecksDAL.GetChecksDueByAccountID(Me.AccountID, Me.FeeTypeID)

        btnSave.Visible = dgPostDatedChecks.RowCount > 0

        lblRecordCount.Text = IIf(dgPostDatedChecks.RowCount = 0, "No Post-dated Checks found", dgPostDatedChecks.RowCount & " Post-dated Checks found")
    End Sub


#End Region




   
End Class



