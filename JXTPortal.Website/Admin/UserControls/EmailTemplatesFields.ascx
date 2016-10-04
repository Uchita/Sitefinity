<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplatesFields.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.EmailTemplatesFields" %>
<div class="form-all">
    <span class="form-message">
        <asp:Literal ID="ltlMessage" runat="server" /></span>
    <ul class="form-section">
        <li class="form-line" id="emt-generalsettings-field">
            <label class="form-label-left">
                <strong>General Settings</strong></label>
            <div class="form-input">
            </div>
        </li>
        <li class="form-line" id="emt-parentemailtemplate-field">
            <label class="form-label-left">
                Parent Email Template:</label>
            <div class="form-input">
                <asp:DropDownList ID="ddlParentEmailTemplate" runat="server" CssClass="form-multiple-column" />
            </div>
        </li>
        <li class="form-line" id="emt-emailcode-field">
            <label class="form-label-left">
                Email Code:<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailCode" Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="ReqVal_dataEmailCode" runat="server" Display="Dynamic" ControlToValidate="txtEmailCode"
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>
        </li>
        <li class="form-line" id="emt-emaildescription-field">
            <label class="form-label-left">
                Email Description:<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="txtEmailDescription"
                    Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmailDescription"
                        runat="server" Display="Dynamic" ControlToValidate="txtEmailDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>
        </li>
        <li class="form-line" id="emt-emailsubject-field">
            <label class="form-label-left">
                Email Subject:<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailSubject" Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="ReqVal_dataEmailSubject" runat="server" Display="Dynamic" ControlToValidate="txtEmailSubject"
                    ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>
        </li>
        <li class="form-line" id="emt-emailbodytext-field">
            <label class="form-label-left">
                Email Body Text:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailBodyText" Width="250px" TextMode="MultiLine"
                    Rows="5"></asp:TextBox>
            </div>
        </li>
        <li class="form-line" id="emt-emailhtmltext-field">
            <label class="form-label-left">
                Email Body HTML:</label>
            <div class="form-input">
                <FredCK:CKEditorControl ID="txtEmailBodyHTML" runat="server" Width="650px" Height="400px" CustomConfig ="custom_config.js" 
                    Toolbar="FullToolbar" EnableViewState="false">
                </FredCK:CKEditorControl>
            </div>
        </li>
        <li class="form-line" id="emt-emailfields-field">
            <label class="form-label-left">
                Email Fields:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailFields" TextMode="MultiLine" Width="250px"
                    Rows="5"></asp:TextBox>
            </div>
        </li>
        <li class="form-line" id="emt-globaltemplate-field">
            <label class="form-label-left">
                Global Template:</label>
            <div class="form-input">
                <asp:CheckBox ID="rbGlobalTemplate" runat="server" />
            </div>
        </li>
        <li class="form-line" id="emt-contactsettings-field">
            <label class="form-label-left">
                <strong>Contact Settings</strong></label>
            <div class="form-input">
            </div>
        </li>
        
        <li class="form-line" id="emt-emailaddressname-field">
            <label class="form-label-left">
                Email Address Name:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailAddressName" Width="250px"></asp:TextBox>
            </div>
        </li>
        <li class="form-line" id="emt-emailaddressfrom-field">
            <label class="form-label-left">
                Email Address From:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailAddressFrom" Width="250px"></asp:TextBox>
            </div>
        </li>
        <li class="form-line" id="emt-emailaddresscc-field">
            <label class="form-label-left">
                Email Address CC:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailAddressCC" Width="250px"></asp:TextBox>
            </div>
        </li>
        <li class="form-line" id="emt-emailaddressbcc-field">
            <label class="form-label-left">
                Email Address BCC:</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="txtEmailAddressBCC" Width="250px"></asp:TextBox>
            </div>
        </li>
        
        <li class="form-line" id="emt-lastmodified-field">
            <label class="form-label-left">
                Last Modified:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="lblLastModified" MaxLength="10"></asp:Label>
            </div>
        </li>
        <li class="form-line" id="emt-lastmodifiedby-field">
            <label class="form-label-left">
                Last Modified By:</label>
            <div class="form-input">
                <asp:Label ID="lblLastModifiedBy" runat="server" />
            </div>
        </li>
        <li class="form-line" id="emt-bottom-button">
            <div class="form-input-wide">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                    CssClass="jxtadminbutton" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="jxtadminbutton" />
            </div>
        </li>
    </ul>
</div>
