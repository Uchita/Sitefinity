<%@ Page Title="301 Redirects" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="Redirect301.aspx.cs" Inherits="JXTPortal.Website.Admin.Redirect301" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    301 Redirects
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="form-message">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
    </span>
    <asp:TextBox ID="tbUrls" runat="server" TextMode="MultiLine" Style="width: 98%;font-size: 13px;" Rows="30" />
    <br />
    <asp:Button runat="server" ID="btnSave" Text="Save &amp; Refresh Cache" CssClass="jxtadminbutton" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnRefresh" Text="Refresh 301s" CssClass="jxtadminbutton" OnClick="btnRefresh_Click" />
    
    <h2>What's in the Cache</h2>
    <asp:Literal id="ltlCache" runat="server" />

</asp:Content>
