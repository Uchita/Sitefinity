<%@ Page Title="Site Locations - Site Educations" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="SiteEducations.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteEducations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Site Education 
<a href='http://support.jxt.com.au/solution/articles/116448-site-educations' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
        </span>
        <br />
        <asp:Repeater ID="rptSiteEducations" runat="server" OnItemDataBound="rptSiteEducations_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col"><input type="checkbox" id="chkSiteEducationsSelectAll" onclick="SelectAll(this);" /> Select All</th>
                            <th scope="col">Default Educations Name</th>
                            <th scope="col">Educations Name</th>
                            <th scope="col">Sequence</th>
                            <th scope="col">Last Modified By</th>
                            <th scope="col">Last Modified Date</th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkSiteEducationsValid" runat="server"></asp:CheckBox>
                    </td>
                    <td>
                        <asp:Literal ID="LtSiteEducationsName" runat="server" Text='<%# Bind("EducationName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txtSiteEducationsName" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtSiteEducationsSequence" runat="server" Width="50px"/>
                        <asp:CompareValidator id="cvSequence" Type="Integer" runat="server" ErrorMessage="Enter Valid Number" Operator="DataTypeCheck" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModifiedBy" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModifiedDate" runat="server" />
                        <asp:HiddenField ID="hiddenEducationParentID" runat="server" />
                        <asp:HiddenField ID="hiddenSiteEducationID" runat="server" />
                        <asp:HiddenField ID="hiddenEducationID" runat="server" Value='<%# Bind("EducationID") %>' />
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
