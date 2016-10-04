<%@ Control Language="C#" ClassName="SiteWebPartTypesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteWebPartName" runat="server" Text="Site Web Part Name:" AssociatedControlID="dataSiteWebPartName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteWebPartName" Text='<%# Bind("SiteWebPartName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSiteWebPartName" runat="server" Display="Dynamic" ControlToValidate="dataSiteWebPartName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


