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
    public partial class AddTaluk : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindDistricts();
                this.PopulateData();
            }
        }

        private void BindDistricts()
        {
            List<MDistrictDTO> lstdistrict = new List<MDistrictDTO>();
            lstdistrict = objITransactionBusiness.GetMDistricts();
            if (lstdistrict != null && lstdistrict.Count > 0) {
                ddlDistrictNames.DataSource = lstdistrict;
                ddlDistrictNames.DataBind();
                ddlDistrictNames.Items.Insert(0, "Select District");
            }
        }
        private void PopulateData()
        {
            List<MTalukDTO> lstMTaluk = new List<MTalukDTO>();
            lstMTaluk = objITransactionBusiness.GetMTaluk();
            if (lstMTaluk != null && lstMTaluk.Count > 0)
            {
                LVTalukDetails.DataSource = lstMTaluk;
                LVTalukDetails.DataBind();
            }
            else
            {

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SaveMTaluk(ddlDistrictNames.SelectedValue, txtTalukName.Text);
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
        protected void EditRecord(object sender, ListViewEditEventArgs e)
        {
            LVTalukDetails.EditIndex = e.NewEditIndex;
            this.PopulateData();
        }
        protected void UpdateRecord(object sender, ListViewUpdateEventArgs e)
        {
            string TalukID = LVTalukDetails.DataKeys[e.ItemIndex].Value.ToString();
            ListViewItem item = LVTalukDetails.Items[e.ItemIndex];
            TextBox txteTalukName = (TextBox)item.FindControl("txteTalukName");
            DropDownList ddlDistrict = (DropDownList)item.FindControl("ddlDistrict");

            ResultDTO resultDTO = objITransactionBusiness.UpdateMTaluk(TalukID, ddlDistrict.SelectedValue, txteTalukName.Text);
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
            //lblMessage.Text = "Record updated successfully !";
            LVTalukDetails.EditIndex = -1;
            // repopulate the data
            this.PopulateData();
        }
        protected void CancelEditRecord(object sender, ListViewCancelEventArgs e)
        {

            LVTalukDetails.EditIndex = -1;
            this.PopulateData();
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {

            string TalukID = LVTalukDetails.DataKeys[e.ItemIndex].Value.ToString();
            ResultDTO resultDTO = objITransactionBusiness.DeleteMTaluk(TalukID);
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
            if (LVTalukDetails.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
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
        protected void LVTalukDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }

    }
}