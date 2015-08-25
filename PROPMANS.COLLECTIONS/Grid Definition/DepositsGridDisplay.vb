Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class DepositsGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("deposit_id", "DEPOSIT NUMBER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("deposit_date", "DEPOSIT DATE", New ShortDateCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("bank_account_no", "ACCOUNT NO"))
        Me.AddColumn(New TextboxColumn("proj_bank_name", "BANK NAME"))
        Me.AddColumn(New TextboxColumn("deposit_type", "DEPOSIT TYPE"))
        Me.AddColumn(New TextboxColumn("deposit_total_amt", "AMOUNT DEPOSITED", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("trans_count", "NO OF RECEIPTS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
    End Sub
End Class
