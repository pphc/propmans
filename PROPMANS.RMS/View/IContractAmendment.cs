using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;

namespace PROPMANS.RMS
{
    public interface IContractAmendment
    {
        ContractAmendment RentalAmendment { get; set; }
        ContractAmendment LeaseAmendment { get; set; }
        Int32 RentalAmendmentCount { set; }
        Int32 LeaseAmendmentCount { set; }

        void LoadAmendTypeList(List<EnumItem> src);

        AmendmentType SelectedRentalAmendmentType { get; }
        AmendmentType SelectedLeaseAmendmentType { get; }

        void LoadRentalAgreements(List<RentalAgreementAmendmentGridDisplay> rentalAgreements);
        void LoadLeaseAgreements(List<LeaseAmendmentGridDisplay> leases);
        void SetLeaseAmendmentDefaults();
        void SetRentalAmendmentDefaults();
    }
}
