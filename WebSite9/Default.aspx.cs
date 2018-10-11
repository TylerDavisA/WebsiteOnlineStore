using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;


public partial class _Default : System.Web.UI.Page
{

    private List<ItemInfo> itemInfoList;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        OleDbConnection cn;
        OleDbCommand cmd;
        OleDbDataReader dr1, dr2;
        

        
       

        //MasterBody.Attributes.Add("style", "background-color: #ADD8E6");

        if (!IsPostBack)
        {
            try
            {
                SortList.Items.Add("Rating");
                SortList.Items.Add("Name");
                SortList.Items.Add("Price");
                string focus, asc;
                focus = (string)Session["Sort"];
                if (focus == null)
                {
                    focus = "Rating";
                }
                SortList.SelectedValue = focus;

                focus = (string)Session["Check"];
                if (focus == null)
                {
                    focus = "false";
                }
                if (focus == "false")
                {
                    Ascend.Checked = false;
                    asc = "DESC";
                }
                else
                {
                    asc = "ASC";
                    Ascend.Checked = true;
                }
                    
                itemInfoList = new List<ItemInfo>();

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
                if(SortList.SelectedValue == "Rating")
                {
                    cmd = new OleDbCommand("SELECT * FROM ItemInfo ORDER BY Rating "+asc+";", cn);
                }
                else if(SortList.SelectedValue == "Name")
                {
                    cmd = new OleDbCommand("SELECT * FROM ItemInfo ORDER BY Title " + asc + ";", cn);
                }
                else if (SortList.SelectedValue == "Price")
                {
                    cmd = new OleDbCommand("SELECT * FROM ItemInfo ORDER BY Price " + asc + ";", cn);
                }
                else
                {
                    cmd = new OleDbCommand("SELECT * FROM ItemInfo;", cn);
                }
                

                cn.Open();




                

                dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
      
                    


                    ItemInfo temp = new ItemInfo();
                    temp.Title = (dr1["Title"].ToString());
                    temp.FluffType = dr1["FluffType"].ToString();
                    temp.Company = dr1["Company"].ToString();
                    temp.SmileType = dr1["SmileType"].ToString();
                    temp.ImgFull = dr1["ImgFull"].ToString();
                    temp.Description = dr1["Description"].ToString();
                    temp.ImgThumb = dr1["ImgFull"].ToString();
                    temp.ModelNumber = (int)dr1["ModelNumber"];
                    temp.Rating = Convert.ToDouble(dr1["Rating"]);
                    temp.Weight = Convert.ToDouble(dr1["Weight"]);
                    temp.Price = Math.Round(Convert.ToDouble(dr1["Price"].ToString()), 2);

                  


                    itemInfoList.Add(temp);

                }



                /*foreach (OrderInfo info in orderInfoList)
                {
                    totalItems += info.TotalQty;
                    totalSales += info.OrderTotal;
                    totalWeight += info.TotalWeight;
                }*/

                // DISPLAY ALL THE BOOKS IN THE FOR LOOP
                dr1.Close();

                cn.Close();
                Session["Items"] = itemInfoList;
                if(Session["Cart"]==null)
                    Session["Cart"] = new List<ItemInfo>();

                

            }
            catch (Exception err)
            {

                return;
            }
        }
        try
        {
            if (itemInfoList == null)
            {
                itemInfoList = (List<ItemInfo>)Session["Items"];


            }

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
                    createPanelHeader.InnerHtml = info.Title;
                    createPanelHeader.Attributes["class"] = "panel-heading";

                    Table tableInner = new Table();
                    TableRow rCompany = new TableRow();
                    TableRow rRating = new TableRow();
                    TableRow rPrice = new TableRow();
                    TableCell company = new TableCell();
                    TableCell rating = new TableCell();
                    TableCell price = new TableCell();


                    company.Text = "Company: " + itemInfoList[j].Company;
                    rating.Text = "Rating: " + itemInfoList[j].Rating.ToString();
                    price.Text = "Price: $" + (String.Format("{0:0.00}", info.Price));

                    rCompany.Cells.Add(company);
                    rRating.Cells.Add(rating);
                    rPrice.Cells.Add(price);

                    tableInner.Rows.Add(rCompany);
                    tableInner.Rows.Add(rRating);
                    tableInner.Rows.Add(rPrice);

                    ImageButton imageButton = new ImageButton();
                    imageButton.ImageUrl = info.ImgThumb;
                    imageButton.ID = info.ModelNumber.ToString();
                    imageButton.Click += (new ImageClickEventHandler(cmdBook_Click));



                    HtmlGenericControl createImg = new HtmlGenericControl("img");
                    createImg.Attributes["src"] = info.ImgThumb;
                    createImg.Attributes["class"] = "img-responsive";

                    HtmlGenericControl createHref = new HtmlGenericControl("a");
                    createHref.Attributes["href"] = url;
                    createHref.Controls.Add(createImg);

                    HtmlGenericControl createThumbnail = new HtmlGenericControl("div");
                    createThumbnail.Attributes["class"] = "thumbnail";
                    createThumbnail.Controls.Add(createHref);

                    HtmlGenericControl createPanelBody = new HtmlGenericControl("div");

                    createPanelBody.Attributes["class"] = "panel-body";

                    createPanelBody.Controls.Add(createThumbnail);
                    createPanelBody.Controls.Add(tableInner);




                    createPanel.Controls.Add(createPanelHeader);
                    createPanel.Controls.Add(createPanelBody);
                    createCol.Controls.Add(createPanel);
                    createDiv.Controls.Add(createCol);




                    j++;
                }


                TableHere.Controls.Add(createDiv);

            }

        }
        catch
        {

        }
    }
    private TableCell AddCell(String pText)
    {
        TableCell cell = new TableCell();
        cell.Text = pText;

        return cell;
    }
    private TableCell AddCellBorder(String pText)
    {
        TableCell cell = new TableCell();
        cell.BorderStyle = BorderStyle.Solid;
        cell.BorderWidth = 1;
        cell.Text = pText;
        cell.Attributes.Add("style", "background-color: #ffffff");

        return cell;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception err)
        {

        }
    }


    protected void cmdBook_Click(Object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        string buttonId = button.ID;
        string url = "BookInfoPage.aspx?";
        url += "Item=" + buttonId;
        Response.Redirect(url);
    }



    protected void SortList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Sort"] = SortList.SelectedValue;
        Response.Redirect("Default.aspx");
    }

    protected void Ascend_CheckedChanged(object sender, EventArgs e)
    {
        if (Ascend.Checked)
            Session["Check"] = "true";
        else
            Session["Check"] = "false";
        Response.Redirect("Default.aspx");
    }
}