<%@ Control Language="C#" ClassName="JobAreaFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobId" runat="server" Text="Job Id:" AssociatedControlID="dataJobId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataJobId" DataSourceID="JobIdJobsDataSource" DataTextField="JobName" DataValueField="JobId" SelectedValue='<%# Bind("JobId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:JobsDataSource ID="JobIdJobsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataJobArchiveId" runat="server" Text="Job Archive Id:" AssociatedControlID="dataJobArchiveId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataJobArchiveId" DataSourceID="JobArchiveIdJobsArchiveDataSource" DataTextField="JobName" DataValueField="JobId" SelectedValue='<%# Bind("JobArchiveId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:JobsArchiveDataSource ID="JobArchiveIdJobsArchiveDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


