<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="JXTPortal.Website.member.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#content-container input').keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#ctl00_ContentPlaceHolder1_btnRetrieve').click();

                    event.preventDefault();
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <div class="form-header-group">
                <h1 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltForgetPassword" runat="server" SetLanguageCode="LabelForgetPassword" />
                </h1>
            </div>
            <p><JXTControl:ucLanguageLiteral ID="ltForgetPasswordInfo" runat="server" SetLanguageCode="LabelResetPasswordInfo" /></p>
            <div class="form-all">
                <ul class="form-section">
                    <li class="form-line" id="member-fp-username-field">
                        <asp:Label ID="lblUsername" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LabelUsername" />
                            </asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-textbox"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="member-fp-or-field">
                        <asp:Label ID="lblOr" runat="server" CssClass="form-label-left"> </asp:Label>
                        <div class="form-input">
                            <strong>-&nbsp;<JXTControl:ucLanguageLiteral ID="ltOr" runat="server" SetLanguageCode="LabelOr" />
                                &nbsp;-</strong>
                        </div>
                    </li>
                    <li class="form-line" id="member-fp-email-field">
                        <asp:Label ID="lblEmail" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltEmail" runat="server" SetLanguageCode="LabelEmail" />
                            </asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-textbox"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="member-fp-message-field">
                        <asp:Label ID="lblMessage" runat="server" CssClass="form-label-left">&nbsp;</asp:Label>
                        <div class="form-input">
                            <span class="form-required">
                                <asp:Literal ID="ltMessage" runat="server" />
                            </span>
                        </div>
                    </li>
                </ul>
                
                <ul class="form-section">
                    <li class="form-line" id="member-fp-bottom-button">
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
