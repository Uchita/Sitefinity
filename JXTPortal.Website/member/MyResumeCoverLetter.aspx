<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="MyResumeCoverLetter.aspx.cs" Inherits="JXTPortal.Website.members.MyResumeCoverLetter" %>
<%@ Register Src="~/usercontrols/member/ucMemberFiles.ascx" TagName="ucMemberFiles"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <div id="content">
        <div class="content-holder">
            <%--<JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage1" runat="server" SetSystemPageCode="SystemPage_MemberDefaultWelcome" />--%>
            <uc4:ucMemberFiles ID="ucMemberFiles1" runat="server" />
        </div>
    </div>
</asp:Content>
