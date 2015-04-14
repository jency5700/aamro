using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAMRO_CRM.Modules
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
          Master.MasterLabelText = "Manage Customers";
        }
    }

}