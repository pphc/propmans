Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class UndepositedReceiptsGridDisplay
    Inherits GridColumnBase
    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("payment_id"))
        Me.AddColumn(New TextboxColumn("or_number", "O.R NUMBER"))
        Me.AddColumn(New TextboxColumn("payment_date", "PAYMENT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("paid_amount", "AMOUNT", New DecimalCellStyle(2)))
    End Sub
End Class
