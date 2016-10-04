﻿<%@ Page Title="MultiLingual Salary Type" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="MultiLingualSalary.aspx.cs" Inherits="JXTPortal.Website.Admin.MultiLingualSalary" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    MultiLingual Salary Type - Add/Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="mlc-language-field">
                <label class="form-label-left">
                    Language:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="true" DataTextField="LanguageName"
                        DataValueField="LanguageID" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
                </div>
            </li>
        </ul>
        <asp:Repeater ID="rptSalary" runat="server" OnItemDataBound="rptSalary_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col">
                                Language
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
                        <asp:HiddenField ID="hfSalaryTypeId" runat="server" />
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
                            Visible="false" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
