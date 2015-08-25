using BCL.Common;
using BCL.RMS;
using System.Collections.Generic;


namespace PROPMANS.RMS
{
    public interface IUpdateAgreementApproval
    {
        bool isRentalAmendment { get; set; }
        List<ContractAmendment> ContractAmendment { get; set; }

        ApprovalStatus ApprovalStatus { get; }
        string ApprovalNotes { get; }

        void LoadApprovalStatusType(List<EnumItem> src);
        void DisplayContractUpdateStatus(bool success);


    }
}
