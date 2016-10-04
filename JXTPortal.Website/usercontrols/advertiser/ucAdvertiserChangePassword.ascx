<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertiserChangePassword.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucAdvertiserChangePassword" %>
<div class="form-header-group">
    <h2 class="form-header">
        <asp:Literal ID="ltlChangePwd" runat="server" Text="Change Password"></asp:Literal></h2>
</div>
<div class="form-all">
    <span class="form-required">
        <asp:Literal ID="litMessage" runat="server" /></span>
    <ul class="form-section">
        <li class="form-line" id="cp-currentpassword-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucCurrentPassword" runat="server" SetLanguageCode="LabelCurrentPassword" />
                <span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="tbCurrentPassword" runat="server" CssClass="form-textbox" TextMode="Password"
                    autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqVal_CurrentPassword" runat="server" ErrorMessage="Required"
                    ControlToValidate="tbCurrentPassword" ValidationGroup="ChangePassword" SetFocusOnError="true"
                    Display="Dynamic" />
                <asp:CustomValidator ID="CusVal_CurrentPassword" runat="server" ErrorMessage="Incorrect current password"
                    OnServerValidate="CusVal_CurrentPassword_ServerValidate" ValidationGroup="ChangePassword"
                    SetFocusOnError="true" Display="Dynamic" />
            </div>
        </li>
        <li class="form-line" id="cp-newpassword-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucNewPassword" runat="server" SetLanguageCode="LabelNewPassword" />
                <span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="tbNewPassword" runat="server" TextMode="Password" CssClass="form-textbox"
                    autocomplete="off" ClientIDMode="Static"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqVal_NewPassword" runat="server" ErrorMessage="Required"
                    ControlToValidate="tbNewPassword" ValidationGroup="ChangePassword" SetFocusOnError="true"
                    Display="Dynamic" />
                <p class="help-block">
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="* "
                        ValidationGroup="ChangePassword" Display="Dynamic" ControlToValidate="tbNewPassword"
                        ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral
                            ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" />
                </p>
            </div>
        </li>
        <li class="form-line" id="cp-confirmnewpassword-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucConfirmNewPassword" runat="server" SetLanguageCode="LabelConfirmNewPassword" />
                <span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="tbConfirmNewPassword" runat="server" TextMode="Password" CssClass="form-textbox"
                    autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqVal_ConfirmNewPassword" runat="server" ErrorMessage="Required"
                    ControlToValidate="tbConfirmNewPassword" ValidationGroup="ChangePassword" SetFocusOnError="true"
                    Display="Dynamic" />
                <asp:CustomValidator ID="CusVal_ConfirmNewPassword" runat="server" ErrorMessage="Confirm password doesn not match"
                    OnServerValidate="CusVal_ConfirmNewPassword_ServerValidate" ValidationGroup="ChangePassword"
                    SetFocusOnError="true" Display="Dynamic" />
            </div>
        </li>
        <li class="form-line" id="cp-bottom-button">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="mini-new-buttons" OnClick="btnSave_Click"
                        ValidationGroup="ChangePassword" />
                </div>
            </div>
        </li>
    </ul>
</div>
