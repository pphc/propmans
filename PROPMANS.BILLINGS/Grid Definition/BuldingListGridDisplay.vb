Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class BuldingListGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("bldg_id"))
        Me.AddColumn(New TextboxColumn("bldg_name", "BLDG NAME"))
        Me.AddColumn(New TextboxColumn("unit_count", "UNITS", New NumericCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("unit_active", "ACTIVE", New NumericCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("unit_generate", "UNBILLED", New NumericCellStyle(DataGridViewContentAlignment.MiddleCenter)))
    End Sub
End Class
