<%@ Control Language="C#" ClassName="DynamicPageWebPartTemplatesFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDynamicPageWebPartName" runat="server" Text="Web Container Name:"
                        AssociatedControlID="dataDynamicPageWebPartName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataDynamicPageWebPartName" Text='<%# Bind("DynamicPageWebPartName") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_dataDynamicPageWebPartName" runat="server" Display="Dynamic" ControlToValidate="dataDynamicPageWebPartName"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" />
                </td>
                <td>
                    <asp:Label runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>'
                        MaxLength="10"></asp:Label>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
