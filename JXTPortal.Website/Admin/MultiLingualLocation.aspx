<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="MultiLingualLocation.aspx.cs" Inherits="JXTPortal.Website.Admin.MultiLingualLocation"
    Title="MultiLingual Location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    MultiLingual Location - Add/Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="mll-language-field">
                <label class="form-label-left">
                    Language:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="true" DataTextField="LanguageName"
                        DataValueField="LanguageID" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
                </div>
            </li>
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Country:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" DataTextField="CountryName"
                        DataValueField="CountryID" 
                        onselectedindexchanged="ddlCountry_SelectedIndexChanged" />
                </div>
            </li>
        </ul>
        <asp:Repeater ID="rptLocation" runat="server" OnItemDataBound="rptLocation_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col">
                                Location
                            </th>
                            <th scope="col">
                                <%# ddlLanguage.SelectedItem.Text %>
                            </th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Literal ID="litDefault" runat="server" />
                        <asp:HiddenField ID="hfLocationId" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbMultiLingual" runat="server" />
                        <asp:RequiredFieldValidator ID="Req_ValMultiLingual" runat="server" ControlToValidate="tbMultiLingual"
                            ErrorMessage="Required" />
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
                        <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                            Visible="false" CssClass="form-submit-button" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
