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
    public partial class MultiLingualSiteLocation : System.Web.UI.Page
    {
        #region Declarations

        private SiteLanguagesService _sitelanguagesservice;
        private SiteLocationService _sitelocationservice;
        private SiteCountriesService _sitecountriesservice;
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
                LoadCountries();
                LoadLanguage();
            }
        }

        #endregion

        #region Methods

        private void LoadLanguage()
        {
            using (TList<JXTPortal.Entities.SiteLanguages> languages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                languages.Filter = "LanguageID <> " + SessionData.Site.DefaultLanguageId.ToString();
                ddlLanguage.DataSource = languages;
                ddlLanguage.DataBind();
                ddlLanguage.Items.Insert(0, new ListItem(" Please Choose ...", "0"));

                phLocation.Visible = (ddlLanguage.Items.Count > 0);
                ltlMessage.Text = (ddlLanguage.Items.Count > 0) ? "" : "This site is not multilingual.";
            }
        }

        private void LoadLocation()
        {
            if (ddlLanguage.SelectedValue != "0" && ddlCountry.SelectedValue != "0")
            {
                TList<Entities.SiteLocation> locations = SiteLocationService.GetByCountryID(SessionData.Site.SiteId, Convert.ToInt32(ddlCountry.SelectedValue));
                if (locations.Count > 0)
                {
                    rptLocation.DataSource = locations;
                    rptLocation.DataBind();
                    btnEditSave.Visible = true;
                }
                else
                {
                    rptLocation.DataSource = null;
                    rptLocation.DataBind();
                    btnEditSave.Visible = false;
                }
            }
            else
            {
                rptLocation.DataSource = null;
                rptLocation.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadCountries()
        {
            using (TList<JXTPortal.Entities.SiteCountries> countries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId))
            {
                ddlCountry.DataSource = countries;
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
            }
        }

        private void LoadLocationXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.SiteLocation location in SiteLocationService.GetTranslatedLocationsByCountryID(Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptLocation.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfLocationId = repeateritem.FindControl("hfLocationId") as HiddenField;

                        if (hfLocationId.Value == location.LocationId.ToString())
                        {
                            tbMultiLingual.Text = location.SiteLocationName;
                            break;
                        }
                    }
                }
            }
        }

        private void WriteLocationXML()
        {
            string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_SITELOCATION_FILENAME, ddlCountry.SelectedValue, SessionData.Site.SiteId);
            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptLocation.Items)
            {
                TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                HiddenField hfLocationId = repeateritem.FindControl("hfLocationId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfLocationId.Value.ToString());
                writer.WriteElementString("name", tbMultiLingual.Text);
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Close();

            ltlMessage.Text = "MultiLingual Site Location updated successfully";
        }

        #endregion


        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex > 0 && ddlLanguage.SelectedIndex > 0)
            {
                LoadLocation();
                LoadLocationXML();
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex > 0 && ddlLanguage.SelectedIndex > 0)
            {
                LoadLocation();
                LoadLocationXML();
            }
        }

        protected void rptLocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.SiteLocation location = e.Item.DataItem as JXTPortal.Entities.SiteLocation)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfLocationId = e.Item.FindControl("hfLocationId") as HiddenField;

                    hfLocationId.Value = location.LocationId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", location.LocationId, location.SiteLocationName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteLocationXML();
        }

        #endregion
    }
}