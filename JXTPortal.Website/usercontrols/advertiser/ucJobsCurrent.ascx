<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobsCurrent.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucJobsCurrent" %>
<%--<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobCurrent" runat="server" SetLanguageCode="LabelCurrentJobs" />
    </h2>
</div>--%>
    
    <asp:Panel ID="pnlCurrentJobs" runat="server">
        <asp:PlaceHolder ID="phRenewJob" runat="server">
            <ul class="form-section">
                <li class="form-line" id="reg-bottom-button">
                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnRefresh" runat="server" CssClass="mini-new-buttons" OnClick="btnRefresh_Click" />
                        </div>
                    </div>
                </li>
            </ul>
        </asp:PlaceHolder>
        <asp:HiddenField ID="hfIsJobScreeningProcess" runat="server" />
        <div class="table-responsive">
            <table id="jobsTable" class="box-table table table-hover" data-limit-navigation="10">
                <thead>
                    <tr>
                        <asp:PlaceHolder ID="phSelectHeader" runat="server">
                            <th scope="col" data-sort-ignore="true">
                                &nbsp;
                            </th>
                        </asp:PlaceHolder>
                        <th scope="col" class="footable-first-column footable-sortable">
                            <JXTControl:ucLanguageLiteral ID="ltUcJobRefNo" runat="server" SetLanguageCode="LabelRefNo" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" class="footable-sortable">
                            <JXTControl:ucLanguageLiteral ID="ltUcJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" class="footable-sortable" data-type="numeric">
                            <JXTControl:ucLanguageLiteral ID="ltUcViews" runat="server" SetLanguageCode="LabelViews" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" class="footable-sortable" data-type="numeric">
                            <JXTControl:ucLanguageLiteral ID="ltUcApplications" runat="server" SetLanguageCode="LabelApplications" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" class="footable-sortable" data-type="numeric">
                            <JXTControl:ucLanguageLiteral ID="ltUcPosted" runat="server" SetLanguageCode="LabelPosted" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" class="footable-sortable" data-type="numeric">
                            <JXTControl:ucLanguageLiteral ID="ltUcExpiry" runat="server" SetLanguageCode="LabelExpiry" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" class="footable-last-column footable-sortable" data-type="numeric">
                            <JXTControl:ucLanguageLiteral ID="ltUcRemaining" runat="server" SetLanguageCode="LabelRemaining" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" data-sort-ignore="true">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelActions" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                <asp:Repeater ID="rptCurrentJobs" runat="server" OnItemCommand="rptCurrentJobs_ItemCommand"
                    OnItemDataBound="rptCurrentJobs_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <asp:PlaceHolder ID="phSelectHeader" runat="server">
                                <td>
                                    <asp:CheckBox ID="cbSelect" runat="server" />    
                                </td>
                            </asp:PlaceHolder>
                            <td scope="col">
                            <asp:HiddenField ID="hfJobID" runat="server" />
                                <asp:Literal ID="litRefNo" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:HyperLink ID="hlJobTitle" runat="server" Target="_blank" CssClass="CurrentJobTitle" />
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litViews" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:HyperLink ID="hypViewApplication" NavigateUrl="#" runat="server" />
                                <%--<asp:LinkButton ID="lbApplications" runat="server" CommandName="ViewApplication">
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
                            <td>
                                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="lbCopyJob" runat="server" CommandName="Copy"></asp:LinkButton>
                                <asp:LinkButton ID="lbExpire" runat="server" CommandName="Expire"></asp:LinkButton>
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
				                <label>Show</label>
					                <select name="showRow" id="Select1" class="form-control" onchange="$('#jobsTable').data('page-size', $(this).val()).trigger('footable_initialized');">
										<option value="10">10</option>
										<option value="20">20</option>
									</select>
			                </div>
			                <div class="form-group">
				                <label>per page</label>		
			                </div>		
                            <JXTControl:ucLanguageLiteral ID="ltTotal" runat="server" SetLanguageCode="LabelTotal" />
                            <asp:Literal ID="litTotalCount" runat="server" />
                            <JXTControl:ucLanguageLiteral ID="ltApplications" runat="server" SetLanguageCode="LabelCurrentJobs" />
		                </td>
	                </tr>
                </tfoot>                        
                </table>
            </div>

                
 
<%--                <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
                    <HeaderTemplate>
                        <div id="tnt_pagination">
                            <JXTControl:ucLanguageLiteral ID="ltPage" runat="server" SetLanguageCode="LabelPage" />
                        :
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>--%>
    </asp:Panel>
