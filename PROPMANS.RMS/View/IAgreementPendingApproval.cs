using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface IAgreementPendingApproval
    {
        AmendmentType RentalRequestType { get; }
        AmendmentType LeaseRequestType { get; }

        int PendingRentalAgreementCount { set; }
        int PendingLeaseAgreementCount { set; }

        void LoadAmendTypeList(List<EnumItem> src);

        void DisplayRentalAgreements(List<PendingRentalAgreementGridDisplay> agreements);
        void DisplayLeaseAgreements(List<PendingLeaseAgreementGridDisplay> contracts);

    }
}
