<%@ Page Title="Pending Jobs" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="PendingJobs.aspx.cs" Inherits="JXTPortal.Website.Admin.PendingJobs" %>
<%@ Register Src="~/usercontrols/advertiser/ucJobsPending.ascx" TagName="ucJobsPending"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Pending Jobs</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager ID="scriptManager" runat="server" />
    <uc1:ucJobsPending ID="ucJobsPending1" runat="server" isadmin="true" />
</asp:Content>