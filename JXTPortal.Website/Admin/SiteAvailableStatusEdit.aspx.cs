using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal;
using JXTPortal.Entities;


namespace JXTPortal.Website.Admin
{
    public partial class SiteAvailableStatusEdit : System.Web.UI.Page
    {
        #region Declarations

        private int _parentAvailableStatusId = 0;
        private AvailableStatusService _availableStatusService;

        #endregion

        #region Properties

        private int ParentAvailableStatusId
        {
            get
            {
                if ((Request.QueryString["ParentAvailableStatusID"] != null))
                {
                    if (int.TryParse((Request.QueryString["ParentAvailableStatusID"].Trim()), out _parentAvailableStatusId))
                    {
                        _parentAvailableStatusId = Convert.ToInt32(Request.QueryString["ParentAvailableStatusID"]);
                    }
                    return _parentAvailableStatusId;
                }

                return _parentAvailableStatusId;
            }
        }

        private AvailableStatusService AvailableStatusService
        {
            get
            {
                if (_availableStatusService == null)
                {
                    _availableStatusService = new AvailableStatusService();
                }
                return _availableStatusService;
            }
        }

        private int SiteAvailableStatusId
        {
            get
            {
                TList<JXTPortal.Entities.AvailableStatus> availableStatus = AvailableStatusService.Find(string.Format("SiteID={0} AND AvailableStatusParentID={1}", SessionData.Site.SiteId, ParentAvailableStatusId));

                if (availableStatus.Count > 0)
                {
                    return availableStatus[0].AvailableStatusId;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region Page Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ParentAvailableStatusId > 0)
                {
                    LoadDefaultAvailableStatus();
                    LoadSiteAvailableStatus();
                }
                else
                {
                    Response.Redirect("SiteAvailableStatus.aspx");
                }
            }

            btnUseDefault.Attributes.Add("onclick", "return confirm('Are you sure you wish to discard your changes?');");
        }

        #endregion

        #region Methods

        private void LoadDefaultAvailableStatus()
        {
            using (JXTPortal.Entities.AvailableStatus objAvailableStatus = AvailableStatusService.GetByAvailableStatusId(ParentAvailableStatusId))
            {
                if (objAvailableStatus != null)
                {
                    lblDefaultAvailableStatusName.Text = objAvailableStatus.AvailableStatusName;
                }
                else
                {
                    Response.Redirect("SiteAvailableStatus.aspx");
                }

            }

        }

        private void LoadSiteAvailableStatus()
        {
            using (TList<JXTPortal.Entities.AvailableStatus> objSiteAvailableStatus = AvailableStatusService.GetBySiteId(SessionData.Site.SiteId))
            {
                objSiteAvailableStatus.Filter = "AvailableStatusParentID = " + ParentAvailableStatusId.ToString();
                btnUseDefault.Visible = (objSiteAvailableStatus.Count > 0);

                if (objSiteAvailableStatus.Count > 0)
                {
                    using (JXTPortal.Entities.AvailableStatus siteavailablestatus = objSiteAvailableStatus[0])
                    {
                        
                        lbCurrentLastModified.Text = siteavailablestatus.LastModified.ToString("dd/MM/yyyy hh:mm:ss tt");
                        AdminUsersService adminUser = new AdminUsersService();
                        using (JXTPortal.Entities.AdminUsers adminuser = adminUser.GetByAdminUserId(siteavailablestatus.LastModifiedBy))
                        {
                            lbCurrentModifiedBy.Text = adminuser.UserName;
                        }

                        txtNewAvailableStatusName.Text = siteavailablestatus.AvailableStatusName;
                    }
                }

                else
                {
                    objSiteAvailableStatus.Filter = "AvailableStatusID = " + ParentAvailableStatusId.ToString();
                    if (objSiteAvailableStatus.Count > 0)
                    {
                        using (JXTPortal.Entities.AvailableStatus siteavailablestatus = objSiteAvailableStatus[0])
                        {

                            lbCurrentLastModified.Text = siteavailablestatus.LastModified.ToString("dd/MM/yyyy hh:mm:ss tt");
                            AdminUsersService adminUser = new AdminUsersService();
                            using (JXTPortal.Entities.AdminUsers adminuser = adminUser.GetByAdminUserId(siteavailablestatus.LastModifiedBy))
                            {
                                lbCurrentModifiedBy.Text = adminuser.UserName;
                            }

                            txtNewAvailableStatusName.Text = siteavailablestatus.AvailableStatusName;
                        }
                    }
                }
            }
        }

        #endregion

        #region Click Event handlers

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteAvailableStatus.aspx");
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            using (JXTPortal.Entities.AvailableStatus availablestatusEdit = new JXTPortal.Entities.AvailableStatus())
            {
                availablestatusEdit.AvailableStatusId = SiteAvailableStatusId;
                availablestatusEdit.SiteId = SessionData.Site.SiteId;

                availablestatusEdit.AvailableStatusParentId = ParentAvailableStatusId;
                availablestatusEdit.AvailableStatusName = txtNewAvailableStatusName.Text;

                if (SiteAvailableStatusId > 0)
                {
                    AvailableStatusService.Update(availablestatusEdit);
                }
                else
                {
                    AvailableStatusService.Insert(availablestatusEdit);
                }
            }
            Response.Redirect("SiteAvailableStatus.aspx");
        }

        protected void btnUseDefault_Click(object sender, EventArgs e)
        {
            if (SiteAvailableStatusId > 0)
            {
                JXTPortal.Entities.AvailableStatus availablestatusDefault = AvailableStatusService.GetByAvailableStatusId(SiteAvailableStatusId);
                if (availablestatusDefault != null)
                {
                    AvailableStatusService.Delete(availablestatusDefault);
                    ltlMessage.Text = "You are now using default Available Status";
                    LoadSiteAvailableStatus();
                }
            }
        }

        #endregion
    }
}
