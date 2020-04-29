<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dProductDetail.ascx.cs" Inherits="IFSoft.display.Product.dProductDetail" %>
<div><asp:Literal ID="ltName" runat="server"></asp:Literal></div>
<div style="float:left;width:30%;"><asp:Literal ID="ltImage" runat="server"></asp:Literal></div>
<div style="float:left;width:68%;">
    <asp:Literal ID="ltDesc" runat="server"></asp:Literal><br />
    <asp:Literal ID="ltPrice" runat="server"></asp:Literal><br />
    <asp:LinkButton ID="lnkCart" runat="server" OnClick="lnkCart_Click">Thêm vào giỏ</asp:LinkButton>
</div>
<div style="clear:both;"></div>
<div style="clear:both;"><asp:Literal ID="ltContent" runat="server"></asp:Literal></div>