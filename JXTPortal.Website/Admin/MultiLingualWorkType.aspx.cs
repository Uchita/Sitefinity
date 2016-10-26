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
    public partial class MultiLingualWorkType : System.Web.UI.Page
    {

        #region Declarations

        private LanguagesService _languagesservice;
        private WorkTypeService _workTypeservice;
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

        private WorkTypeService WorkTypeService
        {
            get
            {
                if (_workTypeservice == null)
                {
                    _workTypeservice = new WorkTypeService();
                }
                return _workTypeservice;
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

        private void LoadWorkType()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                rptWorkType.DataSource = WorkTypeService.GetAll();
                rptWorkType.DataBind();
                btnEditSave.Visible = true;
            }
            else
            {
                rptWorkType.DataSource = null;
                rptWorkType.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadWorkTypeXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.WorkType workType in WorkTypeService.GetTranslatedWorkTypes(Convert.ToInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptWorkType.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfWorkTypeId = repeateritem.FindControl("hfWorkTypeId") as HiddenField;

                        if (hfWorkTypeId.Value == workType.WorkTypeId.ToString())
                        {
                            tbMultiLingual.Text = workType.WorkTypeName;
                            break;
                        }
                    }
                }

                string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);

                if (File.Exists(url))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(url);

                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string workTypeid = xmlnode.ChildNodes[0].InnerText;
                        string workTypename = xmlnode.ChildNodes[1].InnerText;

                        foreach (RepeaterItem repeateritem in rptWorkType.Items)
                        {
                            TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                            HiddenField hfWorkTypeId = repeateritem.FindControl("hfWorkTypeId") as HiddenField;

                            if (hfWorkTypeId.Value == workTypeid)
                            {
                                tbMultiLingual.Text = workTypename;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteWorkTypeXML()
        {
            string url = string.Format(xmlprefix, ConfigurationManager.AppSettings["XMLFilesPath"], ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_WORKTYPE_FILENAME);
            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptWorkType.Items)
            {
                TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                HiddenField hfWorkTypeId = repeateritem.FindControl("hfWorkTypeId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfWorkTypeId.Value.ToString());
                writer.WriteElementString("name", tbMultiLingual.Text);
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual WorkType updated successfully";
        }

        #endregion


        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWorkType();
            LoadWorkTypeXML();
        }

        protected void rptWorkType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.WorkType workType = e.Item.DataItem as JXTPortal.Entities.WorkType)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfWorkTypeId = e.Item.FindControl("hfWorkTypeId") as HiddenField;

                    hfWorkTypeId.Value = workType.WorkTypeId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", workType.WorkTypeId, workType.WorkTypeName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteWorkTypeXML();
        }

        #endregion
    }
}
