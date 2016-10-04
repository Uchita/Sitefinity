

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

public partial class Roles : System.Web.UI.Page
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
            LoadProfession();
            Load();
        }
    }

    private void LoadProfession()
    {
        ProfessionService service = new ProfessionService();
        ddlProfession.Items.Clear();
        string whereclause = "ReferredSiteID IS NULL";

        if (SessionData.Site.UseCustomProfessionRole)
        {
            whereclause = string.Format("ReferredSiteID = {0}", SessionData.Site.SiteId);
        }

        ddlProfession.DataValueField = "ProfessionID";
        ddlProfession.DataTextField = "ProfessionName";

        ddlProfession.DataSource = service.GetPaged(whereclause, string.Empty, 0, Int32.MaxValue);
        ddlProfession.DataBind();

        ddlProfession.Items.Insert(0, new ListItem("- Select a Profession -", "0"));
    }

    private void Load()
    {
        rptRoles.DataSource = null;

        string whereclause = string.Empty;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");
        int totalCount = 0;
        int pageCount = 0;

        if (ddlProfession.SelectedValue != "0")
        {
            whereclause = string.Format("ProfessionID = {0}", ddlProfession.SelectedValue);

            RolesService service = new RolesService();
            TList<JXTPortal.Entities.Roles> roleslist = service.GetPaged(whereclause, string.Empty, CurrentPage, sitePageCount, out totalCount);
            rptRoles.DataSource = roleslist;


            if (roleslist.Count > 0)
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
                rptPage.DataSource = null;
                rptPage.DataBind();
                rptRoles.DataSource = null;
                ltlMessage.Text = "No Record found";
            }

            rptRoles.DataBind();
        }
        else
        {
            rptRoles.DataSource = null;
            rptRoles.DataBind();

            rptPage.DataSource = null;
            rptPage.DataBind();
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

    protected void ddlProfession_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = 0;
        Load();
    }

    protected void rptRoles_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            JXTPortal.Entities.Roles role = e.Item.DataItem as JXTPortal.Entities.Roles;

            Literal ltRoleName = e.Item.FindControl("ltRoleName") as Literal;
            CheckBox ltValid = e.Item.FindControl("ltValid") as CheckBox;
            Literal ltMetaTitle = e.Item.FindControl("ltMetaTitle") as Literal;
            Literal ltMetaKeywords = e.Item.FindControl("ltMetaKeywords") as Literal;
            Literal ltMetaDescription = e.Item.FindControl("ltMetaDescription") as Literal;

            ltRoleName.Text = role.RoleName;
            ltValid.Checked = Convert.ToBoolean(role.Valid);
            ltMetaTitle.Text = role.MetaTitle;
            ltMetaKeywords.Text = role.MetaKeywords;
            ltMetaDescription.Text = role.MetaDescription;
        }
    }
	
}


