Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class MeterApplicationGridDisplay
    Inherits GridColumnBase


    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("unit_id"))
        Me.AddColumn(New TextboxColumn("meter_id"))
        Me.AddColumn(New TextboxColumn("account_id"))
        Me.AddColumn(New TextboxColumn("unit_number", "UNIT NUMBER"))
        Me.AddColumn(New TextboxColumn("unit_owner", "UNIT OWNER"))
        Me.AddColumn(New TextboxColumn("occupancy_status", "OCCUPANCY STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("occupant", "OCCUPANT", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("water_application_date", "WATER APPLICATION DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("meter_status", "METER STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub
End Class
