
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
    public partial class MultiLingualEducations : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private EducationsService _educationsService;
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

        private EducationsService EducationsService
        {
            get
            {
                if (_educationsService == null)
                {
                    _educationsService = new EducationsService();
                }
                return _educationsService;
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

        private void LoadEducations()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                JXTPortal.EducationsService education = new EducationsService();

                using (TList<Entities.Educations> objEducation = education.GetAll())
                {
                    rptMultiLingualEducations.DataSource = objEducation;
                    objEducation.Filter = "GlobalTemplate = True";
                    rptMultiLingualEducations.DataBind();
                    btnEditSave.Visible = true;
                }
            }
            else
            {
                rptMultiLingualEducations.DataSource = null;
                rptMultiLingualEducations.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadEducationsXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.Educations educations in EducationsService.GetTranslatedEducations(Convert.ToInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptMultiLingualEducations.Items)
                    {
                        TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                        HiddenField hfEducationId = repeateritem.FindControl("hfEducationId") as HiddenField;

                        if (hfEducationId.Value == educations.EducationId.ToString())
                        {
                            txtMultiLingual.Text = educations.EducationName;
                            break;
                        }
                    }
                }

                string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_EDUCATIONS_FILENAME);

                if (File.Exists(url))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(url);

                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string educationid = xmlnode.ChildNodes[0].InnerText;
                        string educationName = xmlnode.ChildNodes[1].InnerText;

                        foreach (RepeaterItem repeateritem in rptMultiLingualEducations.Items)
                        {
                            TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                            HiddenField hfEducationId = repeateritem.FindControl("hfEducationId") as HiddenField;

                            if (hfEducationId.Value == educationid)
                            {
                                txtMultiLingual.Text = educationName;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteEducationsXML()
        {
            string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_EDUCATIONS_FILENAME);
            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");

            foreach (RepeaterItem repeateritem in rptMultiLingualEducations.Items)
            {
                TextBox txtMultiLingual = repeateritem.FindControl("txtMultiLingual") as TextBox;
                HiddenField hfEducationId = repeateritem.FindControl("hfEducationId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfEducationId.Value.ToString());
                writer.WriteElementString("name", txtMultiLingual.Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual Educations updated successfully";
        }

        #endregion

        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEducations();
            LoadEducationsXML();
        }

        protected void rptMultiLingualEducations_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (Entities.Educations educations = e.Item.DataItem as Entities.Educations)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox txtMultiLingual = e.Item.FindControl("txtMultiLingual") as TextBox;
                    HiddenField hfEducationId = e.Item.FindControl("hfEducationId") as HiddenField;

                    hfEducationId.Value = educations.EducationId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", educations.EducationId, educations.EducationName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteEducationsXML();
        }

        #endregion
    }
}
