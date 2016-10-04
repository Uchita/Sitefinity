<%@ Control Language="C#" ClassName="FileTypesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataFileTypeName" runat="server" Text="File Type Name:" AssociatedControlID="dataFileTypeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFileTypeName" Text='<%# Bind("FileTypeName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFileTypeName" runat="server" Display="Dynamic" ControlToValidate="dataFileTypeName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFileTypeExtension" runat="server" Text="File Type Extension:" AssociatedControlID="dataFileTypeExtension" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFileTypeExtension" Text='<%# Bind("FileTypeExtension") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFileTypeExtension" runat="server" Display="Dynamic" ControlToValidate="dataFileTypeExtension" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


