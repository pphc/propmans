using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnumLib;
using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public interface INewAddress
    {
        CustomerContact CustomerAddress { get; set; }

        void LoadAddressLocation(List<EnumItem> src);
        void DisplaySaveStatus(bool status);
        void DisplayUpdateStatus(bool status);
    }
}
