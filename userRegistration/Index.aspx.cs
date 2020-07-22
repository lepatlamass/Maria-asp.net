using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Index : System.Web.UI.Page
{
    //connection link to sqld2019
    string connectionString = "Data source = DESKTOP-HG3GU0M; database = UserRegistrationDB; Integrated Security=SSPI;";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Clear();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //checking if the obligatory field are fill and confirming the password
        if (txtUsername.Text == "" || txtPassword.Text == "")
            lblErrorMessage.Text = "Please fill the fields with red *";
        else if (txtPassword.Text != txtConfirmPassword.Text)
            lblErrorMessage.Text = "Password do not MAtch";
        else
        { 
            //connecting to the database and inserting data to the UserRegistrationDB with some logic
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                //making the insert operation(procedure)done on the sql server manager
                SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                //if the hidden field is empty we insert the data
                sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                Clear();
                lblSuccessMessage.Text = "Thanks for registring";
            }
        }
    }
    //clearing the fields after submissions
    void Clear()
    {
        txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUsername.Text = txtPassword.Text = "";
        hfUserID.Value = "";
        lblSuccessMessage.Text = lblErrorMessage.Text = "";
    }
}