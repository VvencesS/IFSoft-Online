<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCategories.ascx.cs" Inherits="IFSoft.admin.News.NewsCategories" %>
<div>DANH SÁCH TIN TỨC</div>
<div>
    <asp:Repeater ID="rbtNewsCategories" runat="server">
        <HeaderTemplate>
            <table style="width:100%">
                <tr>
                    <td style="width:300px">Category Name</td>
                    <td style="width:50px">Order</td>
                    <td style="width:100px">Active</td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#:Eval("vName") %></td>
                <td><%#:Eval("vOrder") %></td>
                <td><%#:Eval("Active") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>