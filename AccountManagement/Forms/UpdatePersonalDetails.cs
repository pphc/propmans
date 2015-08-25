
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using EnumLib;
using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{
    public partial class UpdatePersonalDetails : ComponentFactory.Krypton.Toolkit.KryptonForm,
        IUpdatePersonalDetails
    {
        UpdatePersonalDetailsPresenter presenter;
        #region "Form Instance"
        private static UpdatePersonalDetails aForm;
        public static UpdatePersonalDetails Instance()
        {
            if (aForm == null)
            {
                aForm = new UpdatePersonalDetails();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion
        public UpdatePersonalDetails()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new UpdatePersonalDetailsPresenter(this);
        }

        #region INTERFACE
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                if (value != null)
                {
                    lblFirstName.Text = value.FirstName;
                    lblMiddleName.Text = value.MiddleName;
                    lblLastName.Text = value.LastName;
                    if (value.Birthdate.HasValue)
                    {
                        dtpBirthDate.Value = DateTime.Parse(value.Birthdate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpBirthDate.Checked = false; }
                    cboGender.SelectedValue = (Int32)value.Gender;
                    cboCivilStatus.SelectedValue = (Int32)value.CivilStatus;
                    //cboReligion.SelectedValue = ()
                    //cboCitizenship.SelectedValue = ()
                    txtCompanySchool.Text = value.Company;
                    txtOccupation.Text = value.Occupation;
                    _selectedCustomer = value;
                }
            }
        }

        public void LoadGender(List<EnumItem> src)
        {
            cboGender.DisplayMember = "Name";
            cboGender.ValueMember = "Value";
            cboGender.DataSource = src;
        }

        public void LoadCivilStatus(List<EnumItem> src)
        {
            cboCivilStatus.DisplayMember = "Name";
            cboCivilStatus.ValueMember = "Value";
            cboCivilStatus.DataSource = src;
        }
        #endregion

        #region EVENTS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion        
    }
}
