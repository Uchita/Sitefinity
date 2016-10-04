<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendTestEmail.aspx.cs"
    Inherits="JXTPortal.Website.Admin.SendTestEmail" MasterPageFile="~/MasterPages/admin.master"
    Title="Global - Send Test Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Send Test Email
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="email-field">
                <label class="form-label-left">
                    Email Address:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="tbEmailAddress" runat="server" />
                    <asp:RequiredFieldValidator ID="ReqVal_EmailAddress" runat="server" ErrorMessage="Required"
                        Display="Dynamic" InitialValue="" ControlToValidate="tbEmailAddress" />
                    <asp:CustomValidator ID="CusVal_EmailAddress" runat="server" ErrorMessage="Invalid Email Address"
                        ControlToValidate="tbEmailAddress" Display="Dynamic" OnServerValidate="CusVal_EmailAddress_ServerValidate" />
                </div>
            </li>
            <li class="form-line" id="Li2"><label class="form-label-left">Subject:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="tbSubject" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                        Display="Dynamic" InitialValue="" ControlToValidate="tbSubject" />
                </div>
            </li>
            <li class="form-line" id="Li3"><label class="form-label-left">Body:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="tbBody" runat="server" TextMode="MultiLine" Columns="80" Rows="25"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                        Display="Dynamic" InitialValue="" ControlToValidate="tbBody" />
                </div>
            </li>
            <li class="form-line" id="Li1"><label class="form-label-left">Email Format:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:CheckBox ID="cbHTML" runat="server" Text=" Is HTML Email" Checked="true" />                    
                </div>
            </li>
            <li class="form-line" id="Li4"><label class="form-label-left">Bounce / rejection errors to:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="tbBounceBackEmail" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                        Display="Dynamic" InitialValue="" ControlToValidate="tbBounceBackEmail" />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Invalid Email Address"
                        ControlToValidate="tbBounceBackEmail" Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate" />
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSend" runat="server" CausesValidation="True" Text="Send" CssClass="jxtadminbutton"
                            OnClick="btnSend_Click" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
