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
    public partial class MultiLingualCountry : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private CountriesService _countriesservice;
        private const string xmlprefix = "{0}{2}_{1}.xml";

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

        private void LoadCountry()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                rptCountry.DataSource = CountriesService.GetAll();
                rptCountry.DataBind();
                btnEditSave.Visible = true;
            }
            else
            {
                rptCountry.DataSource = null;
                rptCountry.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadCountryXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.Countries countries in CountriesService.GetTranslatedCountries(Convert.ToInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptCountry.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfCountryId = repeateritem.FindControl("hfCountryId") as HiddenField;

                        if (hfCountryId.Value == countries.CountryId.ToString())
                        {
                            tbMultiLingual.Text = countries.CountryName;
                            break;
                        }
                    }
                }

                string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_COUNTRY_FILENAME);

                if (File.Exists(url))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(url);

                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string countryid = xmlnode.ChildNodes[0].InnerText;
                        string countryname = xmlnode.ChildNodes[1].InnerText;

                        foreach (RepeaterItem repeateritem in rptCountry.Items)
                        {
                            TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                            HiddenField hfCountryId = repeateritem.FindControl("hfCountryId") as HiddenField;

                            if (hfCountryId.Value == countryid)
                            {
                                tbMultiLingual.Text = countryname;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteCountryXML()
        {
            string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_COUNTRY_FILENAME);
            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptCountry.Items)
            {
                TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                HiddenField hfCountryId = repeateritem.FindControl("hfCountryId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfCountryId.Value.ToString());
                writer.WriteElementString("name", tbMultiLingual.Text);
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual Country updated successfully";
        }

        #endregion


        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCountry();
            LoadCountryXML();
        }

        protected void rptCountry_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.Countries country = e.Item.DataItem as JXTPortal.Entities.Countries)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfCountryId = e.Item.FindControl("hfCountryId") as HiddenField;

                    hfCountryId.Value = country.CountryId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", country.CountryId, country.CountryName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteCountryXML();
        }

        #endregion
    }
}
