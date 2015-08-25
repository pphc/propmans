Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class CustomerUnitsGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("ACCOUNT_ID"))
        Me.AddColumn(New TextboxColumn("CUST_UNIT_NO", "UNIT NUMBER", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("UNIT_AREA", "UNIT AREA", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("ACCOUNT_CLASS", "UNIT CLASS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("ACCOUNT_STATUS", "ACCOUNT STATUS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub

End Class
