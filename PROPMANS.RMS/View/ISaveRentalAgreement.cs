using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface ISaveRentalAgreement
    {
       BCL.Accounts.CustomerAccount UnitOwnerAccount { get; set; }
       RentalAgreement RentalAgreement { get; set; }

       string SetViewTitle { set; }
       void LoadLeaseType(List<EnumItem> src);
       void LoadRemitType(List<EnumItem> src);

       void DisplayNewAgreementSaveStatus(bool successful);
       void DisplayUpdateAgreementSaveStatus(bool successful);
     
    }
}
