using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class BookInfoPage : System.Web.UI.Page
{
    ItemInfo focus;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("1");
            DropDownList1.Items.Add("2");
            DropDownList1.Items.Add("3");
            DropDownList1.Items.Add("4");
            DropDownList1.Items.Add("5");
            DropDownList1.Items.Add("6");
            DropDownList1.Items.Add("7");
            DropDownList1.Items.Add("8");
            DropDownList1.Items.Add("9");
            DropDownList1.Items.Add("10");
        }
        string item = Request.QueryString["Item"];
        string imgAddress;
       
        
        int model = Convert.ToInt32(item);
        List<ItemInfo> list = (List<ItemInfo>)Session["Items"];
        focus = null;
        
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i].ModelNumber == model)
                focus = list[i];
        }
        imgAddress = focus.ImgFull;
        Image img = new Image
        {
            ImageUrl = imgAddress
        };

        HtmlGenericControl createImg = new HtmlGenericControl("img");
        createImg.Attributes["src"] = focus.ImgFull;
        createImg.Attributes["class"] = "img-responsive";
        Literal1.Controls.Add(createImg);
        //Form.Controls.Add(img);

        Table tbl = new Table();
        TableRow tr1 = new TableRow();
        TableRow tr2 = new TableRow();
        TableRow tr3 = new TableRow();
        TableRow tr4 = new TableRow();
        TableRow tr5 = new TableRow();
        TableRow tr6 = new TableRow();
        TableRow tr7 = new TableRow();
        TableRow tr8 = new TableRow();
        TableRow tr9 = new TableRow();
        TableCell cell1 = new TableCell();
        TableCell cell2 = new TableCell();
        TableCell cell3 = new TableCell();
        TableCell cell4 = new TableCell();
        TableCell cell5 = new TableCell();
        TableCell cell6 = new TableCell();
        TableCell cell7 = new TableCell();
        TableCell cell8 = new TableCell();
        TableCell cell9 = new TableCell();
        cell1.Text = "Title: "+focus.Title;
        cell2.Text = "Description: "+focus.Description;
        cell3.Text = "Rating: "+focus.Rating;
        cell4.Text = "SmileType: "+focus.SmileType;
        cell5.Text = "Company: "+focus.Company;
        cell6.Text = "Price: $"+ String.Format("{0:00.00}", focus.Price);
        cell7.Text = "Model: "+focus.ModelNumber;
        cell8.Text = "Fluff Type: "+focus.FluffType;
        cell9.Text = "Weight: "+focus.Weight;

        tr1.Cells.Add(cell1);
        tr2.Cells.Add(cell2);
        tr3.Cells.Add(cell3);
        tr4.Cells.Add(cell4);
        tr5.Cells.Add(cell5);
        tr6.Cells.Add(cell6);
        tr7.Cells.Add(cell7);
        tr8.Cells.Add(cell8);
        tr9.Cells.Add(cell9);

        tbl.Rows.Add(tr1);
        tbl.Rows.Add(tr2);
        tbl.Rows.Add(tr3);
        tbl.Rows.Add(tr4);
        tbl.Rows.Add(tr5);
        tbl.Rows.Add(tr6);
        tbl.Rows.Add(tr7);
        tbl.Rows.Add(tr8);
        tbl.Rows.Add(tr9);

        Literal2.Controls.Add(tbl); 
        


    }

    protected void Add_Click(object sender, EventArgs e)
    {
        List<ItemInfo> cart = (List<ItemInfo>)Session["Cart"];
        Boolean hasItem = false;

        // max purchase quantity is 1, check to make sure only one exists in cart.
        for(int i = 0; i < cart.Count; i++)
        {
            if (cart[i].ModelNumber == focus.ModelNumber)
                hasItem = true;
        }
        if (hasItem)
            successful.Text = "Item has already been added to the cart!";
        else
        {
            focus.Quantity = Convert.ToInt32(DropDownList1.SelectedValue);
            cart.Add(focus);

            successful.Text = "Item(s) has been successfully added to cart!";
        }
    }


    protected void goToCart(object sender, EventArgs e)
    {
        Response.Redirect("ViewCart.aspx");
    }
}