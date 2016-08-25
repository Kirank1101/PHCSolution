namespace PHCForms
{
    partial class PatientInfoReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PHCDataSet = new PHCForms.PHCDataSet();
            this.PatientInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PatientInfoTableAdapter = new PHCForms.PHCDataSetTableAdapters.PatientInfoTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlsex = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PHCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.PatientInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PHCForms.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(863, 367);
            this.reportViewer1.TabIndex = 0;
            // 
            // PHCDataSet
            // 
            this.PHCDataSet.DataSetName = "PHCDataSet";
            this.PHCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PatientInfoBindingSource
            // 
            this.PatientInfoBindingSource.DataMember = "PatientInfo";
            this.PatientInfoBindingSource.DataSource = this.PHCDataSet;
            // 
            // PatientInfoTableAdapter
            // 
            this.PatientInfoTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sex";
            // 
            // ddlsex
            // 
            this.ddlsex.FormattingEnabled = true;
            this.ddlsex.Location = new System.Drawing.Point(50, 9);
            this.ddlsex.Name = "ddlsex";
            this.ddlsex.Size = new System.Drawing.Size(121, 21);
            this.ddlsex.TabIndex = 4;
            // 
            // PatientInfoReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 483);
            this.Controls.Add(this.ddlsex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PatientInfoReport";
            this.Text = "PatientInfoReport";
            this.Load += new System.EventHandler(this.PatientInfoReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PHCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PatientInfoBindingSource;
        private PHCDataSet PHCDataSet;
        private PHCDataSetTableAdapters.PatientInfoTableAdapter PatientInfoTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlsex;
    }
}