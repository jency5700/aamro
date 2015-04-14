<%@ Page Title="Add Users" Language="C#" AutoEventWireup="true" MasterPageFile="~/Aamro.Master"
CodeBehind="AddUser.aspx.cs" Inherits="AAMRO_CRM.Modules.AddUser" %>
<%@ MasterType VirtualPath="~/Aamro.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
<table style="vertical-align:top;border-width:thin;border-color:blue;border-style:solid" width = "100%">
    <tr>
        <td>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        </td>

        <td>
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
            </td><td>
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList>            
        </td>        
        </tr>
    <tr>
        <td>
            <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
            </td><td>
            <asp:DropDownList ID="ddlDepartment" runat="server">
                <asp:ListItem Value="1">Accounts</asp:ListItem>
                <asp:ListItem Value="2">IT</asp:ListItem>
                <asp:ListItem Value="3">Sales</asp:ListItem>
            </asp:DropDownList>            
        </td>        

        <td>
            <asp:Label ID="lblDivision" runat="server" Text="Division"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtDivision" runat="server"></asp:TextBox>
        </td>
        
        <td>
            <asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label>
            </td><td>
            <asp:DropDownList ID="ddlRole" runat="server">
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Supervisor</asp:ListItem>
                <asp:ListItem Value="3">Manager</asp:ListItem>
            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>

        <td>
            <asp:Label ID="lblContact" runat="server" Text="Contact"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
        </td>
        </tr>
    <tr>
    <td colspan = "2"></td>
    <td align="right">
        <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" /> 
        </td>
    <td align="left">
        <asp:Button ID="btnClear" runat="server" Text="Clear" onclick="btnClear_Click" />
        </td>
    <td colspan = "2"></td>
    </tr>
    </table>
</asp:Content>

