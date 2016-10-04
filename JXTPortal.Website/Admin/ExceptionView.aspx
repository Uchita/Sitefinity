<%@ Page Title="Exceptions View" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="ExceptionView.aspx.cs" Inherits="JXTPortal.Website.Admin.ExceptionView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<h2><span><a>Admin</a></span><span> &gt; </span><span>Exceptions</span></h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <a href="/Admin/Exceptions.aspx">Back to Exceptions</a><br /><br />
    
    <asp:Literal ID="ltlException" runat="server"></asp:Literal>
</asp:Content>
