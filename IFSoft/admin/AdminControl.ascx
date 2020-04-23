﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adminControl.ascx.cs" Inherits="IFSoft.admin.AdminControl" %>
<%@ Register src="Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<div>
    Banner Admin UserName:[<%=Session["username"] %>]&nbsp;<asp:LinkButton ID="lnkExit" runat="server" OnClick="lnkExit_Click">Exit</asp:LinkButton>
</div>
<table cellspasing="0" cellpadding="0" style="width:100%">
    <tr>
        <td style="width:200px"><uc1:Menu ID="Menu1" runat="server" /></td>
        <td style="width:10px">&nbsp;</td>
        <td style="vertical-align:top;"><asp:PlaceHolder ID="plLoad" runat="server"></asp:PlaceHolder></td>
    </tr>
</table>
