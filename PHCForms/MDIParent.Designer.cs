namespace PHCForms
{
    partial class MDIParent
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLabTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDrugsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ptientInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lbluserid = new System.Windows.Forms.Label();
            this.lblphcid = new System.Windows.Forms.Label();
            this.accountingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prasuthiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aRSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.accountingToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPatientToolStripMenuItem,
            this.addLabTestToolStripMenuItem,
            this.addDrugsToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // addPatientToolStripMenuItem
            // 
            this.addPatientToolStripMenuItem.Name = "addPatientToolStripMenuItem";
            this.addPatientToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addPatientToolStripMenuItem.Text = "Add Patient";
            this.addPatientToolStripMenuItem.Click += new System.EventHandler(this.addPatientToolStripMenuItem_Click);
            // 
            // addLabTestToolStripMenuItem
            // 
            this.addLabTestToolStripMenuItem.Name = "addLabTestToolStripMenuItem";
            this.addLabTestToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addLabTestToolStripMenuItem.Text = "Add LabTest";
            this.addLabTestToolStripMenuItem.Click += new System.EventHandler(this.addLabTestToolStripMenuItem_Click);
            // 
            // addDrugsToolStripMenuItem
            // 
            this.addDrugsToolStripMenuItem.Name = "addDrugsToolStripMenuItem";
            this.addDrugsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addDrugsToolStripMenuItem.Text = "Add Drugs";
            this.addDrugsToolStripMenuItem.Click += new System.EventHandler(this.addDrugsToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem});
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.patientToolStripMenuItem.Text = "Patient";
            this.patientToolStripMenuItem.Click += new System.EventHandler(this.patientToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ptientInfoToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // ptientInfoToolStripMenuItem
            // 
            this.ptientInfoToolStripMenuItem.Name = "ptientInfoToolStripMenuItem";
            this.ptientInfoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ptientInfoToolStripMenuItem.Text = "PtientInfo";
            this.ptientInfoToolStripMenuItem.Click += new System.EventHandler(this.ptientInfoToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // lbluserid
            // 
            this.lbluserid.AutoSize = true;
            this.lbluserid.Location = new System.Drawing.Point(369, 226);
            this.lbluserid.Name = "lbluserid";
            this.lbluserid.Size = new System.Drawing.Size(40, 13);
            this.lbluserid.TabIndex = 4;
            this.lbluserid.Text = "UserID";
            this.lbluserid.Visible = false;
            // 
            // lblphcid
            // 
            this.lblphcid.AutoSize = true;
            this.lblphcid.Location = new System.Drawing.Point(372, 269);
            this.lblphcid.Name = "lblphcid";
            this.lblphcid.Size = new System.Drawing.Size(40, 13);
            this.lblphcid.TabIndex = 5;
            this.lblphcid.Text = "PHCID";
            this.lblphcid.Visible = false;
            // 
            // accountingToolStripMenuItem
            // 
            this.accountingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jSYToolStripMenuItem,
            this.prasuthiToolStripMenuItem,
            this.aRSToolStripMenuItem});
            this.accountingToolStripMenuItem.Name = "accountingToolStripMenuItem";
            this.accountingToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.accountingToolStripMenuItem.Text = "Accounting";
            // 
            // jSYToolStripMenuItem
            // 
            this.jSYToolStripMenuItem.Name = "jSYToolStripMenuItem";
            this.jSYToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jSYToolStripMenuItem.Text = "JSY";
            this.jSYToolStripMenuItem.Click += new System.EventHandler(this.jSYToolStripMenuItem_Click);
            // 
            // prasuthiToolStripMenuItem
            // 
            this.prasuthiToolStripMenuItem.Name = "prasuthiToolStripMenuItem";
            this.prasuthiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.prasuthiToolStripMenuItem.Text = "Prasuthi";
            this.prasuthiToolStripMenuItem.Click += new System.EventHandler(this.prasuthiToolStripMenuItem_Click);
            // 
            // aRSToolStripMenuItem
            // 
            this.aRSToolStripMenuItem.Name = "aRSToolStripMenuItem";
            this.aRSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aRSToolStripMenuItem.Text = "ARS";
            this.aRSToolStripMenuItem.Click += new System.EventHandler(this.aRSToolStripMenuItem_Click);
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.lblphcid);
            this.Controls.Add(this.lbluserid);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent";
            this.Text = "MDIParent";
            this.Load += new System.EventHandler(this.MDIParent_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLabTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDrugsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ptientInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.Label lbluserid;
        private System.Windows.Forms.Label lblphcid;
        private System.Windows.Forms.ToolStripMenuItem accountingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prasuthiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aRSToolStripMenuItem;

    }
}



