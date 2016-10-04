<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="JXTPortal.Website.advertiser.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-container">
        <div id="content">
            <div class="content-holder">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserLogin" />

                <div class="jxt-form jxt-form-advertiser-login">
                    <section class="jxt-form-section jxt-form-section-advertiser-login">
		<h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelPleaseLogin" /></h2>
        <p class="form-required"><JXTControl:ucLanguageLiteral ID="ltLoginError" runat="server" /></p>
		<fieldset class="jxt-form-fieldset jxt-form-fieldset-login-information">
			<legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelLoginInformation" /></legend>
			<div class="jxt-form-group jxt-form-username">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_txtUserName"><JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LabelUsername" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="txtUserName" runat="server" />
                    <asp:PlaceHolder ID="phLoginError" runat="server" Visible="false"><span class="jxt-error"><JXTControl:ucLanguageLiteral ID="ucLoginError" runat="server" SetLanguageCode="LabelAccessDenied" /></span></asp:PlaceHolder>
                    <asp:RequiredFieldValidator ID="rvUserName" runat="server" ControlToValidate="txtUserName" CssClass="jxt-error" Display="Dynamic" /> 
				</div>
			</div>
			<div class="jxt-form-group jxt-form-password">
				<div class="jxt-form-label">
					<label for="ctl00_ContentPlaceHolder1_txtPassword"><JXTControl:ucLanguageLiteral ID="ltPassword" runat="server" SetLanguageCode="LabelPassword" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" AutoCompleteType="None" autocomplete="off" />
                    <asp:PlaceHolder ID="phPasswordChanged" runat="server" Visible="false"><asp:Literal ID="ltErrorMessage" runat="server" /></asp:PlaceHolder>
                    <asp:RequiredFieldValidator ID="rvPassword" runat="server" ControlToValidate="txtPassword" CssClass="jxt-error" Display="Dynamic" /> 
				</div>
			</div>
			<div class="jxt-form-group jxt-form-remember-me">
				<div class="jxt-form-combined">
					<label for="ctl00_ContentPlaceHolder1_cbRememberMe"><input id="cbRememberMe" type="checkbox" runat="server" /><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelRememberMe" /></label> 
					<div class="jxt-form-information jxt-form-forgot-password">
						<a href="/advertiser/forgetpassword.aspx"><JXTControl:ucLanguageLiteral ID="ltForgottenPassword" runat="server" SetLanguageCode="LabelForgotPassword" /></a>
					</div>
				</div>
			</div>
		</fieldset>
		<div class="jxt-form-submit">
			<div class="jxt-form-button">
                <asp:LinkButton ID="btnLogin" runat="server" Text="Login" CssClass="mini-new-buttons"
                        OnClick="btnLogin_Click" />
			</div>
		</div>
	</section>
                    <section class="jxt-form-section">
		<h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelRegisterToday" /></h2>
		<p><a href="register.aspx" class="mini-new-buttons"><JXTControl:ucLanguageLiteral ID="ltRegister" runat="server" SetLanguageCode="LabelRegister" /></a></p>
	</section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
