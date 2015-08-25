'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Receipt Lookup
'Module Description: Search Tool for Finding receipt by or #
'Date Created: N/A
'Date Last Modified: 5/17/2011
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton


Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class ReceiptsLookupFOrm

#Region "Form Instance"
    Private Shared aForm As ReceiptsLookupFOrm
    Public Shared Function Instance() As ReceiptsLookupFOrm
        If aForm Is Nothing Then
            aForm = New ReceiptsLookupFOrm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and Control Events"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UISetup()

    End Sub

    Private Sub chkCondoCorp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCondoCorp.CheckedChanged
        pnlMessage.Visible = False
        ReceiptInfoGroupBox.Visible = False

        txtReceiptNumber.SelectAll()
        txtReceiptNumber.Focus()
    End Sub


    Private Sub btnClearField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearField.Click
        txtReceiptNumber.Text = String.Empty
        txtReceiptNumber.Focus()

        pnlMessage.Visible = False
    End Sub

    Private Sub btnSearchReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchReceipt.Click
        pnlMessage.Visible = False
        ReceiptInfoGroupBox.Visible = False
        If Common.HasValue(txtReceiptNumber) Then
            SearchReceiptNumber()
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        GridHelper.SetGridDisplay(dgInvoices, New ReceiptsPaymentDetailsGridDisplay)

        AddHandler txtReceiptNumber.KeyPress, AddressOf Common.Numeric_KeyPress


        pnlMessage.Visible = False
        ReceiptInfoGroupBox.Visible = False
    End Sub

    Private Sub SearchReceiptNumber()

        If IsReceiptExisting() Then
            ReceiptInfoGroupBox.Visible = True
        Else
            pnlMessage.Visible = True
            txtReceiptNumber.SelectAll()
            txtReceiptNumber.Focus()
        End If
    End Sub

    Private Function IsReceiptExisting() As Boolean
        Dim receiptNumber As String = txtReceiptNumber.Text.Trim
        Dim corporationName As String
        If chkPPHC.Checked Then
            corporationName = "P"
        Else
            corporationName = "C"
        End If

        Dim rcpt As ReceiptInfo = ReceiptInfo.GetReceiptInfo1(receiptNumber, corporationName)

        If Not rcpt Is Nothing Then
            If chkPPHC.Checked Then
                lblCorporationName.Text = "PPHC"
            Else
                lblCorporationName.Text = "CONDO CORP"
            End If

            DisplayReceiptInfo(rcpt)

            If rcpt.PayCategory = "REG" Then
                BillingParticularsGroupBox.Visible = True
                dgInvoices.DataSource = ReceiptInfo.GetReceiptInvoices(rcpt.PaymentID)
            Else
                BillingParticularsGroupBox.Visible = False
            End If


            Return True
        Else
            Return False
        End If

    End Function

    Private Sub DisplayReceiptInfo(ByVal receipt As ReceiptInfo)
        pnlCheckDetails.Visible = False

        With receipt
            lblReceiptNumber.Text = .ReceiptNumber
            lblReceiptAmount.Text = .PaidAmount.ToString("#,###.00")
            lblReceiptDate.Text = .ReceiptDate.ToString("MMMM dd,yyyy")
            lblIssuedBy.Text = .IssuedBy & " / " & .IssuedDateTime

            If .IssueType = PayIssueType.Manual Then
                lblIssuedType.Text = "Receipt is issued manually"
            Else
                lblIssuedType.Text = "Receipt is system generated"
            End If

            lblUnitNumber.Text = .PayeeUnit
            lblUnitOwner.Text = .PayeeName

            If .PayCategory = "REG" Then
                lblPaymentCategory.Text = "REGULAR INVOICES PAYMENT"
            Else
                lblPaymentCategory.Text = "ADVANCE PAYMENT"
            End If

            If .PaymentType = "CSH" Then
                lblPaymentType.Text = "CASH PAYMENT"
            Else
                lblPaymentType.Text = "CHECK PAYMENT"
                pnlCheckDetails.Visible = True

                lblCheckNumber.Text = .CheckNumber
                lblCheckDate.Text = .CheckDate.Value.ToString("MMM dd,yyyy")
                lblCheckBank.Text = .CheckBank
            End If

            lblRemarks.Text = .Remarks
            lblFeeTypename.Text = .FeeName

            If .Status = "ISSD" Then
                lblCancelledPrompt.Visible = False
            Else
                lblCancelledPrompt.Visible = True
            End If

            If Not String.IsNullOrEmpty(.DepositoryAccount) Then
                lblDepositDate.Text = .DepositDate.ToString("MMMM dd,yyyy")
                lblDepositBank.Text = .DepositoryAccount
            Else
                lblDepositDate.Text = String.Empty
                lblDepositBank.Text = String.Empty
            End If


        End With
    End Sub


#End Region

End Class
