

#region Using directives
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
using JXTPortal;
#endregion

public partial class Jobs : System.Web.UI.Page
{
    #region Declaration

    private JobsService _jobsservice;

    #endregion

    #region Properties

    private JobsService JobsService
    {
        get
        {
            if (_jobsservice == null)
            {
                _jobsservice = new JobsService();
            }
            return _jobsservice;
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

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadJobs();
        }
    }

    #endregion

    #region Method

    private void LoadJobs()
    {
        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        rptJobs.DataSource = JobsService.GetPaged("SiteID = " + SessionData.Site.SiteId.ToString(), "", CurrentPage, sitePageCount, out totalCount);
        rptJobs.DataBind();

        if (totalCount > 0)
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
        }
        else
        {
            //lblErrorMsg.Visible = true;
            //lblErrorMsg.Text = "No result Found";
            rptJobs.DataSource = null;
            rptJobs.DataBind();
            rptPage.DataSource = null;
            rptPage.DataBind();
        }
    }

    #endregion Method


    #region Events
    protected void rptJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltRefNo = e.Item.FindControl("ltRefNo") as Literal;
            Literal ltJobTitle = e.Item.FindControl("ltJobTitle") as Literal;
            Literal ltDescription = e.Item.FindControl("ltDescription") as Literal;
            Literal ltApplicationEmailAddress = e.Item.FindControl("ltApplicationEmailAddress") as Literal;
            Literal ltExpired = e.Item.FindControl("ltExpired") as Literal;
            Literal ltBilled = e.Item.FindControl("ltBilled") as Literal;
            Literal ltDatePosted = e.Item.FindControl("ltDatePosted") as Literal;
            Literal ltExpiryDate = e.Item.FindControl("ltExpiryDate") as Literal;
            Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;

            JXTPortal.Entities.Jobs job = e.Item.DataItem as JXTPortal.Entities.Jobs;

            ltRefNo.Text = job.RefNo.ToString();
            ltJobTitle.Text = job.JobName.ToString();
            ltDescription.Text = job.Description.ToString();
            ltApplicationEmailAddress.Text = job.ApplicationEmailAddress.ToString();
            ltExpired.Text = job.Expired.ToString();
            ltBilled.Text = job.Billed.ToString();
            ltDatePosted.Text = job.DatePosted.ToString(SessionData.Site.DateFormat);
            ltExpiryDate.Text = job.ExpiryDate.ToString(SessionData.Site.DateFormat);
            ltLastModified.Text = job.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
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
            LoadJobs();
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
}


