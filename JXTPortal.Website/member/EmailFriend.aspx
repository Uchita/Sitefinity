<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="EmailFriend.aspx.cs" Inherits="JXTPortal.Website.member.EmailFriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <%-- Google reCaptcha --%>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_EmailFriend" />
            <%--<div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditHeaderMyaccount" runat="server" SetLanguageCode="LabelEmailFriend" />
                </h2>
            </div>--%>
            <div class="form-all">
                <asp:Panel ID="pnlSend" runat="server">
                    <ul class="form-section">
                        <li class="form-line" id="ef-jobtitle-field">
                            <asp:Label ID="lbJobTitle" runat="server" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                            </asp:Label>
                            <div class="form-input">
                                <asp:Literal ID="litJobTitle" runat="server" />
                                <asp:HiddenField ID="hfBackUrl" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="ef-yourname-field">
                            <asp:Label ID="lbYourName" runat="server" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltYourName" runat="server" SetLanguageCode="LabelYourName" />
                                <span class="form-required">*</span></asp:Label>
                            <div class="form-input">
                                <asp:TextBox ID="tbYourName" runat="server" CssClass="form-textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvYourName" runat="server" ControlToValidate="tbYourName"
                                    SetFocusOnError="true" Display="Dynamic" />
                            </div>
                        </li>
                        <li id="ef-youremail-field">
                            <asp:Label ID="lbYourEmail" runat="server" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltYourEmail" runat="server" SetLanguageCode="LabelYourEmail" />
                                <span class="form-required">*</span></asp:Label>
                            <div class="form-input">
                                <asp:TextBox ID="tbYourEmail" runat="server" CssClass="form-textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvYourEmail" runat="server" ControlToValidate="tbYourEmail"
                                    SetFocusOnError="true" Display="Dynamic" />
                                <asp:CustomValidator ID="cvYourEmail" runat="server" ControlToValidate="tbYourEmail"
                                    SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvYourEmail_ServerValidate" />
                            </div>
                        </li>
                    </ul>
                    <div class="clearfix">
                    </div>
                    <asp:UpdatePanel ID="updatePanel" runat="server">
                        <ContentTemplate>
                            <ul class="form-section">
                                <li class="form-line" id="Li1">
                                    <asp:Label ID="Label1" runat="server" CssClass="form-label-left">
                                &nbsp;</asp:Label>
                                    <div class="form-input">
                                        <asp:CheckBox ID="cbEmailJobToAFriend" runat="server" CssClass="form-checkbox" AutoPostBack="true"
                                            OnCheckedChanged="cbEmailJobToAFriend_CheckedChanged" />
                                    </div>
                                </li>
                                <asp:PlaceHolder ID="phEmailFriend" runat="server" Visible="false">
                                    <li class="form-line" id="ef-yourfriendname-field">
                                        <asp:Label ID="lbYourFriendName" runat="server" CssClass="form-label-left">
                                            <JXTControl:ucLanguageLiteral ID="ltYourFriendName" runat="server" SetLanguageCode="LabelYourFriendName" />
                                            <span class="form-required">*</span></asp:Label>
                                        <div class="form-input">
                                            <asp:TextBox ID="tbYourFriendName" runat="server" CssClass="form-textbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvYourFriendName" runat="server" ControlToValidate="tbYourFriendName"
                                                SetFocusOnError="true" Display="Dynamic" />
                                        </div>
                                    </li>
                                    <li class="form-line" id="ef-yourfriendemail-field">
                                        <asp:Label ID="lbYourFriendEmail" runat="server" CssClass="form-label-left">
                                            <JXTControl:ucLanguageLiteral ID="ltYourFriendEmail" runat="server" SetLanguageCode="LabelYourFriendEmail" />
                                            <span class="form-required">*</span></asp:Label>
                                        <div class="form-input">
                                            <asp:TextBox ID="tbYourFriendEmail" runat="server" CssClass="form-textbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvYourFriendEmail" runat="server" ControlToValidate="tbYourFriendEmail"
                                                SetFocusOnError="true" Display="Dynamic" />
                                            <asp:CustomValidator ID="cvYourFriendEmail" runat="server" ControlToValidate="tbYourFriendEmail"
                                                SetFocusOnError="true" Display="Dynamic" OnServerValidate="cvYourFriendEmail_ServerValidate" />
                                        </div>
                                    </li>
                                    <li class="form-line" id="ef-messageforyourfriend-field">
                                        <asp:Label ID="lbMessageForYouFriend" runat="server" CssClass="form-label-left">
                                            <JXTControl:ucLanguageLiteral ID="ltMessageForYourFriend" runat="server" SetLanguageCode="LabelMessageForYourFriend" />
                                        </asp:Label>
                                        <div class="form-input">
                                            <asp:TextBox ID="tbMessageForYourFriend" runat="server" CssClass="form-textbox" TextMode="MultiLine"
                                                Rows="5"></asp:TextBox>
                                        </div>
                                    </li>
                                </asp:PlaceHolder>
                            </ul>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <ul  class="form-section">
                        <li class="form-line">
                            <asp:Label ID="Label2" runat="server" CssClass="form-label-left">
                                       &nbsp;
                            </asp:Label>
                            <div class="form-input">
                                <asp:Panel runat="server" ID="plGooleReCaptcha" Visible="true" CssClass="g-recaptcha">
                                </asp:Panel>
                                <span runat="server" id="captchaReqMsg" visible="false" style="color: red; display: inline;">
                                    <JXTControl:ucLanguageLiteral ID="ltCaptchaRequired" runat="server" SetLanguageCode="LabelCaptchaRequired" />
                                </span>
                            </div>
                        </li>
                    </ul>
                </asp:Panel>
                <ul class="form-section">
                    <li class="form-line" id="ef-bottom-button">
                        <div class="form-input-wide">
                            <asp:Literal ID="litMessage" runat="server" />
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="mini-new-buttons" CausesValidation="false"
                                    OnClick="btnBack_Click" />
                                <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="mini-new-buttons" OnClick="btnSend_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
