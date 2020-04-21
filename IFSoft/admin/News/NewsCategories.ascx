<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCategories.ascx.cs" Inherits="IFSoft.admin.News.NewsCategories" %>
<div>DANH SÁCH TIN TỨC</div>

<asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">
    <asp:View ID="v1" runat="server">
        <div>
            <asp:Repeater ID="rbtNewsCategories" runat="server" OnItemCommand="rbtNewsCategories_ItemCommand">
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
                        <td>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument=<%#:Eval("CateID") %>>
                                <%#:Eval("vName") %>
                            </asp:LinkButton> 

                        </td>
                        <td><%#:Eval("vOrder") %></td>
                        <td><%#:Eval("Active") %></td>
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
        <asp:HiddenField ID="hdCategoryID" runat="server" />
        <asp:HiddenField ID="hdInsert" runat="server" />
        <table>
            <tr>
                <td>Category Name</td>
                <td><asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></td>
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


