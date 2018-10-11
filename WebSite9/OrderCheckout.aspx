<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="OrderCheckout.aspx.cs" Inherits="OrderCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="container">
         
        <div class="row">
            <div class="col-md-6">

                <h4>Order Summary</h4>
                <br />
                <br />
                <div id="tableHere"  runat="server">
                    </div>
                <br />
                <br />
                <br />
                <br />
                
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
                        if (/(^\d{5}$)|(^\d{5}-\d{4}$)/.test(zip) && zip.length > 0)
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
            <h4>Shipping Information</h4>
                <table style="width:100%">
                    <tr>
                        <td>
                            Name: <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="vldName" runat="server" ErrorMessage="You must enter your name." ControlToValidate="txtName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Street: <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="vldStreet" runat="server" ErrorMessage="You must enter your street." ControlToValidate="txtStreet" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City:  <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><asp:CustomValidator ID="vldCity" runat="server" ErrorMessage="You must enter your city (No numbers)." ValidateEmptyText="True" ControlToValidate="txtCity"
                    ClientValidationFunction="CityValidation"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            State:  <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox><asp:CustomValidator ID="vldState" runat="server" ErrorMessage="State must be a 2 letter Abbreviation" ValidateEmptyText="True" ControlToValidate="txtState" 
                    ClientValidationFunction="StateValidation"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Zip:  <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox><asp:CustomValidator ID="vldZip" runat="server" ErrorMessage="You must enter your 5-digit Zip." ValidateEmptyText="True" ControlToValidate="txtZip"
                    ClientValidationFunction="ZipValidation"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email: <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:CustomValidator ID="vldEmail" runat="server" ValidateEmptyText="True" ErrorMessage="You must enter your Email containing '@'." 
                    ControlToValidate="txtEmail" ClientValidationFunction="EmailValidation" />
                        </td>
                    </tr>
                </table>
                
                 
                
                
                
                
                
                
                <asp:Button ID="Submit" runat="server" Text="Submit Order" OnClick="Submit_Click" />
        <asp:Button ID="Continue" runat="server" Text="Continue Shopping" OnClick="Continue_Click" /><br />
                <asp:Label ID="Required" runat="server" Text=""></asp:Label>
        
                
            </div>
            <div class="col-md-6" id="tableHeres" runat="server">
               <h3>We Love You!</h3>
                
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
    <br />
    <br />
</asp:Content>

