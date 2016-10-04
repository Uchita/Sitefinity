using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Entities;
using JXTPortal;


namespace JXTPortal.Website.Admin
{
    public partial class CustomWidgetEdit : System.Web.UI.Page
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

        private AdminUsersService _AdminUsersService;
        private AdminUsersService AdminUsersService
        {
            get
            {
                if (_AdminUsersService == null) _AdminUsersService = new AdminUsersService();

                return _AdminUsersService;
            }
        }

        public int CustomWidgetID
        {
            get
            {
                int customwidgetid = 0;

                if (string.IsNullOrWhiteSpace(Request.Params["CustomWidgetID"]) == false && int.TryParse(Request.Params["CustomWidgetID"], out customwidgetid) == false)
                {
                    Response.Redirect("CustomWidget.aspx");
                }

                return customwidgetid;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCSSSelector();
                LoadCustomWidget();
            }
        }

        private void LoadCSSSelector()
        {
            ddlCSS.Items.Clear();


            CustomWidgetCssSelectorService cwcss = new CustomWidgetCssSelectorService();
            TList<CustomWidgetCssSelector> selectors = cwcss.GetBySiteId(SessionData.Site.SiteId);


            if (selectors.Count > 0)
            {
                foreach (CustomWidgetCssSelector selector in selectors)
                {
                    if (selector.Active)
                    {
                        ddlCSS.Items.Add(new ListItem(selector.CustomWidgetCssSelectorName, selector.CustomWidgetCssSelectorId.ToString()));
                    }
                }
            }

            ddlCSS.Items.Insert(0, new ListItem("Please Choose...", "0"));
        }

        private void LoadCustomWidget()
        {
            if (CustomWidgetID > 0)
            {
                Entities.CustomWidget customwidget = CustomWidgetService.GetByCustomWidgetId(CustomWidgetID);
                if (customwidget != null && customwidget.SiteId == SessionData.Site.SiteId)
                {
                    phModified.Visible = true;
                    hfCustomWidgetID.Value = CustomWidgetID.ToString();
                    tbCustomWidgetName.Text = customwidget.CustomWidgetName;
                    ddlCSS.SelectedValue = customwidget.CustomWidgetCssSelectorId.ToString();
                    txtContent.Text = customwidget.Content;
                    ltModifiedDate.Text = customwidget.ModifiedDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    cbActive.Checked = customwidget.Active;
                    Entities.AdminUsers adminuser = AdminUsersService.GetByAdminUserId(customwidget.ModifiedBy);
                    if (adminuser != null)
                    {
                        ltModifiedBy.Text = adminuser.UserName;
                    }

                    if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
                    {
                        tbCustomWidgetName.Enabled = false;
                    }
                }
                else
                {
                    Response.Redirect("CustomWidget.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            TList<Entities.CustomWidget> list = CustomWidgetService.GetBySiteId(SessionData.Site.SiteId);

            if (!string.IsNullOrWhiteSpace(hfCustomWidgetID.Value))
            {
                // Update

                foreach (Entities.CustomWidget cw in list)
                {
                    if (cw.CustomWidgetId != CustomWidgetID)
                    {
                        if (tbCustomWidgetName.Text.Trim() == cw.CustomWidgetName)
                        {
                            ltlMessage.Text = "Custom Widget Name already exists.";
                            return;
                        }
                    }
                }

                Entities.CustomWidget customwidget = CustomWidgetService.GetByCustomWidgetId(CustomWidgetID);
                if (customwidget != null && customwidget.SiteId == SessionData.Site.SiteId)
                {
                    customwidget.CustomWidgetName = tbCustomWidgetName.Text.Trim();
                    customwidget.CustomWidgetCssSelectorId = Convert.ToInt32(ddlCSS.SelectedValue);
                    customwidget.Content = txtContent.Text;
                    customwidget.ModifiedDate = DateTime.Now;
                    customwidget.ModifiedBy = SessionData.AdminUser.AdminUserId;
                    customwidget.Active = cbActive.Checked;
                    if (CustomWidgetService.Update(customwidget))
                    {
                        Response.Redirect("CustomWidget.aspx");
                    }
                }
            }
            else
            {
                // Insert

                foreach (Entities.CustomWidget cw in list)
                {
                    if (tbCustomWidgetName.Text.Trim() == cw.CustomWidgetName)
                    {
                        ltlMessage.Text = "Custom Widget Name already exists.";
                        return;
                    }
                }

                Entities.CustomWidget customwidget = new Entities.CustomWidget();

                customwidget.CustomWidgetName = tbCustomWidgetName.Text.Trim();
                customwidget.CustomWidgetCssSelectorId = Convert.ToInt32(ddlCSS.SelectedValue);
                customwidget.Content = txtContent.Text;
                customwidget.DateCreated = DateTime.Now;
                customwidget.ModifiedDate = DateTime.Now;
                customwidget.ModifiedBy = SessionData.AdminUser.AdminUserId;
                customwidget.Active = true;
                if (CustomWidgetService.Insert(customwidget))
                {
                    Response.Redirect("CustomWidget.aspx");
                }
            }


            Response.Redirect("CustomWidget.aspx");
        }

        protected void cvContent_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (string.IsNullOrWhiteSpace(txtContent.Text) == false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomWidget.aspx");
        }
    }
}