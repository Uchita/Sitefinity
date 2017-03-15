<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPublicProfile.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.peoplesearch.ucPublicProfile" %>

<%--Register UserControls--%>

<div id="content-container" class="container">
        <div id="content" style="box-sizing: border-box; width: 100%;" class="col-xs-12">
            <div class="content-holder">
               
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
                                </figure>

                                <asp:PlaceHolder ID="phProfilePicError" runat="server" Visible="false">
                                <span class="error-message">
                                    <JXTControl:ucLanguageLiteral ID="ucProfilePicError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                </span>
                                </asp:PlaceHolder>
                            </div>
                            <!-- Basic Profile Info & Edit -->
                            <asp:UpdatePanel ID="upProfile" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-sm-8 col-md-5 col-xs-12  section-content" id="basicProfile" runat="server" clientidmode="Static">
                                        <!-- Profile info Section -->
                                        <div class="profile-data editable-section">
                                            <!-- Candidate Name -->
                                            <div class="clearfix">
                                                <div class="pull-left" id="candidate-name">
                                                    <h3>
                                                        <span class="member-title">
                                                            <asp:Literal ID="ltTitle" runat="server" Text="ltTitle" />
                                                        </span> 
                                                        
                                                        <span class="first-name">
                                                            <asp:Literal ID="ltFirstName" runat="server" />
                                                        </span> 
                                                        
                                                        <span class="last-name">
                                                            <asp:Literal ID="ltLastName" runat="server" />
                                                        </span>
                                                      </h3>
                                                </div>
                                            </div>
                                            <asp:Literal ID="ltMultilingualFirstName" runat="server" />

                                            <!-- Title -->
                                            <div id="headline">
                                                <p class="highlight">
                                                    <asp:Literal ID="ltHeadline" runat="server" Text="ltHeadline" />
                                                </p>
                                            </div>

                                            <!-- Seek Status and Availability -->
                                            <div id="profileRow1" class="row">
                                                <asp:Literal ID="ltCurrentSeeking" runat="server" />
                                                <asp:Literal ID="ltAvailableDayFrom" runat="server" />
                                            </div>

                                            <!-- Last Modified Date -->
                                            <div id="profileRow2" class="row">
                                                <asp:Literal ID="ltlLastModifiedDate" runat="server" />                                                
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <!-- DownLoad Resume -->
                           <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" class="col-sm-12 col-md-4 col-xs-12">
                                <ContentTemplate>

                                <div class="info_graphic">
                                    <span class="fa fa-download">
                                        <asp:HyperLink ID="linkDownloadResume" runat=server CssClass="downloadResume">Download Resume</asp:HyperLink>
                                    </span>      
                                </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </section>

                    <!-- Section 2: Summary And Personal Details ........ starts -->
                    <asp:UpdatePanel ID="upSummary" runat="server" UpdateMode="Conditional" class="scroll-point">
                        <ContentTemplate>
                            <div class="row equal-height-blocks">
                                <!-- Summary Content -->
                                <asp:PlaceHolder ID="phSectionSummary" runat="server">
                                    <div class="col-md-12">
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
                                                                    <span id="summaryInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                                        clientidmode="Static">
                                                                        <!-- iconc -->
                                                                    </span>
                                                                </h3>
                                                            </div>
                                                        </div>
                                                        <div class="summary">
                                                            <asp:Literal ID="ltSummary" runat="server" />
                                                        </div>
                                                    </div>
                                                </article>
                                            </div>
                                        </section>
                                    </div>
                                </asp:PlaceHolder>
                            </div>

                            <div class="row equal-height-blocks">
                            <!-- Personal Details -->
                            <asp:PlaceHolder ID="phSectionPersonalDetails" runat="server">
                                <div class="col-md-12">
                                    <section class="form-section full-width clearfix" id="section-3">
                                        <div class="editable-section">
                                            <div class="row">
                                                <div class="col-sm-9  has-edit-icon">
                                                    <h3 class="section-title">
                                                        <span class="fa fa-envelope-o form-icon">
                                                            <!-- icon -->
                                                        </span>
                                                        <asp:Literal ID="ltTitleMyPersonalDetails" runat="server" />
                                                        <span id="personalDetailsInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                            clientidmode="Static">
                                                            <!-- icon -->
                                                        </span>
                                                    </h3>
                                                </div>
                                            </div>
                                            <div id="personalDetailsSlider" class="carousel slide" data-ride="carousel">
                                                
                                                        <div class="col-md-4">
                                                            <span class="highlight primary-email-heading">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral37" runat="server" SetLanguageCode="LabelEmailAddress" />
                                                            </span>
                                                            
                                                            <span class="personal-detail-content primary-email">
                                                                <asp:Literal ID="ltEmail" runat="server"/>
                                                            </span>
                                                         </div>

                                                        <div class="col-md-4">
                                                            <asp:Literal ID="ltDateOfBirth" runat="server" />
                                                        </div>

                                                        <div class="col-md-4">
                                                            <asp:Literal ID="ltGender" runat="server" />
                                                        </div>

                                                        <div class="col-md-4">
                                                            <span class="highlight address-heading">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral40" runat="server" SetLanguageCode="LabelAddress" />
                                                            </span>

                                                            <span class="personal-detail-content address-detail">
                                                                <asp:Literal ID="ltAddress1" runat="server" />
                                                                <asp:Literal ID="ltAddress2" runat="server" />
                                                                <asp:Literal ID="ltCity" runat="server" />
                                                                <asp:Literal ID="ltState" runat="server" />
                                                                <asp:Literal ID="ltPostcode" runat="server" />
                                                                <asp:Literal ID="ltCountry" runat="server" />
                                                            </span>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <asp:Literal ID="ltLineSelected" runat="server" Text="ltLineSelected" />
                                                        </div>
    

                                                        <div class="col-md-4">
                                                            <asp:Literal ID="ltSecondaryEmail" runat="server" />
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:Literal ID="ltPhoneNumber" runat="server" />
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:Literal ID="ltMobileNumber" runat="server" />
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:Literal ID="ltPassportNumber" runat="server" />
                                                        </div>
                                                        
                                                        <div class="col-md-4">
                                                            <span class="highlight">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral45" runat="server" SetLanguageCode="LabelMailingAddress" />
                                                            </span><span class="personal-detail-content mailing-address-detail">
                                                                <asp:Literal ID="ltMailingAddress1" runat="server" />
                                                                <asp:Literal ID="ltMailingAddress2" runat="server" />
                                                                <asp:Literal ID="ltMailingCity" runat="server" />
                                                                <asp:Literal ID="ltMailingState" runat="server" />
                                                                <asp:Literal ID="ltMailingPostcode" runat="server" />
                                                                <asp:Literal ID="ltMailingCountry" runat="server" />
                                                            </span>
                                                        </div>
                                                
                                            </div>
                                        </div>
                                    </section>
                                </div>
                                </asp:PlaceHolder>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <!-- Section 10 & 11: Attach Resume & Coverletter -->
                    <div class="row clearfix scroll-point" id="attach-container">
                        <!-- Section 10: Attach Resume  -->
                        <asp:PlaceHolder ID="phSectionResume" runat="server">
                                    <section class="form-section frm-sec-2" id="sec-AttachResume">   
                                        <!-- Resume Heading -->
                                        <header class="section-header">
                                            <div class="col-sm-8">                                               
                                                <h2 class="section-title">
                                                    <span class="fa fa-file-text-o">
                                                        <!-- icon -->
                                                    </span>

                                                    <asp:Literal ID="ltTitleResume" runat="server" />

                                                    <span id="resumeInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static">
                                                        <!-- icon -->
                                                    </span>
                                                </h2>
                                            </div>
                                        </header>

                                        <!-- Resume Holder Empty Body Content -->
                                        <asp:PlaceHolder ID="phAddEntryTextResume" runat="server">
                                            <p class="empty-case_field text-center">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25757554" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                            </p>
                                        </asp:PlaceHolder>

                                        <!-- Resume Repeater -->
                                        <div class="section-content">
                                            <asp:Repeater ID="rptResume" runat="server" OnItemDataBound="rptResume_ItemDataBound">
                                                <%--Resume List--%>
                                                <HeaderTemplate>
                                                    <ul class="edit-list">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <li>
                                                        <span class="text-nowrap">
                                                            <asp:Literal ID="ltResumeFileName" runat="server" />
                                                        </span>
                                                        <div class="btn-group pull-left">
                                                            <asp:HyperLink ID="hlResumeDownload" runat="server" CssClass="fa fa-download" aria-hidden="true" />
                                                        </div>
                                                    </li>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </ul>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>

                                        <!-- Download All Button -->
                                        <div class="info_graphic downloadAll">
                                            <span class="fa fa-download">
                                                <asp:LinkButton ID="lbDownloadAllResume" CssClass="downloadResume" runat="server" OnClick="lbDownloadAllResume_Click">Download All</asp:LinkButton>
                                            </span>
                                        </div>
                                    </section>
                        </asp:PlaceHolder>

                        <!-- Section 11: Attach Coverletter  -->
                        <asp:PlaceHolder ID="phSectionCoverLetter" runat="server">
                                    <section class="form-section frm-sec-2" id="sec-AttachCoverletter">
                                        <!-- Cover Letter Heading -->
                                        <header class="section-header">
                                            <div class="col-sm-8">
                                                <h2 class="section-title">
                                                    <span class="fa fa-file-text-o">
                                                        <!-- icon -->
                                                    </span>
                                                    <asp:Literal ID="ltTitleCoverLetter" runat="server" />
                                                    <span id="coverLetterInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                        clientidmode="Static">
                                                        <!-- icon -->
                                                    </span>
                                                </h2>
                                            </div>
                                        </header>

                                        <!-- Cover Letter Empty Placeholder -->
                                        <asp:PlaceHolder ID="phAddEntryTextCoverletter" runat="server">
                                            <p class="empty-case_field text-center">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2446" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                            </p>
                                        </asp:PlaceHolder>

                                        <!-- Cover Letter Repeater -->
                                        <div class="section-content">
                                            <asp:Repeater ID="rptCoverLetter" runat="server" OnItemDataBound="rptCoverLetter_ItemDataBound">
                                                <HeaderTemplate>
                                                    <ul class="edit-list">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <li><span class="text-nowrap">
                                                        <asp:Literal ID="ltCoverLetterFileName" runat="server" />
                                                    </span>
                                                        <div class="btn-group pull-left">
                                                            <asp:HyperLink ID="hlCoverLetterDownload" runat="server" CssClass="fa fa-download"
                                                                aria-hidden="true" />
                                                        </div>
                                                    </li>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </ul>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>

                                        <!-- Download All Button -->
                                        <div class="info_graphic downloadAll">
                                                <span class="fa fa-download">
                                                    <asp:LinkButton ID="lbDownloadAllCoverLetter" CssClass="downloadCoverletter" OnClick="lbDownloadAllCoverLetter_Click" runat="server">Download All</asp:LinkButton>
                                                </span>
                                            </div>
                                    </section>
                        </asp:PlaceHolder>
                    </div>

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
                                            </span>
                                            
                                            <asp:Literal ID="ltTitleExperience" runat="server" />

                                            <span id="experienceInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static"><!-- icon --></span>
                                        </h2>
                                        <span><asp:Literal ID="ltExperienceMin" runat="server" /></span>
                                    </div>
                                </header>

                                <!-- Add an Entry when there are no entries -->
                                <asp:Placeholder runat="server" ID="phAddEntryTextExperience">
                                    <p class="empty-case_field text-center">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2456" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                    </p>
                                </asp:PlaceHolder>

                                <asp:Repeater ID="rptExperience" runat="server" OnItemDataBound="rptExperience_ItemDataBound">
                                    <ItemTemplate>
                                        <article id="acExperience" runat="server" class="section-content">
                                            <div class="editable-section">
                                                <header class="section-body-header">
                                                    <div class="title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltExperienceJobTitle" runat="server" Text="ltExperienceJobTitle" />
                                                        </h4>                                                        
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
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    </asp:PlaceHolder>

                    <!-- Section 5: Educational Qualification -->
                    <asp:PlaceHolder ID="phSectionEducation" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-5">
                            <asp:UpdatePanel ID="upEducation" runat="server" UpdateMode="Conditional" class="form-all">
                                <ContentTemplate>
                                    <!-- Header -->
                                    <header class="section-header">
                                        <div class="col-sm-8">
                                            <h2 class="section-title">
                                                <span class="fa fa-pencil">
                                                    <!-- icon -->
                                                </span>
                                                <asp:Literal ID="ltTitleEducation" runat="server" />
                                                <span id="educationInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                    clientidmode="Static">
                                                    <!-- icon -->
                                                </span>
                                            </h2>
                                            <span>
                                                <asp:Literal ID="ltEducationMin" runat="server" /></span>
                                        </div>
                                    </header>

                                    <!-- Add Entry Wen there are no education history-->
                                    <asp:PlaceHolder runat="server" ID="phAddEntryTextEducation">
                                        <p class="empty-case_field text-center">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2466" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </p>
                                    </asp:PlaceHolder>

                                    <!-- Education Listing -->
                                    <asp:Repeater ID="rptEducation" runat="server" OnItemDataBound="rptEducation_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="acEducation" runat="server" class="section-content">
                                                <div class="editable-section">
                                                    <div class="section-entry">
                                                        <div class="title-container has-edit-icon">
                                                            <h4>
                                                                <asp:Literal ID="ltInstitute" runat="server" Text="ltInstitute" />
                                                            </h4>
                                                        </div>

                                                        <asp:Literal ID="ltEducationLocation" runat="server" />

                                                        <h3>
                                                            <asp:Literal ID="ltQualificationName" runat="server" />
                                                        </h3>

                                                        <div class="date-field">
                                                            <asp:Literal ID="ltEducationDate" runat="server" />
                                                        </div>

                                                        <p>
                                                            <asp:Literal ID="ltEducationDescription" runat="server" />
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </section>
                    </asp:PlaceHolder>

                    <!-- Section 6: Skills  -->
                    <asp:PlaceHolder ID="phSectionSkills" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="sec-Skills">
                            <asp:UpdatePanel ID="upSkills" runat="server" UpdateMode="Conditional" class="form-all">
                                <ContentTemplate>
                                    <!-- Heading -->
                                    <header class="section-header">
                                        <div class="col-sm-6">
                                            <h2 class="section-title">
                                                <span class="fa fa-trophy">
                                                    <!-- icon -->
                                                </span>
                                                <asp:Literal ID="ltTitleSkills" runat="server" />
                                                <span id="skillsInfo" class="fa fa-info-circle hide headingInfo" runat="server" clientidmode="Static">
                                                    <!-- icon -->
                                                </span>
                                            </h2>
                                        </div>
                                    </header>

                                    <!-- Empty skills Placeholder -->
                                    <asp:PlaceHolder ID="phAddEntryTextSkills" runat="server">
                                        <p class="empty-case_field text-center">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral247855" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </p>
                                    </asp:PlaceHolder>

                                    <!-- Skills Listing -->
                                    <asp:PlaceHolder ID="phSkillsDisplay" runat="server" Visible="false">
                                        <div class="section-content no-border clearfix">
                                            <h4>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral138" runat="server" SetLanguageCode="LabelPublicProfileSkillSets" />
                                            </h4>

                                            <div class="tagsinput">
                                                <asp:Repeater ID="rptSkills" runat="server" OnItemDataBound="rptSkills_ItemDataBound">
                                                    <ItemTemplate>
                                                        <span class="tag"><span>
                                                            <asp:Literal ID="ltSkill" runat="server" /></span>
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </section>
                    </asp:PlaceHolder>

                    <!-- Section 7: Certification -->
                    <asp:PlaceHolder ID="phSectionCertification" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-7">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" class="form-all">
                                <ContentTemplate>
                                    <!-- Heading -->
                                    <header class="section-header">
                                        <div class="col-sm-8">
                                            <h2 class="section-title">
                                                <span class="fa fa-user">
                                                    <!-- icon -->
                                                </span>
                                                <asp:Literal ID="ltTitleCertification" runat="server" />
                                                <span id="certificationInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                    clientidmode="Static">
                                                    <!-- icon -->
                                                </span>
                                            </h2>
                                        </div>
                                    </header>

                                    <!-- Empty Placeholder -->
                                    <asp:PlaceHolder ID="phAddEntryTextCertificates" runat="server">
                                        <p class="empty-case_field text-center">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27554" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </p>
                                    </asp:PlaceHolder>

                                    <!-- Certification Listing -->
                                    <asp:Repeater ID="rptCertification" runat="server" OnItemDataBound="rptCertification_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="acCertificate" runat="server" class="section-content">
                                                <div class="editable-section">
                                                    <div class="section-entry">
                                                        <div class="title-container has-edit-icon">
                                                            <h4>
                                                                <asp:Literal ID="ltAuthority" runat="server" Text="ltAuthority" />
                                                            </h4>    
                                                        </div>

                                                        <h3>
                                                            <asp:Literal ID="ltCertificateMembershipName" runat="server" />
                                                        </h3>

                                                        <div class="date-field">
                                                            <asp:Literal ID="ltCertificateMembershipDate" runat="server" />
                                                        </div>

                                                        <p>
                                                            <asp:Literal ID="ltCertificateMembershipUrl" runat="server" />
                                                            <span class="certificate-membership">
                                                                <asp:Literal ID="ltCertificateMembershipUrlNo" runat="server" />
                                                            </span>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </section>
                    </asp:PlaceHolder>

                    <!-- Section 8: Licenses -->
                    <asp:PlaceHolder ID="phSectionLicense" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-8">
                            <asp:UpdatePanel ID="upLicense" runat="server" UpdateMode="Conditional" class="form-all">
                                <ContentTemplate>
                                    
                                    <!-- Header Title -->
                                    <header class="section-header">
                                        <div class="col-sm-8">
                                            <h2 class="section-title">
                                                <span class="fa fa-user">
                                                    <!-- icon -->
                                                </span>
                                                <asp:Literal ID="ltTitleLicenses" runat="server" />
                                                <span id="licenseInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                    clientidmode="Static">
                                                    <!-- icon -->
                                                </span>
                                            </h2>
                                        </div>
                                    </header>

                                    <!-- Empty Licences Placeholder -->
                                    <asp:PlaceHolder runat="server" ID="phAddEntryTextLicenses">
                                        <p class="empty-case_field text-center">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2475757" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </p>
                                    </asp:PlaceHolder>

                                    <!-- Licences Listing -->
                                    <asp:Repeater ID="rptLicenses" runat="server" OnItemDataBound="rptLicenses_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="acLicense" runat="server" class="section-content">
                                                <div class="editable-section">
                                                    <div class="section-entry">

                                                        <div class="title-container has-edit-icon">
                                                            <h4>
                                                                <asp:Literal ID="ltLicenseName" runat="server" Text="ltLicenseName" /></h4>
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
                                                            <asp:Literal ID="ltLicenseType" runat="server" Text="ltLicenseType" />
                                                        </h3>

                                                        <div class="date-field">
                                                            <asp:Literal ID="ltLicenseDate" runat="server" Text="ltLicenseDate" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                                            
                                            <!-- Preferred Roles Heading -->
                                            <header class="section-header">
                                                <div class="col-sm-8">
                                                    <h2 class="section-title">
                                                        <span class="fa fa-heart-o">
                                                            <!-- icon -->
                                                        </span>
                                                        <asp:Literal ID="ltTitleRolePreferences" runat="server" />
                                                        <span id="rolePrefenceInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                            clientidmode="Static">
                                                            <!-- icon -->
                                                        </span>
                                                    </h2>
                                                </div>
                                            </header>

                                            <!-- Empty Placeholder -->
                                            <asp:PlaceHolder ID="phAddEntryTextRolePreferences" runat="server">
                                                <p class="empty-case_field text-center">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24475678" runat="server" SetLanguageCode="LabelEditEntry" />
                                                </p>
                                            </asp:PlaceHolder>

                                            <div class="section-content-inner">
                                                <header class="section-body-header">
                                                    <div class="title-container has-edit-icon">
                                                        <h4>
                                                            <asp:Literal ID="ltRolePreferencesSalary" runat="server" Text="ltRolePreferencesSalary" />
                                                         </h4>
                                                    </div>

                                                    <asp:Literal ID="ltRolePreferencesLocation" runat="server" />
                                                </header>

                                                <div class="section-entry">
                                                    <div class="body-field field">
                                                        <h3>
                                                            <asp:Literal ID="ltRolePreferencesProfession" runat="server" />
                                                        </h3>
                                                        
                                                        <h5>
                                                            <asp:Literal ID="ltRolePreferencesRole" runat="server" />
                                                        </h5>
                                                        
                                                        <asp:Literal ID="ltRolePreferencesWorktype" runat="server" />
                                                        
                                                        <p>
                                                            <asp:Literal ID="ltEligibleToWorkIn" runat="server" />
                                                        </p>
                                                    </div>
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
                                    <!-- Heading -->
                                    <header class="section-header">
                                        <div class="col-sm-6">
                                            <h2 class="section-title">
                                                <span class="fa fa-commenting-o">
                                                    <!-- icon -->
                                                </span>
                                                <asp:Literal ID="ltTitleLanguage" runat="server" />
                                                <span id="languageInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                    clientidmode="Static">
                                                    <!-- icon -->
                                                </span>
                                            </h2>
                                        </div>
                                    </header>

                                    <!-- Add Entry Placeholder -->
                                    <asp:PlaceHolder ID="phAddEntryTextLanguages" runat="server">
                                        <p class="empty-case_field text-center">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral245656" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </p>
                                    </asp:PlaceHolder>

                                    <!-- Language Repeater -->
                                    <div class="section-content no-border">
                                        <div class="clearfix">
                                            <asp:Repeater ID="rptLanguages" runat="server" OnItemDataBound="rptLanguages_ItemDataBound">
                                                <ItemTemplate>
                                                    <div class="col-lg-3 col-md-4 col-sm-6 col-sx-12">
                                                        <div class="cancelable-block">
                                                            <p class="lang-title">
                                                                <strong>
                                                                    <asp:Literal ID="ltLanguageName" runat="server" />
                                                                </strong>
                                                            </p>
                                                            <small>
                                                                <asp:Literal ID="ltProficiency" runat="server" />
                                                            </small>                    
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </section>
                    </asp:PlaceHolder>

                    <!-- Section 13: References  -->
                    <asp:PlaceHolder ID="phSectionReferences" runat="server">
                        <section class="form-section scroll-point full-width clearfix" id="section-13">
                            <asp:UpdatePanel ID="upReferences" runat="server" UpdateMode="Conditional" class="form-all">
                                <ContentTemplate>
                                    
                                    <!-- Header Title -->
                                    <header class="section-header">
                                        <div class="col-sm-6">
                                            <h2 class="section-title">
                                                <span class="fa fa-user">
                                                    <!-- icon -->
                                                </span>
                                                <asp:Literal ID="ltTitleReferences" runat="server" />
                                                <span id="referencesInfo" class="fa fa-info-circle hide headingInfo" runat="server"
                                                    clientidmode="Static">
                                                    <!-- icon -->
                                                </span>
                                            </h2>
                                            <span>
                                                <asp:Literal ID="ltReferencesMin" runat="server" /></span>
                                        </div>
                                    </header>

                                    <!-- Place Holder Text -->
                                    <asp:PlaceHolder ID="phAddEntryTextReferences" runat="server">
                                        <p class="empty-case_field text-center">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral276764" runat="server" SetLanguageCode="LabelAddAnEntry" />
                                        </p>
                                    </asp:PlaceHolder>

                                    <!-- references repeater -->
                                    <asp:Repeater ID="rptReferences" runat="server" OnItemDataBound="rptReferences_ItemDataBound">
                                        <ItemTemplate>
                                            <div id="acReference" runat="server" class="section-content">
                                                <div class="editable-section">
                                                    <header class="section-body-header">
                                                        <div class="title-container has-edit-icon">
                                                            <h4>
                                                                <asp:Literal ID="ltReferencesCompany" runat="server" />
                                                            </h4>
                                                        </div>
                                                        <h3>
                                                            <asp:Literal ID="ltReferencesName" runat="server" /></h3>
                                                        <h5>
                                                            <asp:Literal ID="ltReferencesJobTitle" runat="server" /></h5>
                                                    </header>
                                                    <div class="section-entry">
                                                        <div class="body-field field">
                                                            <p>
                                                                <asp:PlaceHolder ID="phReferencesPhone" runat="server" Visible="false">
                                                                <span class="fa fa-phone">
                                                                    <!-- icon -->
                                                                </span>
                                                                
                                                                <asp:Literal ID="ltReferencePhone" runat="server" />
                                                                <asp:Literal ID="ltReferenceEmail" runat="server" />

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
                                                            <asp:Label ID="Label97" runat="server" AssociatedControlID="tbReferencesName">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral231" runat="server" SetLanguageCode="LabelName" />
                                                                <span class="form-required">*</span>:</asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbReferencesName" runat="server" CssClass="form-control" placeholder="tbReferencesName"
                                                                    MaxLength="100" />
                                                            </div>
                                                            <asp:PlaceHolder ID="phReferencesNameError" runat="server" Visible="false"><span
                                                                class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ucReferencesNameError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                        </div>
                                                        <div class="col-sm-6 col-xs-12">
                                                            <asp:Label ID="Label98" runat="server" AssociatedControlID="tbReferencesJobTitle">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral232" runat="server" SetLanguageCode="LabelJobTitle" />
                                                                <span class="form-required">*</span>:</asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbReferencesJobTitle" runat="server" CssClass="form-control" placeholder="tbReferencesJobTitle"
                                                                    MaxLength="100" />
                                                            </div>
                                                            <asp:PlaceHolder ID="phReferencesJobTitleError" runat="server" Visible="false"><span
                                                                class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ucReferencesJobTitleError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-xs-12">
                                                            <asp:Label ID="Label99" runat="server" AssociatedControlID="tbRefernecesCompany">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral233" runat="server" SetLanguageCode="LabelCompany" />
                                                                <span class="form-required">*</span>:</asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbRefernecesCompany" runat="server" CssClass="form-control" placeholder="tbRefernecesCompany"
                                                                    MaxLength="100" />
                                                            </div>
                                                            <asp:PlaceHolder ID="phReferencesCompanyError" runat="server" Visible="false"><span
                                                                class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ucReferencesCompanyError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                        </div>
                                                        <div class="col-sm-6 col-xs-12">
                                                            <asp:Label ID="Label100" runat="server" AssociatedControlID="tbReferencesPhone">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral234" runat="server" SetLanguageCode="LabelPhone" />
                                                                <span class="form-required">*</span>:</asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbReferencesPhone" runat="server" CssClass="form-control" placeholder="tbReferencesPhone"
                                                                    MaxLength="100" />
                                                            </div>
                                                            <asp:PlaceHolder ID="phReferencesPhoneError" runat="server" Visible="false"><span
                                                                class="error-message">
                                                                <JXTControl:ucLanguageLiteral ID="ucReferencesPhoneError" runat="server" SetLanguageCode="LabelRequiredField1" />
                                                            </span></asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-xs-12">
                                                            <asp:Label ID="Label101" runat="server" AssociatedControlID="ddlReferencesRelationship">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral235" runat="server" SetLanguageCode="LabelRelationship" />
                                                                <span class="form-required">*</span> :</asp:Label>
                                                            <div class="form-input">
                                                                <span class="custom-select">
                                                                    <asp:DropDownList ID="ddlReferencesRelationship" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-xs-12">
                                                            <asp:Label ID="Label109" runat="server" AssociatedControlID="tbReferencesEmail">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral61" runat="server" SetLanguageCode="LabelEmail" />
                                                                <span class="form-required">*</span>:</asp:Label>
                                                            <div class="form-input">
                                                                <asp:TextBox ID="tbReferencesEmail" runat="server" CssClass="form-control" placeholder="tbReferencesEmail"
                                                                    MaxLength="100" />
                                                            </div>
                                                            <asp:PlaceHolder ID="phReferencesEmailRequiredError" runat="server" Visible="false">
                                                                <span class="error-message">
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
                                                                <asp:LinkButton ID="lbReferencesSave" runat="server" CssClass="btn btn-primary btn-sm"
                                                                    CausesValidation="false">
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



<%--<div class="form-all">
    <div class="form-header-group">
        <h2 class="form-header">
            <asp:Literal ID="litMemberName" runat="server" />
            <JXTControl:ucLanguageLiteral ID="ltsPublicProfile"
                runat="server" SetLanguageCode="sLabelPublicProfile" />
        </h2>
    </div>
    <div class="search-sequence">
        <ul class="form-section">
            <li class="form-line" id="pp-name-field">
                <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltName" runat="server" SetLanguageCode="LabelName" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litName" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-email-field">
                <asp:Label ID="lbEmail" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltEmail" runat="server" SetLanguageCode="LabelEmail" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litEmail" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-status-field">
                <asp:Label ID="lbStatus" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltStatus" runat="server" SetLanguageCode="LabelStatus" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litStatus" runat="server" />
                </div>
            </li>
            <li class="form-line" id="pp-publicprofile-field">
                <asp:Label ID="lbPublicProfile" runat="server" CssClass="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltPublicProfile" runat="server" SetLanguageCode="LabelPublicProfile" />
                    :</asp:Label>
                <div class="form-input">
                    <asp:Literal ID="litPublicProfile" runat="server" />
                </div>
            </li>
        </ul>
    </div>
</div>--%>
