namespace PROPMANS.CHECK_MONITORING
{
    partial class NewChecksPreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblRecordCount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.CheckDetailsGridPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgNewChecksPreview = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddtoAR = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDetailsGridPanel)).BeginInit();
            this.CheckDetailsGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNewChecksPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.lblRecordCount);
            this.MainPanel.Controls.Add(this.kryptonPanel2);
            this.MainPanel.Controls.Add(this.btnCancel);
            this.MainPanel.Controls.Add(this.btnAddtoAR);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(1138, 331);
            this.MainPanel.TabIndex = 76;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Location = new System.Drawing.Point(10, 268);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(108, 16);
            this.lblRecordCount.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.TabIndex = 94;
            this.lblRecordCount.Values.Text = "No Record/s Found";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.CheckDetailsGridPanel);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(5, 5);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel2.Size = new System.Drawing.Size(1128, 257);
            this.kryptonPanel2.TabIndex = 93;
            // 
            // CheckDetailsGridPanel
            // 
            this.CheckDetailsGridPanel.Controls.Add(this.dgNewChecksPreview);
            this.CheckDetailsGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckDetailsGridPanel.Location = new System.Drawing.Point(5, 5);
            this.CheckDetailsGridPanel.Name = "CheckDetailsGridPanel";
            this.CheckDetailsGridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.CheckDetailsGridPanel.Size = new System.Drawing.Size(1118, 247);
            this.CheckDetailsGridPanel.StateCommon.Color1 = System.Drawing.Color.RoyalBlue;
            this.CheckDetailsGridPanel.TabIndex = 77;
            // 
            // dgNewChecksPreview
            // 
            this.dgNewChecksPreview.AllowUserToAddRows = false;
            this.dgNewChecksPreview.AllowUserToDeleteRows = false;
            this.dgNewChecksPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgNewChecksPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNewChecksPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgNewChecksPreview.Location = new System.Drawing.Point(1, 1);
            this.dgNewChecksPreview.MultiSelect = false;
            this.dgNewChecksPreview.Name = "dgNewChecksPreview";
            this.dgNewChecksPreview.ReadOnly = true;
            this.dgNewChecksPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgNewChecksPreview.Size = new System.Drawing.Size(1116, 245);
            this.dgNewChecksPreview.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1023, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 35);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddtoAR
            // 
            this.btnAddtoAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddtoAR.Location = new System.Drawing.Point(891, 283);
            this.btnAddtoAR.Name = "btnAddtoAR";
            this.btnAddtoAR.Size = new System.Drawing.Size(109, 35);
            this.btnAddtoAR.TabIndex = 91;
            this.btnAddtoAR.Values.Text = "ADD CHECKS";
            this.btnAddtoAR.Click += new System.EventHandler(this.btnAddtoAR_Click);
            // 
            // NewChecksPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 331);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewChecksPreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECK DETAILS PREVIEW";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckDetailsGridPanel)).EndInit();
            this.CheckDetailsGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNewChecksPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnAddtoAR;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel CheckDetailsGridPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgNewChecksPreview;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel lblRecordCount;
    }
}