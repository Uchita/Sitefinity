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
    public partial class SiteNewsTypeEdit : System.Web.UI.Page
    {
         #region Declare variables
        #endregion

        #region Properties

        private NewsTypeService _newsTypeService;

        private NewsTypeService NewsTypeService
        {
            get
            {
                if (_newsTypeService == null)
                {
                    _newsTypeService = new NewsTypeService();
                }
                return _newsTypeService;
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

        private int NewsTypeId
        {
            get
            {
                int _NewsTypeId = 0;

                if (Int32.TryParse(Request.QueryString["NewsTypeId"], out _NewsTypeId))
                {
                    _NewsTypeId = Convert.ToInt32(Request.QueryString["NewsTypeId"]);
                }

                return _NewsTypeId;
            }
        }

        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (NewsTypeId > 0)
                {
                    Load(NewsTypeId);
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
                JXTPortal.Entities.NewsType newsType = new JXTPortal.Entities.NewsType();

                if (tbTypeName.Text.Trim().Length > 0)
                {
                    if (NewsTypeId > 0)
                    {
                        newsType = NewsTypeService.GetByNewsTypeId(NewsTypeId);

                        //site check
                        if (newsType.SiteId != SessionData.Site.SiteId)
                            Response.Redirect("sitenewstype.aspx");
                    }

                    newsType.NewsTypeName = tbTypeName.Text.Trim();
                    newsType.ImageUrl = tbImageURL.Text.Trim();
                    newsType.GlobalTemplate = false;
                    newsType.SiteId = SessionData.Site.SiteId;
                    newsType.Sequence = int.Parse(txtSequence.Text);
                    newsType.LastModifiedDate = DateTime.Now;

                    if (NewsTypeId > 0)
                    {
                        // Update Record

                        NewsTypeService.Update(newsType);
                    }
                    else
                    {
                        // Insert Record
                        NewsTypeService.Insert(newsType);
                    }

                    Response.Redirect("sitenewstype.aspx");
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = "Error: " + ex.Message;
            }
        }

        #endregion

        #region Methods

        private void Load(int newsTypeId)
        {
            using (JXTPortal.Entities.NewsType newsType = NewsTypeService.GetByNewsTypeId(newsTypeId))
            {
                if (newsType != null && newsType.SiteId == SessionData.Site.SiteId)
                {
                    tbTypeName.Text = newsType.NewsTypeName;
                    txtSequence.Text = newsType.Sequence.ToString();
                    ltlLastModified.Text = newsType.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    tbImageURL.Text= newsType.ImageUrl;
                    if (newsType.LastModifiedBy > 0)
                    {
                        AdminUsersService aus = new AdminUsersService();
                        using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(newsType.LastModifiedBy.Value))
                        {
                            ltlLastModifiedBy.Text = adminuser.UserName;
                        }
                    }

                    btnSave.Text = "Update";
                }
                else
                {
                    Response.Redirect("sitenewstype.aspx");
                }
            }
        }

        #endregion
    }
}