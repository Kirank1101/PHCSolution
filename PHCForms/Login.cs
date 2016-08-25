using System;
using System.Windows.Forms;
using PHC.DAInterfaces;
using PHC.BAInterfaces.Validations;
using PHC.BAInterfaces.DataTransfer;
using PHC.Binder.BackEnd;
using PHC.BAInterfaces.Business;
//using PHC.Binder.BackEnd;

namespace PHCForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblstatus.Text = string.Empty;
            //ITransaction imp = BinderSingleton.Instance.GetInstance<ITransaction>();

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            IValidate objIValidate = BinderSingleton.Instance.GetInstance<IValidate>();
            ResultDTO result = objIValidate.validateLogin(txtusername.Text.Trim(), txtpassword.Text.Trim());
            if (result.IsSuccess)
            {
                ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();

                ResultDTO resultdto = objITransactionBusiness.AuthenticateUser(txtusername.Text.Trim(), txtpassword.Text.Trim());

                if (resultdto.IsSuccess)
                {
                    this.Hide();
                    MDIParent MdiParent = new MDIParent(txtusername.Text.Trim(), resultdto.PHCID);
                    MdiParent.Show();

                }
                else
                {
                    pnlstatus.BackColor = System.Drawing.Color.Red;
                    lblstatus.Text = resultdto.Message;
                }
            }
            else
            {
                pnlstatus.BackColor = System.Drawing.Color.Orange;
                lblstatus.Text = result.Message;
            }

        }

        private void btnregister_Click(object sender, EventArgs e)
        {

            UserRegistration userreg = new UserRegistration();
            userreg.Show();
            this.Hide();

        }
    }
}
