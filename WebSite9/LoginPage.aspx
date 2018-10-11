<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <table>
            <tr>
                <th>Login:</th>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td>User Name:</td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td>Remember me:<asp:CheckBox ID="CheckBox" runat="server" /><br /></td>
                
                <td style="text-align: right">
                    <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Wrong" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="Registration.aspx">Don't have an account? Register here.</a>
                </td>
            </tr>

        </table>
    </div>
</asp:Content>

