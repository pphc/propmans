using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface ILeaseAgreement
    {
        BCL.Accounts.Customer TenantAccount { get; set; }
        LeaseAgreement SelectedLeaseAgreement { get; set; }

        RentalBillingType SelectedBillingType { get; }

        void LoadBillingType(List<EnumItem> src);

        void LoadDefaults();

        void LoadLeaseAgreements(List<LeaseAgreementGridDisplay> agreements);
        void LoadRentalBillings(List<LeaseBillingGridDisplay> billings);
        void LoadLeaseActivities(List<RentalActivityGridDisplay> activities);
    }
}
