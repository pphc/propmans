Imports System.Data
Imports DALC
Imports CrystalDecisions.CrystalReports.Engine
Imports BCL.Common

Public Class MeterReadingReport
    Inherits ReportBase

    Public Overrides ReadOnly Property ReportName() As String
        Get
            Return "METER READINGS"
        End Get
    End Property

    Public Overrides ReadOnly Property InputNeeded() As Boolean
        Get
            Return True
        End Get
    End Property

    Private _readingDate As Date
    Public Property ReadingDate() As Date
        Get
            Return _readingDate
        End Get
        Set(ByVal value As Date)
            _readingDate = value
        End Set
    End Property

    Private _includeAllUnits As Boolean
    Public Property IncludeAllUnits() As Boolean
        Get
            Return _includeAllUnits
        End Get
        Set(ByVal value As Boolean)
            _includeAllUnits = value
        End Set
    End Property

    Public Overrides Sub LoadReport()
        LoadData()
        BindItems()
    End Sub

    Private Sub LoadData()

        Using params As New OraParameter

            params.AddItem(":readingdate", ReadingDate, Oracle.DataAccess.Client.OracleDbType.Date)

            Dim query As String
            If IncludeAllUnits Then
                query = "SELECT   meter_id, cs.cust_unit_no, cust_unit_sort,                             " & _
                        "         accounts.getcurrentunitowner (cs.unit_id) full_name,                   " & _
                        "         NVL (um.meter_number, 'N.A') meter_number, um.installed_date,          " & _
                        "         NVL (um.connection_status, 'NOT INSTALLED') connection_status,         " & _
                        "         NVL2                                                                   " & _
                        "             (meter_id,                                                         " & _
                        "              watersystem.getpreviousreading2 (um.meter_id, :readingdate),      " & _
                        "              NULL                                                              " & _
                        "             ) previous_reading,                                                " & _
                        "         NVL2 (meter_id,                                                        " & _
                        "               watersystem.getcurrentreading (um.meter_id, :readingdate),       " & _
                        "               NULL                                                             " & _
                        "              ) curr_reading                                                    " & _
                        "    FROM (SELECT am.unit_id, am.bldg_no, am.cluster_no, am.floor_no,            " & _
                        "                 am.unit_no, ca.account_id, am.unit_number cust_unit_no,        " & _
                        "                 ca.cust_unit_sort                                              " & _
                        "            FROM am_unit am                                                     " & _
                        "                 LEFT JOIN                                                      " & _
                        "                 (SELECT unit_id, account_id, cust_unit_no, cust_unit_sort      " & _
                        "                    FROM customer_accounts                                      " & _
                        "                   WHERE account_status = 'ACT' AND account_class = 'CONDO') ca " & _
                        "                 ON (ca.unit_id = am.unit_id)                                   " & _
                        "           WHERE unit_subclass <> 'PARK') cs                                    " & _
                        "         LEFT JOIN                                                             " & _
                        "         (SELECT unit_id, meter_id, meter_number, installed_date,               " & _
                        "                 connection_status                                              " & _
                        "            FROM utl_meter_detail                                               " & _
                        "           WHERE connection_status <> 'INACT') um ON (cs.unit_id = um.unit_id   " & _
                        "                                                     )                          " & _
                        "ORDER BY bldg_no, cluster_no, floor_no, unit_no                                 "

            Else
                query = "SELECT   meter_id, cs.cust_unit_no, cust_unit_sort,                             " & _
                        "         accounts.getcurrentunitowner (cs.unit_id) full_name,                   " & _
                        "         NVL (um.meter_number, 'N.A') meter_number, um.installed_date,          " & _
                        "         NVL (um.connection_status, 'NOT INSTALLED') connection_status,         " & _
                        "         NVL2                                                                   " & _
                        "             (meter_id,                                                         " & _
                        "              watersystem.getpreviousreading2 (um.meter_id, :readingdate),      " & _
                        "              NULL                                                              " & _
                        "             ) previous_reading,                                                " & _
                        "         NVL2 (meter_id,                                                        " & _
                        "               watersystem.getcurrentreading (um.meter_id, :readingdate),       " & _
                        "               NULL                                                             " & _
                        "              ) curr_reading                                                    " & _
                        "    FROM (SELECT am.unit_id, am.bldg_no, am.cluster_no, am.floor_no,            " & _
                        "                 am.unit_no, ca.account_id, am.unit_number cust_unit_no,        " & _
                        "                 ca.cust_unit_sort                                              " & _
                        "            FROM am_unit am                                                     " & _
                        "                 LEFT JOIN                                                      " & _
                        "                 (SELECT unit_id, account_id, cust_unit_no, cust_unit_sort      " & _
                        "                    FROM customer_accounts                                      " & _
                        "                   WHERE account_status = 'ACT' AND account_class = 'CONDO') ca " & _
                        "                 ON (ca.unit_id = am.unit_id)                                   " & _
                        "           WHERE unit_subclass <> 'PARK') cs                                    " & _
                        "         RIGHT JOIN                                                             " & _
                        "         (SELECT unit_id, meter_id, meter_number, installed_date,               " & _
                        "                 connection_status                                              " & _
                        "            FROM utl_meter_detail                                               " & _
                        "           WHERE connection_status <> 'INACT') um ON (cs.unit_id = um.unit_id   " & _
                        "                                                     )                          " & _
                        "ORDER BY bldg_no, cluster_no, floor_no, unit_no                                 "
            End If


            Using dt As DataTable = OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                ReportDoc = New rptMeterReading
                ReportDoc.SetDataSource(dt)
            End Using
        End Using

    End Sub

    Public Overrides Sub BindItems()

        With ReportDoc.ReportDefinition.Sections("SecReportHeader")

            DirectCast(.ReportObjects("txtProjectName"), TextObject).Text = Defaults.SiteName & " PROJECT"
            DirectCast(.ReportObjects("txtBillingMonth"), TextObject).Text = "FOR THE MONTH OF " & ReadingDate.ToString("MMMM yyyy").ToUpper
            'DirectCast(.ReportObjects("txtAccountStatus"), TextObject).Text = GetConnectionStatusDisplay() & " ACCOUNTS"
            DirectCast(.ReportObjects("txtBillingStaffName"), TextObject).Text = GlobalReference.CurrentUser.UserFullName
            DirectCast(.ReportObjects("txtPropertyAdminName"), TextObject).Text = Defaults.SitePropertyAdmin
            DirectCast(.ReportObjects("txtUsername"), TextObject).Text = OraConnection.Instance.UserID

        End With
    End Sub

    'Private Function GetConnectionStatusDisplay() As String
    '    Dim connStatus As String = String.Empty
    '    Dim listed As Boolean = False
    '    Dim i As Integer = 1
    '    ConnectionStatus.Sort()
    '    For Each stat As MeterConnectionStatus In ConnectionStatus
    '        Select Case stat
    '            Case MeterConnectionStatus.[NEW]
    '                connStatus &= "NEW"
    '            Case MeterConnectionStatus.ACT
    '                connStatus &= "ACTIVE"
    '            Case MeterConnectionStatus.REC
    '                connStatus &= "RECONNECTED"
    '            Case MeterConnectionStatus.TEMW, MeterConnectionStatus.TEMC
    '                If Not listed Then
    '                    connStatus &= "TEMPORARILY DISCONNECTED"
    '                    listed = True
    '                End If
    '            Case MeterConnectionStatus.VOLM
    '                connStatus &= "VOLUNTARY DISCONNECTED"
    '            Case MeterConnectionStatus.PERM
    '                connStatus &= "INACTIVE"
    '        End Select
    '        If ConnectionStatus.Count > 1 Then
    '            If (i + 1) = ConnectionStatus.Count Then
    '                connStatus &= " AND "
    '            Else
    '                If i <> ConnectionStatus.Count Then
    '                    connStatus &= ", "
    '                End If
    '            End If
    '            i += 1
    '        End If
    '    Next
    '    Return connStatus
    'End Function

End Class
