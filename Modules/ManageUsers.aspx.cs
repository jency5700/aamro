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
    public partial class ManageUsers : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Master.MasterLabelText = "Manage Users";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindDdlData();

                BindData();
            }
        }

        public void BindData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
            cmd.CommandText = "Select u.*,d.department,r.role from CRM_User u, Department d, Role r where (u.password = ' ' or u.password is null) and u.deptId =d.deptId and u.RoleId = r.roleId ";
            ds = new DataSet();
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            Grid.DataSource = ds;
            Grid.DataBind();
            con.Close();
        }

        public void BindDdlData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
            cmd.CommandText = "Select * from Department order by department";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            ddlDepartment.DataSource = ds.Tables[0];
            ddlDepartment.DataTextField = "Department";
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));

            ds = new DataSet();
            cmd.CommandText = "Select * from Role order by role ";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            ddlRole.DataSource = ds.Tables[0];
            ddlRole.DataTextField = "Role";
            ddlRole.DataValueField = "RoleId";
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem("--Select--", "0"));

            con.Close();
        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }


        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            BindData();
        }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
                cmd.Connection = con;
                int UserId = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
                cmd.CommandText = "Delete from CRM_User where UserId=" + UserId;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Grid.EditItemIndex = -1;
                BindData();

                Master.MasterMessageText = "User details deleted successfully";
            }
            catch (Exception ex)
            {
                Master.MasterMessageText = "Unhandled error occured. Please contact administrator.";
            }
        }

        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = e.Item.Cells[0].Text;
                cmd.Parameters.Add("@UserName", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[1].FindControl("txtUserName")).Text.Trim();
                cmd.Parameters.Add("@Gender", SqlDbType.Char).Value = ((DropDownList)e.Item.Cells[2].FindControl("ddldgGender")).SelectedValue;
                cmd.Parameters.Add("@DeptId", SqlDbType.Char).Value = ((DropDownList)e.Item.Cells[3].FindControl("ddldgDept")).SelectedValue;
                cmd.Parameters.Add("@Divison", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text.Trim();
                cmd.Parameters.Add("@RoleId", SqlDbType.Char).Value = ((DropDownList)e.Item.Cells[5].FindControl("ddldgRole")).SelectedValue;
                cmd.Parameters.Add("@Contact", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[6].Controls[0]).Text.Trim();
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[7].FindControl("txtEmail")).Text.Trim();
                cmd.CommandText = "Update CRM_User set Username=@UserName,Gender=@Gender,DeptId=@DeptId,Division=@Divison,RoleId=@RoleId,Contact=@Contact,Email=@Email where UserId=@UserId";
                cmd.Connection = con;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Grid.EditItemIndex = -1;
                BindData();

                Master.MasterMessageText = "User details updated successfully";
            }
            catch (Exception ex)
            {
                Master.MasterMessageText = "Unhandled error occured. Please contact administrator.";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string strinput = "";
                ds = new DataSet();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
                cmd.CommandText = "Select u.*,d.department,r.role from CRM_User u, Department d, Role r where (u.password = ' ' or u.password is null) and u.deptId =d.deptId and u.RoleId = r.roleId ";
                if (txtFirstName.Text.Trim() != "")
                {
                    strinput = '%' + txtFirstName.Text.Trim() + '%';
                    cmd.CommandText = cmd.CommandText + " and u.username like '" + strinput + "'";
                    strinput = "";
                }

                if (txtLastName.Text.Trim() != "")
                {
                    strinput = '%' + txtLastName.Text.Trim() + '%';
                    cmd.CommandText = cmd.CommandText + " and u.username like '" + strinput + "'";
                    strinput = "";
                }

                if (ddlGender.SelectedIndex > 0)
                {
                    cmd.CommandText = cmd.CommandText + " and u.gender = '" + ddlGender.SelectedValue + "'";

                }

                if (ddlDepartment.SelectedIndex > 0)
                {
                    cmd.CommandText = cmd.CommandText + " and u.deptId = '" + ddlDepartment.SelectedValue + "'";

                }

                if (txtDivision.Text.Trim() != "")
                {
                    strinput = '%' + txtDivision.Text.Trim() + '%';
                    cmd.CommandText = cmd.CommandText + " and u.division like '" + strinput + "'";
                    strinput = "";
                }
                if (ddlRole.SelectedIndex > 0)
                {
                    cmd.CommandText = cmd.CommandText + " and u.roleId = '" + ddlRole.SelectedValue + "'";
                }
                if (txtEmail.Text.Trim() != "")
                {
                    strinput = '%' + txtEmail.Text.Trim() + '%';
                    cmd.CommandText = cmd.CommandText + " and u.email like '" + strinput + "'";
                    strinput = "";
                }
                if (txtContact.Text.Trim() != "")
                {
                    strinput = '%' + txtContact.Text.Trim() + '%';
                    cmd.CommandText = cmd.CommandText + " and u.contact like '" + strinput + "'";
                    strinput = "";
                }
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Open();
                cmd.ExecuteNonQuery();
                Grid.DataSource = ds;
                Grid.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Master.MasterMessageText = "Unhandled error occured. Please contact administrator.";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlConnection con;

            try
            {
                if (ddlRole.SelectedIndex <= 0)
                {
                    Master.MasterMessageText = "Please select a valid Role";
                    ddlRole.Focus();
                }
                else if (ddlDepartment.SelectedIndex <= 0)
                {
                    Master.MasterMessageText = "Please select a valid Department";
                    ddlDepartment.Focus();
                }
                else if (ddlGender.SelectedIndex <= 0)
                {
                    Master.MasterMessageText = "Please select a valid Gender";
                    ddlGender.Focus();
                }
                else if (txtFirstName.Text.Trim() == "" && txtLastName.Text.Trim() == "")
                {
                    Master.MasterMessageText = "Please enter First/Last name of the User";
                    txtFirstName.Focus();
                }
                else
                {

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
                    cmd.Parameters.Add("@UserName", SqlDbType.Char).Value = txtFirstName.Text + " " + txtLastName.Text;
                    cmd.Parameters.Add("@Gender", SqlDbType.Char).Value = ddlGender.SelectedValue;
                    cmd.Parameters.Add("@DeptId", SqlDbType.Char).Value = ddlDepartment.SelectedValue;
                    cmd.Parameters.Add("@Divison", SqlDbType.Char).Value = txtDivision.Text;
                    cmd.Parameters.Add("@RoleId", SqlDbType.Char).Value = ddlRole.SelectedValue;
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
                BindData();
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

        public ICollection DropsData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Department", typeof(String)));
            dt.Columns.Add(new DataColumn("DeptId", typeof(String)));

            ds = new DataSet();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
            cmd.CommandText = "Select * from Department order by department";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();

            DataView dv = new DataView(ds.Tables[0]);
            return dv;

        }

        DataRow CreateRow(String Text, String Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();

            dr[0] = Text;
            dr[1] = Value;

            return dr;

        }

        public ICollection DdlGenderData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Gender", typeof(String)));
            dt.Columns.Add(new DataColumn("GenderId", typeof(String)));

            DataRow dr = dt.NewRow();
            dr["Gender"] = "Male";
            dr["GenderId"] = "M";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Gender"] = "Female";
            dr["GenderId"] = "F";
            dt.Rows.Add(dr);

            return dt.DefaultView;

        }

        public ICollection DdlDeptData()
        {
            ds = new DataSet();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
            cmd.CommandText = "Select * from Department order by department";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            return ds.Tables[0].DefaultView;
        }

        public ICollection DdlRoleData()
        {
            ds = new DataSet();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
            cmd.CommandText = "Select * from Role order by role";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            return ds.Tables[0].DefaultView;

        }

        protected void Grid_ItemDataBound(object source, System.Web.UI.WebControls.DataGridItemEventArgs e) 
        {
            if (e.Item.Cells[2].FindControl("ddldgGender") != null)
                ((DropDownList)e.Item.Cells[2].FindControl("ddldgGender")).SelectedValue = e.Item.Cells[10].Text;

            if (e.Item.Cells[3].FindControl("ddldgDept") != null)
                ((DropDownList)e.Item.Cells[3].FindControl("ddldgDept")).SelectedValue = e.Item.Cells[11].Text;

            if (e.Item.Cells[5].FindControl("ddldgRole") != null)
                ((DropDownList)e.Item.Cells[5].FindControl("ddldgRole")).SelectedValue = e.Item.Cells[12].Text;
        }

    }
}