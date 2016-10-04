<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.Master" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="JXTPortal.Website.pages.PagePreview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltlMetaContent" runat="server" />
    <asp:Literal ID="ltlCSSAndScripts" runat="server" />
    <meta name='robots' content='noindex, nofollow' />
    
<style>
#jxt-top-bar-preview {
     overflow: hidden;
     position: absolute;
     top: 0;
     right: 0;
     z-index: 99999999;

     width: 240px;
     padding: 10px;

     line-height: 1.5;
     font-size: 14px;
     font-weight: 400;
     font-family: Arial, Helvetica, sans-serif;
     text-align: center;
     background: #0085CC;
     background: rgba(0, 133, 204, 0.9);
     color: #fff;
     -ms-transform: translateY(45px) translateX(50px) rotate(45deg);
     transform: translateY(45px) translateX(50px) rotate(45deg); } 
</style>

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

    
<script>
    !(function ($) {
        $(function () {

            var myPreviewBar = $('<div id="jxt-top-bar-preview"><%= PAGE_TYPE %> Preview</div>');
            $("body").prepend(myPreviewBar);

        });
    })($);
</script>
</asp:Content>
