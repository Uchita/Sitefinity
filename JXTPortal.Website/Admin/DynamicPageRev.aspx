<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="True"
    CodeBehind="DynamicPageRev.aspx.cs" Inherits="JXTPortal.Website.Admin.DynamicPageRev" %>

<%@ Register Src="~/admin/usercontrols/DynamicPagesStatusListing.ascx" TagName="ucDynamicPageStatusListing"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucDynamicPageStatusListing ID="ucDynamicPageStatusListing1" runat="server" IsAdmin="true"
        Visible="true" />
</asp:Content>
