using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Profile;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, EventArgs e)
    {
        if (authenticateUser(txtUsername.Text, txtPassword.Text))
        {
            //true - leave authentication cookie
            //without the cookie, the user is logged out after closing the browser
            FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, CheckBox.Checked);
        }
        else
        {
            Wrong.Text = "*Invalid username and password";
        }
    }


    /*private Boolean authenticateUser(string username, string password)
    {
        ProfileCommon profile = Profile.GetProfile(username);

        if ( profile.Password == password)
        {
            Session["Profile"] = profile;
            return true;
        }
          

        return false;
    }*/
    private Boolean authenticateUser(string username, string password)
    {
        string cs = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

        using(SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramUsername = new SqlParameter("@Username", username);
            SqlParameter paramPassword = new SqlParameter("@Password", password);

            cmd.Parameters.Add(paramUsername);
            cmd.Parameters.Add(paramPassword);

            con.Open();
            int returnCode = (int)cmd.ExecuteScalar();
            return returnCode == 1;
        }
    }
}