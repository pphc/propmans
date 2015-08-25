Imports PROPMANS.BASE_MOD.GridCellStyle
Imports PROPMANS.BASE_MOD.GridColumns

Public Class CustomerOnlyLookupGridDisplay
    Inherits GridColumnBase


    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("cust_id"))
        Me.AddColumn(New TextboxColumn("last_name", "LAST NAME"))
        Me.AddColumn(New TextboxColumn("first_name", "FIRST NAME"))
        Me.AddColumn(New TextboxColumn("middle_name", "MIDDLE NAME"))
    End Sub
End Class


