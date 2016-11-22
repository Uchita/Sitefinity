<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMemberEdit.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.member.ucMemberEdit" %>
<div class="form-header-group">
    <h1 class="form-header">
        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelUpdateMyDetails" />
    </h1>
</div>
<p>
    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelWelcomeMemberEditDetail" />
</p>
<div class="form-all">
    <asp:Literal ID="ltlMessage" runat="server" />
    <ul class="form-section">
        <li class="form-line" id="ucmemberedit-title">
            <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left" AssociatedControlID="ddlTitle">
                <JXTControl:ucLanguageLiteral ID="ucTitle" runat="server" SetLanguageCode="LabelTitle" />
                <span class="form-required">*</span> </asp:Label>
            <div class="form-input">
                <asp:DropDownList ID="ddlTitle" TabIndex="8" runat="server" class="form-dropdown">
                    <asp:ListItem Value="Mr">Mr</asp:ListItem>
                    <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                    <asp:ListItem Value="Ms">Ms</asp:ListItem>
                    <asp:ListItem Value="Miss">Miss</asp:ListItem>
                    <asp:ListItem Value="Dr">Dr</asp:ListItem>
                    <asp:ListItem Value="Professor">Professor</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-first-name">
            <asp:Label ID="lbFirstName" runat="server" CssClass="form-label-left" AssociatedControlID="txtFirstName">
                <JXTControl:ucLanguageLiteral ID="ucFirstName" runat="server" SetLanguageCode="LabelFirstName" />
                <span class="form-required">*</span> </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-textbox2" />
                <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="txtFirstname"
                    ValidationGroup="MemberEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-surname">
            <asp:Label ID="lbSurname" runat="server" CssClass="form-label-left" AssociatedControlID="txtSurname">
                <JXTControl:ucLanguageLiteral ID="ucSurname" runat="server" SetLanguageCode="LabelSurname" />
                <span class="form-required">*</span> </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-textbox2" />
                <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ControlToValidate="txtSurname"
                    ValidationGroup="MemberEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-multilingual-firstname">
            <asp:Label ID="lbLocalFirstName" runat="server" CssClass="form-label-left" AssociatedControlID="txtMultilingualFirstName">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelFirstName" />
                &nbsp;(<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelLocalLanguage" />
                ) </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtMultilingualFirstName" runat="server" CssClass="form-textbox2" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-multilingual-lastname">
            <asp:Label ID="lbLocalSurname" runat="server" CssClass="form-label-left" AssociatedControlID="txtMultilingualSurname">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelSurname" />
                &nbsp;(<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelLocalLanguage" />
                ) </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtMultilingualSurname" runat="server" CssClass="form-textbox2" />
            </div>
            <hr />
        </li>
        <li class="form-line" id="ucmemberedit-username-field">
            <asp:Label ID="lbUsername" runat="server" CssClass="form-label-left" AssociatedControlID="txtUsername">
                <JXTControl:ucLanguageLiteral ID="ucUsername" runat="server" SetLanguageCode="LabelUsername" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-textbox2" ReadOnly="true" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-email-field">
            <asp:Label ID="lbEmailAddress" runat="server" CssClass="form-label-left" AssociatedControlID="txtEmailAddress">
                <JXTControl:ucLanguageLiteral ID="ucEmailAddress" runat="server" SetLanguageCode="LabelEmail" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-textbox2" Enabled="false"
                    ReadOnly="true" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-secondaryemail-field">
            <asp:Label ID="lbSecondaryEmail" runat="server" CssClass="form-label-left" AssociatedControlID="txtSecondaryEmailAddress">
                <JXTControl:ucLanguageLiteral ID="UcSecondaryEmail" runat="server" SetLanguageCode="LabelSecondaryEmail" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtSecondaryEmailAddress" runat="server" CssClass="form-textbox2" />
                <asp:RegularExpressionValidator ID="revSecondaryEmailAddress" runat="server" ControlToValidate="txtSecondaryEmailAddress"
                    ValidationGroup="MemberEdit"
                    SetFocusOnError="true" Display="Dynamic"> 
                </asp:RegularExpressionValidator>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-email-format-section">
            <asp:Label ID="lbEmailFormat" runat="server" CssClass="form-label-left" AssociatedControlID="radlEmailFormat">
                <JXTControl:ucLanguageLiteral ID="ucEmailFormat" runat="server" SetLanguageCode="LabelEmailFormat" />
            </asp:Label>
            <div class="form-input">
                <div class="form-single-column">
                    <span class="form-radio-item" style="clear: left;">
                        <asp:RadioButtonList ID="radlEmailFormat" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            runat="server" class="form-radio">
                            <asp:ListItem Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </span><span class="clearfix"></span>
                </div>
            </div>
            <hr />
        </li>
        <asp:PlaceHolder ID="phLanguage" runat="server" Visible="false">
            <li class="form-line" id="Li2">
                <asp:Label ID="lbLanguage" runat="server" CssClass="form-label-left" AssociatedControlID="ddlLanguage">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelPreferredEmailLanguage" />
                </asp:Label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlLanguage" TabIndex="9" runat="server" class="form-dropdown">
                    </asp:DropDownList>
                </div>
            </li>
        </asp:PlaceHolder>
        <li class="form-line" id="ucmemberedit-address-field">
            <asp:Label ID="lbAddress" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberAddress">
                <JXTControl:ucLanguageLiteral ID="ucAddress" runat="server" SetLanguageCode="LabelAddress" />
            </asp:Label>
            <div id="cid_3" class="form-input">
                <asp:TextBox ID="txtMemberAddress" runat="server" TextMode="MultiLine" class="form-textarea"
                    cols="40" Rows="6" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-suburb-field">
            <asp:Label ID="lbSuburb" runat="server" CssClass="form-label-left" AssociatedControlID="txtSuburb">
                <JXTControl:ucLanguageLiteral ID="ucSuburb" runat="server" SetLanguageCode="LabelSuburb" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtSuburb" runat="server" class="form-textarea" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-postcode-field">
            <asp:Label ID="lbPostcode" runat="server" CssClass="form-label-left" AssociatedControlID="txtPostcode">
                <JXTControl:ucLanguageLiteral ID="ucPostcode" runat="server" SetLanguageCode="LabelPostcode" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtPostcode" runat="server" class="form-textarea" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-state-field">
            <asp:Label ID="lbState" runat="server" CssClass="form-label-left" AssociatedControlID="txtState">
                <JXTControl:ucLanguageLiteral ID="ucState" runat="server" SetLanguageCode="LabelState" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtState" runat="server" class="form-textarea" />
            </div>
        </li>
        <li class="form-line" id="Li1">
            <asp:Label ID="lbCountry" runat="server" CssClass="form-label-left" AssociatedControlID="ddlCountry">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelCountry" />
            </asp:Label>
            <div class="form-input">
                <asp:DropDownList ID="ddlCountry" TabIndex="8" runat="server" class="form-dropdown">
                </asp:DropDownList>
            </div>
        </li>
        <li class="form-line" id="Li7">
            <asp:Label ID="lbAddMailingAddress" runat="server" CssClass="form-label-left" AssociatedControlID="ckAddMailingAddress">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelAddMailingAddress" />
            </asp:Label>
            <div id="Div2" class="form-input">
                <asp:CheckBox ID="ckAddMailingAddress" runat="server" TabIndex="10" ClientIDMode="Static" />
            </div>
        </li>
        <li class="form-line" id="divMailingAddress" style="display: none;" runat="server"
            clientidmode="Static">
            <asp:Label ID="lbMailingAddress" runat="server" CssClass="form-label-left" AssociatedControlID="tbMailingAddress">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelMailingAddress" />
            </asp:Label>
            <div id="Div1" class="form-input">
                <asp:TextBox ID="tbMailingAddress" runat="server" TextMode="MultiLine" class="form-textarea"
                    cols="40" Rows="6" TabIndex="11" />
            </div>
        </li>
        <li class="form-line" id="divMailingSuburb" style="display: none;" runat="server"
            clientidmode="Static">
            <asp:Label ID="lbMailingSuburb" runat="server" CssClass="form-label-left">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelMailingSuburb" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="tbMailingSuburb" runat="server" class="form-textarea" TabIndex="12" />
            </div>
        </li>
        <li class="form-line" id="divMailingPostcode" style="display: none;" runat="server"
            clientidmode="Static">
            <asp:Label ID="lbMailingPostcode" runat="server" CssClass="form-label-left" AssociatedControlID="tbMailingPostcode">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelMailingPostcode" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="tbMailingPostcode" runat="server" class="form-textarea" TabIndex="13" />
            </div>
        </li>
        <li class="form-line" id="divMailingState" style="display: none;" runat="server"
            clientidmode="Static">
            <asp:Label ID="lbMailingState" runat="server" CssClass="form-label-left" AssociatedControlID="tbMailingState">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelMailingState" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="tbMailingState" runat="server" class="form-textarea" TabIndex="14" />
            </div>
        </li>
        <li class="form-line" id="divMailingCountry" style="display: none;" runat="server"
            clientidmode="Static">
            <asp:Label ID="lbMaillingCountry" runat="server" CssClass="form-label-left" AssociatedControlID="ddlMailingCountry">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelMailingCountry" />
            </asp:Label>
            <div class="form-input">
                <asp:DropDownList ID="ddlMailingCountry" TabIndex="15" runat="server" class="form-dropdown">
                </asp:DropDownList>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-account-type">
            <asp:Label ID="lbGender" runat="server" CssClass="form-label-left" AssociatedControlID="radlGender">
                <JXTControl:ucLanguageLiteral ID="ucGender" runat="server" SetLanguageCode="LabelGender" />
            </asp:Label>
            <div class="form-input">
                <div class="form-single-column">
                    <span class="form-radio-item" style="clear: left;">
                        <asp:RadioButtonList ID="radlGender" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            runat="server" class="form-radio" TabIndex="16">
                            <asp:ListItem Value="M" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </span><span class="clearfix"></span>
                </div>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-date-of-birth">
            <asp:Label ID="lbDateOfBirth" runat="server" CssClass="form-label-left" AssociatedControlID="ddlDay">
                <JXTControl:ucLanguageLiteral ID="ucDateOfBirth" runat="server" SetLanguageCode="LabelDateOfBirth" />
            </asp:Label>
            <div class="form-input">
                <asp:UpdatePanel ID="upDateOfBirth" runat="server">
                    <ContentTemplate>
                        <span class="form-sub-label-container">
                            <asp:DropDownList ID="ddlDay" TabIndex="17" runat="server" class="form-dropdown">
                            </asp:DropDownList>
                            <span class='span-dash'>-</span>
                            <asp:Label ID="lbDay" runat="server" CssClass="form-sub-label" AssociatedControlID="ddlDay">
                                <JXTControl:ucLanguageLiteral ID="ucDay" runat="server" SetLanguageCode="LabelDay" />
                            </asp:Label>
                        </span><span class="form-sub-label-container">
                            <asp:DropDownList ID="ddlMonth" TabIndex="18" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                                class="form-dropdown" AutoPostBack="True">
                            </asp:DropDownList>
                            <span class='span-dash'>-</span>
                            <asp:Label ID="lbMonth" runat="server" CssClass="form-sub-label" AssociatedControlID="ddlMonth">
                                <JXTControl:ucLanguageLiteral ID="ucMonth" runat="server" SetLanguageCode="LabelMonth" />
                            </asp:Label>
                        </span><span class="form-sub-label-container">
                            <asp:DropDownList ID="ddlYear" TabIndex="19" runat="server" AutoPostBack="True" class="form-dropdown"
                                OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class='span-dash'>-</span>
                            <asp:Label ID="lbYear" runat="server" CssClass="form-sub-label" AssociatedControlID="ddlYear">
                                <JXTControl:ucLanguageLiteral ID="ucYear" runat="server" SetLanguageCode="LabelYear" />
                            </asp:Label>
                        </span>
                        <%--<span class="form-sub-label-container">
                            <label class="form-sub-label">
                                &nbsp;&nbsp;&nbsp;
                            </label>
                        </span>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <asp:CustomValidator ID="CusValDOB" runat="server" SetFocusOnError="true" Display="Dynamic"
                OnServerValidate="CusValDOB_ServerValidate" ValidationGroup="MemberEdit" />
            <hr />
        </li>
        <%--<li class="form-line" id="ucmemberedit-date-of-birth-error">
            <label class="form-label-left">
                &nbsp;
            </label>
            <div class="form-input">
                <div class="form-single-column">
                </div>
            </div>
        </li>--%>
        <li class="form-line" id="ucmemberedit-phone-home">
            <asp:Label ID="lbPhoneHome" runat="server" CssClass="form-label-left" AssociatedControlID="txtHomePhone">
                <JXTControl:ucLanguageLiteral ID="ucPhoneHome" runat="server" SetLanguageCode="LabelPhoneHome" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtHomePhone" runat="server" class="form-textbox2" MaxLength="38"
                    TabIndex="20" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-phone-work">
            <asp:Label ID="lbPhoneWork" runat="server" CssClass="form-label-left" AssociatedControlID="txtWorkPhone">
                <JXTControl:ucLanguageLiteral ID="ucPhoneWork" runat="server" SetLanguageCode="LabelPhoneWork" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtWorkPhone" runat="server" class="form-textbox2" MaxLength="38"
                    TabIndex="21" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-mobile">
            <asp:Label ID="lbMobilePhone" runat="server" CssClass="form-label-left" AssociatedControlID="txtMobilePhone">
                <JXTControl:ucLanguageLiteral ID="ucPhoneMobile" runat="server" SetLanguageCode="LabelPhoneMobile" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtMobilePhone" runat="server" class="form-textbox2" MaxLength="38"
                    TabIndex="22" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-fax">
            <asp:Label ID="lbFax" runat="server" CssClass="form-label-left" AssociatedControlID="txtFax">
                <JXTControl:ucLanguageLiteral ID="ucFax" runat="server" SetLanguageCode="LabelFax" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtFax" runat="server" class="form-textbox2" MaxLength="38" TabIndex="23" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-education">
            <asp:Label ID="lbEducation" runat="server" CssClass="form-label-left" AssociatedControlID="ddlEducation">
                <JXTControl:ucLanguageLiteral ID="ucEducation" runat="server" SetLanguageCode="LabelEducation" />
            </asp:Label>
            <div class="form-input">
                <asp:DropDownList ID="ddlEducation" TabIndex="24" runat="server" class="form-dropdown">
                </asp:DropDownList>
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-tags-field">
            <asp:Label ID="lbMemberTags" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberTags">
                <JXTControl:ucLanguageLiteral ID="ucTags" runat="server" SetLanguageCode="LabelTags" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="txtMemberTags" runat="server" CssClass="form-textbox2" TabIndex="25" />
            </div>
        </li>
        <li class="form-line" id="ucmemberedit-passportnumber-field">
            <asp:Label ID="lbPassportNo" runat="server" CssClass="form-label-left" AssociatedControlID="tbPassportNo">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelPassportNumber" />
            </asp:Label>
            <div class="form-input">
                <asp:TextBox ID="tbPassportNo" runat="server" CssClass="form-textbox2" TabIndex="26" />
            </div>
        </li>
        <%-- <li class="form-line" id="ucmemberedit-news-unsubscribe">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ucUnsubscribeNews" runat="server" SetLanguageCode="LabelReceiveNewsletter" />
            </label>
            <div class="form-input">
                <asp:CheckBox ID="chkNews" runat="server" />&nbsp;(<JXTControl:ucLanguageLiteral
                    ID="ucTick" runat="server" SetLanguageCode="LabelPleaseTickBoxToSubscribe" TabIndex="27" />
                )
            </div>
        </li>--%>
        <li class="form-line" id="ucmemberedit-bottom-button">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper">
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="mini-new-buttons"
                        ValidationGroup="MemberEdit" TabIndex="28" />
                    <asp:Button ID="btnCloseAccount" runat="server" Text="Close Account" OnClick="btnCloseAccount_Click"
                        CssClass="mini-new-buttons" TabIndex="29" />
                </div>
            </div>
        </li>
    </ul>
</div>
