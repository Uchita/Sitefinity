<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="JobApplicationEdit.aspx.cs" Inherits="JXTPortal.Website.advertiser.JobApplicationEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <script type="text/javascript">

        $(document).ready(function () {

            $("#btnBack").on("click", GoBackToLastPage);

        });

        function GoBackToLastPage() {
            window.history.back();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_Advertiser_Job_Application_Edit" />
            <%--<div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltJobApplicationEdit" runat="server" SetLanguageCode="LabelEditJobApplication" />
                </h2>
            </div>--%>
            <div class="form-all edit-job-application">
                <div class="search-sequence" id="jobapp-edit-container">
                    <asp:Panel ID="pnlSite" runat="server" Visible="false">
                        <div class="form-line" id="jobapp-site-field">
                            <asp:Label ID="Label1" runat="server" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltSite" runat="server" SetLanguageCode="LabelSite" />
                                :</asp:Label>
                            <div class="form-input">
                                <asp:Label ID="dataSite" runat="server" CssClass="form-textbox"></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="form-line" id="jobapp-jobtitle-field">
                        <asp:Label ID="Label2" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataJobTitle" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-appdate-field">
                        <asp:Label ID="lbApplicationDate" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppDate" runat="server" SetLanguageCode="LabelApplicationDate" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataApplicationDate" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-resume-field">
                        <asp:Label ID="lbResume" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteResume" runat="server" SetLanguageCode="LabelResume" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:HyperLink ID="dataResume" runat="server" Text="Download" CssClass="form-textbox"></asp:HyperLink>
                            <asp:Literal ID="litResume" runat="server" />
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-coverletter-field">
                        <asp:Label ID="lbCoverLetter" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteCoverLetter" runat="server"
                                SetLanguageCode="LabelCoverLetter" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:HyperLink ID="dataCoverLetter" runat="server" Text="Download" CssClass="form-textbox"></asp:HyperLink>
                            <asp:Literal ID="litCoverLetter" runat="server" />
                        </div>
                    </div>
                    <asp:PlaceHolder ID="phPDF" runat="server" Visible="false">
                        <div class="form-line" id="jobapp-pdf-field">
                            <asp:Label ID="lbPDF" runat="server" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ucPDF" runat="server" SetLanguageCode="LabelCompletedApplication" />
                                :</asp:Label>
                            <div class="form-input">
                                <asp:LinkButton ID="dataPDF" runat="server" Text="PDF" CssClass="form-textbox" OnClick="dataPDF_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <div class="form-line" id="jobapp-firstname-field">
                        <asp:Label ID="lbFirstName" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteFirstName" runat="server" SetLanguageCode="LabelFirstName" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataFirstName" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-surname-field">
                        <asp:Label ID="lbSurname" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteSurname" runat="server" SetLanguageCode="LabelSurname" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataSurname" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-email-field">
                        <asp:Label ID="lbEmailAddress" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteEmailAdd" runat="server" SetLanguageCode="LabelEmailAddress" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:HyperLink ID="dataEmailAddress" runat="server" CssClass="form-textbox"></asp:HyperLink>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-mobilephone-field">
                        <asp:Label ID="lbMobilePhone" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserAppNoteMobilePhone" runat="server"
                                SetLanguageCode="LabelPhoneMobile" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataMobilePhone" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-note-field">
                        <asp:Label ID="lbNote" runat="server" CssClass="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelNote" />
                            :</asp:Label>
                        <div class="form-input">
                            <asp:Label ID="dataNote" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-referral-domain-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelReferralDomain" />
                            :</label>
                        <div class="form-input">
                            <asp:Label ID="dataReferral" runat="server" CssClass="form-textbox"></asp:Label>
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-status-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ucApplicationStatus" runat="server" SetLanguageCode="LabelApplicationStatus" />
                            :</label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlApplicationStatus" runat="server" CssClass="form-multiple-column" />
                        </div>
                    </div>
                    <div class="form-line" id="jobapp-grade-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="UcApplicantGrade" runat="server" SetLanguageCode="LabelApplicantGrade" />
                            :</label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlApplicantGrade" runat="server" CssClass="form-multiple-column" />
                        </div>
                    </div>
                    <asp:PlaceHolder ID="phScreeningQuestions" runat="server" Visible="false">
                        <div class="form-line" id="screening-questions-field">
                            <label class="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelScreeningQuestions" />
                                :</label>
                        </div>
                        <asp:Repeater ID="rptScreeningQuestions" runat="server" OnItemDataBound="rptScreeningQuestions_ItemDataBound">
                            <ItemTemplate>
                                <div class="form-line" id="screening-questions-field">
                                    <label class="form-label-left">
                                        <asp:Literal ID="ltQuestion" runat="server" />
                                        </label>
                                    <div class="form-input">
                                        <asp:Literal ID="ltAnswer" runat="server" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:PlaceHolder>
                    <div class="form-line" id="adv-bottom-button">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="mini-new-buttons" ClientIDMode="Static" />
                            <asp:Button ID="btnManage" runat="server" Text="Manage Applications" NavigateUrl="#"
                                CssClass="mini-new-buttons" OnClick="btnManage_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="mini-new-buttons"
                                OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
