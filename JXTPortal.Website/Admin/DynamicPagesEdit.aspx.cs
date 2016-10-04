
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Website.Admin.UserControls;
using JXTPortal.Website;
using System.Collections.Generic;
#endregion

public partial class DynamicPagesEdit : System.Web.UI.Page
{
    #region "Properties"

    private SiteLanguagesService _siteLanguagesService;

    private SiteLanguagesService SiteLanguagesService
    {
        get
        {
            if (_siteLanguagesService == null) _siteLanguagesService = new SiteLanguagesService();
            return _siteLanguagesService;
        }
    }

    private DynamicPagesService _dynamicPagesService;

    public DynamicPagesService DynamicPagesService
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

    private RelatedDynamicPagesService _relatedDynamicPagesService;
    public RelatedDynamicPagesService RelatedDynamicPagesService
    {
        get
        {
            if (_relatedDynamicPagesService == null)
                _relatedDynamicPagesService = new RelatedDynamicPagesService();

            return _relatedDynamicPagesService;
        }
    }

    private FilesService _filesService;

    private FilesService FilesService
    {
        get
        {
            if (_filesService == null)
                _filesService = new FilesService();

            return _filesService;
        }
    }

    private DynamicPageFilesService _dynamicPageFilesService;

    private DynamicPageFilesService DynamicPageFilesService
    {
        get
        {
            if (_dynamicPageFilesService == null)
                _dynamicPageFilesService = new DynamicPageFilesService();

            return _dynamicPageFilesService;
        }
    }

    private DynamicpagesCustomWidgetService _DynamicpagesCustomWidgetService;

    private DynamicpagesCustomWidgetService DynamicpagesCustomWidgetService
    {
        get
        {
            if (_DynamicpagesCustomWidgetService == null)
                _DynamicpagesCustomWidgetService = new DynamicpagesCustomWidgetService();

            return _DynamicpagesCustomWidgetService;
        }
    }

    private CustomWidgetService _CustomWidgetService;

    private CustomWidgetService CustomWidgetService
    {
        get
        {
            if (_CustomWidgetService == null)
                _CustomWidgetService = new CustomWidgetService();

            return _CustomWidgetService;
        }
    }

    private GlobalSettingsService _GlobalSettingsService;

    private GlobalSettingsService GlobalSettingsService
    {
        get
        {
            if (_GlobalSettingsService == null)
                _GlobalSettingsService = new GlobalSettingsService();

            return _GlobalSettingsService;
        }
    }

    public List<int> _oldSelectedCSSFiles
    {
        get
        {
            if (ViewState["OldSelectedCSSFiles"] != null)
                return (List<int>)ViewState["OldSelectedCSSFiles"];

            return null;
        }
        set { ViewState["OldSelectedCSSFiles"] = value; }
    }

    public List<int> _oldSelectedJSFiles
    {
        get
        {
            if (ViewState["OldSelectedJSFiles"] != null)
                return (List<int>)ViewState["OldSelectedJSFiles"];

            return null;
        }
        set { ViewState["OldSelectedJSFiles"] = value; }
    }

    public string StrPageName
    {
        get
        {
            string strPageName = "";

            if (!String.IsNullOrEmpty(CommonPage.PageName))
            {
                string[] strPageNames = CommonPage.PageName.Split(new char[] { '/' });
                strPageName = strPageNames[strPageNames.Length - 1];
            }

            return strPageName;
        }
    }


    #endregion

    #region Page Events


    private string GetSHA1String(string text)
    {
        var UE = new UTF8Encoding();// ASCIIEncoding(); // UnicodeEncoding();
        var message = UE.GetBytes(text);

        var hashString = new SHA1Managed();
        var hex = string.Empty;

        var hashValue = hashString.ComputeHash(message);
        foreach (byte b in hashValue)
        {
            hex += String.Format("{0:x2}", b);
        }

        return hex;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("DynamicPageRevisions.aspx");

        CustomPaymentService s = new CustomPaymentService();
        RelatedDynamicPagesService s2 = new RelatedDynamicPagesService();


        if (!Page.IsPostBack)
        {
            pnlCSSJS.Visible = (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser);
            LoadSiteLanguages();
            LoadDynamicPage();
            LoadCSSFiles();
            LoadJavascriptFiles();
            // LoadRelatedDynamicPages();
            LoadJavascript();
        }
    }

