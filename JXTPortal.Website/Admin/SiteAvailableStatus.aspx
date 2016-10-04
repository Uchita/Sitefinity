<%@ Page Title="Site Locations - Site Available Status" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="SiteAvailableStatus.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteAvailableStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Site Member Available Status
<a href='http://support.jxt.com.au/solution/articles/116449-site-member-available-status' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-all">
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
        </span>
        <br />
        <asp:Repeater ID="rptSiteAvailableStatus" runat="server" OnItemDataBound="rptSiteAvailableStatus_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col"><input type="checkbox" id="chkSiteAvailableSelectAll" onclick="SelectAll(this);" /> Select All</th>
                            <th scope="col">Default Work Type Name</th>
                            <th scope="col">Available Status Name</th>
                            <th scope="col">Sequence</th>
                            <th scope="col">Last Modified By</th>
                            <th scope="col">Last Modified Date</th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkSiteAvailableStatusValid" runat="server"></asp:CheckBox>
                    </td>
                    <td>
                        <asp:Literal ID="LtSiteAvalableStatusName" runat="server" Text='<%# Bind("AvailableStatusName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txtSiteAvailableStatusName" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtSiteAvailableStatusSequence" runat="server" Width="50px"/>
                        <asp:CompareValidator id="cvSequence" Type="Integer" runat="server" ErrorMessage="Enter Valid Number" Operator="DataTypeCheck" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModifiedBy" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModifiedDate" runat="server" />
                        <asp:HiddenField ID="hiddenAvailableStatusParentID" runat="server" />
                        <asp:HiddenField ID="hiddenSiteAvailableStatusID" runat="server" />
                        <asp:HiddenField ID="hiddenAvailableStatusID" runat="server" Value='<%# Bind("AvailableStatusID") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <ul class="form-section">
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper-left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
