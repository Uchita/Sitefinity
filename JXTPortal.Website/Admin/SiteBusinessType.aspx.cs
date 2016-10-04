#region Using directives
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
using JXTPortal.Entities;
using JXTPortal;
using JXTPortal.Web.UI;
#endregion

namespace JXTPortal.Website.Admin
{
    public partial class SiteBusinessType : System.Web.UI.Page
    {
        #region Properties

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

        JXTPortal.AdminUsersService _adminusersService;
        JXTPortal.AdminUsersService AdminUsersService
        {
            get
            {
                if (_adminusersService == null)
                {
                    _adminusersService = new JXTPortal.AdminUsersService();
                }
                return _adminusersService;
            }
        }


        private TList<JXTPortal.Entities.AdvertiserBusinessType> businesstype;
        private TList<JXTPortal.Entities.AdvertiserBusinessType> SiteAdvertiserBusinessType;

        #endregion

        #region Page Event Handlers

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
            // Get all Site


            // Get all Default
            int count = 0;
            using (businesstype = AdvertiserBusinessTypeService.GetPaged("SiteID IS NULL AND GlobalTemplate = 1", "Sequence", 0, Int32.MaxValue, out count))
            {
                SiteAdvertiserBusinessType = AdvertiserBusinessTypeService.GetPaged("SiteID = " + SessionData.Site.SiteId.ToString() + " AND GlobalTemplate = 0", "", 0, Int32.MaxValue, out count);
                if (SiteAdvertiserBusinessType.Count == 0)
                {
                    lblErrorMsg.Text = "Default Advertiser Business Type are being used.";
                }
                rptSiteBusinessType.DataSource = businesstype;
                rptSiteBusinessType.DataBind();
            }
        }

        protected void rptSiteBusinessType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TextBox txtSiteBusinessTypeSequence = null;
            TextBox txtSiteBusinessTypeName = null;
            HiddenField hiddenBusinessTypeParentID = null;
            Literal ltLastModifiedBy = null;
            Literal ltLastModifiedDate = null;
            HiddenField hiddenBusinessTypeID = null;
            HiddenField hiddenSiteBusinessTypeID = null;
            CompareValidator cvSequence = null;
            CheckBox chkSiteBusinessTypeValid = null;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                txtSiteBusinessTypeName = (TextBox)e.Item.FindControl("txtSiteBusinessTypeName");
                txtSiteBusinessTypeSequence = (TextBox)e.Item.FindControl("txtSiteBusinessTypeSequence");
                ltLastModifiedBy = (Literal)e.Item.FindControl("ltLastModifiedBy") as Literal;
                ltLastModifiedDate = (Literal)e.Item.FindControl("ltLastModifiedDate") as Literal;
                hiddenBusinessTypeParentID = (HiddenField)e.Item.FindControl("hiddenBusinessTypeParentID");
                hiddenBusinessTypeID = (HiddenField)e.Item.FindControl("hiddenBusinessTypeID");
                hiddenSiteBusinessTypeID = (HiddenField)e.Item.FindControl("hiddenSiteBusinessTypeID");
                chkSiteBusinessTypeValid = (CheckBox)e.Item.FindControl("chkSiteBusinessTypeValid");

                cvSequence = (CompareValidator)e.Item.FindControl("cvSequence");

                cvSequence.ControlToValidate = txtSiteBusinessTypeSequence.ID;

