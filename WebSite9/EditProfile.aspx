<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs"  Inherits="EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="container">
        <div class="row">
            <div class="col-md-6">
                
                     <script type="text/javascript">
                    function StateValidation(objSource, objArgs) {
                        var state = objArgs.Value;
                        if (state.length == 2 && state.length > 0)
                            objArgs.IsValid = true;
                        else
                            objArgs.IsValid = false;
                    }
                    function ZipValidation(objSource, objArgs) {
                        var zip = objArgs.Value;
                         if (/^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/.test(zip) && zip.length > 0)
                            objArgs.IsValid = true;
                        else
                            objArgs.IsValid = false;
                    }
                    function CityValidation(objSource, objArgs) {
                        var city = objArgs.Value;
                        if (/^[a-zA-Z]+$/.test(city) && city.length > 0)
                            objArgs.IsValid = true;
                        else
                            objArgs.IsValid = false;
                    }
                    function EmailValidation(objSource, objArgs) {
                        var city = objArgs.Value;
                        if (/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(city) && city.length > 0)
                            objArgs.IsValid = true;
                        else
                            objArgs.IsValid = false;
                    }
                </script>
           
                <table style="width:100%">
                    <tr>
                        <td>
                            Name: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Street: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox> 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><asp:CustomValidator ID="vldCity" runat="server" ErrorMessage="You must enter your city (No numbers)."  ControlToValidate="txtCity"
                    ClientValidationFunction="CityValidation"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            State:  
                        </td>
                        <td>
                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox><asp:CustomValidator ID="vldState" runat="server" ErrorMessage="State must be a 2 letter Abbreviation" ControlToValidate="txtState" 
                    ClientValidationFunction="StateValidation"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone:  
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><asp:CustomValidator ID="vldZip" runat="server" ErrorMessage="You must enter a number" ControlToValidate="txtPhone"
                    ClientValidationFunction="ZipValidation"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:CustomValidator ID="vldEmail" runat="server" ErrorMessage="You must enter your Email containing '@'." 
                    ControlToValidate="txtEmail" ClientValidationFunction="EmailValidation" />
                        </td>
                    </tr>
                     <tr>
                        <td>
                           Zip: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div class="col-md-6">
                 <h4>Hobbies</h4>
                
                <table style="width:100%">
                    <tr>
                        <td>
                            Sport: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtSport" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Video Game:
                        </td>
                        <td>
                            <asp:TextBox ID="txtGame" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Collection:  
                        </td>
                        <td>
                            <asp:TextBox ID="txtCollection" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtJob" runat="server"></asp:TextBox>
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

