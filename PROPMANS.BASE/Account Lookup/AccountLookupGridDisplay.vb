Imports PROPMANS.BASE_MOD.GridCellStyle
Imports PROPMANS.BASE_MOD.GridColumns

Public Class AccountLookupGridDisplay
    Inherits GridColumnBase


    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("account_id"))
        Me.AddColumn(New TextboxColumn("cust_id"))
        Me.AddColumn(New TextboxColumn("lease_id"))
        Me.AddColumn(New TextboxColumn("unit_number", "UNIT NO."))
        'TODO. consider unbounded text box column without data property name
        Me.AddColumn(New TextboxColumn("customername", "CUSTOMER NAME"))
        Me.AddColumn(New TextboxColumn("first_name"))
        Me.AddColumn(New TextboxColumn("middle_name"))
        Me.AddColumn(New TextboxColumn("last_name"))
        Me.AddColumn(New TextboxColumn("unit_class", "UNIT CLASS", New DefaultCellStyle(Windows.Forms.DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("cust_type", "CUST TYPE", New DefaultCellStyle(Windows.Forms.DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("account_status", "ACCOUNT STATUS", New DefaultCellStyle(Windows.Forms.DataGridViewContentAlignment.MiddleCenter)))
    End Sub
End Class




