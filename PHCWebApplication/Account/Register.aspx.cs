using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PHCWebApplication.Models;
using PHC.BAInterfaces.Business;
using PHC.Binder.BackEnd;
using PHC.BAInterfaces.DataTransfer;
using System.Collections.Generic;

namespace PHCWebApplication.Account
{
    public partial class Register : Page
    {

        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDistricts();
                
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
       
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<CustomUserManager>();
            var signInManager = Context.GetOwinContext().Get<CustomSignInManager>();
            var user = new CustomUser() { UserName = Email.Text, EmailId = Email.Text, PHCID = txtPHCID.Text.Trim(), DistrictId = ddlDistrictNames.SelectedValue, Id = txtPHCID.Text.Trim()
            , Password=Password.Text.Trim(),TalukId=ddlTaluk.SelectedValue};
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void ddlDistrictNames_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<MTalukDTO> lstdistrict = objITransactionBusiness.GetMTaluk().FindAll(A=>A.DistrictID==ddlDistrictNames.SelectedValue);
            if (lstdistrict != null && lstdistrict.Count > 0)
            {
                ddlTaluk.DataSource = lstdistrict;
                ddlTaluk.DataBind();
                ddlTaluk.Items.Insert(0, "Select Taluk");
            }
        }
    }
}