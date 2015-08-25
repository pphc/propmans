Imports PROPMANS.BASE_MOD.GridCellStyle
Imports PROPMANS.BASE_MOD.GridColumns

Public Class UserListGridDisplay
    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("user_id", "USER ID"))
        Me.AddColumn(New TextboxColumn("user_fullname", "USER FULL NAME"))
        Me.AddColumn(New TextboxColumn("user_position", "USER POSITION"))
        Me.AddColumn(New TextboxColumn("company", "DIVISION"))
        Me.AddColumn(New TextboxColumn("user_group", "USER GROUP"))
        Me.AddColumn(New CheckBoxColumn("active", "ACTIVE", "Y", "N", True))
    End Sub
End Class
