<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="AdvertiserUsersEdit" Title="AdvertiserUsers Edit"
    CodeBehind="AdvertiserUsersEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Advertiser Users - Add/Edit <a href='http://support.jxt.com.au/solution/categories/116125/folders/190961/articles/116438-advertiser-user'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="/scripts/strength.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dataUserPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>
    <div class="form-all">
        <asp:MultiView ID="AdvertiserUserMultiView" runat="server" ActiveViewIndex="0">
            <asp:View ID="AdvertiserUserView" runat="server">
                <asp:PlaceHolder ID="PasswordLockedForm" runat="server" Visible="false">
                    <ul class="form-section">
                        <li>
                            <p class="form-required">
                                This account is currently locked by the password security lock (5 failed login attempts
                                with the wrong credentials).
                            </p>
                        </li>
                        <li>
                            <p>
                                Prior to unlocking this account, ensure you have verified the user before unlocking
                                the account. Alternatively this account will be unlocked after 60 mins from the
                                locked time.</p>
                        </li>
                        <li class="form-line">
                            <label class="form-label-left">
                                Locked Time:</label>
                            <div class="form-input">
                                <asp:Literal ID="PasswordLockedTime" runat="server"></asp:Literal>
                            </div>
                        </li>
                        <li class="form-line">
                            <label class="form-label-left">
                                Unlock:<span class="form-required"></span></label>
                            <div class="form-input">
                                <asp:Button ID="btnPasswordUnlock" runat="server" Text="Unlock Password Lock" OnClick="btnPasswordUnlock_Click" />
                            </div>
                        </li>
                    </ul>
                    <hr />
                </asp:PlaceHolder>
                <ul class="form-section">
                    <li class="form-line" id="adv-advertiser-field">
                        <label class="form-label-left">
                            Advertiser:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="dataAdvertiserId" DataTextField="CompanyName"
                                DataValueField="AdvertiserID" CssClass="form-multiple-column" />
                            <%--<data:EntityDropDownList runat="server" ID="dataAdvertiserId" DataSourceID="AdvertiserIdAdvertisersDataSource"
                                DataTextField="CompanyName" DataValueField="AdvertiserId" AppendNullItem="true"
                                Required="true" NullItemText=" Please Choose ..." ErrorText="Required" CssClass="form-multiple-column" />
                            <data:AdvertisersDataSource ID="AdvertiserIdAdvertisersDataSource" runat="server"
                                SelectMethod="GetAll" />--%>
                            <asp:Label ID="lbAdvertiser" runat="server" Visible="false" />
                            <asp:HiddenField ID="hfAdvertiser" runat="server" Value="0" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-primaryaccount-field">
                        <label class="form-label-left">
                            Primary Account:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataPrimaryAccount" runat="server" OnCheckedChanged="PrimaryAccountCB_Changed"
                                AutoPostBack="true" />
                            <span class="form-required">
                                <asp:Literal ID="primaryAccountError" runat="server" Visible="false"></asp:Literal></span>
                        </div>
                    </li>
                    <li class="form-line" id="adv-username-field">
                        <label class="form-label-left">
                            User Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataUserName" TextMode="SingleLine" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_dataUserName" runat="server" Display="Dynamic"
                                ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CusVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName"
                                ErrorMessage="User Name already exists" OnServerValidate="CusVal_dataUserName_ServerValidate"></asp:CustomValidator>
                        </div>
                    </li>
                    <li class="form-line" id="adv-userpassword-field">
                        <label class="form-label-left">
                            User Password:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataUserPassword" ClientIDMode="Static" TextMode="Password"
                                Width="250px" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserPassword"
                                    runat="server" Display="Dynamic" ControlToValidate="dataUserPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="* "
                                Display="Dynamic" ControlToValidate="dataUserPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" />
                            <span>Password must contain 8 characters or more, 1 lowercase letter, 1 uppercase letter
                                and 1 number.</span>
                            <%--<asp:HiddenField ID="hfUserPassword" runat="server" />--%>
                        </div>
                    </li>
                    <li class="form-line" id="adv-confirmpassword-field">
                        <label class="form-label-left">
                            Confirm Password:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataConfirmPassword" TextMode="Password" Width="250px"
                                autocomplete="off"></asp:TextBox><asp:CustomValidator ID="CusVal_dataConfirmPassword"
                                    runat="server" OnServerValidate="CusVal_dataConfirmPassword_ServerValidate" Display="Dynamic"
                                    ControlToValidate="dataUserPassword" ErrorMessage="Confirm Password does not match"></asp:CustomValidator>
                        </div>
                    </li>
                    <li class="form-line" id="adv-firstname-field">
                        <label class="form-label-left">
                            First Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataFirstName" TextMode="SingleLine" Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="ReqVal_dataFirstName" runat="server" Display="Dynamic" ControlToValidate="dataFirstName"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="adv-surname-field">
                        <label class="form-label-left">
                            Surname:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataSurname" TextMode="SingleLine" Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="ReqVal_dataSurname" runat="server" Display="Dynamic" ControlToValidate="dataSurname"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="adv-email-field">
                        <label class="form-label-left">
                            Email:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataEmail" TextMode="SingleLine" Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="ReqVal_dataEmail" runat="server" Display="Dynamic" ControlToValidate="dataEmail"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CusVal_EmailAddress" runat="server" ControlToValidate="dataEmail"
                                ErrorMessage="Invalid Email Format" SetFocusOnError="true" Display="Dynamic"
                                OnServerValidate="CusVal_EmailAddress_ServerValidate"></asp:CustomValidator>
                        </div>
                    </li>
                    <asp:Panel ID="plValidationEmail" runat="server" Visible="false">
                        <li class="form-line" id="Li1">
                            <label class="form-label-left">
                                Send Validation Email:</label>
                            <div class="form-input">
                                <asp:CheckBox ID="cbValidationEmail" runat="server" />
                            </div>
                        </li>
                    </asp:Panel>
                    <li class="form-line" id="adv-applicationemailaddress-field">
                        <label class="form-label-left">
                            Application Email Address:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataApplicationEmailAddress" TextMode="SingleLine"
                                Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_dataApplicationEmailAddress" runat="server"
                                Display="Dynamic" ControlToValidate="dataApplicationEmailAddress" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li class="form-line" id="adv-phone-field">
                        <label class="form-label-left">
                            Phone:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataPhone" MaxLength="40"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-fax-field">
                        <label class="form-label-left">
                            Fax:</label>
                        <div class="form-input">
                            <asp:TextBox runat="server" ID="dataFax" MaxLength="40"></asp:TextBox>
                        </div>
                    </li>
                    <li class="form-line" id="adv-accountstatus-field">
                        <label class="form-label-left">
                            Account Status:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="dataAccountStatus" Width="250" DataTextField="AdvertiserAccountStatusName"
                                DataValueField="AdvertiserAccountStatusID">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ReqVal_AccountStatus" runat="server" ErrorMessage="Required"
                                InitialValue="0" ControlToValidate="dataAccountStatus" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-newsletter-field">
                        <label class="form-label-left">
                            Newsletter:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataNewsletter" runat="server" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phJobExpiryNotification" runat="server">
                        <li class="form-line" id="Li2">
                            <asp:Label ID="Label1" runat="server" CssClass="form-label-left">Job Expiry Notification:
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
                    <li class="form-line" id="adv-newsletterformat-field">
                        <label class="form-label-left">
                            Newsletter Format:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <data:EntityDropDownList runat="server" ID="dataNewsletterFormat" DataSourceID="NewsletterFormatEmailFormatsDataSource"
                                DataTextField="EmailFormatName" DataValueField="EmailFormatId" AppendNullItem="true"
                                Required="true" NullItemText=" Please Choose ..." ErrorText="Required" CssClass="form-multiple-column" />
                            <data:EmailFormatsDataSource ID="NewsletterFormatEmailFormatsDataSource" runat="server"
                                SelectMethod="GetAll" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-emailformat-field">
                        <label class="form-label-left">
                            Email Format:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <data:EntityDropDownList runat="server" ID="dataEmailFormat" DataSourceID="EmailFormatEmailFormatsDataSource"
                                DataTextField="EmailFormatName" DataValueField="EmailFormatId" AppendNullItem="true"
                                Required="true" NullItemText=" Please Choose ..." ErrorText="Required" />
                            <data:EmailFormatsDataSource ID="EmailFormatEmailFormatsDataSource" runat="server"
                                SelectMethod="GetAll" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phLanguage" runat="server" Visible="false">
                        <li class="form-line" id="Li12">
                            <label class="form-label-left">
                                Language:</label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="false">
                                </asp:DropDownList>
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="adv-validated-field">
                        <label class="form-label-left">
                            Validated:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataValidated" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-lastlogondate-field">
                        <label class="form-label-left">
                            Last Login Date:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataLastLoginDate" MaxLength="10"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="adv-lastmodified-field">
                        <label class="form-label-left">
                            Last Modified:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataLastModified" MaxLength="10"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="adv-modifiedby-field">
                        <label class="form-label-left">
                            Modified By:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="dataModifiedBy" MaxLength="10"></asp:Label>
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phExternalAdvertiserUserID" runat="server">
                        <li class="form-line" id="adv-external-field">
                            <label class="form-label-left">
                                External Advertiser User ID:</label>
                            <div class="form-input">
                                <asp:Label runat="server" ID="lbExternalAdvertiserUserID"></asp:Label>
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phLastTCDate" runat="server" Visible="false">
                        <li class="form-line" id="Li11">
                            <label class="form-label-left">
                                Last Terms &amp; Conditions Date:</label>
                            <div class="form-input">
                                <div class="form-input">
                                    <asp:Label runat="server" ID="lbLastTermsAndConditionsDate" />
                                </div>
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                    Text="Insert" CssClass="jxtadminbutton" OnClick="InsertButton_Click" Visible="false" />
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" CssClass="jxtadminbutton" OnClick="UpdateButton_Click" Visible="false" />
                                <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel" CssClass="jxtadminbutton" OnClick="CancelButton_Click" />
                                <asp:Button ID="btnLoginAsAdvertiserUser" runat="server" Text="Login as Advertiser User"
                                    CausesValidation="False" CssClass="jxtadminbutton" Visible="false" OnClick="btnLoginAsAdvertiserUser_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
