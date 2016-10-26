<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="JXTPortal.Website.members.default2" %>
<%@ Register Src="~/usercontrols/member/ucMemberBroadcast.ascx" TagName="ucMemberBroadcast" TagPrefix="uc1" %>
<%@ Register src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" tagname="ucMemberAccountNavigation" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <%--<link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />--%>
    <link href="/styles/owl.carousel.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/owl.carousel.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="endOfHead" runat="server">
    <link rel="stylesheet" href="/styles/member/dashboard.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager" runat="server" />
    

    <div id="content-container" class="newDash container">
        <div id="content" class="col-xs-12" style="width: 100%;">
            <div class="content-holder">
                <div class="memberprofilelinks-wrap">
                    <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
                    <div class="clearfix"></div>
                </div>
                <!-- CV Content -->
                <div id="CV-content">
                    <h1 class="CV-Builder-title"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelDashboard" /></h1>
                    <div class="row member-dashboard-content">
                        <div class="col-md-8">
                            <!-- Basic Details -->
                            <section class="form-section clearfix db_info-holder">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="db_section-content">
                                            <div id="box-profile-info">
                                                <figure class="profilePic-holder">
                                                    <asp:Image ImageUrl="/images/member/profile-placeholder.png" runat="server" CssClass="profilePic" ID="imgMemberProfile" />                                                    
                                                    <%--<label class="btn btn-primary btn-sm btn-file btnUploadImage" for="fuProfile">
                                                        <span class="fileupload-new">Upload Image</span>
                                                        <input type="file" name="ctl00$ContentPlaceHolder1$fuProfile" id="fuProfile">
                                                    </label>--%>
                                                </figure>
                                                <h2 class="member-dashboard-candidatename"><small><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelHi" />, </small><span class="first-name"><asp:Literal ID="ltlFirstName" runat="server" /></span> 
                                                <span class="last-name"><asp:Literal ID="ltlLastName" runat="server" /></span></h2>
                                                <div id="headline">
                                                    <p class="highlight"><asp:Literal ID="ltlHeadline" runat="server" /></p>
                                                </div>
                                                <div class="row">
                                                    <asp:Literal ID="ltlSeekingStatus" runat="server" />
                                                    <asp:Literal ID="ltlAvailabilityDate" runat="server" />
                                                </div>
                                                <asp:Literal ID="ltlBullhornOnBoarding" runat="server" />

                                                <h5><strong><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelWhatAreYouUpTo" /></strong></h5>
                                                <div class="profile-completion-info">
                                                    <span class="jxt_dash-statusInfo status-yes"><span class="fa fa-check"></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelRegistration" /></span>
                                                    <span class="jxt_dash-statusInfo status-yes"><span class="fa fa-check"></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server" SetLanguageCode="LabelValidation" /></span>
                                                    <asp:Literal runat="server" id="ltDashStatusProfileInfo" ></asp:Literal>                                                    
                                                </div>

                                                <asp:PlaceHolder runat="server" ID="phProfileStatusWidget" Visible="false">
                                                <h5 class="text-incomplete"><strong><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral99" runat="server" SetLanguageCode="LabelRequiredProfileSectionsHeading" /></strong></h5>
                                                    <div class="uncomplete-sec-list">
                                                    <div class="jxt_dragable-section" id="owl-demo">
                                                    
                                                        <asp:Literal runat="server" ID="ltProfileStatusIcons"></asp:Literal>
                                                                                                            
                                                    </div>
                                                </div>
                                                </asp:PlaceHolder>

                                                <%--<a href="#" class="btn btn-sm btn-primary"><span class="fa fa-linkedin"></span>Import from LinkedIn</a>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div id="box-profile-status">
                                            <div class="db_section-content">
                                                <h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelHowDoesMyProfileCompare" /></h2>
                                                <div class="profileMeterRing">
                                                    <asp:Literal ID="ltlMemberPercentage" runat="server" />
                                                    <%--<div class="progress-bar" data-percent="90" data-duration="2000" data-color="#ffa64d,white" data-label="Expert">
                                                    </div>--%>
                                                </div>
                                                <div class="button-wrapper text-center">
                                                    <a href="/member/profile.aspx" class="btn btn-sm btn-primary"><span class="fa fa-edit"></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelEditProfile" /></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <!-- //form-section: Basic Details -->
                        </div>
                        <!-- Personal Details -->
                        <div class="col-md-4 col-sm-6">
                            <section class="form-section clearfix" id="box-profile-details">
                                <header class="db_section-header">
                                    <h2><span class="fa fa-info-circle"><!-- info icon --></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelMyDetails" /></h2>
                                </header>
                                <div class="db_section-content">
                                    <span class="highlight"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelEmailAddress" /></span>
                                    <span class="personal-detail-content primary-email"><asp:Literal ID="ltlEmailAddress" runat="server" /></span>
                                    <asp:Literal ID="ltlPhone" runat="server" />
                                    <asp:Literal ID="ltlDOB" runat="server" />
                                    <span class="highlight address-detail-title"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelAddress" /></span>
                                    <span class="personal-detail-content address-detail"><asp:Literal ID="ltlAddress" runat="server" /></span>
                                    <a href="/member/profile.aspx?focus=personal" class="btn btn-sm btn-primary"><span class="fa fa-edit"></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelEditDetails" /></a>
                                </div>
                            </section>
                        </div>
                        <!-- Saved Jobs -->
                        <div class="col-md-4 col-sm-6">
                            <section class="form-section clearfix">
                            
                            <asp:UpdatePanel ID="updatePanel" runat="server">
                                <ContentTemplate>

                                <header class="db_section-header">
                                    <h2><span class="fa fa-save highlight"><!-- save icon --></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelMySavedJobs" /></h2>
                                </header>
                                <div class="db_section-content">
                                    <div id="memberBroadcast-SavedJobs" class="memberBroadcast-widget form-all">
                                    

                                        <table id="box-table-saved" class="box-table table table-hover table-bordered">
                                            <thead>
                                                <tr>
                                                    <th><JXTControl:ucLanguageLiteral ID="ltHeaderSavedJobsName" runat="server" SetLanguageCode="LabelJobTitle" /></th>
                                                    <th class="action-edit">&nbsp;</th>
                                                    <th class="action-head"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelAction" /></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            
                                        <asp:Repeater ID="rptMemberSavedJobs" runat="server" OnItemDataBound="rptMemberSavedJobs_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time"><asp:Literal ID="ltDatePosted" runat="server" /></div>
                                                        <p><asp:Literal ID="ltlSavedJobsName" runat="server" /></p>
                                                    </td>
                                                    <td class="action-edit">
                                                        <asp:LinkButton ID="lnkSavedJobsDelete" runat="server" ValidationGroup="SubAccounts" OnClick="lnkSavedJobsDelete_Click" CausesValidation="false" CssClass="fa fa-trash"><span class="hidden">Delete</span></asp:LinkButton>
                                                    </td>
                                                    <td class="action-cell">
                                                    <asp:HyperLink ID="hlViewSavedJobs" runat="server" CssClass="btn btn-sm btn-primary"><asp:Literal ID="ltViewSavedJobs" runat="server" /></asp:HyperLink>                                                    
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                                <%--<tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this saved job"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell"><a href="" class="btn btn-sm btn-primary" title="View this saved job">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this saved job"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell"><a href="" class="btn btn-sm btn-primary" title="View this saved job">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this saved job"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell"><a href="" class="btn btn-sm btn-primary" title="View this saved job">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this saved job"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell"><a href="" class="btn btn-sm btn-primary" title="View this saved job">View</a></td>
                                                </tr>--%>
                                            </tbody>
                                        </table>
                                    </div>
                                    <asp:Literal ID="ltMemberNoSaveJobs" runat="server" Visible="false" />

                                </div>
                                <footer class="db_section-footer">
                                    <asp:HyperLink ID="hypSavedJobsViewLink" runat="server" NavigateUrl="/member/mysavedjobs.aspx" Visible="false" CssClass="boardy-dashboard-action-view"></asp:HyperLink>
                                </footer>
                                
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </section>
                        </div>
                        <!-- Applied Jobs -->
                        <div class="col-md-4 col-sm-6">
                            <section class="form-section clearfix">
                            
                                <header class="db_section-header">
                                    <h2><span class="fa fa-bar-chart highlight"><!-- chart icon --></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelJobApplicationDetails" /></h2>
                                </header>
                                <div class="db_section-content">
                                    <div id="memberBroadcast-ApplicationTracker" class="memberBroadcast-widget form-all">
                                        <table id="box-table-saved" class="box-table table table-hover table-bordered">
                                            <thead>
                                                <tr>
                                                    <th><JXTControl:ucLanguageLiteral ID="ltHeaderMemberAppTrackerJobsName" runat="server" SetLanguageCode="LabelJobTitle" /></th>
                                                    <th width="80" class="action-head"><JXTControl:ucLanguageLiteral ID="ltHeaderMemberAppTrackerDate" runat="server" SetLanguageCode="LabelApplicationDate" /></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptMemberApplicationTracker" runat="server" OnItemDataBound="rptMemberApplicationTracker_ItemDataBound">
                                                <ItemTemplate>

                                                <tr>
                                                    <td><asp:HyperLink runat="server" ID="hypJobUrl" /></td>
                                                    <td><asp:Literal ID="ltDateApplied" runat="server" /></td>
                                                </tr>
                                                </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <asp:Literal ID="ltMemberNoJobTracker" runat="server" Visible="false" />
                                </div>
                                <footer class="db_section-footer">
                                    <asp:HyperLink ID="hypApplicationTrackerViewLink" runat="server" NavigateUrl="/member/applicationTracker.aspx" Visible="false" CssClass="boardy-dashboard-action-view"></asp:HyperLink>                                    
                                </footer>
                            </section>
                        </div>
                        <!-- Favourite Job Alerts  -->
                        <div class="col-md-4 col-sm-6">
                            <section class="form-section clearfix">
                            
                            <asp:UpdatePanel ID="updatePanel1" runat="server">
                                <ContentTemplate>
                                <header class="db_section-header">
                                    <h2><span class="fa fa-star-o highlight"><!-- start icon --></span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelFavouriteSearches" /> / <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelMyJobAlerts" /></h2>
                                </header>
                                <div class="db_section-content">
                                    <div id="memberBroadcast-JobAlert">
                                        <table id="box-table-alerts" class="box-table table table-hover table-bordered">
                                            <thead>
                                                <tr>
                                                    <th><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelJobTitle" /></th>
                                                    <th class="action-edit">&nbsp;</th>
                                                    <th class="action-head"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelSendEmailAlerts" /></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            <asp:Repeater ID="rptJobAlerts" runat="server" OnItemCommand="rptJobAlerts_ItemCommand" OnItemDataBound="rptJobAlerts_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time"><asp:Literal ID="ltLastModified" runat="server" /></div>
                                                        <p><%# Eval("JobAlertName") %></p>
                                                    </td>
                                                    <td class="action-edit">
                                                    <a href="/member/createjobalert.aspx?id=<%# Eval("JobAlertID") %>" class="fa fa-edit" title="Edit this job alerts"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell">
                                                        <label class="switch switch-flat">
                                                            <asp:HiddenField ID="hfAlertID" runat="server" Value="" />
                                                            <asp:CheckBox ID="cbAlertEnabled" runat="server" AutoPostBack="true" OnCheckedChanged="cbAlertEnabled_CheckedChanged" />
                                                            <%--<span class="switch-label" data-on="Yes" data-off="No"></span>--%>
                                                            <asp:Literal id="ltlJobAlertSwitch" runat="server" />
                                                            <span class="switch-handle"></span>
                                                            <span class="hidden"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelYes" /></span>
                                                        </label>
                                                    </td>
                                                </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
