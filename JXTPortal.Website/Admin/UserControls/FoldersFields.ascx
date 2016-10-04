<%@ Control Language="C#" ClassName="FoldersFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataParentFolderId" runat="server" Text="Parent Folder Id:" AssociatedControlID="dataParentFolderId" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataParentFolderId" Text='<%# Bind("ParentFolderId") %>'></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataParentFolderId" runat="server" Display="Dynamic" ControlToValidate="dataParentFolderId"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataParentFolderId"
                            runat="server" Display="Dynamic" ControlToValidate="dataParentFolderId" ErrorMessage="Invalid value"
                            MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFolderName" runat="server" Text="Folder Name:" AssociatedControlID="dataFolderName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataFolderName" Text='<%# Bind("FolderName") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_dataFolderName" runat="server" Display="Dynamic" ControlToValidate="dataFolderName"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
