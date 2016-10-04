<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="JXTPortal.Website._404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeftNav" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
				<%--<h1>Page Not Found</h1>
				<p></p>
                <h2>The page you requested could not be found. </h2>
                <p>Please try the following:</p>
                <ul style="margin-left: 40px; list-style-type: square;">
                        <li>Make sure that the address you have typed is and formatted correctly.
                        </li>
                        <li>If you have reached this page from a link, contact their web site administrator to let them know that the link is incorrect.
                        </li>
                        <li>Please click <a href="/">here</a> to return to our <a href="/">home page</a>. </li>
                </ul>
                <p>&nbsp;</p>--%>
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_404" />
        </div>
    </div>
</asp:Content>
