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

public partial class Members : System.Web.UI.Page
{
    #region Properties

    MembersService _membersService;
    MembersService MembersService
    {
        get
        {
            if (_membersService == null)
            {
                _membersService = new JXTPortal.MembersService();
            }
            return _membersService;
        }
    }

    private SitesService _sitesService;
    private SitesService SitesService
    {
        get
        {
            if (_sitesService == null) _sitesService = new SitesService();

            return _sitesService;
        }
    }

    private SiteProfessionService _siteProfessionService;
    private SiteProfessionService SiteProfessionService
    {
        get
        {
            if (_siteProfessionService == null) _siteProfessionService = new SiteProfessionService();

            return _siteProfessionService;
        }
    }

    private SiteRolesService _siteRolesService;
    private SiteRolesService SiteRolesService
    {
        get
        {
            if (_siteRolesService == null) _siteRolesService = new SiteRolesService();

            return _siteRolesService;
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

    #endregion

    #region Return Properties

    public int? _memberID
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdminMemberListingMemberID.Text.Trim()))
            {
                return Convert.ToInt32(txtAdminMemberListingMemberID.Text.Trim());
            }
            return null;
        }
    }

    public int? _siteID
    {
        get
        {
            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
            {
                return Convert.ToInt32(SessionData.Site.SiteId);
            }

            if (!Page.IsPostBack)
            {
                return Convert.ToInt32(SessionData.Site.SiteId);
            }

            if (ddlSite.SelectedItem != null && ddlSite.SelectedValue.Length > 0 && Convert.ToInt32(ddlSite.SelectedValue) > 0)
            {
                return Convert.ToInt32(ddlSite.SelectedValue);
            }
            return null;
        }
    }

    public string _firstName
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdminMemberListingFirstname.Text.Trim()))
            {
                return txtAdminMemberListingFirstname.Text.Trim();
            }
            return null;
        }
    }

    public string _surname
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdminListingSurname.Text.Trim()))
            {
                return txtAdminListingSurname.Text.Trim();
            }
            return null;
        }
    }

    public string _emailAddress
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdminListingEmail.Text.Trim()))
            {
                return txtAdminListingEmail.Text.Trim();
            }
            return null;
        }
    }

    public string _username
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdminMemberListingUsername.Text.Trim()))
            {
                return txtAdminMemberListingUsername.Text.Trim();
            }
            return null;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        revEmailAddress.ValidationExpression = ConfigurationManager.AppSettings["EmailValidationRegex"];

        if (!IsPostBack)
        {
            loadSites();
            loadForm();
        }

        ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnDownload);
    }

    #endregion

    #region Events

    protected void rptAdminMembers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltViewMember = e.Item.FindControl("ltViewMember") as Literal;
            Literal ltAdminMemberID = e.Item.FindControl("ltAdminMemberID") as Literal;
            Literal ltAdminMemberFirstName = e.Item.FindControl("ltAdminMemberFirstName") as Literal;
            Literal ltAdminMemberSurname = e.Item.FindControl("ltAdminMemberSurname") as Literal;
            Literal ltAdminMemberUsername = e.Item.FindControl("ltAdminMemberUsername") as Literal;
            Literal ltAdminMemberEmail = e.Item.FindControl("ltAdminMemberEmail") as Literal;
            Literal ltAdminMemberIsValidated = e.Item.FindControl("ltAdminMemberIsValidated") as Literal;
            Literal ltAdminMemberEmailFormat = e.Item.FindControl("ltAdminMemberEmailFormat") as Literal;
            Literal ltAdminMembersRegisteredDate = e.Item.FindControl("ltAdminMembersRegisteredDate") as Literal;

            DataRowView members = (DataRowView)e.Item.DataItem;
            ltViewMember.Text = "Select";
            ltAdminMemberID.Text = HttpUtility.HtmlEncode(Convert.ToString(members["MemberID"]));
            ltAdminMemberFirstName.Text = HttpUtility.HtmlEncode(Convert.ToString(members["FirstName"]));
            ltAdminMemberSurname.Text = HttpUtility.HtmlEncode(Convert.ToString(members["Surname"]));
            ltAdminMemberUsername.Text = HttpUtility.HtmlEncode(Convert.ToString(members["Username"]));
            ltAdminMemberEmail.Text = HttpUtility.HtmlEncode(Convert.ToString(members["EmailAddress"]));
            ltAdminMemberIsValidated.Text = Convert.ToString(members["Validated"]);
            ltAdminMemberEmailFormat.Text = Convert.ToString(members["EmailFormatName"]);
            ltAdminMembersRegisteredDate.Text = string.Format("{0:"+SessionData.Site.DateFormat + "}", members["RegisteredDate"]);
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

    #region Method

    protected void loadForm()
    {
        //if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != 1)
        //{
        //    pnlSiteID.Visible = false;
        //}        

        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        //Site drop down is pre selected as per siteID
        if (!Page.IsPostBack)
            ddlSite.SelectedValue = Convert.ToString(SessionData.Site.SiteId);
        else
        {
            //is post back, ie clicking the search button

            //non admin users will always be searching in their own site
            if (!SessionData.AdminUser.isAdminUser)
                ddlSite.SelectedValue = Convert.ToString(SessionData.Site.SiteId);
        }

        using (DataSet objMembers = MembersService.AdminGetPaged(_memberID, _siteID, _firstName, _surname, _emailAddress, _username,
              sitePageCount, CurrentPage + 1))
        {
            if (objMembers.Tables[0].Rows.Count > 0)
            {
                lblErrorMsg.Visible = false;

                ArrayList pagelist = new ArrayList();
                totalCount = Convert.ToInt32(objMembers.Tables[0].Rows[0]["TotalCount"]);

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

                rptAdminMembers.DataSource = objMembers;
                rptAdminMembers.DataBind();
                btnDownload.Visible = true;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnDownload);
            }
            else
            {
                btnDownload.Visible = false;
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "No result Found";
                rptAdminMembers.DataSource = null;
                rptAdminMembers.DataBind();
                rptPage.DataSource = null;
                rptPage.DataBind();
            }
        }
    }

    private void loadSites()
    {
        List<JXTPortal.Entities.Sites> sites = new List<JXTPortal.Entities.Sites>();
        if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser)
        {
            sites = SitesService.GetAll().OrderBy(s => s.SiteName).ToList();
        }
        else
        {
            sites.Add(SitesService.GetBySiteId(SessionData.Site.SiteId));
        }

        ddlSite.DataSource = sites;
        ddlSite.DataTextField = "SiteName";
        ddlSite.DataValueField = "SiteID";
        ddlSite.DataBind();

        if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser)
            ddlSite.Items.Insert(0, new ListItem("-All-", "0"));
    }

    #endregion

    #region Click Event handlers

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            CurrentPage = 0;
            loadForm();
        }
    }


    protected void btnDownload_Click(object sender, EventArgs e)
    {
        TList<JXTPortal.Entities.SiteProfession> siteprofession = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId);
        TList<JXTPortal.Entities.SiteRoles> siteroles = SiteRolesService.GetBySiteId(SessionData.Site.SiteId);

        using (DataSet objMembers = MembersService.AdminGetPaged(_memberID, _siteID, _firstName, _surname, _emailAddress, _username,
              Int32.MaxValue, CurrentPage + 1))
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Members.csv");
            Response.Charset = "";

            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "text/csv";

            Response.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}\n", "MemberID", "First Name", "Surname", "Username", "Email Address", "Phone", "Address", "Suburb", "State", "Postcode", "Country", "Add Mailing Address", "Mailing Address", "Mailing Suburb", "Mailing State", "Mailing Postcode", "Mailing Country", "Email Format", "Is Validated", "Category", "Sub Category", "Document Uploaded", "Registration Date"));

            foreach (DataRow dr in objMembers.Tables[0].Rows)
            {
                Response.Write(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\"\n", dr["MemberID"].ToString()
                    , dr["FirstName"].ToString().Replace("\"", "\"\"")
                    , dr["Surname"].ToString().Replace("\"", "\"\"")
                    , dr["Username"].ToString().Replace("\"", "\"\"")
                    , dr["EmailAddress"].ToString().Replace("\"", "\"\"")
                    , (dr["HomePhone"] != DBNull.Value) ? dr["HomePhone"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (dr["Address1"] != DBNull.Value) ? dr["Address1"].ToString().Replace("\"", "\"\"").Trim().Replace("\n", " ").Replace("\r", " ").Replace("\t", " ") : string.Empty
                    , (dr["Suburb"] != DBNull.Value) ? dr["Suburb"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (dr["States"] != DBNull.Value) ? dr["States"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (dr["Postcode"] != DBNull.Value) ? dr["Postcode"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (dr["CountryName"] != DBNull.Value) ? dr["CountryName"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (string.IsNullOrWhiteSpace(dr["MailingAddress1"].ToString().Replace("\"", "\"\""))) ? "No" : "Yes"
                    , (dr["MailingAddress1"] != DBNull.Value) ? dr["MailingAddress1"].ToString().Trim().Replace("\n", " ").Replace("\r", " ").Replace("\t", " ").Replace("\"", "\"\"") : string.Empty
                    , (dr["MailingSuburb"] != DBNull.Value) ? dr["MailingSuburb"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (dr["MailingStates"] != DBNull.Value) ? dr["MailingStates"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (dr["MailingPostcode"] != DBNull.Value) ? dr["MailingPostcode"].ToString().Replace("\"", "\"\"") : string.Empty
                    , (dr["MailingCountryName"] != DBNull.Value) ? dr["MailingCountryName"].ToString().Replace("\"", "\"\"") : string.Empty
                    , dr["EmailFormatName"].ToString().Replace("\"", "\"\"")
                    , (dr["Validated"].ToString() == "FALSE") ? "No" : "Yes"
                    , (dr["PreferredCategoryID"] != DBNull.Value) ? ConverToProfessionString(dr["PreferredCategoryID"].ToString().Replace("\"", "\"\""), siteprofession) : string.Empty
                    , (dr["PreferredSubCategoryID"] != DBNull.Value) ? ConverToRolesString(dr["PreferredSubCategoryID"].ToString().Replace("\"", "\"\""), siteroles) : string.Empty
                    , (dr["FileCount"].ToString() == "") ? "No" : "Yes"
                    , ((DateTime)dr["RegisteredDate"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt")));
            }

            Response.End();
        }
    }

    private string ConverToProfessionString(string strprofession, TList<JXTPortal.Entities.SiteProfession> professionlist)
    {
        string value = string.Empty;

        if (!string.IsNullOrWhiteSpace(strprofession))
        {
            string[] professions = strprofession.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string professionid in professions)
            {
                foreach (JXTPortal.Entities.SiteProfession siteprofession in professionlist)
                {
                    if (professionid == siteprofession.ProfessionId.ToString())
                    {
                        value += siteprofession.SiteProfessionName + ",";
                        break;
                    }
                }
            }
        }

        return value.TrimEnd(new char[] { ',' });
    }

    private string ConverToRolesString(string strrole, TList<JXTPortal.Entities.SiteRoles> rolelist)
    {
        string value = string.Empty;

        if (!string.IsNullOrWhiteSpace(strrole))
        {
            string[] roles = strrole.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string professionid in roles)
            {
                foreach (JXTPortal.Entities.SiteRoles siteproles in rolelist)
                {
                    if (professionid == siteproles.RoleId.ToString())
                    {
                        value += siteproles.SiteRoleName + ",";
                        break;
                    }
                }
            }
        }

        return value.TrimEnd(new char[] { ',' });
    }

    #endregion



}


