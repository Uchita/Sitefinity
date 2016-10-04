<%@ Control Language="C#" ClassName="SiteWebPartsFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSiteWebPartTypeId" runat="server" Text="Site Web Part Type Id:"
                        AssociatedControlID="dataSiteWebPartTypeId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataSiteWebPartTypeId" DataSourceID="SiteWebPartTypeIdSiteWebPartTypesDataSource"
                        DataTextField="SiteWebPartName" DataValueField="SiteWebPartTypeId" SelectedValue='<%# Bind("SiteWebPartTypeId") %>'
                        AppendNullItem="true" Required="true" NullItemText=" Please Choose ..." ErrorText="Required" />
                    <data:SiteWebPartTypesDataSource ID="SiteWebPartTypeIdSiteWebPartTypesDataSource"
                        runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSiteWebPartHtml" runat="server" Text="Site Web Part Html:"
                        AssociatedControlID="dataSiteWebPartHtml" />
                </td>
                <td>
                    <FredCK:CKEditorControl ID="txtPageContent" runat="server" Width="650px" Height="400px"
                        CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
