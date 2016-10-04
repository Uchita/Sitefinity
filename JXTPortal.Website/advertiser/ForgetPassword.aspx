<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="JXTPortal.Website.advertiser.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltForgetPassword" runat="server" SetLanguageCode="LabelForgetPassword" />
                </h2>
            </div>
            <div class="form-all">
                <ul class="form-section">
                    <li class="form-line" id="fp-username-field">
                        <asp:Label ID="lbAccountType" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LabelUsername" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="tbUserName" runat="server" CssClass="form-textbox"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="fp-or-field">
                        <asp:Label ID="lbOr" runat="server" CssClass="form-label-left"> </asp:Label>
                        <div class="form-input">
                            <strong>-&nbsp;<JXTControl:ucLanguageLiteral ID="ltOr" runat="server" SetLanguageCode="LabelOr" />
                                &nbsp;-</strong>
                        </div>
                    </li>
                    <li class="form-line" id="fp-email-field">
                        <asp:Label ID="lbEmail" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltEmail" runat="server" SetLanguageCode="LabelEmail" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-textbox"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="fp-message-field">
                        <asp:Label ID="Label1" runat="server" CssClass="form-label-left">
                        &nbsp;</asp:Label>
                        <div class="form-input">
                            <span class="form-required">
                                <asp:Literal ID="litMessage" runat="server" />
                            </span>
                        </div>
                    </li>
                </ul>
                <ul class="form-section">
                    <li class="form-line" id="fg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnRetrieve" runat="server" Text="Reset" CssClass="mini-new-buttons"
                                    OnClick="btnRetrieve_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
