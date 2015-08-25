Imports ComponentFactory.Krypton.Toolkit
Imports System.Windows.Forms
Imports PROPMANS.BASE_MOD.GridColumns

Public Class GridHelper
    Public Shared SourceGrid As KryptonDataGridView

    Public Shared Sub SetGridDisplay(ByRef grid As KryptonDataGridView, ByVal columnDisplay As GridColumnBase)
        SourceGrid = grid
        InitializeGrid()
        columnDisplay.grid = grid
        columnDisplay.SetColumnDisplay()

    End Sub

    Private Shared Sub InitializeGrid()
        With SourceGrid
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridStyles.Style = DataGridViewStyle.Sheet
            .Dock = DockStyle.Fill
            .AutoGenerateColumns = False
        End With

    End Sub

    Public Shared ReadOnly Property CurrentCellValue(ByVal columnName As String) As Object
        Get
            Return SourceGrid.CurrentRow.Cells(columnName).Value
        End Get
    End Property

    Public Shared ReadOnly Property RowCount()
        Get
            Return SourceGrid.RowCount
        End Get
    End Property

End Class
