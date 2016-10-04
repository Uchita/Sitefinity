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
    public partial class MultiLingualProfession : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private ProfessionService _professionservice;
        private SiteProfessionService _siteProfessionservice;

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

        private ProfessionService ProfessionService
        {
            get
            {
                if (_professionservice == null)
                {
                    _professionservice = new ProfessionService();
                }
                return _professionservice;
            }
        }

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteProfessionservice == null)
                {
                    _siteProfessionservice = new SiteProfessionService();
                }
                return _siteProfessionservice;
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

        private void LoadProfession()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                TList<Entities.Profession> professions = new TList<Entities.Profession>();
                if (SessionData.Site.UseCustomProfessionRole)
                {
                    //professions = ProfessionService.GetByReferredSiteId(SessionData.Site.SiteId);


                    SiteCustomMappingService _service = new SiteCustomMappingService();
                    SiteCustomMapping siteMapping = _service.GetAll().Find(s => s.SiteId == SessionData.Site.SiteId);

                    // Check if there is custom mapping then filter by the master site.
                    if (siteMapping != null)
                        professions = ProfessionService.GetByReferredSiteId(siteMapping.MasterSiteId);
                    else
                        professions = ProfessionService.GetByReferredSiteId(SessionData.Site.SiteId);
                }
                else
                {
                    professions = ProfessionService.GetAll();
                }


                rptProfessions.DataSource = professions;
                rptProfessions.DataBind();
                btnEditSave.Visible = true;
            }
            else
            {
                rptProfessions.DataSource = null;
                rptProfessions.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadProfessionXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.Profession profession in ProfessionService.GetTranslatedProfessions(Convert.ToInt16(ddlLanguage.SelectedValue), SessionData.Site.UseCustomProfessionRole))
                {
                    foreach (RepeaterItem repeateritem in rptProfessions.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfProfessionId = repeateritem.FindControl("hfProfessionId") as HiddenField;

                        if (hfProfessionId.Value == profession.ProfessionId.ToString())
                        {
                            tbMultiLingual.Text = profession.ProfessionName;
                            break;
                        }
                    }
                }
            }
        }


        private void WriteProfessionXML()
        {
            string url = string.Empty;

            if (SessionData.Site.UseCustomProfessionRole)
            {
                string xmlprefix = "{0}{2}_{3}_{1}.xml";
                url = string.Format(xmlprefix,
                                    System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                    Convert.ToInt32(ddlLanguage.SelectedValue),
                                    PortalConstants.XMLTranslationFiles.XML_CUSTOMPROFESSION_FILENAME, SessionData.Site.SiteId);
            }
            else
            {
                string xmlprefix = "{0}{2}_{1}.xml";

                url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                             PortalConstants.XMLTranslationFiles.XML_PROFESSION_FILENAME);
            }


            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptProfessions.Items)
            {
                TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                HiddenField hfProfessionId = repeateritem.FindControl("hfProfessionId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfProfessionId.Value.ToString());
                writer.WriteElementString("name", tbMultiLingual.Text);
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Close();

            ltlMessage.Text = "MultiLingual Profession updated successfully";
        }

        #endregion


        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfession();
            LoadProfessionXML();
        }

        protected void rptProfessions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.Profession profession = e.Item.DataItem as JXTPortal.Entities.Profession)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfProfessionId = e.Item.FindControl("hfProfessionId") as HiddenField;

                    hfProfessionId.Value = profession.ProfessionId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", profession.ProfessionId, profession.ProfessionName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteProfessionXML();
        }

        #endregion


    }
}
