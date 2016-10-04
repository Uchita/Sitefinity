<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucContactDetails.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucContactDetails" %>
<div class="ctrlHolder">
    <asp:RadioButtonList ID="rbOptions" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
        CssClass="blockLabels" RepeatLayout="UnorderedList" OnSelectedIndexChanged="rbOptions_SelectedIndexChanged">
    </asp:RadioButtonList>
</div>
<asp:Panel ID="pnlContactDetails" runat="server">
    <h3>
        <JXTControl:ucLanguageLiteral ID="ltUcContactDetails" runat="server" SetLanguageCode="LabelContactDetails" />
    </h3>
    <div class="ctrlHolder">
        <label class="form-label-left">
            <JXTControl:ucLanguageLiteral ID="ucContactFirstName" runat="server" SetLanguageCode="LabelFirstName" />
            :<span class="form-required">*</span></label>
        <asp:TextBox ID="tbFirstName" runat="server" size="35" class="textInput" />
        <p class="formHint">
            <asp:RequiredFieldValidator ID="ReqVal_FirstName" runat="server" ControlToValidate="tbFirstName"
                SetFocusOnError="true" Display="Dynamic" ValidationGroup="ValidationApplyJob" /></p>
    </div>
    <div class="ctrlHolder">
        <label class="form-label-left">
            <JXTControl:ucLanguageLiteral ID="ucContactSurname" runat="server" SetLanguageCode="LabelSurname" />
            :<span class="form-required">*</span></label>
        <asp:TextBox ID="tbSurname" runat="server" size="35" class="textInput" />
        <p class="formHint">
            <asp:RequiredFieldValidator ID="ReqVal_Surname" runat="server" ControlToValidate="tbSurname"
                SetFocusOnError="true" Display="Dynamic" ValidationGroup="ValidationApplyJob" /></p>
    </div>
    <div class="ctrlHolder">
        <label class="form-label-left">
            <JXTControl:ucLanguageLiteral ID="ltUcContactPhone" runat="server" SetLanguageCode="LabelPhone" />
            :<span class="form-required">*</span></label>
        <asp:TextBox ID="tbPhone" runat="server" size="35" class="textInput" MaxLength="40" />
        <p class="formHint">
            <asp:RequiredFieldValidator ID="ReqVal_Phone" runat="server" ControlToValidate="tbPhone"
                SetFocusOnError="true" Display="Dynamic" ValidationGroup="ValidationApplyJob" />
            <asp:CustomValidator ID="CusVal_Phone" runat="server" ControlToValidate="tbPhone"
                SetFocusOnError="true" Display="Dynamic" 
                onservervalidate="CusVal_Phone_ServerValidate" />
        </p>
    </div>
    <div class="ctrlHolder">
        <label class="form-label-left">
            <JXTControl:ucLanguageLiteral ID="ltUcContactEmailAddress" runat="server" SetLanguageCode="LabelEmailAddress" />
            :<span class="form-required">*</span></label>
        <asp:TextBox ID="tbEmail" runat="server" size="35" class="textInput" />
        <p class="formHint">
            <asp:RequiredFieldValidator ID="ReqVal_Email" runat="server" ControlToValidate="tbEmail"
                SetFocusOnError="true" Display="Dynamic" ValidationGroup="ValidationApplyJob" />
            <asp:CustomValidator ID="CusVal_Email" runat="server" ControlToValidate="tbEmail"
                OnServerValidate="CusVal_Email_ServerValidate" SetFocusOnError="true" Display="Dynamic" />
            <asp:Literal ID="litMessage" runat="server" /></p>
    </div>
</asp:Panel>
<asp:Panel ID="pnlLogin" runat="server" Visible="false">
    <h3>
        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelLogin" />
    </h3>
    <div class="ctrlHolder">
        <label class="form-label-left">
            <JXTControl:ucLanguageLiteral ID="ltUsername" runat="server" SetLanguageCode="LabelUsername" />
            :<span class="form-required">*</span></label>
        <asp:TextBox ID="txtUserName" runat="server" size="35" class="textInput" />
    </div>
    <div class="ctrlHolder">
        <label class="form-label-left">
            <JXTControl:ucLanguageLiteral ID="ltPassword" runat="server" SetLanguageCode="LabelPassword" />
            :<span class="form-required">*</span></label>
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" size="35" class="textInput" />
    </div>
    <div class="ctrlHolder apply-login-links">
        <label class="form-label-left">
            <a href="/member/register.aspx">
                <JXTControl:ucLanguageLiteral ID="ltRegister" runat="server" SetLanguageCode="LabelRegister" />
            </a>| <a href="/member/ForgetPassword.aspx">
                <JXTControl:ucLanguageLiteral ID="ltForgottenPassword" runat="server" SetLanguageCode="LabelForgottenPassword" />
            </a>
        </label>
    </div>
    <div class="ctrlHolder">
        <p class="formHint">
            <span id="spErrorMessage" style="color: Red;">
                <asp:Literal ID="ltErrorMessage" runat="server" /></span></p>
    </div>
    <div class="ctrlHolder">
        <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="OptionLogin"
            OnClick="btnLogin_Click" CssClass="mini-new-buttons" />
    </div>
</asp:Panel>
