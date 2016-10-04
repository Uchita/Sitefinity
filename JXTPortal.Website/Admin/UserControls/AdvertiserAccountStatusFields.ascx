<%@ Control Language="C#" ClassName="AdvertiserAccountStatusFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdvertiserAccountStatusName" runat="server" Text="Account Status Name:" AssociatedControlID="dataAdvertiserAccountStatusName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAdvertiserAccountStatusName" Text='<%# Bind("AdvertiserAccountStatusName") %>'  TextMode="SingleLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAdvertiserAccountStatusName" runat="server" Display="Dynamic" ControlToValidate="dataAdvertiserAccountStatusName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


