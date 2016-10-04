<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="NewsSearch.aspx.cs" Inherits="JXTPortal.Website.NewsSearch" Title="Untitled Page" %>
<%@ Register Src="~/usercontrols/news/ucNewsSearch.ascx" TagName="ucNewsSearch"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftNav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
            </ajaxToolkit:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_NewsSearch" />
                    <uc1:ucNewsSearch id="ucNewsSearch" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
