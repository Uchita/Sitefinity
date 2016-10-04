<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="PublicProfile.aspx.cs" Inherits="JXTPortal.Website.members.PublicProfile" %>

<%@ Register Src="~/usercontrols/peoplesearch/ucPublicProfile.ascx" TagName="ucPublicProfile"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
    <div class="content-holder">
        <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_PublicProfile" />
        <uc1:ucPublicProfile ID="ucPeopleSearch1" runat="server" />
    </div>
    </div>
</asp:Content>
