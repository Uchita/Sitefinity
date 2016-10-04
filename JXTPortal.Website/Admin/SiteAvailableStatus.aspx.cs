
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
    public partial class SiteAvailableStatus : System.Web.UI.Page
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

        private TList<JXTPortal.Entities.AvailableStatus> availableStatus;
        private TList<JXTPortal.Entities.AvailableStatus> siteAvailableStatus;

        #endregion

        #region Page Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();
            }
        }

        //protected void rptSiteAvailableStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Overwrite")
        //    {
        //        Response.Redirect("SiteAvailableStatusEdit.aspx?ParentAvailableStatusID=" + e.CommandArgument);
        //    }
        //}

        #endregion

        #region Methods

        protected void loadForm()
        {
            // Get all Site
            

            // Get all Default
            using (availableStatus = AvailableStatusService.GetAll())
            {
                siteAvailableStatus = AvailableStatusService.GetBySiteId(SessionData.Site.SiteId);

                availableStatus.Filter = "GlobalTemplate = True";
                rptSiteAvailableStatus.DataSource = availableStatus;
                rptSiteAvailableStatus.DataBind();
            }
        }

        protected void rptSiteAvailableStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TextBox txtSiteAvailableStatusName = null;
            HiddenField hiddenAvailableStatusParentID = null;
            Literal ltLastModifiedBy = null;
            Literal ltLastModifiedDate = null;
            HiddenField hiddenSiteAvailableStatusID = null;
            HiddenField hiddenAvailableStatusID = null;
            TextBox txtSiteAvailableStatusSequence = null;
            CheckBox chkSiteAvailableStatusValid = null;

            CompareValidator cvSequence = null;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                txtSiteAvailableStatusName = e.Item.FindControl("txtSiteAvailableStatusName") as TextBox;
                ltLastModifiedBy = (Literal)e.Item.FindControl("ltLastModifiedBy") as Literal;
                ltLastModifiedDate = (Literal)e.Item.FindControl("ltLastModifiedDate") as Literal;
                hiddenAvailableStatusParentID = (HiddenField)e.Item.FindControl("hiddenAvailableStatusParentID");
                hiddenAvailableStatusID = (HiddenField)e.Item.FindControl("hiddenAvailableStatusID");
                hiddenSiteAvailableStatusID = (HiddenField)e.Item.FindControl("hiddenSiteAvailableStatusID");
                chkSiteAvailableStatusValid = (CheckBox)e.Item.FindControl("chkSiteAvailableStatusValid");

                txtSiteAvailableStatusSequence = (TextBox)e.Item.FindControl("txtSiteAvailableStatusSequence");
                cvSequence = (CompareValidator)e.Item.FindControl("cvSequence");

                cvSequence.ControlToValidate = txtSiteAvailableStatusSequence.ID;

                if (siteAvailableStatus != null)
                {
                    var objAvailableStatus = siteAvailableStatus.FirstOrDefault(sa => sa.AvailableStatusParentId == Convert.ToInt32(hiddenAvailableStatusID.Value));

                    if (objAvailableStatus != null && siteAvailableStatus.Count > 0)
                    {
                        hiddenSiteAvailableStatusID.Value = Convert.ToString(objAvailableStatus.AvailableStatusId);
                        hiddenAvailableStatusParentID.Value = hiddenAvailableStatusID.Value;
                        txtSiteAvailableStatusName.Text = objAvailableStatus.AvailableStatusName;
                        ltLastModifiedBy.Text = Convert.ToString(objAvailableStatus.LastModifiedBy);
                        ltLastModifiedDate.Text = objAvailableStatus.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        txtSiteAvailableStatusSequence.Text = Convert.ToString(objAvailableStatus.Sequence);
                        chkSiteAvailableStatusValid.Checked = true;
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
                //using (TList<JXTPortal.Entities.AvailableStatus> AvailableStatusEdit = AvailableStatusService.GetBySiteId(SessionData.Site.SiteId))
                //{
                //    AvailableStatusService.Delete(AvailableStatusEdit);
                //}

                TextBox txtSiteAvailableStatusName = null;
                HiddenField hiddenAvailableStatusID = null;
                CheckBox chkSiteAvailableStatusValid = null;
                HiddenField hiddenSiteAvailableStatusID = null;
                TextBox txtSiteAvailableStatusSequence = null;

                using (JXTPortal.Entities.AvailableStatus objAvailableStatus = new JXTPortal.Entities.AvailableStatus())
                {
                    foreach (RepeaterItem repeaterItem in rptSiteAvailableStatus.Items)
                    {
                        txtSiteAvailableStatusName = repeaterItem.FindControl("txtSiteAvailableStatusName") as TextBox;
                        chkSiteAvailableStatusValid = repeaterItem.FindControl("chkSiteAvailableStatusValid") as CheckBox;
                        hiddenAvailableStatusID = (HiddenField)repeaterItem.FindControl("hiddenAvailableStatusID");
                        hiddenSiteAvailableStatusID = (HiddenField)repeaterItem.FindControl("hiddenSiteAvailableStatusID");
                        txtSiteAvailableStatusSequence = (TextBox)repeaterItem.FindControl("txtSiteAvailableStatusSequence");


                        try
                        {
                            using (Entities.AvailableStatus availablestatus = AvailableStatusService.GetByAvailableStatusId(Convert.ToInt32(hiddenAvailableStatusID.Value)))
                            {
                                if (availablestatus != null)
                                {
                                    if (!availablestatus.GlobalTemplate)
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
                        catch
                        {
                            lblErrorMsg.Text = "Error";
                            return;
                        }

                        if (chkSiteAvailableStatusValid.Checked == true && !string.IsNullOrEmpty(txtSiteAvailableStatusName.Text))
                        {
                            objAvailableStatus.AvailableStatusParentId = Convert.ToInt32(hiddenAvailableStatusID.Value);
                            objAvailableStatus.SiteId = SessionData.Site.SiteId;
                            objAvailableStatus.AvailableStatusName = txtSiteAvailableStatusName.Text;
                            objAvailableStatus.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                            objAvailableStatus.LastModified = DateTime.Now;

                            if (!string.IsNullOrEmpty(txtSiteAvailableStatusSequence.Text.Trim()))
                            {
                                objAvailableStatus.Sequence = Convert.ToInt32(txtSiteAvailableStatusSequence.Text);
                            }
                            else
                            {
                                objAvailableStatus.Sequence = 0;
                            }

                            if (hiddenSiteAvailableStatusID != null && !string.IsNullOrEmpty(hiddenSiteAvailableStatusID.Value))
                            {
                                try
                                {
                                    using (Entities.AvailableStatus availablestatus = AvailableStatusService.GetByAvailableStatusId(Convert.ToInt32(hiddenSiteAvailableStatusID.Value)))
                                    {
                                        if (availablestatus != null)
                                        {
                                            if (availablestatus.SiteId != SessionData.Site.SiteId)
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
                                catch
                                {
                                    lblErrorMsg.Text = "Error";
                                    return;
                                }

                                objAvailableStatus.AvailableStatusId = Convert.ToInt32(hiddenSiteAvailableStatusID.Value);
                                AvailableStatusService.Update(objAvailableStatus);
                            }
                            else
                            {
                                AvailableStatusService.Insert(objAvailableStatus);
                            }

                            lblErrorMsg.Text = "Site Available Status has been saved";
                            
                        }
                        else
                        {
                            if (!chkSiteAvailableStatusValid.Checked && hiddenSiteAvailableStatusID != null && !string.IsNullOrEmpty(hiddenSiteAvailableStatusID.Value))
                            {
                                AvailableStatusService.Delete(Convert.ToInt32(hiddenSiteAvailableStatusID.Value));
                            }

                            if (chkSiteAvailableStatusValid.Checked == true && string.IsNullOrEmpty(txtSiteAvailableStatusName.Text))
                            {
                                lblErrorMsg.Text = "* Selected Site Available Status Name cannot be empty";
                            }
                        }
                    }
                }


                loadForm();
                //Response.Redirect("siteavailablestatus.aspx");
            }
        }

        #endregion
    }
}
