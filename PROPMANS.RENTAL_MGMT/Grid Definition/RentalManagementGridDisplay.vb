Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class RentalManagementAgreementGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("AGREEMENT_ID"))
        'Me.AddColumn(New TextboxColumn("ACCOUNT_ID"))
        Me.AddColumn(New TextboxColumn("CONTRACT_NO", "CONTRACT #", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("UNIT_NUMBER", "UNIT NUMBER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("UNIT_OWNER", "UNIT OWNER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("UNIT_CLASS", "UNIT TYPE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("CONTRACT_START", "START", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("CONTRACT_END", "END", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("RENT_AMT", "RENT AMOUNT", New DecimalCellStyle(2)))
        Me.AddColumn(New TextboxColumn("CONTRACT_STATUS", "CONTRACT STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("approval_status", "APPROVAL STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("occupancy_status", "OCCUPANCY STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("created_by", "CREATED BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("created_on", "CREATED ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("updated_by", "UPDATED BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("updated_on", "UPDATED ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub

End Class
