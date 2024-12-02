<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCRUD.aspx.cs" Inherits="MyWebFormsCRUD.MyCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="1">
            <tr>
                <td bgcolor="green" width="33%" height="150">
                    <asp:DropDownList ID="cbCategory" runat="server" CssClass="form-select" DataTextField="name" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="cbCategory_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                </td>
                <td bgcolor="red" width="33%" height="150">
                    <table  width="100%">
                        <tr><td><asp:TextBox ID="tbName" runat="server"  CssClass="form-control"></asp:TextBox></td></tr>
                        <tr><td><asp:TextBox ID="tbAuthor" runat="server"  CssClass="form-control"></asp:TextBox></td></tr>
                        <tr><td><asp:TextBox ID="tbDesc" runat="server"  CssClass="form-control"></asp:TextBox></td></tr>
                        <tr><td> <asp:DropDownList ID="cbCategory2" runat="server" CssClass="form-select" DataTextField="name" DataValueField="id">
                         </asp:DropDownList></td></tr>
                    </table>

                </td>
                <td bgcolor="yellow" width="33%" height="150">3</td>
            </tr>
            <tr>
                <td bgcolor="blue" width="100%" colspan="3" height="800">
                    <asp:GridView ID="GvMusic" runat="server" CellPadding="2" ForeColor="Black" GridLines="None" Height="248px" Width="1317px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
