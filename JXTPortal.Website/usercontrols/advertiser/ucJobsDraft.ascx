<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobsDraft.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucJobsDraft" %>
<%--<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobDraft" runat="server" SetLanguageCode="LabelDraftJobs" />
    </h2>
</div>
--%>
    <asp:Panel ID="pnlDraftJobs" runat="server">
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
                        <th scope="col" class="footable-last-column footable-sortable" data-value="numeric">
                            <JXTControl:ucLanguageLiteral ID="ltUcCreated" runat="server" SetLanguageCode="LabelCreated" />&nbsp;<span class="footable-sort-indicator"></span>
                        </th>
                        <th scope="col" data-sort-ignore="true">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelActions" />
                        </th>
                    </tr>
                </thead>
                <tbody>
            <asp:Repeater ID="rptDraftJobs" runat="server" OnItemCommand="rptDraftJobs_ItemCommand"
                OnItemDataBound="rptDraftJobs_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        
                        <td scope="col">
                            <asp:Literal ID="litRefNo" runat="server" />
                        </td>
                        <td scope="col">
                            <span class="CurrentJobTitle"><asp:Literal ID="litJobTitle" runat="server" /></span>
                        </td>
                        <td scope="col" data-value="<asp:Literal ID="litPostedDateSort" runat="server" />">
                            <asp:Literal ID="litPosted" runat="server" />
                        </td>
                        <td class="col">
                            <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit"></asp:LinkButton>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete"></asp:LinkButton>
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


<%--            <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
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
