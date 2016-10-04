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
    public partial class NewsIndustryEdit : System.Web.UI.Page
    {
        #region Declare Variables

        private int newsindustryId = 0;

        #endregion

        #region Properties

        JXTPortal.NewsIndustryService _newsindustryService;
        JXTPortal.NewsIndustryService NewsIndustryService
        {
            get
            {
                if (_newsindustryService == null)
                {
                    _newsindustryService = new JXTPortal.NewsIndustryService();
                }
                return _newsindustryService;
            }
        }

        private int NewsIndustryID
        {
            get
            {
                if ((Request.QueryString["NewsIndustryId"] != null))
                {
                    if (int.TryParse((Request.QueryString["NewsIndustryId"].Trim()), out newsindustryId))
                    {
                        newsindustryId = Convert.ToInt32(Request.QueryString["NewsIndustryId"]);
                    }
                    return newsindustryId;
                }
                return newsindustryId;
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
            if (NewsIndustryID > 0)
            {
                using (JXTPortal.Entities.NewsIndustry objNewsIndustry = NewsIndustryService.GetByNewsIndustryId(NewsIndustryID))
                {
                    if (objNewsIndustry.GlobalTemplate)
                    {
                        //txtEducationParentID.Text = Convert.ToString(objEducations.EducationParentId);
                        txtnewsIndustryName.Text = objNewsIndustry.NewsIndustryName;
                        lblLastModifiedBy.Text = Convert.ToString(objNewsIndustry.LastModifiedBy);
                        lblLastModifiedDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", objNewsIndustry.LastModifiedDate);
                        txtnewsIndustrySequence.Text = Convert.ToString(objNewsIndustry.Sequence);
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
                JXTPortal.Entities.NewsIndustry objNewsIndustry = new JXTPortal.Entities.NewsIndustry();
                bool isupdate = true;

                try
                {
                    if (NewsIndustryID > 0)
                    {
                        objNewsIndustry = NewsIndustryService.GetByNewsIndustryId(NewsIndustryID);
                        if (objNewsIndustry != null && objNewsIndustry.GlobalTemplate == false)
                        {
                            isupdate = false;
                        }
                    }

                    objNewsIndustry.NewsIndustryParentId = (int?)null;
                    objNewsIndustry.NewsIndustryName = txtnewsIndustryName.Text;
                    objNewsIndustry.GlobalTemplate = chknewsIndustryGlobalTemplate.Checked;
                    objNewsIndustry.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                    objNewsIndustry.LastModifiedDate = DateTime.Now;
                    objNewsIndustry.Sequence = Convert.ToInt32(txtnewsIndustrySequence.Text);

                    if (NewsIndustryID > 0 && isupdate)
                    {
                        NewsIndustryService.Update(objNewsIndustry);
                    }
                    else
                    {
                        NewsIndustryService.Insert(objNewsIndustry);
                    }

                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
                finally
                {
                    objNewsIndustry.Dispose();
                }
                Response.Redirect("newsindustry.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("newsindustry.aspx");
        }
        #endregion
    }
}