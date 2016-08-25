using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHCForms
{
    public partial class PatientInfoReport : Form
    {
        public PatientInfoReport()
        {
            InitializeComponent();
        }

        private void PatientInfoReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PHCDataSet.PatientInfo' table. You can move, or remove it, as needed.
            this.PatientInfoTableAdapter.FillBy(this.PHCDataSet.PatientInfo);
            this.reportViewer1.RefreshReport();

            ddlsex.Items.Add("Select");
            ddlsex.Items.Add("Male");
            ddlsex.Items.Add("Femail");
            ddlsex.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ddlsex.SelectedIndex == 0)
            {
                this.PatientInfoTableAdapter.FillBy(this.PHCDataSet.PatientInfo);
                this.reportViewer1.RefreshReport();
            }
            else
            {                
                this.PatientInfoTableAdapter.Fill(this.PHCDataSet.PatientInfo, ddlsex.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
