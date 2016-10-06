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
    public partial class PHCTransaction : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rblTransaction.Items[0].Selected = true;
                lblReceivedorGiven.Text = PHCConstant.HandOver;
                RFVReceivedOrGiven.ErrorMessage = PHCConstant.ErrorMessageHandOver;
                BindLVPHCTransDetails();
            }
        }

        private void BindLVPHCTransDetails()
        {
            List<PHCTransactionDTO> lstphctran = objITransactionBusiness.GetPHCTransactionDetails(PHCConstant.PHCID);
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
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.WarningBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.WarningForeColor);
                lblstatus.Text = PHCConstant.PHCTransactionWarning;
                btnSave.Enabled = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResultDTO resultDTO = objITransactionBusiness.SavePHCTransaction(PHCConstant.PHCID, rblTransaction.SelectedValue,txtReceivedorGiven.Text,txtChequeNo.Text,Convert.ToDecimal(txtAmount.Text),txtDescription.Text);
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void rblTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTransaction.SelectedIndex == 0)
            {
                lblReceivedorGiven.Text = PHCConstant.HandOver;
                RFVReceivedOrGiven.ErrorMessage = PHCConstant.ErrorMessageHandOver;
            }
            else
            {
                lblReceivedorGiven.Text = PHCConstant.Received;
                RFVReceivedOrGiven.ErrorMessage = PHCConstant.ErrorMessageReceived;
            }
        }
        protected void LVPHCTransDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindLVPHCTransDetails();
        }


    }
}