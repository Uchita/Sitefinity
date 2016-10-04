<%@ Control Language="C#" ClassName="MemberFilesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMemberId" runat="server" Text="Member Id:" AssociatedControlID="dataMemberId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataMemberId" DataSourceID="MemberIdMembersDataSource" DataTextField="Username" DataValueField="MemberId" SelectedValue='<%# Bind("MemberId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:MembersDataSource ID="MemberIdMembersDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMemberFileTypeId" runat="server" Text="Member File Type Id:" AssociatedControlID="dataMemberFileTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataMemberFileTypeId" DataSourceID="MemberFileTypeIdMemberFileTypesDataSource" DataTextField="MemberFileTypeName" DataValueField="MemberFileTypeId" SelectedValue='<%# Bind("MemberFileTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:MemberFileTypesDataSource ID="MemberFileTypeIdMemberFileTypesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMemberFileName" runat="server" Text="Member File Name:" AssociatedControlID="dataMemberFileName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMemberFileName" Text='<%# Bind("MemberFileName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMemberFileName" runat="server" Display="Dynamic" ControlToValidate="dataMemberFileName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMemberFileTitle" runat="server" Text="Member File Title:" AssociatedControlID="dataMemberFileTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMemberFileTitle" Text='<%# Bind("MemberFileTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMemberFileTitle" runat="server" Display="Dynamic" ControlToValidate="dataMemberFileTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModifiedDate" runat="server" Text="Last Modified Date:" AssociatedControlID="dataLastModifiedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModifiedDate" Text='<%# Bind("LastModifiedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModifiedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModifiedDate" runat="server" Display="Dynamic" ControlToValidate="dataLastModifiedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrivacyLevelId" runat="server" Text="Privacy Level Id:" AssociatedControlID="dataPrivacyLevelId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrivacyLevelId" Text='<%# Bind("PrivacyLevelId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPrivacyLevelId" runat="server" Display="Dynamic" ControlToValidate="dataPrivacyLevelId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


