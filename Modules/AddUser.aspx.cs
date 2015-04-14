using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace AAMRO_CRM.Modules
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Master.MasterLabelText = "Add User";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlConnection con;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
                cmd.Parameters.Add("@UserName", SqlDbType.Char).Value = txtFirstName.Text + " " + txtLastName.Text;
                cmd.Parameters.Add("@Gender", SqlDbType.Char).Value = ddlGender.SelectedIndex;
                cmd.Parameters.Add("@DeptId", SqlDbType.Char).Value = ddlDepartment.SelectedIndex;
                cmd.Parameters.Add("@Divison", SqlDbType.Char).Value = txtDivision.Text;
                cmd.Parameters.Add("@RoleId", SqlDbType.Char).Value = ddlRole.SelectedIndex;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = txtEmail.Text;
                cmd.Parameters.Add("@Contact", SqlDbType.Char).Value = txtContact.Text;
                cmd.CommandText = "Insert into CRM_User (UserName,Gender,deptId,Division,RoleId,Email,Contact,CreatedDate) ";
                cmd.CommandText = cmd.CommandText + "VALUES (@UserName,@Gender,@DeptId,@Divison,@RoleId,@Email,@Contact,GETDATE())";

                cmd.Connection = con;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                Master.MasterMessageText = "User Added successfully";
                Clear(false);
            }
            catch (Exception ex)
            {
                Master.MasterMessageText = "Unhandled error occured. Please contact administrator.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear(true);
        }

        private void Clear(bool blnclear)
        {
            if (blnclear)
            {
                Master.MasterMessageText = " ";
            }
            txtFirstName.Text = "";
            txtLastName.Text = "";
            ddlGender.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            txtDivision.Text = "";
            ddlRole.SelectedIndex = 0;
            txtEmail.Text = "";
            txtContact.Text = "";
        }
    }
}