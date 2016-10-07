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
    public partial class ClearTransaction : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulateData();
            }
        }
        private void PopulateData()
        {
            List<PHCTransactionDTO> lstphctran = objITransactionBusiness.GetPendingTransactionDetails(PHCConstant.PHCID);
            if (lstphctran != null && lstphctran.Count > 0)
            {
                LVPHCTransDetails.DataSource = lstphctran;
                LVPHCTransDetails.DataBind();
            }
            else
            {
                LVPHCTransDetails.Items.Clear();
                LVPHCTransDetails.DataSource = null;
                LVPHCTransDetails.DataBind();
            }
        }
        protected void LVPHCTransDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "TransactionCompleted")
            {
                Label lblPHCTransactionID = (Label)e.Item.FindControl("lblPHCTransactionID");

                ResultDTO resultDTO = objITransactionBusiness.UpdateTransaction(lblPHCTransactionID.Text, PHCConstant.PHCID);
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
        }
        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            List<PHCTransactionDTO> lstPHCTransactionDTO = new List<PHCTransactionDTO>();
            lstPHCTransactionDTO = objITransactionBusiness.GetPatientPendingTransaction(txtPatientName.Text.Trim(), PHCConstant.PHCID);

            if (lstPHCTransactionDTO != null && lstPHCTransactionDTO.Count > 0)
            {
                LVPHCTransDetails.DataSource = lstPHCTransactionDTO;
                LVPHCTransDetails.DataBind();
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.WarningBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.WarningForeColor);
                lblstatus.Text = PHCConstant.NoRecordExist;
            }

        }
        protected void LVPHCTransDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }
    }
}