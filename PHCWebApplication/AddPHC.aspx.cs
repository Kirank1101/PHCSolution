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
    public partial class AddPHC : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();

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
            this.BindDistricts();
            txtPHCName.Text = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            ddlDistrictNames.Enabled = true;
            ddlTalukNames.Enabled = true;
        }
        private void BindDistricts()
        {
            List<MDistrictDTO> lstdistrict = ViewstateDistricts;
            if (lstdistrict != null && lstdistrict.Count > 0)
            {
                ddlDistrictNames.DataSource = lstdistrict;
                ddlDistrictNames.DataBind();
                ddlDistrictNames.Items.Insert(0, "Select District");
                ddlTalukNames.Items.Clear();
                ddlTalukNames.Items.Insert(0, "Select Taluk");
            }
        }
        private void PopulateData()
        {
            List<MPHCDTO> lstMPHC = new List<MPHCDTO>();
            lstMPHC = objITransactionBusiness.GetMPHC();
            if (lstMPHC != null && lstMPHC.Count > 0)
            {
                LVPHCDetails.DataSource = lstMPHC;
                LVPHCDetails.DataBind();
            }
            else
            {
                LVPHCDetails.Items.Clear();
                LVPHCDetails.DataSource = null;
                LVPHCDetails.DataBind();
            }
        }
        const string VSDistrict = PHCConstant.VSDistrict;
        public List<MDistrictDTO> ViewstateDistricts
        {
            get
            {
                if (ViewState[VSDistrict] == null)
                {
                    List<MDistrictDTO> lstdistrict = new List<MDistrictDTO>();
                    lstdistrict = objITransactionBusiness.GetMDistricts();

                    ViewState[VSDistrict] = lstdistrict;
                }
                return (List<MDistrictDTO>)ViewState[VSDistrict];
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SaveMPHC(ddlTalukNames.SelectedValue, txtPHCName.Text);
            if (resultDTO.IsSuccess)
            {
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
            this.PopulateData();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string PHCID = ViewState["PHCID"].ToString();
            ResultDTO resultDTO = objITransactionBusiness.UpdateMPHC(PHCID, txtPHCName.Text);

            if (resultDTO.IsSuccess)
            {
                ViewState["PHCID"] = null;
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PageReset();
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {
            PageReset();
            string PHCID = LVPHCDetails.DataKeys[e.ItemIndex].Value.ToString();
            ResultDTO resultDTO = objITransactionBusiness.DeleteMPHC(PHCID);
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
        protected void LVPHCDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }
        private void BindTaluks(string DistrictID)
        {
            List<MTalukDTO> lstTaluk = new List<MTalukDTO>();
            lstTaluk = objITransactionBusiness.GetMTalukNames(DistrictID);
            if (lstTaluk != null && lstTaluk.Count > 0)
            {
                ddlTalukNames.DataSource = lstTaluk;
                ddlTalukNames.DataBind();
                ddlTalukNames.Items.Insert(0, "Select Taluk");
            }
        }
        protected void LVPHCDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                PageReset();
                Label lblPHCID = (Label)e.Item.FindControl("lblPHCID");
                Label lblDistrictID = (Label)e.Item.FindControl("lblDistrictID");
                Label lblTalukID = (Label)e.Item.FindControl("lblTalukID");
                Label lblPHCName = (Label)e.Item.FindControl("lblPHCName");

                string PHCID = lblPHCID.Text;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                ddlDistrictNames.SelectedValue = lblDistrictID.Text;
                BindTaluks(lblDistrictID.Text);
                ddlTalukNames.SelectedValue = lblTalukID.Text;
                txtPHCName.Text = lblPHCName.Text;
                ddlDistrictNames.Enabled = false;
                ddlTalukNames.Enabled = false;
                ViewState["PHCID"] = PHCID;
            }
        }
        protected void ddlDistrictNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrictNames.SelectedIndex > 0)
            {
                BindTaluks(ddlDistrictNames.SelectedValue);
            }
            else
            {
                ddlTalukNames.Items.Clear();
                ddlTalukNames.DataSource = null;
                ddlTalukNames.DataBind();
                ddlTalukNames.Items.Insert(0, "Select Taluk");
            }
        }
        
    }
}