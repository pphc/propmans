Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.RentalMgmt

Public Class RentalManagementAgreementReport
    Inherits ReportBase


#Region "PROPERTIES"

    Private _unitNumber As String

    Public Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
        Set(ByVal Value As String)
            _unitNumber = Value
        End Set
    End Property

    Private _contractNumber As String

    Public Property ContractNumber() As String
        Get
            Return _contractNumber
        End Get
        Set(ByVal Value As String)
            _contractNumber = Value
        End Set
    End Property

    Private _unitOwnerName As String

    Public Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
        Set(ByVal Value As String)
            _unitOwnerName = Value
        End Set
    End Property

    Private _residenceAddress As String

    Public Property ResidenceAddress() As String
        Get
            Return _residenceAddress
        End Get
        Set(ByVal Value As String)
            _residenceAddress = Value
        End Set
    End Property


    Private _agreementDate As Date
    Public Property AgreementDate() As Date
        Get
            Return _agreementDate
        End Get
        Set(ByVal value As Date)
            _agreementDate = value
        End Set
    End Property


    Private _contractStart As Date
    Public Property ContractStart() As Date
        Get
            Return _contractStart
        End Get
        Set(ByVal value As Date)
            _contractStart = value
        End Set
    End Property


    Private _contractEnd As Date
    Public Property ContractEnd() As Date
        Get
            Return _contractEnd
        End Get
        Set(ByVal value As Date)
            _contractEnd = value
        End Set
    End Property


    Private _numberOfMonths As String

    Public Property NumberOfMonths() As String
        Get
            Return _numberOfMonths
        End Get
        Set(ByVal value As String)
            _numberOfMonths = value
        End Set
    End Property

    Private _agreementID As String


#End Region

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "RENTAL MANAGEMENT AGREEMENT"
        End Get
    End Property

    Public Sub New(ByVal agrementID As String)
        _agreementID = agrementID
    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Public Overrides Sub BindItems()


        ReportDoc = New rptRentalManagementAgreementForm
        With ReportDoc.DataDefinition
            Dim blank As String = "_________________________________________________________"

            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"

            .FormulaFields("AgreementDate").Text = "'" & AgreementDate.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("UnitOwnerName").Text = "'" & UnitOwnerName & "'"

            If String.IsNullOrEmpty(ResidenceAddress) Then
                .FormulaFields("ResidenceAddress").Text = "'" & blank & "'"
            Else
                .FormulaFields("ResidenceAddress").Text = "'" & ResidenceAddress & "'"
            End If

            .FormulaFields("ContractNumber").Text = "'" & ContractNumber & "'"

            .FormulaFields("UnitNumber").Text = "'" & UnitNumber & "'"

            .FormulaFields("ContractStart").Text = "'" & ContractStart.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("ContractEnd").Text = "'" & ContractEnd.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("Term").Text = "'" & NumberOfMonths & "'"
        End With

    End Sub

    Public Sub LoadData()
        ''fetch record by id

        Using params As New OraParameter
            params.AddItem("agreementId", _agreementID, Oracle.DataAccess.Client.OracleDbType.Int32)

            Dim query As String = "SELECT APPLICATION_DATE,                                                                          " & _
                                  "(SELECT DETAILS " & _
                                  "FROM AM_CUSTOMER_CONTACT " & _
                                  " where cust_id = (select acct_cust_id from customer_accounts where account_id = a.account_id) " & _
                                  " and contact_type = 'ADDRESS' " & _
                                  " AND preffered ='Y') ADDRESS" & _
                                  "     , (SELECT PARAMETER_VALUE||'-'|| LPAD(a.AGREEMENT_ID,6,'0')                                 " & _
                                  "        FROM PROJECT_PARAMETER                                                                   " & _
                                  "        WHERE PARAMETER_NAME = 'SITE_CODE')CONTRACT_#                                            " & _
                                  "     , accounts.getcustomerfullname_fml ((SELECT CUST_ID                                         " & _
                                  "								   FROM CUSTOMERS                                                   " & _
                                  "								   WHERE CUST_ID IN (SELECT ACCT_CUST_ID                            " & _
                                  "													 FROM CUSTOMER_ACCOUNTS                         " & _
                                  "													 WHERE ACCOUNT_ID = a.ACCOUNT_ID)))UNIT_OWNER   " & _
                                  "     , (SELECT CUST_UNIT_NO                                                                      " & _
                                  "        FROM CUSTOMER_ACCOUNTS                                                                   " & _
                                  "        WHERE ACCOUNT_ID = a.ACCOUNT_ID) UNIT_NUMBER                                             " & _
                                  "     , CONTRACT_START                                                                            " & _
                                  "     , CONTRACT_END                                                                              " & _
                                  "     , MONTHS_TERM                                                                               " & _
                                  "FROM RM_AGREEMENT a                                                                              " & _
                                  "WHERE a.AGREEMENT_ID = :agreementId                                                              "


            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)

                AgreementDate = Date.Parse(.Rows(0)("APPLICATION_DATE"))

                ResidenceAddress = .Rows(0)("ADDRESS").ToString
                ContractNumber = .Rows(0)("CONTRACT_#").ToString

                UnitOwnerName = .Rows(0)("UNIT_OWNER").ToString

                UnitNumber = .Rows(0)("UNIT_NUMBER").ToString

                ContractStart = Date.Parse(.Rows(0)("CONTRACT_START"))

                ContractEnd = Date.Parse(.Rows(0)("CONTRACT_END"))

                NumberOfMonths = .Rows(0)("MONTHS_TERM").ToString



            End With

        End Using


    End Sub

End Class
