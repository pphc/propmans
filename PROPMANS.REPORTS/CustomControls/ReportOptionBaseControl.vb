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
Public Class ReportOptionBaseControl

    Public Overridable ReadOnly Property IsEntryValid() As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Function IsDateRangeValid(ByVal fromdate As Date, ByVal endDate As Date) As Boolean
        If fromdate > endDate Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
