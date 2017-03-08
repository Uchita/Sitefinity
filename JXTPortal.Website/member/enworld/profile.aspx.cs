using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Client.Salesforce;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.Services;
using System.ComponentModel.DataAnnotations;
using JXTPortal.Entities;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using JXTPortal.Common;
using JXTPortal.Common.Extensions;

namespace JXTPortal.Website.member.enworld
{
    public partial class profile : System.Web.UI.Page
    {
        private static string EmailValidationRegex = ConfigurationManager.AppSettings["EmailValidationRegex"];
        private string XMLPath = "/xml/enworld.xml";
        private const string ENWORLD_SF_QUERY = @"SELECT Id, FirstName, LastName, First_Name_Local__c, Last_Name_Local__c, Email, 
                                                    RecordTypeId, ts2__EEO_Gender__c, Birthdate, MobilePhone, Phone, Secondary_Email__c ,MailingStreet, MailingCity, MailingPostalCode, MailingState, MailingCountry,English_Language_Level__c,Japanese_Language_Level__c,Third_Language__c,Third_Language_Proficiency__c,
                                                    Current_Company__c, Current_Position__c, Industry__c, Job_Category__c, Job_Functions__c, Employment_Type__c, Salary_Period__c, Current_Fixed_Salary__c, Annual_Variable_Salary__c, 
                                                    Desired_Country__c, Desired_Locations__c, Employment_Preference__c, Desired_Industry__c, Desired_Job_Category__c, Desired_Job_Functions__c, Desired_Other_Countries__c, CurrencyIsoCode
                                                    FROM CONTACT where Id = '{0}'";

