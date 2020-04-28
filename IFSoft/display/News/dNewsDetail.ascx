<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dNewsDetail.ascx.cs" Inherits="IFSoft.display.News.dNewsDetail" %>
<div><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
<asp:Repeater ID="rptNewsDetails" runat="server">
    <ItemTemplate>
        <img src='/Images/<%#:Eval("vImage") %>' width="200px" style="margin:20px auto;"/>
    </ItemTemplate>
</asp:Repeater>
<div><asp:Literal ID="ltDesc" runat="server"></asp:Literal></div>
<div><asp:Literal ID="ltContent" runat="server"></asp:Literal></div>
<div><asp:Literal ID="ltAuthor" runat="server"></asp:Literal></div>

<div>TIN TỨC KHÁC</div>
<asp:Repeater ID="rptNewsList" runat="server">
    <ItemTemplate>
        <div>
            <a href='?f=news&fs=del&id=<%#:Eval("DelID") %>' class="title">
                <%#:Eval("vTitle") %>
            </a>
        </div>
    </ItemTemplate>
</asp:Repeater>

