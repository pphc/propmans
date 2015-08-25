using BCL.RMS;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface ISaveActvity
    {
        BCL.Accounts.CustomerAccount UnitOwnerAccount { get; set; }
        BCL.Accounts.Customer  Tenant { get; set; }

        RentalServiceAgreement Agreement { get; set; }
        RentalActivity Activity { get; set; }
        string WindowTitle { set; }
       
       // Remove on 5/8/2015
       //void LoadRentalAgreements(List<RentalAgreement> src);
       //void LoadLeaseAgreements(List<LeaseAgreement> src);
        void LoadActivityType(List<ActivityType> src);

        void DisplayNewActivitySaveStatus(bool successful);
        void DisplayUpdateAgreementSaveStatus(bool successful);
    }
}
