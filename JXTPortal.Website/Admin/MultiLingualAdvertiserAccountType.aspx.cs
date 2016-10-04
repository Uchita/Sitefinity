
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
    public partial class MultiLingualAdvertiserAccountType : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private AdvertiserAccountTypeService _advertiserAccountTypeService;
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

        private AdvertiserAccountTypeService AdvertiserAccountTypeService
        {
            get
            {
                if (_advertiserAccountTypeService == null)
                {
                    _advertiserAccountTypeService = new AdvertiserAccountTypeService();
                }
                return _advertiserAccountTypeService;
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

        private void LoadAccountType()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                using (TList<Entities.AdvertiserAccountType> objAccountType = AdvertiserAccountTypeService.GetAll())
                {
                    rptMultiLingualAdvertiserAccountType.DataSource = objAccountType;
                    rptMultiLingualAdvertiserAccountType.DataBind();
                    btnEditSave.Visible = true;
                }
            }
            else
            {
                rptMultiLingualAdvertiserAccountType.DataSource = null;
                rptMultiLingualAdvertiserAccountType.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadAccountTypeXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.AdvertiserAccountType accountType in 
                    AdvertiserAccountTypeService.GetTranslatedAdvertiserAccountType(Convert.ToInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptMultiLingualAdvertiserAccountType.Items)
                    {
                        TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                        HiddenField hfAdvertiserAccountTypeID = repeateritem.FindControl("hfAdvertiserAccountTypeID") as HiddenField;

                        if (hfAdvertiserAccountTypeID.Value == accountType.AdvertiserAccountTypeId.ToString())
                        {
                            txtMultiLingual.Text = accountType.AdvertiserAccountTypeName;
                            break;
                        }
                    }
                }

                string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_ADVERTISERACCOUNTTYPE_FILENAME);

                if (File.Exists(url))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(url);

                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string advertiserAccountTypeId = xmlnode.ChildNodes[0].InnerText;
                        string advertiserAccountTypeName = xmlnode.ChildNodes[1].InnerText;

                        foreach (RepeaterItem repeateritem in rptMultiLingualAdvertiserAccountType.Items)
                        {
                            TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                            HiddenField hfAdvertiserAccountTypeID = repeateritem.FindControl("hfAdvertiserAccountTypeID") as HiddenField;

                            if (hfAdvertiserAccountTypeID.Value == advertiserAccountTypeId)
                            {
                                txtMultiLingual.Text = advertiserAccountTypeName;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteAccountTypeXML()
        {
            string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_ADVERTISERACCOUNTTYPE_FILENAME);

            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");

            foreach (RepeaterItem repeateritem in rptMultiLingualAdvertiserAccountType.Items)
            {
                TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                HiddenField hfAdvertiserAccountTypeID = repeateritem.FindControl("hfAdvertiserAccountTypeID") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfAdvertiserAccountTypeID.Value.ToString());
                writer.WriteElementString("name", txtMultiLingual.Text);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual Advertiser Account Type updated successfully";
        }

        #endregion

        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccountType();
            LoadAccountTypeXML();
        }

        protected void rptMultiLingualAdvertiserAccountType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (Entities.AdvertiserAccountType accountType = e.Item.DataItem as Entities.AdvertiserAccountType)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox txtMultiLingual = e.Item.FindControl("txtMultiLingual") as TextBox;
                    HiddenField hfAdvertiserAccountTypeID = e.Item.FindControl("hfAdvertiserAccountTypeID") as HiddenField;

                    hfAdvertiserAccountTypeID.Value = accountType.AdvertiserAccountTypeId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", accountType.AdvertiserAccountTypeId, accountType.AdvertiserAccountTypeName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteAccountTypeXML();
        }

        #endregion
    }
}
