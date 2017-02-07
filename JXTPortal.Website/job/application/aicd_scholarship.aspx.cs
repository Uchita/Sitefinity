using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.Xml;
using JXTPortal.JobApplications.Models;
using System.Web.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.IO;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Configuration;
using log4net;

namespace JXTPortal.Website.job.application
{
    public partial class aicd_scholarship : System.Web.UI.Page
    {

        #region Properties
        
        private int _jobid = 0;
        protected int JobID
        {
            get
            {
                if ((Request.QueryString["jobid"] != null))
                {
                    if (int.TryParse((Request.QueryString["jobid"].Trim()), out _jobid))
                    {
                        _jobid = Convert.ToInt32(Request.QueryString["jobid"]);
                    }
                    return _jobid;
                }

                return _jobid;
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
        /*private int _appid = 0;
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
        }*/

        private string _profession = string.Empty;
        protected string Profession
        {
            get
            {
                if ((Request.QueryString["profession"] != null))
                {
                    _profession = Request.QueryString["profession"];
                    return _profession;
                }

                return _profession;
            }
        }


        private MembersService _memebrsService;
        private MembersService MembersService
        {
            get
            {
                if (_memebrsService == null)
                    _memebrsService = new MembersService();
                return _memebrsService;
            }
        }

        private JobsService _jobsService;
        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                    _jobsService = new JobsService();
                return _jobsService;
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

        //for front end grab
        private AicdSponsorshipModel _FormData;
        public AicdSponsorshipModel FormData
        {
            get
            {
                if (_FormData == null)
                    _FormData = GetFormDataFromSession();
                    
                return _FormData;
            }
        }

        private DynamicPagesService _dynamicPagesService = null;

        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            if (!Page.IsPostBack)
            {
                // Check if already applied for the job.
                if (JobID > 1)
                {
                    JobApplications.FormGenerator formGenerator = new JobApplications.FormGenerator();                    
                    AicdSponsorshipModel currentFormModel = new AicdSponsorshipModel();
                    bool blnJobPageRedirect = false;
                    string strJobFriendlyName = string.Empty;

                    using (TList<JobApplication> jobApplicationList = JobApplicationService.CustomGetByJobIdMemberId(JobID, SessionData.Member.MemberId))                    
                    using (VList<JXTPortal.Entities.ViewJobs> jobs = ViewJobsService.GetByID(JobID, SessionData.Site.SiteId))                
                    {


                        if (jobs != null && jobs.Count > 0)
                        {

                            // Terms and conditions
                            using (JXTPortal.Entities.DynamicPages dynamicPage = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId, jobs[0].RefNo, SessionData.Language.LanguageId))
                            {
                                if (dynamicPage != null)
                                    ltlTermsAndConditions.Text = dynamicPage.PageContent;
                            }

                            strJobFriendlyName = jobs[0].JobFriendlyName;

                            // If expired redirect to the job detail page.
                            if ((jobs[0].Expired.HasValue && jobs[0].Expired.Value == (int) PortalEnums.Jobs.JobStatus.Expired) || jobs[0].ExpiryDate < DateTime.Now)
                            {

                                blnJobPageRedirect = true;
                            }

                            hfJobId.Value = jobs[0].JobId.ToString();
                            CommonPage.SetBrowserPageTitle(Page, jobs[0].JobName);
                            hypLinkJobTitle.Text = jobs[0].JobName;
                            hypLinkJobTitle.NavigateUrl = Utils.GetJobUrl(jobs[0].JobId, jobs[0].JobFriendlyName);
                        }


                        if (jobApplicationList != null && jobApplicationList.Count > 0)
                        {

                            // If the job is already applied .. then redirect to the job.
                            if (jobApplicationList[0].Draft == false)
                            {
                                blnJobPageRedirect = true;
                            }
                            else // Get Job application is Draft - Get XML and set to the Session
                            {

                                if (!string.IsNullOrWhiteSpace(jobApplicationList[0].ExternalXmlFilename))
                                {
                                    string strXmlString = JobApplicationService.ReadXMLFromFTP(jobApplicationList[0].ExternalXmlFilename);

                                    currentFormModel = Utils.ProcessXMLFromXmlString(currentFormModel, strXmlString);


                                    //currentFormModel.tab1 = Utils.ProcessXMLFromXmlString(currentFormModel.tab1, jobApplicationList[0].CustomQuestionnaireXml);
                                    formGenerator.GenerateForm(ref plhTab1, currentFormModel.tab8 != null ? currentFormModel.tab8.tab1Values : null, false);

                                }
                            }

                            // Check if the resume is uploaded
                            /*if (!string.IsNullOrWhiteSpace(jobApplicationList[0].MemberResumeFile))
                                currentFormModel.tab8.blnResumeFile = true;*/


                        }
                        else
                        {
                            formGenerator.GenerateForm(ref plhTab1, null, false);

                            using (Entities.Members members = MembersService.GetByMemberId(SessionData.Member.MemberId))
                            {
                                if (members != null)
                                {
                                    currentFormModel = GetFormDataFromSession();

                                    // Assign member values
                                    currentFormModel.tab2.firstName = members.FirstName;
                                    currentFormModel.tab2.lastName = members.Surname;
                                    currentFormModel.tab2.email = members.EmailAddress;
                                    currentFormModel.tab2.phoneNumber = !string.IsNullOrWhiteSpace(members.MobilePhone) ? members.MobilePhone.Trim() : (!string.IsNullOrWhiteSpace(members.HomePhone) ? members.HomePhone.Trim() : string.Empty);
                                    currentFormModel.tab2.postcode = members.PostCode;

                                }
                            }
                        }
                    }


                    // You already applied - Redirect to the Job 
                    // Or if the job is expired.
                    if (blnJobPageRedirect)
                        Response.Redirect("~/" + Utils.GetJobUrl(JobID, strJobFriendlyName));


                    currentFormModel.JobID = JobID;

                    //place back to the session
                    HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] = currentFormModel;

                }
                else
                    Response.Redirect("/advancedsearch.aspx");
                
            }

        }
        
