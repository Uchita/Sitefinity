<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WidgetSearch.aspx.cs" Inherits="JXTPortal.Website.job.WidgetSearch" %>
<%@ Register src="~/usercontrols/job/ucAdvancedSearch.ascx" tagname="ucAdvancedSearch" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">    
    <asp:Literal ID="ltJquery" runat="server" />
    <script type="text/javascript" src="//images.jxt.net.au/COMMON/js/jxtscript.js"></script>
    <meta name="robots" content="nofollow" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:ucAdvancedSearch ID="ucAdvancedSearch1" runat="server" IsAdvancedSearch="false" IsDynamicWidget="" />
    </form>
</body>
</html>
