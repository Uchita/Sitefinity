using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.JobApplications.Models;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.job.application.doc
{
    public partial class aicd_scholarship_doc : System.Web.UI.Page
    {
        private AicdSponsorshipModel _formData;

        //for front end grab
        public AicdSponsorshipModel FormData
        {
            get
            {
                if (_formData == null)
                    return new AicdSponsorshipModel();
                return _formData;
            }
        }

        private int _appid = 0;
        protected int ApplicationID
        {
            get
            {
                if ((Request.QueryString["appid"] != null))
                {
                    if (int.TryParse((Request.QueryString["appid"].Trim()), out _appid))
                    {
                        _appid = Convert.ToInt32(Request.QueryString["appid"]);
                    }
                    return _appid;
                }

                return _appid;
            }
        }

        private ViewJobsService _viewJobsService;

        private ViewJobsService ViewJobsService
        {
            get
            {
                if (_viewJobsService == null)
                    _viewJobsService = new ViewJobsService();
                return _viewJobsService;
            }
        }

        private JobApplicationService _jobApplicationService;
        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();
                return _jobApplicationService;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (ApplicationID > 1)
            {
                JobApplications.FormGenerator formGenerator = new JobApplications.FormGenerator();


                using (JobApplication jobApplication = JobApplicationService.GetByJobApplicationId(ApplicationID))
                {
                    // Todo - Check its advertisers application
                    if (jobApplication != null) // Todo && jobApplicationList[0].Draft == false)
                    {

                        using (VList<JXTPortal.Entities.ViewJobs> jobs = ViewJobsService.GetByID(jobApplication.JobId, SessionData.Site.SiteId))
                        {
                            // If expired redirect to the job detail page.
                            if ((jobs[0].Expired.HasValue && jobs[0].Expired.Value == (int)PortalEnums.Jobs.JobStatus.Expired) || jobs[0].ExpiryDate < DateTime.Now)
                            {
                                Response.Redirect("~/" + Utils.GetJobUrl(jobs[0].JobId, jobs[0].JobFriendlyName));
                            }

                            ltJobName.Text = HttpUtility.HtmlEncode(jobs[0].JobName);
                            //hypLinkJobTitle.Text = jobs[0].JobName + " - Application complete";
                            //hypLinkJobTitle.NavigateUrl = Utils.GetJobUrl(jobs[0].JobId, jobs[0].JobFriendlyName);

                        }

                        //_formData = new AicdSponsorshipModel();
                        //_formData.tab8 = Utils.ProcessXMLFromXmlString(_formData.tab8, jobApplication.CustomQuestionnaireXml);
                        //formGenerator.GenerateForm(ref plhTab1, _formData.tab8 != null ? _formData.tab8.tab1Values : null, true);

                        if (!string.IsNullOrWhiteSpace(jobApplication.ExternalXmlFilename))
                        {
                            string strXmlString = JobApplicationService.ReadXMLFromFTP(jobApplication.ExternalXmlFilename);

                            _formData = Utils.ProcessXMLFromXmlString(FormData, strXmlString);
                            _formData.tab8 = Utils.ProcessXMLFromXmlString(_formData.tab8, jobApplication.CustomQuestionnaireXml);

                            ltTitle.Text = Enum.GetName(typeof(ENUM_Title), _formData.tab2.title);
                            ltFirstName.Text = HttpUtility.HtmlEncode(_formData.tab2.firstName);
                            ltMiddleName.Text = HttpUtility.HtmlEncode(_formData.tab2.middleName);
                            ltLastName.Text = HttpUtility.HtmlEncode(_formData.tab2.lastName);
                            ltHonorifics.Text = HttpUtility.HtmlEncode(_formData.tab2.honorifics);
                            ltEmail.Text = HttpUtility.HtmlEncode(_formData.tab2.email);
                            ltPhoneNumber.Text = HttpUtility.HtmlEncode(_formData.tab2.phoneNumber);
                            ltPostcode.Text = HttpUtility.HtmlEncode(_formData.tab2.postcode);
                            ltState.Text = HttpUtility.HtmlEncode(Enum.GetName(typeof(ENUM_State), _formData.tab2.state));

                            rptDirectorshipExperience.DataSource = _formData.tab3;
                            rptDirectorshipExperience.DataBind();

                            rptProfessionalExperience.DataSource = _formData.tab4;
                            rptProfessionalExperience.DataBind();

                            rptEducationAndQualifications.DataSource = _formData.tab5.qualifications;
                            rptEducationAndQualifications.DataBind();

                            ltEQAssociationMembership.Text = HttpUtility.HtmlEncode(_formData.tab5.Other_Specify);
                            RefereeContact rc = new RefereeContact();
                            List<RefereeContact> refereecontacts = new List<RefereeContact>();
                            rc.Name = _formData.tab7.name1;
                            rc.ContactDetails = _formData.tab7.contact1;
                            rc.Relationship = _formData.tab7.relationship1;
                            refereecontacts.Add(rc);

                            rc = new RefereeContact();
                            rc.Name = _formData.tab7.name2;
                            rc.ContactDetails = _formData.tab7.contact2;
                            rc.Relationship = _formData.tab7.relationship2;
                            refereecontacts.Add(rc);

                            rptReferee.DataSource = refereecontacts;
                            rptReferee.DataBind();

                            string courseapplying = string.Empty;
                            foreach (QuestionaireValues qv in _formData.tab8.tab1Values)
                            {
                                if (qv.name == "blnAboriginal1")
                                {
                                    ltAboriginal.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnAboriginal2")
                                {
                                    ltAboriginal.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnDiverseBackground1")
                                {
                                    ltLinguisticallyDiverse.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnDiverseBackground2")
                                {
                                    ltLinguisticallyDiverse.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnRuralRegional1")
                                {
                                    ltRegional.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnRuralRegional2")
                                {
                                    ltRegional.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnDisability1")
                                {
                                    ltDisability.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnDisability2")
                                {
                                    ltDisability.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "chkScholarship2Q1")
                                {
                                    courseapplying += "<li>" + HttpUtility.HtmlEncode(qv.value) + "</li>";
                                }
                                else if (qv.name == "chkScholarship2Q2")
                                {
                                    courseapplying += "<li>" + HttpUtility.HtmlEncode(qv.value) + "</li>";
                                }
                                else if (qv.name == "chkScholarship2Q3")
                                {
                                    courseapplying += "<li>" + HttpUtility.HtmlEncode(qv.value) + "</li>";
                                }
                                else if (qv.name == "blnScholarship3Q1")
                                {
                                    ltMember.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnScholarship3Q2")
                                {
                                    ltMember.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnScholarship4Q1")
                                {
                                    ltFinancialLiteracy.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnScholarship4Q2")
                                {
                                    ltFinancialLiteracy.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnScholarship4Q3")
                                {
                                    ltFinancialLiteracy.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "blnScholarship4Q4")
                                {
                                    ltFinancialLiteracy.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "txtScholarshipAdditional1")
                                {
                                    ltAwards.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                                else if (qv.name == "txtScholarshipAdditional2")
                                {
                                    ltOutline.Text = HttpUtility.HtmlEncode(qv.value);
                                }
                            }

                            if (!string.IsNullOrEmpty(courseapplying))
                            {
                                ltCourse.Text = "<ul>" + courseapplying + "</ul>";
                            }
                        }

                    }
                }
            }
            else
                Response.Redirect("/advancedsearch.aspx");
        }

        protected void rptDirectorshipExperience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltDEIndex = e.Item.FindControl("ltDEIndex") as Literal;
                Literal ltDEExperienceSummary = e.Item.FindControl("ltDEExperienceSummary") as Literal;
                Literal ltDETypeOfRole = e.Item.FindControl("ltDETypeOfRole") as Literal;
                Literal ltDEPositionTitle = e.Item.FindControl("ltDEPositionTitle") as Literal;
                Literal ltDEOrganisationName = e.Item.FindControl("ltDEOrganisationName") as Literal;
                Literal ltDEStartDate = e.Item.FindControl("ltDEStartDate") as Literal;
                Literal ltDEEndDate = e.Item.FindControl("ltDEEndDate") as Literal;
                Literal ltDEAdditionRoles = e.Item.FindControl("ltDEAdditionRoles") as Literal;
                Literal ltDEBoardCommittee = e.Item.FindControl("ltDEBoardCommittee") as Literal;
                Literal ltTypeOfOrganisation = e.Item.FindControl("ltTypeOfOrganisation") as Literal;
                Literal ltDEOrganisationIndustry = e.Item.FindControl("ltDEOrganisationIndustry") as Literal;

                DirectorshipExperience de = e.Item.DataItem as DirectorshipExperience;
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                string boardcommitte = string.Empty;
                ltDEIndex.Text = (e.Item.ItemIndex + 1).ToString();
                ltDEExperienceSummary.Text = HttpUtility.HtmlEncode(de.experienceSummary);
                ltDETypeOfRole.Text = Enum.GetName(typeof(ENUM_DirectorshipRole), de.roleType);
                ltDEPositionTitle.Text = HttpUtility.HtmlEncode(de.positionTitle);
                ltDEOrganisationName.Text = HttpUtility.HtmlEncode(de.organisationName);
                ltDEStartDate.Text = dtfi.GetMonthName(de.dirStartDateMonth) + " " + de.dirStartDateYear.ToString();
                ltDEEndDate.Text = (de.directorshipIsCurrent) ? "Current" : dtfi.GetMonthName(de.dirEndDateMonth) + " " + de.dirEndDateYear.ToString();
                ltDEAdditionRoles.Text = (de.role_isChairman) ? "Board Chair" : string.Empty;
                if (de.member_isAudit) boardcommitte += "<li>Audit</li>";
                if (de.member_isCompliance) boardcommitte += "<li>Compliance</li>";
                if (de.member_isFinance) boardcommitte += "<li>Finance</li>";
                if (de.member_isNominations) boardcommitte += "<li>Nominations</li>";
                if (de.member_isRemuneration) boardcommitte += "<li>Remuneration</li>";
                if (de.member_isRisk) boardcommitte += "<li>Risk</li>";
                if (de.member_isSustainability) boardcommitte += "<li>Sustainability</li>";
                if (!string.IsNullOrWhiteSpace(de.member_isOther_Specify)) boardcommitte += "<li>" + de.member_isOther_Specify + "</li>";

                ltDEBoardCommittee.Text = "<ul>" + boardcommitte + "</ul>";
                ltTypeOfOrganisation.Text = Enum.GetName(typeof(ENUM_DirectorshipOrgType), de.organisationType);
                ltDEOrganisationIndustry.Text = HttpUtility.HtmlEncode(de.organisationIndustry);

            }
        }

        protected void rptProfessionalExperience_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltPEIndex = e.Item.FindControl("ltPEIndex") as Literal;
                Literal ltPEExperienceSummary = e.Item.FindControl("ltPEExperienceSummary") as Literal;
                Literal ltPETypeOfRole = e.Item.FindControl("ltPETypeOfRole") as Literal;
                Literal ltPEPositionTitle = e.Item.FindControl("ltPEPositionTitle") as Literal;
                Literal ltPEOrganisationName = e.Item.FindControl("ltPEOrganisationName") as Literal;
                Literal ltPEStartDate = e.Item.FindControl("ltPEStartDate") as Literal;
                Literal ltPEEndDate = e.Item.FindControl("ltPEEndDate") as Literal;
                Literal ltPEAddicationalRoles = e.Item.FindControl("ltPEAddicationalRoles") as Literal;
                Literal ltPETypeOfOrganisation = e.Item.FindControl("ltPETypeOfOrganisation") as Literal;
                Literal ltPEOrganisationIndustry = e.Item.FindControl("ltPEOrganisationIndustry") as Literal;

                ProfessionalExperience pe = e.Item.DataItem as ProfessionalExperience;
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();

                ltPEIndex.Text = (e.Item.ItemIndex + 1).ToString();
                ltPEExperienceSummary.Text = HttpUtility.HtmlEncode(pe.professionalExperienceSummary);
                ltPETypeOfRole.Text = Enum.GetName(typeof(ENUM_ProfessionalRole), pe.profRole);
                ltPEPositionTitle.Text = HttpUtility.HtmlEncode(pe.jobTitle);
                ltPEOrganisationName.Text = HttpUtility.HtmlEncode(pe.profOrgName);
                ltPEStartDate.Text = dtfi.GetMonthName(pe.profStartDateMonth) + " " + pe.profStartDateYear.ToString();
                ltPEEndDate.Text = (pe.profIsCurrent) ? "Current" : dtfi.GetMonthName(pe.profEndDateMonth) + " " + pe.profEndDateYear.ToString();
                ltPEAddicationalRoles.Text = HttpUtility.HtmlEncode(pe.profRole_Specify);
                ltPETypeOfOrganisation.Text = Enum.GetName(typeof(ENUM_DirectorshipOrgType), pe.organisationType);
                ltPEOrganisationIndustry.Text = HttpUtility.HtmlEncode(pe.organisationIndustry);

            }
        }

        protected void rptEducationAndQualifications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltEQIndex = e.Item.FindControl("ltEQIndex") as Literal;
                Literal ltEQCourseName = e.Item.FindControl("ltEQCourseName") as Literal;
                Literal ltEQInstitution = e.Item.FindControl("ltEQInstitution") as Literal;
                Literal ltEQStartDate = e.Item.FindControl("ltEQStartDate") as Literal;
                Literal ltEQEndDate = e.Item.FindControl("ltEQEndDate") as Literal;

                Qualifications q = e.Item.DataItem as Qualifications;
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();

                ltEQIndex.Text = (e.Item.ItemIndex + 1).ToString();
                ltEQCourseName.Text = HttpUtility.HtmlEncode(q.courseName);
                ltEQInstitution.Text = HttpUtility.HtmlEncode(q.institution);
                ltEQStartDate.Text = dtfi.GetMonthName(q.qStartDateMonth) + " " + q.qStartDateYear.ToString();
                ltEQEndDate.Text = (q.qIsCurrent) ? "Current" : dtfi.GetMonthName(q.qEndDateMonth) + " " + q.qEndDateYear.ToString();
            }

        }

        protected void rptReferee_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltRFContactsIndex = e.Item.FindControl("ltRFContactsIndex") as Literal;
                Literal ltRFName = e.Item.FindControl("ltRFName") as Literal;
                Literal ltRFRelationship = e.Item.FindControl("ltRFRelationship") as Literal;
                Literal ltRFContact = e.Item.FindControl("ltRFContact") as Literal;

                RefereeContact rc = e.Item.DataItem as RefereeContact;

                ltRFContactsIndex.Text = (e.Item.ItemIndex + 1).ToString();
                ltRFName.Text = HttpUtility.HtmlEncode(rc.Name);
                ltRFContact.Text = HttpUtility.HtmlEncode(rc.ContactDetails);
                ltRFRelationship.Text = HttpUtility.HtmlEncode(rc.Relationship);
            }

        }

        internal class RefereeContact
        {
            public string Name { get; set; }
            public string Relationship { get; set; }
            public string ContactDetails { get; set; }
        }
    }
}