Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class WaterConsumptionBlockGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("rate_id"))
        Me.AddColumn(New TextboxColumn("from"))
        Me.AddColumn(New TextboxColumn("to"))
        Me.AddColumn(New TextboxColumn("consumption_block", "CONSUMPTION BLOCK"))
        Me.AddColumn(New TextboxColumn("rate", "RATE.", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("min_charge", "MIN CHARGE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
    End Sub
End Class

