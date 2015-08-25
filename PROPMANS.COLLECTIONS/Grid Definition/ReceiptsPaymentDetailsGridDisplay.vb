Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class ReceiptsPaymentDetailsGridDisplay
    Inherits GridColumnBase
    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("bill_generate_date", "STATEMENT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("amount_due", "AMOUNT DUE", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("penalty_amt", "PENALTY", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("amount_paid", "AMOUNT PAID", New DecimalCellStyle(2)))
    End Sub
End Class
