using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class UnitType
    {
        #region PROPERTIES

        public string UnitTypeID { get; set; }
        public string UnitDescription { get; set; }
        public string UnitSQM { get; set; }
        public string UnitDuesRate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public List<Unit> Units { get; set; }
        #endregion
    }
}
