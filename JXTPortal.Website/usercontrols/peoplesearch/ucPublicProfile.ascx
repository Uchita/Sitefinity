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
                                                                <asp:Literal ID="ltEmail" runat="server" Text="ltEmail" />
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
                    
                    <!-- Section 10 & 11: Attach Rsume & Coverletter -->
                    <div class="row clearfix scroll-point" id="attach-container">
                        <!-- Section 10: Attach Resume  -->
                        <asp:PlaceHolder ID="phSectionResume" runat="server">
                            <asp:UpdatePanel ID="upResume" runat="server" UpdateMode="Conditional" class="col-md-6">
                                <ContentTemplate>
                                    <section class="form-section frm-sec-2" id="sec-AttachResume">
                                        <header class="section-header">
                                            <div class="col-sm-8">
                                                <!-- Resume Heading -->
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
                                            <!-- Cover Letter Heading -->
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
                                    </section>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
