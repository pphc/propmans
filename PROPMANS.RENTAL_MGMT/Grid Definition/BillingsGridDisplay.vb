Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class BillingsGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("bill_id"))
        Me.AddColumn(New TextboxColumn("bill_date", "BILLING MONTH", New MonthYearDateCellStyle))
        Me.AddColumn(New TextboxColumn("period", "PERIOD", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("bill_generate_date", "STATEMENT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("bill_due_date", "DUE DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("amount_due", "AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("penalty_amt", "PENALTY", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("total_due", "TOTAL", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("amount_paid", "AMOUNT PAID", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("balance", "BALANCE", New DecimalCellStyle(2)))

    End Sub

End Class
