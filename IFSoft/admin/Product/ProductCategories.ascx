<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCategories.ascx.cs" Inherits="IFSoft.admin.Product.ProductCategories" %>
<div>DANH SÁCH SẢN PHẨM</div>

<asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">
    <asp:View ID="v1" runat="server">
        <div>
            <asp:Repeater ID="rbtProductCategories" runat="server" OnItemCommand="rbtProductCategories_ItemCommand">
                <HeaderTemplate>
                    <table style="width:100%">
                        <tr>
                            <td style="width:300px">Name</td>
                            <td style="width:50px">Order</td>
                            <td style="width:100px">Active</td>
                            <td></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument=<%#:Eval("ProID") %>>
                                <%#:Eval("vName") %>
                            </asp:LinkButton> 

                        </td>
                        <td><%#:Eval("vOrder") %></td>
                        <td><%#:Eval("Active") %></td>
                        <td>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument=<%#:Eval("ProID") %> OnLoad="msgDelete">
                                Xóa
                            </asp:LinkButton> 

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lnkAddNew_Click1">Add New</asp:LinkButton>
        </div>
            
    </asp:View>
    <asp:View ID="v2" runat="server">
        <asp:HiddenField ID="hdProID" runat="server" />
        <asp:HiddenField ID="hdInsert" runat="server" />
        <table>
            <tr>
                <td>Product Category Name</td>
                <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Order</td>
                <td><asp:TextBox ID="txtOrder" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Active</td>
                <td><asp:CheckBox ID="chkActive" runat="server" Checked="true"/></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSave" runat="server" Text="Cập nhật" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>