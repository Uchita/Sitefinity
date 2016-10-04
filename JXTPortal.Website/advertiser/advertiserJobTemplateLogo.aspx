<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="advertiserJobTemplateLogo.aspx.cs" Inherits="JXTPortal.Website.advertiser.advertiserJobTemplateLogo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>
<div id="content">
    <div class="content-holder">       
       <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserJobTemplateLogo" />       
       <JXTControl:AdvertiserJobTemplateLogo ID="ucAdvertiserJobTemplateLogo" runat="server" IsAdmin="False" />  
    </div>
</div> 
</asp:Content>
