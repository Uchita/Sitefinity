<%@ Control Language="C#" ClassName="LocationFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocationName" runat="server" Text="Location Name:" AssociatedControlID="dataLocationName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocationName" Text='<%# Bind("LocationName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLocationName" runat="server" Display="Dynamic" ControlToValidate="dataLocationName" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


