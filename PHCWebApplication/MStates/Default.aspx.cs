using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using PHC.DataAccess;

namespace PHCWebApplication.MStates
{
    public partial class Default : System.Web.UI.Page
    {
		protected PHC.DataAccess.PHCSolutions _db = new PHC.DataAccess.PHCSolutions();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of MState entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<PHC.DataAccess.MState> GetData()
        {
            return _db.MStates;
        }
    }
}

