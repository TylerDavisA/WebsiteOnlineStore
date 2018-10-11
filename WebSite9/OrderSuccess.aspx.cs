using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string companyName = (string)Session["CompanyName"];
        int orderNum = (int)Session["OrderNumber"];
        string order = companyName +"-"+ orderNum.ToString();
        OrderComfirmation.Text = "Order " + order + " has been processed.";
        Email.Text = "An email has been sent to confirm your order.";
        
    }
}