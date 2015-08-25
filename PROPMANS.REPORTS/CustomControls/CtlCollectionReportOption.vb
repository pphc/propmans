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

Imports BCL.Payments

Public Class CtlCollectionReportOption

#Region "Public Properties"

    Private _isEntryValid As Boolean

    Public Overrides ReadOnly Property IsEntryValid() As Boolean
        Get
            Return IsDateRangeValid(dtpStartDate.Value.Date, dtpEndDate.Value.Date)
        End Get
    End Property

#End Region

#Region "User Controls Events"

    Private Sub ctlCollectionReportOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboCorporationType.DisplayMember = "Value"
        cboCorporationType.ValueMember = "Key"
        cboCorporationType.DataSource = EnumHelper.ToEnumValueList(GetType(CompanyDivision))
    End Sub


    Private Sub dtpStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        If dtpStartDate.Value > dtpEndDate.Value Then
            dtpEndDate.Value = dtpStartDate.Value
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.ValueChanged
        If dtpEndDate.Value.Date < dtpStartDate.Value.Date Then
            dtpStartDate.Value = dtpEndDate.Value
        End If
    End Sub

#End Region

#Region "Local Procedures"

#End Region


End Class
