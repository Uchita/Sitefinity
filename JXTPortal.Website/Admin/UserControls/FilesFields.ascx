<%@ Control Language="C#" ClassName="FilesFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFolderId" runat="server" Text="Folder Id:" AssociatedControlID="dataFolderId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataFolderId" DataSourceID="FolderIdFoldersDataSource"
                        DataTextField="ParentFolderId" DataValueField="FolderId" SelectedValue='<%# Bind("FolderId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:FoldersDataSource ID="FolderIdFoldersDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFileName" runat="server" Text="File Name:" AssociatedControlID="dataFileName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataFileName" Text='<%# Bind("FileName") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFileName"
                            runat="server" Display="Dynamic" ControlToValidate="dataFileName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFileSystemName" runat="server" Text="File System Name:" AssociatedControlID="dataFileSystemName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataFileSystemName" Text='<%# Bind("FileSystemName") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator
                            ID="ReqVal_dataFileSystemName" runat="server" Display="Dynamic" ControlToValidate="dataFileSystemName"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataFileTypeId" runat="server" Text="File Type Id:" AssociatedControlID="dataFileTypeId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataFileTypeId" DataSourceID="FileTypeIdFileTypesDataSource"
                        DataTextField="FileTypeName" DataValueField="FileTypeId" SelectedValue='<%# Bind("FileTypeId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:FileTypesDataSource ID="FileTypeIdFileTypesDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>'
                        MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server"
                            SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator
                                ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModifiedBy" runat="server" Text="Last Modified By:" AssociatedControlID="dataLastModifiedBy" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataLastModifiedBy" DataSourceID="LastModifiedByAdminUsersDataSource"
                        DataTextField="UserName" DataValueField="AdminUserId" SelectedValue='<%# Bind("LastModifiedBy") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:AdminUsersDataSource ID="LastModifiedByAdminUsersDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
