Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class LeaseContractGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("lease_id"))
        Me.AddColumn(New TextboxColumn("contract_no", "CONTRACT #", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("unit_number", "UNIT NUMBER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("unit_type", "UNIT TYPE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("tenant_name", "TENANT", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("contract_start", "LEASE START", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("contract_end", "LEASE END", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("rent_amt", "RENT AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("contract_status", "STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("approval_status", "APPROVAL STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("created_by", "CREATED BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("created_on", "CREATED ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("updated_by", "UPDATED BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("updated_on", "UPDATED ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub

End Class
