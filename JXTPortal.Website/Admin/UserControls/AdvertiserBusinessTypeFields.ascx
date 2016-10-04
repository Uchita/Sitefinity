<%@ Control Language="C#" ClassName="AdvertiserBusinessTypeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdvertiserBusinessTypeName" runat="server" Text="Advertiser Business Type Name:" AssociatedControlID="dataAdvertiserBusinessTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAdvertiserBusinessTypeName" Text='<%# Bind("AdvertiserBusinessTypeName") %>' Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAdvertiserBusinessTypeName" runat="server" Display="Dynamic" ControlToValidate="dataAdvertiserBusinessTypeName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


