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

namespace WebApplication5
{
    public partial class AddPatientDetails : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        string VSPatientID = PHCConstant.VSPatientID;
        string VSECNo = PHCConstant.VSECNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageReset();
                this.PopulateData();
                rbUnmarried.Checked = true;
                rbMale.Checked = true;
            }
        }
        private void PageReset()
        {
            this.BindVillages();
            this.BindBloodGroup();
            this.BindReligion();
            this.BindEducation();
            txtPatientName.Text = string.Empty;
            txtECNo.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtDOB.Text = string.Empty;
            rbMale.Checked = true;
            rbUnmarried.Checked = true;
            txtContactNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
        private void BindEducation()
        {
            List<MEducationDTO> lstMEducationDTO = ViewstateEducation;
            if (lstMEducationDTO != null && lstMEducationDTO.Count > 0)
            {
                ddlEducation.DataSource = lstMEducationDTO;
                ddlEducation.DataBind();
                ddlEducation.Items.Insert(0, "Select Education");
            }
            else
                ddlEducation.Items.Insert(0, "Select Education");

        }
        private void BindReligion()
        {
            List<MReligionDTO> lstMReligionDTO = ViewstateReligion;
            if (lstMReligionDTO != null && lstMReligionDTO.Count > 0)
            {
                ddlReligion.DataSource = lstMReligionDTO;
                ddlReligion.DataBind();
                ddlReligion.Items.Insert(0, "Select Religion");
            }
            else
                ddlReligion.Items.Insert(0, "Select Religion");

        }
        private void PopulateData()
        {

            List<PatientDetailDTO> lstPatientDetailDTO = new List<PatientDetailDTO>();
            lstPatientDetailDTO = objITransactionBusiness.GetPatientDetail(PHCConstant.PHCID);
            if (lstPatientDetailDTO != null && lstPatientDetailDTO.Count > 0)
            {
                LVPatientDetailDetails.DataSource = lstPatientDetailDTO;
                LVPatientDetailDetails.DataBind();
            }
            else
            {

            }
        }
        private void BindVillages()
        {
            List<MVillageDTO> lstMVillageDTO = ViewstateVillages;
            if (lstMVillageDTO != null && lstMVillageDTO.Count > 0)
            {
                ddlVillages.DataSource = lstMVillageDTO;
                ddlVillages.DataBind();
                ddlVillages.Items.Insert(0, "Select Village");
            }
            else
                ddlVillages.Items.Insert(0, "Select Village");


        }
        private void BindBloodGroup()
        {
            List<BloodGroupDTO> lstbloodgroup = objITransactionBusiness.GetBloodGroup();
            ddlBloodGroup.DataSource = lstbloodgroup;
            ddlBloodGroup.DataBind();
            ddlBloodGroup.Items.Insert(0, "Select BloodGroup");
        }
        const string VSVillages = PHCConstant.VSVillages;
        public List<MVillageDTO> ViewstateVillages
        {
            get
            {
                if (ViewState[VSVillages] == null)
                {
                    List<MVillageDTO> lstMVillageDTO = new List<MVillageDTO>();
                    lstMVillageDTO = objITransactionBusiness.GetMVillages(PHCConstant.PHCID);
                    ViewState[VSVillages] = lstMVillageDTO;
                }
                return (List<MVillageDTO>)ViewState[VSVillages];
            }
        }
        const string VSEducation = PHCConstant.VSEducation;
        public List<MEducationDTO> ViewstateEducation
        {
            get
            {
                if (ViewState[VSEducation] == null)
                {
                    List<MEducationDTO> lstMEducationDTO = new List<MEducationDTO>();
                    lstMEducationDTO = objITransactionBusiness.GetMEducation();
                    ViewState[VSEducation] = lstMEducationDTO;
                }
                return (List<MEducationDTO>)ViewState[VSEducation];
            }
        }
        const string VSReligion = PHCConstant.VSReligion;
        public List<MReligionDTO> ViewstateReligion
        {
            get
            {
                if (ViewState[VSReligion] == null)
                {
                    List<MReligionDTO> lstMReligionDTO = new List<MReligionDTO>();
                    lstMReligionDTO = objITransactionBusiness.GetMReligion();
                    ViewState[VSReligion] = lstMReligionDTO;
                }
                return (List<MReligionDTO>)ViewState[VSReligion];
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SavePatientDetails(PHCConstant.PHCID, txtPatientName.Text, txtECNo.Text, Convert.ToInt16(txtAge.Text), txtDOB.Text, GetGender(), ddlBloodGroup.SelectedItem.Text, ddlVillages.SelectedValue, txtAddress.Text, txtContactNo.Text, txtPhoneNo.Text, ddlEducation.SelectedValue, ddlReligion.SelectedValue, rbMarried.Checked ? "M" : "S", txtFatherName.Text, txtHusbandName.Text);
            if (resultDTO.IsSuccess)
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.SuccessBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.SuccessForeColor);
                lblstatus.Text = resultDTO.Message;
                this.PageReset();
                this.PopulateData();
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.ErrorBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.ErrorForeColor);
                lblstatus.Text = resultDTO.Message;
            }
        }
        private string GetGender()
        {
            if (rbMale.Checked)
                return PHCConstant.Male;
            else if (rbFemale.Checked)
                return PHCConstant.FeMale;
            else
                return string.Empty;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string PatientID =Convert.ToString(ViewState[VSPatientID]);
            string ECno = Convert.ToString( ViewState[VSECNo]);
            ResultDTO resultDTO = new ResultDTO();
            if ((!string.IsNullOrEmpty(ECno) && !string.IsNullOrEmpty(txtECNo.Text)) || string.IsNullOrEmpty(ECno))
                resultDTO = objITransactionBusiness.UpdatePatientDetail(PHCConstant.PHCID, PatientID, txtPatientName.Text, txtECNo.Text, Convert.ToInt16(txtAge.Text), txtDOB.Text, GetGender(), ddlBloodGroup.SelectedItem.Text, ddlVillages.SelectedValue, txtAddress.Text, txtContactNo.Text, txtPhoneNo.Text, ddlEducation.SelectedValue, ddlReligion.SelectedValue, rbMarried.Checked? "M" : "S", txtFatherName.Text, txtHusbandName.Text);
            else
            {
                resultDTO.IsSuccess = false;
                resultDTO.Message = "EC Number is Required";
            }
            if (resultDTO.IsSuccess)
            {
                ViewState[VSECNo] = null;
                ViewState[VSPatientID] = null;
                PageReset();
                this.PopulateData();
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.SuccessBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.SuccessForeColor);
                lblstatus.Text = resultDTO.Message;
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.ErrorBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.ErrorForeColor);
                lblstatus.Text = resultDTO.Message;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PageReset();
            ViewState[VSPatientID] = null;
            ViewState[VSECNo] = null;
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {
            PageReset();
            string PatientID = LVPatientDetailDetails.DataKeys[e.ItemIndex].Value.ToString();
            ResultDTO resultDTO = objITransactionBusiness.DeletePatientDetail(PatientID);
            if (resultDTO.IsSuccess)
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.SuccessBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.SuccessForeColor);
                lblstatus.Text = resultDTO.Message;
                this.PopulateData();
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.ErrorBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.ErrorForeColor);
                lblstatus.Text = resultDTO.Message;
            }
        }
        protected void LVPatientDetailDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }
        protected void LVPatientDetailDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                //PageReset();
                Label lblPHCID = (Label)e.Item.FindControl("lblPHCID");
                Label lblPatientID = (Label)e.Item.FindControl("lblPatientID");
                Label lblPatientName = (Label)e.Item.FindControl("lblPatientName");
                Label lblECNumber = (Label)e.Item.FindControl("lblECNumber");
                Label lblBloodGroup = (Label)e.Item.FindControl("lblBloodGroup");
                Label lblGender = (Label)e.Item.FindControl("lblGender");
                Label lblAge = (Label)e.Item.FindControl("lblAge");
                Label lblDOB = (Label)e.Item.FindControl("lblDOB");
                Label lblPlace = (Label)e.Item.FindControl("lblPlace");
                Label lblContactNo = (Label)e.Item.FindControl("lblContactNo");
                Label lblRefPhoneNo = (Label)e.Item.FindControl("lblRefPhoneNo");
                Label lblAddress = (Label)e.Item.FindControl("lblAddress");
                Label lblVillageID = (Label)e.Item.FindControl("lblVillageID");

                Label lblEducationID = (Label)e.Item.FindControl("lblEducationID");
                Label lblReligionID = (Label)e.Item.FindControl("lblReligionID");
                Label lblIsMarried = (Label)e.Item.FindControl("lblIsMarried");
                Label lblHusbandName = (Label)e.Item.FindControl("lblHusbandName");
                Label lblFatherName = (Label)e.Item.FindControl("lblFatherName");
                string PatientID = lblPatientID.Text;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                txtPatientName.Text = lblPatientName.Text;
                txtECNo.Text = lblECNumber.Text;
                if (!string.IsNullOrEmpty(txtECNo.Text))
                    ViewState[VSECNo] = txtECNo.Text;
                else
                    ViewState[VSECNo] = null;

                ddlBloodGroup.SelectedValue = lblBloodGroup.Text;
                if (lblGender.Text == PHCConstant.Male)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;

                if (lblIsMarried.Text == PHCConstant.Married)
                    rbMale.Checked=true;
                else if (lblIsMarried.Text == PHCConstant.Single)
                    rbUnmarried.Checked=true;

                txtHusbandName.Text = lblHusbandName.Text;
                txtFatherName.Text = lblFatherName.Text;
                txtAge.Text = lblAge.Text;
                txtDOB.Text = lblDOB.Text;
                BindVillages();
                ddlVillages.SelectedValue = lblVillageID.Text;

                BindReligion();
                ddlReligion.SelectedValue = lblReligionID.Text;
                BindEducation();
                ddlEducation.SelectedValue = lblEducationID.Text;
                
                txtAddress.Text = lblAddress.Text;

                txtContactNo.Text = lblContactNo.Text;
                txtPhoneNo.Text = lblRefPhoneNo.Text;
                ViewState[VSPatientID] = PatientID;
            }
        }


    }
}