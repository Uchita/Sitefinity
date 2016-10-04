<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertiserEdit.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucAdvertiserEdit" %>
<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltucAdvEditHeaderMyaccount" runat="server" SetLanguageCode="LabelMyAccount" />
    </h2>
</div>
<div class="form-all">
    <span class="form-required">
        <asp:Literal ID="litMessage" runat="server" /></span>
    <asp:Panel ID="pnlCompanyDetails" runat="server">
        <ul class="form-section">
            <%--<li class="form-line" id="adv-accounttype-field">
                <asp:Label ID="lbAccountType" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditAccounttype" runat="server" SetLanguageCode="LabelAccountType" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="dataAccountType" runat="server"></asp:Literal>
                </div>
            </li>--%>
            <li class="form-line" id="adv-compnayname-field">
                <asp:Label ID="lbCompanyName" runat="server" CssClass="form-label-left" AssociatedControlID="dataCompanyName">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditCompanyName" runat="server" SetLanguageCode="LabelCompanyName" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataCompanyName" runat="server" CssClass="form-textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_CompanyName" runat="server" ControlToValidate="dataCompanyName"
                        ValidationGroup="AdvertiserEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-webaddress-field">
                <asp:Label ID="lbWebAddress" runat="server" CssClass="form-label-left" AssociatedControlID="dataWebAddress">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditWebAddress" runat="server" SetLanguageCode="LabelWebAddress" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataWebAddress" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-accountspayableemail-field">
                <asp:Label ID="lbAccountsPayableEmail" runat="server" CssClass="form-label-left"
                    AssociatedControlID="dataAccountsPayableEmail">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditAccountsPayableEmail" runat="server"
                        SetLanguageCode="LabelAccountsPayableEmail" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataAccountsPayableEmail" runat="server" CssClass="form-textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_AccountsPayableEmail" runat="server" ControlToValidate="dataAccountsPayableEmail"
                        ValidationGroup="AdvertiserEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-streetaddress1-field">
                <asp:Label ID="lbStreetAddress1" runat="server" CssClass="form-label-left" AssociatedControlID="dataStreetAddress1">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditStreetAddress1" runat="server" SetLanguageCode="LabelStreetAddress1" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataStreetAddress1" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-streetaddress2-field">
                <asp:Label ID="lbStreetAddress2" runat="server" CssClass="form-label-left" AssociatedControlID="dataStreetAddress2">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditStreetAddress2" runat="server" SetLanguageCode="LabelStreetAddress2" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataStreetAddress2" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <hr />
            <li class="form-line" id="adv-postaladdress1-field">
                <asp:Label ID="lbPostalAddress1" runat="server" CssClass="form-label-left" AssociatedControlID="dataPostalAddress1">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditPostalAddress1" runat="server" SetLanguageCode="LabelPostalAddress1" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataPostalAddress1" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-postaladdress2-field">
                <asp:Label ID="lbPostalAddress2" runat="server" CssClass="form-label-left" AssociatedControlID="dataPostalAddress2">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditPostalAddress2" runat="server" SetLanguageCode="LabelPostalAddress2" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataPostalAddress2" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <hr />
            <li class="form-line" id="adv-businessnumber-field">
                <asp:Label ID="lbBusinessNumber" runat="server" CssClass="form-label-left" AssociatedControlID="dataBusinessNumber">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditBusinessNumber" runat="server" SetLanguageCode="LabelBusinessNumber" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataBusinessNumber" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-noofemployees-field">
                <asp:Label ID="lbNoOfEmployees" runat="server" CssClass="form-label-left" AssociatedControlID="dataNoOfEmployees">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditTotalEmployees" runat="server" SetLanguageCode="LabelTotalEmployees" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataNoOfEmployees" runat="server" CssClass="form-textbox" MaxLength="10"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-businesstype-field">
                <asp:Label ID="lbBusinessType" runat="server" CssClass="form-label-left" AssociatedControlID="ddlBusinessType">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditBusinessType" runat="server" SetLanguageCode="LabelBusinessType" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlBusinessType" runat="server" CssClass="form-multiple-column" />
                    <asp:RequiredFieldValidator ID="rfvBusinessType" runat="server" ControlToValidate="ddlBusinessType" ValidationGroup="AdvertiserEdit" 
                        InitialValue="0" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-companyprofile-field">
                <asp:Label ID="lbCompanyProfile" runat="server" CssClass="form-label-left" AssociatedControlID="txtContent">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditCompanyProfile" runat="server" SetLanguageCode="LabelCompanyProfile" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <FredCK:CKEditorControl ID="txtContent" runat="server" Width="650px" Height="400px"
                        CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                </div>
            </li>
            <hr />
        </ul>
    </asp:Panel>
    <asp:Panel ID="pnlConatactDetails" runat="server">
        <ul class="form-section">
            <li class="form-line" id="adv-firstname-field">
                <asp:Label ID="lbFirstName" runat="server" CssClass="form-label-left" AssociatedControlID="dataFirstName">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditFirstname" runat="server" SetLanguageCode="LabelFirstName" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataFirstName" runat="server" CssClass="form-textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_FirstName" runat="server" ControlToValidate="dataFirstName"
                        ValidationGroup="AdvertiserEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-lastname-field">
                <asp:Label ID="lbLastName" runat="server" CssClass="form-label-left" AssociatedControlID="dataLastName">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditSurname" runat="server" SetLanguageCode="LabelSurname" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataLastName" runat="server" CssClass="form-textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_LastName" runat="server" ControlToValidate="dataLastName"
                        ValidationGroup="AdvertiserEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-phone-field">
                <asp:Label ID="lbPhone" runat="server" CssClass="form-label-left" AssociatedControlID="dataPhone">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditPhone" runat="server" SetLanguageCode="LabelPhone" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataPhone" runat="server" CssClass="form-textbox" MaxLength="30"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-fax-field">
                <asp:Label ID="lbFax" runat="server" CssClass="form-label-left" AssociatedControlID="dataFax">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditFax" runat="server" SetLanguageCode="LabelFax" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataFax" runat="server" CssClass="form-textbox" MaxLength="30"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-emailaddress-field">
                <asp:Label ID="lbEmailAddress" runat="server" CssClass="form-label-left" AssociatedControlID="dataEmailAddress">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditEmailAddress" runat="server" SetLanguageCode="LabelEmailAddress" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataEmailAddress" runat="server" CssClass="form-textbox" Enabled="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_EmailAddress" runat="server" ControlToValidate="dataEmailAddress"
                        ValidationGroup="AdvertiserEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <span class="form-hint">
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelChangeEmailContactAdmin" />
                    </span>
                </div>
            </li>
            <li class="form-line" id="adv-applicationemail-field">
                <asp:Label ID="lbApplicationEmail" runat="server" CssClass="form-label-left" AssociatedControlID="dataApplicationEmail">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditApplicationEmail" runat="server" SetLanguageCode="LabelApplicationEmailAddress" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="dataApplicationEmail" runat="server" CssClass="form-textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_ApplicationEmail" runat="server" ControlToValidate="dataApplicationEmail"
                        ValidationGroup="AdvertiserEdit" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </li>
            <asp:PlaceHolder ID="phLanguage" runat="server" Visible="false">
                <li class="form-line" id="Li1">
                    <asp:Label ID="Label2" runat="server" CssClass="form-label-left" AssociatedControlID="ddlLanguage">
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelLanguage" />
                    </asp:Label>
                    <div class="form-input">
                        <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-multiple-column" />
                    </div>
                </li>
            </asp:PlaceHolder>
            <li class="form-line" id="adv-email-format-section">
                <asp:Label ID="lbEmailFormat" runat="server" AssociatedControlID="dataEmailFormat"
                    CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditEmailFormat" runat="server" SetLanguageCode="LabelEmailFormat" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:RadioButtonList ID="dataEmailFormat" runat="server" DataValueField="EmailFormatId"
                        DataTextField="EmailFormatName" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList>
                </div>
            </li>


            <li class="form-line" id="Li3">
                <asp:Label ID="Label3" runat="server" CssClass="form-label-left" AssociatedControlID="tbVideoLink">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelVideoLink" />
                </asp:Label>
                <div class="form-input">
                     <asp:TextBox ID="tbVideoLink" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <asp:PlaceHolder ID="phIndustry" runat="server">
            <li class="form-line" id="Li4">
                <asp:Label ID="Label4" runat="server" CssClass="form-label-left" AssociatedControlID="ddlIndustry">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelIndustry" />
                </asp:Label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlIndustry" runat="server" CssClass="form-multiple-column" />
                </div>
            </li>
            </asp:PlaceHolder>
            <li class="form-line" id="Li5">
                <asp:Label ID="Label5" runat="server" CssClass="form-label-left" AssociatedControlID="tbNominatedCompanyRole">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelNominatedCompanyRole" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbNominatedCompanyRole" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="Li6">
                <asp:Label ID="Label6" runat="server" CssClass="form-label-left" AssociatedControlID="tbNominatedCompanyFirstName">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelNominatedCompanyFirstName" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbNominatedCompanyFirstName" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="Li7">
                <asp:Label ID="Label7" runat="server" CssClass="form-label-left" AssociatedControlID="tbNominatedCompanyLastName">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelNominatedCompanyLastName" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbNominatedCompanyLastName" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="Li8">
                <asp:Label ID="Label8" runat="server" CssClass="form-label-left" AssociatedControlID="tbNominatedCompanyEmailAddress">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelNominatedCompanyEmailAddress" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbNominatedCompanyEmailAddress" runat="server" CssClass="form-textbox"></asp:TextBox>
                     <asp:CustomValidator ID="CusVal_NominatedCompanyEmailAddress" runat="server" ControlToValidate="tbNominatedCompanyEmailAddress"
                                ErrorMessage="Invalid Email Format" OnServerValidate="CusVal_NominatedCompanyEmailAddress_ServerValidate"
                                SetFocusOnError="true" Display="Dynamic" ValidationGroup="AdvertiserEdit"></asp:CustomValidator>
                </div>
            </li>
            <li class="form-line" id="Li9">
                <asp:Label ID="Label9" runat="server" CssClass="form-label-left" AssociatedControlID="tbNominatedCompanyPhone">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelNominatedCompanyPhone" />
                </asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbNominatedCompanyPhone" runat="server" CssClass="form-textbox"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="Li10">
                <asp:Label ID="Label10" runat="server" CssClass="form-label-left" AssociatedControlID="ddlPreferredContactMethod">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelPreferredContactMethod" />
                </asp:Label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlPreferredContactMethod" runat="server" CssClass="form-multiple-column" />
                </div>
            </li>
            <li class="form-line" id="adv-username-field">
                <asp:Label ID="lbUserName" runat="server" CssClass="form-label-left" AssociatedControlID="dataUserName">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditUsername" runat="server" SetLanguageCode="LabelUsername" />
                    <span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:Label ID="dataUserName" runat="server" CssClass="form-textbox"></asp:Label>
                </div>
            </li>
            <li class="form-line" id="adv-password-field">
                <asp:Label ID="lbPassword" runat="server" AssociatedControlID="dataPassword" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditPassword" runat="server" SetLanguageCode="LabelPassword" />
                </asp:Label>
                <div class="form-input">
                    <asp:HyperLink ID="dataPassword" runat="server" CssClass="form-textbox" NavigateUrl="~/advertiser/edit.aspx?tab=2">
                        <JXTControl:ucLanguageLiteral ID="ltucAdvEditChangepwd" runat="server" SetLanguageCode="LabelChangePwd" />
                    </asp:HyperLink>
                </div>
            </li>
            <asp:PlaceHolder ID="phJobExpiryNotification" runat="server" Visible="false">
                <li class="form-line" id="Li2">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="cbJobExpiryNofification" CssClass="form-label-left">
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelJobExpiryNotification" />
                    </asp:Label>
                    <div class="form-input">
                        <div class="form-single-column">
                            <span class="form-checkbox-item" style="clear: left;">
                                <asp:CheckBox ID="cbJobExpiryNofification" runat="server" CssClass="form-checkbox"
                                    Style="clear: left;" />
                            </span><span class="clearfix"></span>
                        </div>
                    </div>
                </li>
            </asp:PlaceHolder>
            <li class="form-line" id="adv-newsletter-field">
                <asp:Label ID="lbNewsletter" runat="server" AssociatedControlID="dataPassword" CssClass="form-label-left"></asp:Label>
                <div class="form-input">
                    <div class="form-single-column">
                        <span class="form-checkbox-item" style="clear: left;">
                            <asp:CheckBox ID="dataNewsletter" runat="server" Text="I would like to subscribe to the newsletter"
                                CssClass="form-checkbox" Style="clear: left;" />
                        </span><span class="clearfix"></span>
                    </div>
                </div>
            </li>
        </ul>
    </asp:Panel>
    <asp:Panel ID="pnlAdvertiserLogo" runat="server">
        <ul class="form-section">
            <hr />
            <li class="form-line" id="adv-selectDocument-field">
                <asp:label ID="lbAdvEditSelectDocument" runat="server" cssclass="form-label-left" AssociatedControlID="docInput">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditSelectDocument" runat="server" SetLanguageCode="LabelCompanyLogo" />
                </asp:label>
                <div class="form-input">
                    <asp:FileUpload ID="docInput" runat="server" class="form-textbox" />
                </div>
            </li>
            <li class="form-line" id="adv-advertiserlogo-field">
                <asp:Label ID="lblNoLogo" runat="server">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditYouhavenologo" runat="server" SetLanguageCode="LabelYouhavenologo" />
                </asp:Label>
                <div class="form-input">
                    <asp:Image ID="imgLogo" runat="server"></asp:Image>
                    <asp:CustomValidator ID="cvalFileName" runat="server" ValidationGroup="AdvertiserEdit"
                        SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvalFile" runat="server" ErrorMessage="CustomValidator"
                        ValidationGroup="AdvertiserEdit" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvalFileType" runat="server" ValidationGroup="AdvertiserEdit"
                        SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                </div>
            </li>
            <!--<li class="form-line" id="Li1">
                <asp:Label ID="lblRemoveLogo" runat="server" class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltucAdvEditRemovelogo" runat="server" SetLanguageCode="LabelRemovelogo" />
                    </asp:Label>
                <div class="form-input">
                    <asp:CheckBox ID="chkRemoveLogo" runat="server" />
                </div>
            </li>-->
        </ul>
    </asp:Panel>
    <ul class="form-section">
        <li class="form-line" id="adv-bottom-button">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" ValidationGroup="AdvertiserEdit"
                        Text="Update" CssClass="mini-new-buttons" />
                </div>
            </div>
        </li>
    </ul>
</div>
