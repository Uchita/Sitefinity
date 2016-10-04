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
using JXTPortal.Web.UI;
using JXTPortal.Entities;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class ConsultantsEdit : System.Web.UI.Page
    {
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

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
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

                        if (consultant.ImageUrl != null)
                        {
                            imImage.ImageUrl = "/getfile.aspx?consultantid=" + consultant.ConsultantId.ToString();
                            imImage.Visible = true;
                            cbRemoveImage.Visible = true;
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
                                                            , tbTitle.Text
                                                            , tbName.Text
                                                            , tbLastName.Text
                                                            , tbPositionTitle.Text
                                                            , tbLocation.Text
                                                            , tbOfficeLocation.Text
                                                            , tbCategories.Text
                                                            , tbShortDescription.Text
                                                            , tbFullDescription.Text
                                                            , tbTestimonial.Text
                                                            , tbMetaTitle.Text
                                                            , tbMetaKeyword.Text
                                                            , tbMetaDescription.Text);


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
                            txtMultiTitle.Text = langnode["Title"].InnerXml;
                            txtMultiFirstName.Text = langnode["FirstName"].InnerXml;
                            txtMultiLastName.Text = langnode["LastName"].InnerXml;
                            txtMultiPositionTitle.Text = langnode["PositionTitle"].InnerXml;
                            txtMultiLocation.Text = langnode["Location"].InnerXml;
                            txtMultiOfficeLocation.Text = langnode["OfficeLocation"].InnerXml;
                            txtMultiCategories.Text = langnode["Categories"].InnerXml;
                            txtMultiShortDescription.Text = langnode["ShortDescription"].InnerXml;
                            txtMultiFullDescription.Text = langnode["FullDescription"].InnerXml;
                            txtMultiTestimonial.Text = langnode["Testimonial"].InnerXml;
                            txtMultiMetaTitle.Text = langnode["MetaTitle"].InnerXml;
                            txtMultiMetaKeyword.Text = langnode["MetaKeyword"].InnerXml;
                            txtMultiMetaDescription.Text = langnode["MetaDescription"].InnerXml;

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

                    using (TList<SiteLanguages> SiteLanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (SiteLanguages.Count > 1)
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
                                                                , txtMultiTitle.Text
                                                                ,txtMultiFirstName.Text
                                                                ,txtMultiLastName.Text
                                                                ,txtMultiPositionTitle.Text
                                                                ,txtMultiLocation.Text
                                                                ,txtMultiOfficeLocation.Text
                                                                ,txtMultiCategories.Text
                                                                ,txtMultiShortDescription.Text
                                                                ,txtMultiFullDescription.Text
                                                                ,txtMultiTestimonial.Text
                                                                ,txtMultiMetaTitle.Text
                                                                ,txtMultiMetaKeyword.Text
                                                                ,txtMultiMetaDescription.Text);
                            }

                            consultantxml += "</Languages>";
                        }
                    }

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
                    }

                    if (fuImage.HasFile)
                    {
                        System.IO.BinaryReader b = new System.IO.BinaryReader(fuImage.FileContent);
                        fuImage.FileContent.Position = 0;
                        consultant.ImageUrl = b.ReadBytes((int)fuImage.FileContent.Length);
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
                    consultant.ConsultantsXml = consultantxml;

                    if (ConsultantId > 0)
                    {
                        ConsultantsService.Update(consultant);
                    }
                    else
                    {
                        ConsultantsService.Insert(consultant);
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
                                    txtMultiTitle.Text = langnode["Title"].InnerXml;
                                    txtMultiFirstName.Text = langnode["FirstName"].InnerXml;
                                    txtMultiLastName.Text = langnode["LastName"].InnerXml;
                                    txtMultiPositionTitle.Text = langnode["PositionTitle"].InnerXml;
                                    txtMultiLocation.Text = langnode["Location"].InnerXml;
                                    txtMultiOfficeLocation.Text = langnode["OfficeLocation"].InnerXml;
                                    txtMultiCategories.Text = langnode["Categories"].InnerXml;
                                    txtMultiShortDescription.Text = langnode["ShortDescription"].InnerXml;
                                    txtMultiFullDescription.Text = langnode["FullDescription"].InnerXml;
                                    txtMultiTestimonial.Text = langnode["Testimonial"].InnerXml;
                                    txtMultiMetaTitle.Text = langnode["MetaTitle"].InnerXml;
                                    txtMultiMetaKeyword.Text = langnode["MetaKeyword"].InnerXml;
                                    txtMultiMetaDescription.Text = langnode["MetaDescription"].InnerXml;
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
                            langnode["Title"].InnerXml = txtMultiTitle.Text;
                            langnode["FirstName"].InnerXml = txtMultiFirstName.Text;
                            langnode["LastName"].InnerXml = txtMultiLastName.Text;
                            langnode["PositionTitle"].InnerXml = txtMultiPositionTitle.Text;
                            langnode["Location"].InnerXml = txtMultiLocation.Text;
                            langnode["OfficeLocation"].InnerXml = txtMultiOfficeLocation.Text;
                            langnode["Categories"].InnerXml = txtMultiCategories.Text;
                            langnode["ShortDescription"].InnerXml = txtMultiShortDescription.Text;
                            langnode["FullDescription"].InnerXml = txtMultiFullDescription.Text;
                            langnode["Testimonial"].InnerXml = txtMultiTestimonial.Text;
                            langnode["MetaTitle"].InnerXml = txtMultiMetaTitle.Text;
                            langnode["MetaKeyword"].InnerXml = txtMultiMetaKeyword.Text;
                            langnode["MetaDescription"].InnerXml = txtMultiMetaDescription.Text;

                            consultant.ConsultantsXml = langxml.InnerXml.Replace("&rsquo;", "'");

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