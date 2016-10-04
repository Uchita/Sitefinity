<%@ Control Language="C#" ClassName="SiteCountriesFields" %>

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
        <td class="literal"><asp:Label ID="lbldataCountryId" runat="server" Text="Country Id:" AssociatedControlID="dataCountryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountryId" DataSourceID="CountryIdCountriesDataSource" DataTextField="CountryName" DataValueField="CountryId" SelectedValue='<%# Bind("CountryId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CountriesDataSource ID="CountryIdCountriesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteCountryName" runat="server" Text="Site Country Name:" AssociatedControlID="dataSiteCountryName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteCountryName" Text='<%# Bind("SiteCountryName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSiteCountryName" runat="server" Display="Dynamic" ControlToValidate="dataSiteCountryName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


