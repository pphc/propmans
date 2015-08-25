'***********************************************************************
' Assembly         : BCL
' Author           : Mark Angelo Rivo
' Created          : 09-24-2010
'
' Last Modified By : Mark Angelo Rivo
' Last Modified On : 09-27-2010
' Description      : 
'
' Copyright        : (c) Phinma Properties. All rights reserved.
'***********************************************************************
Imports System.IO
Imports System.Text


Namespace Utils
    ''' <summary>
    ''' Produces Excel file without using Excel
    ''' </summary>
    Public Class ExcelWriter
        Implements IDisposable

        Private stream As Stream
        Private writer As BinaryWriter

        Private clBegin As UShort() = {&H809, 8, 0, &H10, 0, 0}

        Private clEnd As UShort() = {&HA, 0}


        Private Sub WriteUshortArray(ByVal value As UShort())
            For i As Integer = 0 To value.Length - 1
                writer.Write(value(i))
            Next
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ExcelWriter"/> class.
        ''' </summary>
        ''' <param name="stream">The stream.</param>
        Public Sub New(ByVal stream As Stream)
            Me.stream = stream
            writer = New BinaryWriter(stream)
        End Sub

        ''' <summary>
        ''' Writes the text cell value.
        ''' </summary>
        ''' <param name="row">The row.</param>
        ''' <param name="col">The col.</param>
        ''' <param name="value">The string value.</param>
        Public Sub WriteCell(ByVal row As Integer, ByVal col As Integer, ByVal value As String)
            Dim clData As UShort() = {&H204, 0, 0, 0, 0, 0}
            Dim iLen As Integer = value.Length

            'Use Latin 9(ISO) encoding to display  Ñ character
            Dim plainText As Byte() = Encoding.GetEncoding(28605).GetBytes(value)


            clData(1) = CUShort(8 + iLen)
            clData(2) = CUShort(row)
            clData(3) = CUShort(col)
            clData(5) = CUShort(iLen)
            WriteUshortArray(clData)
            writer.Write(plainText, 0, plainText.Length)
        End Sub

        ''' <summary>
        ''' Writes the integer cell value.
        ''' </summary>
        ''' <param name="row">The row number.</param>
        ''' <param name="col">The column number.</param>
        ''' <param name="value">The value.</param>
        Public Sub WriteCell(ByVal row As Integer, ByVal col As Integer, ByVal value As Integer)
            Dim clData As UShort() = {&H27E, 10, 0, 0, 0}
            clData(2) = CUShort(row)
            clData(3) = CUShort(col)
            WriteUshortArray(clData)
            Dim iValue As Integer = (value << 2) Or 2
            writer.Write(iValue)
        End Sub

        ''' <summary>
        ''' Writes the double cell value.
        ''' </summary>
        ''' <param name="row">The row number.</param>
        ''' <param name="col">The column number.</param>
        ''' <param name="value">The value.</param>
        Public Sub WriteCell(ByVal row As Integer, ByVal col As Integer, ByVal value As Double)
            Dim clData As UShort() = {&H203, 14, 0, 0, 0}
            clData(2) = CUShort(row)
            clData(3) = CUShort(col)
            WriteUshortArray(clData)
            writer.Write(value)
        End Sub

        ''' <summary>
        ''' Writes the empty cell.
        ''' </summary>
        ''' <param name="row">The row number.</param>
        ''' <param name="col">The column number.</param>
        Public Sub WriteCell(ByVal row As Integer, ByVal col As Integer)
            Dim clData As UShort() = {&H201, 6, 0, 0, &H17}
            clData(2) = CUShort(row)
            clData(3) = CUShort(col)
            WriteUshortArray(clData)
        End Sub

        ''' <summary>
        ''' Must be called once for creating XLS file header
        ''' </summary>
        Public Sub BeginWrite()
            WriteUshortArray(clBegin)
        End Sub

        Public Sub WriteSheetName(ByVal name As String)
            Dim clWorkSheetName As UShort() = {&H85, 0, &H809, 0, 0, 0}

            Dim iLen As Integer = name.Length

            'Use Latin 9(ISO) encoding to display  Ñ character
            Dim plainText As Byte() = Encoding.GetEncoding(28605).GetBytes(name)

            clWorkSheetName(5) = CUShort(iLen)

            WriteUshortArray(clWorkSheetName)
            writer.Write(plainText, 0, plainText.Length)

        End Sub

        ''' <summary>
        ''' Ends the writing operation, but do not close the stream
        ''' </summary>
        Public Sub EndWrite()
            WriteUshortArray(clEnd)
            writer.Flush()
        End Sub

        Private disposedValue As Boolean ' = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    stream.Dispose()
                    writer.Close()
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

End Namespace
