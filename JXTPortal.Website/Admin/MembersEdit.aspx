<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="MembersEdit" Title="Members Edit" CodeBehind="MembersEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Members - Add/Edit <a href='http://support.jxt.com.au/solution/categories/116125/folders/190961/articles/116439-members'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="/scripts/strength.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <asp:PlaceHolder ID="MemberStatusClosedMessage" runat="server" Visible="false">
            
            <div class="msg warning">
                This member account has an account status of "CLOSED" and data on this page is for display only.
            </div>

        </asp:PlaceHolder>

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
            <li class="form-line" id="admin-members-Site">
                <label class="form-label-left">
                    Site:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlSite" TabIndex="11" runat="server" class="form-dropdown"
                        Enabled="false" />
                </div>
            </li>
            <li class="form-line" id="admin-members-username">
                <label class="form-label-left">
                    Username:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtUsername" CssClass="form-textbox2" Enabled="false"></asp:TextBox>
                    <%--<asp:Literal ID="ltLocked" runat="server" Visible="false"><span class="form-required">This account is currently Locked</span></asp:Literal>--%>
                    <%--                    <asp:RequiredFieldValidator ID="ReqVal_dataUsername" runat="server" Display="Dynamic"
                        ControlToValidate="txtUsername" ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    --%>
                </div>
            </li>
            <li class="form-line" id="admin-members-password">
                <label class="form-label-left">
                    Password:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtPassword" MaxLength="25" CssClass="form-textbox2"
                        size="20" autocomplete="off" ClientIDMode="Static" TextMode="Password"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="*"
                        Display="Dynamic" ControlToValidate="txtPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" />
                    <span>Password must contain 8 characters or more, 1 lowercase letter, 1 uppercase letter
                        and 1 number.</span>
                </div>
            </li>
            <li class="form-line" id="admin-members-valid">
                <label class="form-label-left">
                    Active:</label>
                <div class="form-input">
                    <asp:CheckBox ID="chkMemberValid" runat="server" />
                    (If not selected, Candidate is inactive)
                </div>
            </li>
            <li class="form-line" id="Li2">
                <label class="form-label-left">
                    Validated:</label>
                <div class="form-input">
                    <asp:Label ID="lblMemberValidated" runat="server" Visible="false" />
                    <asp:CheckBox ID="cbMemberValidated" runat="server" Visible="false"/>
                </div>
            </li>
            <li class="form-line" id="Li16">
                <label class="form-label-left">
                    Account Status:</label>
                <div class="form-input">
                    <asp:Label ID="lblMemberAccountStatus" runat="server" />
                </div>
            </li>
            <li class="form-line" id="admin-members-registeredDate">
                <label class="form-label-left">
                    Registration Date:</label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblMemberRegisteredDate" />
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-members-lastModifiedDate">
                <label class="form-label-left">
                    Last Modified Date:</label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblMemberLastModifiedDate" />
                    </div>
                </div>
            </li>
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
            <hr />
            <li class="form-line" id="admin-members-Titletype">
                <label class="form-label-left">
                    Title:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlTitle" TabIndex="8" runat="server" class="form-dropdown">
                        <asp:ListItem>Mr</asp:ListItem>
                        <asp:ListItem>Mrs</asp:ListItem>
                        <asp:ListItem>Ms</asp:ListItem>
                        <asp:ListItem>Miss</asp:ListItem>
                        <asp:ListItem>Dr</asp:ListItem>
                        <asp:ListItem>Professor</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
            <li class="form-line" id="admin-members-first-name">
                <label class="form-label-left">
                    First Name:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtFirstName" runat="server" class="form-textbox validate[required]"
                        size="20" />
                    <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="txtFirstname"
                        ErrorMessage="Firstname is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="admin-members-surname">
                <label class="form-label-left">
                    Surname:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtSurname" runat="server" class="form-textbox validate[required]"
                        size="20" />
                    <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ControlToValidate="txtSurname"
                        ErrorMessage="Surname is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="Li13">
                <label class="form-label-left">
                    First Name (Local Language):</label>
                <div class="form-input">
                    <asp:TextBox ID="txtMultilingualFirstName" runat="server" class="form-textbox" size="20" />
                </div>
            </li>
            <li class="form-line" id="Li14">
                <label class="form-label-left">
                    Surname (Local Language):</label>
                <div class="form-input">
                    <asp:TextBox ID="txtMultilingualSurname" runat="server" class="form-textbox" size="20" />
                </div>
            </li>
            <hr />
            <li class="form-line" id="admin-members-email-field">
                <label class="form-label-left">
                    E-mail:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtEmailAddress" runat="server" class="form-textbox validate[required, Email]"
                        size="30" />
                    <asp:CustomValidator ID="ctmEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                        OnServerValidate="ctmEmailAddress_ServerValidate" SetFocusOnError="true"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                        ErrorMessage="Email address is required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                        SetFocusOnError="true" ErrorMessage="A valid email address is required">  
                    </asp:RegularExpressionValidator>
                </div>
            </li>
            <li class="form-line" id="Li15">
                <label class="form-label-left">
                    Secondary E-mail:</label>
                <div class="form-input">
                    <asp:TextBox ID="txtSecondaryEmailAddress" runat="server" class="form-textbox" size="30" />
                </div>
            </li>
            <li class="form-line" id="admin-members-email-format-section">
                <label class="form-label-left">
                    Email Format</label>
                <div class="form-input">
                    <div class="form-single-column">
                        <span class="form-radio-item" style="clear: left;">
                            <asp:RadioButtonList ID="radlEmailFormat" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                runat="server" class="form-radio">
                                <asp:ListItem Value="1" Selected="True">HTML</asp:ListItem>
                                <asp:ListItem Value="2">Text</asp:ListItem>
                            </asp:RadioButtonList>
                            <span class="clearfix"></span>
                    </div>
                </div>
            </li>
            <hr />
            <li class="form-line" id="admin-members-address1-field">
                <label class="form-label-left">
                    Address1:</label>
                <div id="form-input" class="form-input">
                    <asp:TextBox ID="txtMemberAddress1" runat="server" TextMode="MultiLine" class="form-textarea"
                        cols="40" Rows="4" />
                </div>
            </li>
            <li class="form-line" id="admin-members-address2-field">
                <label class="form-label-left">
                    Address2:</label>
                <div id="form-input" class="form-input">
                    <asp:TextBox ID="txtMemberAddress2" runat="server" TextMode="MultiLine" class="form-textarea"
                        cols="40" Rows="4" />
                </div>
            </li>
            <li class="form-line" id="admin-members-Suburb-field">
                <label class="form-label-left">
                    Suburb:</label>
                <div id="form-input" class="form-input">
                    <asp:TextBox ID="txtMemberSuburb" runat="server" class="form-textarea" />
                </div>
            </li>
            <li class="form-line" id="admin-members-Postcode-field">
                <label class="form-label-left">
                    Postcode:</label>
                <div id="form-input" class="form-input">
                    <asp:TextBox ID="txtMemberPostcode" runat="server" />
                </div>
            </li>
            <li class="form-line" id="admin-members-State-field">
                <label class="form-label-left">
                    State:</label>
                <div id="form-input" class="form-input">
                    <asp:TextBox ID="txtMemberState" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li9">
                <label class="form-label-left">
                    Country:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlCountry" TabIndex="8" runat="server" class="form-dropdown">
                    </asp:DropDownList>
                </div>
            </li>
            <hr />
            <li class="form-line" id="Li4">
                <label class="form-label-left">
                    Mailing Address1:</label>
                <div id="Div1" class="form-input">
                    <asp:TextBox ID="tbMailingAddress1" runat="server" TextMode="MultiLine" class="form-textarea"
                        cols="40" Rows="4" />
                </div>
            </li>
            <li class="form-line" id="Li5">
                <label class="form-label-left">
                    Mailing Address2:</label>
                <div id="Div2" class="form-input">
                    <asp:TextBox ID="tbMailingAddress2" runat="server" TextMode="MultiLine" class="form-textarea"
                        cols="40" Rows="4" />
                </div>
            </li>
            <li class="form-line" id="Li6">
                <label class="form-label-left">
                    Mailing Suburb:</label>
                <div id="Div3" class="form-input">
                    <asp:TextBox ID="tbMailingSuburb" runat="server" class="form-textarea" />
                </div>
            </li>
            <li class="form-line" id="Li7">
                <label class="form-label-left">
                    Mailing Postcode:</label>
                <div id="Div4" class="form-input">
                    <asp:TextBox ID="tbMailingPostcode" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li8">
                <label class="form-label-left">
                    Mailing State:</label>
                <div id="Div5" class="form-input">
                    <asp:TextBox ID="tbMailingState" runat="server" />
                </div>
            </li>
            <li class="form-line" id="Li10">
                <label class="form-label-left">
                    Mailing Country:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlMailingCountry" TabIndex="8" runat="server" class="form-dropdown">
                    </asp:DropDownList>
                </div>
            </li>
            <hr />
            <li class="form-line" id="admin-members-account-type">
                <label class="form-label-left">
                    Gender:</label>
                <div class="form-input">
                    <div class="form-single-column">
                        <asp:RadioButtonList ID="radlGender" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            runat="server" class="form-radio">
                            <asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:RadioButtonList>
                        <span class="clearfix"></span>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-members-date-of-birth">
                <label class="form-label-left">
                    Date of Birth:
                </label>
                <div class="form-input">
                    <span class="form-sub-label-container">
                        <asp:DropDownList ID="ddlDay" TabIndex="25" runat="server" class="noDefault form-textbox">
                        </asp:DropDownList>
                        -
                        <label class="form-sub-label" for="day_1" id="sublabel_day">
                            Day
                        </label>
                    </span><span class="form-sub-label-container">
                        <asp:DropDownList ID="ddlMonth" TabIndex="25" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        -
                        <label class="form-sub-label" for="month_1" id="sublabel_month">
                            Month
                        </label>
                    </span><span class="form-sub-label-container">
                        <asp:DropDownList ID="ddlYear" TabIndex="25" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CustomValidator ID="CusValDOB" runat="server" Display="Dynamic" OnServerValidate="CusValDOB_ServerValidate"
                            ErrorMessage="Invalid Date" SetFocusOnError="true" />
                        <label class="form-sub-label">
                            Year
                        </label>
                    </span><span class="form-sub-label-container">
                        <label class="form-sub-label">
                            &nbsp;&nbsp;&nbsp;
                        </label>
                    </span>
                </div>
            </li>
            <hr />
            <li class="form-line" id="admin-members-phone-home">
                <label class="form-label-left">
                    Phone (H):</label>
                <div class="form-input">
                    <asp:TextBox ID="txtHomePhone" runat="server" class="form-textbox" size="20" MaxLength="38" />
                </div>
            </li>
            <%--<li class="form-line" id="admin-members-phone-work">
                <label class="form-label-left">
                    Phone (W):</label>
                <div class="form-input">
                    <asp:TextBox ID="txtWorkPhone" runat="server" class="form-textbox" size="20" MaxLength="38" />
                </div>
            </li>--%>
            <li class="form-line" id="admin-members-mobile">
                <label class="form-label-left">
                    Mobile:</label>
                <div class="form-input">
                    <asp:TextBox ID="txtMobilePhone" runat="server" class="form-textbox" size="20" MaxLength="38" />
                </div>
            </li>
            <hr />
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Passport Number:
                </label>
                <div class="form-input">
                    <asp:TextBox ID="tbPassportNo" runat="server" class="form-textbox" size="20" />
                </div>
            </li>
            <asp:PlaceHolder ID="phLanguage" runat="server" Visible="false">
                <li class="form-line" id="Li12">
                    <label class="form-label-left">
                        Preferred email language:</label>
                    <div class="form-input">
                        <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                    </div>
                </li>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phExternalID" runat="server" Visible="false">
                <li class="form-line" id="Li3">
                    <label class="form-label-left">
                        External ID</label>
                    <div class="form-input">
                        <asp:Literal ID="ltExternalID" runat="server" />
                    </div>
                </li>
            </asp:PlaceHolder>
            <hr />
            <%--<h3 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltucMemberSearchCriteria" runat="server" SetLanguageCode="LabelSearchCriteria" />
            </h3>
            
            <li class="form-line" id="admin-members-country-type">
                <label id="Label1" class="form-label-left" runat="server">
                    Country:</label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlCountry" TabIndex="11" runat="server" AutoPostBack="True"
                        class="form-dropdown" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                </div>
            </li>
            <li class="form-line" id="admin-members-Location">
                <label id="Label2" class="form-label-left" runat="server">
                    Location:</label>
                <div class="form-input">
                    <asp:UpdatePanel ID="upLocation" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlLocation" TabIndex="11" runat="server" AutoPostBack="True"
                                class="form-dropdown" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </li>
            <li class="form-line" id="admin-members-Area">
                <label id="Label3" class="form-label-left" runat="server">
                    Area:</label>
                <div class="form-input">
                    <asp:UpdatePanel ID="upArea" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlArea" TabIndex="11" runat="server" class="form-dropdown">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlLocation" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </li>
            <li class="form-line" id="admin-members-avail-status">
                <label class="form-label-left">
                    Available Status:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlAvailability" TabIndex="25" runat="server" class="form-dropdown">
                    </asp:DropDownList>
                </div>
            </li>
            <li class="form-line" id="admin-members-avail-date">
                <label class="form-label-left">
                    Availability Date:
                </label>
                <div class="form-input">
                    <span class="form-sub-label-container">
                        <asp:TextBox runat="server" ID="txtAvailabilityDate" Text='<%# Bind("AvailabilityFromDate", "{0:dd/MM/yyyy}") %>'
                            MaxLength="10" class="form-textbox" size="20"></asp:TextBox>
                        <asp:ImageButton ID="ibFirstApprovedDate" runat="server" SkinID="CalendarImageButton"
                            CausesValidation="False" />
                        <ajaxToolkit:CalendarExtender ID="cal_dataFirstApprovedDate" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtAvailabilityDate" PopupButtonID="ibFirstApprovedDate">
                        </ajaxToolkit:CalendarExtender>
                        <asp:CompareValidator ID="cvFirstApprovedDate" runat="server" ControlToValidate="txtAvailabilityDate"
                            Type="Date" Operator="DataTypeCheck" ErrorMessage="Invalid Date. "></asp:CompareValidator>
                        <asp:RangeValidator ID="rvFirstApprovedDate" runat="server" ControlToValidate="txtAvailabilityDate"
                            Type="Date" ErrorMessage='Date out of range.' Display="Dynamic">
                        </asp:RangeValidator>
                    </span>
                </div>
            </li>
            
            <li class="form-line" id="admin-members-salarytype">
                <label class="form-label-left">
                    Salary Type:</label>
                <div class="form-input">
                    <asp:DropDownList runat="server" ID="ddlSalary" DataTextField="SalaryTypeName" DataValueField="SalaryTypeID"
                    CssClass="form-multiple-column" />
                </div>
            </li>
            
            <li class="form-line" id="admin-members-desired-pay">
                <label class="form-label-left">
                    Desired Salary:
                </label>
                <div class="form-input">
                    <span class="form-sub-label-container">From
                        <span class="divSalaryCurrency"><asp:Literal ID="ltlLowerCurrency" runat="server" /></span>
                        <asp:TextBox ID="txtSalaryLowerBand" runat="server" size="10" CssClass="textInput numbersOnly"></asp:TextBox>
                    </span>
                    <span class="form-sub-label-container">To
                        
                        <span class="divSalaryCurrency"><asp:Literal ID="ltlUpperCurrency" runat="server" /></span>
                        <asp:TextBox ID="txtSalaryUpperBand" runat="server" size="10" CssClass="textInput numbersOnly"></asp:TextBox>
                    </span>
                </div>
            </li>
            <li class="form-line" id="admin-members-business-type">
                <label class="form-label-left">
                    Prefered Classification:</label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlprefClassification" TabIndex="25" runat="server" class="form-dropdown"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlprefClassification_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </li>
            <li class="form-line" id="admin-members-preferredSubClassification">
                <label class="form-label-left">
                    Prefered SubClassification:</label>
                <div class="form-input">
                    <asp:UpdatePanel ID="upSubClassification" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlprefSubClassification" TabIndex="25" runat="server" class="form-dropdown" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlprefClassification" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </li>--%>
            <li class="form-line" id="admin-members-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnLoginAsMember" runat="server" Text="Login as Member" CausesValidation="False"
                            CssClass="jxtadminbutton" Visible="false" OnClick="btnLoginAsMember_Click" />
                    </div>
                    <!--form-buttons-wrapper-->
                </div>
                <!--form-input-wide-->
            </li>
            <br />
            <br />
            <asp:GridView ID="grdJobAlert" runat="server" AutoGenerateColumns="false" AllowMultiColumnSorting="false"
                DefaultSortColumnName="" DefaultSortDirection="Ascending" GridLines="None" CellSpacing="1"
                AllowSorting="false" CellPadding="3" OnRowDeleting="grdJobAlert_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDeleteAlert" runat="server" OnClientClick="return confirm('Are you sure you want to unsubscribe this alert?');"
                                CommandName="Delete" CommandArgument='<%# Eval("JobAlertID") %>' CausesValidation="false">Unsubscribe</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="true" HeaderText="Alert ID" DataField="JobAlertID" SortExpression="JobAlertID" />
                    <asp:BoundField ReadOnly="true" HeaderText="Job Alert Name" DataField="JobAlertName" />
                    <asp:BoundField ReadOnly="true" HeaderText="Last Modified" DataField="LastModified"
                        DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField ReadOnly="true" HeaderText="Send Email Alerts" DataField="AlertActive" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:GridView ID="grdDoc" runat="server" OnSelectedIndexChanged="grdDoc_SelectedIndexChanged"
                AutoGenerateColumns="false" AllowMultiColumnSorting="false" DefaultSortColumnName=""
                DefaultSortDirection="Ascending" ExcelExportFileName="Export_Members.xls" GridLines="None"
                CellSpacing="1" CellPadding="3">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='/download.aspx?type=mf&id=<%# Eval("MemberFileID") %>'>Download</a></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="true" HeaderText="Document Name" DataField="MemberFileTitle"
                        SortExpression="MemberFileTitle" />
                    <asp:BoundField ReadOnly="true" HeaderText="Last Modified" DataField="LastModifiedDate"
                        SortExpression="LastModifiedDate" />
                    <%--<asp:BoundField HeaderText="Date Entered" DataField="LastModifiedDate" SortExpression="LastModifiedDate"
                        DataFormatString="{0:dd/MM/yyyy}" />--%>
                </Columns>
            </asp:GridView>
        </ul>
    </div>
    </span>
</asp:Content>
