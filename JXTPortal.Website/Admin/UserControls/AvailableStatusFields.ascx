<%@ Control Language="C#" ClassName="AvailableStatusFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAvailableStatusParentId" runat="server" Text="Available Status Parent Id:" AssociatedControlID="dataAvailableStatusParentId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAvailableStatusParentId" Text='<%# Bind("AvailableStatusParentId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAvailableStatusParentId" runat="server" Display="Dynamic" ControlToValidate="dataAvailableStatusParentId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAvailableStatusParentId" runat="server" Display="Dynamic" ControlToValidate="dataAvailableStatusParentId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAvailableStatusName" runat="server" Text="Available Status Name:" AssociatedControlID="dataAvailableStatusName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAvailableStatusName" Text='<%# Bind("AvailableStatusName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAvailableStatusName" runat="server" Display="Dynamic" ControlToValidate="dataAvailableStatusName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGlobalTemplate" runat="server" Text="Global Template:" AssociatedControlID="dataGlobalTemplate" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataGlobalTemplate" SelectedValue='<%# Bind("GlobalTemplate") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


