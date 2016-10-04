<%@ Control Language="C#" ClassName="MemberWizardFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteId" runat="server" Text="Site Id:" AssociatedControlID="dataSiteId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSiteId" DataSourceID="SiteIdSitesDataSource" DataTextField="SiteName" DataValueField="SiteId" SelectedValue='<%# Bind("SiteId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:SitesDataSource ID="SiteIdSitesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMemberWizardParentId" runat="server" Text="Member Wizard Parent Id:" AssociatedControlID="dataMemberWizardParentId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMemberWizardParentId" Text='<%# Bind("MemberWizardParentId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMemberWizardParentId" runat="server" Display="Dynamic" ControlToValidate="dataMemberWizardParentId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProfileTitle" runat="server" Text="Profile Title:" AssociatedControlID="dataProfileTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProfileTitle" Text='<%# Bind("ProfileTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProfileTitle" runat="server" Display="Dynamic" ControlToValidate="dataProfileTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCvTitle" runat="server" Text="Cv Title:" AssociatedControlID="dataCvTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCvTitle" Text='<%# Bind("CvTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCvTitle" runat="server" Display="Dynamic" ControlToValidate="dataCvTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRolePreferencesTitle" runat="server" Text="Role Preferences Title:" AssociatedControlID="dataRolePreferencesTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRolePreferencesTitle" Text='<%# Bind("RolePreferencesTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRolePreferencesTitle" runat="server" Display="Dynamic" ControlToValidate="dataRolePreferencesTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEducationTitle" runat="server" Text="Education Title:" AssociatedControlID="dataEducationTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEducationTitle" Text='<%# Bind("EducationTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEducationTitle" runat="server" Display="Dynamic" ControlToValidate="dataEducationTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMembershipsTitle" runat="server" Text="Memberships Title:" AssociatedControlID="dataMembershipsTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMembershipsTitle" Text='<%# Bind("MembershipsTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMembershipsTitle" runat="server" Display="Dynamic" ControlToValidate="dataMembershipsTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExperienceTitle" runat="server" Text="Experience Title:" AssociatedControlID="dataExperienceTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExperienceTitle" Text='<%# Bind("ExperienceTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExperienceTitle" runat="server" Display="Dynamic" ControlToValidate="dataExperienceTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSkillsTitle" runat="server" Text="Skills Title:" AssociatedControlID="dataSkillsTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSkillsTitle" Text='<%# Bind("SkillsTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSkillsTitle" runat="server" Display="Dynamic" ControlToValidate="dataSkillsTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProfileEnable" runat="server" Text="Profile Enable:" AssociatedControlID="dataProfileEnable" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataProfileEnable" SelectedValue='<%# Bind("ProfileEnable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCvEnable" runat="server" Text="Cv Enable:" AssociatedControlID="dataCvEnable" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataCvEnable" SelectedValue='<%# Bind("CvEnable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRolePreferencesEnable" runat="server" Text="Role Preferences Enable:" AssociatedControlID="dataRolePreferencesEnable" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataRolePreferencesEnable" SelectedValue='<%# Bind("RolePreferencesEnable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEducationEnable" runat="server" Text="Education Enable:" AssociatedControlID="dataEducationEnable" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEducationEnable" SelectedValue='<%# Bind("EducationEnable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMembershipsEnable" runat="server" Text="Memberships Enable:" AssociatedControlID="dataMembershipsEnable" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataMembershipsEnable" SelectedValue='<%# Bind("MembershipsEnable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExperienceEnable" runat="server" Text="Experience Enable:" AssociatedControlID="dataExperienceEnable" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataExperienceEnable" SelectedValue='<%# Bind("ExperienceEnable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSkillsEnable" runat="server" Text="Skills Enable:" AssociatedControlID="dataSkillsEnable" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSkillsEnable" SelectedValue='<%# Bind("SkillsEnable") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGlobalTemplate" runat="server" Text="Global Template:" AssociatedControlID="dataGlobalTemplate" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataGlobalTemplate" SelectedValue='<%# Bind("GlobalTemplate") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModifiedBy" runat="server" Text="Last Modified By:" AssociatedControlID="dataLastModifiedBy" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLastModifiedBy" DataSourceID="LastModifiedByAdminUsersDataSource" DataTextField="UserName" DataValueField="AdminUserId" SelectedValue='<%# Bind("LastModifiedBy") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AdminUsersDataSource ID="LastModifiedByAdminUsersDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


