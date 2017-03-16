<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="ScreeningQuestionsTemplates.aspx.cs" Inherits="JXTPortal.Website.advertiser.ScreeningQuestionsTemplates" %>

<%@ Register Src="/usercontrols/navigation/ucAdvertiserAccountNavigation.ascx" TagName="ucAdvertiserAccountNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="endOfHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-container" class="newDash">
        <div id="content">
            <div class="content-holder">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserScreeningQuestions" />
                <uc2:ucAdvertiserAccountNavigation ID="ucAdvertiserAccountNavigation1" runat="server" />
                <asp:Button ID="btnCreateNewTemplate" runat="server" CssClass="mini-new-buttons"
                    OnClick="btnCreateNewTemplate_Click" />
                
                <div class="table-responsive">
                    <asp:Repeater ID="rptScreeningQuestionsTemplate" runat="server" OnItemDataBound="rptScreeningQuestionsTemplate_ItemDataBound" OnItemCommand="rptScreeningQuestionsTemplate_ItemCommand">
                    <HeaderTemplate>
                        <table id="jobsTable" class="box-table table table-hover footable-loaded footable no-paging">
                            <thead>
                                <tr>
                                    <th scope="col">
                                        &nbsp;
                                    </th>
                                    <th scope="col">
                                        <JXTControl:ucLanguageLiteral ID="ltTemplateName" runat="server" SetLanguageCode="LabelTemplateName" />
                                    </th>
                                    <th scope="col">
                                        <JXTControl:ucLanguageLiteral ID="ltVisible" runat="server" SetLanguageCode="LabelVisible" />
                                    </th>
                                    <th scope="col">
                                       <JXTControl:ucLanguageLiteral ID="lbAction" runat="server" SetLanguageCode="LabelAction" />
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                
                            </td>
                            <td scope="col">
                                <asp:Literal ID="ltTemplateName" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="ltVisible" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:LinkButton ID="lbAction" runat="server" CommandName="Edit"> 
                                    <JXTControl:ucLanguageLiteral ID="ltAction" runat="server" SetLanguageCode="LabelEdit" />
                                </asp:LinkButton> 
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody></table></FooterTemplate>
                </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $(function () {
            $('#jobsTable').footable();
        });
    
    </script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.sort.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.filter.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.paginate.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.bookmarkable.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/newdash/newDash.js' type="text/javascript"></script>
</asp:Content>
