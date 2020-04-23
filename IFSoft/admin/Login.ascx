<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="IFSoft.admin.Login" %>
<div>UserName</div>
<div><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></div>
<div>Password</div>
<div><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></div>
<div><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></div>
