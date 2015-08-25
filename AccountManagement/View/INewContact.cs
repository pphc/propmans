using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnumLib;
using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{
    public interface INewContact
    {
        CustomerContact CustomerContact { get; set; }

        void LoadContactType(List<EnumItem> src);
        void LoadContactLocation(List<EnumItem> src);
        void DisplaySaveStatus(bool status);
        void DisplayUpdateStatus(bool status);
    }
}
