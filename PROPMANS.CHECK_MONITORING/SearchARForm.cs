using BCL;
using BCL.Checks;
using System;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class SearchARForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        public string ARID { 
            get {
                return dgAR.CurrentRow.Cells[0].Value.ToString();    
            } 
        }

        public string ARNumber
        {
            get
            {
                return dgAR.CurrentRow.Cells[1].Value.ToString();
            }
        }

        public CheckCustodian ARCUstodian
        {
            get
            {
                return (CheckCustodian)dgAR.CurrentRow.Cells[3].Value;
            }
        }


        public DateTime ARDate
        {
            get
            {
                return DateTime.Parse(dgAR.CurrentRow.Cells[2].Value.ToString());
            }
        }

        public string Remarks
        {
            get
            {
                return dgAR.CurrentRow.Cells[4].Value.ToString();
            }
        }

        public string Notes
        {
            get
            {
                if (dgAR.CurrentRow.Cells[5].Value == null)
                {
                  return string.Empty ;
                }else
                {
                    return dgAR.CurrentRow.Cells[5].Value.ToString();
                }
            }
        }


        public SearchARForm()
        {
            InitializeComponent();
            btnOK.Visible = false;
        }

        private void btnSearchAR_Click(object sender, EventArgs e)
        {
            if (txtARNumber.Text.Trim().Length != 0 ) {
               CustomBindingList<AcknowlegementReceipt> csb = new CustomBindingList<AcknowlegementReceipt>(ChecksDAL.GetARDetailsByARNumber(txtARNumber.Text.Trim()));
               dgAR.DataSource = csb;
                btnOK.Visible = dgAR.RowCount > 0;
            }
        }

        private void btnViewAllAR_Click(object sender, EventArgs e)
        {
            CustomBindingList<AcknowlegementReceipt> csb = new CustomBindingList<AcknowlegementReceipt>(ChecksDAL.GetARDetails());
            dgAR.DataSource = csb;
            btnOK.Visible = dgAR.RowCount > 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
