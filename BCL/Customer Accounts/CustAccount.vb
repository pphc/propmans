Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common

Namespace CustomerAccounts

    Public Class CustAccount

#Region "PROPERTIES"

        Public Property CustomerId As String
        Public Property AccountId As String
        Public Property CustId As String
        Public Property UnitId As String
        Public Property ProjectId As String
        Public Property UnitNo As String

        Public Property MoveInDate As Nullable(Of Date)
        Public Property TakeOutDate As Nullable(Of Date)
        Public Property CdStartDate As Nullable(Of Date)
        Public Property AtmDate As Nullable(Of Date)

        Public Property Occupant As String
        Public Property AccountStatus As String
        Public Property FinanceCode As String
        Public Property UnitSort As String
        Public Property UnitType As String
        Public Property UnitArea As String

        Public Property RentalManagement As String
        Public Property PaymentScheme As Nullable(Of UnitInventory.PaymentSchemeList)
        Public Property CondoDuesRate As String

        Public Property OrientationDate As Nullable(Of Date)
        Public Property InspectionDate As Nullable(Of Date)
        Public Property ReInspectionDate As Nullable(Of Date)
        Public Property AcceptanceDate As Nullable(Of Date)
        Public Property KeyTurnOverDate As Nullable(Of Date)
        Public Property PowerApplicationDate As Nullable(Of Date)
        Public Property WaterApplicationDate As Nullable(Of Date)
        Public Property MoveInFeePaymentDate As Nullable(Of Date)
        Public Property EarlyMoveinRequestDate As Nullable(Of Date)
        Public Property LivingFrequency As String
        Public Property AccountClass As String

