<%@ Control Language="C#" ClassName="AdminUsersFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAdminRoleId" runat="server" Text="Admin Role Id:" AssociatedControlID="dataAdminRoleId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataAdminRoleId" DataSourceID="AdminRoleIdAdminRolesDataSource"
                        DataTextField="RoleName" DataValueField="AdminRoleId" SelectedValue='<%# Bind("AdminRoleId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:AdminRolesDataSource ID="AdminRoleIdAdminRolesDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName"
                            runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUserPassword" runat="server" Text="User Password:" AssociatedControlID="dataUserPassword" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataUserPassword" Text='<%# Bind("UserPassword") %>' TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_dataUserPassword" runat="server" Display="Dynamic" ControlToValidate="dataUserPassword"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFirstName" runat="server" Text="First Name:" AssociatedControlID="dataFirstName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataFirstName" Text='<%# Bind("FirstName") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFirstName"
                            runat="server" Display="Dynamic" ControlToValidate="dataFirstName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSurname" runat="server" Text="Surname:" AssociatedControlID="dataSurname" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataSurname" Text='<%# Bind("Surname") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSurname"
                            runat="server" Display="Dynamic" ControlToValidate="dataSurname" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmail"
                            runat="server" Display="Dynamic" ControlToValidate="dataEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
