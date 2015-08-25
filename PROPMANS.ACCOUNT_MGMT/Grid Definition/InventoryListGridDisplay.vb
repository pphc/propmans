Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class InventoryListGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("UNIT_ID"))
        Me.AddColumn(New TextboxColumn("UNIT_NUMBER", "UNIT NUMBER"))
        Me.AddColumn(New TextboxColumn("UNIT_DESCRIPTION", "UNIT  TYPE"))
        Me.AddColumn(New TextboxColumn("UNIT_AREA", "UNIT AREA", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("UNIT_SUBCLASS", "UNIT CLASS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("CUSTOMER_NAME", "UNIT OWNER"))
        Me.AddColumn(New TextboxColumn("SALE_STATUS", "UNIT SALE STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("OCCUPANCY_STATUS", "OCCUPANCY STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("OCCUPANT", "OCCUPANT", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub

End Class
