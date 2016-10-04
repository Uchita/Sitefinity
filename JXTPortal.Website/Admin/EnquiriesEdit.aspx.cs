
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
#endregion

public partial class EnquiriesEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int enquiryId = 0;

    #endregion

    #region Properties

    JXTPortal.EnquiriesService _enquiriesService;
    JXTPortal.EnquiriesService EnquiriesService
    {
        get
        {
            if (_enquiriesService == null)
            {
                _enquiriesService = new JXTPortal.EnquiriesService();
            }
            return _enquiriesService;
        }
    }

    private int EnquiryId
    {
        get
        {
            if ((Request.QueryString["EnquiryId"] != null))
            {
                if (int.TryParse((Request.QueryString["EnquiryId"].Trim()), out enquiryId))
                {
                    enquiryId = Convert.ToInt32(Request.QueryString["EnquiryId"]);
                }
                return enquiryId;
            }
            return enquiryId;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadForm();
        }
        else
        {
            Response.Redirect("Enquiries.aspx");
        }
    }

    #endregion

    #region Methods

    private void loadForm()
    {
        if (SessionData.AdminUser == null)
        {
            Response.Redirect("~/admin/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            return;
        }

        if (EnquiryId > 0)
        {
            using (JXTPortal.Entities.Enquiries objEnquiries = EnquiriesService.GetByEnquiryId(EnquiryId))
            {
                if (objEnquiries != null && objEnquiries.SiteId == SessionData.Site.SiteId)
                {
                    checkAdminRole();

                    txtEnquiriesName.Text = objEnquiries.Name;
                    txtEnquiriesEmail.Text = objEnquiries.Email;
                    txtEnquiriesPhone.Text = objEnquiries.ContactPhone;
                    lblEnquirySiteID.Text = Convert.ToString(objEnquiries.SiteId);
                    txtEnquiriesContent.Text = objEnquiries.Content;
                    lblEnquiryDate.Text = string.Format("{0:" + SessionData.Site.DateFormat+ "}", objEnquiries.Date);
                    lblEnquiryIpAddress.Text = Convert.ToString(objEnquiries.IpAddress);
                }
                else
                {
                    Response.Redirect("enquiries.aspx");
                }
            }
        }
    }

    private void checkAdminRole()
    {
        if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor)
        {
            txtEnquiriesName.ReadOnly = true;
            txtEnquiriesEmail.ReadOnly = true;
            txtEnquiriesPhone.ReadOnly = true;
            txtEnquiriesContent.ReadOnly = true;
            btnSubmit.Visible = false;
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.Enquiries objEnquiries = null;

            if (EnquiryId > 0)
            {
                objEnquiries = EnquiriesService.GetByEnquiryId(EnquiryId);

                if (objEnquiries == null || objEnquiries.SiteId != SessionData.Site.SiteId)
                    Response.Redirect("/admin/enquiries.aspx");
            }

            objEnquiries.Name = txtEnquiriesName.Text;
            objEnquiries.Email = txtEnquiriesEmail.Text;
            objEnquiries.ContactPhone = txtEnquiriesPhone.Text;
            objEnquiries.Content = txtEnquiriesContent.Text;
            objEnquiries.Date = DateTime.Now;
            objEnquiries.IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null) ?
                HttpContext.Current.Request.UserHostAddress : HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (EnquiryId > 0)
            {
                EnquiriesService.Update(objEnquiries);
            }
            else
            {
                EnquiriesService.Insert(objEnquiries);
            }

            //dispose
            if (objEnquiries != null)
                objEnquiries.Dispose();

            Response.Redirect("enquiries.aspx");

        }
    }

    #endregion
}


