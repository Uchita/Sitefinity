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

namespace JXTPortal.Website.Admin
{
    public partial class SiteNewsIndustryEdit : System.Web.UI.Page
    {
        #region Declare variables
        #endregion

        #region Properties

        private NewsIndustryService _newsIndustryService;

        private NewsIndustryService NewsIndustryService
        {
            get
            {
                if (_newsIndustryService == null)
                {
                    _newsIndustryService = new NewsIndustryService();
                }
                return _newsIndustryService;
            }
        }


        private NewsService _newsService;

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

        private int NewsIndustryId
        {
            get
            {
                int _NewsIndustryId = 0;

                if (Int32.TryParse(Request.QueryString["NewsIndustryId"], out _NewsIndustryId))
                {
                    _NewsIndustryId = Convert.ToInt32(Request.QueryString["NewsIndustryId"]);
                }

                return _NewsIndustryId;
            }
        }

        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (NewsIndustryId > 0)
                {
                    Load(NewsIndustryId);
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
                JXTPortal.Entities.NewsIndustry newsIndustry = new JXTPortal.Entities.NewsIndustry();

                if (tbIndustryName.Text.Trim().Length > 0)
                {
                    if (NewsIndustryId > 0)
                    {
                        newsIndustry = NewsIndustryService.GetByNewsIndustryId(NewsIndustryId);

                        //site check
                        if (newsIndustry.SiteId != SessionData.Site.SiteId)
                            Response.Redirect("sitenewsindustry.aspx");
                    }

                    newsIndustry.NewsIndustryName = tbIndustryName.Text.Trim();
                    newsIndustry.GlobalTemplate = false;
                    newsIndustry.SiteId = SessionData.Site.SiteId;
                    newsIndustry.Sequence = int.Parse(txtSequence.Text);
                    newsIndustry.LastModifiedDate = DateTime.Now;

                    if (NewsIndustryId > 0)
                    {
                        // Update Record

                        NewsIndustryService.Update(newsIndustry);
                    }
                    else
                    {
                        // Insert Record
                        NewsIndustryService.Insert(newsIndustry);
                    }

                    Response.Redirect("sitenewsindustry.aspx");
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "Error: " + ex.Message;
            }
        }

        #endregion

        #region Methods

        private void Load(int newsIndustryId)
        {
            using (JXTPortal.Entities.NewsIndustry newsIndustry = NewsIndustryService.GetByNewsIndustryId(newsIndustryId))
            {
                if (newsIndustry != null && newsIndustry.SiteId == SessionData.Site.SiteId)
                {
                    tbIndustryName.Text = newsIndustry.NewsIndustryName;
                    txtSequence.Text = newsIndustry.Sequence.ToString();
                    ltlLastModified.Text = newsIndustry.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                    if (newsIndustry.LastModifiedBy > 0)
                    {
                        AdminUsersService aus = new AdminUsersService();
                        using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(newsIndustry.LastModifiedBy.Value))
                        {
                            ltlLastModifiedBy.Text = adminuser.UserName;
                        }
                    }

                    btnSave.Text = "Update";
                }
                else
                {
                    Response.Redirect("sitenewsIndustry.aspx");
                }
            }
        }

        #endregion
    }
}