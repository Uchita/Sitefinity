<%@ Control Language="C#" ClassName="EnquiriesFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" 
                    ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>'></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataContactPhone" runat="server" Text="Contact Phone:" AssociatedControlID="dataContactPhone" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataContactPhone" Text='<%# Bind("ContactPhone") %>'
                        MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="literal" valign="top">
                    <asp:Label ID="lbldataContent" runat="server" Text="Content:" AssociatedControlID="dataContent" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataContent" Text='<%# Bind("Content") %>' TextMode="MultiLine"
                        Width="400px" Rows="20"></asp:TextBox>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
