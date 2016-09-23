using PHC.BAInterfaces.Business;
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
    public partial class AddDiseases : System.Web.UI.Page
    {
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PopulateData();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ResultDTO resultDTO = objITransactionBusiness.SaveMdisease(DateTime.Now.ToLongTimeString(), txtnewDiseaseName.Text);
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
        const string VSDiseaseNames = "VSDiseases";
        public List<DiseaseClass> ViewstateDiseaseNames
        {
            get
            {
                if (ViewState[VSDiseaseNames] == null)
                    ViewState[VSDiseaseNames] = new List<DiseaseClass>();
                return (List<DiseaseClass>)ViewState[VSDiseaseNames];
            }
            set
            {
                ViewState[VSDiseaseNames] = value;
            }
        }

        private void PopulateData()
        {
            List<MDiseaseDTO> lstdisease = new List<MDiseaseDTO>();
            lstdisease = objITransactionBusiness.GetMDiseases();
            if (lstdisease != null && lstdisease.Count > 0)
            {
                ListView1.DataSource = lstdisease;
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
            string DiseaseID = ListView1.DataKeys[e.ItemIndex].Value.ToString();
            ListViewItem item = ListView1.Items[e.ItemIndex];
            TextBox txtdiseasename = (TextBox)item.FindControl("txtDiseaseName");

            List<DiseaseClass> lstvst = null;
            lstvst = ViewstateDiseaseNames;

            DiseaseClass tst = lstvst.Where(t => t.DiseaseID == DiseaseID).SingleOrDefault();
            tst.DiseaseName = txtdiseasename.Text;
            ViewstateDiseaseNames = lstvst;

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

            string DiseaseID = ListView1.DataKeys[e.ItemIndex].Value.ToString();
            List<DiseaseClass> lstvst = null;
            lstvst = ViewstateDiseaseNames;
            DiseaseClass tst = lstvst.Where(t => t.DiseaseID == DiseaseID).SingleOrDefault();
            lstvst.Remove(tst);
            ViewstateDiseaseNames = lstvst;
            //lblMessage.Text = "Record delete successfully !";
            // repopulate the data
            this.PopulateData();
        }
        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DPLV1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PopulateData();
        }

    }
    [Serializable]
    public class DiseaseClass
    {
        public string DiseaseID { get; set; }
        public string DiseaseName { get; set; }
    }
}