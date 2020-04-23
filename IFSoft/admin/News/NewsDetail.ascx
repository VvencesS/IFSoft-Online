<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs" Inherits="IFSoft.admin.News.NewsDetail" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">
    <asp:View ID="v0" runat="server">
        <asp:Repeater ID="rptNewsDetails" runat="server" OnItemCommand="rptNewsDetails_ItemCommand">
            <HeaderTemplate>
                <table style="width:100%;">
                    <tr>
                        <td style="width:100px;">Image</td>
                        <td style="width:400px;">Title</td>
                        <td style="width:100px;">Author</td>
                        <td style="width:100px;">Active</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><img src='/Images/<%#:Eval("vImage") %>' width="100px"/></td>
                    <td><%#:Eval("vTitle") %></td>
                    <td><%#:Eval("vAuthor") %></td>
                    <td><%#:Eval("Active") %></td>
                    <td>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%#:Eval("DelID") %>'>Cập nhật</asp:LinkButton>
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#:Eval("DelID") %>' OnLoad="msgDelete">Xóa</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdInsert" runat="server" />
        <asp:HiddenField ID="hdDelID" runat="server" />
        <asp:HiddenField ID="hdImage" runat="server" />
        <div><asp:LinkButton ID="lnkUpdate" runat="server" OnClick="lnkUpdate_Click">Add New</asp:LinkButton></div>
    </asp:View>
    <asp:View ID="v1" runat="server">
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">News Category</td>
                <td style="width:10px;"></td>
                <td><asp:DropDownList ID="drpNewsCategoy" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Title</td>
                <td></td>
                <td><asp:TextBox ID="txtTitle" runat="server" style="width:500px"></asp:TextBox></td>
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
                <td>Author</td>
                <td></td>
                <td><asp:TextBox ID="txtAuthor" runat="server" style="width:500px"></asp:TextBox></td>
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

