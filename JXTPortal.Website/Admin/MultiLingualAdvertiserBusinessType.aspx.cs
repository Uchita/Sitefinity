
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using JXTPortal.Common;
using System.Configuration;
using System.IO;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class MultiLingualAdvertiserBusinessType : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private AdvertiserBusinessTypeService _advertiserBusinessTypeService;
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

        private AdvertiserBusinessTypeService AdvertiserBusinessTypeService
        {
            get
            {
                if (_advertiserBusinessTypeService == null)
                {
                    _advertiserBusinessTypeService = new AdvertiserBusinessTypeService();
                }
                return _advertiserBusinessTypeService;
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

        private void LoadBusinessType()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                using (TList<Entities.AdvertiserBusinessType> objBusinessType = AdvertiserBusinessTypeService.GetDefaultBusinessTypes())
                {
                    rptMultiLingualAdvertiserBusinessType.DataSource = objBusinessType;
                    rptMultiLingualAdvertiserBusinessType.DataBind();
                    btnEditSave.Visible = true;
                }
            }
            else
            {
                rptMultiLingualAdvertiserBusinessType.DataSource = null;
                rptMultiLingualAdvertiserBusinessType.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadBusinessTypeXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.AdvertiserBusinessType businessType in AdvertiserBusinessTypeService.GetTranslatedAdvertiserBusinessType(SessionData.Language.LanguageId))
                {
                    foreach (RepeaterItem repeateritem in rptMultiLingualAdvertiserBusinessType.Items)
                    {
                        TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                        HiddenField hfAdvertiserBusinessTypeID = repeateritem.FindControl("hfAdvertiserBusinessTypeID") as HiddenField;

                        if (hfAdvertiserBusinessTypeID.Value == businessType.AdvertiserBusinessTypeId.ToString())
                        {
                            txtMultiLingual.Text = businessType.AdvertiserBusinessTypeName;
                            break;
                        }
                    }
                }

                string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_ADVERTISERBUSINESSTYPE_FILENAME);

                if (File.Exists(url))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(url);

                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string advertiserBusinessTypeId = xmlnode.ChildNodes[0].InnerText;
                        string advertiserBusinessTypeName = xmlnode.ChildNodes[1].InnerText;

                        foreach (RepeaterItem repeateritem in rptMultiLingualAdvertiserBusinessType.Items)
                        {
                            TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                            HiddenField hfAdvertiserBusinessTypeID = repeateritem.FindControl("hfAdvertiserBusinessTypeID") as HiddenField;

                            if (hfAdvertiserBusinessTypeID.Value == advertiserBusinessTypeId)
                            {
                                txtMultiLingual.Text = advertiserBusinessTypeName;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteBusinessTypeXML()
        {
            string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_ADVERTISERBUSINESSTYPE_FILENAME);

            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");

            foreach (RepeaterItem repeateritem in rptMultiLingualAdvertiserBusinessType.Items)
            {
                TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                HiddenField hfAdvertiserBusinessTypeID = repeateritem.FindControl("hfAdvertiserBusinessTypeID") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfAdvertiserBusinessTypeID.Value.ToString());
                writer.WriteElementString("name", txtMultiLingual.Text);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual Advertiser Business Type updated successfully";
        }

        #endregion

        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBusinessType();
            LoadBusinessTypeXML();
        }

        protected void rptMultiLingualAdvertiserBusinessType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (Entities.AdvertiserBusinessType businessType = e.Item.DataItem as Entities.AdvertiserBusinessType)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox txtMultiLingual = e.Item.FindControl("txtMultiLingual") as TextBox;
                    HiddenField hfAdvertiserBusinessTypeID = e.Item.FindControl("hfAdvertiserBusinessTypeID") as HiddenField;

                    hfAdvertiserBusinessTypeID.Value = businessType.AdvertiserBusinessTypeId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", businessType.AdvertiserBusinessTypeId, businessType.AdvertiserBusinessTypeName);

                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteBusinessTypeXML();
        }

        #endregion
    }
}