                if (SiteAdvertiserBusinessType != null)
                {
                    var objSiteBusinessType = SiteAdvertiserBusinessType.FirstOrDefault(se => se.BusinessTypeParentId == Convert.ToInt32(hiddenBusinessTypeID.Value));

                    if (objSiteBusinessType != null && SiteAdvertiserBusinessType.Count > 0)
                    {
                        hiddenSiteBusinessTypeID.Value = objSiteBusinessType.AdvertiserBusinessTypeId.ToString();
                        hiddenBusinessTypeParentID.Value = hiddenBusinessTypeID.Value;
                        txtSiteBusinessTypeName.Text = objSiteBusinessType.AdvertiserBusinessTypeName;

                        if (objSiteBusinessType.LastModifiedBy.HasValue)
                        {
                            ltLastModifiedBy.Text = Convert.ToString(objSiteBusinessType.LastModifiedBy);

                            using (Entities.AdminUsers adminusers = AdminUsersService.GetByAdminUserId(objSiteBusinessType.LastModifiedBy.Value))
                            {
                                if (adminusers != null)
                                    ltLastModifiedBy.Text = adminusers.UserName;
                            }
                        }

                        ltLastModifiedDate.Text = objSiteBusinessType.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        txtSiteBusinessTypeSequence.Text = Convert.ToString(objSiteBusinessType.Sequence);
                        chkSiteBusinessTypeValid.Checked = true;
                    }

                }
            }
        }

        #endregion

        #region Click Event handlers

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //using (TList<JXTPortal.Entities.Educations> EducationsEdit = AdvertiserBusinessTypeService.GetBySiteId(SessionData.Site.SiteId))
                //{
                //    AdvertiserBusinessTypeService.Delete(EducationsEdit);
                //}

                TextBox txtSiteBusinessTypeSequence = null;
                TextBox txtSiteBusinessTypeName = null;
                HiddenField hiddenBusinessTypeParentID = null;
                Literal ltLastModifiedBy = null;
                Literal ltLastModifiedDate = null;
                HiddenField hiddenBusinessTypeID = null;
                HiddenField hiddenSiteBusinessTypeID = null;
                CompareValidator cvSequence = null;
                CheckBox chkSiteBusinessTypeValid = null;

                //get the site educations
                int count = 0;
                TList<JXTPortal.Entities.AdvertiserBusinessType> SiteAdvertiserBusinessTypes = AdvertiserBusinessTypeService.GetPaged("SiteID = " + SessionData.Site.SiteId.ToString() + " AND GlobalTemplate = 0", "", 0, Int32.MaxValue, out count);


                foreach (RepeaterItem repeaterItem in rptSiteBusinessType.Items)
                {
                    txtSiteBusinessTypeName = (TextBox)repeaterItem.FindControl("txtSiteBusinessTypeName");
                    txtSiteBusinessTypeSequence = (TextBox)repeaterItem.FindControl("txtSiteBusinessTypeSequence");
                    ltLastModifiedBy = (Literal)repeaterItem.FindControl("ltLastModifiedBy") as Literal;
                    ltLastModifiedDate = (Literal)repeaterItem.FindControl("ltLastModifiedDate") as Literal;
                    hiddenBusinessTypeParentID = (HiddenField)repeaterItem.FindControl("hiddenBusinessTypeParentID");
                    hiddenBusinessTypeID = (HiddenField)repeaterItem.FindControl("hiddenBusinessTypeID");
                    hiddenSiteBusinessTypeID = (HiddenField)repeaterItem.FindControl("hiddenSiteBusinessTypeID");
                    chkSiteBusinessTypeValid = (CheckBox)repeaterItem.FindControl("chkSiteBusinessTypeValid");

                    cvSequence = (CompareValidator)repeaterItem.FindControl("cvSequence");

                    JXTPortal.Entities.AdvertiserBusinessType objBusinessType = null;
                    if (hiddenSiteBusinessTypeID != null && !string.IsNullOrEmpty(hiddenSiteBusinessTypeID.Value))
                    {
                        int targetSiteBusinessTypeID = Convert.ToInt32(hiddenSiteBusinessTypeID.Value);
                        //verify target site education is for this site
                        objBusinessType = SiteAdvertiserBusinessTypes.Where(c => c.AdvertiserBusinessTypeId == targetSiteBusinessTypeID && c.SiteId == SessionData.Site.SiteId).SingleOrDefault();
                    }


                    try
                    {
                        using (Entities.AdvertiserBusinessType education = AdvertiserBusinessTypeService.GetByAdvertiserBusinessTypeId(Convert.ToInt32(hiddenBusinessTypeID.Value)))
                        {
                            if (education != null)
                            {
                                if (!education.GlobalTemplate)
                                {
                                    lblErrorMsg.Text = "Error";
                                    return;
                                }
                            }
                            else
                            {
                                lblErrorMsg.Text = "Error";
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text = "Error";
                        return;
                    }

                    if (chkSiteBusinessTypeValid.Checked == true && !string.IsNullOrEmpty(txtSiteBusinessTypeName.Text))
                    {

                        //create a new one if 1: targetSiteEducationID is 0 OR 2: targetSiteEducationID is being hacked
                        if (objBusinessType == null)
                        {
                            objBusinessType = new JXTPortal.Entities.AdvertiserBusinessType();
                            objBusinessType.SiteId = SessionData.Site.SiteId;
                        }

                        if (!string.IsNullOrEmpty(hiddenSiteBusinessTypeID.Value))
                        {
                            objBusinessType.AdvertiserBusinessTypeId = Convert.ToInt32(hiddenSiteBusinessTypeID.Value);
                        }

                        objBusinessType.BusinessTypeParentId = Convert.ToInt32(hiddenBusinessTypeID.Value);
                        objBusinessType.AdvertiserBusinessTypeName = txtSiteBusinessTypeName.Text;
                        objBusinessType.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                        objBusinessType.LastModifiedDate = DateTime.Now;

                        if (!string.IsNullOrEmpty(txtSiteBusinessTypeSequence.Text.Trim()))
                        {
                            objBusinessType.Sequence = Convert.ToInt32(txtSiteBusinessTypeSequence.Text);
                        }
                        else
                        {
                            objBusinessType.Sequence = 0;
                        }

                        if (objBusinessType.AdvertiserBusinessTypeId > 0)
                        {
                            AdvertiserBusinessTypeService.Update(objBusinessType);
                        }
                        else
                        {
                            AdvertiserBusinessTypeService.Insert(objBusinessType);
                        }

                        lblErrorMsg.Text = "Advertiser Business Type has been saved";

                        /*
                        if (hiddenSiteEducationID != null)
                        {
                            objEducations.EducationId = Convert.ToInt32(hiddenSiteEducationID.Value);
                        }

                        AdvertiserBusinessTypeService.Save(objEducations);
                        */
                    }
                    else
                    {
                        if (!chkSiteBusinessTypeValid.Checked && objBusinessType != null)
                        {
                            AdvertiserBusinessTypeService.Delete(objBusinessType);
                        }

                        if (chkSiteBusinessTypeValid.Checked == true && string.IsNullOrEmpty(txtSiteBusinessTypeName.Text))
                        {
                            lblErrorMsg.Text = "* Selected Advertiser Business Type Name cannot be empty";
                            return;
                        }
                    }

                    //dispose object if used
                    if (objBusinessType != null)
                        objBusinessType.Dispose();

                }

                loadForm();
                //Response.Redirect("siteeducations.aspx");
            }
        }

        #endregion
    }
}