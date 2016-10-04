

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
using JXTPortal;
using JXTPortal.Entities;
using System.Collections;
#endregion

public partial class Profession : System.Web.UI.Page
{
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
        ltlMessage.Text = string.Empty;

        if (!Page.IsPostBack)
        {
            Load();
        }
    }

    private void Load()
    {
        rptProfession.DataSource = null;

        ProfessionService service = new ProfessionService();
        string whereclause = "ReferredSiteID IS NULL";
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");
        int totalCount = 0;
        int pageCount = 0;

        if (SessionData.Site.UseCustomProfessionRole)
        {
            whereclause = string.Format("ReferredSiteID = {0}", SessionData.Site.SiteId);

        }
        DataSet ds = service.GetPaged(whereclause, string.Empty, CurrentPage, sitePageCount);
        rptProfession.DataSource = ds;
        rptProfession.DataBind();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ArrayList pagelist = new ArrayList();
            totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);

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
            rptProfession.DataSource = null;
            rptProfession.DataBind();

            ltlMessage.Text = "No Record found";
        }

    }

    protected void rptProfession_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView profession = e.Item.DataItem as DataRowView;

            Literal ltProfessionName = e.Item.FindControl("ltProfessionName") as Literal;
            CheckBox ltValid = e.Item.FindControl("ltValid") as CheckBox;
            Literal ltMetaTitle = e.Item.FindControl("ltMetaTitle") as Literal;
            Literal ltMetaKeywords = e.Item.FindControl("ltMetaKeywords") as Literal;
            Literal ltMetaDescription = e.Item.FindControl("ltMetaDescription") as Literal;

            ltProfessionName.Text = profession["ProfessionName"].ToString();
            ltValid.Checked = Convert.ToBoolean(profession["Valid"]);
            ltMetaTitle.Text = profession["MetaTitle"].ToString();
            ltMetaKeywords.Text = profession["MetaKeywords"].ToString();
            ltMetaDescription.Text = profession["MetaDescription"].ToString();
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
            Load();
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


