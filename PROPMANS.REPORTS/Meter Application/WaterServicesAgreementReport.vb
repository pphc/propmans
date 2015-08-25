Imports DALC
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine

Public Class WaterServicesAgreementReport
    Inherits ReportBase

    Private _accountID As String

    Public Property AccountID() As String
        Get
            Return _accountID
        End Get
        Private Set(ByVal value As String)

        End Set
    End Property


    Private _unitOwnerName As String
    Public Property UnitOwnerName() As String
        Get
            Return _unitOwnerName
        End Get
        Private Set(ByVal value As String)
            _unitOwnerName = value
        End Set
    End Property


    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Private Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Private Set(ByVal value As String)
            _address = value
        End Set
    End Property

    Private _unitNumber As String
    Public Property UnitNumber() As String
        Get
            Return _unitNumber
        End Get
        Private Set(ByVal value As String)
            _unitNumber = value
        End Set
    End Property

    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "WATER SERVICES AGREEMENT"
        End Get
    End Property

    Public Sub New(ByVal accountID As String)

        _accountID = accountID
        LoadAccountInfo()

    End Sub

    Public Overrides Sub BindItems()

        ReportDoc = New rptWaterServicesAgreement

        With ReportDoc.DataDefinition
            .FormulaFields("UnitOwnerName").Text = "'" & UnitOwnerName & "'"
            .FormulaFields("UnitNumber").Text = "'" & UnitNumber & "'"

            If String.IsNullOrEmpty(Status) Then
                .FormulaFields("CivilStatus").Text = "'" & "married to " & "____________________________________" & "'"
            Else
                If Status.Trim.ToUpper = "SINGLE" Then
                    .FormulaFields("CivilStatus").Text = "'" & Status.ToLower & "'"
                Else
                    .FormulaFields("CivilStatus").Text = "'" & "married to " & "____________________________________" & "'"
                End If
            End If


            If Not String.IsNullOrEmpty(Address) Then
                .FormulaFields("Address").Text = "'" & Address & "'"
            Else
                .FormulaFields("Address").Text = "'" & "____________________________________" & "'"
            End If

            .FormulaFields("ProjectName").Text = "'" & Defaults.SiteName & "'"
            .FormulaFields("ProjectLocation").Text = "'" & Defaults.SiteAddress & "'"

        End With

        'With ReportDoc.ReportDefinition.Sections("Section1")

        '    DirectCast(.ReportObjects("ProjectName"), TextObject).Text = Defaults.SiteName

        '    Dim unitOwnerInfo As String = DirectCast(.ReportObjects("UnitOwnerInfo"), TextObject).Text

        '    ''unitOwnerInfo = unitOwnerInfo.Replace("#UNIT_OWNER#", UnitOwnerName)
        '    unitOwnerInfo = unitOwnerInfo.Replace("#UNIT_OWNER#", "____________________________________________")

        '    Dim statusdesc As String = String.Empty

        '    If Not String.IsNullOrEmpty(Status) Then

        '        Select Case Status
        '            Case "single"
        '                statusdesc = "single"
        '            Case "married"
        '                statusdesc = "married to ________________________________"
        '        End Select

        '    Else
        '        statusdesc = "single / married to ____________________________________"
        '    End If
        '    unitOwnerInfo = unitOwnerInfo.Replace("#STATUS#", statusdesc)



        '    If Not String.IsNullOrEmpty(Address) Then
        '        unitOwnerInfo = unitOwnerInfo.Replace("#ADDRESS#", Address)
        '    Else
        '        unitOwnerInfo = unitOwnerInfo.Replace("#ADDRESS#", "____________________________________")
        '    End If


        '    DirectCast(.ReportObjects("UnitOwnerInfo"), TextObject).Text = unitOwnerInfo

        '    Dim projInfo As String = DirectCast(.ReportObjects("ProjectInfo"), TextObject).Text

        '    projInfo = projInfo.Replace("#PROJECT_NAME#", Defaults.SiteName)
        '    projInfo = projInfo.Replace("#PROJECT_LOC#", Defaults.SiteAddress)

        '    DirectCast(.ReportObjects("ProjectInfo"), TextObject).Text = projInfo

        '    'DirectCast(.ReportObjects("UnitNumber"), TextObject).Text = UnitNumber
        '    DirectCast(.ReportObjects("UnitNumber"), TextObject).Text = ""


        'End With

        'With ReportDoc.ReportDefinition.Sections("DetailSection1")
        '    DirectCast(.ReportObjects("UnitOwner2"), TextObject).Text = UnitOwnerName
        'End With
    End Sub

    Private Sub LoadAccountInfo()

        Dim query As String = "select ACCOUNTS.GETCUSTOMERFULLNAME_FML(cust_id) custname,cust_marital_status status, " & _
                "ACCOUNTS.GETUNITNUMBER(:accountid) unitnumber,                       " & _
                "(SELECT DETAILS                                                       " & _
                "FROM AM_CUSTOMER_CONTACT                                              " & _
                "where cust_id = cs.cust_id                                            " & _
                "and contact_type = 'ADDRESS'                                          " & _
                "AND preffered ='Y')  address                                          " & _
                "from customers cs                                                     " & _
                "where cust_id = (select acct_cust_id from customer_accounts           " & _
                "where account_id = :accountid)                                        "

        Using params As New OraParameter
            params.AddItem("accountid", AccountID, Oracle.DataAccess.Client.OracleDbType.Int32)

            With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)

                UnitOwnerName = .Rows(0)("custname").ToString
                UnitNumber = .Rows(0)("unitnumber").ToString
                Status = .Rows(0)("status").ToString
                Address = .Rows(0)("address").ToString

            End With

        End Using

    End Sub
End Class
