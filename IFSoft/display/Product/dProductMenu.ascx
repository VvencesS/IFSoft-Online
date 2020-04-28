<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dProductMenu.ascx.cs" Inherits="IFSoft.display.Product.dProductMenu" %>
<asp:Repeater ID="rptProductList" runat="server">
    <ItemTemplate>
        <li><a href="#"><%#:Eval("vName") %></a></li>
    </ItemTemplate>
</asp:Repeater>