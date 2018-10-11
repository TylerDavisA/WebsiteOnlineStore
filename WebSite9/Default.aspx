<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <table>
                    <tr>
                        <th>Sort by: </th>
                        <td><asp:DropDownList ID="SortList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SortList_SelectedIndexChanged" ></asp:DropDownList></td>
                    </tr>
                </table>
                
            </div>
            <div class="col-md-2">
                <table>
                    <tr>
                        <th>Ascending: </th>
                        <td><asp:CheckBox ID="Ascend" runat="server" AutoPostBack="true" OnCheckedChanged="Ascend_CheckedChanged" /></td>
                    </tr>
                </table>
                <br />
                <br />
            </div>
        </div>
    </div>
    <div class="conatiner">
        <div class="container" id="TableHere" runat="server"></div>
    </div>
    

    

</asp:Content>

