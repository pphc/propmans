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


Imports ComponentFactory.Krypton.Toolkit
Imports BCL.Common
Imports PROPMANS.BASE_MOD
Imports BCL.Billings

Public Class CtlCollectionEfficiencyReportOption

#Region "Public Properties"

    Private _isEntryValid As Boolean

    Public Overrides ReadOnly Property IsEntryValid() As Boolean
        Get
            Return IsDateRangeValid(dtpCERStartDate.Value.Date, dtpCEREndDate.Value.Date)
        End Get
    End Property

#End Region
    Private bLoaded As Boolean

#Region "User Controls Events"

    Private Sub ctlCollectionEfficiencyReportOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Common.BindComboBoxtoList(cboCERFeeType, New BillableFeeTypes(GlobalReference.CurrentUser.CompanyAccess))
        bLoaded = True
        cboCERFeeType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cboCERFeeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCERFeeType.SelectedIndexChanged
        If bLoaded Then
            PopulateBillMonths(cboCERBillMonth, cboCERFeeType.SelectedValue.ToString)
        End If
    End Sub

    Private Sub dtpCERStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCERStartDate.ValueChanged
        dtpCEREndDate.Value = dtpCERStartDate.Value
    End Sub

    Private Sub dtpCEREndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCEREndDate.ValueChanged
        If dtpCEREndDate.Value.Date < dtpCERStartDate.Value.Date Then
            dtpCERStartDate.Value = dtpCEREndDate.Value
        End If
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub PopulateBillMonths(ByRef cbo As KryptonComboBox, ByVal feeid As String)
        Common.BindComboBoxtoList(cbo, New BillingMonths(feeid))
    End Sub
#End Region

End Class
