

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
using JXTPortal;
using JXTPortal.Entities;
using System.Collections;
#endregion

public partial class Educations : System.Web.UI.Page
{
    private EducationsService _educationsservice;
    private EducationsService EducationsService
    {
        get
        {
            if (_educationsservice == null)
            {
                _educationsservice = new EducationsService();
            }
            return _educationsservice;
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
            LoadEducations();
        }
    }

    private void LoadEducations()
    {
        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        TList<JXTPortal.Entities.Educations> educations = EducationsService.GetPaged("GlobalTemplate = 1", "Sequence", CurrentPage, sitePageCount, out totalCount);
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

        rptEducation.DataSource = educations;
        rptEducation.DataBind();
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
            LoadEducations();
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

    protected void rptEducation_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Response.Redirect("~/Admin/EducationsEdit.aspx?EducationID=" + e.CommandArgument.ToString());
        }
    }

    protected void rptEducation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
            Literal litEducationName = e.Item.FindControl("litEducationName") as Literal;
            CheckBox cbGlobalTemplate = e.Item.FindControl("cbGlobalTemplate") as CheckBox;
            Literal litSequence = e.Item.FindControl("litSequence") as Literal;
            Literal litLastModified = e.Item.FindControl("litLastModified") as Literal;

            JXTPortal.Entities.Educations education = e.Item.DataItem as JXTPortal.Entities.Educations;

            lbSelect.CommandArgument = education.EducationId.ToString();
            litEducationName.Text = education.EducationName;
            cbGlobalTemplate.Checked = education.GlobalTemplate;
            litSequence.Text = education.Sequence.ToString();
            litLastModified.Text = education.LastModified.ToString(SessionData.Site.DateFormat);
        }
    }
	
}


