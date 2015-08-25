using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public interface IUpdateUnitMonitoring
    {
        CustomerAccount SelectedAccount { get; set; }

        void DisplayUpdateStatus(bool status);
    }
}
