Namespace Common
    Public Class Month
        Inherits ListSource
        Public Sub New()
            For i As Integer = 1 To 12
                Me.AddItem(i, MonthName(i).ToUpper)
            Next
        End Sub
    End Class

End Namespace
