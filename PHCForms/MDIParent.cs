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
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent(string username,string phcid)
        {
            InitializeComponent();
            lbluserid.Text = username;
            lblphcid.Text = phcid;
            
        }

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            PatientInfo PI = new PatientInfo();
            PI.MdiParent = this;
            PI.Show();
        }

        private void addLabTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            AddLabTests AddLabTests = new AddLabTests();
            AddLabTests.MdiParent = this;
            AddLabTests.Show();
        }

        private void addDrugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            DrugInfo Druginfo = new DrugInfo();
            Druginfo.MdiParent = this;
            Druginfo.Show();
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            PrescriptionDetails PrescriptionDetails = new PrescriptionDetails();
            PrescriptionDetails.MdiParent = this;
            PrescriptionDetails.Show();

        }

        private void ptientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            PatientInfoReport PatientInfoReport = new PatientInfoReport();
            PatientInfoReport.MdiParent = this;
            PatientInfoReport.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            UserRegistration UserRegistration = new UserRegistration();
            UserRegistration.MdiParent = this;
            UserRegistration.Show();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {

        }

        private void jSYToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prasuthiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aRSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
