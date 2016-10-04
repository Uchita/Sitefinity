<%@ Control Language="C#" ClassName="JobAlertsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobAlertName" runat="server" Text="Job Alert Name:" AssociatedControlID="dataJobAlertName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataJobAlertName" Text='<%# Bind("JobAlertName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSearchKeywords" runat="server" Text="Search Keywords:" AssociatedControlID="dataSearchKeywords" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSearchKeywords" Text='<%# Bind("SearchKeywords") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRecurrenceType" runat="server" Text="Recurrence Type:" AssociatedControlID="dataRecurrenceType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRecurrenceType" Text='<%# Bind("RecurrenceType") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRecurrenceType" runat="server" Display="Dynamic" ControlToValidate="dataRecurrenceType" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDailyFrequency" runat="server" Text="Daily Frequency:" AssociatedControlID="dataDailyFrequency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDailyFrequency" Text='<%# Bind("DailyFrequency") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDailyFrequency" runat="server" Display="Dynamic" ControlToValidate="dataDailyFrequency" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeeklyFrequency" runat="server" Text="Weekly Frequency:" AssociatedControlID="dataWeeklyFrequency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWeeklyFrequency" Text='<%# Bind("WeeklyFrequency") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWeeklyFrequency" runat="server" Display="Dynamic" ControlToValidate="dataWeeklyFrequency" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeeklyDayOccurence" runat="server" Text="Weekly Day Occurence:" AssociatedControlID="dataWeeklyDayOccurence" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWeeklyDayOccurence" Text='<%# Bind("WeeklyDayOccurence") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWeeklyDayOccurence" runat="server" Display="Dynamic" ControlToValidate="dataWeeklyDayOccurence" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateLastRun" runat="server" Text="Date Last Run:" AssociatedControlID="dataDateLastRun" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateLastRun" Text='<%# Bind("DateLastRun", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateLastRun" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateNextRun" runat="server" Text="Date Next Run:" AssociatedControlID="dataDateNextRun" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateNextRun" Text='<%# Bind("DateNextRun", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateNextRun" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMemberId" runat="server" Text="Member Id:" AssociatedControlID="dataMemberId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataMemberId" DataSourceID="MemberIdMembersDataSource" DataTextField="Username" DataValueField="MemberId" SelectedValue='<%# Bind("MemberId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:MembersDataSource ID="MemberIdMembersDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAlertActive" runat="server" Text="Alert Active:" AssociatedControlID="dataAlertActive" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataAlertActive" SelectedValue='<%# Bind("AlertActive") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailFormat" runat="server" Text="Email Format:" AssociatedControlID="dataEmailFormat" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmailFormat" Text='<%# Bind("EmailFormat") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataEmailFormat" runat="server" Display="Dynamic" ControlToValidate="dataEmailFormat" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomRecurrenceType" runat="server" Text="Custom Recurrence Type:" AssociatedControlID="dataCustomRecurrenceType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomRecurrenceType" Text='<%# Bind("CustomRecurrenceType") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCustomRecurrenceType" runat="server" Display="Dynamic" ControlToValidate="dataCustomRecurrenceType" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastResultCount" runat="server" Text="Last Result Count:" AssociatedControlID="dataLastResultCount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastResultCount" Text='<%# Bind("LastResultCount") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLastResultCount" runat="server" Display="Dynamic" ControlToValidate="dataLastResultCount" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrimaryAlert" runat="server" Text="Primary Alert:" AssociatedControlID="dataPrimaryAlert" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPrimaryAlert" SelectedValue='<%# Bind("PrimaryAlert") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnsubscribeValidateId" runat="server" Text="Unsubscribe Validate Id:" AssociatedControlID="dataUnsubscribeValidateId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataUnsubscribeValidateId" Value='<%# Bind("UnsubscribeValidateId") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEditValidateId" runat="server" Text="Edit Validate Id:" AssociatedControlID="dataEditValidateId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataEditValidateId" Value='<%# Bind("EditValidateId") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataViewValidateId" runat="server" Text="View Validate Id:" AssociatedControlID="dataViewValidateId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataViewValidateId" Value='<%# Bind("ViewValidateId") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteId" runat="server" Text="Site Id:" AssociatedControlID="dataSiteId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSiteId" DataSourceID="SiteIdSitesDataSource" DataTextField="SiteName" DataValueField="SiteId" SelectedValue='<%# Bind("SiteId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SitesDataSource ID="SiteIdSitesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountryId" runat="server" Text="Country Id:" AssociatedControlID="dataCountryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountryId" DataSourceID="CountryIdCountriesDataSource" DataTextField="CountryName" DataValueField="CountryId" SelectedValue='<%# Bind("CountryId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CountriesDataSource ID="CountryIdCountriesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocationId" runat="server" Text="Location Id:" AssociatedControlID="dataLocationId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLocationId" DataSourceID="LocationIdLocationDataSource" DataTextField="LocationName" DataValueField="LocationId" SelectedValue='<%# Bind("LocationId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:LocationDataSource ID="LocationIdLocationDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAreaIds" runat="server" Text="Area Ids:" AssociatedControlID="dataAreaIds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAreaIds" Text='<%# Bind("AreaIds") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProfessionId" runat="server" Text="Profession Id:" AssociatedControlID="dataProfessionId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProfessionId" DataSourceID="ProfessionIdProfessionDataSource" DataTextField="ProfessionName" DataValueField="ProfessionId" SelectedValue='<%# Bind("ProfessionId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ProfessionDataSource ID="ProfessionIdProfessionDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSearchRoleIds" runat="server" Text="Search Role Ids:" AssociatedControlID="dataSearchRoleIds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSearchRoleIds" Text='<%# Bind("SearchRoleIds") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWorkTypeIds" runat="server" Text="Work Type Ids:" AssociatedControlID="dataWorkTypeIds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWorkTypeIds" Text='<%# Bind("WorkTypeIds") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalaryIds" runat="server" Text="Salary Ids:" AssociatedControlID="dataSalaryIds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalaryIds" Text='<%# Bind("SalaryIds") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDaysPosted" runat="server" Text="Days Posted:" AssociatedControlID="dataDaysPosted" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDaysPosted" Text='<%# Bind("DaysPosted") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDaysPosted" runat="server" Display="Dynamic" ControlToValidate="dataDaysPosted" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGeneratedSql" runat="server" Text="Generated Sql:" AssociatedControlID="dataGeneratedSql" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGeneratedSql" Text='<%# Bind("GeneratedSql") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


