Imports DALC
Imports System.Collections.Specialized

Namespace Common
    Public Class ProjectParameter

        Private _namevalue As New NameValueCollection

        Public ReadOnly Property Namevalue As NameValueCollection
            Get
                Return _namevalue
            End Get
        End Property

        Public ReadOnly Property SiteCode As String
            Get
                Return Namevalue("SITE_CODE")
            End Get
        End Property


        Public ReadOnly Property SiteFinanceCode As String
            Get
                Return Namevalue("SITE_FIN_CODE")
            End Get
        End Property


        Public ReadOnly Property SiteName As String
            Get
                Return Namevalue("SITE_NAME")
            End Get
        End Property

        Public ReadOnly Property SiteLegalName As String
            Get
                Return Namevalue("SITE_LEGAL_NAME")
            End Get
        End Property

        Public ReadOnly Property SiteAddress As String
            Get
                Return Namevalue("SITE_ADDRESS")
            End Get
        End Property

        Public ReadOnly Property SiteOfficeLocation As String
            Get
                Return Namevalue("SITE_OFFICE_LOC")
            End Get

        End Property

        Public ReadOnly Property SiteContactNos As String
            Get
                Return Namevalue("SITE_CONTACT_NOS")
            End Get
        End Property

        Public ReadOnly Property SiteEmailAddress As String
            Get
                Return Namevalue("SITE_EMAIL_ADDRESS")
            End Get
        End Property

        Public ReadOnly Property SitePropertyAdmin As String
            Get
                Return Namevalue("SITE_PROP_ADMIN")
            End Get
        End Property

        Public ReadOnly Property SiteDeveloperName As String
            Get
                Return Namevalue("SITE_DEVELOPER")
            End Get
        End Property

        Public ReadOnly Property QBDepositoryAccount As String
            Get
                Return Namevalue("QB_DEPOSITORY_ACNT")
            End Get
        End Property

        Public ReadOnly Property QBDefferedOutputVAT As String
            Get
                Return Namevalue("QB_DEF_OUTPUT_VAT")
            End Get
        End Property

        Public ReadOnly Property QBOutputVAT As String
            Get
                Return Namevalue("QB_OUTPUT_VAT")
            End Get
        End Property

        Public ReadOnly Property QBPaymentsTag As Boolean
            Get
                Return Namevalue("QB_PAYMENTS_TAG") = "Y"
            End Get
        End Property

        Public ReadOnly Property MainSchema As String
            Get
                Return Namevalue("MAIN_SCHEMA")
            End Get
        End Property



        Public Sub New()

            Dim query = "SELECT PARAMETER_NAME,PARAMETER_VALUE " & _
                        "FROM PROJECT_PARAMETER"

            For Each rw As DataRow In OraDBHelper2.GetResultSet(query).Rows
                _namevalue.Add(rw("parameter_name").ToString, rw("parameter_value").ToString)
            Next


        End Sub

    End Class
End Namespace


