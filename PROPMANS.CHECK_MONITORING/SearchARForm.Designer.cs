namespace PROPMANS.CHECK_MONITORING
{
    partial class SearchARForm
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
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ARGridPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgAR = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnViewAllAR = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSearchAR = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtARNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.KryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ARGridPanel)).BeginInit();
            this.ARGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.btnCancel);
            this.MainPanel.Controls.Add(this.btnOK);
            this.MainPanel.Controls.Add(this.ARGridPanel);
            this.MainPanel.Controls.Add(this.kryptonPanel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainPanel.Size = new System.Drawing.Size(773, 414);
            this.MainPanel.TabIndex = 76;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(679, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 34);
            this.btnCancel.TabIndex = 79;
            this.btnCancel.Values.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(592, 366);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 34);
            this.btnOK.TabIndex = 78;
            this.btnOK.Values.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ARGridPanel
            // 
            this.ARGridPanel.Controls.Add(this.dgAR);
            this.ARGridPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ARGridPanel.Location = new System.Drawing.Point(10, 85);
            this.ARGridPanel.Name = "ARGridPanel";
            this.ARGridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.ARGridPanel.Size = new System.Drawing.Size(753, 260);
            this.ARGridPanel.StateCommon.Color1 = System.Drawing.Color.RoyalBlue;
            this.ARGridPanel.TabIndex = 77;
            // 
            // dgAR
            // 
            this.dgAR.AllowUserToAddRows = false;
            this.dgAR.AllowUserToDeleteRows = false;
            this.dgAR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAR.Location = new System.Drawing.Point(1, 1);
            this.dgAR.Name = "dgAR";
            this.dgAR.ReadOnly = true;
            this.dgAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAR.Size = new System.Drawing.Size(751, 258);
            this.dgAR.TabIndex = 3;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnViewAllAR);
            this.kryptonPanel1.Controls.Add(this.btnSearchAR);
            this.kryptonPanel1.Controls.Add(this.txtARNumber);
            this.kryptonPanel1.Controls.Add(this.KryptonLabel13);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(10, 10);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Size = new System.Drawing.Size(753, 75);
            this.kryptonPanel1.TabIndex = 76;
            // 
            // btnViewAllAR
            // 
            this.btnViewAllAR.Location = new System.Drawing.Point(404, 23);
            this.btnViewAllAR.Name = "btnViewAllAR";
            this.btnViewAllAR.Size = new System.Drawing.Size(81, 34);
            this.btnViewAllAR.TabIndex = 76;
            this.btnViewAllAR.Values.Text = "VIEW ALL";
            this.btnViewAllAR.Click += new System.EventHandler(this.btnViewAllAR_Click);
            // 
            // btnSearchAR
            // 
            this.btnSearchAR.Location = new System.Drawing.Point(317, 23);
            this.btnSearchAR.Name = "btnSearchAR";
            this.btnSearchAR.Size = new System.Drawing.Size(81, 34);
            this.btnSearchAR.TabIndex = 75;
            this.btnSearchAR.Values.Text = "SEARCH";
            this.btnSearchAR.Click += new System.EventHandler(this.btnSearchAR_Click);
            // 
            // txtARNumber
            // 
            this.txtARNumber.Location = new System.Drawing.Point(144, 28);
            this.txtARNumber.Name = "txtARNumber";
            this.txtARNumber.Size = new System.Drawing.Size(167, 20);
            this.txtARNumber.TabIndex = 74;
            this.txtARNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // KryptonLabel13
            // 
            this.KryptonLabel13.Location = new System.Drawing.Point(17, 28);
            this.KryptonLabel13.Name = "KryptonLabel13";
            this.KryptonLabel13.Size = new System.Drawing.Size(121, 20);
            this.KryptonLabel13.TabIndex = 73;
            this.KryptonLabel13.Values.Text = "ENTER AR NUMBER:";
            // 
            // SearchARForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 414);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchARForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEARCH ACKNOWLEDGEMENT RECEIPTS";
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ARGridPanel)).EndInit();
            this.ARGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal ComponentFactory.Krypton.Toolkit.KryptonPanel MainPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtARNumber;
        internal ComponentFactory.Krypton.Toolkit.KryptonLabel KryptonLabel13;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnViewAllAR;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnSearchAR;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        internal ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        internal ComponentFactory.Krypton.Toolkit.KryptonPanel ARGridPanel;
        internal ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgAR;
    }
}