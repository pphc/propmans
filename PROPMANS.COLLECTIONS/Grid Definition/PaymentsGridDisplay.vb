
Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class PaymentsGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("account_id"))
        Me.AddColumn(New TextboxColumn("cust_unit_no", "UNIT NUMBER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleRight)))
        Me.AddColumn(New TextboxColumn("unit_owner", "UNIT OWNER"))
        Me.AddColumn(New TextboxColumn("unit_type", "UNIT TYPE"))
        Me.AddColumn(New TextboxColumn("move_in_date", "MOVE-IN DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("takeout_date", "TAKE-OUT DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("cd_start_Date", "CONDO DUES START DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("occupant", "OCCUPANT"))
        Me.AddColumn(New TextboxColumn("account_status", "ACCOUNT STATUS"))
        Me.AddColumn(New TextboxColumn("acct_cust_id"))
        Me.AddColumn(New TextboxColumn("cust_lname"))
        Me.AddColumn(New TextboxColumn("cust_fname"))
        Me.AddColumn(New TextboxColumn("cust_unit_sort"))
    End Sub
End Class
