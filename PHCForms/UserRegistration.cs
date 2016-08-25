using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PHC.BAInterfaces.Business;
using PHC.BAInterfaces.Validations;
using PHC.Binder.BackEnd;
using PHC.BAInterfaces.DataTransfer;

namespace PHCForms
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            IValidate objIValidate = BinderSingleton.Instance.GetInstance<IValidate>();
            ResultDTO result = objIValidate.validateuserregistration(txtname.Text.Trim(), txtemailid.Text.Trim(), txtcontactno.Text.Trim(), txtloginid.Text.Trim(), txtpassword.Text.Trim(), txtconfirmpassword.Text.Trim());
            if (result.IsSuccess)
            {
                ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();

                bool status = objITransactionBusiness.AddUserRegistration(txtname.Text.Trim(), txtemailid.Text.Trim(), txtcontactno.Text.Trim(), txtloginid.Text.Trim(), txtpassword.Text.Trim(), txtconfirmpassword.Text.Trim());

                if (status)
                {
                    pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessBackGroundColor);
                    lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.SuccessForeColor);
                    lblstatus.Text = PHCConstatnt.Save;

                }
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.WarningBackGroundColor);
                lblstatus.ForeColor = System.Drawing.ColorTranslator.FromHtml(PHCConstatnt.WarningForeColor);
                lblstatus.Text = result.Message;
            }

        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            if ((Form)this.MdiParent != null)
            {
                string userid = ((Form)this.MdiParent).Controls["lbluserid"].Text;
                string phcid = ((Form)this.MdiParent).Controls["lblphcid"].Text;
                ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
                UserDTO userDTO = objITransactionBusiness.GetUsers(userid);
                if (userDTO != null)
                {
                    txtname.Text = userDTO.Name;
                    txtemailid.Text = userDTO.EmailID;
                    txtcontactno.Text = userDTO.ContactNo;
                    txtloginid.Text = userDTO.LoginID;
                    txtloginid.Enabled = false;
                }
            }
        }
    }
}
