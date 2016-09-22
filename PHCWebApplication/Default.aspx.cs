using PHC.BAInterfaces.Business;
using PHC.Binder.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PHCWebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ITransactionBusiness business = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        }
    }
}