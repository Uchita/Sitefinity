<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="JXTPortal.Website.member.profile" %>

<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<%@ Register Src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" TagName="ucMemberAccountNavigation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var dateformat = '<%=DateFormat %>';
    </script>
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="/styles/member/jquery-ui.css" />
    <link rel="stylesheet" href="/styles/member/jquery-ui.structure.css" />
    <link rel="stylesheet" href="/styles/member/jquery-ui.theme.css" />
    <link rel="stylesheet" href="/styles/member/jscrollpane.css" />
    <!-- the mousewheel plugin -->
    <script type="text/javascript" src="/scripts/member/jquery.mousewheel.js"></script>
    <!-- the jScrollPane script -->
    <script type="text/javascript" src="/scripts/member/jquery.jscrollpane.js"></script>
    <script src='/scripts/member/jquery-ui.js'></script>
    <script src='/scripts/member/profile-builder.js'></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="endOfHead" runat="server">
    <link rel="stylesheet" href="/styles/member/member_profile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <div id="content-container" class="container">
        <div id="content" style="box-sizing: border-box; width: 100%;" class="col-xs-12">
            <div class="content-holder">
                <div class="memberprofilelinks-wrap">
                    <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
                    <div class="clearfix">
                    </div>
                </div>
                <%--
                    <ul id="memberProfileLinks" class="nav navbar-right">
                        <li class="active"><a href="#" id="memberProfileDropdown" role="button" class="dropdown-toggle btn btn-default"
                            data-toggle="dropdown"><i class="fa fa-cog" aria-hidden="true"></i><span class="profile-dropdown-text">
                                <JXTControl:ucLanguageLiteral ID="ltSettings" runat="server" SetLanguageCode="LabelSettings" />
                            </span><b class="caret"></b></a>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="memberProfileDropdown">
                                <li id="memberProfileHome"><a href="/member/default.aspx">
                                    <JXTControl:ucLanguageLiteral ID="ltDashboard" runat="server" SetLanguageCode="LabelDashboard" />
                                </a></li>
                                <li id="memberProfileDetails"><a href="/member/memberedit.aspx">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LinkButtonAccountDetails" />
                                </a></li>
                                <li id="memberProfilePassword"><a href="/member/changepassword.aspx">
                                    <JXTControl:ucLanguageLiteral ID="ltChangePassword" runat="server" SetLanguageCode="LabelChangePassword" />
                                </a></li>
                                <li id="memberProfileCV" class="active"><a href="/member/cvprofile.aspx">
                                    <JXTControl:ucLanguageLiteral ID="ltMenuProfile" runat="server" SetLanguageCode="LabelProfile" />
                                </a></li>
                                <li class="divider"></li>
                                <li id="memberProfileAlerts"><a href="/member/myjobalerts.aspx">
                                    <JXTControl:ucLanguageLiteral ID="ltFavouriteSearches" runat="server" SetLanguageCode="LabelFavouriteSearches" />
                                    /
                                    <JXTControl:ucLanguageLiteral ID="ltMyJobAlerts" runat="server" SetLanguageCode="LabelMyJobAlerts" />
                                </a></li>
                                <li id="memberProfileSavedJobs"><a href="/member/mysavedjobs.aspx">
                                    <JXTControl:ucLanguageLiteral ID="ltMySavedJobs" runat="server" SetLanguageCode="LabelMySavedJobs" />
                                </a></li>
                                <li id="memberProfileApplication"><a href="/member/applicationtracker.aspx">
                                    <JXTControl:ucLanguageLiteral ID="ltMyApplicationTracker" runat="server" SetLanguageCode="LabelMyApplicationTracker" />
                                </a></li>
                                <asp:PlaceHolder ID="phDraftJobs" runat="server" Visible="false">
                                    <li id='memberDraftJobs'><a href="/member/draftjobs.aspx">
                                        <JXTControl:ucLanguageLiteral ID="ltDraftJobs" runat="server" SetLanguageCode="LabelDraftJobs" />
                                    </a></li>
                                </asp:PlaceHolder>
                                <li class="divider"></li>
                                <li id="memberProfileLogout"><a href="/logout.aspx">
                                    <JXTControl:ucLanguageLiteral ID="ltLogout" runat="server" SetLanguageCode="LabelLogout" />
                                </a></li>
                            </ul>
                        </li>
                    </ul>
                    <div class="clearfix">
                    </div>
                </div>--%>
                <!-- CV Content -->
                <div id="CV-content">
                    <h1 class="CV-Builder-title">
                        <asp:Literal ID="ltTitleProfile" runat="server" />
                    </h1>
                    <!-- Basic Details -->
                    <section class="form-section scroll-point scroll-point full-width clearfix" id="section-1">
                        <div class="form-all">
                            <!-- Profile Image -->
                            <div class="col-sm-4 col-md-3 col-xs-12 " id="imgMemberProfile">
                                <figure class="noProfileImage profileImageHolder">
                                    <asp:Image ID="profilePic" runat="server" ImageUrl="/images/member/profile-placeholder.png" AlternateText="profile pic"
                                        ClientIDMode="Static" />
                                    <span class="btn btn-primary btn-sm btn-file btnUploadImage"><span class="fileupload-new">
                                        <JXTControl:ucLanguageLiteral ID="ltUploadImage" runat="server" SetLanguageCode="LabelUploadProfileImage" />
                                    </span>
                                        <asp:FileUpload ID="fuProfile" runat="server" ClientIDMode="Static" />
                                    </span>
                                </figure>
                                <p class="text-right">
                                    <asp:LinkButton ID="lbProfileSubmit" runat="server" CssClass="btn btn-primary btn-sm profile-upload-btn submit-pic-btn"
                                        OnClick="lbProfileSubmit_Click">
                                        <JXTControl:ucLanguageLiteral ID="ltProfileSubmit" runat="server" SetLanguageCode="LabelAdvertiserJobTemplateLogoSelectDoc" />
                                        <span class="fa fa-upload" aria-hidden="true"></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-sm profile-upload-btn remove-btn">
                                        <JXTControl:ucLanguageLiteral ID="ltProfileRemove" runat="server" SetLanguageCode="LabelRemove" />
                                        <span class="fa fa-times" aria-hidden="true"></span>
                                    </asp:LinkButton>
                                </p>
                                <asp:PlaceHolder ID="phProfilePicError" runat="server" Visible="false"><span class="error-message">
                                    <JXTControl:ucLanguageLiteral ID="ucProfilePicError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                </span></asp:PlaceHolder>
                            </div>
                            <!-- Basic Profile Info & Edit -->
                            <asp:UpdatePanel ID="upProfile" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-sm-8 col-md-5 col-xs-12  section-content" id="basicProfile" runat="server" clientidmode="Static">
                                        <div class="profile-data editable-section">
                                            <div class="clearfix">
                                                <div class="pull-left" id="candidate-name">
                                                    <h3>
                                                        <span class="member-title"><asp:Literal ID="ltTitle" runat="server" Text="ltTitle" /></span> <span class="first-name"><asp:Literal ID="ltFirstName" runat="server" /></span> <span class="last-name"><asp:Literal ID="ltLastName" runat="server" /></span></h3>
                                                </div>
                                                <div class="pull-left">
                                                    <a id="hfProfileEdit" runat="server" class="fa fa-edit" href="#basicProfileEdit"
                                                        data-toggle="collapse">
                                                        <!-- -->
                                                    </a>
                                                </div>
                                            </div>
                                            <asp:Literal ID="ltMultilingualFirstName" runat="server" />
                                            <%--<div id="local-name">
                                                <h5>
                                                    <strong>
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral238" runat="server" SetLanguageCode="LabelLocalName" />
                                                        :</strong> <span class="local-first-name">
                                                            <asp:Literal ID="ltMultilingualFirstName" runat="server" Text="ltMultilingualFirstName" /></span>
                                                    <span class="loca-last-name">
                                                        <asp:Literal ID="ltMultilingualLastName" runat="server" Text="ltMultilingualLastName" /></span></h5>
                                            </div>--%>
                                            <div id="headline">
                                                <p class="highlight">
                                                    <asp:Literal ID="ltHeadline" runat="server" Text="ltHeadline" /></p>
                                            </div>
                                            <div id="profileRow1" class="row">
                                                <asp:Literal ID="ltCurrentSeeking" runat="server" />
                                                <asp:Literal ID="ltAvailableDayFrom" runat="server" />
                                            </div>
                                            <div id="profileRow2" class="row">
                                                <asp:Literal ID="ltlLastModifiedDate" runat="server" />                                                
                                            </div>
                                        </div>
                                        <div class="profile-edit collapse overlayEdit" id="basicProfileEdit" runat="server" clientidmode="Static">
                                            <div class="row">
                                                <div class="col-md-6 col-xs-12 basicprofile-closebtn pull-right">
                                                    <a href="#basicProfileEdit" data-toggle="collapse" class="fa fa-times close-btn">
                                                        <!-- close -->
                                                    </a>
                                                </div>
                                                <div class="col-md-6 col-xs-12">
                                                    <div class="form-line" id="ucmemberedit-title">
                                                        <asp:Label ID="lbProfileTitle" runat="server" AssociatedControlID="ddlProfileTitle">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelTitle" />
                                                            <span class="form-required">*</span>:</asp:Label>
                                                        <div class="form-input">
                                                            <div class="custom-select">
                                                                <asp:DropDownList ID="ddlProfileTitle" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Selected="selected" Value="0" disabled="disabled">-- ddlProfileTitle --</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <asp:PlaceHolder ID="phProfileTitleError" runat="server" Visible="false"><span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ucProfileTitleError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6 col-xs-12">
                                                    <div class="form-input">
                                                        <div class="form-line" id="ucmemberedit-first-name">
                                                            <asp:Label id="lbProfileFirstName" runat="server" AssociatedControlID="tbProfileFirstName">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelFirstName" />
                                                                <span class="form-required">*</span>:</asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbProfileFirstName" runat="server" CssClass="form-control" placeholder="First Name" />
                                                                <asp:PlaceHolder ID="phProfileFirstNameError" runat="server" Visible="false"><span
                                                                    class="error-message">
                                                                    <JXTControl:ucLanguageLiteral ID="ltErrorProfileFirstName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                                </span></asp:PlaceHolder>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-xs-12">
                                                    <div class="form-line">
                                                        <asp:Label id="lbProfileLastName" runat="server" AssociatedControlID="tbProfileLastName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelLastName" />
                                                            <span class="form-required">*</span>:</asp:Label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbProfileLastName" runat="server" CssClass="form-control" placeholder="Last Name" />
                                                            <asp:PlaceHolder ID="phProfileLastNameError" runat="server" Visible="false"><span
                                                                class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ltErrorProfileLastName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <asp:PlaceHolder ID="phMultilingual" runat="server">
                                            <div class="row">
                                                <div class="col-md-6 col-xs-12">
                                                    <div class="form-input">
                                                        <div class="form-line" id="ucmemberedit-multilingual-firstname">
                                                            <asp:Label id="lbProfileFirstNameLocalLanguage" runat="server" AssociatedControlID="tbProfileFirstNameLocalLanguage">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelFirstNameLocalLanguage" />
                                                                :</asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbProfileFirstNameLocalLanguage" runat="server" CssClass="form-control"
                                                                    placeholder="First Name" />
                                                            </div>
                                                        </div>
                                                        <asp:PlaceHolder ID="phProfileFirstNameLocalError" runat="server" Visible="false">
                                                            <span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ltErrorProfileFirstNameLocal" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                            </span>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-xs-12">
                                                    <div class="form-line" id="ucmemberedit-multilingual-lastname">
                                                        <asp:Label ID="lbProfileLastNameLocalLanguage" runat="server" AssociatedControlID="tbProfileLastNameLocalLanguage">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelLastNameLocalLanguage" />
                                                            :</asp:Label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbProfileLastNameLocalLanguage" runat="server" CssClass="form-control"
                                                                placeholder="Last Name" />
                                                        </div>
                                                    </div>
                                                    <asp:PlaceHolder ID="phProfileLastNameLocalError" runat="server" Visible="false">
                                                        <span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorProfileLastNameLocal" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                        </span>
                                                    </asp:PlaceHolder>
                                                </div>
                                            </div>
                                            </asp:PlaceHolder>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-line">
                                                        <asp:Label ID="lbProfileHeadline" runat="server" AssociatedControlID="tbProfileHeadline">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelHeadline" />
                                                            <span class="form-required">*</span>:</asp:Label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbProfileHeadline" runat="server" CssClass="form-control" placeholder="Headline" MaxLength="512" />
                                                        </div>
                                                    </div>
                                                    <asp:PlaceHolder ID="phProfileHeadlineError" runat="server" Visible="false"><span
                                                        class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ucProfileHeadlineError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6 col-xs-12">
                                                    <div class="form-line">
                                                        <asp:Label ID="lbProfileCurrentStatus" runat="server" AssociatedControlID="ddlProfileCurrentStatus">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelCurrentStatus" />
                                                            :</asp:Label>
                                                        <div class="form-input">
                                                            <div class="custom-select">
                                                                <asp:DropDownList ID="ddlProfileCurrentStatus" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Selected="selected" Value="0" disabled="disabled">-- ddlProfileCurrentStatus --</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-xs-12">
                                                    <div class="form-line">
                                                        <asp:Label ID="lbMemberavailableDate" runat="server" AssociatedControlID="memberavailableDate">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelAvailabilityDateFrom" />
                                                            :</asp:Label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="memberavailableDate" runat="server" placeholder="Availability Date"
                                                                ClientIDMode="Static" CssClass="form-control" />
                                                        </div>
                                                    <asp:PlaceHolder ID="phProfileAvailDateError" runat="server" Visible="false"><span
                                                        class="error-message-2">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral180" runat="server" SetLanguageCode="LabelInvalidDate" />
                                                    </span></asp:PlaceHolder>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <asp:LinkButton ID="lbProfileSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        ValidationGroup="Profile" OnClick="lbProfileSave_Click">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a class="btn btn-primary btn-sm cancel-btn collapsed" href="#basicProfileEdit" data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- Profile Meter Indicator -->
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" class="col-sm-12 col-md-4 col-xs-12">
                                <ContentTemplate>
                                <h4 class="text-center">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelHowDoesMyFileCompare" />
                                </h4>
                                <div class="info_graphic">
                                    <div class="profile-status-wrap">
                                        <div class="profile-status">
                                        </div>
                                        <span class="perc"><span class="status">
                                            <asp:Literal ID="ltProfileProgress" runat="server" Text="60" /></span>%</span>
                                    </div>
                                    <div class="profile_status_info_wrap">
                                        <div class="profile_status_info">
                                            <span class="pro_level">
                                                <asp:Literal ID="ltProfileLevel" runat="server" /></span>
                                        </div>
                                    </div>
                                </div>
                                <span id="profileSubmittedDate">
                                    <asp:Literal runat="server" ID="ltProfileSubmittedDate" Visible="false"></asp:Literal>
                                </span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </section>
                    <!-- //form-section: Basic Details -->
                    <!-- Section 1: Quick links         .............. starts -->
                    <asp:UpdatePanel ID="upNavigation" runat="server" UpdateMode="Always" class="row small">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="phIncompletedSectionHeading" runat="server">
                                <div class="col-xs-12">
                                    <h3 class="section-title" id="incompleteSectionHeading">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral26" runat="server" SetLanguageCode="LabelSectionIncomplete" />
                                    </h3>
                                </div>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavSummary" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-2" data-form=".fa-edit" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavSummary" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavDirectorship" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-15" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavDirectorship" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavWorkExperience" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-4" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavWorkExperience" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavEducation" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-5" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavEducation" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavSkills" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#sec-Skills" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavSkills" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavCertification" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-7" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavCertification" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavLicenses" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-8" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavLicenses" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavRolePreferences" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-9" data-form=".fa-edit" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavRolePreferences" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavResume" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#sec-AttachResume" data-form=".add-btn" class="btn btn-primary quick-links">
                                    <span class="ellipsis-text">
                                        <asp:Literal ID="ltNavResume" runat="server" />
                                    </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavCoverLetter" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#sec-AttachCoverletter" data-form=".add-btn" class="btn btn-primary quick-links">
                                    <span class="ellipsis-text">
                                        <asp:Literal ID="ltNavCoverLetter" runat="server" />
                                    </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavLanguages" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#sec-Languages" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavLanguages" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavReferences" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-13" data-form=".add-btn" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavReferences" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                            <asp:PlaceHolder ID="phNavCustomQuestions" runat="server"><span class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <a href="#section-14" data-form=".fa-edit" class="btn btn-primary quick-links"><span
                                    class="ellipsis-text">
                                    <asp:Literal ID="ltNavCustomQuestions" runat="server" />
                                </span><span class="fa fa-pencil-square-o"></span></a></span></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div>
                        <a href="javascript:void(0);" class="viewmore_btn"><span class="more-btn">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral29" runat="server" SetLanguageCode="LabelViewMore" />
                        </span><span class="less-btn">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral30" runat="server" SetLanguageCode="LabelViewLess" />
                        </span></a>
                    </div>
                    <!-- Section 1: Quick links         .................. ends -->
                    <!-- Section 2: Summary And Personal Details ........ starts -->
                    <asp:UpdatePanel ID="upSummary" runat="server" UpdateMode="Conditional" class="scroll-point">
                        <ContentTemplate>
                            <div class="row equal-height-blocks">
                                <asp:PlaceHolder ID="phSectionSummary" runat="server">
                                    <div class="col-md-6">
                                        <section class="form-section full-width clearfix" id="section-2">
                                        <div class="form-all">
                                            <article id="acSummary" runat="server" class="section-content">
                                                <div class="editable-section">
                                                    <div class="row">
                                                        <div class="col-sm-7 col-xs-8 has-edit-icon">
                                                            <h3 class="section-title">
                                                                <span class="fa fa-file-text-o form-icon">
                                                                    <!-- icon -->
                                                                </span>
                                                                <asp:Literal ID="ltTitleSummary" runat="server" />
                                                                <span id="summaryInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- iconc --></span>
                                                            </h3>
                                                        </div>
                                                        <div class="col-sm-5 col-xs-4 add-btn-holder">
                                                            <asp:PlaceHolder ID="phTickSummary" runat="server"><span class="fa fa-check section_status pull-right" aria-hidden="true"></span></asp:PlaceHolder>
                                                            <a id="hfSummaryEdit" runat="server" href="#edit-summary" class="fa fa-edit pull-right fa-6"
                                                                data-toggle="collapse">
                                                                <!-- icon -->
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <div class="summary">
                                                        <asp:Literal ID="ltSummary" runat="server" />                                                                                                                
                                                    </div>

                                                </div>
                                                <div class="profile-edit collapse" id="ecSummary" runat="server">
                                                    <div class="row">
                                                        <div class="col-sm-7   has-edit-icon">
                                                            <h2 class="section-title">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral32" runat="server" SetLanguageCode="LabelSummary" />
                                                            </h2>
                                                        </div>
                                                        <div class="col-sm-5 add-btn-holder">
                                                            <a id="hfSummaryClose" runat="server" data-toggle="collapse" class="fa fa-times close-btn">
                                                                <!-- close -->
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <asp:PlaceHolder ID="phSummaryError" runat="server" Visible="false">
                                                        <span class="error-message-2">
                                                            <JXTControl:ucLanguageLiteral ID="ucSummaryError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span>
                                                    </asp:PlaceHolder>
                                                    <asp:TextBox ID="tbSummary" runat="server" TextMode="MultiLine" Rows="8" Columns="5" CssClass="form-control" />
                                                    <div class="button-container">
                                                        <asp:LinkButton ID="lbSummarySave" runat="server" CssClass="btn btn-primary btn-sm"
                                                            ValidationGroup="Summary" OnClick="lbSummarySave_Click">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral34" runat="server" SetLanguageCode="LabelSave" />
                                                        </asp:LinkButton>
                                                        <a id="hfSummaryCancel" runat="server" data-toggle="collapse" class="btn btn-primary btn-sm cancel-btn">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral35" runat="server" SetLanguageCode="LabelCancel" />
                                                        </a>

                                                    </div>
                                                </div>
                                            </article>
                                        </div>
                                    </section>
                                    </div>
                                </asp:PlaceHolder>
                                <div class="col-md-6">
                                    <section class="form-section full-width clearfix" id="section-3">
                                        <div class="editable-section">
                                            <div class="row">
                                                <div class="col-sm-9  has-edit-icon">
                                                    <h3 class="section-title">
                                                        <span class="fa fa-envelope-o form-icon">
                                                            <!-- icon -->
                                                        </span>
                                                        <asp:Literal ID="ltTitleMyPersonalDetails" runat="server" />
                                                        <span id="personalDetailsInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                                    </h3>
                                                </div>
                                                <div class="col-sm-3">
                                                    <!-- <a href="#personalDetails-form" data-toggle="collapse" class="btn btn-primary btn-sm add-btn pull-right"><span class="fa fa-plus"></span>Add</a> -->
                                                    <asp:PlaceHolder ID="phTickDetails" runat="server"><span class="fa fa-check section_status pull-right" aria-hidden="true"></span></asp:PlaceHolder>
                                                    <a id="hfDetailsEdit" runat="server" href="#personalDetailsform" class="fa fa-edit pull-right fa-6" data-toggle="collapse">
                                                        <!-- icon -->
                                                    </a>
                                                </div>
                                            </div>
                                            <div id="personalDetailsSlider" class="carousel slide" data-ride="carousel">
                                                <!-- Indicators -->
                                                <ol class="carousel-indicators">
                                                    <li data-target="#personalDetailsSlider" data-slide-to="0" class="active"></li>
                                                    <li data-target="#personalDetailsSlider" data-slide-to="1"></li>
                                                </ol>
                                                <!-- Wrapper for slides -->
                                                <div class="carousel-inner" role="listbox">
                                                    <div class="item active">
                                                        <span class="highlight primary-email-heading"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral37" runat="server" SetLanguageCode="LabelEmailAddress" /></span>
                                                        <span class="personal-detail-content primary-email"><asp:Literal ID="ltEmail" runat="server" Text="ltEmail" /></span> 
                                                        <asp:Literal ID="ltDateOfBirth" runat="server"  />
                                                        <asp:Literal ID="ltGender" runat="server" />

                                                        <span class="highlight address-heading"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral40" runat="server" SetLanguageCode="LabelAddress" /></span>
                                                        <span class="personal-detail-content address-detail">
                                                            <asp:Literal ID="ltAddress1" runat="server" />
                                                            <asp:Literal ID="ltAddress2" runat="server" />
                                                            <asp:Literal ID="ltCity" runat="server"  />
                                                            <asp:Literal ID="ltState" runat="server"  />
                                                            <asp:Literal ID="ltPostcode" runat="server" />
                                                            <asp:Literal ID="ltCountry" runat="server"  />
                                                        </span>

                                                            <asp:Literal ID="ltLineSelected" runat="server" Text="ltLineSelected" />
                                                    </div>
                                                    <div class="item">                                                        
                                                        <asp:Literal ID="ltSecondaryEmail" runat="server" />
                                                        <asp:Literal ID="ltPhoneNumber" runat="server" />
                                                        <asp:Literal ID="ltMobileNumber" runat="server" />
                                                        <asp:Literal ID="ltPassportNumber" runat="server" />
                                                        <span class="highlight">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral45" runat="server" SetLanguageCode="LabelMailingAddress" />
                                                        </span>
                                                        <span class="personal-detail-content mailing-address-detail">
                                                            <asp:Literal ID="ltMailingAddress1" runat="server" />
                                                            <asp:Literal ID="ltMailingAddress2" runat="server"  />
                                                            <asp:Literal ID="ltMailingCity" runat="server" />
                                                            <asp:Literal ID="ltMailingState" runat="server" />
                                                            <asp:Literal ID="ltMailingPostcode" runat="server" />
                                                            <asp:Literal ID="ltMailingCountry" runat="server" />
                                                        </span>
                                                    </div>
                                                </div>
                                                <!-- Left and right controls -->
                                                <div class="slider-nav">
                                                    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                                                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">
                                                            Previous</span> </a><a class="right carousel-control" href="#myCarousel" role="button"
                                                                data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true">
                                                                </span><span class="sr-only">Next</span> </a>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                            <div class="personalDetails-form form-all collapse" id="personalDetailsform" runat="server"
                                clientidmode="Static">
                                <div id="personal-item-1" class="row">
                                    <div class="col-sm-7 col-xs-10  has-edit-icon">
                                        <h3 class="section-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral46" runat="server" SetLanguageCode="LabelPersonalDetails" />
                                        </h3>
                                    </div>
                                    <div class="col-sm-5 col-xs-2">
                                        <a href="#personalDetailsform" data-toggle="collapse" class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                    </div>
                                </div>
                                <div class="personaldetailsForm-wrap">
                                    <div class="row">
                                        <div id="personal-item-2" class="col-md-6">
                                            <asp:Label ID="lbDetailsPrimaryEmail" runat="server" AssociatedControlID="tbDetailsPrimaryEmail">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral47" runat="server" SetLanguageCode="LabelPrimaryEmail" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="tbDetailsPrimaryEmail" runat="server" CssClass="form-control" Text="tbDetailsPrimaryEmail"
                                                    ReadOnly="false" disabled="disabled" />
                                            </div>
                                        </div>
                                        <div id="personal-item-3" class="col-md-6">
                                            <asp:Label ID="lbDetailsSecondaryEmail" runat="server" AssociatedControlID="tbDetailsSecondaryEmail">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral48" runat="server" SetLanguageCode="LabelSecondaryEmail" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="tbDetailsSecondaryEmail" runat="server" CssClass="form-control"
                                                    Text="tbDetailsSecondaryEmail" placeholder="Secondary Email" />
                                            </div>
                                            <asp:PlaceHolder ID="phDetailsSecondaryEmailError" runat="server" Visible="false"><span
                                                class="error-message">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral23" runat="server" SetLanguageCode="LabelEmailInvalid" />
                                            </span></asp:PlaceHolder>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div id="personal-item-4" class="col-md-6">
                                            <asp:Label AssociatedControlID="rbDetailsMale" ID="lbGender" runat="server">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral49" runat="server" SetLanguageCode="LabelGender" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <div class="form-single-column">
                                                    <span class="form-radio-item"><span id="personaldetail-gender" class="form-radio">
                                                        <asp:Label ID="lbDetailsMale" runat="server" CssClass="radio-inline" AssociatedControlID="rbDetailsMale">
                                                            <input type="radio" id="rbDetailsMale" runat="server" name="personaldetailGender" /><JXTControl:ucLanguageLiteral
                                                                ID="UcLanguageLiteral42" runat="server" SetLanguageCode="LabelMale" />
                                                        </asp:Label>
                                                        <asp:Label ID="lbDetailsFemale" runat="server" CssClass="radio-inline" AssociatedControlID="rbDetailsFemale">
                                                            <input type="radio" id="rbDetailsFemale" runat="server" name="personaldetailGender" /><JXTControl:ucLanguageLiteral
                                                                ID="UcLanguageLiteral41" runat="server" SetLanguageCode="LabelFemale" />
                                                        </asp:Label>
                                                    </span></span><span class="clearfix"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="personal-item-5" class="col-md-6">
                                            <asp:Label ID="lbDetailsDay" runat="server" AssociatedControlID="ddlDetailsDay">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral50" runat="server" SetLanguageCode="LabelDateOfBirth" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <div id="DateOfBirth" class="row">
                                                    <div id="DateOfBirthDayWrapper" class="col-xs-4">
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlDetailsDay" runat="server" CssClass="form-dropdown">
                                                                <asp:ListItem Selected="True" Value="0" disabled="disabled">ddlDetailsDay</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                        <asp:Label ID="lbDetailsDay2" runat="server" CssClass="form-sub-label" AssociatedControlID="ddlDetailsDay">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral51" runat="server" SetLanguageCode="LabelDay" />
                                                            :</asp:Label>
                                                    </div>
                                                    <div id="DateOfBirthMonthWrapper" class="col-xs-4">
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlDetailsMonth" runat="server" CssClass="form-dropdown">
                                                                <asp:ListItem Selected="True" Value="0" disabled="disabled">ddlDetailsMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                        <asp:Label ID="lbDetailsMonth" runat="server" CssClass="form-sub-label" AssociatedControlID="ddlDetailsMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral52" runat="server" SetLanguageCode="LabelMonth" />
                                                            :</asp:Label>
                                                    </div>
                                                    <div id="DateOfBirthYearWrapper" class="col-xs-4">
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlDetailsYear" runat="server" CssClass="form-dropdown">
                                                                <asp:ListItem Selected="True" Value="0" disabled="disabled">ddlDetailsYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                        <asp:Label ID="lbDetailsYear" runat="server" CssClass="form-sub-label" AssociatedControlID="ddlDetailsYear">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral53" runat="server" SetLanguageCode="LabelYear" />
                                                            :</asp:Label>
                                                    </div>
                                                    <asp:PlaceHolder ID="phDetailsDOBError" runat="server" Visible="false"><span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ucDetailsDOBError" runat="server" SetLanguageCode="LabelInvalidDate" />
                                                    </span></asp:PlaceHolder>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div id="personal-item-6" class="col-md-6">
                                            <div class="row">
                                                <div class="col-sm-8 col-xs-6">
                                                    <asp:Label ID="lbDetailsHomePhone" runat="server" AssociatedControlID="tbDetailsHomePhone">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral54" runat="server" SetLanguageCode="LabelPhoneHome" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <asp:TextBox ID="tbDetailsHomePhone" runat="server" CssClass="form-control" Text="tbDetailsHomePhone"
                                                            MaxLength="38" />
                                                        <asp:RegularExpressionValidator ID="validatorHomePhone" runat="server" ControlToValidate="tbDetailsHomePhone"
                                                            SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[ \+\(\)\d]*$"
                                                            ErrorMessage="ValidationPhoneNumbers">  
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="revHomePhone" runat="server" ControlToValidate="tbDetailsHomePhone"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">  
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4 col-xs-6 text-center">
                                                    <asp:Label ID="lbbPreferHomePhone" runat="server" AssociatedControlID="rbPreferHomePhone">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral55" runat="server" SetLanguageCode="LabelPreferredLine" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <input name="preferredPhone" class="form-control btn-checkbox" type="radio" id="rbPreferHomePhone"
                                                            runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="personal-item-7" class="col-md-6">
                                            <div class="row">
                                                <div class="col-sm-8 col-xs-6">
                                                    <asp:Label ID="lbDetailsMobilePhone" runat="server" runat="server" AssociatedControlID="tbDetailsMobilePhone">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral56" runat="server" SetLanguageCode="LabelPhoneMobile" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <asp:TextBox ID="tbDetailsMobilePhone" runat="server" CssClass="form-control" Text="tbDetailsMobilePhone"
                                                            MaxLength="38" />
                                                        <asp:RegularExpressionValidator ID="validatorMobilePhone" runat="server" ControlToValidate="tbDetailsMobilePhone"
                                                            SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[ \+\(\)\d]*$"
                                                            ErrorMessage="ValidationPhoneNumbers">  
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="revMobilePhone" runat="server" ControlToValidate="tbDetailsMobilePhone"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>

                                                    </div>
                                                </div>
                                                <div class="col-sm-4 col-xs-6 text-center">
                                                    <asp:Label ID="lbPreferMobilePhone" runat="server" AssociatedControlID="rbPreferMobilePhone">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral57" runat="server" SetLanguageCode="LabelPreferredLine" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <input name="preferredPhone" class="form-control btn-checkbox" type="radio" id="rbPreferMobilePhone"
                                                            placeholder="Prefered Line" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div id="personal-item-8" class="col-md-6">
                                            <asp:Label ID="lbDetailsAddress1" runat="server" AssociatedControlID="tbDetailsAddress1">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral58" runat="server" SetLanguageCode="LabelAddress" />
                                                1:</asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="tbDetailsAddress1" runat="server" CssClass="form-control" />
                                                <asp:RegularExpressionValidator ID="revAddress1" runat="server" ControlToValidate="tbDetailsAddress1"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div id="personal-item-9" class="col-md-6">
                                            <asp:Label ID="lbDetailsAddress2" runat="server" AssociatedControlID="tbDetailsAddress2">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral59" runat="server" SetLanguageCode="LabelAddress" />
                                                2:</asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="tbDetailsAddress2" runat="server" CssClass="form-control" />

                                                <asp:RegularExpressionValidator ID="revAddress2" runat="server" ControlToValidate="tbDetailsAddress2"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div id="personal-item-10" class="col-md-6">
                                                    <asp:Label ID="lbDetailsSuburb" runat="server" AssociatedControlID="tbDetailsSuburb">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral60" runat="server" SetLanguageCode="LabelCityTown" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <asp:TextBox ID="tbDetailsSuburb" runat="server" CssClass="form-control" />

                                                        <asp:RegularExpressionValidator ID="revSuburb" runat="server" ControlToValidate="tbDetailsSuburb"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div id="personal-item-11" class="col-md-6">
                                                    <asp:Label ID="lbDetailsState" runat="server" AssociatedControlID="tbDetailsState">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral62" runat="server" SetLanguageCode="LabelState" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <asp:TextBox ID="tbDetailsState" runat="server" CssClass="form-control" />

                                                        <asp:RegularExpressionValidator ID="revState" runat="server" ControlToValidate="tbDetailsState"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div id="personal-item-12" class="col-md-6">
                                                    <asp:Label ID="lbDetailsPostcode" runat="server" AssociatedControlID="tbDetailsPostcode">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral63" runat="server" SetLanguageCode="LabelPostcode" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <asp:TextBox ID="tbDetailsPostcode" runat="server" CssClass="form-control" />

                                                        <asp:RegularExpressionValidator ID="revPostcode" runat="server" ControlToValidate="tbDetailsPostcode"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div id="personal-item-13" class="col-md-6">
                                                    <asp:Label ID="lbDetailsCountry" runat="server" AssociatedControlID="ddlDetailsCountry">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral64" runat="server" SetLanguageCode="LabelCountry" />
                                                        :</asp:Label>
                                                    <div class="form-input">
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlDetailsCountry" runat="server" CssClass="form-dropdown form-control">
                                                                <asp:ListItem Selected="True" disabled="disabled">-ddlDetailsCountry-</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div id="personal-item-14" class="col-md-6">
                                            <asp:Label ID="lbDetailsVideoURL" runat="server" AssociatedControlID="tbDetailsVideoURL">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral265" runat="server" SetLanguageCode="LabelVideoURL" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="tbDetailsVideoURL" runat="server" CssClass="form-control" />

                                                <asp:RegularExpressionValidator ID="revVideoURL" runat="server" ControlToValidate="tbDetailsVideoURL"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div id="personal-item-15" class="col-md-3">
                                            <asp:Label ID="lbDetailsPassportNumber" runat="server" AssociatedControlID="tbDetailsPassportNumber">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral65" runat="server" SetLanguageCode="LabelPassportNumber" />
                                                :</asp:Label>
                                            <div class="form-input">
                                                <asp:TextBox ID="tbDetailsPassportNumber" runat="server" CssClass="form-control" />
                                                <asp:RegularExpressionValidator ID="revPassportNumber" runat="server" ControlToValidate="tbDetailsPassportNumber"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <p id="lb-personaldetailsMailingadd">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral66" runat="server" SetLanguageCode="LabelMailingAddress" />
                                        :</p>
                                    <div>
                                    </div>
                                    <a data-toggle="collapse" href="#mailingaddress-form" aria-expanded="false" aria-controls="mailingaddress-form"
                                        class="mailing-add-link collapsed">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral67" runat="server" SetLanguageCode="LabelMailingAddress" />
                                        <span class="caret_symbol"></span></a>
                                    <div class="collapse" id="mailingaddress-form">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:CheckBox ID="cbDetailsSameAsAbove" runat="server" />
                                                <asp:Label ID="lbDetailsSameAsAbove" runat="server" AssociatedControlID="cbDetailsSameAsAbove">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral68" runat="server" SetLanguageCode="LabelSameAsAbove" />
                                                </asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div id="personal-item-16" class="col-md-6">
                                                <asp:Label ID="lbDetailsMailingAddress1" runat="server" AssociatedControlID="tbDetailsMailingAddress1">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral69" runat="server" SetLanguageCode="LabelAddress" />
                                                    1:</asp:Label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbDetailsMailingAddress1" runat="server" CssClass="form-control"
                                                        placeholder="tbDetailsMailingAddress1" />
                                                        <asp:RegularExpressionValidator ID="revMailingAddress1" runat="server" ControlToValidate="tbDetailsMailingAddress1"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div id="personal-item-17" class="col-md-6">
                                                <asp:Label ID="lbDetailsMailingAddress2" runat="server" AssociatedControlID="tbDetailsMailingAddress2">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral70" runat="server" SetLanguageCode="LabelAddress" />
                                                    2:</asp:Label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbDetailsMailingAddress2" runat="server" CssClass="form-control"
                                                        placeholder="tbDetailsMailingAddress2" />
                                                        <asp:RegularExpressionValidator ID="revMailingAddress2" runat="server" ControlToValidate="tbDetailsMailingAddress2"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div id="personal-item-18" class="col-md-6">
                                                        <asp:Label ID="lbDetailsMailingSuburb" runat="server" AssociatedControlID="tbDetailsMailingSuburb">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral71" runat="server" SetLanguageCode="LabelCityTown" />
                                                            :</asp:Label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDetailsMailingSuburb" runat="server" CssClass="form-control" placeholder="tbDetailsMailingSuburb" />
                                                            <asp:RegularExpressionValidator ID="revMailingSuburb" runat="server" ControlToValidate="tbDetailsMailingSuburb"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div id="personal-item-19" class="col-md-6">
                                                        <asp:Label ID="lbDetailsMailingState" runat="server" AssociatedControlID="tbDetailsMailingState">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral73" runat="server" SetLanguageCode="LabelState" />
                                                            :</asp:Label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDetailsMailingState" runat="server" CssClass="form-control" placeholder="tbDetailsMailingState" />
                                                            <asp:RegularExpressionValidator ID="revMailingState" runat="server" ControlToValidate="tbDetailsMailingState"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div id="personal-item-20" class="col-md-6">
                                                        <asp:Label ID="lbDetailsMailingPostcode" runat="server" AssociatedControlID="tbDetailsMailingPostcode">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral74" runat="server" SetLanguageCode="LabelPostcode" />
                                                            :</asp:Label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDetailsMailingPostcode" runat="server" CssClass="form-control"
                                                                placeholder="tbDetailsMailingPostcode" />
                                                                <asp:RegularExpressionValidator ID="revMailingPostcode" runat="server" ControlToValidate="tbDetailsMailingPostcode"
                                                            SetFocusOnError="true" Display="Dynamic"
                                                            ErrorMessage="ValidateNoHTMLContent">
                                                        </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div id="personal-item-21" class="col-md-6">
                                                        <asp:Label ID="lbDetailsMailingCountry" runat="server" AssociatedControlID="ddlDetailsMailingCountry">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral75" runat="server" SetLanguageCode="LabelCountry" />
                                                            :</asp:Label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlDetailsMailingCountry" runat="server" CssClass="form-dropdown form-control">
                                                                    <asp:ListItem Selected="True" disabled="disabled">-ddlDetailsMailingCountry-</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="button-container">
                                        <asp:LinkButton ID="lbDetailsSave" runat="server" CssClass="btn btn-primary btn-sm"
                                            ValidationGroup="Details" OnClick="lbDetailsSave_Click">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral76" runat="server" SetLanguageCode="LabelSave" />
                                        </asp:LinkButton>
                                        <a href="#personalDetailsform" data-toggle="collapse" class="btn btn-primary btn-sm cancel-btn">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral78" runat="server" SetLanguageCode="LabelCancel" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- Section 10 & 11: Attach Rsume & Coverletter -->
                    <div class="row clearfix scroll-point" id="attach-container">
                        <!-- Section 10: Attach Resume  -->
                        <asp:PlaceHolder ID="phSectionResume" runat="server">
                            <asp:UpdatePanel ID="upResume" runat="server" UpdateMode="Conditional" class="col-md-6">
                                <ContentTemplate>
                                    <section class="form-section frm-sec-2" id="sec-AttachResume">
                                <header class="section-header">
                                    <div class="col-sm-8">
                                        <h2 class="section-title">
                                            <span class="fa fa-file-text-o">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleResume" runat="server" />
                                            <span id="resumeInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a  id="hfResume" runat="server" href="#newResume" class="btn btn-primary btn-sm add-btn"><span class="fa fa-plus">
                                            <!-- icon -->
                                        </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral196" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickResume" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:PlaceHolder ID="phAddEntryTextResume" runat="server">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25757554" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>    
                                <div class="section-content">
                                    <asp:Repeater ID="rptResume" runat="server" OnItemDataBound="rptResume_ItemDataBound"
                                        OnItemCommand="rptResume_ItemCommand">
                                        <HeaderTemplate>
                                            <ul class="edit-list">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><span class="text-nowrap">
                                                <asp:Literal ID="ltResumeFileName" runat="server" /></span>
                                                <div class="btn-group pull-left">
                                                    <asp:HyperLink ID="hlResumeDownload" runat="server" CssClass="fa fa-download" aria-hidden="true" />
                                                    <asp:LinkButton ID="lbResumeDelete" runat="server" CssClass="fa fa-trash fa-1" data-toggle="modal"
                                                        data-target="#deleteConfirm" CommandName="ResumeDelete" />
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="attach-editform-container visible-xs visible-sm hidden-md hidden-lg"
                                    id="resume_container">
                                    <div class="form-all">
                                    </div>
                                </div>
                                <footer class="section-footer">
                                    <a href="#newResume" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral197" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </section>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:PlaceHolder>
                        <!-- Section 11: Attach Coverletter  -->
                        <asp:PlaceHolder ID="phSectionCoverLetter" runat="server">
                            <asp:UpdatePanel ID="upCoverLetter" runat="server" UpdateMode="Conditional" class="col-md-6">
                                <ContentTemplate>
                                    <section class="form-section frm-sec-2" id="sec-AttachCoverletter">
                                <header class="section-header">
                                    <div class="col-sm-8">
                                        <h2 class="section-title">
                                            <span class="fa fa-file-text-o">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleCoverLetter" runat="server" />
                                            <span id="coverLetterInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a id="hfCoverLetter" runat="server" href="#newCoverletter" class="btn btn-primary btn-sm add-btn"><span class="fa fa-plus">
                                            <!-- icon -->
                                        </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral199" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickCoverLetter" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:PlaceHolder ID="phAddEntryTextCoverletter" runat="server">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2446" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>                                    
                                <div class="section-content">
                                    <asp:Repeater ID="rptCoverLetter" runat="server" OnItemDataBound="rptCoverLetter_ItemDataBound"
                                        OnItemCommand="rptCoverLetter_ItemCommand">
                                        <HeaderTemplate>
                                            <ul class="edit-list">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><span class="text-nowrap">
                                                <asp:Literal ID="ltCoverLetterFileName" runat="server" /></span>
                                                <div class="btn-group pull-left">
                                                    <asp:HyperLink ID="hlCoverLetterDownload" runat="server" CssClass="fa fa-download"
                                                        aria-hidden="true" />
                                                    <asp:LinkButton ID="lbCoverLetterDelete" runat="server" CssClass="fa fa-trash fa-1"
                                                        data-toggle="modal" data-target="#deleteConfirm" CommandName="CoverLetterDelete" />
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                                <footer class="section-footer">
                                    <a href="#newCoverletter" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral200" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </section>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:PlaceHolder>
                        <div class="attach-editform-container col-xs-12" id="attach_forms">
                            <div class="form-all">
                                <!-- Edit form section  -->
                                <div class="form-section full-width" id="cover_letter_wrap">
                                    <div class="section-content new-block-holder edit-mode hidden">
                                        <div class="profile-edit collapse" id="newCoverletter" runat="server" clientidmode="Static">
                                            <h2 class="form-title">
                                                <asp:Literal ID="ucAttachCoverLetter" runat="server" />
                                            </h2>
                                            <div class="row">
                                                <div class="col-sm-6 col-xs-12">
                                                    <asp:Label ID="Label88" runat="server" AssociatedControlID="tbCoverLetterTitle">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral202" runat="server" SetLanguageCode="LabelTitle" />
                                                        <span class="form-required">*</span>:</asp:Label>
                                                    <div class="form-input">
                                                        <asp:TextBox ID="tbCoverLetterTitle" runat="server" CssClass="form-control" placeholder="tbCoverLetterTitle" />
                                                    </div>
                                                    <asp:PlaceHolder ID="phCoverLetterTitleError" runat="server" Visible="false"><span
                                                        class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorCoverLetterTitle" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                                </div>
                                            </div>
                                            <a href="#newCoverletter" data-toggle="collapse" class="fa fa-times close-btn">
                                                <!-- close -->
                                            </a>
                                            <div class="form-line">
                                                <asp:Label ID="Label89" runat="server" AssociatedControlID="rbCoverLetterUpload">
                                                    <input type="radio" id="rbCoverLetterUpload" runat="server" name="CoverLetter" checked /><JXTControl:ucLanguageLiteral
                                                        ID="UcLanguageLiteral43" runat="server" SetLanguageCode="LabelUploadCoverLetter" />
                                                    :</asp:Label>
                                                <div class="form-input custom-fileUpload">
                                                    <asp:Label ID="Label90" runat="server" AssociatedControlID="fuCoverLetter"><span
                                                        class="upload-lbl btn btn-primary btn-sm">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral204" runat="server" SetLanguageCode="LabelUploadFile" />
                                                    </span>
                                                        <asp:FileUpload ID="fuCoverLetter" runat="server" CssClass="form-control" />
                                                    </asp:Label>
                                                    &nbsp;&nbsp;<p>
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral205" runat="server" SetLanguageCode="LabelFileName" />
                                                        : <span class="filename-holder">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral206" runat="server" SetLanguageCode="LabelNoFileChosen" />
                                                        </span>
                                                    </p>
                                                    <span class="help-block">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25" runat="server" SetLanguageCode="LabelUploadCoverDesc" />
                                                    </span>
                                                    <asp:PlaceHolder ID="phCoverLetterError" runat="server" Visible="false"><span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ucCoverLetterError" runat="server" SetLanguageCode="LabelUploadProfileImageInvalid" />
                                                    </span></asp:PlaceHolder>
                                                </div>
                                            </div>
                                            <div class="or-separator">
                                                <span>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral207" runat="server" SetLanguageCode="LabelOr" />
                                                </span>
                                            </div>
                                            <asp:Label ID="Label91" runat="server" AssociatedControlID="rbCoverLetterWriteYourOwn">
                                                <input type="radio" id="rbCoverLetterWriteYourOwn" runat="server" name="CoverLetter" /><JXTControl:ucLanguageLiteral
                                                    ID="UcLanguageLiteral44" runat="server" SetLanguageCode="LabelCoverLetterWriteYourOwn" />
                                                :</asp:Label>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <asp:Label ID="Label92" runat="server" AssociatedControlID="tbCustomCoverLetter">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral209" runat="server" SetLanguageCode="LabelCustomCoverLetter" />
                                                        <span class="form-required">*</span>:</asp:Label>
                                                    <div class="form-input">
                                                        <asp:TextBox ID="tbCustomCoverLetter" runat="server" TextMode="MultiLine" CssClass="form-control"
                                                            Rows="5" Columns="5" placeholder="tbCustomCoverLetter" />
                                                    </div>
                                                    <asp:PlaceHolder ID="phCustomCoverLetterError" runat="server" Visible="false"><span
                                                        class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral281" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                                </div>
                                            </div>
                                            <!-- Save buttton  -->
                                            <div class="form-input-wide">
                                                <div class="form-buttons-wrapper">
                                                    <asp:LinkButton ID="lbCoverLetterSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        OnClick="lbCoverLetterSave_Click" ValidationGroup="Coverletter">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral210" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a href="#newCoverletter" class="btn btn-primary cancel-btn btn-sm" data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral212" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- //profile-edit -->
                                    </div>
                                </div>
                                <!-- //form-section -->
                                <div class="form-section full-width" id="resume_wrap">
                                    <div class="section-content new-block-holder edit-mode hidden">
                                        <div class="profile-edit collapse" id="newResume" runat="server" clientidmode="Static">
                                            <h2 class="form-title">
                                                <asp:Literal ID="ucAttachResume" runat="server" />
                                            </h2>
                                            <a href="#newResume" data-toggle="collapse" class="fa fa-times close-btn">
                                                <!-- close -->
                                            </a>
                                            <div class="form-line">
                                                <div class="form-input custom-fileUpload">
                                                    <asp:Label ID="Label93" runat="server" AssociatedControlID="fuResume"><span class="upload-lbl btn btn-primary btn-sm">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral215" runat="server" SetLanguageCode="LabelUploadFile" />
                                                    </span>
                                                        <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control" />
                                                    </asp:Label>
                                                    &nbsp;&nbsp;<p>
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral216" runat="server" SetLanguageCode="LabelFileName" />
                                                        : <span class="filename-holder">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral217" runat="server" SetLanguageCode="LabelNoFileChosen" />
                                                        </span>
                                                    </p>
                                                    <span class="help-block">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24" runat="server" SetLanguageCode="LabelUploadCoverDesc" />
                                                    </span>
                                                    <asp:PlaceHolder ID="phResumeError" runat="server" Visible="false"><span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ucResumeError" runat="server" SetLanguageCode="LabelUploadProfileImageInvalid" />
                                                    </span></asp:PlaceHolder>
                                                </div>
                                            </div>
                                            <!-- Save buttton  -->
                                            <div class="form-input-wide">
                                                <div class="form-buttons-wrapper">
                                                    <asp:LinkButton ID="lbResumeSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        OnClick="lbResumeSave_Click" ValidationGroup="Resume">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral211" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a href="#newResume" class="btn btn-primary cancel-btn btn-sm" data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral218" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- //profile-edit -->
                                    </div>
                                </div>
                                <!-- //form-section -->
                            </div>
                        </div>
                    </div>
                    <!-- //Section 2: Summary And Personal Details ........ ends -->
                    <!-- Section 15: Directorship  -->
                    <!-- Backend need to generate id name according to the section name -->
                    <asp:PlaceHolder ID="phSectionDirectorship" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-15">

                        <asp:UpdatePanel ID="upDirectorship" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-8">
                                        <h2 class="section-title">
                                            <span class="fa fa-user">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleDirectorship" runat="server" />
                                            <span id="directorshipInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a href="#newDirectorshipExperience" class="btn btn-primary btn-sm add-btn" id="hfDirectorshipAdd"
                                            runat="server"><span class="fa fa-plus">
                                                <!-- icon -->
                                            </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral242" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickDirectorship" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:Placeholder runat="server" ID="phAddEntryTextDirectorship">
                                    <p class="empty-case_field text-center">Add an entry</p>
                                </asp:PlaceHolder>
                                <asp:Repeater ID="rptDirectorship" runat="server" OnItemDataBound="rptDirectorship_ItemDataBound"
                                    OnItemCommand="rptDirectorship_ItemCommand">
                                    <ItemTemplate>
                                        <article id="acDirectorship" runat="server" class="section-content" itemscope itemtype="http://schema.org/Person">
                                            <div class="editable-section">
                                                <header class="section-body-header">
                                                    <div class="exp-title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltDirectorshipCompanyName" runat="server" /></h4>
                                                        <a id="aDirectorshipEdit" runat="server" class="fa fa-edit" data-toggle="collapse">
                                                            <!-- icon -->
                                                        </a>
                                                        <asp:LinkButton ID="lbDirectorshipDelete" runat="server" CssClass="fa fa-trash fa-1"
                                                            data-toggle="modal" data-target="#deleteConfirm" CommandName="DirectorshipDelete" />
                                                        
                                                    </div>
                                                    <h3 itemprop="jobTitle">
                                                        <asp:Literal ID="ltDirectorshipJobTitle" runat="server" Text="ltDirectorshipJobTitle" /></h3>
                                                    <asp:Literal ID="ltDirectorshipWebsite" runat="server" />
                                                    <%--<h4 class="director-website">
                                                        <asp:HyperLink ID="hlDirectorshipWebsite" runat="server" Target="_blank" ></asp:HyperLink></h4>--%>
                                                    <div class="experience-date-locale">
                                                        <asp:Literal ID="ltDirectorshipDateTime" runat="server" />
                                                    </div>
                                                </header>
                                                <div class="section-entry">
                                                    <div class="body-field field description">
                                                        <p>
                                                            <asp:Literal ID="ltDirectorshipDescription" runat="server" /></p>
                                                        <p class="note">
                                                            <strong>
                                                                <asp:Literal ID="ltDirectorshipResponsibilities" runat="server" /></strong></p>
                                                        <p>
                                                            <asp:Literal ID="ltDirectorshipTypes" runat="server" /></p>
                                                        <p>
                                                            <asp:Literal ID="ltDirectorshipAdditionalRoles" runat="server" /></p>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Edit form section  -->
                                            <div class="profile-edit collapse" id="edit-DirectorshipExperience<%# Container.ItemIndex + 1 %>">
                                                <h2 class="form-title">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral243" runat="server" SetLanguageCode="LabelEditEntry" />
                                                </h2>
                                                <a href="#edit-DirectorshipExperience<%# Container.ItemIndex + 1 %>" data-toggle="collapse"
                                                    class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label ID="lbDirectorshipJobTitle" runat="server" AssociatedControlID="tbDirectorshipJobTitle">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral245" runat="server" SetLanguageCode="LabelJobTitle" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDirectorshipJobTitle" runat="server" CssClass="form-control" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phDirectorshipJobTitleError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorDirectorshipJobTitle" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="lbDirectorshipCompanyName" runat="server" AssociatedControlID="tbDirectorshipCompanyName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral244" runat="server" SetLanguageCode="LabelOrganisationName" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDirectorshipCompanyName" runat="server" CssClass="form-control" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phDirectorshipCompanyNameError" runat="server" Visible="false">
                                                            <span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ltErrorDirectorshipCompanyName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="lbDirectorshipWebsite" runat="server" AssociatedControlID="tbDirectorshipWebsite">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral246" runat="server" SetLanguageCode="LabelOrganisationWebsite" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDirectorshipWebsite" runat="server" CssClass="form-control" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phDirectorshipWebsiteError" runat="server" Visible="false">
                                                            <span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ltErrorDirectorshipWebsite" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row date_wrap">
                                                    <div class="col-sm-6 col-xs-12 group-controls">
                                                        <asp:label ID="lbDirectorshipStartMonth" runat="server" AssociatedControlID="ddlDirectorshipStartMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral247" runat="server" SetLanguageCode="LabelStart" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlDirectorshipStartMonth" runat="server" CssClass="form-control" />
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlDirectorshipStartYear" runat="server" CssClass="form-control" />
                                                        </span><span>
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral248" runat="server" SetLanguageCode="LabelTo" />
                                                        </span>
                                                    </div>
                                                    <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                        <asp:label id="lbDirectorshipEndMonth" runat="server" AssociatedControlID="ddlDirectorshipEndMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral249" runat="server" SetLanguageCode="LabelEnd" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlDirectorshipEndMonth" runat="server" CssClass="form-control" />
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlDirectorshipEndYear" runat="server" CssClass="form-control" />
                                                        </span>
                                                        <asp:PlaceHolder ID="phDirectorshipEndError" runat="server" Visible="false"><span
                                                            class="error-message-2">
                                                            <JXTControl:ucLanguageLiteral ID="ucDirectorshipEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-1 col-xs-12">
                                                        <asp:label ID="lbDirectorshipCurrent" runat="server" AssociatedControlID="cbDirectorshipCurrent">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral250" runat="server" SetLanguageCode="LabelCurrent" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <input id="cbDirectorshipCurrent" runat="server" type="checkbox" class="form-control btn-checkbox current-date" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <asp:label id="lbDirectorshipSummary" runat="server" AssociatedControlID="tbDirectorshipSummary">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral251" runat="server" SetLanguageCode="LabelSummary" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDirectorshipSummary" runat="server" TextMode="MultiLine" Rows="5"
                                                                Columns="5" CssClass="form-control" placeholder="Directorship summary" />
                                                            <asp:PlaceHolder ID="phDirectorshipSummaryError" runat="server" Visible="false">
                                                            <span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ltErrorDirectorshipSummary" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                            </span></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <asp:label id="lbDirectorshipResponsibilities" runat="server" AssociatedControlID="tbDirectorshipResponsibilities">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral252" runat="server" SetLanguageCode="LabelResponsibilitiesAndAchievements" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbDirectorshipResponsibilities" runat="server" TextMode="MultiLine"
                                                                Rows="5" Columns="5" CssClass="form-control" placeholder="Responsibilities and achievements" />
                                                            <asp:PlaceHolder ID="phDirectorshipResponsibilitiesError" runat="server" Visible="false">
                                                                <span class="error-message">
                                                                    <JXTControl:ucLanguageLiteral ID="ltErrorDirectorshipResponsibilities" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                                </span>
                                                            </asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-3 col-xs-12">
                                                        <asp:label id="lbDirectorshipType" runat="server" AssociatedControlID="ddlDirectorshipType">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral253" runat="server" SetLanguageCode="LabelTypeOfDirectorship" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlDirectorshipType" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="chair" Text="Chair" />
                                                                    <asp:ListItem Value="nonexecutiveDirector" Text="Non-executive Director" />
                                                                    <asp:ListItem Value="executivedirector" Text="Executive Director" />
                                                                    <asp:ListItem Value="managingdirector" Text="Managing Director" />
                                                                    <asp:ListItem Value="other" Text="Other" />
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                                <label><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral254" runat="server" SetLanguageCode="LabelAdditionalRolesAndResponsibilities" /></label>
                                                        <div class="form-input">
                                                            <asp:label id="lbDirectorshipAuditCommittee" runat="server" AssociatedControlID="cbDirectorshipAuditCommittee">
                                                                <input type="checkbox" id="cbDirectorshipAuditCommittee" runat="server" class="form-control" /><JXTControl:ucLanguageLiteral
                                                                    ID="UcLanguageLiteral255" runat="server" SetLanguageCode="cbAuditCommittee" />
                                                            </asp:label>
                                                            <asp:label id="Label1" runat="server" AssociatedControlID="cbDirectorshipRiskCommittee">
                                                                <input type="checkbox" id="cbDirectorshipRiskCommittee" runat="server" class="form-control" /><JXTControl:ucLanguageLiteral
                                                                    ID="UcLanguageLiteral256" runat="server" SetLanguageCode="cbRiskCommittee" />
                                                            </asp:label>
                                                            <asp:label id="Label2" runat="server" AssociatedControlID="cbDirectorshipNominationsCommittee">
                                                                <input type="checkbox" id="cbDirectorshipNominationsCommittee" runat="server" class="form-control" /><JXTControl:ucLanguageLiteral
                                                                    ID="UcLanguageLiteral257" runat="server" SetLanguageCode="cbNominationsCommittee" />
                                                            </asp:label>
                                                            <asp:label id="Label3" runat="server" AssociatedControlID="cbDirectorshipRemunerationCommittee">
                                                                <input type="checkbox" id="cbDirectorshipRemunerationCommittee" runat="server" class="form-control" /><JXTControl:ucLanguageLiteral
                                                                    ID="UcLanguageLiteral258" runat="server" SetLanguageCode="cbRemunerationCommittee" />
                                                            </asp:label>
                                                            <asp:label id="Label4" runat="server" AssociatedControlID="cbDirectorshipOHSCommittee">
                                                                <input type="checkbox" id="cbDirectorshipOHSCommittee" runat="server" class="form-control" /><JXTControl:ucLanguageLiteral
                                                                    ID="UcLanguageLiteral259" runat="server" SetLanguageCode="cbOHSCommittee" />
                                                            </asp:label>
                                                            <asp:label id="Label5" runat="server" AssociatedControlID="cbDirectorshipOther">
                                                                <input type="checkbox" id="cbDirectorshipOther" runat="server" class="form-control" /><JXTControl:ucLanguageLiteral
                                                                    ID="UcLanguageLiteral260" runat="server" SetLanguageCode="cbOther" />
                                                            </asp:label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="button-container">
                                                    <asp:LinkButton ID="lbDirectorshipSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        ValidationGroup="Directorship">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral261" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a class="btn btn-primary cancel-btn btn-sm" href="#edit-DirectorshipExperience<%# Container.ItemIndex + 1 %>"
                                                        data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral262" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <article id="acDirectorshipAdd" runat="server" class="section-content new-block-holder edit-mode hidden" itemscope itemtype="http://schema.org/Person">
                                    <div class="profile-edit collapse" id="newDirectorshipExperience" runat="server" clientidmode="Static">
                                        <h2 class="form-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral271" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </h2>
                                        <a href="#newDirectorshipExperience" data-toggle="collapse" class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="lbDirectorshipAddJobTitle" runat="server" AssociatedControlID="tbDirectorshipAddJobTitle">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral245" runat="server" SetLanguageCode="LabelJobTitle" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbDirectorshipAddJobTitle" runat="server" CssClass="form-control" />
                                                </div>
                                                <asp:PlaceHolder ID="phDirectorshipAddJobTitleError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddDirectorshipJobTitle" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label6" runat="server" AssociatedControlID="tbDirectorshipAddCompanyName">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27555744" runat="server" SetLanguageCode="LabelOrganisationName" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbDirectorshipAddCompanyName" runat="server" CssClass="form-control" />
                                                </div>
                                                <asp:PlaceHolder ID="phDirectorshipAddCompanyNameError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddDirectorshipCompanyName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label7" runat="server" AssociatedControlID="tbDirectorshipAddWebsite">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral246" runat="server" SetLanguageCode="LabelOrganisationWebsite" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbDirectorshipAddWebsite" runat="server" CssClass="form-control" />
                                                </div>
                                                <asp:PlaceHolder ID="phDirectorshipAddWebsiteError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddDirectorshipWebsite" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row date_wrap">
                                            <div class="col-sm-6 col-xs-12 group-controls">
                                                <asp:label id="Label8" runat="server" AssociatedControlID="ddlDirectorshipAddStartMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral247" runat="server" SetLanguageCode="LabelStart" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlDirectorshipAddStartMonth" runat="server" CssClass="form-control" />
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlDirectorshipAddStartYear" runat="server" CssClass="form-control" />
                                                </span><span>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral248" runat="server" SetLanguageCode="LabelTo" />
                                                </span>
                                            </div>
                                            <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                <asp:label id="Label9" runat="server" AssociatedControlID="ddlDirectorshipAddEndMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral249" runat="server" SetLanguageCode="LabelEnd" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlDirectorshipAddEndMonth" runat="server" CssClass="form-control" />
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlDirectorshipAddEndYear" runat="server" CssClass="form-control" />
                                                </span>
                                                <asp:PlaceHolder ID="phDirectorshipAddEndError" runat="server" Visible="false"><span
                                                    class="error-message-2">
                                                    <JXTControl:ucLanguageLiteral ID="ucDirectorshipAddEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-1 col-xs-12">
                                                <asp:label id="Label10" runat="server" AssociatedControlID="cbDirectorshipAddCurrent">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral250" runat="server" SetLanguageCode="LabelCurrent" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <input id="cbDirectorshipAddCurrent" runat="server" type="checkbox" class="form-control btn-checkbox current-date" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <asp:label id="Label11" runat="server" AssociatedControlID="tbDirectorshipAddSummary">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral251" runat="server" SetLanguageCode="LabelSummary" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbDirectorshipAddSummary" runat="server" TextMode="MultiLine" Rows="5"
                                                        Columns="5" CssClass="form-control" placeholder="Directorship summary" />
                                                </div>
                                                <asp:PlaceHolder ID="phDirectorshipAddSummaryError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddDirectorshipSummary" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <asp:label id="Label12" runat="server" AssociatedControlID="tbDirectorshipAddResponsibilities">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral252" runat="server" SetLanguageCode="LabelResponsibilitiesAndAchievements" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbDirectorshipAddResponsibilities" runat="server" TextMode="MultiLine"
                                                        Rows="5" Columns="5" CssClass="form-control" placeholder="Responsibilities and achievements" />
                                                </div>
                                                <asp:PlaceHolder ID="phDirectorshipAddResponsibilitiesError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddDirectorshipResponsibilities" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3 col-xs-12">
                                                 <asp:label id="Label13" runat="server" AssociatedControlID="ddlDirectorshipAddType">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral253" runat="server" SetLanguageCode="LabelTypeOfDirectorship" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlDirectorshipAddType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="chair" Text="Chair" />
                                                            <asp:ListItem Value="nonexecutiveDirector" Text="Non-executive Director" />
                                                            <asp:ListItem Value="executivedirector" Text="Executive Director" />
                                                            <asp:ListItem Value="managingdirector" Text="Managing Director" />
                                                            <asp:ListItem Value="other" Text="Other" />
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <label>
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelAdditionalRolesAndResponsibilities" />
                                                        :</label>
                                                <div class="form-input">
                                                    <asp:label id="Label14" runat="server" AssociatedControlID="cbDirectorshipAddAuditCommittee">
                                                        <input type="checkbox" id="cbDirectorshipAddAuditCommittee" runat="server" class="form-control" /><JXTControl:ucLanguageLiteral
                                                            ID="UcLanguageLiteral1" runat="server" SetLanguageCode="cbAuditCommittee" />
                                                    </asp:label>
                                                   <asp:label id="Label15" runat="server" AssociatedControlID="cbDirectorshipAddRiskCommittee">
                                                   <input type="checkbox" id="cbDirectorshipAddRiskCommittee" runat="server" class="form-control"><JXTControl:ucLanguageLiteral
                                                            ID="UcLanguageLiteral2" runat="server" SetLanguageCode="cbRiskCommittee" />
                                                    </asp:label>
                                                    <asp:label id="Label16" runat="server" AssociatedControlID="cbDirectorshipAddNominationsCommittee">
                                                        <input type="checkbox" id="cbDirectorshipAddNominationsCommittee" runat="server"
                                                            class="form-control"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server"
                                                                SetLanguageCode="cbNominationsCommittee" />
                                                    </asp:label>
                                                   <asp:label id="Label17" runat="server" AssociatedControlID="cbDirectorshipAddRemunerationCommittee">
                                                   <input type="checkbox" id="cbDirectorshipAddRemunerationCommittee" runat="server"
                                                            class="form-control"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral258" runat="server"
                                                                SetLanguageCode="cbRemunerationCommittee" />
                                                    </asp:label>
                                                    <asp:label id="Label18" runat="server" AssociatedControlID="cbDirectorshipAddOHSCommittee">
                                                    <input type="checkbox" id="cbDirectorshipAddOHSCommittee" runat="server" class="form-control"><JXTControl:ucLanguageLiteral
                                                            ID="UcLanguageLiteral15" runat="server" SetLanguageCode="cbOHSCommittee" />
                                                    </asp:label>
                                                    <asp:label id="Label19" runat="server" AssociatedControlID="cbDirectorshipAddOther">
                                                        <input type="checkbox" id="cbDirectorshipAddOther" runat="server" class="form-control"><JXTControl:ucLanguageLiteral
                                                            ID="UcLanguageLiteral16" runat="server" SetLanguageCode="cbOther" />
                                                    </asp:label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="button-container">
                                            <asp:LinkButton ID="lbDirectorshipAddSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                ValidationGroup="DirectorshipAdd" OnClick="lbDirectorshipAddSave_Click">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral261" runat="server" SetLanguageCode="LabelSave" />
                                            </asp:LinkButton>
                                            <a class="btn btn-primary cancel-btn btn-sm" href="#edit-DirectorshipExperience1"
                                                data-toggle="collapse">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral262" runat="server" SetLanguageCode="LabelCancel" />
                                            </a>
                                        </div>
                                    </div>
                                </article>
                                <footer class="section-footer">
                                    <a href="#newDirectorshipExperience" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral263" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 4: Experience  -->
                    <asp:PlaceHolder ID="phSectionExperience" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-4">
                        <asp:UpdatePanel ID="upexperience" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-8">
                                        <h2 class="section-title">
                                            <span class="fa fa-briefcase">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleExperience" runat="server" />
                                            <span id="experienceInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                        <span><asp:Literal ID="ltExperienceMin" runat="server" /></span>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a href="#newExperience" class="btn btn-primary btn-sm add-btn" id="hfExperienceAdd"
                                            runat="server"><span class="fa fa-plus">
                                                <!-- icon -->
                                            </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral79" runat="server" SetLanguageCode="LabelAdd" /></a>
                                        <asp:PlaceHolder ID="phTickWorkExperience" runat="server" Visible="false">
                                            <span class="fa fa-check section_status" aria-hidden="true"></span>
                                        </asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:Placeholder runat="server" ID="phAddEntryTextExperience">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2456" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>

                                <asp:Repeater ID="rptExperience" runat="server" OnItemDataBound="rptExperience_ItemDataBound"
                                    OnItemCommand="rptExperience_ItemCommand">
                                    <ItemTemplate>
                                        <article id="acExperience" runat="server" class="section-content">
                                            <div class="editable-section">
                                                <header class="section-body-header">
                                                    <div class="title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltExperienceJobTitle" runat="server" Text="ltExperienceJobTitle" /></h4>
                                                        <a id="aExperienceEdit" runat="server" class="fa fa-edit fa-0" data-toggle="collapse">
                                                            <!-- icon -->
                                                        </a>
                                                        <asp:LinkButton ID="lbExperienceDelete" runat="server" CssClass="fa fa-trash fa-1" data-toggle="modal" data-target="#deleteConfirm" CommandName="ExperienceDelete" />
                                                    </div>
                                                    <asp:Literal ID="ltExperienceCompanyNameAndLocation" runat="server" Text="ltExperienceCompanyNameAndLocation" />
                                                    <div class="date-field">
                                                        <asp:Literal ID="ltExperienceDate" runat="server" Text="ltExperienceDate" />
                                                    </div>
                                                </header>
                                                <div class="section-entry">
                                                    <div class="body-field field description">
                                                        <p>
                                                            <asp:Literal ID="ltExperienceDescription" runat="server" Text="ltExperienceDescription" />
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Edit form section  -->
                                            <div class="profile-edit collapse" id="edit-Experience<%# Container.ItemIndex + 1 %>">
                                                <h2 class="form-title">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral80" runat="server" SetLanguageCode="LabelEditEntry" />
                                                </h2>
                                                <a href="#edit-Experience<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label20" runat="server" AssociatedControlID="tbExperienceCompanyName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral81" runat="server" SetLanguageCode="LabelCompanyName" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbExperienceCompanyName" runat="server" PlaceHolder="tbExperienceCompanyName" CssClass="form-control" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phExperienceCompanyNameError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorExperienceCompanyName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label21" runat="server" AssociatedControlID="tbExperienceJobTitle">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral82" runat="server" SetLanguageCode="LabelJobTitle" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbExperienceJobTitle" runat="server" PlaceHolder="tbExperienceJobTitle" CssClass="form-control" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phExperienceJobTitleError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorExperienceJobTitle" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-4 col-xs-12">
                                                        <asp:label id="Label23" runat="server" AssociatedControlID="tbExperienceCity">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral84" runat="server" SetLanguageCode="LabelCityTown" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbExperienceCity" runat="server" PlaceHolder="tbExperienceCity"
                                                                CssClass="form-control" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phExperienceCityError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorExperienceCity" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                            </span>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <asp:label id="Label107" runat="server" AssociatedControlID="tbExperienceState">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27" runat="server" SetLanguageCode="LabelState" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbExperienceState" runat="server" PlaceHolder="LabelState" CssClass="form-control" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phExperienceStateError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorExperienceState" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                            </span>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <asp:label id="Label22" runat="server" AssociatedControlID="ddlExperienceCountry">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral83" runat="server" SetLanguageCode="LabelCountry" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlExperienceCountry" runat="server" CssClass="form-control">
                                                                    <asp:ListItem disabled="disabled" Selected="True" Value="0">-- ddlExperienceCountry --</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
  
                                                </div>
                                                <div class="row date_wrap">
                                                    <div class="col-sm-6 col-xs-12 group-controls">
                                                        <asp:label id="Label24" runat="server" AssociatedControlID="ddlExperienceStartMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral85" runat="server" SetLanguageCode="LabelStart" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlExperienceStartMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperienceStartMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlExperienceStartYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperienceStartYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span>
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral86" runat="server" SetLanguageCode="LabelTo" />
                                                        </span>
                                                    </div>
                                                    <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                        <asp:label id="Label25" runat="server" AssociatedControlID="ddlExperienceEndMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral87" runat="server" SetLanguageCode="LabelEnd" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlExperienceEndMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperienceEndMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlExperienceEndYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperiencEndYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                        <asp:PlaceHolder ID="phExperienceEndError" runat="server" Visible="false"><span class="error-message-2">
                                                            <JXTControl:ucLanguageLiteral ID="ucExperienceEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-1 col-xs-12">
                                                        <asp:label id="Label26" runat="server" AssociatedControlID="cbExperienceCurrent">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral88" runat="server" SetLanguageCode="LabelCurrent" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <input id="cbExperienceCurrent" runat="server" type="checkbox" class="form-control btn-checkbox current-date" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                       <asp:label id="Label27" runat="server" AssociatedControlID="tbExperienceDescription">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral89" runat="server" SetLanguageCode="LabelDescription" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbExperienceDescription" runat="server" Rows="5" Columns="5" TextMode="MultiLine"
                                                                CssClass="form-control" placeholder="tbExperienceDescription" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phExperienceDescriptionError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorExperienceDescription" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                            </span>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="button-container">
                                                    <asp:LinkButton ID="lbExperienceSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        ValidationGroup="Experience">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral91" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a href="#edit-Experience<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="btn btn-primary cancel-btn btn-sm">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral90" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <article id="acExperienceAdd" runat="server" class="section-content new-block-holder edit-mode hidden">
                                    <div class="profile-edit collapse" id="newExperience" runat="server" clientidmode="Static">
                                        <h2 class="form-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral92" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </h2>
                                        <a href="#newExperience" data-toggle="collapse" class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label28" runat="server" AssociatedControlID="tbExperienceAddCompanyName">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral93" runat="server" SetLanguageCode="LabelCompanyName" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbExperienceAddCompanyName" runat="server" PlaceHolder="tbExperienceAddCompanyName" CssClass="form-control" />
                                                </div>
                                                <asp:PlaceHolder ID="phExperienceAddCompanyNameError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddExperienceCompanyName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                  <asp:label id="Label29" runat="server" AssociatedControlID="tbExperienceAddJobTitle">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral94" runat="server" SetLanguageCode="LabelJobTitle" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbExperienceAddJobTitle" runat="server" PlaceHolder="tbExperienceAddJobTitle" CssClass="form-control" />
                                                </div>
                                                <asp:PlaceHolder ID="phExperienceAddJobTitleError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddExperienceJobTitle" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4 col-xs-12">
                                                <asp:label id="Label108" runat="server" AssociatedControlID="tbExperienceAddCity">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral31" runat="server" SetLanguageCode="LabelCityTown" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbExperienceAddCity" runat="server" PlaceHolder="LabelCityTown" CssClass="form-control" />
                                                </div>
                                                <asp:PlaceHolder ID="phExperienceAddCityError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddExperienceCity" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span>
                                                </asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-4 col-xs-12">
                                                <asp:label id="Label31" runat="server" AssociatedControlID="tbExperienceAddState">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral96" runat="server" SetLanguageCode="LabelState" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbExperienceAddState" runat="server" PlaceHolder="LabelState" CssClass="form-control" />
                                                </div>
                                                <asp:PlaceHolder ID="phExperienceAddStateError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddExperienceState" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span>
                                                </asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-4 col-xs-12">
                                                <asp:label id="Label30" runat="server" AssociatedControlID="ddlExperienceAddCountry">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral95" runat="server" SetLanguageCode="LabelCountry" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlExperienceAddCountry" runat="server" CssClass="form-control">
                                                            <asp:ListItem disabled="disabled" Selected="True" Value="0">-- ddlExperienceAddCountry --</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row date_wrap">
                                            <div class="col-sm-6 col-xs-12 group-controls">
                                                <asp:label id="Label32" runat="server" AssociatedControlID="ddlExperienceAddStartMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral97" runat="server" SetLanguageCode="LabelStart" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlExperienceAddStartMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperienceAddStartMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlExperienceAddStartYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperienceAddStartYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral98" runat="server" SetLanguageCode="LabelTo" />
                                                </span>
                                            </div>
                                            <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                <asp:label id="Label33" runat="server" AssociatedControlID="ddlExperienceAddEndMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral99" runat="server" SetLanguageCode="LabelEnd" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlExperienceAddEndMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperienceAddEndMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlExperienceAddEndYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlExperienceAddEndYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                                <asp:PlaceHolder ID="phExperienceAddEndError" runat="server" Visible="false"><span
                                                    class="error-message-2">
                                                    <JXTControl:ucLanguageLiteral ID="ucExperienceAddEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-1 col-xs-12">
                                                <asp:label id="Label34" runat="server" AssociatedControlID="cbExperienceAddCurrent">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral100" runat="server" SetLanguageCode="LabelCurrent" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <input id="cbExperienceAddCurrent" runat="server" type="checkbox" class="form-control btn-checkbox current-date" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <asp:label id="Label35" runat="server" AssociatedControlID="tbExperienceAddDescription">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral101" runat="server" SetLanguageCode="LabelDescription" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbExperienceAddDescription" runat="server" Rows="5" Columns="5"
                                                        TextMode="MultiLine" CssClass="form-control" placeholder="tbExperienceAddDescription" />
                                                </div>
                                                <asp:PlaceHolder ID="phExperienceAddDescriptionError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddExperienceDescription" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span>
                                                </asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="button-container">
                                            <asp:LinkButton ID="lbExperienceAddSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                ValidationGroup="ExperienceAdd" OnClick="lbExperienceAddSave_Click">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral102" runat="server" SetLanguageCode="LabelSave" />
                                            </asp:LinkButton>
                                            <a href="#newExperience" data-toggle="collapse" class="btn btn-primary cancel-btn btn-sm">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral103" runat="server" SetLanguageCode="LabelCancel" />
                                            </a>
                                        </div>
                                    </div>
                                </article>
                                <footer class="section-footer">
                                    <a href="#newExperience" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral104" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 5: Educational Qualification -->
                    <asp:PlaceHolder ID="phSectionEducation" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-5">
                        <asp:UpdatePanel ID="upEducation" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-8">
                                        <h2 class="section-title">
                                            <span class="fa fa-pencil">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleEducation" runat="server" />
                                            <span id="educationInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                        <span><asp:Literal ID="ltEducationMin" runat="server" /></span>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a id="hfEducationAdd" runat="server" href="#newEducation" class="btn btn-primary btn-sm add-btn">
                                            <span class="fa fa-plus">
                                                <!-- icon -->
                                            </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral106" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickEducation" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:Placeholder runat="server" ID="phAddEntryTextEducation">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2466" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>
                                <asp:Repeater ID="rptEducation" runat="server" OnItemDataBound="rptEducation_ItemDataBound"
                                    OnItemCommand="rptEducation_ItemCommand">
                                    <ItemTemplate>
                                        <div id="acEducation" runat="server" class="section-content">
                                            <div class="editable-section">
                                                <div class="section-entry">
                                                    <div class="title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltInstitute" runat="server" Text="ltInstitute" /></h4>
                                                        <a id="aEducationEdit" runat="server" class="fa fa-edit fa-0" data-toggle="collapse">
                                                            <!-- icon -->
                                                        </a>
                                                        <asp:LinkButton ID="lbEducationDelete" runat="server" CssClass="fa fa-trash fa-1" data-toggle="modal" data-target="#deleteConfirm" CommandName="EducationDelete" />
                                                    </div>
                                                    <asp:Literal ID="ltEducationLocation" runat="server" />
                                                    <h3>
                                                        <asp:Literal ID="ltQualificationName" runat="server" /></h3>
                                                    <div class="date-field">
                                                        <asp:Literal ID="ltEducationDate" runat="server" />
                                                    </div>
                                                    <p>
                                                        <asp:Literal ID="ltEducationDescription" runat="server" /></p>
                                                </div>
                                            </div>
                                            <!-- Edit form section  -->
                                            <div class="profile-edit collapse" id="edit-Education<%# Container.ItemIndex + 1 %>">
                                                <h2 class="form-title">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral107" runat="server" SetLanguageCode="LabelEditEntry" />
                                                </h2>
                                                <a href="#edit-Education<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <asp:label id="Label36" runat="server" AssociatedControlID="tbEducationInstitute">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral108" runat="server" SetLanguageCode="LabelInstitutionName" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbEducationInstitute" runat="server" CssClass="form-control" maxlength="255"/>
                                                        </div>
                                                        <asp:PlaceHolder ID="phEducationInstituteError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorEducationInstitute" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label39" runat="server" AssociatedControlID="ddlEducationQualificationLevel">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral111" runat="server" SetLanguageCode="LabelQualificationLevel" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlEducationQualificationLevel" runat="server" CssClass="form-control">
                                                                    <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationQualificationLevel</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                        <asp:PlaceHolder ID="phEducationQualificationLevelError" runat="server" Visible="false">
                                                            <span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral19" runat="server"
                                                                    SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label40" runat="server" AssociatedControlID="tbEducationQualificationName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral112" runat="server" SetLanguageCode="LabelQualificationName" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbEducationQualificationName" runat="server" CssClass="form-control QualificationNameAutocomplete"
                                                                placeholder="tbEducationQualificationName"  maxlength="255"/>
                                                        </div>
                                                        <asp:PlaceHolder ID="phEducationQualificationNameError" runat="server" Visible="false">
                                                            <span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ltErrorEducationQualificationName" runat="server"
                                                                    SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label37" runat="server" AssociatedControlID="ddlEducationCountry">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral109" runat="server" SetLanguageCode="LabelCountry" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlEducationCountry" runat="server" CssClass="form-control">
                                                                    <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationCountry</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label38" runat="server" AssociatedControlID="tbEducationState">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral110" runat="server" SetLanguageCode="LabelCityState" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbEducationState" runat="server" CssClass="form-control" placeholder="tbEducationState"  maxlength="100" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phEducationStateError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorEducationState" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                
                                                <div class="row rw_Education_OtherQualification">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label41" runat="server" AssociatedControlID="tbEducationOtherQualification">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral113" runat="server" SetLanguageCode="LabelOtherQualification" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbEducationOtherQualification" runat="server" CssClass="form-control" maxlength="100" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phEducationOtherQualificationError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorEducationOtherQualification" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-1 col-xs-12">
                                                        <asp:label id="Label111" runat="server" AssociatedControlID="cbEducationGraduated">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral132" runat="server" SetLanguageCode="LabelGraduated" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <input name="cbEducationGraduated" type="checkbox" id="cbEducationGraduated" runat="server" class="form-control btn-checkbox current-date" onclick="if( $(this).is(':checked') ) { $(this).closest('.profile-edit').find('.tbEducationGraduatedCredits').attr('disabled', 'disabled'); } else { $(this).closest('.profile-edit').find('.tbEducationGraduatedCredits').removeAttr('disabled'); }" />
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2 col-xs-12">
                                                        <asp:label id="Label112" runat="server" AssociatedControlID="tbEducationGraduatedCredits">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral134" runat="server" SetLanguageCode="LabelGraduatedCredits" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbEducationGraduatedCredits" runat="server" Enabled="true" CssClass="tbEducationGraduatedCredits" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phEducationGraduatedCreditsError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorEducationGraduatedCredits" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row date_wrap">
                                                    <div class="col-sm-6 col-xs-12 group-controls">
                                                        <asp:label id="Label42" runat="server" AssociatedControlID="ddlEducationStartMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral114" runat="server" SetLanguageCode="LabelStartDate" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlEducationStartMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationStartMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlEducationStartYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationStartYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span>
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral150" runat="server" SetLanguageCode="LabelTo" />
                                                        </span>
                                                    </div>
                                                    <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                        <asp:label id="Label43" runat="server" AssociatedControlID="ddlEducationEndMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral115" runat="server" SetLanguageCode="LabelEndDate" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlEducationEndMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationEndMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlEducationEndYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationEndYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                        <asp:PlaceHolder ID="phEducationEndError" runat="server" Visible="false"><span class="error-message-2">
                                                            <JXTControl:ucLanguageLiteral ID="ucEducationEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-1 col-xs-12">
                                                        <asp:label id="Label44" runat="server" AssociatedControlID="cbEducationCurrent">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral116" runat="server" SetLanguageCode="LabelCurrent" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <input name="eduCurrent" type="checkbox" id="cbEducationCurrent" runat="server" class="form-control btn-checkbox current-date" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="button-container">
                                                    <asp:LinkButton ID="lbEducationSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        ValidationGroup="Education">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral117" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a class="btn btn-primary cancel-btn btn-sm" href="#edit-Education<%# Container.ItemIndex + 1 %>"
                                                        data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral118" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- Add New -->
                                <div id="acEducationAdd" runat="server" class="section-content new-block-holder edit-mode hidden">
                                    <!-- Edit form section  -->
                                    <div id="newEducation" runat="server" class="profile-edit collapse" clientidmode="Static">
                                        <h2 class="form-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral119" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </h2>
                                        <a href="#newEducation" data-toggle="collapse" class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <asp:label id="Label45" runat="server" AssociatedControlID="tbEducationAddInstitute">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral120" runat="server" SetLanguageCode="LabelInstitutionName" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbEducationAddInstitute" runat="server" CssClass="form-control"
                                                        placeholder="tbEducationAddInstitute"  maxlength="255"/>
                                                </div>
                                                <asp:PlaceHolder ID="phEducationAddInstituteError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddEdicationInstitute" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label49" runat="server" AssociatedControlID="ddlEducationAddQualificationLevel">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral123" runat="server" SetLanguageCode="LabelQualificationLevel" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlEducationAddQualificationLevel" runat="server" CssClass="form-control">
                                                            <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationAddQualificationLevel</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                                <asp:PlaceHolder ID="phEducationAddQualificationLevelError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server"
                                                            SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label50" runat="server" AssociatedControlID="tbEducationAddQualificationName">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral124" runat="server" SetLanguageCode="LabelQualificationName" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbEducationAddQualificationName" runat="server" CssClass="form-control QualificationNameAutocomplete"
                                                        placeholder="tbEducationAddQualificationName" maxlength="255" />
                                                </div>
                                                <asp:PlaceHolder ID="phEducationAddQualificationNameError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddEducationAddQualificationName" runat="server"
                                                            SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label47" runat="server" AssociatedControlID="ddlEducationAddCountry">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral121" runat="server" SetLanguageCode="LabelCountry" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlEducationAddCountry" runat="server" CssClass="form-control">
                                                            <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationAddCountry</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label48" runat="server" AssociatedControlID="tbEducationAddState">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral122" runat="server" SetLanguageCode="LabelCityState" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbEducationAddState" runat="server" CssClass="form-control" placeholder="tbEducationAddState" maxlength="100" />
                                                </div>
                                                <asp:PlaceHolder ID="phEducationAddStateError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorAddEducationState" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row rw_Education_OtherQualification">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label51" runat="server" AssociatedControlID="tbEducationAddOtherQualification">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral125" runat="server" SetLanguageCode="LabelOtherQualification" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbEducationAddOtherQualification" runat="server" CssClass="form-control"
                                                        placeholder="tbEducationAddOtherQualificationLevel"  maxlength="100"/>
                                                </div>
                                                <asp:PlaceHolder ID="phEducationAddOtherQualificationError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorAddEducationOtherQualification" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-1 col-xs-12">
                                                <asp:label id="Label113" runat="server" AssociatedControlID="cbEducationAddGraduated">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral140" runat="server" SetLanguageCode="LabelGraduated" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <input name="cbEducationAddGraduated" type="checkbox" id="cbEducationAddGraduated" runat="server" class="form-control btn-checkbox current-date" onclick="if( $(this).is(':checked') ) { $(this).closest('.profile-edit').find('.tbEducationAddGraduatedCredits').attr('disabled', 'disabled'); } else { $(this).closest('.profile-edit').find('.tbEducationAddGraduatedCredits').removeAttr('disabled'); }" />
                                                </div>
                                            </div>
                                            <div class="col-sm-2 col-xs-12">
                                                <asp:label id="Label114" runat="server" AssociatedControlID="tbEducationAddGraduatedCredits">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral170" runat="server" SetLanguageCode="LabelGraduatedCredits" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbEducationAddGraduatedCredits" runat="server" Enabled="true" CssClass="tbEducationAddGraduatedCredits" />
                                                </div>
                                                <asp:PlaceHolder ID="phEducationAddGraduatedCreditsError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorAddEducationGraduatedCredits" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row date_wrap">
                                            <div class="col-sm-6 col-xs-12 group-controls">
                                                <asp:label id="Label52" runat="server" AssociatedControlID="ddlEducationAddStartMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral126" runat="server" SetLanguageCode="LabelStartDate" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlEducationAddStartMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationStartMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlEducationAddStartYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationAddStartYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral151" runat="server" SetLanguageCode="LabelTo" />
                                                </span>
                                            </div>
                                            <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                <asp:label id="Label53" runat="server" AssociatedControlID="ddlEducationAddEndMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral127" runat="server" SetLanguageCode="LabelEndDate" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlEducationAddEndMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationAddEndMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlEducationAddEndYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlEducationAddEndYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                                <asp:PlaceHolder ID="phEducationAddEndError" runat="server" Visible="false"><span
                                                    class="error-message-2">
                                                    <JXTControl:ucLanguageLiteral ID="ucEducationAddEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-1 col-xs-12">
                                                <asp:label id="Label46" runat="server" AssociatedControlID="cbEducationAddCurrent">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral128" runat="server" SetLanguageCode="LabelCurrent" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <input name="eduCurrent" type="checkbox" id="cbEducationAddCurrent" runat="server"
                                                        class="form-control btn-checkbox current-date" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="button-container">
                                            <asp:LinkButton ID="lbEducationAddSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                ValidationGroup="EducationAdd" OnClick="lbEducationAddSave_Click">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral129" runat="server" SetLanguageCode="LabelSave" />
                                            </asp:LinkButton>
                                            <a class="btn btn-primary cancel-btn btn-sm" href="#newEducation" data-toggle="collapse">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral130" runat="server" SetLanguageCode="LabelCancel" />
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <footer class="section-footer">
                                    <a href="#newEducation" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral131" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 6: Skills  -->
                    <asp:PlaceHolder ID="phSectionSkills" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="sec-Skills">
                        <asp:UpdatePanel ID="upSkills" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-6">
                                        <h2 class="section-title">
                                            <span class="fa fa-trophy">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleSkills" runat="server" />
                                            <span id="skillsInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a id="hfSkills" runat="server" href="#newSkill" class="btn btn-primary btn-sm add-btn"><span class="fa fa-plus">
                                            <!-- icon -->
                                        </span>
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral133" runat="server" SetLanguageCode="LabelAdd" /></a>
                                        <asp:PlaceHolder ID="phTickSkills" runat="server" Visible="false">
                                            <span class="fa fa-check section_status" aria-hidden="true"></span>
                                        </asp:PlaceHolder>
                                    </div>                                        
                                </header>
                                <asp:PlaceHolder ID="phAddEntryTextSkills" runat="server">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral247855" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>
                                <!-- Edit form section  -->
                                <div id="acSkills" runat="server" class="section-content new-block-holder edit-mode hidden">
                                    <div class="profile-edit collapse" id="newSkill" runat="server" clientidmode="Static">
                                        <a href="#newSkill" data-toggle="collapse" class="fa fa-times close-btn" style="z-index:999">
                                            <!-- close -->
                                        </a>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label54" runat="server" AssociatedControlID="tbSkillsAddSkill">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral135" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbSkillsAddSkill" runat="server" ClientIDMode="Static" CssClass="form-control autocomplete ui-autocomplete-input" maxlength="50" onkeyup="if(event.keyCode == 13){__doPostBack('ctl00$ContentPlaceHolder1$lbSkillsAdd','');}" />
                                                    <span runat="server" id="ltAddSkillErrorMsgWrapper" class="error-message" Visible="false">
                                                        <JXTControl:ucLanguageLiteral ID="ltAddSkillErrorMsg" runat="server" SetLanguageCode="LabelAddSkillAlreadyExist"/>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <!-- Save buttton  -->
                                                <div class="form-input-wide">
                                                    <br />
                                                    <asp:LinkButton ID="lbSkillsAdd" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lbSkillsAdd_Click" >
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral137" runat="server" SetLanguageCode="LabelAdd" />
                                                        <span class="fa fa-plus">
                                                            <!-- icon -->
                                                        </span>
                                                    </asp:LinkButton>
                                                    <a href="#newSkill" class="btn btn-primary btn-sm cancel-btn" data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral136" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:PlaceHolder ID="phSkillsDisplay" runat="server" Visible="false">
                                <div class="section-content no-border clearfix">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral138" runat="server" SetLanguageCode="LabelYourSkillSets" />
                                    </h4>
                                    <div class="tagsinput">
                                        <asp:Repeater ID="rptSkills" runat="server" OnItemDataBound="rptSkills_ItemDataBound" OnItemCommand="rptSkills_ItemCommand">
                                            <ItemTemplate>
                                                <span class="tag"><span>
                                                    <asp:Literal ID="ltSkill" runat="server" /></span> 
                                                    <asp:LinkButton ID="lbSkillDelete" runat="server" CommandName="SkillDelete" CausesValidation="false" title="Remove tag"/>
                                                    </span>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                </asp:PlaceHolder>
                                <footer class="section-footer">
                                    <a href="#newSkill" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral139" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 7: Certification -->
                    <asp:PlaceHolder ID="phSectionCertification" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-7">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-8">
                                        <h2 class="section-title">
                                            <span class="fa fa-user">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleCertification" runat="server" />
                                            <span id="certificationInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a id="hfCertificateAdd" runat="server" href="#newCnM" class="btn btn-primary btn-sm add-btn">
                                            <span class="fa fa-plus">
                                                <!-- icon -->
                                            </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral141" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickCertificate" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:PlaceHolder ID="phAddEntryTextCertificates" runat="server">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27554" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>
                                <asp:Repeater ID="rptCertification" runat="server" OnItemDataBound="rptCertification_ItemDataBound"
                                OnItemCommand="rptCertification_ItemCommand">
                                    <ItemTemplate>
                                        <div id="acCertificate" runat="server" class="section-content">
                                            <div class="editable-section">
                                                <div class="section-entry">
                                                    <div class="title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltAuthority" runat="server" Text="ltAuthority" /></h4>
                                                        <a id="aCertificateEdit" runat="server" class="fa fa-edit fa-0" data-toggle="collapse">
                                                            <!-- icon -->
                                                        </a>
                                                        <asp:LinkButton ID="lbCertificateDelete" runat="server" CssClass="fa fa-trash fa-1" data-toggle="modal" data-target="#deleteConfirm" CommandName="CertificateDelete" />
                                                    </div>
                                                    <h3>
                                                        <asp:Literal ID="ltCertificateMembershipName" runat="server" /></h3>
                                                    <div class="date-field">
                                                        <asp:Literal ID="ltCertificateMembershipDate" runat="server" />
                                                    </div>
                                                    <p>
                                                        <asp:Literal ID="ltCertificateMembershipUrl" runat="server" /><span
                                                            class="certificate-membership">
                                                            <asp:Literal ID="ltCertificateMembershipUrlNo" runat="server" /></span></p>
                                                </div>
                                            </div>
                                            <!-- Edit form section  -->
                                            <div class="profile-edit collapse" id="edit-CnM<%# Container.ItemIndex + 1 %>">
                                                <h2 class="form-title">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral142" runat="server" SetLanguageCode="LabelEditEntry" />
                                                </h2>
                                                <a href="#edit-CnM<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <asp:label id="Label55" runat="server" AssociatedControlID="tbCertificateCertificateMembershipName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral143" runat="server" SetLanguageCode="LabelEditCertificationsMembershipName" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbCertificateCertificateMembershipName" runat="server" CssClass="form-control"
                                                                placeholder="tbCertificateCertificateMembershipName" maxlength="600" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phCertificateMembershipNameError" runat="server" Visible="false">
                                                            <span class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ltErrorCertificateMembershipName" runat="server"
                                                                    SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label56" runat="server" AssociatedControlID="tbCertificateAuthority">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral144" runat="server" SetLanguageCode="LabelAuthority" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbCertificateAuthority" runat="server" CssClass="form-control" placeholder="tbCertificateAuthority" maxlength="100" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phCertificateAuthorityError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorCertificateAuthority" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label57" runat="server" AssociatedControlID="tbCertificateMembershipNumber">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral145" runat="server" SetLanguageCode="LabelCertificateMembershipNumber" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbCertificateMembershipNumber" runat="server" CssClass="form-control"
                                                                placeholder="tbCertificateMembershipNumber"  maxlength="100"/>
                                                        <asp:PlaceHolder ID="phCertificateMembershipNumberError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorCertificateMembershipNumber" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                        </span></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <asp:label id="Label58" runat="server" AssociatedControlID="tbCertificateURL">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral146" runat="server" SetLanguageCode="LabelCertificationURL" />
                                                            <span class="optional-field">(<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral147" runat="server" SetLanguageCode="LabelOptional" />)</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbCertificateURL" runat="server" CssClass="form-control" placeholder="tbCertificateURL" maxlength="256" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phCertificateURLError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorCertificateURL" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row certificate_validity_wrap">
                                                    <div class="col-sm-6 col-xs-12 group-controls">
                                                        <asp:label id="Label59" runat="server" AssociatedControlID="ddlCertificateStartMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral148" runat="server" SetLanguageCode="LabelStartDate" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlCertificateStartMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateStartMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlCertificateStartYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateStartYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span>
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral152" runat="server" SetLanguageCode="LabelTo" />
                                                        </span>
                                                    </div>
                                                    <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                        <asp:label id="Label60" runat="server" AssociatedControlID="ddlCertificateEndMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral149" runat="server" SetLanguageCode="LabelEndDate" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlCertificateEndMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateEndMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlCertificateEndYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateEndYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                        <asp:PlaceHolder ID="phCertificateError" runat="server" Visible="false"><span class="error-message-2">
                                                            <JXTControl:ucLanguageLiteral ID="ucCertificateError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row certificate_checkbox">
                                                    <div class="col-xs-12">
                                                        <div class="oneline-input-holder">
                                                            <asp:label id="Label61" runat="server" AssociatedControlID="cbCertificateDoesNotExpire">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral153" runat="server" SetLanguageCode="LabelCertificateDoesNotExpire" />
                                                                :
                                                                <input id="cbCertificateDoesNotExpire" runat="server" class="form-control btn-checkbox"
                                                                    type="checkbox" />
                                                            </asp:label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="button-container">
                                                    <asp:LinkButton ID="lbCertificateSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        ValidationGroup="Certificate">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral154" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a class="btn btn-primary cancel-btn btn-sm" href="#edit-CnM<%# Container.ItemIndex + 1 %>"
                                                        data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral155" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- Add New -->
                                <div id="acCertificateAdd" runat="server" class="section-content new-block-holder edit-mode hidden">
                                    <!-- Edit form section  -->
                                    <div class="profile-edit collapse" id="newCnM" runat="server" clientidmode="Static">
                                        <h2 class="form-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral156" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </h2>
                                        <a href="#newCnM" data-toggle="collapse" class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <asp:label id="Label62" runat="server" AssociatedControlID="tbCertificateAddCertificateMembershipName">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral157" runat="server" SetLanguageCode="LabelEditCertificationsMembershipName" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbCertificateAddCertificateMembershipName" runat="server" CssClass="form-control"
                                                        placeholder="tbCertificateAddCertificateMembershipName"  maxlength="600"/>
                                                </div>
                                                <asp:PlaceHolder ID="phCertificateAddNameError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddCertificateName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label63" runat="server" AssociatedControlID="tbCertificateAddAuthority">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral158" runat="server" SetLanguageCode="LabelAuthority" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbCertificateAddAuthority" runat="server" CssClass="form-control"
                                                        placeholder="tbCertificateAddAuthority" maxlength="100" />
                                                </div>
                                                <asp:PlaceHolder ID="phCertificateAddAuthorityError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddCertificateAuthority" runat="server"
                                                            SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label64" runat="server" AssociatedControlID="tbCertificateAddMembershipNumber">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral159" runat="server" SetLanguageCode="LabelCertificateMembershipNumber" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbCertificateAddMembershipNumber" runat="server" CssClass="form-control"
                                                        placeholder="tbCertificateAddMembershipNumber" maxlength="100" />
                                                </div>
                                                <asp:PlaceHolder ID="phCertificateAddMembershipNumberError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddCertificateMembershipNumber" runat="server"
                                                            SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <asp:label id="Label65" runat="server" AssociatedControlID="tbCertificateAddURL">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral160" runat="server" SetLanguageCode="LabelCertificationURL" />
                                                    <span class="optional-field">(<JXTControl:ucLanguageLiteral ID="UcLanguageLiteral161" runat="server" SetLanguageCode="LabelOptional" />)</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbCertificateAddURL" runat="server" CssClass="form-control" placeholder="tbCertificateAddURL"  maxlength="256"/>
                                                </div>
                                                <asp:PlaceHolder ID="phCertificateAddURLError" runat="server" Visible="false">
                                                    <span class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="ltErrorAddCertificateURL" runat="server"
                                                            SetLanguageCode="ValidateNoHTMLContent" />
                                                    </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row certificate_validity_wrap">
                                            <div class="col-sm-6 col-xs-12 group-controls">
                                                <asp:label id="Label66" runat="server" AssociatedControlID="ddlCertificateAddStartMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral162" runat="server" SetLanguageCode="LabelStartDate" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlCertificateAddStartMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateAddStartMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlCertificateAddStartYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateAddStartYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral163" runat="server" SetLanguageCode="LabelTo" />
                                                </span>
                                            </div>
                                            <div class="col-sm-5 col-xs-12 group-controls end-date-wrap">
                                                <asp:label id="Label67" runat="server" AssociatedControlID="ddlCertificateAddEndMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral164" runat="server" SetLanguageCode="LabelEndDate" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlCertificateAddEndMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateAddEndMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlCertificateAddEndYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlCertificateAddEndYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                                <asp:PlaceHolder ID="phCertificateAddError" runat="server" Visible="false"><span
                                                    class="error-message-2">
                                                    <JXTControl:ucLanguageLiteral ID="ucCertificateAddError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row certificate_checkbox">
                                            <div class="col-xs-12">
                                                <div class="oneline-input-holder">
                                                    <asp:label id="Label68" runat="server" AssociatedControlID="cbCertificateAddDoesNotExpire">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral165" runat="server" SetLanguageCode="LabelCertificateDoesNotExpire" />
                                                        :
                                                        <input id="cbCertificateAddDoesNotExpire" runat="server" class="form-control btn-checkbox"
                                                            type="checkbox" />
                                                    </asp:label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="button-container">
                                            <asp:LinkButton ID="lbCertificateAddSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                ValidationGroup="CertificateAdd" OnClick="lbCertificateAddSave_Click">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral166" runat="server" SetLanguageCode="LabelSave" />
                                            </asp:LinkButton>
                                            <a class="btn btn-primary cancel-btn btn-sm" href="#newCnM" data-toggle="collapse">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral167" runat="server" SetLanguageCode="LabelCancel" />
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <footer class="section-footer">
                                    <a href="#newCnM" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral168" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 8: Licenses -->
                    <asp:PlaceHolder ID="phSectionLicense" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-8">
                        <asp:UpdatePanel ID="upLicense" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-8">
                                        <h2 class="section-title">
                                            <span class="fa fa-user">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleLicenses" runat="server" />
                                            <span id="licenseInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a id="hfLicenseAdd" runat="server" href="#newLicense" class="btn btn-primary btn-sm add-btn">
                                            <span class="fa fa-plus">
                                                <!-- icon -->
                                            </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral169" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickLicense" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:Placeholder runat="server" ID="phAddEntryTextLicenses">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2475757" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>
                                <asp:Repeater ID="rptLicenses" runat="server" OnItemDataBound="rptLicenses_ItemDataBound"
                                    OnItemCommand="rptLicenses_ItemCommand">
                                    <ItemTemplate>
                                        <div id="acLicense" runat="server" class="section-content">
                                            <div class="editable-section">
                                                <div class="section-entry">
                                                    <div class="title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltLicenseName" runat="server" Text="ltLicenseName" /></h4>
                                                        <a id="aLicenseEdit" runat="server" class="fa fa-edit fa-0" data-toggle="collapse">
                                                            <!-- icon -->
                                                        </a>
                                                        <asp:LinkButton ID="lbLicenseDelete" runat="server" CssClass="fa fa-trash fa-1" data-toggle="modal" data-target="#deleteConfirm" CommandName="LicenseDelete" />
                                                    </div>
                                                    <asp:PlaceHolder ID="phLicenseAddress" runat="server" Visible="false"> 
                                                    <address class="inline-field">
                                                        <span class="fa fa-map-marker">
                                                            <!-- icon -->
                                                        </span>
                                                        <asp:Literal ID="ltLicenseStateCountry" runat="server" Text="" />
                                                    </address>
                                                    </asp:PlaceHolder>
                                                    <h3>
                                                        <asp:Literal ID="ltLicenseType" runat="server" Text="ltLicenseType" /></h3>
                                                    <div class="date-field">
                                                        <asp:Literal ID="ltLicenseDate" runat="server" Text="ltLicenseDate" />
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Edit form section  -->
                                            <div class="profile-edit collapse" id="edit-License<%# Container.ItemIndex + 1 %>">
                                                <h2 class="form-title">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral171" runat="server" SetLanguageCode="LabelEditEntry" />
                                                </h2>
                                                <a href="#edit-License<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <asp:label id="Label69" runat="server" AssociatedControlID="tbLicenseName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral172" runat="server" SetLanguageCode="LabelLicenseName" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbLicenseName" runat="server" CssClass="form-control" placeholder="tbLicenseName" maxlength="100" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phLicenseNameError" runat="server" Visible="false"><span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorLicenseName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label70" runat="server" AssociatedControlID="tbLicenseType">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral173" runat="server" SetLanguageCode="LabelLicenseType" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbLicenseType" runat="server" CssClass="form-control licenseTypeAutocomplete" placeholder="tbLicenseType" maxlength="200" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phLicenseTypeError" runat="server" Visible="false"><span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorLicenseType" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                         <asp:label id="Label71" runat="server" AssociatedControlID="ddlLicenseCountry">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral174" runat="server" SetLanguageCode="LabelCountry" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlLicenseCountry" runat="server" CssClass="form-control">
                                                                    <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseCountry</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                         <asp:label id="Label72" runat="server" AssociatedControlID="tbLicenseState">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral175" runat="server" SetLanguageCode="LabelCityState" />
                                                            :</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbLicenseState" runat="server" CssClass="form-control" placeholder="tbLicenseState" maxlength="100" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phLicenseStateError" runat="server" Visible="false"><span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorLicenseState" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12 group-controls">
                                                        <asp:label id="Label73" runat="server" AssociatedControlID="ddlLicenseIssueMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral176" runat="server" SetLanguageCode="LabelStartDate" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlLicenseIssueMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseIssueMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlLicenseIssueYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseIssueYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span>To</span>
                                                    </div>
                                                    <div class="col-sm-5 col-xs-12 group-controls">
                                                        <asp:label id="Label74" runat="server" AssociatedControlID="ddlLicenseExpiryMonth">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral177" runat="server" SetLanguageCode="LabelExpiryDate" />
                                                            :</asp:label>
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlLicenseExpiryMonth" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseExpiryMonth</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span><span class="custom-select">
                                                            <asp:DropDownList ID="ddlLicenseExpiryYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseExpiryYear</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                        <asp:PlaceHolder ID="phLicenseError" runat="server" Visible="false"><span class="error-message-2">
                                                            <JXTControl:ucLanguageLiteral ID="ucLicenseError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="button-container">
                                                    <asp:LinkButton ID="lbLicenseSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                        ValidationGroup="License">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral179" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a class="btn btn-primary cancel-btn btn-sm" href="#edit-License<%# Container.ItemIndex + 1 %>"
                                                        data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral178" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- Add New -->
                                <div id="acLicenseAdd" runat="server" class="section-content new-block-holder edit-mode hidden">
                                    <!-- Edit form section  -->
                                    <div class="profile-edit collapse" id="newLicense" runat="server" clientidmode="Static">
                                        <h2 class="form-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral33" runat="server" SetLanguageCode="LabelAddAnEntry" /></h2>
                                        <a href="#newLicense" data-toggle="collapse" class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <asp:label id="Label75" runat="server" AssociatedControlID="tbLicenseAddName">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral181" runat="server" SetLanguageCode="LabelLicenseName" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbLicenseAddName" runat="server" CssClass="form-control" placeholder="tbLicenseAddName" maxlength="100"/>
                                                </div>
                                                <asp:PlaceHolder ID="phLicenseAddNameError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddLicenseName" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label76" runat="server" AssociatedControlID="tbLicenseAddType">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral173" runat="server" SetLanguageCode="LabelLicenseType" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbLicenseAddType" runat="server" CssClass="form-control licenseTypeAutocomplete" placeholder="tbLicenseAddType" maxlength="200" />
                                                </div>
                                                <asp:PlaceHolder ID="phLicenseAddTypeError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ltErrorAddLicenseType" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label77" runat="server" AssociatedControlID="ddlLicenseAddCountry">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral174" runat="server" SetLanguageCode="LabelCountry" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlLicenseAddCountry" runat="server" CssClass="form-control">
                                                            <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseAddCountry</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label78" runat="server" AssociatedControlID="tbLicenseAddState">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral175" runat="server" SetLanguageCode="LabelCityState" />
                                                    :</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbLicenseAddState" runat="server" CssClass="form-control" placeholder="tbLicenseAddState" maxlength="100" />
                                                </div>
                                                <asp:PlaceHolder ID="phLicenseAddStateError" runat="server" Visible="false"><span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ltErrorAddLicenseState" runat="server" SetLanguageCode="ValidateNoHTMLContent" />
                                                        </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12 group-controls">
                                                <asp:label id="Label79" runat="server" AssociatedControlID="ddlLicenseAddIssueMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral176" runat="server" SetLanguageCode="LabelIssueDate" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlLicenseAddIssueMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseAddIssueMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlLicenseAddIssueYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseAddIssueYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span>To</span>
                                            </div>
                                            <div class="col-sm-5 col-xs-12 group-controls">
                                                 <asp:label id="Label80" runat="server" AssociatedControlID="ddlLicenseAddExpiryMonth">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral177" runat="server" SetLanguageCode="LabelExpiryDate" />
                                                    :</asp:label>
                                                <span class="custom-select">
                                                    <asp:DropDownList ID="ddlLicenseAddExpiryMonth" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseAddExpiryMonth</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="custom-select">
                                                    <asp:DropDownList ID="ddlLicenseAddExpiryYear" runat="server" CssClass="form-control">
                                                        <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlLicenseAddExpiryYear</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                                <asp:PlaceHolder ID="phLicenseAddError" runat="server" Visible="false"><span class="error-message-2">
                                                    <JXTControl:ucLanguageLiteral ID="ucLicenseAddError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="button-container">
                                            <asp:LinkButton ID="lbLicenseAddSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                ValidationGroup="LicenseAdd" OnClick="lbLicenseAddSave_Click">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral179" runat="server" SetLanguageCode="LabelSave" />
                                            </asp:LinkButton>
                                            <a class="btn btn-primary cancel-btn btn-sm" href="#newLicense" data-toggle="collapse">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral178" runat="server" SetLanguageCode="LabelCancel" />
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <footer class="section-footer">
                                    <a href="#newLicense" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral182" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 9: Role Preference -->
                    <asp:PlaceHolder ID="phSectionRolePreference" runat="server">
                        <section class="form-section scroll-point full-width clearfix self-editable" id="section-9">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <div id="acRolePrefrence" runat="server" class="section-content">
                                    <div class="editable-section">
                                        <header class="section-header">
                                            <div class="col-sm-8">
                                                <h2 class="section-title">
                                                    <span class="fa fa-heart-o">
                                                        <!-- icon -->
                                                    </span><asp:Literal ID="ltTitleRolePreferences" runat="server" />
                                                    <span id="rolePrefenceInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                                </h2>
                                            </div>
                                            <div class="pull-right add-btn-holder">
                                                <!--  <a href="#new-Role" class="btn btn-primary btn-sm add-btn"><span class="fa fa-plus"></span>Add</a> -->
                                                <a id="hfRolePreferencesEdit" runat="server" href="#editRole" class="fa fa-edit fa-0" data-toggle="collapse">
                                                    <!-- icon -->
                                                </a><asp:PlaceHolder ID="phTickRolePreference" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                            </div>
                                        </header>
                                        <asp:PlaceHolder ID="phAddEntryTextRolePreferences" runat="server">
                                            <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24475678" runat="server" SetLanguageCode="LabelEditEntry" /></p>
                                        </asp:PlaceHolder>
                                        <div class="section-content-inner">
                                            <header class="section-body-header">
                                                <div class="title-container has-edit-icon">
                                                    <h4>
                                                        <asp:Literal ID="ltRolePreferencesSalary" runat="server" Text="ltRolePreferencesSalary" /></h4>
                                                </div>
                                            
                                                <asp:Literal ID="ltRolePreferencesLocation" runat="server" />
                                            </header>
                                            <div class="section-entry">
                                                <div class="body-field field">
                                                    <h3><asp:Literal ID="ltRolePreferencesProfession" runat="server" /></h3>
                                                    <h5><asp:Literal ID="ltRolePreferencesRole" runat="server" /></h5>
                                                    <asp:Literal ID="ltRolePreferencesWorktype" runat="server" />
                                                    <p><asp:Literal ID="ltEligibleToWorkIn" runat="server" /></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Edit form section  -->
                                    <div class="profile-edit collapse" id="editRole" runat="server" clientidmode="Static">
                                        <header class="section-header">
                                            <div class="col-sm-6">
                                                <h2 class="section-title">
                                                    <span class="fa fa-heart-o">
                                                        <!-- icon -->
                                                    </span><asp:Literal ID="ltRolePreferencesEditTitle" runat="server" />
                                                </h2>
                                            </div>
                                            <div class="pull-right">
                                                <!--  <a href="#new-Role" class="btn btn-primary btn-sm add-btn"><span class="fa fa-plus"></span>Add</a> -->
                                                <a href="#editRole" data-toggle="collapse" class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                            </div>
                                        </header>
                                        <div class="section-content-inner">
                                            <div class="row">
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:label id="Label81" runat="server" AssociatedControlID="ddlRolePreferenceWorkType">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral186" runat="server" SetLanguageCode="LabelWorkType" />:</asp:label>
                                                    <div class="form-input">
                                                        <div class="controls multiselect-group">
                                                            <asp:DropDownList ID="ddlRolePreferenceWorkType" runat="server" CssClass="multiselect form-control"
                                                                multiple="multiple">
                                                                <asp:ListItem Selected="True" Value="0">ddlRolePreferenceWorkType</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hfRolePreferenceWorkType" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:label id="Label82" runat="server" AssociatedControlID="ddlRolePreferenceSalaryRequirements">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral187" runat="server" SetLanguageCode="LabelSalaryRequirements" />:</asp:label>
                                                    <div class="form-input">
                                                        <span class="custom-select">
                                                            <asp:DropDownList ID="ddlRolePreferenceSalaryRequirements" runat="server" CssClass="form-control">
                                                                <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlRolePreferenceSalaryRequirements</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4 col-xs-6 rw_RolePreference_SalaryRange">
                                                    <asp:label id="Label83" runat="server" AssociatedControlID="tbRolePreferenceSalaryMin">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral188" runat="server" SetLanguageCode="LabelSalaryRange" />:</asp:label>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-xs-12">
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbRolePreferenceSalaryMin" runat="server" CssClass="form-control"
                                                                    placeholder="tbRolePreferenceSalaryMin" />
                                                            </div>
                                                        </div>
                                                        <asp:PlaceHolder ID="phRolePreferenceSalaryMinError" runat="server" Visible="false"><span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral20" runat="server" SetLanguageCode="LabelDecimalOnly" />
                                                        </span></asp:PlaceHolder>
                                                        <div class="col-sm-6 col-xs-12">
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbRolePreferenceSalaryMax" runat="server" CssClass="form-control"
                                                                    placeholder="tbRolePreferenceSalaryMax" />
                                                            </div>

                                                        </div>
                                                        <asp:PlaceHolder ID="phRolePreferenceSalaryMaxError" runat="server" Visible="false"><span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral21" runat="server" SetLanguageCode="LabelDecimalOnly" />
                                                        </span></asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="phRolePreferenceSalaryRangeError" runat="server" Visible="false"><span class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral22" runat="server" SetLanguageCode="LabelSalaryRangeError" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:UpdatePanel ID="upProfession" runat="server" UpdateMode="Conditional" class="row">
                                                <ContentTemplate>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <asp:Label ID="lblRolePreferenceJobClassification" runat="server" AssociatedControlID="ddlRolePreferenceJobClassification">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral189" runat="server" SetLanguageCode="LabelJobClassification" />:</asp:Label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlRolePreferenceJobClassification" runat="server" CssClass="form-control"
                                                                    AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlRolePreferenceJobClassification_SelectedIndexChanged">
                                                                    <asp:ListItem disabled="disabled" Selected="True" Value="0">ddlRolePreferenceJobClassification</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12">
                                                         <asp:label id="Label84" runat="server" AssociatedControlID="ddlRolePreferenceJobSubClassification">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral190" runat="server" SetLanguageCode="LabelSubClassification" />:</asp:label>
                                                        <div class="form-input">
                                                            <div class="controls multiselect-group">
                                                                <asp:DropDownList ID="ddlRolePreferenceJobSubClassification" runat="server" CssClass="multiselect form-control"
                                                                    multiple="multiple">
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hfRolePreferenceJobSubClassification" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="upLocation" runat="server" UpdateMode="Conditional" class="row">
                                                <ContentTemplate>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <asp:label id="Label85" runat="server" AssociatedControlID="ddlRolePreferenceDesiredLocation">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral191" runat="server" SetLanguageCode="LabelDesiredLocation" />:</asp:label>
                                                            
                                                        <div class="form-input">
                                                        <span class="custom-select">
                                                            <uc1:DropDownListX ID="ddlRolePreferenceDesiredLocation" runat="server" CssClass="form-control"
                                                                AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlRolePreferenceDesiredLocation_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="0">ddlRolePreferenceDesiredLocation</asp:ListItem>
                                                            </uc1:DropDownListX>
                                                            </span>
                                                        </div>
                                                        
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12">
                                                        <asp:label id="Label86" runat="server" AssociatedControlID="ddlRolePreferenceDesiredRegion">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral192" runat="server" SetLanguageCode="LabelDesiredRegion" />:</asp:label>
                                                        <div class="form-input">
                                                            <div class="controls multiselect-group">
                                                                <asp:DropDownList ID="ddlRolePreferenceDesiredRegion" runat="server" CssClass="multiselect form-control"
                                                                    multiple="multiple">
                                                                    <asp:ListItem Selected="True" Value="0">ddlRolePreferenceDesiredRegion</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hfRolePreferenceDesiredRegion" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 col-xs-12 rw_RolePreference_EligibleToWorkIn">
                                                        <asp:label id="Label87" runat="server" AssociatedControlID="ddlRolePreferenceEligibleToWorkIn">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral193" runat="server" SetLanguageCode="LabelEligibleToWorkIn" />:</asp:label>
                                                        <div class="form-input">
                                                            <div class="controls multiselect-group">
                                                                <asp:DropDownList ID="ddlRolePreferenceEligibleToWorkIn" runat="server" CssClass="multiselect form-control"
                                                                    multiple="multiple">
                                                                    <asp:ListItem Selected="True" Value="0">ddlRolePreferenceEligibleToWorkIn</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hfRolePreferenceEligibleWorkIn" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <!-- Save buttton  -->
                                            <div class="form-input-wide">
                                                <label class="spacer-lbl">
                                                    &nbsp;</label>
                                                <asp:LinkButton ID="lbRolePreferenceSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                    ValidationGroup="RolePreference" OnClick="lbRolePreferenceSave_Click">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral195" runat="server" SetLanguageCode="LabelSave" />
                                                </asp:LinkButton>
                                                <a href="#editRole" class="btn btn-primary cancel-btn btn-sm" data-toggle="collapse">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral194" runat="server" SetLanguageCode="LabelCancel" />
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 12: Languages  -->
                    <asp:PlaceHolder ID="phSectionLanguages" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="sec-Languages">
                        <asp:UpdatePanel ID="upLanguages" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-6">
                                        <h2 class="section-title">
                                            <span class="fa fa-commenting-o">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleLanguage" runat="server" />
                                            <span id="languageInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>                                                                                        
                                        </h2>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <a href="#newLanguage" class="btn btn-primary btn-sm add-btn"><span class="fa fa-plus">
                                            <!-- icon -->
                                        </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral219" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickLanguage" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                <asp:PlaceHolder ID="phAddEntryTextLanguages" runat="server">
                                    <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral245656" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                </asp:PlaceHolder>                                
                                <!-- Edit form section  -->
                                <div id="acLanguage" runat="server" class="section-content new-block-holder edit-mode hidden">
                                    <div class="profile-edit collapse" id="newLanguage" runat="server" clientidmode="Static" >
                                        <h2 class="form-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral220" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </h2>
                                        <a id="hfLanguageAdd" runat="server" href="#newLanguage" data-toggle="collapse"
                                            class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                        <div class="clearfix">
                                            <div class="col-sm-3 col-xs-12">
                                                <asp:label id="Label94" runat="server" AssociatedControlID="tbLanguageName">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral221" runat="server" SetLanguageCode="LabelLanguage" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbLanguageName" runat="server" CssClass="form-control" placeholder="tbLanguageName" maxlength="150" />
                                                </div>
                                                <asp:PlaceHolder ID="phLanguageNameError" runat="server" Visible="false"><span class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ucLanguageNameError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-3 col-xs-12">
                                                <asp:label id="Label95" runat="server" AssociatedControlID="ddlLanguageProficiency">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral222" runat="server" SetLanguageCode="LabelProficiency" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlLanguageProficiency" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-sm-5 col-xs-12">
                                                <!-- Save buttton  -->
                                                <div class="form-input-wide">
                                                    <label for="">
                                                        &nbsp;</label>
                                                    <asp:LinkButton ID="lbLanguageAdd" runat="server" CssClass="btn btn-primary btn-sm"
                                                        OnClick="lbLanguageAdd_Click" ValidationGroup="Language">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral223" runat="server" SetLanguageCode="LabelAdd" />
                                                        <span class="fa fa-plus">
                                                            <!-- icon -->
                                                        </span>
                                                    </asp:LinkButton>
                                                    <a href="#newLanguage" class="btn btn-primary btn-sm cancel-btn" data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral224" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="section-content no-border">
                                    <div class="clearfix">
                                        <asp:Repeater ID="rptLanguages" runat="server" OnItemDataBound="rptLanguages_ItemDataBound"
                                            OnItemCommand="rptLanguages_ItemCommand">
                                            <ItemTemplate>
                                                <div class="col-lg-3 col-md-4 col-sm-6 col-sx-12">
                                                    <div class="cancelable-block">
                                                        <p class="lang-title">
                                                            <strong>
                                                                <asp:Literal ID="ltLanguageName" runat="server" />
                                                            </strong>
                                                        </p>
                                                        <small>
                                                            <asp:Literal ID="ltProficiency" runat="server" /></small>
                                                        <asp:LinkButton ID="lbLanguageDelete" runat="server" CssClass="fa fa-times close-btn"
                                                            CommandName="LanguageDelete" CausesValidation="false" />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <footer class="section-footer">
                                    <a href="#newLanguage" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral225" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 13: References  -->
                    <asp:PlaceHolder ID="phSectionReferences" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-13">
                        <asp:UpdatePanel ID="upReferences" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <header class="section-header">
                                    <div class="col-sm-6">
                                        <h2 class="section-title">
                                            <span class="fa fa-user">
                                                <!-- icon -->
                                            </span><asp:Literal ID="ltTitleReferences" runat="server" />
                                            <span id="referencesInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                        <span><asp:Literal ID="ltReferencesMin" runat="server" /></span>
                                    </div>
                                    <div class="pull-right add-btn-holder">
                                        <asp:PlaceHolder ID="phUponRequest" runat="server">
                                        <div class="oneline-input-holder">
                                            <asp:label id="Label96" runat="server" AssociatedControlID="refUponRequest" CssClass="pull-left">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral227" runat="server" SetLanguageCode="LabelUponRequest" />
                                                :
                                                <input name="refUponRequest" type="checkbox" id="refUponRequest" runat="server" class="form-control btn-checkbox uponrequest-btn" />
                                            </asp:label>
                                            <asp:LinkButton ID="lbReferencesSubmit" runat="server" CssClass="btn btn-primary btn-sm upon-request-submit-btn" OnClick="lbReferencesSubmit_Click">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral228" runat="server" SetLanguageCode="ButtonSubmit" />
                                                <span class="fa fa-upload" aria-hidden="true"></span>
                                            </asp:LinkButton>
                                        </div>
                                        </asp:PlaceHolder>
                                        <a id="hfReferenceAdd" runat="server" href="#newReference" class="btn btn-primary btn-sm add-btn">
                                            <span class="fa fa-plus">
                                                <!-- icon -->
                                            </span><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral229" runat="server" SetLanguageCode="LabelAdd" />
                                        </a><asp:PlaceHolder ID="phTickReferences" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                    </div>
                                </header>
                                    <asp:PlaceHolder ID="phAddEntryTextReferences" runat="server">
                                        <p class="empty-case_field text-center"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral276764" runat="server" SetLanguageCode="LabelAddAnEntry" /></p>
                                    </asp:PlaceHolder>
                                    <asp:Repeater ID="rptReferences" runat="server" OnItemDataBound="rptReferences_ItemDataBound"
                                    OnItemCommand="rptReferences_ItemCommand">
                                    <ItemTemplate>
                                        <div id="acReference" runat="server" class="section-content">
                                            <div class="editable-section">
                                                <header class="section-body-header">
                                                    <div class="title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltReferencesCompany" runat="server" /></h4>
                                                        <a id="aReferenceEdit" runat="server" class="fa fa-edit fa-0" data-toggle="collapse">
                                                            <!-- icon -->
                                                        </a>
                                                        <asp:LinkButton ID="lbReferencesDelete" runat="server" CssClass="fa fa-trash fa-1" data-toggle="modal" data-target="#deleteConfirm" CommandName="ReferencesDelete" />
                                                    </div>
                                                    <h3>
                                                        <asp:Literal ID="ltReferencesName" runat="server" /></h3>
                                                    <h5>
                                                        <asp:Literal ID="ltReferencesJobTitle" runat="server" /></h5>
                                                </header>
                                                <div class="section-entry">
                                                    <div class="body-field field">
                                                        <p>
                                                                    <asp:PlaceHolder id="phReferencesPhone" runat="server" Visible="false">
                                                                        <span class="fa fa-phone"><!-- icon --></span> <asp:Literal ID="ltReferencePhone" runat="server" /> <asp:Literal ID="ltReferenceEmail" runat="server" />
                                                                    </asp:PlaceHolder>
                                                                    <span class="fa fa-user">
                                                                        <!-- icon -->
                                                                    </span>
                                                                    <asp:Literal ID="ltReferencesRelationship" runat="server" />
                                                                    <asp:Literal ID="ltReferencesEmailDisplay" runat="server" />

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Edit form section  -->
                                            <div class="profile-edit collapse" id="edit-Reference<%# Container.ItemIndex + 1 %>">
                                                <h2 class="form-title">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral230" runat="server" SetLanguageCode="LabelEditEntry" />
                                                </h2>
                                                <a href="#edit-Reference<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label97" runat="server" AssociatedControlID="tbReferencesName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral231" runat="server" SetLanguageCode="LabelName" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbReferencesName" runat="server" CssClass="form-control" placeholder="tbReferencesName" maxlength="100" />
                                                        </div>
                                                        <asp:PlaceHolder ID="phReferencesNameError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ucReferencesNameError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label98" runat="server" AssociatedControlID="tbReferencesJobTitle">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral232" runat="server" SetLanguageCode="LabelJobTitle" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbReferencesJobTitle" runat="server" CssClass="form-control" placeholder="tbReferencesJobTitle" maxlength="100"/>
                                                        </div>
                                                        <asp:PlaceHolder ID="phReferencesJobTitleError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ucReferencesJobTitleError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label99" runat="server" AssociatedControlID="tbRefernecesCompany">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral233" runat="server" SetLanguageCode="LabelCompany" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbRefernecesCompany" runat="server" CssClass="form-control" placeholder="tbRefernecesCompany" maxlength="100"/>
                                                        </div>
                                                        <asp:PlaceHolder ID="phReferencesCompanyError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ucReferencesCompanyError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label100" runat="server" AssociatedControlID="tbReferencesPhone">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral234" runat="server" SetLanguageCode="LabelPhone" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbReferencesPhone" runat="server" CssClass="form-control" placeholder="tbReferencesPhone" maxlength="100"/>
                                                        </div>
                                                        <asp:PlaceHolder ID="phReferencesPhoneError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ucReferencesPhoneError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label101" runat="server" AssociatedControlID="ddlReferencesRelationship">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral235" runat="server" SetLanguageCode="LabelRelationship" />
                                                            <span class="form-required">*</span> :</asp:label>
                                                        <div class="form-input">
                                                            <span class="custom-select">
                                                                <asp:DropDownList ID="ddlReferencesRelationship" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:label id="Label109" runat="server" AssociatedControlID="tbReferencesEmail">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral61" runat="server" SetLanguageCode="LabelEmail" />
                                                            <span class="form-required">*</span>:</asp:label>
                                                        <div class="form-input">
                                                            <asp:TextBox ID="tbReferencesEmail" runat="server" CssClass="form-control" placeholder="tbReferencesEmail" maxlength="100"/>
                                                        </div>
                                                    <asp:PlaceHolder ID="phReferencesEmailRequiredError" runat="server" Visible="false"><span
                                                        class="error-message">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral184" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                    </span></asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="phReferencesEmailError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral77" runat="server" SetLanguageCode="LabelEmailInvalid" />
                                                        </span></asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-xs-12">
                                                        <!-- Save buttton  -->
                                                        <div class="form-input-wide">
                                                            <label class="spacer-lbl">
                                                                &nbsp;</label>
                                                            <asp:LinkButton ID="lbReferencesSave" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral36" runat="server" SetLanguageCode="LabelSave" />
                                                            </asp:LinkButton>
                                                            <a href="#edit-Reference<%# Container.ItemIndex + 1 %>" class="btn btn-primary btn-sm cancel-btn"
                                                                data-toggle="collapse">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral39" runat="server" SetLanguageCode="LabelCancel" />
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div id="acReferenceAdd" runat="server" class="section-content new-block-holder edit-mode hidden">
                                    <div class="profile-edit collapse" id="newReference" runat="server" clientidmode="Static">
                                        <h2 class="form-title">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral240" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </h2>
                                        <a href="#newReference" data-toggle="collapse" class="fa fa-times close-btn">
                                            <!-- close -->
                                        </a>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label102" runat="server" AssociatedControlID="tbReferencesAddName">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral231" runat="server" SetLanguageCode="LabelName" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbReferencesAddName" runat="server" CssClass="form-control" placeholder="tbReferencesAddName" maxlength="100"/>
                                                </div>
                                                <asp:PlaceHolder ID="phReferencesAddNameError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ucReferencesAddNameError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label103" runat="server" AssociatedControlID="tbReferencesAddJobTitle">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral232" runat="server" SetLanguageCode="LabelJobTitle" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbReferencesAddJobTitle" runat="server" CssClass="form-control"
                                                        placeholder="tbReferencesAddJobTitle" maxlength="100"/>
                                                </div>
                                                <asp:PlaceHolder ID="phReferencesAddJobTitleError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ucReferencesAddJobTitle" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label104" runat="server" AssociatedControlID="tbRefernecesAddCompany">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral233" runat="server" SetLanguageCode="LabelCompany" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbRefernecesAddCompany" runat="server" CssClass="form-control" placeholder="tbRefernecesAddCompany" maxlength="100"/>
                                                </div>
                                                <asp:PlaceHolder ID="phReferencesAddCompany" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ucReferencesAddCompany" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label105" runat="server" AssociatedControlID="tbReferencesAddPhone">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral234" runat="server" SetLanguageCode="LabelPhone" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbReferencesAddPhone" runat="server" CssClass="form-control" placeholder="tbReferencesAddPhone" maxlength="100"/>
                                                </div>
                                                <asp:PlaceHolder ID="phReferencesAddPhoneError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="ucReferencesAddPhone" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                 <asp:label id="Label106" runat="server" AssociatedControlID="ddlReferencesAddRelationship">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral235" runat="server" SetLanguageCode="LabelRelationship" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <span class="custom-select">
                                                        <asp:DropDownList ID="ddlReferencesAddRelationship" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </span>
                                                </div>
                                                <asp:PlaceHolder ID="phRelationshipError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral28" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:label id="Label110" runat="server" AssociatedControlID="tbReferencesAddEmail">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral72" runat="server" SetLanguageCode="LabelEmail" />
                                                    <span class="form-required">*</span>:</asp:label>
                                                <div class="form-input">
                                                    <asp:TextBox ID="tbReferencesAddEmail" runat="server" CssClass="form-control" placeholder="tbReferencesAddEmail" maxlength="100"/>
                                                </div>
                                                <asp:PlaceHolder ID="phReferencesAddEmailRequiredError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral183" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                </span></asp:PlaceHolder>
                                                <asp:PlaceHolder ID="phReferencesAddEmailError" runat="server" Visible="false"><span
                                                    class="error-message">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral105" runat="server" SetLanguageCode="LabelEmailInvalid" />
                                                </span></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <!-- Save buttton  -->
                                                <div class="form-input-wide">
                                                    <label class="spacer-lbl">
                                                        &nbsp;</label>
                                                    <asp:LinkButton ID="lbReferencesAddSave" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false"
                                                        OnClick="lbReferencesAddSave_Click">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral236" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <a href="#newReference" class="btn btn-primary btn-sm cancel-btn" data-toggle="collapse">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral237" runat="server" SetLanguageCode="LabelCancel" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <footer class="section-footer">
                                    <a href="#newReference" class="btn add-btn">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral230" runat="server" SetLanguageCode="LabelAdd" />
                                        <span class="fa fa-plus">
                                            <!-- -->
                                        </span></a>
                                </footer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 14: Supplement Questions  -->
                    <asp:PlaceHolder ID="phSectionCustomQuestions" runat="server">
                        <section class="form-section scroll-point full-width clearfix self-editable" id="section-14">
                        <asp:UpdatePanel ID="upCustomQuestions" runat="server" UpdateMode="Conditional" class="form-all">
                            <ContentTemplate>
                                <div id="acCustomQuestions" runat="server" class="section-content qa-section">
                                    <div class="editable-section">
                                        <header class="section-header">
                                            <div class="col-sm-8">
                                                <h2 class="section-title">
                                                    <span class="fa fa-user">
                                                        <!-- icon -->
                                                    </span><asp:Literal ID="ltTitleCustomQuestions" runat="server" />
                                                    <span id="customQuestionInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                                </h2>
                                            </div>
                                            <div class="pull-right add-btn-holder">
                                                <a id="hfCustomQuestions" runat="server" href="#editsupplementaryQuestions" class="fa fa-edit fa-6"
                                                    data-toggle="collapse">
                                                    <!-- icon -->
                                                </a><asp:PlaceHolder ID="phTickCustomQuestions" runat="server"><span class="fa fa-check section_status" aria-hidden="true"></span></asp:PlaceHolder>
                                            </div>
                                        </header>
                                        <div class="section-content-inner section-entry">
                                            <asp:Repeater ID="rptCustomQuestions" runat="server" OnItemDataBound="rptCustomQuestions_ItemDataBound">
                                                <HeaderTemplate>
                                                    <dl>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <dt>
                                                        <p>
                                                            <strong>
                                                                <asp:Literal ID="ltQuestion" runat="server" /></strong></p>
                                                    </dt>
                                                    <dd>
                                                            <asp:Literal ID="ltAnswer" runat="server" />
                                                    </dd>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </dl>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="profile-edit collapse" id="editsupplementaryQuestions" runat="server" clientidmode="Static">
                                        <header class="section-header">
                                            <div class="col-xs-10">
                                                <h2 class="section-title">
                                                    <span class="fa fa-user">
                                                        <!-- icon -->
                                                    </span><asp:Literal ID="ltTitleCustomQuestionsEdit" runat="server" />
                                                </h2>
                                            </div>
                                            <div class="col-xs-2 text-right">
                                                <a href="#editsupplementaryQuestions" data-toggle="collapse" class="fa fa-times close-btn">
                                                    <!-- close -->
                                                </a>
                                            </div>
                                        </header>
                                        <div class="section-content-inner">
                                        
                                        <asp:Repeater ID="rptCustomQuestionsAnswers" runat="server" OnItemDataBound="rptCustomQuestionsAnswers_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="row question_wrap">
                                                    <div class="col-xs-12">
                                                            <asp:Literal ID="ltQuestion" runat="server" />
                                                        <asp:PlaceHolder ID="phCustomQuestionError" runat="server" Visible="false"><span
                                                            class="error-message">
                                                            <JXTControl:ucLanguageLiteral ID="ucCustomQuestionError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                        </span></asp:PlaceHolder>
                                                        <div id="divInput" runat="server" class="form-input">
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <!-- Save buttton  -->
                                        <div class="form-input-wide">
                                            <div class="form-buttons-wrapper">
                                                <asp:LinkButton ID="lbCustomQuestionsSave" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="false"
                                                    OnClick="lbCustomQuestionsSave_Click">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral269" runat="server" SetLanguageCode="LabelSave" />
                                                </asp:LinkButton>
                                                <a href="#editsupplementaryQuestions" class="btn btn-primary cancel-btn btn-sm"
                                                    data-toggle="collapse">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral270" runat="server" SetLanguageCode="LabelCancel" />
                                                </a>
                                            </div>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>
                    <!-- Section 16: Download Profile btn  -->
                    <div class="text-center">
                        <asp:LinkButton ID="lbDownloadPdf" runat="server" CssClass="btn btn-primary" role="button"
                            OnClick="PDFGetButton_Click">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral264" runat="server" SetLanguageCode="LabelProfileDownloadPDF" />
                            <span class="fa fa-download" aria-hidden="true"></span>
                        </asp:LinkButton>
                    </div>
                </div>
                <!-- //CV-content -->
                <!-- //content-holder -->
            </div>
        </div>
    </div>
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && (!(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")) && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.js"))))
       { %>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js"></script>
    <% } %>
    <script src='https://images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-multiselect.js'></script>
    <!-- Modal -->
    <div id="deleteConfirm" class="modal fade" role="dialog">
        <div class="vertical-alignment-helper">
            <div class="modal-dialog modal-sm vertical-align-center">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                    </div>
                    <div class="modal-body">
                        <p class="delete-confirm text-center">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral38" runat="server" SetLanguageCode="LabelConfirmDeleteRecord" />
                        </p>
                    </div>
                    <div class="modal-footer">
                        <a id="confirmDeleteYes" class="btn btn-primary btn-sm yes-btn" data-dismiss="modal">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral282" runat="server" SetLanguageCode="LabelYes" />
                        </a><a class="btn btn-primary btn-sm no-btn" data-dismiss="modal">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral283" runat="server" SetLanguageCode="LabelNo" />
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--    </div>--%>
</asp:Content>
