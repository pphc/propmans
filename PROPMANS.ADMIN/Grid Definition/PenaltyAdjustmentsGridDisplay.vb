Imports PROPMANS.BASE_MOD.GridCellStyle
Imports PROPMANS.BASE_MOD.GridColumns

Public Class PenaltyAdjustmentsGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        'TODO. checkbox must be first
        Me.AddColumn(New TextboxColumn("bill_id"))
        'TODO. consider width =25
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("bill_date", "BILLING MONTH", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("bill_generate_date", "STATEMENT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("amount_due", "PRINCIPAL AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("penalty_amt", "PENALTY AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("status", "STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("adjustment", "ADJUSTMENT", New DecimalCellStyle(2), True))

    End Sub
End Class


