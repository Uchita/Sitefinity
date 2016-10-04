<%@ Control Language="C#" ClassName="LanguagesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataLanguageName" runat="server" Text="Language Name:" AssociatedControlID="dataLanguageName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLanguageName" Text='<%# Bind("LanguageName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLanguageName" runat="server" Display="Dynamic" ControlToValidate="dataLanguageName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


