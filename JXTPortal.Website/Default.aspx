<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/default.Master" CodeBehind="Default.aspx.cs" Inherits="JXTPortal.Website._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltlMetaContent" runat="server" />
    <asp:Literal ID="ltlCSSAndScripts" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltlAboveHeader" runat="server" />
    <asp:PlaceHolder ID="plHeader" runat="server">
    <div id="header">
        <JXTControl:ucLanguages id="ucLanguage" runat="server" />
        <asp:Literal ID="ltlHeader" runat="server" />    
    </div>
    </asp:PlaceHolder>

    <asp:Literal ID="ltlLeftNavigation" runat="server" />    
    <asp:Literal ID="ltlContent" runat="server" />
    <asp:Literal ID="ltlRightNavigation" runat="server" />  
    <asp:Literal ID="ltlFooter" runat="server" />
    <asp:Literal ID="ltlBelowFooter" runat="server" />
 </asp:Content>