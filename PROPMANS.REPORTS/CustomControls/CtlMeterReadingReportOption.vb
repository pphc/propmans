'***********************************************************************
' Assembly         : PROPMANS.REPORTS
' Author           : Mark Angelo Rivo
' Created          : 06-23-2011
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 02-04-2013
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************

Imports BCL.Utils
Imports ComponentFactory.Krypton.Toolkit
Imports BCL.WaterSystem
Imports PROPMANS.BASE_MOD

Public Class CtlMeterReadingReportOption

#Region "Public Properties and Procedures"
    'Public Overrides ReadOnly Property IsEntryValid() As Boolean
    '    Get
    '        If GetWaterAccountStatus(pnlMeterReadings).Count > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End Get
    'End Property

    Public ReadOnly Property IncludeAllUnits() As Boolean
        Get
            Return YesRadioButton.Checked
        End Get
    End Property

    Public Function GetBillingMonth() As Date
        Dim period As String = cboBillingMonth.SelectedValue.ToString

        Return Date.Parse(period)

    End Function
#End Region

#Region "User Control Events"
    Private Sub ctlMeterReadingReportOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PopulateFeeTypes()
    End Sub
#End Region

#Region "Local Procedures"

    Private Sub PopulateFeeTypes()
        Common.BindComboBoxtoList(cboBillingMonth, New WaterReadingMonthSource)
    End Sub

    'Private Function GetWaterAccountStatus(ByVal pnl As KryptonPanel) As List(Of MeterConnectionStatus)
    '    Dim connList As New List(Of MeterConnectionStatus)

    '    For Each ctrl As Control In pnl.Controls
    '        If TypeOf ctrl Is KryptonCheckBox Then
    '            If DirectCast(ctrl, KryptonCheckBox).Checked Then
    '                connList.Add(EnumHelper.GetEnumValueFromDBValue(Of MeterConnectionStatus)(DirectCast(ctrl, KryptonCheckBox).Tag.ToString))
    '            End If
    '        End If
    '    Next

    '    Return connList
    'End Function

#End Region

End Class
