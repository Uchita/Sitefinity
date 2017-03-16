using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Service.Dapper;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;
using JXTPortal.Service.Dapper.Models;

namespace JXTPortal.Website.Admin
{
    public partial class ScreeningQuestionsTemplate : System.Web.UI.Page
    {
  
        public IScreeningQuestionsTemplatesService ScreeningQuestionsTemplatesService { get; set; }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadScreeningQuestionsTemplates();
            }
        }

        private void LoadScreeningQuestionsTemplates()
        {
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

            ScreeningQuestionsTemplateDetail screeningQuestionsTemplateDetail = ScreeningQuestionsTemplatesService.GetPaged(SessionData.Site.SiteId, CurrentPage, sitePageCount);
            lblErrorMsg.Visible = false;

            if (screeningQuestionsTemplateDetail.ScreeningQuestionsTemplates.Any())
            {
                var pagelist = GetPageList(sitePageCount);

                if (pagelist.Any())
                {
                    rptPage.DataSource = pagelist;
                    rptPage.DataBind();
                    rptPage.Visible = true;
                }
                else
                {
                    rptPage.Visible = false;
                }

                rptScreeningQuestionsTemplate.DataSource = screeningQuestionsTemplateDetail.ScreeningQuestionsTemplates;
                rptScreeningQuestionsTemplate.DataBind();
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "No result Found";
                rptScreeningQuestionsTemplate.DataSource = null;
                rptScreeningQuestionsTemplate.DataBind();
                rptPage.DataSource = null;
                rptPage.DataBind();
            }
        }

        private IEnumerable<string> GetPageList(int sitePageCount)
        {
            int _maxPagesToDisplay = 10;
            IList<string> results = new List<string>();
            int totalCount = ScreeningQuestionsTemplatesService.GetSiteCount(SessionData.Site.SiteId);
            int pageCount = (int)Math.Ceiling((double)totalCount / sitePageCount);

            if (CurrentPage >= _maxPagesToDisplay)
            {
                results.Add("previous");
            }

            //Determine the index of the first page to add to the pageList
            int index = (CurrentPage == 0) ? 0 : (CurrentPage / _maxPagesToDisplay) * _maxPagesToDisplay;

            for (int i = index; i < pageCount; i++)
            {
                results.Add(i.ToString());

                if ((i % 10) == 9 && (i < pageCount - 1))
                {
                    results.Add("next");
                    break;
                }
            }

            return results;
        }

        protected void btnCreateNewTemplate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/ScreeningQuestionsTemplateEdit.aspx");
        }

        protected void rptScreeningQuestionsTemplate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltTemplateID = e.Item.FindControl("ltTemplateID") as Literal;
                Literal ltTemplateName = e.Item.FindControl("ltTemplateName") as Literal;
                Literal ltVisible = e.Item.FindControl("ltVisible") as Literal;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;
                Literal ltLastModifiedBy = e.Item.FindControl("ltLastModifiedBy") as Literal;

                JXTPortal.Service.Dapper.Models.ScreeningQuestionsTemplate screeningQuestionsTemplate = e.Item.DataItem as JXTPortal.Service.Dapper.Models.ScreeningQuestionsTemplate;

                ltTemplateID.Text = screeningQuestionsTemplate.ScreeningQuestionsTemplateId.ToString();
                ltTemplateName.Text = HttpUtility.HtmlEncode(screeningQuestionsTemplate.TemplateName);
                ltVisible.Text = (screeningQuestionsTemplate.Visible) ? "Yes" : "No";
                ltLastModified.Text = screeningQuestionsTemplate.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss");
                ltLastModifiedBy.Text = HttpUtility.HtmlEncode(screeningQuestionsTemplate.LastModifiedByName);
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
                LoadScreeningQuestionsTemplates();
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
    }
}