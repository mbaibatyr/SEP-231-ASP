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
                    
                </td>
                <td bgcolor="red" width="33%" height="150">
                    <table  width="100%">
                        <tr><td><asp:TextBox ID="tbName" runat="server"  CssClass="form-control"></asp:TextBox></td></tr>
                        <tr><td><asp:TextBox ID="tbAuthor" runat="server"  CssClass="form-control"></asp:TextBox></td></tr>
                        <tr><td><asp:TextBox ID="tbDesc" runat="server"  CssClass="form-control"></asp:TextBox></td></tr>
                        <tr><td> <asp:DropDownList ID="cbCategory2" runat="server" CssClass="form-select" DataTextField="name" DataValueField="id">
                         </asp:DropDownList></td></tr>
                        <tr><td>
                            <asp:Button ID="btIns" runat="server" Text="Добавить" OnClick="btIns_Click"></asp:Button>
                            <asp:Button ID="btUpd" runat="server" Text="Изменить" OnClick="btUpd_Click" OnClientClick="return confirm('Изменить запись?');"></asp:Button>
                            <asp:Button ID="btClear" runat="server" Text="Очистить" OnClick="btClear_Click"></asp:Button>
                            <asp:HiddenField ID="music_id" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                    </table>

                </td>
                <td bgcolor="yellow" width="33%" height="150">
                      <asp:DropDownList ID="cbReport" runat="server" CssClass="form-select" DataTextField="name" DataValueField="id">
                          <asp:ListItem Selected="True">Excel</asp:ListItem>
                          <asp:ListItem>CSV</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btReport" runat="server" Text="Выгрузить" CssClass="btn btn-info" OnClick="btReport_Click" ></asp:Button>
                </td>
            </tr>
            <tr>
                <td bgcolor="blue" width="100%" colspan="3" height="800">
                    <asp:GridView ID="GvMusic" runat="server" CssClass="GridView_With_GridLines" DataKeyNames="id,name,author,category_id,description"
                        AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                        BorderWidth="1px" CellPadding="4" PageSize="21" AutoGenerateColumns="False" OnSelectedIndexChanged="GvMusic_SelectedIndexChanged">
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#FFD789" BorderStyle="Groove" BorderWidth="2" />
            <PagerSettings Position="TopAndBottom" />
            <PagerStyle CssClass="cssPager" />
            <Columns>
                <asp:CommandField SelectText="Выбрать" ShowSelectButton="True">
                    <HeaderStyle Wrap="True" Width="100" />
                    <ItemStyle CssClass="GridView_HyperLink" Wrap="True" ForeColor="Red" />
                    <ControlStyle Width="50px" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="№">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Название">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="700px" />
                </asp:BoundField>
                <asp:BoundField DataField="description" HeaderText="Описание">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="700px" />
                </asp:BoundField>
                <asp:BoundField DataField="category" HeaderText="Категория">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="700px" />
                </asp:BoundField>
                <asp:BoundField DataField="category_id" HeaderText="ID Категории" Visible="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="700px" />
                </asp:BoundField>
                <asp:BoundField DataField="author" HeaderText="Автор">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="700px" />
                </asp:BoundField>                
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle CssClass="GridView_With_GridLines_Header" ForeColor="#CCCCFF" HorizontalAlign="Left"
                Wrap="False" BackColor="#003399" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
