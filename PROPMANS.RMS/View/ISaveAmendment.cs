using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
 
    public interface ISaveAmendment
    {
        RentalServiceAgreement Agreement { get; set; }
        ContractAmendment Amendment { get; set; }
       
        void LoadAmendmentRequestType(List<EnumItem> src);
        void LoadRequestingParty(List<EnumItem> src);

        void SetViewTitleText();
        void DisplayUpdateAmendmentStatus(bool success);
        void DisplaySaveNewAmendmentStatus(bool success);

    }
}
