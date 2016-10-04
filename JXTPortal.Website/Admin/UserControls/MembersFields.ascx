<%@ Control Language="C#" ClassName="MembersFields" %>

<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>       
     
        <ul class="form-section">
        
            <li class="form-line" id="admin-members-Usernamefield">
                <label class="form-label-left">Username:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataUsername" Text='<%# Bind("Username") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataUsername" runat="server" Display="Dynamic" 
                    ControlToValidate="dataUsername" ErrorMessage="Required"></asp:RequiredFieldValidator>                    
                </div>
            </li>
            
            <%--<li class="form-line" id="admin-members-Passwordfield">
                <label class="form-label-left">Password:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Username") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataPassword" runat="server" Display="Dynamic" 
                    ControlToValidate="dataPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>                    
                </div>
            </li>--%>
            
            <li class="form-line" id="admin-members-Titlefield">
                <label class="form-label-left">Title:</label>
                <div class="form-input">
                    <%--<asp:TextBox runat="server" ID="dataTitle" Text='<%# Bind("Title") %>' TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>--%>
                    <data:EntityDropDownList runat="server" ID="dataTitle" DataSourceID="MembersDataSource"
                        DataTextField="Title" DataValueField="MemberID" SelectedValue='<%# Bind("Title") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" CssClass="form-multiple-column" />
                    
                </div>
            </li>
            
            
            <%--<tr>
                <td class="literal">
                    <asp:Label ID="lbldataTitle" runat="server" Text="Title:" AssociatedControlID="dataTitle" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataTitle" Text='<%# Bind("Title") %>' MaxLength="100"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEmailAddress" runat="server" Text="Email Address:" AssociatedControlID="dataEmailAddress" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataEmailAddress" Text='<%# Bind("EmailAddress") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_dataEmailAddress" runat="server" Display="Dynamic" ControlToValidate="dataEmailAddress"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCompany" runat="server" Text="Company:" AssociatedControlID="dataCompany" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataCompany" Text='<%# Bind("Company") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPosition" runat="server" Text="Position:" AssociatedControlID="dataPosition" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPosition" Text='<%# Bind("Position") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataHomePhone" runat="server" Text="Home Phone:" AssociatedControlID="dataHomePhone" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataHomePhone" Text='<%# Bind("HomePhone") %>' MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataWorkPhone" runat="server" Text="Work Phone:" AssociatedControlID="dataWorkPhone" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataWorkPhone" Text='<%# Bind("WorkPhone") %>' MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataMobilePhone" runat="server" Text="Mobile Phone:" AssociatedControlID="dataMobilePhone" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataMobilePhone" Text='<%# Bind("MobilePhone") %>'
                        MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFax" runat="server" Text="Fax:" AssociatedControlID="dataFax" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataFax" Text='<%# Bind("Fax") %>' MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAddress1" runat="server" Text="Address1:" AssociatedControlID="dataAddress1" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAddress1" Text='<%# Bind("Address1") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAddress2" runat="server" Text="Address2:" AssociatedControlID="dataAddress2" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAddress2" Text='<%# Bind("Address2") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLocationId" runat="server" Text="Location Id:" AssociatedControlID="dataLocationId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataLocationId" Text='<%# Bind("LocationId") %>'></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataLocationId" runat="server" Display="Dynamic" ControlToValidate="dataLocationId"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataLocationId"
                            runat="server" Display="Dynamic" ControlToValidate="dataLocationId" ErrorMessage="Invalid value"
                            MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAreaId" runat="server" Text="Area Id:" AssociatedControlID="dataAreaId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAreaId" Text='<%# Bind("AreaId") %>'></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataAreaId" runat="server" Display="Dynamic" ControlToValidate="dataAreaId"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAreaId"
                            runat="server" Display="Dynamic" ControlToValidate="dataAreaId" ErrorMessage="Invalid value"
                            MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            
            <tr>
                <td class="literal">
                    <asp:Label ID="lblCountries" runat="server" Text="Country:" AssociatedControlID="dataCountry" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataCountry" DataSourceID="CountriesDataSource"
                        DataTextField="CountryName" DataValueField="CountryID" SelectedValue='<%# Bind("CountryID") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:CountriesDataSource ID="CountriesDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
            
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredCategoryId" runat="server" Text="Preferred Category Id:"
                        AssociatedControlID="dataPreferredCategoryId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredCategoryId" Text='<%# Bind("PreferredCategoryId") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataPreferredCategoryId" runat="server" Display="Dynamic" ControlToValidate="dataPreferredCategoryId"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredSubCategoryId" runat="server" Text="Preferred Sub Category Id:"
                        AssociatedControlID="dataPreferredSubCategoryId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredSubCategoryId" Text='<%# Bind("PreferredSubCategoryId") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataPreferredSubCategoryId" runat="server" Display="Dynamic" ControlToValidate="dataPreferredSubCategoryId"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredSalaryId" runat="server" Text="Preferred Salary Id:"
                        AssociatedControlID="dataPreferredSalaryId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredSalaryId" Text='<%# Bind("PreferredSalaryId") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataPreferredSalaryId" runat="server" Display="Dynamic" ControlToValidate="dataPreferredSalaryId"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSubscribed" runat="server" Text="Subscribed:" AssociatedControlID="dataSubscribed" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataSubscribed" SelectedValue='<%# Bind("Subscribed") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataMonthlyUpdate" runat="server" Text="Monthly Update:" AssociatedControlID="dataMonthlyUpdate" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataMonthlyUpdate" SelectedValue='<%# Bind("MonthlyUpdate") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataReferringMemberId" runat="server" Text="Referring Member Id:"
                        AssociatedControlID="dataReferringMemberId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataReferringMemberId" Text='<%# Bind("ReferringMemberId") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataReferringMemberId" runat="server" Display="Dynamic" ControlToValidate="dataReferringMemberId"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModifiedDate" runat="server" Text="Last Modified Date:"
                        AssociatedControlID="dataLastModifiedDate" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataLastModifiedDate" Text='<%# Bind("LastModifiedDate", "{0:d}") %>'
                        MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModifiedDate" runat="server"
                            SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEmailFormat" runat="server" Text="Email Format:" AssociatedControlID="dataEmailFormat" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataEmailFormat" DataSourceID="EmailFormatEmailFormatsDataSource"
                        DataTextField="EmailFormatName" DataValueField="EmailFormatId" SelectedValue='<%# Bind("EmailFormat") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:EmailFormatsDataSource ID="EmailFormatEmailFormatsDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
            
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastLogon" runat="server" Text="Last Logon:" AssociatedControlID="dataLastLogon" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataLastLogon" Text='<%# Bind("LastLogon", "{0:d}") %>'
                        MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastLogon" runat="server"
                            SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDateOfBirth" runat="server" Text="Date Of Birth:" AssociatedControlID="dataDateOfBirth" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataDateOfBirth" Text='<%# Bind("DateOfBirth", "{0:d}") %>'
                        MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateOfBirth" runat="server"
                            SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataGender" runat="server" Text="Gender:" AssociatedControlID="dataGender" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataGender" Text='<%# Bind("Gender") %>' MaxLength="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataTags" runat="server" Text="Tags:" AssociatedControlID="dataTags" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataTags" Text='<%# Bind("Tags") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataValidated" runat="server" Text="Validated:" AssociatedControlID="dataValidated" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataValidated" SelectedValue='<%# Bind("Validated") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataMemberUrlExtension" runat="server" Text="Member Url Extension:"
                        AssociatedControlID="dataMemberUrlExtension" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataMemberUrlExtension" Text='<%# Bind("MemberUrlExtension") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataWebsiteUrl" runat="server" Text="Website Url:" AssociatedControlID="dataWebsiteUrl" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataWebsiteUrl" Text='<%# Bind("WebsiteUrl") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAvailabilityId" runat="server" Text="Availability Id:" AssociatedControlID="dataAvailabilityId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAvailabilityId" Text='<%# Bind("AvailabilityId") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataAvailabilityId" runat="server" Display="Dynamic" ControlToValidate="dataAvailabilityId"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAvailabilityFromDate" runat="server" Text="Availability From Date:"
                        AssociatedControlID="dataAvailabilityFromDate" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAvailabilityFromDate" Text='<%# Bind("AvailabilityFromDate", "{0:d}") %>'
                        MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataAvailabilityFromDate" runat="server"
                            SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataMySpaceHeading" runat="server" Text="My Space Heading:" AssociatedControlID="dataMySpaceHeading" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataMySpaceHeading" Text='<%# Bind("MySpaceHeading") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataMySpaceContent" runat="server" Text="My Space Content:" AssociatedControlID="dataMySpaceContent" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataMySpaceContent" Text='<%# Bind("MySpaceContent") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUrlReferrer" runat="server" Text="Url Referrer:" AssociatedControlID="dataUrlReferrer" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataUrlReferrer" Text='<%# Bind("UrlReferrer") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataRequiredPasswordChange" runat="server" Text="Required Password Change:"
                        AssociatedControlID="dataRequiredPasswordChange" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataRequiredPasswordChange" SelectedValue='<%# Bind("RequiredPasswordChange") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredJobTitle" runat="server" Text="Preferred Job Title:"
                        AssociatedControlID="dataPreferredJobTitle" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredJobTitle" Text='<%# Bind("PreferredJobTitle") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredAvailability" runat="server" Text="Preferred Availability:"
                        AssociatedControlID="dataPreferredAvailability" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredAvailability" Text='<%# Bind("PreferredAvailability") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredAvailabilityType" runat="server" Text="Preferred Availability Type:"
                        AssociatedControlID="dataPreferredAvailabilityType" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredAvailabilityType" Text='<%# Bind("PreferredAvailabilityType") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataPreferredAvailabilityType" runat="server" Display="Dynamic"
                        ControlToValidate="dataPreferredAvailabilityType" ErrorMessage="Invalid value"
                        MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredSalaryFrom" runat="server" Text="Preferred Salary From:"
                        AssociatedControlID="dataPreferredSalaryFrom" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredSalaryFrom" Text='<%# Bind("PreferredSalaryFrom") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPreferredSalaryTo" runat="server" Text="Preferred Salary To:"
                        AssociatedControlID="dataPreferredSalaryTo" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataPreferredSalaryTo" Text='<%# Bind("PreferredSalaryTo") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCurrentSalaryFrom" runat="server" Text="Current Salary From:"
                        AssociatedControlID="dataCurrentSalaryFrom" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataCurrentSalaryFrom" Text='<%# Bind("CurrentSalaryFrom") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCurrentSalaryTo" runat="server" Text="Current Salary To:" AssociatedControlID="dataCurrentSalaryTo" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataCurrentSalaryTo" Text='<%# Bind("CurrentSalaryTo") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLookingFor" runat="server" Text="Looking For:" AssociatedControlID="dataLookingFor" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataLookingFor" Text='<%# Bind("LookingFor") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataExperience" runat="server" Text="Experience:" AssociatedControlID="dataExperience" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataExperience" Text='<%# Bind("Experience") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSkills" runat="server" Text="Skills:" AssociatedControlID="dataSkills" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataSkills" Text='<%# Bind("Skills") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataReasons" runat="server" Text="Reasons:" AssociatedControlID="dataReasons" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataReasons" Text='<%# Bind("Reasons") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataComments" runat="server" Text="Comments:" AssociatedControlID="dataComments" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataComments" Text='<%# Bind("Comments") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataProfileType" runat="server" Text="Profile Type:" AssociatedControlID="dataProfileType" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataProfileType" Text='<%# Bind("ProfileType") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
        </ul>    
    </ItemTemplate>
</asp:FormView>
