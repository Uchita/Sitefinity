#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using System.Collections;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class Consultants : System.Web.UI.Page
    {
        private ConsultantsService _consultantsservice;
        private ConsultantsService ConsultantsService
        {
            get
            {
                if (_consultantsservice == null)
                {
                    _consultantsservice = new ConsultantsService();
                }
                return _consultantsservice;
            }
        }

        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
            }

        }
        public string defaultSortOrder = "ConsultantID";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LoadConsultants(defaultSortOrder);
            }
        }

        private void LoadConsultants(String sortingOrder)
        {
            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

            string filter = string.Empty;

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                filter += " AND (FirstName LIKE '%" + tbName.Text.Replace("'", "''") + "%' OR LastName LIKE '%" + tbName.Text.Replace("'", "''") + "%')";
            }

            if (!string.IsNullOrWhiteSpace(tbPositionTitle.Text))
            {
                filter += " AND PositionTitle LIKE '%" + tbPositionTitle.Text.Replace("'", "''") + "%'";
            }

            if (ddlStatus.SelectedValue != "0")
            {
                filter += " AND PositionTitle = " + ddlStatus.SelectedValue.ToString();
            }


            TList<JXTPortal.Entities.Consultants> consultants = ConsultantsService.GetPaged("SiteId = " + SessionData.Site.SiteId.ToString() + filter, sortingOrder, CurrentPage, sitePageCount, out totalCount);

            if (totalCount > 0)
            {
                ArrayList pagelist = new ArrayList();

                if (totalCount % sitePageCount == 0)
                    pageCount = totalCount / sitePageCount;
                else
                    pageCount = (totalCount / sitePageCount) + 1;


                if (CurrentPage >= 10)
                {
                    pagelist.Add("previous");
                }

                int index = (CurrentPage == 0) ? 0 : (CurrentPage) / 10 * 10;
                for (int i = index; i < pageCount; i++)
                {
                    pagelist.Add(i.ToString());

                    if ((i % 10) == 9 && (i < pageCount - 1))
                    {
                        pagelist.Add("next");
                        break;
                    }

                }

                if (pagelist.Count > 1)
                {
                    rptPage.DataSource = pagelist;
                    rptPage.DataBind();
                    rptPage.Visible = true;
                }
                else
                {
                    rptPage.Visible = false;
                }
            }
            else
            {
                lblErrorMsg.Visible = true;
                rptConsultants.Visible = false;
            }
            rptConsultants.DataSource = consultants;
            rptConsultants.DataBind();
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                if (e.CommandArgument.ToString() == "prev")
                {
                    CurrentPage = ((CurrentPage + 1) / 10 * 10 - 1);
                }
                else if (e.CommandArgument.ToString() == "next")
                {
                    CurrentPage = ((CurrentPage + 10) / 10 * 10);
                }
                else
                {
                    CurrentPage = Convert.ToInt32(e.CommandArgument);
                }

                LoadConsultants(defaultSortOrder);
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;

                if (e.Item.DataItem.ToString() == "previous")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "prev";
                }
                else if (e.Item.DataItem.ToString() == "next")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "next";
                }
                else
                {
                    lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                    lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();
                }

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                    lbPageNo.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void rptConsultants_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string OrderByFirstName = "FirstName";
            string OrderByLastName = "LastName";
            string OrderByEmail = "Email";
            string OrderByPositionTitle = "PositionTitle";
            string OrderByStatus = "Valid";
            string OrderByLastModified = "LastModified";


            if (e.CommandName == "Select")
            {
                Response.Redirect("~/Admin/ConsultantsEdit.aspx?ConsultantID=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Delete")
            {
                int consultantid = Convert.ToInt32(e.CommandArgument);

                using (Entities.Consultants consultant = ConsultantsService.GetByConsultantId(consultantid))
                {
                    if (consultant != null && consultant.SiteId == SessionData.Site.SiteId)
                    {
                        ConsultantsService.Delete(consultant);
                        LoadConsultants(defaultSortOrder);
                    }
                    else
                    {
                        Response.Redirect("/admin/consultants.aspx");
                    }
                }
            }

            if (e.CommandName == "FirstName")
            {
                LoadConsultants(OrderByFirstName);
            }

            if (e.CommandName == "LastName")
            {
                LoadConsultants(OrderByLastName);
            }

            if (e.CommandName == "Email")
            {
                LoadConsultants(OrderByEmail);
            }

            if (e.CommandName == "PositionTitle")
            {
                LoadConsultants(OrderByPositionTitle);
            }

            if (e.CommandName == "Status")
            {
                LoadConsultants(OrderByStatus);
            }

            if (e.CommandName == "LastModified")
            {
                LoadConsultants(OrderByLastModified);
            }
        }

        protected void rptConsultants_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;
                Literal ltName = e.Item.FindControl("ltName") as Literal;
                Literal ltLastName = e.Item.FindControl("ltLastName") as Literal;
                Literal ltEmail = e.Item.FindControl("ltEmail") as Literal;
                Literal ltPositionTitle = e.Item.FindControl("ltPositionTitle") as Literal;
                Literal ltStatus = e.Item.FindControl("ltStatus") as Literal;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;

                LinkButton lbSortFirstName = e.Item.FindControl("lbSortFirstName") as LinkButton;
                LinkButton lbSortLastName = e.Item.FindControl("lbSortLastName") as LinkButton;
                LinkButton lbSortEmail = e.Item.FindControl("lbSortEmail") as LinkButton;
                LinkButton lbSortPositionTitle = e.Item.FindControl("lbSortPositionTitle") as LinkButton;
                LinkButton lbSortStatus = e.Item.FindControl("lbSortStatus") as LinkButton;
                LinkButton lbSortLastModified = e.Item.FindControl("lbSortLastModified") as LinkButton;

                JXTPortal.Entities.Consultants consultant = e.Item.DataItem as JXTPortal.Entities.Consultants;

                lbSelect.CommandArgument = consultant.ConsultantId.ToString();
                lbDelete.CommandArgument = consultant.ConsultantId.ToString();
                ltName.Text = HttpUtility.HtmlEncode(consultant.FirstName);
                ltLastName.Text = HttpUtility.HtmlEncode(consultant.LastName);
                ltEmail.Text = HttpUtility.HtmlEncode(consultant.Email);
                ltPositionTitle.Text = HttpUtility.HtmlEncode(consultant.PositionTitle);
                ltStatus.Text = ((PortalEnums.Admin.ConsultantStatus)consultant.Valid).ToString();
                if (consultant.LastModified.HasValue)
                {
                    ltLastModified.Text = consultant.LastModified.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadConsultants(defaultSortOrder);
        }

    }
}
