<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="AdvertisersMapping.aspx.cs" Inherits="JXTPortal.Website.Admin.bullhorn.AdvertisersMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript">
        function TypeChanged(dropdown, textbox) {
            if ($('#' + dropdown).val() != 'string') {
                $('#' + textbox).val('');
                $('#' + textbox).prop('disabled', 'disabled');
            }
            else {
                $('#' + textbox).prop('disabled', false);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Bullhorn Mapping
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="gse-generalsettings-field">
                <h3>
                    Advertisers Mapping</h3>
            </li>
        </ul>
        <asp:Repeater ID="rptAdvertisersMapping" runat="server" OnItemDataBound="rptAdvertisersMapping_ItemDataBound"
            OnItemCommand="rptAdvertisersMapping_ItemCommand">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                Sync
                            </th>
                            <th scope="col">
                                JXT Column Name
                            </th>
                            <th scope="col">
                                Bullhorn Column Select
                            </th>
                            <th scope="col" style="display:none">
                                Bullhorn Column Name
                            </th>
                            <th scope="col" style="display:none">
                                Bullhorn Column Type
                            </th>
                            <th scope="col" style="display:none">
                                Bullhorn Column Size
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="cbSync" runat="server" />
                        <asp:HiddenField ID="hfAdvertiserMappingID" runat="server" />
                        <asp:HiddenField ID="hfDefaultAdvertiserMappingID" runat="server" />
                        <asp:HiddenField ID="hfJXTEntity" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltJXTColumn" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlThirdPartyColumn" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="display:none">
                        <asp:TextBox ID="tbThirdPartyColumn" runat="server" />
                        <asp:Literal ID="ltThirdPartyColumnError" runat="server" />
                    </td>
                    <td style="display:none">
                        <asp:DropDownList ID="ddlThirdPartyType" runat="server">
                            <asp:ListItem Value="string" Text="String" />
                            <asp:ListItem Value="int" Text="Integer" />
                            <asp:ListItem Value="datetime" Text="DateTime" />
                            <asp:ListItem Value="bool" Text="Boolean" />
                        </asp:DropDownList>
                    </td>
                    <td style="display:none">
                        <asp:TextBox ID="tbThirdPartySize" runat="server" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
                <ul class="form-section">
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnAdvertiserSave" runat="server" Text="Update" CommandName="Update"
                                    CssClass="jxtadminbutton" />
                            </div>
                        </div>
                    </li>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <ul class="form-section">
            <li class="form-line" id="Li1">
                <h3>
                    Advertiser Users Mapping</h3>
            </li>
        </ul>
        <asp:Repeater ID="rptAdvertiserUsersMapping" runat="server" OnItemDataBound="rptAdvertiserUsersMapping_ItemDataBound"
            OnItemCommand="rptAdvertiserUsersMapping_ItemCommand">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                Sync
                            </th>
                            <th scope="col">
                                JXT Column Name
                            </th>
                            <th scope="col">
                                Bullhorn Column Select
                            </th>
                            <th scope="col" style="display:none">
                                Bullhorn Column Name
                            </th>
                            <th scope="col" style="display:none">
                                Bullhorn Column Type
                            </th>
                            <th scope="col" style="display:none">
                                Bullhorn Column Size
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="cbSync" runat="server" />
                        <asp:HiddenField ID="hfAdvertiserUserMappingID" runat="server" />
                        <asp:HiddenField ID="hfDefaultAdvertiserUserMappingID" runat="server" />
                        <asp:HiddenField ID="hfJXTEntity" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltJXTColumn" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlThirdPartyColumn" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="display:none">
                        <asp:TextBox ID="tbThirdPartyColumn" runat="server" />
                        <asp:Literal ID="ltThirdPartyColumnError" runat="server" />
                    </td>
                    <td style="display:none">
                        <asp:DropDownList ID="ddlThirdPartyType" runat="server">
                            <asp:ListItem Value="string" Text="String" />
                            <asp:ListItem Value="int" Text="Integer" />
                            <asp:ListItem Value="datetime" Text="DateTime" />
                            <asp:ListItem Value="bool" Text="Boolean" />
                        </asp:DropDownList>
                    </td>
                    <td style="display:none">
                        <asp:TextBox ID="tbThirdPartySize" runat="server" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
                <ul class="form-section">
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnAdvertiserUsersave" runat="server" Text="Update" CommandName="Update"
                                    CssClass="jxtadminbutton" />
                            </div>
                        </div>
                    </li>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
