using BCL.Accounts;
using System;

namespace PROPMANS.ACCOUNT_SEARCH
{
    public interface INewTenantInfo
    {
        Customer Tenant { get; set; }

        string CustomerLastName { get; set; }
        string CustomerFirstName { get; set; }
        string CustomerMiddleName { get; set; }
        DateTime? BirthDate { get; set; }
        bool WithoutMiddleName { get; }


    }
}
