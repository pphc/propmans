Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class AccountHouseMemberGridDisplay

    Inherits GridColumnBase

    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("MEMBER_ID"))
        Me.AddColumn(New TextboxColumn("HOUSEHOLD_NAME", "NAME"))
        Me.AddColumn(New TextboxColumn("OWNER_RELATION", "RELATION"))
        Me.AddColumn(New TextboxColumn("BIRTH_DATE", "BIRTH DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("OCCUPATION", "OCCUPATION"))
        Me.AddColumn(New TextboxColumn("MOVE_IN_DATE", "MOVE IN DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("MOVE_OUT_DATE", "MOVE OUT DATE", New ShortDateCellStyle))

    End Sub

End Class