        #endregion


        #region Web Methods

        /// <summary>
        /// Page Submit handles the requests when the "Next" button is clicked on the front end. This perform required checks on various tabs 
        /// like "At least 1 record is required..." etc
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Json object that includes a "Success" property that indicates the PageSubmit is successful or not.</returns>
        [WebMethod]
        public static object PageSubmit(AicdSponsorshipModel model)
        {

            try
            {
                // Check if Session Expired.
                if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
                {
                    return ReturnSessionIsExpired();
                }

                switch (model.tabSubmit)
                {
                    case 1:
                        //validate input model
                        List<ValidationResult> validateTab1Results = ValidateModel(model.tabSubmit, model);

                        //return errors if validation failed
                        if (validateTab1Results.Count() > 0)
                            return new { Success = false, ValidateResult = validateTab1Results };

                        //success, refresh to the session
                        StoreFormToSession(model.tabSubmit, model);

                        return new { Success = true };
                    case 2:
                    case 6:
                    case 7:
                        //validate input model
                        List<ValidationResult> validateResults = ValidateModel(model.tabSubmit, model);

                        //return errors if validation failed
                        if (validateResults.Count() > 0)
                            return new { Success = false, ValidateResult = validateResults };

                        //success, refresh to the session
                        StoreFormToSession(model.tabSubmit, model);

                        //
                        SaveDraft(null, false);

                        return new { Success = true };

                    case 3:
                        //directorship experience: record submits uses another webmethod.
                        //here we do logic checks and return ok to proceed or not to tab 4
                        //if (DirectorshipExperienceHasRecords())
                        //{
                        //    return new { Success = true };
                        //}
                        //return new { Success = false, ValidateResult = new List<ValidationResult> { new ValidationResult("At least 1 directorship experience is required", new List<string> { "tab3_form" }) } };
                        return new { Success = true };

                    case 4:
                        //professional experience: record submits uses another webmethod.
                        //here we do logic checks and return ok to proceed or not to tab 5
                        if (ProfessionalExperienceHasRecords())
                        {
                            return new { Success = true };
                        }
                        return new { Success = false, ValidateResult = new List<ValidationResult> { new ValidationResult("At least 1 professional experience is required", new List<string> { "tab4_form" }) } };
                    case 5:
                        //regardless store the membership details
                        model.tab5._isFromPageSubmit = true;
                        StoreFormToSession(model.tabSubmit, model);

                        //Qualifications: record submits uses another webmethod.
                        //here we do logic checks and return ok to proceed or not to tab 6

                        return new { Success = true };
                        /*if (QualificationsHasRecords())
                        {
                            return new { Success = true };
                        }
                        return new { Success = false, ValidateResult = new List<ValidationResult> { new ValidationResult("At least 1 qualification is required", new List<string> { "tab5_form" }) } };
                        */
                    case 8:
                        //validate input model
                        List<ValidationResult> validateTab8Results = ValidateModel(model.tabSubmit, model);

                        //return errors if validation failed
                        if (validateTab8Results.Count() > 0)
                            return new { Success = false, ValidateResult = validateTab8Results };

                        //success, refresh to the session
                        StoreFormToSession(model.tabSubmit, model);
                        
                        // Submit 
                        SaveDraft(null, true);

                        return new { Success = true };

                    default:
                        return new { Success = false };

                }
            }
            catch (Exception e)
            {
                var logger = LogManager.GetLogger(typeof(aicd_scholarship));
                logger.Error(e);

                return new { Success = false, ValidateResult = new List<ValidationResult> { new ValidationResult("Error occured while processing the last request. Please try again.", new List<string> { "form_error" }) } };
            }


        }

