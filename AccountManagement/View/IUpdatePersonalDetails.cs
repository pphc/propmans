using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnumLib;
using PROPMANS.BL.AccountManagement;

namespace PROPMANS.VIEW.AccountManagement
{
    public interface IUpdatePersonalDetails
    {
        Customer SelectedCustomer { get; set; }

        void LoadGender(List<EnumItem> src);
        void LoadCivilStatus(List<EnumItem> src);
    }
}