#End Region

        Public Shared Function GetAccountsByCustomerId(ByVal customerID As String) As DataTable

            Dim query As String = "SELECT a.ACCOUNT_ID                        " & _
                                  "     , a.MOVE_IN_DATE                      " & _
                                  "     , a.TAKEOUT_DATE                      " & _
                                  "     , a.CD_START_DATE                     " & _
                                  "     , a.OCCUPANT                          " & _
                                  "     , CASE a.ACCOUNT_STATUS               " & _
                                  "            WHEN 'ACT' THEN 'ACTIVE'       " & _
                                  "            WHEN 'INACT' THEN 'INACTIVE'   " & _
                                  "       END ACCOUNT_STATUS                  " & _
                                  "     , a.CUST_FINANCE_CODE                 " & _
                                  "     , a.CUST_UNIT_SORT                    " & _
                                  "     , a.CUST_UNIT_NO                      " & _
                                  "     , a.CUST_UNIT_TYPE                    " & _
                                  "     , a.ACCT_CUST_ID                      " & _
                                  "     , a.RENTAL_MGT                        " & _
                                  "     , a.UNIT_ID                           " & _
                                  "     , a.PAYMENT_SCHEME                    " & _
                                  "     , a.CONDO_DUES_RATE                   " & _
                                  "     , a.ORIENTATION_DATE                  " & _
                                  "     , a.INSPECTION_DATE                   " & _
                                  "     , a.ACCEPTANCE_DATE                   " & _
                                  "     , a.KEY_TURN_OVER_DATE                " & _
                                  "     , POWER_APPLICATION_DATE              " & _
                                  "     , a.WATER_APPLICATION_DATE            " & _
                                  "     , a.LIVING_FREQUENCY                  " & _
                                  "     , a.ACCOUNT_CLASS                     " & _
                                  "     , b.UNIT_AREA  || ' SQM'   UNIT_AREA  " & _
                                  "      , a.ATM_DATE                         " & _
                                  "FROM CUSTOMER_ACCOUNTS a, AM_UNIT b        " & _
                                  "WHERE ACCT_CUST_ID = :customerID           " & _
                                  "AND a.UNIT_ID = b.UNIT_ID                  " & _
                                  "ORDER BY  a.CUST_UNIT_NO                   "

            Using param As New OraParameter

                param.AddItem("customerID", customerID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

        Public Shared Function GetAccountInfoByAccountId(ByVal accountId As String) As CustAccount 'DataTable

            Dim query As String = "SELECT   account_id, move_in_date, takeout_date, cd_start_date, ca.occupant, " & _
                        "         CASE account_status                                                 " & _
                        "            WHEN 'ACT'                                                       " & _
                        "               THEN 'ACTIVE'                                                 " & _
                        "            WHEN 'INACT'                                                     " & _
                        "               THEN 'INACTIVE'                                               " & _
                        "         END account_status,                                                 " & _
                        "         cust_finance_code, cust_unit_sort, cust_unit_no, cust_unit_type,    " & _
                        "         acct_cust_id, rental_mgt, au.unit_id, payment_scheme,               " & _
                        "         condo_dues_rate, orientation_date, inspection_date, acceptance_date," & _
                        "         key_turn_over_date, power_application_date, water_application_date, " & _
                        "         living_frequency, account_class, unit_area || ' SQM' unit_area,     " & _
                        "         atm_date, early_move_in_request_date, move_in_fee_payment_date      " & _
                        "    FROM customer_accounts ca JOIN am_unit au ON (ca.unit_id = au.unit_id)   " & _
                        "   WHERE account_id = :accountid                                             " & _
                        "ORDER BY cust_unit_no                                                        "

            Dim CustAccount As New CustAccount

            CustAccount.AccountId = accountId

            Using param As New OraParameter

                param.AddItem(":accountId", accountId, OracleDbType.BinaryDouble)

                With OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

                    CustAccount.AccountId = .Rows(0)("ACCOUNT_ID").ToString

                    If Not Convert.IsDBNull(.Rows(0)("MOVE_IN_DATE")) Then
                        CustAccount.MoveInDate = Date.Parse(.Rows(0)("MOVE_IN_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("TAKEOUT_DATE")) Then
                        CustAccount.TakeOutDate = Date.Parse(.Rows(0)("TAKEOUT_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("CD_START_DATE")) Then
                        CustAccount.CdStartDate = Date.Parse(.Rows(0)("CD_START_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("ATM_DATE")) Then
                        CustAccount.AtmDate = Date.Parse(.Rows(0)("ATM_DATE").ToString)
                    End If

                    CustAccount.Occupant = .Rows(0)("OCCUPANT").ToString

                    CustAccount.AccountStatus = .Rows(0)("ACCOUNT_STATUS").ToString

                    CustAccount.FinanceCode = .Rows(0)("CUST_FINANCE_CODE").ToString

                    CustAccount.UnitSort = .Rows(0)("CUST_UNIT_SORT").ToString

                    CustAccount.UnitNo = .Rows(0)("CUST_UNIT_NO").ToString

                    CustAccount.UnitType = .Rows(0)("CUST_UNIT_TYPE").ToString
                    CustAccount.UnitArea = .Rows(0)("UNIT_AREA").ToString

                    CustAccount.CustId = .Rows(0)("ACCT_CUST_ID").ToString

                    CustAccount.RentalManagement = .Rows(0)("RENTAL_MGT").ToString

                    CustAccount.UnitId = .Rows(0)("UNIT_ID").ToString

                    If Not Convert.IsDBNull(.Rows(0)("PAYMENT_SCHEME")) Then
                        CustAccount.PaymentScheme = EnumHelper.GetEnumValueFromDBValue(Of UnitInventory.PaymentSchemeList)(.Rows(0)("PAYMENT_SCHEME").ToString)
                    Else

                    End If


                    CustAccount.CondoDuesRate = .Rows(0)("CONDO_DUES_RATE").ToString

                    If Not Convert.IsDBNull(.Rows(0)("ORIENTATION_DATE")) Then
                        CustAccount.OrientationDate = Date.Parse(.Rows(0)("ORIENTATION_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("INSPECTION_DATE")) Then
                        CustAccount.InspectionDate = Date.Parse(.Rows(0)("INSPECTION_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("KEY_TURN_OVER_DATE")) Then
                        CustAccount._KeyTurnOverDate = Date.Parse(.Rows(0)("KEY_TURN_OVER_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("ACCEPTANCE_DATE")) Then
                        CustAccount.AcceptanceDate = Date.Parse(.Rows(0)("ACCEPTANCE_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("POWER_APPLICATION_DATE")) Then
                        CustAccount.PowerApplicationDate = Date.Parse(.Rows(0)("POWER_APPLICATION_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("WATER_APPLICATION_DATE")) Then
                        CustAccount.WaterApplicationDate = Date.Parse(.Rows(0)("WATER_APPLICATION_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("EARLY_MOVE_IN_REQUEST_DATE")) Then
                        CustAccount.EarlyMoveinRequestDate = Date.Parse(.Rows(0)("EARLY_MOVE_IN_REQUEST_DATE").ToString)
                    End If

                    If Not Convert.IsDBNull(.Rows(0)("MOVE_IN_FEE_PAYMENT_DATE")) Then
                        CustAccount.MoveInFeePaymentDate = Date.Parse(.Rows(0)("MOVE_IN_FEE_PAYMENT_DATE").ToString)
                    End If

                    CustAccount.LivingFrequency = .Rows(0)("LIVING_FREQUENCY").ToString

                    CustAccount.AccountClass = .Rows(0)("ACCOUNT_CLASS").ToString

                End With

            End Using

            Return CustAccount

        End Function

        Public Shared Function UpdateUnitInformation(ByVal updateRecord As CustAccount) As String

            With updateRecord

                Dim query As String = "UPDATE CUSTOMER_ACCOUNTS                               " & _
                                      "SET ORIENTATION_DATE          = :OrientationDate       " & _
                                      "  , INSPECTION_DATE           = :InspectionDate        " & _
                                      "  , PAYMENT_SCHEME           = :PaymentScheme        " & _
                                      "  , TAKEOUT_DATE           = :TakeoutDate        " & _
                                      "  , MOVE_IN_FEE_PAYMENT_DATE  = :MoveinFeePayment        " & _
                                        "  , ATM_DATE  = :Atmdate        " & _
                                    "  , EARLY_MOVE_IN_REQUEST_DATE  = :Earlymoveindate        " & _
                                      "  , ACCEPTANCE_DATE           = :AcceptanceDate        " & _
                                      "  , KEY_TURN_OVER_DATE        = :KeyTurnOverDate       " & _
                                      "  , POWER_APPLICATION_DATE    = :PowerAgreementDate  " & _
                                      "  , CD_START_DATE             = :CdStartDate  " & _
                                      "WHERE ACCOUNT_ID              = :AccountId             "

                Using params As New OraParameter

                    params.AddParameter("AccountId", .AccountId, OracleDbType.Varchar2)
                    If .PaymentScheme.HasValue Then
                        params.AddParameter("PaymentScheme", EnumHelper.GetDBValue(.PaymentScheme.Value), OracleDbType.Varchar2)
                    Else
                        params.AddParameter("PaymentScheme", Nothing, OracleDbType.Varchar2)
                    End If

                    params.AddParameter("TakeoutDate", .TakeOutDate, OracleDbType.Date)
                    params.AddParameter("MoveinFeePayment", .MoveInFeePaymentDate, OracleDbType.Date)
                    params.AddParameter("Atmdate", .AtmDate, OracleDbType.Date)
                    params.AddParameter("Earlymoveindate", .EarlyMoveinRequestDate, OracleDbType.Date)
                    params.AddParameter("OrientationDate", .OrientationDate, OracleDbType.Date)
                    params.AddParameter("InspectionDate", .InspectionDate, OracleDbType.Date)
                    params.AddParameter("AcceptanceDate", .AcceptanceDate, OracleDbType.Date)
                    params.AddParameter("KeyTurnOverDate", .KeyTurnOverDate, OracleDbType.Date)
                    params.AddParameter("CdStartDate", .CdStartDate, OracleDbType.Date)
                    params.AddParameter("PowerAgreementDate", .PowerApplicationDate, OracleDbType.Date)

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

        Public Shared Function GetHouseholdMemberByAccountId(ByVal accountId As String) As DataTable

            Dim query As String = "SELECT MEMBER_ID                " & _
                                  "     , HOUSEHOLD_NAME           " & _
                                  "     , BIRTH_DATE               " & _
                                  "     , OCCUPATION               " & _
                                  "     , OWNER_RELATION           " & _
                                  "     , ACCOUNT_ID               " & _
                                  "     , MOVE_IN_DATE             " & _
                                  "     , MOVE_OUT_DATE            " & _
                                  "FROM AM_HOUSEHOLD_MEMBER        " & _
                                  "WHERE ACCOUNT_ID = :accountId   " & _
                                  "ORDER BY MEMBER_ID ASC          "

            Using param As New OraParameter

                param.AddItem("accountId", accountId, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

    End Class

End Namespace