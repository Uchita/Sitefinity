

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal;
using System.Collections;
#endregion

public partial class AdvertiserBusinessType : System.Web.UI.Page
{
    JXTPortal.AdvertiserBusinessTypeService _advertiserbusinesstypeService;
    JXTPortal.AdvertiserBusinessTypeService AdvertiserBusinessTypeService
    {
        get
        {
            if (_advertiserbusinesstypeService == null)
            {
                _advertiserbusinesstypeService = new JXTPortal.AdvertiserBusinessTypeService();
            }
            return _advertiserbusinesstypeService;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadBusinessType();
        }
    }

    private void LoadBusinessType()
    {
        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        TList<JXTPortal.Entities.AdvertiserBusinessType> businesstypes = AdvertiserBusinessTypeService.GetDefaultBusinessTypes();
        totalCount = businesstypes.Count;
        //TList<JXTPortal.Entities.Educations> educations = EducationsService.GetPaged("", "Sequence", CurrentPage, sitePageCount, out totalCount);

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

        rptBusinessType.DataSource = businesstypes;
        rptBusinessType.DataBind();
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
            LoadBusinessType();
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

    protected void rptBusinessType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Response.Redirect("~/Admin/AdvertiserBusinessTypeEdit.aspx?AdvertiserBusinessTypeID=" + e.CommandArgument.ToString());
        }
    }

    protected void rptBusinessType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
            Literal litBusinessTypeName = e.Item.FindControl("litBusinessTypeName") as Literal;
            CheckBox cbGlobalTemplate = e.Item.FindControl("cbGlobalTemplate") as CheckBox;
            Literal litSequence = e.Item.FindControl("litSequence") as Literal;
            Literal litLastModified = e.Item.FindControl("litLastModified") as Literal;

            JXTPortal.Entities.AdvertiserBusinessType businesstype = e.Item.DataItem as JXTPortal.Entities.AdvertiserBusinessType;

            lbSelect.CommandArgument = businesstype.AdvertiserBusinessTypeId.ToString();
            litBusinessTypeName.Text = businesstype.AdvertiserBusinessTypeName;
            cbGlobalTemplate.Checked = businesstype.GlobalTemplate;
            litSequence.Text = businesstype.Sequence.ToString();
            if (businesstype.LastModifiedDate.HasValue)
            {
                litLastModified.Text = businesstype.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat);
            }
        }
    }
	
}


