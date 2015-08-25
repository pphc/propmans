using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public  class CustomerRelationship
    {
        public string RelationID { get; set; }
        public CustomerAccount Account { get; set; }
        public Tenant Tenant { get; set; }
        public Customer Customer { get; set; }
        public RelationCategory RelationCategory { get; set; }
        public RelationType RelationType { get; set; }
        public DateTime? MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }

    }
}
