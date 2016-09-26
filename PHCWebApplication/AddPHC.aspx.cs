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
                this.BindDistricts();
            }
        }
        private void BindDistricts()
        {
            List<MDistrictDTO> lstdistrict = new List<MDistrictDTO>();
            lstdistrict = objITransactionBusiness.GetMDistricts();
            if (lstdistrict != null && lstdistrict.Count > 0)
            {
                ddlDistrictNames.DataSource = lstdistrict;
                ddlDistrictNames.DataBind();
                ddlDistrictNames.Items.Insert(0, "Select District");
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

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SaveMPHC(ddlDistrictNames.SelectedValue, ddlTalukNames.SelectedValue, txtPHCName.Text);
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
            this.PopulateData();
        }
        protected void EditRecord(object sender, ListViewEditEventArgs e)
        {
            LVPHCDetails.EditIndex = e.NewEditIndex;
            this.PopulateData();
        }
        protected void UpdateRecord(object sender, ListViewUpdateEventArgs e)
        {
            string PHCID = LVPHCDetails.DataKeys[e.ItemIndex].Value.ToString();
            ListViewItem item = LVPHCDetails.Items[e.ItemIndex];
            TextBox txtePHCName = (TextBox)item.FindControl("txtePHCName");
            DropDownList ddlDistrict = (DropDownList)item.FindControl("ddlDistrict");

            //ResultDTO resultDTO = objITransactionBusiness.UpdateMPHC(PHCID, ddlDistrict.SelectedValue, ddleTaluk.SelectedValue, txtePHCName.Text);
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
            //lblMessage.Text = "Record updated successfully !";
            LVPHCDetails.EditIndex = -1;
            // repopulate the data
            this.PopulateData();
        }
        protected void CancelEditRecord(object sender, ListViewCancelEventArgs e)
        {

            LVPHCDetails.EditIndex = -1;
            this.PopulateData();
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {

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
        protected void OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (LVPHCDetails.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList ddlDistrict = (e.Item.FindControl("ddlDistrict") as DropDownList);

                List<MDistrictDTO> lstdistrict = new List<MDistrictDTO>();
                lstdistrict = objITransactionBusiness.GetMDistricts();

                ddlDistrict.DataSource = lstdistrict;
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
                Label lblDistrictName = (e.Item.FindControl("lblDistrictName") as Label);
                ddlDistrict.Items.FindByText(lblDistrictName.Text).Selected = true;
            }
        }
        protected void LVPHCDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
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

    }
}