'***********************************************************************
' Assembly         : PROPMANS_UI
' Author           : Mark Angelo Rivo
' Created          : 06-23-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 07-01-2011
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************

Imports System.Data
Imports PROPMANS.BASE_MOD
Imports BCL.Payments

Public Class CtlDepositSummaryReportOption

#Region "Public Properties"

    Private _isEntryValid As Boolean

    Public Overrides ReadOnly Property IsEntryValid() As Boolean
        Get
            If dgDepositList.RowCount > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property DepositID() As String
        Get
            Return dgDepositList.CurrentRow.Cells("deposit_id").Value.ToString()
        End Get
    End Property

#End Region

#Region "User Control Events"
    Private Sub ctlDepositSummaryReportOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridHelper.SetGridDisplay(dgDepositList, New DepositSummaryGridDisplay)
    End Sub

    Private Sub btnViewDeposits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDeposits.Click
        If IsDateRangeValid1() Then
            dgDepositList.DataSource = Deposits.GetDepositsbyDateRange(dtpDepositStartDate.Value.Date, dtpDepositEndDate.Value.Date)
        Else
            DirectCast(dgDepositList.DataSource, DataTable).Rows.Clear()
        End If

    End Sub


#End Region

#Region "Local Procedures"


    Private Function IsDateRangeValid1() As Boolean
        If dtpDepositStartDate.Value.Date > dtpDepositEndDate.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

End Class
