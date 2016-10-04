<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberChangePassword.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.member.ucMemberChangePassword" %>
<div class="form-header-group">
    <h1 class="form-header">
        <JXTControl:ucLanguageLiteral ID="lblMemberHeaderChangePassword" runat="server" SetLanguageCode="LabelChangePwd" />
    </h1>
</div>
<p>
    <JXTControl:ucLanguageLiteral ID="litucMemberEditPasswordWelcome" runat="server"
        SetLanguageCode="LabelWelcomeMemberEditPassword" />
</p>
<div class="form-all">
    <asp:Label ID="lblMessage" runat="server" CssClass="form-required">
        <asp:Literal ID="litMessage" runat="server" /></asp:Label><ul class="form-section">
            <li class="form-line" id="ucMember-currentpassword-field">
                <asp:Label ID="lbCurrentPassword" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberCurrentPassword">
                    <JXTControl:ucLanguageLiteral ID="litucMemberCurrentPassword" runat="server" SetLanguageCode="LabelCurrentPassword" />
                    <span class="form-required">*</span> </asp:Label><div class="form-input">
                        <asp:TextBox ID="txtMemberCurrentPassword" runat="server" CssClass="form-textbox2"
                            TextMode="Password" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator
                                ID="ReqVal_CurrentPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtMemberCurrentPassword"
                                ValidationGroup="GroupMemberPasswordValidation" SetFocusOnError="true" Display="Dynamic" />
                        <asp:CustomValidator ID="CusVal_CurrentPassword" runat="server" ErrorMessage="Incorrect current password"
                            OnServerValidate="CusVal_CurrentPassword_ServerValidate" ValidationGroup="GroupMemberPasswordValidation"
                            SetFocusOnError="true" Display="Dynamic" />
                    </div>
            </li>
            <li class="form-line" id="ucMember-newpassword-field">
                <asp:Label ID="lbNewPassword" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberNewPassword">
                    <JXTControl:ucLanguageLiteral ID="litucMemberNewPassword" runat="server" SetLanguageCode="LabelNewPassword" />
                    <span class="form-required">*</span> </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="txtMemberNewPassword" runat="server" TextMode="Password" CssClass="form-textbox2"
                        autocomplete="off" ClientIDMode="Static"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_NewPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtMemberNewPassword"
                            ValidationGroup="GroupMemberPasswordValidation" SetFocusOnError="true" Display="Dynamic" />
                    <p class="help-block">
                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="* "
                            Display="Dynamic" ValidationGroup="GroupMemberPasswordValidation" ControlToValidate="txtMemberNewPassword"
                            ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral
                                ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" />
                    </p>
                </div>
            </li>
            <li class="form-line" id="ucMember-confirmnewpassword-field">
                <asp:Label ID="lbConfirmNewPassword" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberConfirmNewPassword">
                    <JXTControl:ucLanguageLiteral ID="litucMemberConfirmNewPassword" runat="server" SetLanguageCode="LabelConfirmNewPassword" />
                    <span class="form-required">*</span> </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="txtMemberConfirmNewPassword" runat="server" TextMode="Password"
                        CssClass="form-textbox2" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_ConfirmNewPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtMemberConfirmNewPassword"
                            ValidationGroup="GroupMemberPasswordValidation" SetFocusOnError="true" Display="Dynamic" />
                    <asp:CustomValidator ID="CusVal_ConfirmNewPassword" runat="server" ErrorMessage="Confirm password doesn not match"
                        OnServerValidate="CusVal_ConfirmNewPassword_ServerValidate" ValidationGroup="GroupMemberPasswordValidation"
                        SetFocusOnError="true" Display="Dynamic" />
                </div>
            </li>
            <li class="form-line" id="cp-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="mini-new-buttons" OnClick="btnSave_Click"
                            ValidationGroup="GroupMemberPasswordValidation" />
                    </div>
                </div>
            </li>
        </ul>
</div>
