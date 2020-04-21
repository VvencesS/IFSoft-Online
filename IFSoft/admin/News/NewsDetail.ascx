<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs" Inherits="IFSoft.admin.News.NewsDetail" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<FTB:FreeTextBox ID="txtContent" runat="server"></FTB:FreeTextBox>
<asp:Button ID="BtnTest" runat="server" Text="Load Data from FreeTextBox" OnClick="BtnTest_Click"/>
