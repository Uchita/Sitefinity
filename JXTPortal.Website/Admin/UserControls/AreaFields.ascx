<%@ Control Language="C#" ClassName="AreaFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAreaName" runat="server" Text="Area Name:" AssociatedControlID="dataAreaName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAreaName" Text='<%# Bind("AreaName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAreaName" runat="server" Display="Dynamic" ControlToValidate="dataAreaName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocationId" runat="server" Text="Location Id:" AssociatedControlID="dataLocationId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLocationId" DataSourceID="LocationIdLocationDataSource" DataTextField="LocationName" DataValueField="LocationId" SelectedValue='<%# Bind("LocationId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LocationDataSource ID="LocationIdLocationDataSource" runat="server" SelectMethod="GetAll"  />
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


