using PHC.BAInterfaces.Business;
using PHC.BAInterfaces.Constants;
using PHC.BAInterfaces.DataTransfer;
using PHC.Binder.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PHCWebApplication
{
    public partial class PatientPrescription : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDisease();
                BindddlDrugs();
                BindLVDrugs();
                PopulateData();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
        }

        private void BindddlDrugs()
        {
            List<MDrugsDTO> lstMDrugsDTO = ViewstateDrugNames;
            if (lstMDrugsDTO != null && lstMDrugsDTO.Count > 0)
            {
                ddlDrugNames.DataSource = lstMDrugsDTO;
                ddlDrugNames.DataBind();
                ddlDrugNames.Items.Insert(0, "Select Drug");
            }
        }

        private void BindLVDrugs()
        {
            LVDrugs.DataSource = ViewstateDrugsIssues;
            LVDrugs.DataBind();
        }
        protected void BindDisease()
        {
            ddlDisease.DataSource = ViewstateDisease;
            ddlDisease.DataBind();
            ddlDisease.Items.Insert(0, "---Select Disease---");
        }
        private void PopulateData()
        {

        }
        protected void ResetPage()
        {
            lblage.Text = string.Empty;
            lblbloodgroup.Text = string.Empty;
            lblECNO.Text = string.Empty;
            lblVillage.Text = string.Empty;
        }

        const string VSDisease = PHCConstatnt.VSDisease;
        const string VSDrugs = PHCConstatnt.VSDrugs;

        const string VSDrugName = PHCConstatnt.VSDrugName;
        public List<MDrugsDTO> ViewstateDrugNames
        {
            get
            {
                if (ViewState[VSDrugName] == null)
                {
                    List<MDrugsDTO> lstMDrugsDTO = new List<MDrugsDTO>();
                    lstMDrugsDTO = objITransactionBusiness.GetMDrugs();

                    ViewState[VSDrugName] = lstMDrugsDTO;
                }
                return (List<MDrugsDTO>)ViewState[VSDrugName];
            }
        }

        public List<MDiseaseDTO> ViewstateDisease
        {
            get
            {
                if (ViewState[VSDisease] == null)
                {
                    List<MDiseaseDTO> lstMDiseaseDTO = new List<MDiseaseDTO>();
                    lstMDiseaseDTO = objITransactionBusiness.GetMDiseases();

                    ViewState[VSDisease] = lstMDiseaseDTO;
                }
                return (List<MDiseaseDTO>)ViewState[VSDisease];
            }
        }
        public List<TempDrugsDTO> ViewstateDrugsIssues
        {
            get
            {
                if (ViewState[VSDrugs] == null)
                {
                    List<TempDrugsDTO> lstTempDrugsDTO = new List<TempDrugsDTO>();
                    ViewState[VSDrugs] = lstTempDrugsDTO;
                }
                return (List<TempDrugsDTO>)ViewState[VSDrugs];
            }
            set
            {
                ViewState[VSDrugs] = value;
            }
        }

        private List<TempDrugsDTO> GetEmptyDrugsList()
        {
            List<TempDrugsDTO> lsttempdrug = new List<TempDrugsDTO>();
            TempDrugsDTO tempdrug = new TempDrugsDTO();

            lsttempdrug.Add(tempdrug);
            return lsttempdrug;
        }

        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPatientName.Text.Trim()))
            {
                PatientDetailDTO PatientDetailDTO = new PatientDetailDTO();
                PatientDetailDTO = objITransactionBusiness.GeTPatientInfo(txtPatientName.Text.Trim());

                if (PatientDetailDTO != null)
                {
                    lblage.Text = Convert.ToString(PatientDetailDTO.Age);
                    lblbloodgroup.Text = PatientDetailDTO.BloodGroup;
                    lblVillage.Text = PatientDetailDTO.Place;
                    lblECNumber.Text = PatientDetailDTO.ECNumber;
                }
                else
                    ResetPage();
            }
            else
                ResetPage();
        }
        protected void btnSaveDrug_Click(object sender, EventArgs e)
        {
            List<TempDrugsDTO> lsttempdrug = new List<TempDrugsDTO>();
            lsttempdrug = ViewstateDrugsIssues;
            TempDrugsDTO TD = new TempDrugsDTO();
            TD.DrugIssueID = Convert.ToString(DateTime.Now);
            TD.DrugID = ddlDrugNames.SelectedValue;
            TD.DrugName = ddlDrugNames.SelectedItem.Text;
            TD.Quantity = Convert.ToInt32(txtQuantity.Text);
            TD.Dosage = txtDosage.Text;
            lsttempdrug.Add(TD);
            ViewstateDrugsIssues = lsttempdrug;
            BindLVDrugs();
            ResetDrugs();
        }

        private void ResetDrugs()
        {
            ViewState[PHCConstatnt.DrugIssueID] = null;
            ddlDrugNames.SelectedIndex = 0;
            txtQuantity.Text = string.Empty;
            txtDosage.Text = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
        protected void btnUpdateDrug_Click(object sender, EventArgs e)
        {
            string DrugIssueID = ViewState[PHCConstatnt.DrugIssueID].ToString();
            List<TempDrugsDTO> lsttempdrugs = new List<TempDrugsDTO>();
            lsttempdrugs = ViewstateDrugsIssues;

            TempDrugsDTO td = lsttempdrugs.Where(p => p.DrugIssueID == DrugIssueID).FirstOrDefault();
            td.DrugID = ddlDrugNames.SelectedValue;
            td.DrugName = Convert.ToString(ddlDrugNames.SelectedItem);
            td.Quantity = Convert.ToInt32(txtQuantity.Text);
            td.Dosage = txtDosage.Text;
            ViewstateDrugsIssues = lsttempdrugs;

            //if (resultDTO.IsSuccess)
            //{

            BindddlDrugs();
            BindLVDrugs();
            ResetDrugs();
            //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
            //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
            //lblstatus.Text = resultDTO.Message;
            //}
            //else
            //{
            //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorBackGroundColor);
            //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorForeColor);
            //lblstatus.Text = resultDTO.Message;
            //}

        }
        protected void btnCancelDrug_Click(object sender, EventArgs e)
        {
            ResetDrugs();
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {
            ResetDrugs();
            string DrugIssueID = LVDrugs.DataKeys[e.ItemIndex].Value.ToString();
            List<TempDrugsDTO> ltd = ViewstateDrugsIssues;
            TempDrugsDTO td = ltd.Where(p => p.DrugIssueID == DrugIssueID).FirstOrDefault();
            ltd.Remove(td);
            ViewstateDrugsIssues = ltd;
            BindLVDrugs();
            //if (resultDTO.IsSuccess)
            //{
            //    //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
            //    //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
            //    //lblstatus.Text = resultDTO.Message;
            //}
            //else
            //{
            //    //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorBackGroundColor);
            //    //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorForeColor);
            //    //lblstatus.Text = resultDTO.Message;
            //}
            //this.PopulateData();
        }
        protected void LVDrugs_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                //PageReset();
                Label lblDrugIssueID = (Label)e.Item.FindControl("lblDrugIssueID");
                Label lblDrugID = (Label)e.Item.FindControl("lblDrugID");
                Label lblDrugName = (Label)e.Item.FindControl("lblDrugName");
                Label lblQuantity = (Label)e.Item.FindControl("lblQuantity");
                Label lblDosage = (Label)e.Item.FindControl("lblDosage");
                List<TempDrugsDTO> lsttempdrug = new List<TempDrugsDTO>();
                lsttempdrug = ViewstateDrugsIssues;
                TempDrugsDTO td = lsttempdrug.Where(p => p.DrugIssueID == lblDrugIssueID.Text).FirstOrDefault();
                ddlDrugNames.SelectedValue = td.DrugID;
                txtQuantity.Text = Convert.ToString(td.Quantity);
                txtDosage.Text = td.Dosage;
                ViewState[PHCConstatnt.DrugIssueID] = td.DrugIssueID;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
        }
        protected void LVPHCDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }


    }
}