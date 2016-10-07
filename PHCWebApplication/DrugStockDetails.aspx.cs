using PHC.BAInterfaces.Business;
using PHC.BAInterfaces.DataTransfer;
using PHC.Binder.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AllInOne.Common.Library.Util;
using PHC.BAInterfaces.Constants;
namespace PHCWebApplication
{
    public partial class DrugStockDetails : System.Web.UI.Page
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
            this.BindDrugs();
            txtQuantity.Text = string.Empty;
            txtBatchNo.Text = string.Empty;
            txtManufactureDate.Text = string.Empty;
            txtExpiryDate.Text = string.Empty;
            txtPurchaseDate.Text = string.Empty;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        private void BindDrugs()
        {
            List<MDrugsDTO> lstMDrugsDTO = ViewstateDrugNames;
            if (lstMDrugsDTO != null && lstMDrugsDTO.Count > 0)
            {
                ddlDrugNames.DataSource = lstMDrugsDTO;
                ddlDrugNames.DataBind();
                ddlDrugNames.Items.Insert(0, "Select Drug");
            }
        }
        private void PopulateData()
        {

            List<DrugStockDTO> lstDrugStockDTO = new List<DrugStockDTO>();
            lstDrugStockDTO = objITransactionBusiness.GetDrugPurchaseDetail(PHCConstant.PHCID);
            if (lstDrugStockDTO != null && lstDrugStockDTO.Count > 0)
            {
                LVDrugsStockDetails.DataSource = lstDrugStockDTO;
                LVDrugsStockDetails.DataBind();
            }
            else
            {

            }
        }
        const string VSDrugName = "VSDrugName";
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SaveDrugStock(ddlDrugNames.SelectedValue,PHCConstant.PHCID, Convert.ToInt16(txtQuantity.Text), txtBatchNo.Text, txtManufactureDate.Text, txtExpiryDate.Text, txtPurchaseDate.Text);
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string DrugStockID = ViewState["DrugStockID"].ToString();
            ResultDTO resultDTO = objITransactionBusiness.UpdateDrugStock(DrugStockID, ddlDrugNames.SelectedValue,PHCConstant.PHCID, Convert.ToInt16(txtQuantity.Text), txtBatchNo.Text, txtManufactureDate.Text, txtExpiryDate.Text, txtPurchaseDate.Text);

            if (resultDTO.IsSuccess)
            {
                ViewState["DrugStockID"] = null;
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PageReset();
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {
            PageReset();
            string DrugStockID = LVDrugsStockDetails.DataKeys[e.ItemIndex].Value.ToString();
            ResultDTO resultDTO = objITransactionBusiness.DeleteDrugStock(DrugStockID);
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
        protected void LVDrugsStockDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }
        protected void LVDrugsStockDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditData")
            {
                //PageReset();
                Label lblPHCID = (Label)e.Item.FindControl("lblPHCID");
                Label lblDrugStockID = (Label)e.Item.FindControl("lblDrugStockID");
                Label lblDrugID = (Label)e.Item.FindControl("lblDrugID");
                Label lblPHCName = (Label)e.Item.FindControl("lblPHCName");
                Label lblQuantity = (Label)e.Item.FindControl("lblQuantity");
                Label lblBatchNo = (Label)e.Item.FindControl("lblBatchNo");
                Label lblMfDate = (Label)e.Item.FindControl("lblMfDate");
                Label lblExpDate = (Label)e.Item.FindControl("lblExpDate");
                Label lblPurchaseDate = (Label)e.Item.FindControl("lblPurchaseDate");

                string DrugStockID = lblDrugStockID.Text;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                ddlDrugNames.SelectedValue = lblDrugID.Text;
                txtQuantity.Text = lblQuantity.Text;
                txtBatchNo.Text = lblBatchNo.Text;
                txtManufactureDate.Text = lblMfDate.Text;
                txtExpiryDate.Text = lblExpDate.Text;
                txtPurchaseDate.Text = lblPurchaseDate.Text;
                ViewState["DrugStockID"] = DrugStockID;
            }
        }

    }
}