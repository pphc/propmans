using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class Floor
    {
        #region PROPERTIES
        public string FloorID { get; set; }
        public string FloorName { get; set; }
        public string FloorNumber { get; set; }
        public Cluster FloorCluster { get; set; }
        public List<Unit> Units { get; set; }
        #endregion
    }
}
