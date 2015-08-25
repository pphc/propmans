using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface ISaveLeaseAgreement
    {
        BCL.Accounts.Customer Tenant { get; set; }
        LeaseAgreement LeaseAgreement { get; set; }
        RentalAgreement RentalAgreement { get; set; }

        void LoadLeasePurpose(List<EnumItem> src);

        void DisplayNewAgreementSaveStatus(bool successful);
        void DisplayUpdateAgreementSaveStatus(bool successful);
    }
}
