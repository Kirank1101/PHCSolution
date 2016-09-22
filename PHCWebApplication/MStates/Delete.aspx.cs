using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using PHC.DataAccess;

namespace PHCWebApplication.MStates
{
    public partial class Delete : System.Web.UI.Page
    {
		protected PHC.DataAccess.PHCSolutions _db = new PHC.DataAccess.PHCSolutions();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected MState item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(string StateID)
        {
            using (_db)
            {
                var item = _db.MStates.Find(StateID);

                if (item != null)
                {
                    _db.MStates.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single MState item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public PHC.DataAccess.MState GetItem([FriendlyUrlSegmentsAttribute(0)]string StateID)
        {
            if (StateID == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.MStates.Where(m => m.StateID == StateID).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}