        public string _SFContactID;
        private SalesforceIntegration.SObjDescribeResponse _SFFormModel;
        private SalesforceIntegration.SObjBatchObject _SFContactModel;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            //redirect to custom
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
            !ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SessionData.Site.MasterSiteId + " "))
            {
                Response.Redirect("/member/default.aspx");
                return;
            }

            CommonPage.SetBrowserPageTitle(Page, "Update Profile");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _SFContactID = SFContactIDGetFromSessionMember();
            tbDOB.Attributes.Add("placeholder", SessionData.Site.DateFormat.ToLower());

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(_SFContactID))
                {
                    bool isSFRecordCreated = false;
                    //if the current user has no SFContactID, we get the record from SF and save to DB
                    MembersService _ms = new MembersService();
                    Entities.Members thisMember = _ms.GetByMemberId(SessionData.Member.MemberId);

                    SalesforceMemberSync sfSync = new SalesforceMemberSync();
                    sfSync.CheckContactAndSaveInSalesForce(thisMember, SessionData.Site.SiteId, false, out _SFContactID, out isSFRecordCreated);

                    if (string.IsNullOrEmpty(_SFContactID))
                    {
                        //If still can not locate SFContactID, we FAILED
                        ltGeneralMessage.Text = Common.Utils.MessageDisplayWrapper("Unable to validate member record. Please contact support.", Common.BootstrapAlertType.Danger);
                        plCVBuilder.Visible = false;
                        return;
                    }

                    //if we created a new record on SF using a local member record, we have to unload the resumes from the member record to SF too
                    if (isSFRecordCreated)
                    {
                        MemberFilesService _mfs = new MemberFilesService();
                        using (TList<MemberFiles> thisMemberFiles = _mfs.GetByMemberId(thisMember.MemberId))
                        {
                            foreach (MemberFiles f in thisMemberFiles)
                            {
                                byte[] memberfilecontent = null;

                                if (!string.IsNullOrWhiteSpace(f.MemberFileUrl))
                                {
                                    string errormessage = string.Empty;

                                    FtpClient ftpclient = new FtpClient();
                                    ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                                    ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                    ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                                    string filepath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], f.MemberId, f.MemberFileUrl);
                                    Stream ms = null;
                                    ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);

                                    if (string.IsNullOrEmpty(errormessage))
                                    {
                                        ms.Position = 0;
                                        memberfilecontent = ((MemoryStream)ms).ToArray();
                                    }
                                }
                                else
                                {
                                    memberfilecontent = f.MemberFileContent;
                                }

                                bool uploadToSFSuccess = ResumeUploadToSF(memberfilecontent, f.MemberFileName);
                            }
                        }
                    }
                }

                //bool dataGetSuccess = FormGetFromSF();
                //if (!dataGetSuccess)
                //{
                //    ltGeneralMessage.Text = Common.Utils.MessageDisplayWrapper("Unable to connect to integration service. Please contact support.", Common.BootstrapAlertType.Danger);
                //    plCVBuilder.Visible = false;
                //    return;
                //}

                //Now we can get the enworld specific fields from SF
                bool data2GetSuccess = FormGetObjectsFromSF();

                if (data2GetSuccess)
                {
                    //update to database
                    SalesforceIntegration.SObjRecord thisContact = _SFContactModel.results[0].result.records[0];

                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    string json = ser.Serialize(thisContact);

                    MembersService _ms = new MembersService();
                    _ms.SetMemberCandidateData(SessionData.Member.MemberId, json);
                    _ms = null;
                }
                else
                {
                    ltGeneralMessage.Text = Common.Utils.MessageDisplayWrapper("Unable to connect to integration service. Please contact support.", Common.BootstrapAlertType.Danger);
                    plCVBuilder.Visible = false;
                    return;
                }

                PreserveDataToJavascript();

                FormSetup();
            }
        }


        private void PreserveDataToJavascript()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<script type=""text/javascript"">");

            #region Describes

            #region Country / State

            List<object> countryStates = XMLMultiValueListGet("country", "states");

            sb.Append("countryData = jQuery.parseJSON('" + ser.Serialize(countryStates).Replace("\\", "\\\\") + "');\n");

            #endregion

            #region Desired Country / Location

            List<object> dCountryLoc = XMLMultiValueListGet("desiredcountry", "locations");

            sb.Append("desiredCountryData = jQuery.parseJSON('" + ser.Serialize(dCountryLoc).Replace("\\", "\\\\") + "');\n");

            #endregion

            #region Job Category / Job Functions
            List<object> jobCateFunc = XMLMultiValueListGet("jobcategory", "jobfunctions");

            sb.Append("jobFuncData = jQuery.parseJSON('" + ser.Serialize(jobCateFunc).Replace("\\", "\\\\") + "');\n");
            #endregion

            #endregion

            #region Data

            //SalesforceIntegration.SObjResults experienceData = new SalesforceIntegration.SObjResults { result = new SalesforceIntegration.SObjResult { records = new List<SalesforceIntegration.SObjRecord>() } };

            //if (experienceData != null)
            //{
            //    SalesforceIntegration.SObjResult Sector_Experience = experienceData.result;
            //    sb.Append("experienceStore = jQuery.parseJSON('" + ser.Serialize(Sector_Experience.records) + "');\n");
            //}




            #endregion


            sb.Append(@"</script>");

            ModelPreserveJSBlock.Text = sb.ToString();
        }


        #region Form Setup
        private void FormSetup()
        {
            Tab1Setup();
            Tab2Setup();
            Tab3Setup();

            SetupPlaceholdersAndLangRelated();

            PopulateDataToForm();
        }

        private void SetupPlaceholdersAndLangRelated()
        {
            tbMobilePhone.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPhoneMobileFull"));
            tbHomePhone.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelPhoneHomeFull"));
            tbSecondEmail.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelSecondaryEmail"));
            tbAddress1.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelAddress"));
            tbCity.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCity"));
            tbCurrentCompany.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCurrentCompanyName"));
            tbCurrentJobTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelCurrentJobTitle"));
            tbFixedSalary.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelFixedSalary"));
            tbIncentiveSalary.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelIncentiveSalary"));
            fileUploadTitle.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelFileTitle"));
            tbZip.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelZipCodePlaceholder"));


            btnUpload.Text = CommonFunction.GetResourceValue("LabelUploadFile");
        }

        private void PopulateDataToForm()
        {
            SalesforceIntegration.SObjRecord thisContact = _SFContactModel.results[0].result.records[0];

            #region Tab 1
            ddlGender.SelectedValue = thisContact.ts2__EEO_Gender__c;
            //tbDOB.Text = thisContact.Birthdate;

            if (!string.IsNullOrEmpty(thisContact.Birthdate))
            {
                string[] dobSplit = thisContact.Birthdate.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    DateTime dt = new DateTime(int.Parse(dobSplit[0]), int.Parse(dobSplit[1]), int.Parse(dobSplit[2]));
                    tbDOB.Text = string.Format("{0}-{1}-{2}", dt.Day, dt.Month, dt.Year);
                }
                catch (Exception e)
                {
                }
            }
            tbMobilePhone.Text = thisContact.MobilePhone;
            tbHomePhone.Text = thisContact.Phone;
            ddlCountry.SelectedValue = thisContact.MailingCountry;
            tbSecondEmail.Text = thisContact.Secondary_Email__c;
            tbAddress1.Text = thisContact.MailingStreet;
            tbCity.Text = thisContact.MailingCity;
            ddlState.SelectedValue = thisContact.MailingState;
            tbZip.Text = thisContact.MailingPostalCode;
            //TODO:
            ddlEnglishLanguageLevel.SelectedValue = thisContact.English_Language_Level__c;
            ddlJapaneseLanguageLevel.SelectedValue = thisContact.Japanese_Language_Level__c;
            ddlOtherLanguage.SelectedValue = thisContact.Third_Language__c;
            ddlOtherLanguageLevel.SelectedValue = thisContact.Third_Language_Proficiency__c;
            #endregion

            #region Tab 2

            tbCurrentCompany.Text = thisContact.Current_Company__c;
            tbCurrentJobTitle.Text = thisContact.Current_Position__c;
            ddlIndustry.SelectedValue = thisContact.Industry__c;
            ddlJobCategory.SelectedValue = thisContact.Job_Category__c;
            if (!string.IsNullOrEmpty(thisContact.Job_Category__c))
            {
                #region setup Job Functions Dropdown

                List<string> jobFuncDDValues = XMLPullMultiValue("jobcategory", "jobfunctions", thisContact.Job_Category__c);

                var jobFuncSelectableValues = (from m in jobFuncDDValues select new { text = m, value = m }).ToList();

                ddlJobFunctions.DataSource = jobFuncSelectableValues;
                ddlJobFunctions.DataTextField = "text";
                ddlJobFunctions.DataValueField = "value";
                ddlJobFunctions.DataBind();

                if (!string.IsNullOrEmpty(thisContact.Job_Functions__c))
                {
                    foreach (string jobFuncValue in thisContact.Job_Functions__c.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        foreach (ListItem listitem in ddlJobFunctions.Items)
                        {
                            if (listitem.Value == jobFuncValue)
                            {
                                listitem.Selected = true;
                                break;
                            }
                        }
                    }
                }
                #endregion
            }

            ddlEmploymentType.SelectedValue = thisContact.Employment_Type__c;
            ddlSalaryPeriod.SelectedValue = thisContact.Salary_Period__c;
            tbFixedSalary.Text = thisContact.Current_Fixed_Salary__c;
            tbIncentiveSalary.Text = thisContact.Annual_Variable_Salary__c;

            ddlSalaryCurrency.SelectedValue = thisContact.CurrencyIsoCode;

            #endregion

            #region Tab 3

            ddlPrimDesiredCountry.SelectedValue = thisContact.Desired_Country__c;
            if (!string.IsNullOrEmpty(thisContact.Desired_Locations__c))
            {
                List<string> desiredLocDDValues = XMLPullMultiValue("desiredcountry","locations", thisContact.Desired_Country__c);

                var desiredLocSelectableValues = (from m in desiredLocDDValues select new { text = m, value = m }).ToList();

                ddlPrimDesiredLocation.DataSource = desiredLocSelectableValues;
                ddlPrimDesiredLocation.DataTextField = "text";
                ddlPrimDesiredLocation.DataValueField = "value";
                ddlPrimDesiredLocation.DataBind();

                //if (ddlPrimDesiredCountry.Items.Count == 0)
                {
                    if (ddlPrimDesiredCountry.SelectedValue == "--None--")
                        ddlPrimDesiredLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectPrimaryDesiredCountry"), "--None--"));
                    else
                        ddlPrimDesiredLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLAllAreas"), "--None--"));
                }

                foreach (string desiredLocValue in thisContact.Desired_Locations__c.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    foreach (ListItem listitem in ddlPrimDesiredLocation.Items)
                    {
                        if (listitem.Value == desiredLocValue)
                        {
                            listitem.Selected = true;
                            break;
                        }
                    }
                }
            }

            //employment preference
            if (!string.IsNullOrEmpty(thisContact.Employment_Preference__c))
            {
                foreach (string empTypeValue in thisContact.Employment_Preference__c.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    foreach (ListItem listitem in ddlDesiredEmployType.Items)
                    {
                        if (listitem.Value == empTypeValue)
                        {
                            listitem.Selected = true;
                            break;
                        }
                    }
                }
            }

            ddlPrimDesiredIndustry.SelectedValue = thisContact.Desired_Industry__c;

            //Primary Desired Job Category / Function
            ddlPrimDesiredJobCategory.SelectedValue = thisContact.Desired_Job_Category__c;

            List<string> desiredJobFuncDDValues = XMLPullMultiValue("jobcategory", "jobfunctions", thisContact.Desired_Job_Category__c);

            var desiredJobFuncSelectableValues = (from m in desiredJobFuncDDValues select new { text = m, value = m }).ToList();

            ddlPrmDesiredJobFunction.DataSource = desiredJobFuncSelectableValues;
            ddlPrmDesiredJobFunction.DataTextField = "text";
            ddlPrmDesiredJobFunction.DataValueField = "value";
            ddlPrmDesiredJobFunction.DataBind();

            if (!string.IsNullOrEmpty(thisContact.Desired_Job_Functions__c))
            {
                List<string> primDesiredJobFunctions = thisContact.Desired_Job_Functions__c.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (ListItem item in ddlPrmDesiredJobFunction.Items)
                {
                    if (primDesiredJobFunctions.Contains(item.Value))
                        item.Selected = true;
                }
            }


            if (!string.IsNullOrEmpty(thisContact.Desired_Other_Countries__c))
            {
                List<string> secondDesiredCountries = thisContact.Desired_Other_Countries__c.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (secondDesiredCountries.Count() > 0)
                {
                    foreach (ListItem item in ddlSecondDesiredCountry.Items)
                    {
                        if (secondDesiredCountries.Contains(item.Value))
                            item.Selected = true;
                    }
                }
            }

            #endregion

        }

        private void Tab1Setup()
        {
            SalesforceIntegration.SObjRecord thisContact = _SFContactModel.results[0].result.records[0];

            #region DDL Gender
            List<string> genderDDValues = XMLPullValue("gender");

            var genderSelectableValues = (from m in genderDDValues select new { text = m, value = m }).ToList();

            ddlGender.DataSource = genderSelectableValues;
            ddlGender.DataTextField = "text";
            ddlGender.DataValueField = "value";
            ddlGender.DataBind();
            //ddlGender.Items.Insert(0, new ListItem("- Not Specified -", "--None--"));
            ddlGender.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLNotSpecified"), "--None--"));

            #endregion

            #region DDL Country / State
            List<string> countryDDValues = XMLPullValue("country");

            var countrySelectableValues = (from m in countryDDValues select new { text = m, value = m }).ToList();

            ddlCountry.DataSource = countrySelectableValues;
            ddlCountry.DataTextField = "text";
            ddlCountry.DataValueField = "value";
            ddlCountry.DataBind();
            //ddlCountry.Items.Insert(0, new ListItem("- Please Select -", "--None--"));
            ddlCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelect"), "--None--"));


            if (!string.IsNullOrEmpty(thisContact.MailingCountry))
            {
                List<string> stateDDValues = XMLPullMultiValue("country", "states", thisContact.MailingCountry);
                var stateSelectableValues = (from m in stateDDValues select new { text = m, value = m }).ToList();

                ddlState.DataSource = stateSelectableValues;
                // Code to fix the country dropdown not working 
                //List<ListItem> states = new List<ListItem>();
                //foreach (string state in stateDDValues)
                //{
                //    if (state.Contains("|"))
                //    {
                //        states.Add(new ListItem(state.Split(new char[] {'|'})[0], state.Split(new char[] {'|'})[1]));
                //    }
                //    else
                //    {
                //        states.Add(new ListItem(state));
                //    }
                //}

                //ddlState.DataSource = states;
                ddlState.DataTextField = "text";
                ddlState.DataValueField = "value";
                ddlState.DataBind();
            }

            //state default display
            //ddlState.Items.Insert(0, new ListItem("- Not Specified -", ""));
            ddlState.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLNotSpecified"), ""));

            #endregion

            #region DDL Languages
            List<string> languagesDDValues = XMLPullValue("language");
            var languagesSelectableValues = (from m in languagesDDValues select new { text = m, value = m }).ToList();

            ddlOtherLanguage.DataSource = languagesSelectableValues;
            ddlOtherLanguage.DataTextField = "text";
            ddlOtherLanguage.DataValueField = "value";
            ddlOtherLanguage.DataBind();
            //ddlOtherLanguage.Items.Insert(0, new ListItem("- Please Select -", "--None--"));
            ddlOtherLanguage.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLNotSpecified"), "--None--"));

            List<string> languageLevelsDDValues = XMLPullValue("languagelevel");
            var languageLevelsSelectableDDValues = (from m in languageLevelsDDValues select new { text = m, value = m }).ToList();

            ddlEnglishLanguageLevel.DataSource = languageLevelsSelectableDDValues;
            ddlEnglishLanguageLevel.DataTextField = "text";
            ddlEnglishLanguageLevel.DataValueField = "value";
            ddlEnglishLanguageLevel.DataBind();
            //ddlEnglishLanguageLevel.Items.Insert(0, new ListItem("- Please Select -", "--None--"));
            ddlEnglishLanguageLevel.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLNotSpecified"), "--None--"));

            ddlJapaneseLanguageLevel.DataSource = languageLevelsSelectableDDValues;
            ddlJapaneseLanguageLevel.DataTextField = "text";
            ddlJapaneseLanguageLevel.DataValueField = "value";
            ddlJapaneseLanguageLevel.DataBind();
            //ddlJapaneseLanguageLevel.Items.Insert(0, new ListItem("- Not Specified -", "--None--"));
            ddlJapaneseLanguageLevel.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLNotSpecified"), "--None--"));

            ddlOtherLanguageLevel.DataSource = languageLevelsSelectableDDValues;
            ddlOtherLanguageLevel.DataTextField = "text";
            ddlOtherLanguageLevel.DataValueField = "value";
            ddlOtherLanguageLevel.DataBind();
            //ddlOtherLanguageLevel.Items.Insert(0, new ListItem("- Not Specified -", "--None--"));
            ddlOtherLanguageLevel.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLNotSpecified"), "--None--"));

            #endregion
        }

        private void Tab2Setup()
        {
            #region DDL Industry
            List<string> industryDDValues = XMLPullValue("industry");

            var industrySelectableValues = (from m in industryDDValues select new { text = m, value = m }).ToList();

            ddlIndustry.DataSource = industrySelectableValues;
            ddlIndustry.DataTextField = "text";
            ddlIndustry.DataValueField = "value";
            ddlIndustry.DataBind();
            //ddlIndustry.Items.Insert(0, new ListItem("- Please select an Industry -", "--None--"));
            ddlIndustry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectIndustry"), "--None--"));
            #endregion

            #region DDL Employment Type
            List<string> employmentTypeDDValues = XMLPullValue("employmenttype");

            var employmentTypeSelectableValues = (from m in employmentTypeDDValues select new { text = m, value = m }).ToList();

            ddlEmploymentType.DataSource = employmentTypeSelectableValues;
            ddlEmploymentType.DataTextField = "text";
            ddlEmploymentType.DataValueField = "value";
            ddlEmploymentType.DataBind();
            #endregion

            #region DDL Salary Period
            List<string> salaryDDValues = XMLPullValue("salaryperiod");

            var salarySelectableValues = (from m in salaryDDValues select new { text = m, value = m }).ToList();

            ddlSalaryPeriod.DataSource = salarySelectableValues;
            ddlSalaryPeriod.DataTextField = "text";
            ddlSalaryPeriod.DataValueField = "value";
            ddlSalaryPeriod.DataBind();

            #endregion

            #region DDL Job Category / Job Functions
            List<string> jobCateDDValues = XMLPullValue("jobcategory");

            var jobCateSelectableValues = (from m in jobCateDDValues select new { text = m, value = m }).ToList();

            ddlJobCategory.DataSource = jobCateSelectableValues;
            ddlJobCategory.DataTextField = "text";
            ddlJobCategory.DataValueField = "value";
            ddlJobCategory.DataBind();

            //ddlJobCategory.Items.Insert(0, new ListItem("- Please select a Job Category -", "--None--"));
            ddlJobCategory.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectJobCategory"), "--None--"));

            //ddlJobFunctions.Items.Insert(0, new ListItem("- Please select a Job Category -", "--None--"));
            ddlJobFunctions.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectJobCategory"), "--None--"));

            #endregion

            #region DDL Salary Currency
            string errorMsg;
            SalesforceIntegration.SObjDescribeResponse descResp;
            bool contactGetSuccess = new SalesforceIntegration(SessionData.Site.SiteId)
                                    .PostSObjectDescribeBatchRequest(new string[]
                                        {
                                            "Contact"
                                        }, out descResp, out errorMsg);
            if (contactGetSuccess)
            {
                SalesforceIntegration.SObjField currencyField = descResp.results.First().result.fields.Where(c => c.name.Equals("Salary_Currency__c")).FirstOrDefault();

                ddlSalaryCurrency.DataSource = currencyField.picklistValues;
                ddlSalaryCurrency.DataTextField = "label";
                ddlSalaryCurrency.DataValueField = "value";
                ddlSalaryCurrency.DataBind();

            }
            #endregion
        }

        private void Tab3Setup()
        {
            #region DDL Desired Country / Location
            IEnumerable<string> desiredCountryDDValues = XMLPullValue("desiredcountry").OrderBy(c => c);

            var dCountrySelectableValues = (from m in desiredCountryDDValues select new { text = m, value = m }).ToList();

            ddlPrimDesiredCountry.DataSource = dCountrySelectableValues;
            ddlPrimDesiredCountry.DataTextField = "text";
            ddlPrimDesiredCountry.DataValueField = "value";
            ddlPrimDesiredCountry.DataBind();

            //ddlPrimDesiredCountry.Items.Insert(0, new ListItem("- Please select a Country -", "--None--"));
            ddlPrimDesiredCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectCountry"), "--None--"));

            ddlSecondDesiredCountry.DataSource = dCountrySelectableValues;
            ddlSecondDesiredCountry.DataTextField = "text";
            ddlSecondDesiredCountry.DataValueField = "value";
            ddlSecondDesiredCountry.DataBind();
            #endregion

            #region DDL Employment Type
            List<string> employmentTypeDDValues = XMLPullValue("employmenttype");

            var employmentTypeSelectableValues = (from m in employmentTypeDDValues select new { text = m, value = m }).ToList();

            ddlDesiredEmployType.DataSource = employmentTypeSelectableValues;
            ddlDesiredEmployType.DataTextField = "text";
            ddlDesiredEmployType.DataValueField = "value";
            ddlDesiredEmployType.DataBind();
            #endregion

            #region DDL Desired Industry
            List<string> industryDDValues = XMLPullValue("industry");

            var industrySelectableValues = (from m in industryDDValues select new { text = m, value = m }).ToList();

            ddlPrimDesiredIndustry.DataSource = industrySelectableValues;
            ddlPrimDesiredIndustry.DataTextField = "text";
            ddlPrimDesiredIndustry.DataValueField = "value";
            ddlPrimDesiredIndustry.DataBind();

            //ddlPrimDesiredIndustry.Items.Insert(0, new ListItem("- Please select an Industry -", "--None--"));
            ddlPrimDesiredIndustry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectIndustry"), "--None--"));
            #endregion

            #region DDL Desired Job Category / Job Functions
            List<string> jobCateDDValues = XMLPullValue("jobcategory");

            var jobCateSelectableValues = (from m in jobCateDDValues select new { text = m, value = m }).ToList();

            ddlPrimDesiredJobCategory.DataSource = jobCateSelectableValues;
            ddlPrimDesiredJobCategory.DataTextField = "text";
            ddlPrimDesiredJobCategory.DataValueField = "value";
            ddlPrimDesiredJobCategory.DataBind();

            //ddlPrimDesiredJobCategory.Items.Insert(0, new ListItem("- Please select a Job Category -", "--None--"));
            ddlPrimDesiredJobCategory.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectJobCategory"), "--None--"));

            //ddlPrmDesiredJobFunction.Items.Insert(0, new ListItem("- Please select a Job Category -", "--None--"));
            ddlPrmDesiredJobFunction.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectJobCategory"), "--None--"));

            #endregion

            #region Resume

            MemberFilesService _mfs = new MemberFilesService();
            List<MemberFiles> memberFiles = _mfs.GetByMemberId(SessionData.Member.MemberId).ToList();
            rptResume.DataSource = memberFiles;
            rptResume.DataBind();

            if (memberFiles.Count() > 0)
                plUploadFileTable.Visible = true;

            if (memberFiles.Count() >= 3)
                phFileUpload.Visible = false;

            #endregion

        }

        #endregion


        private bool FormGetObjectsFromSF()
        {
            //get from salesforce
            SalesforceIntegration sfInt = new SalesforceIntegration();
            string errorMsg;
            bool contactGetSuccess = sfInt.PostSObjectBatchRequest(new string[]
                                        {
                                            string.Format(ENWORLD_SF_QUERY, _SFContactID)
                                        }, out _SFContactModel, out errorMsg);

            if (!contactGetSuccess)
            {
                //show error message
            }
            return contactGetSuccess;
        }

        protected void ddlPrimDesiredCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPrimDesiredLocation.Items.Clear();

            //load
            List<string> desiredLocDDValues = XMLPullMultiValue("desiredcountry", "locations", ddlPrimDesiredCountry.SelectedValue);

            var dLocSelectableValues = (from m in desiredLocDDValues select new { text = m, value = m }).ToList();

            ddlPrimDesiredLocation.DataSource = dLocSelectableValues;
            ddlPrimDesiredLocation.DataTextField = "text";
            ddlPrimDesiredLocation.DataValueField = "value";
            ddlPrimDesiredLocation.DataBind();

            if (dLocSelectableValues.Count() == 0)
            {
                if (ddlPrimDesiredCountry.SelectedValue == "--None--")
                    ddlPrimDesiredLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectJobCategory"), "--None--"));
                else
                    ddlPrimDesiredLocation.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLAllAreas"), "--None--"));
            }

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click(); MultiselectInit(); })", true);
        }

        protected void ddlPrimDesiredJobCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPrmDesiredJobFunction.Items.Clear();

            //load
            List<string> desiredFuncDDValues = XMLPullMultiValue("jobcategory", "jobfunctions", ddlPrimDesiredJobCategory.SelectedValue);

            var dFuncSelectableValues = (from m in desiredFuncDDValues select new { text = m, value = m }).ToList();

            ddlPrmDesiredJobFunction.DataSource = dFuncSelectableValues;
            ddlPrmDesiredJobFunction.DataTextField = "text";
            ddlPrmDesiredJobFunction.DataValueField = "value";
            ddlPrmDesiredJobFunction.DataBind();

            if (dFuncSelectableValues.Count() == 0)
            {
                if (ddlPrimDesiredJobCategory.SelectedValue == "--None--")
                    ddlPrmDesiredJobFunction.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLPleaseSelectPrimaryDesiredJobCategory"), "--None--"));
                else
                    ddlPrmDesiredJobFunction.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("DDLAllAreas"), "--None--"));
            }

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click(); MultiselectInit(); })", true);
        }


        #region Databinds

        protected void rptResume_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltCol0 = e.Item.FindControl("ltCol0") as Literal;

                Literal ltFileTitle = e.Item.FindControl("resumeFileTitle") as Literal;
                Literal ltResumeName = e.Item.FindControl("resumeFileName") as Literal;
                Literal ltResumeUploadDate = e.Item.FindControl("resumeUploadDate") as Literal;
                LinkButton lbRemove = e.Item.FindControl("lbRemove") as LinkButton;

                MemberFiles thisFile = e.Item.DataItem as MemberFiles;
                ltFileTitle.Text = thisFile.MemberFileTitle;
                ltResumeName.Text = thisFile.MemberFileName;
                ltResumeUploadDate.Text = String.Format("{0:" + SessionData.Site.DateFormat + "}", thisFile.LastModifiedDate);
                lbRemove.CommandArgument = thisFile.MemberFileId.ToString();
            }
        }

        #endregion

        #region Click Events

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            FileUploadMessage.Text = string.Empty;

            if (fuTest.HasFile && fuTest.PostedFile.ContentLength > 0)
            {
                MemberFiles mf = new MemberFiles();
                MemberFilesService _mfs = new MemberFilesService();

                if (string.IsNullOrEmpty(fileUploadTitle.Text))
                {
                    //display message
                    FileUploadMessage.Text = "Resume title is required";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click()})", true);
                    return;
                }

                if (!string.IsNullOrEmpty(fileUploadTitle.Text))
                {
                    if (!fileUploadTitle.Text.IsValidContent())
                    {
                        FileUploadMessage.Text = "Resume File Name cannot contain invalid content";
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click()})", true);
                        return;
                    }
                }

                if (_mfs.GetByMemberId(SessionData.Member.MemberId).Where(c => c.DocumentTypeId == 2).Count() >= 3)
                {
                    //can not have more than 3
                    FileUploadMessage.Text = "You can only upload up to 3 resumes";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click()})", true);
                    return;
                }

                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    mf.MemberFileName = System.IO.Path.GetFileName(fuTest.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                }
                mf.MemberFileSearchExtension = System.IO.Path.GetExtension(fuTest.PostedFile.FileName).Trim();

                bool found = false;

                foreach (string ext in ConfigurationManager.AppSettings["ApplicationFileTypes"].Split(new char[] { ',' }))
                {
                    if (ext == mf.MemberFileSearchExtension)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    //error, display message
                    FileUploadMessage.Text = "Uploaded file type is not accepted";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click()})", true);
                    return;
                }
                else
                {
                    //sends to SF first
                    byte[] fileByte = ConvertStreamToByteArray(fuTest.PostedFile.InputStream);

                    bool uploadToSFSuccess = ResumeUploadToSF(fileByte, fuTest.FileName);

                    if (uploadToSFSuccess)
                    {
                        mf.MemberFileTitle = fileUploadTitle.Text;
                        mf.MemberId = SessionData.Member.MemberId;
                        mf.MemberFileTypeId = MemberFileTypeID(fuTest.PostedFile.FileName);
                        mf.DocumentTypeId = 2;

                        _mfs.Insert(mf);

                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                        ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                        ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                        string extension = string.Empty;

                        extension = Path.GetExtension(fuTest.PostedFile.FileName);
                        string filepath = string.Format("{0}{1}/{2}/{3}/MemberFiles_{4}{5}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], SessionData.Member.MemberId, mf.MemberFileId, extension);
                        string errormessage = string.Empty;

                        ftpclient.UploadFileFromStream(fuTest.PostedFile.InputStream, filepath, out errormessage);

                        mf.MemberFileUrl = string.Format("MemberFiles_{0}{1}", mf.MemberFileId, extension);
                        mf.MemberFileTitle = mf.MemberFileName;
                        mf.MemberId = SessionData.Member.MemberId;
                        mf.MemberFileTypeId = MemberFileTypeID(fuTest.PostedFile.FileName);
                        mf.DocumentTypeId = 1;

                        _mfs.Update(mf);

                        List<MemberFiles> memberFiles = _mfs.GetByMemberId(SessionData.Member.MemberId).ToList();
                        rptResume.DataSource = memberFiles;
                        rptResume.DataBind();

                        if (memberFiles.Count() >= 3)
                            phFileUpload.Visible = false;

                        fileUploadTitle.Text = string.Empty;

                        plUploadFileTable.Visible = true;
                    }
                }
                _mfs = null;
            }
            else
            {
                FileUploadMessage.Text = "No file was selected";
            }
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click()})", true);
        }

        #endregion

        #region Data Commands

        protected void rptResume_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int memberFileID = int.Parse(e.CommandArgument.ToString());

                MemberFilesService _mfs = new MemberFilesService();
                MemberFiles thisFile = _mfs.GetByMemberFileId(memberFileID);

                if (thisFile.MemberId == SessionData.Member.MemberId)
                {
                    _mfs.Delete(thisFile);

                    List<MemberFiles> memberFiles = _mfs.GetByMemberId(SessionData.Member.MemberId).ToList();
                    rptResume.DataSource = memberFiles;
                    rptResume.DataBind();

                    if (memberFiles.Count() > 0)
                        plUploadFileTable.Visible = true;
                    else
                        plUploadFileTable.Visible = false;

                    phFileUpload.Visible = true;
                }

                _mfs = null;
            }
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FileUpload", "$(document).ready(function() {$('#aDesiredPosition').click()})", true);
        }


        #endregion

        #region XML Related

        private List<object> XMLMultiValueListGet(string tagname, string childNodeName)
        {
            //TODO: optimize file access
            List<object> returnModel = new List<object>();

            List<string> topValues = XMLPullValue(tagname);

            foreach (string tValue in topValues)
            {
                List<string> childValues = XMLPullMultiValue(tagname, childNodeName, tValue);
                returnModel.Add(new { Value = tValue, Childs = childValues });
            }

            return returnModel;
        }

        private List<string> XMLPullValue(string tagname)
        {
            string langCode = Enum.GetName(typeof(PortalEnums.Languages.URLLanguage), SessionData.Language.LanguageId);
            List<string> values = new List<string>();

            XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(Server.MapPath(XMLPath));

            XmlNodeList list = xmldoc.GetElementsByTagName(tagname);

            //if (tagname == "country" || tagname == "desiredcountry" || tagname == "jobcategory")
            //{
            foreach (XmlNode node in list)
            {
                string nodeValue = node.Attributes["Name"].InnerText;
                foreach (XmlNode innerNode in node.ChildNodes)
                {
                    if (innerNode.Name == "name" && innerNode.Attributes["Language"] != null && innerNode.Attributes["Language"].InnerText == langCode)
                    {
                        string nodeDisplayText = innerNode.InnerText;
                        values.Add(nodeDisplayText);
                    }
                }
            }
            //}
            //else
            //{
            //    foreach (XmlNode node in list)
            //    {
            //        if (node.Attributes["Language"] != null && node.Attributes["Language"].InnerText == langCode)
            //        {
            //            values.Add(node.InnerText);
            //        }
            //    }
            //}

            return values;
        }

        private List<string> XMLPullMultiValue(string tagname, string childTagName, string value)
        {
            string langCode = Enum.GetName(typeof(PortalEnums.Languages.URLLanguage), SessionData.Language.LanguageId);
            List<string> values = new List<string>();

            XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.Load(Server.MapPath(XMLPath));

            XmlNodeList list = xmldoc.GetElementsByTagName(tagname);

            foreach (XmlNode node in list)
            {
                if (node.Attributes["Name"].Value == value)
                {
                    foreach (XmlNode child in node[childTagName].ChildNodes)
                    {
                        foreach (XmlNode childNameNode in child.ChildNodes)
                        {
                            if (childNameNode.Name == "name" && childNameNode.Attributes["Language"] != null && childNameNode.Attributes["Language"].Value == langCode)
                            {
                                values.Add(childNameNode.InnerText);
                            }
                        }
                    }
                }
            }


            return values;
        }

        private bool XMLValidateValue(string tagname, string value)
        {
            List<string> values = XMLPullValue(tagname);

            foreach (string name in values)
            {
                if (name == value)
                {
                    return true;
                }
            }

            return false;
        }

        private bool XMLValidateValue(string tagname, string childNodeName, string value, string childvalue)
        {
            List<string> values = XMLPullMultiValue(tagname, childNodeName, value);
            foreach (string name in values)
            {
                if (name == childvalue)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Classes

        private class DropDownListModel
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        #endregion

        #region WebMethod

        [WebMethod(EnableSession = true)]
        public static object Tab1Save(string gender, string dob, string mobile, string phone, string country, string secondEmail, string address, string city, string state, string zip, string engLevel, string japLevel, string otherLanguage, string otherLevel)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            #region Fields Error Check
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(country) || country == "--None--")
            {
                errors.Add(CommonFunction.GetResourceValue("LabelCountryMandatory"));
            }

            if (!string.IsNullOrEmpty(dob))
            {
                if (!dob.IsValidContent())
                {
                    errors.Add(CommonFunction.GetResourceValue("LabelInvalidDate"));
                }
            }

            if (!string.IsNullOrEmpty(mobile))
            {
                if (!mobile.IsValidContent())
                    errors.Add("Mobile Phone cannot contain invalid content");

                if (mobile.Length > 40)
                    errors.Add("Mobile Phone cannot exceed 40 characters");
            }

            if (!string.IsNullOrEmpty(phone))
            {
                if (!phone.IsValidContent())
                    errors.Add("Home Phone cannot contain invalid content");

                if (phone.Length > 40)
                    errors.Add("Home Phone cannot exceed 40 characters");
            }

            if (!string.IsNullOrEmpty(address))
            {
                if (!address.IsValidContent())
                    errors.Add("Address cannot contain invalid content");

                if (address.Length > 255)
                    errors.Add("Address cannot exceed 255 characters");
            }

            if (!string.IsNullOrEmpty(city))
            {
                if (!city.IsValidContent())
                    errors.Add("City cannot contain invalid content");

                if (city.Length > 40)
                    errors.Add("City cannot exceed 40 characters");
            }

            if (!string.IsNullOrEmpty(zip))
            {
                if (!zip.IsValidContent())
                    errors.Add("Zip Code cannot contain invalid content");

                if (zip.Length > 20)
                    errors.Add("Zip Code cannot exceed 20 characters");
            }

            if (!string.IsNullOrEmpty(secondEmail))
            {
                string emailRegExpPat = EmailValidationRegex;
                Regex r = new Regex(emailRegExpPat, RegexOptions.IgnoreCase);
                Match m = r.Match(secondEmail);

                if (!m.Success)
                {
                    errors.Add(CommonFunction.GetResourceValue("LabelEmailInvalid"));
                    //errors.Add("Invalid Secondary Email Address format");
                }
            }

            if (!string.IsNullOrEmpty(dob))
            {
                string[] dobSplit = dob.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    DateTime dt = new DateTime(int.Parse(dobSplit[2]), int.Parse(dobSplit[1]), int.Parse(dobSplit[0]));

                    if (dt >= DateTime.Now)
                        errors.Add("Date of birth must be in the past");
                    else
                        dob = string.Format("{0}-{1}-{2}", int.Parse(dobSplit[2]), int.Parse(dobSplit[1]), int.Parse(dobSplit[0]));
                }
                catch (Exception e)
                {
                    errors.Add(CommonFunction.GetResourceValue("LabelInvalidDate"));
                }
            }

            if (errors.Count() > 0)
            {
                return new { Success = false, Message = errors };
            }

            #endregion

            if (!string.IsNullOrEmpty(sfContactID))
            {
                List<SalesforceIntegration.ErrorMessage> errorMsgs = null;
                string sfEntityID = null;

                bool postSuccess = false;

                postSuccess = FormActionPatchToSF(sfContactID, "Contact",
                    new
                    {
                        ts2__EEO_Gender__c = gender == "--None--" ? null : gender,
                        Birthdate = string.IsNullOrEmpty(dob) ? null : dob,
                        MobilePhone = mobile,
                        Phone = phone,
                        Secondary_Email__c = secondEmail,
                        MailingCountry = country == "--None--" ? null : country,
                        MailingStreet = address,
                        MailingCity = city,
                        MailingState = state == "--None--" ? null : state,
                        MailingPostalCode = zip,

                        English_Language_Level__c = engLevel == "--None--" ? null : engLevel,
                        Japanese_Language_Level__c = japLevel == "--None--" ? null : japLevel,
                        Third_Language__c = otherLanguage == "--None--" ? null : otherLanguage,
                        Third_Language_Proficiency__c = otherLevel == "--None--" ? null : otherLevel

                    }, out sfEntityID, out errorMsgs);

                if (postSuccess)
                {
                    MembersService _ms = new MembersService();
                    _ms.UpdateMemberSecondaryEmail(SessionData.Member.MemberId, SessionData.Site.MasterSiteId, secondEmail, true);

                    SalesforceIntegration.SObjRecord thisCandData = _ms.CandidateDataGet(SessionData.Member.MemberId, SessionData.Site.MasterSiteId);
                    thisCandData.ts2__EEO_Gender__c = gender == "--None--" ? null : gender;
                    thisCandData.Birthdate = string.IsNullOrEmpty(dob) ? null : dob;
                    thisCandData.MobilePhone = mobile;
                    thisCandData.Phone = phone;
                    thisCandData.Secondary_Email__c = secondEmail;
                    thisCandData.MailingCountry = country == "--None--" ? null : country;
                    thisCandData.MailingStreet = address;
                    thisCandData.MailingCity = city;
                    thisCandData.MailingState = state == "--None--" ? null : state;
                    thisCandData.MailingPostalCode = zip;
                    thisCandData.English_Language_Level__c = engLevel == "--None--" ? null : engLevel;
                    thisCandData.Japanese_Language_Level__c = japLevel == "--None--" ? null : japLevel;
                    thisCandData.Third_Language__c = otherLanguage == "--None--" ? null : otherLanguage;
                    thisCandData.Third_Language_Proficiency__c = otherLevel == "--None--" ? null : otherLevel;

                    _ms.CandidateDataUpdate(SessionData.Member.MemberId, SessionData.Site.SiteId, thisCandData);

                    _ms = null;

                    return new { Success = true };
                }
                else
                    return new { Success = false, Message = errorMsgs.First().message };
            }

            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        [WebMethod(EnableSession = true)]
        public static object Tab2Save(string company, string jobtitle, string industry, string jobcategory, List<string> jobfunctions, string employmenttype, string salaryperiod, string fixedsalary, string incentivesalary, string ddlSalaryCurrency)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            #region Fields Error Check
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(company))
                errors.Add("Company is a required field");

            if (string.IsNullOrEmpty(jobtitle))
                errors.Add("Job Title is a required field");

            if (string.IsNullOrEmpty(industry) || industry == "--None--")
                errors.Add("You must select an Industry");

            if (string.IsNullOrEmpty(jobcategory) || jobcategory == "--None--")
                errors.Add("You must select a Job Category");

            if (string.IsNullOrEmpty(employmenttype) || employmenttype == "--None--")
                errors.Add("You must select an Employment Type");

            if (!string.IsNullOrEmpty(company))
            {
                if (!company.IsValidContent())
                    errors.Add("Company cannot contain invalid content");
                if (company.Length > 255)
                    errors.Add("Company cannot exceed 255 characters");
            }

            if (!string.IsNullOrEmpty(jobtitle))
            {
                if (!jobtitle.IsValidContent())
                    errors.Add("Job Title cannot contain invalid content");
                if (jobtitle.Length > 255)
                    errors.Add("Job Title cannot exceed 255 characters");
            }

            try
            {
                if (!string.IsNullOrEmpty(fixedsalary))
                    decimal.Parse(fixedsalary);
            }
            catch (Exception e)
            {
                errors.Add("Fixed Salary must be a number");
            }

            try
            {
                if (!string.IsNullOrEmpty(incentivesalary))
                    decimal.Parse(incentivesalary);
            }
            catch (Exception e)
            {
                errors.Add("Incentive Salary must be a number");
            }

            if (errors.Count() > 0)
            {
                return new { Success = false, Message = errors };
            }

            #endregion

            if (!string.IsNullOrEmpty(sfContactID))
            {
                List<SalesforceIntegration.ErrorMessage> errorMsgs = null;
                string sfEntityID = null;

                bool postSuccess = false;

                postSuccess = FormActionPatchToSF(sfContactID, "Contact",
                    new
                    {
                        Current_Company__c = company,
                        Current_Position__c = jobtitle,
                        Industry__c = industry == "--None--" ? null : industry,
                        Job_Category__c = jobcategory == "--None--" ? null : jobcategory,
                        Job_Functions__c = jobfunctions == null ? null : String.Join(";", jobfunctions),
                        Employment_Type__c = employmenttype,
                        Salary_Period__c = salaryperiod,
                        Current_Fixed_Salary__c = fixedsalary,
                        Annual_Variable_Salary__c = incentivesalary,
                        Salary_Currency__c = ddlSalaryCurrency
                    }, out sfEntityID, out errorMsgs);

                if (postSuccess)
                {
                    MembersService _ms = new MembersService();

                    SalesforceIntegration.SObjRecord thisCandData = _ms.CandidateDataGet(SessionData.Member.MemberId, SessionData.Site.MasterSiteId);
                    thisCandData.Current_Company__c = company;
                    thisCandData.Current_Position__c = jobtitle;
                    thisCandData.Industry__c = industry == "--None--" ? null : industry;
                    thisCandData.Job_Category__c = jobcategory == "--None--" ? null : jobcategory;
                    thisCandData.Job_Functions__c = jobfunctions == null ? null : String.Join(";", jobfunctions);
                    thisCandData.Employment_Type__c = employmenttype;
                    thisCandData.Salary_Period__c = salaryperiod;
                    thisCandData.Current_Fixed_Salary__c = fixedsalary;
                    thisCandData.Annual_Variable_Salary__c = incentivesalary;
                    thisCandData.CurrencyIsoCode = ddlSalaryCurrency;

                    _ms.CandidateDataUpdate(SessionData.Member.MemberId, SessionData.Site.SiteId, thisCandData);

                    _ms = null;
                    return new { Success = true };
                }
                else
                    return new { Success = false, Message = errorMsgs.First().message };
            }

            return new { Success = false, Message = "Session expired, please reload the page." };
        }

        [WebMethod(EnableSession = true)]
        public static object Tab3Save(string dCountry, List<string> dLocation, List<string> dEmployType, string dIndustry, string dJobCate, List<string> dJobFunc, List<string> dSecondCountry)
        {
            string sfContactID = SFContactIDGetFromSessionMember();

            if (!string.IsNullOrEmpty(sfContactID))
            {
                List<SalesforceIntegration.ErrorMessage> errorMsgs = null;
                string sfEntityID = null;

                bool postSuccess = false;

                postSuccess = FormActionPatchToSF(sfContactID, "Contact",
                    new
                    {
                        Desired_Country__c = dCountry == "--None--" ? null : dCountry,
                        Desired_Locations__c = dLocation == null ? null : String.Join(";", dLocation),
                        Employment_Preference__c = dEmployType == null ? null : String.Join(";", dEmployType),
                        Desired_Industry__c = dIndustry,
                        Desired_Job_Category__c = dJobCate == "--None--" ? null : dJobCate,
                        Desired_Job_Functions__c = dJobFunc == null ? null : String.Join(";", dJobFunc),
                        Desired_Other_Countries__c = dSecondCountry == null ? null : String.Join(";", dSecondCountry)
                    }, out sfEntityID, out errorMsgs);

                if (postSuccess)
                {
                    MembersService _ms = new MembersService();

                    SalesforceIntegration.SObjRecord thisCandData = _ms.CandidateDataGet(SessionData.Member.MemberId, SessionData.Site.MasterSiteId);
                    thisCandData.Desired_Country__c = dCountry == "--None--" ? null : dCountry;
                    thisCandData.Desired_Locations__c = dLocation == null ? null : String.Join(";", dLocation);
                    thisCandData.Employment_Preference__c = dEmployType == null ? null : String.Join(";", dEmployType);
                    thisCandData.Desired_Industry__c = dIndustry;
                    thisCandData.Desired_Job_Category__c = dJobCate == "--None--" ? null : dJobCate;
                    thisCandData.Desired_Job_Functions__c = dJobFunc == null ? null : String.Join(";", dJobFunc);
                    thisCandData.Desired_Other_Countries__c = dSecondCountry == null ? null : String.Join(";", dSecondCountry);

                    _ms.CandidateDataUpdate(SessionData.Member.MemberId, SessionData.Site.SiteId, thisCandData);

                    _ms = null;

                    return new { Success = true, EntityID = sfEntityID };
                }
                else
                    return new { Success = false, Message = errorMsgs.First().message };
            }

            return new { Success = false, Message = "Session expired, please reload the page." };
        }


        #endregion

        private static bool FormActionPostToSF(string entity, object jsonObj, out string sfEntityID, out string errorMsg)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            SalesforceIntegration sfInt = new SalesforceIntegration();
            bool postSuccess = sfInt.EntityPost(entity, ser.Serialize(jsonObj), out sfEntityID, out errorMsg);

            return postSuccess;
        }

        private static bool FormActionPatchToSF(string SFID, string entity, object jsonObj, out string sfEntityID, out List<SalesforceIntegration.ErrorMessage> errorMsgs)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            SalesforceIntegration sfInt = new SalesforceIntegration();
            bool postSuccess = sfInt.EntityPatch(SFID, entity, ser.Serialize(jsonObj), out sfEntityID, out errorMsgs);

            return postSuccess;
        }



        private static bool FormActionDeleteToSF(string entity, string sfContactID, string sfID, out string errorMsg)
        {
            //TODO: Query for the reference of SFContactID with the SF object ID before executing the DELETE

            //Execute Delete
            SalesforceIntegration sfInt = new SalesforceIntegration();
            bool deleteSuccess = sfInt.EntityDelete(entity, sfID, out errorMsg);

            return deleteSuccess;
        }

        private static string SFContactIDGetFromSessionMember()
        {
            if (SessionData.Member != null)
            {
                using (Entities.Members thisMember = new MembersService().GetByMemberId(SessionData.Member.MemberId))
                {
                    return thisMember.ExternalMemberId;
                }
            }

            // If not logged in
            return string.Empty;
        }




        private bool ResumeUploadToSF(byte[] fileByte, string fileName)
        {
            bool attachmentUploaded = false;

            if (fileByte.Length > 0)
            {
                if (fileByte != null)
                {
                    String file64String = Convert.ToBase64String(fileByte);

                    //                    string jsonString = @"{ ""ContactId"" : """ + _SFContactID + @""", ""Name"" : """ + fileName + @""", ""ContentType"":""application/octet-stream"", ""Body"": """ + file64String + @""" }";
                    string jsonString = @"{ ""ContactId"" : """ + _SFContactID + @""", ""Name"" : """ + fileName + @""", ""ContentType"":""application/octet-stream"", ""Body"": """ + file64String + @""" }";
                    string entityID, error;

                    SalesforceIntegration sfInt = new SalesforceIntegration();
                    bool uploadFileSuccess = sfInt.EntityPost("ParseResume", jsonString, out entityID, out error);
                    if (uploadFileSuccess)
                    {
                        attachmentUploaded = true;
                    }
                    else
                    {
                        attachmentUploaded = false;
                    }
                }
            }
            else
            {
                //file length is 0
                attachmentUploaded = false;
            }
            return attachmentUploaded;
        }

        private int MemberFileTypeID(string filename)
        {
            int _memberFileTypeID = 0;

            MemberFileTypesService _mfts = new MemberFileTypesService();
            using (TList<Entities.MemberFileTypes> objMemberFileTypes = _mfts.GetAll())
            {

                Entities.MemberFileTypes objMemberFileType = objMemberFileTypes.Find("MemberFileExtensions", System.IO.Path.GetExtension(filename).Trim());

                if (objMemberFileType != null)
                {
                    _memberFileTypeID = objMemberFileType.MemberFileTypeId;
                }

            }
            _mfts = null;
            return _memberFileTypeID;
        }

        public byte[] ConvertStreamToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private byte[] getArray(HttpPostedFile f)
        {
            //reset the file
            f.InputStream.Seek(0, SeekOrigin.Begin);

            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }
    }
}