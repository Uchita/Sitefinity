<%@ Control Language="C#" ClassName="SiteRolesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataRoleId" runat="server" Text="Role Id:" AssociatedControlID="dataRoleId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataRoleId" DataSourceID="RoleIdRolesDataSource" DataTextField="RoleName" DataValueField="RoleId" SelectedValue='<%# Bind("RoleId") %>' AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." ErrorText="Required" />
					<data:RolesDataSource ID="RoleIdRolesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteRoleName" runat="server" Text="Site Role Name:" AssociatedControlID="dataSiteRoleName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteRoleName" Text='<%# Bind("SiteRoleName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSiteRoleName" runat="server" Display="Dynamic" ControlToValidate="dataSiteRoleName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaTitle" runat="server" Text="Meta Title:" AssociatedControlID="dataMetaTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaTitle" Text='<%# Bind("MetaTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaTitle" runat="server" Display="Dynamic" ControlToValidate="dataMetaTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaKeywords" runat="server" Text="Meta Keywords:" AssociatedControlID="dataMetaKeywords" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaKeywords" Text='<%# Bind("MetaKeywords") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaKeywords" runat="server" Display="Dynamic" ControlToValidate="dataMetaKeywords" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaDescription" runat="server" Text="Meta Description:" AssociatedControlID="dataMetaDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaDescription" Text='<%# Bind("MetaDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaDescription" runat="server" Display="Dynamic" ControlToValidate="dataMetaDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


