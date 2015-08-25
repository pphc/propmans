
Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common

Public Class DepositSummary
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "DEPOSIT SUMMARY"
        End Get
    End Property


    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property

    Private _depositID As String
    Public Property DepositID() As String
        Get
            Return _depositID
        End Get
        Set(ByVal value As String)
            _depositID = value
        End Set
    End Property

    Private _bankAccountNumber As String
    Public Property BankAccountNumber() As String
        Get
            Return _bankAccountNumber
        End Get
        Private Set(ByVal value As String)
            _bankAccountNumber = value
        End Set
    End Property

    Private _bankName As String
    Public Property BankName() As String
        Get
            Return _bankName
        End Get
        Private Set(ByVal value As String)
            _bankName = value
        End Set
    End Property

    Private _depositDate As Date
    Public Property DepositDate() As Date
        Get
            Return _depositDate
        End Get
        Set(ByVal value As Date)
            _depositDate = value
        End Set
    End Property

    Private _depositType As String
    Public Property DepositType() As String
        Get
            Return _depositType
        End Get
        Private Set(ByVal value As String)
            _depositType = value
        End Set
    End Property

    Private crystalreportname As String = "rptDepositDetail.rpt"
    Public Sub New()

    End Sub

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()

        Using params As New OraParameter
            Dim query As String = "SELECT deposit_id, deposit_date, bank_account_no, proj_bank_name," & _
                                    "       deposit_type, deposit_total_amt,deposit_remarks           " & _
                                    "  FROM deposits ds JOIN depository_banks db                      " & _
                                    "       ON (ds.depository_bank_id = db.proj_bank_id)              " & _
                                    " WHERE deposit_id = :depositid                                   "

            params.AddItem(":depositid", DepositID, Oracle.DataAccess.Client.OracleDbType.Int32)
            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                BankAccountNumber = .Rows(0)("bank_account_no").ToString
                BankName = .Rows(0)("proj_bank_name").ToString
                DepositDate = Date.Parse(.Rows(0)("deposit_date"))
                If .Rows(0)("deposit_type") = "CSH" Then
                    DepositType = "CASH"
                Else
                    DepositType = "CHECK"
                End If
            End With
        End Using

        Using params As New OraParameter
            Dim query As String = "SELECT   payment_id, or_number, payment_date, paid_amount " & _
                        "    FROM payments                                         " & _
                        "   WHERE pay_deposit_id = :depositid                      " & _
                        "ORDER BY or_number                                        "
            params.AddParameter(":depositid", DepositID, Oracle.DataAccess.Client.OracleDbType.Int32)

            Using dtDeposit As DataTable = OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                ReportDoc = New rptDepositDetail
                ReportDoc.SetDataSource(DirectCast(dtDeposit, DataTable))
            End Using

        End Using

    End Sub

    Public Overrides Sub BindItems()

        With ReportDoc.ReportDefinition.Sections("SecReportHeader")

            DirectCast(.ReportObjects("txtProjectName"), TextObject).Text = Defaults.SiteName

            DirectCast(.ReportObjects("txtDepositNumber"), TextObject).Text = DepositID
            DirectCast(.ReportObjects("txtAccountNumber"), TextObject).Text = BankAccountNumber
            DirectCast(.ReportObjects("txtBankName"), TextObject).Text = BankName
            DirectCast(.ReportObjects("txtDepositDate"), TextObject).Text = DepositDate.ToString("MMM dd, yyyy")
            DirectCast(.ReportObjects("txtDepositType"), TextObject).Text = DepositType



            DirectCast(.ReportObjects("txtBillingStaffName"), TextObject).Text = GlobalReference.CurrentUser.UserFullName
            DirectCast(.ReportObjects("txtPropertyAdminName"), TextObject).Text = Defaults.SitePropertyAdmin
            'TODO move to other class OraConnection.Instance.UserID
            DirectCast(.ReportObjects("txtUsername"), TextObject).Text = OraConnection.Instance.UserID

        End With
    End Sub


End Class
