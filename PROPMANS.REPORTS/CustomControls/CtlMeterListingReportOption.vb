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
Imports BCL.WaterSystem

Public Class CtlMeterListingReportOption

#Region "Public Properties"
    Public Overrides ReadOnly Property IsEntryValid() As Boolean
        Get
            If GetWaterAccountStatus(pnlMeterListingParams).Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    <CLSCompliant(False)> _
    Public ReadOnly Property ConnectionStatus() As List(Of MeterConnectionStatus)
        Get
            Return GetWaterAccountStatus(pnlMeterListingParams)
        End Get
    End Property
#End Region

#Region "User Control Events"

#End Region

#Region "Local Procedures"

    Private Function GetWaterAccountStatus(ByVal pnl As KryptonPanel) As List(Of MeterConnectionStatus)
        Dim connList As New List(Of MeterConnectionStatus)

        For Each ctrl As Control In pnl.Controls
            If TypeOf ctrl Is KryptonCheckBox Then
                If DirectCast(ctrl, KryptonCheckBox).Checked Then
                    connList.Add(EnumHelper.GetEnumValueFromDBValue(Of MeterConnectionStatus)(DirectCast(ctrl, KryptonCheckBox).Tag.ToString))
                End If
            End If
        Next

        Return connList
    End Function

#End Region

End Class
