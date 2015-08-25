using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PROPMANS.BL.AccountManagement
{
    public class Customer
    {
        #region PROPERTIES
        public string CustomerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Gender? Gender { get; set; }
        public CivilStatus? CivilStatus { get; set; }
        public string DisplayName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; }
        public string Company { get; set; }
        public string CustomerCode { get; set; }
        public string Notes { get; set; }
        public string Citizenship { get; set; }
        public NameSake? NameSake { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string EditedBy { get; set; }
        public DateTime EditedDate { get; set; }

        public List<CustomerAccount> Customers { get; set; }
        public List<CustomerContact> CustomerContacts { get; set; }
        #endregion

    }
}
