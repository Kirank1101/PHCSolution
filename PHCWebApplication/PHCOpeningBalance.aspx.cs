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
using AllInOne.Common.Library.Util;

namespace PHCWebApplication
{
    public partial class PHCOpeningBalance : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool PHCOB = objITransactionBusiness.CheckPHCOpeningBalanceExist(PHCConstant.PHCID);
                if (PHCOB)
                {
                    txtPHCOBName.Enabled = false;
                    btnSave.Enabled=false;
                    
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.WarningBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstant.WarningForeColor);
                lblstatus.Text = "Already Opening Balance Amount has been alloted.";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e) {

            ResultDTO resultDTO = objITransactionBusiness.SavePHCOpeningBalance(PHCConstant.PHCID, Convert.ToDecimal( txtPHCOBName.Text));
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
    }
}