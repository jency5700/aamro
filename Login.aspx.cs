using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AAMRO_CRM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["User"] = "";
            txtUserName.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ValidateUser"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                switch (userId)
                {
                    case -1:
                        Response.Write ("Username and/or password is incorrect.");
                        break;
                    case -2:
                        Response.Write ("Account has not been activated.");
                        break;
                    default:
                        Session["User"] = txtUserName.Text;
                        Response.Redirect("Home.aspx");
                        break;
                        //FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                }
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtpassword.Text = "";
        }

    }
}