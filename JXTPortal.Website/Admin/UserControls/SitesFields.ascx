<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SitesFields.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.SitesFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSiteName" runat="server" Text="Site Name:" AssociatedControlID="dataSiteName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataSiteName" Text='<%# Bind("SiteName") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSiteUrl" runat="server" Text="Site Url:" AssociatedControlID="dataSiteUrl" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataSiteUrl" Text='<%# Bind("SiteUrl") %>' TextMode="MultiLine"
                        Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSiteDescription" runat="server" Text="Site Description:" AssociatedControlID="dataSiteDescription" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataSiteDescription" Text='<%# Bind("SiteDescription") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lblSiteAdminLogo" runat="server" Text="Site Admin Logo:" AssociatedControlID="dataSiteAdminLogo" />
                </td>
                <td>
                    <asp:FileUpload ID="fileUploadSiteAdminLogo" runat="server" />
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
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModifiedBy" runat="server" Text="Last Modified By:" AssociatedControlID="dataLastModifiedBy" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataLastModifiedBy" DataSourceID="LastModifiedByAdminUsersDataSource"
                        DataTextField="UserName" DataValueField="AdminUserId" SelectedValue='<%# Bind("LastModifiedBy") %>'
                        AppendNullItem="true" Required="false" NullItemText=" Please Choose ..." />
                    <data:AdminUsersDataSource ID="LastModifiedByAdminUsersDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
