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
    public partial class AddVillages : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulateData();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SaveMVillage(txtVillageName.Text.ToUpper(),PHCConstant.PHCID);
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
        private void PopulateData()
        {
            List<MVillageDTO> lstVillage = new List<MVillageDTO>();
            lstVillage = objITransactionBusiness.GetMVillage(PHCConstant.PHCID);
            if (lstVillage != null && lstVillage.Count > 0)
            {
                ListView1.DataSource = lstVillage;
                ListView1.DataBind();
            }
            else
            {
                ListView1.Items.Clear();
                ListView1.DataSource = null;
                ListView1.DataBind();
            }
        }
        protected void EditRecord(object sender, ListViewEditEventArgs e)
        {
            ListView1.EditIndex = e.NewEditIndex;
            this.PopulateData();
        }
        protected void UpdateRecord(object sender, ListViewUpdateEventArgs e)
        {
            string VillageID = ListView1.DataKeys[e.ItemIndex].Value.ToString();
            ListViewItem item = ListView1.Items[e.ItemIndex];
            TextBox txteVillagename = (TextBox)item.FindControl("txteVillageName");

            ResultDTO resultDTO = objITransactionBusiness.UpdateMVillage(VillageID, PHCConstant.PHCID, txteVillagename.Text.ToUpper());
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
            ListView1.EditIndex = -1;
            // repopulate the data
            this.PopulateData();
        }
        protected void CancelEditRecord(object sender, ListViewCancelEventArgs e)
        {

            ListView1.EditIndex = -1;
            this.PopulateData();
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {

            string VillageID = ListView1.DataKeys[e.ItemIndex].Value.ToString();
            ResultDTO resultDTO = objITransactionBusiness.DeleteMVillage(VillageID, PHCConstant.PHCID);
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
        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }

    }
}