<%--
                                                <tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this job alert"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell">
                                                        <label class="switch switch-flat">
                                                            <input class="switch-input" type="checkbox" checked />
                                                            <span class="switch-label" data-on="Yes" data-off="No"></span>
                                                            <span class="switch-handle"></span>
                                                            <span class="hidden">Yes</span>
                                                        </label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this job alert"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell">
                                                        <label class="switch switch-flat">
                                                            <input class="switch-input" type="checkbox" />
                                                            <span class="switch-label" data-on="Yes" data-off="No"></span>
                                                            <span class="switch-handle"></span>
                                                            <span class="hidden">No</span>
                                                        </label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this job alert"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell">
                                                        <label class="switch switch-flat">
                                                            <input class="switch-input" type="checkbox" />
                                                            <span class="switch-label" data-on="Yes" data-off="No"></span>
                                                            <span class="switch-handle"></span>
                                                            <span class="hidden">No</span>
                                                        </label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="sj_time">04/05/16</div>
                                                        <p>Senior Web Developer and designer</p>
                                                    </td>
                                                    <td class="action-edit"><a href="#" class="fa fa-edit" title="Edit this job alert"><span class="hidden">Edit</span></a></td>
                                                    <td class="action-cell">
                                                        <label class="switch switch-flat">
                                                            <input class="switch-input" type="checkbox" checked />
                                                            <span class="switch-label" data-on="Yes" data-off="No"></span>
                                                            <span class="switch-handle"></span>
                                                            <span class="hidden">Yes</span>
                                                        </label>
                                                    </td>
                                                </tr>--%>
                                            </tbody>
                                        </table>
                                    </div>
                                    <asp:Literal ID="ltMemberNoJobAlerts" runat="server" Visible="false" />
                                </div>
                                <footer class="db_section-footer">
                                    <asp:HyperLink ID="hypJobAlertsViewLink" runat="server" NavigateUrl="/member/MyJobAlerts.aspx" Visible="false" CssClass="boardy-dashboard-action-view"></asp:HyperLink>                                    
                                </footer>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </section>
                        </div>
                    </div>
                </div>
                <!-- //CV-content -->
            </div>
            <!-- //content-holder -->
        </div>
    </div>
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src="/scripts/lib/jQuery-plugin-progressbar.js" type="text/javascript"></script>
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <%--<script src='//images.jxt.net.au/COMMON/newdash/newDash.js'></script>--%>

    <script>

        function resizeBoxes() {
            if ($(window).width() > 991) {
                //top row
                $('.db_info-holder, #box-profile-details, #box-profile-details .db_section-content').css('min-height', 150);

                var maxHeight = 0;
                $('.db_info-holder, #box-profile-details').each(function () {
                    maxHeight = $(this).outerHeight() > maxHeight ? $(this).outerHeight() : maxHeight;
                });
                $('.db_info-holder, #box-profile-details').css("min-height", maxHeight);

                //seconde row
                maxHeight = 0;
                $('.col-md-4:nth-child(n+3) .db_section-content').each(function () {
                    maxHeight = $(this).outerHeight() > maxHeight ? $(this).outerHeight() : maxHeight;
                });
                $('.col-md-4:nth-child(n+3) .db_section-content').css("min-height", maxHeight);

            } else if ($(window).width() > 767) {
                $('.db_info-holder').css('min-height', 150);
                maxHeight = 0;
                $('.col-md-4 .db_section-content').each(function () {
                    maxHeight = $(this).outerHeight() > maxHeight ? $(this).outerHeight() : maxHeight;
                });
                $('.col-md-4 .db_section-content').css("min-height", maxHeight);
            }
        }
        $(document).ready(function () {
            //circular progress bar
            if ($(".progress-bar").length) {
                $(".progress-bar").loading();
            }
            $('.dropdown-toggle').dropdown();

            resizeBoxes();

            //owl carousel
            $("#owl-demo").owlCarousel({
                items : 6,
                itemsTablet : [768, 4],
                itemsMobile : [767, 6],
                itemsMobile : [420, 4],
                navigation: true,
                navigationText : ["&lsaquo;", "&rsaquo;"],
                pagination: false,
                rewindNav: false,
            });

        });

        $(window).resize(function () {
            resizeBoxes();
        });
    </script>
</asp:Content>
