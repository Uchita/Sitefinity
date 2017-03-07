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

                            <!-- Profile Meter Indicator -->
                           <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" class="col-sm-12 col-md-4 col-xs-12">
                                <ContentTemplate>

                                <!-- Meter Level (Expert/Medium/Low/etc) -->
                                <h4 class="text-center">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelHowDoesMyFileCompare" />
                                </h4>
                                <div class="info_graphic">
                                    <div class="profile-status-wrap">
                                        <div class="profile-status">
                                        </div>
                                        <span class="perc">
                                            <span class="status">
                                                <asp:Literal ID="ltProfileProgress" runat="server" Text="60" />
                                            </span>%
                                        </span>
                                    </div>

                                    <div class="profile_status_info_wrap">
                                        <div class="profile_status_info">
                                            <span class="pro_level">
                                                <asp:Literal ID="ltProfileLevel" runat="server" />
                                             </span>
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

                    <!-- Section 2: Summary And Personal Details ........ starts -->
                    <asp:UpdatePanel ID="upSummary" runat="server" UpdateMode="Conditional" class="scroll-point">
                        <ContentTemplate>
                            <div class="row equal-height-blocks">
                                <!-- Summary Content -->
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
                                                        <span class="highlight primary-email-heading">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral37" runat="server" SetLanguageCode="LabelEmailAddress" />
                                                        </span>
                                                        
                                                        <span class="personal-detail-content primary-email"> 
                                                            <asp:Literal ID="ltEmail" runat="server" Text="ltEmail" />
                                                        </span> 

                                                        <asp:Literal ID="ltDateOfBirth" runat="server"  />
                                                        <asp:Literal ID="ltGender" runat="server" />

                                                        <span class="highlight address-heading">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral40" runat="server" SetLanguageCode="LabelAddress" />
                                                        </span>

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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                   
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
