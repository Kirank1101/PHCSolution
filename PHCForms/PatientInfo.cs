using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PHC.BAInterfaces.Business;
using PHC.Binder.BackEnd;
using PHC.BAInterfaces.DataTransfer;
using PHC.BAInterfaces.Validations;

namespace PHCForms
{
    public partial class PatientInfo : Form
    {
        public PatientInfo()
        {
            InitializeComponent();
        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {
            Bindbloodgroup();
        }

        private void Bindbloodgroup()
        {
            ddlsex.Items.Add("-Select-");
            ddlsex.Items.Add("Male");
            ddlsex.Items.Add("Female");
            ddlsex.SelectedIndex = 0;
            
            List<BloodGroups> lstbg = new List<BloodGroups>();
            lstbg.Add(new BloodGroups() { BloodGroupID = "-1", BloodGroup = "-Select-" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "O +" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "O -" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "A +" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "A -" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "B +" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "B -" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "AB +" });
            lstbg.Add(new BloodGroups() { BloodGroupID = "op", BloodGroup = "AB -" });

            ddlbloodgroup.DataSource = lstbg;
            ddlbloodgroup.DisplayMember = "BloodGroup";
            ddlbloodgroup.ValueMember = "BloodGroupID";
            //ddlbloodgroup.Items.Insert(0, "-Select-");
            //ddlbloodgroup.Items.Add(new { Text = "---Select---", Value = -1 });
            //ddlbloodgroup.Items.Insert(0, new BloodGroups { BloodGroupID = "0", BloodGroup= "--Select--" });
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            IValidate objIValidate = BinderSingleton.Instance.GetInstance<IValidate>();
            ResultDTO result = objIValidate.validatePatientInfo(txtname.Text.Trim(), txtage.Text.Trim(), txtcontact.Text.Trim(),ddlsex.SelectedIndex,ddlbloodgroup.SelectedIndex);
            if (result.IsSuccess)
            {
                string phcid = ((Form)this.MdiParent).Controls["lblphcid"].Text;
                ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
                ResultDTO resultDTO = objITransactionBusiness.AddPatientInfo(txtname.Text, txtage.Text, ddlsex.SelectedText, txtdob.Text, ddlbloodgroup.SelectedText, phcid,txtcontact.Text);
                if (resultDTO.IsSuccess)
                {
                    pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
                    lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
                    lblstatus.Text = resultDTO.Message;
                }
                else
                {
                    pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorBackGroundColor);
                    lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorForeColor);
                    lblstatus.Text = resultDTO.Message;
                }
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.WarningBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.WarningForeColor);
                lblstatus.Text = result.Message;
            }
        }
    }
}
