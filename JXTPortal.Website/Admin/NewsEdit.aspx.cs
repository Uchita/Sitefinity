
#region Imports...
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
using JXTPortal.Web.UI;
using System.Data.SqlTypes;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;
#endregion

public partial class NewsEdit : System.Web.UI.Page
{
    #region Declarations

    private NewsCategoriesService _newsCategoriesService;
    private NewsService _newsService;
    private int _newsid = 0;

    #endregion

    #region Properties

    private NewsCategoriesService NewsCategoriesService
    {
        get
        {
            if (_newsCategoriesService == null) _newsCategoriesService = new NewsCategoriesService();
            return _newsCategoriesService;
        }
    }

    private NewsService NewsService
    {
        get
        {
            if (_newsService == null) _newsService = new NewsService();
            return _newsService;
        }
    }

    private int NewsId
    {
        get
        {
            if ((Request.QueryString["NewsId"] != null))
            {
                if (int.TryParse((Request.QueryString["NewsId"].Trim()), out _newsid))
                {
                    _newsid = Convert.ToInt32(Request.QueryString["NewsId"]);
                }
                return _newsid;
            }

            return _newsid;
        }
    }

    #endregion

    #region Page Method

    protected void Page_Load(object sender, EventArgs e)
    {
        // To Enable CkFinder
        //txtPageContent.FileBrowserImageBrowseUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images"; //&currentFolder=/files/images/
        //txtPageContent.FileBrowserImageBrowseUrl = "/ckfinder/ckfinder.html?Type=Images&CKEditor=editor1&CKEditorFuncNum=4&langCode=en"; //&currentFolder=/files/images/
        cal_dataPostDate.Format = SessionData.Site.DateFormat;

        if (!Page.IsPostBack)
        {
            LoadNewsCategory();

            LoadOthers();

            InsertButton.Visible = (NewsId == 0);
            UpdateButton.Visible = (NewsId > 0);
            LoadNews();

            txtMetaKeywords.Attributes["onkeyup"] = "CharaterCount('" + txtMetaKeywords.ClientID + "', 'spKeywordsCount', 256);";
            txtMetaKeywords.Attributes["onmouseup"] = "CharaterCount('" + txtMetaKeywords.ClientID + "', 'spKeywordsCount', 256);";

            txtMetaDescription.Attributes["onkeyup"] = "CharaterCount('" + txtMetaDescription.ClientID + "', 'spDescriptionCount', 160);";
            txtMetaDescription.Attributes["onmouseup"] = "CharaterCount('" + txtMetaDescription.ClientID + "', 'spDescriptionCount', 160);";

            txtMetaTitle.Attributes["onkeyup"] = "CharaterCount('" + txtMetaTitle.ClientID + "', 'spTitleCount', 69);";
            txtMetaTitle.Attributes["onmouseup"] = "CharaterCount('" + txtMetaTitle.ClientID + "', 'spTitleCount', 69);";

            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CharaterCount", "$( document ).ready(function() { CharaterCount(\"" + txtMetaKeywords.ClientID + "\", \"spKeywordsCount\", 256); CharaterCount(\"" + txtMetaDescription.ClientID + "\", \"spDescriptionCount\", 160); CharaterCount(\"" + txtMetaTitle.ClientID + "\", \"spTitleCount\", 69); });", true);
        }
    }

    #endregion

    #region Methods

    private void LoadOthers()
    {
        // Load industries
        NewsIndustryService NewsIndustryService = new JXTPortal.NewsIndustryService();
        ddlIndustries.DataSource = NewsIndustryService.GetAll().FindAll(s => s.SiteId == SessionData.Site.SiteId);
        ddlIndustries.DataValueField = "NewsIndustryID";
        ddlIndustries.DataTextField = "NewsIndustryName";
        ddlIndustries.DataBind();

        if (ddlIndustries != null && ddlIndustries.Items.Count > 0)
            pnlIndustries.Visible = true;

        ddlIndustries.Items.Insert(0, new ListItem("-Select-", "0"));

        // Load types
        NewsTypeService NewsTypeService = new JXTPortal.NewsTypeService();
        lstNewsType.DataSource = NewsTypeService.GetAll().FindAll(s => s.SiteId == SessionData.Site.SiteId);
        lstNewsType.DataValueField = "NewsTypeID";
        lstNewsType.DataTextField = "NewsTypeName";
        lstNewsType.DataBind();


        if (lstNewsType != null && lstNewsType.Items.Count > 0)
            pnlNewsType.Visible = true;
    }

    private void LoadNewsCategory()
    {
        dataNewsCategoryId.DataSource = NewsCategoriesService.GetBySiteId(SessionData.Site.SiteId);
        dataNewsCategoryId.DataBind();
    }

    private void LoadNews()
    {
        if (NewsId > 0)
        {
            using (JXTPortal.Entities.News news = NewsService.GetByNewsId(NewsId))
            {
                if (news.SiteId != SessionData.Site.SiteId)
                    Response.Redirect("/admin/news.aspx");
                else
                {
                    dataNewsCategoryId.SelectedValue = news.NewsCategoryId.ToString();
                    dataSubject.Text = HttpUtility.HtmlDecode(news.Subject);
                    txtPageContent.Text = news.Content;
                    dataPostDate.Text = news.PostDate.ToString(SessionData.Site.DateFormat);
                    if (news.Valid.HasValue && news.Valid.Value)
                        chkValid.Checked = news.Valid.Value;
                    dataSequence.Text = news.Sequence.ToString();
                    dataTags.Text = news.Tags.ToString();

                    
                    txtPageFriendlyName.Text = news.PageFriendlyName;

                    txtMetaTitle.Text = HttpUtility.HtmlDecode(news.MetaTitle);
                    txtMetaKeywords.Text = HttpUtility.HtmlDecode(news.MetaKeywords);
                    txtMetaDescription.Text = HttpUtility.HtmlDecode(news.MetaDescription);

                    if (news.LastModified != null)
                        dataLastModified.Text = ((DateTime)news.LastModified).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");


                    if (news.NewsIndustryId.HasValue)
                        ddlIndustries.SelectedValue = news.NewsIndustryId.Value.ToString();

                    if (!string.IsNullOrWhiteSpace(news.NewsTypeIds))
                    {
                        string[] ids = (news.NewsTypeIds).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string id in ids)
                        {
                            lstNewsType.Items.FindByValue(id).Selected = true;
                            //lstNewsType.SelectedValue = id;
                        }
                    }

                    tbImageURL.Text = news.ImageUrl;
                    tbAuthor.Text = news.Author;

                    AdminUsersService aus = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(news.LastModifiedBy))
                    {
                        dataLastModifiedBy.Text = adminuser.UserName;
                    }
                }
            }
        } 
    }

