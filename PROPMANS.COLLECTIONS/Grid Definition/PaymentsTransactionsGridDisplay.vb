Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class PaymentsTransactionsGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("payment_id"))
        Me.AddColumn(New TextboxColumn("list_id"))
        Me.AddColumn(New TextboxColumn("or_number", "OR NUMBER"))
        Me.AddColumn(New TextboxColumn("ar_item"))
        Me.AddColumn(New TextboxColumn("list_item"))
        Me.AddColumn(New TextboxColumn("class_name"))
        Me.AddColumn(New TextboxColumn("upload_type"))
        Me.AddColumn(New TextboxColumn("fee_name", "FEE NAME"))
        Me.AddColumn(New TextboxColumn("payment_date", "DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("paid_amount", "AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("pay_category", "PAY CATEGORY"))
        Me.AddColumn(New TextboxColumn("payment_type", "MODE OF PAYMENT"))
    End Sub
End Class

