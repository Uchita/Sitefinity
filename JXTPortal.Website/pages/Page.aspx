<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="JXTPortal.Website.pages.Page" %>
<%--<%@ Register Src="~/usercontrols/navigation/ucDynamicPageList.ascx" TagName="ucDynamicPageList" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltlMetaContent" runat="server" />
    <asp:Literal ID="ltlCSSAndScripts" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltlAboveHeader" runat="server" />
    <asp:PlaceHolder ID="plHeader" runat="server">
        <div id="header">
            <JXTControl:ucLanguages ID="ucLanguage" runat="server" />
            <asp:Literal ID="ltlHeader" runat="server" />
        </div>
    </asp:PlaceHolder>
    <div id="dynamic-container">
        <%--<div id="dynamic-side-left-container">--%>
        <asp:Literal ID="ltlLeftNavigation" runat="server" />
        <%-- <uc1:ucDynamicPageList ID="ucDynamicPageList1" runat="server" />
        </div>--%>
        <div id="dynamic-content">
            <asp:Literal ID="ltBreadcrumb" runat="server" />
            <div class="dynamic-content-holder">
                <asp:Literal ID="ltlContent" runat="server" />
            </div>
        </div>
        <asp:Literal ID="ltlRightNavigation" runat="server" />
    </div>
    <asp:PlaceHolder ID="plFooter" runat="server">
        <div id="footer">
            <asp:Literal ID="ltlFooter" runat="server" />
        </div>
    </asp:PlaceHolder>
    <asp:Literal ID="ltlBelowFooter" runat="server" />
</asp:Content>
