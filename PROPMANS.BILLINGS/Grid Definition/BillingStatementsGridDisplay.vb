Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class BillingStatementsGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New CheckBoxColumn("select", ""))
        Me.AddColumn(New TextboxColumn("bill_id"))
        Me.AddColumn(New TextboxColumn("account_id"))
        Me.AddColumn(New TextboxColumn("unit_number", "UNIT NUMBER"))
        Me.AddColumn(New TextboxColumn("cust_name", "CUSTOMER NAME"))
        Me.AddColumn(New TextboxColumn("previous_balance", "PREVIOUS", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("amount_due", "CURRENT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("penalty_amt", "PENALTY", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("advances", "ADVANCES", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("bill_date"))
        Me.AddColumn(New TextboxColumn("bill_generate_date"))
        Me.AddColumn(New TextboxColumn("bill_due_date"))
        Me.AddColumn(New TextboxColumn("or_number"))
        Me.AddColumn(New TextboxColumn("payment_date"))
        Me.AddColumn(New TextboxColumn("amount"))
    End Sub

End Class
