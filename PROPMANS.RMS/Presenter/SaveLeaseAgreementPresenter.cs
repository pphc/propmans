using BCL.Common;
using BCL.RMS;
using System;

namespace PROPMANS.RMS
{
    public abstract class SaveLeaseAgreementPresenter
    {
        protected ISaveLeaseAgreement view;
        protected RMSDA da = new RMSDA();
        protected Boolean SuccessfullySaved = false;

        public SaveLeaseAgreementPresenter(ISaveLeaseAgreement view)
        {
            this.view = view;
            view.LoadLeasePurpose(LeasePurpose.Residential.ItemList(false, true));
        }

        public abstract void SaveLeaseAgrement();
        
    }

    public class NewLeaseAgreementPresenter : SaveLeaseAgreementPresenter
    {
        public override void SaveLeaseAgrement()
        {
            var ID = da.InsertLeaseAgreement(view.Tenant.CustomerID, view.LeaseAgreement);
            SuccessfullySaved = ID > 0;
            view.DisplayNewAgreementSaveStatus(SuccessfullySaved);
        }
        public NewLeaseAgreementPresenter(ISaveLeaseAgreement view)
            : base(view)
        { 
        }
    
    }

    public class UpdateLeaseAgreementPresenter : SaveLeaseAgreementPresenter
    {
        public override void SaveLeaseAgrement()
        {
            var ID = da.UpdateLeaseAgreement(view.LeaseAgreement);
            SuccessfullySaved = ID > 0;
            view.DisplayUpdateAgreementSaveStatus(SuccessfullySaved);
        }
        public UpdateLeaseAgreementPresenter(ISaveLeaseAgreement view)
            : base(view)
        {
        }

    }
}
