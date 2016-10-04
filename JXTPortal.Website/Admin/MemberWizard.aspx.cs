

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using System.IO;
using System.Xml;
#endregion

public partial class MemberWizard : System.Web.UI.Page
{
    #region Declare variables

    private MemberWizardService _memberWizardService = null;
    private SiteLanguagesService _siteLanguagesService = null;
    private List<MemberWizardContainer> MemberWizardContainerList = null;
    #endregion

    #region Properties

    int MemberWizardId = 0;
    private MemberWizardService MemberWizardService
    {
        get
        {
            if (_memberWizardService == null)
                _memberWizardService = new MemberWizardService();
            return _memberWizardService;
        }
    }

    private SiteLanguagesService SiteLanguagesService
    {
        get
        {
            if (_siteLanguagesService == null)
                _siteLanguagesService = new SiteLanguagesService();
            return _siteLanguagesService;
        }
    }

    internal class MemberWizardContainer
    {
        public int LanguageId { get; set; }
        public string Profile { get; set; }
        public string CV { get; set; }
        public string RolePreferences { get; set; }
        public string Education { get; set; }
        public string Memberships { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string Directorship { get; set; }
        public string Summary { get; set; }
        public string PersonalDetails { get; set; }
        public string Licenses { get; set; }
        public string AttachCoverLetter { get; set; }
        public string Languages { get; set; }
        public string References { get; set; }
        public string CustomQuestion { get; set; }
        public string ProfileInfo { get; set; }
        public string CVInfo { get; set; }
        public string RolePreferencesInfo { get; set; }
        public string EducationInfo { get; set; }
        public string MembershipsInfo { get; set; }
        public string ExperienceInfo { get; set; }
        public string SkillsInfo { get; set; }
        public string DirectorshipInfo { get; set; }
        public string SummaryInfo { get; set; }
        public string PersonalDetailsInfo { get; set; }
        public string LicensesInfo { get; set; }
        public string AttachCoverLetterInfo { get; set; }
        public string LanguagesInfo { get; set; }
        public string ReferencesInfo { get; set; }
        public string CustomQuestionInfo { get; set; }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadMemberWizard();
            //LoadLanguages();

            /*int? memberPoints = 0;

            MemberWizardService.CustomGetMemberPoints(SessionData.Site.SiteId, 237101, ref memberPoints);

            Response.Write(memberPoints.Value);*/
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ltlMessage.Text = string.Empty;
        MemberWizardId = GetMemberWizardID();

        if (Page.IsValid)
        {
            JXTPortal.Entities.MemberWizard memberWizard = null;
            if (MemberWizardId > 0)
            {
                memberWizard = MemberWizardService.GetByMemberWizardId(MemberWizardId);
            }
            else
            {
                memberWizard = new JXTPortal.Entities.MemberWizard();
            }


            if (memberWizard != null)
            {
                #region Member Profile Settings

                memberWizard.MinEducationsEntry = short.Parse(ddlMinEducation.SelectedValue);
                memberWizard.MinExperiencesEntry = short.Parse(ddlMinExperience.SelectedValue);
                memberWizard.MinReferencesEntry = short.Parse(ddlMinReference.SelectedValue);

                #endregion

                #region Member Profile Wizard Options
                int profilepoint = 0, cvpoint = 0, rolepreferencespoint = 0, educationpoint = 0, membershipspoint = 0, directiorshippoint = 0,
                    experiencepoint = 0, skillspoint = 0, summarypoint = 0, personaldetailspoint = 0, licensespoint = 0, attachcoverletterpoint = 0,
                    languagespoint = 0, referencespoint = 0, customquestionpoint = 0;
                string missingmsg = "<p class='msg warning'>Section Label(s) & Percentage(s) needs to be filled when checkbox is checked</p>";

                if (cbProfileTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtProfilePoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    profilepoint = Convert.ToInt32(txtProfilePoints.Text);
                }

                if (cbCVTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtCVTitle.Text) || string.IsNullOrWhiteSpace(txtCVPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }
                    cvpoint = Convert.ToInt32(txtCVPoints.Text);
                }

                if (cbRolePreferencesTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtRolePreferencesTitle.Text) || string.IsNullOrWhiteSpace(txtRolePreferencesPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }
                    rolepreferencespoint = Convert.ToInt32(txtRolePreferencesPoints.Text);
                }

                if (cbEducationTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtEducationTitle.Text) || string.IsNullOrWhiteSpace(txtEducationPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    educationpoint = Convert.ToInt32(txtEducationPoints.Text);
                }

                if (cbMembershipsTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtMembershipsTitle.Text) || string.IsNullOrWhiteSpace(txtMembershipsPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }
                    membershipspoint = Convert.ToInt32(txtMembershipsPoints.Text);
                }

                if (cbDirectorshipTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtDirectorshipTitle.Text) || string.IsNullOrWhiteSpace(txtDirectorshipPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    directiorshippoint = Convert.ToInt32(txtDirectorshipPoints.Text);
                }

                if (cbExperienceTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtExperienceTitle.Text) || string.IsNullOrWhiteSpace(txtExperiencePoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    experiencepoint = Convert.ToInt32(txtExperiencePoints.Text);
                }

                if (cbSkillsTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtSkillsTitle.Text) || string.IsNullOrWhiteSpace(txtSkillsPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    skillspoint = Convert.ToInt32(txtSkillsPoints.Text);
                }

                if (cbSummaryTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtSummaryTitle.Text) || string.IsNullOrWhiteSpace(txtSummaryPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    summarypoint = Convert.ToInt32(txtSummaryPoints.Text);
                }

                if (cbPersonalDetailsTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtPersonalDetailsTitle.Text) || string.IsNullOrWhiteSpace(txtPersonalDetailsPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    personaldetailspoint = Convert.ToInt32(txtPersonalDetailsPoints.Text);
                }

                if (cbLicensesTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtLicensesTitle.Text) || string.IsNullOrWhiteSpace(txtLicensesPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    licensespoint = Convert.ToInt32(txtLicensesPoints.Text);
                }

                if (cbAttachCoverLetterTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtAttachCoverLetterTitle.Text) || string.IsNullOrWhiteSpace(txtAttachCoverLetterPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    attachcoverletterpoint = Convert.ToInt32(txtAttachCoverLetterPoints.Text);
                }

                if (cbLanguagesTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtLanguagesTitle.Text) || string.IsNullOrWhiteSpace(txtLanguagesPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    languagespoint = Convert.ToInt32(txtLanguagesPoints.Text);
                }

                if (cbReferencesTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtReferencesTitle.Text) || string.IsNullOrWhiteSpace(txtReferencesPoints.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    referencespoint = Convert.ToInt32(txtReferencesPoints.Text);
                }

