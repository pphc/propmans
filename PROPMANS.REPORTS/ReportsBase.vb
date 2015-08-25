Imports CrystalDecisions.CrystalReports.Engine

Imports BCL.Common
Imports System.IO
Imports System.Data
Imports System.Drawing.Imaging


Public MustInherit Class ReportBase
    Implements IDisposable

    Private CompanyLogoFileName As String = "companylogo.jpg"

    Private _reportDoc As ReportDocument
    Public Property ReportDoc() As ReportDocument
        Get
            Return _reportDoc
        End Get
        Set(ByVal value As ReportDocument)
            _reportDoc = value
        End Set
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property Defaults() As ProjectParameter
        Get
            Return GlobalReference.ProjectParameters
        End Get
    End Property

    Public Overridable ReadOnly Property InputNeeded() As Boolean
        Get
            Return False
        End Get
    End Property

    Public MustOverride ReadOnly Property ReportName() As String


    Protected Sub New()

    End Sub

    Public Overridable Sub LoadReport()
        BindItems()
    End Sub

    Public MustOverride Sub BindItems()

    Private disposedValue As Boolean = False        ' To detect redundant calls

    Public Function LoadCompanyLogo() As ImageDataSet.CompanyLogoDataTable

        Dim bm As New Bitmap(Application.StartupPath & "\" & CompanyLogoFileName)


        Using mstream As New MemoryStream
            bm.Save(mstream, ImageFormat.Jpeg)
            Using dtImg As New ImageDataSet.CompanyLogoDataTable
                Dim dr As ImageDataSet.CompanyLogoRow = dtImg.NewCompanyLogoRow
                dr.Image = mstream.ToArray
                dtImg.AddCompanyLogoRow(dr)
                dtImg.AcceptChanges()
                Return dtImg
            End Using
        End Using

    End Function


    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If Not ReportDoc Is Nothing Then
                    ReportDoc.Dispose()
                End If
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



