Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.RentalMgmt
Imports BCL.Common

Public Class KeyTenantTurnOverReport
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

    Private _tenantName As String

    Public Property TenantName() As String
        Get
            Return _tenantName
        End Get
        Set(ByVal Value As String)
            _tenantName = Value
        End Set
    End Property

    Private _turnOverDate As Date
    Public Property TurnOverDate() As Date
        Get
            Return _turnOverDate
        End Get
        Set(ByVal value As Date)
            _turnOverDate = value
        End Set
    End Property

    Private _leaseId As String
    Public Sub New(ByVal leaseId As String)
        _leaseId = leaseId
    End Sub

#End Region

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "KEY TENANT TURN OVER FORM"
        End Get
    End Property





    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Public Overrides Sub BindItems()
        ReportDoc = New rptTenantKeyTurnOverForm
        With ReportDoc.DataDefinition

            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"

            .FormulaFields("UserFullName").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"

            .FormulaFields("TenantName").Text = "'" & TenantName & "'"

            .FormulaFields("TurnOverDate").Text = "'" & TurnOverDate.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("UnitNumber").Text = "'" & UnitNumber & "'"








        End With
    End Sub

    Public Sub LoadData()
        ''fetch record by id

        Using params As New OraParameter
            params.AddItem("leaseId", _leaseId, Oracle.DataAccess.Client.OracleDbType.Int32)

            Dim query As String = "SELECT accounts.getcustomerfullname_fml ((SELECT CUST_ID                       " & _
                                  "                                     FROM CUSTOMERS                            " & _
                                  "                                     WHERE CUST_ID = a.CUST_ID)) TENANT_NAME   " & _
                                  "    , (SELECT CUST_UNIT_NO                                                     " & _
                                  "       FROM CUSTOMER_ACCOUNTS                                                  " & _
                                  "       WHERE ACCOUNT_ID IN (SELECT ACCOUNT_ID                                  " & _
                                  "                            FROM RM_AGREEMENT                                  " & _
                                  "                            WHERE AGREEMENT_ID = a.AGREEMENT_ID)) UNIT_NUMBER  " & _
                                  "   , (SELECT APPLICATION_DATE                                                  " & _
                                  "      FROM RM_AGREEMENT                                                        " & _
                                  "      WHERE AGREEMENT_ID = a.AGREEMENT_ID) APPLICATION_DATE                    " & _
                                  "FROM RM_LEASE_CONTRACT a                                                       " & _
                                  "WHERE LEASE_ID = :leaseId                                                      "


            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)


                TenantName = .Rows(0)("TENANT_NAME").ToString

                UnitNumber = .Rows(0)("UNIT_NUMBER").ToString

                TurnOverDate = Date.Parse(.Rows(0)("APPLICATION_DATE"))




            End With

        End Using


    End Sub

End Class
