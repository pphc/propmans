using BCL.Common;
using BCL.RMS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.RMS
{
    public partial class UpdateAgreementApprovalForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        IUpdateAgreementApproval
    {
        private UpdateAgreementApprovalPresenter presenter;

        public bool isRentalAmendment
        {
            get;set;
        }

        public List<ContractAmendment> ContractAmendment
        {
            get; set;
        }

        public string ApprovalNotes
        {
            get { return txtNotes.Text.Trim(); }
        }


       public ApprovalStatus ApprovalStatus
       {
           get { return (ApprovalStatus) cboApprovalStatus.SelectedValue; }
       }

     
        public UpdateAgreementApprovalForm()
        {
            InitializeComponent();
            presenter = new UpdateAgreementApprovalPresenter(this);
        }

       public void LoadApprovalStatusType(List<EnumItem> src)
       {
           cboApprovalStatus.DisplayMember = "Name";
           cboApprovalStatus.ValueMember = "Value";
           cboApprovalStatus.DataSource = src;
       }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ApprovalStatus != BCL.RMS.ApprovalStatus.Pending)
            {
                if (IsentryValid())
                {
                    if (MessageBox.Show("Update Status of selected agreements?", "Contract Status Approval Update Confirmation",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        presenter.UpdateContractStatus();
                    }
                }
           
            }
            else
            {
                MessageBox.Show("Select Approval Status.", "No changes in Approval",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }
        private bool IsentryValid()
        {
            bool valid = true;

            if (this.ApprovalStatus == BCL.RMS.ApprovalStatus.Disapproved) {
                if (string.IsNullOrWhiteSpace(txtNotes.Text)) {
                    valid = false;
                    MessageBox.Show("Must have notes for disapproved requests");
                    txtNotes.Focus();
                }         
            }

            return valid;
        
        }

        public void DisplayContractUpdateStatus(bool successful)
        {
            if (successful)
            {
                MessageBox.Show("Contract Status succesfully Updated");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Contract Status not succesfully Updated");
            }
        }

       private void btnCancel_Click(object sender, EventArgs e)
       {
           this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.Close();
       }
    }
}
