using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface IRentalAgreement
    {
        BCL.Accounts.CustomerAccount SelectedAccount { get; set; }
        RentalAgreement SelectedRentalAgreement { get; set; }
        RentalActivity SelectedActivity { get; }

        void LoadDefaults();
        void LoadLeaseType(List<EnumItem> src);
        void LoadRemitType(List<EnumItem> src);

        void LoadRentalAgreements(List<RentalAgreementsGridDisplay> rentalAgreements);
        void LoadLeases(List<UnitLeasesGridDisplay> leases);
        void LoadRentalActivities(List<RentalActivityGridDisplay> activities);
      
    }
}
