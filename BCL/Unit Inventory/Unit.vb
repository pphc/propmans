Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DALC
Imports BCL.Utils
Imports BCL.Common


Namespace UnitInventory
    Public Class Unit

#Region "PROPERTIES"

        Private _floorId As String

        Public Property FloorId() As String
            Get
                Return _floorId
            End Get
            Set(ByVal Value As String)
                _floorId = Value
            End Set
        End Property

        Private _unitId As String

        Public Property UnitId() As String
            Get
                Return _unitId
            End Get
            Set(ByVal Value As String)
                _unitId = Value
            End Set
        End Property

        Private _typeId As String

        Public Property TypeId() As String
            Get
                Return _typeId
            End Get
            Set(ByVal Value As String)
                _typeId = Value
            End Set
        End Property

        Private _phase As String

        Public Property Phase() As String
            Get
                Return _phase
            End Get
            Set(ByVal Value As String)
                _phase = Value
            End Set
        End Property

        Private _bldg As String

        Public Property Bldg() As String
            Get
                Return _bldg
            End Get
            Set(ByVal Value As String)
                _bldg = Value
            End Set
        End Property

        Private _cluster As String

        Public Property Cluster() As String
            Get
                Return _cluster
            End Get
            Set(ByVal Value As String)
                _cluster = Value
            End Set
        End Property

        Private _floor As String

        Public Property Floor() As String
            Get
                Return _floor
            End Get
            Set(ByVal Value As String)
                _floor = Value
            End Set
        End Property

        Private _number As String

        Public Property Number() As String
            Get
                Return _number
            End Get
            Set(ByVal Value As String)
                _number = Value
            End Set
        End Property

        Private _area As String

        Public Property Area() As String
            Get
                Return _area
            End Get
            Set(ByVal Value As String)
                _area = Value
            End Set
        End Property

        Private _subClass As UnitSubClass

        Public Property SubClass() As UnitSubClass
            Get
                Return _subClass
            End Get
            Set(ByVal Value As UnitSubClass)
                _subClass = Value
            End Set
        End Property

        Private _saleStatus As SaleStatusList

        Public Property SaleStatus() As SaleStatusList
            Get
                Return _saleStatus
            End Get
            Set(ByVal Value As SaleStatusList)
                _saleStatus = Value
            End Set
        End Property

        Private _rfoDate As Nullable(Of Date)

        Public Property RfoDate() As Nullable(Of Date)
            Get
                Return _rfoDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _rfoDate = Value
            End Set
        End Property

        Private _occupancyStatus As OccupancyStatuslist

        Public Property OccupancyStatus() As OccupancyStatuslist
            Get
                Return _occupancyStatus
            End Get
            Set(ByVal Value As OccupancyStatuslist)
                _occupancyStatus = Value
            End Set
        End Property

        Private _occupant As OccupantList

        Public Property Occupant() As OccupantList
            Get
                Return _occupant
            End Get
            Set(ByVal Value As OccupantList)
                _occupant = Value
            End Set
        End Property

        Private _occupancyDate As Nullable(Of Date)

        Public Property OccupancyDate() As Nullable(Of Date)
            Get
                Return _occupancyDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _occupancyDate = Value
            End Set
        End Property

        Private _description As String

        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Private _sqmArea As String

        Public Property SqmArea() As String
            Get
                Return _sqmArea
            End Get
            Set(ByVal Value As String)
                _sqmArea = Value
            End Set
        End Property

        Private _owner As String

        Public Property Owner() As String
            Get
                Return _owner
            End Get
            Set(ByVal Value As String)
                _owner = Value
            End Set
        End Property

        Private _duesRate As Nullable(Of Decimal)

        Public Property DuesRate() As Nullable(Of Decimal)
            Get
                Return _duesRate
            End Get
            Set(ByVal Value As Nullable(Of Decimal))
                _duesRate = Value
            End Set
        End Property

