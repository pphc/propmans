using BCL.Checks;
using PROPMANS.BASE_MOD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class CheckStatusUpdateForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        public string checkID;

        private bool IsMultipleUpdate = false;
        private ArrayList checkIDs;

        public CheckStatusUpdateForm(CheckStatus checkStatus)
        {
            InitializeComponent();

            Common.BindComboBoxtoList(ref  cboCheckStatus, new CheckStatusListSrc(checkStatus));
            Common.BindComboBoxtoList( ref  cboNotificationType, new NotificationListSrc());
            dtpStatusDate.MaxDate = DateTime.Today;
        }

        public CheckStatusUpdateForm(List<ChecksDTC> checks)
        {
            InitializeComponent();

            Common.BindComboBoxtoList(ref  cboCheckStatus, new CheckStatusListSrc(checks[0].CheckStatus));
            Common.BindComboBoxtoList(ref  cboNotificationType, new NotificationListSrc());
            dtpStatusDate.MaxDate = DateTime.Today;
            IsMultipleUpdate = true;
            checkIDs = new ArrayList();

            foreach (ChecksDTC ck in checks) {
                checkIDs.Add(ck.CheckID);
            }
        }

        private void btnSaveStatus_Click(object sender, EventArgs e)
        {
            if (IsEntryValid())
            {
                if (SaveStatus()) {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
               
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private bool IsEntryValid() {
            errorProvider1.Clear(); 
            bool valid = true;

            if (cboCheckStatus.SelectedValue.Equals("-1") ) {
                errorProvider1.SetError(cboCheckStatus, "Select Status");
                cboCheckStatus.Focus();
                valid = false;
            }
            if (cboNotificationType.SelectedValue.Equals("-1"))
            {
                errorProvider1.SetError(cboNotificationType, "Select Status");
                cboNotificationType.Focus();
                valid = false;
            }

            if (! Common.HasValue(txtRemarks)) {
                errorProvider1.SetError(txtRemarks, "Enter Remarks for change status");
                txtRemarks.Focus();
                valid = false;
            }

            return valid;
        
        }
        private bool SaveStatus() {
            if (IsMultipleUpdate)
            {
                return ChecksDAL.UpdateCheckStatus(checkIDs, cboCheckStatus.SelectedValue.ToString(), dtpStatusDate.Value.Date, cboNotificationType.SelectedValue.ToString(), txtRemarks.Text.Trim()) > 0;
            }
            else {
                return ChecksDAL.UpdateCheckStatus(this.checkID, cboCheckStatus.SelectedValue.ToString(), dtpStatusDate.Value.Date, cboNotificationType.SelectedValue.ToString(), txtRemarks.Text.Trim()) > 0;
            }
        
        }

    

  

    }
}
