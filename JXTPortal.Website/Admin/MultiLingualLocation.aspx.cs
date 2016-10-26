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
    public partial class MultiLingualLocation : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private LocationService _locationservice;
        private CountriesService _countriesservice;
        private const string xmlprefix = "{0}{2}_{1}_{3}.xml";

        #endregion

        #region Properties

        private LanguagesService LanguagesService
        {
            get
            {
                if (_languagesservice == null)
                {
                    _languagesservice = new LanguagesService();
                }
                return _languagesservice;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationservice == null)
                {
                    _locationservice = new LocationService();
                }
                return _locationservice;
            }
        }

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesservice == null)
                {
                    _countriesservice = new CountriesService();
                }
                return _countriesservice;
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
            using (TList<JXTPortal.Entities.Languages> languages = LanguagesService.GetAll())
            {
                languages.Filter = "LanguageName <> English";
                ddlLanguage.DataSource = languages;
                ddlLanguage.DataBind();
                ddlLanguage.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
            }
        }

        private void LoadLocation()
        {
            if (ddlLanguage.SelectedValue != "0" && ddlCountry.SelectedValue != "0")
            {
                 TList<Entities.Location> locations = LocationService.GetByCountryId(Convert.ToInt32(ddlCountry.SelectedValue));
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
            using (TList<JXTPortal.Entities.Countries> countries = CountriesService.GetAll())
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
                foreach (Entities.Location location in LocationService.GetTranslatedLocations(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptLocation.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfLocationId = repeateritem.FindControl("hfLocationId") as HiddenField;

                        if (hfLocationId.Value == location.LocationId.ToString())
                        {
                            tbMultiLingual.Text = location.LocationName;
                            break;
                        }
                    }
                }
            }
        }

        private void WriteLocationXML()
        {
            string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_LOCATION_FILENAME, ddlCountry.SelectedValue);
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

            ltlMessage.Text = "MultiLingual Location updated successfully";
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
                using (JXTPortal.Entities.Location location = e.Item.DataItem as JXTPortal.Entities.Location)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfLocationId = e.Item.FindControl("hfLocationId") as HiddenField;

                    hfLocationId.Value = location.LocationId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", location.LocationId, location.LocationName);
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
