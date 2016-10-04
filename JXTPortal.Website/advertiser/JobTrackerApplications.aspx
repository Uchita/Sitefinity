<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true" CodeBehind="JobTrackerApplications.aspx.cs" Inherits="JXTPortal.Website.advertiser.JobTrackerApplications" %>
<%@ Register Src="/usercontrols/navigation/ucAdvertiserAccountNavigation.ascx" TagName="ucAdvertiserAccountNavigation" TagPrefix="uc2" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />

    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap.min.js' type="text/javascript"></script>
    <% } %>
    
	<link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
	<link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
	<link rel="stylesheet" href="/styles/lib/footable.core.css"/> <!-- New Script -->
	<link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content-container" class="newDash container">
    <div id="content" class="row">  
        <div id="content-holder" class="col-sm-12">
            
			<h1><JXTControl:ucLanguageLiteral ID="ltApplicationManager" runat="server" SetLanguageCode="LabelApplicationManager" /></h1><!-- Dynamic Content -->
            <uc2:ucAdvertiserAccountNavigation ID="ucAdvertiserAccountNavigation1" runat="server" />
                
                <%--<asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
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
--%>
                
				<!-- Start the Job Tracker Datatable -->
				<div id="jobTrackerTbl">
					<h2 id="appliedJobTitle"><asp:Literal ID="litJobName" runat="server" /></h2>
                    
                    <asp:PlaceHolder ID="phlApplications" runat="server">

					<div class="row">
						<div class="col-md-12">								
							<p class="text-left">
                                <asp:LinkButton ID="lnkDownloadSelected" runat="server" 
                                    CssClass="btn btn-default downloadSelected" onclick="lnkDownloadSelected_Click"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelDownloadSelectedApplicants" /></asp:LinkButton> 
                                &nbsp;<asp:LinkButton ID="lnkEmailSelected" runat="server" 
                                    CssClass="btn btn-default email-selected" onclick="lnkEmailSelected_Click"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelEmailMeSelectedApplicants" /></asp:LinkButton>
                                    
                                &nbsp;<asp:HyperLink ID="hypLinkDownload" runat="server" CssClass="btn btn-default downloadSelected" Target="_blank" Text="Download in Excel"></asp:HyperLink>
								<%--<a id="downloadSelected" class="btn btn-default">Download Selected</a> 
								<a id="emailSelected" class="btn btn-default">Email Selected</a> --%>
							</p>
						</div>
						<div class="col-md-12">								
							<div class="form-inline">
								<span class="hidden-xs"><JXTControl:ucLanguageLiteral ID="ltSearch" runat="server" SetLanguageCode="ButtonSearch" />: </span><input id="filter" type="text" class="form-control" placeholder="Keyword" />
                                 <asp:DropDownList ID="ddlApplicationStatus" runat="server" CssClass="form-control filter-status" />
								<%--<select class="form-control filter-status">
								    <option value="">- Select Status -</option>
								    <option>Applied</option>
								    <option>Shortlisted</option>
								    <option>Rejected</option>
								</select>--%>
							</div>
						</div>
					</div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="plhSuccess" runat="server" Visible="false">
                        <br /><div class="alert alert-success">
						    <strong><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelSentApplicantEmail" /></strong>
					    </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="plhFailed" runat="server" Visible="false">
                        <br /><div class="alert alert-danger">
                            <strong><JXTControl:ucLanguageLiteral ID="ltNoResult" runat="server" SetLanguageCode="LabelNoResultFound" /></strong>
                        </div>
                    </asp:PlaceHolder>
                    <%--<div class="status">

                    </div>
					
					<div class="alert alert-danger">
						<strong>Error Message!</strong> Some more text here.
					</div>--%>
                    <div class="table-responsive">
                    <asp:Repeater ID="rptJobApplication" runat="server" OnItemCommand="rptJobApplication_ItemCommand"
                    OnItemDataBound="rptJobApplication_ItemDataBound">
                    <HeaderTemplate>
                    <table id="jobsTable" class="table table-bordered table-striped job-tracker" data-filter="#filter" data-page-size="10">
						<thead>
							<tr>
							    <th class="applicantCheckboxLabel" data-sort-ignore="true" data-name="Select"><input id="chkCheckAll" type="checkbox" class="checkall" /></th>
							    <th class="applicantViewLabel" data-sort-ignore="true" data-hide="phone,tablet" data-name="Preview"></th>
							    <th class="applicantFnameLabel" data-toggle="true"><JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerFirstName" runat="server" SetLanguageCode="LabelFirstName" /></th>
							    <th class="applicantLnamwLabel" data-hide="phone"><JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerSurname" runat="server" SetLanguageCode="LabelSurname" /></th>
							    <th class="applicantStateLabel" data-hide="phone,tablet"><JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerState" runat="server" SetLanguageCode="LabelState" /></th>
							    <th class="applicantPostcodeLabel" data-hide="phone,tablet"><JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerPostcode" runat="server" SetLanguageCode="LabelPostcode" /></th>
							    <th class="applicantStatusLabel" data-hide="phone"><JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerStatus" runat="server" SetLanguageCode="LabelStatus" /></th>
							    <th class="applicantEmailLabel" data-hide="phone,tablet"><JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerEmail" runat="server" SetLanguageCode="LabelEmail" /></th>
							    <th class="applicantApplicationDateLabel" data-hide="phone,tablet"><JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerDate" runat="server" SetLanguageCode="LabelDateEntered" /></th>
							    <th class="applicantDownloadedLabel" data-hide="phone,tablet" data-sort-ignore="true" data-name="Download Application"><i class="fa fa-download"></i></th>
                                
                                    <%--<asp:PlaceHolder ID="plNoteHeader" runat="server" Visible="false">
                                        <th scope="col">
                                            <JXTControl:ucLanguageLiteral ID="ltSearch" runat="server" SetLanguageCode="ButtonSearch" />
                                        </th>
                                    </asp:PlaceHolder>--%>
							</tr>
						</thead>
						<tbody>


                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
							<td class="applicantCheckbox">
                                <asp:CheckBox ID="chkApplicationID" runat="server" />
                                <asp:HiddenField ID="hiddenApplicationID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "JobApplicationID").ToString() %>' /></td>
							<td class="applicantView"><a href="/advertiser/jobapplicationedit.aspx?jobapplicationid=<%# DataBinder.Eval(Container.DataItem, "JobApplicationID").ToString() %>"><i class="fa fa-search"></i></a></td>
							<td class="applicantFname"><asp:Literal ID="litFirstName" runat="server" Text="" /></td>
							<td class="applicantLname"><asp:Literal ID="litSurname" runat="server" Text="" /></td>
							<td class="applicantState"><asp:Literal ID="litState" runat="server" Text="" /></td>
							<td class="applicantPostcode"><asp:Literal ID="litPostcode" runat="server" Text="" /></td>
							<td class="applicantStatus"><asp:Literal ID="litApplicationStatus" runat="server" Text="Status" /></td>
							<td class="applicantEmail"><asp:HyperLink ID="hlEmailAddress" runat="server" Text="Email" /></td>
							<td class="applicantApplicationDate" data-value="<asp:Literal ID="litApplicationDateYYY" runat="server" />"><asp:Literal ID="litApplicationDate" runat="server" /></td>
							<td class="applicantDownloaded<%# DataBinder.Eval(Container.DataItem, "JobApplicationID").ToString() %>"><asp:Literal ID="litFileDownloaded" runat="server" /></td>
                            <%--<asp:PlaceHolder ID="plNote" runat="server" Visible="false">
                                <td>
                                    <asp:LinkButton ID="lbNote" runat="server" CommandName="Note">
                                        <JXTControl:ucLanguageLiteral ID="ltAdvertiserJobtrackerNewEdit" runat="server" SetLanguageCode="LabelNew" />
                                    </asp:LinkButton>
                                </td>
                            </asp:PlaceHolder>--%>
						</tr>


                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        <tfoot class="hide-if-no-paging">
							<tr>
							    <td colspan="10" class="form-inline text-right">
									<p>
							    	Show 
							    	<select name="showRow" id="showRow" onchange="$('#jobsTable').data('page-size', $(this).val()).trigger('footable_initialized');">
							    		<option value="10">10</option>
							    		<option value="20">20</option>							    		
							    	</select>
							    	per page
							    	&nbsp;
							    	<JXTControl:ucLanguageLiteral ID="ltTotal" runat="server" SetLanguageCode="LabelTotal" /> <span class="totalCount"></span> <JXTControl:ucLanguageLiteral ID="ltApplications" runat="server" SetLanguageCode="LabelApplications" />
							    	</p>
							        <div class="pagination-wrap"></div>
							    </td>
							</tr>
						</tfoot>

                        </table>
                    </FooterTemplate>
                </asp:Repeater>
    			</div>

				</div>
				<!-- jobTrackerTbl -->
        </div>
    </div>
    </div>

    
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->

    <script type="text/javascript">
        $(function () {
            $(".applicantCheckbox input:checkbox").addClass("chkApplicationClass");

            var max = 10; // Maximum ten applications
            var checkboxes = $('input[class="chkApplicationClass"]');

            checkboxes.change(function () {
                checkboxes = $('input[class="chkApplicationClass"]');
                var current = checkboxes.filter(':checked').length;
                checkboxes.filter(':not(:checked)').prop('disabled', current >= max);
            });

            $('.checkall').on('click', function () {
                checkboxes = $('tbody td.footable-visible input:checkbox');
                if (this.checked) {
                    checkboxes.prop('disabled', false);
                    checkboxes.prop('checked', false);

                    var isvisibleChkboxes = $('tbody td.footable-visible input:checkbox:visible')
                    isvisibleChkboxes.slice(0, max).prop("checked", true);
                }
                else
                    checkboxes.prop('checked', false);


                var current = checkboxes.filter(':checked').length;
                checkboxes.filter(':not(:checked)').prop('disabled', current >= max);
            });


            $('.email-selected').on('click', function (e) {
                checkboxes = $('input[class="chkApplicationClass"]');
                var current = checkboxes.filter(':checked').length;
                if (current > 1) {
                    alert('You can only select one application at a time');
                    e.preventDefault();
                    return false;
                }
            });

            $('.downloadSelected').on('click', function (e) {
                var IDs = [];
                checkboxes = $('tbody td.footable-visible input:checkbox:visible:checked').each(function () { IDs.push(this.id); });
                var current = checkboxes.length;
                if (current > max) {
                    alert('You can select maximum ' + max + ' application(s) at a time');
                    e.preventDefault();
                    return false;
                }

                $.each(IDs, function (i) {
                    //console.log(IDs[i]);
                    //console.log($('#' + IDs[i]).siblings('input:hidden').val());

                    $('.applicantDownloaded' + $('#' + IDs[i]).siblings('input:hidden').val()).html("<i class='fa fa-check-circle'></i>");
                });

            });
            
        });
    </script>
    
	<script src="//images.jxt.net.au/COMMON/newdash/lib/footable.js" type="text/javascript"></script> <!-- New Script -->
	<script src="//images.jxt.net.au/COMMON/newdash/lib/footable.sort.js" type="text/javascript"></script> <!-- New Script -->
	<script src="//images.jxt.net.au/COMMON/newdash/lib/footable.filter.js" type="text/javascript"></script> <!-- New Script -->
	<script src="//images.jxt.net.au/COMMON/newdash/lib/footable.paginate.js" type="text/javascript"></script> <!-- New Script -->
	<script src="//images.jxt.net.au/COMMON/newdash/lib/footable.bookmarkable.js" type="text/javascript"></script> <!-- New Script -->
	<script src='//images.jxt.net.au/COMMON/newdash/newDash.js' type="text/javascript"></script>
</asp:Content>
