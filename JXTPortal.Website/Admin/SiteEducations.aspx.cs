
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
    public partial class SiteEducations : System.Web.UI.Page
    {
        #region Properties

        JXTPortal.EducationsService _educationsService;
        JXTPortal.EducationsService EducationsService
        {
            get
            {
                if (_educationsService == null)
                {
                    _educationsService = new JXTPortal.EducationsService();
                }
                return _educationsService;
            }
        }

        private TList<JXTPortal.Entities.Educations> education;
        private TList<JXTPortal.Entities.Educations> SiteEducation;

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
            using (education = EducationsService.GetAll())
            {
                SiteEducation = EducationsService.GetBySiteId(SessionData.Site.SiteId);

                education.Filter = "GlobalTemplate = True";
                rptSiteEducations.DataSource = education;
                rptSiteEducations.DataBind();
            }
        }

        protected void rptSiteEducations_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TextBox txtSiteEducationsSequence = null;
            TextBox txtSiteEducationsName = null;
            HiddenField hiddenEducationParentID = null;
            Literal ltLastModifiedBy = null;
            Literal ltLastModifiedDate = null;
            HiddenField hiddenEducationID = null;
            HiddenField hiddenSiteEducationID = null;
            CompareValidator cvSequence = null;
            CheckBox chkSiteEducationsValid = null;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                txtSiteEducationsName = (TextBox)e.Item.FindControl("txtSiteEducationsName");
                ltLastModifiedBy = (Literal)e.Item.FindControl("ltLastModifiedBy") as Literal;
                ltLastModifiedDate = (Literal)e.Item.FindControl("ltLastModifiedDate") as Literal;
                hiddenEducationParentID = (HiddenField)e.Item.FindControl("hiddenEducationParentID");
                hiddenEducationID = (HiddenField)e.Item.FindControl("hiddenEducationID");
                hiddenSiteEducationID = (HiddenField)e.Item.FindControl("hiddenSiteEducationID");
                chkSiteEducationsValid = (CheckBox)e.Item.FindControl("chkSiteEducationsValid");

                cvSequence = (CompareValidator)e.Item.FindControl("cvSequence");
                txtSiteEducationsSequence = (TextBox)e.Item.FindControl("txtSiteEducationsSequence");

                cvSequence.ControlToValidate = txtSiteEducationsSequence.ID;

                if (SiteEducation != null)
                {
                    var objSiteEducation = SiteEducation.FirstOrDefault(se => se.EducationParentId == Convert.ToInt32(hiddenEducationID.Value));

                    if (objSiteEducation != null && SiteEducation.Count > 0)
                    {
                        hiddenSiteEducationID.Value = objSiteEducation.EducationId.ToString();
                        hiddenEducationParentID.Value = hiddenEducationID.Value;
                        txtSiteEducationsName.Text = objSiteEducation.EducationName;
                        ltLastModifiedBy.Text = Convert.ToString(objSiteEducation.LastModifiedBy);
                        ltLastModifiedDate.Text = objSiteEducation.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        txtSiteEducationsSequence.Text = Convert.ToString(objSiteEducation.Sequence);
                        chkSiteEducationsValid.Checked = true;
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
                //using (TList<JXTPortal.Entities.Educations> EducationsEdit = EducationsService.GetBySiteId(SessionData.Site.SiteId))
                //{
                //    EducationsService.Delete(EducationsEdit);
                //}

                TextBox txtSiteEducationsName = null;
                HiddenField hiddenEducationID = null;
                CheckBox chkSiteEducationsValid = null;
                HiddenField hiddenSiteEducationID = null;
                TextBox txtSiteEducationsSequence = null;

                //get the site educations
                TList<JXTPortal.Entities.Educations> SiteEducations = EducationsService.GetBySiteId(SessionData.Site.SiteId);


                foreach (RepeaterItem repeaterItem in rptSiteEducations.Items)
                {
                    chkSiteEducationsValid = (CheckBox)repeaterItem.FindControl("chkSiteEducationsValid");
                    txtSiteEducationsName = (TextBox)repeaterItem.FindControl("txtSiteEducationsName");
                    hiddenEducationID = (HiddenField)repeaterItem.FindControl("hiddenEducationID");
                    hiddenSiteEducationID = (HiddenField)repeaterItem.FindControl("hiddenSiteEducationID");
                    txtSiteEducationsSequence = (TextBox)repeaterItem.FindControl("txtSiteEducationsSequence");

                    JXTPortal.Entities.Educations objEducation = null;
                    if (hiddenSiteEducationID != null && !string.IsNullOrEmpty(hiddenSiteEducationID.Value))
                    {
                        int targetSiteEducationID = Convert.ToInt32(hiddenSiteEducationID.Value);
                        //verify target site education is for this site
                        objEducation = SiteEducations.Where(c => c.EducationId == targetSiteEducationID && c.SiteId == SessionData.Site.SiteId).SingleOrDefault();
                    }


                    try
                    {
                        using (Entities.Educations education = EducationsService.GetByEducationId(Convert.ToInt32(hiddenEducationID.Value)))
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

                    if (chkSiteEducationsValid.Checked == true && !string.IsNullOrEmpty(txtSiteEducationsName.Text))
                    {

                        //create a new one if 1: targetSiteEducationID is 0 OR 2: targetSiteEducationID is being hacked
                        if (objEducation == null)
                        {
                            objEducation = new JXTPortal.Entities.Educations();
                            objEducation.SiteId = SessionData.Site.SiteId;
                        }


                        objEducation.EducationParentId = Convert.ToInt32(hiddenEducationID.Value);
                        objEducation.EducationName = txtSiteEducationsName.Text;
                        objEducation.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                        objEducation.LastModified = DateTime.Now;

                        if (!string.IsNullOrEmpty(txtSiteEducationsSequence.Text.Trim()))
                        {
                            objEducation.Sequence = Convert.ToInt32(txtSiteEducationsSequence.Text);
                        }
                        else
                        {
                            objEducation.Sequence = 0;
                        }

                        if (objEducation.EducationId > 0)
                        {
                            EducationsService.Update(objEducation);
                        }
                        else
                        {
                            EducationsService.Insert(objEducation);
                        }

                        lblErrorMsg.Text = "Site Educations has been saved";

                        /*
                        if (hiddenSiteEducationID != null)
                        {
                            objEducations.EducationId = Convert.ToInt32(hiddenSiteEducationID.Value);
                        }

                        EducationsService.Save(objEducations);
                        */
                    }
                    else
                    {
                        if (!chkSiteEducationsValid.Checked && objEducation != null)
                        {
                            EducationsService.Delete(objEducation);
                        }

                        if (chkSiteEducationsValid.Checked == true && string.IsNullOrEmpty(txtSiteEducationsName.Text))
                        {
                            lblErrorMsg.Text = "* Selected Site Education Name cannot be empty";
                        }
                    }

                    //dispose object if used
                    if (objEducation != null)
                        objEducation.Dispose();

                }

                loadForm();
                //Response.Redirect("siteeducations.aspx");
            }
        }

        #endregion
    }
}
