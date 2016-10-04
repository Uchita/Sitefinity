
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
using JXTPortal.Entities;
using JXTPortal;
using System.Xml.Linq;
using System.Linq;
using JXTPortal.Common;
#endregion

public partial class SiteWorkType : System.Web.UI.Page
{
    #region Properties

    private WorkTypeService _workTypeService;
    private WorkTypeService WorkTypeService
    {
        get
        {
            if (_workTypeService == null)
            {
                _workTypeService = new JXTPortal.WorkTypeService();
            }
            return _workTypeService;
        }
    }

    private SiteWorkTypeService _siteWorkTypeService;
    private SiteWorkTypeService SiteWorkTypeService
    {
        get
        {
            if (_siteWorkTypeService == null)
            {
                _siteWorkTypeService = new SiteWorkTypeService();
            }
            return _siteWorkTypeService;
        }
    }

    private TList<JXTPortal.Entities.SiteWorkType> SiteWorkTypes;


    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        //SiteWorkTypes = SiteWorkTypeService.GetAll();

        if (!IsPostBack)
        {
            loadForm();
        }
    }

    #endregion

    #region Methods

    protected void loadForm()
    {
        

        using (TList<JXTPortal.Entities.WorkType> objWorkType = WorkTypeService.GetAll())
        {
            SiteWorkTypes = SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId);

            rptWorktype.DataSource = objWorkType;
            rptWorktype.DataBind();
        }
    }

    protected void rptWorktype_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        TextBox txtSiteWorkTypeName = null;
        TextBox tbFriendlyUrl = null;
        CheckBox chkSiteWorkTypeValid = null;
        HiddenField hiddenWorkTypeID = null;
        HiddenField hiddenSiteWorkTypeID = null;
        TextBox txtSiteWorkTypeSequence = null;
        HiddenField hiddenSiteID = null;

        CompareValidator cvSequence = null;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            txtSiteWorkTypeName = e.Item.FindControl("txtSiteWorkTypeName") as TextBox;
            tbFriendlyUrl = e.Item.FindControl("tbFriendlyUrl") as TextBox;
            txtSiteWorkTypeSequence = e.Item.FindControl("txtSiteWorkTypeSequence") as TextBox;
            chkSiteWorkTypeValid = e.Item.FindControl("chkSiteWorkTypeValid") as CheckBox;
            
            hiddenWorkTypeID = (HiddenField)e.Item.FindControl("hiddenWorkTypeID");
            hiddenSiteWorkTypeID = (HiddenField)e.Item.FindControl("hiddenSiteWorkTypeID");
            hiddenSiteID = (HiddenField)e.Item.FindControl("hiddenSiteID");
            
            cvSequence = (CompareValidator)e.Item.FindControl("cvSequence");
            cvSequence.ControlToValidate = txtSiteWorkTypeSequence.ID;

            if (SiteWorkTypes != null)
            {
                var objSiteWorkType = SiteWorkTypes.FirstOrDefault(sw => sw.WorkTypeId == Convert.ToInt32(hiddenWorkTypeID.Value) && sw.SiteId == SessionData.Site.SiteId);

                if (objSiteWorkType != null)
                {
                    hiddenSiteWorkTypeID.Value = Convert.ToString(objSiteWorkType.SiteWorkTypeId);
                    hiddenSiteID.Value = Convert.ToString(objSiteWorkType.SiteId);
                    txtSiteWorkTypeName.Text = objSiteWorkType.SiteWorkTypeName;
                    tbFriendlyUrl.Text = objSiteWorkType.SiteWorkTypeFriendlyUrl;
                    chkSiteWorkTypeValid.Checked = objSiteWorkType.Valid;
                    txtSiteWorkTypeSequence.Text = Convert.ToString(objSiteWorkType.Sequence);
                }
            }
        }
    }

    //protected void rptWorktype_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if (e.CommandName == "Edit")
    //    {
    //        TextBox txtSiteWorkTypeName = e.Item.FindControl("txtSiteWorkTypeName") as TextBox;
    //        if (txtSiteWorkTypeName != null)
    //        {
    //            txtSiteWorkTypeName.Enabled = true;
    //        }
    //    }
    //}

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //using (TList<JXTPortal.Entities.SiteWorkType> SiteWorkType = SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
            //{
            //    SiteWorkTypeService.Delete(SiteWorkType);
            //}

            TextBox txtSiteWorkTypeName = null;
            TextBox tbFriendlyUrl = null;
            CheckBox chkSiteWorkTypeValid = null;
            HiddenField hiddenWorkTypeID = null;
            HiddenField hiddenSiteWorkTypeID = null;
            HiddenField hiddenSiteID = null;
            TextBox txtSiteWorkTypeSequence = null;

            //get the site salary types again
            TList<JXTPortal.Entities.SiteWorkType> SiteWorkTypes = SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId);


                foreach (RepeaterItem repeaterItem in rptWorktype.Items)
                {
                    txtSiteWorkTypeName = repeaterItem.FindControl("txtSiteWorkTypeName") as TextBox;
                    tbFriendlyUrl = repeaterItem.FindControl("tbFriendlyUrl") as TextBox;
                    chkSiteWorkTypeValid = repeaterItem.FindControl("chkSiteWorkTypeValid") as CheckBox;
                    hiddenWorkTypeID = (HiddenField)repeaterItem.FindControl("hiddenWorkTypeID");
                    txtSiteWorkTypeSequence = repeaterItem.FindControl("txtSiteWorkTypeSequence") as TextBox;
                    hiddenSiteWorkTypeID = (HiddenField)repeaterItem.FindControl("hiddenSiteWorkTypeID");
                    hiddenSiteID = (HiddenField)repeaterItem.FindControl("hiddenSiteID");

                    //if this targetID is 0, means we are creating a new one, otherwise update
                    JXTPortal.Entities.SiteWorkType objSiteWorkType = null;
                    if (hiddenSiteWorkTypeID != null && !string.IsNullOrEmpty(hiddenSiteWorkTypeID.Value))
                    {
                        int targetSiteWorkTypeID = Convert.ToInt32(hiddenSiteWorkTypeID.Value);
                        //verify target site salary type is for this site
                        objSiteWorkType = SiteWorkTypes.Where(c => c.SiteWorkTypeId == targetSiteWorkTypeID && c.SiteId == SessionData.Site.SiteId).SingleOrDefault();
                    }


                    if (chkSiteWorkTypeValid.Checked == true && !string.IsNullOrEmpty(txtSiteWorkTypeName.Text))
                    {
                        if (objSiteWorkType == null)
                        {
                            objSiteWorkType = new JXTPortal.Entities.SiteWorkType();
                            objSiteWorkType.SiteId = SessionData.Site.SiteId;
                        }

                        objSiteWorkType.SiteWorkTypeName = txtSiteWorkTypeName.Text;
                        string friendlyurl = string.Empty;
                        friendlyurl = (!string.IsNullOrEmpty(tbFriendlyUrl.Text))? Utils.UrlFriendlyName(tbFriendlyUrl.Text) : Utils.UrlFriendlyName(txtSiteWorkTypeName.Text);

                        objSiteWorkType.SiteWorkTypeFriendlyUrl = friendlyurl;
                        objSiteWorkType.Valid = chkSiteWorkTypeValid.Checked;

                        if (!string.IsNullOrEmpty(txtSiteWorkTypeSequence.Text.Trim()))
                        {
                            objSiteWorkType.Sequence = Convert.ToInt32(txtSiteWorkTypeSequence.Text);
                        }
                        else
                        {
                            objSiteWorkType.Sequence = 0;
                        }

                        if (hiddenSiteWorkTypeID != null && !string.IsNullOrEmpty(hiddenSiteWorkTypeID.Value) && !string.IsNullOrEmpty(hiddenSiteID.Value))
                        {                            
                            SiteWorkTypeService.Update(objSiteWorkType);
                        }
                        else
                        {
                            objSiteWorkType.WorkTypeId = Convert.ToInt32(hiddenWorkTypeID.Value);
                            SiteWorkTypeService.Insert(objSiteWorkType);
                        }

                        lblErrorMsg.Text = "Site Worktype has been saved";
                    }
                    else
                    {
                        if (chkSiteWorkTypeValid.Checked == false && objSiteWorkType != null)
                        {
                            SiteWorkTypeService.Delete(objSiteWorkType);
                            txtSiteWorkTypeName.Text = string.Empty;
                            tbFriendlyUrl.Text = string.Empty;
                            txtSiteWorkTypeSequence.Text = string.Empty;
                        }

                        if (chkSiteWorkTypeValid.Checked == true && string.IsNullOrEmpty(txtSiteWorkTypeName.Text))
                        {
                            lblErrorMsg.Text = "* Selected Site Work Type Name cannot be empty";
                        }
                    }
                }
            

            loadForm();
            //Response.Redirect("siteworktype.aspx");
        }
    }

    #endregion
}