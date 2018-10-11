<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="BookInfoPage.aspx.cs" Inherits="BookInfoPage"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            
            <div class="col-lg-6">

                Quantity:<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <asp:Button ID="Add" runat="server" Text="Add To Cart" OnClick="Add_Click" />
                <asp:Button ID="viewCart" runat="server" Text="View Shopping Cart" OnClick="goToCart" />
                <br />
                <asp:Label id="successful" runat="server"></asp:Label>
                
                <br />
                <br />
                <br />
                <div class="container" id="Literal2" runat="server"></div>
               
                
                </div>
                
                <div class="col-lg-6" id="Literal1" runat="server">
                
            </div>
                   
            
        </div>
        
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
    

           
</asp:Content>

