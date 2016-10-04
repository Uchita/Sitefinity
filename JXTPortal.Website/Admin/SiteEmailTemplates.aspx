<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="SiteEmailTemplates.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteEmailTemplates"
    Title="Sites - Site Email Templates" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Site Email Templates List
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
        </span>
        <br />
        <ul class="form-section">
            <li class="form-line" id="set-bulk-field">
                <label class="form-label-left">
                    Bulk Email Update</label>
                <div class="form-input">
                    &nbsp;
                </div>
            </li>
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Contact Name</label>
                <div class="form-input">
                    <asp:TextBox ID="tbBulkEmailName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic"
                        ControlToValidate="tbBulkEmailName" SetFocusOnError="true" ValidationGroup="Bulk" />
                </div>
            </li>
            <li class="form-line" id="Li2">
                <label class="form-label-left">
                    Email Address</label>
                <div class="form-input">
                    <asp:TextBox ID="tbBulkEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic"
                        ControlToValidate="tbBulkEmail" SetFocusOnError="true" ValidationGroup="Bulk" />
            
                    <asp:CustomValidator ID="cvBulkEmail" runat="server" 
                        ControlToValidate="tbBulkEmail" SetFocusOnError="true" 
                        onservervalidate="cvBulkEmail_ServerValidate" ValidationGroup="Bulk" />
                </div>
            </li>
            <li class="form-line" id="Li3">
                <label class="form-label-left">
                    &nbsp;</label>
                <div class="form-input">
                    <input type="checkbox" id="cbSelectAll" onclick="SelectAll(this);" />&nbsp;Select All
                </div>
            </li>
        </ul>
        
        <table cellpadding="3" border="0" class="grid">
            <asp:Repeater ID="rptSiteEmailTemplates" runat="server" OnItemCommand="rptSiteEmailTemplates_ItemCommand"
                OnItemDataBound="rptSiteEmailTemplates_ItemDataBound">
                <HeaderTemplate>
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                            </th>
                            <th scope="col">
                                Email Code
                            </th>
                            <th scope="col">
                                Email Subject
                            </th>
                            <th scope="col">
                                Email Description
                            </th>
                            <th scope="col">
                                &nbsp;
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td scope="col">
                            <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                            <asp:HiddenField ID="hfEmailTemplateID" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="litEmailCode" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="litEmailSubject" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="litEmailDescription" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:LinkButton ID="lbOverwrite" runat="server" Text="Overwrite" CommandName="Overwrite"
                                CommandArgument='<%# Bind("EmailTemplateID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
                <HeaderTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="8">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litPage" runat="server" Text="Page:" />
                                        </td>
                </HeaderTemplate>
                <ItemTemplate>
                    <td>
                        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="AdminMember" />
                    </td>
                </ItemTemplate>
                <FooterTemplate>
                    </tr> </table> </td> </tr> </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <br />
        <asp:Button runat="server" ID="btnBulkUpdate" Text="Update Selected" CssClass="jxtadminbutton"
            OnClick="btnBulkUpdate_Click" ValidationGroup="Bulk"></asp:Button>
    </div>
</asp:Content>
