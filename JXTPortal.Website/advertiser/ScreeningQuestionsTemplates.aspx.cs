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

namespace JXTPortal.Website.advertiser
{
    public partial class ScreeningQuestionsTemplates : System.Web.UI.Page
    {
        public IScreeningQuestionsTemplatesService ScreeningQuestionsTemplatesService { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Screening Questions");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCreateNewTemplate.Text = CommonFunction.GetResourceValue("LabelCreateNewTemplate");

            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

            if (!Page.IsPostBack)
            {
                LoadScreeningQuestionsTemplates();
            }
        }

        private void LoadScreeningQuestionsTemplates()
        {
            List<ScreeningQuestionsTemplatesEntity> screeningQuestionsTemplates = ScreeningQuestionsTemplatesService.SelectByCreatedByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId);

            if (screeningQuestionsTemplates.Count > 0)
            {
                rptScreeningQuestionsTemplate.DataSource = screeningQuestionsTemplates;
                rptScreeningQuestionsTemplate.DataBind();
            }
            else
            {
                rptScreeningQuestionsTemplate.DataSource = null;
                rptScreeningQuestionsTemplate.DataBind();
             
            }

        }

        protected void rptScreeningQuestionsTemplate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltTemplateName = e.Item.FindControl("ltTemplateName") as Literal;
                Literal ltVisible = e.Item.FindControl("ltVisible") as Literal;
                LinkButton lbAction = e.Item.FindControl("lbAction") as LinkButton;

                ScreeningQuestionsTemplatesEntity screeningQuestionsTemplate = e.Item.DataItem as ScreeningQuestionsTemplatesEntity;

                ltTemplateName.Text = HttpUtility.HtmlEncode(screeningQuestionsTemplate.TemplateName);
                ltVisible.Text = (screeningQuestionsTemplate.Visible) ? CommonFunction.GetResourceValue("LabelYes") : CommonFunction.GetResourceValue("LabelNo");
                lbAction.CommandArgument = screeningQuestionsTemplate.ScreeningQuestionsTemplateId.ToString();
            }
        }

        protected void rptScreeningQuestionsTemplate_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/advertiser/ScreeningQuestionTemplateEdit.aspx?ScreeningQuestionsTemplateId=" + e.CommandArgument);
            }
        }

        protected void btnCreateNewTemplate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/advertiser/ScreeningQuestionTemplateEdit.aspx");
        }
    }
}