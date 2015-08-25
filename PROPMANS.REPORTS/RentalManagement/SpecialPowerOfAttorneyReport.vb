Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.RentalMgmt

Public Class SpecialPowerOfAttorneyReport
    Inherits ReportBase


#Region "PROPERTIES"

    Private _unitOwnerName As String

    Public Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
        Set(ByVal Value As String)
            _unitOwnerName = Value
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

    Private _agreementDate As Date
    Public Property AgreementDate() As Date
        Get
            Return _agreementDate
        End Get
        Set(ByVal value As Date)
            _agreementDate = value
        End Set
    End Property

    Private _agreementID As String



    Private _residenceAddress As String

    Public Property ResidenceAddress() As String
        Get
            Return _residenceAddress
        End Get
        Set(ByVal Value As String)
            _residenceAddress = Value
        End Set
    End Property

    Private _civilStatus As String

    Public Property CivilStatus() As String
        Get
            Return _civilStatus
        End Get
        Set(ByVal Value As String)
            _civilStatus = Value
        End Set
    End Property

    Private _nationality As String

    Public Property Nationality() As String
        Get
            Return _nationality
        End Get
        Set(ByVal Value As String)
            _nationality = Value
        End Set
    End Property



#End Region

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "SPECIAL POWER OF ATTORNEY"
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

        ReportDoc = New rptSpecialPowerOfAttorneyForm
        With ReportDoc.DataDefinition
            Dim blank As String = "_________________________________________________________"

            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"

            .FormulaFields("AgreementDate").Text = "'" & AgreementDate.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("UnitOwnerName").Text = "'" & UnitOwnerName & "'"

            .FormulaFields("ContractNumber").Text = "'" & ContractNumber & "'"

            If String.IsNullOrEmpty(ResidenceAddress) Then
                .FormulaFields("UnitOwnerAddress").Text = "'" & blank & "'"
            Else
                .FormulaFields("UnitOwnerAddress").Text = "'" & ResidenceAddress & "'"
            End If

            If String.IsNullOrEmpty(Nationality) Then
                .FormulaFields("Nationality").Text = "'" & "Filipino" & "'"
            Else
                .FormulaFields("Nationality").Text = "'" & Nationality & "'"
            End If

            If String.IsNullOrEmpty(CivilStatus) Then
                .FormulaFields("CivilStatus").Text = "'" & "married to " & blank & "'"
            Else
                If CivilStatus.Trim.ToUpper = "SINGLE" Then
                    .FormulaFields("CivilStatus").Text = "'" & CivilStatus.ToLower & "'"
                Else
                    .FormulaFields("CivilStatus").Text = "'" & "married to " & blank & "'"
                End If
            End If



        End With
    End Sub

    Public Sub LoadData()
        ''fetch record by id

        Using params As New OraParameter
            params.AddItem("agreementId", _agreementID, Oracle.DataAccess.Client.OracleDbType.Int32)

            Dim query As String = "SELECT APPLICATION_DATE,                                                                                                                     " & _
                                    "                                (SELECT DETAILS                                                                                              " & _
                                    "                                FROM AM_CUSTOMER_CONTACT                                                                                     " & _
                                    "                                 where cust_id = (select acct_cust_id from customer_accounts where account_id = a.account_id)                " & _
                                    "                                 and contact_type = 'ADDRESS'                                                                                " & _
                                    "                                 AND preffered ='Y') ADDRESS,                                                                                " & _
                                    "                                 (SELECT INITCAP(CITIZENSHIP)                                                                                         " & _
                                    "                                FROM CUSTOMERS                                                                                               " & _
                                    "                                 where cust_id = (select acct_cust_id from customer_accounts where account_id = a.account_id))  NATIONALITY, " & _
                                    "                                   (SELECT CUST_MARITAL_STATUS                                                                               " & _
                                    "                                FROM CUSTOMERS                                                                                               " & _
                                    "                                 where cust_id = (select acct_cust_id from customer_accounts where account_id = a.account_id))  CIVIL_STATUS " & _
                                    "                                     , (SELECT PARAMETER_VALUE||'-'|| LPAD(a.AGREEMENT_ID,6,'0')                                             " & _
                                    "                                        FROM PROJECT_PARAMETER                                                                               " & _
                                    "                                        WHERE PARAMETER_NAME = 'SITE_CODE')CONTRACT_#                                                        " & _
                                    "                                     , accounts.getcustomerfullname_fml ((SELECT CUST_ID                                                     " & _
                                    "                                                                   FROM CUSTOMERS                                                            " & _
                                    "                                                                   WHERE CUST_ID IN (SELECT ACCT_CUST_ID                                     " & _
                                    "                                                                                     FROM CUSTOMER_ACCOUNTS                                  " & _
                                    "                                                                                     WHERE ACCOUNT_ID = a.ACCOUNT_ID)))UNIT_OWNER            " & _
                                    "                                                                                                                                             " & _
                                    "                                FROM RM_AGREEMENT a                                                                                          " & _
                                    "                                WHERE a.AGREEMENT_ID = :agreementId                                                                          " & _
                                    "                                                                                                                                             "

            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)

                AgreementDate = Date.Parse(.Rows(0)("APPLICATION_DATE"))

                ContractNumber = .Rows(0)("CONTRACT_#").ToString

                UnitOwnerName = .Rows(0)("UNIT_OWNER").ToString
                ResidenceAddress = .Rows(0)("ADDRESS").ToString
                Nationality = .Rows(0)("NATIONALITY").ToString
                CivilStatus = .Rows(0)("CIVIL_STATUS").ToString

            End With

        End Using


    End Sub

End Class
