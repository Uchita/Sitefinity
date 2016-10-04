<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobsSuspended.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucJobsSuspended" %>
<div class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobCurrent" runat="server" SetLanguageCode="LabelSuspendedJobs" />
    </h2>
</div>

    <asp:Panel ID="pnlCurrentJobs" runat="server">
        <asp:PlaceHolder ID="phSortBy" runat="server">
            <ul class="form-section">
                <li class="form-line" id="Li2">
                    <div class="form-input">
                        <JXTControl:ucLanguageLiteral ID="ltSortBy" runat="server" SetLanguageCode="LabelSortBy" />
                        :
                        <asp:DropDownList ID="ddlSortBy" runat="server" />
                        <%= " " %><asp:DropDownList ID="ddlOrder" runat="server" />
                        <asp:Button ID="btnView" runat="server" CssClass="mini-new-buttons" OnClick="btnView_Click" />
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
                            <ProgressTemplate>
                                <img src="/images/loading.gif"  alt="loading" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </li>
                <asp:PlaceHolder ID="phRenewJob" runat="server">
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnRefresh" runat="server" CssClass="mini-new-buttons" OnClick="btnRefresh_Click" />
                            </div>
                        </div>
                    </li>
                </asp:PlaceHolder>
            </ul>
        </asp:PlaceHolder>
        <asp:HiddenField ID="hfIsJobScreeningProcess" runat="server" />
        <asp:UpdatePanel ID="upCurrentJobs" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                <asp:Repeater ID="rptCurrentJobs" runat="server" OnItemCommand="rptCurrentJobs_ItemCommand"
                    OnItemDataBound="rptCurrentJobs_ItemDataBound">
                    <HeaderTemplate>
                        <table id="jobsTable" class="box-table table table-hover" data-limit-navigation="10">
                            <thead>
                                <tr>
                                    <th scope="col" class="footable-first-column footable-sortable">
                                        <JXTControl:ucLanguageLiteral ID="ltUcJobRefNo" runat="server" SetLanguageCode="LabelRefNo" />&nbsp;<span class="footable-sort-indicator"></span>
                                    </th>
                                    <th scope="col" class="footable-sortable">
                                        <JXTControl:ucLanguageLiteral ID="ltUcJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />&nbsp;<span class="footable-sort-indicator"></span>
                                    </th>
                                    <th scope="col" class="footable-sortable" data-type="numeric">
                                        <JXTControl:ucLanguageLiteral ID="ltUcExpiry" runat="server" SetLanguageCode="LabelExpiry" />&nbsp;<span class="footable-sort-indicator"></span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td scope="col">
                                <asp:Literal ID="litRefNo" runat="server" />
                            </td>
                            <td scope="col">
                                <span class="CurrentJobTitle"><asp:Literal ID="litJobTitle" runat="server" /></span>
                            </td>
                            <td scope="col" data-value="<asp:Literal ID="litExpiryDateSort" runat="server" />">
                                <asp:Literal ID="litExpiry" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
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
                    </FooterTemplate>
                </asp:Repeater>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
