<%@ Control Language="C#" ClassName="DynamicPageFilesFields" %>

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
        <td class="literal"><asp:Label ID="lbldataPageName" runat="server" Text="Page Name:" AssociatedControlID="dataPageName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPageName" Text='<%# Bind("PageName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPageName" runat="server" Display="Dynamic" ControlToValidate="dataPageName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFileId" runat="server" Text="File Id:" AssociatedControlID="dataFileId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataFileId" DataSourceID="FileIdFilesDataSource" DataTextField="FileName" DataValueField="FileId" SelectedValue='<%# Bind("FileId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:FilesDataSource ID="FileIdFilesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


