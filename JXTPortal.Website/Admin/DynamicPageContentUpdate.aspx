<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/admin.master"
    CodeBehind="DynamicPageContentUpdate.aspx.cs" Inherits="JXTPortal.Website.Admin.DynamicPageContentUpdate"
    Title="Dynamic Pages Content Update" validateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Bulk Path Update</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<p>Updates the Dynamic Pages, Web Containers and Global Settings (Meta Tags only)</p>
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="sr-siterolename-field">
                <label class="form-label-left">
                    From:</label>
                <div class="form-input">
                    <asp:TextBox ID="txtFrom" runat="server" Width="500" />
                    <asp:RequiredFieldValidator ID="ReqVal_txtFrom" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtFrom" />
                </div>
            </li>
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    To:</label>
                <div class="form-input">
                    <asp:TextBox ID="txtTo" runat="server" Width="500" />
                    <asp:RequiredFieldValidator ID="ReqVal_txtTo" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtTo" />
                </div>
            </li>
            <li class="form-line" id="Li2">
                <label class="form-label-left">
                    Include/Update System Page:</label>
                <div class="form-input">
                    <asp:CheckBox ID="chkInclude" runat="server" Checked="true" />
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Update" OnClick="btnSave_Click" CssClass="jxtadminbutton"
                            OnClientClick="return confirm('Are you certain you want to replace this content?');" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
