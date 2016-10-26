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
    public partial class MultiLingualArea : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private LocationService _locationservice;
        private CountriesService _countriesservice;
        private AreaService _areaservice;
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

        private AreaService AreaService
        {
            get
            {
                if (_areaservice == null)
                {
                    _areaservice = new AreaService();
                }
                return _areaservice;
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
                LoadLanguage();
                LoadCountry();
                LoadLocation();
            }
        }

        #endregion

        #region Methods

        private void LoadLanguage()
        {
            using (TList<JXTPortal.Entities.Languages> languages = LanguagesService.GetAll())
            {
                // ToDo - Add in Web.config the default value of LanguageID = 1 and Filter with LanguageID = from Web.config
                // ToDo - Change in all the Admin Multilingual pages
                languages.Filter = "LanguageName <> English";
                ddlLanguage.DataSource = languages;
                ddlLanguage.DataBind();
                ddlLanguage.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
            }
        }

        private void LoadCountry()
        {
            using (TList<JXTPortal.Entities.Countries> countries = CountriesService.GetAll())
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
                using (TList<JXTPortal.Entities.Location> locations = LocationService.GetByCountryId(Convert.ToInt32(ddlCountry.SelectedValue)))
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
                TList<Entities.Area> areas = AreaService.GetByLocationId(Convert.ToInt32(ddlLocation.SelectedValue));
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

                foreach (Entities.Area objArea in AreaService.GetTranslatedAreas(Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptArea.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfAreaId = repeateritem.FindControl("hfAreaId") as HiddenField;

                        if (hfAreaId.Value == objArea.AreaId.ToString())
                        {
                            tbMultiLingual.Text = objArea.AreaName;
                            break;
                        }
                    }
                }

            }
        }

        private void WriteAreaXML()
        {
            string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_AREA_FILENAME, ddlLocation.SelectedValue);
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
            ltlMessage.Text = "MultiLingual Area updated successfully";
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
                using (JXTPortal.Entities.Area area = e.Item.DataItem as JXTPortal.Entities.Area)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfAreaId = e.Item.FindControl("hfAreaId") as HiddenField;

                    hfAreaId.Value = area.AreaId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", area.AreaId, area.AreaName);
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
