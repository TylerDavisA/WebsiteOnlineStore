<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
    function EmailValidation(objSource, objArgs) {
                        var city = objArgs.Value;
                        if (/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(city) && city.length > 0)
                            objArgs.IsValid = true;
                        else
                            objArgs.IsValid = false;
                    }
    </script>
    <div class="container">
         <h4>Shipping Information</h4>
                <table style="width:100%">
                    <tr>
                        <td>
                            User Name: <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="vldName" runat="server" ErrorMessage="You must enter a user name." ControlToValidate="txtUserName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Password:  <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a password." ControlToValidate="txtPass" />
                        
                        </td>
                    </tr>

                    <tr>
                        <td>
                            (Compare Validation) Password (retype):  <span style="color:red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPass2" runat="server"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ValidateEmptyText="True"   ErrorMessage="Passwords do not match." 
                                ControlToCompare="txtPass" ControlToValidate="txtPass2"/>
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
                    <tr>
                        <td>
                            <asp:Label ID="UserTaken" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right">
                            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                        </td>
                    </tr>
                </table>
    </div>
</asp:Content>

