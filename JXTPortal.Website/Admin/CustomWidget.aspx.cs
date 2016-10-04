using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Entities;
using JXTPortal;

namespace JXTPortal.Website.Admin
{
    public partial class CustomWidget : System.Web.UI.Page
    {
        #region Properties

        private CustomWidgetService _CustomWidgetService;
        private CustomWidgetService CustomWidgetService
        {
            get
            {
                if (_CustomWidgetService == null) _CustomWidgetService = new CustomWidgetService();

                return _CustomWidgetService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Text = string.Empty;

            if (!Page.IsPostBack)
            {
                LoadCustomWidget();
            }
        }

        private void LoadCustomWidget()
        {
            DataSet customwidgets = CustomWidgetService.CustomGetBySiteID(SessionData.Site.SiteId);
            if (customwidgets != null)
            {
                if (customwidgets.Tables[0].Rows.Count == 0)
                {
                    lblErrorMsg.Text = "There is no Custom Widget";
                }
                else
                {
                    rptCustomWidget.DataSource = customwidgets;
                    rptCustomWidget.DataBind();
                }
            }
        }

        protected void rptCustomWidget_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView template = e.Item.DataItem as DataRowView;

                Literal ltModifiedDate = e.Item.FindControl("ltModifiedDate") as Literal;
                ltModifiedDate.Text = ((DateTime)template["ModifiedDate"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomWidgetEdit.aspx");
        }

    }
}