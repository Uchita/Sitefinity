#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal;

using System.Web.Script.Serialization;
using JXTPortal.Common;
using System.IO;
using SectionIO;
#endregion

public partial class SitesEdit : System.Web.UI.Page
{
   
    public ICacheFlusher CacheFlusher {get;set;}

    public SitesEdit()
    {
    }

    #region Properties

    protected string URLPOSTFIX = ConfigurationManager.AppSettings[PortalConstants.WebConfigurationKeys.WEBSITEURLPOSTFIX];

    private SitesService _sitesService;

    private SitesService SitesService
    {
        get
        {
            if (_sitesService == null)
            {
                _sitesService = new SitesService();
            }
            return _sitesService;
        }
    }

    private GlobalSettingsService _globalsettingsservice;

    public GlobalSettingsService GlobalSettingsService
    {
        get
        {
            if (_globalsettingsservice == null)
            {
                _globalsettingsservice = new GlobalSettingsService();
            }
            return _globalsettingsservice;
        }
    }

    private int SiteId
    {
        get
        {
            int _SiteId = 0;

            if (Int32.TryParse(Request.QueryString["SiteId"], out _SiteId))
            {
                _SiteId = Convert.ToInt32(Request.QueryString["SiteId"]);
            }

            return _SiteId;
        }
    }

    #endregion


    #region Page Event handlers

