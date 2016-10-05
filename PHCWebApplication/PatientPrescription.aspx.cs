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
                BindddlLabTest();
                BindLVLabTest();
                btnUpdate.Visible = false;
                btnSave.Visible = true;

            }
        }

        private void BindPatientVisitHistory(string PatientID, string PHCID)
        {
            try
            {
                List<PatientVistiHistoryDTO> lstPVH = objITransactionBusiness.GetPatientVistHistory(PatientID, PHCID);
                LVPatientVisit.DataSource = lstPVH;
                LVPatientVisit.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
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
            ddlDisease.Items.Insert(0, "Select Disease");
        }

        protected void ResetPage()
        {
            lblage.Text = string.Empty;
            lblbloodgroup.Text = string.Empty;
            lblECNumber.Text = string.Empty;
            lblVillage.Text = string.Empty;
        }
        const string VSDisease = PHCConstatnt.VSDisease;
        const string VSDrugs = PHCConstatnt.VSDrugs;
        const string VSDrugName = PHCConstatnt.VSDrugName;
        const string VSPatientID = PHCConstatnt.VSPatientID;
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
        public string ViewStatePatientID
        {
            get
            {
                if (ViewState[VSPatientID] == null)
                    return string.Empty;
                else
                    return (string)ViewState[VSPatientID];
            }
            set
            {
                ViewState[VSPatientID] = value;
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
                PatientDetailDTO = objITransactionBusiness.GeTPatientInfo(txtPatientName.Text.Trim(), PHCConstatnt.PHCID);

                if (PatientDetailDTO != null)
                {
                    ViewStatePatientID = PatientDetailDTO.PatientID;
                    lblage.Text = Convert.ToString(PatientDetailDTO.Age);
                    lblbloodgroup.Text = PatientDetailDTO.BloodGroup;
                    lblVillage.Text = PatientDetailDTO.Place;
                    lblECNumber.Text = PatientDetailDTO.ECNumber;
                    BindPatientVisitHistory(PatientDetailDTO.PatientID, PatientDetailDTO.PHCID);

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
            TD.Quantity = Convert.ToInt16(txtQuantity.Text);
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
            td.Quantity = Convert.ToInt16(txtQuantity.Text);
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

        #region LabTest
        const string VSLabTest = PHCConstatnt.VSLabTest;
        private void BindddlLabTest()
        {
            List<MLabTestDTO> lstMLabTestDTO = new List<MLabTestDTO>();
            lstMLabTestDTO = objITransactionBusiness.GetMLabTest();
            if (lstMLabTestDTO != null && lstMLabTestDTO.Count > 0)
            {
                ddlLabTestNames.DataSource = lstMLabTestDTO;
                ddlLabTestNames.DataBind();
                ddlLabTestNames.Items.Insert(0, "Select LabTest");
            }
        }
        public List<TempLabTestDTO> ViewstateLabTest
        {
            get
            {
                if (ViewState[VSLabTest] == null)
                {
                    List<TempLabTestDTO> lstTempLabTestDTO = new List<TempLabTestDTO>();
                    ViewState[VSLabTest] = lstTempLabTestDTO;
                }
                return (List<TempLabTestDTO>)ViewState[VSLabTest];
            }
            set
            {
                ViewState[VSLabTest] = value;
            }
        }
        private void BindLVLabTest()
        {
            LVLabTest.DataSource = ViewstateLabTest;
            LVLabTest.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<TempLabTestDTO> lsttempLab = new List<TempLabTestDTO>();
            lsttempLab = ViewstateLabTest;
            TempLabTestDTO TL = new TempLabTestDTO();
            TL.LabTestID = ddlLabTestNames.SelectedValue;
            TL.LabTestName = ddlLabTestNames.SelectedItem.Text;
            lsttempLab.Add(TL);
            ViewstateLabTest = lsttempLab;
            BindLVLabTest();
            ResetLabs();
        }
        private void ResetLabs()
        {
            ViewState[PHCConstatnt.LabTestID] = null;
            ddlLabTestNames.SelectedIndex = 0;
        }
        protected void EditRecord(object sender, ListViewEditEventArgs e)
        {
            LVLabTest.EditIndex = e.NewEditIndex;
            this.BindLVLabTest();
        }
        protected void UpdateRecord(object sender, ListViewUpdateEventArgs e)
        {
            string LabTestID = ViewState[PHCConstatnt.LabTestID].ToString();
            List<TempLabTestDTO> lsttemplabtest = new List<TempLabTestDTO>();
            lsttemplabtest = ViewstateLabTest;

            TempLabTestDTO td = lsttemplabtest.Where(p => p.LabTestID == LabTestID).FirstOrDefault();
            td.LabTestName = Convert.ToString(ddlLabTestNames.SelectedItem);
            ViewstateLabTest = lsttemplabtest;

            //if (resultDTO.IsSuccess)
            //{

            BindLVLabTest();
            ResetLabs();

        }
        protected void CancelEditRecord(object sender, ListViewCancelEventArgs e)
        {
            LVLabTest.EditIndex = -1;
            BindLVLabTest();
        }
        protected void DeleteLabTest(object sender, ListViewDeleteEventArgs e)
        {
            ResetLabs();
            string LabTestID = LVDrugs.DataKeys[e.ItemIndex].Value.ToString();
            List<TempLabTestDTO> llt = ViewstateLabTest;
            TempLabTestDTO td = llt.Where(p => p.LabTestID == LabTestID).FirstOrDefault();
            llt.Remove(td);
            ViewstateLabTest = llt;
            BindLVLabTest();

        }
        protected void OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LVLabTest.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList ddlLabTest = (e.Item.FindControl("ddlLabTest") as DropDownList);

                List<MLabTestDTO> lstlabTest = new List<MLabTestDTO>();
                lstlabTest = objITransactionBusiness.GetMLabTest();

                ddlLabTest.DataSource = lstlabTest;
                ddlLabTest.DataBind();
                ddlLabTest.Items.Insert(0, new ListItem("Select LabTest", "0"));
                Label lblLabTestName = (e.Item.FindControl("lblLabTestName") as Label);
                ddlLabTest.Items.FindByText(lblLabTestName.Text).Selected = true;
            }
        }
        #endregion
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            List<TempDrugsDTO> lTD = ViewstateDrugsIssues;
            List<TempLabTestDTO> lLT = ViewstateLabTest;
            if (lTD != null && lTD.Count > 0)
            {
                ResultDTO resultDTO = objITransactionBusiness.SavePatientPrescription(ViewStatePatientID, PHCConstatnt.PHCID, ddlDisease.SelectedValue, txtdescription.Text, lTD, lLT);
                if (resultDTO.IsSuccess)
                {
                    pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
                    lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
                    lblstatus.Text = resultDTO.Message;
                    PageReset();
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
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.WarningForeColor);
                lblstatus.Text = "Please enter Mandator fields";
            }
        }

        private void PageReset()
        {
            try
            {
                ViewStatePatientID = string.Empty;
                ViewstateDrugsIssues = null;
                ViewstateLabTest = null;
                txtPatientName.Text = string.Empty;
                txtDosage.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtdescription.Text = string.Empty;
                BindLVDrugs();
                BindLVLabTest();
                ResetDrugs();
                ResetLabs();
                BindDisease();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}