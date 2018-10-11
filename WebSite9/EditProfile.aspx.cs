using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtName.Text = Profile.FirstName;
            txtStreet.Text = Profile.Street;
            txtCity.Text = Profile.City;
            txtState.Text = Profile.State;
            txtEmail.Text = Profile.Email;
            txtPhone.Text = Profile.Phone;
            txtZip.Text = Profile.Zip;

            if (Profile.hobby != null)
            {
                txtSport.Text = Profile.hobby.Sport;
                txtGame.Text = Profile.hobby.VideoGame;
                txtCollection.Text = Profile.hobby.Collection;
                txtJob.Text = Profile.hobby.Job;
            }
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Profile.FirstName = txtName.Text;
        Profile.Street = txtStreet.Text;
        Profile.City = txtCity.Text;
        Profile.State = txtState.Text;
        Profile.Email = txtEmail.Text;
        Profile.Phone = txtPhone.Text;
        Profile.Zip = txtZip.Text;

        Hobbies hobby = new Hobbies();
        hobby.Sport = txtSport.Text;
        hobby.VideoGame = txtGame.Text;
        hobby.Collection = txtCollection.Text;
        hobby.Job = txtJob.Text;
        Profile.hobby = hobby;

        Profile.Save();
        Response.Redirect("ViewProfile.aspx");
    }
}