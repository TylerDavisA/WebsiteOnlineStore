using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblNumProfiles.Text = "Total number of profiles: "+ProfileManager.GetNumberOfProfiles(ProfileAuthenticationOption.All).ToString();
        
        if (!IsPostBack)
        {
            lblName.Text = Profile.FirstName;
            lblStreet.Text = Profile.Street;
            lblCity.Text = Profile.City;
            lblState.Text = Profile.State;
            lblEmail.Text = Profile.Email;
            lblPhone.Text = Profile.Phone;
            lblZip.Text = Profile.Zip;

            if(Profile.hobby != null)
            {
                lblSport.Text = Profile.hobby.Sport;
                lblGame.Text = Profile.hobby.VideoGame;
                lblCollection.Text = Profile.hobby.Collection;
                lblJob.Text = Profile.hobby.Job;
            }
            
        }
        

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditProfile.aspx");
    }
}