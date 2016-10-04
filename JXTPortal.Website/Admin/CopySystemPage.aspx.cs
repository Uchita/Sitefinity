using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class CopySystemPage : System.Web.UI.Page
    {
        private DynamicPagesService _dynamicPagesService = null;

        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        private SiteLanguagesService _sitelanguagesservice = null;

        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesservice == null)
                {
                    _sitelanguagesservice = new SiteLanguagesService();
                }
                return _sitelanguagesservice;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ltlMessage.Text = "";

            if (!Page.IsPostBack)
            {
                LoadDynamicPages();
                LoadSites();
                LoadMissingPages();
            }
        }

        private void LoadDynamicPages()
        {
            ddlSystemPage.Items.Clear();

            DataSet ds = DynamicPagesService.GetSystemPagesNameBySiteID(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSystemPage.DataSource = ds.Tables[0];
                ddlSystemPage.DataBind();
            }

            ddlSystemPage.Items.Insert(0, new ListItem("- Select a System Page -", "0"));
        }

        private void LoadSites()
        {
            ddlSite.Items.Clear();
            pnlSystemPage.Visible = false;

            if (ddlSystemPage.SelectedValue != "0")
            {
                DataSet ds = DynamicPagesService.GetSiteMissingSystemPagesByName(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]), ddlSystemPage.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSite.DataSource = ds.Tables[0];
                    ddlSite.DataBind();
                }

                ddlSite.Items.Insert(0, new ListItem("- All -", "0"));
            }
            else
            {
                ddlSite.Items.Insert(0, new ListItem("- Select a System Page first -", "0"));
            }
        }

        private void LoadMissingPages()
        {
            int mastersiteid = Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]);
            int siteid = SessionData.Site.SiteId;
            pnlMissingSystemPage.Visible = false;

            if (mastersiteid != siteid)
            {
                DataSet ds = DynamicPagesService.GetMissingSystemPagesBySiteID(mastersiteid, siteid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptSystemPages.DataSource = ds.Tables[0];
                    rptSystemPages.DataBind();

                    pnlMissingSystemPage.Visible = true;
                }
            }
        }

        protected void ddlSystemPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSites();

            pnlSystemPage.Visible = false;
            if (ddlSystemPage.SelectedValue != "0")
            {
                TList<Entities.DynamicPages> ds = DynamicPagesService.GetSystemPagesBySiteIDPageName(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]), ddlSystemPage.SelectedValue);
                if (ds.Count > 0)
                {
                    tbContent.Text = ds[0].PageContent;
                    pnlSystemPage.Visible = true;
                }
            }
        }

        protected void rptSystemPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chkSystemPage = e.Item.FindControl("chkSystemPage") as CheckBox;
                Literal ltlSystemPage = e.Item.FindControl("ltlSystemPage") as Literal;

                DataRowView dr = (DataRowView)e.Item.DataItem;
                ltlSystemPage.Text = dr["PageName"].ToString();
            }
        }

        protected void cvSystemPages_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;

            foreach (RepeaterItem ri in rptSystemPages.Items)
            {
                CheckBox chkSystemPage = ri.FindControl("chkSystemPage") as CheckBox;
                if (chkSystemPage.Checked)
                {
                    count++;
                }
            }

            args.IsValid = (count > 0);
        }

        protected void CopyButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string systempagename = ddlSystemPage.SelectedValue;
                int siteid = Convert.ToInt32(ddlSite.SelectedValue);

                if (ddlSite.SelectedValue == "0") // All
                {
                    foreach (ListItem li in ddlSite.Items)
                    {
                        DynamicPagesService.CopySystemPage(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]), Convert.ToInt32(li.Value)
                                                            , systempagename, JXTPortal.Entities.PortalConstants.DEFAULT_LANGUAGE_ID, Convert.ToInt32(ConfigurationManager.AppSettings["DefaultAdminID"]));
                    }
                }
                else
                {
                    DynamicPagesService.CopySystemPage(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]), Convert.ToInt32(ddlSite.SelectedValue)
                                                            , systempagename, JXTPortal.Entities.PortalConstants.DEFAULT_LANGUAGE_ID, Convert.ToInt32(ConfigurationManager.AppSettings["DefaultAdminID"]));
                }

                LoadDynamicPages();
                LoadSites();
                LoadMissingPages();

                ltlMessage.Text = "System Page has been copied successfully";
            }
        }

        protected void CopyButton2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CopyButton2.Enabled = false;

                foreach (RepeaterItem ri in rptSystemPages.Items)
                {
                    CheckBox chkSystemPage = ri.FindControl("chkSystemPage") as CheckBox;
                    Literal ltlSystemPage = ri.FindControl("ltlSystemPage") as Literal;

                    if (chkSystemPage.Checked)
                    {
                        DynamicPagesService.CopySystemPage(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]), SessionData.Site.SiteId
                                                            , ltlSystemPage.Text, JXTPortal.Entities.PortalConstants.DEFAULT_LANGUAGE_ID, Convert.ToInt32(ConfigurationManager.AppSettings["DefaultAdminID"]));
                    }
                }

                ltlMessage.Text = "System Page has been copied successfully";
                LoadMissingPages();
            }

            CopyButton2.Enabled = true;
        }
    }
}
