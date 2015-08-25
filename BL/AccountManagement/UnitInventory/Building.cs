using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class Building
    {
        #region PROPERTIES
        public string BuildingID { get; set; }

        public Phase BldgPhase { get; set; }
        public BuildingType BldgType { get; set; }

        public string BuildingNumber { get; set; }

        public string BuildingName { get; set; }


        public List<Cluster> Clusters { get; set; }
        #endregion
    }
}
