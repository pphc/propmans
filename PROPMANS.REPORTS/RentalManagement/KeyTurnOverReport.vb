Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.RentalMgmt
Imports BCL.Common

Public Class KeyTurnOverReport
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

    Private _unitOwnerName As String

    Public Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
        Set(ByVal Value As String)
            _unitOwnerName = Value
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

    Private _agreementID As String

#End Region

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "KEY TURN OVER FORM"
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
        ReportDoc = New rptKeyTurnOverForm
        With ReportDoc.DataDefinition

            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"

            .FormulaFields("UserFullName").Text = "'" & GlobalReference.CurrentUser.UserFullName & "'"

            .FormulaFields("UnitOwnerName").Text = "'" & UnitOwnerName & "'"

            .FormulaFields("TurnOverDate").Text = "'" & TurnOverDate.ToString("MMMM d, yyyy") & "'"

            .FormulaFields("UnitNumber").Text = "'" & UnitNumber & "'"








        End With
    End Sub

    Public Sub LoadData()
        ''fetch record by id

        Using params As New OraParameter
            params.AddItem("agreementId", _agreementID, Oracle.DataAccess.Client.OracleDbType.Int32)

            Dim query As String = "SELECT accounts.getcustomerfullname_fml ((SELECT CUST_ID                                              " & _
                                  "                                     FROM CUSTOMERS                                                   " & _
                                  "                                     WHERE CUST_ID IN (SELECT ACCT_CUST_ID                            " & _
                                  "                                                       FROM CUSTOMER_ACCOUNTS                         " & _
                                  "                                                       WHERE ACCOUNT_ID = a.ACCOUNT_ID)))UNIT_OWNER   " & _
                                  "    , (SELECT CUST_UNIT_NO                                                                            " & _
                                  "       FROM CUSTOMER_ACCOUNTS                                                                         " & _
                                  "       WHERE ACCOUNT_ID = a.ACCOUNT_ID) UNIT_NUMBER                                                   " & _
                                  "    , APPLICATION_DATE                                                                                " & _
                                  "FROM RM_AGREEMENT a                                                                                   " & _
                                  "WHERE AGREEMENT_ID = :agreementId                                                                     "


            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)


                UnitOwnerName = .Rows(0)("UNIT_OWNER").ToString

                UnitNumber = .Rows(0)("UNIT_NUMBER").ToString

                TurnOverDate = Date.Parse(.Rows(0)("APPLICATION_DATE"))




            End With

        End Using


    End Sub

End Class
