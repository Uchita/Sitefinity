<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobsPending.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucJobsPending" %>
<script type="text/javascript">
    function JobStatusUpdate() {
        $("#jobsTable input:checked").each(function (index) {
            var id = $(this).attr('id');
            var newid = '#' + id.replace(/_cbSelect/g, '_ddlAction');
            var value = $('#ddlUpdateRecords').val();

            $(newid).val(value);
        });
        // $("div").text(n + (n === 1 ? " is" : " are") + " checked!");
    }
</script>
    <div class="form-header-group">
        <h1>
            <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobPending" runat="server" SetLanguageCode="LabelPendingJobs" />
        </h1>
    </div>
    <asp:Panel ID="pnlPendingJobs" runat="server">
        <asp:PlaceHolder ID="phSortBy" runat="server" Visible="False">
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
                                <img src="/images/loading.gif"  alt="loading"/>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </li>
            </ul>
        </asp:PlaceHolder>
        <asp:UpdatePanel ID="upCurrentJobs" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phBulkUpdate" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlUpdateRecords" runat="server" Width="15%" ClientIDMode="Static" />
                    <asp:Button ID="btnBulkUpdate" runat="server" CssClass="mini-new-buttons" Text="Update Multiple" OnClick="btnBulkUpdate_Click" />
                </asp:PlaceHolder>
                <span class="form-required"><asp:Literal ID="litError" runat="server" /></span>
                    <div class="table-responsive">
                        <table id="jobsTable" class="box-table table table-hover grid" data-limit-navigation="10">
                            <thead>
                                <tr>
                                    <asp:PlaceHolder ID="phSelectHeader" runat="server">
                                        <th scope="col" data-sort-ignore="true">
                                            &nbsp;
                                        </th>
                                    </asp:PlaceHolder>
                                    <th scope="col" class="footable-first-column footable-sortable">
                                        <JXTControl:ucLanguageLiteral ID="ltUcJobRefNo" runat="server" SetLanguageCode="LabelRefNo" />&nbsp;<span class="footable-sort-indicator">
                                    </th>
                                    <th scope="col" class="footable-sortable">
                                        <JXTControl:ucLanguageLiteral ID="ltUcJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />&nbsp;<span class="footable-sort-indicator">
                                    </th>
                                    <th scope="col" class="footable-sortable" data-type="numeric">
                                        <JXTControl:ucLanguageLiteral ID="ltUcPosted" runat="server" SetLanguageCode="LabelPosted" />&nbsp;<span class="footable-sort-indicator">
                                    </th>
                                    <asp:PlaceHolder ID="phEditHeader" runat="server">
                                        <th scope="col" class="footable-sortable">
                                            <JXTControl:ucLanguageLiteral ID="ltUcStatus" runat="server" SetLanguageCode="LabelStatus" />&nbsp;<span class="footable-sort-indicator">
                                        </th>
                                        <th scope="col" class="footable-sortable">
                                            <JXTControl:ucLanguageLiteral ID="ltUcAction" runat="server" SetLanguageCode="LabelActions" />&nbsp;<span class="footable-sort-indicator">
                                        </th>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phActionHeader" runat="server">
                                        <th class="footable-sortable">
                                            Advertiser&nbsp;<span class="footable-sort-indicator">
                                        </th>
                                        <th data-sort-ignore="true">
                                            Action
                                        </th>
                                    </asp:PlaceHolder>
                                </tr>
                            </thead>
                            <tbody>

                <asp:Repeater ID="rptCurrentJobs" runat="server" OnItemCommand="rptCurrentJobs_ItemCommand"
                    OnItemDataBound="rptCurrentJobs_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <asp:PlaceHolder ID="phSelect" runat="server">
                                <td scope="col">
                                    <asp:CheckBox ID="cbSelect" runat="server" AutoPostBack="true" />
                                </td>
                            </asp:PlaceHolder>
                            <td scope="col">
                                <asp:HiddenField ID="hfJobID" runat="server" />
                                <asp:Literal ID="litRefNo" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:HyperLink ID="hlJobTitle" runat="server" Target="_self" CssClass="CurrentJobTitle" />
                            </td>
                            <td scope="col" data-value="<asp:Literal ID="litPostedSort" runat="server" />">
                                <asp:Literal ID="litPosted" runat="server" />
                            </td>
                            <asp:PlaceHolder ID="phEdit" runat="server">
                                <td scope="col">
                                    <asp:Literal ID="litStatus" runat="server" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit"></asp:LinkButton>
                                </td>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="phAction" runat="server">
                                <td>
                                    <asp:Literal ID="ltAdvertiser" runat="server" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAction" runat="server" Width="100%" />
                                </td>
                            </asp:PlaceHolder>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel ID="plNoResultsTableRow" runat="server" Visible="false">
                    <tr><td colspan="8">No results found</td></tr>
                </asp:Panel>
                    </tbody>
                    <asp:Panel ID="tableFooter" runat="server">
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
                    </asp:Panel>
                </table>
            </div>
                <%--<asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
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
                <br />
                <asp:PlaceHolder ID="phUpdateRecords" runat="server" Visible="false">
                    <asp:Button ID="btnUpdateRecords" runat="server" CssClass="mini-new-buttons" Text="Update Records"
                        OnClick="btnUpdateRecords_Click" /><asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <img src="/Admin/images/ajax-loader.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
