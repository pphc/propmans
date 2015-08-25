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

Public Class CtlCustomerLedgerReportOption

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

    Private _leaseID As String
    Public Property LeaseID() As String
        Get
            Return _leaseID
        End Get
        Set(ByVal value As String)
            _leaseID = value
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


    Private _custType As String
    Public ReadOnly Property CustType() As String
        Get
            Return _custType
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
                _custType = frm.CustomerType

                lblUnitNumber.Text = _unitNumber
                lblCustomerName.Text = _unitOwnerName
                lblCustomerType.Text = frm.CustomerType
                _accountID = frm.AccountID
                _leaseID = frm.LeaseID
                _isEntryValid = True
            Else
                lblUnitNumber.Text = String.Empty
                lblCustomerName.Text = String.Empty
                _isEntryValid = False
            End If
        End Using

        
    End Sub

#End Region

End Class
