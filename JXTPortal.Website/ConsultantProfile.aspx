<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true" CodeBehind="ConsultantProfile.aspx.cs" Inherits="JXTPortal.Website.ConsultantProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-container">
    <div id="content">  
        <div class="content-holder">
            <asp:Literal ID="ltlSystemDynamicPage" runat="server" />
            
        </div>
    </div>
    </div>

    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
</asp:Content>
