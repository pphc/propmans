'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 06-23-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 06-24-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************


Imports PROPMANS.BASE_MOD
Imports BCL.Common

Public Class CtlPaymentApplicationOption

#Region "Public Properties"

    Private _accountID As String

    Public Property AccountID() As String
        Get
            Return _accountID
        End Get
        Set(ByVal value As String)
            _accountID = value
        End Set
    End Property

    Private _unitNumber As String
    Public ReadOnly Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
    End Property

    Private _unitOwnerName As String
    Public ReadOnly Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
    End Property


    Private _isEntryValid As Boolean

    Public Overrides ReadOnly Property IsEntryValid() As Boolean
        Get
            Return _isEntryValid
        End Get
    End Property

#End Region

#Region "User Control Events"

    Private Sub ctlCustomerLedgerReportOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateFeeTypes()
    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        SearchCustomer()
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub PopulateFeeTypes()
        Common.BindComboBoxtoList(cboFeeType, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))
    End Sub

    Private Sub SearchCustomer()

        Using frm As AccountLookupForm = New AccountLookupForm
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                _unitNumber = frm.UnitNumber
                _unitOwnerName = frm.CustomerFullName

                lblUnitNumber.Text = _unitNumber
                lblCustomerName.Text = _unitOwnerName
                _accountID = frm.AccountID
                _isEntryValid = True
            Else
                lblUnitNumber.Text = String.Empty
                lblCustomerName.Text = String.Empty
                _isEntryValid = False
            End If
        End Using
        'lblCustomerName.Visible = False
        'lblNotExistingPrompt.Visible = False
        'If Not txtCustUnitNo.Text.Trim.Length = 0 Then
        '    AccountInfo = UnitOwner.GetCustomerInfoByUnitNo(txtCustUnitNo.Text.Trim)
        '    If Not AccountInfo Is Nothing Then

        '        '                Dim custName As String = AccountInfo.Owner.FullName ' COMMENTED BY CODEIT.RIGHT

        '        If Not String.IsNullOrEmpty(AccountInfo.Owner.FullName) Then
        '            lblCustomerName.Visible = True
        '            lblCustomerName.Text = AccountInfo.Owner.FullName
        '        Else
        '            lblNotExistingPrompt.Visible = True
        '            txtCustUnitNo.SelectAll()
        '            txtCustUnitNo.Focus()
        '        End If
        '        _isEntryValid = True
        '    Else
        '        lblNotExistingPrompt.Visible = True
        '        txtCustUnitNo.SelectAll()
        '        txtCustUnitNo.Focus()
        '        _isEntryValid = False
        '    End If
        'Else
        '    lblCustomerName.Text = String.Empty
        '    txtCustUnitNo.Focus()
        '    _isEntryValid = False
        'End If
    End Sub

#End Region


End Class