    protected void Page_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnEditSave);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            txtSiteURL.Attributes.Add("onkeyup", "javascript:SetStagingUrl(\"" + txtSiteURL.ClientID + "\", \"" + txtStagingSiteUrl.ClientID + "\")");

            if (SiteId > 0)
            {
                Load(SiteId);
            }
            else
            {
                Response.Redirect("Sites.aspx");
            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSites_Click(object sender, EventArgs e)
    {
        btnEditSave.Text = "Insert";
    }

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        JXTPortal.Entities.Sites site = new JXTPortal.Entities.Sites();

        ltlMessage.Text = string.Empty;

        try
        {
            // If Edit
            if (SiteId > 0)
            {
                site = SitesService.GetBySiteId(SiteId);
            }

            site.SiteName = txtSiteName.Text;
            site.SiteDescription = txtSiteDescription.Text;
            site.SiteUrl = txtSiteURL.Text.ToLower().Replace("http://", string.Empty).Replace("www.", string.Empty);
            site.MobileUrl = txtSiteURL.Text.ToLower().Replace("http://", string.Empty).Replace("www.", string.Empty);

            site.Live = chkLive.Checked;

            if (SiteId > 0)
            {
                // Update Record
                SitesService.Update(site);
            }
            else
            {
                // Insert Record
                SitesService.InsertDefault(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]), PortalConstants.DEFAULT_LANGUAGE_ID, site);

                //It's already wrapped on the command above in the stored proc
                //Add Default GlobalSetting for new added site
                //TODO : Remove AddDefaultGlobalSettings function
                //AddDefaultGlobalSettings(site.SiteId);
            }

            if ((flAdminSiteLogo.PostedFile != null) && flAdminSiteLogo.PostedFile.ContentLength > 0)
            {
                System.Drawing.Image originalImage = System.Drawing.Image.FromStream(flAdminSiteLogo.PostedFile.InputStream);

                FtpClient ftpclient = new FtpClient();
                string errormessage = string.Empty;
                string extension = Utils.GetImageExtension(originalImage);
                ftpclient.Host = ConfigurationManager.AppSettings["FTPFileManager"];
                ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                ftpclient.UploadFileFromStream(flAdminSiteLogo.PostedFile.InputStream, string.Format("{0}/{1}/Sites_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["SitesFolder"], site.SiteId, extension), out errormessage);

                if (string.IsNullOrWhiteSpace(errormessage))
                {
                    site.SiteAdminLogoUrl = string.Format("Sites_{0}.{1}", site.SiteId, extension);
                    SitesService.Update(site);
                }
            }

        }
        catch (Exception ex)
        {
            ltlMessage.Text = ex.Message;
        }
        finally
        {
            site.Dispose();
        }

        String siteUrl = string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Host);
        String path = "sites";
        String siteLogoName = string.Format("Site_{0}.png", site.SiteId);

        CacheFlusher.FlushImage(siteUrl, path, siteLogoName);

        if (String.IsNullOrEmpty(ltlMessage.Text))
            Response.Redirect("sites.aspx");      
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("sites.aspx");
    }

    #endregion

    #region "Methods"

    private void Load(int siteID)
    {
        if (SiteId > 0)
        {

            // If the Content Editor doesnt have permission to access the page.
            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor && SiteId != SessionData.Site.SiteId)
            {
                Response.Redirect("default.aspx");
            }

            using (JXTPortal.Entities.Sites site = SitesService.GetBySiteId(siteID))
            {
                if (site != null && site.SiteId > 0)
                {
                    pnlGlobalSettings.Visible = true;
                    txtSiteName.Text = site.SiteName;
                    txtSiteDescription.Text = site.SiteDescription;
                    txtSiteURL.Text = site.SiteUrl.ToLower();
                    //txtMobileUrl.Text = site.MobileUrl.ToLower();
                    txtStagingSiteUrl.Text = String.Format("{0}{1}", site.SiteUrl.ToLower(), URLPOSTFIX);
                    chkLive.Checked = site.Live.Value;

                    if (!string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                    {
                        imgSiteLogo.ImageUrl = string.Format("/media/{0}/{1}", ConfigurationManager.AppSettings["SitesFolder"], site.SiteAdminLogoUrl);
                    }
                    else
                    {
                        if (site.SiteAdminLogo != null)
                        {
                            imgSiteLogo.ImageUrl = String.Format("GetAdminLogo.aspx?SiteID={0}", siteID);
                        }
                    }
                }
            }
        }
    }

    protected void AddDefaultGlobalSettings(int newSiteID)
    {
        using (JXTPortal.Entities.GlobalSettings globalSetting = new JXTPortal.Entities.GlobalSettings())
        {
            globalSetting.SiteId = newSiteID;
            globalSetting.DefaultLanguageId = 1;
            globalSetting.PublicJobsSearch = false;
            globalSetting.PublicMembersSearch = false;
            globalSetting.PublicCompaniesSearch = false;
            globalSetting.PublicSponsoredAdverts = false;
            globalSetting.PrivateJobs = false;
            globalSetting.PrivateMembers = false;
            globalSetting.PrivateCompanies = false;
            globalSetting.LastModifiedBy = SessionData.AdminUser.AdminUserId;
            globalSetting.LastModified = DateTime.Now;
            globalSetting.ShowFaceBookButton = false;
            globalSetting.UseAdvertiserFilter = 1;
            globalSetting.ShowTwitterButton = false;
            globalSetting.ShowJobAlertButton = false;
            globalSetting.ShowLinkedInButton = false;

            GlobalSettingsService.Insert(globalSetting);
        }
    }

    #endregion

    protected void gridViewSites_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SelectSite")
        {
            SessionService.SetSite(SitesService.FindSite(Convert.ToInt32(e.CommandArgument), string.Empty));
            Response.Redirect("default.aspx");
        }
        else if (e.CommandName == "EditSite")
        {
            Load(Convert.ToInt32(e.CommandArgument));
        }
    }

    private byte[] getArray(HttpPostedFile f)
    {
        byte[] b = new byte[f.ContentLength];

        f.InputStream.Read(b, 0, f.ContentLength);

        return b;
    }

    protected void btnExportAsJSON_Click(object sender, EventArgs e)
    {
        byte[] file = new byte[0];
        int CampaignSequenceNumber = -99999;

        SiteLanguagesService sls = new SiteLanguagesService();
        TList<SiteLanguages> lsl = sls.GetBySiteId(SiteId);
        GlobalSettings gs = GlobalSettingsService.GetBySiteId(SiteId).FirstOrDefault();
        JXTPortal.Entities.Sites s = SitesService.GetBySiteId(SiteId);

        if (lsl.Count > 0)
        {
            int languageid = lsl[0].LanguageId;

            DynamicPagesService dps = new DynamicPagesService();
            TList<JXTPortal.Entities.DynamicPages> ldp = dps.GetHierarchy(s.SiteId, languageid, 0, null, true, false);

            SitemapContainer sitemap = new SitemapContainer();
            sitemap.site.siteid = s.SiteId;
            sitemap.site.sitename = s.SiteName;
            sitemap.site.siteurl = s.SiteUrl;

            string dynamicUrl = string.Empty;
            foreach (JXTPortal.Entities.DynamicPages dp in ldp)
            {
                if (dp.ParentDynamicPageId == 0 && dp.Sequence == CampaignSequenceNumber)
                { }
                else
                {
                    // Only if checked to display on Sitemap.
                    if (dp.OnSiteMap)
                    {
                        dynamicUrl = dps.GetDynamicPageFullUrl(s.SiteUrl, dp, gs.WwwRedirect, gs.EnableSsl).ToLower();

                        DynamicPageContainer dpc = new DynamicPageContainer();
                        dpc.loc = dynamicUrl;
                        dpc.priority = (dp.PageName != null && dp.PageName.ToLower().Equals("homepage") ? "1" : "0.7");
                        dpc.changefreq = "weekly";

                        sitemap.urls.Add(dpc);

                    }
                }
            }

            var json = new JavaScriptSerializer().Serialize(sitemap);
            file = Encoding.Unicode.GetBytes(json.ToString());
            Response.AddHeader("content-disposition", @"attachment;filename=""sitemap_" + s.SiteId.ToString() + @".json""");

            Response.OutputStream.Write(file, 0, file.Length);
            Response.ContentType = "application/json";
            Response.End();            
        }
    }
    
    protected void btnFlushJs_Click(object sender, EventArgs e)
    {
        FlushAssets(AssetClass.js);
    }

    protected void btnFlushCss_Click(object sender, EventArgs e)
    {
        FlushAssets(AssetClass.css);
    }

    protected void btnFlushAll_Click(object sender, EventArgs e)
    {
        FlushAssets(AssetClass.all);
    }

    private void FlushAssets(AssetClass asset)
    {  
        CacheFlusher.FlushAssetType(asset, Request.Url.Host, GetSiteFTPFolder());
    }

    private string GetSiteFTPFolder()
    {
        string ftpFolder = string.Empty;

        using (var siteGlobalSettings = GlobalSettingsService.GetBySiteId(SiteId))
        {
            var siteSettings = siteGlobalSettings.FirstOrDefault();
            
            if (siteSettings == null)
            {
                Response.Redirect("/admin/sites.aspx");
            }

            ftpFolder = siteSettings.GlobalFolder;

            //if doesn't exist prompt and save
            if (string.IsNullOrWhiteSpace(ftpFolder))
            {
                //Prompt and save
                string script = "alert(\"Global FTP Folder Field is Empty, please update before attempting to flush cache\"); location.href=\"/admin/globalsettingsedit.aspx\"";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "test", script, true);
            }
        }

        return ftpFolder;
    }

    internal class SitemapContainer
    {
        public SiteContainer site;
        public List<DynamicPageContainer> urls;

        public SitemapContainer()
        {
            site = new SiteContainer();
            urls = new List<DynamicPageContainer>();
        }
    }

    internal class SiteContainer
    {
        public int siteid { get; set; }
        public string sitename { get; set; }
        public string siteurl { get; set; }
    }

    internal class DynamicPageContainer
    {
        public string loc;
        public string priority;
        public string changefreq;
    }

    
}


