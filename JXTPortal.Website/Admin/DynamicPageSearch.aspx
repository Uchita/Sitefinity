<%@ Page Title="Dynamic Page Search" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="DynamicPageSearch.aspx.cs" Inherits="JXTPortal.Website.Admin.DynamicPageSearch" %>
<%@ Register Src="~/Admin/UserControls/DynamicPageSearchFields.ascx" TagName="ucDynamicPageSearch"
    TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">Dynamic Page Search
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucDynamicPageSearch ID="ucDynamicPageSearch1" runat="server" />
</asp:Content>
