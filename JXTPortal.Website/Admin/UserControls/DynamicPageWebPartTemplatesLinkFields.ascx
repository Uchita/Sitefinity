<%@ Control Language="C#" ClassName="DynamicPageWebPartTemplatesLinkFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDynamicPageWebPartTemplateId" runat="server" Text="Dynamic Page Web Part Template Id:" AssociatedControlID="dataDynamicPageWebPartTemplateId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDynamicPageWebPartTemplateId" DataSourceID="DynamicPageWebPartTemplateIdDynamicPageWebPartTemplatesDataSource" DataTextField="DynamicPageWebPartName" DataValueField="DynamicPageWebPartTemplateId" SelectedValue='<%# Bind("DynamicPageWebPartTemplateId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DynamicPageWebPartTemplatesDataSource ID="DynamicPageWebPartTemplateIdDynamicPageWebPartTemplatesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteWebPartId" runat="server" Text="Site Web Part Id:" AssociatedControlID="dataSiteWebPartId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSiteWebPartId" DataSourceID="SiteWebPartIdSiteWebPartsDataSource" DataTextField="SiteWebPartHtml" DataValueField="SiteWebPartId" SelectedValue='<%# Bind("SiteWebPartId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SiteWebPartsDataSource ID="SiteWebPartIdSiteWebPartsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


