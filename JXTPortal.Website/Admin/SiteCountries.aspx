<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    Inherits="SiteCountries" Title="SiteCountries List" CodeBehind="SiteCountries.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Countries List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <label class="form-label-left">
            <input id="cbSelectAll" type="checkbox" onclick="SelectAllCB();" />
            <strong>Select All</strong></label>
        <ul>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper-left">
                        <asp:Button ID="btnEditSaveTop" runat="server" Text="Update" OnClick="btnEditSave_Click"
                            CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
        <div id="tree-section-container">
            <div class="tree-section-1">
                <asp:Repeater ID="rptCountries" runat="server" 
                    onitemdatabound="rptCountries_ItemDataBound">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="border-width: 0;">
                            <tbody>
                                <tr>
                                    <td style="white-space: nowrap;">
                                        <asp:CheckBox ID="cbCountry" runat="server" />
                                        <asp:HiddenField ID="hfCountry" runat="server" />
                                        <asp:TextBox ID="tbSequence" runat="server" Width="40px" />
                                        <asp:Literal ID="ltCountry" runat="server" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <ul>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper-left">
                        <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                            CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script language="javascript" type="text/javascript">
        function SelectAllCB() {
            var selectchecked = $('#cbSelectAll').is(':checked');
            $('input[type=checkbox]').prop('checked', selectchecked);
        }
    </script>
</asp:Content>