    protected void cvPostDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrWhiteSpace(dataPostDate.Text))
        {
            DateTime dt;

            if (DateTime.TryParseExact(dataPostDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
            {
                if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                {
                    cvPostDate.ErrorMessage = "Date out of range.";

                    args.IsValid = false;
                }
            }
            else
            {
                cvPostDate.ErrorMessage = "Invalid Date.";

                args.IsValid = false;
            }
        }
    }

    #endregion

    #region Button Events

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                using (JXTPortal.Entities.News news = new JXTPortal.Entities.News())
                {
                    //news.NewsId = NewsId;
                    news.NewsCategoryId = Convert.ToInt32(dataNewsCategoryId.SelectedValue);
                    news.Subject = HttpUtility.HtmlEncode(dataSubject.Text.Trim());
                    news.Content = txtPageContent.Text;
                    news.PostDate = DateTime.ParseExact(dataPostDate.Text, SessionData.Site.DateFormat, null);
                    news.Valid = chkValid.Checked;
                    news.Tags = dataTags.Text;

                    if (!String.IsNullOrEmpty(dataSequence.Text))
                        news.Sequence = Convert.ToInt32(dataSequence.Text);
                    else
                        news.Sequence = 0;

                    // Set the Page Friendly Name
                    if (!String.IsNullOrEmpty(txtPageFriendlyName.Text.Trim()))
                        news.PageFriendlyName = Utils.UrlFriendlyName(txtPageFriendlyName.Text.Trim());
                    else
                        news.PageFriendlyName = Utils.UrlFriendlyName(news.Subject);

                    news.MetaTitle = HttpUtility.HtmlEncode(txtMetaTitle.Text.Trim());
                    news.MetaKeywords = HttpUtility.HtmlEncode(txtMetaKeywords.Text.Trim());
                    news.MetaDescription = HttpUtility.HtmlEncode(txtMetaDescription.Text.Trim());


                    if (ddlIndustries != null && ddlIndustries.SelectedValue != null)
                        news.NewsIndustryId = Convert.ToInt32(ddlIndustries.SelectedValue);
                    else
                        news.NewsIndustryId = null;

                    if (lstNewsType != null && lstNewsType.Items.Count > 0)
                    {
                        news.NewsTypeIds = string.Empty;
                        foreach (ListItem item in lstNewsType.Items)
                        {
                            if (item.Selected)
                            {
                                if (!string.IsNullOrWhiteSpace(news.NewsTypeIds))
                                    news.NewsTypeIds = news.NewsTypeIds + "," + item.Value;
                                else
                                    news.NewsTypeIds = item.Value;
                            }
                        }
                    }

                    news.ImageUrl = tbImageURL.Text;
                    news.Author = tbAuthor.Text;

                    NewsService.Insert(news);
                    Response.Redirect("news.aspx");
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                using (JXTPortal.Entities.News news = NewsService.GetByNewsId(NewsId))
                {
                    if (news.SiteId != SessionData.Site.SiteId)
                        Response.Redirect("/admin/news.aspx");
                    else
                    {
                        news.NewsCategoryId = Convert.ToInt32(dataNewsCategoryId.SelectedValue);
                        news.Subject = HttpUtility.HtmlEncode(dataSubject.Text);
                        news.Content = txtPageContent.Text;
                        news.PostDate = DateTime.ParseExact(dataPostDate.Text, SessionData.Site.DateFormat, null);
                        news.Valid = chkValid.Checked;
                        news.Tags = dataTags.Text;

                        if (!String.IsNullOrEmpty(dataSequence.Text))
                            news.Sequence = Convert.ToInt32(dataSequence.Text);
                        else
                            news.Sequence = 0;

                        // Set the Page Friendly Name
                        if (!String.IsNullOrEmpty(txtPageFriendlyName.Text.Trim()))
                            news.PageFriendlyName = Utils.UrlFriendlyName(txtPageFriendlyName.Text.Trim());
                        else
                            news.PageFriendlyName = Utils.UrlFriendlyName(news.Subject);

                        news.MetaTitle = HttpUtility.HtmlEncode(txtMetaTitle.Text.Trim());
                        news.MetaKeywords = HttpUtility.HtmlEncode(txtMetaKeywords.Text.Trim());
                        news.MetaDescription = HttpUtility.HtmlEncode(txtMetaDescription.Text.Trim());


                        if (ddlIndustries != null && ddlIndustries.SelectedValue != null)
                            news.NewsIndustryId = Convert.ToInt32(ddlIndustries.SelectedValue);
                        else
                            news.NewsIndustryId = null;

                        if (lstNewsType != null && lstNewsType.Items.Count > 0)
                        {
                            news.NewsTypeIds = string.Empty;
                            foreach (ListItem item in lstNewsType.Items)
                            {
                                if (item.Selected)
                                {
                                    if (!string.IsNullOrWhiteSpace(news.NewsTypeIds))
                                        news.NewsTypeIds = news.NewsTypeIds + "," + item.Value;
                                    else
                                        news.NewsTypeIds = item.Value;
                                }
                            }
                        }
                        news.ImageUrl = tbImageURL.Text;
                        news.Author = tbAuthor.Text;
                        NewsService.Update(news);
                        Response.Redirect("news.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("news.aspx");
    }

    #endregion

}


