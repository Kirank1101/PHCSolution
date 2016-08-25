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
    public partial class PrescriptionDetails : Form
    {
        public PrescriptionDetails()
        {
            InitializeComponent();
        }

        private void PrescriptionDetails_Load(object sender, EventArgs e)
        {
            lblbloodgroup.Text = "'O' +ve";
            lblpatientage.Text = "23";
            lblpatientsex.Text = "Male";

            List<Patient> lstPatient = new List<Patient>();
            Patient Patient = new Patient();
            Patient.Name = "Paracetamol 250";
            Patient.Dosage = "1-1-1";
            lstPatient.Add(Patient);
            Patient Patient1 = new Patient();
            Patient1.Name = "Amoxicillin 500mg";
            Patient1.Dosage = "1-0-1";
            lstPatient.Add(Patient1);
            dataGridView1.DataSource = lstPatient;

            List<LabTest> lstlabtest = new List<LabTest>();
            LabTest lblte = new LabTest();
            lblte.Labtests = "HIV";
            lblte.Result = "-ve";
            lstlabtest.Add(lblte);
            datagridLabTest.DataSource = lstlabtest;

            List<PatientHistory> lblph = new List<PatientHistory>();
            PatientHistory ph = new PatientHistory();
            ph.prescriptionid = "";
            ph.Decease = "Fever";
            ph.Description = "asdfa asdf";
            lblph.Add(ph);
            DGVPatientHistory.DataSource = lblph;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //foreach (DataGridCell row in datagridLabTest)
            //{

            //}
        }
        int id;
        private void DGVPatientHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(DGVPatientHistory.Rows[0].Cells["prescriptionid"].Value.ToString()))
                id = Convert.ToInt32(DGVPatientHistory.Rows[e.RowIndex].Cells["prescriptionid"].Value.ToString());
        }

        
    }
}
