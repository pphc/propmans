'*****************************************************************
'Property Management System ver. 2.0
'
'Module: Billings Preview
'Module Description:preview billing report
'Date Created: 3/2/2010
'Date Last Modified:
'
'Change Log:
'
'*****************************************************************

Imports ComponentFactory.Krypton
Imports BCL
Imports BCL.Entities
Imports CrystalDecisions.CrystalReports.Engine

Public Class ReportPreviewForm

    Private billid As String
    Private billtype As CommonReportType
    Private _billingNotes As String ' ENCAPSULATE FIELD BY CODEIT.RIGHT

    Public Property BillingNotes() As String
        Get
            Return _billingNotes
        End Get
        Set(ByVal Value As String)
            _billingNotes = Value
        End Set
    End Property
    Private bAttachReportOnly As Boolean ' = False
    Private rep As ReportDocument


#Region "Form and Control Events"
    Public Sub New(ByVal billID As String, ByVal billType As CommonReportType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        billID = billID
        billType = billType
    End Sub

    Public Sub New(ByVal report As ReportDocument)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bAttachReportOnly = True
        rep = report
    End Sub

    Private Sub BillingsPreviewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bAttachReportOnly Then
            CrystalReportViewer.DisplayGroupTree = False

            CrystalReportViewer.ReportSource = rep
        Else
            UISetup()
        End If

    End Sub

    Private Sub CrystalReportViewer_Error(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ExceptionEventArgs) Handles CrystalReportViewer.Error
        e.Handled = False
    End Sub

#End Region

#Region "Local Procedures"

    Private Sub UISetup()
        'Dim soa As ReportStore = New CommonReportStore

        'Dim rep As CommonReport
        'Select Case billtype
        '    Case CommonReportType.CondoDues
        '        rep = soa.loadReport("condodues")
        '    Case CommonReportType.ParkingDues
        '        rep = soa.loadReport("parkingdues")
        '    Case CommonReportType.UnitRental
        '        rep = soa.loadReport("unitrental")
        '    Case CommonReportType.ParkingRental
        '        rep = soa.loadReport("parkingrental")
        '    Case CommonReportType.Water
        '        rep = soa.loadReport("waterbill")
        '    Case Else
        '        rep = Nothing
        'End Select

        'rep.reportPath = Application.StartupPath.Replace("bin\Debug", "").ToString & "\Reports\"
        'rep.BillID = billid
        'rep.Notes = BillingNotes
        'rep.LoadReport()
        'CrystalReportViewer.DisplayGroupTree = False

        'CrystalReportViewer.ReportSource = rep.reportDoc

    End Sub
#End Region

  
End Class