                if (cbCustomQuestionTitle.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtCustomQuestionTitle.Text))
                    {
                        ltlMessage.Text = missingmsg;
                        return;
                    }

                    //customquestionpoint = Convert.ToInt32(txtCustomQuestionPoints.Text);
                }

                int totalpoint = profilepoint + cvpoint + rolepreferencespoint + educationpoint + membershipspoint + directiorshippoint +
                    experiencepoint + skillspoint + summarypoint + personaldetailspoint + licensespoint + attachcoverletterpoint +
                    languagespoint + referencespoint; // +customquestionpoint;

                if (totalpoint != 100)
                {
                    ltlMessage.Text = "<p class='msg warning'>Total points needs to be 100 instead of " + totalpoint + "</p>";
                    return;
                }


                //memberWizard.ProfileTitle = txtProfileTitle.Text;
                memberWizard.ProfilePoints = (cbProfileTitle.Checked) ? profilepoint : -1;
                memberWizard.CvTitle = txtCVTitle.Text;
                memberWizard.CvPoints = (cbCVTitle.Checked) ? cvpoint : -1;
                memberWizard.RolePreferencesTitle = txtRolePreferencesTitle.Text;
                memberWizard.RolePreferencesPoints = (cbRolePreferencesTitle.Checked) ? rolepreferencespoint : -1;
                memberWizard.EducationTitle = txtEducationTitle.Text;
                memberWizard.EducationPoints = (cbEducationTitle.Checked) ? educationpoint : -1;
                memberWizard.MembershipsTitle = txtMembershipsTitle.Text;
                memberWizard.MembershipsPoints = (cbMembershipsTitle.Checked) ? membershipspoint : -1;
                memberWizard.DirectorshipTitle = txtDirectorshipTitle.Text ?? string.Empty;
                memberWizard.DirectorshipPoints = (cbDirectorshipTitle.Checked) ? directiorshippoint : -1;
                memberWizard.ExperienceTitle = txtExperienceTitle.Text;
                memberWizard.ExperiencePoints = (cbExperienceTitle.Checked) ? experiencepoint : -1;
                memberWizard.SkillsTitle = txtSkillsTitle.Text;
                memberWizard.SkillsPoints = (cbSkillsTitle.Checked) ? skillspoint : -1;

                memberWizard.SummaryTitle = txtSummaryTitle.Text;
                memberWizard.SummaryPoints = (cbSummaryTitle.Checked) ? summarypoint : -1;
                memberWizard.PersonalDetailsTitle = txtPersonalDetailsTitle.Text;
                memberWizard.PersonalDetailsPoints = (cbPersonalDetailsTitle.Checked) ? personaldetailspoint : -1;
                memberWizard.LicensesTitle = txtLicensesTitle.Text;
                memberWizard.LicensesPoints = (cbLicensesTitle.Checked) ? licensespoint : -1;
                memberWizard.AttachCoverLetterTitle = txtAttachCoverLetterTitle.Text;
                memberWizard.AttachCoverLetterPoints = (cbAttachCoverLetterTitle.Checked) ? attachcoverletterpoint : -1;
                memberWizard.LanguagesTitle = txtLanguagesTitle.Text;
                memberWizard.LanguagesPoints = (cbLanguagesTitle.Checked) ? languagespoint : -1;
                memberWizard.ReferencesTitle = txtReferencesTitle.Text;
                memberWizard.ReferencesPoints = (cbReferencesTitle.Checked) ? referencespoint : -1;
                memberWizard.CustomQuestionTitle = txtCustomQuestionTitle.Text;
                memberWizard.CustomQuestionPoints = (cbCustomQuestionTitle.Checked) ? customquestionpoint : -1;

                // Write Info
                StringBuilder xml = new StringBuilder();
                if (string.IsNullOrWhiteSpace(memberWizard.WizardLanguageXml))
                {
                    xml.AppendLine("<MemberWizards>");
                    xml.AppendLine("</MemberWizards>");
                }
                else
                {
                    xml = new StringBuilder(memberWizard.WizardLanguageXml);
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml.ToString());

                System.Xml.XmlNodeList infolist = xmldoc.GetElementsByTagName("Info");
                System.Xml.XmlNode infonode = null;
                if (infolist != null && infolist.Count == 0)
                {
                    XmlElement memberwizardelement = xmldoc["MemberWizards"];
                    XmlNode newnode = xmldoc.CreateElement("Info");

                    infonode = memberwizardelement.AppendChild(newnode);
                }
                else
                {
                    infonode = infolist.Item(0);
                }
                string infofields = string.Format(@"<CV>{0}</CV>
                                                    <RolePreferences>{1}</RolePreferences>
                                                    <Education>{2}</Education>
                                                    <Memberships>{3}</Memberships>
                                                    <Experience>{4}</Experience>
                                                    <Skills>{5}</Skills>
                                                    <Directorship>{6}</Directorship>
                                                    <Summary>{7}</Summary>
                                                    <PersonalDetails>{8}</PersonalDetails>
                                                    <Licenses>{9}</Licenses>
                                                    <AttachCoverLetter>{10}</AttachCoverLetter>
                                                    <Languages>{11}</Languages>
                                                    <References>{12}</References>
                                                    <CustomQuestion>{13}</CustomQuestion>",
                                                    HttpUtility.HtmlEncode(txtCVInfo.Text),
                                                    HttpUtility.HtmlEncode(txtRolePreferencesInfo.Text),
                                                    HttpUtility.HtmlEncode(txtEducationInfo.Text),
                                                    HttpUtility.HtmlEncode(txtMembershipsInfo.Text),
                                                    HttpUtility.HtmlEncode(txtExperienceInfo.Text),
                                                    HttpUtility.HtmlEncode(txtSkillsInfo.Text),
                                                    HttpUtility.HtmlEncode(txtDirectorshipInfo.Text),
                                                    HttpUtility.HtmlEncode(txtSummaryInfo.Text),
                                                    HttpUtility.HtmlEncode(txtPersonalDetailsInfo.Text),
                                                    HttpUtility.HtmlEncode(txtLicensesInfo.Text),
                                                    HttpUtility.HtmlEncode(txtAttachCoverLetterInfo.Text),
                                                    HttpUtility.HtmlEncode(txtLanguagesInfo.Text),
                                                    HttpUtility.HtmlEncode(txtReferencesInfo.Text),
                                                    HttpUtility.HtmlEncode(txtCustomQuestionInfo.Text)
                                                    );

                infonode.InnerXml = infofields;

                memberWizard.WizardLanguageXml = xmldoc.OuterXml;


                memberWizard.SiteId = SessionData.Site.SiteId;
                memberWizard.LastModified = DateTime.Now;
                memberWizard.LastModifiedBy = SessionData.AdminUser.AdminUserId;

                #endregion

                if (MemberWizardId > 1)
                {
                    //if (memberWizard.GlobalTemplate)

                    memberWizard.MemberWizardId = MemberWizardId;

                    MemberWizardService.Update(memberWizard);
                    ltSettingsMessage.Text = "<p class='msg done'>Member Profile Settings has been updated.</p>";
                    ltlMessage.Text = "<p class='msg done'>Member Profile Wizard Options has been updated.</p>";
                }
                else
                {
                    memberWizard.GlobalTemplate = false;

                    MemberWizardService.Insert(memberWizard);
                    ltSettingsMessage.Text = "<p class='msg done'>Member Profile Settings has been overwritten.</p>";
                    ltlMessage.Text = "<p class='msg done'>Member Profile Wizard Options has been overwritten.</p>";
                }
            }

            LoadMemberWizard();
            LoadLanguages();
        }
    }

    protected void btnMultilingualSave_Click(object sender, EventArgs e)
    {
        ltMultilingualMessage.Text = string.Empty;

        LoadMultilingualValues();
        MemberWizardId = GetMemberWizardID();

        int langid = 0;
        string langname = string.Empty;

        foreach (RepeaterItem ri in rptMultilingual.Items)
        {
            LinkButton lbLanguage = ri.FindControl("lbLanguage") as LinkButton;
            if (lbLanguage.Enabled == false)
            {
                langid = Convert.ToInt32(lbLanguage.CommandArgument);
                langname = lbLanguage.Text;
            }
        }

        foreach (MemberWizardContainer container in MemberWizardContainerList)
        {
            if (container.LanguageId == langid)
            {
                container.CV = txtMultiCV.Text;
                container.RolePreferences = txtMultiRolePreferences.Text;
                container.Education = txtMultiEducation.Text;
                container.Memberships = txtMultiMemberships.Text;
                container.Experience = txtMultiExperience.Text;
                container.Skills = txtMultiSkills.Text;
                container.Directorship = txtMultiDirectorship.Text;
                container.Summary = txtMultiSummary.Text;
                container.PersonalDetails = txtMultiPersonalDetails.Text;
                container.Licenses = txtMultiLicenses.Text;
                container.AttachCoverLetter = txtMultiAttachCoverLetter.Text;
                container.Languages = txtMultiLanguages.Text;
                container.References = txtMultiReferences.Text;
                container.CustomQuestion = txtMultiCustomQuestion.Text;
                container.CVInfo = txtMultiCVInfo.Text;
                container.RolePreferencesInfo = txtMultiRolePreferencesInfo.Text;
                container.EducationInfo = txtMultiEducationInfo.Text;
                container.MembershipsInfo = txtMultiMembershipsInfo.Text;
                container.ExperienceInfo = txtMultiExperienceInfo.Text;
                container.SkillsInfo = txtMultiSkillsInfo.Text;
                container.DirectorshipInfo = txtMultiDirectorshipInfo.Text;
                container.SummaryInfo = txtMultiSummaryInfo.Text;
                container.PersonalDetailsInfo = txtMultiPersonalDetailsInfo.Text;
                container.LicensesInfo = txtMultiLicensesInfo.Text;
                container.AttachCoverLetterInfo = txtMultiAttachCoverLetterInfo.Text;
                container.LanguagesInfo = txtMultiLanguagesInfo.Text;
                container.ReferencesInfo = txtMultiReferencesInfo.Text;
                container.CustomQuestionInfo = txtMultiCustomQuestionInfo.Text;
            }
        }


        JXTPortal.Entities.MemberWizard memberWizard = null;
        if (MemberWizardId > 0)
        {
            memberWizard = MemberWizardService.GetByMemberWizardId(MemberWizardId);
        }
        else
        {
            memberWizard = MemberWizardService.GetAll().Find(s => s.GlobalTemplate.Equals(true));
        }

        if (memberWizard != null)
        {

            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<MemberWizards>");

            foreach (MemberWizardContainer container in MemberWizardContainerList)
            {
                xml.AppendLine("<MemberWizard>");
                xml.AppendLine("<LanguageID>" + container.LanguageId.ToString() + "</LanguageID>");
                xml.AppendLine("<Profile>" + HttpUtility.HtmlEncode(container.Profile) + "</Profile>");
                xml.AppendLine("<CV>" + HttpUtility.HtmlEncode(container.CV) + "</CV>");
                xml.AppendLine("<RolePreferences>" + HttpUtility.HtmlEncode(container.RolePreferences) + "</RolePreferences>");
                xml.AppendLine("<Education>" + HttpUtility.HtmlEncode(container.Education) + "</Education>");
                xml.AppendLine("<Memberships>" + HttpUtility.HtmlEncode(container.Memberships) + "</Memberships>");
                xml.AppendLine("<Experience>" + HttpUtility.HtmlEncode(container.Experience) + "</Experience>");
                xml.AppendLine("<Skills>" + HttpUtility.HtmlEncode(container.Skills) + "</Skills>");
                xml.AppendLine("<Directorship>" + HttpUtility.HtmlEncode(container.Directorship) + "</Directorship>");
                xml.AppendLine("<Summary>" + HttpUtility.HtmlEncode(container.Summary) + "</Summary>");
                xml.AppendLine("<PersonalDetails>" + HttpUtility.HtmlEncode(container.PersonalDetails) + "</PersonalDetails>");
                xml.AppendLine("<Licenses>" + HttpUtility.HtmlEncode(container.Licenses) + "</Licenses>");
                xml.AppendLine("<AttachCoverLetter>" + HttpUtility.HtmlEncode(container.AttachCoverLetter) + "</AttachCoverLetter>");
                xml.AppendLine("<Languages>" + HttpUtility.HtmlEncode(container.Languages) + "</Languages>");
                xml.AppendLine("<References>" + HttpUtility.HtmlEncode(container.References) + "</References>");
                xml.AppendLine("<CustomQuestion>" + HttpUtility.HtmlEncode(container.CustomQuestion) + "</CustomQuestion>");
                xml.AppendLine("<LanguageID>" + container.LanguageId.ToString() + "</LanguageID>");
                xml.AppendLine("<ProfileInfo>" + HttpUtility.HtmlEncode(container.ProfileInfo) + "</ProfileInfo>");
                xml.AppendLine("<CVInfo>" + HttpUtility.HtmlEncode(container.CVInfo) + "</CVInfo>");
                xml.AppendLine("<RolePreferencesInfo>" + HttpUtility.HtmlEncode(container.RolePreferencesInfo) + "</RolePreferencesInfo>");
                xml.AppendLine("<EducationInfo>" + HttpUtility.HtmlEncode(container.EducationInfo) + "</EducationInfo>");
                xml.AppendLine("<MembershipsInfo>" + HttpUtility.HtmlEncode(container.MembershipsInfo) + "</MembershipsInfo>");
                xml.AppendLine("<ExperienceInfo>" + HttpUtility.HtmlEncode(container.ExperienceInfo) + "</ExperienceInfo>");
                xml.AppendLine("<SkillsInfo>" + HttpUtility.HtmlEncode(container.SkillsInfo) + "</SkillsInfo>");
                xml.AppendLine("<DirectorshipInfo>" + HttpUtility.HtmlEncode(container.DirectorshipInfo) + "</DirectorshipInfo>");
                xml.AppendLine("<SummaryInfo>" + HttpUtility.HtmlEncode(container.SummaryInfo) + "</SummaryInfo>");
                xml.AppendLine("<PersonalDetailsInfo>" + HttpUtility.HtmlEncode(container.PersonalDetailsInfo) + "</PersonalDetailsInfo>");
                xml.AppendLine("<LicensesInfo>" + HttpUtility.HtmlEncode(container.LicensesInfo) + "</LicensesInfo>");
                xml.AppendLine("<AttachCoverLetterInfo>" + HttpUtility.HtmlEncode(container.AttachCoverLetterInfo) + "</AttachCoverLetterInfo>");
                xml.AppendLine("<LanguagesInfo>" + HttpUtility.HtmlEncode(container.LanguagesInfo) + "</LanguagesInfo>");
                xml.AppendLine("<ReferencesInfo>" + HttpUtility.HtmlEncode(container.ReferencesInfo) + "</ReferencesInfo>");
                xml.AppendLine("<CustomQuestionInfo>" + HttpUtility.HtmlEncode(container.CustomQuestionInfo) + "</CustomQuestionInfo>");
                xml.AppendLine("</MemberWizard>");
            }
            if (!string.IsNullOrWhiteSpace(memberWizard.WizardLanguageXml))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(memberWizard.WizardLanguageXml);

                System.Xml.XmlNodeList infolist = xmldoc.GetElementsByTagName("Info");
                if (infolist != null && infolist.Count  > 0)
                {
                    xml.AppendLine(infolist.Item(0).OuterXml);
                }
            }

            xml.AppendLine("</MemberWizards>");


            memberWizard.WizardLanguageXml = xml.ToString();

            MemberWizardService.Update(memberWizard);

            ltMultilingualMessage.Text = "<p class='msg done'>Member Wizard " + HttpUtility.HtmlEncode(langname) + " has been updated.</p>";
        }

    }

    #endregion

    #region Methods

    private int GetMemberWizardID()
    {
        int memberWizardID = 0;

        using (TList<JXTPortal.Entities.MemberWizard> memberWizards = MemberWizardService.GetAll())
        {
            JXTPortal.Entities.MemberWizard memberWizard = memberWizards.Find(s => s.SiteId.Equals(SessionData.Site.SiteId)); //&& s.GlobalTemplate.Equals(false)

            if (memberWizard != null)
                memberWizardID = memberWizard.MemberWizardId;
        }

        return memberWizardID;

    }

    private void LoadMemberWizard()
    {
        MemberWizardId = GetMemberWizardID();

        bool blnLanguages = false;

        JXTPortal.Entities.MemberWizard memberWizard = new JXTPortal.Entities.MemberWizard();
        if (MemberWizardId > 0)
        {
            memberWizard = MemberWizardService.GetByMemberWizardId(MemberWizardId);
            if (memberWizard.GlobalTemplate)
                ltlWizard.Text = "<p class='msg info'>Current site is the <b>GLOBAL Member Profile Wizard</b>.</p>";
            else
            {
                ltlWizard.Text = "<p class='msg info'>Current site is using <b>Custom Member Profile Wizard options</b>.</p>";

                blnLanguages = true;
            }
        }
        else
        {
            memberWizard = MemberWizardService.GetAll().Find(s => s.GlobalTemplate.Equals(true));

            ltlWizard.Text = "<p class='msg warning'>Current site is using <b>GLOBAL Member Profile Wizard options</b>, please overwrite if its custom for the current site.</p>";
        }

        if (memberWizard != null)
        {
            string wizardlangxml = memberWizard.WizardLanguageXml;
            string ProfileInfo = string.Empty;
            string CVInfo = string.Empty;
            string RolePreferencesInfo = string.Empty;
            string EducationInfo = string.Empty;
            string MembershipsInfo = string.Empty;
            string ExperienceInfo = string.Empty;
            string SkillsInfo = string.Empty;
            string DirectorshipInfo = string.Empty;
            string SummaryInfo = string.Empty;
            string PersonalDetailsInfo = string.Empty;
            string LicensesInfo = string.Empty;
            string AttachCoverLetterInfo = string.Empty;
            string LanguagesInfo = string.Empty;
            string ReferencesInfo = string.Empty;
            string CustomQuestionInfo = string.Empty;

            if (!string.IsNullOrWhiteSpace(wizardlangxml))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(memberWizard.WizardLanguageXml);

                System.Xml.XmlNodeList infonodelist = xmldoc.GetElementsByTagName("Info");
                if (infonodelist != null && infonodelist.Count > 0)
                {
                    System.Xml.XmlNode infonode = infonodelist[0];

                    CVInfo = HttpUtility.HtmlDecode(infonode["CV"].InnerXml);
                    RolePreferencesInfo = HttpUtility.HtmlDecode(infonode["RolePreferences"].InnerXml);
                    EducationInfo = HttpUtility.HtmlDecode(infonode["Education"].InnerXml);
                    MembershipsInfo = HttpUtility.HtmlDecode(infonode["Memberships"].InnerXml);
                    ExperienceInfo = HttpUtility.HtmlDecode(infonode["Experience"].InnerXml);
                    SkillsInfo = HttpUtility.HtmlDecode(infonode["Skills"].InnerXml);
                    DirectorshipInfo = HttpUtility.HtmlDecode(infonode["Directorship"].InnerXml);
                    SummaryInfo = HttpUtility.HtmlDecode(infonode["Summary"].InnerXml);
                    PersonalDetailsInfo = HttpUtility.HtmlDecode(infonode["PersonalDetails"].InnerXml);
                    LicensesInfo = HttpUtility.HtmlDecode(infonode["Licenses"].InnerXml);
                    AttachCoverLetterInfo = HttpUtility.HtmlDecode(infonode["AttachCoverLetter"].InnerXml);
                    LanguagesInfo = HttpUtility.HtmlDecode(infonode["Languages"].InnerXml);
                    ReferencesInfo = HttpUtility.HtmlDecode(infonode["References"].InnerXml);
                    CustomQuestionInfo = HttpUtility.HtmlDecode(infonode["CustomQuestion"].InnerXml);
                }

            }

            //Member Profile Settings
            SetMinDropdowns(memberWizard.MinExperiencesEntry, memberWizard.MinEducationsEntry, memberWizard.MinReferencesEntry);

            //txtProfileTitle.Text = memberWizard.ProfileTitle;
            if (memberWizard.ProfilePoints >= 0)
            {
                cbProfileTitle.Checked = true;
                txtProfilePoints.Text = (memberWizard.ProfilePoints >= 0) ? memberWizard.ProfilePoints.ToString() : string.Empty;
            }
            else
                txtProfilePoints.Text = string.Empty;

            txtCVTitle.Text = memberWizard.CvTitle;
            if (memberWizard.CvPoints >= 0)
            {
                cbCVTitle.Checked = true;
                txtCVPoints.Text = (memberWizard.CvPoints >= 0) ? memberWizard.CvPoints.ToString() : string.Empty;
                txtCVInfo.Text = CVInfo;
            }
            else
                txtCVPoints.Text = string.Empty;

            txtRolePreferencesTitle.Text = memberWizard.RolePreferencesTitle;
            if (memberWizard.RolePreferencesPoints >= 0)
            {
                cbRolePreferencesTitle.Checked = true;
                txtRolePreferencesPoints.Text = (memberWizard.RolePreferencesPoints >= 0) ? memberWizard.RolePreferencesPoints.ToString() : string.Empty;
                txtRolePreferencesInfo.Text = RolePreferencesInfo;
            }
            else
                txtRolePreferencesPoints.Text = string.Empty;

            txtEducationTitle.Text = memberWizard.EducationTitle;
            if (memberWizard.EducationPoints >= 0)
            {
                phManageableFields_qualification.Visible = true;
                cbEducationTitle.Checked = true;
                txtEducationPoints.Text = (memberWizard.EducationPoints >= 0) ? memberWizard.EducationPoints.ToString() : string.Empty;
                txtEducationInfo.Text = EducationInfo;
            }
            else
            {
                txtEducationPoints.Text = string.Empty;
                phManageableFields_qualification.Visible = false;
            }

            txtMembershipsTitle.Text = memberWizard.MembershipsTitle;
            if (memberWizard.MembershipsPoints >= 0)
            {
                cbMembershipsTitle.Checked = true;
                txtMembershipsPoints.Text = (memberWizard.MembershipsPoints >= 0) ? memberWizard.MembershipsPoints.ToString() : string.Empty;
                txtMembershipsInfo.Text = MembershipsInfo;
            }
            else
                txtMembershipsPoints.Text = string.Empty;

            txtDirectorshipTitle.Text = memberWizard.DirectorshipTitle;
            if (memberWizard.DirectorshipPoints >= 0)
            {
                cbDirectorshipTitle.Checked = true;
                txtDirectorshipPoints.Text = (memberWizard.DirectorshipPoints >= 0) ? memberWizard.DirectorshipPoints.ToString() : string.Empty;
                txtDirectorshipInfo.Text = DirectorshipInfo;
            }
            else
                txtDirectorshipPoints.Text = string.Empty;

            txtExperienceTitle.Text = memberWizard.ExperienceTitle;
            if (memberWizard.ExperiencePoints >= 0)
            {
                cbExperienceTitle.Checked = true;
                txtExperiencePoints.Text = (memberWizard.ExperiencePoints >= 0) ? memberWizard.ExperiencePoints.ToString() : string.Empty;
                txtExperienceInfo.Text = ExperienceInfo;
            }
            else
                txtExperiencePoints.Text = string.Empty;

            txtSkillsTitle.Text = memberWizard.SkillsTitle;
            if (memberWizard.SkillsPoints >= 0)
            {
                phManageableFields_skills.Visible = true;
                cbSkillsTitle.Checked = true;
                txtSkillsPoints.Text = (memberWizard.SkillsPoints >= 0) ? memberWizard.SkillsPoints.ToString() : string.Empty;
                txtSkillsInfo.Text = SkillsInfo;
            }
            else
            {
                phManageableFields_skills.Visible = false;

                txtSkillsPoints.Text = string.Empty;
            }
            // Start
            txtSummaryTitle.Text = memberWizard.SummaryTitle;
            if (memberWizard.SummaryPoints >= 0)
            {
                cbSummaryTitle.Checked = true;
                txtSummaryPoints.Text = (memberWizard.SummaryPoints >= 0) ? memberWizard.SummaryPoints.ToString() : string.Empty;
                txtSummaryInfo.Text = SummaryInfo;
            }
            else
                txtSummaryPoints.Text = string.Empty;

            txtPersonalDetailsTitle.Text = memberWizard.PersonalDetailsTitle;
            if (memberWizard.PersonalDetailsPoints >= 0)
            {
                cbPersonalDetailsTitle.Checked = true;
                txtPersonalDetailsPoints.Text = (memberWizard.PersonalDetailsPoints >= 0) ? memberWizard.PersonalDetailsPoints.ToString() : string.Empty;
                txtPersonalDetailsInfo.Text = PersonalDetailsInfo;
            }
            else
                txtPersonalDetailsPoints.Text = string.Empty;

            txtLicensesTitle.Text = memberWizard.LicensesTitle;
            if (memberWizard.LicensesPoints >= 0)
            {
                phManageableFields_licence.Visible = true;
                cbLicensesTitle.Checked = true;
                txtLicensesPoints.Text = (memberWizard.LicensesPoints >= 0) ? memberWizard.LicensesPoints.ToString() : string.Empty;
                txtLicensesInfo.Text = LicensesInfo;
            }
            else
            {
                phManageableFields_licence.Visible = false;
                txtLicensesPoints.Text = string.Empty;
            }

            txtAttachCoverLetterTitle.Text = memberWizard.AttachCoverLetterTitle;
            if (memberWizard.AttachCoverLetterPoints >= 0)
            {
                cbAttachCoverLetterTitle.Checked = true;
                txtAttachCoverLetterPoints.Text = (memberWizard.AttachCoverLetterPoints >= 0) ? memberWizard.AttachCoverLetterPoints.ToString() : string.Empty;
                txtAttachCoverLetterInfo.Text = AttachCoverLetterInfo;
            }
            else
                txtAttachCoverLetterPoints.Text = string.Empty;

            txtLanguagesTitle.Text = memberWizard.LanguagesTitle;
            if (memberWizard.LanguagesPoints >= 0)
            {
                cbLanguagesTitle.Checked = true;
                txtLanguagesPoints.Text = (memberWizard.LanguagesPoints >= 0) ? memberWizard.LanguagesPoints.ToString() : string.Empty;
                txtLanguagesInfo.Text = LanguagesInfo;
            }
            else
                txtLanguagesPoints.Text = string.Empty;

            txtReferencesTitle.Text = memberWizard.ReferencesTitle;
            if (memberWizard.ReferencesPoints >= 0)
            {
                cbReferencesTitle.Checked = true;
                txtReferencesPoints.Text = (memberWizard.ReferencesPoints >= 0) ? memberWizard.ReferencesPoints.ToString() : string.Empty;
                txtReferencesInfo.Text = ReferencesInfo;
            }
            else
                txtReferencesPoints.Text = string.Empty;

            txtCustomQuestionTitle.Text = memberWizard.CustomQuestionTitle;
            if (memberWizard.CustomQuestionPoints >= 0)
            {
                cbCustomQuestionTitle.Checked = true;
                phCustomQuestions.Visible = true;
                //txtCustomQuestionPoints.Text = (memberWizard.CustomQuestionPoints >= 0) ? memberWizard.CustomQuestionPoints.ToString() : string.Empty;
                txtCustomQuestionInfo.Text = CustomQuestionInfo;
            }
            else
            {
                phCustomQuestions.Visible = false;
            }

            ltlLastModified.Text = memberWizard.LastModified.ToString();


            if (memberWizard.LastModified != null)
                ltlLastModified.Text = ((DateTime)memberWizard.LastModified).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

            AdminUsersService objAdminUsers = new AdminUsersService();
            using (JXTPortal.Entities.AdminUsers adminuser = objAdminUsers.GetByAdminUserId(memberWizard.LastModifiedBy))
            {
                ltlLastModifiedBy.Text = adminuser.UserName;
            }

            LoadMultilingualValues();

        }

        // Load languages only when there is custom options for the current site.
        if (blnLanguages)
            LoadLanguages();
    }

    private void LoadMultilingualValues()
    {
        // WizardLanguageXML

        MemberWizardId = GetMemberWizardID();

        JXTPortal.Entities.MemberWizard memberWizard = new JXTPortal.Entities.MemberWizard();
        if (MemberWizardId > 0)
        {
            memberWizard = MemberWizardService.GetByMemberWizardId(MemberWizardId);
        }
        else
        {
            memberWizard = MemberWizardService.GetAll().Find(s => s.GlobalTemplate.Equals(true));
        }

        if (memberWizard != null)
        {
            bool hasWizard = false;

            if (!string.IsNullOrWhiteSpace(memberWizard.WizardLanguageXml))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(memberWizard.WizardLanguageXml);

                MemberWizardContainerList = new List<MemberWizardContainer>();

                foreach (XmlNode xmlnode in xmldoc.SelectNodes("MemberWizards/MemberWizard"))
                {
                    hasWizard = true;
                    MemberWizardContainer container = new MemberWizardContainer();

                    XmlNode langnode = xmlnode.SelectSingleNode("LanguageID");
                    if (langnode != null)
                    {
                        container.LanguageId = Convert.ToInt32(langnode.InnerText);
                        XmlNode profilenode = xmlnode.SelectSingleNode("Profile");
                        if (profilenode != null)
                        { container.Profile = profilenode.InnerText; }
                        XmlNode cvnode = xmlnode.SelectSingleNode("CV");
                        if (cvnode != null)
                        { container.CV = cvnode.InnerText; }
                        XmlNode rolepreferencesnode = xmlnode.SelectSingleNode("RolePreferences");
                        if (rolepreferencesnode != null)
                        { container.RolePreferences = rolepreferencesnode.InnerText; }
                        XmlNode educationnode = xmlnode.SelectSingleNode("Education");
                        if (educationnode != null)
                        { container.Education = educationnode.InnerText; }
                        XmlNode membershipsnode = xmlnode.SelectSingleNode("Memberships");
                        if (membershipsnode != null)
                        { container.Memberships = membershipsnode.InnerText; }
                        XmlNode experiencenode = xmlnode.SelectSingleNode("Experience");
                        if (experiencenode != null)
                        { container.Experience = experiencenode.InnerText; }
                        XmlNode skillsnode = xmlnode.SelectSingleNode("Skills");
                        if (skillsnode != null)
                        { container.Skills = skillsnode.InnerText; }
                        XmlNode directorshipnode = xmlnode.SelectSingleNode("Directorship");
                        if (directorshipnode != null)
                        { container.Directorship = directorshipnode.InnerText; }
                        XmlNode summarynode = xmlnode.SelectSingleNode("Summary");
                        if (summarynode != null)
                        { container.Summary = summarynode.InnerText; }
                        XmlNode personaldetailsnode = xmlnode.SelectSingleNode("PersonalDetails");
                        if (personaldetailsnode != null)
                        { container.PersonalDetails = personaldetailsnode.InnerText; }
                        XmlNode licensesnode = xmlnode.SelectSingleNode("Licenses");
                        if (licensesnode != null)
                        { container.Licenses = licensesnode.InnerText; }
                        XmlNode attachcoverletternode = xmlnode.SelectSingleNode("AttachCoverLetter");
                        if (attachcoverletternode != null)
                        { container.AttachCoverLetter = attachcoverletternode.InnerText; }
                        XmlNode languagesnode = xmlnode.SelectSingleNode("Languages");
                        if (languagesnode != null)
                        { container.Languages = languagesnode.InnerText; }
                        XmlNode referencesnode = xmlnode.SelectSingleNode("References");
                        if (referencesnode != null)
                        { container.References = referencesnode.InnerText; }
                        XmlNode customquestionnode = xmlnode.SelectSingleNode("CustomQuestion");
                        if (customquestionnode != null)
                        { container.CustomQuestion = customquestionnode.InnerText; }
                        XmlNode cvnodeInfo = xmlnode.SelectSingleNode("CVInfo");
                        if (cvnodeInfo != null)
                        { container.CVInfo = cvnodeInfo.InnerText; }
                        XmlNode rolepreferencesnodeInfo = xmlnode.SelectSingleNode("RolePreferencesInfo");
                        if (rolepreferencesnodeInfo != null)
                        { container.RolePreferencesInfo = rolepreferencesnodeInfo.InnerText; }
                        XmlNode educationnodeInfo = xmlnode.SelectSingleNode("EducationInfo");
                        if (educationnodeInfo != null)
                        { container.EducationInfo = educationnodeInfo.InnerText; }
                        XmlNode membershipsnodeInfo = xmlnode.SelectSingleNode("MembershipsInfo");
                        if (membershipsnodeInfo != null)
                        { container.MembershipsInfo = membershipsnodeInfo.InnerText; }
                        XmlNode experiencenodeInfo = xmlnode.SelectSingleNode("ExperienceInfo");
                        if (experiencenodeInfo != null)
                        { container.ExperienceInfo = experiencenodeInfo.InnerText; }
                        XmlNode skillsnodeInfo = xmlnode.SelectSingleNode("SkillsInfo");
                        if (skillsnodeInfo != null)
                        { container.SkillsInfo = skillsnodeInfo.InnerText; }
                        XmlNode directorshipnodeInfo = xmlnode.SelectSingleNode("DirectorshipInfo");
                        if (directorshipnodeInfo != null)
                        { container.DirectorshipInfo = directorshipnodeInfo.InnerText; }
                        XmlNode summarynodeInfo = xmlnode.SelectSingleNode("SummaryInfo");
                        if (summarynodeInfo != null)
                        { container.SummaryInfo = summarynodeInfo.InnerText; }
                        XmlNode personaldetailsnodeInfo = xmlnode.SelectSingleNode("PersonalDetailsInfo");
                        if (personaldetailsnodeInfo != null)
                        { container.PersonalDetailsInfo = personaldetailsnodeInfo.InnerText; }
                        XmlNode licensesnodeInfo = xmlnode.SelectSingleNode("LicensesInfo");
                        if (licensesnodeInfo != null)
                        { container.LicensesInfo = licensesnodeInfo.InnerText; }
                        XmlNode attachcoverletternodeInfo = xmlnode.SelectSingleNode("AttachCoverLetterInfo");
                        if (attachcoverletternodeInfo != null)
                        { container.AttachCoverLetterInfo = attachcoverletternodeInfo.InnerText; }
                        XmlNode languagesnodeInfo = xmlnode.SelectSingleNode("LanguagesInfo");
                        if (languagesnodeInfo != null)
                        { container.LanguagesInfo = languagesnodeInfo.InnerText; }
                        XmlNode referencesnodeInfo = xmlnode.SelectSingleNode("ReferencesInfo");
                        if (referencesnodeInfo != null)
                        { container.ReferencesInfo = referencesnodeInfo.InnerText; }
                        XmlNode customquestionnodeInfo = xmlnode.SelectSingleNode("CustomQuestionInfo");
                        if (customquestionnodeInfo != null)
                        { container.CustomQuestionInfo = customquestionnodeInfo.InnerText; }

                        MemberWizardContainerList.Add(container);
                    }
                }
            }


            if(!hasWizard)
            {
                TList<JXTPortal.Entities.SiteLanguages> langs = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
                langs.Filter = "LanguageID <> " + SessionData.Site.DefaultLanguageId.ToString();
                if (langs.Count > 0)
                {
                    MemberWizardContainerList = new List<MemberWizardContainer>();

                    foreach (JXTPortal.Entities.SiteLanguages lang in langs)
                    {
                        MemberWizardContainer container = new MemberWizardContainer();
                        container.LanguageId = lang.LanguageId;
                        container.Profile = memberWizard.ProfileTitle;
                        container.CV = memberWizard.CvTitle;
                        container.RolePreferences = memberWizard.RolePreferencesTitle;
                        container.Education = memberWizard.EducationTitle;
                        container.Memberships = memberWizard.MembershipsTitle;
                        container.Experience = memberWizard.ExperienceTitle;
                        container.Skills = memberWizard.SkillsTitle;
                        container.Directorship = memberWizard.DirectorshipTitle;
                        container.Summary = memberWizard.SummaryTitle;
                        container.PersonalDetails = memberWizard.PersonalDetailsTitle;
                        container.Licenses = memberWizard.LicensesTitle;
                        container.AttachCoverLetter = memberWizard.AttachCoverLetterTitle;
                        container.Languages = memberWizard.LanguagesTitle;
                        container.References = memberWizard.ReferencesTitle;
                        container.CustomQuestion = memberWizard.CustomQuestionTitle;

                        if (!string.IsNullOrWhiteSpace(memberWizard.WizardLanguageXml))
                        {
                            XmlDocument xmldoc = new XmlDocument();
                            xmldoc.LoadXml(memberWizard.WizardLanguageXml);

                            System.Xml.XmlNodeList infonodelist = xmldoc.GetElementsByTagName("Info");
                            if (infonodelist != null && infonodelist.Count > 0)
                            {
                                System.Xml.XmlNode infonode = infonodelist[0];

                                container.CVInfo = HttpUtility.HtmlDecode(infonode["CV"].InnerXml);
                                container.RolePreferencesInfo = HttpUtility.HtmlDecode(infonode["RolePreferences"].InnerXml);
                                container.EducationInfo = HttpUtility.HtmlDecode(infonode["Education"].InnerXml);
                                container.MembershipsInfo = HttpUtility.HtmlDecode(infonode["Memberships"].InnerXml);
                                container.ExperienceInfo = HttpUtility.HtmlDecode(infonode["Experience"].InnerXml);
                                container.SkillsInfo = HttpUtility.HtmlDecode(infonode["Skills"].InnerXml);
                                container.DirectorshipInfo = HttpUtility.HtmlDecode(infonode["Directorship"].InnerXml);
                                container.SummaryInfo = HttpUtility.HtmlDecode(infonode["Summary"].InnerXml);
                                container.PersonalDetailsInfo = HttpUtility.HtmlDecode(infonode["PersonalDetails"].InnerXml);
                                container.LicensesInfo = HttpUtility.HtmlDecode(infonode["Licenses"].InnerXml);
                                container.AttachCoverLetterInfo = HttpUtility.HtmlDecode(infonode["AttachCoverLetter"].InnerXml);
                                container.LanguagesInfo = HttpUtility.HtmlDecode(infonode["Languages"].InnerXml);
                                container.ReferencesInfo = HttpUtility.HtmlDecode(infonode["References"].InnerXml);
                                container.CustomQuestionInfo = HttpUtility.HtmlDecode(infonode["CustomQuestion"].InnerXml);
                            }

                        }

                        MemberWizardContainerList.Add(container);

                    }
                }
            }
        }
    }

    private void LoadLanguages()
    {
        TList<JXTPortal.Entities.SiteLanguages> langs = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
        langs.Filter = "LanguageID <> " + SessionData.Site.DefaultLanguageId.ToString();
        if (langs.Count > 0)
        {
            phMultilingual.Visible = true;

            rptMultilingual.DataSource = langs;
            rptMultilingual.DataBind();

            RepeaterItem firstlang = rptMultilingual.Items[0];
            LinkButton lbLanguage = firstlang.FindControl("lbLanguage") as LinkButton;
            lbLanguage.Enabled = false;

            AssignMultilingualValues(Convert.ToInt32(lbLanguage.CommandArgument));

        }
    }

    protected void rptMultilingual_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Language")
        {
            foreach (RepeaterItem ri in rptMultilingual.Items)
            {
                LinkButton lbLanguage = ri.FindControl("lbLanguage") as LinkButton;
                lbLanguage.Enabled = true;

                if (e.CommandArgument == lbLanguage.CommandArgument)
                {
                    lbLanguage.Enabled = false;

                    AssignMultilingualValues(Convert.ToInt32(lbLanguage.CommandArgument));
                }
            }
        }
    }

    protected void rptMultilingual_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbLanguage = e.Item.FindControl("lbLanguage") as LinkButton;

            JXTPortal.Entities.SiteLanguages lang = e.Item.DataItem as JXTPortal.Entities.SiteLanguages;

            lbLanguage.CommandArgument = lang.LanguageId.ToString();
            lbLanguage.Text = lang.SiteLanguageName;
        }
    }

    private void AssignMultilingualValues(int langid)
    {
        LoadMultilingualValues();

        foreach (MemberWizardContainer container in MemberWizardContainerList)
        {
            if (container.LanguageId == langid)
            {
                txtMultiCV.Text = HttpUtility.HtmlDecode(container.CV);
                txtMultiRolePreferences.Text = HttpUtility.HtmlDecode(container.RolePreferences);
                txtMultiEducation.Text = HttpUtility.HtmlDecode(container.Education);
                txtMultiMemberships.Text = HttpUtility.HtmlDecode(container.Memberships);
                txtMultiExperience.Text = HttpUtility.HtmlDecode(container.Experience);
                txtMultiSkills.Text = HttpUtility.HtmlDecode(container.Skills);
                txtMultiDirectorship.Text = HttpUtility.HtmlDecode(container.Directorship);
                txtMultiSummary.Text = HttpUtility.HtmlDecode(container.Summary);
                txtMultiPersonalDetails.Text = HttpUtility.HtmlDecode(container.PersonalDetails);
                txtMultiLicenses.Text = HttpUtility.HtmlDecode(container.Licenses);
                txtMultiAttachCoverLetter.Text = HttpUtility.HtmlDecode(container.AttachCoverLetter);
                txtMultiLanguages.Text = HttpUtility.HtmlDecode(container.Languages);
                txtMultiReferences.Text = HttpUtility.HtmlDecode(container.References);
                txtMultiCustomQuestion.Text = HttpUtility.HtmlDecode(container.CustomQuestion);
                txtMultiCVInfo.Text = HttpUtility.HtmlDecode(container.CVInfo);
                txtMultiRolePreferencesInfo.Text = HttpUtility.HtmlDecode(container.RolePreferencesInfo);
                txtMultiEducationInfo.Text = HttpUtility.HtmlDecode(container.EducationInfo);
                txtMultiMembershipsInfo.Text = HttpUtility.HtmlDecode(container.MembershipsInfo);
                txtMultiExperienceInfo.Text = HttpUtility.HtmlDecode(container.ExperienceInfo);
                txtMultiSkillsInfo.Text = HttpUtility.HtmlDecode(container.SkillsInfo);
                txtMultiDirectorshipInfo.Text = HttpUtility.HtmlDecode(container.DirectorshipInfo);
                txtMultiSummaryInfo.Text = HttpUtility.HtmlDecode(container.SummaryInfo);
                txtMultiPersonalDetailsInfo.Text = HttpUtility.HtmlDecode(container.PersonalDetailsInfo);
                txtMultiLicensesInfo.Text = HttpUtility.HtmlDecode(container.LicensesInfo);
                txtMultiAttachCoverLetterInfo.Text = HttpUtility.HtmlDecode(container.AttachCoverLetterInfo);
                txtMultiLanguagesInfo.Text = HttpUtility.HtmlDecode(container.LanguagesInfo);
                txtMultiReferencesInfo.Text = HttpUtility.HtmlDecode(container.ReferencesInfo);
                txtMultiCustomQuestionInfo.Text = HttpUtility.HtmlDecode(container.CustomQuestionInfo);

                break;
            }
        }



        txtMultiCV.Enabled = cbCVTitle.Checked;

        txtMultiRolePreferences.Enabled = cbRolePreferencesTitle.Checked;

        txtMultiEducation.Enabled = cbEducationTitle.Checked;

        txtMultiMemberships.Enabled = cbMembershipsTitle.Checked;

        txtMultiDirectorship.Enabled = cbDirectorshipTitle.Checked;

        txtMultiExperience.Enabled = cbExperienceTitle.Checked;

        txtMultiSkills.Enabled = cbSkillsTitle.Checked;

        txtMultiSummary.Enabled = cbSummaryTitle.Checked;

        txtMultiPersonalDetails.Enabled = cbPersonalDetailsTitle.Checked;

        txtMultiLicenses.Enabled = cbLicensesTitle.Checked;

        txtMultiAttachCoverLetter.Enabled = cbAttachCoverLetterTitle.Checked;

        txtMultiLanguages.Enabled = cbLanguagesTitle.Checked;

        txtMultiReferences.Enabled = cbReferencesTitle.Checked;

        txtMultiCustomQuestion.Enabled = cbCustomQuestionTitle.Checked;

        txtMultiCVInfo.Enabled = cbCVTitle.Checked;

        txtMultiRolePreferencesInfo.Enabled = cbRolePreferencesTitle.Checked;

        txtMultiEducationInfo.Enabled = cbEducationTitle.Checked;

        txtMultiMembershipsInfo.Enabled = cbMembershipsTitle.Checked;

        txtMultiDirectorshipInfo.Enabled = cbDirectorshipTitle.Checked;

        txtMultiExperienceInfo.Enabled = cbExperienceTitle.Checked;

        txtMultiSkillsInfo.Enabled = cbSkillsTitle.Checked;

        txtMultiSummaryInfo.Enabled = cbSummaryTitle.Checked;

        txtMultiPersonalDetailsInfo.Enabled = cbPersonalDetailsTitle.Checked;

        txtMultiLicensesInfo.Enabled = cbLicensesTitle.Checked;

        txtMultiAttachCoverLetterInfo.Enabled = cbAttachCoverLetterTitle.Checked;

        txtMultiLanguagesInfo.Enabled = cbLanguagesTitle.Checked;

        txtMultiReferencesInfo.Enabled = cbReferencesTitle.Checked;

        txtMultiCustomQuestionInfo.Enabled = cbCustomQuestionTitle.Checked;
    }

    private void SetMinDropdowns(int minExp, int minEdu, int minRef)
    {
        List<ListItem> numSelects = new List<ListItem>
        {
            new ListItem("No Minimum","0"),
            new ListItem("1","1"),
            new ListItem("2","2"),
            new ListItem("3","3"),
            new ListItem("4","4"),
            new ListItem("5","5")
        };

        ddlMinExperience.DataValueField = "value";
        ddlMinExperience.DataTextField = "text";
        ddlMinExperience.DataSource = numSelects;
        ddlMinExperience.DataBind();
        ddlMinExperience.SelectedValue = minExp.ToString();

        ddlMinEducation.DataValueField = "value";
        ddlMinEducation.DataTextField = "text";
        ddlMinEducation.DataSource = numSelects;
        ddlMinEducation.DataBind();
        ddlMinEducation.SelectedValue = minEdu.ToString();

        ddlMinReference.DataValueField = "value";
        ddlMinReference.DataTextField = "text";
        ddlMinReference.DataSource = numSelects;
        ddlMinReference.DataBind();
        ddlMinReference.SelectedValue = minRef.ToString();
    }

    #endregion

}