#End Region

        Public Shared Function GetUnitsByFloorID(ByVal floorID As String) As DataTable

            Dim query As String = "SELECT a.FLOOR_ID                                                                                                   " & _
                                    ", a.UNIT_ID                                                                                                       " & _
                                    ", a.UNIT_NUMBER                                                                                                   " & _
                                    ", a.UNIT_AREA || ' SQM' UNIT_AREA                                                                                 " & _
                                    ", a.UNIT_SUBCLASS                                                                                                 " & _
                                    ", accounts.getcurrentunitowner(a.unit_id) CUSTOMER_NAME                                                           " & _
                                    ", a.SALE_STATUS                                                                                                   " & _
                                    ", a.RFO_DATE                                                                                                      " & _
                                    ", DECODE(a.OCCUPANCY_STATUS,'OCC','OCCUPIED','VACANT') occupancy_status                                                                                              " & _
                                    ", a.OCCUPANT                                                                                                      " & _
                                    ", a.OCCUPANCY_DATE                                                                                                " & _
                                    ", a.FLOOR_ID                                                                                                      " & _
                                    ", a.UNIT_TYPE_ID                                                                                                  " & _
                                    ", b.UNIT_DESCRIPTION                                                                                              " & _
                                    "FROM AM_UNIT a, AM_UNIT_TYPE b                                                                                    " & _
                                    "WHERE a.UNIT_TYPE_ID = b.UNIT_TYPE_ID                                                                             " & _
                                    "AND a.FLOOR_ID = :floorID                                                                                         " & _
                                    "ORDER BY a.UNIT_NO ASC"
            Using param As New OraParameter

                param.AddItem(":floorID", floorID, OracleDbType.Int32)
                Return OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

            End Using

        End Function

        Public Shared Function GetUnitsByUnitID(ByVal unitID As String) As Unit

            Dim query As String = "SELECT UNIT_ID                                               " & _
                                    ", UNIT_NUMBER                                              " & _
                                    ", UNIT_AREA || ' SQM' UNIT_AREA                            " & _
                                    ", UNIT_SUBCLASS                                            " & _
                                    ", SALE_STATUS                                              " & _
                                    ", accounts.getcurrentunitowner(unit_id) CUSTOMER_NAME      " & _
                                    ", RFO_DATE                                                 " & _
                                    ", OCCUPANCY_STATUS                                         " & _
                                    ", OCCUPANT                                                 " & _
                                    ", OCCUPANCY_DATE                                           " & _
                                    ", UNIT_TYPE_ID                                             " & _
                                    "FROM AM_UNIT                                               " & _
                                    "WHERE UNIT_ID = :unitID                                    " & _
                                    "ORDER BY UNIT_NUMBER ASC                                   "

            Dim unitinfo As New Unit
            unitinfo.UnitID = unitID


            Using param As New OraParameter

                param.AddItem(":unitID", unitID, OracleDbType.Varchar2)
                With OraDBHelper2.GetResultSet(query, param.GetParameterCollection)

                    unitinfo.UnitID = .Rows(0)("UNIT_ID").ToString

                    unitinfo.Number = .Rows(0)("UNIT_NUMBER").ToString

                    unitinfo.Area = .Rows(0)("UNIT_AREA").ToString

                    unitinfo.Owner = .Rows(0)("CUSTOMER_NAME").ToString

                    If Not Convert.IsDBNull(.Rows(0)("UNIT_SUBCLASS")) Then

                        unitinfo.SubClass = EnumHelper.GetEnumValueFromDBValue(Of UnitSubClass)(.Rows(0)("UNIT_SUBCLASS").ToString)

                    End If

                    If Not Convert.IsDBNull(.Rows(0)("SALE_STATUS")) Then

                        unitinfo.SaleStatus = EnumHelper.GetEnumValueFromDBValue(Of SaleStatusList)(.Rows(0)("SALE_STATUS").ToString)

                    End If

                    If Not Convert.IsDBNull(.Rows(0)("OCCUPANCY_STATUS")) Then

                        unitinfo.OccupancyStatus = EnumHelper.GetEnumValueFromDBValue(Of OccupancyStatuslist)(.Rows(0)("OCCUPANCY_STATUS").ToString)

                    End If

                    If Not Convert.IsDBNull(.Rows(0)("OCCUPANT")) Then

                        unitinfo.Occupant = EnumHelper.GetEnumValueFromDBValue(Of OccupantList)(.Rows(0)("OCCUPANT").ToString)

                    End If


                    If Not Convert.IsDBNull(.Rows(0)("RFO_DATE")) Then

                        unitinfo.RfoDate = Date.Parse(.Rows(0)("RFO_DATE"))

                    End If

                    If Not Convert.IsDBNull(.Rows(0)("OCCUPANCY_DATE")) Then

                        unitinfo.OccupancyDate = Date.Parse(.Rows(0)("OCCUPANCY_DATE"))

                    End If

                    unitinfo.TypeId = .Rows(0)("UNIT_TYPE_ID").ToString

                End With

            End Using

            Return unitinfo

        End Function

        Public Shared Function UpdateUnitInventory(ByVal updateRecord As Unit) As String

            With updateRecord

                Dim query As String = "UPDATE am_unit                             " & _
                                      "SET rfo_date = :rfoDate                    " & _
                                      "  , occupancy_status = :occupancyStatus    " & _
                                      "  , occupancy_date = :occupancyDate        " & _
                                      "  , occupant= :occupant                    " & _
                                      "WHERE unit_id = :UnitID            "



                Using params As New OraParameter

                    params.AddParameter("UnitID", .UnitId, OracleDbType.Varchar2)
                    params.AddParameter("rfoDate", .RfoDate, OracleDbType.Date)
                    params.AddParameter("occupancyStatus", EnumHelper.GetDBValue(.OccupancyStatus), OracleDbType.Varchar2)
                    params.AddParameter("occupancyDate", .OccupancyDate, OracleDbType.Date)
                    params.AddParameter("occupant", EnumHelper.GetDBValue(.Occupant), OracleDbType.Varchar2)

                    Return OraDBHelper2.SqlExecute(query, params.GetParameterCollection)

                End Using

            End With

        End Function

    End Class

End Namespace
