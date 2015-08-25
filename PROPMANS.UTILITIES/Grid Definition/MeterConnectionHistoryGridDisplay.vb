Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class MeterConnectionHistoryGridDisplay
    Inherits GridColumnBase
   
    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("changed_date", "CHANGE DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("connection_status", "CONNECTION STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("remarks", "REMARKS"))

    End Sub
End Class
