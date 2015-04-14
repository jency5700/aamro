<%@ Page Title="Manage Users" Language="C#" AutoEventWireup="true" MasterPageFile="~/Aamro.Master"
CodeBehind="ManageUsers.aspx.cs" Inherits="AAMRO_CRM.Modules.ManageUsers" %>
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
                <asp:ListItem Value="0">-Select-</asp:ListItem>
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
            </asp:DropDownList>
        </td>
        
    </tr>
    <tr>

        <td>
            <asp:Label ID="lblContact" runat="server" Text="Contact"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
        <td colspan ="2">
            <asp:RegularExpressionValidator ID="EmailVal" runat="server" ForeColor="Red" Font-Size="Medium"
                ErrorMessage="Invalid Email" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
        </td>
        </tr>
 


    <tr>
    <td colspan = "2"></td>
    <td colspan = "2">
        <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" /> 
        <asp:Button ID="btnSearch" runat="server" Text="Search" 
            onclick="btnSearch_Click" />        
        <asp:Button ID="btnClear" runat="server" Text="Clear" 
            onclick="btnClear_Click" />
        </td>
    <td colspan = "2"></td>
    </tr>
    </table>
    <table style="vertical-align:top;border-width:thin;border-color:blue;border-style:solid" width = "100%">
<tr><asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="UserId"
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" OnItemDataBound="Grid_ItemDataBound">
<Columns>
<asp:BoundColumn HeaderText="User Id" DataField="UserId" Visible ="false" ReadOnly ="true">
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="User Name">
    <EditItemTemplate>
        <asp:TextBox ID="txtUserName" runat="server"
          Text='<%# Bind("UserName") %>'>
        </asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            runat="server" ControlToValidate="txtUserName"
            ErrorMessage="User name cannot be blank" ForeColor="Red"
            ValidationGroup="EditValidationControls">
        </asp:RequiredFieldValidator>--%>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="lblUserName" runat="server"
          Text='<%# Bind("UserName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Gender">
    <HeaderStyle Width="100px" Wrap="False"></HeaderStyle>
    <EditItemTemplate>
        <asp:DropDownList ID="ddldgGender" runat="server" DataSource='<%# DdlGenderData() %>'
DataTextField="Gender" DataValueField = "GenderId" >
        </asp:DropDownList>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="lbldgGender" runat="server" Text='<%# Bind("[Gender]") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Department">
    <HeaderStyle Width="100px" Wrap="False"></HeaderStyle>
    <EditItemTemplate>
        <asp:DropDownList ID="ddldgDept" runat="server" DataSource='<%# DdlDeptData() %>'
DataTextField="Department" DataValueField = "DeptId">
        </asp:DropDownList>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="lbldgDept" runat="server" Text='<%# Bind("[Department]") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="Division" DataField="Division">
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="Role" >
    <HeaderStyle Width="100px" Wrap="False"></HeaderStyle>
    <EditItemTemplate>
        <asp:DropDownList ID="ddldgRole" runat="server" DataSource='<%# DdlRoleData() %>' se
DataTextField="Role" DataValueField = "RoleId">
        </asp:DropDownList>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="lbldgRole" runat="server" Text='<%# Bind("[Role]") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="Contact" DataField="Contact">
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="Email">
    <EditItemTemplate>
        <asp:TextBox ID="txtEmail" runat="server"
          Text='<%# Bind("Email") %>'>
        </asp:TextBox>
        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1"
            runat="server" ControlToValidate="txtEmail" ForeColor="Red"
            ErrorMessage="Invalid Email" ValidationExpression="^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$"
            ValidationGroup="EditValidationControls">
        </asp:RegularExpressionValidator>--%>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="lblEmail" runat="server"
          Text='<%# Bind("Email") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateColumn>


<asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit" ValidationGroup = "EditValidationControls">
</asp:EditCommandColumn>
<asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete">
</asp:ButtonColumn>

<asp:BoundColumn HeaderText="Gender" DataField="Gender" Visible ="false" ReadOnly ="true">
</asp:BoundColumn>
<asp:BoundColumn HeaderText="Department" DataField="DeptId" Visible = "false" ReadOnly ="true">
</asp:BoundColumn>
<asp:BoundColumn HeaderText="Role" DataField="RoleId" Visible = "false" ReadOnly ="true">
</asp:BoundColumn>
</Columns>
<FooterStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
<SelectedItemStyle BackColor="#CCCCFF" Font-Bold="True" ForeColor="Navy" />
<PagerStyle ForeColor="#006699" HorizontalAlign="Left" Mode="NumericPages" />
<AlternatingItemStyle BackColor="White" />
<ItemStyle BackColor="#CCCCFF" ForeColor="#333333" />
<HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" />
</asp:DataGrid>
</tr>
</table>
</asp:Content>

