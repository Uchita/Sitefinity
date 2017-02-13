#region Imports
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using JXTPortal.Common;
using JXTPortal.Common.Extensions;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using SectionIO;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class ConsultantsEdit : System.Web.UI.Page
    {
        public ICacheFlusher CacheFlusher { get; set; }

        #region Declare Variables

        private int consultantId = 0;

        #endregion

        #region Properties

        JXTPortal.ConsultantsService _consultantsService;
        JXTPortal.ConsultantsService ConsultantsService
        {
            get
            {
                if (_consultantsService == null)
                {
                    _consultantsService = new JXTPortal.ConsultantsService();
                }
                return _consultantsService;
            }
        }

        JXTPortal.SiteLanguagesService _sitelanguagesService;
        JXTPortal.SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesService == null)
                {
                    _sitelanguagesService = new JXTPortal.SiteLanguagesService();
                }
                return _sitelanguagesService;
            }
        }

        private int ConsultantId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(hfConsultantId.Value))
                {
                    consultantId = Convert.ToInt32(hfConsultantId.Value);
                }

                if ((Request.QueryString["ConsultantId"] != null))
                {
                    if (int.TryParse((Request.QueryString["ConsultantId"].Trim()), out consultantId))
                    {
                        consultantId = Convert.ToInt32(Request.QueryString["ConsultantId"]);
                    }
                    return consultantId;
                }
                return consultantId;
            }
        }

        private GlobalSettingsService _globalsettingsservice;
        private GlobalSettingsService GlobalSettingsService
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

        private string FTPFolderLocation
        {
            get { return GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation; }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (FTPFolderLocation.StartsWith("s3://"))
            {
                tbShortDescription.CustomConfig = "s3custom_config.js";
                tbFullDescription.CustomConfig = "s3custom_config.js";
                tbTestimonial.CustomConfig = "s3custom_config.js";
                txtMultiShortDescription.CustomConfig = "s3custom_config.js";
                txtMultiFullDescription.CustomConfig = "s3custom_config.js";
                txtMultiTestimonial.CustomConfig = "s3custom_config.js";
            }

            if (!IsPostBack)
            {
                loadForm();
            }
        }

        #endregion

        #region Methods

        protected void loadForm()
        {
            if (ConsultantId > 0)
            {
                using (JXTPortal.Entities.Consultants consultant = ConsultantsService.GetByConsultantId(consultantId))
                {
                    if (consultant != null && consultant.SiteId == SessionData.Site.SiteId)
                    {
                        hfConsultantId.Value = ConsultantId.ToString();

                        tbTitle.Text = consultant.Title;
                        tbName.Text = consultant.FirstName;
                        tbLastName.Text = consultant.LastName;
                        tbEmail.Text = consultant.Email;
                        tbPhone.Text = consultant.Phone;
                        tbMobile.Text = consultant.Mobile;
                        tbPositionTitle.Text = consultant.PositionTitle;
                        tbOfficeLocation.Text = consultant.OfficeLocation;
                        tbCategories.Text = consultant.Categories;
                        tbLocation.Text = consultant.Location;
                        tbFriendlyURL.Text = consultant.FriendlyUrl;
                        tbShortDescription.Text = consultant.ShortDescription;
                        tbTestimonial.Text = consultant.Testimonial;
                        tbFullDescription.Text = consultant.FullDescription;
                        tbLinkedIn.Text = consultant.LinkedInUrl;
                        tbTwitter.Text = consultant.TwitterUrl;
                        tbFacebook.Text = consultant.FacebookUrl;
                        tbGoogle.Text = consultant.GoogleUrl;
                        tbLink.Text = consultant.Link;
                        tbWeChat.Text = consultant.WechatUrl;
                        tbFeaturedTeamMember.Checked = (consultant.FeaturedTeamMember > 0);

                        if (!string.IsNullOrWhiteSpace(consultant.ConsultantImageUrl))
                        {
                            imImage.ImageUrl = string.Format("/media/{0}/{1}?ver={2}", ConfigurationManager.AppSettings["ConsultantsFolder"], consultant.ConsultantImageUrl, consultant.LastModified.ToEpocTimestamp());
                            imImage.Visible = true;
                            cbRemoveImage.Visible = true;
                        }
                        else
                        {
                            if (consultant.ImageUrl != null)
                            {
                                imImage.ImageUrl = string.Format("/getfile.aspx?consultantid={0}&ver={1}",consultant.ConsultantId,consultant.LastModified.ToEpocTimestamp());
                                imImage.Visible = true;
                                cbRemoveImage.Visible = true;
                            }
                        }

                        //tbImageURL.Text = consultant.ImageUrl;
                        tbVideoURL.Text = consultant.VideoUrl;
                        tbBlogRSS.Text = consultant.BlogRss;
                        tbNewsRSS.Text = consultant.NewsRss;
                        tbJobRSS.Text = consultant.JobRss;
                        tbTestimonialsRSS.Text = consultant.TestimonialsRss;
                        ddlStatus.SelectedValue = consultant.Valid.ToString();
                        tbMetaTitle.Text = consultant.MetaTitle;
                        tbMetaDescription.Text = consultant.MetaDescription;
                        tbMetaKeyword.Text = consultant.MetaKeywords;
                        if (consultant.LastModifiedBy.HasValue)
                        {
                            AdminUsersService aus = new AdminUsersService();
                            using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(consultant.LastModifiedBy.Value))
                            {
                                ltLastModifiedBy.Text = adminuser.UserName;
                            }
                        }

                        ltLastModified.Text = (consultant.LastModified.HasValue) ? consultant.LastModified.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt") : string.Empty;  
                        tbSequence.Text = consultant.Sequence.ToString();

                        LoadLanguages(consultant);
                    }
                    else
                    {
                        Response.Redirect("/admin/consultants.aspx");
                    }
                }
            }
        }

        private int LoadLanguages(Entities.Consultants consultant)
        {
            int langid = 0;
            if (consultant.ConsultantId > 0)
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

                    langid = Convert.ToInt32(lbLanguage.CommandArgument);

                    if (string.IsNullOrWhiteSpace(consultant.ConsultantsXml))
                    {
                        // Construct & Update the XML
                        string consultantxml = string.Empty;

                        consultantxml = "<Languages>";

                        foreach (SiteLanguages lang in langs)
                        {
                            consultantxml += string.Format(@"<Language>
                                                                    <id>{0}</id>
                                                                    <Title>{1}</Title>
                                                                    <FirstName>{2}</FirstName>
                                                                    <LastName>{3}</LastName>
                                                                    <PositionTitle>{4}</PositionTitle>
                                                                    <Location>{5}</Location>
                                                                    <OfficeLocation>{6}</OfficeLocation>
                                                                    <Categories>{7}</Categories>
                                                                    <ShortDescription>{8}</ShortDescription>
                                                                    <FullDescription>{9}</FullDescription>
                                                                    <Testimonial>{10}</Testimonial>
                                                                    <MetaTitle>{11}</MetaTitle>
                                                                    <MetaKeyword>{12}</MetaKeyword>
                                                                    <MetaDescription>{13}</MetaDescription>
                                                                </Language>"
                                                            , lang.LanguageId
                                                            , Utils.XmlEncode(tbTitle.Text)
                                                            , Utils.XmlEncode(tbName.Text)
                                                            , Utils.XmlEncode(tbLastName.Text)
                                                            , Utils.XmlEncode(tbPositionTitle.Text)
                                                            , Utils.XmlEncode(tbLocation.Text)
                                                            , Utils.XmlEncode(tbOfficeLocation.Text)
                                                            , Utils.XmlEncode(tbCategories.Text)
                                                            , Utils.XmlEncode(tbShortDescription.Text)
                                                            , Utils.XmlEncode(tbFullDescription.Text)
                                                            , Utils.XmlEncode(tbTestimonial.Text)
                                                            , Utils.XmlEncode(tbMetaTitle.Text)
                                                            , Utils.XmlEncode(tbMetaKeyword.Text)
                                                            , Utils.XmlEncode(tbMetaDescription.Text));


                        }

                        consultantxml += "</Languages>";
                        consultant.ConsultantsXml = consultantxml;

                        ConsultantsService.Update(consultant);
                    }

                    XmlDocument langxml = new XmlDocument();
                    langxml.LoadXml(consultant.ConsultantsXml);

                    XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                    foreach (XmlNode langnode in langlist)
                    {
                        if (langnode.ChildNodes[0].InnerXml == langid.ToString())
                        {
                            txtMultiTitle.Text =  Server.HtmlDecode(langnode["Title"].InnerXml);
                            txtMultiFirstName.Text = HttpUtility.HtmlDecode(langnode["FirstName"].InnerXml);
                            txtMultiLastName.Text = HttpUtility.HtmlDecode(langnode["LastName"].InnerXml);
                            txtMultiPositionTitle.Text = HttpUtility.HtmlDecode(langnode["PositionTitle"].InnerXml);
                            txtMultiLocation.Text = HttpUtility.HtmlDecode(langnode["Location"].InnerXml);
                            txtMultiOfficeLocation.Text = HttpUtility.HtmlDecode(langnode["OfficeLocation"].InnerXml);
                            txtMultiCategories.Text = HttpUtility.HtmlDecode(langnode["Categories"].InnerXml);
                            txtMultiShortDescription.Text = HttpUtility.HtmlDecode(langnode["ShortDescription"].InnerXml);
                            txtMultiFullDescription.Text = HttpUtility.HtmlDecode(langnode["FullDescription"].InnerXml);
                            txtMultiTestimonial.Text = HttpUtility.HtmlDecode(langnode["Testimonial"].InnerXml);
                            txtMultiMetaTitle.Text = HttpUtility.HtmlDecode(langnode["MetaTitle"].InnerXml);
                            txtMultiMetaKeyword.Text = HttpUtility.HtmlDecode(langnode["MetaKeyword"].InnerXml);
                            txtMultiMetaDescription.Text = HttpUtility.HtmlDecode(langnode["MetaDescription"].InnerXml);

                        }
                    }

                }
            }

            return langid;
        }

        #endregion

        #region Click Event handlers

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                JXTPortal.Entities.Consultants consultant = null;

                try
                {
                    string consultantxml = string.Empty;

                    if (ConsultantId > 0)
                    {
                        consultant = ConsultantsService.GetByConsultantId(consultantId);

                        if (consultant == null || consultant.SiteId != SessionData.Site.SiteId)
                        {
                            Response.Redirect("/admin/consultants.aspx");
                        }
                    }

                    if (consultant == null)
                        consultant = new Entities.Consultants();

                    consultant.SiteId = SessionData.Site.SiteId;
                    consultant.Title = tbTitle.Text;
                    consultant.FirstName = tbName.Text;
                    consultant.LastName = tbLastName.Text;
                    consultant.Email = tbEmail.Text;
                    consultant.Phone = tbPhone.Text;
                    consultant.Mobile = tbMobile.Text;
                    consultant.PositionTitle = tbPositionTitle.Text;
                    consultant.OfficeLocation = tbOfficeLocation.Text;
                    consultant.Categories = tbCategories.Text;
                    consultant.Location = tbLocation.Text;
                    consultant.FriendlyUrl = JXTPortal.Common.Utils.UrlFriendlyName(tbFriendlyURL.Text);
                    consultant.ShortDescription = tbShortDescription.Text;
                    consultant.Testimonial = tbTestimonial.Text;
                    consultant.FullDescription = tbFullDescription.Text;
                    consultant.LinkedInUrl = tbLinkedIn.Text;
                    consultant.TwitterUrl = tbTwitter.Text;
                    consultant.FacebookUrl = tbFacebook.Text;
                    consultant.GoogleUrl = tbGoogle.Text;
                    consultant.Link = tbLink.Text;
                    consultant.WechatUrl = tbWeChat.Text;
                    consultant.FeaturedTeamMember = (tbFeaturedTeamMember.Checked) ? 1 : 0;

                    if (cbRemoveImage.Checked)
                    {
                        consultant.ImageUrl = null;
                        consultant.ConsultantImageUrl = string.Empty;
                    }
                    consultant.VideoUrl = tbVideoURL.Text;
                    consultant.BlogRss = tbBlogRSS.Text;
                    consultant.NewsRss = tbNewsRSS.Text;
                    consultant.JobRss = tbJobRSS.Text;
                    consultant.TestimonialsRss = tbTestimonialsRSS.Text;
                    consultant.Valid = Convert.ToInt32(ddlStatus.SelectedValue);
                    consultant.MetaTitle = tbMetaTitle.Text;
                    consultant.MetaDescription = tbMetaDescription.Text;
                    consultant.MetaKeywords = tbMetaKeyword.Text;
                    consultant.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                    consultant.LastModified = DateTime.Now;
                    consultant.Sequence = (string.IsNullOrWhiteSpace(tbSequence.Text)) ? 0 : Convert.ToInt32(tbSequence.Text);

                    using (TList<SiteLanguages> SiteLanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (SiteLanguages.Count > 1)
                        {
                            if (string.IsNullOrEmpty(consultant.ConsultantsXml))
                            {
                                consultantxml = "<Languages>";

                                foreach (SiteLanguages lang in SiteLanguages)
                                {
                                    consultantxml += string.Format(@"<Language>
                                                                    <id>{0}</id>
                                                                    <Title>{1}</Title>
                                                                    <FirstName>{2}</FirstName>
                                                                    <LastName>{3}</LastName>
                                                                    <PositionTitle>{4}</PositionTitle>
                                                                    <Location>{5}</Location>
                                                                    <OfficeLocation>{6}</OfficeLocation>
                                                                    <Categories>{7}</Categories>
                                                                    <ShortDescription>{8}</ShortDescription>
                                                                    <FullDescription>{9}</FullDescription>
                                                                    <Testimonial>{10}</Testimonial>
                                                                    <MetaTitle>{11}</MetaTitle>
                                                                    <MetaKeyword>{12}</MetaKeyword>
                                                                    <MetaDescription>{13}</MetaDescription>
                                                                </Language>"
                                                                    , lang.LanguageId
                                                                    , Utils.HtmlEncode(tbTitle.Text)
                                                                    , Utils.HtmlEncode(tbName.Text)
                                                                    , Utils.HtmlEncode(tbLastName.Text)
                                                                    , Utils.HtmlEncode(tbPositionTitle.Text)
                                                                    , Utils.HtmlEncode(tbLocation.Text)
                                                                    , Utils.HtmlEncode(tbOfficeLocation.Text)
                                                                    , Utils.HtmlEncode(tbCategories.Text)
                                                                    , Utils.HtmlEncode(tbShortDescription.Text)
                                                                    , Utils.HtmlEncode(tbFullDescription.Text)
                                                                    , Utils.HtmlEncode(tbTestimonial.Text)
                                                                    , Utils.HtmlEncode(tbMetaTitle.Text)
                                                                    , Utils.HtmlEncode(tbMetaKeyword.Text)
                                                                    , Utils.HtmlEncode(tbMetaDescription.Text));
                                }

                                consultantxml += "</Languages>";


                                consultant.ConsultantsXml = consultantxml;
                            }
                            else
                            {
                                XmlDocument langxml = new XmlDocument();
                                langxml.LoadXml(consultant.ConsultantsXml);

                                XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                                foreach (XmlNode langnode in langlist)
                                {
                                    if (langnode.ChildNodes[0].InnerXml == SessionData.Site.DefaultLanguageId.ToString())
                                    {
                                        langnode["Title"].InnerText = tbTitle.Text;
                                        langnode["FirstName"].InnerText = tbName.Text;
                                        langnode["LastName"].InnerText = tbLastName.Text;
                                        langnode["PositionTitle"].InnerText = tbPositionTitle.Text;
                                        langnode["Location"].InnerText = tbLocation.Text;
                                        langnode["OfficeLocation"].InnerText = tbOfficeLocation.Text;
                                        langnode["Categories"].InnerText = tbCategories.Text;
                                        langnode["ShortDescription"].InnerText = tbShortDescription.Text;
                                        langnode["FullDescription"].InnerText = tbFullDescription.Text;
                                        langnode["Testimonial"].InnerText = tbTestimonial.Text;
                                        langnode["MetaTitle"].InnerText = tbMetaTitle.Text;
                                        langnode["MetaKeyword"].InnerText = tbMetaKeyword.Text;
                                        langnode["MetaDescription"].InnerText = tbMetaDescription.Text;

                                        consultant.ConsultantsXml = langxml.InnerXml;
                                    }
                                }
                            }

                        }
                    }

                    if (ConsultantId > 0)
                    {
                        ConsultantsService.Update(consultant);
                    }
                    else
                    {
                        ConsultantsService.Insert(consultant);
                    }

                    if (fuImage.HasFile)
                    {
                        System.Drawing.Image objOriginalImage = System.Drawing.Image.FromStream(fuImage.FileContent);

                        FtpClient ftpclient = new FtpClient();
                        string errormessage = string.Empty;
                        string extension = Utils.GetImageExtension(objOriginalImage);
                        ftpclient.Host = ConfigurationManager.AppSettings["FTPFileManager"];
                        ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                        ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                        ftpclient.UploadFileFromStream(fuImage.FileContent, string.Format("{0}/{1}/Consultants_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["ConsultantsFolder"], consultant.ConsultantId, extension), out errormessage);

                        if (string.IsNullOrWhiteSpace(errormessage))
                        {
                            consultant.ConsultantImageUrl = string.Format("Consultants_{0}.{1}", consultant.ConsultantId, extension);
                            ConsultantsService.Update(consultant);
                        }
                    }

                    hfConsultantId.Value = consultant.ConsultantId.ToString();

                    LoadLanguages(consultant);

                    ltlMessage.Text = "Consultant has been updated successfully.";

                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
                finally
                {
                    consultant.Dispose();
                }

                String siteUrl = string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Host);
                String path = "consultants";
                String consultantImage = string.Format("Consultant_{0}.jpg", ConsultantId);

                CacheFlusher.FlushImage(siteUrl,path,consultantImage);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("consultants.aspx");
        }

        protected void cvalFileName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if ((this.fuImage.PostedFile != null) && !string.IsNullOrEmpty(this.fuImage.PostedFile.FileName))
            {
                System.Drawing.Image img = null;
                string contenttype = string.Empty;
                args.IsValid = JXTPortal.Common.Utils.IsValidUploadImage(fuImage.PostedFile.FileName, fuImage.PostedFile.InputStream, out img, out contenttype);
                if (!args.IsValid)
                {
                    cvalFileName.ErrorMessage = "Failed to validate file";
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvalFile_ServerValidate(System.Object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if ((this.fuImage.PostedFile != null) && !string.IsNullOrEmpty(this.fuImage.PostedFile.FileName))
            {
                if (fuImage.PostedFile.ContentLength == 0)
                {
                    this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageInvalidSize");
                    args.IsValid = false;

                }
                else if ((fuImage.PostedFile.ContentLength / (Math.Pow(1024, 2))) > 1)
                {
                    this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageExceed");
                    args.IsValid = false;

                }
                else
                {
                    args.IsValid = true;
                }
            }
        }

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }

        #endregion

        protected void cvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int totalCount = 0;
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");
            string friendlyurl = JXTPortal.Common.Utils.UrlFriendlyName(tbFriendlyURL.Text);
            TList<JXTPortal.Entities.Consultants> consultants = ConsultantsService.GetPaged("SiteId = " + SessionData.Site.SiteId.ToString() + " AND FriendlyURL = '" + friendlyurl.Replace("'", "''") + "'", "ConsultantID", 0, sitePageCount, out totalCount);

            if (ConsultantId > 0)
            {
                foreach (JXTPortal.Entities.Consultants consultant in consultants)
                {
                    if (consultant.ConsultantId != ConsultantId)
                    {
                        args.IsValid = false;
                    }
                }
            }
            else
            {
                if (consultants.Count > 0)
                {
                    args.IsValid = false;
                }
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

                    if (e.CommandArgument.ToString() == lbLanguage.CommandArgument.ToString())
                    {
                        lbLanguage.Enabled = false;

                        Entities.Consultants consultant = ConsultantsService.GetByConsultantId((ConsultantId == 0) ? Convert.ToInt32(hfConsultantId.Value) : ConsultantId);

                        if (!string.IsNullOrWhiteSpace(consultant.ConsultantsXml))
                        {
                            XmlDocument langxml = new XmlDocument();

                            langxml.LoadXml(consultant.ConsultantsXml);

                            XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                            foreach (XmlNode langnode in langlist)
                            {
                                if (langnode.ChildNodes[0].InnerXml == e.CommandArgument.ToString())
                                {
                                    txtMultiTitle.Text = Server.HtmlDecode(langnode["Title"].InnerXml);
                                    txtMultiFirstName.Text = HttpUtility.HtmlDecode(langnode["FirstName"].InnerXml);
                                    txtMultiLastName.Text = HttpUtility.HtmlDecode(langnode["LastName"].InnerXml);
                                    txtMultiPositionTitle.Text = HttpUtility.HtmlDecode(langnode["PositionTitle"].InnerXml);
                                    txtMultiLocation.Text = HttpUtility.HtmlDecode(langnode["Location"].InnerXml);
                                    txtMultiOfficeLocation.Text = HttpUtility.HtmlDecode(langnode["OfficeLocation"].InnerXml);
                                    txtMultiCategories.Text = HttpUtility.HtmlDecode(langnode["Categories"].InnerXml);
                                    txtMultiShortDescription.Text = HttpUtility.HtmlDecode(langnode["ShortDescription"].InnerXml);
                                    txtMultiFullDescription.Text = HttpUtility.HtmlDecode(langnode["FullDescription"].InnerXml);
                                    txtMultiTestimonial.Text = HttpUtility.HtmlDecode(langnode["Testimonial"].InnerXml);
                                    txtMultiMetaTitle.Text = HttpUtility.HtmlDecode(langnode["MetaTitle"].InnerXml);
                                    txtMultiMetaKeyword.Text = HttpUtility.HtmlDecode(langnode["MetaKeyword"].InnerXml);
                                    txtMultiMetaDescription.Text = HttpUtility.HtmlDecode(langnode["MetaDescription"].InnerXml);
                                }
                            }
                        }
                    }
                    else
                    {
                        lbLanguage.Enabled = true;
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

        protected void btnMultilingualSave_Click(object sender, EventArgs e)
        {
            Entities.Consultants consultant = ConsultantsService.GetByConsultantId((ConsultantId == 0) ? Convert.ToInt32(hfConsultantId.Value) : ConsultantId);
            if (consultant != null)
            {
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

                if (langid > 0)
                {
                    XmlDocument langxml = new XmlDocument();
                    langxml.LoadXml(consultant.ConsultantsXml);

                    XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                    foreach (XmlNode langnode in langlist)
                    {
                        if (langnode.ChildNodes[0].InnerXml == langid.ToString())
                        {
                            langnode["Title"].InnerText =  txtMultiTitle.Text;
                            langnode["FirstName"].InnerText = txtMultiFirstName.Text;
                            langnode["LastName"].InnerText = txtMultiLastName.Text;
                            langnode["PositionTitle"].InnerText = txtMultiPositionTitle.Text;
                            langnode["Location"].InnerText = txtMultiLocation.Text;
                            langnode["OfficeLocation"].InnerText = txtMultiOfficeLocation.Text;
                            langnode["Categories"].InnerText = txtMultiCategories.Text;
                            langnode["ShortDescription"].InnerText = txtMultiShortDescription.Text;
                            langnode["FullDescription"].InnerText = txtMultiFullDescription.Text;
                            langnode["Testimonial"].InnerText = txtMultiTestimonial.Text;
                            langnode["MetaTitle"].InnerText = txtMultiMetaTitle.Text;
                            langnode["MetaKeyword"].InnerText = txtMultiMetaKeyword.Text;
                            langnode["MetaDescription"].InnerText = txtMultiMetaDescription.Text;

                            consultant.ConsultantsXml = langxml.InnerXml;

                            ConsultantsService.Update(consultant);

                            ltMultilingualMessage.Text = "Consultant " + HttpUtility.HtmlEncode(langname) + " has been updated.";
                            return;
                        }
                    }
                }
            }
        }
    }
}