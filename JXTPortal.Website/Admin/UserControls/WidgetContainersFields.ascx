<%@ Control Language="C#" ClassName="WidgetContainersFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteId" runat="server" Text="Site Id:" AssociatedControlID="dataSiteId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSiteId" DataSourceID="SiteIdSitesDataSource" DataTextField="SiteName" DataValueField="SiteId" SelectedValue='<%# Bind("SiteId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SitesDataSource ID="SiteIdSitesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLanguageId" runat="server" Text="Language Id:" AssociatedControlID="dataLanguageId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLanguageId" DataSourceID="LanguageIdLanguagesDataSource" DataTextField="LanguageName" DataValueField="LanguageId" SelectedValue='<%# Bind("LanguageId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LanguagesDataSource ID="LanguageIdLanguagesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidgetName" runat="server" Text="Widget Name:" AssociatedControlID="dataWidgetName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidgetName" Text='<%# Bind("WidgetName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidgetDomain" runat="server" Text="Widget Domain:" AssociatedControlID="dataWidgetDomain" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidgetDomain" Text='<%# Bind("WidgetDomain") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidgetContainerClass" runat="server" Text="Widget Container Class:" AssociatedControlID="dataWidgetContainerClass" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidgetContainerClass" Text='<%# Bind("WidgetContainerClass") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidgetContainerHeaderClass" runat="server" Text="Widget Container Header Class:" AssociatedControlID="dataWidgetContainerHeaderClass" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidgetContainerHeaderClass" Text='<%# Bind("WidgetContainerHeaderClass") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidgetItemClass" runat="server" Text="Widget Item Class:" AssociatedControlID="dataWidgetItemClass" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidgetItemClass" Text='<%# Bind("WidgetItemClass") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidgetJobLinkCss" runat="server" Text="Widget Job Link Css:" AssociatedControlID="dataWidgetJobLinkCss" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidgetJobLinkCss" Text='<%# Bind("WidgetJobLinkCss") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidgetItemLinkImageId" runat="server" Text="Widget Item Link Image Id:" AssociatedControlID="dataWidgetItemLinkImageId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidgetItemLinkImageId" Text='<%# Bind("WidgetItemLinkImageId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWidgetItemLinkImageId" runat="server" Display="Dynamic" ControlToValidate="dataWidgetItemLinkImageId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowJobs" runat="server" Text="Show Jobs:" AssociatedControlID="dataShowJobs" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowJobs" SelectedValue='<%# Bind("ShowJobs") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowCompanies" runat="server" Text="Show Companies:" AssociatedControlID="dataShowCompanies" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowCompanies" SelectedValue='<%# Bind("ShowCompanies") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowSite" runat="server" Text="Show Site:" AssociatedControlID="dataShowSite" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowSite" SelectedValue='<%# Bind("ShowSite") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataShowPeople" runat="server" Text="Show People:" AssociatedControlID="dataShowPeople" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataShowPeople" SelectedValue='<%# Bind("ShowPeople") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobHtml" runat="server" Text="Job Html:" AssociatedControlID="dataJobHtml" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataJobHtml" Text='<%# Bind("JobHtml") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyHtml" runat="server" Text="Company Html:" AssociatedControlID="dataCompanyHtml" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompanyHtml" Text='<%# Bind("CompanyHtml") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteHtml" runat="server" Text="Site Html:" AssociatedControlID="dataSiteHtml" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteHtml" Text='<%# Bind("SiteHtml") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPeopleHtml" runat="server" Text="People Html:" AssociatedControlID="dataPeopleHtml" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPeopleHtml" Text='<%# Bind("PeopleHtml") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataJavascript" runat="server" Text="Javascript:" AssociatedControlID="dataJavascript" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataJavascript" Text='<%# Bind("Javascript") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSearchCss" runat="server" Text="Search Css:" AssociatedControlID="dataSearchCss" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSearchCss" Text='<%# Bind("SearchCss") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultProfessionId" runat="server" Text="Default Profession Id:" AssociatedControlID="dataDefaultProfessionId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDefaultProfessionId" DataSourceID="DefaultProfessionIdProfessionDataSource" DataTextField="ProfessionName" DataValueField="ProfessionId" SelectedValue='<%# Bind("DefaultProfessionId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ProfessionDataSource ID="DefaultProfessionIdProfessionDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultCountryId" runat="server" Text="Default Country Id:" AssociatedControlID="dataDefaultCountryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDefaultCountryId" DataSourceID="DefaultCountryIdCountriesDataSource" DataTextField="CountryName" DataValueField="CountryId" SelectedValue='<%# Bind("DefaultCountryId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CountriesDataSource ID="DefaultCountryIdCountriesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultLocationId" runat="server" Text="Default Location Id:" AssociatedControlID="dataDefaultLocationId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDefaultLocationId" DataSourceID="DefaultLocationIdLocationDataSource" DataTextField="LocationName" DataValueField="LocationId" SelectedValue='<%# Bind("DefaultLocationId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:LocationDataSource ID="DefaultLocationIdLocationDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWidth" runat="server" Text="Width:" AssociatedControlID="dataWidth" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWidth" Text='<%# Bind("Width") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWidth" runat="server" Display="Dynamic" ControlToValidate="dataWidth" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHeight" runat="server" Text="Height:" AssociatedControlID="dataHeight" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHeight" Text='<%# Bind("Height") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataHeight" runat="server" Display="Dynamic" ControlToValidate="dataHeight" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOnAdvancedSearch" runat="server" Text="On Advanced Search:" AssociatedControlID="dataOnAdvancedSearch" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataOnAdvancedSearch" SelectedValue='<%# Bind("OnAdvancedSearch") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


