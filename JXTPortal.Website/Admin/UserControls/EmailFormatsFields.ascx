<%@ Control Language="C#" ClassName="EmailFormatsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailFormatName" runat="server" Text="Email Format Name:" AssociatedControlID="dataEmailFormatName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmailFormatName" Text='<%# Bind("EmailFormatName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmailFormatName" runat="server" Display="Dynamic" ControlToValidate="dataEmailFormatName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


