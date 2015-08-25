Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class ORInventoryGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("batch_id"))
        Me.AddColumn(New TextboxColumn("start_number", "STARTING O.R", , True))
        Me.AddColumn(New TextboxColumn("end_number", "ENDING O.R", , True))
        Me.AddColumn(New TextboxColumn("date_received", "DATE ENCODED", New ShortDateCellStyle, True))
    End Sub
End Class
