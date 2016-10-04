<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="AdvertiserApplicationNote.aspx.cs" Inherits="JXTPortal.Website.advertiser.AdvertiserApplicationNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltAdvertiserApplicationNote" runat="server" SetLanguageCode="LabelJobApplicationNote" />
                </h2>
            </div>
            
            <div class="form-all">
                <ul class="form-section">
                    <li class="form-line" id="jobapp-appdate-field">
                        <asp:Label ID="lbApplicationDate" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteDate" runat="server" SetLanguageCode="LabelApplicationDate" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataApplicationDate" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-resume-field">
                        <asp:Label ID="lbResume" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteResume" runat="server" SetLanguageCode="LabelResume" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:HyperLink ID="dataResume" runat="server" Text="Download" CssClass="form-textbox"></asp:HyperLink>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-coverletter-field">
                        <asp:Label ID="lbCoverLetter" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteCoverLetter" runat="server"
                                SetLanguageCode="LabelCoverLetter" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:HyperLink ID="dataCoverLetter" runat="server" CssClass="form-textbox"></asp:HyperLink>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-appstatus-field">
                        <asp:Label ID="lbApplicationStatus" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteStatus" runat="server" SetLanguageCode="LabelStatus" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataApplicationStatus" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-applicantgrade-field">
                        <asp:Label ID="lbApplicantGrade" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteAppGrade" runat="server" SetLanguageCode="LabelApplicantGrade" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataApplicantGrade" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-lastvieweddate-field">
                        <asp:Label ID="lbLastViewedDate" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteViewedDate" runat="server" SetLanguageCode="LabelLastViewedDate" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataLastViewedDate" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-firstname-field">
                        <asp:Label ID="lbFirstName" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteFirstName" runat="server" SetLanguageCode="LabelFirstName" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataFirstName" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-surname-field">
                        <asp:Label ID="lbSurname" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteSurname" runat="server" SetLanguageCode="LabelSurname" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataSurname" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-email-field">
                        <asp:Label ID="lbEmailAddress" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteEmailAdd" runat="server" SetLanguageCode="LabelEmailAddress" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:HyperLink ID="dataEmailAddress" runat="server" CssClass="form-textbox"></asp:HyperLink>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-mobilephone-field">
                        <asp:Label ID="lbMobilePhone" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteMobilePhone" runat="server"
                                SetLanguageCode="LabelPhoneMobile" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataMobilePhone" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="jobapp-note-field">
                        <asp:Label ID="lbNote" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteNote" runat="server" SetLanguageCode="LabelNote" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="dataNote" CssClass="form-textbox"
                                Rows="5" />
                            <asp:RequiredFieldValidator ID="ReqVal_Note" runat="server" ControlToValidate="dataNote"
                                ErrorMessage="Required" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                </ul>
                <ul class="form-section">
                    <li class="form-line" id="adv-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="mini-new-buttons" CausesValidation="False" OnClick="btnBack_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="mini-new-buttons" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
