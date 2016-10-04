<%@ Page Title="Admin Login Page Edit" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="AdminLoginPageEdit.aspx.cs" Inherits="AdminLoginPageEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Admin Login Page
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="form-message">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
    </span>
    <ul class="form-section">
        <li class="form-line" id="adv-accountsettings-field">
            <h2>
                Admin Login Page Content</h2>
        </li>
        <li class="form-line" id="Li3">
            <label class="form-input">
                <strong>Page Content</strong></label>
        </li>
        <li class="form-line" id="Li4">
            <label class="form-input">
                <FredCK:CKEditorControl ID="tbLoginContent" runat="server" Width="650px" Height="400px"
                    CustomConfig="custom_config.js" Toolbar="SmallToolbar" EnableViewState="false">
                </FredCK:CKEditorControl>
            </label>
        </li>
        <li class="form-line" id="adv-lastmodified-field">
            <label class="form-label-left">
                Last Modified:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="dataLastModified" MaxLength="10"></asp:Label>
            </div>
        </li>
        <li class="form-line" id="adv-modifiedby-field">
            <label class="form-label-left">
                Last Modified By:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="dataModifiedBy" MaxLength="10"></asp:Label>
            </div>
        </li>
    </ul>
    <ul class="form-section">
        <li class="form-line">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper-left">
                    <asp:Button ID="btnSubmit" runat="server" Text="Save Admin Page Content" CssClass="jxtadminbutton"
                        OnClick="btnSubmit_Click" />
                </div>
            </div>
        </li>
    </ul>
</asp:Content>
