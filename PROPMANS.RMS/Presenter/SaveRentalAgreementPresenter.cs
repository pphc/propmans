using BCL.Common;
using BCL.RMS;
using System;

namespace PROPMANS.RMS
{
    public abstract  class SaveRentalAgreementPresenter
    { 
        protected ISaveRentalAgreement view;
        protected  RMSDA da = new RMSDA();
        protected Boolean SuccessfullySaved=false;
        protected abstract string ViewTitle { get; }
        protected SaveRentalAgreementPresenter(ISaveRentalAgreement view)
        {
            this.view = view;
            view.LoadLeaseType(LeaseType.Bare.ItemList(false,true));
            view.LoadRemitType(RemitType.ATM.ItemList(false, true));
            view.SetViewTitle = this.ViewTitle;
        }

        public abstract void SaveRentalAgrement();
    
    }
    public class NewRentalAgreementPresenter : SaveRentalAgreementPresenter 
    {
        protected override string ViewTitle
        {
            get { return "NEW RENTAL AGREEMENT"; }
        }
        public override void SaveRentalAgrement()
        {
                var ID = da.InsertRentalAgreement(view.UnitOwnerAccount.AccountID, view.RentalAgreement);
                SuccessfullySaved = ID > 0;
                view.DisplayNewAgreementSaveStatus(SuccessfullySaved);
        }
        public NewRentalAgreementPresenter(ISaveRentalAgreement view) : base(view)
        {
        }


       
    }

    public class UpdateRentalAgreementPresenter : SaveRentalAgreementPresenter
    {
        protected override string ViewTitle
        {
            get { return "UPDATE RENTAL AGREEMENT"; }
        }
        public override void SaveRentalAgrement()
        {
                var ID = da.UpdateRentalAgreement(view.RentalAgreement);

                SuccessfullySaved = ID > 0;

                view.DisplayUpdateAgreementSaveStatus(SuccessfullySaved);
        }
        public UpdateRentalAgreementPresenter(ISaveRentalAgreement view)
            : base(view)
        { }
    }
}
