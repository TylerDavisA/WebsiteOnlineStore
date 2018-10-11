using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        

        if (Page.IsValid)
        {
            string cs = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@Username", txtUserName.Text);
                SqlParameter password = new SqlParameter("@Password", txtPass.Text);
                SqlParameter email = new SqlParameter("@Email", txtEmail.Text);

                cmd.Parameters.Add(username);
                cmd.Parameters.Add(password);
                cmd.Parameters.Add(email);

                con.Open();
                int returnCode = (int)cmd.ExecuteScalar();
                if(returnCode == -1)
                {
                    UserTaken.Text = "Sorry but that user name is already taken";
                }
                else
                {
                    Response.Redirect("RegistrationSuccessful.aspx");
                }

            }
        }
    }
}