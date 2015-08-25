Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Statements
Imports System.Text
Imports BCL.Utils


Imports BCL.Common



Namespace WaterSystem


    Public Enum MeterConnectionStatus
        <EnumDescription("ACTIVE")> _
        <EnumDBValue("ACT")> _
        ACT
        <EnumDescription("VOLUNTARY DISCONNECTED")> _
        <EnumDBValue("VOLM")> _
        VOLM
        <EnumDescription("TEMPORARY DISCONNECTED")> _
        <EnumDBValue("TEMP")> _
        TEMP
        <EnumDescription("INACTIVE METER")> _
        <EnumDBValue("INACT")> _
        INACTIVE
    End Enum

    Public Enum MeterReadingStatus
        <EnumDescription("START")> _
        <EnumDBValue("START")> _
        START
        <EnumDescription("NORMAL")> _
        <EnumDBValue("NORMAL")> _
        NORMAL
        <EnumDescription("AVERAGE")> _
        <EnumDBValue("AVERAGE")> _
        AVERAGE
        <EnumDescription("DISCONNECTION")> _
        <EnumDBValue("DISC")> _
        DISCONNECTION
    End Enum

    Public Enum MeterReadingFlag
        <EnumDescription("BEGINNING")> _
        <EnumDBValue("BEG")> _
        BEGINNING
        <EnumDescription("ZERO CONSUMPTION")> _
        <EnumDBValue("ZERO")> _
        ZERO
        <EnumDescription("LOW CONSUMPTION")> _
        <EnumDBValue("LOW")> _
        LOW
        <EnumDescription("AVERAGE CONSUMPTION")> _
        <EnumDBValue("AVE")> _
        AVE
        <EnumDescription("HIGH CONSUMPTION")> _
        <EnumDBValue("HIGH")> _
        HIGH
        <EnumDescription("NEGATIVE CONSUMPTION")> _
        <EnumDBValue("NEG")> _
        NEGATIVE
    End Enum

    Public Enum DisconnectionType
        <EnumDescription("VOLUNTARY DISCONNECTION")> _
        <EnumDBValue("VOLM")> _
        Voluntary
        <EnumDescription("TEMPORARY DISCONNECTION")> _
        <EnumDBValue("TEMP")> _
        Temporary
        <EnumDescription("METER REPLACEMENT")> _
        <EnumDBValue("INACT")> _
        Replacement
    End Enum

    Public Enum DisconnectionReason
        <EnumDescription("NON PAYMENT OF WATER BILL")> _
        <EnumDBValue("NON PAYMENT OF WATER BILL")> _
        NonPaymentWater
        <EnumDescription("NON PAYMENT OF CONDO DUES")> _
        <EnumDBValue("NON PAYMENT OF CONDO DUES")> _
        NonPaymentDues
        <EnumDescription("OTHER REASON")> _
        <EnumDBValue("OTHER REASON")> _
        Other
    End Enum

    Public Class WaterReadingMonthSource
        Inherits ListSource

        Public Sub New()
            Dim lastMonth As Date = New Date(Now.Year, Now.Month, 1).AddMonths(1)
            Dim firstMonth As Nullable(Of Date)


            Dim query As String = "SELECT MIN (reading_date) " & _
                                  "FROM(utl_meter_reading) " & _
                                  "WHERE reading_status = 'NORMAL' "

            firstMonth = OraDBHelper2.SqlExecuteScalar(query)

            If Not firstMonth.HasValue Then
                firstMonth = Now.Date
            End If

            Dim currentMonth As Date = New Date(firstMonth.Value.Year, firstMonth.Value.Month, 1)

            While (currentMonth <= lastMonth)
                List.Add(New ItemLIst(currentMonth.ToString("MM/dd/yy"), currentMonth.ToString("MMMM yyyy").ToUpper))
                currentMonth = currentMonth.AddMonths(1)
            End While


        End Sub
    End Class

    Public Class WaterMeter

#Region "Properties"
        Private _meterID As String

        Public Property MeterID() As String
            Get
                Return _meterID
            End Get
            Set(ByVal Value As String)
                _meterID = Value
            End Set
        End Property

        Public ReadOnly Property ApplicationNumber() As String
            Get
                Return BCL.Common.GlobalReference.ProjectParameters.SiteCode & "-" & WaterApplicationNumber
            End Get
        End Property

        Private _waterApplicationNumber As String

        Public Property WaterApplicationNumber() As String
            Get
                Return _waterApplicationNumber
            End Get
            Set(ByVal Value As String)
                _waterApplicationNumber = Value
            End Set
        End Property


        Private _unitID As String

        Public Property UnitID() As String
            Get
                Return _unitID
            End Get
            Set(ByVal Value As String)
                _unitID = Value
            End Set
        End Property


        Private _ApplicationDate As Date

        Public Property ApplicationDate() As Date
            Get
                Return _ApplicationDate
            End Get
            Set(ByVal Value As Date)
                _ApplicationDate = Value
            End Set
        End Property


        Private _meterNumber As String

        Public Property MeterNumber() As String
            Get
                Return _meterNumber
            End Get
            Set(ByVal Value As String)
                _meterNumber = Value
            End Set
        End Property

        Private _installationDate As Nullable(Of Date)

        Public Property InstallationDate() As Date
            Get
                Return _installationDate
            End Get
            Set(ByVal Value As Date)
                _installationDate = Value
            End Set
        End Property

        Private _startReading As Decimal

        Public Property StartReading() As Decimal
            Get
                Return _startReading
            End Get
            Set(ByVal Value As Decimal)
                _startReading = Value
            End Set
        End Property

        Private _installedBy As String

        Public Property InstalledBy() As String
            Get
                Return _installedBy
            End Get
            Set(ByVal Value As String)
                _installedBy = Value
            End Set
        End Property

        Private _meterRemarks As String

        Public Property MeterRemarks() As String
            Get
                Return _meterRemarks
            End Get
            Set(ByVal Value As String)
                _meterRemarks = Value
            End Set
        End Property

        Private _connectionStatus As MeterConnectionStatus
        Public Property ConnectionStatus() As MeterConnectionStatus
            Get
                Return _connectionStatus
            End Get
            Set(ByVal Value As MeterConnectionStatus)
                _connectionStatus = Value
            End Set
        End Property

        Public ReadOnly Property ConnectionStatusDescription() As String
            Get
                Return EnumHelper.GetDescription(ConnectionStatus)
            End Get
        End Property


        Private _connectionStatusDate As Nullable(Of Date)

        Public Property ConnectionStatusDate() As Nullable(Of Date)
            Get
                Return _connectionStatusDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _connectionStatusDate = Value
            End Set
        End Property

        Private _connectionStatusRamarks As String

        Public Property ConnectionStatusRamarks() As String
            Get
                Return _connectionStatusRamarks
            End Get
            Set(ByVal Value As String)
                _connectionStatusRamarks = Value
            End Set
        End Property

