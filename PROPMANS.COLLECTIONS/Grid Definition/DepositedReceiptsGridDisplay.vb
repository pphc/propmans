Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class DepositedReceiptsGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("payment_id"))
        Me.AddColumn(New TextboxColumn("or_number", "OR NUMBER"))
        Me.AddColumn(New TextboxColumn("payment_date", "DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("paid_amount", "AMOUNT", New DecimalCellStyle(2)))
    End Sub
End Class
