
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports DALC
Imports BCL.Common
Imports BCL.Checks

Public Class CheckDetails
    Public Property ItemNumber As Integer
    Public Property CheckBank As String
    Public Property CheckNumber As String
    Public Property CheckDate As Date
    Public Property CheckAmount As Decimal

End Class


Public Class CheckARReport
    Inherits ReportBase

    Public Property CheckDetails As List(Of Check)
    Public Property CheckDistribution As List(Of CheckAmountDistribution)

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "CKECKS ACKNOWLEDGEMENT RECEIPT"
        End Get
    End Property

    Public Property CustomerAccountName As String
    Public Property CustomerName As String
    Public Property ARNumber As String
    Public Property ARDate As Date
    Public Property PaymentFor As String
    Public Property Custodian As CheckCustodian


    Public Sub New()

    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()
        Try

            Dim chkinfo As New List(Of CheckDetails)

            Dim cnt As Integer = 1
            For Each chk As Check In CheckDetails
                chkinfo.Add(New CheckDetails With {.ItemNumber = cnt,
                                                     .CheckNumber = chk.CheckNumber,
                                                     .CheckBank = String.Format("{0} - {1}", chk.Bank, chk.Branch),
                                                     .CheckDate = chk.CheckDate,
                                                     .CheckAmount = chk.CheckAmount}
                                                     )
                cnt += 1
            Next

            For Each chk As CheckAmountDistribution In CheckDistribution
                CustomerAccountName = chk.AccountName.UnitNumber & "-" & chk.AccountName.AccountName
                CustomerName = chk.AccountName.AccountName
            Next


            ReportDoc = New rptCheckAR
            ReportDoc.SetDataSource(chkinfo)
            'Dim x As New ExportOptions
            'x.ExportFormatType = ExportFormatType.PortableDocFormat

            'ReportDoc.Export(x)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub


    Public Overrides Sub BindItems()

        With ReportDoc.DataDefinition
            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteLegalName & "'"
            .FormulaFields("ReceivedBy").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"

            .FormulaFields("CustomerAccountName").Text = "'" & CustomerAccountName & "'"
            .FormulaFields("PaymentFor").Text = "'" & PaymentFor & "'"
            .FormulaFields("ARNumber").Text = "'" & ARNumber & "'"
            .FormulaFields("ARDate").Text = "'" & ARDate.ToString("MMMM dd, yyyy") & "'"
            If Custodian = BCL.Checks.CheckCustodian.HeadOffice Then
                .FormulaFields("CheckCustodian").Text = "'" & Defaults.SiteDeveloperName & "'"
            Else
                .FormulaFields("CheckCustodian").Text = "'" & Defaults.SiteLegalName & "'"
            End If

            .FormulaFields("CustomerName").Text = "'" & CustomerName & "'"



        End With
    End Sub
End Class
