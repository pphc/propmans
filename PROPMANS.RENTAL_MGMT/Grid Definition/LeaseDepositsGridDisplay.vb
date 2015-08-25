Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class LeaseDepositsGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("bill_id"))
        Me.AddColumn(New TextboxColumn("deposit_item", "DEPOSIT ITEM", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("bill_generate_date", "INVOICE DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("amount_due", "DEPOSIT AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("bill_status", "INVOICE STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
    End Sub

End Class


