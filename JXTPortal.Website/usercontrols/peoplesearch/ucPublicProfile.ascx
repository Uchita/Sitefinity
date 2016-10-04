<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPublicProfile.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.peoplesearch.ucPublicProfile" %>
<div class="form-all">
    <div class="form-header-group">
        <h2 class="form-header">
            <asp:Literal ID="litMemberName" runat="server" /><JXTControl:ucLanguageLiteral ID="ltsPublicProfile"
                runat="server" SetLanguageCode="sLabelPublicProfile" />
        </h2>
    </div>
    <div class="search-sequence">
        <ul class="form-section">
            <li class="form-line" id="pp-name-field">
                <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltName" runat="server" SetLanguageCode="LabelName" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litName" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-email-field">
                <asp:Label ID="lbEmail" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltEmail" runat="server" SetLanguageCode="LabelEmail" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litEmail" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-status-field">
                <asp:Label ID="lbStatus" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltStatus" runat="server" SetLanguageCode="LabelStatus" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litStatus" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-publicprofile-field">
                <asp:Label ID="lbPublicProfile" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltPublicProfile" runat="server" SetLanguageCode="LabelPublicProfile" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litPublicProfile" runat="server" />
                </div>
            </li>
        </ul>
    </div>
</div>
