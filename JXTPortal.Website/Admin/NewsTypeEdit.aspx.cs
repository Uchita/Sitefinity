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
using JXTPortal.Web.UI;
using JXTPortal.Entities;
#endregion


namespace JXTPortal.Website.Admin
{
    public partial class NewsTypeEdit : System.Web.UI.Page
    {
        #region Declare Variables

        private int newstypeId = 0;

        #endregion

        #region Properties

        JXTPortal.NewsTypeService _newstypeService;
        JXTPortal.NewsTypeService NewsTypeService
        {
            get
            {
                if (_newstypeService == null)
                {
                    _newstypeService = new JXTPortal.NewsTypeService();
                }
                return _newstypeService;
            }
        }

        private int NewsTypeID
        {
            get
            {
                if ((Request.QueryString["NewsTypeId"] != null))
                {
                    if (int.TryParse((Request.QueryString["NewsTypeId"].Trim()), out newstypeId))
                    {
                        newstypeId = Convert.ToInt32(Request.QueryString["NewsTypeId"]);
                    }
                    return newstypeId;
                }
                return newstypeId;
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
            if (NewsTypeID > 0)
            {
                using (JXTPortal.Entities.NewsType objNewsType = NewsTypeService.GetByNewsTypeId(NewsTypeID))
                {
                    if (objNewsType.GlobalTemplate)
                    {
                        //txtEducationParentID.Text = Convert.ToString(objEducations.EducationParentId);
                        txtnewsTypeName.Text = objNewsType.NewsTypeName;
                        tbImageURL.Text = objNewsType.ImageUrl;
                        lblLastModifiedBy.Text = Convert.ToString(objNewsType.LastModifiedBy);
                        lblLastModifiedDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", objNewsType.LastModifiedDate);
                        txtnewsTypeSequence.Text = Convert.ToString(objNewsType.Sequence);
                    }
                }
            }
        }

        #endregion

        #region Click Event handlers

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                JXTPortal.Entities.NewsType objNewsType = new JXTPortal.Entities.NewsType();
                bool isupdate = true;

                try
                {
                    if (NewsTypeID > 0)
                    {
                        objNewsType = NewsTypeService.GetByNewsTypeId(NewsTypeID);
                        if (objNewsType != null && objNewsType.GlobalTemplate == false)
                        {
                            isupdate = false;
                        }
                    }

                    objNewsType.NewsTypeParentId = (int?)null;
                    objNewsType.NewsTypeName = txtnewsTypeName.Text;
                    objNewsType.ImageUrl = tbImageURL.Text;
                    objNewsType.GlobalTemplate = chknewsTypeGlobalTemplate.Checked;
                    objNewsType.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                    objNewsType.LastModifiedDate = DateTime.Now;
                    objNewsType.Sequence = Convert.ToInt32(txtnewsTypeSequence.Text);

                    if (NewsTypeID > 0 && isupdate)
                    {
                        NewsTypeService.Update(objNewsType);
                    }
                    else
                    {
                        NewsTypeService.Insert(objNewsType);
                    }

                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
                finally
                {
                    objNewsType.Dispose();
                }
                Response.Redirect("newstype.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("newstype.aspx");
        }
        #endregion
    }
}