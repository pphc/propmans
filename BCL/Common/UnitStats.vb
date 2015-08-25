Imports DALC

Namespace Common
    Public Class UnitStats

        Private _unitStat As DataTable
        Public ReadOnly Property UnitStat() As DataTable
            Get
                Return _unitStat
            End Get
        End Property

        Public Sub New()
            LoadUnitStat()
        End Sub

        Private Sub LoadUnitStat()

            Dim query As String = "SELECT bldg_id, bldg_number, bldg_name,                                            " & _
            "       (SELECT bldg_type_desc                                                      " & _
            "          FROM am_building_type                                                    " & _
            "         WHERE bldg_type_id = am.bldg_type_id) bldg_type,                          " & _
            "       (SELECT COUNT (unit_id)                                                     " & _
            "          FROM am_unit                                                             " & _
            "         WHERE unit_subclass <> 'PARK'                                             " & _
            "           AND floor_id IN (SELECT floor_id                                        " & _
            "                              FROM am_floor                                        " & _
            "                             WHERE CLUSTER_ID IN (SELECT CLUSTER_ID                " & _
            "                                                    FROM am_cluster                " & _
            "                                                   WHERE bldg_id = am.bldg_id)))   " & _
            "                                                                  condo_count,     " & _
            "       (SELECT COUNT (unit_id)                                                     " & _
            "          FROM am_unit                                                             " & _
            "         WHERE unit_subclass = 'PARK'                                              " & _
            "           AND floor_id IN (SELECT floor_id                                        " & _
            "                              FROM am_floor                                        " & _
            "                             WHERE CLUSTER_ID IN (SELECT CLUSTER_ID                " & _
            "                                                    FROM am_cluster                " & _
            "                                                   WHERE bldg_id = am.bldg_id)))   " & _
            "                                                                parking_count      " & _
            "  FROM am_building am                                                              "

            _unitStat = OraDBHelper2.GetResultSet(query)

        End Sub

        Public Function LoadCondoUnitStat() As DataTable

            Using dv As New DataView(_unitStat)

                dv.RowFilter = "condo_count <> 0"

                dv.Sort = "bldg_number"

                Return dv.ToTable()
            End Using

        End Function

        Public Function LoadParkingUnitStat() As DataTable
            Using dv As New DataView(_unitStat)

                dv.RowFilter = "parking_count <> 0"

                dv.Sort = "bldg_number"

                Return dv.ToTable()
            End Using

        End Function

        Public Function LoadStat(ByVal feeTypeID As String, ByVal billDate As Date) As DataTable
            Using param As New OraParameter
                param.AddParameter("feetypeid", feeTypeID, Oracle.DataAccess.Client.OracleDbType.Int32)
                param.AddParameter("billdate", billDate, Oracle.DataAccess.Client.OracleDbType.Date)
                param.AddParameter("billstat", "", Oracle.DataAccess.Client.OracleDbType.RefCursor, ParameterDirection.ReturnValue)
                Return OraDBHelper2.ExecuteProcedureRefCursor("billings.getbillstat", param.GetParameterCollection)
            End Using
        End Function

    End Class

End Namespace
