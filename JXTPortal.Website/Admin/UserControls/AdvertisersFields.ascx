<%@ Control Language="C#" ClassName="AdvertisersFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="adv-accountsettings-field">
                <label class="form-label-left">
                    <strong>General Settings</strong></label>
                <div class="form-input">
                </div>
            </li>
            <li class="form-line" id="adv-advertiser-field">
                <label class="form-label-left">
                    Account Type:<span class="form-required">*</span></label>
                <div class="form-input">
                    <data:EntityDropDownList runat="server" ID="dataAdvertiserAccountTypeId" DataSourceID="AdvertiserAccountTypeDataSource"
                        DataTextField="AdvertiserAccountTypeName" DataValueField="AdvertiserAccountTypeID"
                        SelectedValue='<%# Bind("AdvertiserAccountTypeId") %>' AppendNullItem="true"
                        Required="true" NullItemText="< Please Choose ...>" CssClass="form-multiple-column" />
                    <data:AdvertiserAccountTypeDataSource ID="AdvertiserAccountTypeDataSource" runat="server"
                        SelectMethod="GetAll" />
                </div>
            </li>
            <li class="form-line" id="adv-accountstatus-field">
                <label class="form-label-left">
                    Account Status:<span class="form-required">*</span></label>
                <div class="form-input">
                    <data:EntityDropDownList runat="server" ID="dataAdvertiserAccountStatusID" DataSourceID="AdvertiserAccountStatusDataSource"
                        DataTextField="AdvertiserAccountStatusName" DataValueField="AdvertiserAccountStatusID"
                        SelectedValue='<%# Bind("AdvertiserAccountStatusId") %>' AppendNullItem="true"
                        Required="true" NullItemText="< Please Choose ...>" CssClass="form-multiple-column" />
                    <data:AdvertiserAccountStatusDataSource ID="AdvertiserAccountStatusDataSource" runat="server"
                        SelectMethod="GetAll" />
                </div>
            </li>
            <li class="form-line" id="adv-companyname-field">
                <label class="form-label-left">
                    Company Name:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataCompanyName" Text='<%# Bind("CompanyName") %>'
                        TextMode="SingleLine" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataCompanyName" runat="server" Display="Dynamic"
                        ControlToValidate="dataCompanyName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-businesstype-field">
                <label class="form-label-left">
                    Business Type:<span class="form-required">*</span></label>
                <div class="form-input">
                    <data:EntityDropDownList runat="server" ID="dataBusinessTypeId" DataSourceID="AdvertiserBusinessTypeDataSource"
                        DataTextField="AdvertiserBusinessTypeName" DataValueField="AdvertiserBusinessTypeID"
                        SelectedValue='<%# Bind("AdvertiserBusinessTypeId") %>' AppendNullItem="true"
                        Required="true" NullItemText="< Please Choose ...>" CssClass="form-multiple-column" />
                    <data:AdvertiserBusinessTypeDataSource ID="AdvertiserBusinessTypeDataSource" runat="server"
                        SelectMethod="GetAll" />
                </div>
            </li>
            <li class="form-line" id="adv-businessno-field">
                <label class="form-label-left">
                    Business Number</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataBusinessNumber" Text='<%# Bind("BusinessNumber") %>'
                        TextMode="SingleLine" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-noofemployees-field">
                <label class="form-label-left">
                    No Of Employees:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataNoOfEmployees" Text='<%# Bind("NoOfEmployees") %>'
                        MaxLength="10"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-contactdetails-field">
                <label class="form-label-left">
                    <strong>Contact Details</strong></label>
                <div class="form-input">
                </div>
            </li>
            <li class="form-line" id="adv-streetaddress1-field">
                <label class="form-label-left">
                    Street Address1:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataStreetAddress1" Text='<%# Bind("StreetAddress1") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-streetaddress2-field">
                <label class="form-label-left">
                    Street Address2:
                </label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataStreetAddress2" Text='<%# Bind("StreetAddress2") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-postaladdress1-field">
                <label class="form-label-left">
                    Postal Address1:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataPostalAddress1" Text='<%# Bind("PostalAddress1") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-postaladdress2-field">
                <label class="form-label-left">
                    Postal Address2:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataPostalAddress2" Text='<%# Bind("PostalAddress2") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-webaddress-field">
                <label class="form-label-left">
                    Web Address:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataWebAddress" Text='<%# Bind("WebAddress") %>'
                        TextMode="SingleLine" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-accountsettings-field">
                <label class="form-label-left">
                    <strong>Account Settings</strong></label>
                <div class="form-input">
                </div>
            </li>
            <li class="form-line" id="adv-accountpayableemail-field">
                <label class="form-label-left">
                    Accounts Payable Email:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataAccountsPayableEmail" Text='<%# Bind("AccountsPayableEmail") %>'
                        TextMode="SingleLine" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-requirelogon-field">
                <label class="form-label-left">
                    Require Logon For External Application:</label>
                <div class="form-input">
                    <asp:RadioButtonList runat="server" ID="dataRequireLogonForExternalApplication" SelectedValue='<%# Bind("RequireLogonForExternalApplication") %>'
                        RepeatDirection="Horizontal" CssClass="form-radio-column">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </li>
            <li class="form-line" id="adv-firstapproveddate-field">
                <label class="form-label-left">
                    First Approved Date:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataFirstApprovedDate" Text='<%# Bind("FirstApprovedDate", "{0:"+ JXTPortal.Entities.SessionData.Site.DateFormat +"}") %>'
                        MaxLength="10"></asp:TextBox>
                    <asp:ImageButton ID="ibFirstApprovedDate" runat="server" SkinID="CalendarImageButton"
                        CausesValidation="False" />
                    <ajaxToolkit:CalendarExtender ID="cal_dataFirstApprovedDate" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="dataFirstApprovedDate" PopupButtonID="ibFirstApprovedDate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:CompareValidator ID="cvFirstApprovedDate" runat="server" ControlToValidate="dataFirstApprovedDate"
                        Type="Date" Operator="DataTypeCheck" ErrorMessage="Invalid Date. "></asp:CompareValidator>
                    <asp:RangeValidator ID="rvFirstApprovedDate" runat="server" ControlToValidate="dataFirstApprovedDate"
                        Type="Date" MinimumValue='<%# System.Data.SqlTypes.SqlDateTime.MinValue.Value.ToString("yyyy-MM-dd") %>'
                        MaximumValue='<%# new DateTime(DateTime.Now.Year + 100, 12, 31).ToString("yyyy-MM-dd") %>'
                        ErrorMessage='Date out of range.'></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="adv-profile-field">
                <label class="form-label-left">
                    Profile:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataProfile" Text='<%# Bind("Profile") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-freetrialstartdate-field">
                <label class="form-label-left">
                    Free Trial Start Date:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataFreeTrialStartDate" Text='<%# Bind("FreeTrialStartDate", "{0:dd/MM/yyyy}") %>'
                        MaxLength="10"></asp:TextBox>
                    <asp:ImageButton ID="ibFreeTrialStartDate" runat="server" SkinID="CalendarImageButton"
                        CausesValidation="False" />
                    <ajaxToolkit:CalendarExtender ID="cal_dataFreeTrialStartDate" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="dataFreeTrialStartDate" PopupButtonID="ibFreeTrialStartDate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:CompareValidator ID="cvFreeTrialStartDate" runat="server" ControlToValidate="dataFreeTrialStartDate"
                        Type="Date" Operator="DataTypeCheck" ErrorMessage="Invalid Date. "></asp:CompareValidator>
                    <asp:RangeValidator ID="rvFreeTrialStartDate" runat="server" ControlToValidate="dataFreeTrialStartDate"
                        Type="Date" MinimumValue='<%# System.Data.SqlTypes.SqlDateTime.MinValue.Value.ToString("yyyy-MM-dd") %>'
                        MaximumValue='<%# new DateTime(DateTime.Now.Year + 100, 12, 31).ToString("yyyy-MM-dd"); %>'
                        ErrorMessage='Date out of range.'></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="adv-freetrialenddate-field">
                <label class="form-label-left">
                    Free Trial End Date:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataFreeTrialEndDate" Text='<%# Bind("FreeTrialEndDate", "{0:dd/MM/yyyy}") %>'
                        MaxLength="10"></asp:TextBox>
                    <asp:ImageButton ID="ibFreeTrialEndDate" runat="server" SkinID="CalendarImageButton"
                        CausesValidation="False" />
                    <ajaxToolkit:CalendarExtender ID="cal_dataFreeTrialEndDate" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="dataFreeTrialEndDate" PopupButtonID="ibFreeTrialEndDate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:CompareValidator ID="cvFreeTrialEndDate" runat="server" ControlToValidate="dataFreeTrialEndDate"
                        Type="Date" Operator="DataTypeCheck" ErrorMessage="Invalid Date. "></asp:CompareValidator>
                    <asp:RangeValidator ID="rvFreeTrialEndDate" runat="server" ControlToValidate="dataFreeTrialEndDate"
                        Type="Date" MinimumValue='<%# System.Data.SqlTypes.SqlDateTime.MinValue.Value.ToString("yyyy-MM-dd") %>'
                        MaximumValue='<%# new DateTime(DateTime.Now.Year + 100, 12, 31).ToString("yyyy-MM-dd"); %>'
                        ErrorMessage='Date out of range.'></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="adv-lastmodified-field">
                <label class="form-label-left">
                    Last Modified:</label>
                <div class="form-input">
                    <asp:Label runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label>
                </div>
            </li>
        </ul>
    </ItemTemplate>
</asp:FormView>
