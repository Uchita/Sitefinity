

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
#endregion

public partial class AvailableStatus : System.Web.UI.Page
{
    #region Properties

    JXTPortal.AvailableStatusService _availableStatusService;
    JXTPortal.AvailableStatusService AvailableStatusService
    {
        get
        {
            if (_availableStatusService == null)
            {
                _availableStatusService = new JXTPortal.AvailableStatusService();
            }
            return _availableStatusService;
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

    private TList<JXTPortal.Entities.AvailableStatus> availableStatus;
    

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
	{
        if (!IsPostBack)
        {
            loadForm();
        }
    }

    #endregion

    #region Methods

    protected void loadForm()
    {
        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        using (availableStatus = AvailableStatusService.GetPaged("GlobalTemplate = 1", "Sequence", CurrentPage, sitePageCount, out totalCount))
        {
            if (availableStatus.Count > 0)
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

                rptAdminAvailableStatus.Visible = true;
                rptAdminAvailableStatus.DataSource = availableStatus;
                rptAdminAvailableStatus.DataBind();
            }
            else
            {
                rptAdminAvailableStatus.Visible = false;
                rptAdminAvailableStatus.DataSource = null;
                rptAdminAvailableStatus.DataBind();
                rptPage.Visible = false;
                rptPage.DataSource = null;
                rptPage.DataBind();
                
            }
        }
    }

    protected void rptAdminAvailableStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltAdminAvailableStatusView = e.Item.FindControl("ltAdminAvailableStatusView") as Literal;
            Literal ltAdminAvailableStatusName = e.Item.FindControl("ltAdminAvailableStatusName") as Literal;
            CheckBox chkAvailableGlobalTemplate = e.Item.FindControl("chkAvailableGlobalTemplate") as CheckBox;
            //Literal ltAdminAvailableStatusSequence = e.Item.FindControl("ltAdminAvailableStatusSequence") as Literal;
            Literal ltAdminAvailableStatusLastModified = e.Item.FindControl("ltAdminAvailableStatusLastModified") as Literal;

            using (JXTPortal.Entities.AvailableStatus availableStatus = e.Item.DataItem as JXTPortal.Entities.AvailableStatus)
            {
                ltAdminAvailableStatusView.Text = "View";
                ltAdminAvailableStatusName.Text = availableStatus.AvailableStatusName;
                chkAvailableGlobalTemplate.Checked = availableStatus.GlobalTemplate;
                //ltAdminAvailableStatusSequence.Text = Convert.ToString(availableStatus.Sequence);
                ltAdminAvailableStatusLastModified.Text = string.Format("{0:"+ SessionData.Site.DateFormat + "}", availableStatus.LastModified);
            }
        }
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
            loadForm();
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

    #endregion
	
}


