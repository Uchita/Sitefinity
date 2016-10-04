<%@ Control Language="C#" ClassName="GlobalSettingsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublicJobsSearch" runat="server" Text="Public Jobs Search:" AssociatedControlID="dataPublicJobsSearch" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPublicJobsSearch" SelectedValue='<%# Bind("PublicJobsSearch") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublicMembersSearch" runat="server" Text="Public Members Search:" AssociatedControlID="dataPublicMembersSearch" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPublicMembersSearch" SelectedValue='<%# Bind("PublicMembersSearch") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublicCompaniesSearch" runat="server" Text="Public Companies Search:" AssociatedControlID="dataPublicCompaniesSearch" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPublicCompaniesSearch" SelectedValue='<%# Bind("PublicCompaniesSearch") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPublicSponsoredAdverts" runat="server" Text="Public Sponsored Adverts:" AssociatedControlID="dataPublicSponsoredAdverts" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPublicSponsoredAdverts" SelectedValue='<%# Bind("PublicSponsoredAdverts") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrivateJobs" runat="server" Text="Private Jobs:" AssociatedControlID="dataPrivateJobs" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPrivateJobs" SelectedValue='<%# Bind("PrivateJobs") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrivateMembers" runat="server" Text="Private Members:" AssociatedControlID="dataPrivateMembers" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPrivateMembers" SelectedValue='<%# Bind("PrivateMembers") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrivateCompanies" runat="server" Text="Private Companies:" AssociatedControlID="dataPrivateCompanies" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPrivateCompanies" SelectedValue='<%# Bind("PrivateCompanies") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPageTitlePrefix" runat="server" Text="Page Title Prefix:" AssociatedControlID="dataPageTitlePrefix" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPageTitlePrefix" Text='<%# Bind("PageTitlePrefix") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPageTitleSuffix" runat="server" Text="Page Title Suffix:" AssociatedControlID="dataPageTitleSuffix" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPageTitleSuffix" Text='<%# Bind("PageTitleSuffix") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultTitle" runat="server" Text="Default Title:" AssociatedControlID="dataDefaultTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDefaultTitle" Text='<%# Bind("DefaultTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHomeTitle" runat="server" Text="Home Title:" AssociatedControlID="dataHomeTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHomeTitle" Text='<%# Bind("HomeTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultDescription" runat="server" Text="Default Description:" AssociatedControlID="dataDefaultDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDefaultDescription" Text='<%# Bind("DefaultDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHomeDescription" runat="server" Text="Home Description:" AssociatedControlID="dataHomeDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHomeDescription" Text='<%# Bind("HomeDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultKeywords" runat="server" Text="Default Keywords:" AssociatedControlID="dataDefaultKeywords" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDefaultKeywords" Text='<%# Bind("DefaultKeywords") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHomeKeywords" runat="server" Text="Home Keywords:" AssociatedControlID="dataHomeKeywords" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHomeKeywords" Text='<%# Bind("HomeKeywords") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGeneralKeywords" runat="server" Text="General Keywords:" AssociatedControlID="dataGeneralKeywords" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGeneralKeywords" Text='<%# Bind("GeneralKeywords") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowFaceBookButton" runat="server" Text="Show Face Book Button:" AssociatedControlID="dataShowFaceBookButton" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowFaceBookButton" SelectedValue='<%# Bind("ShowFaceBookButton") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUseBlankHomePage" runat="server" Text="Use Blank Home Page:" AssociatedControlID="dataUseBlankHomePage" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataUseBlankHomePage" SelectedValue='<%# Bind("UseBlankHomePage") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUseAdvertiserFilter" runat="server" Text="Use Advertiser Filter:" AssociatedControlID="dataUseAdvertiserFilter" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUseAdvertiserFilter" Text='<%# Bind("UseAdvertiserFilter") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUseAdvertiserFilter" runat="server" Display="Dynamic" ControlToValidate="dataUseAdvertiserFilter" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataUseAdvertiserFilter" runat="server" Display="Dynamic" ControlToValidate="dataUseAdvertiserFilter" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMerchantId" runat="server" Text="Merchant Id:" AssociatedControlID="dataMerchantId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMerchantId" Text='<%# Bind("MerchantId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMerchantId" runat="server" Display="Dynamic" ControlToValidate="dataMerchantId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowTwitterButton" runat="server" Text="Show Twitter Button:" AssociatedControlID="dataShowTwitterButton" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowTwitterButton" SelectedValue='<%# Bind("ShowTwitterButton") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowJobAlertButton" runat="server" Text="Show Job Alert Button:" AssociatedControlID="dataShowJobAlertButton" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowJobAlertButton" SelectedValue='<%# Bind("ShowJobAlertButton") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowLinkedInButton" runat="server" Text="Show Linked In Button:" AssociatedControlID="dataShowLinkedInButton" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowLinkedInButton" SelectedValue='<%# Bind("ShowLinkedInButton") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteDocType" runat="server" Text="Site Doc Type:" AssociatedControlID="dataSiteDocType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteDocType" Text='<%# Bind("SiteDocType") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


