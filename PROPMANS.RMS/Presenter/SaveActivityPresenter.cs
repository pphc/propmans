using BCL.RMS;
using System;
using System.Linq;

namespace PROPMANS.RMS
{
    public abstract class SaveActivityPresenter
    {
        public ISaveActvity view;
        protected RMSDA da = new RMSDA();
        protected Boolean SuccessfullySaved = false;

        public SaveActivityPresenter()
        {
        }
        public abstract void Intialize();
        public abstract void SaveActivity();
    }

    public class NewRentalActivityPresenter : SaveActivityPresenter
    {
        public NewRentalActivityPresenter() : base() {
        }
        public override void Intialize()
        {
            view.WindowTitle = "NEW RMA ACTIVITY";
            var agreement = (from ag in da.LoadRentalAgreementsByAccountID(view.UnitOwnerAccount.AccountID)
                              orderby ag.CreatedOn descending
                              select ag).FirstOrDefault();
            view.Agreement = agreement;
            //Remove on 5/8/2015
            //view.LoadRentalAgreements(agreements);
            view.LoadActivityType(da.LoadActivityType());
        }

        public override void SaveActivity()
        {
            var ID = da.InsertRMActivity(view.Agreement.ID, view.Activity);
            SuccessfullySaved = ID > 0;
            view.DisplayNewActivitySaveStatus(SuccessfullySaved);
        }
    }

    public class NewLeaseActivityPresenter : SaveActivityPresenter
    {
        public NewLeaseActivityPresenter()
            : base()
        {
        }

        public override void Intialize()
        {
            view.WindowTitle = "NEW LEASE ACTIVITY";
            var agreement = (from ag in da.LoadLeaseAgreementsByCustID(view.Tenant.CustomerID)
                            orderby ag.CreatedOn descending
                             select ag).FirstOrDefault();

                             
            //Remove on 5/8/2015
            //view.LoadLeaseAgreements(agreements);
            view.Agreement = agreement;
            view.LoadActivityType(da.LoadActivityType());
        }

        public override void SaveActivity()
        {
            var ID = da.InsertLeaseActivity(view.Agreement.ID, view.Activity);
            SuccessfullySaved = ID > 0;
            view.DisplayNewActivitySaveStatus(SuccessfullySaved);
        }
    }

    public class UpdateRMAActivityPresenter : SaveActivityPresenter
    {
        public UpdateRMAActivityPresenter() : base() { }

        public override void Intialize()
        {
            view.WindowTitle = "UPDATE RMA ACTIVITY";
            var agreement = (from ag in da.LoadRentalAgreementsByAccountID(view.UnitOwnerAccount.AccountID)
                             orderby ag.CreatedOn descending
                             select ag).FirstOrDefault();
            view.Agreement = agreement;
           // view.LoadRentalAgreements(agreements);
            view.LoadActivityType(da.LoadActivityType());
        }


        public override void SaveActivity()
        {
            var ID = da.UpdateActivity(view.Activity);
            SuccessfullySaved = ID > 0;
            view.DisplayUpdateAgreementSaveStatus(SuccessfullySaved);
        }
    }

    public class UpdateLeaseActivityPresenter : SaveActivityPresenter
    {
        public UpdateLeaseActivityPresenter() : base() { }

        public override void Intialize()
        {
            view.WindowTitle = "UPDATE LEASE ACTIVITY";
            var agreement = (from ag in da.LoadLeaseAgreementsByCustID(view.Tenant.CustomerID)
                             orderby ag.CreatedOn descending
                             select ag).FirstOrDefault();
            view.Agreement = agreement;
           // view.LoadLeaseAgreements(agreements);
            view.LoadActivityType(da.LoadActivityType());
        }


        public override void SaveActivity()
        {
            var ID = da.UpdateActivity(view.Activity);
            SuccessfullySaved = ID > 0;
            view.DisplayUpdateAgreementSaveStatus(SuccessfullySaved);
        }
    }
}
