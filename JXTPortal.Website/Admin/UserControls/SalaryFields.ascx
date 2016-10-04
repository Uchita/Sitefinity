<%@ Control Language="C#" ClassName="SalaryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalaryTypeId" runat="server" Text="Salary Type Id:" AssociatedControlID="dataSalaryTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalaryTypeId" DataSourceID="SalaryTypeIdSalaryTypeDataSource" DataTextField="SalaryTypeName" DataValueField="SalaryTypeId" SelectedValue='<%# Bind("SalaryTypeId") %>' AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." ErrorText="Required" />
					<data:SalaryTypeDataSource ID="SalaryTypeIdSalaryTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalaryName" runat="server" Text="Salary Name:" AssociatedControlID="dataSalaryName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalaryName" Text='<%# Bind("SalaryName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalaryName" runat="server" Display="Dynamic" ControlToValidate="dataSalaryName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataValid" runat="server" Text="Valid:" AssociatedControlID="dataValid" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataValid" SelectedValue='<%# Bind("Valid") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


