<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="JobTracker.aspx.cs" Inherits="JXTPortal.Website.advertiser.JobTracker" %>
<%@ Register Src="/usercontrols/navigation/ucAdvertiserAccountNavigation.ascx" TagName="ucAdvertiserAccountNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="/styles/lib/footable.core.css" />

    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <div id="content-container" class="newDash">
        <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_Advertiser_Job_Tracker" />
             <uc2:ucAdvertiserAccountNavigation ID="ucAdvertiserAccountNavigation1" runat="server" />

            <%--<div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerJobTracker" runat="server"
                        SetLanguageCode="LinkButtonJobTracker" />
                </h2>
            </div>--%>

            <asp:Panel ID="pnlCurrentJobs" runat="server">
                <div class="table-responsive">
                <table id="jobsTable" class="box-table table table-hover" data-limit-navigation="10">
                    <thead>
                        <tr>
                            <th scope="col" class="footable-first-column footable-sortable">
                                <JXTControl:ucLanguageLiteral ID="ltUcJobRefNo" runat="server" SetLanguageCode="LabelRefNo" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col" class="footable-sortable">
                                <JXTControl:ucLanguageLiteral ID="ltUcJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col"  class="footable-sortable"  data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="ltUcViews" runat="server" SetLanguageCode="LabelViews" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col"  class="footable-sortable"  data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="ltUcApplications" runat="server" SetLanguageCode="LabelApplications" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col"  class="footable-sortable" data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="ltUcPosted" runat="server" SetLanguageCode="LabelPosted" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col"  class="footable-sortable" data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="ltUcExpiry" runat="server" SetLanguageCode="LabelExpiry" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col"  class="footable-last-column footable-sortable"  data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="ltUcRemaining" runat="server" SetLanguageCode="LabelRemaining" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                <asp:Repeater ID="rptCurrentJobs" runat="server" OnItemCommand="rptCurrentJobs_ItemCommand"
                    OnItemDataBound="rptCurrentJobs_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td scope="col">
                                <asp:Literal ID="litRefNo" runat="server" />
                            </td>
                            <td scope="col">
                                <span class="CurrentJobTitle"><asp:Literal ID="litJobTitle" runat="server" /></span>
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litViews" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:HyperLink ID="hypViewApplication" NavigateUrl="#" runat="server" />
                                <%--<asp:LinkButton ID="lbViewApplication" runat="server" CommandName="ViewApplication">
                                    <asp:Literal ID="litApplications" runat="server" />
                                </asp:LinkButton>--%>
                            </td>
                            <td scope="col" data-value="<asp:Literal ID="litPostedDateSort" runat="server" />">
                                <asp:Literal ID="litPosted" runat="server" />
                            </td>
                            <td scope="col" data-value="<asp:Literal ID="litExpiryDateSort" runat="server" />">
                                <asp:Literal ID="litExpiry" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litRemaining" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel ID="plNoResultsTableRow" runat="server" Visible="false">
                    <tr><td colspan="9">No results found</td></tr>
                </asp:Panel>
                    </tbody>
                    <tfoot class="TablePaginationFooter hide-if-no-paging">
	                    <tr>
		                    <td colspan="10" class="form-inline text-right">                                    
			                    <div class="form-group pull-left">
				                    <div class="pagination-wrap">
				                    </div>
			                    </div>
			                    <div class="form-group">
				                    <label for="exampleInputName2">Show</label>
					                    <select name="showRow" id="Select1" class="form-control" onchange="$('#jobsTable').data('page-size', $(this).val()).trigger('footable_initialized');">
											<option value="10">10</option>
											<option value="20">20</option>
										</select>
			                    </div>
			                    <div class="form-group">
				                    <label for="exampleInputEmail2">per page</label>		
			                    </div>		
		                    </td>
	                    </tr>
                    </tfoot>
                    </table>
                </div>



