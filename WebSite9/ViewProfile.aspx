<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="lblNumProfiles" runat="server" Text=""></asp:Label>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                
                   
            <h4>Profile Information</h4>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                <table style="width:100%">
                    <tr>
                        <td>
                            Name: 
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Street:
                        </td>
                        <td>
                            <asp:Label ID="lblStreet" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City:  
                        </td>
                        <td>
                            <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            State: 
                        </td>
                        <td>
                            <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone: 
                        </td>
                        <td>
                            <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email: 
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Zip: 
                        </td>
                        <td>
                            <asp:Label ID="lblZip" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                
            </div>
            <div class="col-md-6">
                
                   
            <h4>Hobbies</h4>
                
                <table style="width:100%">
                    <tr>
                        <td>
                            Sport: 
                        </td>
                        <td>
                            <asp:Label ID="lblSport" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Video Game:
                        </td>
                        <td>
                            <asp:Label ID="lblGame" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Collection:  
                        </td>
                        <td>
                            <asp:Label ID="lblCollection" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job: 
                        </td>
                        <td>
                            <asp:Label ID="lblJob" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                </table>
                
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
</asp:Content>

