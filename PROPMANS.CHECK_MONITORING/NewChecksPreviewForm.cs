using BCL.Checks;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROPMANS.CHECK_MONITORING
{
    public partial class NewChecksPreviewForm : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        private List<Check> Checks;
        public NewChecksPreviewForm(List<Check> checks)
        {
            this.Checks = checks;
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            dgNewChecksPreview.DataSource = Checks;
            lblRecordCount.Text = Checks.Count + " checks to add";
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
    }
}