#End Region

        Public Shared Function GetAllUnitsMeterApplications() As DataTable
            Dim query As String = "SELECT   unit_id, unit_number,                                                   " & _
                                "         accounts.getcurrentunitowner (au.unit_id) unit_owner,                   " & _
                                "         accounts.getcurrentunitowneraccountid (au.unit_id) account_id,          " & _
                                "         DECODE (occupancy_status,                                               " & _
                                "                 'OCC', 'OCCUPIED',                                              " & _
                                "                 'VACANT'                                                        " & _
                                "                ) occupancy_status,                                              " & _
                                "         occupant,                                                               " & _
                                "         (SELECT meter_id                                                        " & _
                                "            FROM utl_meter_detail                                                " & _
                                "           WHERE unit_id = au.unit_id                                            " & _
                                "             AND connection_status <> 'INACT') meter_id,                         " & _
                                "         (SELECT water_application_date                                          " & _
                                "                FROM customer_accounts                                           " & _
                                "               WHERE account_id =                                                " & _
                                "                            accounts.getcurrentunitowneraccountid (au.unit_id)) water_application_date  ,  " & _
                                "         NVL2                                                                    " & _
                                "            ((SELECT water_application_date                                      " & _
                                "                FROM customer_accounts                                           " & _
                                "               WHERE account_id =                                                " & _
                                "                            accounts.getcurrentunitowneraccountid (au.unit_id)), " & _
                                "             NVL2 ((SELECT connection_status                                     " & _
                                "                      FROM utl_meter_detail                                      " & _
                                "                     WHERE unit_id = au.unit_id                                  " & _
                                "                       AND connection_status <> 'INACT'),                        " & _
                                "                   'INSTALLED',                                                  " & _
                                "                   'PENDING'                                                     " & _
                                "                  ),                                                             " & _
                                "             'NOT INSTALLED'                                                     " & _
                                "            ) meter_status                                                       " & _
                                "    FROM am_unit au                                                              " & _
                                "   WHERE unit_subclass <> 'PARK'                                                 " & _
                                "ORDER BY bldg_no, cluster_no, floor_no                                           "

            Return OraDBHelper2.GetResultSet(query)
        End Function

        Public Shared Function GetAllUnitsMeterApplicationsByUnitNumber(ByVal unitNumber As String) As DataTable
            Dim query As String = "SELECT   unit_id, unit_number,                                                   " & _
                                "         accounts.getcurrentunitowner (au.unit_id) unit_owner,                   " & _
                                "         accounts.getcurrentunitowneraccountid (au.unit_id) account_id,          " & _
                                "         DECODE (occupancy_status,                                               " & _
                                "                 'OCC', 'OCCUPIED',                                              " & _
                                "                 'VACANT'                                                        " & _
                                "                ) occupancy_status,                                              " & _
                                "         occupant,                                                               " & _
                                "         (SELECT meter_id                                                        " & _
                                "            FROM utl_meter_detail                                                " & _
                                "           WHERE unit_id = au.unit_id                                            " & _
                                "             AND connection_status <> 'INACT') meter_id,                         " & _
                                "         (SELECT water_application_date                                          " & _
                                "                FROM customer_accounts                                           " & _
                                "               WHERE account_id =                                                " & _
                                "                            accounts.getcurrentunitowneraccountid (au.unit_id)) water_application_date  ,  " & _
                                "         NVL2                                                                    " & _
                                "            ((SELECT water_application_date                                      " & _
                                "                FROM customer_accounts                                           " & _
                                "               WHERE account_id =                                                " & _
                                "                            accounts.getcurrentunitowneraccountid (au.unit_id)), " & _
                                "             NVL2 ((SELECT connection_status                                     " & _
                                "                      FROM utl_meter_detail                                      " & _
                                "                     WHERE unit_id = au.unit_id                                  " & _
                                "                       AND connection_status <> 'INACT'),                        " & _
                                "                   'INSTALLED',                                                  " & _
                                "                   'PENDING'                                                     " & _
                                "                  ),                                                             " & _
                                "             'NOT INSTALLED'                                                     " & _
                                "            ) meter_status                                                       " & _
                                "    FROM am_unit au                                                              " & _
                                "   WHERE unit_subclass <> 'PARK'                                                 " & _
                                "     AND unit_number = :unitnumber " & _
                                "ORDER BY bldg_no, cluster_no, floor_no                                           "

            Using param As New OraParameter
                param.AddParameter("unitnumber", unitNumber)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetMeterInfoByMeterID(ByVal meterID As String) As WaterMeter

            Dim query As String = "SELECT meter_id, meter_number, installed_date, start_reading,meter_remarks," & _
                        "       connection_status, installed_by                                                  " & _
                        "  FROM utl_meter_detail                                                       " & _
                        " WHERE meter_id = :meterid "


            Dim meter As New WaterMeter
            meter.MeterID = meterID

            Using param As New OraParameter
                param.AddItem(":meterID", meterID, OracleDbType.Int32)

                With OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

                    meter.MeterNumber = .Rows(0)("meter_number").ToString()
                    meter.InstallationDate = .Rows(0)("installed_date")
                    meter.StartReading = Decimal.Parse(.Rows(0)("start_reading"))
                    meter.InstalledBy = .Rows(0)("installed_by").ToString()
                    meter.MeterRemarks = .Rows(0)("meter_remarks").ToString()
                    meter.ConnectionStatus = EnumHelper.GetEnumValueFromDBValue(Of MeterConnectionStatus)(.Rows(0)("connection_status").ToString())
                End With
            End Using

            Return meter
        End Function

        'Public Shared Function GetMeters() As DataTable

        '    Dim query As String = "SELECT unit_id                                                                                                                                   " & _
        '                            "	  , meter_id                                                                                                                                  " & _
        '                            "     , (SELECT cust_unit_no FROM customer_accounts  WHERE account_id = UMD.unit_id) unit_number                                                      " & _
        '                            "     , getcustfullname_lfm((SELECT acct_cust_id FROM customer_accounts  WHERE account_id = UMD.unit_id)) unit_owner                                  " & _
        '                            "     , application_date                                                                                                                          " & _
        '                            "     , meter_number                                                                                                                              " & _
        '                            "     , installation_date installed_date                                                                                                          " & _
        '                            "     , start_reading                                                                                                                             " & _
        '                            "     , connection_status                                                                                                                         " & _
        '                            "     , (SELECT cust_lname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_lname    " & _
        '                            "     , (SELECT cust_fname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_fname    " & _
        '                            "FROM utl_meter_detail UMD                                                                                                                            " & _
        '                            "ORDER BY installation_date                                                                                                                       "
        '    Return OraDBHelper2.GetResultSet(query)

        'End Function

        Public Shared Function GetAllMeters() As DataTable

            Dim query As String = "SELECT unit_id                                                                                                                                   " & _
                                    "	  , meter_id                                                                                                                                  " & _
                                    "     , (SELECT unit_number FROM am_unit WHERE unit_id = UMD.unit_id) unit_number, (select cust_unit_sort from customer_accounts where account_id = accounts.getcurrentunitowneraccountid(UMD.unit_id))" & _
                                    "     , accounts.getcurrentunitowner(UMD.unit_id) unit_owner                                  " & _
                                    "     , meter_number                                                                                                                              " & _
                                    "     , installed_date                                                                                                          " & _
                                    "     , start_reading                                                                                                                             " & _
                                    "     , connection_status                                                                                                                         " & _
                                    "FROM utl_meter_detail UMD                                                                                                                            " & _
                                    "ORDER BY 4,9                                                                                                                      "

            Return OraDBHelper2.GetResultSet(query)

        End Function

        Public Shared Function GetMetersByUnitNumber(ByVal unitNumber As String)

            Dim query As String = "SELECT unit_id                                                                                                                                   " & _
                                          "	  , meter_id                                                                                                                                  " & _
                                          "     , (SELECT unit_number FROM am_unit WHERE unit_id = UMD.unit_id) unit_number                                                      " & _
                                          "     , accounts.getcurrentunitowner(UMD.unit_id) unit_owner                                  " & _
                                          "     , meter_number                                                                                                                              " & _
                                          "     , installed_date                                                                                                         " & _
                                          "     , start_reading                                                                                                                             " & _
                                          "     , connection_status                                                                                                                         " & _
                                          "     , (SELECT cust_lname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_lname    " & _
                                          "     , (SELECT cust_fname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_fname    " & _
                                          "FROM utl_meter_detail UMD                                                                                                                            " & _
                                          "WHERE unit_id = (select unit_id from am_unit where unit_number = :unitNumber)  " & _
                                          "ORDER BY installed_date desc "
            Using params As New OraParameter

                params.AddItem("unitNumber", unitNumber)
                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using
        End Function

        Public Shared Function GetMetersByMeterNumber(ByVal meterNumber As String)
            Dim query As String = "SELECT unit_id                                                                                                                                   " & _
                                         "	  , meter_id                                                                                                                                  " & _
                                         "     , (SELECT unit_number FROM am_unit WHERE unit_id = UMD.unit_id) unit_number                                                      " & _
                                         "     , accounts.getcurrentunitowner(UMD.unit_id) unit_owner                                  " & _
                                         "     , meter_number                                                                                                                              " & _
                                         "     , installed_date                                                                                                          " & _
                                         "     , start_reading                                                                                                                             " & _
                                         "     , connection_status                                                                                                                         " & _
                                         "     , (SELECT cust_lname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_lname    " & _
                                         "     , (SELECT cust_fname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_fname    " & _
                                         "FROM utl_meter_detail UMD                                                                                                                            " & _
                                         "WHERE meter_number = :meternumber   " & _
                                         "ORDER BY installed_date  "
            Using params As New OraParameter

                params.AddItem("meternumber", meterNumber, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using


        End Function

        Public Shared Function GetMetersByMeterID(ByVal meterID As String)

            Dim query As String = "SELECT unit_id                                                                                                                                   " & _
                                       "	  , meter_id                                                                                                                                  " & _
                                       "     , (SELECT unit_number FROM am_unit WHERE unit_id = UMD.unit_id) unit_number                                                      " & _
                                       "     , accounts.getcurrentunitowner(UMD.unit_id) unit_owner                                  " & _
                                       "     , meter_number                                                                                                                              " & _
                                       "     , installed_date                                                                                                          " & _
                                       "     , start_reading                                                                                                                             " & _
                                       "     , connection_status                                                                                                                         " & _
                                       "     , (SELECT cust_lname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_lname    " & _
                                       "     , (SELECT cust_fname FROM customers  WHERE cust_id = (select acct_cust_id from customer_accounts where account_id = UMD.unit_id)) cust_fname    " & _
                                       "FROM utl_meter_detail UMD                                                                                                                            " & _
                                       "WHERE meter_id = :meterid   " & _
                                       "ORDER BY installed_date  "
            Using params As New OraParameter

                params.AddItem("meterid", meterID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetAverageConsumption(ByVal meterID As String) As Decimal
            Using params As New OraParameter
                params.AddParameter("meterid", meterID, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("averageconsumption", "", OracleDbType.Decimal, ParameterDirection.ReturnValue)

                Return Decimal.Parse(DirectCast(OraDBHelper2.ExecuteFunction("watersystem.getaverageconsumption", params.GetParameterCollection), OracleDecimal).ToSingle)
            End Using
        End Function

        Public Shared Function GetAverageConsumption(ByVal meterID As String, ByVal readingDate As Date) As Decimal
            Using params As New OraParameter
                params.AddParameter("meterid", meterID, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("readingdate", readingDate, OracleDbType.Date, ParameterDirection.Input)
                params.AddParameter("averageconsumption", "", OracleDbType.Decimal, ParameterDirection.ReturnValue)

                Return Decimal.Parse(DirectCast(OraDBHelper2.ExecuteFunction("watersystem.getaverageconsumption", params.GetParameterCollection), OracleDecimal).ToSingle)
            End Using
        End Function

        Public Shared Function InsertNewMeterApplication(ByVal meterInfo As WaterMeter) As String
            With meterInfo

                Using params As New OraParameter
                    params.AddParameter("unitid", .UnitID, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("meternumber", .MeterNumber, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("installationdate", .InstallationDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("startReading", .StartReading, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("installedBy", .InstalledBy, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("meterremarks", .MeterRemarks, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("meterID", "", OracleDbType.Int32, ParameterDirection.ReturnValue)

                    Return DirectCast(OraDBHelper2.ExecuteFunction("watersystem.insertmeterdetails", params.GetParameterCollection), OracleDecimal).ToString

                End Using


            End With


        End Function

        Public Shared Sub UpdateMeterApplication(ByVal meterInfo As WaterMeter)
            With meterInfo

                Using params As New OraParameter
                    params.AddParameter("meterid", .MeterID, OracleDbType.Int32, ParameterDirection.Input)
                    params.AddParameter("meternumber", .MeterNumber, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("installationdate", .InstallationDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("startReading", .StartReading, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("installedBy", .InstalledBy, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("meterremarks", .MeterRemarks, OracleDbType.Varchar2, ParameterDirection.Input)

                    OraDBHelper2.ExecuteProcedureforInput("watersystem.updatemeterdetails", params.GetParameterCollection)

                End Using
            End With

        End Sub

        Public Shared Sub UpdateMeterApplicationDate(ByVal accountID As String, ByVal AgreementDate As Date)
            Dim query As String = "UPDATE customer_accounts " & _
                                    "SET water_application_date = :applicationtDate " & _
                                    "WHERE account_id = :accountid"

            Using params As New OraParameter
                params.AddParameter("accountid", accountID, OracleDbType.Int32)
                params.AddParameter("applicationtDate", AgreementDate, OracleDbType.Date)

                OraDBHelper2.SqlExecute(query, params.GetParameterCollection)
            End Using
        End Sub

        Public Shared Function GetConnectionStatusDescription(ByVal statusCode As String) As String
            Return EnumHelper.GetDescription(EnumHelper.GetEnumValueFromDBValue(Of MeterConnectionStatus)(statusCode))
        End Function

        Public Shared Function GetMeterDisconnectionInfo(ByVal meterID As String) As WaterMeter
            Dim query As String = "SELECT connection_status, connection_status_remarks, connection_status_date " & _
                            "  FROM utl_meter_detail                                                     " & _
                            " WHERE meter_id = :meterid                                                  "

            Using params As New OraParameter

                params.AddItem("meterid", meterID, OracleDbType.Int32)
                With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                    Dim md As New WaterMeter

                    md.ConnectionStatus = EnumHelper.GetEnumValueFromDBValue(Of MeterConnectionStatus)(.Rows(0)("connection_status").ToString)
                    md.ConnectionStatusDate = Date.Parse(.Rows(0)("connection_status_date"))
                    md.ConnectionStatusRamarks = .Rows(0)("connection_status_remarks").ToString

                    Return md
                End With
            End Using

        End Function

        Public Shared Function IsUnitHasActiveMeter(ByVal unitID As String) As Boolean
            Dim query As String = "SELECT COUNT (meter_id)                               " & _
                                "  FROM utl_meter_detail                               " & _
                                " WHERE unit_id = :unitid AND connection_status <> 'INACT'"

            Using params As New OraParameter
                params.AddParameter("unitid", unitID)
                Return Integer.Parse(OraDBHelper2.SqlExecuteScalar(query, params.GetParameterCollection)) > 0
            End Using
        End Function

        Public Shared Function IsMeterReconnected(ByVal meterID As String, ByRef reconnectionDate As Date, ByRef lastReadStat As WaterSystem.MeterReadingStatus) As Boolean
            Dim query As String = "SELECT DISTINCT NVL ((SELECT COUNT (meter_history_id)                                              " & _
                                    "                        FROM utl_meter_connection_history                                          " & _
                                    "                       WHERE meter_id = um.meter_id                                                " & _
                                    "                         AND connection_status = 'ACT'),                                           " & _
                                    "                     0                                                                             " & _
                                    "                    ) reccount,                                                                    " & _
                                    "                (SELECT MIN (reading_status)                                                       " & _
                                    "                   FROM utl_meter_reading                                                          " & _
                                    "                  WHERE meter_id = um.meter_id                                                     " & _
                                    "                    AND reading_date = (SELECT MAX (reading_date)                                  " & _
                                    "                                          FROM utl_meter_reading                                   " & _
                                    "                                         WHERE meter_id = um.meter_id))                            " & _
                                    "                                                               last_read_stat,                     " & _
                                    "                FIRST_VALUE (changed_date) OVER (PARTITION BY meter_id ORDER BY changed_date DESC) " & _
                                    "                                                                    recondate                      " & _
                                    "           FROM utl_meter_connection_history um                                                    " & _
                                    "          WHERE meter_id = :meterid AND connection_status = 'ACT'                                  "

            Dim actcount As Integer = 0

            Try
                Using params As New OraParameter
                    params.AddParameter("meterid", meterID)
                    With OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
                        If .Rows.Count > 0 Then
                            If Not Convert.IsDBNull(.Rows(0)("reccount")) Then
                                Integer.TryParse(.Rows(0)("reccount"), actcount)
                            End If
                            If Not Convert.IsDBNull(.Rows(0)("recondate")) Then
                                Date.TryParse(.Rows(0)("recondate"), reconnectionDate)
                            End If

                            If Not Convert.IsDBNull(.Rows(0)("last_read_stat")) Then
                                lastReadStat = EnumHelper.GetEnumValueFromDBValue(Of WaterSystem.MeterReadingStatus)(.Rows(0)("last_read_stat").ToString)
                            End If
                        End If
                    End With
                End Using


            Catch ex As NullReferenceException

            End Try

            Return actcount > 1
        End Function

        Public Sub DisconnectMeter()
            Using params As New OraParameter
                params.AddParameter("meterid", Me.MeterID, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("connectionstatus", EnumHelper.GetDBValue(Me.ConnectionStatus), OracleDbType.Varchar2, ParameterDirection.Input)
                params.AddParameter("connectionstatusdate", Me.ConnectionStatusDate, OracleDbType.Date, ParameterDirection.Input)
                params.AddParameter("connectionstatusremarks", Me.ConnectionStatusRamarks, OracleDbType.Varchar2, ParameterDirection.Input)

                OraDBHelper2.ExecuteProcedureforInput("watersystem.updatemeterconnectionstatus", params.GetParameterCollection)

            End Using
        End Sub

        Public Sub ReconnectMeter()
            Using params As New OraParameter
                params.AddParameter("meterid", Me.MeterID, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("connectionstatus", EnumHelper.GetDBValue(Me.ConnectionStatus), OracleDbType.Varchar2, ParameterDirection.Input)
                params.AddParameter("connectionstatusdate", Me.ConnectionStatusDate, OracleDbType.Date, ParameterDirection.Input)
                params.AddParameter("connectionstatusremarks", Me.ConnectionStatusRamarks, OracleDbType.Varchar2, ParameterDirection.Input)

                OraDBHelper2.ExecuteProcedureforInput("watersystem.updatemeterconnectionstatus", params.GetParameterCollection)

            End Using
        End Sub

    End Class

    Public Class WaterMeterReading

#Region "Properties"
        Private _readingID As String
        Public Property ReadingID() As String
            Get
                Return _readingID
            End Get
            Set(ByVal Value As String)
                _readingID = Value
            End Set
        End Property

        Private _meterID As String

        Public Property MeterID() As String
            Get
                Return _meterID
            End Get
            Set(ByVal Value As String)
                _meterID = Value
            End Set
        End Property

        Private _readingDate As Date
        Public Property ReadingDate() As Date
            Get
                Return _readingDate
            End Get
            Set(ByVal Value As Date)
                _readingDate = Value
            End Set
        End Property

        Private _reading As Decimal
        Public Property Reading() As Decimal
            Get
                Return _reading
            End Get
            Set(ByVal Value As Decimal)
                _reading = Value
            End Set
        End Property

        Private _readingCu As Decimal
        Public Property ReadingCu() As Decimal
            Get
                Return _readingCu
            End Get
            Set(ByVal Value As Decimal)
                _readingCu = Value
            End Set
        End Property

        Private _readingAdjustment As Decimal
        Public Property ReadingAdjustment() As Decimal
            Get
                Return _readingAdjustment
            End Get
            Set(ByVal Value As Decimal)
                _readingAdjustment = Value
            End Set
        End Property

        Private _readingStatus As MeterReadingStatus
        Public Property ReadingStatus() As MeterReadingStatus
            Get
                Return _readingStatus
            End Get
            Set(ByVal Value As MeterReadingStatus)
                _readingStatus = Value
            End Set
        End Property

        Public ReadOnly Property ReadingStatusName() As String
            Get
                Return EnumHelper.GetDescription(ReadingStatus)
            End Get
        End Property

        Public ReadOnly Property ReadingFlagDescription() As String
            Get
                Return EnumHelper.GetDescription(ReadingFlag)
            End Get
        End Property


        Private _readingFlag As WaterSystem.MeterReadingFlag
        Public Property ReadingFlag() As WaterSystem.MeterReadingFlag
            Get
                Return _readingFlag
            End Get
            Set(ByVal Value As WaterSystem.MeterReadingFlag)
                _readingFlag = Value
            End Set
        End Property

        Private _billed As String
        Public Property Billed() As String
            Get
                Return _billed
            End Get
            Set(ByVal Value As String)
                _billed = Value
            End Set
        End Property

        Private _readingCost As Decimal
        Public Property ReadingCost() As Decimal
            Get
                Return _readingCost
            End Get
            Set(ByVal Value As Decimal)
                _readingCost = Value
            End Set
        End Property

        Private _paramId As String
        Public Property ParamId() As String
            Get
                Return _paramId
            End Get
            Set(ByVal Value As String)
                _paramId = Value
            End Set
        End Property

        Private _readingRemarks As String
        Public Property ReadingRemarks() As String
            Get
                Return _readingRemarks
            End Get
            Set(ByVal Value As String)
                _readingRemarks = Value
            End Set
        End Property
#End Region

        Public Shared Function GetMeterReadings(ByVal meteriD As String) As DataTable

            Dim query As String = "SELECT reading_id, reading_date, reading, reading_adjustment, reading_cu,  " & _
                            "       reading_status, reading_flag, billed, reading_cost, reading_remarks,cost_adjustment " & _
                            "  FROM utl_meter_reading                                                   " & _
                            " WHERE meter_id = :meterid  " & _
                            " ORDER BY 2 desc"

            Using params As New OraParameter
                params.AddParameter("meterid", meteriD, OracleDbType.Int32)

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetLastReadingInfo(ByVal meterID As String) As WaterSystem.WaterMeterReading
            Using params As New OraParameter

                params.AddParameter("meterid", meterID, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                Dim previous As New WaterSystem.WaterMeterReading

                With OraDBHelper2.ExecuteProcedureRefCursor("watersystem.getlastreadinginfo", params.GetParameterCollection)
                    previous.ReadingDate = Date.Parse(.Rows(0)("reading_date"))
                    previous.Reading = Decimal.Parse(.Rows(0)("reading"))
                    previous.ReadingCu = Decimal.Parse(.Rows(0)("reading_cu"))
                    previous.ReadingAdjustment = Decimal.Parse(.Rows(0)("reading_adjustment"))
                    previous.ReadingStatus = EnumHelper.GetEnumValueFromDBValue(Of MeterReadingStatus)(.Rows(0)("reading_status").ToString)
                    previous.ReadingRemarks = .Rows(0)("reading_remarks").ToString
                    previous.ReadingFlag = EnumHelper.GetEnumValueFromDBValue(Of MeterReadingFlag)(.Rows(0)("reading_flag").ToString)
                End With

                Return previous
            End Using
        End Function

        Public Shared Function GetLastReadingInfo(ByVal meterID As String, ByVal readingDate As Date) As WaterSystem.WaterMeterReading
            Using params As New OraParameter

                params.AddParameter("meterid", meterID, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("readingdate", readingDate, OracleDbType.Date, ParameterDirection.Input)
                params.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                Dim previous As New WaterSystem.WaterMeterReading

                With OraDBHelper2.ExecuteProcedureRefCursor("watersystem.getpreviousreadinginfo", params.GetParameterCollection)
                    previous.ReadingDate = Date.Parse(.Rows(0)("reading_date"))
                    previous.Reading = Decimal.Parse(.Rows(0)("reading"))
                    previous.ReadingCu = Decimal.Parse(.Rows(0)("reading_cu"))
                    previous.ReadingAdjustment = Decimal.Parse(.Rows(0)("reading_adjustment"))
                    previous.ReadingStatus = EnumHelper.GetEnumValueFromDBValue(Of MeterReadingStatus)(.Rows(0)("reading_status").ToString)
                    previous.ReadingRemarks = .Rows(0)("reading_remarks").ToString
                    previous.ReadingFlag = EnumHelper.GetEnumValueFromDBValue(Of MeterReadingFlag)(.Rows(0)("reading_flag").ToString)
                End With

                Return previous
            End Using
        End Function

        Public Shared Function GetReadingInfobyReadingID(ByVal readingID) As WaterSystem.WaterMeterReading
            Using params As New OraParameter

                params.AddParameter("readingid", readingID, OracleDbType.Int32, ParameterDirection.Input)
                params.AddParameter("refcursor", Nothing, OracleDbType.RefCursor, ParameterDirection.ReturnValue)

                Dim reading As New WaterSystem.WaterMeterReading

                With OraDBHelper2.ExecuteProcedureRefCursor("watersystem.getreadinginfobyreadingid", params.GetParameterCollection)
                    reading.ReadingID = readingID
                    reading.ReadingDate = Date.Parse(.Rows(0)("reading_date"))
                    reading.Reading = Decimal.Parse(.Rows(0)("reading"))
                    reading.ReadingCu = Decimal.Parse(.Rows(0)("reading_cu"))
                    reading.ReadingAdjustment = Decimal.Parse(.Rows(0)("reading_adjustment"))
                    reading.ReadingStatus = EnumHelper.GetEnumValueFromDBValue(Of MeterReadingStatus)(.Rows(0)("reading_status").ToString)
                    reading.ReadingRemarks = .Rows(0)("reading_remarks").ToString
                    reading.ReadingFlag = EnumHelper.GetEnumValueFromDBValue(Of MeterReadingFlag)(.Rows(0)("reading_flag").ToString)
                End With

                Return reading
            End Using
        End Function

        Public Shared Function InsertStartMeterReading(ByVal meterReading As WaterMeterReading) As String
            With meterReading

                Using params As New OraParameter
                    params.AddParameter("meterid", .MeterID, OracleDbType.Int32, ParameterDirection.Input)
                    params.AddParameter("readingdate", .ReadingDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("actualreading", .Reading, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddItem("readingid", "", ParameterDirection.ReturnValue, OracleDbType.Int32)

                    Return DirectCast(OraDBHelper2.ExecuteFunction("watersystem.insertmeterreading", params.GetParameterCollection), OracleDecimal).ToString

                End Using


            End With


        End Function

        Public Shared Function InsertMeterReading(ByVal meterReading As WaterMeterReading) As String
            With meterReading

                Using params As New OraParameter
                    params.AddParameter("meterid", .MeterID, OracleDbType.Int32, ParameterDirection.Input)
                    params.AddParameter("readingdate", .ReadingDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("actualreading", .Reading, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("readingcu", .ReadingCu, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("readingadjustment", .ReadingAdjustment, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("readingstatus", EnumHelper.GetDBValue(.ReadingStatus), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("readingflag", EnumHelper.GetDBValue(.ReadingFlag), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("readingremarks", .ReadingRemarks, OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddItem("readingid", "", ParameterDirection.ReturnValue, OracleDbType.Int32)

                    Return DirectCast(OraDBHelper2.ExecuteFunction("watersystem.insertmeterreading", params.GetParameterCollection), OracleDecimal).ToString

                End Using


            End With


        End Function

        Public Shared Function UpdateMeterReading(ByVal meterReading As WaterMeterReading) As String
            With meterReading

                Using params As New OraParameter
                    params.AddParameter("readingid", .ReadingID, OracleDbType.Int32, ParameterDirection.Input)
                    params.AddParameter("readingdate", .ReadingDate, OracleDbType.Date, ParameterDirection.Input)
                    params.AddParameter("actualreading", .Reading, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("readingcu", .ReadingCu, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("readingadjustment", .ReadingAdjustment, OracleDbType.Decimal, ParameterDirection.Input)
                    params.AddParameter("readingstatus", EnumHelper.GetDBValue(.ReadingStatus), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("readingflag", EnumHelper.GetDBValue(.ReadingFlag), OracleDbType.Varchar2, ParameterDirection.Input)
                    params.AddParameter("readingremarks", .ReadingRemarks, OracleDbType.Varchar2, ParameterDirection.Input)

                    Return OraDBHelper2.ExecuteFunction("watersystem.updatemeterreading", params.GetParameterCollection)

                End Using


            End With


        End Function

        Public Shared Function GetReadingFlagDescription(ByVal flagCode As String) As String
            Return EnumHelper.GetDescription(EnumHelper.GetEnumValueFromDBValue(Of MeterReadingFlag)(flagCode))
        End Function

        Public Shared Function NextReadingDateAfterReconnection(ByVal reconnectionDate As Date) As Date

            Dim nextreading As Date = New Date(reconnectionDate.Year, reconnectionDate.Month, 1).AddMonths(1)

            If (nextreading - reconnectionDate).Days <= 20 Then
                Return nextreading.AddMonths(1)
            Else
                Return nextreading
            End If
        End Function
    End Class

    Public Class WaterMeterConnectionHistory

        Private _meterhistoryID As String

        Public Property MeterhistoryID() As String
            Get
                Return _meterhistoryID
            End Get
            Set(ByVal Value As String)
                _meterhistoryID = Value
            End Set
        End Property

        Private _changeDate As Date

        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(ByVal Value As Date)
                _changeDate = Value
            End Set
        End Property

        Private _remarks As String

        Public Property Remarks() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
            End Set
        End Property

        Public Shared Function GetConnectionHistory(ByVal meteriD As String) As DataTable

            Dim query As String = "SELECT changed_date, connection_status, remarks " & _
                                "  FROM utl_meter_connection_history             " & _
                                " WHERE meter_id = :meterid                      "

            Using params As New OraParameter
                params.AddParameter("meterid", meteriD, OracleDbType.Int32)

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function
    End Class

    Public Class ReadingMonth

        Public ReadOnly Property MonthYear() As String
            Get
                Return Month & Year
            End Get
        End Property

        Public ReadOnly Property MonthYearDescription() As String
            Get
                Return MonthName(Month).ToUpper & " " & Year
            End Get
        End Property

        Public ReadOnly Property ReadingDate() As Date
            Get
                Return New Date(Year, Month, 1)
            End Get
        End Property


        Private _month As Integer
        Public Property Month() As Integer
            Get
                Return _month
            End Get
            Set(ByVal value As Integer)
                _month = value
            End Set
        End Property

        Private _year As Integer
        Public Property Year() As Integer
            Get
                Return _year
            End Get
            Set(ByVal value As Integer)
                _year = value
            End Set
        End Property

        Public Sub New(ByVal month As Integer, ByVal year As Integer)
            Me.Month = month
            Me.Year = year
        End Sub

    End Class

    Public Class MeterReadingHelper

        Private _meterID As String
        Public Property MeterID() As String
            Get
                Return _meterID
            End Get
            Private Set(ByVal value As String)
                _meterID = value
            End Set
        End Property

        Private _previousReadingInfo As WaterSystem.WaterMeterReading
        Public Property PreviousReadingInfo() As WaterSystem.WaterMeterReading
            Get
                Return _previousReadingInfo
            End Get
            Private Set(ByVal value As WaterSystem.WaterMeterReading)
                _previousReadingInfo = value
            End Set
        End Property

        Private _presentReadingInfo As New WaterSystem.WaterMeterReading
        Public Property PresentReadingInfo() As WaterSystem.WaterMeterReading
            Get
                Return _presentReadingInfo
            End Get
            Private Set(ByVal value As WaterSystem.WaterMeterReading)
                _presentReadingInfo = value
            End Set
        End Property


        Public ReadOnly Property NextReadingDate() As Date
            Get
                Dim previous As Date = PreviousReadingInfo.ReadingDate
                'TODO must not be hardcode for 1
                Dim nextreading As Date = New Date(previous.Year, previous.Month, 1).AddMonths(1)

                Select Case PreviousReadingInfo.ReadingStatus
                    Case MeterReadingStatus.START
                        If (nextreading - PreviousReadingInfo.ReadingDate).Days <= 20 Then
                            PresentReadingInfo.ReadingDate = nextreading.AddMonths(1)
                        Else
                            PresentReadingInfo.ReadingDate = nextreading
                        End If
                    Case MeterReadingStatus.DISCONNECTION
                        'TODO. make a reconnection class helper
                        Dim reconnectionDate As Date
                        Dim lastconnstat As WaterSystem.MeterReadingStatus
                        WaterSystem.WaterMeter.IsMeterReconnected(Me.MeterID, reconnectionDate, lastconnstat)

                        nextreading = New Date(reconnectionDate.Year, reconnectionDate.Month, 1).AddMonths(1)


                        If (nextreading - reconnectionDate).Days <= 20 Then
                            PresentReadingInfo.ReadingDate = nextreading.AddMonths(1)
                        Else
                            PresentReadingInfo.ReadingDate = nextreading
                        End If
                    Case Else
                        PresentReadingInfo.ReadingDate = nextreading

                End Select

                Return PresentReadingInfo.ReadingDate
            End Get


        End Property


        Private _averageConsumption As Decimal

        Public Property AverageConsumption() As Decimal
            Get
                Return _averageConsumption
            End Get
            Private Set(ByVal value As Decimal)
                _averageConsumption = value
            End Set
        End Property

        Public ReadOnly Property AverageConsumptionMonths() As Integer
            Get
                'TODO.  Get param value from the parameters table for number of months
                Return 3
            End Get
        End Property

        Public ReadOnly Property ReadingCutoffDays() As Integer
            Get
                'TODO.  Get param value from the parameters table for number of months
                Return 20
            End Get
        End Property

        Public ReadOnly Property Consumption() As Decimal
            Get
                PresentReadingInfo.ReadingCu = GetConsumption()
                Return PresentReadingInfo.ReadingCu
            End Get
        End Property

        Private _isEntryValid As Boolean
        Public ReadOnly Property IsEntryValid() As Boolean
            Get
                Return _isEntryValid
            End Get
        End Property

        Public ReadOnly Property ReadingFlagDescription() As String
            Get
                Return EnumHelper.GetDescription(PresentReadingInfo.ReadingFlag)
            End Get
        End Property

        Public ReadOnly Property ConsumptionVariancePercentage() As Decimal
            Get
                Return 0.5
            End Get
        End Property

        Public Sub New(ByVal meterID As String)
            Me.MeterID = meterID
            PresentReadingInfo.MeterID = meterID

            PreviousReadingInfo = WaterSystem.WaterMeterReading.GetLastReadingInfo(meterID)

            AverageConsumption = WaterSystem.WaterMeter.GetAverageConsumption(meterID)
        End Sub

        Public Sub New(ByVal meterID As String, ByVal readingID As String)
            Me.MeterID = meterID

            PresentReadingInfo = WaterSystem.WaterMeterReading.GetReadingInfobyReadingID(readingID)
            PresentReadingInfo.MeterID = meterID

            PreviousReadingInfo = WaterSystem.WaterMeterReading.GetLastReadingInfo(meterID, PresentReadingInfo.ReadingDate)

            AverageConsumption = WaterSystem.WaterMeter.GetAverageConsumption(meterID, PresentReadingInfo.ReadingDate)
        End Sub


        Public Function GetValidReadingMonths() As List(Of ReadingMonth)

            Dim readingMonths As New List(Of ReadingMonth)

            Dim currentSystemDate As Date = New Date(Date.Now.Year, _
                                 Date.Now.Month, 1)

            Dim nreadate As Date = NextReadingDate
            While nreadate <= currentSystemDate
                readingMonths.Add(New ReadingMonth(nreadate.Month, nreadate.Year))

                nreadate = nreadate.AddMonths(1)
            End While


            Return readingMonths

        End Function

        Private Function GetConsumption() As Decimal
            Dim cons As Decimal = 0
            If PresentReadingInfo.ReadingStatus = MeterReadingStatus.NORMAL Then
                cons = PresentReadingInfo.Reading - PreviousReadingInfo.Reading
            Else
                cons = AverageConsumption
            End If

            cons += PresentReadingInfo.ReadingAdjustment


            If cons < 0 Then
                _isEntryValid = False
            Else
                _isEntryValid = True
            End If


            If PreviousReadingInfo.ReadingStatus = MeterReadingStatus.START Then
                PresentReadingInfo.ReadingFlag = MeterReadingFlag.BEGINNING
            Else
                If cons < 0 Then
                    PresentReadingInfo.ReadingFlag = MeterReadingFlag.NEGATIVE
                ElseIf cons = 0 Then
                    PresentReadingInfo.ReadingFlag = MeterReadingFlag.ZERO
                Else
                    Select Case cons
                        Case Is > AverageConsumption + (AverageConsumption * ConsumptionVariancePercentage)
                            PresentReadingInfo.ReadingFlag = MeterReadingFlag.HIGH
                        Case Is < AverageConsumption - (AverageConsumption * ConsumptionVariancePercentage)
                            PresentReadingInfo.ReadingFlag = MeterReadingFlag.LOW
                        Case Else
                            PresentReadingInfo.ReadingFlag = MeterReadingFlag.AVE
                    End Select
                End If
            End If


            Return cons
        End Function

        Public Function SaveReading() As String

            Return WaterSystem.WaterMeterReading.InsertMeterReading(PresentReadingInfo)

        End Function

        Public Function UpdateReading() As String
            If Me.PresentReadingInfo.ReadingStatus = MeterReadingStatus.AVERAGE Then
                Me.PresentReadingInfo.Reading = Me.PreviousReadingInfo.Reading
            End If

            Return WaterSystem.WaterMeterReading.UpdateMeterReading(PresentReadingInfo)

        End Function

    End Class
End Namespace
