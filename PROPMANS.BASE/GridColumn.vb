Imports System.Windows.Forms
Imports ComponentFactory.Krypton.Toolkit

Namespace GridColumns

    Public Interface IGridColumnDisplay
        Sub SetColumnDisplay()
    End Interface

    Public MustInherit Class GridColumnBase
        Implements IGridColumnDisplay

        Public grid As KryptonDataGridView
        Public MustOverride Sub SetColumnDisplay() Implements IGridColumnDisplay.SetColumnDisplay

        Protected Sub AddColumn(ByVal gridColumn As DataGridViewColumn)
            grid.Columns.Add(gridColumn)
        End Sub
    End Class


    Public Class TextboxColumn
        Inherits DataGridViewTextBoxColumn

        ''' <summary>
        ''' Invisible Column
        ''' </summary>
        ''' <param name="dbColumnName">database column</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal dbColumnName As String)
            Me.DataPropertyName = dbColumnName
            Me.Name = dbColumnName
            Me.Visible = False

            Me.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dbColumnName">database column</param>
        ''' <param name="columnHeaderName">column header display text</param>
        ''' <param name="cellStyle"><see>PROPMANS.BASE.GridCellStyle</see></param>
        ''' <param name="readOnly">data is not editable</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal dbColumnName As String, _
                       ByVal columnHeaderName As String, _
                       Optional ByVal cellStyle As DataGridViewCellStyle = Nothing, _
                       Optional ByVal [readOnly] As Boolean = False _
                       )

            Me.DataPropertyName = dbColumnName
            Me.Name = dbColumnName
            Me.HeaderText = columnHeaderName

            Me.Visible = True

            Me.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            If cellStyle Is Nothing Then
                Me.DefaultCellStyle = New GridCellStyle.DefaultCellStyle()
            Else
                Me.DefaultCellStyle = cellStyle
            End If

            Me.ReadOnly = [readOnly]
        End Sub

    End Class

    Public Class CheckBoxColumn
        Inherits DataGridViewCheckBoxColumn

        Public Sub New(ByVal dbColumnName As String, _
                         ByVal columnHeaderName As String, _
                         Optional ByVal [readOnly] As Boolean = False _
                         )

            Me.DataPropertyName = dbColumnName
            Me.Name = dbColumnName
            Me.HeaderText = columnHeaderName

            Me.Visible = True


            Me.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Me.ReadOnly = [readOnly]

        End Sub

        Public Sub New(ByVal dbColumnName As String, _
                 ByVal columnHeaderName As String, _
                 ByVal trueValue As String, _
                 ByVal falsevalue As String, _
                 Optional ByVal [readOnly] As Boolean = False _
                 )

            Me.DataPropertyName = dbColumnName
            Me.Name = dbColumnName
            Me.HeaderText = columnHeaderName

            Me.Visible = True

            Me.TrueValue = trueValue
            Me.FalseValue = falsevalue

            Me.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Me.ReadOnly = [readOnly]

        End Sub
    End Class

    Public Class ComboBoxColumn
        Inherits DataGridViewComboBoxColumn

        Public Sub New(ByVal ColumnName As String, _
                         ByVal columnHeaderName As String, _
                         ByVal source As IList, _
                         ByVal sourceType As Type, _
                         Optional ByVal [readOnly] As Boolean = False _
                         )
            Me.Name = ColumnName
            Me.HeaderText = columnHeaderName

            Me.DisplayMember = "value"
            Me.ValueMember = "key"
            Me.ValueType = GetType(Type)
            Me.DataSource = DataSource

            Me.Visible = True

            Me.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            Me.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Me.ReadOnly = [readOnly]

        End Sub
    End Class

End Namespace