    #endregion

    #region "Methods"

    private void LoadDynamicPage()
    {
        ltSiteUrl.Text = string.Format("http://www.{0}/", SessionData.Site.SiteUrl);
        if (!String.IsNullOrEmpty(CommonPage.PageName))
        {
            using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, CommonPage.PageName))
            {
                foreach (JXTPortal.Entities.DynamicPages dynamicPage in dynamicPages)
                {
                    if (dynamicPage.LanguageId == SessionData.Site.DefaultLanguageId)
                    {

                        txtPageName.Text = dynamicPage.PageName;
                        chkValid.Checked = dynamicPage.Valid;

                        string[] strPageNames2 = dynamicPage.PageFriendlyName.Split(new char[] { '/' });
                        string strPageName2 = strPageNames2[strPageNames2.Length - 1];
                        txtPageFriendlyName.Text = strPageName2;
                        tbCustomUrl.Text = dynamicPage.CustomUrl;
                        litViewPage.Text = DynamicPagesService.GetDynamicPageLink(dynamicPage, string.Empty);
                        txtHyperlink.Text = dynamicPage.HyperLink;
                        cbOpenNewWindow.Checked = dynamicPage.OpenInNewWindow;
                        txtSequence.Text = dynamicPage.Sequence.ToString();
                        cbOnTopNav.Checked = dynamicPage.OnTopNav;
                        cbOnLeftNav.Checked = dynamicPage.OnLeftNav;
                        cbOnBottomNav.Checked = dynamicPage.OnBottomNav;
                        cbOnSiteMap.Checked = dynamicPage.OnSiteMap;
                        chkSecured.Checked = dynamicPage.Secured;
                        chkBreadcrumb.Checked = dynamicPage.GenerateBreadcrumb;

                        // Disable Page Code
                        txtPageName.Enabled = false;
                    }
                }
            }
        }
        else
        {

            // For new dynamic page .. check the below by default.
            chkValid.Checked = true;
            cbOnTopNav.Checked = true;
            cbOnSiteMap.Checked = true;
        
        }
    }

    private void LoadSiteLanguages()
    {
        rptDynamicPages.DataSource = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
        rptDynamicPages.DataBind();
    }

    private void LoadCSSFiles()
    {
        //get by siteid and filetypeid
        siteRepeaterCSSFile.DataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, String.Empty, Convert.ToInt32(PortalEnums.Files.FileTypes.CSS));
        siteRepeaterCSSFile.DataTextField = "FileName";
        siteRepeaterCSSFile.DataValueField = "FileId";
        siteRepeaterCSSFile.HeaderName = "Please Select CSS File";

        siteRepeaterCSSFile.SiteDataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, txtPageName.Text,
                                                                                        Convert.ToInt32(PortalEnums.Files.FileTypes.CSS));
        siteRepeaterCSSFile.SiteDataValueField = "FileId";
        siteRepeaterCSSFile.Bind();

        _oldSelectedCSSFiles = siteRepeaterCSSFile.SelectedValues;
    }

    private void LoadJavascriptFiles()
    {
        //get by siteid and filetypeid
        siteRepeaterJavascriptFile.DataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, String.Empty,
                                                                                            Convert.ToInt32(PortalEnums.Files.FileTypes.Javascript));
        siteRepeaterJavascriptFile.DataTextField = "FileName";
        siteRepeaterJavascriptFile.DataValueField = "FileId";
        siteRepeaterJavascriptFile.HeaderName = "Please Select Javascript File";

        siteRepeaterJavascriptFile.SiteDataSource = FilesService.GetBySiteIDPageNameFileTypeID(SessionData.Site.SiteId, txtPageName.Text,
                                                                                                Convert.ToInt32(PortalEnums.Files.FileTypes.Javascript));
        siteRepeaterJavascriptFile.SiteDataValueField = "FileId";
        siteRepeaterJavascriptFile.Bind();

        _oldSelectedJSFiles = siteRepeaterJavascriptFile.SelectedValues;
    }


    /// <summary>
    /// Load Javascript to Fix the bug Ajax-Javascript
    /// </summary>
    private void LoadJavascript()
    {
        int index = 1;
        int defaultid = 0;
        StringBuilder relateddedaultpagelist = new StringBuilder();
        StringBuilder relatedselectedpagelist = new StringBuilder();

        using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, SessionData.Site.DefaultLanguageId, 0, null, true, true))
        {
            foreach (JXTPortal.Entities.DynamicPages dynamicpage in dynamicpages)
            {
                if (dynamicpage.ParentDynamicPageId != 0 && dynamicpage.PageName != txtPageName.Text)
                {
                    int lvlcount = dynamicpage.PageFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;

                    for (int i = 0; i < lvlcount; i++)
                    {
                        dynamicpage.PageTitle = string.Format(" - {0}", dynamicpage.PageTitle);
                    }
                }
                if (dynamicpage.Valid && dynamicpage.PageName != txtPageName.Text)
                {

                    relateddedaultpagelist.AppendLine("{id:" + dynamicpage.DynamicPageId.ToString() + ",text:\"" + dynamicpage.PageTitle + "\"},");
                }
            }

        }

        for (int i = 0; i < rptDynamicPages.Items.Count; i++)
        {
            if (((DynamicPagesFieldsList)((RepeaterItem)rptDynamicPages.Items[i]).FindControl("ucDynamicPage")).LanguageID == SessionData.Site.DefaultLanguageId)
            {
                defaultid = ((DynamicPagesFieldsList)((RepeaterItem)rptDynamicPages.Items[i]).FindControl("ucDynamicPage")).DynamicPageID;
                index = i + 1;
                break;
            }
        }

        if (defaultid > 0)
        {
            DataSet ds = RelatedDynamicPagesService.CustomGetByDynamicPageID(defaultid);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                relatedselectedpagelist.Append(dr["RelatedDynamicPageID"].ToString() + ",");
            }
        }


        string relatedscript = @" var ddlRelatedDynamicPages = $('#ddlRelatedDynamicPages');
                                $(ddlRelatedDynamicPages).val([" + relatedselectedpagelist.ToString().TrimEnd(new char[] { ',' });
        relatedscript += @"]).select2({
                                data:[
                                  " + relateddedaultpagelist.ToString().TrimEnd(new char[] { ',', '\r', '\n' });
        relatedscript += @"],
                                placeholder: 'Select a Related Dynamic Page',
                                multiple: true,
                                width: ""500px""
                               
                });
                $(ddlRelatedDynamicPages).change(function() {
                                var ids = $(ddlRelatedDynamicPages).val();
                                var selections = ( JSON.stringify($(ddlRelatedDynamicPages).select2('data')) );
                                console.log('Selected options: ' + selections);
                });";


        StringBuilder columndefaultlist = new StringBuilder();
        StringBuilder leftcolumnselectedlist = new StringBuilder();
        StringBuilder rightcolumnselectedlist = new StringBuilder();

        TList<JXTPortal.Entities.CustomWidget> customwidgets = CustomWidgetService.GetBySiteId(SessionData.Site.SiteId);
        if (customwidgets.Count > 0)
        {
            foreach (JXTPortal.Entities.CustomWidget customwidget in customwidgets)
            {
                if (customwidget.Active)
                {
                    columndefaultlist.AppendLine("{id:" + customwidget.CustomWidgetId.ToString() + ",text:\"" + customwidget.CustomWidgetName + "\"},");
                }
            }
        }
        if (defaultid > 0)
        {
            DataSet ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(defaultid, (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    leftcolumnselectedlist.Append(dr["CustomWidgetID"].ToString() + ",");
                }
            }

            ds = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(defaultid, (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    rightcolumnselectedlist.Append(dr["CustomWidgetID"].ToString() + ",");
                }
            }
        }

        string leftcolumnscript = @" var ddlLeftColumn = $('#ddlLeftColumn');
                                $(ddlLeftColumn).val([" + leftcolumnselectedlist.ToString().TrimEnd(new char[] { ',' });
        leftcolumnscript += @"]).select2({
                                data:[
                                  " + columndefaultlist.ToString().TrimEnd(new char[] { ',', '\r', '\n' });
        leftcolumnscript += @"],
                                placeholder: 'Select a Custom Widget',
                                multiple: true,
                                width: ""500px""
                               
                });
                $(ddlLeftColumn).change(function() {
                                var ids = $(ddlLeftColumn).val();
                                var selections = ( JSON.stringify($(ddlLeftColumn).select2('data')) );
                                console.log('Selected options: ' + selections);
                });";

        string rightcolumnscript = @" var ddlrightColumn = $('#ddlRightColumn');
                                $(ddlrightColumn).val([" + rightcolumnselectedlist.ToString().TrimEnd(new char[] { ',' });
        rightcolumnscript += @"]).select2({
                                data:[
                                  " + columndefaultlist.ToString().TrimEnd(new char[] { ',', '\r', '\n' });
        rightcolumnscript += @"],
                                placeholder: 'Select a Custom Widget',
                                multiple: true,
                                width: ""500px""
                               
                });
                $(ddlrightColumn).change(function() {
                                var ids = $(ddlrightColumn).val();
                                var selections = ( JSON.stringify($(ddlrightColumn).select2('data')) );
                                console.log('Selected options: ' + selections);
                });";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptToWork", @"
                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                            <script type='text/javascript'>
                                $().ready(function() {
                                    $('#coda-slider-1').codaSlider({
                                        dynamicArrows: false,
                                        autoHeight: true,
                                        firstPanelToLoad: " + index + @"
                                    });

                                    " + relatedscript + @"
                                    " + leftcolumnscript + @"
                                    " + rightcolumnscript + @"
 
                                });

                            </script>

                            ", false);
    }


    #endregion

    #region Repeater DataBinds

    protected void rptDynamicPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DynamicPagesFieldsList ucDynamicPage = (DynamicPagesFieldsList)e.Item.FindControl("ucDynamicPage");
            Literal litLanguageName = (Literal)e.Item.FindControl("litLanguageName");

            JXTPortal.Entities.SiteLanguages siteLanguage = (JXTPortal.Entities.SiteLanguages)e.Item.DataItem;
            litLanguageName.Text = siteLanguage.SiteLanguageName;
            ucDynamicPage.LanguageID = siteLanguage.LanguageId;

            // Load the Dynamic Page of the Language 
            ucDynamicPage.LoadListAndDynamicPage();
        }

        if (e.Item.ItemType == ListItemType.Footer)
        {
            //SystemPage MUST not be deleted
            Button btnDelete = (Button)e.Item.FindControl("btnDelete");

            if (CommonPage.PageName.StartsWith("SystemPage", StringComparison.CurrentCultureIgnoreCase))
            {
                tbCustomUrl.Enabled = false;
                btnDelete.Visible = false;
            }
        }
    }

    protected void rptDynamicPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        bool valid = true;


        if (e.CommandName == "Save" || e.CommandName == "Apply")
        {
            JXTPortal.Entities.DynamicPages dynamicPage = new JXTPortal.Entities.DynamicPages();

            if (!string.IsNullOrEmpty(hfCode.Value))
            {
                TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, hfCode.Value);
                if (dynamicPages.Count > 0)
                {
                    dynamicPage = dynamicPages[0];
                }
            }

            dynamicPage.PageName = txtPageName.Text.Trim();
            dynamicPage.Valid = chkValid.Checked;
            dynamicPage.PageFriendlyName = txtPageFriendlyName.Text.Trim();
            dynamicPage.CustomUrl = tbCustomUrl.Text.Trim().ToLower();
            dynamicPage.HyperLink = txtHyperlink.Text;
            dynamicPage.OpenInNewWindow = cbOpenNewWindow.Checked;
            dynamicPage.Sequence = Convert.ToInt32(txtSequence.Text);
            dynamicPage.OnTopNav = cbOnTopNav.Checked;
            dynamicPage.OnLeftNav = cbOnLeftNav.Checked;
            dynamicPage.OnBottomNav = cbOnBottomNav.Checked;
            dynamicPage.OnSiteMap = cbOnSiteMap.Checked;
            dynamicPage.Secured = chkSecured.Checked;
            dynamicPage.GenerateBreadcrumb = chkBreadcrumb.Checked;

            StringBuilder relateddedaultpagelist = new StringBuilder();

            using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, SessionData.Site.DefaultLanguageId, 0, null, true, true))
            {
                foreach (JXTPortal.Entities.DynamicPages dynamicpage in dynamicpages)
                {
                    if (dynamicpage.ParentDynamicPageId != 0 && dynamicpage.PageName != txtPageName.Text)
                    {
                        int lvlcount = dynamicpage.PageFriendlyName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;

                        for (int i = 0; i < lvlcount; i++)
                        {
                            dynamicpage.PageTitle = string.Format(" - {0}", dynamicpage.PageTitle);
                        }
                    }
                    if (dynamicpage.Valid && dynamicpage.PageName != txtPageName.Text)
                    {

                        relateddedaultpagelist.AppendLine("{id:" + dynamicpage.DynamicPageId.ToString() + ",text:\"" + dynamicpage.PageTitle + "\"},");
                    }
                }

            }

            StringBuilder columndefaultlist = new StringBuilder();

            TList<JXTPortal.Entities.CustomWidget> customwidgets = CustomWidgetService.GetBySiteId(SessionData.Site.SiteId);
            if (customwidgets.Count > 0)
            {
                foreach (JXTPortal.Entities.CustomWidget customwidget in customwidgets)
                {
                    if (customwidget.Active)
                    {
                        columndefaultlist.AppendLine("{id:" + customwidget.CustomWidgetId.ToString() + ",text:\"" + customwidget.CustomWidgetName + "\"},");
                    }
                }
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "AssignRelatedPages", @"
                                            <script type='text/javascript'>
                                               $('#ddlRelatedDynamicPages').val([" + ddlRelatedDynamicPages.Value + @"]).select2({ 
                                                data:[
                                                " + relateddedaultpagelist.ToString().TrimEnd(new char[] { ',' }) + @"],
                                                placeholder: 'Select a Related Dynamic Page', width: '500px', multiple: true});
                                               $(ddlRelatedDynamicPages).change(function() {
                                                var ids = $(ddlRelatedDynamicPages).val();
                                                var selections = ( JSON.stringify($(ddlRelatedDynamicPages).select2('data')) );
                                                console.log('Selected options: ' + selections);
                                                });

                                               $('#ddlLeftColumn').val([" + ddlLeftColumn.Value + @"]).select2({ 
                                                data:[
                                                " + columndefaultlist.ToString().TrimEnd(new char[] { ',' }) + @"],
                                                placeholder: 'Select a Related Custom Widget', width: '500px', multiple: true});
                                               $(ddlLeftColumn).change(function() {
                                                var ids = $(ddlLeftColumn).val();
                                                var selections = ( JSON.stringify($(ddlLeftColumn).select2('data')) );
                                                console.log('Selected options: ' + selections);
                                                });

                                               $('#ddlRightColumn').val([" + ddlRightColumn.Value + @"]).select2({ 
                                                data:[
                                                " + columndefaultlist.ToString().TrimEnd(new char[] { ',' }) + @"],
                                                placeholder: 'Select a Related Custom Widget', width: '500px', multiple: true});
                                               $(ddlRightColumn).change(function() {
                                                var ids = $(ddlRightColumn).val();
                                                var selections = ( JSON.stringify($(ddlRightColumn).select2('data')) );
                                                console.log('Selected options: ' + selections);
                                                });
                                            </script>

                                            ", false);

            try
            {
                int isvalidno = -1;

                for (int i = 0; i < rptDynamicPages.Items.Count; i++)
                {
                    RepeaterItem item = rptDynamicPages.Items[i];
                    DynamicPagesFieldsList ucDynamicPage = (DynamicPagesFieldsList)item.FindControl("ucDynamicPage");

                    if (!ucDynamicPage.Validate())
                    {
                        if (isvalidno == -1)
                        {
                            isvalidno = i;
                        }
                    }
                }

                if (isvalidno != -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                                            <script type='text/javascript'>
                                                     $('#coda-slider-1').codaSlider({
                                                        dynamicArrows: false,
                                                        autoHeight: true
                                                    });

                                                   $('.tab" + (isvalidno + 1).ToString() + @" a').click();

                                            </script>

                                            ", false);
                    return;
                }

                for (int i = 0; i < rptDynamicPages.Items.Count; i++)
                {
                    RepeaterItem item = rptDynamicPages.Items[i];
                    DynamicPagesFieldsList ucDynamicPage = (DynamicPagesFieldsList)item.FindControl("ucDynamicPage");

                    ucDynamicPage.DynamicPageEntity = dynamicPage;

                    // Saving Related Dynamic Pages
                    string selecteddynamicpages = hfRelatedDynamicPages.Value;


                    // Display error message if dynamic pages saving has error
                    string errormessage = string.Empty;
                    if (!ucDynamicPage.Save(out errormessage))
                    {
                        if (valid)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "test", @"
                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
                                            <script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>
                                            <script type='text/javascript'>
                                                 $('#coda-slider-1').codaSlider({
                                                        dynamicArrows: false,
                                                        autoHeight: true
                                                    });

                                                   $('.tab" + (i + 1).ToString() + @" a').click();

                                            </script>

                                            ", false);
                        }
                        ltlMessage.Text = errormessage;
                        valid = false;
                        break;
                    }
                    else
                    {
                        int dpid = ucDynamicPage.DynamicPageID;
                        int langid = ucDynamicPage.LanguageID;

                        RelatedDynamicPagesService.CustomModify(dpid, ddlRelatedDynamicPages.Value);


                        string[] splits = ddlLeftColumn.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        DataSet leftcolumnlist = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dpid, (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                        if (leftcolumnlist != null && leftcolumnlist.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in leftcolumnlist.Tables[0].Rows)
                            {
                                bool found = false;
                                string customwidgetid = dr["CustomWidgetID"].ToString();
                                foreach (string s in splits)
                                {
                                    if (s == customwidgetid)
                                    {
                                        found = true;
                                        break;
                                    }
                                }

                                if (!found)
                                {
                                    DynamicpagesCustomWidgetService.CustomDelete(dpid, Convert.ToInt32(customwidgetid), (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                                }
                            }
                        }


                        for (int index = 0; index < splits.Length; index++)
                        {
                            TList<DynamicpagesCustomWidget> dpcwlist = DynamicpagesCustomWidgetService.CustomSelect(dpid, Convert.ToInt32(splits[index]), (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column);
                            if (dpcwlist.Count > 0)
                            {
                                DynamicpagesCustomWidget dpcw = dpcwlist[0];
                                dpcw.Sequence = index + 1;
                                DynamicpagesCustomWidgetService.Update(dpcw);
                            }
                            else
                            {
                                DynamicpagesCustomWidget dpcw = new DynamicpagesCustomWidget();
                                dpcw.DynamicPageId = dpid;
                                dpcw.CustomWidgetId = Convert.ToInt32(splits[index]);
                                dpcw.Position = (int)PortalEnums.DynamicPage.WidgetPosition.Left_Column;
                                dpcw.Sequence = index + 1;
                                DynamicpagesCustomWidgetService.Insert(dpcw);
                            }
                        }

                        splits = ddlRightColumn.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        DataSet rightcolumnlist = DynamicpagesCustomWidgetService.CustomGetByDynamicPageIDPosition(dpid, (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                        if (rightcolumnlist != null && rightcolumnlist.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in rightcolumnlist.Tables[0].Rows)
                            {
                                bool found = false;
                                string customwidgetid = dr["CustomWidgetID"].ToString();
                                foreach (string s in splits)
                                {
                                    if (s == customwidgetid)
                                    {
                                        found = true;
                                        break;
                                    }
                                }

                                if (!found)
                                {
                                    DynamicpagesCustomWidgetService.CustomDelete(dpid, Convert.ToInt32(customwidgetid), (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                                }
                            }
                        }

                        for (int index = 0; index < splits.Length; index++)
                        {
                            TList<DynamicpagesCustomWidget> dpcwlist = DynamicpagesCustomWidgetService.CustomSelect(dpid, Convert.ToInt32(splits[index]), (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column);
                            if (dpcwlist.Count > 0)
                            {
                                DynamicpagesCustomWidget dpcw = dpcwlist[0];
                                dpcw.Sequence = index + 1;
                                DynamicpagesCustomWidgetService.Update(dpcw);
                            }
                            else
                            {
                                DynamicpagesCustomWidget dpcw = new DynamicpagesCustomWidget();
                                dpcw.DynamicPageId = dpid;
                                dpcw.CustomWidgetId = Convert.ToInt32(splits[index]);
                                dpcw.Position = (int)PortalEnums.DynamicPage.WidgetPosition.Right_Column;
                                dpcw.Sequence = index + 1;
                                DynamicpagesCustomWidgetService.Insert(dpcw);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message + "<br>" + ex.StackTrace;
                return;
            }

            if (valid)
            {
                //TODO:
                //save css?or js?
                //the control return List<int>
                List<int> dynamicCSSList = siteRepeaterCSSFile.SelectedValues;
                List<int> dynamicJavascriptList = siteRepeaterJavascriptFile.SelectedValues;

                int? _tempDynamicID = 0;

                // Save CSS
                if (pnlCSSJS.Visible && (!CommonFunction.CompareLists(_oldSelectedCSSFiles, dynamicCSSList) || (!CommonFunction.CompareLists(_oldSelectedJSFiles, dynamicJavascriptList))))
                {
                    string pName = CommonPage.PageName;
                    if (string.IsNullOrEmpty(pName)) pName = hfCode.Value;

                    if (!String.IsNullOrEmpty(pName))
                    {
                        using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, pName))
                        {
                            if (dynamicPages.Count > 0)
                            {
                                // only for one language
                                foreach (JXTPortal.Entities.DynamicPages dp in dynamicPages)
                                {
                                    using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                                        DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, dp.LanguageId, dp.DynamicPageId, null, null, true))
                                    {

                                        if (DynamicPagesList.Count > 0)
                                        {
                                            foreach (JXTPortal.Entities.DynamicPages _DynamicPagesList in DynamicPagesList)
                                            {
                                                // Delete All CSS file links for the Dynamic Page

                                                //if (_DynamicPagesList.DynamicPageId != dp.DynamicPageId)
                                                {

                                                    if (!CommonFunction.CompareLists(_oldSelectedCSSFiles, dynamicCSSList))
                                                    {
                                                        DynamicPageFilesService.DeleteBySiteIDPageName(SessionData.Site.SiteId, _DynamicPagesList.PageName, Convert.ToInt32(PortalEnums.Files.FileTypes.CSS));

                                                        foreach (int fileID in dynamicCSSList)
                                                        {
                                                            DynamicPageFilesService.Insert(SessionData.Site.SiteId, _DynamicPagesList.PageName, fileID, ref _tempDynamicID);
                                                        }
                                                    }

                                                    // Save Javascript
                                                    if (!CommonFunction.CompareLists(_oldSelectedJSFiles, dynamicJavascriptList))
                                                    {
                                                        DynamicPageFilesService.DeleteBySiteIDPageName(SessionData.Site.SiteId, _DynamicPagesList.PageName, Convert.ToInt32(PortalEnums.Files.FileTypes.Javascript));

                                                        foreach (int fileID in dynamicJavascriptList)
                                                        {
                                                            DynamicPageFilesService.Insert(SessionData.Site.SiteId, _DynamicPagesList.PageName, fileID, ref _tempDynamicID);
                                                        }
                                                    }
                                                }

                                            }

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                hfCode.Value = txtPageName.Text;

                ltlMessage.Text = "Dynamic page has been saved";

                if (e.CommandName == "Save")
                    Response.Redirect("dynamicpages.aspx");



            }
        }
        else if (e.CommandName == "Delete")
        {
            // Delete Dynamic Pages for Site
            string pName = CommonPage.PageName;
            if (string.IsNullOrEmpty(pName)) pName = hfCode.Value;

            if (!String.IsNullOrEmpty(pName))
            {
                using (TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, StrPageName))
                {
                    if (dynamicpages.Count > 0)
                    {

                        for (int i = 0; i < dynamicpages.Count; i++)
                        {
                            TList<GlobalSettings> gs =  GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
                            if (gs.Count > 0 && gs[0].DefaultDynamicPageId == dynamicpages[i].DynamicPageId)
                            {
                                dynamicpages[i].DynamicPageId = 0;
                                DynamicPagesService.Update(dynamicpages[i]);
                            }

                            TList<DynamicpagesCustomWidget> customwidgets = DynamicpagesCustomWidgetService.GetByDynamicPageId(dynamicpages[i].DynamicPageId);
                            foreach (DynamicpagesCustomWidget customwidget in customwidgets)
                            {
                                DynamicpagesCustomWidgetService.Delete(customwidget);
                            }

                            TList<RelatedDynamicPages> relatedpages = RelatedDynamicPagesService.GetByDynamicPageId(dynamicpages[i].DynamicPageId);
                            foreach (RelatedDynamicPages relatedpage in relatedpages)
                            {
                                RelatedDynamicPagesService.Delete(relatedpage);
                            }

                            relatedpages = RelatedDynamicPagesService.GetByRelatedDynamicPageId(dynamicpages[i].DynamicPageId);
                            foreach (RelatedDynamicPages relatedpage in relatedpages)
                            {
                                RelatedDynamicPagesService.Delete(relatedpage);
                            }
 
                            DynamicPagesService.Delete(dynamicpages[i].DynamicPageId);

                        }

                        Response.Redirect("dynamicpages.aspx");
                    }
                }
            }
        }

        //if (valid)
        //    
    }

    #endregion

    protected void CusVal_PageName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        char[] invalidchars = new char[] { '+', '/', '?', '%', '#', '&', '\'' };

        foreach (char c in invalidchars)
        {
            if (txtPageName.Text.Contains(c.ToString()))
            {
                CusVal_PageName.ErrorMessage = "Unique Page Code contains invalid character(s). (+ / ? % # & ')";

                args.IsValid = false;
                return;
            }
        }

        string sOut = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(txtPageName.Text));
        if (sOut != txtPageName.Text)
        {
            CusVal_PageName.ErrorMessage = "Unique Page Code contains non-english character(s).";

            args.IsValid = false;
            return;
        }


        if (string.IsNullOrEmpty(StrPageName) && string.IsNullOrEmpty(hfCode.Value))
        {
            TList<JXTPortal.Entities.DynamicPages> dynamicpages = DynamicPagesService.GetBySiteIdPageName(SessionData.Site.SiteId, txtPageName.Text.Trim());

            if (dynamicpages.Count > 0)
            {
                CusVal_PageName.ErrorMessage = "Unique Page Code already exists.";

                args.IsValid = false;
                return;
            }
        }
    }

    protected void CusVal_tbCustomUrl_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string customurl = tbCustomUrl.Text;

        if (customurl.StartsWith("/"))
        {
            CusVal_tbCustomUrl.ErrorMessage = "Custom URL cannot start with /";
            args.IsValid = false;
            return;
        }

        char[] invalidchars = new char[] { '#', '%', '&', '*', '\'', '\\', ':', '+', '<', '>', '[', ']', '^', '`', '{', '}', '|', '?', ',', '.' };
        foreach (char c in invalidchars)
        {
            if (tbCustomUrl.Text.Contains(c.ToString()))
            {
                CusVal_tbCustomUrl.ErrorMessage = "Custom URL cannot contain any of these characters: # % & * ' \\ : + < > [ ] ^ ` { } | ? , .";
                args.IsValid = false;
                return;
            }
        }


        if (!string.IsNullOrWhiteSpace(StrPageName))
        {
            TList<JXTPortal.Entities.DynamicPages> pages = DynamicPagesService.GetBySiteId(SessionData.Site.SiteId);

            foreach (JXTPortal.Entities.DynamicPages page in pages)
            {
                if (page.PageName != StrPageName)
                {
                    if (page.CustomUrl == tbCustomUrl.Text)
                    {
                        CusVal_tbCustomUrl.ErrorMessage = "Custom URL already exists.";
                        args.IsValid = false;
                        break;
                    }
                }
            }
        }


    }

    protected void CusVal_txtHyperLink_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(tbCustomUrl.Text))
        {
            CusVal_txtHyperLink.ErrorMessage = "You cannot have Overwrite URL .";
            args.IsValid = false;
        }
    }
}


