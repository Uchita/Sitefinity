#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal;
using System.Collections;
#endregion


namespace JXTPortal.Website.Admin
{
    public partial class NewsType : System.Web.UI.Page
    {
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
                LoadNewsType();
            }
        }

        private void LoadNewsType()
        {
            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

            TList<JXTPortal.Entities.NewsType> newstypes = NewsTypeService.GetPaged("SiteID IS NULL AND GlobalTemplate = 1", "", 0, Int32.MaxValue, out totalCount);

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

            rptNewsType.DataSource = newstypes;
            rptNewsType.DataBind();
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
                LoadNewsType();
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

        protected void rptNewsType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Response.Redirect("~/Admin/NewsTypeEdit.aspx?NewsTypeID=" + e.CommandArgument.ToString());
            }
        }

        protected void rptNewsType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
                Literal litNewsTypeName = e.Item.FindControl("litNewsTypeName") as Literal;
                CheckBox cbGlobalTemplate = e.Item.FindControl("cbGlobalTemplate") as CheckBox;
                Literal litSequence = e.Item.FindControl("litSequence") as Literal;
                Literal litLastModified = e.Item.FindControl("litLastModified") as Literal;

                JXTPortal.Entities.NewsType newstype = e.Item.DataItem as JXTPortal.Entities.NewsType;

                lbSelect.CommandArgument = newstype.NewsTypeId.ToString();
                litNewsTypeName.Text = newstype.NewsTypeName;
                cbGlobalTemplate.Checked = newstype.GlobalTemplate;
                litSequence.Text = newstype.Sequence.ToString();
                if (newstype.LastModifiedDate.HasValue)
                {
                    litLastModified.Text = newstype.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat);
                }
            }
        }
    }
}