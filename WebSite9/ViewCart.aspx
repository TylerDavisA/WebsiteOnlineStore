<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="container">
        <div class="row">
            
            
                <h3><span>Your</span> Cart</h3>
                <div id="tableHere"  runat="server">

    </div>
                
             <br />
            <asp:Label ID="Shipping" runat="server" Text="Estimated shipping cost: " Font-Bold="True" Font-Italic="True"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Check Out" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Continue Shopping" OnClick="Button2_Click" />
            <br />
             <asp:Label ID="Empty" runat="server" Text=""></asp:Label>
              
                   
            
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    
</asp:Content>



