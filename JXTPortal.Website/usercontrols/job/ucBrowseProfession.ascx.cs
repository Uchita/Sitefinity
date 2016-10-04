using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucBrowseProfession : System.Web.UI.UserControl
    {
        #region Properties

        private SiteProfessionService _siteprofessionservice;
        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionservice == null)
                {
                    _siteprofessionservice = new SiteProfessionService();
                }
                return _siteprofessionservice;
            }
        }

        private SiteRolesService _siterolesservice;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siterolesservice == null)
                {
                    _siterolesservice = new SiteRolesService();
                }
                return _siterolesservice;
            }
        }

        private string SiteProfession
        {
            get
            {
                string _siteprofession = string.Empty;
                _siteprofession = Request.QueryString["SiteProfession"];
                return _siteprofession;
            }
        }

        private string SiteRole
        {
            get
            {
                string _siterole = string.Empty;
                _siterole = Request.QueryString["SiteRole"];
                return _siterole;
            }
        }

        private string SiteCountry
        {
            get
            {
                string _sitecountry = string.Empty;
                _sitecountry = Request.QueryString["SiteCountry"];
                return _sitecountry;
            }
        }

        private string SiteLocation
        {
            get
            {
                string _sitelocation = string.Empty;
                _sitelocation = Request.QueryString["SiteLocation"];
                return _sitelocation;
            }
        }

        private string SiteWorkType
        {
            get
            {
                string _siteworktype = string.Empty;
                _siteworktype = Request.QueryString["SiteWorkType"];
                return _siteworktype;
            }
        }

        private int PageNo
        {
            get
            {
                int _pageno = 1;
                Int32.TryParse(Request.QueryString["PageNo"], out _pageno);
                return _pageno;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProfessionRole();
            }
        }

        private void LoadProfessionRole()
        {
            if (string.IsNullOrEmpty(SiteProfession))
            {
                using (TList<Entities.SiteProfession> siteprofessions = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId))
                {
                    rptProfessionRoles.DataSource = siteprofessions;
                    rptProfessionRoles.DataBind();
                }
                ltHeader.Text = "Jobs By Classification";
            }
            else
            {
                ltHeader.Text = "Jobs By Sub-Classification";
                // Needs to update the sp
                TList<Entities.SiteProfession> siteprofessions = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId);
                siteprofessions.Filter = "SiteProfessionFriendlyUrl = " + SiteProfession;
                if (siteprofessions.Count > 0)
                {
                    int pid = siteprofessions[0].ProfessionId;
                    using (TList<Entities.SiteRoles> siteroles = SiteRolesService.GetByProfessionID(SessionData.Site.SiteId, pid))
                    {
                        if (siteroles.Count > 0)
                        {
                            rptProfessionRoles.DataSource = siteroles;
                            rptProfessionRoles.DataBind();
                        }
                    }
                }
            }
        }

        protected void rptProfessionRoles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem is Entities.SiteProfession)
                {
                    Entities.SiteProfession siteprofession = e.Item.DataItem as Entities.SiteProfession;
                    Literal ltLink = e.Item.FindControl("ltLink") as Literal;
                    ltLink.Text = string.Format(@"<a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(siteprofession.SiteProfessionFriendlyUrl, SiteRole, SiteCountry,
                        SiteLocation, SiteWorkType, 1), siteprofession.SiteProfessionName, string.Format("Browse {0} Jobs", siteprofession.SiteProfessionName));
                }
                else if (e.Item.DataItem is Entities.SiteRoles)
                {
                    Entities.SiteRoles siterole = e.Item.DataItem as Entities.SiteRoles;
                    Literal ltLink = e.Item.FindControl("ltLink") as Literal;
                    ltLink.Text = string.Format(@"<a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(SiteProfession, siterole.SiteRoleFriendlyUrl, SiteCountry,
                        SiteLocation, SiteWorkType, 1), siterole.SiteRoleName, string.Format("Browse {0} Jobs", siterole.SiteRoleName));
                }
            }
        }
    }
}