Imports PROPMANS.BASE_MOD.GridCellStyle
Imports PROPMANS.BASE_MOD.GridColumns
Imports BCL

Public Class UserRolesGridDisplay
    Inherits GridColumnBase
    'TODO..
    'Public Sub SetGridDisplay(ByRef dg As KryptonDataGridView) Implements IGridDisplay.SetGridDisplay
    '    dg.Columns.Add(DGColumn.NewTextBoxColumn("module_id", "", , False))
    '    dg.Columns.Add(DGColumn.NewTextBoxColumn("module_name", "MODULE NAME", , True, True, DataGridViewColumnSortMode.NotSortable))
    '    dg.Columns.Add(DGColumn.NewTextBoxColumn("access_type", "", , False))
    '    dg.Columns.Add(DGColumn.NewComboBoxColumn("ac_type", "SELECT ACCESS TYPE", Utils.EnumHelper.ToEnumValueList(GetType(ReferenceList.UserAccessType)), True))
    '    dg.Update()
    'End Sub
    Public Overrides Sub SetColumnDisplay()
        Me.AddColumn(New TextboxColumn("module_id"))
        Me.AddColumn(New TextboxColumn("module_name", "MODULE NAME"))
        Me.AddColumn(New TextboxColumn("access_type"))
        Me.AddColumn(New ComboBoxColumn("ac_type", "ACCESS PRIVELEGE", Utils.EnumHelper.ToEnumValueList(GetType(ReferenceList.UserAccessType)), GetType(ReferenceList.UserAccessType)))
    End Sub
End Class
