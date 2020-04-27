<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dNewsList.ascx.cs" Inherits="IFSoft.display.News.dNewsList" %>
<div>News List</div>
<asp:Repeater ID="rptNewsDetails" runat="server">
            <HeaderTemplate>
                <table style="width:100%;">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td colspan="2">
                        <a href='?f=news&id=<%#:Eval("DelID") %>' class="title">
                            <%#:Eval("vTitle") %>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <img src='/Images/<%#:Eval("vImage") %>' width="120px"/>

                    </td>
                    <td style="vertical-align:top;"><%#:Eval("vDesc") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>