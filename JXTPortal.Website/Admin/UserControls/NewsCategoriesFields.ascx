<%@ Control Language="C#" ClassName="NewsCategoriesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNewsCategoryName" runat="server" Text="News Category Name:" AssociatedControlID="dataNewsCategoryName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNewsCategoryName" Text='<%# Bind("NewsCategoryName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSequence" runat="server" Text="Sequence:" AssociatedControlID="dataSequence" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSequence" Text='<%# Bind("Sequence") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="dataSequence" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="dataSequence" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaTitle" runat="server" Text="Meta Title:" AssociatedControlID="dataMetaTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaTitle" Text='<%# Bind("MetaTitle") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaTitle" runat="server" Display="Dynamic" ControlToValidate="dataMetaTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaKeywords" runat="server" Text="Meta Keywords:" AssociatedControlID="dataMetaKeywords" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaKeywords" Text='<%# Bind("MetaKeywords") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaKeywords" runat="server" Display="Dynamic" ControlToValidate="dataMetaKeywords" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMetaDescription" runat="server" Text="Meta Description:" AssociatedControlID="dataMetaDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMetaDescription" Text='<%# Bind("MetaDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMetaDescription" runat="server" Display="Dynamic" ControlToValidate="dataMetaDescription" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


