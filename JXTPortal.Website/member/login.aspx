<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="JXTPortal.Website.members.login" %>

<%@ Register Src="~/usercontrols/member/ucMemberSocialLogin.ascx" TagName="ucMemberSocialLogin"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#content input').keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#btnLogin').click();

                    event.preventDefault();
                    return false;
                }
            });
        });
    </script>
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_MemberLogin" />
            <div class="login-main-holder">
                <div id="socialLoginWrapper">
                    <uc1:ucMemberSocialLogin ID="ucMemberSocialLogin1" runat="server" />
                </div>
                <div class="form-all">
                    <ul class="form-section">
                        <li class="form-required" id="memberlogin-errorMessage">
                            <p>
                                <asp:Literal ID="ltErrorMessage" runat="server" /></p>
                        </li>
                        <li class="form-line">
                            <label class="form-label-left" for="ctl00_ContentPlaceHolder1_txtUserName">
                                <JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LabelUsername" />
                                <span class="form-required">*</span>
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-textbox" />
                            </div>
                        </li>
                        <li class="form-line">
                            <label class="form-label-left" for="ctl00_ContentPlaceHolder1_txtPassword">
                                <JXTControl:ucLanguageLiteral ID="ltPassword" runat="server" SetLanguageCode="LabelPassword" />
                                <span class="form-required">*</span>
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-textbox"
                                    AutoCompleteType="None" autocomplete="off" />
                            </div>
                        </li>
                        <li class="memberlogin-links">
                            <asp:PlaceHolder ID="phMemberRegisterLink" runat="server"><a class="memberlogin-register"
                                href="/member/register.aspx">
                                <JXTControl:ucLanguageLiteral ID="ltRegister" runat="server" SetLanguageCode="LabelRegister" />
                            </a>&nbsp;<span>|</span> </asp:PlaceHolder>
                            <a class="memberlogin-forgetpassword" href="/member/forgetpassword.aspx">
                                <JXTControl:ucLanguageLiteral ID="ltForgottenPassword" runat="server" SetLanguageCode="LabelForgottenPassword" />
                            </a></li>
                    </ul>
                </div>
                <div class="member-submitbottom">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="mini-new-buttons"
                        ClientIDMode="Static" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
