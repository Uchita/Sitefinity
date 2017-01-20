using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Service.Dapper;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;
using JXTPortal.Service.Dapper.Models;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Website.advertiser
{
    public partial class ScreeningQuestionTemplateEdit : System.Web.UI.Page
    {
        private int _screeningQuestionsTemplateId = 0;
        protected int ScreeningQuestionsTemplateId
        {
            get
            {
                if ((Request.QueryString["ScreeningQuestionsTemplateId"] != null))
                {
                    if (int.TryParse((Request.QueryString["ScreeningQuestionsTemplateId"].Trim()), out _screeningQuestionsTemplateId))
                    {
                        _screeningQuestionsTemplateId = Convert.ToInt32(Request.QueryString["ScreeningQuestionsTemplateId"]);
                    }
                    return _screeningQuestionsTemplateId;
                }
                else
                {
                    if (ViewState["ScreeningQuestionsTemplateId"] != null)
                    {
                        return Convert.ToInt32(ViewState["ScreeningQuestionsTemplateId"]);
                    }
                }
                return _screeningQuestionsTemplateId;
            }
        }

        public IScreeningQuestionsTemplatesService ScreeningQuestionsTemplatesService { get; set; }
        public IScreeningQuestionsService ScreeningQuestionsService { get; set; }
        public IScreeningQuestionsMappingsService ScreeningQuestionsMappingsService { get; set; }
        public IScreeningQuestionsTemplateOwnersService ScreeningQuestionsTemplateOwnersService { get; set; }
        public IAdvertisersService AdvertisersService { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Screening Questions - Add/Edit");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = CommonFunction.GetResourceValue("LabelAdd");

            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

            if (!Page.IsPostBack)
            {
                LoadQuestionType();
                LoadTemplate();
            }
        }

        private void LoadQuestionType()
        {
            ddlType.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelTextBox"), "1"));
            ddlType.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelTextArea"), "2"));
            ddlType.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelDropdown"), "3"));
            ddlType.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelMultiSelect"), "4"));
            ddlType.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelRadioButtons"), "5"));
        }

        private void InsertTemplate()
        {
            ScreeningQuestionsTemplatesEntity screeningQuestionsTemplate = new ScreeningQuestionsTemplatesEntity();
            screeningQuestionsTemplate.TemplateName = tbTemplateName.Text;
            screeningQuestionsTemplate.SiteId = SessionData.Site.SiteId;
            screeningQuestionsTemplate.Visible = true;
            screeningQuestionsTemplate.CreatedByAdvertiserId = SessionData.AdvertiserUser.AdvertiserId;
            screeningQuestionsTemplate.LastModified = DateTime.Now;


            int newScreeningQuestionsTemplateId = ScreeningQuestionsTemplatesService.Insert(screeningQuestionsTemplate);
            ViewState["ScreeningQuestionsTemplateId"] = newScreeningQuestionsTemplateId;

            ScreeningQuestionsTemplateOwnersService.Insert(new ScreeningQuestionsTemplateOwnersEntity { 
                                                                    AdvertiserId = SessionData.AdvertiserUser.AdvertiserId,
                                                                    ScreeningQuestionsTemplateId = newScreeningQuestionsTemplateId
            });

            phScreeningQuestions.Visible = true;

        }

        private void UpdateTemplate(int templateId)
        {
            ScreeningQuestionsTemplatesEntity screeningQuestionsTemplate = ScreeningQuestionsTemplatesService.Select(templateId);
            if (screeningQuestionsTemplate != null)
            {
                screeningQuestionsTemplate.TemplateName = tbTemplateName.Text;
                screeningQuestionsTemplate.SiteId = SessionData.Site.SiteId;
                screeningQuestionsTemplate.Visible = true;
                screeningQuestionsTemplate.LastModified = DateTime.Now;

                ScreeningQuestionsTemplatesService.Update(screeningQuestionsTemplate);
            }
        }

        private void InsertQuestion()
        {
            ScreeningQuestionsEntity screeningQuestion = new ScreeningQuestionsEntity();
            screeningQuestion.ScreeningQuestionIndex = 0;
            screeningQuestion.QuestionTitle = string.Empty;
            screeningQuestion.LanguageId = SessionData.Site.DefaultLanguageId;
            screeningQuestion.KnockoutValue = string.Empty;
            screeningQuestion.Options = string.Empty;

            ScreeningQuestionsService.Insert(screeningQuestion);

        }

        private void DeleteQuestion(int templateId, int questionId)
        {
            ScreeningQuestionsMappingsService.Delete(templateId, questionId);
        }

        private void InsertOwnership()
        {
            ScreeningQuestionsTemplateOwnersService.Insert(new ScreeningQuestionsTemplateOwnersEntity
            {
                ScreeningQuestionsTemplateId = ScreeningQuestionsTemplateId,
                AdvertiserId = 0,
            });

        }

        private void DeleteOwnership(int templateId, int advertiserId)
        {
            ScreeningQuestionsTemplateOwnersService.Delete(templateId, advertiserId);
        }

        private void LoadTemplate()
        {
            if (ScreeningQuestionsTemplateId > 0)
            {
                ScreeningQuestionsTemplatesEntity screeningQuestionsTemplate = ScreeningQuestionsTemplatesService.Select(ScreeningQuestionsTemplateId);
                if (screeningQuestionsTemplate != null && screeningQuestionsTemplate.CreatedByAdvertiserId.HasValue && screeningQuestionsTemplate.CreatedByAdvertiserId.Value == SessionData.AdvertiserUser.AdvertiserId)
                {
                    tbTemplateName.Text = screeningQuestionsTemplate.TemplateName;
                    cbVisible.Checked = screeningQuestionsTemplate.Visible;
                    phScreeningQuestions.Visible = true;

                    btnSubmit.Text = CommonFunction.GetResourceValue("LabelSave");

                    LoadQuestions(SessionData.Site.DefaultLanguageId);
                }
                else
                {
                    Response.Redirect("/advertiser/ScreeningQuestionsTemplate.aspx");
                }
            }
        }

        private void LoadQuestions(int languageId)
        {
            if (ScreeningQuestionsTemplateId > 0)
            {
                List<ScreeningQuestionsEntity> screeningQuestions = ScreeningQuestionsService.SelectByScreeningQuestionsTemplateIdLanguageId(ScreeningQuestionsTemplateId, languageId);

                rptScreeningQuestions.DataSource = (screeningQuestions.Count > 0) ? screeningQuestions : null;
                rptScreeningQuestions.DataBind();
            }
            else
            {
                rptScreeningQuestions.DataSource = null;
                rptScreeningQuestions.DataBind();
            }
        }

        protected void rptScreeningQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal ltScreeningQuestions = e.Item.FindControl("ltScreeningQuestions") as Literal;
                ltScreeningQuestions.Text = HttpUtility.HtmlEncode(CommonFunction.GetResourceValue("LabelScreeningQuestions"));
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
                Literal ltSequence = e.Item.FindControl("ltSequence") as Literal;
                Literal ltQuestionType = e.Item.FindControl("ltQuestionType") as Literal;
                Literal ltQuestionTitle = e.Item.FindControl("ltQuestionTitle") as Literal;
                Literal ltMandatory = e.Item.FindControl("ltMandatory") as Literal;
                Literal ltVisible = e.Item.FindControl("ltVisible") as Literal;

                ScreeningQuestionsEntity screeningQuestion = e.Item.DataItem as ScreeningQuestionsEntity;
                lbSelect.CommandArgument = screeningQuestion.ScreeningQuestionId.ToString();
                ltSequence.Text = screeningQuestion.ScreeningQuestionIndex.ToString();
                ltQuestionType.Text = CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Jobs.ScreeningQuestionsType)screeningQuestion.QuestionType));
                ltQuestionTitle.Text = HttpUtility.HtmlEncode(screeningQuestion.QuestionTitle.ToString());
                ltMandatory.Text = (screeningQuestion.Mandatory) ? CommonFunction.GetResourceValue("LabelYes") : CommonFunction.GetResourceValue("LabelNo");
                ltVisible.Text = (screeningQuestion.Visible) ? CommonFunction.GetResourceValue("LabelYes") : CommonFunction.GetResourceValue("LabelNo");
            }
        }


        protected void rptAdvertiser_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;
                Literal ltAdvertiserID = e.Item.FindControl("ltAdvertiserID") as Literal;
                Literal ltCompanyName = e.Item.FindControl("ltCompanyName") as Literal;

                AdvertisersEntity advertiser = e.Item.DataItem as AdvertisersEntity;

                lbDelete.CommandArgument = advertiser.AdvertiserID.ToString();
                ltAdvertiserID.Text = advertiser.AdvertiserID.ToString();
                ltCompanyName.Text = HttpUtility.HtmlEncode(advertiser.CompanyName);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ScreeningQuestionsEntity screeningQuestion = ScreeningQuestionsService.Select(Convert.ToInt32(hfScreeningQuestionId.Value));

            if (screeningQuestion != null)
            {
                screeningQuestion.QuestionTitle = tbTitle.Text;
                screeningQuestion.QuestionType = Convert.ToInt32(ddlType.SelectedValue);
                screeningQuestion.ScreeningQuestionIndex = Convert.ToInt32(tbSequence.Text);
                screeningQuestion.Options = tbOptions.Text;
                screeningQuestion.Mandatory = cbMandatory.Checked;
                screeningQuestion.Visible = cbQuestionVisible.Checked;
                screeningQuestion.LanguageId = SessionData.Site.DefaultLanguageId;
                screeningQuestion.LastModified = DateTime.Now;

                ScreeningQuestionsService.Update(screeningQuestion);

                ltAddScreeningQuestions.Text = CommonFunction.GetResourceValue("LabelAddScreeningQuestions");

                tbTitle.Text = string.Empty;
                ddlType.SelectedIndex = 0;
                tbSequence.Text = string.Empty;
                tbOptions.Text = string.Empty;
                cbMandatory.Checked = false;
                cbQuestionVisible.Checked = true;

                btnAdd.Visible = true;
                btnSave.Visible = false;
                btnCancel.Visible = false;

                LoadQuestions(SessionData.Site.DefaultLanguageId);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ltAddScreeningQuestions.Text = CommonFunction.GetResourceValue("LabelAddScreeningQuestions");

            tbTitle.Text = string.Empty;
            ddlType.SelectedIndex = 0;
            tbSequence.Text = string.Empty;
            tbOptions.Text = string.Empty;
            cbMandatory.Checked = false;
            cbQuestionVisible.Checked = true;

            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            phOptions.Visible = false;
        }

        protected void rptScreeningQuestions_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                ltAddScreeningQuestions.Text = CommonFunction.GetResourceValue("LabelEditScreeningQuestions");

                btnAdd.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;

                ScreeningQuestionsEntity screeningQuestion = ScreeningQuestionsService.Select(Convert.ToInt32(e.CommandArgument));
                if (screeningQuestion != null)
                {
                    hfScreeningQuestionId.Value = screeningQuestion.ScreeningQuestionId.ToString();
                    tbTitle.Text = screeningQuestion.QuestionTitle;
                    ddlType.SelectedValue = screeningQuestion.QuestionType.ToString();
                    tbSequence.Text = screeningQuestion.ScreeningQuestionIndex.ToString();
                    tbOptions.Text = screeningQuestion.Options;
                    cbMandatory.Checked = screeningQuestion.Mandatory;
                    cbQuestionVisible.Checked = screeningQuestion.Visible;

                    phOptions.Visible = (screeningQuestion.QuestionType > (int)PortalEnums.Jobs.ScreeningQuestionsType.TextArea);

                }
                else
                {
                    Response.Redirect("/advertiser/ScreeningQuestionsTemplates.aspx");
                }
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            phOptions.Visible = (Convert.ToInt32(ddlType.SelectedValue) > (int)PortalEnums.Jobs.ScreeningQuestionsType.TextArea);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ScreeningQuestionsEntity screeningQuestion = new ScreeningQuestionsEntity
            {
                QuestionTitle = tbTitle.Text,
                QuestionType = Convert.ToInt32(ddlType.SelectedValue),
                ScreeningQuestionIndex = Convert.ToInt32(tbSequence.Text),
                Options = tbOptions.Text,
                Mandatory = cbMandatory.Checked,
                Visible = cbQuestionVisible.Checked,
                LanguageId = SessionData.Site.DefaultLanguageId,
                LastModified = DateTime.Now
            };

            int screeningQuestionId = ScreeningQuestionsService.Insert(screeningQuestion);

            ScreeningQuestionsMappingsService.Insert(new ScreeningQuestionsMappingsEntity
            {
                ScreeningQuestionId = screeningQuestionId,
                ScreeningQuestionsTemplateId = ScreeningQuestionsTemplateId
            });

            tbTitle.Text = string.Empty;
            ddlType.SelectedIndex = 0;
            tbSequence.Text = string.Empty;
            tbOptions.Text = string.Empty;
            cbMandatory.Checked = false;
            cbQuestionVisible.Checked = true;

            LoadQuestions(SessionData.Site.DefaultLanguageId);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ScreeningQuestionsTemplateId > 0)
            {
                UpdateTemplate(ScreeningQuestionsTemplateId);
            }
            else
            {
                InsertTemplate();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/advertiser/ScreeningQuestionsTemplates.aspx");
        }
    }
}