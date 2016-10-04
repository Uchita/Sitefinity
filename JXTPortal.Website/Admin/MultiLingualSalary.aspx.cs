using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Common;
using System.Configuration;
using System.Xml;
using System.IO;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class MultiLingualSalary : System.Web.UI.Page
    {

        #region Declarations

        private LanguagesService _languagesservice;
        private SalaryTypeService _salarytypeservice;
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

        private SalaryTypeService SalaryTypeService
        {
            get
            {
                if (_salarytypeservice == null)
                {
                    _salarytypeservice = new SalaryTypeService();
                }
                return _salarytypeservice;
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

        private void LoadSalary()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                rptSalary.DataSource = SalaryTypeService.GetAll();
                rptSalary.DataBind();
                btnEditSave.Visible = true;
            }
            else
            {
                rptSalary.DataSource = null;
                rptSalary.DataBind();
                btnEditSave.Visible = false;
            }
        }

        private void LoadSalaryXML()
        {
            if (ddlLanguage.SelectedValue != "0")
            {
                foreach (Entities.SalaryType salarytype in SalaryTypeService .GetTranslatedSalaryTypes(Convert.ToInt16(ddlLanguage.SelectedValue)))
                {
                    foreach (RepeaterItem repeateritem in rptSalary.Items)
                    {
                        TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                        HiddenField hfSalaryTypeId = repeateritem.FindControl("hfSalaryTypeId") as HiddenField;

                        if (hfSalaryTypeId.Value == salarytype.SalaryTypeId.ToString())
                        {
                            tbMultiLingual.Text = salarytype.SalaryTypeName;
                            break;
                        }
                    }
                }

                string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);

                if (File.Exists(url))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(url);

                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string salaryid = xmlnode.ChildNodes[0].InnerText;
                        string salaryname = xmlnode.ChildNodes[1].InnerText;

                        foreach (RepeaterItem repeateritem in rptSalary.Items)
                        {
                            TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                            HiddenField hfSalaryId = repeateritem.FindControl("hfSalaryTypeId") as HiddenField;

                            if (hfSalaryId.Value == salaryid)
                            {
                                tbMultiLingual.Text = salaryname;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteSalaryXML()
        {
            string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), ddlLanguage.SelectedValue,
                                            PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);
            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptSalary.Items)
            {
                TextBox tbMultiLingual = repeateritem.FindControl("tbMultiLingual") as TextBox;
                HiddenField hfSalaryId = repeateritem.FindControl("hfSalaryTypeId") as HiddenField;

                writer.WriteStartElement("item");
                writer.WriteElementString("id", hfSalaryId.Value.ToString());
                writer.WriteElementString("name", tbMultiLingual.Text);
                writer.WriteEndElement();

            }
            writer.WriteEndElement();
            writer.Close();
            ltlMessage.Text = "MultiLingual Salary Type updated successfully";
        }

        #endregion


        #region Events

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalary();
            LoadSalaryXML();
        }

        protected void rptSalary_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.SalaryType salarytype = e.Item.DataItem as JXTPortal.Entities.SalaryType)
                {
                    Literal litDefault = e.Item.FindControl("litDefault") as Literal;
                    TextBox tbMultiLingual = e.Item.FindControl("tbMultiLingual") as TextBox;
                    HiddenField hfSalaryTypeId = e.Item.FindControl("hfSalaryTypeId") as HiddenField;

                    hfSalaryTypeId.Value = salarytype.SalaryTypeId.ToString();
                    litDefault.Text = string.Format("{0}. {1}", salarytype.SalaryTypeId, salarytype.SalaryTypeName);
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            WriteSalaryXML();
        }

        #endregion
    }
}
