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
    public partial class ucBrowseWorkType : System.Web.UI.UserControl
    {
        #region Properties

        private SiteWorkTypeService _siteworktypeservice;
        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeservice == null)
                {
                    _siteworktypeservice = new SiteWorkTypeService();
                }
                return _siteworktypeservice;
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
                LoadWrokType();
            }
        }

        private void LoadWrokType()
        {
            using (TList<Entities.SiteWorkType> siteworktypes = SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
            {
                rptWorkType.DataSource = siteworktypes;
                rptWorkType.DataBind();
            }

        }

        protected void rptWorkType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.SiteWorkType siteworktype = e.Item.DataItem as Entities.SiteWorkType;
                Literal ltLink = e.Item.FindControl("ltLink") as Literal;
                ltLink.Text = string.Format(@"<a href='{0}' title='{2}'>{1}</a>", Utils.GetJobBrowseUrl(SiteProfession, SiteRole, SiteCountry,
                    SiteLocation, siteworktype.SiteWorkTypeFriendlyUrl, 1), siteworktype.SiteWorkTypeName, string.Format("Browse {0} Jobs", siteworktype.SiteWorkTypeName));

            }
        }
    }
}