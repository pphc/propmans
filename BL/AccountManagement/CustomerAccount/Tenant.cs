using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class Tenant
    {
        public string TenantID{get;set;}
        public CustomerAccount  UnitOwner { get; set; }
        public Customer Customer { get; set; }
        public bool IsUnderRMS { get; set; }

        public DateTime? MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }
        public DateTime? OrientationDate { get; set; }
    }
}
