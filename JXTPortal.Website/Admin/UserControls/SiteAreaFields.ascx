<%@ Control Language="C#" ClassName="SiteAreaFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAreaId" runat="server" Text="Area Id:" AssociatedControlID="dataAreaId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAreaId" DataSourceID="AreaIdAreaDataSource" DataTextField="AreaName" DataValueField="AreaId" SelectedValue='<%# Bind("AreaId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AreaDataSource ID="AreaIdAreaDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteAreaName" runat="server" Text="Site Area Name:" AssociatedControlID="dataSiteAreaName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteAreaName" Text='<%# Bind("SiteAreaName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSiteAreaName" runat="server" Display="Dynamic" ControlToValidate="dataSiteAreaName" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