        [WebMethod(EnableSession = true)]
        public static object SaveDraft(AicdSponsorshipModel model, bool isFinished = false)
        {
            try
            {

                // Check if Session Expired.
                if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
                {
                    return ReturnSessionIsExpired();

                }

                // Put the current data from the page to session without validation
                if (model != null)
                    StoreFormToSession(-1, model); // -1 means save as draft

                AicdSponsorshipModel currentFormModel = GetFormDataFromSession();

                if (currentFormModel == null)
                    return new { Success = false, ValidateResult = new List<ValidationResult> { new ValidationResult("There has been no input to the form. Save draft canceled", new List<string> { "form_error" }) } };

                string xmlResult = Utils.ProcessModelToXML(currentFormModel);
                string xmlCustomResult = Utils.ProcessModelToXML(currentFormModel.tab8);

                string strErrorMessage = string.Empty;
                JXTPortal.JobApplicationService jobApplicationService = new JXTPortal.JobApplicationService();
                int? jobApplicationID = null; // currentFormModel.JobApplicationID;


                // Get the Job application ID if the user applied saved as draft.
                using (TList<JobApplication> jobApplicationList = jobApplicationService.CustomGetByJobIdMemberId(currentFormModel.JobID, SessionData.Member.MemberId))
                {
                    if (jobApplicationList != null && jobApplicationList.Count > 0 && jobApplicationList[0].Draft == true)
                    {
                        jobApplicationID = jobApplicationList[0].JobApplicationId;
                    }
                }

                string strPDFurl = string.Empty;
                
                if (jobApplicationID.HasValue)
                    strPDFurl = "http://" + HttpContext.Current.Request.Url.Host + "/job/application/doc/aicd_scholarship_doc.aspx?appid=" + jobApplicationID.Value;
                
                bool blnResult = jobApplicationService.ApplyJobWithCustomApplication(HttpContext.Current.Request, 
                                                                                        currentFormModel.JobID, 
                                                                                        ref jobApplicationID, 
                                                                                        xmlCustomResult, 
                                                                                        xmlResult, 
                                                                                        null, 
                                                                                        !isFinished, 
                                                                                        strPDFurl,
                                                                                        ref strErrorMessage);

                // Set the Application ID
                currentFormModel.JobApplicationID = jobApplicationID;

                //place back to the session
                HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] = currentFormModel;

                //Write XML to File
                /*XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(xmlResult);
                xdoc.Save(HttpContext.Current.Server.MapPath("/Content/XML/CForm.xml"));*/

