Imports System.Windows.Forms

Namespace GridCellStyle

    ''' <summary>
    ''' Numeric Format Cell Style
    ''' </summary>
    ''' 
    ''' <remarks>
    ''' Whole Number Only
    ''' <example>
    '''  1,100,1000
    ''' </example>
    ''' 
    ''' </remarks>
    Public Class NumericCellStyle
        Inherits DataGridViewCellStyle

        Public Sub New(Optional ByVal alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleRight)
            Me.Format = "N0"
            Me.Alignment = alignment
        End Sub
    End Class

    ''' <summary>
    ''' Decimal Format Cell Style
    ''' </summary>
    ''' 
    ''' <remarks>
    ''' Decimal Format Only
    ''' <example>
    '''  1.00,100.00,1000.00
    ''' </example>
    ''' 
    ''' </remarks>
    Public Class DecimalCellStyle
        Inherits DataGridViewCellStyle

        Public Sub New(ByVal decimalPlaces As Integer, Optional ByVal alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleRight)
            Me.Format = "N" & decimalPlaces.ToString
            Me.Alignment = alignment
        End Sub
    End Class




    ''' <summary>
    ''' Short Date Cell Style
    ''' </summary>
    ''' 
    ''' <remarks>
    ''' Short Date Format Only
    ''' <example>
    '''  1/1/1985,11/1/2012
    ''' </example>
    ''' 
    ''' </remarks>
    Public Class ShortDateCellStyle
        Inherits DataGridViewCellStyle

        Public Sub New(Optional ByVal alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleCenter)
            Me.Format = "d"
            Me.Alignment = alignment
        End Sub
    End Class

    ''' <summary>
    ''' Month Year Format Cell Style
    ''' </summary>
    ''' 
    ''' <remarks>
    ''' Month Year
    ''' <example>
    '''  January 2001,December 2012
    ''' </example>
    ''' 
    ''' </remarks>
    Public Class MonthYearDateCellStyle
        Inherits DataGridViewCellStyle

        Public Sub New(Optional ByVal alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft)
            Me.Format = "MMMM yyyy"
            Me.Alignment = alignment
        End Sub
    End Class

    ''' <summary>
    ''' Default Cell Style for Text
    ''' </summary>
    ''' <remarks>Text is left alligned</remarks>
    Public Class DefaultCellStyle
        Inherits DataGridViewCellStyle

        Public Sub New(Optional ByVal alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft)
            Me.Format = "g"
            Me.Alignment = alignment
        End Sub
    End Class
End Namespace
