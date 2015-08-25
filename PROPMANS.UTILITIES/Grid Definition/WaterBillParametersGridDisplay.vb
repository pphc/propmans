Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class WaterBillParametersGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("bill_param_id"))
        Me.AddColumn(New TextboxColumn("effective_date", "EFFECTIVE DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("effective_until", "EFFECTIVE UNTIL", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("min_consumption", "MINIMUM CONSUMPTION", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("min_charge", "MINIMUM CHARGE", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("rate", "RATE PER CU.M.", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("w_cons_table", "WITH CONS. BLOCK", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub
End Class
