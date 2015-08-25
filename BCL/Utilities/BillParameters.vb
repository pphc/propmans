Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports System.Text
Imports BCL.Utils

Namespace Utilities

    Public Enum RateClass
        <EnumDescription("RESIDENTIAL")> _
        <EnumDBValue("RES")> _
        Residential
        <EnumDescription("COMMERCIAL")> _
        <EnumDBValue("COMM")> _
        Commercial
    End Enum

    Public Class WaterBillParameter

        Private _paramID As String

        Public Property ParamID() As String
            Get
                Return _paramID
            End Get
            Set(ByVal Value As String)
                _paramID = Value
            End Set
        End Property


        Private _effectiveDate As Date

        Public Property EffectiveDate() As Date
            Get
                Return _effectiveDate
            End Get
            Set(ByVal Value As Date)
                _effectiveDate = Value
            End Set
        End Property

        Private _effectiveUntil As Nullable(Of Date)

        Public Property EffectiveUntil() As Nullable(Of Date)
            Get
                Return _effectiveUntil
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _effectiveUntil = Value
            End Set
        End Property


        Private _minConsumption As Decimal

        Public Property MinConsumption() As Decimal
            Get
                Return _minConsumption
            End Get
            Set(ByVal value As Decimal)
                _minConsumption = value
            End Set
        End Property


        Private _minCharge As Decimal

        Public Property MinCharge() As Decimal
            Get
                Return _minCharge
            End Get
            Set(ByVal value As Decimal)
                _minCharge = value
            End Set
        End Property

        Private _rate As Decimal
        Public Property Rate() As Decimal
            Get
                Return _rate
            End Get
            Set(ByVal value As Decimal)
                _rate = value
            End Set
        End Property

        Private _withConsumptionBlock As Boolean
        Public Property WithConsumptionBlock() As Boolean
            Get
                Return _withConsumptionBlock
            End Get
            Set(ByVal value As Boolean)
                _withConsumptionBlock = value
            End Set
        End Property


        Public Shared Function GetAllWaterBillParameters() As DataTable

            Dim query As String = "SELECT bill_param_id, effective_date, effective_until, min_consumption," & _
                                    "       min_charge, rate, w_cons_table                                  " & _
                                    "  FROM utl_water_bill_parameter                                        " & _
                                    "  order by 2 desc                                                      "

            Return OraDBHelper2.GetResultSet(query)

        End Function

        Public Shared Function IsParameterReferenced(ByVal paramid As String) As Boolean

            Dim query As String = "SELECT COUNT (reading_id)                                                   " & _
                            "  FROM utl_meter_reading                                                    " & _
                            " WHERE bill_param_id = :paramid AND reading_status NOT IN ('START', 'DISC') "

            Using params As New OraParameter
                params.AddParameter(":paramid", paramid)
                Dim count As Integer = Integer.Parse(OraDBHelper2.SqlExecuteScalar(query, params.GetParameterCollection).ToString)


                Return IIf(count = 0, False, True)
            End Using

        End Function

        Public Shared Function GetNextEffectiveMonth() As Nullable(Of Date)

            Dim query As String = "SELECT effective_date, effective_until                   " & _
                                "  FROM utl_water_bill_parameter                          " & _
                                " WHERE effective_date = (SELECT MAX (effective_date)     " & _
                                "                           FROM utl_water_bill_parameter)"

            Dim effectiveMonth As Nullable(Of Date)

            With OraDBHelper2.GetResultSet(query)
                If .Rows.Count > 0 Then
                    If Convert.IsDBNull(.Rows(0)("effective_until")) Then
                        effectiveMonth = Date.Parse(.Rows(0)("effective_date")).AddMonths(1)
                    Else
                        effectiveMonth = Date.Parse(.Rows(0)("effective_until")).AddMonths(1)
                    End If

                End If

            End With

            Return effectiveMonth
        End Function

        Public Function InsertParameter() As Integer
            Dim query As String = "INSERT INTO utl_water_bill_parameter                                       " & _
                            "            (effective_date, effective_until, min_consumption, min_charge, " & _
                            "             rate, w_cons_table                                            " & _
                            "            )                                                              " & _
                            "     VALUES (:effectivedate, :effectiveuntil, :minconsumption, :mincharge, " & _
                            "             :rate, :wconstable                                            " & _
                            "            )                                                              "

            Using params As New OraParameter
                params.AddParameter(":effectivedate", Me.EffectiveDate, OracleDbType.Date)
                params.AddParameter(":effectiveuntil", Me.EffectiveUntil, OracleDbType.Date)
                params.AddItem(":minconsumption", Me.MinConsumption, OracleDbType.Decimal)
                params.AddItem(":mincharge", Me.MinCharge, OracleDbType.Decimal)
                params.AddItem(":rate", Me.Rate, OracleDbType.Decimal)
                params.AddItem(":wconstable", IIf(Me.WithConsumptionBlock, "Y", "N"))

                Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)
            End Using
        End Function


        Public Function UpdateParameter() As Integer
            Dim query As String = "UPDATE utl_water_bill_parameter            " & _
                                "   SET min_consumption = :minconsumption, " & _
                                "       min_charge = :mincharge,           " & _
                                "       rate = :rate,                       " & _
                                "       w_cons_table = :wconstable        " & _
                                " WHERE bill_param_id = :paramid      "

            Using params As New OraParameter
                params.AddParameter(":paramid", Me.ParamID)
                ' params.AddParameter(":effectivedate", Me.EffectiveDate, OracleDbType.Date)
                'params.AddParameter(":effectiveuntil", Me.EffectiveUntil, OracleDbType.Date)
                params.AddItem(":minconsumption", Me.MinConsumption, OracleDbType.Decimal)
                params.AddItem(":mincharge", Me.MinCharge, OracleDbType.Decimal)
                params.AddItem(":rate", Me.Rate, OracleDbType.Decimal)
                params.AddItem(":wconstable", IIf(Me.WithConsumptionBlock, "Y", "N"))

                Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)
            End Using
        End Function

        'Public Shared Function IsPeriodExist(ByVal period As Date) As Boolean
        '    Using params As New OraParameter
        '        params.AddItem(":period", period, OracleDbType.Date)

        '        Dim x As Integer = OraDBHelper2.SqlExecuteScalar(SelectStatement.IsBillPeriodExist, params.GetParameterCollection)
        '        If x > 0 Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    End Using
        'End Function

        'Public Shared Function GetBillingMonth() As Date

        '    Using params As New OraParameter
        '        params.AddItem(":billmonth", "", ParameterDirection.ReturnValue, OracleDbType.Date)

        '        With DirectCast(OraDBHelper2.FunctionExecute("getlastbillingparametermonth", params.GetParameterCollection), OracleDate)
        '            If .IsNull Then
        '                Return Now.Date
        '            Else
        '                Return .Value.AddMonths(1)
        '            End If
        '        End With

        '    End Using

        'End Function

        'Public Shared Function AreAllReadingInputted(ByVal period As Date) As Boolean
        '    Using params As New OraParameter
        '        params.AddItem(":period", period, OracleDbType.Date)

        '        If OraDBHelper2.SqlExecuteScalar(SelectStatement.GetMeterWithoutReading, params.GetParameterCollection) > 0 Then
        '            Return False
        '        Else
        '            Return True
        '        End If
        '    End Using
        'End Function


    End Class

    Public Class WaterConsumptionBlock
        Private _rateID As String
        Public Property RateID() As String
            Get
                Return _rateID
            End Get
            Set(ByVal value As String)
                _rateID = value
            End Set
        End Property

        Private _from As Decimal
        Public Property FromConsumption() As Decimal
            Get
                Return _from
            End Get
            Set(ByVal value As Decimal)
                _from = value
            End Set
        End Property

        Private _to As Decimal
        Public Property ToConsumption() As Decimal
            Get
                Return _to
            End Get
            Set(ByVal value As Decimal)
                _to = value
            End Set
        End Property

        Private _rate As Decimal
        Public Property Rate() As Decimal
            Get
                Return _rate
            End Get
            Set(ByVal value As Decimal)
                _rate = value
            End Set
        End Property

        Private _minRate As Boolean
        Public Property MinRate() As Boolean
            Get
                Return _minRate
            End Get
            Set(ByVal value As Boolean)
                _minRate = value
            End Set
        End Property


        Private _rateClass As RateClass
        Public Property RateClass() As RateClass
            Get
                Return _rateClass
            End Get
            Set(ByVal value As RateClass)
                _rateClass = value
            End Set
        End Property

        Public Shared Function GetConsumptionTables(ByVal paramID As String, ByVal rateClass As RateClass) As DataTable

            Dim query As String = "SELECT rate_id, from_cons, to_cons, rate, min_rate          " & _
                            "  FROM utl_water_rate                                       " & _
                            " WHERE bill_param_id = :paramid AND rate_class = :rateclass "

            Using params As New OraParameter
                params.AddParameter("paramid", paramID)
                params.AddParameter("rateclass", EnumHelper.GetDBValue(rateClass))

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function

        Public Shared Function GetConsumptionTables(ByVal paramID As String) As DataTable

            Dim query As String = "SELECT rate_id, from_cons, to_cons, rate, min_rate,rate_class          " & _
                            "  FROM utl_water_rate                                       " & _
                            " WHERE bill_param_id = :paramid"

            Using params As New OraParameter
                params.AddParameter("paramid", paramID)

                Return OraDBHelper2.GetResultSet(query, params.GetParameterCollection)
            End Using

        End Function


    End Class

End Namespace
