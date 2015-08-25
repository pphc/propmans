using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public class UpdateUnitMonitoringPresenter
    {
        private IUpdateUnitMonitoring view;
        private CustomerAccountDA da = new CustomerAccountDA();
        protected Boolean Status = false;

        public UpdateUnitMonitoringPresenter(IUpdateUnitMonitoring view)
        {
            this.view = view;
        }

        public void UpdateUnitMonitoring()
        {
            var ID = da.UpdateUnitMonitoring(view.SelectedAccount);
            Status = ID > 0;
            view.DisplayUpdateStatus(Status);
        }
    }
}
