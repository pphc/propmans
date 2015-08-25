Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class VehiclesGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        'Me.AddColumn(New TextboxColumn("AGREEMENT_ID"))
        Me.AddColumn(New TextboxColumn("vehicle_id"))
        Me.AddColumn(New TextboxColumn("plate_no", "PLATE NO", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("make", "MAKE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("model", "MODEL/SERIES", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("color", "COLOR", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("status", "ACTIVE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("CREATED_BY", "CREATED BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("CREATED_ON", "CREATED ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("updated_by", "UPDATED BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("updated_on", "UPDATED ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub

End Class
