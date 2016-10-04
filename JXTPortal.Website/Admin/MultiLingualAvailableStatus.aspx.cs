
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
    public partial class MultiLingualAvailableStatus : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private AvailableStatusService _availableStatusService;
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

        private AvailableStatusService AvailableStatusService
        {
            get
            {
                if (_availableStatusService == null)
                {
                    _availableStatusService = new AvailableStatusService();
                }
                return _availableStatusService;
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

        private void LoadAvailableStatus()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                //rptMultiLingualAvailableStatus.DataSource = AvailableStatusService.GetAll();
                JXTPortal.AvailableStatusService available = new AvailableStatusService();

                using (TList<Entities.AvailableStatus> objAvailableStatus = available.GetAll())
                {
                    rptMultiLingualAvailableStatus.DataSource = objAvailableStatus;
                    objAvailableStatus.Filter = "GlobalTemplate = True";
                    rptMultiLingualAvailableStatus.DataBind();
                    btnEditSave.Visible = true;
                }
            }
            else
            {
                rptMultiLingualAvailableStatus.DataSource = null;
                rptMultiLingualAvailableStatus.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadAvailableStatusXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.AvailableStatus availableStatus in AvailableStatusService.GetTranslatedAvailableStatus(Convert.ToUInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptMultiLingualAvailableStatus.Items)
                    {
                        TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                        HiddenField hfAvailableStatusId = repeateritem.FindControl("hfAvailableStatusId") as HiddenField;

                        if (hfAvailableStatusId.Value == availableStatus.AvailableStatusId.ToString())
                        {
                            txtMultiLingual.Text = availableStatus.AvailableStatusName;
                            break;
                        }
                    }
                }

                string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_AVAILABLESTATUS_FILENAME);

                if (File.Exists(url))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(url);

                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string availableStatusid = xmlnode.ChildNodes[0].InnerText;
                        string availableStatusName = xmlnode.ChildNodes[1].InnerText;

                        foreach (RepeaterItem repeateritem in rptMultiLingualAvailableStatus.Items)
                        {
                            TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                            HiddenField hfAvailableStatusId = repeateritem.FindControl("hfAvailableStatusId") as HiddenField;

                            if (hfAvailableStatusId.Value == availableStatusid)
                            {
                                txtMultiLingual.Text = availableStatusName;
                                break;
                            }
                        }
                    }
                }

            }
        }

        private void WriteAvailableStatusXML()
        {
            string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_AVAILABLESTATUS_FILENAME);
            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");

            foreach (RepeaterItem repeateritem in rptMultiLingualAvailableStatus.Items)
            {
                TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                HiddenField hfAvailableStatusId = repeateritem.FindControl("hfAvailableStatusId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfAvailableStatusId.Value.ToString());
                writer.WriteElementString("name", txtMultiLingual.Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual Available Status updated successfully";
        }

        #endregion

        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableStatus();
            LoadAvailableStatusXML();
        }

        protected void rptMultiLingualAvailableStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (Entities.AvailableStatus availableStatus = e.Item.DataItem as Entities.AvailableStatus)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox txtMultiLingual = e.Item.FindControl("txtMultiLingual") as TextBox;
                    HiddenField hfAvailableStatusId = e.Item.FindControl("hfAvailableStatusId") as HiddenField;

                    hfAvailableStatusId.Value = availableStatus.AvailableStatusId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", availableStatus.AvailableStatusId, availableStatus.AvailableStatusName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteAvailableStatusXML();
        }


        #endregion
    }
}
