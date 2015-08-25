using BCL;
using BCL.Checks;
using PROPMANS.BASE_MOD;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class ChecksUpdateForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {

        private string AccountID { get; set; }
        private string AccountName { get; set; }
        private string LeaseID { get; set; }
        private string UnitNumber { get; set; }

        private  ChecksDTC SelectedCheck
        {
            get {

                return (ChecksDTC)dgCheckDetails.CurrentRow.DataBoundItem;
            }
        }
        
        #region "Form Instance"
        private static ChecksUpdateForm aForm;
        public static ChecksUpdateForm Instance()
        {
            if (aForm == null)
            {
                aForm = new ChecksUpdateForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion

        public ChecksUpdateForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            lblCustomerType.Text = string.Empty;
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            using (AccountLookupForm frm = new AccountLookupForm())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    this.AccountID = frm.AccountID;
                    this.UnitNumber = frm.UnitNumber;
                    this.AccountName = frm.CustomerFullName;
                    txtAccountName.Text = this.UnitNumber + "-" + this.AccountName;
                    lblCustomerType.Text = frm.CustomerType;
                    this.AccountName = frm.CustomerFullName;

                    LoadCheckDetails();
                }
        
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (! string.IsNullOrEmpty(this.AccountID)) {
                LoadCheckDetails();
            }
        }

        private void btnUpdateChecks_Click(object sender, EventArgs e)
        {
            if (dgCheckDetails.RowCount > 0) {

                if (dgCheckDetails.SelectedRows.Count == 1)
                {
                    using (CheckStatusUpdateForm frm = new CheckStatusUpdateForm(SelectedCheck.CheckStatus))
                    {
                        frm.lblCheckNumber.Text = String.Format("{0} - {1:d}", SelectedCheck.CheckNumber, SelectedCheck.CheckDate);
                        frm.checkID = SelectedCheck.CheckID;
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            LoadCheckDetails();
                            MessageBox.Show("Check Status Updated", "Update Successfull");
                        }
                    }
                }
                else
                {
                    List<ChecksDTC> checks = new List<ChecksDTC>();
                    foreach (DataGridViewRow dr in dgCheckDetails.SelectedRows)
                    {
                        checks.Add((ChecksDTC)dr.DataBoundItem);
                    }

                    if (IsAllCheckStatusSame(checks))
                    {
                        using (CheckStatusUpdateForm frm = new CheckStatusUpdateForm(checks))
                        {
                            frm.lblCheckNumber.Text = "MULTIPLE CHECKS STATUS UPDATE";
                            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                LoadCheckDetails();
                                MessageBox.Show("Check Status Updated", "Update Successfull");
                            }
                        }
                    }
                    else {
                        MessageBox.Show("Check Status must be the same for all checks");
                    }
                }

               
            }
        
        }

        private bool IsAllCheckStatusSame(List<ChecksDTC> checks)
        {
            CheckStatus firstcheckStatus = checks[0].CheckStatus;
            bool SameStatus = true;
            foreach (ChecksDTC ck in checks)
            {
                if (firstcheckStatus != ck.CheckStatus) {
                    SameStatus = false;
                    break;
                }
            }

            return SameStatus;
        }
        private void btnAddtoAR_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadCheckDetails() {

            CustomBindingList<ChecksDTC> csb2 = new CustomBindingList<ChecksDTC>(ChecksDAL.GetCheckDetailsByAccountID(this.AccountID));
            dgCheckDetails.DataSource = csb2;

            if (dgCheckDetails.RowCount > 0)
            {
                lblRecordCount.Text = dgCheckDetails.RowCount + " record/s found";
            }
            else {
                lblRecordCount.Text = "No record/s found";
            }
        }

        private void btnViewCheckStatusHistory_Click(object sender, EventArgs e)
        {
            if (dgCheckDetails.RowCount > 0)
            {
                using (CheckStatusHistoryForm frm = new CheckStatusHistoryForm(SelectedCheck.CheckID))
                {
                    frm.lblCheckINumber.Text = String.Format("{0} - {1:d}", SelectedCheck.CheckNumber, SelectedCheck.CheckDate);
                    frm.lblCheckBank.Text = SelectedCheck.BankName;
                    frm.ShowDialog(this);
                }

            }

        }

    }
}
