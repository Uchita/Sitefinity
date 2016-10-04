<%@ Control Language="C#" ClassName="AdvertiserUsersFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="adv-advertiser-field">
                <label class="form-label-left">
                    Advertiser:<span class="form-required">*</span></label>
                <div class="form-input">
                    <data:EntityDropDownList runat="server" ID="dataAdvertiserId" DataSourceID="AdvertiserIdAdvertisersDataSource"
                        DataTextField="CompanyName" DataValueField="AdvertiserId" SelectedValue='<%# Bind("AdvertiserId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required"
                        CssClass="form-multiple-column" />
                    <data:AdvertisersDataSource ID="AdvertiserIdAdvertisersDataSource" runat="server"
                        SelectMethod="GetAll" />
                </div>
            </li>
            <li class="form-line" id="adv-primaryaccount-field">
                <label class="form-label-left">
                    Primary Account:</label>
                <div class="form-input">
                    <asp:RadioButtonList runat="server" ID="dataPrimaryAccount" SelectedValue='<%# Bind("PrimaryAccount") %>'
                        RepeatDirection="Horizontal" CssClass="form-radio-column">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </li>
            <li class="form-line" id="adv-username-field">
                <label class="form-label-left">
                    User Name:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName"
                            runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CusVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName"
                        ErrorMessage="User Name already exists"></asp:CustomValidator>
                </div>
            </li>
            <li class="form-line" id="adv-userpassword-field">
                <label class="form-label-left">
                    User Password:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataUserPassword" TextMode="Password" Width="250px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataUserPassword" runat="server" Display="Dynamic" ControlToValidate="dataUserPassword"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hfUserPassword" runat="server" Value='<%# Bind("UserPassword") %>' />
                </div>
            </li>
            <li class="form-line" id="adv-confirmpassword-field">
                <label class="form-label-left">
                    Confirm Password:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataConfirmPassword" TextMode="Password" Width="250px"></asp:TextBox><asp:CustomValidator
                        ID="CusVal_dataConfirmPassword" runat="server" Display="Dynamic" ControlToValidate="dataUserPassword"
                        ErrorMessage="Confirm Password does not match"></asp:CustomValidator>
                </div>
            </li>
            <li class="form-line" id="adv-firstname-field">
                <label class="form-label-left">
                    First Name:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataFirstName" Text='<%# Bind("FirstName") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFirstName"
                            runat="server" Display="Dynamic" ControlToValidate="dataFirstName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-surname-field">
                <label class="form-label-left">
                    Surname:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataSurname" Text='<%# Bind("Surname") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSurname" runat="server"
                            Display="Dynamic" ControlToValidate="dataSurname" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-email-field">
                <label class="form-label-left">
                    Email:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmail" runat="server"
                            Display="Dynamic" ControlToValidate="dataEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="adv-applicationemailaddress-field">
                <label class="form-label-left">
                    Application Email Address:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataApplicationEmailAddress" Text='<%# Bind("ApplicationEmailAddress") %>'
                        TextMode="SingleLine" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-phone-field">
                <label class="form-label-left">
                    Phone:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>' MaxLength="40"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-fax-field">
                <label class="form-label-left">
                    Fax:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataFax" Text='<%# Bind("Fax") %>' MaxLength="40"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-accountstatus-field">
                <label class="form-label-left">
                    Account Status:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataAccountStatus" Text='<%# Bind("AccountStatus") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataAccountStatus" runat="server" Display="Dynamic" ControlToValidate="dataAccountStatus"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="adv-newsletter-field">
                <label class="form-label-left">
                    Newsletter:</label>
                <div class="form-input">
                    <asp:RadioButtonList runat="server" ID="dataNewsletter" SelectedValue='<%# Bind("Newsletter") %>'
                        RepeatDirection="Horizontal" CssClass="form-radio-column">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </li>
            <li class="form-line" id="adv-newsletterformat-field">
                <label class="form-label-left">
                    Newsletter Format:<span class="form-required">*</span></label>
                <div class="form-input">
                    <data:EntityDropDownList runat="server" ID="dataNewsletterFormat" DataSourceID="NewsletterFormatEmailFormatsDataSource"
                        DataTextField="EmailFormatName" DataValueField="EmailFormatId" SelectedValue='<%# Bind("NewsletterFormat") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required"
                        CssClass="form-multiple-column" />
                    <data:EmailFormatsDataSource ID="NewsletterFormatEmailFormatsDataSource" runat="server"
                        SelectMethod="GetAll" />
                </div>
            </li>
            <li class="form-line" id="adv-emailformat-field">
                <label class="form-label-left">
                    Email Format:<span class="form-required">*</span></label>
                <div class="form-input">
                    <data:EntityDropDownList runat="server" ID="dataEmailFormat" DataSourceID="EmailFormatEmailFormatsDataSource"
                        DataTextField="EmailFormatName" DataValueField="EmailFormatId" SelectedValue='<%# Bind("EmailFormat") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:EmailFormatsDataSource ID="EmailFormatEmailFormatsDataSource" runat="server"
                        SelectMethod="GetAll" />
                </div>
            </li>
            <li class="form-line" id="adv-validated-field">
                <label class="form-label-left">
                    Validated:</label>
                <div class="form-input">
                    <asp:RadioButtonList runat="server" ID="dataValidated" SelectedValue='<%# Bind("Validated") %>'
                        RepeatDirection="Horizontal" CssClass="form-radio-column">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </li>
            <li class="form-line" id="adv-description-field">
                <label class="form-label-left">
                    Description:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="adv-lastlogondate-field">
                <label class="form-label-left">
                    Last Login Date:</label>
                <div class="form-input">
                    <asp:Label runat="server" ID="dataLastLoginDate" Text='<%# Bind("LastLoginDate", "{0:dd/MM/yyyy hh:mm:ss tt}") %>'
                        MaxLength="10"></asp:Label>
                </div>
            </li>
            <li class="form-line" id="adv-lastmodified-field">
                <label class="form-label-left">
                    Last Modified:</label>
                <div class="form-input">
                    <asp:Label runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:dd/MM/yyyy hh:mm:ss tt}") %>'
                        MaxLength="10"></asp:Label>
                </div>
            </li>
            <li class="form-line" id="adv-modfifiedby-field">
                <label class="form-label-left">
                    Modified By:</label>
                <div class="form-input">
                    <asp:Label runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:dd/MM/yyyy hh:mm:ss tt}") %>'
                        MaxLength="10"></asp:Label>
                </div>
            </li>
        </ul>
    </ItemTemplate>
</asp:FormView>
