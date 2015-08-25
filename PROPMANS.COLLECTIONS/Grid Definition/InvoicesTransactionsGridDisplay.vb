
Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class InvoicesTransactionsGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("bill_id"))
        Me.AddColumn(New TextboxColumn("list_id"))
        Me.AddColumn(New TextboxColumn("unit_number", "UNIT NUMBER"))
        Me.AddColumn(New TextboxColumn("customer_name", "CUSTOMER NAME"))
        Me.AddColumn(New TextboxColumn("ar_item"))
        Me.AddColumn(New TextboxColumn("list_item"))
        Me.AddColumn(New TextboxColumn("class_name"))
        Me.AddColumn(New TextboxColumn("fee_name", "FEE NAME"))
        Me.AddColumn(New TextboxColumn("bill_date", "INVOICE MONTH", New MonthYearDateCellStyle))
        Me.AddColumn(New TextboxColumn("bill_generate_date", "STATEMENT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("bill_due_date", "DUE DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("amount_due", "AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("w_vat", "WITH VAT"))
    End Sub
End Class


