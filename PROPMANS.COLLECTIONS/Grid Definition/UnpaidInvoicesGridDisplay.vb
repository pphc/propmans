Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class UnpaidInvoicesGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("bill_id"))
        Me.AddColumn(New TextboxColumn("fee_name", "FEE NAME"))
        Me.AddColumn(New TextboxColumn("bill_date", "BILLING MONTH", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("bill_generate_date", "STATEMENT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("bill_due_date", "DUE DATE", New ShortDateCellStyle(2)))
        Me.AddColumn(New TextboxColumn("amount_due", "AMOUNT DUE", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("penalty_amt", "PENALTY", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("balance", "BALANCE", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("appliedamount", "APPLIED AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("vatable", "WITH VAT", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("status", "STATUS"))
    End Sub
End Class
