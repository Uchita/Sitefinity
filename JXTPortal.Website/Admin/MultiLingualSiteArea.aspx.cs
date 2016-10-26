using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;


namespace JXTPortal.Website.Admin
{
    public partial class MultiLingualSiteArea : System.Web.UI.Page
    {
        #region Declarations

        private SiteLanguagesService _sitelanguagesservice;
        private SiteLocationService _sitelocationservice;
        private SiteCountriesService _sitecountriesservice;
        private SiteAreaService _siteareaservice;
        private const string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";

        #endregion

        #region Properties

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

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaservice == null)
                {
                    _siteareaservice = new SiteAreaService();
                }
                return _siteareaservice;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationservice == null)
                {
                    _sitelocationservice = new SiteLocationService();
                }
                return _sitelocationservice;
            }
        }

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesservice == null)
                {
                    _sitecountriesservice = new SiteCountriesService();
                }
                return _sitecountriesservice;
            }
        }

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadLanguage();
                LoadCountry();
                LoadLocation();
            }
        }

        #endregion

        #region Methods

        private void LoadLanguage()
        {
            using (TList<JXTPortal.Entities.SiteLanguages> languages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                // ToDo - Add in Web.config the default value of LanguageID = 1 and Filter with LanguageID = from Web.config
                // ToDo - Change in all the Admin Multilingual pages
                languages.Filter = "LanguageID <> " + SessionData.Site.DefaultLanguageId.ToString();
                ddlLanguage.DataSource = languages;
                ddlLanguage.DataBind();
                ddlLanguage.Items.Insert(0, new ListItem(" Please Choose ...", "0"));

                phArea.Visible = (ddlLanguage.Items.Count > 0);
                ltlMessage.Text = (ddlLanguage.Items.Count > 0) ? "" : "This site is not multilingual.";
            }
        }

        private void LoadCountry()
        {
            using (TList<JXTPortal.Entities.SiteCountries> countries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
            {
                ddlCountry.DataSource = countries;
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
            }
        }

        private void LoadLocation()
        {
            ddlLocation.Items.Clear();

            if (ddlCountry.SelectedValue != "0")
            {
                using (TList<JXTPortal.Entities.SiteLocation> locations = SiteLocationService.GetByCountryID(SessionData.Site.SiteId, Convert.ToInt32(ddlCountry.SelectedValue)))
                {
                    ddlLocation.DataSource = locations;
                    ddlLocation.DataBind();
                    ddlLocation.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
                }
            }
            else
            {
                ddlLocation.DataSource = null;
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem(" Please Choose a Country...", "0"));
            }
        }

        private void LoadArea()
        {
            if (ddlLanguage.SelectedValue != "0" && ddlCountry.SelectedValue != "0" && ddlLocation.SelectedValue != "0")
            {
                TList<Entities.SiteArea> areas = SiteAreaService.GetByLocationID(SessionData.Site.SiteId, Convert.ToInt32(ddlLocation.SelectedValue));
                if (areas.Count > 0)
                {
                    rptArea.DataSource = areas;
                    rptArea.DataBind();
                    btnEditSave.Visible = true;
                }
                else
                {
                    rptArea.DataSource = null;
                    rptArea.DataBind();
                    btnEditSave.Visible = false;
                }
            }
            else
            {
                rptArea.DataSource = null;
                rptArea.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadAreaXML()
        {
            if (ddlLanguage.SelectedValue != "0" && ddlCountry.SelectedValue != "0" && ddlLocation.SelectedValue != "0")
            {

                foreach (Entities.SiteArea objArea in SiteAreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptArea.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfAreaId = repeateritem.FindControl("hfAreaId") as HiddenField;

                        if (hfAreaId.Value == objArea.AreaId.ToString())
                        {
                            tbMultiLingual.Text = objArea.SiteAreaName;
                            break;
                        }
                    }
                }

            }
        }

        private void WriteAreaXML()
        {
            string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_SITEAREA_FILENAME, ddlLocation.SelectedValue, SessionData.Site.SiteId);
            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptArea.Items)
            {
                TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                HiddenField hfAreaId = repeateritem.FindControl("hfAreaId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfAreaId.Value.ToString());
                writer.WriteElementString("name", tbMultiLingual.Text);
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual Site Area updated successfully";
        }

        #endregion


        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea();
            LoadAreaXML();
        }

        protected void rptArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.SiteArea area = e.Item.DataItem as JXTPortal.Entities.SiteArea)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfAreaId = e.Item.FindControl("hfAreaId") as HiddenField;

                    hfAreaId.Value = area.AreaId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", area.AreaId, area.SiteAreaName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteAreaXML();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLocation();

            LoadArea();
            LoadAreaXML();
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArea();
            LoadAreaXML();
        }

        #endregion
    }
}