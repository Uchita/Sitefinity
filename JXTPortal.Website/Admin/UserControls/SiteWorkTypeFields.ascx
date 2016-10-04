<%@ Control Language="C#" ClassName="SiteWorkTypeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWorkTypeId" runat="server" Text="Work Type Id:" AssociatedControlID="dataWorkTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWorkTypeId" DataSourceID="WorkTypeIdWorkTypeDataSource" DataTextField="WorkTypeName" DataValueField="WorkTypeId" SelectedValue='<%# Bind("WorkTypeId") %>' AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." ErrorText="Required" />
					<data:WorkTypeDataSource ID="WorkTypeIdWorkTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteWorkTypeName" runat="server" Text="Site Work Type Name:" AssociatedControlID="dataSiteWorkTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteWorkTypeName" Text='<%# Bind("SiteWorkTypeName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSiteWorkTypeName" runat="server" Display="Dynamic" ControlToValidate="dataSiteWorkTypeName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


