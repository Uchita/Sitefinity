<%@ Control Language="C#" ClassName="MemberStatusFields" %>

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
        <td class="literal"><asp:Label ID="lbldataMemberStatusName" runat="server" Text="Member Status Name:" AssociatedControlID="dataMemberStatusName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMemberStatusName" Text='<%# Bind("MemberStatusName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMemberStatusName" runat="server" Display="Dynamic" ControlToValidate="dataMemberStatusName" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
			<tr>
        <td class="literal"><asp:Label ID="lbldataSequence" runat="server" Text="Sequence:" AssociatedControlID="dataSequence" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSequence" Text='<%# Bind("Sequence") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="dataSequence" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="dataSequence" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


