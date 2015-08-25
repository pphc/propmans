using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class Phase
    {
        #region PROPERTIES

        public string PhaseID { get; set; }
        public string PhaseName { get; set; }
        public string PhaseNumber { get; set; }
        public string PhaseRemarks { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public List<Building> Buildings { get; set; }
        #endregion
    }
}
