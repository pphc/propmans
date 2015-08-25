using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface IAgreementSelection
    {
        RentalServiceAgreement Agreement { get; }

        LeaseType SelectedLeaseType { get; }
        Int32 AvailableUnitsCount { set; }

        void LoadLeaseType(List<EnumItem> src);

        void LoadAvailableRentalUnits(List<AvailableUnitsForRentGridDisplay> agreements);
        void LoadActiveRentalAgreements(List<ActiveRentalAgreementsGridDisplay> agreements);
        void LoadActiveLeaseAgreements(List<ActiveLeaseAgreementsGridDisplay> agreements);

        string DialogueTitleCaption { set; }
    }
}
