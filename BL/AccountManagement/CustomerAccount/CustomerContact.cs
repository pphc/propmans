using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROPMANS.BL.AccountManagement
{
    public class CustomerContact
    {
        #region PROPERTIES

        public Customer Customer { get; set; }

        public string ContactID { get; set; }
        public ContactType ContactType { get; set; }
        //public AddressContactLocation AddressLocation { get; set; }
        //public ContactLocation ContactLocation { get; set; }
        public ContactLocation ContactLocation { get; set; }
        public string Details { get; set; }
        public ActiveStatus Active { get; set; }
        public ActiveStatus Preffered { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        #endregion
    }
}
