<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="ResendEmailValidation.aspx.cs" Inherits="JXTPortal.Website.advertiser.ResendEmailValidation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelHaventReceivedWelcomeEmail" /></h1>
    <div class="jxt-form jxt-form-advertiser-resend-welcome-email">
        <section class="jxt-form-section jxt-form-section-resend-email">
		<h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelResendEmail" /></h2>
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
		<fieldset class="jxt-form-fieldset jxt-form-fieldset-email-details">
			<legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelEmailDetails" /></legend>
			<div class="jxt-form-group jxt-form-email">
				<div class="jxt-form-label">
					<label for=""><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelEmail" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
                    <asp:TextBox ID="tbEmailAddress"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_UserName" runat="server" ControlToValidate="tbEmailAddress"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="tbEmailAddress"
                            SetFocusOnError="true" Display="Dynamic" ErrorMessage="Invalid email address"
                            ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$">  
                        </asp:RegularExpressionValidator>
				</div>
			</div>
			<%--<div class="jxt-form-group jxt-form-captcha">
				<div class="jxt-form-label">
					<label for=""><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelCaptcha" />&nbsp;<span class="form-required">*</span></label>
				</div>
				<div class="jxt-form-field">
					<input type="text">
				</div>
			</div>--%>
		</fieldset>
		<div class="jxt-form-submit">
			<div class="jxt-form-button">
                <asp:Button ID="btnResendButton" runat="server" CssClass="mini-new-buttons" Text="Resend" OnClick="btnRegister_Click"/>
			</div>
		</div>
	</section>
        <section class="jxt-form-section">
		<h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelStillHavingIssue" /></h2>
		<p><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelPleaseContactSupport" /></p>
	</section>
    </div>
</asp:Content>