<%--                <asp:Repeater ID="rptCurrentPage" runat="server" OnItemCommand="rptCurrentPage_ItemCommand"
                    OnItemDataBound="rptCurrentPage_ItemDataBound">
                    <HeaderTemplate>
                        <div id="tnt_pagination">
                            <JXTControl:ucLanguageLiteral ID="ltPage" runat="server" SetLanguageCode="LabelPage" />
                        :
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="SubAccounts" />
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>--%>


            </asp:Panel>
            <%--<asp:Panel ID="pnlApplications" runat="server" Visible="false">
                <asp:HyperLink ID="hypLinkDownload" runat="server" CssClass="mini-new-buttons" Target="_blank"></asp:HyperLink>
                <ul class="form-section">
                    <li class="form-line" id="adv-accounttype-field"><strong>
                        <JXTControl:ucLanguageLiteral ID="ltJobName" runat="server" SetLanguageCode="LabelJobTitle" />
                    </strong>:
                        <asp:Literal ID="litJobName" runat="server" />
                    </li>
                </ul>
                <asp:Repeater ID="rptJobApplication" runat="server" OnItemCommand="rptJobApplication_ItemCommand"
                    OnItemDataBound="rptJobApplication_ItemDataBound">
                    <HeaderTemplate>
                        <table id="box-table">
                            <thead>
                                <tr>
                                    <th scope="col">
                                        &nbsp;
                                    </th>
                                    <th scope="col">
                                        <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerDate" runat="server" SetLanguageCode="LabelDateEntered" />
                                    </th>
                                    <th scope="col">
                                        <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerStatus" runat="server" SetLanguageCode="LabelStatus" />
                                    </th>
                                    <th scope="col">
                                        <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerFirstName" runat="server"
                                            SetLanguageCode="LabelFirstName" />
                                    </th>
                                    <th scope="col">
                                        <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerSurname" runat="server" SetLanguageCode="LabelSurname" />
                                    </th>
                                    <th scope="col">
                                        <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerEmail" runat="server" SetLanguageCode="LabelEmail" />
                                    </th>
                                    <asp:PlaceHolder ID="plNoteHeader" runat="server" Visible="false">
                                        <th scope="col">
                                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerNote" runat="server" SetLanguageCode="LabelNote" />
                                        </th>
                                    </asp:PlaceHolder>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbSelect" runat="server" CommandName="Select">
                                    <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerSelect" runat="server" SetLanguageCode="ButtonSelect" />
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:Literal ID="litApplicationDate" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="litApplicationStatus" runat="server" Text="Status" />
                            </td>
                            <td>
                                <asp:Literal ID="litFirstName" runat="server" Text="First Name" />
                            </td>
                            <td>
                                <asp:Literal ID="litSurname" runat="server" Text="Surname" />
                            </td>
                            <td>
                                <asp:HyperLink ID="hlEmailAddress" runat="server" Text="Email" />
                            </td>
                            <asp:PlaceHolder ID="plNote" runat="server" Visible="false">
                                <td>
                                    <asp:LinkButton ID="lbNote" runat="server" CommandName="Note">
                                        <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerNewEdit" runat="server" SetLanguageCode="LabelNew" />
                                    </asp:LinkButton>
                                </td>
                            </asp:PlaceHolder>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody></table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
                    <HeaderTemplate>
                        <div id="tnt_pagination">
                            <JXTControl:ucLanguageLiteral ID="ltPage" runat="server" SetLanguageCode="LabelPage" />
                        :
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="SubAccounts" />
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:Panel>--%>
            <div id="dialog" title="Edit Note" style="display: none;">
                <asp:HiddenField ID="hfJobAppId" runat="server" />
                <asp:TextBox ID="tbEditNote" runat="server" Rows="5" TextMode="MultiLine" Style="width: 95%" /><br />
                <asp:LinkButton ID="btnSaveNote" runat="server" Text="Save" OnClick="btnSaveNote_Click"
                    Style="float: right" />
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
