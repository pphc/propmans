using BCL.Common;
using BCL.RMS;
using System.Linq;

namespace PROPMANS.RMS
{
    public enum RentalServiceType
    { RentalAgreement,LeaseAgreement}
    public abstract class SaveAmendmentPresenter
    {
        public ISaveAmendment view;
        public abstract  RentalServiceType ServiceType();
        protected RMSDA da = new RMSDA();

        protected SaveAmendmentPresenter() {
        }
        public void InitializeView()
        {
            view.LoadAmendmentRequestType((from p in AmendmentType.RentalExtension.ItemList(false, true)
                                  where p.Name != "NEW CONTRACT"
                                  select p).ToList());
            view.LoadRequestingParty(RequesterType.UnitOwner.ItemList(false, true));

            view.SetViewTitleText();
        }
        public abstract string GetDialogueTitle();
        public abstract void SaveAmendment();
    }

    public class NewRentalAmendmentPresenter : SaveAmendmentPresenter
    {
        public override RentalServiceType ServiceType()
        {
            return RentalServiceType.RentalAgreement;
        }
        public NewRentalAmendmentPresenter() : base() { }
        
        public override string GetDialogueTitle()
        {
            return "NEW RENTAL AGREEMENT AMENDMENT REQUEST";
        }

        public override void SaveAmendment()
        {
            var ID = da.InsertRentalAmmendment(view.Amendment);
            view.DisplaySaveNewAmendmentStatus(ID > 0);
        }
    }

    public class NewLeaseAmendmentPresenter : SaveAmendmentPresenter
    {
        public override RentalServiceType ServiceType()
        {
            return RentalServiceType.LeaseAgreement;
        }
        public NewLeaseAmendmentPresenter() : base() { }
        public override string GetDialogueTitle()
        {
            return "NEW LEASE AGREEMENT AMENDMENT REQUEST";
        }

        public override void SaveAmendment()
        {
            var ID = da.InsertLeaseAmmendment(view.Amendment);
            view.DisplaySaveNewAmendmentStatus(ID > 0);
        }
    }

    public class UpdateRentalAmendmentPresenter : SaveAmendmentPresenter
    {
        public override RentalServiceType ServiceType()
        {
            return RentalServiceType.RentalAgreement;
        }
        public UpdateRentalAmendmentPresenter() : base() { }
        public override string GetDialogueTitle()
        {
            return "UPDATE RENTAL AGREEMENT AMENDMENT REQUEST";
        }

        public override void SaveAmendment()
        {
            var ID = da.UpdateRentalAmmendment(view.Amendment);
            view.DisplayUpdateAmendmentStatus(ID > 0);
        }
    }

    public class UpdateLeaseAmendmentPresenter : SaveAmendmentPresenter
    {
        public override RentalServiceType ServiceType()
        {
            return RentalServiceType.LeaseAgreement;
        }
        public UpdateLeaseAmendmentPresenter() : base() { }

        public override string GetDialogueTitle()
        {
            return "UPDATE LEASE AGREEMENT AMENDMENT REQUEST";
        }

        public override void SaveAmendment()
        {
            var ID = da.UpdateLeaseAmmendment(view.Amendment);
            view.DisplayUpdateAmendmentStatus(ID > 0);
        }

    }

}
