using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace JXTPortal.Website.Admin
{
    public partial class CustomQuestions : System.Web.UI.Page
    {
        private MemberWizardService _memberWizardService = null;
        private MemberWizardService MemberWizardService
        {
            get
            {
                if (_memberWizardService == null)
                    _memberWizardService = new MemberWizardService();
                return _memberWizardService;
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
                LoadMemberWizard();
            }
        }

        private int LoadLanguages(int customquestionid)
        {
            int langid = 0;
            if (customquestionid > 0)
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

                    // AssignMultilingualValues(Convert.ToInt32(lbLanguage.CommandArgument));
                }
            }

            return langid;
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            phOptions.Visible = (ddlType.SelectedValue == "dropdown" || ddlType.SelectedValue == "multiselect" || ddlType.SelectedValue == "radio");
        }

        protected void rptConsultants_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CustomQuestion customquestion = e.Item.DataItem as CustomQuestion;

                Literal ltQuestionTitle = e.Item.FindControl("ltQuestionTitle") as Literal;
                Literal ltQuestionType = e.Item.FindControl("ltQuestionType") as Literal;
                Literal ltMandatory = e.Item.FindControl("ltMandatory") as Literal;
                Literal ltSequence = e.Item.FindControl("ltSequence") as Literal;
                LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;

                lbSelect.CommandArgument = customquestion.Id.ToString();
                ltQuestionTitle.Text = customquestion.Title;
                ltQuestionType.Text = customquestion.Type;
                ltMandatory.Text = customquestion.Mandatory.ToString();
                ltSequence.Text = customquestion.Sequence.ToString();

                lbDelete.CommandArgument = customquestion.Id.ToString();
            }
        }

        protected void rptConsultants_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            TList<Entities.MemberWizard> memberwizardlist = MemberWizardService.GetBySiteId(SessionData.Site.SiteId);
            memberwizardlist.Filter = "GlobalTemplate = false";
            List<CustomQuestion> customquestionlist = new List<CustomQuestion>();
            ltlMessage.Text = string.Empty;
            if (memberwizardlist.Count > 0)
            {
                Entities.MemberWizard memberwizard = memberwizardlist[0];
                string customquestionxml = memberwizard.CustomQuestionsXml;

                try
                {
                    if (!string.IsNullOrWhiteSpace(customquestionxml))
                    {
                        XmlDocument customquestions = new XmlDocument();
                        customquestions.LoadXml(customquestionxml);

                        if (e.CommandName == "Select")
                        {
                            foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                            {
                                if (questionnode["Status"].InnerXml == "1" && questionnode["Id"].InnerXml == e.CommandArgument.ToString())
                                {
                                    ltInfo.Text = "Edit Custom Question";
                                    ddlType.Enabled = false;

                                    int langid = LoadLanguages(Convert.ToInt32(questionnode["Id"].InnerXml));

                                    XmlNode languagesnode = questionnode["Languages"];
                                    foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                                    {
                                        if (languagenode["Id"].InnerXml == SessionData.Site.DefaultLanguageId.ToString())
                                        {
                                            List<string> parameters = new List<string>();

                                            tbTitle.Text = HttpUtility.HtmlDecode(languagenode["Title"].InnerXml);
                                            string parametersstring = string.Empty;

                                            XmlNode paramsnode = languagenode.SelectSingleNode("Parameters");
                                            if (!string.IsNullOrWhiteSpace(paramsnode.InnerXml))
                                            {
                                                foreach (XmlNode itemnode in paramsnode.SelectNodes("Item"))
                                                {
                                                    parametersstring += HttpUtility.HtmlDecode(itemnode.InnerXml) + ",";

                                                }
                                            }
                                            tbOptions.Text = parametersstring.TrimEnd(new char[] { ',' });
                                        }

                                        if (languagenode["Id"].InnerXml == langid.ToString())
                                        {
                                            txtMultiTitle.Text = HttpUtility.HtmlDecode(languagenode["Title"].InnerXml);
                                            string parametersstring = string.Empty;

                                            XmlNode paramsnode = languagenode.SelectSingleNode("Parameters");
                                            if (!string.IsNullOrWhiteSpace(paramsnode.InnerXml))
                                            {
                                                foreach (XmlNode itemnode in paramsnode.SelectNodes("Item"))
                                                {
                                                    parametersstring += HttpUtility.HtmlDecode(itemnode.InnerXml) + ",";

                                                }
                                            }
                                            txtMultiOptions.Text = parametersstring.TrimEnd(new char[] { ',' });
                                        }

                                    }

                                    ddlType.SelectedValue = questionnode["Type"].InnerXml;
                                    tbSequence.Text = questionnode["Sequence"].InnerXml;
                                    cbMandatory.Checked = Convert.ToBoolean(questionnode["Mandatory"].InnerXml);
                                    btnAdd.Visible = false;
                                    btnSave.Visible = true;
                                    btnCancel.Visible = true;
                                    phOptions.Visible = (ddlType.SelectedValue == "dropdown" || ddlType.SelectedValue == "multiselect" || ddlType.SelectedValue == "radio");
                                    hfCustomQuestionId.Value = questionnode["Id"].InnerXml;
                                    phMultilingualOptions.Visible = (ddlType.SelectedValue == "dropdown" || ddlType.SelectedValue == "multiselect" || ddlType.SelectedValue == "radio");
                                }
                            }
                        }

                        if (e.CommandName == "Delete")
                        {
                            foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                            {
                                if (questionnode["Status"].InnerXml == "1" && questionnode["Id"].InnerXml == e.CommandArgument.ToString())
                                {
                                    questionnode["Status"].InnerXml = "0";

                                    memberwizard.CustomQuestionsXml = customquestions.InnerXml;
                                    MemberWizardService.Update(memberwizard);

                                    LoadMemberWizard();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                }
            }
            else
            {
                Response.Redirect("/admin/memberwizard.aspx");
            }

        }

        private void LoadMemberWizard()
        {
            TList<Entities.MemberWizard> memberwizardlist = MemberWizardService.GetBySiteId(SessionData.Site.SiteId);
            memberwizardlist.Filter = "GlobalTemplate = false";
            List<CustomQuestion> customquestionlist = new List<CustomQuestion>();

            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            tbTitle.Text = string.Empty;
            ddlType.SelectedIndex = 0;
            ddlType.Enabled = true;
            tbOptions.Text = string.Empty;
            phOptions.Visible = false;
            tbSequence.Text = string.Empty;
            cbMandatory.Checked = false;
            phMultilingual.Visible = false;
            hfCustomQuestionId.Value = string.Empty;
            ltInfo.Text = "Add Custom Question";

            if (memberwizardlist.Count > 0)
            {
                Entities.MemberWizard memberwizard = memberwizardlist[0];
                string customquestionxml = memberwizard.CustomQuestionsXml;

                if (memberwizard.CustomQuestionPoints < 0)
                {
                    Response.Redirect("/admin/memberwizard.aspx");
                }

                try
                {
                    if (!string.IsNullOrWhiteSpace(customquestionxml))
                    {
                        XmlDocument customquestions = new XmlDocument();
                        customquestions.LoadXml(customquestionxml);

                        foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                        {
                            if (questionnode["Status"].InnerXml == "1")
                            {
                                CustomQuestion customquestion = new CustomQuestion();

                                customquestion.Id = Convert.ToInt32(questionnode["Id"].InnerXml);

                                XmlNode languagesnode = questionnode["Languages"];
                                foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                                {
                                    if (languagenode["Id"].InnerXml == SessionData.Site.DefaultLanguageId.ToString())
                                    {
                                        List<string> parameters = new List<string>();

                                        customquestion.Title = languagenode["Title"].InnerXml;

                                        XmlNode paramsnode = languagenode.SelectSingleNode("Parameters");
                                        if (!string.IsNullOrWhiteSpace(paramsnode.InnerXml))
                                        {
                                            foreach (XmlNode itemnode in paramsnode.SelectNodes("Item"))
                                            {
                                                parameters.Add(itemnode.InnerXml);
                                            }
                                        }
                                        customquestion.Parameters = parameters;


                                        break;
                                    }
                                }

                                customquestion.Type = questionnode["Type"].InnerXml;
                                customquestion.Sequence = Convert.ToInt32(questionnode["Sequence"].InnerXml);
                                customquestion.Mandatory = Convert.ToBoolean(questionnode["Mandatory"].InnerXml);
                                customquestion.Status = Convert.ToInt32(questionnode["Status"].InnerXml);
                                if (customquestion.Status == 1)
                                {
                                    customquestionlist.Add(customquestion);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                }

                if (customquestionlist.Count == 0)
                {
                    lblErrorMsg.Visible = true;
                }
                else
                {
                    customquestionlist.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                    rptConsultants.DataSource = customquestionlist;
                    rptConsultants.DataBind();
                }
            }
            else
            {
                Response.Redirect("/admin/memberwizard.aspx");
            }
        }

        protected void rptMultilingual_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ltMultilingualMessage.Text = string.Empty;
            if (e.CommandName == "Language")
            {
                foreach (RepeaterItem ri in rptMultilingual.Items)
                {
                    LinkButton lbLanguage = ri.FindControl("lbLanguage") as LinkButton;
                    lbLanguage.Enabled = true;

                    if (e.CommandArgument.ToString() == lbLanguage.CommandArgument.ToString())
                    {
                        lbLanguage.Enabled = false;

                        TList<Entities.MemberWizard> memberwizardlist = MemberWizardService.GetBySiteId(SessionData.Site.SiteId);
                        memberwizardlist.Filter = "GlobalTemplate = false";
                        List<CustomQuestion> customquestionlist = new List<CustomQuestion>();

                        if (memberwizardlist.Count > 0)
                        {
                            Entities.MemberWizard memberwizard = memberwizardlist[0];
                            string customquestionxml = memberwizard.CustomQuestionsXml;

                            try
                            {
                                if (!string.IsNullOrWhiteSpace(customquestionxml))
                                {
                                    XmlDocument customquestions = new XmlDocument();
                                    customquestions.LoadXml(customquestionxml);

                                    foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                                    {
                                        if (questionnode["Status"].InnerXml == "1" && questionnode["Id"].InnerXml == hfCustomQuestionId.Value)
                                        {
                                            ddlType.Enabled = false;

                                            XmlNode languagesnode = questionnode["Languages"];
                                            foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                                            {
                                                if (languagenode["Id"].InnerXml == e.CommandArgument.ToString())
                                                {
                                                    txtMultiTitle.Text = HttpUtility.HtmlDecode(languagenode["Title"].InnerXml);
                                                    string parametersstring = string.Empty;

                                                    XmlNode paramsnode = languagenode.SelectSingleNode("Parameters");
                                                    if (!string.IsNullOrWhiteSpace(paramsnode.InnerXml))
                                                    {
                                                        foreach (XmlNode itemnode in paramsnode.SelectNodes("Item"))
                                                        {
                                                            parametersstring += HttpUtility.HtmlDecode(itemnode.InnerXml) + ",";

                                                        }
                                                    }
                                                    txtMultiOptions.Text = parametersstring.TrimEnd(new char[] { ',' });
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ltMultilingualMessage.Text = ex.Message;
                            }
                        }
                        else
                        {
                            Response.Redirect("/admin/memberwizard.aspx");
                        }
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
            TList<Entities.MemberWizard> memberwizardlist = MemberWizardService.GetBySiteId(SessionData.Site.SiteId);
            memberwizardlist.Filter = "GlobalTemplate = false";
            List<CustomQuestion> customquestionlist = new List<CustomQuestion>();

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

            if (memberwizardlist.Count > 0)
            {
                Entities.MemberWizard memberwizard = memberwizardlist[0];
                string customquestionxml = memberwizard.CustomQuestionsXml;

                TList<Entities.SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);

                XmlDocument customquestions = new XmlDocument();
                if (!string.IsNullOrWhiteSpace(customquestionxml))
                {
                    customquestions.LoadXml(customquestionxml);
                }

                try
                {
                    if (!string.IsNullOrWhiteSpace(customquestionxml))
                    {
                        if (!string.IsNullOrWhiteSpace(hfCustomQuestionId.Value))
                        {
                            foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                            {
                                if (hfCustomQuestionId.Value == questionnode["Id"].InnerXml)
                                {
                                    XmlNode languagesnode = questionnode.SelectSingleNode("Languages");
                                    string langxml = string.Empty;
                                    int itemscount = 0;

                                    foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                                    {
                                        if (languagenode["Id"].InnerXml == SessionData.Site.DefaultLanguageId.ToString())
                                        {
                                            XmlNode parametersndoe = languagenode["Parameters"];

                                            itemscount = parametersndoe.ChildNodes.Count;

                                            break;
                                        }
                                    }

                                    if (string.IsNullOrWhiteSpace(txtMultiTitle.Text))
                                    {
                                        ltMultilingualMessage.Text = "Error - Title is mandatory";
                                        return;
                                    }

                                    Regex regex = new Regex("(\".*?\"|[^\",\\s]+)(?=\\s*,|\\s*$)");
                                    if (itemscount != regex.Matches(txtMultiOptions.Text).Count)
                                    {
                                        ltMultilingualMessage.Text = "Error - Options count does not match, please match with - <i>" + tbOptions.Text + "</i>";
                                        return;
                                    }

                                    foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                                    {
                                        if (languagenode["Id"].InnerXml == langid.ToString())
                                        {
                                            langxml += string.Format("<Id>{0}</Id>", langid);
                                            langxml += string.Format("<Title>{0}</Title>", HttpUtility.HtmlEncode(txtMultiTitle.Text));
                                            if (string.IsNullOrWhiteSpace(tbOptions.Text) || ddlType.SelectedValue == "textbox" || ddlType.SelectedValue == "textarea")
                                            {
                                                langxml += string.Format("<Parameters />");
                                            }
                                            else
                                            {
                                                langxml += string.Format("<Parameters>");
                                                string str = txtMultiOptions.Text;

                                                foreach (Match m in regex.Matches(str))
                                                {
                                                    langxml += string.Format("<Item>{0}</Item>", HttpUtility.HtmlEncode(m.Value));
                                                }
                                                langxml += string.Format("</Parameters>");
                                            }

                                            languagenode.InnerXml = langxml;
                                        }
                                    }

                                    memberwizard.CustomQuestionsXml = customquestions.InnerXml;
                                    MemberWizardService.Update(memberwizard);

                                    ltMultilingualMessage.Text = "Custom Question for " + HttpUtility.HtmlEncode(langname) + " has been updated.";
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ltMultilingualMessage.Text = ex.Message;
                }
            }
        }

        internal class CustomQuestion
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
            public List<string> Parameters { get; set; }
            public int Sequence { get; set; }
            public bool Mandatory { get; set; }
            public int Status { get; set; }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ltlMessage.Text = string.Empty;
            LoadMemberWizard();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ltlMessage.Text = string.Empty;
            TList<Entities.MemberWizard> memberwizardlist = MemberWizardService.GetBySiteId(SessionData.Site.SiteId);
            memberwizardlist.Filter = "GlobalTemplate = false";
            int newid = 1;
            List<CustomQuestion> customquestionlist = new List<CustomQuestion>();

            if (memberwizardlist.Count > 0)
            {
                Entities.MemberWizard memberwizard = memberwizardlist[0];
                string customquestionxml = memberwizard.CustomQuestionsXml;

                TList<Entities.SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);

                XmlDocument customquestions = new XmlDocument();
                if (!string.IsNullOrWhiteSpace(customquestionxml))
                {
                    customquestions.LoadXml(customquestionxml);
                }

                try
                {
                    if (string.IsNullOrWhiteSpace(customquestionxml))
                    {
                        customquestions.LoadXml("<CustomQuestions></CustomQuestions>");
                    }


                    XmlNode questionsnode = customquestions.SelectSingleNode("CustomQuestions");
                    XmlElement newquestion = customquestions.CreateElement("Question");


                    if (questionsnode.ChildNodes.Count > 0)
                    {
                        newid = Convert.ToInt32(questionsnode.LastChild["Id"].InnerXml) + 1;
                    }
                    newquestion.InnerXml += string.Format("<Id>{0}</Id>", newid);
                    newquestion.InnerXml += string.Format("<Type>{0}</Type>", HttpUtility.HtmlEncode(ddlType.SelectedValue));

                    newquestion.InnerXml += string.Format("<Sequence>{0}</Sequence>", tbSequence.Text);
                    newquestion.InnerXml += string.Format("<Mandatory>{0}</Mandatory>", cbMandatory.Checked);
                    newquestion.InnerXml += string.Format("<Status>1</Status>");

                    string languagexml = string.Empty;

                    languagexml += "<Languages>";
                    foreach (SiteLanguages sl in sitelanguages)
                    {
                        languagexml += "<Language>";
                        languagexml += string.Format("<Id>{0}</Id>", sl.LanguageId);
                        languagexml += string.Format("<Title>{0}</Title>", HttpUtility.HtmlEncode(tbTitle.Text));
                        if (string.IsNullOrWhiteSpace(tbOptions.Text) || ddlType.SelectedValue == "textbox" || ddlType.SelectedValue == "textarea")
                        {
                            languagexml += string.Format("<Parameters />");
                        }
                        else
                        {
                            languagexml += string.Format("<Parameters>");
                            string str = tbOptions.Text;
                            Regex regex = new Regex("(\".*?\"|[^\",\\s]+)(?=\\s*,|\\s*$)");
                            foreach (Match m in regex.Matches(str))
                            {
                                languagexml += string.Format("<Item>{0}</Item>", HttpUtility.HtmlEncode(m.Value));
                            }
                            languagexml += string.Format("</Parameters>");
                        }
                        languagexml += "</Language>";
                    }

                    languagexml += "</Languages>";
                    newquestion.InnerXml += languagexml;


                    questionsnode.AppendChild(newquestion);

                    memberwizard.CustomQuestionsXml = customquestions.InnerXml;
                    MemberWizardService.Update(memberwizard);

                    LoadMemberWizard();

                    ltlMessage.Text = "Custom Question has been added.";

                    //foreach (RepeaterItem ri in rptConsultants.Items)
                    //{
                    //    LinkButton lbSelect = ri.FindControl("lbSelect") as LinkButton;
                    //    if (lbSelect.CommandArgument == newid.ToString())
                    //    {
                    //        rptConsultants_ItemCommand(lbSelect, new RepeaterCommandEventArgs(ri, rptConsultants, new CommandEventArgs(lbSelect.CommandName, lbSelect.CommandArgument)));

                    //        break;
                    //    }
                    //}

                    btnAdd.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;

                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ltlMessage.Text = string.Empty;
            TList<Entities.MemberWizard> memberwizardlist = MemberWizardService.GetBySiteId(SessionData.Site.SiteId);
            memberwizardlist.Filter = "GlobalTemplate = false";
            int newid = 1;
            List<CustomQuestion> customquestionlist = new List<CustomQuestion>();

            if (memberwizardlist.Count > 0)
            {
                Entities.MemberWizard memberwizard = memberwizardlist[0];
                string customquestionxml = memberwizard.CustomQuestionsXml;

                TList<Entities.SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);

                XmlDocument customquestions = new XmlDocument();
                if (!string.IsNullOrWhiteSpace(customquestionxml))
                {
                    customquestions.LoadXml(customquestionxml);
                }

                try
                {
                    if (!string.IsNullOrWhiteSpace(customquestionxml))
                    {
                        bool found = false;

                        foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                        {
                            if (hfCustomQuestionId.Value == questionnode["Id"].InnerXml)
                            {
                                found = true;
                                XmlNode languagesnode = questionnode.SelectSingleNode("Languages");
                                string langxml = string.Empty;
                                foreach (SiteLanguages sl in sitelanguages)
                                {
                                    langxml += "<Language>";
                                    langxml += string.Format("<Id>{0}</Id>", sl.LanguageId);
                                    langxml += string.Format("<Title>{0}</Title>", HttpUtility.HtmlEncode(tbTitle.Text));

                                    if (string.IsNullOrWhiteSpace(tbOptions.Text) || ddlType.SelectedValue == "textbox" || ddlType.SelectedValue == "textarea")
                                    {
                                        langxml += string.Format("<Parameters />");
                                    }
                                    else
                                    {
                                        langxml += string.Format("<Parameters>");

                                        Regex regex = new Regex("(\".*?\"|[^\",\\s]+)(?=\\s*,|\\s*$)");
                                        foreach (Match m in regex.Matches(tbOptions.Text))
                                        {
                                            langxml += string.Format("<Item>{0}</Item>", HttpUtility.HtmlEncode(m.Value));
                                        }
                                        langxml += string.Format("</Parameters>");
                                    }
                                    langxml += "</Language>";
                                }

                                languagesnode.InnerXml = langxml;

                                questionnode["Type"].InnerXml = HttpUtility.HtmlEncode(ddlType.SelectedValue);
                                questionnode["Sequence"].InnerXml = tbSequence.Text;
                                questionnode["Mandatory"].InnerXml = Convert.ToBoolean(cbMandatory.Checked).ToString();

                                memberwizard.CustomQuestionsXml = customquestions.InnerXml;
                                MemberWizardService.Update(memberwizard);
                                ltlMessage.Text = "Custom Question has been updated.";
                                LoadMemberWizard();
                            }
                        }

                        if (!found)
                        {
                            // error
                        }
                    }
                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
            }
        }
    }
}