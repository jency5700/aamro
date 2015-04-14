<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AAMRO_CRM.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-weight: normal;
            font-size: medium;
            width: 235px;
        }
        .style3
        {
            width: 237px;
        }
        .style4
        {
            font-family: "Helvetica Neue", "Lucida Grande", "Segoe UI", Arial, Helvetica, Verdana, sans-serif;
            font-weight: normal;
            width: 235px;
            text-align: right;
            font-size: small;
        }
        .style6
        {
            font-weight: normal;
            text-align: left;
            font-size: medium;
        }
        .style7
        {
            width: 237px;
            text-align: left;
        }
    </style>
</head>
<body style="font-weight: 700; font-size: x-large; text-align: center">
    <form id="login" runat="server">
    <div style="height:50px"></div>
    <table class="style1" bgcolor="#D5D5F7" width = "100%">
    <tr><td>
    <asp:Image  ImageUrl="~/login.png" runat="server"/>
    </td>
    <td><table width = "100%">
     <tr>
            <td class="style4">
                User Name</td>
            <td class="style7">
                <asp:TextBox ID="txtUserName" runat="server" Width="180px" TabIndex="1"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="2" align="right">
                <asp:RequiredFieldValidator ID="valUserName" runat="server" 
                    ControlToValidate="txtUserName" ErrorMessage="Please enter User Name" 
                    ForeColor="Red" Font-Size="Medium"></asp:RequiredFieldValidator></td></tr>
        <tr>
            <td class="style4">
                Password</td>
            <td class="style7">
                <asp:TextBox ID="txtpassword" runat="server"  
                    TextMode="Password" Width="180px" TabIndex="2"></asp:TextBox>
            </td>
           </tr>
        
        <tr><td colspan="2" align="right">
                <asp:RequiredFieldValidator ID="valPassword" runat="server" 
                    ControlToValidate="txtpassword" ErrorMessage="Please enter Password" 
                    ForeColor="Red" Font-Size="Medium"></asp:RequiredFieldValidator>
                </td></tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" 
                    Width="80px" TabIndex="3" />
                    <abbr>   &nbsp;&nbsp;   </abbr>
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" 
                    onclick="btnClear_Click" TabIndex="4" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table></td>
    </tr>
       
    </table>
    </form>
    </body>
</html>
