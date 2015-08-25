Imports PROPMANS.BASE_MOD.GridCellStyle
Imports PROPMANS.BASE_MOD.GridColumns

<CLSCompliant(False)>
Public Class DepositSummaryGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("deposit_id"))
        Me.AddColumn(New TextboxColumn("deposit_date", "DEPOSIT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("bank_account_no", "BANK ACCOUNT"))
        Me.AddColumn(New TextboxColumn("proj_bank_name", "BANK NAME"))
        Me.AddColumn(New TextboxColumn("deposit_type", "DEPOSIT TYPE"))
        Me.AddColumn(New TextboxColumn("deposit_total_amt", "TOTAL AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("trans_count", "O.R COUNT", New DecimalCellStyle(2)))
    End Sub
End Class
