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
#endregion


namespace JXTPortal.Website.Admin
{
    public partial class Industry : System.Web.UI.Page
    {
        #region Properties

        IndustryService _industryService;
        IndustryService IndustryService
        {
            get
            {
                if (_industryService == null)
                {
                    _industryService = new JXTPortal.IndustryService();
                }
                return _industryService;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
            }
        }

        private void LoadForm()
        {
            using (TList<Entities.Industry> industries = IndustryService.GetBySiteId(SessionData.Site.SiteId))
            {
                lblErrorMsg.Visible = (industries.Count == 0);

                industries.Sort("Sequence");

                if (industries.Count > 0)
                {
                    rptIndustry.DataSource = industries;
                }
                else
                {
                    rptIndustry.DataSource = null;
                }
                rptIndustry.DataBind();
            }
        }

        protected void rptIndustry_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltIndustryName = e.Item.FindControl("ltIndustryName") as Literal;
                Literal ltSequence = e.Item.FindControl("ltSequence") as Literal;
                Literal ltValid = e.Item.FindControl("ltValid") as Literal;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;

                Entities.Industry industry = e.Item.DataItem as Entities.Industry;

                ltIndustryName.Text = HttpUtility.HtmlEncode(industry.IndustryName);
                ltSequence.Text = (industry.Sequence.HasValue) ? industry.Sequence.Value.ToString() : string.Empty;
                ltValid.Text = industry.Valid.ToString();
                if (industry.LastModified.HasValue)
                {
                    ltLastModified.Text = industry.LastModified.Value.ToString(SessionData.Site.DateFormat  + " hh:mm:ss tt");
                }
            }
        }
    }
}