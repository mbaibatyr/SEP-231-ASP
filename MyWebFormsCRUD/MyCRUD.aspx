﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCRUD.aspx.cs" Inherits="MyWebFormsCRUD.MyCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>    
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="1">
            <tr>
                <td bgcolor="green" width="33%" height="150">
                    <asp:DropDownList ID="cbCategory" runat="server" CssClass="form-select" DataTextField="name" DataValueField="id">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                </td>
                <td bgcolor="red" width="33%" height="150">2</td>
                <td bgcolor="yellow" width="33%" height="150">3</td>
            </tr>
            <tr>
                <td bgcolor="blue" width="100%" colspan="3" height="800">4<asp:GridView ID="GvMusic" runat="server" Height="224px" Width="1142px">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
