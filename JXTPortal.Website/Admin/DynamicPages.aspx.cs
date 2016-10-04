

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
using System.Text;
#endregion

public partial class DynamicPages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlLanguage.DataSource = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
            ddlLanguage.DataTextField = "SiteLanguageName";
            ddlLanguage.DataValueField = "LanguageID";
            ddlLanguage.DataBind();

            ddlLanguage.SelectedValue = SessionData.Site.DefaultLanguageId.ToString();

            SetDynamicPages();

        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetDynamicPages();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptToWork", @"
<script type='text/javascript'  src='/admin/scripts/jquery.treeview.js'></script>

<script type='text/javascript'>
$(function() {
    $('#browser').treeview({
        control: '#treecontrol'
    });

    $('#browser').bind('contextmenu', function(event) {
        if ($(event.target).is('li') || $(event.target).parents('li').length) {
            $('#browser').treeview({
                remove: $(event.target).parents('li').filter(':first')
            });
            return false;
        }
    });
})
</script>
", false);

    }

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

    private DynamicPagesService DynamicPagesService
    {
        get
        {
            if (_dynamicPagesService == null) _dynamicPagesService = new DynamicPagesService();
            return _dynamicPagesService;
        }
    }


    #region Methods

    protected void SetDynamicPages()
    {

        StringBuilder strDynamicPages = new StringBuilder();

        using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                    DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, Convert.ToInt32(ddlLanguage.SelectedValue), 0, null, false, true))
        {
            string strPageLink = string.Empty;

            // Order by Sequence
            DynamicPagesList.Sort("Sequence");

            using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList_1 = DynamicPagesList)
            {

                strDynamicPages.Append("<ul id='browser' class='filetree'>");

                for (int i = 0; i < DynamicPagesList.Count; i++)
                {
                    // Show the Parent Dynamic pages - excluding the Campaign Pages (campaign pages are identified by the sequence number)
                    if (DynamicPagesList[i].ParentDynamicPageId == 0 && DynamicPagesList[i].Sequence != JXTPortal.Website.CommonPage.CampaignSequenceNumber)
                    {

                        strPageLink = String.Format("<span class='folder'> {2}. <a href='DynamicPageRevisions.aspx?code={0}'>{1}</a> - ({0}) {3}</span>",
                                                        DynamicPagesList[i].PageName,
                                                        DynamicPagesList[i].PageTitle,
                                                        DynamicPagesList[i].DynamicPageId,
                                                        (string.IsNullOrEmpty(DynamicPagesList[i].CustomUrl)) ? DynamicPagesList[i].PageFriendlyName : DynamicPagesList[i].CustomUrl);

                        strDynamicPages.Append(String.Format(@"<li>{0}{1}</li>",
                                                            strPageLink,
                                                            GetFirstLevelDynamicPages(DynamicPagesList_1,
                                                            DynamicPagesList[i].DynamicPageId)));

                    }


                }
            }

            strDynamicPages.Append("</ul>");
        }

        ltlDynamicPages.Text = strDynamicPages.ToString();

    }

    private string GetFirstLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList, int parentDynamicPageID)
    {
        StringBuilder strDynamicPages = new StringBuilder();
        Boolean blnRecords = false;

        strDynamicPages.Append("<ul>");
        for (int i = 0; i < DynamicPagesList.Count; i++)
        {

            if (DynamicPagesList[i].ParentDynamicPageId == parentDynamicPageID)
            {
                blnRecords = true;

                strDynamicPages.Append(String.Format("<li><span class='file'> {3}. <a href='DynamicPageRevisions.aspx?code={0}'>{1}</a> - ({0}) {4}</span>{2}</li>",
                        DynamicPagesList[i].PageName,
                        DynamicPagesList[i].PageTitle,
                        GetSecondLevelDynamicPages(DynamicPagesList, DynamicPagesList[i].DynamicPageId),
                        DynamicPagesList[i].DynamicPageId,
                        (string.IsNullOrEmpty(DynamicPagesList[i].CustomUrl)) ? DynamicPagesList[i].PageFriendlyName : DynamicPagesList[i].CustomUrl));

            }
        }
        strDynamicPages.Append("</ul>");

        if (blnRecords)
        {
            return strDynamicPages.ToString();
        }

        return string.Empty;
    }

    private string GetSecondLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList,
                                                int parentDynamicPageID)
    {

        StringBuilder strDynamicPages = new StringBuilder();
        Boolean blnRecords = false;

        strDynamicPages.Append("<ul>");
        for (int i = 0; i < DynamicPagesList.Count; i++)
        {
            if (DynamicPagesList[i].ParentDynamicPageId == parentDynamicPageID)
            {
                blnRecords = true;
                strDynamicPages.Append(String.Format("<li><span class='file'> {2}. <a href='DynamicPageRevisions.aspx?code={0}'>{1}</a> - ({0}) {3}</span>{4}</li>",
                        DynamicPagesList[i].PageName,
                        DynamicPagesList[i].PageTitle,
                        DynamicPagesList[i].DynamicPageId,
                        (string.IsNullOrEmpty(DynamicPagesList[i].CustomUrl)) ? DynamicPagesList[i].PageFriendlyName : DynamicPagesList[i].CustomUrl,
                        GetSecondLevelDynamicPages(DynamicPagesList, DynamicPagesList[i].DynamicPageId)));
            }
        }
        strDynamicPages.Append("</ul>");

        if (blnRecords)
        {
            return strDynamicPages.ToString();
        }

        return string.Empty;
    }

    private string GetThirdLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList,
                                            int parentDynamicPageID)
    {

        StringBuilder strDynamicPages = new StringBuilder();
        Boolean blnRecords = false;

        strDynamicPages.Append("<ul>");
        for (int i = 0; i < DynamicPagesList.Count; i++)
        {
            if (DynamicPagesList[i].ParentDynamicPageId == parentDynamicPageID)
            {
                blnRecords = true;
                strDynamicPages.Append(String.Format("<li><span class='file'> {2}. <a href='DynamicPageRevisions.aspx?code={0}'>{1}</a> - ({0}) {3}</span></li>",
                        DynamicPagesList[i].PageName,
                        DynamicPagesList[i].PageTitle,
                        DynamicPagesList[i].DynamicPageId,
                        (string.IsNullOrEmpty(DynamicPagesList[i].CustomUrl)) ? DynamicPagesList[i].PageFriendlyName : DynamicPagesList[i].CustomUrl));
            }
        }
        strDynamicPages.Append("</ul>");

        if (blnRecords)
        {
            return strDynamicPages.ToString();
        }

        return string.Empty;
    }

    #endregion




}


