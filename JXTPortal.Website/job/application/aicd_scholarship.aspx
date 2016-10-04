<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="aicd_scholarship.aspx.cs" Inherits="JXTPortal.Website.job.application.aicd_scholarship" %>

<%@ Import Namespace="JXTPortal.JobApplications" %>
<%@ Import Namespace="JXTPortal.JobApplications.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-fileupload.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-multiselect.css" />
    <%--<link rel="stylesheet" href="/Content/Cform/css/system-responsive.css" />
    <link rel="stylesheet" href="/Content/Cform/css/style.css" />
    --%>
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/applications/aicd_scholarship/css/custom-application.css" />
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap.min.js'></script>
    <% } %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.bootstrap.wizard.js'></script>
    <%--<script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-fileupload.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-maxlength.min.js'></script>--%>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-multiselect.js'></script>
    <script src="/scripts/applications/aicd_scholarship.js" type="text/javascript"></script>
    <%--<script src='//images.jxt.net.au/COMMON/applications/aicd_scholarship/js/custom-application.js'></script>--%>
    <script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.validate.min.js"
        type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.validate.unobtrusive.js"
        type="text/javascript"></script>
    <script src='//images.jxt.net.au/COMMON/js/textareaCounter.js'></script>
    <script src="https://kofamily.photos/scripts/uploader/js/vendor/jquery.ui.widget.js"></script>
    <!-- The Iframe Transport is required for browsers without support for XHR file uploads -->
    <script src="https://kofamily.photos/scripts/uploader/js/jquery.iframe-transport.js"></script>
    <!-- The basic File Upload plugin -->
    <script src="https://kofamily.photos/scripts/uploader/js/jquery.fileupload.js"></script>
    <link rel="stylesheet" href="http://blueimp.github.io/jQuery-File-Upload/css/jquery.fileupload.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="customApplicationContainer" class="container">
        <div id="customApplicationContent" class="row">
            <div id="customApplicationHolder" class="col-md-12">
                <!-- Start the Custom Application wizard block -->
                <asp:HiddenField ID="hfJobId" runat="server" ClientIDMode="Static" />
                <div id="customApplication">
                    <h1>
                        <asp:HyperLink ID="hypLinkJobTitle" runat="server" Target="_blank"></asp:HyperLink></h1>
                    <div id="rootwizard">
                        <ul class="wizard-steps">
                            <li class="active"><a id="tab1Trigger" href="#tab1" data-toggle="tab"><span class="step">
                                1</span><span class="step-name">Terms & Conditions</span></a></li>
                            <li class=""><a href="#tab2" id="tab2Trigger" data-toggle="tab"><span class="step">2</span><span
                                class="step-name">Personal details</span></a></li>
                            <li class=""><a href="#tab3" id="tab3Trigger" data-toggle="tab"><span class="step">3</span><span
                                class="step-name">Directorship Experience</span></a></li>
                            <li class=""><a href="#tab4" id="tab4Trigger" data-toggle="tab"><span class="step">4</span><span
                                class="step-name">Professional Experience</span></a></li>
                            <li class=""><a href="#tab5" id="tab5Trigger" data-toggle="tab"><span class="step">5</span><span
                                class="step-name">Education and Qualifications</span></a></li>
                            <%--<li class=""><a href="#tab6" id="tab6Trigger" href="javascript:void(0)" data-toggle="tab">
                                <span class="step">6</span><span class="step-name">Association Membership</span></a></li>
                            --%><li class=""><a href="#tab7" id="tab7Trigger" data-toggle="tab"><span class="step">
                                6</span><span class="step-name">Referee contacts</span></a></li>
                            <li class=""><a href="#tab8" id="tab8Trigger" data-toggle="tab"><span class="step">7</span><span
                                class="step-name">Additional Information</span></a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane fade active in" id="tab1">
                                <h3 class="tab-title">
                                    Terms and Conditions</h3>
                                <div class="divTermsAndConditionsScroll">
                                    <asp:Literal ID="ltlTermsAndConditions" runat="server" />                                                                       
                                </div>

                                <div class="form-group">
                                    <div class="checkbox">
                                        <label class="col-md-12">
                                            <input type="checkbox" id="chkTermsAndConditions" name="chkTermsAndConditions" value="true"
                                                onclick="ClearErrorMessages();" class="valid" />
                                            I hereby accept the Terms and Conditions</label>
                                        <span class="field-validation-valid" id="validTermsAndConditions" style="color: Red">
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <!-- tab1 -->
                            <div class="tab-pane fade" id="tab2">
                                <h3 class="tab-title">
                                    Personal details</h3>
                                <div class="form-group">
                                    <label class="control-label" for="ddlProfileTitle">
                                        Title</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateEnumDropDown("ddlProfileTitle", "title","", typeof(ENUM_Title), ((int) FormData.tab2.title).ToString(), null) %>
                                    <div class="othersfield" style="display: none;">
                                        <input type="text" name="titleOthers" placeholder="Please specify" id="ddlProfileTitleOther"
                                            value="<%=FormData.tab2.titleOthers %>" />
                                        <span class="field-validation-valid" data-valmsg-for="titleOthers" data-valmsg-replace="true"
                                            style="color: Red"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtFirstName">
                                        First Name*</label>
                                    <input id="firstName" type="text" name="firstName" placeholder="" value="<%=FormData.tab2.firstName %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field" disabled="disabled" />
                                    <span class="field-validation-valid" data-valmsg-for="firstName" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtMiddleName">
                                        Middle name</label>
                                    <input id="middleName" type="text" name="middleName" placeholder="" value="<%=FormData.tab2.middleName %>"
                                        data-val="true" />
                                    <span class="field-validation-valid" data-valmsg-for="middleName" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtLastName">
                                        Last Name*</label>
                                    <input id="lastName" type="text" name="lastName" placeholder="" value="<%=FormData.tab2.lastName %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field" disabled="disabled" />
                                    <span class="field-validation-valid" data-valmsg-for="lastName" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtHonorifics">
                                        Honorifics/Post Nominals(e.g AO, GAICD)</label>
                                    <input id="txtHonorifics" type="text" name="honorifics" placeholder="" value="<%=FormData.tab2.honorifics %>" />
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtEmail">
                                        Email address*</label>
                                    <input id="email" type="email" name="email" placeholder="" value="<%=FormData.tab2.email %>"
                                        required="required" data-val="true" data-val-email="Please enter a valid email address"
                                        data-val-required="Please fill in the required field" disabled="disabled" />
                                    <span class="field-validation-valid" data-valmsg-for="email" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="phoneNumber">
                                        Mobile number*</label>
                                    <input id="phoneNumber" type="tel" name="phoneNumber" placeholder="" value="<%=FormData.tab2.phoneNumber %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field" />
                                    <span class="field-validation-valid" data-valmsg-for="phoneNumber" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="postcode">
                                        Postcode*</label>
                                    <input id="postcode" type="text" name="postcode" placeholder="" value="<%=FormData.tab2.postcode %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field"
                                        data-val-regex="Must only contains numbers" data-val-regex-pattern="^[0-9]+$" />
                                    <span class="field-validation-valid" data-valmsg-for="postcode" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="ddlState">
                                        State*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateEnumDropDown("ddlState", "state", "", typeof(ENUM_State), ((int)FormData.tab2.state).ToString(), new { required = "required" })%>
                                </div>
                                <%--<h3 class="tab-title">
                                    Email subscriptions</h3>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="receiveEmail" name="receiveEmail" value="true" <%=FormData.tab2.receiveEmail ? @"checked=""checked""" : string.Empty %>>
                                        Receive information about services from the Australian Institute of Company Directors</label>
                                </div>--%>
                            </div>
                            <!-- tab2 -->
                            <div class="tab-pane fade" id="tab3">
                                <input type="hidden" name="internalGUID" value="" />
                                <h3 class="tab-title">
                                    Directorship Experience</h3>
                                <div class="form-group">
                                    <div class="help-text">
                                        Please summarise your directorship experience, including sector and governance expertise
                                        and committee and board roles and responsibilities. (Max 200 words)</div>
                                    <textarea id="experienceSummary" name="experienceSummary" cols="5" rows="5" class="maxtwohundred"
                                        data-val="false"></textarea><p>
                                        </p>
                                    <span class="field-validation-valid" data-valmsg-for="experienceSummary" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <hr>
                                <div class="form-group">
                                    <div class="help-text">
                                    <b>Board and Committee Experience</b> Please list up to 6 directorships you have held and any committee positions held on these boards.</div><br />
                                    <label class="control-label" for="ddlDirectorshipExpJobType">
                                        Type of role*</label>
                                    <%= AicdSponsorshipFrontEndHelper.DirectorshipRole.GenerateDirectorshipRoleDropDown("ddlDirectorshipExpJobType", "roleType", "", "1", null) %>
                                    <div class="othersfield" style="display: none;">
                                        <input type="text" placeholder="Please specify" id="roleType_Specify" name="roleType_Specify" />
                                        <span class="field-validation-valid" data-valmsg-for="roleType_Specify" data-valmsg-replace="true"
                                            style="color: Red"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtDirectorshipExpJobTitle">
                                        Position title*</label>
                                    <input id="txtDirectorshipExpJobTitle" name="positionTitle" type="text" placeholder="Position title"
                                        required="required" data-val="true" data-val-required="Please fill in the required field" />
                                    <span class="field-validation-valid" data-valmsg-for="positionTitle" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtDirectorshipExpOrganisationName">
                                        Organisation Name*</label>
                                    <input id="txtDirectorshipExpOrganisationName" name="organisationName" type="text"
                                        placeholder="Organisation Name" required="required" data-val="true" data-val-required="Please fill in the required field" />
                                    <span class="field-validation-valid" data-valmsg-for="organisationName" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="startDirectorshipExpJobStartDate">
                                        Start Date*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateMonthDropDown("ddlDirectorshipExpJobStartMonth", "dirStartDateMonth", "", 1, null) %>
                                </div>
                                <div class="form-group">
                                    <%= AicdSponsorshipFrontEndHelper.GenerateYearDropDown("ddlDirectorshipExpJobStartYear", "dirStartDateYear", "", DateTime.Now.Year - 80, DateTime.Now.Year, DateTime.Now.Year, null, null) %>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="startDirectorshipExpJobEndDate">
                                        End Date*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateMonthDropDown("ddlDirectorshipExpJobEndMonth", "dirEndDateMonth", "", 1, null) %>
                                    <span class="field-validation-valid" data-valmsg-for="dirEndDateMonth" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <%= AicdSponsorshipFrontEndHelper.GenerateYearDropDown("ddlDirectorshipExpJobEndYear", "dirEndDateYear", "", DateTime.Now.Year - 80, DateTime.Now.Year, DateTime.Now.Year, null, null) %>
                                </div>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <label for="directorshipIsCurrent">
                                            <input type="checkbox" id="directorshipIsCurrent" name="directorshipIsCurrent" value="true"
                                                onclick="DirectorRoleIsCurrentClick(this);" />
                                            <span class="field-validation-valid" data-valmsg-for="directorshipIsCurrent" data-valmsg-replace="true"
                                                style="color: Red"></span>Is Current</label>
                                    </div>
                                </div>
                                <h4>
                                    Additional roles and responsibilities</h4>
                                (Please select if you have held these roles at any time as a director)
                                <hr>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <label for="chkAdditionalDirectorChair">
                                            <input type="checkbox" id="chkAdditionalDirectorChair" name="role_isChairman" value="true" />
                                            Board Chair</label></div>
                                    <%--<div class="checkbox">
                                        <label for="chkAdditionalDirectorOwner">
                                            <input type="checkbox" id="chkAdditionalDirectorOwner" name="role_isOwnerDirector"
                                                value="true" />
                                            Owner director</label></div>
                                    <div class="checkbox">
                                        <label for="chkAdditionalDirectorSecretary">
                                            <input type="checkbox" id="chkAdditionalDirectorSecretary" name="role_isCompanySecretary"
                                                value="true" />
                                            Company secretary</label></div>--%>
                                </div>
                                <hr>
                                <div class="form-group">
                                    <label class="control-label" for="chkAdditionalDirectorCommittee">
                                        Member of board committee(s)</label>
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="chkAdditionalDirectorCommittee1" name="member_isAudit"
                                                value="true" />
                                            Audit</label></div>
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="chkAdditionalDirectorCommittee2" name="member_isCompliance"
                                                value="true" />
                                            Compliance</label></div>
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="chkAdditionalDirectorCommittee3" name="member_isFinance"
                                                value="true" />
                                            Finance</label></div>
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="chkAdditionalDirectorCommittee4" name="member_isNominations"
                                                value="true" />
                                            Nominations</label></div>
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="chkAdditionalDirectorCommittee5" name="member_isRemuneration"
                                                value="true" />
                                            Remuneration</label></div>
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="chkAdditionalDirectorCommittee6" name="member_isRisk"
                                                value="true" />
                                            Risk</label></div>
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" id="chkAdditionalDirectorCommittee7" name="member_isSustainability"
                                                value="true" />
                                            Sustainability</label></div>
                                    <label>
                                        Others</label>
                                    <input type="text" id="chkAdditionalDirectorCommittee8Other" name="member_isOther_Specify"
                                        placeholder="Please specify" />
                                </div>
                                <h4>
                                    Organisation details</h4>
                                <hr>
                                <div class="form-group">
                                    <label class="control-label" for="ddlDirectorshipExpOrgType">
                                        Type of organisation*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateDirectorshipOrgTypeDropDown("ddlDirectorshipExpOrgType", "organisationType", "", "0", null) %>
                                    <span class="field-validation-valid" data-valmsg-for="organisationType" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="ddlDirectorshipExpOrgIndustry">
                                        Organisation industry*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateDirectorshipOrgIndustryDropDown("ddlDirectorshipExpOrgIndustry", "organisationIndustry", "", "", null) %>
                                    <span class="field-validation-valid" data-valmsg-for="organisationIndustry" data-valmsg-replace="true" style="color: Red"></span>
                                </div>
                                <br>
                                <div>
                                    <span class="field-validation-valid" data-valmsg-for="tab3_form" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <!-- experience -->
                                <button id="addDirectorshipExperience" type="button" class="btn btn-primary add-another"
                                    onclick="AddDirectorshipExperience(this);">
                                    <i class="fa fa-plus">
                                        <!--ICON-->
                                    </i>Save
                                    <%= FormData.tab3.Count() > 0 ? "& add another" : string.Empty %>
                                    role</button>
                                <button id="resetDirectorshipExperience" type="button" class="btn btn-default add-another"
                                    onclick="ResetForm('#tab3');">
                                    <i class="fa fa-refresh">
                                        <!--ICON-->
                                    </i>Reset</button>
                                <button id="editDirectorshipCancel" type="button" class="btn btn-default add-another hide"
                                    onclick="CancelDirectorshipExperience(this);">
                                    <i class="fa fa-plus">
                                        <!--ICON-->
                                    </i>Cancel</button>
                                <br>
                                <div class="directorship-experience-list">
                                    <div class="table-responsive">
                                        <table id="directorship-experience-table" class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        Role
                                                    </th>
                                                    <th>
                                                        Job Title
                                                    </th>
                                                    <th>
                                                        Organisation
                                                    </th>
                                                    <th>
                                                        Start
                                                    </th>
                                                    <th>
                                                        End
                                                    </th>
                                                    <th class="text-right">
                                                        Actions
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <% 
                                                    if (FormData.tab3.Count() == 0)
                                                    {
                                                %>
                                                <tr>
                                                    <td colspan="6">
                                                        <i>You have not added any directorship experience yet</i>
                                                    </td>
                                                </tr>
                                                <%                                                                
                                                    }

                                                    foreach (DirectorshipExperience exp in FormData.tab3)
                                                    {
                                                %>
                                                <tr>
                                                    <td>
                                                        <%=AicdSponsorshipFrontEndHelper.DirectorshipRole.DirectorshipRoleFullTextFromEnumGet(((int)exp.roleType).ToString()) %>
                                                    </td>
                                                    <td>
                                                        <%=exp.positionTitle %>
                                                    </td>
                                                    <td>
                                                        <%=exp.organisationName %>
                                                    </td>
                                                    <td>
                                                        <%=String.Format("{0:MMM yyyy}", new DateTime(exp.dirStartDateYear, exp.dirStartDateMonth,1)) %>
                                                    </td>
                                                    <td>
                                                        <%=exp.directorshipIsCurrent ? "Present" : String.Format("{0:MMM yyyy}", new DateTime(exp.dirEndDateYear, exp.dirEndDateMonth,1)) %>
                                                    </td>
                                                    <td class="text-right">
                                                        <button type="button" class="btn btn-success btn-xs" onclick="EditDirectorshipRole('<%=exp.internalGUID %>', this);">
                                                            <i class="fa fa-pencil">
                                                                <!--ICON-->
                                                            </i>Edit</button>
                                                        <button type="button" class="btn btn-danger btn-xs" onclick="DeleteDirectorshipRole('<%=exp.internalGUID %>', this);">
                                                            <i class="fa fa-times">
                                                                <!--ICON-->
                                                            </i>Delete</button>
                                                    </td>
                                                </tr>
                                                <%          
                                                    } 
                                                %>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <!-- tab3 -->
                            <div class="tab-pane fade" id="tab4">
                                <input type="hidden" name="internalGUID" value="" />
                                <h3 class="tab-title">
                                    Professional Experience</h3>
                                <div class="form-group">
                                    <div class="help-text">
                                        Briefly describe your professional experience. Please include Key responsibilities and achievements and committte experience you have gained. (Max 200 words)</div>
                                    <textarea id="txtProfessionalExpSummary" name="professionalExperienceSummary" cols="5"
                                        rows="5" class="maxtwohundred"></textarea><p>
                                        </p>
                                    <span class="field-validation-valid" data-valmsg-for="professionalExperienceSummary"
                                        data-valmsg-replace="true" style="color: Red"></span>
                                </div>
                                <hr>
                                <div class="form-group">
                                    <div class="help-text">
                                        <b>Professional Experience (excluding board and committee positions)</b>. Please list up to 6 of your most recent positions held. If more than one significant position was held with the same organisation, please list each significant position held and dates. Please do not list non-executive director roles in this section.</div><br />
                                    <label class="control-label" for="ddlProfessionalExpJobType">
                                        Type of role*</label>
                                    <%= AicdSponsorshipFrontEndHelper.ProfessionalRole.GenerateProfessionalRoleDropDown("ddlProfessionalExpJobType", "profRole", "", "1", null) %>
                                    <div class="othersfield" style="display: none;">
                                        <input type="text" placeholder="Please specify" id="profRole_Specify" name="profRole_Specify" />
                                        <span class="field-validation-valid" data-valmsg-for="profRole_Specify" data-valmsg-replace="true"
                                            style="color: Red"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtProfessionalExpJobTitle">
                                        Position Title*</label>
                                    <input id="txtProfessionalExpJobTitle" type="text" name="jobTitle" placeholder="Job title"
                                        required="required" data-val="true" data-val-required="Please fill in the required field" />
                                    <span class="field-validation-valid" data-valmsg-for="jobTitle" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="txtProfessionalExpOrganisationName">
                                        Organisation Name*</label>
                                    <input id="txtProfessionalExpOrganisationName" type="text" name="profOrgName" placeholder="Organisation Name"
                                        required="required" data-val="true" data-val-required="Please fill in the required field" />
                                    <span class="field-validation-valid" data-valmsg-for="profOrgName" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="startProfessionalExpJobStartDate">
                                        Start Date*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateMonthDropDown("startProfessionalExpJobStartMonth", "profStartDateMonth", "", 1, null) %>
                                </div>
                                <div class="form-group">
                                    <%= AicdSponsorshipFrontEndHelper.GenerateYearDropDown("startProfessionalExpJobStartYear", "profStartDateYear", "", DateTime.Now.Year - 80, DateTime.Now.Year, DateTime.Now.Year, null, null) %>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="endProfessionalExpJobEndDate">
                                        End Date*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateMonthDropDown("endProfessionalExpJobEndMonth", "profEndDateMonth", "", 1, null) %>
                                    <span class="field-validation-valid" data-valmsg-for="profEndDateMonth" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <%= AicdSponsorshipFrontEndHelper.GenerateYearDropDown("endProfessionalExpJobEndYear", "profEndDateYear", "", DateTime.Now.Year - 80, DateTime.Now.Year, DateTime.Now.Year, null, null) %>
                                </div>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <label for="profIsCurrent">
                                            <input type="checkbox" id="profIsCurrent" name="profIsCurrent" value="true" onclick="ProfessionalRoleIsCurrentClick(this);" />
                                            <span class="field-validation-valid" data-valmsg-for="profIsCurrent" data-valmsg-replace="true"
                                                style="color: Red"></span>Is Current
                                        </label>
                                    </div>
                                </div>
                                <%--<h4>
                                    Additional roles and responsibilities</h4>
                                <hr>
                                <div class="form-group">
                                    <div class="checkbox">
                                        <label for="chkAdditionalProfessionalSecretary">
                                            <input type="checkbox" id="chkAdditionalProfessionalSecretary" name="role_isSecretary"
                                                value="true">
                                            Company secretary</label>
                                    </div>
                                </div>--%>
                                <h4>
                                    Organisation details</h4>
                                <hr>
                                <div class="form-group">
                                    <label class="control-label" for="ddlProfessionalExpOrgType">
                                        Type of organisation*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateDirectorshipOrgTypeDropDown("ddlProfessionalExpOrgType", "organisationType", "", "0", null) %>
                                    <span class="field-validation-valid" data-valmsg-for="organisationType" data-valmsg-replace="true" style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="ddlProfessionalExpOrgIndustry">
                                        Organisation industry*</label>
                                    <%= AicdSponsorshipFrontEndHelper.GenerateDirectorshipOrgIndustryDropDown("ddlProfessionalExpOrgIndustry", "organisationIndustry", "", "", null) %>
                                    <span class="field-validation-valid" data-valmsg-for="organisationIndustry" data-valmsg-replace="true" style="color: Red"></span>
                                </div>
                                <br>
                                <div>
                                    <span class="field-validation-valid" data-valmsg-for="tab4_form" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <!-- experience -->
                                <button id="addProfessionalExperience" type="button" class="btn btn-primary add-another"
                                    onclick="AddProfessionalExperience(this);">
                                    <i class="fa fa-plus">
                                        <!--ICON-->
                                    </i>Save
                                    <%= FormData.tab4.Count() > 0 ? "& add another" : string.Empty %>
                                    role</button>
                                <button id="resetProfessionalExperience" type="button" class="btn btn-default add-another"
                                    onclick="ResetForm('#tab4');">
                                    <i class="fa fa-refresh">
                                        <!--ICON-->
                                    </i>Reset</button>
                                <button id="editProfessionalCancel" type="button" class="btn btn-default add-another hide"
                                    onclick="CancelProfessionalExperience(this);">
                                    <i class="fa fa-plus">
                                        <!--ICON-->
                                    </i>Cancel</button>
                                <br>
                                <div class="Professional-experience-list">
                                    <div class="table-responsive">
                                        <table id="professional-experience-table" class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        Role
                                                    </th>
                                                    <th>
                                                        Job Title
                                                    </th>
                                                    <th>
                                                        Organisation
                                                    </th>
                                                    <th>
                                                        Start
                                                    </th>
                                                    <th>
                                                        End
                                                    </th>
                                                    <th class="text-right">
                                                        Actions
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <% 
                                                    if (FormData.tab4.Count() == 0)
                                                    {
                                                %>
                                                <tr>
                                                    <td colspan="6">
                                                        <i>You have not added any professional experience yet</i>
                                                    </td>
                                                </tr>
                                                <%                                                                
                                                    }

                                                    foreach (ProfessionalExperience exp in FormData.tab4)
                                                    {
                                                %>
                                                <tr>
                                                    <td>
                                                        <%=AicdSponsorshipFrontEndHelper.ProfessionalRole.ProfessionalRoleFullTextFromEnumGet(((int)exp.profRole).ToString()) %>
                                                    </td>
                                                    <td>
                                                        <%=exp.jobTitle %>
                                                    </td>
                                                    <td>
                                                        <%=exp.profOrgName %>
                                                    </td>
                                                    <td>
                                                        <%=String.Format("{0:MMM yyyy}", new DateTime(exp.profStartDateYear, exp.profStartDateMonth,1)) %>
                                                    </td>
                                                    <td>
                                                        <%=exp.profIsCurrent ? "Present" : String.Format("{0:MMM yyyy}", new DateTime(exp.profEndDateYear, exp.profEndDateMonth,1)) %>
                                                    </td>
                                                    <td class="text-right">
                                                        <button type="button" class="btn btn-success btn-xs" onclick="EditProfessionalRole('<%=exp.internalGUID %>', this);">
                                                            <i class="fa fa-pencil">
                                                                <!--ICON-->
                                                            </i>Edit</button>
                                                        <button type="button" class="btn btn-danger btn-xs" onclick="DeleteProfessionalRole('<%=exp.internalGUID %>', this);">
                                                            <i class="fa fa-times">
                                                                <!--ICON-->
                                                            </i>Delete</button>
                                                    </td>
                                                </tr>
                                                <%          
                                                    } 
                                                %>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <!-- tab4 -->
                            <div class="tab-pane fade" id="tab5">
                                <h3 class="tab-title">
                                    Education and Qualifications</h3>
                                <div id="qualificationForm">
                                    <input type="hidden" name="internalGUID" value="" />
                                    <div class="form-group">
                                        <label class="control-label" for="txtEducationCourseName">
                                            Qualification name (e.g Bachelor of Business)*</label>
                                        <input id="txtEducationCourseName" type="text" name="courseName" placeholder="Master of Business Management"
                                            data-val="true" data-val-required="Please fill in the required field">
                                        <span class="field-validation-valid" data-valmsg-for="courseName" data-valmsg-replace="true"
                                            style="color: Red"></span>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label" for="txtEducationInstitution">
                                            Institution*</label>
                                        <input id="txtEducationInstitution" type="text" name="institution" placeholder="University of Sydney"
                                            data-val="true" data-val-required="Please fill in the required field">
                                        <span class="field-validation-valid" data-valmsg-for="institution" data-valmsg-replace="true"
                                            style="color: Red"></span>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label" for="startEducationDate">
                                            Start Date*</label>
                                        <%= AicdSponsorshipFrontEndHelper.GenerateMonthDropDown("ddlEducationStartMonth", "qStartDateMonth", "", 1, null) %>
                                    </div>
                                    <div class="form-group">
                                        <%= AicdSponsorshipFrontEndHelper.GenerateYearDropDown("ddlEducationStartYear", "qStartDateYear", "", DateTime.Now.Year - 80, DateTime.Now.Year, DateTime.Now.Year, null, null) %>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label" for="endEducationDate">
                                            End Date*</label>
                                        <%= AicdSponsorshipFrontEndHelper.GenerateMonthDropDown("ddlEducationEndMonth", "qEndDateMonth", "", 1, null) %>
                                        <span class="field-validation-valid" data-valmsg-for="qEndDateMonth" data-valmsg-replace="true"
                                            style="color: Red"></span>
                                    </div>
                                    <div class="form-group">
                                        <%= AicdSponsorshipFrontEndHelper.GenerateYearDropDown("ddlEducationEndYear", "qEndDateYear", "", DateTime.Now.Year - 80, DateTime.Now.Year, DateTime.Now.Year, null, null) %>
                                    </div>
                                    <div class="form-group">
                                        <div class="checkbox">
                                            <label for="qIsCurrent">
                                                <input type="checkbox" id="qIsCurrent" name="qIsCurrent" value="true" onclick="QualificationIsCurrentClick(this);" />
                                                <span class="field-validation-valid" data-valmsg-for="qIsCurrent" data-valmsg-replace="true"
                                                    style="color: Red"></span>Is Current
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <!-- qualification -->
                                <br>
                                <div>
                                    <span class="field-validation-valid" data-valmsg-for="tab5_form" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <button id="add-qualification" type="button" class="btn btn-primary add-another"
                                    onclick="AddQualification(this);">
                                    <i class="fa fa-plus">
                                        <!--ICON-->
                                    </i>Save
                                    <%= FormData.tab5.qualifications.Count() > 0 ? "& add another" : string.Empty %>
                                    qualification</button>
                                <button id="resetQualification" type="button" class="btn btn-default add-another"
                                    onclick="ResetForm('#qualificationForm');">
                                    <i class="fa fa-refresh">
                                        <!--ICON-->
                                    </i>Reset</button>
                                <button id="cancel-qualification" type="button" class="btn btn-default add-another hide"
                                    onclick="CancelQualification(this);">
                                    <i class="fa fa-plus">
                                        <!--ICON-->
                                    </i>Cancel</button>
                                <br>
                                <br>
                                <div class="qualification-list">
                                    <div class="table-responsive">
                                        <table id="qualification-table" class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        Course Name
                                                    </th>
                                                    <th>
                                                        Institution
                                                    </th>
                                                    <th>
                                                        Start
                                                    </th>
                                                    <th>
                                                        End
                                                    </th>
                                                    <th class="text-right">
                                                        Actions
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <% 
                                                    if (FormData.tab5.qualifications.Count() == 0)
                                                    {
                                                %>
                                                <tr>
                                                    <td colspan="6">
                                                        <i>You have not added any qualifications yet</i>
                                                    </td>
                                                </tr>
                                                <%                                                                
                                                    }

                                                    foreach (Qualifications exp in FormData.tab5.qualifications)
                                                    {
                                                %>
                                                <tr>
                                                    <td>
                                                        <%=exp.courseName %>
                                                    </td>
                                                    <td>
                                                        <%=exp.institution %>
                                                    </td>
                                                    <td>
                                                        <%=String.Format("{0:MMM yyyy}", new DateTime(exp.qStartDateYear, exp.qStartDateMonth,1)) %>
                                                    </td>
                                                    <td>
                                                        <%=exp.qIsCurrent ? "Present" : String.Format("{0:MMM yyyy}", new DateTime(exp.qEndDateYear, exp.qEndDateMonth, 1))%>
                                                    </td>
                                                    <td class="text-right">
                                                        <button type="button" class="btn btn-success btn-xs" onclick="EditQualification('<%=exp.internalGUID %>', this);">
                                                            <i class="fa fa-pencil">
                                                                <!--ICON-->
                                                            </i>Edit</button>
                                                        <button type="button" class="btn btn-danger btn-xs" onclick="DeleteQualification('<%=exp.internalGUID %>', this);">
                                                            <i class="fa fa-times">
                                                                <!--ICON-->
                                                            </i>Delete</button>
                                                    </td>
                                                </tr>
                                                <%          
                                                } 
                                                %>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <h3 class="tab-title">
                                    Association Memberships (e.g. Institute of Chartered Accountants in Australia)</h3>
                                <%--<div class="checkbox dynamic-content">
                                    <label>
                                        <input type="checkbox" value="true" id="AreYouMemberOfAICD" name="AreYouMemberOfAICD"
                                            <%= FormData.tab5.AreYouMemberOfAICD ? @"checked=""checked""" : string.Empty %>>Are
                                        you a member of the Australian Insititue of Company Directors?</label>
                                </div>
                                <div class="checkbox dynamic-content">
                                    <label>
                                        <input type="checkbox" value="true" id="chkAssociationMem1" name="CPA" <%= FormData.tab5.CPA ? @"checked=""checked""" : string.Empty %>>CPA
                                        (Certified Professional Accountant)</label>
                                </div>
                                <div class="checkbox dynamic-content">
                                    <label>
                                        <input type="checkbox" value="true" id="chkAssociationMem2" name="ICAA" <%= FormData.tab5.ICAA ? @"checked=""checked""" : string.Empty %>>ICAA
                                        (Institute of Chartered Accountants in Australia)</label>
                                </div>
                                <div class="checkbox dynamic-content">
                                    <label>
                                        <input type="checkbox" value="true" id="chkAssociationMem3" name="CSA" <%= FormData.tab5.CSA ? @"checked=""checked""" : string.Empty %>>Governance
                                        Institute of Australia
                                    </label>
                                </div>
                                <div class="checkbox dynamic-content">
                                    <label>
                                        <input type="checkbox" value="true" id="chkAssociationMem4" name="EA" <%= FormData.tab5.EA ? @"checked=""checked""" : string.Empty %>>EA
                                        (Engineering Australia)</label>
                                </div>
                                <div class="checkbox dynamic-content">
                                    <label>
                                        <input type="checkbox" value="true" id="chkAssociationMem5" name="LawSociety" <%= FormData.tab5.LawSociety ? @"checked=""checked""" : string.Empty %>>My
                                        state Law Society</label>
                                </div>
                                <div class="checkbox dynamic-content">
                                    <label>
                                        <input type="checkbox" value="true" id="chkAssociationMem6" name="IntDirectorshipOrg"
                                            <%= FormData.tab5.IntDirectorshipOrg ? @"checked=""checked""" : string.Empty %>>International
                                        directorship organisation</label>
                                </div>--%>
                                <div class="dynamic-content others">
                                    
                                    <div class="dynamic-content othersfield">
                                        
                                        <textarea cols="5" rows="5" placeholder="(e.g. Institute of Chartered Accountants in Australia)" id="chkAssociationMem7Other" name="Other_Specify"><%= FormData.tab5.Other_Specify %></textarea>
                                        <span class="field-validation-valid" data-valmsg-for="Other_Specify" data-valmsg-replace="true" style="color: Red"></span>
                                    </div>
                                </div>
                            </div>
                            <!-- tab5 -->
                            <%--<div class="tab-pane fade" id="tab6">
                        </div>
                        <!-- tab6 -->--%>
                            <div class="tab-pane fade" id="tab7">
                                <h3 class="tab-title">
                                    Referee contacts</h3>
                                Please provide contact details of two referees who support your application and
                                can verify comments provided. Note your referees may be contacted if you reach the
                                candidate short list for this application.
                                <h4>
                                    First referee</h4>
                                <div class="form-group">
                                    <label for="txtFirstRefereeName" class="control-label">
                                        Name*</label>
                                    <input type="text" name="name1" id="txtFirstRefereeName" value="<%=FormData.tab7.name1 %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field">
                                    <span class="field-validation-valid" data-valmsg-for="name1" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstRefereeRelationship" class="control-label">
                                        Relationship to you*</label>
                                    <input type="text" name="relationship1" id="txtFirstRefereeRelationship" value="<%=FormData.tab7.relationship1 %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field">
                                    <span class="field-validation-valid" data-valmsg-for="relationship1" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstRefereeContact" class="control-label">
                                        Contact details (mobile, email)*</label>
                                    <input type="text" name="contact1" id="txtFirstRefereeContact" value="<%=FormData.tab7.contact1 %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field">
                                    <span class="field-validation-valid" data-valmsg-for="contact1" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <h4>
                                    Second referee</h4>
                                <div class="form-group">
                                    <label for="txtSecondRefereeName" class="control-label">
                                        Name*</label>
                                    <input type="text" name="name2" id="txtSecondRefereeName" value="<%=FormData.tab7.name2 %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field">
                                    <span class="field-validation-valid" data-valmsg-for="name2" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label for="txtSecondRefereeRelationship" class="control-label">
                                        Relationship to you*</label>
                                    <input type="text" name="relationship2" id="txtSecondRefereeRelationship" value="<%=FormData.tab7.relationship2 %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field">
                                    <span class="field-validation-valid" data-valmsg-for="relationship2" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                                <div class="form-group">
                                    <label for="txtSecondRefereeContact" class="control-label">
                                        Contact details (mobile, email)*</label>
                                    <input type="text" name="contact2" id="txtSecondRefereeContact" value="<%=FormData.tab7.contact2 %>"
                                        required="required" data-val="true" data-val-required="Please fill in the required field">
                                    <span class="field-validation-valid" data-valmsg-for="contact2" data-valmsg-replace="true"
                                        style="color: Red"></span>
                                </div>
                            </div>
                            <!-- tab7 -->
                            <div class="tab-pane fade" id="tab8">
                                <h3 class="tab-title">
                                    Additional Information</h3>
                                <asp:PlaceHolder ID="plhTab1" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <%--<!-- Resume -->
                                <h3 class="tab-title">
                                    Resume</h3>
                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                    <label for="resume">
                                        Upload a Resume:</label>
                                    <div class="input-append">
                                        <div class="uneditable-input span3">
                                            <i class="icon-file fileupload-exists"></i><span class="fileupload-preview"></span>
                                        </div>
                                        <span class="btn btn-success fileinput-button"><i class="glyphicon glyphicon-plus"></i>
                                            <span>Browse..</span>
                                            <!-- The file input field used as target for the file upload widget -->
                                            <input id="fileupload" type="file" name="files[]" onclick="$('#progressBar').css('width', '0%');">
                                        </span><span id='resume-response'>
                                            <%= FormData.tab8.blnResumeFile ? "Resume file uploaded." : string.Empty %></span><br />
                                        <b><i>
                                            <%= ConfigurationManager.AppSettings["ApplicationFileTypes"] %></i></b>
                                        
                                    </div>
                                </div>--%>
                            </div>
                            <!-- tab8 -->
                            <div class="col-md-12 text-center">
                                <span class="field-validation-valid" data-valmsg-for="form_error" data-valmsg-replace="true"
                                    style="color: Red"></span>
                            </div>
                            <ul class="pager wizard">
                                <li class="previous"><a href="javascript:;" id="prevTabBtn">Previous</a></li>
                                <li class="next"><a href="javascript:void(0)" id="nextTabBtn">Next</a></li>
                                <li class="next finish pull-right" style="display: none;"><a href="javascript:void(0);" id="finishTabBtn">Submit Application</a></li>
                                <li class="draft pull-right"><a href="javascript:void(0)" id="saveDraftBtn" onclick="SaveDraft(this,false)">
                                    Save Draft</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!-- customApplication -->
            </div>
        </div>
    </div>
</asp:Content>
