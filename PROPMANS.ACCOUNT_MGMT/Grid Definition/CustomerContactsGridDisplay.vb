Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class CustomerContactsGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("CONTACT_ID"))
        Me.AddColumn(New TextboxColumn("CONTACT_TYPE", "CONTACT TYPE"))
        Me.AddColumn(New TextboxColumn("CONTACT_LOC", "CONTACT LOCATION"))
        Me.AddColumn(New TextboxColumn("DETAILS", "CONTACT DETAILS", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("ACTIVE", "ACTIVE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub
End Class
