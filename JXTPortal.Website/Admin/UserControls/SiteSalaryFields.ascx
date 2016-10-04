<%@ Control Language="C#" ClassName="SiteSalaryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalaryId" runat="server" Text="Salary Id:" AssociatedControlID="dataSalaryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalaryId" DataSourceID="SalaryIdSalaryDataSource" DataTextField="SalaryName" DataValueField="SalaryId" SelectedValue='<%# Bind("SalaryId") %>' AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." ErrorText="Required" />
					<data:SalaryDataSource ID="SalaryIdSalaryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSiteSalaryName" runat="server" Text="Site Salary Name:" AssociatedControlID="dataSiteSalaryName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSiteSalaryName" Text='<%# Bind("SiteSalaryName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSiteSalaryName" runat="server" Display="Dynamic" ControlToValidate="dataSiteSalaryName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalaryUpperBand" runat="server" Text="Salary Upper Band:" AssociatedControlID="dataSalaryUpperBand" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalaryUpperBand" Text='<%# Bind("SalaryUpperBand") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalaryUpperBand" runat="server" Display="Dynamic" ControlToValidate="dataSalaryUpperBand" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalaryLowerBand" runat="server" Text="Salary Lower Band:" AssociatedControlID="dataSalaryLowerBand" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalaryLowerBand" Text='<%# Bind("SalaryLowerBand") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalaryLowerBand" runat="server" Display="Dynamic" ControlToValidate="dataSalaryLowerBand" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


