<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="True" Inherits="MemberWizard" Title="Member Profile Wizard" CodeBehind="MemberWizard.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Member Profile Wizard</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">

        <h2>Member Profile Settings</h2>
        <asp:Literal ID="ltSettingsMessage" runat="server" />
        <ul class="form-section">
            <li class="form-line" id="Li7">
                <label class="form-label-left">
                    Minimum Profile Experiences:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlMinExperience" runat="server"></asp:DropDownList>
                </div>
            </li>
            <li class="form-line" id="Li8">
                <label class="form-label-left">
                    Minimum Profile Educations:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlMinEducation" runat="server"></asp:DropDownList>
                </div>
            </li>

            <li class="form-line" id="Li9">
                <label class="form-label-left">
                    Minimum Profile References:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlMinReference" runat="server"></asp:DropDownList>
                </div>
            </li>
        </ul>

        <h2>Member Profile Wizard Options</h2>
        <asp:Literal ID="ltlWizard" runat="server" />
        <asp:Literal ID="ltlMessage" runat="server" />
        <ul class="form-section">
            <li class="form-line" id="Li39"><span style="display: inline-block; width: 166px; font-weight: bold;">Section Name</span> 
                <span style="display: inline-block; width: 60px; font-weight: bold;">Enabled</span> 
                <span style="display: inline-block; width: 410px; font-weight: bold;">Section Label</span> 
                <span style="display: inline-block; width: 100px; font-weight: bold;">Percentage(%)</span> 
                <span style="display: inline-block; font-weight: bold;">Info</span>                 
                </li>
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    On Registration:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbProfileTitle" runat="server" AutoPostBack="false" Checked="true"
                        Enabled="false" />
                    <asp:TextBox ID="txtProfileTitle" runat="server" Width="400" Enabled="false" />
                    <asp:TextBox ID="txtProfilePoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                </div>
            </li>
            <li class="form-line" id="Li15">
                <label class="form-label-left">
                    Summary Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbSummaryTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtSummaryTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtSummaryPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtSummaryInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li16">
                <label class="form-label-left">
                    Personal Details Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbPersonalDetailsTitle" runat="server" AutoPostBack="false" Checked="true"
                        Enabled="false" />
                    <asp:TextBox ID="txtPersonalDetailsTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtPersonalDetailsPoints" runat="server" Width="80" MaxLength="3"
                        onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtPersonalDetailsInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li13">
                <label class="form-label-left">
                    Directorship Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbDirectorshipTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtDirectorshipTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtDirectorshipPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtDirectorshipInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li5">
                <label class="form-label-left">
                    Experience Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbExperienceTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtExperienceTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtExperiencePoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtExperienceInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li3">
                <label class="form-label-left">
                    Education Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbEducationTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtEducationTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtEducationPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtEducationInfo" runat="server" Width="400" MaxLength="255" />
                    <asp:PlaceHolder ID="phManageableFields_qualification" runat="server" Visible="false"><a href="memberprofilemanageablefields.aspx">Add / Edit Qualification Names</a></asp:PlaceHolder>
                </div>
            </li>
            <li class="form-line" id="Li6">
                <label class="form-label-left">
                    Skills Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbSkillsTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtSkillsTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtSkillsPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtSkillsInfo" runat="server" Width="400" MaxLength="255" />
                    <asp:PlaceHolder ID="phManageableFields_skills" runat="server" Visible="false"><a href="memberprofilemanageablefields.aspx">Add / Edit Skills</a></asp:PlaceHolder>
                </div>
            </li>
            <li class="form-line" id="Li4">
                <label class="form-label-left">
                    Certificates & Memberships Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbMembershipsTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtMembershipsTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtMembershipsPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtMembershipsInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li17">
                <label class="form-label-left">
                    Licenses Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbLicensesTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtLicensesTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtLicensesPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtLicensesInfo" runat="server" Width="400" MaxLength="255" />
                    <asp:PlaceHolder ID="phManageableFields_licence" runat="server" Visible="false"><a href="memberprofilemanageablefields.aspx">Add / Edit Licence Types</a></asp:PlaceHolder>
                </div>
            </li>
            <li class="form-line" id="Li2">
                <label class="form-label-left">
                    Role Preferences Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbRolePreferencesTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtRolePreferencesTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtRolePreferencesPoints" runat="server" Width="80" MaxLength="3"
                        onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtRolePreferencesInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Attach Resume Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbCVTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtCVTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtCVPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtCVInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li18">
                <label class="form-label-left">
                    Attach Cover Letter Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbAttachCoverLetterTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtAttachCoverLetterTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtAttachCoverLetterPoints" runat="server" Width="80" MaxLength="3"
                        onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtAttachCoverLetterInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li19">
                <label class="form-label-left">
                    Languages Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbLanguagesTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtLanguagesTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtLanguagesPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtLanguagesInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li20">
                <label class="form-label-left">
                    References Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbReferencesTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtReferencesTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtReferencesPoints" runat="server" Width="80" MaxLength="3" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtReferencesInfo" runat="server" Width="400" MaxLength="255" />
                </div>
            </li>
            <li class="form-line" id="Li21">
                <label class="form-label-left">
                    Custom Questions Title:
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="cbCustomQuestionTitle" runat="server" AutoPostBack="false" />
                    <asp:TextBox ID="txtCustomQuestionTitle" runat="server" Width="400" />
                    <asp:TextBox ID="txtCustomQuestionPoints" runat="server" Width="80" MaxLength="3" Visible="true" Enabled="false" 
                        onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || event.charCode == 0)" />
                    <asp:TextBox ID="txtCustomQuestionInfo" runat="server" Width="400" MaxLength="255" />
                    <asp:PlaceHolder ID="phCustomQuestions" runat="server" Visible="false"><a href="CustomQuestions.aspx">Add / Edit Custom Questions</a></asp:PlaceHolder>
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Last Modified:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModified" runat="server" Text="" />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Last Modified By:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModifiedBy" runat="server" Text="" />
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Save Wizard" OnClick="btnSave_Click"
                            CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
        <asp:PlaceHolder ID="phMultilingual" runat="server" Visible="false">
            <asp:ScriptManager ID="scriptManager" runat="server" />
            <asp:UpdatePanel ID="upMultiLingual" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <h2>
                        Multilingual Titles</h2>
                    
                        <asp:Literal ID="ltMultilingualMessage" runat="server" />
                    <asp:Repeater ID="rptMultilingual" runat="server" OnItemDataBound="rptMultilingual_ItemDataBound"
                        OnItemCommand="rptMultilingual_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbLanguage" runat="server" CommandName="Language" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="form-section">
                        <li class="form-line" id="Li31">
                            <label class="form-label-left">
                                Summary Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiSummary" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiSummaryInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li32">
                            <label class="form-label-left">
                                Personal Details Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiPersonalDetails" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiPersonalDetailsInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li30">
                            <label class="form-label-left">
                                Directorship Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiDirectorship" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiDirectorshipInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li28">
                            <label class="form-label-left">
                                Experience Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiExperience" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiExperienceInfo" runat="server" Width="400" />
                            </div>
                        </li>
                         <li class="form-line" id="Li26">
                            <label class="form-label-left">
                                Education Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiEducation" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiEducationInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li29">
                            <label class="form-label-left">
                                Skills Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiSkills" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiSkillsInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li27">
                            <label class="form-label-left">
                                Certificates & Memberships Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiMemberships" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiMembershipsInfo" runat="server" Width="400" />
                            </div>
                        </li>
                       
                        <li class="form-line" id="Li33">
                            <label class="form-label-left">
                                Licenses Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiLicenses" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiLicensesInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li25">
                            <label class="form-label-left">
                                Role Preferences Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiRolePreferences" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiRolePreferencesInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li24">
                            <label class="form-label-left">
                                Attach Resume Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiCV" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiCVInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li34">
                            <label class="form-label-left">
                                Attach Cover Letter Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiAttachCoverLetter" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiAttachCoverLetterInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li35">
                            <label class="form-label-left">
                                Languages Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiLanguages" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiLanguagesInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li36">
                            <label class="form-label-left">
                                References Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiReferences" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiReferencesInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li37">
                            <label class="form-label-left">
                                Custom Quesiton Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiCustomQuestion" runat="server" Width="400" />
                                <asp:TextBox ID="txtMultiCustomQuestionInfo" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li38">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnMultilingualSave" runat="server" Text="Save" OnClick="btnMultilingualSave_Click"
                                        CssClass="jxtadminbutton" ValidationGroup="MultiLingual" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:PlaceHolder>
    </div>
</asp:Content>
