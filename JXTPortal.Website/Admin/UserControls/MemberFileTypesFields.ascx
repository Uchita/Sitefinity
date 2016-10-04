<%@ Control Language="C#" ClassName="MemberFileTypesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMemberFileTypeName" runat="server" Text="Member File Type Name:" AssociatedControlID="dataMemberFileTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMemberFileTypeName" Text='<%# Bind("MemberFileTypeName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMemberFileTypeName" runat="server" Display="Dynamic" ControlToValidate="dataMemberFileTypeName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


