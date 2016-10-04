<%@ Page Title="AdvertiserJobTemplate Logo" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="AdvertiserJobTemplateLogo.aspx.cs" Inherits="JXTPortal.Website.Admin.AdvertiserJobTemplateLogo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">Advertiser Job Template Logo
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <JXTControl:AdvertiserJobTemplateLogo ID="ucAdvertiserJobTemplateLogo" runat="server" IsAdmin="True" />
</asp:Content>

