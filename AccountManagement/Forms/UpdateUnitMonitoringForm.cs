
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using PROPMANS.BL.AccountManagement;


namespace PROPMANS.VIEW.AccountManagement
{
    public partial class UpdateUnitMonitoringForm : ComponentFactory.Krypton.Toolkit.KryptonForm,
        IUpdateUnitMonitoring
    {
        UpdateUnitMonitoringPresenter presenter;
        #region "Form Instance"
        private static UpdateUnitMonitoringForm aForm;
        public static UpdateUnitMonitoringForm Instance()
        {
            if (aForm == null)
            {
                aForm = new UpdateUnitMonitoringForm();
            }
            return aForm;
        }

        private void Form_Disposed(object sender, System.EventArgs e)
        {
            aForm = null;
        }
        #endregion
        public UpdateUnitMonitoringForm()
        {
            InitializeComponent();
            this.Disposed += Form_Disposed;
            presenter = new UpdateUnitMonitoringPresenter(this); 
        }
        #region INTERFACE
        private CustomerAccount _selectedAccount;
        public CustomerAccount SelectedAccount
        {
            get
            {
                //_selectedAccount.AccountID = _selectedAccount.AccountID;
                if (dtpTakeOutdate.Checked) { _selectedAccount.TakeOutDate = dtpTakeOutdate.Value.Date; } else { _selectedAccount.TakeOutDate = null; }
                if (dtpDuesBillingDate.Checked) { _selectedAccount.CDStartDate = dtpDuesBillingDate.Value.Date; } else { _selectedAccount.CDStartDate = null; }
                if (dtpATMDate.Checked) { _selectedAccount.ATMDate = dtpATMDate.Value.Date; } else { _selectedAccount.ATMDate = null; }
                if (dtpAcceptanceDate.Checked) { _selectedAccount.AcceptanceDate = dtpAcceptanceDate.Value.Date; } else { _selectedAccount.AcceptanceDate = null; }
                if (dtpOrientationDate.Checked) { _selectedAccount.OrientationDate = dtpOrientationDate.Value.Date; } else { _selectedAccount.OrientationDate = null; }
                if (dtpPowerConnectionDate.Checked) { _selectedAccount.PowerApplicationDate = dtpPowerConnectionDate.Value.Date; } else { _selectedAccount.PowerApplicationDate = null; }
                if (dtpWaterConnectionDate.Checked) { _selectedAccount.WaterApplicationDate = dtpWaterConnectionDate.Value.Date; } else { _selectedAccount.WaterApplicationDate = null; }
                if (dtpEarlyMoveInRequest.Checked) { _selectedAccount.EarlyMoveInRequestDate = dtpEarlyMoveInRequest.Value.Date; } else { _selectedAccount.EarlyMoveInRequestDate = null; }
                if (dtpMoveInFeePaymentDate.Checked) { _selectedAccount.MoveInFeePaymentDate = dtpMoveInFeePaymentDate.Value.Date; } else { _selectedAccount.MoveInFeePaymentDate = null; }
                if (dtpLastInspectionDate.Checked) { _selectedAccount.InspectionDate = dtpLastInspectionDate.Value.Date; } else { _selectedAccount.InspectionDate = null; }
                if (dtpKeyTurnOverDate.Checked) { _selectedAccount.KeyTurnOverDate = dtpKeyTurnOverDate.Value.Date; } else { _selectedAccount.KeyTurnOverDate = null; }
                
                return _selectedAccount;
            }
            set
            {
                if (value != null)
                {
                    lblAccountID.Text = value.AccountID;
                    lblUnitNumber.Text = value.Unit.UnitNumber;
                    lblUnitType.Text = value.Unit.UnitType.UnitDescription;
                    lblUnitArea.Text = value.Unit.UnitArea;

                    if (value.TakeOutDate.HasValue)
                    {
                        dtpTakeOutdate.Value = DateTime.Parse(value.TakeOutDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else
                    { dtpDuesBillingDate.Checked = false; }

                    if (value.CDStartDate.HasValue)
                    {
                        dtpDuesBillingDate.Value = DateTime.Parse(value.CDStartDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpDuesBillingDate.Checked = false; }

                    if (value.PowerApplicationDate.HasValue)
                    {
                        dtpPowerConnectionDate.Value = DateTime.Parse(value.PowerApplicationDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpPowerConnectionDate.Checked = false; }

                    if (value.WaterApplicationDate.HasValue)
                    {
                        dtpWaterConnectionDate.Value = DateTime.Parse(value.WaterApplicationDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpWaterConnectionDate.Checked = false; }

                    if (value.EarlyMoveInRequestDate.HasValue)
                    {
                        dtpEarlyMoveInRequest.Value = DateTime.Parse(value.EarlyMoveInRequestDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpEarlyMoveInRequest.Checked = false; }

                    if (value.MoveInFeePaymentDate.HasValue)
                    {
                        dtpMoveInFeePaymentDate.Value = DateTime.Parse(value.MoveInFeePaymentDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpMoveInFeePaymentDate.Checked = false; }

                    if (value.ATMDate.HasValue)
                    {
                        dtpATMDate.Value = DateTime.Parse(value.ATMDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpATMDate.Checked = false; }

                    if (value.InspectionDate.HasValue)
                    {
                        dtpLastInspectionDate.Value = DateTime.Parse(value.InspectionDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpLastInspectionDate.Checked = false; }

                    if (value.OrientationDate.HasValue)
                    {
                        dtpOrientationDate.Value = DateTime.Parse(value.OrientationDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpOrientationDate.Checked = false; }

                    if (value.AcceptanceDate.HasValue)
                    {
                        dtpAcceptanceDate.Value = DateTime.Parse(value.AcceptanceDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpAcceptanceDate.Checked = false; }

                    if (value.KeyTurnOverDate.HasValue)
                    {
                        dtpKeyTurnOverDate.Value = DateTime.Parse(value.KeyTurnOverDate.Value.ToString("MMMM dd, yyyy"));
                    }
                    else { dtpKeyTurnOverDate.Checked = false; }
                    _selectedAccount = value;
                }                
            }
        }

        public void DisplayUpdateStatus(bool status)
        {
            if (status)
            {
                MessageBox.Show("Account Successfully Updated!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("Failed to Update Account!");
            }
        }
        #endregion

        #region EVENTS
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("UPDATE MONITORING?", "CONFIRM SAVING",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                presenter.UpdateUnitMonitoring();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion               

    }
}
