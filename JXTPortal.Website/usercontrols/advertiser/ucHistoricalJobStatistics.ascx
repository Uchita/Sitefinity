<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHistoricalJobStatistics.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.advertiser.ucHistoricalJobStatistics" %>
<%--<div id="divHeader" runat="server" class="form-header-group">
    <h2 class="form-header">
        <JXTControl:ucLanguageLiteral ID="ltHistoricalJobStatistics" runat="server" SetLanguageCode="LabelArchivedJobs" />
    </h2>
</div>--%>
    <ul class="form-section">
        <li class="form-line" id="jobs-dateposted-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelDatePosted" />
                (<JXTControl:ucLanguageLiteral ID="ltFromDate" runat="server" SetLanguageCode="LabelFromDate" />) :</label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="tbFromDate" MaxLength="10"></asp:TextBox>
                <asp:ImageButton ID="ibFromDate" runat="server" SkinID="CalendarImageButton" ImageUrl="/images/minical.gif"
                    CausesValidation="False" />
                <ajaxToolkit:CalendarExtender ID="cal_tbFormDate" runat="server" Format="dd/MM/yyyy"
                    TargetControlID="tbFromDate" PopupButtonID="ibFromDate">
                </ajaxToolkit:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqVal_FromDate" runat="server" ControlToValidate="tbFromDate"
                    ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic" ValidationGroup="Historical"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvFromDate" runat="server" ControlToValidate="tbFromDate" OnServerValidate="cvFromDate_ServerValidate" ValidationGroup="Historical" />
            </div>
        </li>
        <li class="form-line" id="Li1">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltDuration" runat="server" SetLanguageCode="LabelDuration" />
                :</label>
            <div class="form-input">
                <asp:DropDownList ID="ddlDuration" runat="server" />
            </div>
        </li>
        <li class="form-line" runat="server" visible="false">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltSortBy" runat="server" SetLanguageCode="LabelSortBy" />
                :</label>
            <div class="form-input">
                <asp:DropDownList ID="ddlSortBy" runat="server" />
                &nbsp;<asp:DropDownList ID="ddlOrder" runat="server" />
            </div>
        </li>
    </ul>
    <asp:UpdatePanel ID="upCurrentJobs" runat="server">
        <ContentTemplate>
<%--            <ul>
                <li class="form-line" id="reg-bottom-button">
--%>                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" ValidationGroup="Historical"
                                CssClass="mini-new-buttons" />
                            <asp:Button ID="btnQuickRepost" runat="server" CssClass="mini-new-buttons" OnClick="btnQuickRepost_Click"
                                Visible="false" />
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
                                <ProgressTemplate>
                                    <img src="/images/loading.gif" alt="loading"/>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
    <%--            </li>
            </ul>
    --%>        <p>
                <JXTControl:ucLanguageLiteral ID="ltNoResult" runat="server" SetLanguageCode="LabelNoResultFound"
                    Visible="false" />
            </p>
            <asp:Panel ID="pnlStatistics" runat="server" Visible="false">
            <div class="box-table-responsive">
                <table id="jobsTable" class="box-table table table-hover" data-limit-navigation="10" class="ddd">
                    <thead>
                        <tr>
                            <asp:PlaceHolder ID="phSelectHeader" runat="server">
                                <th scope="col" data-sort-ignore="true">
                                    &nbsp;
                                </th>
                            </asp:PlaceHolder>
                            <th scope="col" class="footable-first-column footable-sortable">
                                <JXTControl:ucLanguageLiteral ID="UclitRefNo" runat="server" SetLanguageCode="LabelRefNo" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col" class="footable-sortable">
                                <JXTControl:ucLanguageLiteral ID="UclitJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col" class="footable-sortable" data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="UclitViewed" runat="server" SetLanguageCode="LabelViewed" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col" class="footable-sortable" data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="UclitApplications" runat="server" SetLanguageCode="LabelApplications" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col" class="footable-last-column footable-sortable" data-type="numeric">
                                <JXTControl:ucLanguageLiteral ID="UclitDatePosted" runat="server" SetLanguageCode="LabelDatePosted" />&nbsp;<span class="footable-sort-indicator"></span>
                            </th>
                            <th scope="col" data-sort-ignore="true">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelActions" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>

                <asp:Repeater ID="rptHistoricalStatistics" runat="server" OnItemDataBound="rptHistoricalStatistics_ItemDataBound"
                    OnItemCommand="rptHistoricalStatistics_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <asp:PlaceHolder ID="phSelect" runat="server">
                                <td>
                                    <asp:CheckBox ID="cbSelect" runat="server"></asp:CheckBox>
                                </td>
                            </asp:PlaceHolder>
                            <td scope="col">
                                <asp:Literal ID="litRefNo" runat="server" />
                            </td>
                            <td>
                                <span class="CurrentJobTitle"><asp:Literal ID="litJobTitle" runat="server" /></span>
                            </td>
                            <td scope="col">
                                <asp:Literal ID="litViewed" runat="server" />
                            </td>
                            <td scope="col">
                                <asp:LinkButton ID="lbApplication" runat="server" CommandName="ViewApplication">
                                    <asp:Literal ID="litApplications" runat="server" /></asp:LinkButton>
                            </td>
                            <td scope="col" data-value="<asp:Literal ID="litDatePostedSort" runat="server" />">
                                <asp:Literal ID="litDatePosted" runat="server" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hfJobID" runat="server" />
                                <asp:LinkButton ID="lbCopyJob" runat="server" CommandName="CopyJob"></asp:LinkButton><br />
                                <asp:LinkButton ID="lbRepostJob" runat="server" CommandName="RepostJob"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel ID="plNoResultsTableRow" runat="server" Visible="false">
                    <tr><td colspan="7">No results found</td></tr>
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
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfAdvertiser" runat="server" Value="0" />
    <br />
    <asp:Button ID="btnDownload" runat="server" Visible="false" OnClick="btnDownload_Click"
        CssClass="mini-new-buttons" />

