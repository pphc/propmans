'*****************************************************************
'Property Management System ver. 2.0
'
'Module/Sub Module: Receipt Verification
'Module Description: Verify Receipt Number and Date before printing
'Date Created: 3/09/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports BCL

Imports ComponentFactory
Imports PROPMANS.BASE_MOD

Public Class ReceiptVerificationForm

    Private _unitOwner As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Public Property UnitOwner() As String
        Get
            Return _unitOwner
        End Get
        Set(ByVal Value As String)
            _unitOwner = Value
        End Set
    End Property
    Private _receiptNumber As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Public Property ReceiptNumber() As String
        Get
            Return _receiptNumber
        End Get
        Set(ByVal Value As String)
            _receiptNumber = Value
        End Set
    End Property
    Private _receiptDate As Date ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Public Property ReceiptDate() As Date
        Get
            Return _receiptDate
        End Get
        Set(ByVal Value As Date)
            _receiptDate = Value
        End Set
    End Property
    Private _receiptAmount As Decimal ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Public Property ReceiptAmount() As Decimal
        Get
            Return _receiptAmount
        End Get
        Set(ByVal Value As Decimal)
            _receiptAmount = Value
        End Set
    End Property


#Region "Form and Control Events"


    Private Sub ReceiptVerificationForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub chkOverrideReceiptNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverrideReceiptNumber.Click
        If chkOverrideReceiptNumber.Checked Then
            txtReceiptNumber.ReadOnly = False
            txtReceiptNumber.SelectAll()
            txtReceiptNumber.Focus()
        Else
            txtReceiptNumber.ReadOnly = True
            txtReceiptNumber.Text = ReceiptNumber
        End If
    End Sub


    Private Sub txtAmountReceived_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountReceived.TextChanged
        If Not String.IsNullOrEmpty(txtAmountReceived.Text) Then
            If Decimal.Parse(txtAmountReceived.Text) > ReceiptAmount Then
                lblAmountChange.Text = (Decimal.Parse(txtAmountReceived.Text) - ReceiptAmount).ToString("#,###.00")
            Else
                lblAmountChange.Text = String.Empty
            End If
        End If
    End Sub



    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtAmountReceived.Text = String.Empty
        txtAmountReceived.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Common.HasValue(txtReceiptNumber) Then
            ReceiptNumber = txtReceiptNumber.Text
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

    Private Sub UISetup()
        AddHandler txtReceiptNumber.KeyPress, AddressOf Common.Numeric_KeyPress
        AddHandler txtAmountReceived.KeyPress, AddressOf Common.Decimal_KeyPress

        lblUnitOwnerName.Text = UnitOwner
        txtReceiptNumber.Text = ReceiptNumber
        lblReceiptDate.Text = ReceiptDate.ToString("MMMM dd, yyyy")
        txtReceiptNumber.ReadOnly = True
        lblReceiptAmount.Text = ReceiptAmount.ToString("#,###.#0")

    End Sub
#End Region


End Class
