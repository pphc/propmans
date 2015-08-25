using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class BuildingType
    {
        public string BldgTypeID { get; set; }
        public string BldgTypeDesc { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        List<Building> Buildings { get; set; }
    }
}
