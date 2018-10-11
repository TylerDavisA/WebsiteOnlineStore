using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    List<ItemInfo> cart;
    DropDownList drop;
    protected void Page_Load(object sender, EventArgs e)
    {
        cart = (List<ItemInfo>)Session["Cart"];
        int totalCount = 0;
        double totalPriceValue = 0;
        double totalWeightValue = 0;
        Table tbl = new Table();
        if (cart.Count == 0)
        {
            TableRow tr1 = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = "Shopping cart is empty!";
            tr1.Cells.Add(cell);
            tbl.Rows.Add(tr1);
        }
        else
        {
            drop = new DropDownList();
            drop.Items.Add("1");
            drop.Items.Add("2");
            drop.Items.Add("3");
            drop.Items.Add("4");
            drop.Items.Add("5");
            drop.Items.Add("6");
            drop.Items.Add("7");
            drop.Items.Add("8");
            drop.Items.Add("9");
            drop.Items.Add("10");
           
            
            TableRow headers = new TableRow();
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell list = new TableHeaderCell();
            TableHeaderCell hRemove = new TableHeaderCell();
            TableHeaderCell hWeight = new TableHeaderCell();
            TableHeaderCell hExtendedPrice = new TableHeaderCell();
            h1.Text = "Order Summary";
            h2.Text = "Unit Price";
            h3.Text = "Quantity";
            hRemove.Text = "New Quantity:";
            hExtendedPrice.Text = "Extended Price";
            hWeight.Text = "Weight";
            if(Session["ListValue"] != null)
                drop.SelectedValue = Session["ListValue"].ToString();
            list.Controls.Add(drop);
            headers.Cells.Add(h1);
            headers.Cells.Add(h2);
            headers.Cells.Add(h3);
            headers.Cells.Add(hExtendedPrice);
            headers.Cells.Add(hWeight);
            
            headers.Cells.Add(hRemove);
            headers.Cells.Add(list);
            tbl.Rows.Add(headers);

            for (int i = 0; i < cart.Count; i++)
            {
                TableRow tempRow = new TableRow();
                TableCell title, price, remove, change, quantity, extendedPrice, weight;
                title = new TableCell();
                price = new TableCell();
                quantity = new TableCell();
                remove = new TableCell();
                change = new TableCell();
                extendedPrice = new TableCell();
                weight = new TableCell();
                
                
                title.Text = cart[i].Title + "  ";
                price.Text = "$" + String.Format("{0:00.00}", cart[i].Price) + "  ";
                quantity.Text = cart[i].Quantity.ToString();
                extendedPrice.Text = "$" + String.Format("{0:00.00}", cart[i].Price * cart[i].Quantity) + "  ";
                weight.Text = String.Format("{0:0.0}", cart[i].Weight * cart[i].Quantity);
                totalCount += cart[i].Quantity;
                totalPriceValue += cart[i].Price * cart[i].Quantity;
                totalWeightValue += cart[i].Weight * cart[i].Quantity;

                Button buttonRemove = new Button();
                Button buttonChange = new Button();
                

                
                buttonRemove.Click += new EventHandler(this.cmd_Remove);
                buttonRemove.Text = "Remove";

                buttonChange.Click += new EventHandler(this.cmd_Change);
                buttonChange.Text = "Change Quantity";
                buttonChange.ID = (cart[i].ModelNumber * 100).ToString();
                buttonChange.Attributes.Add("runat", "server");
                
                buttonRemove.ID = cart[i].ModelNumber.ToString();
                buttonRemove.Attributes.Add("runat", "server");
                remove.Controls.Add(buttonRemove);
                change.Controls.Add(buttonChange);
                list.Controls.Add(drop);

                tempRow.Cells.Add(title);
                tempRow.Cells.Add(price);
                tempRow.Cells.Add(quantity);
                tempRow.Cells.Add(extendedPrice);
                tempRow.Cells.Add(weight);
                tempRow.Cells.Add(remove);
                tempRow.Cells.Add(change);

                tbl.Rows.Add(tempRow);
            }
            TableHeaderCell count = new TableHeaderCell();
            TableHeaderCell totalPrice = new TableHeaderCell();
            TableHeaderCell totalWeight = new TableHeaderCell();
            TableHeaderCell empty1 = new TableHeaderCell();
            TableHeaderCell empty2 = new TableHeaderCell();
            TableRow totalRow = new TableRow();
            empty2.Text = "Total: ";
            count.Text = totalCount.ToString();
            totalPrice.Text = "$"+ String.Format("{0:00.00}", totalPriceValue);
            totalWeight.Text =  String.Format("{0:0.0}", totalWeightValue);
            totalRow.Cells.Add(empty1);
            totalRow.Cells.Add(empty2);
            totalRow.Cells.Add(count);
            totalRow.Cells.Add(totalPrice);
            totalRow.Cells.Add(totalWeight);
            tbl.Rows.Add(totalRow);

        }
        tbl.Attributes.Add("width", "75%");
        tableHere.Controls.Add(tbl);

        Shipping.Text = "Estimated shipping cost: $"+ String.Format("{0:0.00}", totalWeightValue * .46);
        Session["ShippingCost"] = totalWeightValue * .46;
    }
    public void cmd_Remove(Object sender, EventArgs e)
    {
        Button temp = (Button)sender;
        int isbn = Convert.ToInt32(temp.ID);
        for(int i = 0; i < cart.Count; i++)
        {
            if (isbn == cart[i].ModelNumber)
            {
                cart.RemoveAt(i);
                break;
            }
                
        }
        Response.Redirect("ViewCart.aspx");
    }

    public void cmd_Change(Object sender, EventArgs e)
    {
        Button temp = (Button)sender;
        int isbn = (Convert.ToInt32(temp.ID)/ 100);
        for (int i = 0; i < cart.Count; i++)
        {
            if (isbn == cart[i].ModelNumber)
            {
                cart[i].Quantity = Convert.ToInt32(drop.SelectedValue);
                break;
            }

        }
        Session["ListValue"] = drop.SelectedValue;
        Response.Redirect("ViewCart.aspx");
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(cart.Count == 0)
        {
            Empty.Text = "Shopping Cart is empty, please fill it before checking out.";
        }
        else
        {
            Session["Cart"] = cart;
            Response.Redirect("OrderCheckout.aspx");
        }
            
    }
}