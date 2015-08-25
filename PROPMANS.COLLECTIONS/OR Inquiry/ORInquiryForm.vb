'*****************************************************************
'Property Management System ver. 2.0
'
'Module: O.R INQUIRY
'Module Description: Search and View Official Receipt Details
'Date Created: 10/2/2013
'Created By: Mark Angelo Rivo
'Date Last Modified:
'Modified By:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton.Toolkit
Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class ORInquiryForm

#Region "Form Instance"
    Private Shared aForm As ORInquiryForm
    Public Shared Function Instance() As ORInquiryForm
        If aForm Is Nothing Then
            aForm = New ORInquiryForm
        End If
        Return aForm
    End Function

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        aForm = Nothing
    End Sub
#End Region

#Region "Form and Control Events"


    Private Sub ReceiptsLookupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UISetup()
    End Sub

    Private Sub SearchCriteria_CheckedChanged(sender As Object, e As EventArgs) Handles chkByORNumber.CheckedChanged, chkByORDate.CheckedChanged, chkByORDate.CheckedChanged, chkByFeeType.CheckedChanged, chkByCustomer.CheckedChanged
        Dim isChecked As Boolean = DirectCast(sender, KryptonCheckBox).Checked
        Dim searchCriteria As String = DirectCast(sender, KryptonCheckBox).Tag.ToString.ToUpper

        Select Case searchCriteria
            Case "OR"
                ByORSearchKryptonGroupBox.Enabled = isChecked
                txtByORNumber.SelectAll()
                txtByORNumber.Focus()
            Case "ORDATE"
                ByORDateSearchKryptonGroupBox.Enabled = isChecked
            Case "FEETYPE"
                ByFeeTypeSearchKryptonGroupBox.Enabled = isChecked
            Case "CUSTOMER"
                ByCustomerSearchKryptonGroupBox.Enabled = isChecked
        End Select

    End Sub

    Private Sub btnClearSelection_Click(sender As Object, e As EventArgs) Handles btnClearSelection.Click
        txtByORNumber.Clear()
    End Sub

    Private Sub btnSearchReceipt_Click(sender As Object, e As EventArgs) Handles btnSearchReceipt.Click

    End Sub


    Private Sub btnClearField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



#End Region

#Region "Local Procedures"

    Private Sub UISetup()
    End Sub

    Private Sub SearchReceiptNumber()
    End Sub

    Private Function IsReceiptExisting() As Boolean

    End Function

    Private Sub DisplayReceiptInfo(ByVal receipt As ReceiptInfo)
    End Sub


#End Region



   

End Class
