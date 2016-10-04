<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CompanySearch.aspx.cs" Inherits="JXTPortal.Website.CompanySearch" Title="Untitled Page" %>
<%@ Register Src="~/usercontrols/advertiser/ucCompanySearch.ascx" TagName="ucCompanySearch"
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
                    <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_CompanySearch" />
                    <uc1:ucCompanySearch id="ucCompanySearch" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
