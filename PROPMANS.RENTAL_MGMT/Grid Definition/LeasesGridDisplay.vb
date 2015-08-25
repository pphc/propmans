Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class LeasesGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("lease_id"))
        Me.AddColumn(New TextboxColumn("contract_no", "CONTRACT #", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("tenant_name", "TENANT NAME", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("contract_start", "LEASE START", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("contract_end", "LEASE END", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("rent_amt", "RENT AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("contract_status", "CONTRACT STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
    End Sub

End Class
