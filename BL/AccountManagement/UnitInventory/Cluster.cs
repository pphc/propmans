using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class Cluster
    {
        #region PROPERTIES

        public Building CLusterBldg { get; set; }
        public string ClusterID { get; set; }
        public string ClusterName { get; set; }
        public string ClusterNumber { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public List<Floor> Floor { get; set; }
        #endregion
    }
}
