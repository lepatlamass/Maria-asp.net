using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    //connection link to sqld2019
    string connectionString = "Data source = DESKTOP-HG3GU0M; database = UserRegistrationDB; Integrated Security=SSPI;";
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMessage.Visible = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            //open connection to the db
            sqlCon.Open();
            string query = "SELECT COUNT(1) FROM UserRegistration WHERE Username=@Username AND Password=@Password";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if (count==1)
            {
                Session["Username"] = txtUsername.Text.Trim();
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
            }
        }
    }
}