<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberSocialLogin.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.member.ucMemberSocialLogin" %>
<asp:PlaceHolder ID="phSocialMedia" runat="server">
    <div class="boardyLoginWithSocial">
        <h3>
            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelLoginWithSocialMedia" />
        </h3>
        <asp:LinkButton ID="lbSignInFacebook" CssClass="boardyLoginSocialButton" runat="server" CausesValidation="false"
            OnClick="lbSignInFacebook_Click" Visible="false">
                        <img src="//images.jxt.net.au/COMMON/images/apply/sign-in-facebook.svg" alt="sign in facebook"
                            class="img-responsive" /></asp:LinkButton>
        <asp:LinkButton ID="lbSignInLinkedIn" CssClass="boardyLoginSocialButton" runat="server" CausesValidation="false"
            OnClick="lbSignInLinkedIn_Click" Visible="false"><img
                                src="//images.jxt.net.au/COMMON/images/apply/sign-in-linkedin.svg" alt="sign in linkedin"
                                class="img-responsive" /></asp:LinkButton>
        <asp:LinkButton ID="lbSignInGoogle" CssClass="boardyLoginSocialButton" runat="server" CausesValidation="false"
            OnClick="lbSignInGoogle_Click" Visible="false"><img src="//images.jxt.net.au/COMMON/images/apply/sign-in-google.svg"
                                    alt="sign in google" class="img-responsive" /></asp:LinkButton>
        <div class="clearfix">
        </div>
    </div>
</asp:PlaceHolder>
