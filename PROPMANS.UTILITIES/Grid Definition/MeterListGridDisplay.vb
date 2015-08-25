Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class MeterListGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("meter_id"))
        Me.AddColumn(New TextboxColumn("unit_id"))
        Me.AddColumn(New TextboxColumn("unit_number", "UNIT NUMBER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("unit_owner", "UNIT  OWNER", New DefaultCellStyle))
        Me.AddColumn(New TextboxColumn("meter_number", "METER NUMBER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("installed_date", "DATE INSTALLED", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("start_reading", "START READING", New DecimalCellStyle(4)))
        Me.AddColumn(New TextboxColumn("connection_status", "CONNECTION STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
    End Sub

End Class


