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
    public partial class MultiLingualRoles : System.Web.UI.Page
    {
        #region Declarations

        private LanguagesService _languagesservice;
        private ProfessionService _professionservice;
        private RolesService _rolesservice;

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

        private RolesService RolesService
        {
            get
            {
                if (_rolesservice == null)
                {
                    _rolesservice = new RolesService();
                }
                return _rolesservice;
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

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadLanguage();
                LoadProfession();
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
            TList<JXTPortal.Entities.Profession> professions = new TList<Entities.Profession>();
            if (!SessionData.Site.UseCustomProfessionRole)
            {
                professions = ProfessionService.GetAll();
            }
            else
            {
                SiteCustomMappingService _service = new SiteCustomMappingService();
                SiteCustomMapping siteMapping = _service.GetAll().Find(s => s.SiteId == SessionData.Site.SiteId);

                // Check if there is custom mapping then filter by the master site.
                if (siteMapping != null)
                    professions = ProfessionService.GetByReferredSiteId(siteMapping.MasterSiteId);
                else
                    professions = ProfessionService.GetByReferredSiteId(SessionData.Site.SiteId);

            }

            ddlProfession.DataSource = professions;
            ddlProfession.DataBind();
            ddlProfession.Items.Insert(0, new ListItem(" Please Choose ...", "0"));

        }

        private void LoadRoles()
        {
            if (ddlLanguage.SelectedValue != "0" && ddlProfession.SelectedValue != "0")
            {
                rptRoles.DataSource = RolesService.GetByProfessionId(Convert.ToInt32(ddlProfession.SelectedValue));
                rptRoles.DataBind();
                btnEditSave.Visible = true;
            }
            else
            {
                rptRoles.DataSource = null;
                rptRoles.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadRolesXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.Roles objRole in RolesService.GetTranslatedRoles(Convert.ToInt32(ddlProfession.SelectedValue), Convert.ToInt16(ddlLanguage.SelectedValue), SessionData.Site.UseCustomProfessionRole))
                {
                    foreach (RepeaterItem repeateritem in rptRoles.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfRoleId = repeateritem.FindControl("hfRoleId") as HiddenField;

                        if (hfRoleId.Value == objRole.RoleId.ToString())
                        {
                            tbMultiLingual.Text = objRole.RoleName;
                            break;
                        }
                    }
                }
            }
        }

        private void WriteRolesXML()
        {
            string url = string.Empty;

            if (SessionData.Site.UseCustomProfessionRole)
            {
                string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";

                url = string.Format(xmlprefix,
                                    System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                     Convert.ToInt32(ddlLanguage.SelectedValue),
                                    PortalConstants.XMLTranslationFiles.XML_CUSTOMROLE_FILENAME, Convert.ToInt32(ddlProfession.SelectedValue), SessionData.Site.SiteId);
            }
            else
            {
                string xmlprefix = "{0}{2}_{1}_{3}.xml";

               url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_ROLE_FILENAME, Convert.ToInt32(ddlProfession.SelectedValue));
            }

            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptRoles.Items)
            {
                TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                HiddenField hfRoleId = repeateritem.FindControl("hfRoleId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfRoleId.Value.ToString());
                writer.WriteElementString("name", tbMultiLingual.Text);
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Close();

            ltlMessage.Text = "MultiLingual Roles updated successfully";
        }

        #endregion


        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles();
            LoadRolesXML();
        }

        protected void rptRoles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.Roles role = e.Item.DataItem as JXTPortal.Entities.Roles)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfRoleId = e.Item.FindControl("hfRoleId") as HiddenField;

                    hfRoleId.Value = role.RoleId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", role.RoleId, role.RoleName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteRolesXML();
        }


        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoles();
            LoadRolesXML();
        }
        #endregion

    }
}
