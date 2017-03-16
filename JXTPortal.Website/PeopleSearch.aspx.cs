using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website
{
    public partial class PeopleSearch : System.Web.UI.Page
    {
        #region Page Events

        #region "Properties"

        protected string DateFormat
        {
            get { return SessionData.Site.DateFormat.ToLower().Replace("yyyy", "yy"); }
        }

        private MembersService _membersService;

        private MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                    _membersService = new MembersService();

                return _membersService;
            }
        }

        private CountriesService _countriesService;
        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null)
                    _countriesService = new CountriesService();

                return _countriesService;
            }
        }

        private LocationService _locationService;
        private LocationService LocationService
        {
            get
            {
                if (_locationService == null)
                    _locationService = new LocationService();

                return _locationService;
            }
        }

        private AreaService _areaService;
        private AreaService AreaService
        {
            get
            {
                if (_areaService == null)
                    _areaService = new AreaService();

                return _areaService;
            }
        }

        private SiteProfessionService _siteprofessionService;
        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionService == null)
                    _siteprofessionService = new SiteProfessionService();

                return _siteprofessionService;
            }
        }

        private SiteRolesService _siterolesService;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siterolesService == null)
                    _siterolesService = new SiteRolesService();

                return _siterolesService;
            }
        }

        private SiteWorkTypeService _siteworktypeService;
        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeService == null)
                    _siteworktypeService = new SiteWorkTypeService();

                return _siteworktypeService;
            }
        }

        private SiteSalaryTypeService _sitesalarytypeService;
        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_sitesalarytypeService == null)
                    _sitesalarytypeService = new SiteSalaryTypeService();

                return _sitesalarytypeService;
            }
        }

        private string _currency = string.Empty;

        private string Currency
        {
            get { return _currency; }
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

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, CommonFunction.GetResourceValue("LabelPeopleSearch"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalSettingsService gservice = new GlobalSettingsService();
            //Site level flag check
            using (TList<GlobalSettings> gss = gservice.GetBySiteId(SessionData.Site.SiteId))
            {
                if (gss.Count > 0)
                {
                    if (gss[0].EnablePeopleSearch == false)
                    {
                        Response.Redirect("~/default.aspx");
                    }
                }
            }

            //Advertiser level flag check
            if (Entities.SessionData.AdvertiserUser == null || !Entities.SessionData.AdvertiserUser.AllowedToAccessPeopleSearch)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            tbKeywords.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelEnterKeywords"));
            availableDate.Attributes.Add("placeholder", CommonFunction.GetResourceValue("LabelAvailableDateFrom"));
            lbSearch.Text = CommonFunction.GetResourceValue("LabelSearch");

            if (!Page.IsPostBack)
            {
                SetLabels();
                LoadCountryLocationArea();
                LoadProfessionRoles();
                LoadWorkType();
                LoadSalary();
                LoadAvailability();
                LoadEligibleToWorkIn();
                LoadSortBy();

                CurrentPage = 0;
                Search();

                string script = "$(document).ready(function(){" +
                "var slider = new Slider('#ex2', {value: [" + hfAnnualRange.Value + "]}); var slider = new Slider('#ex3', {value: [" + hfHourlyRange.Value + "]});" +
                             "})";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Init", script, true);
            }
            else
            {
                ResetJS();
            }
        }

        private void SetLabels()
        {
            if (tbKeywords.Attributes["placeholder"] != null)
                tbKeywords.Attributes.Add("placeholder", CommonFunction.GetResourceValue(tbKeywords.Attributes["placeholder"]));
            if (availableDate.Attributes["placeholder"] != null)
                availableDate.Attributes.Add("placeholder", CommonFunction.GetResourceValue(availableDate.Attributes["placeholder"]));
        }

        private void LoadSortBy()
        {
            ddlSort.Items.Clear();

            ddlSort.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortBy") + ": " + CommonFunction.GetResourceValue("LabelRecentCandidate"), "Recent"));
            ddlSort.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortBy") + ": " + CommonFunction.GetResourceValue("LabelAlphabeticalAscending"), "AZ"));
            ddlSort.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSortBy") + ": " + CommonFunction.GetResourceValue("LabelAlphabeticalDescending"), "ZA"));
        }

        private void LoadCountryLocationArea()
        {
            List<Entities.Countries> countries = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);
            StringBuilder sbCountryCityRegion = new StringBuilder();
            sbCountryCityRegion.Append("<select id=\"ddlCountryCityRegion\" class=\"selectpicker\" multiple=\"multiple\">");
            if (countries != null)
            {
                countries = countries.Where(c => c.Sequence != -1).ToList();

                foreach (Countries country in countries)
                {
                    List<Entities.Location> locations = LocationService.GetTranslatedLocations(SessionData.Language.LanguageId, country.CountryId);

                    locations = locations.Where(l => l.Valid == true).ToList();

                    if (locations.Count > 0)
                    {
                        sbCountryCityRegion.AppendFormat("<option label=\"{0}\" disabled>{0}</option>", country.CountryName);

                        foreach (Entities.Location location in locations)
                        {
                            sbCountryCityRegion.AppendFormat("<optgroup label=\"{0}\">", location.LocationName);

                            List<Entities.Area> areas = AreaService.GetTranslatedAreas(location.LocationId, SessionData.Language.LanguageId);

                            foreach (Entities.Area area in areas)
                            {
                                sbCountryCityRegion.AppendFormat("<option value=\"{0}\">{1}</option>", area.AreaId, HttpUtility.HtmlEncode(area.AreaName));

                            }

                            sbCountryCityRegion.AppendFormat("</optgroup>", location.LocationName);
                        }
                    }
                }
            }
            sbCountryCityRegion.Append("</select>");

            ltCountryCityRegion.Text = sbCountryCityRegion.ToString();
        }

        private void LoadProfessionRoles()
        {
            List<Entities.SiteProfession> professions = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole);

            StringBuilder sbProfessionRoles = new StringBuilder();
            sbProfessionRoles.Append("<select id=\"ddlProfessionsRoles\" class=\"selectpicker\" multiple=\"multiple\">");
            foreach (Entities.SiteProfession profession in professions)
            {
                sbProfessionRoles.AppendFormat("<optgroup label=\"{0}\" class=\"titletext\">", profession.SiteProfessionName);

                List<Entities.SiteRoles> roles = SiteRolesService.GetTranslatedByProfessionID(profession.ProfessionId, SessionData.Site.UseCustomProfessionRole);
                foreach (Entities.SiteRoles role in roles)
                {
                    sbProfessionRoles.AppendFormat("<option value=\"{0}\">{1}</option>", role.RoleId, HttpUtility.HtmlEncode(role.SiteRoleName));
                }
                sbProfessionRoles.AppendFormat("</optgroup>");

            }

            sbProfessionRoles.Append("</select>");
            ltProfessionsRoles.Text = sbProfessionRoles.ToString();
        }

        private void LoadWorkType()
        {
            List<Entities.SiteWorkType> worktypes = SiteWorkTypeService.GetTranslatedWorkTypes();
            foreach (Entities.SiteWorkType worktype in worktypes)
            {
                ddlWorkType.Items.Add(new ListItem(worktype.SiteWorkTypeName, worktype.WorkTypeId.ToString()));
            }

        }

        private void LoadSalary()
        {
            List<Entities.SiteSalaryType> sitesalarytypes = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            sitesalarytypes = sitesalarytypes.Where(s => s.SalaryTypeId != (int)PortalEnums.Search.SalaryType.NA).ToList();


            foreach (Entities.SiteSalaryType sitesalarytype in sitesalarytypes)
            {
                salaryRange.Items.Add(new ListItem(SiteSalaryTypeService.Get_TranslatedSalaryType(SessionData.Site.SiteId, sitesalarytype.SalaryTypeId).SalaryTypeName, sitesalarytype.SalaryTypeId.ToString()));
            }

            salaryRange.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), ""));
            salaryRange.Items[0].Attributes.Add("disabled", "disabled");
            salaryRange.Items[0].Selected = true;
        }

        private void LoadAvailability()
        {
            Dictionary<string, int> availabilities = CommonFunction.GetEnumFormattedNames<PortalEnums.Members.CurrentlySeeking>();

            ddlStatus.Items.Clear();
            ddlStatus.DataValueField = "Value";
            ddlStatus.DataTextField = "Key";
            ddlStatus.DataSource = availabilities;
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseSelect"), ""));
        }

        private void LoadEligibleToWorkIn()
        {
            List<Entities.Countries> countries = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);
            countries = countries.Where(c => c.Sequence != -1).ToList();
            ddlEligibleToWorkIn.DataValueField = "CountryID";
            ddlEligibleToWorkIn.DataTextField = "CountryName";
            ddlEligibleToWorkIn.DataSource = countries;
            ddlEligibleToWorkIn.DataBind();
        }

        private void Search()
        {
            string keyword = tbKeywords.Text;
            string areaids = (string.IsNullOrWhiteSpace(hfCountryCityRegion.Value)) ? null : hfCountryCityRegion.Value;
            string roleids = (string.IsNullOrWhiteSpace(hfProfessionsRoles.Value)) ? null : hfProfessionsRoles.Value;
            string worktypeids = (string.IsNullOrWhiteSpace(hfWorkType.Value)) ? null : hfWorkType.Value;
            int? salartypeid = (string.IsNullOrWhiteSpace(salaryRange.SelectedValue)) ? (int?)null : Convert.ToInt32(salaryRange.SelectedValue);
            decimal? salarylowerband = (decimal?)null;
            decimal? salaryupperband = (decimal?)null;
            int? availabilityid = (string.IsNullOrWhiteSpace(ddlStatus.SelectedValue)) ? (int?)null : Convert.ToInt32(ddlStatus.SelectedValue);
            string eligibletoworkin = (string.IsNullOrWhiteSpace(hfEligibleToWorkIn.Value)) ? null : hfEligibleToWorkIn.Value;
            DateTime? availabledatefrom = (DateTime?)null;
            DateTime trydatefrom;

            if (DateTime.TryParseExact(availableDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out trydatefrom))
            {
                availabledatefrom = DateTime.ParseExact(availableDate.Text, SessionData.Site.DateFormat, null);
            }
            else
            {
                availableDate.Text = string.Empty;
            }

            if (salartypeid.HasValue)
            {
                if (salartypeid.Value == (int)PortalEnums.Search.SalaryType.Annual)
                {
                    string[] splits = hfAnnualRange.Value.Split(new char[] { ',' });
                    salarylowerband = Convert.ToDecimal(splits[0]);
                    salaryupperband = Convert.ToDecimal(splits[1]);
                }

                if (salartypeid.Value == (int)PortalEnums.Search.SalaryType.Hourly)
                {
                    string[] splits = hfHourlyRange.Value.Split(new char[] { ',' });
                    salarylowerband = Convert.ToDecimal(splits[0]);
                    salaryupperband = Convert.ToDecimal(splits[1]);
                }
            }

            System.Data.DataSet ds = MembersService.CustomPeopleSearch(keyword, SessionData.Site.SiteId, salarylowerband, salaryupperband, salartypeid, worktypeids, null, roleids, null, null, areaids, eligibletoworkin, availabledatefrom, CurrentPage, Convert.ToInt32(ddlPageSize.SelectedValue), ((ddlStatus.SelectedValue == "") ? " " : ddlStatus.SelectedValue) + ddlSort.SelectedValue);
            int resultcount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            ltResultCount.Text = resultcount.ToString();
            rptPeopleSearch.DataSource = ds.Tables[0];
            rptPeopleSearch.DataBind();

            if (resultcount <= Convert.ToInt32(ddlPageSize.SelectedValue))
            {
                phPage.Visible = false;
            }
            else
            {
                phPage.Visible = true;

                List<string> pages = new List<string>();

                if (CurrentPage > 0)
                {
                    pages.Add("prev");
                }

                int totalpage = 0;

                if (resultcount % Convert.ToInt32(ddlPageSize.SelectedValue) == 0)
                {
                    totalpage = (resultcount / Convert.ToInt32(ddlPageSize.SelectedValue));
                }
                else
                {
                    totalpage = (resultcount / Convert.ToInt32(ddlPageSize.SelectedValue) + 1);
                }


                if (CurrentPage <= (totalpage - 2) && (CurrentPage - 1) < totalpage)
                {
                    pages.Add(CurrentPage.ToString());
                    pages.Add((CurrentPage + 1).ToString());
                    pages.Add("next");
                }
                else
                {
                    pages.Add((CurrentPage - 1).ToString());
                    pages.Add(CurrentPage.ToString());
                }

                rptPage.DataSource = pages;
                rptPage.DataBind();
            }
        }

        private string RenderControl(Control control)
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }

        private void ResetJS()
        {
            salaryRange.Items[0].Attributes.Add("disabled", "disabled");

            string script = "$(document).ready(function(){" +

                "$('#ddlProfessionsRoles').multiselect(" + (!string.IsNullOrWhiteSpace(hfProfessionsRoles.Value) ? "'select', ['" + hfProfessionsRoles.Value.Replace(",", "','") + @"']" : string.Empty) + ");" +
                "$('#ddlCountryCityRegion').multiselect(" + (!string.IsNullOrWhiteSpace(hfCountryCityRegion.Value) ? "'select', ['" + hfCountryCityRegion.Value.Replace(",", "','") + @"']" : string.Empty) + ");" +
                "$('#ddlWorkType').multiselect(" + (!string.IsNullOrWhiteSpace(hfWorkType.Value) ? "'select', ['" + hfWorkType.Value.Replace(",", "','") + @"']" : string.Empty) + ");" +
                "$('#ddlEligibleToWorkIn').multiselect(" + (!string.IsNullOrWhiteSpace(hfEligibleToWorkIn.Value) ? "'select', ['" + hfEligibleToWorkIn.Value.Replace(",", "','") + @"']" : string.Empty) + ");" +
                "var slider = new Slider('#ex2', {value: [" + hfAnnualRange.Value + "]}); var slider = new Slider('#ex3', {value: [" + hfHourlyRange.Value + "]});" +
                ((string.IsNullOrWhiteSpace(salaryRange.SelectedValue)) ? string.Empty : "$('.range').hide(); $('#" + salaryRange.SelectedValue + "').show();") +
                              "})";
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "Reset", script, true);
        }

        #endregion

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            Search();
        }

        protected void rptPeopleSearch_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //define full virtual path
            var fullPath = "~/usercontrols/member/ucCVProfileDownload.ascx";

            //initialize a new page to host the control
            Page page = new Page();
            //disable event validation (this is a workaround to handle the "RegisterForEventValidation can only be called during Render()" exception)
            page.EnableEventValidation = false;

            //load the control and add it to the page's form
            JXTPortal.Website.usercontrols.member.ucCVProfileDownload control = (JXTPortal.Website.usercontrols.member.ucCVProfileDownload)page.LoadControl(fullPath);
            control.Setup(Convert.ToInt32(e.CommandArgument));
            page.Controls.Add(control);

            //call RenderControl method to get the generated HTML
            string html = RenderControl(page);

            byte[] file = new PDFCreator().ConvertHTMLToPDF(html);

            Response.AddHeader("content-disposition", @"attachment;filename=""MyFile.pdf""");

            Response.OutputStream.Write(file, 0, file.Length);
            Response.ContentType = "application/pdf";
            Response.End();

        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);

                Search();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltHead = e.Item.FindControl("ltHead") as Literal;
                Literal ltTail = e.Item.FindControl("ltTail") as Literal;
                LinkButton lbPage = e.Item.FindControl("lbPage") as LinkButton;

                string page = e.Item.DataItem as string;

                if (page == "prev" || page == "next")
                {
                    if (page == "prev")
                    {
                        ltHead.Text = "<li class=\"prev\">";
                        lbPage.Text = "«";
                        lbPage.CommandArgument = (CurrentPage - 1).ToString();
                        ltTail.Text = "</li>";
                    }

                    if (page == "next")
                    {
                        ltHead.Text = "<li class=\"next\">";
                        lbPage.Text = "»";
                        lbPage.CommandArgument = (CurrentPage + 1).ToString();
                        ltTail.Text = "</li>";
                    }
                }
                else
                {
                    if (page == CurrentPage.ToString())
                    {
                        ltHead.Text = "<li class=\"page active\">";
                    }
                    else
                    {
                        ltHead.Text = "<li class=\"page\">";
                    }

                    lbPage.Text = (Convert.ToInt32(page) + 1).ToString();
                    lbPage.CommandArgument = page;

                    ltTail.Text = "</li>";
                }
            }
        }

        protected void rptPeopleSearch_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = e.Item.DataItem as System.Data.DataRowView;

                HyperLink hlMemberPublicProfileURL = e.Item.FindControl("hlMemberPublicProfileURL") as HyperLink;
                Literal ltFirstName = e.Item.FindControl("ltFirstName") as Literal;
                Literal ltLastName = e.Item.FindControl("ltLastName") as Literal;
                Literal ltMail = e.Item.FindControl("ltMail") as Literal;
                Literal ltShortBio = e.Item.FindControl("ltShortBio") as Literal;
                Literal ltLocation = e.Item.FindControl("ltLocation") as Literal;
                Literal ltWorkType = e.Item.FindControl("ltWorkType") as Literal;
                Literal ltProfession = e.Item.FindControl("ltProfession") as Literal;
                Literal ltAvailableDate = e.Item.FindControl("ltAvailableDate") as Literal;
                Literal ltSalary = e.Item.FindControl("ltSalary") as Literal;
                Literal ltStatus = e.Item.FindControl("ltStatus") as Literal;
                Literal ltEligibleToWorkIn = e.Item.FindControl("ltEligibleToWorkIn") as Literal;
                LinkButton lbDownload = e.Item.FindControl("lbDownload") as LinkButton;

                lbDownload.Attributes.Add("title", CommonFunction.GetResourceValue("LabelDownload"));

                int memberid = Convert.ToInt32(drv["MemberID"]);
                lbDownload.CommandArgument = memberid.ToString();

                // Genrates Member Public Profile URL
                hlMemberPublicProfileURL.NavigateUrl = string.Format("/member/publicprofile.aspx?memberid={0}", memberid);

                ltFirstName.Text = HttpUtility.HtmlEncode(drv["FirstName"].ToString());
                ltLastName.Text = HttpUtility.HtmlEncode(drv["Surname"].ToString());

                ltMail.Text = string.Format("<a href=\"mailto:{0}\" class=\"btn btn-default\" title=\"Mail {1} {2}\"><i class=\"fa fa-envelope tip\"></i></a>", drv["EmailAddress"], drv["FirstName"].ToString().Replace("\"", ""), drv["Surname"].ToString().Replace("\"", ""));

                if (!string.IsNullOrWhiteSpace(drv["ShortBio"].ToString()))
                {
                    ltShortBio.Text = string.Format(@"<div class=""row"">
                                        <div class=""col-md-11 col-sm-10 view"">
                                            {0}
                                        </div>
                                    </div>
                                    ", TrimText(HttpUtility.HtmlEncode(drv["ShortBio"].ToString()).Replace("\n", "<br />"), 200));
                }

                if (!string.IsNullOrWhiteSpace(drv["LocationName"].ToString()))
                {
                    string location = drv["LocationName"].ToString();

                    ltLocation.Text = string.Format("<li class=\"view\"><span class=\"resulthead\">{0}:</span> {1}</li>", CommonFunction.GetResourceValue("LabelLocation"), TrimText(HttpUtility.HtmlEncode(location.Replace("|", ", ")), 15));
                }

                if (!string.IsNullOrWhiteSpace(drv["WorkTypeName"].ToString()))
                {
                    string worktype = drv["WorkTypeName"].ToString();

                    ltWorkType.Text = string.Format("<li class=\"view\"><span class=\"resulthead\">{0}:</span> {1}</li>", CommonFunction.GetResourceValue("LabelWorkType"), TrimText(HttpUtility.HtmlEncode(worktype.Replace("|", ", ")), 15));
                }

                if (!string.IsNullOrWhiteSpace(drv["PreferredCategoryName"].ToString()))
                {
                    string profession = drv["PreferredCategoryName"].ToString().Replace("|", ", ");

                    if (!string.IsNullOrWhiteSpace(drv["PreferredSubCategoryName"].ToString()))
                    {
                        profession += ", " + drv["PreferredSubCategoryName"].ToString().Replace("|", ", ");
                    }

                    ltProfession.Text = string.Format("<li class=\"view\"><span class=\"resulthead\">{0}:</span> {1}</li>", CommonFunction.GetResourceValue("LabelProfession"), TrimText(HttpUtility.HtmlEncode(profession), 15));
                }

                if (!string.IsNullOrWhiteSpace(drv["AvailabilityFromDate"].ToString()))
                {
                    ltAvailableDate.Text = string.Format("<li class=\"view\"><span class=\"resulthead\">{0}:</span> {1}</li>", CommonFunction.GetResourceValue("LabelAvailableDate"), Convert.ToDateTime(drv["AvailabilityFromDate"]).ToString(SessionData.Site.DateFormat));
                }

                if (!string.IsNullOrWhiteSpace(drv["PreferredSalaryId"].ToString()) && drv["PreferredSalaryId"].ToString() != "0")
                {
                    string salarytypename = string.Empty;

                    salarytypename = SiteSalaryTypeService.Get_TranslatedSalaryType(SessionData.Site.SiteId, Convert.ToInt32(drv["PreferredSalaryId"])).SalaryTypeName;

                    string lower = string.Empty;
                    string upper = string.Empty;
                    string salary = string.Empty;

                    if (!string.IsNullOrWhiteSpace(drv["PreferredSalaryFrom"].ToString()))
                    {
                        lower = drv["Currency"].ToString() + drv["PreferredSalaryFrom"].ToString();
                        salary = lower;
                    }

                    if (!string.IsNullOrWhiteSpace(drv["PreferredSalaryTo"].ToString()))
                    {
                        if (!string.IsNullOrWhiteSpace(salary))
                        {
                            salary += " - ";
                        }

                        upper = drv["Currency"].ToString() + drv["PreferredSalaryTo"].ToString();

                        salary += upper;
                    }

                    ltSalary.Text = string.Format("<li class=\"view\"><span class=\"resulthead\">{0}:</span> {1}</li>", HttpUtility.HtmlEncode(salarytypename), TrimText(HttpUtility.HtmlEncode(salary), 15));
                }

                if (!string.IsNullOrWhiteSpace(drv["AvailabilityID"].ToString()) && drv["AvailabilityID"].ToString() != "0" && Convert.ToInt32(drv["AvailabilityID"]) <= 3)
                {
                    ltStatus.Text = string.Format("<li class=\"view\"><span class=\"resulthead\">{0}:</span> {1}</li>", CommonFunction.GetResourceValue("LabelStatus"), TrimText(HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.CurrentlySeeking)Convert.ToInt32(drv["AvailabilityId"])))), 15));
                }

                if (!string.IsNullOrWhiteSpace(drv["EligibleToWorkIn"].ToString()))
                {
                    string[] splits = drv["EligibleToWorkIn"].ToString().Split(new char[] { ',' });
                    string eligibletoworkin = string.Empty;


                    foreach (string s in splits)
                    {
                        eligibletoworkin += CountriesService.GetTranslatedCountry(Convert.ToInt32(s), SessionData.Language.LanguageId).CountryName + ", ";
                    }

                    ltEligibleToWorkIn.Text = string.Format("<li class=\"view\"><span class=\"resulthead\">{0}:</span> {1}</li>", CommonFunction.GetResourceValue("LabelEligibleToWorkIn"), TrimText(HttpUtility.HtmlEncode(eligibletoworkin.TrimEnd(new char[] { ' ', ',' })), 15));
                }
            }
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = 0;
            Search();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = 0;
            Search();
        }

        private string TrimText(string text, int limit)
        {
            if (text.Length > limit)
            {
                int index = text.IndexOfAny(new char[] { ' ', '\n', '　', '。', '，' }, limit);

                if (index > 0 && index != text.Length - 1)
                {
                    text = string.Format(@"{0}<a class=""toggle"" data-toggle=""tooltip"" data-placement=""top"" data-original-title=""expand listing"" >...</a>
                                                <div class=""content"">
                                            {1}
                                            </div>", text.Substring(0, index), text.Substring(index));
                }
            }

            return text;
        }

    }
}
