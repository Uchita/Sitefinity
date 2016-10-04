<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Job.Master" AutoEventWireup="true"
    CodeBehind="ApplyJob_old.aspx.cs" Inherits="JXTPortal.Website.ApplyJob" %>

<%@ Register Src="~/usercontrols/job/ucContactDetails.ascx" TagName="ucContactDetails"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function OnCoverLetterSelection(rbNoCoverLetterId, rbWriteOneNowId, rbUploadCoverLetterId, rbExistingCoverLetterId) {
            var rbNoCoverLetter, rbWriteOneNowId, rbUploadCoverLetter, rbExistingCoverLetter;

            rbNoCoverLetter = document.getElementById(rbNoCoverLetterId);
            rbWriteOneNow = document.getElementById(rbWriteOneNowId);
            rbUploadCoverLetter = document.getElementById(rbUploadCoverLetterId);
            rbExistingCoverLetter = document.getElementById(rbExistingCoverLetterId);

            var divCoverLetterText = document.getElementById("ctl00_ContentPlaceHolder1_divCoverLetterText");
            if (!divCoverLetterText) {
                divCoverLetterText = document.getElementById("ContentPlaceHolder1_divCoverLetterText");
            }
            var divFileUploadCV = document.getElementById("ctl00_ContentPlaceHolder1_divFileUploadCV");
            if (!divFileUploadCV) {
                divFileUploadCV = document.getElementById("ContentPlaceHolder1_divFileUploadCV");
            }

            var divCoverLetter = document.getElementById("ctl00_ContentPlaceHolder1_divCoverLetter");
            if (!divCoverLetter) {
                divCoverLetter = document.getElementById("ContentPlaceHolder1_divCoverLetter");
            }

            if (rbNoCoverLetter.checked) {
                divCoverLetterText.style.display = "none";
                divFileUploadCV.style.display = "none";
                divCoverLetter.style.display = "none";
            }
            else if (rbWriteOneNow.checked) {
                divCoverLetterText.style.display = "block";
                divFileUploadCV.style.display = "none";
                divCoverLetter.style.display = "none";
            }
            else if (rbUploadCoverLetter.checked) {
                divCoverLetterText.style.display = "none";
                divFileUploadCV.style.display = "block";
                divCoverLetter.style.display = "none";
            }
            else {
                if (rbExistingCoverLetter) {
                    if (rbExistingCoverLetter.checked) {
                        divCoverLetterText.style.display = "none";
                        divFileUploadCV.style.display = "none";
                        divCoverLetter.style.display = "block";
                    }
                }
            }
        }

        function OnResumeSelection(rbUploadResumeId, rbNoResumeId, rbExistingResumeId, rbUseMyProfile) {
            var rbUploadResume, rbNoResume, rbExistingResume;

            rbUploadResume = document.getElementById(rbUploadResumeId);
            rbNoResume = document.getElementById(rbNoResumeId);
            rbExistingResume = document.getElementById(rbExistingResumeId);
            rbUseMyProfile = document.getElementById(rbUseMyProfile);

            var divFileUploadResume, divResume;

            divFileUploadResume = document.getElementById("ctl00_ContentPlaceHolder1_divFileUploadResume");
            if (!divFileUploadResume) {
                divFileUploadResume = document.getElementById("ContentPlaceHolder1_divFileUploadResume");
            }
            divResume = document.getElementById("ctl00_ContentPlaceHolder1_divResume");
            if (!divResume) {
                divResume = document.getElementById("ContentPlaceHolder1_divResume");
            }

            if (rbUploadResume.checked) {
                divFileUploadResume.style.display = "block";
                divResume.style.display = "none";
            }
            else if (rbNoResume.checked || rbUseMyProfile.checked) {
                divFileUploadResume.style.display = "none";
                divResume.style.display = "none";
            }
            else {
                if (rbExistingResume) {
                    if (rbExistingResume.checked) {
                        divFileUploadResume.style.display = "none";
                        divResume.style.display = "block";
                    }
                }
            }
        }
    </script>
    <div id="content">
        <div class="form-all">
            <!-- Referrer - <asp:Literal ID="ltReferrer" runat="server" /> -->
            <div class="uniForm">
                <fieldset class="inlineLabels">
                    <h1>
                        <asp:Literal ID="litJobName" runat="server" /></h1>
                    <div id="jobBreadCrumb">
                        <asp:HyperLink ID="hLinkJob" runat="server" />
                        -
                        <asp:HyperLink ID="hLinkProfession" runat="server" /></div>
                    <uc1:ucContactDetails ID="ucContactDetails1" runat="server" />
                    <%--<JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_ApplyJob" />--%>
                    <asp:Panel ID="pnlLoggedIn" runat="server">
                        <div class="ctrlHolder">
                            <p class="formHint">
                                <asp:Literal ID="litLoggedIn" runat="server" /></p>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlPeopleBank" runat="server" Visible="False">
                        <div class="ctrlHolder">
                            <label class="form-label-left">
                                Landline Number:<span class="form-required">*</span></label>
                            <asp:TextBox ID="txtLandline" runat="server" size="35" class="textInput" />
                            <p class="formHint">
                                <asp:RequiredFieldValidator ID="ReqVal_Landline" runat="server" ControlToValidate="txtLandline"
                                    SetFocusOnError="true" Display="Dynamic" Text="Landline is required" ValidationGroup="ValidationApplyJob" /><asp:CompareValidator
                                        ID="cv" runat="server" ControlToValidate="txtLandline" Type="Integer" Operator="DataTypeCheck"
                                        Display="Dynamic" ErrorMessage="Landline must be an integer" ValidationGroup="ValidationApplyJob" /></p>
                        </div>
                        <div class="ctrlHolder">
                            <label class="form-label-left">
                                State I Reside In:<span class="form-required">*</span></label>
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="ACT" Value="ACT"></asp:ListItem>
                                <asp:ListItem Text="NSW" Value="NSW"></asp:ListItem>
                                <asp:ListItem Text="NT" Value="NT"></asp:ListItem>
                                <asp:ListItem Text="QLD" Value="QLD"></asp:ListItem>
                                <asp:ListItem Text="SA" Value="SA"></asp:ListItem>
                                <asp:ListItem Text="TAS" Value="TAS"></asp:ListItem>
                                <asp:ListItem Text="VIC" Value="VIC"></asp:ListItem>
                                <asp:ListItem Text="WA" Value="WA"></asp:ListItem>
                                <asp:ListItem Text="I'm Overseas" Value="Overseas"></asp:ListItem>
                            </asp:DropDownList>
                            <p class="formHint">
                                <asp:RequiredFieldValidator ID="ReqVal_State" runat="server" ControlToValidate="ddlState"
                                    SetFocusOnError="true" Display="Dynamic" Text="State is required" ValidationGroup="ValidationApplyJob" /></p>
                        </div>
                        <div class="ctrlHolder">
                            <label class="form-label-left">
                                Residency Status:<span class="form-required">*</span></label>
                            <asp:DropDownList ID="ddlResidencyStatus" runat="server">
                                <asp:ListItem Text="Please Select" Value="" />
                                <asp:ListItem Text="Australian Citizen" Value="Australian Citizen"></asp:ListItem>
                                <asp:ListItem Text="Australian Permanent Resident" Value="Australian Permanent Resident"></asp:ListItem>
                                <asp:ListItem Text="NZ Citizen" Value="NZ Citizen"></asp:ListItem>
                                <asp:ListItem Text="International Applicant" Value="International Applicant"></asp:ListItem>
                                <asp:ListItem Text="International Applicant with Work Visa" Value="International Applicant with Work Visa"></asp:ListItem>
                            </asp:DropDownList>
                            <p class="formHint">
                                <asp:RequiredFieldValidator ID="ReqVal_ResidencyStatus" runat="server" ControlToValidate="ddlResidencyStatus"
                                    SetFocusOnError="true" Display="Dynamic" Text="Residency Status is required"
                                    ValidationGroup="ValidationApplyJob" /></p>
                        </div>
                    </asp:Panel>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ucApplyjobcoverletter" runat="server" SetLanguageCode="LabelCoverLetter" />
                    </h3>
                    <p>
                        <JXTControl:ucLanguageLiteral ID="ucApplyjobUploadCL" runat="server" SetLanguageCode="LabelOptionUploadCreateCover" />
                    </p>
                    <div class="ctrlHolder">
                        <p class="label">
                            <JXTControl:ucLanguageLiteral ID="ucApplyjobCoverLetter2" runat="server" SetLanguageCode="LabelCoverLetter" />
                        </p>
                        <ul class="blockLabels">
                            <li>
                                <label for="">
                                    <asp:RadioButton ID="rbNoCoverLetter" runat="server" Text="No Cover Letter" GroupName="CoverLetter"
                                        Checked="true" /></label></li>
                            <li>
                                <label for="">
                                    <asp:RadioButton ID="rbWriteOneNow" runat="server" GroupName="CoverLetter" /></label></li>
                            <li>
                                <label for="">
                                    <asp:RadioButton ID="rbUploadCoverLetter" runat="server" Text="Upload a cover letter from my computer"
                                        GroupName="CoverLetter" />
                                </label>
                            </li>
                            <li>
                                <label for="">
                                    <asp:RadioButton ID="rbExistingCoverLetter" runat="server" Text="Select Existing Cover Letter"
                                        GroupName="CoverLetter" />
                                </label>
                            </li>
                        </ul>
                    </div>
                    <div id="divCoverLetterText" class="ctrlHolder" runat="server" style="display: none;">
                        <label for="">
                            <JXTControl:ucLanguageLiteral ID="ltCLWrite" runat="server" SetLanguageCode="LabelWriteCoverLetter" />
                            :</label>
                        <asp:TextBox ID="txtCoverLetterText" runat="server" TextMode="MultiLine" Rows="5"
                            Columns="70" />
                        <p class="formHint">
                            <asp:CustomValidator ID="CusVal_CoverLetterText" runat="server" ErrorMessage="Cover Letter cannot be empty."
                                OnServerValidate="CusVal_CoverLetterText_ServerValidate" ValidationGroup="ValidationApplyJob" /></p>
                    </div>
                    <div id="divFileUploadCV" class="ctrlHolder" runat="server" style="display: none;">
                        <label for="">
                            <JXTControl:ucLanguageLiteral ID="ltCLUpload" runat="server" SetLanguageCode="LabelFileUpload" />
                        </label>
                        <asp:FileUpload ID="fileUploadCV" runat="server" />
                        <p class="formHint">
                            <JXTControl:ucLanguageLiteral ID="ltCLRestriction" runat="server" SetLanguageCode="LabelDocRestriction" />
                            <asp:CustomValidator ID="CusVal_FileUploadCV" runat="server" ErrorMessage="Please choose a cover letter."
                                OnServerValidate="CusVal_FileUploadCV_ServerValidate" ValidationGroup="ValidationApplyJob" /></p>
                    </div>
                    <br />
                    <div id="divCoverLetter" class="ctrlHolder" runat="server" style="display: none;">
                        <asp:DropDownList ID="ddlCoverLetter" runat="server" DataValueField="MemberFileID"
                            DataTextField="MemberFileTitle" />
                        <p class="formHint">
                            <asp:CustomValidator ID="CusVal_CoverLetter" runat="server" ErrorMessage="Please choose a cover letter."
                                OnServerValidate="CusVal_CoverLetter_ServerValidate" ValidationGroup="ValidationApplyJob" /></p>
                    </div>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltApplyJobResumeHeader" runat="server" SetLanguageCode="LabelResume" />
                    </h3>
                    <p>
                        <JXTControl:ucLanguageLiteral ID="ltApplyJoboptionuploadresume" runat="server" SetLanguageCode="LabelOptionUploadResume" />
                    </p>
                    <div class="ctrlHolder">
                        <p class="label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelResume" />
                        </p>
                        <ul class="blockLabels">
                            <li>
                                <label for="">
                                    <asp:RadioButton ID="rbUploadResume" runat="server" Text="Upload a resume from my computer"
                                        GroupName="Resume" Checked="true" /></label></li>
                            <li>
                                <label for="">
                                    <asp:RadioButton ID="rbNoResume" runat="server" Text="No Resume" GroupName="Resume" /></label></li>
                            <li>
                                <label for="">
                                    <asp:RadioButton ID="rbExistingResume" runat="server" Text="Select Existing Resume"
                                        GroupName="Resume" /></label></li>
                            <asp:PlaceHolder ID="phUseMyPorfile" runat="server" Visible="false">
                                <li>
                                    <label for="">
                                        <asp:RadioButton ID="rbUseMyProfile" runat="server" Text="Use my profile" GroupName="Resume" />
                                    </label>
                                </li>
                            </asp:PlaceHolder>
                        </ul>
                    </div>
                    <div id="divFileUploadResume" runat="server" class="ctrlHolder" style="display: block;">
                        <label for="">
                            <JXTControl:ucLanguageLiteral ID="ltResumeUpload" runat="server" SetLanguageCode="LabelFileUpload" />
                        </label>
                        <asp:FileUpload ID="fileUploadResume" runat="server" />
                        <p class="formHint">
                            <JXTControl:ucLanguageLiteral ID="ltResumeRestriction" runat="server" SetLanguageCode="LabelDocRestriction" />
                            <asp:CustomValidator ID="CusVal_FileUploadResume" runat="server" ErrorMessage="Please choose a resume."
                                OnServerValidate="CusVal_FileUploadResume_ServerValidate" ValidationGroup="ValidationApplyJob" /></p>
                    </div>
                    <div id="divResume" runat="server" class="ctrlHolder" style="display: none;">
                        <asp:DropDownList ID="ddlResume" runat="server" DataValueField="MemberFileID" DataTextField="MemberFileTitle" />
                        <p class="formHint">
                            <asp:CustomValidator ID="CusVal_Resume" runat="server" ErrorMessage="Please choose a resume."
                                OnServerValidate="CusVal_Resume_ServerValidate" ValidationGroup="ValidationApplyJob" />
                        </p>
                    </div>
                    <div id="divJobApply-Jobalert">
                        <h3>
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelJobAlert" />
                        </h3>
                        <div class="ctrlHolder">
                            <p class="label">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelReceiveJobAlert" />
                                :</p>
                            <ul class="blockLabels">
                                <li>
                                    <label for="">
                                        <asp:RadioButton ID="rbJobAlertYes" runat="server" Text="Yes, send me a Daily Job Alert"
                                            GroupName="JobAlert" Checked="false" /></label></li>
                                <li>
                                    <label for="">
                                        <asp:RadioButton ID="rbJobAlertNo" runat="server" Text="No, do not send me a Daily Job Alert"
                                            GroupName="JobAlert" Checked="true" /></label></li>
                            </ul>
                        </div>
                    </div>
                    <div class="buttonHolder">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="ApplyButton" runat="server" CausesValidation="True" Text="Apply"
                                CssClass="mini-new-buttons" OnClick="ApplyButton_Click" ValidationGroup="ValidationApplyJob" />
                            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" Text="Cancel"
                                CssClass="mini-new-buttons" />
                        </div>
                    </div>
                    <p class="formHint">
                        <span class="form-required">
                            <asp:Literal ID="litMessage" runat="server" /></span></p>
                    <JXTControl:ucPrivacySettings ID="ucPrivacySettings" runat="server" />
                </fieldset>
            </div>
        </div>
    </div>
    <style type="text/css">
        .uniForm .inlineLabels ul li label
        {
            float: none !important;
            display: inline !important;
            width: 100%;
            margin-left: 5px !important;
            font-size: 1em !important;
        }
    </style>
</asp:Content>
