using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Service.Dapper;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Website.Admin
{
    public partial class ScreeningQuestionsTemplate : System.Web.UI.Page
    {
        public IScreeningQuestionsTemplatesService ScreeningQuestionsTemplatesService { get; set; }

        public ScreeningQuestionsTemplate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             List<ScreeningQuestionsTemplatesEntity> screeningQuestions = ScreeningQuestionsTemplatesService.SelectBySiteId(SessionData.Site.SiteId);

        }
    }
}