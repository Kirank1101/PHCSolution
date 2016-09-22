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
    public partial class Edit : System.Web.UI.Page
    {
		protected PHC.DataAccess.PHCSolutions _db = new PHC.DataAccess.PHCSolutions();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Update methd to update the selected MState item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(string  StateID)
        {
            using (_db)
            {
                var item = _db.MStates.Find(StateID);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", StateID));
                    return;
                }

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Default");
                }
            }
        }

        // This is the Select method to selects a single MState item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public PHC.DataAccess.MState GetItem([FriendlyUrlSegmentsAttribute(0)]string StateID)
        {
            if (StateID == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.MStates.Find(StateID);
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
