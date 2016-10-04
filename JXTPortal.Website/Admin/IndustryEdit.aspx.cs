#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Website;
using JXTPortal;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Xml;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class IndustryEdit : System.Web.UI.Page
    {
        private int industryId = 0;
        private int IndustryId
        {
            get
            {
                if ((Request.QueryString["IndustryId"] != null))
                {
                    if (int.TryParse((Request.QueryString["IndustryId"].Trim()), out industryId))
                    {
                        industryId = Convert.ToInt32(Request.QueryString["IndustryId"]);
                    }
                    return industryId;
                }
                return industryId;
            }
        }

        private IndustryService _industryService = null;
        private IndustryService IndustryService
        {
            get
            {
                if (_industryService == null)
                    _industryService = new IndustryService();
                return _industryService;
            }
        }

        private SiteLanguagesService _sitelanguagesService = null;
        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesService == null)
                    _sitelanguagesService = new SiteLanguagesService();
                return _sitelanguagesService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (IndustryId > 0)
                {
                    LoadIndustry();
                }
            }
        }

        private void LoadIndustry()
        {
            Entities.Industry industry = IndustryService.GetByIndustryId(IndustryId);

            btnDelete.Visible = false;
            phMultilingual.Visible = false;
            hfIndustryId.Value = IndustryId.ToString();

            if (industry != null)
            {
                tbIndustryName.Text = industry.IndustryName;
                tbSequence.Text = industry.Sequence.ToString();
                cbValid.Checked = industry.Valid;

                btnDelete.Visible = true;

                LoadLanguages(industry);
            }
        }

        private int LoadLanguages(Entities.Industry industry)
        {
            int langid = 0;
            if (industry.IndustryId > 0)
            {
                TList<JXTPortal.Entities.SiteLanguages> langs = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
                langs.Filter = "LanguageID <> " + SessionData.Site.DefaultLanguageId.ToString();
                if (langs.Count > 0)
                {
                    phMultilingual.Visible = true;

                    rptMultilingual.DataSource = langs;
                    rptMultilingual.DataBind();

                    RepeaterItem firstlang = rptMultilingual.Items[0];
                    LinkButton lbLanguage = firstlang.FindControl("lbLanguage") as LinkButton;
                    lbLanguage.Enabled = false;

                    langid = Convert.ToInt32(lbLanguage.CommandArgument);

                    if (!string.IsNullOrWhiteSpace(industry.IndustryLanguageXml))
                    {
                        XmlDocument langxml = new XmlDocument();
                        langxml.LoadXml(industry.IndustryLanguageXml);

                        XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                        foreach (XmlNode langnode in langlist)
                        {
                            if (langnode.ChildNodes[0].InnerXml == langid.ToString())
                            {
                                txtMultiIndustryName.Text = langnode.ChildNodes[1].InnerXml;
                            }
                        }
                    }

                }
            }

            return langid;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IndustryService.Delete(IndustryId);

            Response.Redirect("Industry.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entities.Industry industry = IndustryService.GetByIndustryId(IndustryId);

            string industryxml = string.Empty;

            using (TList<SiteLanguages> SiteLanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (SiteLanguages.Count > 1)
                {
                    industryxml = "<Languages>";

                    foreach (SiteLanguages lang in SiteLanguages)
                    {
                        industryxml += string.Format("<Language><id>{0}</id><name>{1}</name></Language>", lang.LanguageId, tbIndustryName.Text);
                    }

                    industryxml += "</Languages>";
                }
            }

            if (industry != null)
            {
                industry.IndustryName = tbIndustryName.Text;
                industry.Sequence = Convert.ToInt32(tbSequence.Text);
                industry.Valid = cbValid.Checked;
                industry.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                industry.LastModified = DateTime.Now;
                industry.IndustryLanguageXml = industryxml;

                IndustryService.Update(industry);
            }
            else
            {
                industry = new Entities.Industry();

                industry.IndustryName = tbIndustryName.Text;
                industry.Sequence = Convert.ToInt32(tbSequence.Text);
                industry.Valid = cbValid.Checked;
                industry.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                industry.LastModified = DateTime.Now;
                industry.IndustryLanguageXml = industryxml;

                IndustryService.Insert(industry);
            }
            hfIndustryId.Value = industry.IndustryId.ToString();

            LoadLanguages(industry);

            ltlMessage.Text = "Industry has been updated successfully.";
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Industry.aspx");
        }

        protected void rptMultilingual_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Language")
            {
                foreach (RepeaterItem ri in rptMultilingual.Items)
                {
                    LinkButton lbLanguage = ri.FindControl("lbLanguage") as LinkButton;
                    lbLanguage.Enabled = true;

                    if (e.CommandArgument.ToString() == lbLanguage.CommandArgument.ToString())
                    {
                        lbLanguage.Enabled = false;

                        Entities.Industry industry = IndustryService.GetByIndustryId((IndustryId == 0) ? Convert.ToInt32(hfIndustryId.Value) : IndustryId);
                        XmlDocument langxml = new XmlDocument();
                        langxml.LoadXml(industry.IndustryLanguageXml);

                        XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                        foreach (XmlNode langnode in langlist)
                        {
                            if (langnode.ChildNodes[0].InnerXml == e.CommandArgument.ToString())
                            {
                                txtMultiIndustryName.Text = langnode.ChildNodes[1].InnerXml;
                            }
                        }
                    }
                    else
                    {
                        lbLanguage.Enabled = true;
                    }
                }
            }
        }

        protected void rptMultilingual_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbLanguage = e.Item.FindControl("lbLanguage") as LinkButton;

                JXTPortal.Entities.SiteLanguages lang = e.Item.DataItem as JXTPortal.Entities.SiteLanguages;

                lbLanguage.CommandArgument = lang.LanguageId.ToString();
                lbLanguage.Text = lang.SiteLanguageName;
            }
        }

        protected void btnMultilingualSave_Click(object sender, EventArgs e)
        {
            Entities.Industry industry = IndustryService.GetByIndustryId((IndustryId == 0) ? Convert.ToInt32(hfIndustryId.Value) : IndustryId);
            if (industry != null)
            {
                int langid = 0;
                string langname = string.Empty;

                foreach (RepeaterItem ri in rptMultilingual.Items)
                {
                    LinkButton lbLanguage = ri.FindControl("lbLanguage") as LinkButton;
                    if (lbLanguage.Enabled == false)
                    {
                        langid = Convert.ToInt32(lbLanguage.CommandArgument);
                        langname = lbLanguage.Text;
                    }
                }

                if (langid > 0)
                {
                    XmlDocument langxml = new XmlDocument();
                    langxml.LoadXml(industry.IndustryLanguageXml);

                    XmlNodeList langlist = langxml.GetElementsByTagName("Language");
                    foreach (XmlNode langnode in langlist)
                    {
                        if (langnode.ChildNodes[0].InnerXml == langid.ToString())
                        {
                            langnode.ChildNodes[1].InnerXml = HttpUtility.HtmlEncode(txtMultiIndustryName.Text);

                            industry.IndustryLanguageXml = langxml.InnerXml;

                            IndustryService.Update(industry);

                            ltMultilingualMessage.Text = "Industry " + HttpUtility.HtmlEncode(langname) + " has been updated.";
                            return;
                        }
                    }
                }
            }
        }
    }
}

