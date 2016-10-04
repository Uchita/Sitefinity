
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
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Website;
#endregion

public partial class NewsCategoriesEdit : System.Web.UI.Page
{
    #region Declare variables
    #endregion

    #region Properties

    private NewsCategoriesService _newsCategoriesService;

    private NewsCategoriesService NewsCategoriesService
    {
        get
        {
            if (_newsCategoriesService == null)
            {
                _newsCategoriesService = new NewsCategoriesService();
            }
            return _newsCategoriesService;
        }
    }


    private NewsService  _newsService;

    private NewsService NewsService
    {
        get
        {
            if (_newsService == null)
            {
                _newsService = new NewsService();
            }
            return _newsService;
        }
    }

    private int NewsCategoryId
    {
        get
        {
            int _NewsCategoryId = 0;

            if (Int32.TryParse(Request.QueryString["NewsCategoryId"], out _NewsCategoryId))
            {
                _NewsCategoryId = Convert.ToInt32(Request.QueryString["NewsCategoryId"]);
            }

            return _NewsCategoryId;
        }
    }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (NewsCategoryId > 0)
            {
                Load(NewsCategoryId);
            }
        }
    }

    #endregion

    #region Click Events

    /// <summary>
    /// Save the News Category
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            JXTPortal.Entities.NewsCategories newsCategory = new JXTPortal.Entities.NewsCategories();

            if (txtCategoryName.Text.Trim().Length > 0)
            {
                if (NewsCategoryId > 0)
                {
                    newsCategory = NewsCategoriesService.GetByNewsCategoryId(NewsCategoryId);

                    //site check
                    if( newsCategory.SiteId != SessionData.Site.SiteId )
                        Response.Redirect("newscategories.aspx");
                }
                
                newsCategory.NewsCategoryName = txtCategoryName.Text.Trim();

                // Set the Page Friendly Name
                if (!String.IsNullOrEmpty(txtPageFriendlyName.Text.Trim()))
                {
                    newsCategory.PageFriendlyName = Utils.UrlFriendlyName(txtPageFriendlyName.Text.Trim());
                }
                else
                {
                    newsCategory.PageFriendlyName = Utils.UrlFriendlyName(newsCategory.NewsCategoryName);
                }

                newsCategory.Valid = chkValid.Checked;
                newsCategory.Sequence = int.Parse(txtSequence.Text);
                newsCategory.MetaTitle = HttpUtility.HtmlEncode(txtMetaTitle.Text.Trim());
                newsCategory.MetaKeywords = HttpUtility.HtmlEncode(txtMetaKeywords.Text.Trim());
                newsCategory.MetaDescription = HttpUtility.HtmlEncode(txtMetaDescription.Text.Trim());

                if (NewsCategoryId > 0)
                {
                    // Update Record

                    if (pnlMoveTo.Visible )
                    {
                        int newNewsCategoryId = Convert.ToInt32(ddlMoveTo.SelectedValue);
                        using (TList<JXTPortal.Entities.News> news = NewsService.GetByNewsCategoryId(NewsCategoryId))
                        {
                            foreach (JXTPortal.Entities.News newsarticle in news)
                            {
                                newsarticle.NewsCategoryId = newNewsCategoryId;
                                NewsService.Update(newsarticle);
                            }
                        }

                    }

                    NewsCategoriesService.Update(newsCategory);
                }
                else
                {
                    // Insert Record
                    NewsCategoriesService.Insert(newsCategory);
                }
                
                Response.Redirect("newscategories.aspx");
            }
        }
        catch (Exception ex)
        {
            ltlMessage.Text = "Error: " + ex.Message;
        }
    }

    #endregion

    #region Methods

    private void Load(int newsCategoryId)
    {
        using (JXTPortal.Entities.NewsCategories newsCategory = NewsCategoriesService.GetByNewsCategoryId(newsCategoryId))
        {
            if (newsCategory != null && newsCategory.SiteId == SessionData.Site.SiteId)
            {
                txtCategoryName.Text = newsCategory.NewsCategoryName;
                txtPageFriendlyName.Text = newsCategory.PageFriendlyName;
                chkValid.Checked = newsCategory.Valid;
                txtSequence.Text = newsCategory.Sequence.ToString();
                txtMetaTitle.Text = HttpUtility.HtmlDecode(newsCategory.MetaTitle);
                txtMetaKeywords.Text = HttpUtility.HtmlDecode(newsCategory.MetaKeywords);
                txtMetaDescription.Text = HttpUtility.HtmlDecode(newsCategory.MetaDescription);
                ltlLastModified.Text = newsCategory.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                LoadNewsCategory(newsCategory.NewsCategoryId);

                if (newsCategory.LastModifiedBy > 0)
                {
                    AdminUsersService aus = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(newsCategory.LastModifiedBy))
                    {
                        ltlLastModifiedBy.Text = adminuser.UserName;
                    }
                }

                btnSave.Text = "Update";
            }
            else
            {
                Response.Redirect("newscategories.aspx");
            }
        }
    }

    private void LoadNewsCategory(int newsCategoryId)
    {
        ddlMoveTo.Items.Clear();
        TList<JXTPortal.Entities.NewsCategories> newsCategories = NewsCategoriesService.GetBySiteId(SessionData.Site.SiteId);
        newsCategories.Filter = "NewsCategoryID <> " + newsCategoryId.ToString();

        ddlMoveTo.DataValueField = "NewsCategoryID";
        ddlMoveTo.DataTextField = "NewsCategoryName";

        ddlMoveTo.DataSource = newsCategories;
        ddlMoveTo.DataBind();

        ddlMoveTo.Items.Insert(0, new ListItem("Select a News Category", "0"));
    }

    #endregion

    protected void chkValid_CheckedChanged(object sender, EventArgs e)
    {
        if (btnSave.Text == "Update")
        {
            pnlMoveTo.Visible = !chkValid.Checked;
        }
    }


}


