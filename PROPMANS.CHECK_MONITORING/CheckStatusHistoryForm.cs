using BCL.Checks;
using System;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class CheckStatusHistoryForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        private string _checkID;
        public CheckStatusHistoryForm(string checkID)
        {
            _checkID =checkID;
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            dgCheckStatusHistory.DataSource = ChecksDAL.GetCheckStatusHistory(_checkID);
            lblRecordCount.Text = dgCheckStatusHistory.RowCount + " record/s found";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

   
    }
}