                //Load XML from File
                //CFormModel m = ProcessXMLFromFile(HttpContext.Current.Server.MapPath("/Content/XML/CForm.xml"));
            }
            catch (Exception e)
            {
                var logger = LogManager.GetLogger(typeof(aicd_scholarship));
                logger.Error(e);

                return new { Success = false, ValidateResult = new List<ValidationResult> { new ValidationResult("Error occured while processing the last request. Please try again.", new List<string> { "form_error" }) } };
            }

            return new { Success = true };
        }


        #region STEP3: DirectorshipExperience Web Methods

        [WebMethod]
        public static object DirectorshipExperienceAdd(DirectorshipExperience model)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            ValidationContext context = new ValidationContext(model, null, null); ;
            List<ValidationResult> dataAnnotationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, dataAnnotationResults, true);

            if (dataAnnotationResults.Count() > 0)
                return new { Success = false, ValidateResult = dataAnnotationResults };

            List<ValidationResult> logicResults = logicResults = model.LogicValidate();
            if (logicResults.Count() > 0)
                return new { Success = false, ValidateResult = logicResults };

            //store to session
            StoreFormToSession(3, new AicdSponsorshipModel { tab3 = new List<DirectorshipExperience> { model } });

            //get full list for display
            List<DirectorshipExperience> fullCurrentList = GetFormDataFromSession().tab3;

            return new { Success = true, ExperienceList = fullCurrentList };
        }

        [WebMethod]
        public static object DirectorshipExperienceRemove(string guid)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            List<DirectorshipExperience> fullCurrentList = DeleteDirectorshipExperience(guid);

            return new { Success = true, ExperienceList = fullCurrentList };
        }

        [WebMethod]
        public static object DirectorshipExperienceEdit(string guid)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            DirectorshipExperience experience = DirectorshipExperienceGet(guid);

            if (experience == null)
                return new { Success = false };
            else
                return new { Success = true, Experience = experience };
        }

        #endregion

        #region STEP4: ProfessionalExperience Web Methods

        [WebMethod]
        public static object ProfessionalExperienceAdd(ProfessionalExperience model)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            ValidationContext context = new ValidationContext(model, null, null); ;
            List<ValidationResult> dataAnnotationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, dataAnnotationResults, true);

            if (dataAnnotationResults.Count() > 0)
                return new { Success = false, ValidateResult = dataAnnotationResults };

            List<ValidationResult> logicResults = logicResults = model.LogicValidate();
            if (logicResults.Count() > 0)
                return new { Success = false, ValidateResult = logicResults };

            //store to session
            StoreFormToSession(4, new AicdSponsorshipModel { tab4 = new List<ProfessionalExperience> { model } });

            //get full list for display
            List<ProfessionalExperience> fullCurrentList = GetFormDataFromSession().tab4;

            return new { Success = true, ExperienceList = fullCurrentList };
        }

        [WebMethod]
        public static object ProfessionalExperienceRemove(string guid)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            List<ProfessionalExperience> fullCurrentList = DeleteProfessionalExperience(guid);

            return new { Success = true, ExperienceList = fullCurrentList };
        }

        [WebMethod]
        public static object ProfessionalExperienceEdit(string guid)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return new { Success = false, Session = "Your Session has expired, Reloading the application now." };
            }

            ProfessionalExperience experience = ProfessionalExperienceGet(guid);

            if (experience == null)
                return new { Success = false };
            else
                return new { Success = true, Experience = experience };
        }

        #endregion

        #region STEP5: Qualifications Web Methods

        [WebMethod]
        public static object QualificationAdd(Qualifications model)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            ValidationContext context = new ValidationContext(model, null, null); ;
            List<ValidationResult> dataAnnotationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, dataAnnotationResults, true);

            if (dataAnnotationResults.Count() > 0)
                return new { Success = false, ValidateResult = dataAnnotationResults };

            List<ValidationResult> logicResults = logicResults = model.LogicValidate();
            if (logicResults.Count() > 0)
                return new { Success = false, ValidateResult = logicResults };

            //store to session
            StoreFormToSession(5, new AicdSponsorshipModel { tab5 = new Tab5Model { _isFromPageSubmit = false, qualifications = new List<Qualifications> { model } } });

            //get full list for display
            List<Qualifications> fullCurrentList = GetFormDataFromSession().tab5.qualifications;

            return new { Success = true, ExperienceList = fullCurrentList };
        }

        [WebMethod]
        public static object QualificationRemove(string guid)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            List<Qualifications> fullCurrentList = DeleteQualification(guid);

            return new { Success = true, ExperienceList = fullCurrentList };
        }

        [WebMethod]
        public static object QualificationEdit(string guid)
        {
            // Check if Session Expired.
            if (HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] == null)
            {
                return ReturnSessionIsExpired();
            }

            Qualifications experience = QualificationsGet(guid);

            if (experience == null)
                return new { Success = false };
            else
                return new { Success = true, Experience = experience };
        }

        #endregion

        #endregion

        #region Private Helpers/Methods

        /// <summary>
        /// This method handles all of the server side validation. Both data annotation validation and logic validation is checked.
        /// </summary>
        /// <param name="tabNumber"></param>
        /// <param name="model"></param>
        /// <returns>The validation errors generated from data annotation errors first if any, then logic validation errors if any.</returns>
        private static List<ValidationResult> ValidateModel(int tabNumber, AicdSponsorshipModel model)
        {
            ValidationContext context = null;
            List<ValidationResult> logicResults = new List<ValidationResult>();
            List<ValidationResult> dataAnnotationResults = new List<ValidationResult>();

            switch (tabNumber)
            {
                case 1:

                    //logicResults = model.tab1.LogicValidate();

                    return logicResults;                    
                case 2:
                    context = new ValidationContext(model.tab2, null, null);
                    Validator.TryValidateObject(model.tab2, context, dataAnnotationResults, true);
                    if (dataAnnotationResults.Count() == 0)
                    {
                        logicResults = model.tab2.LogicValidate();
                        return logicResults;
                    }
                    else
                        return dataAnnotationResults;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                    /*context = new ValidationContext(model.tab6, null, null);
                    Validator.TryValidateObject(model.tab6, context, dataAnnotationResults, true);
                    if (dataAnnotationResults.Count() == 0)
                    {
                        logicResults = model.tab6.LogicValidate();
                        return logicResults;
                    }
                    else
                        return dataAnnotationResults;*/
                case 7:
                    context = new ValidationContext(model.tab7, null, null);
                    Validator.TryValidateObject(model.tab7, context, dataAnnotationResults, true);
                    if (dataAnnotationResults.Count() == 0)
                    {
                        logicResults = model.tab7.LogicValidate();
                        return logicResults;
                    }
                    else
                        return dataAnnotationResults;
                case 8:

                    logicResults = model.tab8.LogicValidate();

                    return logicResults;    
                case 9:
                    break;
            }

            return new List<ValidationResult>();

        }

        private static object ReturnSessionIsExpired()
        {
            return new { Success = false, Session = "Your Session has expired, Reloading the application now." };
         
        }

        /// <summary>
        /// This method handles all of the store to session requests.
        /// </summary>
        /// <param name="tabNumber">The tab number</param>
        private static void StoreFormToSession(int tabNumber, AicdSponsorshipModel newModel)
        {
            //check existing model in session
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (currentModel == null)
                currentModel = new AicdSponsorshipModel();

            //switch tabNumber and perform store to session base on the tab number and input model
            switch (tabNumber)
            {
                case -1: //use this for save draft calls
                    currentModel.tab1 = newModel.tab1;
                    currentModel.tab2 = newModel.tab2;
                    //currentModel.tab5 = newModel.tab5;

                    currentModel.tab5.AreYouMemberOfAICD = newModel.tab5.AreYouMemberOfAICD;
                    currentModel.tab5.CPA = newModel.tab5.CPA;
                    currentModel.tab5.CSA = newModel.tab5.CSA;
                    currentModel.tab5.EA = newModel.tab5.EA;
                    currentModel.tab5.ICAA = newModel.tab5.ICAA;
                    currentModel.tab5.IntDirectorshipOrg = newModel.tab5.IntDirectorshipOrg;
                    currentModel.tab5.LawSociety = newModel.tab5.LawSociety;
                    currentModel.tab5.Other_Specify = newModel.tab5.Other_Specify;

                    currentModel.tab7 = newModel.tab7;
                    currentModel.tab8 = newModel.tab8;

                    
                    break;
                case 1:
                    currentModel.tab1 = newModel.tab1;
                    break;
                case 2:
                    currentModel.tab2 = newModel.tab2;
                    break;
                case 3:
                    DirectorshipExperience submittedDirectorExp = newModel.tab3.First();
                    //new exp record
                    if (string.IsNullOrEmpty(submittedDirectorExp.internalGUID))
                    {
                        //generate a guid for this exp model
                        submittedDirectorExp.internalGUID = Guid.NewGuid().ToString();
                        currentModel.tab3.Add(submittedDirectorExp);
                    }
                    else //edit existing record 
                    {
                        //get the list of the non-related records
                        List<DirectorshipExperience> existingExps = (from m in currentModel.tab3 where m.internalGUID.ToUpper() != submittedDirectorExp.internalGUID.ToUpper() select m).ToList();
                        //add the new list
                        existingExps.Add(submittedDirectorExp);
                        currentModel.tab3 = existingExps;
                    }
                    //preform sort
                    currentModel.tab3 = (from exp in currentModel.tab3
                                         orderby
                                         !exp.directorshipIsCurrent,
                                         new DateTime(exp.dirEndDateYear, exp.dirStartDateMonth, 1) descending,
                                         new DateTime(exp.dirStartDateYear, exp.dirEndDateMonth, 1) descending
                                         select exp).ToList();
                    break;
                case 4:
                    ProfessionalExperience submittedProfExp = newModel.tab4.First();
                    //new exp record
                    if (string.IsNullOrEmpty(submittedProfExp.internalGUID))
                    {
                        //generate a guid for this exp model
                        submittedProfExp.internalGUID = Guid.NewGuid().ToString();
                        currentModel.tab4.Add(submittedProfExp);
                    }
                    else //edit existing record
                    {
                        //get the list of the non-related records
                        List<ProfessionalExperience> existingExps = (from m in currentModel.tab4 where m.internalGUID.ToUpper() != submittedProfExp.internalGUID.ToUpper() select m).ToList();
                        //add the new list
                        existingExps.Add(submittedProfExp);
                        currentModel.tab4 = existingExps;
                    }
                    //preform sort
                    currentModel.tab4 = (from exp in currentModel.tab4
                                         orderby
                                         !exp.profIsCurrent,
                                         new DateTime(exp.profEndDateYear, exp.profEndDateMonth, 1) descending,
                                         new DateTime(exp.profStartDateYear, exp.profStartDateMonth, 1) descending
                                         select exp).ToList();
                    break;
                case 5:

                    if (newModel.tab5._isFromPageSubmit)
                    {
                        currentModel.tab5.AreYouMemberOfAICD = newModel.tab5.AreYouMemberOfAICD;
                        currentModel.tab5.CPA = newModel.tab5.CPA;
                        currentModel.tab5.CSA = newModel.tab5.CSA;
                        currentModel.tab5.EA = newModel.tab5.EA;
                        currentModel.tab5.ICAA = newModel.tab5.ICAA;
                        currentModel.tab5.IntDirectorshipOrg = newModel.tab5.IntDirectorshipOrg;
                        currentModel.tab5.LawSociety = newModel.tab5.LawSociety;
                        currentModel.tab5.Other_Specify = newModel.tab5.Other_Specify;
                    }
                    else
                    {
                        Qualifications submittedQualification = newModel.tab5.qualifications.First();
                        //new exp record
                        if (string.IsNullOrEmpty(submittedQualification.internalGUID))
                        {
                            //generate a guid for this exp model
                            submittedQualification.internalGUID = Guid.NewGuid().ToString();
                            currentModel.tab5.qualifications.Add(submittedQualification);
                        }
                        else //edit existing record
                        {
                            //get the list of the non-related records
                            List<Qualifications> existingQualifactions = (from m in currentModel.tab5.qualifications where m.internalGUID.ToUpper() != submittedQualification.internalGUID.ToUpper() select m).ToList();
                            //add the new list
                            existingQualifactions.Add(submittedQualification);
                            currentModel.tab5.qualifications = existingQualifactions;
                        }
                        //preform sort
                        currentModel.tab5.qualifications = (from exp in currentModel.tab5.qualifications
                                                            orderby
                                                            !exp.qIsCurrent,
                                                            new DateTime(exp.qEndDateYear, exp.qEndDateMonth, 1) descending,
                                                            new DateTime(exp.qStartDateYear, exp.qStartDateMonth, 1) descending
                                                            select exp).ToList();
                    }
                    break;
                case 6:
                    //currentModel.tab6 = newModel.tab6;
                    break;
                case 7:
                    currentModel.tab7 = newModel.tab7;
                    break;
                case 8:
                    currentModel.tab8 = newModel.tab8;
                    break;
            }

            //place back to the session
            HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] = currentModel;

        }

        #region STEP3: DirectorshipExperience Session Methods

        private static List<DirectorshipExperience> DeleteDirectorshipExperience(string guid)
        {
            //check existing model in session
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            List<DirectorshipExperience> expToKeep = (from m in currentModel.tab3 where m.internalGUID.ToUpper() != guid.ToUpper() select m).ToList();
            currentModel.tab3 = expToKeep;

            HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] = currentModel;

            return expToKeep;
        }

        private static DirectorshipExperience DirectorshipExperienceGet(string guid)
        {
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (currentModel != null)
            {
                return (from m in currentModel.tab3 where m.internalGUID.ToUpper() == guid.ToUpper() select m).FirstOrDefault();
            }
            return null;
        }

        private static bool DirectorshipExperienceHasRecords()
        {
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (currentModel == null || currentModel.tab3.Count() == 0)
                return false;

            return true;
        }

        #endregion

        #region STEP4: ProfessionalExperience Session Methods
        private static List<ProfessionalExperience> DeleteProfessionalExperience(string guid)
        {
            //check existing model in session
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            List<ProfessionalExperience> expToKeep = (from m in currentModel.tab4 where m.internalGUID.ToUpper() != guid.ToUpper() select m).ToList();
            currentModel.tab4 = expToKeep;

            HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] = currentModel;

            return expToKeep;
        }

        private static ProfessionalExperience ProfessionalExperienceGet(string guid)
        {
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (currentModel != null)
            {
                return (from m in currentModel.tab4 where m.internalGUID.ToUpper() == guid.ToUpper() select m).FirstOrDefault();
            }
            return null;
        }

        private static bool ProfessionalExperienceHasRecords()
        {
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (currentModel == null || currentModel.tab4.Count() == 0)
                return false;

            return true;
        }
        #endregion

        #region STEP5: Qualifications Session Methods
        private static List<Qualifications> DeleteQualification(string guid)
        {
            //check existing model in session
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            List<Qualifications> expToKeep = (from m in currentModel.tab5.qualifications where m.internalGUID.ToUpper() != guid.ToUpper() select m).ToList();
            currentModel.tab5.qualifications = expToKeep;

            HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY] = currentModel;

            return expToKeep;
        }

        private static Qualifications QualificationsGet(string guid)
        {
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (currentModel != null)
            {
                return (from m in currentModel.tab5.qualifications where m.internalGUID.ToUpper() == guid.ToUpper() select m).FirstOrDefault();
            }
            return null;
        }

        private static bool QualificationsHasRecords()
        {
            AicdSponsorshipModel currentModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (currentModel == null || currentModel.tab5.qualifications.Count() == 0)
                return false;

            return true;
        }
        #endregion

        private static AicdSponsorshipModel GetFormDataFromSession()
        {
            AicdSponsorshipModel cFormModel = (AicdSponsorshipModel)HttpContext.Current.Session[PortalConstants.Session.SESSION_FORMDATA_KEY];

            if (cFormModel == null) return new AicdSponsorshipModel();

            return cFormModel;
        }

        #endregion
    }



}