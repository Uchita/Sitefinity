<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertiserPublicProfile.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucAdvertiserPublicProfile" %>
<div class="form-header-group">
    <h2 class="form-header">
        <asp:Literal ID="litCompanyName" runat="server" />
    </h2>
</div>
<div class="form-all">    
    <div class="search-sequence">
        <br />
        <asp:Image ID="imgAdvertiserLogo" runat="server" /><br />
        <p>
            <asp:Literal ID="litProfile" runat="server" />
        </p>
        <ul class="form-section">
            <li class="form-line" id="pp-name-field">
                <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltName" runat="server" SetLanguageCode="LabelWebAddress" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:HyperLink ID="hlWebAddress" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-email-field">
                <asp:Label ID="lbBusinessType" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltBusinessType" runat="server" SetLanguageCode="LabelBusinessType" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litBusinessType" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-status-field">
                <asp:Label ID="lbNoOfEmployees" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltNoOfEmployees" runat="server" SetLanguageCode="LabelNoOfEmployees" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litNoOfEmployees" runat="server" />
                </div>
            </li>
        </ul>
    </div>
</div>