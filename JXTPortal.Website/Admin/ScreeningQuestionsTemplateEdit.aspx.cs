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

namespace JXTPortal.Website.Admin
{
    public partial class ScreeningQuestionsTemplateEdit : System.Web.UI.Page
    {
        private int _screeningQuestionsTemplateId;
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

                return _screeningQuestionsTemplateId;
            }
        }

        public IScreeningQuestionsTemplatesService ScreeningQuestionsTemplatesService { get; set; }
        public IScreeningQuestionsService ScreeningQuestionsService { get; set; }
        public IScreeningQuestionsMappingsService ScreeningQuestionsMappingsService { get; set; }
        public IScreeningQuestionsTemplateOwnersService ScreeningQuestionsTemplateOwnersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void InsertTemplate()
        {
            ScreeningQuestionsTemplatesEntity screeningQuestionsTemplate = new ScreeningQuestionsTemplatesEntity();
            screeningQuestionsTemplate.TemplateName = string.Empty;
            screeningQuestionsTemplate.SiteId = SessionData.Site.SiteId;
            screeningQuestionsTemplate.Visible = true;
            screeningQuestionsTemplate.LastModified = DateTime.Now;
            screeningQuestionsTemplate.LastModifiedBy = SessionData.AdminUser.AdminUserId;

            ScreeningQuestionsTemplatesService.Insert(screeningQuestionsTemplate);
        }

        private void UpdateTemplate(int templateId)
        {
            ScreeningQuestionsTemplatesEntity screeningQuestionsTemplate = ScreeningQuestionsTemplatesService.Select(templateId);
            if (screeningQuestionsTemplate != null)
            {
                screeningQuestionsTemplate.TemplateName = string.Empty;
                screeningQuestionsTemplate.SiteId = SessionData.Site.SiteId;
                screeningQuestionsTemplate.Visible = true;
                screeningQuestionsTemplate.LastModified = DateTime.Now;
                screeningQuestionsTemplate.LastModifiedBy = SessionData.AdminUser.AdminUserId;

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

        private void EditQuestion(int questionId)
        {
            ScreeningQuestionsEntity screeningQuestion = ScreeningQuestionsService.Select(questionId);
            if (screeningQuestion != null)
            {
                screeningQuestion.ScreeningQuestionIndex = 0;
                screeningQuestion.QuestionTitle = string.Empty;
                screeningQuestion.LanguageId = SessionData.Site.DefaultLanguageId;
                screeningQuestion.KnockoutValue = string.Empty;
                screeningQuestion.Options = string.Empty;

                ScreeningQuestionsService.Update(screeningQuestion);
            }
        }

        private void DeleteQuestion(int templateId, int questionId)
        {
            ScreeningQuestionsMappingsService.Delete(templateId, questionId);
        }

        private void InsertOwnership()
        {

        }

        private void DeleteOwnership()
        {

        }
    }
}