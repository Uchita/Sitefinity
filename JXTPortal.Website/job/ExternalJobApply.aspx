<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ExternalJobApply.aspx.cs" Inherits="JXTPortal.Website.job.ExternalJobApply" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftNav" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            
            <asp:Literal ID="ltExternalJobApply" runat="server" Visible="false" Text="" />
            <iframe runat="server" scrolling="no" frameborder="0" id="iframe_app" width="600px" height="950px" style="" allowtransparency="true"></iframe>
            
        </div>
    </div>
</asp:Content>