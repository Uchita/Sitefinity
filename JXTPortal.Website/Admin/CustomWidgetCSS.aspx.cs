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
    public partial class CustomWidgetCSS : System.Web.UI.Page
    {
        #region Properties

        private CustomWidgetCssSelectorService _CustomWidgetCssSelectorService;
        private CustomWidgetCssSelectorService CustomWidgetCssSelectorService
        {
            get
            {
                if (_CustomWidgetCssSelectorService == null) _CustomWidgetCssSelectorService = new CustomWidgetCssSelectorService();

                return _CustomWidgetCssSelectorService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Text = string.Empty;

            if (!Page.IsPostBack)
            {
                LoadCSSSelectors();
            }
        }

        private void LoadCSSSelectors()
        {
            DataSet ds = CustomWidgetCssSelectorService.CustomGetBySiteID(SessionData.Site.SiteId);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                rptCustomWidget.DataSource = ds;
                rptCustomWidget.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCSSSelector.Text) || string.IsNullOrWhiteSpace(tbCSSClassName.Text))
            {
                lblErrorMsg.Text = "CSS Selector and CSS Class Name cannot be empty.";
            }
            else
            {
                string CSSSelector = tbCSSSelector.Text.Trim();
                string CSSClassName = tbCSSClassName.Text.Trim();

                Entities.CustomWidgetCssSelector newselector = new CustomWidgetCssSelector();
                newselector.CustomWidgetCssSelectorName = CSSSelector;
                newselector.CustomWidgetCssSelectorClassName = CSSClassName;
                newselector.SiteId = SessionData.Site.SiteId;
                newselector.Active = true;
                newselector.ModifiedBy = SessionData.AdminUser.AdminUserId;
                newselector.ModifiedDate = DateTime.Now;

                // Check if name exists

                try
                {
                    DataSet ds = CustomWidgetCssSelectorService.CustomGetBySiteID(SessionData.Site.SiteId);
                    if (ds != null)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["CustomWidgetCSSSelectorName"].ToString() == CSSSelector)
                            {
                                lblErrorMsg.Text = "CSS Selector already exists.";
                                return;
                            }
                        }

                        if (CustomWidgetCssSelectorService.Insert(newselector))
                        {
                            tbCSSSelector.Text = string.Empty;
                            tbCSSClassName.Text = string.Empty;

                            LoadCSSSelectors();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.Message;
                }
            }
        }

        protected void rptCustomWidget_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox cbCSSSelector = e.Item.FindControl("cbCSSSelector") as CheckBox;
                HiddenField hfCustomWidgetCSSSelector = e.Item.FindControl("hfCustomWidgetCSSSelector") as HiddenField;
                TextBox tbCSSSelector = e.Item.FindControl("tbCSSSelector") as TextBox;
                TextBox tbCSSClassName = e.Item.FindControl("tbCSSClassName") as TextBox;
                Literal ltCount = e.Item.FindControl("ltCount") as Literal;

                DataRowView drv = e.Item.DataItem as DataRowView;
                cbCSSSelector.Checked = Convert.ToBoolean(drv["Active"]);
                hfCustomWidgetCSSSelector.Value = drv["CustomWidgetCssSelectorId"].ToString();
                tbCSSSelector.Text = drv["CustomWidgetCSSSelectorName"].ToString();
                tbCSSClassName.Text = drv["CustomWidgetCSSSelectorClassName"].ToString();
                ltCount.Text = drv["COUNT"].ToString();
                int count = Convert.ToInt32(drv["COUNT"]);

                cbCSSSelector.Enabled = (count == 0) ? true : false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve all items from repeater first
            try
            {
                List<CustomWidgetCSSSelectorClass> selectorlist = new List<CustomWidgetCSSSelectorClass>();

                foreach (RepeaterItem ri in rptCustomWidget.Items)
                {
                    CheckBox cbCSSSelector = ri.FindControl("cbCSSSelector") as CheckBox;
                    HiddenField hfCustomWidgetCSSSelector = ri.FindControl("hfCustomWidgetCSSSelector") as HiddenField;
                    TextBox tbCSSSelector = ri.FindControl("tbCSSSelector") as TextBox;
                    TextBox tbCSSClassName = ri.FindControl("tbCSSClassName") as TextBox;

                    if (string.IsNullOrWhiteSpace(tbCSSSelector.Text) || string.IsNullOrWhiteSpace(tbCSSClassName.Text))
                    {
                        lblErrorMsg.Text = "CSS Selector and CSS Class Name cannot be empty.";
                        return;
                    }

                    CustomWidgetCSSSelectorClass selector = new CustomWidgetCSSSelectorClass();
                    selector.ID = Convert.ToInt32(hfCustomWidgetCSSSelector.Value);
                    selector.CSSSelector = tbCSSSelector.Text;
                    selector.CSSClassName = tbCSSClassName.Text;

                    if (cbCSSSelector != null)
                    {
                        selector.Active = cbCSSSelector.Checked;
                    }
                    else
                    {
                        selector.Active = true;
                    }

                    foreach (CustomWidgetCSSSelectorClass cwcs in selectorlist)
                    {
                        if (cwcs.CSSSelector == selector.CSSSelector)
                        {
                            lblErrorMsg.Text = "All CSS Selector must have a unique name.";
                            return;
                        }
                    }

                    selectorlist.Add(selector);
                }

                foreach (CustomWidgetCSSSelectorClass cwcs in selectorlist)
                {
                    Entities.CustomWidgetCssSelector selector = new Entities.CustomWidgetCssSelector();
                    selector.CustomWidgetCssSelectorId = cwcs.ID;
                    selector.SiteId = SessionData.Site.SiteId;
                    selector.CustomWidgetCssSelectorName = cwcs.CSSSelector;
                    selector.CustomWidgetCssSelectorClassName = cwcs.CSSClassName;
                    selector.Active = cwcs.Active;
                    selector.ModifiedDate = DateTime.Now;
                    selector.ModifiedBy = SessionData.AdminUser.AdminUserId;
                    CustomWidgetCssSelectorService.Update(selector);
                }

                LoadCSSSelectors();
                lblErrorMsg.Text = "All CSS Selector has been updated successfully.";
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        internal class CustomWidgetCSSSelectorClass
        {
            public int ID { get; set; }
            public string CSSSelector { get; set; }
            public string CSSClassName { get; set; }
            public bool Active { get; set; }

            public CustomWidgetCSSSelectorClass() { }
        }
    }
}