Imports PROPMANS.BASE_MOD.GridCellStyle
Imports PROPMANS.BASE_MOD.GridColumns

Public Class BillingsDataChangeGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("", ""))
        Me.AddColumn(New TextboxColumn("bill_id"))
        Me.AddColumn(New TextboxColumn("fee_name", "FEE NAME"))
        Me.AddColumn(New TextboxColumn("bill_date", "BILLING MONTH", New MonthYearDateCellStyle))
        Me.AddColumn(New TextboxColumn("bill_generate_date", "STATEMENT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("amount_due", "AMOUNT DUE", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("penalty_amt", "PENALTY", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("bill_status", "STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub
End Class
