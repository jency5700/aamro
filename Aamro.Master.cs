using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAMRO_CRM
{
    public partial class Aamro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleContent.Visible = false;
            lblMasterTitle.Visible = false;
            MessageContent.Visible = false;
            lblMessage.Visible = false;
            if (Session["User"] == null || Convert.ToString(Session["User"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            else {
                lblWelcomeTitle.Text = "Welcome " + Session["User"];
            }
        }
        

        public string MasterLabelText
        {
            get
            {
                return lblMasterTitle.Text;
            }
            set 
            {
                TitleContent.Visible = true;
                lblMasterTitle.Visible = true;
                lblMasterTitle.Text = value;
            }
        }

        public string MasterMessageText
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                MessageContent.Visible = true;
                lblMessage.Visible = true;
                lblMessage.Text = value;
            }
        }

        public string MasterWelcomeText
        {
            get
            {
                return lblWelcomeTitle.Text;
            }
            set
            {
                lblWelcomeTitle.Text = value;
            }
        }

    }
}