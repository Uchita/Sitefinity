#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Website;
using JXTPortal;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class SiteSummary : System.Web.UI.Page
    {
        #region Properties

        SiteSummaryService _siteSummaryService;
        SiteSummaryService SiteSummaryService
        {
            get
            {
                if (_siteSummaryService == null)
                {
                    _siteSummaryService = new JXTPortal.SiteSummaryService();
                }
                return _siteSummaryService;
            }
        }

        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
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

        #region Events

        protected void rptSiteSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
                {
                    PlaceHolder phHeadCol = e.Item.FindControl("phHeadCol") as PlaceHolder;
                    phHeadCol.Visible = false;
                }
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltTitle = e.Item.FindControl("ltTitle") as Literal;
                Literal ltDescription = e.Item.FindControl("ltDescription") as Literal;
                HyperLink hlURL = e.Item.FindControl("hlURL") as HyperLink;
                Literal ltTimeStamp = e.Item.FindControl("ltTimeStamp") as Literal;
                Literal ltValid = e.Item.FindControl("ltValid") as Literal;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;
                PlaceHolder phCol = e.Item.FindControl("phCol") as PlaceHolder;


                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
                {
                    phCol.Visible = false;
                }

                Entities.SiteSummary sitesummary = e.Item.DataItem as Entities.SiteSummary;
                ltTitle.Text = HttpUtility.HtmlEncode(sitesummary.Title);
                ltDescription.Text = HttpUtility.HtmlEncode(sitesummary.Description);
                hlURL.NavigateUrl = sitesummary.Url;
                ltTimeStamp.Text = (sitesummary.TimeStamp.HasValue) ? sitesummary.TimeStamp.Value.ToString(SessionData.Site.DateFormat) : string.Empty;
                ltValid.Text = Enum.GetName(typeof(PortalEnums.Admin.SiteSummaryValid), sitesummary.Valid);
                ltLastModified.Text = sitesummary.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                if (e.CommandArgument.ToString() == "prev")
                {
                    CurrentPage = ((CurrentPage + 1) / 10 * 10 - 1);
                }
                else if (e.CommandArgument.ToString() == "next")
                {
                    CurrentPage = ((CurrentPage + 10) / 10 * 10);
                }
                else
                {
                    CurrentPage = Convert.ToInt32(e.CommandArgument);
                }
                loadForm();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;

                if (e.Item.DataItem.ToString() == "previous")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "prev";
                }
                else if (e.Item.DataItem.ToString() == "next")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "next";
                }
                else
                {
                    lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                    lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();
                }

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                    lbPageNo.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        #endregion

        #region Method

        protected void loadForm()
        {
            //if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != 1)
            //{
            //    pnlSiteID.Visible = false;
            //}        

            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");
            string filter = string.Empty;

            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
            {
                filter = "Valid = " + (int)PortalEnums.Admin.SiteSummaryValid.Live + " OR Valid = " + (int)PortalEnums.Admin.SiteSummaryValid.Prelive + " OR SiteID = " + SessionData.Site.SiteId.ToString();
                btnSiteSummary.Visible = false;
            }

            using (TList<JXTPortal.Entities.SiteSummary> summary = SiteSummaryService.GetPaged(filter, "SiteSummaryID DESC", CurrentPage, sitePageCount, out totalCount))
            {
                if (summary.Count > 0)
                {
                    ArrayList pagelist = new ArrayList();

                    if (totalCount % sitePageCount == 0)
                        pageCount = totalCount / sitePageCount;
                    else
                        pageCount = (totalCount / sitePageCount) + 1;

                    if (CurrentPage >= 10)
                    {
                        pagelist.Add("previous");
                    }

                    int index = (CurrentPage == 0) ? 0 : (CurrentPage) / 10 * 10;
                    for (int i = index; i < pageCount; i++)
                    {
                        pagelist.Add(i.ToString());

                        if ((i % 10) == 9 && (i < pageCount - 1))
                        {
                            pagelist.Add("next");
                            break;
                        }

                    }

                    if (pagelist.Count > 1)
                    {
                        rptPage.DataSource = pagelist;
                        rptPage.DataBind();
                        rptPage.Visible = true;
                    }
                    else
                    {
                        rptPage.Visible = false;
                    }

                    if (pagelist.Count > 1)
                    {
                        rptPage.DataSource = pagelist;
                        rptPage.DataBind();
                        rptPage.Visible = true;
                    }
                    else
                    {
                        rptPage.Visible = false;
                    }

                    rptSiteSummary.DataSource = summary;
                    rptSiteSummary.DataBind();

                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "No result Found";
                    rptSiteSummary.DataSource = null;
                    rptSiteSummary.DataBind();
                    rptPage.DataSource = null;
                    rptPage.DataBind();
                }
            }

        }

        #endregion
    }
}