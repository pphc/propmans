using BCL.Common;
using BCL.RMS;

namespace PROPMANS.RMS
{
    public class UpdateAgreementApprovalPresenter
    {
        private IUpdateAgreementApproval view;
        private RMSDA da = new RMSDA();

        public UpdateAgreementApprovalPresenter(IUpdateAgreementApproval view)
        {
            this.view = view;
            view.LoadApprovalStatusType(ApprovalStatus.Approved.ItemList(false, true));
        }

        public void UpdateContractStatus()
        {
            int ID = 0;
            if (view.isRentalAmendment)
            {
                ID = da.UpdateRentalAgreementContractStatus(view.ContractAmendment, view.ApprovalStatus,view.ApprovalNotes);
            }
            else
            {
                ID = da.UpdateLeaseAgreementContractStatus(view.ContractAmendment, view.ApprovalStatus, view.ApprovalNotes);
            }
           
            view.DisplayContractUpdateStatus(ID > 0);
        }
    }
}
