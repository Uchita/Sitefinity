using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.Client.Salesforce;
using System.IO;

namespace JXTPortal.Website.members
{
    public partial class register : System.Web.UI.Page
    {
        #region Properties

        private MembersService _membersService = null;
        private MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
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

        private CountriesService _countriesService;
        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null)
                    _countriesService = new CountriesService();
                return _countriesService;
            }
        }

        private JXTPortal.Entities.Members objMembers = null;

        private GlobalSettingsService _globalsettingsservice;
        public GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                {
                    _globalsettingsservice = new GlobalSettingsService();
                }
                return _globalsettingsservice;
            }
        }

        private SiteLanguagesService _sitelanguagesservice;
        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesservice == null)
                {
                    _sitelanguagesservice = new SiteLanguagesService();
                }
                return _sitelanguagesservice;
            }
        }

        #endregion

        #region Page Event Handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            // Is SSL.
            // CommonPage.IsSSL();

            CommonPage.SetBrowserPageTitle(Page, "Member Registration");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetFormValues();
                LoadSiteCountries();
                LoadSiteProfession();
                LoadSiteLangauge();

                using (TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
                {
                    phLanguage.Visible = (sitelanguages.Count > 1);
                }
            }

            if (ckAddMailingAddress.Checked)
            {
                divMailingAddress.Style["display"] = "block";
                divMailingSuburb.Style["display"] = "block";
                divMailingPostcode.Style["display"] = "block";
                divMailingState.Style["display"] = "block";
                divMailingCountry.Style["display"] = "block";
            }
        }

        #endregion

        #region Methods

        private void LoadSiteLangauge()
        {
            TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
            phLanguage.Visible = (sitelanguages.Count > 1);
            //phMultiLingual.Visible = (sitelanguages.Count > 1);
            ddlLanguage.Items.Clear();
            foreach (SiteLanguages sitelang in sitelanguages)
            {
                ddlLanguage.Items.Add(new ListItem(sitelang.SiteLanguageName, sitelang.LanguageId.ToString()));
            }

            ddlLanguage.SelectedValue = SessionData.Language.LanguageId.ToString();
        }

        public void SetFormValues()
        {

            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonRegister");
            rfvFirstname.ErrorMessage = CommonFunction.GetResourceValue("LabelFirstnameRequired");
            rfvSurname.ErrorMessage = CommonFunction.GetResourceValue("LabelSurnameRequired");
            rfvUsername.ErrorMessage = CommonFunction.GetResourceValue("LabelUsernameRequired");
            rfvPassword.ErrorMessage = CommonFunction.GetResourceValue("labellPasswordRequired");
            rfvConfirmPassword.ErrorMessage = CommonFunction.GetResourceValue("LabelPasswordNotMatch");
            comvPassword.ErrorMessage = CommonFunction.GetResourceValue("LabelPasswordNotMatch");
            rfvEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            revEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            cvEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelEmalAddressNotMatch");
            this.radlEmailFormat.Items[0].Text = CommonFunction.GetResourceValue("LabelHTML");
            this.radlEmailFormat.Items[1].Text = CommonFunction.GetResourceValue("LabelText");
            this.ddlTitle.Items[0].Text = CommonFunction.GetResourceValue("LabelMr");
            this.ddlTitle.Items[1].Text = CommonFunction.GetResourceValue("LabelMrs");
            this.ddlTitle.Items[2].Text = CommonFunction.GetResourceValue("LabelMs");
            this.ddlTitle.Items[3].Text = CommonFunction.GetResourceValue("LabelMiss");
            this.ddlTitle.Items[4].Text = CommonFunction.GetResourceValue("LabelDr");
            this.ddlTitle.Items[5].Text = CommonFunction.GetResourceValue("LabelProfessor");
            this.ddlTitle.Items[6].Text = CommonFunction.GetResourceValue("LabelOther");

            validatorPhone.ErrorMessage = CommonFunction.GetResourceValue(validatorPhone.ErrorMessage);
        }

        private void LoadSiteProfession()
        {
            ddlClassification.Items.Clear();
            SiteProfessionService _siteprofessionservice = new SiteProfessionService();
            List<Entities.SiteProfession> siteprofessions = _siteprofessionservice.GetTranslatedProfessions(SessionData.Site.UseCustomProfessionRole);

            ddlClassification.DataTextField = "SiteProfessionName";
            ddlClassification.DataValueField = "ProfessionID";
            ddlClassification.DataSource = siteprofessions;
            ddlClassification.DataBind();

            ddlClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllClassification"), "0"));

            // Default value of subclassification.
            ddlSubClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectClassificationFirst"), "0"));

        }

        private void LoadSiteCountries()
        {
            List<Countries> siteCountries = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);

            if (siteCountries != null)
            {
                siteCountries = siteCountries.Where(c => c.Sequence != -1).OrderBy(c => c.CountryName).ToList();

                ddlCountry.DataSource = siteCountries;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllCountries"), "0"));

                ddlMailingCountry.DataSource = siteCountries;
                ddlMailingCountry.DataTextField = "CountryName";
                ddlMailingCountry.DataValueField = "CountryID";
                ddlMailingCountry.DataBind();
                ddlMailingCountry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllCountries"), "0"));
            }
        }


        protected void ddlClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles();

            //AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "MultiSubClassification", "$(document).ready(function() {$('#ddlSubClassification').multiselect(); $('#ddlSubClassification').on('change', function () {$('#hfSubClassification').val($('#ddlSubClassification').val());});});", true);
        }


        private void LoadRoles()
        {
            ddlSubClassification.Items.Clear();

            if (ddlClassification.SelectedValue != null && int.Parse(ddlClassification.SelectedValue) > 0)
            {
                SiteRolesService SiteRolesService = new JXTPortal.SiteRolesService();
                ddlSubClassification.DataSource = SiteRolesService.GetTranslatedByProfessionID(int.Parse(ddlClassification.SelectedValue), SessionData.Site.UseCustomProfessionRole);
                ddlSubClassification.DataTextField = "SiteRoleName";
                ddlSubClassification.DataValueField = "RoleId";
                ddlSubClassification.DataBind();
                ddlSubClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelAllSubClassifications"), "0"));
            }
            else
            {
                ddlSubClassification.DataSource = null;
                ddlSubClassification.DataBind();

                // Please choose Classification
                ddlSubClassification.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectClassificationFirst"), "0"));
            }
        }

        private void SetFocus(string clientid)
        {
            string js = "$(document).ready(function() { var el = document.getElementById(\"" + clientid + "\"); el.scrollIntoView(false); })";

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "focusJS", js, true);
        }

        #endregion

        #region Upload resume
        protected bool uploadFile(int memberID)
        {
            bool hasUploadedFile = false;
            if (Page.IsValid)
            {
                if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                {
                    using (Entities.MemberFiles objMemberFiles = new Entities.MemberFiles())
                    {
                        int memberFileTypeID = MemberFileTypeID(docInput.PostedFile.FileName);
                        if (memberFileTypeID > 0)
                        {
                            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                            {
                                objMemberFiles.MemberFileName = System.IO.Path.GetFileName(docInput.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                            }
                            objMemberFiles.MemberFileSearchExtension = System.IO.Path.GetExtension(docInput.PostedFile.FileName).Trim();
                            
                            objMemberFiles.MemberFileTitle = objMemberFiles.MemberFileName;
                            objMemberFiles.MemberId = memberID;
                            objMemberFiles.MemberFileTypeId = memberFileTypeID;
                            objMemberFiles.DocumentTypeId = (int)PortalEnums.Members.MemberFileTypes.Resume;  // Document type is Resume 

                            MemberFilesService mfs = new MemberFilesService();
                            mfs.Insert(objMemberFiles);


                            FtpClient ftpclient = new FtpClient();
                            ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                            string extension = string.Empty;

                            extension = Path.GetExtension(docInput.PostedFile.FileName);
                            string filepath = string.Format("{0}{1}/{2}/{3}/MemberFiles_{4}{5}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberID, objMemberFiles.MemberFileId, extension);
                            string errormessage = string.Empty;

                            ftpclient.UploadFileFromStream(docInput.PostedFile.InputStream, filepath, out errormessage);
                            objMemberFiles.MemberFileUrl = string.Format("MemberFiles_{0}{1}", objMemberFiles.MemberFileId, extension);

                            mfs.Update(objMemberFiles);

                            hasUploadedFile = true;
                        }
                    }

                    //Response.Redirect("~/member/myresumecoverletter.aspx");
                }
            }
            return hasUploadedFile;
        }

        protected bool uploadCoverLetter(int memberID)
        {
            bool hasUploadedFile = false;
            if (Page.IsValid)
            {
                if ((fuCoverLetter.PostedFile != null) && fuCoverLetter.PostedFile.ContentLength > 0)
                {
                    using (Entities.MemberFiles objMemberFiles = new Entities.MemberFiles())
                    {
                        int memberFileTypeID = MemberFileTypeID(fuCoverLetter.PostedFile.FileName);
                        if (memberFileTypeID > 0)
                        {
                            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                            {
                                objMemberFiles.MemberFileName = System.IO.Path.GetFileName(fuCoverLetter.PostedFile.FileName).Trim().Replace(c.ToString(), "");
                            }
                            objMemberFiles.MemberFileSearchExtension = System.IO.Path.GetExtension(fuCoverLetter.PostedFile.FileName).Trim();
                            objMemberFiles.MemberFileTitle = objMemberFiles.MemberFileName;
                            objMemberFiles.MemberId = memberID;
                            objMemberFiles.MemberFileTypeId = memberFileTypeID;
                            objMemberFiles.DocumentTypeId = (int)PortalEnums.Members.MemberFileTypes.CoverLetter;  // Document type is Resume 

                            MemberFilesService mfs = new MemberFilesService();
                            mfs.Insert(objMemberFiles);


                            FtpClient ftpclient = new FtpClient();
                            ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                            string extension = string.Empty;

                            extension = Path.GetExtension(fuCoverLetter.PostedFile.FileName);
                            string filepath = string.Format("{0}{1}/{2}/{3}/MemberFiles_{4}{5}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberID, objMemberFiles.MemberFileId, extension);
                            string errormessage = string.Empty;

                            ftpclient.UploadFileFromStream(fuCoverLetter.PostedFile.InputStream, filepath, out errormessage);
                            objMemberFiles.MemberFileUrl = string.Format("MemberFiles_{0}{1}", objMemberFiles.MemberFileId, extension);

                            mfs.Update(objMemberFiles);

                            hasUploadedFile = true;
                        }
                    }

                    //Response.Redirect("~/member/myresumecoverletter.aspx");
                }
            }
            return hasUploadedFile;
        }

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }
        private int MemberFileTypeID(string filename)
        {
            int _memberFileTypeID = 0;

            MemberFileTypesService MemberFileTypesService = new MemberFileTypesService();
            using (TList<Entities.MemberFileTypes> objMemberFileTypes = MemberFileTypesService.GetAll())
            {

                Entities.MemberFileTypes objMemberFileType = objMemberFileTypes.Find("MemberFileExtensions", System.IO.Path.GetExtension(filename).Trim());

                if (objMemberFileType != null)
                {
                    _memberFileTypeID = objMemberFileType.MemberFileTypeId;
                }

            }
            return _memberFileTypeID;
        }
        protected void cvalDocument_ServerValidate(object source, ServerValidateEventArgs args)
        {
            /*if (docInput.PostedFile == null || docInput.PostedFile.ContentLength == 0)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("ErrorEnsureDocumentSelected");
                return;
            }
            else */
            if (docInput.PostedFile != null && !CommonFunction.CheckExtension(docInput.PostedFile.FileName))
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("ErrorFileExtension");
                return;
            }
            /*else if (CheckFileName == true)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("ErrorFileExist");
                return;
            }*/
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvalCoverLetter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (fuCoverLetter.PostedFile != null && !CommonFunction.CheckExtension(fuCoverLetter.PostedFile.FileName))
            {
                args.IsValid = false;
                this.cvalCoverLetter.ErrorMessage = CommonFunction.GetResourceValue("ErrorFileExtension");
                return;
            }
            else
            {
                args.IsValid = true;
            }
        }
        #endregion

        #region Click Event handlers

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                using (JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members())
                {
                    objMembers.SiteId = SessionData.Site.MasterSiteId;
                    objMembers.Username = CommonService.EncodeString(txtUsername.Text);
                    objMembers.Password = CommonService.EncryptMD5(txtPassword.Text);
                    objMembers.EmailAddress = CommonService.EncodeString(txtEmailAddress.Text);
                    objMembers.Title = CommonService.EncodeString(ddlTitle.SelectedValue);
                    objMembers.FirstName = CommonService.EncodeString(txtFirstName.Text);
                    objMembers.Surname = CommonService.EncodeString(txtSurname.Text);
                    objMembers.MultiLingualFirstName = CommonService.EncodeString(txtMultiLingualFirstname.Text);
                    objMembers.MultiLingualSurame = CommonService.EncodeString(txtMultiLingualSurname.Text);
                    objMembers.HomePhone = CommonService.EncodeString(txtTel.Text);
                    objMembers.Address1 = CommonService.EncodeString(txtAddress.Text);
                    objMembers.Suburb = CommonService.EncodeString(txtSuburb.Text);
                    objMembers.PostCode = CommonService.EncodeString(txtPostcode.Text);
                    objMembers.States = CommonService.EncodeString(txtState.Text);

                    objMembers.PreferredCategoryId = ddlClassification.SelectedValue;
                    objMembers.PreferredSubCategoryId = ddlSubClassification.SelectedValue;
                    objMembers.PassportNo = CommonService.EncodeString(txtPassport.Text);
                    objMembers.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
                    //Set default country to Australia if nothing is selected
                    if (Convert.ToInt32(ddlCountry.SelectedValue) > 0)
                    {
                        objMembers.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                    }
                    else
                    {
                        using (TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                        {
                            if (gslist[0].DefaultCountryId.HasValue)
                                objMembers.CountryId = gslist[0].DefaultCountryId.Value;
                        }

                    }

                    if (ckAddMailingAddress.Checked)
                    {
                        objMembers.MailingAddress1 = CommonService.EncodeString(tbMailingAddress.Text);
                        objMembers.MailingSuburb = CommonService.EncodeString(tbMailingSuburb.Text);
                        objMembers.MailingPostCode = CommonService.EncodeString(tbMailingPostcode.Text);
                        objMembers.MailingStates = CommonService.EncodeString(tbMailingState.Text);
                        objMembers.MailingCountryId = 1;
                        //Set default country to Australia if nothing is selected
                        if (Convert.ToInt32(ddlMailingCountry.SelectedValue) > 0)
                        {
                            objMembers.MailingCountryId = Convert.ToInt32(ddlMailingCountry.SelectedValue);
                        }
                        else
                        {
                            objMembers.MailingCountryId = (int?)null;
                        }
                    }


                    objMembers.EmailFormat = Convert.ToInt32(radlEmailFormat.SelectedValue);
                    objMembers.ValidateGuid = Guid.NewGuid();
                    objMembers.SearchField = String.Format("{0} {1} {2}",
                                               objMembers.FirstName,
                                               objMembers.Surname,
                                               ddlCountry.SelectedItem.Text);
                    objMembers.ReferringSiteId = SessionData.Site.SiteId;
                    //Insert into Members
                    MembersService.Insert(objMembers);

                    // If user uploaded Resume then Upload file.
                    List<HttpPostedFile> filesposted = new List<HttpPostedFile>();

                    if (docInput.HasFile)
                    {
                        if (uploadFile(objMembers.MemberId))
                        {
                            filesposted.Add(docInput.PostedFile);
                        }
                    }

                    if (fuCoverLetter.HasFile)
                    {
                        if (uploadCoverLetter(objMembers.MemberId))
                        {
                            filesposted.Add(fuCoverLetter.PostedFile);
                        }
                    }

                    if (!string.IsNullOrEmpty(SessionData.Site.MemberRegistrationNotificationEmail))
                    {
                        //Send confirmation email to new member and site's admin
                        MailService.SendMemberRegistrationToSiteAdmin(objMembers, ((ddlClassification.SelectedValue == "0") ? string.Empty : ddlClassification.SelectedItem.Text), ((ddlSubClassification.SelectedValue == "0") ? string.Empty : ddlSubClassification.SelectedItem.Text), filesposted, SessionData.Site.MemberRegistrationNotificationEmail);
                    }

                    //Send confirmation email to new member
                    MailService.SendMemberRegistration(objMembers, txtPassword.Text);

                    // SALESFORCE - Check if contact new/exists in Salesforce and insert/update in Salesforce. - Only valid users
                    // SalesforceMemberSync memberSync = new SalesforceMemberSync(objMembers);

                    Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.MEMBER_REGISTRATION_SUCCESS, "", "", ""));

                }
            }
        }

        protected void ctmUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (MembersService.GetBySiteIdUsername(SessionData.Site.MasterSiteId, txtUsername.Text) != null)
            {
                args.IsValid = false;
                ctmUsername.ErrorMessage = "- " + CommonFunction.GetResourceValue("ErrorUsernameExist") + "<br />";
                SetFocus(ctmUsername.ClientID);
            }
        }

        protected void ctmEmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Check if already exists in the platform
            if (MembersService.GetBySiteIdEmailAddress(SessionData.Site.MasterSiteId, txtEmailAddress.Text) != null)
            {
                args.IsValid = false;
                ctmEmailAddress.ErrorMessage = "- " + CommonFunction.GetResourceValue("LabelEmailAddressExist");
                SetFocus(ctmEmailAddress.ClientID);
            }
            else
            {
                // If Enworld then ignore checking Salesforce
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) && !(ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SessionData.Site.MasterSiteId + " ")))
                {

                    // Sites which has SALESFORCE enabled - If exists from Sales force then save in the platform then alert the email already exists.
                    int memberid = 0; string errormsg = string.Empty;
                    SalesforceMemberSync memberSync = new SalesforceMemberSync();
                    if (memberSync.GetContactFromSalesForceAndSave(txtEmailAddress.Text, string.Empty, SessionData.Site.MasterSiteId, ref memberid, ref errormsg))
                    {
                        args.IsValid = false;
                        ctmEmailAddress.ErrorMessage = "- " + CommonFunction.GetResourceValue("LabelEmailAddressExist");
                        SetFocus(ctmEmailAddress.ClientID);
                    }
                }
            }
        }


        #endregion

        #region SALESFORCE

        /*
        /// <summary>
        /// SALESFORCE - If Member doesn't exist in Platform check if exist in SALESFORCE and grab the details from Salesforce.
        /// </summary>
        /// <param name="strEmail"></param>
        private bool GetContactFromSalesForceAndSave(string strEmail)
        {
            if (ConfigurationManager.AppSettings["SalesForceSyncSiteIDs"] != null &&
                    ConfigurationManager.AppSettings["SalesForceSyncSiteIDs"].Contains(string.Format(" {0} ", SessionData.Site.SiteId)))
            {
                int memberid = 0; string errormsg = string.Empty;
                SalesforceMemberSync memberSync = new SalesforceMemberSync();

                // Get Candidate from Salesforce by email
                // And If candidate exists in Sales force, save in Boardy platform.
                if (memberSync.GetContactFromSalesForceAndSave(strEmail, ref memberid, ref errormsg) && memberid > 0)
                {
                    return true;
                }
            }

            return false;
        }*/


        #endregion
    }
}
