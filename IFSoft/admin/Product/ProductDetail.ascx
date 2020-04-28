<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.ascx.cs" Inherits="IFSoft.admin.Product.ProductDetail" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">
    <asp:View ID="v0" runat="server">
        <div>LIST PRODUCT DETAIL</div>
        <asp:DropDownList ID="drpProductCategory1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpProductCategory1_SelectedIndexChanged"></asp:DropDownList>
        <asp:Repeater ID="rptProductDetails" runat="server" OnItemCommand="rptProductDetails_ItemCommand">
            <HeaderTemplate>
                <table style="width:100%;">
                    <tr>
                        <td style="width:100px;">Image</td>
                        <td style="width:100px;">Name</td>
                        <td style="width:100px;">Quantity</td>
                        <td style="width:100px;">Price</td>
                        <td style="width:100px;">Active</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><img src='/Images/<%#:Eval("vImage") %>' width="100px"/></td>
                    <td><%#:Eval("vName") %></td>
                    <td><%#:Eval("iQuantity") %></td>
                    <td><%#:Eval("vPrice") %></td>
                    <td><%#:Eval("Active") %></td>
                    <td>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%#:Eval("ProDelID") %>'>Cập nhật</asp:LinkButton>
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#:Eval("ProDelID") %>' OnLoad="msgDelete">Xóa</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdInsert" runat="server" />
        <asp:HiddenField ID="hdProDelID" runat="server" />
        <asp:HiddenField ID="hdImage" runat="server" />
        <div><asp:LinkButton ID="lnkUpdate" runat="server" OnClick="lnkUpdate_Click">Add New</asp:LinkButton></div>
    </asp:View>
    <asp:View ID="v1" runat="server">
        <div>ADD NEW/UPDATE PRODUCTDETAIL</div>
        <table style="width:100%;">
            <tr>
                <td style="width:150px;">Product Category</td>
                <td style="width:10px;"></td>
                <td><asp:DropDownList ID="drpProductCategory" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Code</td>
                <td></td>
                <td><asp:TextBox ID="txtCode" runat="server" style="width:500px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Name</td>
                <td></td>
                <td><asp:TextBox ID="txtName" runat="server" style="width:500px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Desc</td>
                <td></td>
                <td><asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" style="width:500px;"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Content</td>
                <td></td>
                <td><FTB:FreeTextBox ID="txtContent" runat="server"></FTB:FreeTextBox></td>
            </tr>
            <tr>
                <td>Image</td>
                <td></td>
                <td><asp:FileUpload ID="fUp" runat="server" /></td>
            </tr>
            <tr>
                <td>Quantity</td>
                <td></td>
                <td><asp:TextBox ID="txtQuantity" runat="server" style="width:500px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Price</td>
                <td></td>
                <td><asp:TextBox ID="txtPrice" runat="server" style="width:500px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>View</td>
                <td></td>
                <td><asp:TextBox ID="txtView" runat="server" TextMode="MultiLine" style="width:500px;"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Active</td>
                <td></td>
                <td><asp:CheckBox ID="chkActive" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:Button ID="btnUpdate" runat="server" Text="update" OnClick="btnUpdate_Click"></asp:Button></td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>