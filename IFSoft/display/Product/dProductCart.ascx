<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dProductCart.ascx.cs" Inherits="IFSoft.display.Product.dProductCart" %>
<asp:Repeater ID="rptProductCart" runat="server">
    <HeaderTemplate>
        <table style="width:100%;">
            <tr>
                <td>Name</td>
                <td>Quantity</td>
                <td>Price</td>
                <td>Money</td>
                <td></td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
            <tr>
                <td><%#:Eval("Name") %></td>
                <td><%#:Eval("Quantity") %></td>
                <td><%#:string.Format("{0:N0}", Eval("Price")) %></td>
                <td><%#:string.Format("{0:N0}", Eval("Money")) %></td>
                <td><asp:LinkButton ID="lnkDelete" runat="server">Xóa</asp:LinkButton></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>