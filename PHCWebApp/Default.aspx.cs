using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PHC.BAInterfaces.Business;
using PHC.Binder.BackEnd;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ITransactionBusiness b= BinderSingleton

        ITransactionBusiness business = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        

       
    }
}
