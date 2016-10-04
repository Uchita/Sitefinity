<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="MemberEdit.aspx.cs" Inherits="JXTPortal.Website.members.MemberEdit" %>
<%@ Register Src="~/usercontrols/member/ucMemberEdit.ascx" TagName="ucMemberEdit" TagPrefix="uc2" %>
<%@ Register src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" tagname="ucMemberAccountNavigation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />

    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
    <script type="text/javascript">
        $(function () {

            $('#ckAddMailingAddress').change(function () {
                if ($(this).is(":checked")) {
                    $("#divMailingAddress").show();
                    $("#divMailingSuburb").show();
                    $("#divMailingPostcode").show();
                    $("#divMailingState").show();
                    $("#divMailingCountry").show();
                }
                else {
                    $("#divMailingAddress").hide();
                    $("#divMailingSuburb").hide();
                    $("#divMailingPostcode").hide();
                    $("#divMailingState").hide();
                    $("#divMailingCountry").hide();
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div id="content-container">
    <div id="content">
        <div class="content-holder">
            <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
            <%--<JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage1" runat="server" SetSystemPageCode="SystemPage_MemberDefaultWelcome" />--%>
            <uc2:ucMemberEdit ID="ucMemberEdit1" runat="server" />
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
