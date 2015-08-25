Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class CustomerAddressGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("CONTACT_ID"))
        Me.AddColumn(New TextboxColumn("CONTACT_LOC", "ADDRESS LOCATION"))
        Me.AddColumn(New TextboxColumn("DETAILS", "ADDRESS DETAILS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("ACTIVE", "ACTIVE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("PREFFERED", "PREFFERED", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub

End Class
