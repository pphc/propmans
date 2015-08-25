Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class CustomerAccountsGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        'Me.AddColumn(New TextboxColumn("MEMBER_ID"))
        Me.AddColumn(New TextboxColumn("", "UNIT NUMBER"))
        Me.AddColumn(New TextboxColumn("", "UNIT AREA"))
        Me.AddColumn(New TextboxColumn("", "UNIT CLASS"))
        Me.AddColumn(New TextboxColumn("", "ACCOUNT STATUS"))



    End Sub

End Class
