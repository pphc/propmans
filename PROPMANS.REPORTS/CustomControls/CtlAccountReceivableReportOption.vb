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

Imports BCL.Utils

Imports ComponentFactory.Krypton.Toolkit
Imports BCL.Common
Imports PROPMANS.BASE_MOD
Imports BCL.Billings

Public Class CtlAccountReceivableReportOption

#Region "Public Properties"

    'Public Overrides ReadOnly Property IsEntryValid() As Boolean
    '    Get
    '        Return ()
    '    End Get
    'End Property

#End Region

    Private bLoaded As Boolean

#Region "User Controls Events"

    Private Sub ctlAccountReceivableReportOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Common.BindComboBoxtoList(cboBillingFeeType, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))
        bLoaded = True
        cboBillingFeeType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cboBillingFeeType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillingFeeType.SelectedIndexChanged
        If bLoaded Then
            PopulateBillMonths(cboBillMonth, cboBillingFeeType.SelectedValue.ToString)
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub PopulateBillMonths(ByRef cbo As KryptonComboBox, ByVal feeid As String)
        Common.BindComboBoxtoList(cbo, New BillingMonths(feeid))
    End Sub
#End Region


End Class
