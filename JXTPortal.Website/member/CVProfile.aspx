<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="CVProfile.aspx.cs" Inherits="JXTPortal.Website.member.CVProfile" %>

<%@ Register Src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" TagName="ucMemberAccountNavigation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-fileupload.min.css" />
    <%--<link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-datetimepicker.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-editable.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/jquery.tagsinput.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-multiselect.css" />--%>
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/CV-Builder-style.css" />
    <!--[if lt IE 9]>
	<script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/html5shiv.js" type="text/javascript"></script>
	<script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/respond.min.js" type="text/javascript"></script>
<![endif]-->
    <%--<script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.js'></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content-container" class="newDash container">
        <div id="CV-content" class="row">
            <div id="CV-content-holder" class="col-sm-8 col-md-9">
                <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
                <h1 class="CV-Builder-title">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelProfile" />
                </h1>
                <div id="complete-profile">
                    <div id="tab1" class="row profile-summary">
                        <div id="tab1-collapse" class="scroll-content">
                            <div class="col-sm-4 col-md-3">
                                <asp:Image ImageUrl="//images.jxt.net.au/placeholder.png" runat="server" CssClass="thumbnail profilePic"
                                    ID="imgMemberProfile" />
                            </div>
                            <div class="col-sm-8 col-md-9">
                                <div class="row">
                                    <div class="col-md-8 col-sm-7">
                                        <h3 id="candidate-name">
                                            <asp:Literal ID="ltlName" runat="server"></asp:Literal></h3>
                                        <p id="headline">
                                            <asp:Literal ID="ltlHeadline" runat="server"></asp:Literal></p>
                                        <asp:Literal ID="ltlCurrentStatus" runat="server"></asp:Literal>
                                    </div>
                                    <div class="col-md-4 col-sm-5 hidden-xs cv-progress">
                                        <div class="text-right">
                                            <p>
                                                <JXTControl:ucLanguageLiteral ID="ltProgressText1" runat="server" SetLanguageCode="LabelProfileProgressText1" />
                                                <span class="cv-complete-num">
                                                    <asp:Literal ID="ltlProfileProgressPercent" runat="server"></asp:Literal></span>
                                                <JXTControl:ucLanguageLiteral ID="ltProgressText2" runat="server" SetLanguageCode="LabelProfileProgressText2" />
                                            </p>
                                            <div class="progress">
                                                <asp:Literal ID="ltlProgressBarBar" runat="server"></asp:Literal>
                                            </div>
                                            <p>
                                                <small>
                                                    <JXTControl:ucLanguageLiteral ID="ltProgressTextLastUpdated" runat="server" SetLanguageCode="LabelProfileProgressLastUpdated" />
                                                    <asp:Literal ID="ltlProfileProgressLastDate" runat="server"></asp:Literal>
                                                </small>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <p id="summary">
                                    <asp:Literal ID="ltlShortBio" runat="server"></asp:Literal>
                                </p>
                                <div class="text-right CV-Busilder-edit">
                                    <a href="/member/cvbuilder.aspx">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelEdit" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- tab1 -->
                    <div id="tab2" class="row coverletter">
                        <a name="tab2"></a>
                        <div class="col-md-12">
                            <h3 class="coverletter-title" data-toggle="collapse" data-target="#tab2-collapse">
                                <asp:Literal ID="ltlCoverletter" runat="server" /></h3>
                            <div id="tab2-collapse" class="scroll-content in">
                                <div class="table-responsive">
                                    <asp:PlaceHolder ID="plhCoverletter" runat="server">
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <JXTControl:ucLanguageLiteral ID="ucFileName" runat="server" SetLanguageCode="LabelDocumentName" />
                                                    </th>
                                                    <th>
                                                        <JXTControl:ucLanguageLiteral ID="ucLabelFileType" runat="server" SetLanguageCode="LabelFileType" />
                                                    </th>
                                                    <th class="text-right">
                                                        <JXTControl:ucLanguageLiteral ID="ucActions" runat="server" SetLanguageCode="LabelActions" />
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Literal ID="ltlFiles" runat="server"></asp:Literal>
                                                <%--<tr>
										<td>Coverletter.txt</td>
										<td class="text-right"><a href="#" class="btn btn-success btn-xs"><i class="fa fa-download"><!--ICON--></i> Download</a></td>
									</tr>--%>
                                                <%--	<tr>
										<td>Resume.pdf</td>
										<td class="text-right"><a href="#" class="btn btn-success btn-xs"><i class="fa fa-download"><!--ICON--></i> Download</a></td>
									</tr>
                                                --%>
                                            </tbody>
                                        </table>
                                    </asp:PlaceHolder>
                                    <asp:Literal ID="ltlFilesMessage" runat="server"></asp:Literal>
                                </div>
                                <div class="text-right CV-Busilder-edit">
                                    <a href="/member/cvbuilder.aspx?tab=tab2">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelEdit" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- tab2 -->
                    <div id="tab3" class="row role-preferences">
                        <a name="tab3"></a>
                        <div class="col-md-12">
                            <h3 class="role-preferences-title" data-toggle="collapse" data-target="#tab3-collapse">
                                <asp:Literal ID="ltlRolePreferences" runat="server" /></h3>
                            <div id="tab3-collapse" class="scroll-content in">
                                <div class="row role-location">
                                    <div class="col-sm-6">
                                        <p class="location-title">
                                            <JXTControl:ucLanguageLiteral ID="ucLabelLocation" runat="server" SetLanguageCode="LabelLocation" />
                                        </p>
                                        <asp:Literal ID="ltlLocations" runat="server"></asp:Literal>
                                    </div>
                                    <div class="col-sm-6">
                                        <p class="classification-title">
                                            <JXTControl:ucLanguageLiteral ID="ucLabelClassification" runat="server" SetLanguageCode="LabelClassification" />
                                            /
                                            <JXTControl:ucLanguageLiteral ID="ucLabelSubClassification" runat="server" SetLanguageCode="LabelSubClassification" />
                                        </p>
                                        <asp:Literal ID="ltlClassifications" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="row role-work-type">
                                    <div class="col-sm-6">
                                        <p class="work-type-title">
                                            <JXTControl:ucLanguageLiteral ID="ucLabelWorkType" runat="server" SetLanguageCode="LabelWorkType" />
                                        </p>
                                        <asp:Literal ID="ltlWorktypes" runat="server"></asp:Literal>
                                    </div>
                                    <div class="col-md-6">
                                        &nbsp;</div>
                                </div>
                                <div class="text-right CV-Busilder-edit">
                                    <a href="/member/cvbuilder.aspx?tab=tab3">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelEdit" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- tab3 -->
                    <div id="tab4" class="row qualification">
                        <a name="tab4"></a>
                        <div class="col-md-12">
                            <h3 class="qualification-title" data-toggle="collapse" data-target="#tab4-collapse">
                                <asp:Literal ID="ltlQualifications" runat="server" /></h3>
                            <div id="tab4-collapse" class="scroll-content in">
                                <asp:Literal ID="ltlQualificationList" runat="server"></asp:Literal>
                                <%--<div class="qualification">
							<p class="title">Master of Business Management</p>
							<p class="institution">University of Sydney</p>
							<p class="qualification-dates"><span class="startdate">01/01/2012</span> - <span class="enddate">30/06/2016</span> <span class="qualification-current">(Current)</span></p>
						</div>
						<div class="qualification">
							<p class="title">Bachelor of Business</p>
							<p class="institution">University of New South Wales</p>
							<p class="qualification-dates"><span class="startdate">01/01/2008</span> - <span class="enddate">30/06/2010</span> <span class="qualification-current">(Graduate)</span></p>
						</div>
						<div class="qualification">
							<p class="title">Diploma of Business</p>
							<p class="institution">Sydney TAFE</p>
							<p class="qualification-dates"><span class="startdate">01/01/2006</span> - <span class="enddate">30/11/2007</span> <span class="qualification-current">(Graduate)</span></p>
						</div>--%>
                                <div class="text-right CV-Busilder-edit">
                                    <a href="/member/cvbuilder.aspx?tab=tab4">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelEdit" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- tab4 -->
                    <div id="tab5" class="row dynamic-content">
                        <a name="tab5"></a>
                        <div class="col-md-12">
                            <h3 class="dynamic-content-title" data-toggle="collapse" data-target="#tab5-collapse">
                                <asp:Literal ID="ltlMemberships" runat="server" /></h3>
                            <div id="tab5-collapse" class="scroll-content in">
                                <asp:Literal ID="ltlMembershipsValues" runat="server" />
                                <div class="text-right CV-Busilder-edit">
                                    <a href="/member/cvbuilder.aspx?tab=tab5">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelEdit" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- tab5 -->
                    <asp:PlaceHolder ID="phDirectorship" runat="server">
                        <div id="tab6" class="row directorship">
                            <a name="tab6"></a>
                            <div class="col-md-12">
                                <h3 class="directorship-title" data-toggle="collapse" data-target="#tab6-collapse">
                                    <asp:Literal ID="ltlDirectorship" runat="server" /></h3>
                                <div id="tab6-collapse" class="scroll-content in">
                                    <asp:Literal ID="ltlDirectorshipList" runat="server"></asp:Literal>
                                    <div class="text-right CV-Busilder-edit">
                                        <a href="/member/cvbuilder.aspx?tab=tab6">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelEdit" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <!-- tab6 -->
                    <div id="tab7" class="row experience">
                        <a name="tab7"></a>
                        <div class="col-md-12">
                            <h3 class="experience-title" data-toggle="collapse" data-target="#tab7-collapse">
                                <asp:Literal ID="ltlExperience" runat="server" /></h3>
                            <div id="tab7-collapse" class="scroll-content in">
                                <asp:Literal ID="ltlExperienceList" runat="server"></asp:Literal>
                                <div class="text-right CV-Busilder-edit">
                                    <a id="hlExperience" runat="server" href="/member/cvbuilder.aspx?tab=tab7">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelEdit" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- tab6 -->
                    <div id="tab8" class="row skills">
                        <a name="tab8"></a>
                        <div class="col-md-12">
                            <h3 class="skills-title" data-toggle="collapse" data-target="#tab8-collapse">
                                <asp:Literal ID="ltlSkills" runat="server" /></h3>
                            <div id="tab8-collapse" class="scroll-content in">
                                <div id="skill-tags">
                                    <asp:Literal ID="ltlSkillsTags" runat="server"></asp:Literal>
                                </div>
                                <div class="text-right CV-Busilder-edit">
                                    <a id="hlSkills" runat="server" href="/member/cvbuilder.aspx?tab=tab8">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelEdit" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- tab7 -->
                    <div class="col-md-12 text-center cv-download-pdf">
                        <asp:LinkButton ID="lbDownloadPdf" runat="server" CssClass="btn btn-primary btn-download-pdf" role="button" OnClick="PDFGetButton_Click">
                            <i class="fa fa-arrow-circle-o-down">
                                <!--ICON-->
                            </i>
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelProfileDownloadPDF" />
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div id="CV-side-holder" class="hidden-xs col-sm-4 col-md-3">
                <div id="CV-contactinfo">
				<h4 id="CV-contactinfo-title"><JXTControl:ucLanguageLiteral ID="ucContactInformation" runat="server" SetLanguageCode="LabelContactInformation" /></h4>
				<p id="CV-contactinfo-email"><strong><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelContactEmail" />:</strong> <span><asp:Literal ID="ltContactEmail" runat="server" /></span></p>
                <asp:PlaceHolder ID="phContactNumber" runat="server">
				    <p id="CV-contactinfo-num"><strong><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelContactNumber" />:</strong> <span><asp:Literal ID="ltContactNumber" runat="server" /></span></p>
                </asp:PlaceHolder>
			</div>
                <div id="scrollbar-nav">

                    <ul class="nav nav-pills nav-stacked">
                        <li class="active"><a href="#tab1" id="BtnTab1">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelProfile" />
                        </a></li>
                        <li><a href="#tab2" id="BtnTab2">
                            <asp:Literal ID="ltlCoverletter2" runat="server" /></a></li>
                        <li><a href="#tab3" id="BtnTab3">
                            <asp:Literal ID="ltlRolePreferences2" runat="server" /></a></li>
                        <li><a href="#tab4" id="BtnTab4">
                            <asp:Literal ID="ltlQualifications2" runat="server" /></a></li>
                        <li><a href="#tab5" id="BtnTab5">
                            <asp:Literal ID="ltlMemberships2" runat="server" /></a></li>
                        
                        <asp:Literal ID="ltlDirectorship2" runat="server" />

                        <li><a href="#tab7" id="BtnTab7">
                            <asp:Literal ID="ltlExperience2" runat="server" /></a></li>
                        <li><a href="#tab8" id="BtnTab8">
                            <asp:Literal ID="ltlSkills2" runat="server" /></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap.min.js'></script>
    <% } %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/CV-Profile-scripts.js'></script>
    <%--<script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.bootstrap.wizard.min.js"></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.validate.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-fileupload.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/moment.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-datetimepicker.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-editable.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.tagsinput.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-maxlength.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-multiselect.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/CV-Builder-scripts.js'></script>--%>
</asp:Content>
