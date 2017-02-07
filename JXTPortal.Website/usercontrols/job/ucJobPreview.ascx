<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobPreview.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucJobPreview" %>   
    <asp:Literal ID="litJobExpired" runat="server" />
<div class="jobdetail-top">
    <div class="job-detailtop-title">
        <asp:HyperLink ID="hLinkJob" runat="server" />
        -
        <asp:HyperLink ID="hLinkProfession" runat="server" />
    </div>
    <div class="backtoresults">
        <asp:PlaceHolder ID="phBackToResult" runat="server"><a href="/advancedsearch.aspx?search=1&retainsearch=1">
            <JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LinkButtonBackToResult" />
        </a></asp:PlaceHolder>
    </div>
</div>
<asp:Literal ID="litJobPreview" runat="server" />
<asp:PlaceHolder ID="phExpiredJob" runat="server" Visible="false">
<link rel="stylesheet" href="//images.jxt.net.au/jxt/MASTER/expired-jobs.css" />
</asp:PlaceHolder>