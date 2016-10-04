<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="JXTPortal.Website.members.ChangePassword" %>
<%@ Register Src="~/usercontrols/member/ucMemberChangePassword.ascx" TagName="ucMemberChangePassword" TagPrefix="uc3" %>
<%@ Register src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" tagname="ucMemberAccountNavigation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtMemberNewPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>

    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

    <div id="content-container">
    <div id="content">  
            <div class="content-holder">
            <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
                <%--<JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage1" runat="server" SetSystemPageCode="SystemPage_MemberDefaultWelcome" />--%>
                <uc3:ucMemberChangePassword ID="ucMemberChangePassword1" runat="server" />
            </div>
        </div>
    </div>

    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/newdash/newDash.js'></script>
</asp:Content>
