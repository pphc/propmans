Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class MeterReadingListGridDisplay
    Inherits GridColumnBase
 
    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("reading_id"))
        Me.AddColumn(New TextboxColumn("reading_date", "READING DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("reading", "READING", New DecimalCellStyle(4)))
        Me.AddColumn(New TextboxColumn("reading_adjustment", "ADJUSTMENT", New DecimalCellStyle(4)))
        Me.AddColumn(New TextboxColumn("reading_cu", "CONSUMPTION", New DecimalCellStyle(4)))
        Me.AddColumn(New TextboxColumn("reading_status", "STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("reading_flag", "FLAG", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("reading_remarks", "READING REMARKS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("billed", "BILLED", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("reading_cost", "COST", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("cost_adjustment", "COST ADJUSTMENT", New DecimalCellStyle(2)))

    End Sub
End Class
