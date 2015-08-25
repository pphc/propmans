using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class Unit
    {
        #region PROPERTIES
        public string UnitID { get; set; }

        public List<Customer> UnitAccounts { get; set; }
        public Floor UnitFloor { get; set; }
        public UnitType UnitType { get; set; }

        public string UnitPhaseNo { get; set; }
        public string UnitBuildingNo { get; set; }
        public string UnitClusterNo { get; set; }
        public string UnitFoorNo { get; set; }
        public string UnitNo { get; set; }
        public string UnitNumber { get; set; }
        public string UnitArea { get; set; }

        public UnitSubClass SubClass { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public DateTime? RFODate { get; set; }
        public OccupancyStatus OccupancyStatus { get; set; }
        public Occupant Occupant { get; set; }
        public DateTime? OccupancyDate { get; set; }
        public DateTime? CMDTurnOverDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        #endregion
    }
}
