using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class KnowledgeBaseView : System.Web.UI.Page
    {
        #region Property

        public IKnowledgeBaseRepository KnowledgeBaseRepository { get; set; }

        private int Id
        {
            get
            {
                int _id = 0;
                if ((Request.QueryString["Id"] != null))
                {
                    if (int.TryParse((Request.QueryString["Id"].Trim()), out _id))
                    {
                        _id = Convert.ToInt32(Request.QueryString["Id"]);
                    }
                    return _id;
                }
                return _id;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadForm();
            }
        }

        protected void LoadForm()
        {
            if (Id > 0)
            {
                var entity = KnowledgeBaseRepository.Select(Id);
                if (entity != null && entity.Valid)
                {
                    ltSubject.Text = entity.Subject;
                    ltKnowledgeBaseContent.Text = entity.Content;
                    ltDate.Text = String.Format("Modified On: {0:" + SessionData.Site.DateFormat + " hh:mm:ss tt" + "}", entity.LastModified);
                }
                else
                {
                    Response.Redirect("KnowledgeBaseBrowse.aspx");
                }
            }
        }
    }
}