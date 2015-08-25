Imports PROPMANS.BASE_MOD.GridColumns
Imports PROPMANS.BASE_MOD.GridCellStyle

Public Class ActivitiesGridDisplay

    Inherits GridColumnBase



    Public Overrides Sub SetColumnDisplay()

        Me.AddColumn(New TextboxColumn("ACTIVITY_ID"))
        Me.AddColumn(New TextboxColumn("ACTIVITY_TYPE_ID"))
        Me.AddColumn(New TextboxColumn("ACTIVITY_DATE", "DATE", New ShortDateCellStyle))
        Me.AddColumn(New TextboxColumn("ACTIVITY_NAME", "ACTIVITY TYPE", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("NOTES", "NOTES", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("CREATED_BY", "CREATED BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("CREATED_ON", "CREATED ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("UPDATED_BY", "UPDATE BY", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))
        Me.AddColumn(New TextboxColumn("UPDATED_ON", "UPDATE ON", New DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter)))

    End Sub

End Class
