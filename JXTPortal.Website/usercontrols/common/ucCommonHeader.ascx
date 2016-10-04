<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCommonHeader.ascx.cs" Inherits="JXTPortal.Website.usercontrols.common.ucCommonHeader" %>
<%--<%    
    bool isSecureConnection = String.Equals(Request.Headers["X-Forwarded-Proto"], "https", StringComparison.OrdinalIgnoreCase);

    if (isSecureConnection)
    {
%>
<meta name="robots" content="noindex,nofollow" />
<% } %>--%>
<%--
<%=Request.IsSecureConnection %>
<%=Request.Headers["X-Forwarded-Proto"] %>**
<%=Request.ServerVariables["SERVER_PORT_SECURE"]%>##--%>



<asp:Literal ID="ltlLanguageLinks" runat="server" />

