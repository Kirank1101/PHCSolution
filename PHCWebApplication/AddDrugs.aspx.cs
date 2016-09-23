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
    public partial class AddDrugs : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PopulateData();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SaveMDrug(txtDrugName.Text, Convert.ToInt32(txtquantity.Text), txtBatchNo.Text, Convert.ToDateTime(txtMfd.Text), Convert.ToDateTime(txtExpdt.Text), Convert.ToDateTime(txtPurchasedate.Text));
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
        private void PopulateData()
        {
            List<MDrugsDTO> lstdrugs = new List<MDrugsDTO>();
            lstdrugs = objITransactionBusiness.GetMDrugs();
            if (lstdrugs != null && lstdrugs.Count > 0)
            {
                ListView1.DataSource = lstdrugs;
                ListView1.DataBind();
            }
            else
            {

            }
        }
        protected void EditRecord(object sender, ListViewEditEventArgs e)
        {
            ListView1.EditIndex = e.NewEditIndex;
            this.PopulateData();
        }
        protected void UpdateRecord(object sender, ListViewUpdateEventArgs e)
        {
            string DrugID = ListView1.DataKeys[e.ItemIndex].Value.ToString();
            ListViewItem item = ListView1.Items[e.ItemIndex];
            TextBox txtedrugname = (TextBox)item.FindControl("txteDrugName");
            TextBox txteQuantity = (TextBox)item.FindControl("txteQuantity");
            TextBox txteBatchNo = (TextBox)item.FindControl("txteBatchNo");
            TextBox txteMfDate = (TextBox)item.FindControl("txteMfDate");
            TextBox txteExpDate = (TextBox)item.FindControl("txteExpDate");
            TextBox txtePurchaseDate = (TextBox)item.FindControl("txtePurchaseDate");

            ResultDTO resultDTO = objITransactionBusiness.UpdateMDrug(DrugID, txtedrugname.Text, Convert.ToInt32(txteQuantity.Text), txteBatchNo.Text, Convert.ToDateTime(txteMfDate.Text), Convert.ToDateTime(txteExpDate.Text), Convert.ToDateTime(txtePurchaseDate.Text));
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

            string DrugID = ListView1.DataKeys[e.ItemIndex].Value.ToString();
            ResultDTO resultDTO = objITransactionBusiness.DeleteMDrug(DrugID);
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