﻿using PHC.BAInterfaces.Business;
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
        string VSPatientID = PHCConstatnt.VSPatientID;
        string VSECNo = PHCConstatnt.VSECNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageReset();
                this.PopulateData();
            }
        }
        private void PageReset()
        {
            this.BindVillages();
            this.BindBloodGroup();
            txtPatientName.Text = string.Empty;
            txtECNo.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtDOB.Text = string.Empty;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            txtContactNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
        private void PopulateData()
        {

            List<PatientDetailDTO> lstPatientDetailDTO = new List<PatientDetailDTO>();
            lstPatientDetailDTO = objITransactionBusiness.GetPatientDetail(PHCConstatnt.PHCID);
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
        const string VSVillages = PHCConstatnt.VSVillages;
        public List<MVillageDTO> ViewstateVillages
        {
            get
            {
                if (ViewState[VSVillages] == null)
                {
                    List<MVillageDTO> lstMVillageDTO = new List<MVillageDTO>();
                    lstMVillageDTO = objITransactionBusiness.GetMVillages(PHCConstatnt.PHCID);
                    ViewState[VSVillages] = lstMVillageDTO;
                }
                return (List<MVillageDTO>)ViewState[VSVillages];
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SavePatientDetails(PHCConstatnt.PHCID, txtPatientName.Text, txtECNo.Text, Convert.ToInt16(txtAge.Text), txtDOB.Text, GetGender(), ddlBloodGroup.SelectedItem.Text, ddlVillages.SelectedValue, txtAddress.Text, txtContactNo.Text, txtPhoneNo.Text);
            if (resultDTO.IsSuccess)
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
                lblstatus.Text = resultDTO.Message;
                this.PageReset();
                this.PopulateData();
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorForeColor);
                lblstatus.Text = resultDTO.Message;
            }
        }
        private string GetGender()
        {
            if (rbMale.Checked)
                return PHCConstatnt.Male;
            else if (rbFemale.Checked)
                return PHCConstatnt.FeMale;
            else
                return string.Empty;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string PatientID =Convert.ToString(ViewState[VSPatientID]);
            string ECno = Convert.ToString( ViewState[VSECNo]);
            ResultDTO resultDTO = new ResultDTO();
            if ((!string.IsNullOrEmpty(ECno) && !string.IsNullOrEmpty(txtECNo.Text)) || string.IsNullOrEmpty(ECno))
                resultDTO = objITransactionBusiness.UpdatePatientDetail(PHCConstatnt.PHCID, PatientID, txtPatientName.Text, txtECNo.Text, Convert.ToInt16(txtAge.Text), txtDOB.Text, GetGender(), ddlBloodGroup.SelectedItem.Text, ddlVillages.SelectedValue, txtAddress.Text, txtContactNo.Text, txtPhoneNo.Text);
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
                //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
                //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
                //lblstatus.Text = resultDTO.Message;
            }
            else
            {
                //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorBackGroundColor);
                //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorForeColor);
                //lblstatus.Text = resultDTO.Message;
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
                //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
                //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
                //lblstatus.Text = resultDTO.Message;
            }
            else
            {
                //pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorBackGroundColor);
                //lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.ErrorForeColor);
                //lblstatus.Text = resultDTO.Message;
            }
            this.PopulateData();
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
                if (lblGender.Text == PHCConstatnt.Male)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;

                txtAge.Text = lblAge.Text;
                txtDOB.Text = lblDOB.Text;
                BindVillages();
                ddlVillages.SelectedValue = lblVillageID.Text;
                txtAddress.Text = lblAddress.Text;

                txtContactNo.Text = lblContactNo.Text;
                txtPhoneNo.Text = lblRefPhoneNo.Text;
                ViewState[VSPatientID] = PatientID;
            }
        }


    }
}