using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class OrderCheckout : System.Web.UI.Page
{
    int ordNumber;
    List<ItemInfo> cart;
    string companyName;
    Boolean allFieldsValid = true;
    string fieldName = "tyler", fieldStreet ="2701 AL OGDON WAY", fieldCity= "Cheney", fieldState= "WA", fieldZip="99004", fieldEmail="Tadtoo22@gmail.com";
    protected void Page_Load(object sender, EventArgs e)
    {

        OleDbConnection cn;
        OleDbCommand cmd, cmd1;
        OleDbDataReader dr1, dr2;
        string query;
        
        


        if (!IsPostBack)
        {
            txtName.Text = Profile.FirstName;
            txtStreet.Text = Profile.Street;
            txtCity.Text = Profile.City;
            txtState.Text = Profile.State;
            txtEmail.Text = Profile.Email;
            txtZip.Text = Profile.Zip;
            try
            {
                cn = new OleDbConnection();
                
                if (Request.UserHostAddress.ToString().Equals("::1"))
                {
                    //Local server...
                    cn.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\Tadto\source\Websites\WebSite9\App_Data\ShoppingDatabase1.accdb;Persist Security Info=False;";
                }
                else
                {
                    //Smarterasp.net access
                    cn.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=h:\root\home\tadtoo22-001\www\xeffles\App_Data\ShoppingDatabase1.accdb;Persist Security Info=False;";
                }

                //Create the SQL Command...
                //cmd = new OleDbCommand("SELECT * FROM InvoiceQuery", cn);
                cmd = new OleDbCommand("SELECT * FROM NextOrderNumber WHERE CompanyName = 'Quokka Team';", cn);

                cn.Open();






                dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    companyName = dr1["CompanyName"].ToString();
                    ordNumber = Convert.ToInt32(dr1["NextOrder"]);
                }

                Session["OrderNumber"] = ordNumber;
                Session["CompanyName"] = companyName;
                dr1.Close();

                try {
                    query = "UPDATE NextOrderNumber SET NextOrder = "+(ordNumber+1)+" WHERE CompanyName = '" + companyName + "';";
                    cmd1 = new OleDbCommand(query, cn);
                    cmd1.ExecuteNonQuery();
                }
                catch
                {

                }
                


                cn.Close();




            }
            catch (Exception err)
            {

                return;
            }
            int quantityTotal;
            
            double weight, orderTotal, shipping, totalCost;
            weight = orderTotal = shipping = totalCost = quantityTotal =0;
            cart = (List<ItemInfo>)Session["Cart"];
            if (cart == null)
            {

            }
            else
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    quantityTotal += cart[i].Quantity;
                    orderTotal += cart[i].Price * cart[i].Quantity;
                    weight += cart[i].Weight * cart[i].Quantity;
                }
                shipping = weight * 0.46;
                Table tbl = new Table();
                TableRow r1 = new TableRow();
                TableRow r2 = new TableRow();
                TableRow r3 = new TableRow();
                TableRow r4 = new TableRow();

                TableRow r5 = new TableRow();
                TableRow r6 = new TableRow();
                TableRow r7 = new TableRow();
                TableHeaderCell items1;
                TableCell items2;
                items1 = new TableHeaderCell();
                items2 = new TableCell();
                items1.Text = "Items:";
                items2.Text = cart.Count.ToString();
                r1.Cells.Add(items1);
                r1.Cells.Add(items2);

                TableHeaderCell quantity1 = new TableHeaderCell();
                quantity1.Text = "Quantity: ";
                TableCell quantity2 = new TableCell();
                quantity2.Text = quantityTotal.ToString();
                r2.Cells.Add(quantity1);
                r2.Cells.Add(quantity2);

                TableHeaderCell weightCell = new TableHeaderCell();
                weightCell.Text = "Weight: ";
                TableCell weightCell2 = new TableCell();
                weightCell2.Text = weight.ToString();
                r3.Cells.Add(weightCell);
                r3.Cells.Add(weightCell2);

                TableHeaderCell orderNum = new TableHeaderCell();
                orderNum.Text = "Order Number: ";
                TableCell orderNum2 = new TableCell();
                orderNum2.Text = companyName+"-" + ordNumber;
                r4.Cells.Add(orderNum);
                r4.Cells.Add(orderNum2);

                TableHeaderCell itemTotal = new TableHeaderCell();
                itemTotal.Text = "Item Total: ";
                TableCell itemTotal2 = new TableCell();
                itemTotal2.Text = "$" + String.Format("{0:0.00}", orderTotal);
                r5.Cells.Add(itemTotal);
                r5.Cells.Add(itemTotal2);

                TableHeaderCell shippingCost = new TableHeaderCell();
                shippingCost.Text = "Shipping Cost: ";
                TableCell shippingCost2 = new TableCell();
                shippingCost2.Text = "$" + String.Format("{0:0.00}", shipping);
                r6.Cells.Add(shippingCost);
                r6.Cells.Add(shippingCost2);

                TableHeaderCell orderTotalCell = new TableHeaderCell();
                orderTotalCell.Text = "Order Total: ";
                TableCell orderTotalCell2 = new TableCell();
                orderTotalCell2.Text = "$" + String.Format("{0:0.00}", shipping + orderTotal);
                r7.Cells.Add(orderTotalCell);
                r7.Cells.Add(orderTotalCell2);

                tbl.Rows.Add(r4);
                tbl.Rows.Add(r1);
                tbl.Rows.Add(r2);
                tbl.Rows.Add(r3);
                tbl.Rows.Add(r5);
                tbl.Rows.Add(r6);
                tbl.Rows.Add(r7);

                tbl.Attributes.Add("width", "50%");
                tableHere.Controls.Add(tbl);
            }


        }

        List<ItemInfo> itemInfoList = (List < ItemInfo > )Session["Cart"];
        int j = 0;
        while (j < itemInfoList.Count)
        {
            HtmlGenericControl createDiv = new HtmlGenericControl("div");
            createDiv.ID = "row" + j;
            createDiv.Attributes["class"] = "row";
            TableRow tr = new TableRow();


            // Make a panel for each cell and populate it with data

            for (int i = 0; i < 4; i++)
            {

                if (j >= itemInfoList.Count)
                    break;
                ItemInfo info = itemInfoList[j];
                string url = "BookInfoPage.aspx?";
                url += "Item=" + info.ModelNumber;

                HtmlGenericControl createCol = new HtmlGenericControl("div");
                createCol.ID = "col" + j + "" + i;
                createCol.Attributes["class"] = "col-md-3";

                HtmlGenericControl createPanel = new HtmlGenericControl("div");
                createPanel.ID = "colPanel" + j + "" + i;
                createPanel.Attributes["class"] = "panel panel-primary";

                HtmlGenericControl createPanelHeader = new HtmlGenericControl("div");
                createPanelHeader.InnerHtml = info.Title +" x "+info.Quantity;
                createPanelHeader.Attributes["class"] = "panel-heading";

                

              

                Image image = new ImageButton();
                image.ImageUrl = info.ImgThumb;
                



                HtmlGenericControl createImg = new HtmlGenericControl("img");
                createImg.Attributes["src"] = info.ImgThumb;
                createImg.Attributes["class"] = "img-responsive";

                HtmlGenericControl createThumbnail = new HtmlGenericControl("div");
                createThumbnail.Attributes["class"] = "thumbnail";
                createThumbnail.Controls.Add(createImg);

                HtmlGenericControl createPanelBody = new HtmlGenericControl("div");

                createPanelBody.Attributes["class"] = "panel-body";

                createPanelBody.Controls.Add(createThumbnail);




                createPanel.Controls.Add(createPanelHeader);
                createPanel.Controls.Add(createPanelBody);
                createCol.Controls.Add(createPanel);
                createDiv.Controls.Add(createCol);




                j++;
            }


            tableHeres.Controls.Add(createDiv);

        }

    }

    protected void Continue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void Submit_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            fieldName = txtName.Text;
            fieldStreet = txtStreet.Text;
            fieldCity = txtCity.Text;
            fieldState = txtState.Text;
            fieldZip = txtZip.Text;
            fieldEmail = txtEmail.Text;
            sendEmail(); 
            Session["Cart"] = new List<ItemInfo>();
            Response.Redirect("OrderSuccess.aspx");
        }
        
            Required.Text = "Please fill out form with valid responses.";
          // SEND EMAIL HERE

        //Refresh cart.
        
        
    }
    public void sendEmail()
    {
        MailMessage mailMessage = new MailMessage("Xeffles@xeffles.net", fieldEmail);
        mailMessage.Subject = "Order Has Been Processed";
        mailMessage.Body = getBody();
        mailMessage.IsBodyHtml = true;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Credentials = new System.Net.NetworkCredential("Xeffles@xeffles.net", "ootdat22!");
        smtpClient.Host = "mail.xeffles.net";
        
        smtpClient.Send(mailMessage);
    }

    public string getBody()
    {
        List < ItemInfo > cart = (List<ItemInfo>)Session["Cart"];
        string body;
        int quantity = 0;
        double shippingCost = 0, price = 0;

        body = "Dear valued customer,<br /><br />" +
            "Your order has been processed.<br /><br />" +
            "Order number: "+Session["CompanyName"]+"-"+Session["OrderNumber"]+
            "<table cellpadding=\"10\"style=\"border-collapse:collapse; text-align:center;\"><tr><th>Item Name</th><th>Quantity</th><th>Item Price</th><th>Total Price</th></tr>";

        for(int i = 0; i < cart.Count; i++)
        {
            body += "<tr><td>"+cart[i].Title+"</td><td>"+cart[i].Quantity+"</td><td>"+ "$" + String.Format("{0:0.00}", cart[i].Price) + "</td><td>"+ "$" + String.Format("{0:0.00}", cart[i].Price * cart[i].Quantity) +"</td></tr>";
            quantity += cart[i].Quantity;
            price += cart[i].Quantity * cart[i].Price;
        }
        body += "</table ><br /><br />" 
            +"Total quantity: " + quantity + "<br />"
            + "Shipping cost: $" + String.Format("{0:0.00}", (double)Session["ShippingCost"]) + "<br />"
            + "Total order cost: $" + String.Format("{0:0.00}", (double)Session["ShippingCost"] + price) + "<br /><br />"
            +
            "Shipping Destination: <br />"
            + fieldName + "<br />"
            + fieldStreet + "<br />"
            + fieldCity + "<br />"
            + fieldState + "<br />"
            + fieldZip + "<br /><br />"
            + "If you did not place an order with Quokka Team, please contact <br />"
            + "Tadtoo22@gmail.com";

        return body;
    }
}