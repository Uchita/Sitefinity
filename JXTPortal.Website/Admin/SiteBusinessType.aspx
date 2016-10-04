<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="SiteBusinessType.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteBusinessType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Advertiser Business Type 
<%--<a href='http://support.jxt.com.au/solution/articles/116448-site-educations' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
        </span>
        <br />
        <asp:Repeater ID="rptSiteBusinessType" runat="server" OnItemDataBound="rptSiteBusinessType_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col"><input type="checkbox" id="chkSiteBusinessTypeSelectAll" onclick="SelectAll(this);" /> Select All</th>
                            <th scope="col">Default Business Type Name</th>
                            <th scope="col">Business Type Name</th>
                            <th scope="col">Sequence</th>
                            <th scope="col">Last Modified By</th>
                            <th scope="col">Last Modified Date</th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkSiteBusinessTypeValid" runat="server"></asp:CheckBox>
                    </td>
                    <td>
                        <asp:Literal ID="ltSiteBusinessTypeName" runat="server" Text='<%# Bind("AdvertiserBusinessTypeName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txtSiteBusinessTypeName" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtSiteBusinessTypeSequence" runat="server" Width="50px"/>
                        <asp:CompareValidator id="cvSequence" Type="Integer" runat="server" ErrorMessage="Enter Valid Number" Operator="DataTypeCheck" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModifiedBy" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModifiedDate" runat="server" />
                        <asp:HiddenField ID="hiddenBusinessTypeParentID" runat="server" />
                        <asp:HiddenField ID="hiddenSiteBusinessTypeID" runat="server" />
                        <asp:HiddenField ID="hiddenBusinessTypeID" runat="server" Value='<%# Bind("AdvertiserBusinessTypeID") %>' />
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>