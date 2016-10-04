﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="SiteNewsIndustryEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteNewsIndustryEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News Industry - Add/Edit
    <a href='http://support.jxt.com.au/solution/articles/116440-news-categories-' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    News Industry Name:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="tbIndustryName" runat="server" /><asp:RequiredFieldValidator ID="ReqVal_IndustryName"
                        runat="server" Display="Dynamic" ControlToValidate="tbIndustryName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="reg-num-employees">
                <label class="form-label-left">
                    Sequence:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtSequence" runat="server" CssClass="form-textbox validate[Numeric]"
                        Columns="5" />
                    <asp:RequiredFieldValidator ID="ReqVal_txtSequence" runat="server" Display="Dynamic"
                        ControlToValidate="txtSequence" ErrorMessage="Required" />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter the valid sequence"
                        ControlToValidate="txtSequence" MinimumValue="0" MaximumValue="99999" Display="Dynamic"></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="Li4">
                <label class="form-label-left">
                    Last Modified:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModified" runat="server"></asp:Literal>
                </div>
            </li>
            <li class="form-line" id="Li5">
                <label class="form-label-left">
                    Last Modified By:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModifiedBy" runat="server"></asp:Literal>
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Insert" OnClick="btnSave_Click" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>