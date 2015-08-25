using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using DALC;
using EnumLib;

namespace PROPMANS.BL.AccountManagement
{
    public class UnitInventoryDA
    {
        #region LIST
        private List<Phase> _phase;
        public List<Phase> Phases { get { return _phase; } }

        private List<BuildingType> _bldgType;
        public List<BuildingType> BuildingTypes { get { return _bldgType; } }

        private List<UnitType> _unitType;
        public List<UnitType> UnitTypes { get { return _unitType; } }

        private List<Building> _building;
        public List<Building> Buildings { get { return _building; } }

        private List<Cluster> _cluster;
        public List<Cluster> Clusters { get { return _cluster; } }

        private List<Floor> _floor;
        public List<Floor> Floors { get { return _floor; } }

        private List<Unit> _unit;
        public List<Unit> Units { get { return _unit; } }

        #endregion

        public UnitInventoryDA()
        {
            LoadPhases();
            LoadBuildingTypes();
            LoadUnitTypes();
            LoadBuildings();
            LoadClusters();
            LoadFloors();
            LoadUnits();
        }

        #region FUNCTIONS

        private void LoadPhases()
        {
            _phase = new List<Phase>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("units.getphases", param.GetParameterCollection()).Rows)
                {
                    _phase.Add(new Phase
                    {
                        PhaseID = row["PHASE_ID"].ToString(),
                        PhaseName = row["PHASE_NAME"].ToString(),
                        PhaseNumber = row["PHASE_NUMBER"].ToString(),
                        PhaseRemarks = row["REMARKS"].ToString(),
                    });
                }
            }
        }

        private void LoadBuildingTypes()
        {
            _bldgType = new List<BuildingType>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("units.getbuildingtypes", param.GetParameterCollection()).Rows)
                {
                    _bldgType.Add(new BuildingType
                    {
                        BldgTypeID = row["BLDG_TYPE_ID"].ToString(),
                        BldgTypeDesc = row["BLDG_TYPE_DESC"].ToString()
                    });
                }
            }
        }

        private void LoadUnitTypes()
        {
            _unitType = new List<UnitType>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("units.getunittypes", param.GetParameterCollection()).Rows)
                {
                    _unitType.Add(new UnitType
                    {
                        UnitTypeID = row["UNIT_TYPE_ID"].ToString(),
                        UnitDescription = row["UNIT_DESCRIPTION"].ToString(),
                        UnitSQM = row["UNIT_SQM_AREA"].ToString(),
                        UnitDuesRate = row["UNIT_DUES_RATE"].ToString()
                    });
                }
            }
        }

        private void LoadBuildings()
        {
            _building = new List<Building>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("units.getbuildings", param.GetParameterCollection()).Rows)
                {
                    
                    _building.Add(new Building
                    {
                        BuildingID = row["BLDG_ID"].ToString(),
                        BuildingName = row["BLDG_NAME"].ToString(),
                        BuildingNumber = row["BLDG_NUMBER"].ToString(),
                        BldgPhase = GetBuildingPhase(row["PHASE_ID"].ToString()),
                        BldgType = GetBuildingType((row["BLDG_TYPE_ID"].ToString()))
                    });
                }
            }
        }

        private void LoadClusters()
        {

            _cluster = new List<Cluster>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("units.getclusters", param.GetParameterCollection()).Rows)
                {
                    _cluster.Add(new Cluster
                    {
                        ClusterID = row["CLUSTER_ID"].ToString(),
                        ClusterName = row["CLUSTER_NAME"].ToString(),
                        ClusterNumber = row["CLUSTER_NUMBER"].ToString(),
                        CLusterBldg = GetBuildingCluster(row["BLDG_ID"].ToString())
                    });
                }
            }
        }

        private void LoadFloors()
        {
            _floor = new List<Floor>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("units.getfloors", param.GetParameterCollection()).Rows)
                {
                    _floor.Add(new Floor
                    {
                        FloorID = row["FLOOR_ID"].ToString(),
                        FloorName = row["FLOOR_NAME"].ToString(),
                        FloorNumber = row["FLOOR_NUMBER"].ToString(),
                        FloorCluster = GetFloorCluster(row["CLUSTER_ID"].ToString())
                    });
                }
            }
        }

        private void LoadUnits()
        {
            _unit = new List<Unit>();
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("refcursor", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                foreach (DataRow row in OraDBHelper2.ExecuteProcedureRefCursor("units.getunits", param.GetParameterCollection()).Rows)
                {
                    _unit.Add(new Unit
                    {
                        UnitID = row["UNIT_ID"].ToString(),
                        UnitPhaseNo = row["PHASE_NO"].ToString(),
                        UnitBuildingNo = row["BLDG_NO"].ToString(),
                        UnitClusterNo = row["CLUSTER_NO"].ToString(),
                        UnitFoorNo = row["FLOOR_NO"].ToString(),
                        UnitNo = row["UNIT_NO"].ToString(),
                        UnitNumber = row["UNIT_NUMBER"].ToString(),
                        UnitArea = row["UNIT_AREA"].ToString(),
                        SubClass = EnumExtensions.Entry<UnitSubClass>(row["UNIT_SUBCLASS"].ToString()),
                        SaleStatus = EnumExtensions.Entry<SaleStatus>(row["SALE_STATUS"].ToString()),
                        RFODate = GetDate(row["RFO_Date"]),
                        OccupancyStatus = EnumExtensions.Entry<OccupancyStatus>(row["OCCUPANCY_STATUS"].ToString()),
                        Occupant = EnumExtensions.Entry<Occupant>(row["OCCUPANT"].ToString()),
                        OccupancyDate = GetDate(row["OCCUPANCY_DATE"]),
                        CMDTurnOverDate = GetDate(row["CMD_TURNOVER"]),
                        UnitFloor = GetUnitFloor(row["FLOOR_ID"].ToString()),
                        UnitType = GetUnitType(row["UNIT_TYPE_ID"].ToString())
                    });
                }

            }
        }

        private DateTime? GetDate(object obj)
        {
            DateTime? datevalue = null;
            if (!Convert.IsDBNull(obj))
            {
                datevalue = DateTime.Parse(obj.ToString());
            }
            return datevalue;
        }

        public Int32 UpdateUnit(Unit unit, OccupancyStatus OccupancyStatus, Occupant Occupant)
        {
            using (OraParameter param = new OraParameter())
            {
                param.AddParameter("unitid", unit.UnitID);
                //param.AddParameter("KEY_TURN_OVER_DATE", null);
                param.AddParameter("occupancystatus", OccupancyStatus.DBVAlue());
                param.AddParameter("occ", Occupant.DBVAlue());
                param.AddParameter("retnumber", null, OracleDbType.Int32, ParameterDirection.ReturnValue);

                return (Int32)((OracleDecimal)OraDBHelper2.ExecuteFunction("UNITS.UpdateUnit", param.GetParameterCollection()));
            }
        }

        #endregion

        #region PRIVATE FUNCTIONS (LINQ)
        private Phase GetBuildingPhase(string phaseID)
        {

            return (from Phase phase in Phases
                    where phase.PhaseID.Equals(phaseID)
                    select phase).SingleOrDefault();
        }

        private BuildingType GetBuildingType(string bldgTypeID)
        {
            return (from BuildingType bldgType in BuildingTypes
                    where bldgType.BldgTypeID.Equals(bldgTypeID)
                    select bldgType).SingleOrDefault();
        }

        private Building GetBuildingCluster(string bldgID)
        {
            return (from Building bldg in Buildings
                    where bldg.BuildingID.Equals(bldgID)
                    select bldg).SingleOrDefault();
        }

        private Cluster GetFloorCluster(string clusterID)
        {
            return (from Cluster cluster in Clusters
                    where cluster.ClusterID.Equals(clusterID)
                    select cluster).SingleOrDefault();
        }

        private Floor GetUnitFloor(string floorID)
        {
            return (from Floor floor in Floors
                    where floor.FloorID.Equals(floorID)
                    select floor).SingleOrDefault();
        }

        private UnitType GetUnitType(string unitTypeID)
        {
            return (from UnitType unitType in UnitTypes
                    where unitType.UnitTypeID.Equals(unitTypeID)
                    select unitType).SingleOrDefault();
        }

        #endregion

        #region PUBLIC FUNCTIONS USED TO POPULATE
        public List<Phase> GetPhases()
        {
            return Phases;
        }

        public List<Building> GetBuildings(string phaseID)
        {
            return (from Building bldg in Buildings
                    where bldg.BldgPhase.PhaseID.Equals(phaseID)
                    select bldg).ToList();
        }

        public List<Cluster> GetClusters(string bldgID)
        {
            return (from Cluster cluster in Clusters
                    where cluster.CLusterBldg.BuildingID.Equals(bldgID)
                    select cluster).ToList();
        }

        public List<Floor> GetFloors(string clusterID)
        {
            return (from Floor floor in Floors
                    where floor.FloorCluster.ClusterID.Equals(clusterID)
                    select floor).ToList();
        }

        public List<Unit> GetUnits(string floorID)
        {
            return (from Unit unit in Units
                    where unit.UnitFloor.FloorID.Equals(floorID)
                    select unit).ToList();
        }

        public Unit GetUnitByUnitID(string unitID)
        {
            return (from Unit _unit in Units
                    where _unit.UnitID.Equals(unitID)
                    select _unit).SingleOrDefault();
        }

        public void ReloadUnits()
        {
            this.LoadUnits();
        }
        #endregion

    }
}
