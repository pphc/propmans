using System;
using System.Collections.Generic;

using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{
    public partial class HouseHoldForm : ComponentFactory.Krypton.Toolkit.KryptonForm        
    {        
        #region "Form Instance"
        private static NewAddressForm aForm;
        public static NewAddressForm Instance()
        {
            if (aForm == null)
            {
                aForm = new NewAddressForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion
        public HouseHoldForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;            
        }
       
    }
}
