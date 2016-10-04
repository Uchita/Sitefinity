<%@ Control Language="C#" ClassName="AdvertiserAccountTypeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdvertiserAccountTypeName" runat="server" Text="Account Type Name:" AssociatedControlID="dataAdvertiserAccountTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAdvertiserAccountTypeName" Text='<%# Bind("AdvertiserAccountTypeName") %>'  TextMode="SingleLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAdvertiserAccountTypeName" runat="server" Display="Dynamic" ControlToValidate="dataAdvertiserAccountTypeName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


