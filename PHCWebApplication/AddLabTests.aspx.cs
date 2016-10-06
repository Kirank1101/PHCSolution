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
    public partial class AddLabTests : System.Web.UI.Page
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
            ResultDTO resultDTO = objITransactionBusiness.SaveMLabTest(txtLabTestName.Text);
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
            List<MLabTestDTO> lstMLabTestDTO = new List<MLabTestDTO>();
            lstMLabTestDTO = objITransactionBusiness.GetMLabTest();
            if (lstMLabTestDTO != null && lstMLabTestDTO.Count > 0)
            {

                LVLabTest.DataSource = lstMLabTestDTO;
                LVLabTest.DataBind();
            }
            else
            {
                LVLabTest.Items.Clear();
                LVLabTest.DataSource = null;
                LVLabTest.DataBind();
            }
        }
        protected void EditRecord(object sender, ListViewEditEventArgs e)
        {
            LVLabTest.EditIndex = e.NewEditIndex;
            this.PopulateData();
        }
        protected void UpdateRecord(object sender, ListViewUpdateEventArgs e)
        {
            string LabTestID = LVLabTest.DataKeys[e.ItemIndex].Value.ToString();
            ListViewItem item = LVLabTest.Items[e.ItemIndex];
            TextBox txteLabTestName = (TextBox)item.FindControl("txteLabTestName");

            ResultDTO resultDTO = objITransactionBusiness.UpdateMLabTest(LabTestID, txteLabTestName.Text);
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
            LVLabTest.EditIndex = -1;
            // repopulate the data
            this.PopulateData();
        }
        protected void CancelEditRecord(object sender, ListViewCancelEventArgs e)
        {

            LVLabTest.EditIndex = -1;
            this.PopulateData();
        }
        protected void DeleteRecord(object sender, ListViewDeleteEventArgs e)
        {

            string LabTestID = LVLabTest.DataKeys[e.ItemIndex].Value.ToString();
            ResultDTO resultDTO = objITransactionBusiness.DeleteMLabTest(LabTestID);
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
        protected void LVLabTest_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }

    }
}