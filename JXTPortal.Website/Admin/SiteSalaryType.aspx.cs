
#region Using directives
using System;
using System.Data;
using System.Collections.Generic;
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
using System.Linq;
#endregion

public partial class SiteSalaryType : System.Web.UI.Page
{
    #region Properties

    private SalaryTypeService _salaryTypeService;
    private SalaryTypeService SalaryTypeService
    {
        get
        {
            if (_salaryTypeService == null)
            {
                _salaryTypeService = new JXTPortal.SalaryTypeService();
            }
            return _salaryTypeService;
        }
    }

    private SiteSalaryTypeService _siteSalaryTypeService;
    private SiteSalaryTypeService SiteSalaryTypeService
    {
        get
        {
            if (_siteSalaryTypeService == null)
            {
                _siteSalaryTypeService = new SiteSalaryTypeService();
            }
            return _siteSalaryTypeService;
        }
    }

    private List<JXTPortal.Entities.SiteSalaryType> SiteSalaryTypes;

    #endregion

    #region Page Event Handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        //SiteSalaryTypes = SiteSalaryTypeService.GetAll();

        if (!IsPostBack)
        {
            loadForm();
        }
    }

    #endregion

    #region Methods

    protected void loadForm()
    {
        List<JXTPortal.Entities.SalaryType> salaryTypes = SalaryTypeService.Get_ValidList();
        SiteSalaryTypes = SiteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);

        rptSiteSalaryType.DataSource = salaryTypes;
        rptSiteSalaryType.DataBind();
    }

    protected void rptSiteSalaryType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        TextBox txtSiteSalaryTypeName = null;
        CheckBox chkSiteSalaryTypeValid = null;
        HiddenField hiddenSalaryTypeID = null;
        TextBox txtSiteSalaryTypeSequence = null;
        HiddenField hiddenSiteSalaryTypeID = null;
        CompareValidator cvSequence = null;
        JXTPortal.Entities.SalaryType salarytype = e.Item.DataItem as JXTPortal.Entities.SalaryType;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            txtSiteSalaryTypeName = e.Item.FindControl("txtSiteSalaryTypeName") as TextBox;
            chkSiteSalaryTypeValid = e.Item.FindControl("chkSiteSalaryTypeValid") as CheckBox;
            txtSiteSalaryTypeSequence = e.Item.FindControl("txtSiteSalaryTypeSequence") as TextBox;
            hiddenSalaryTypeID = (HiddenField)e.Item.FindControl("hiddenSalaryTypeID");
            hiddenSiteSalaryTypeID = (HiddenField)e.Item.FindControl("hiddenSiteSalaryTypeID");

            cvSequence = (CompareValidator)e.Item.FindControl("cvSequence");

            cvSequence.ControlToValidate = txtSiteSalaryTypeSequence.ID;

            txtSiteSalaryTypeName.Text = salarytype.SalaryTypeName;
            foreach (JXTPortal.Entities.SiteSalaryType sitesalarytype in SiteSalaryTypes)
            {
                if (sitesalarytype.SalaryTypeId == salarytype.SalaryTypeId)
                {
                    hiddenSiteSalaryTypeID.Value = Convert.ToString(sitesalarytype.SiteSalaryTypeId);
                    txtSiteSalaryTypeName.Text = sitesalarytype.SalaryTypeName;
                    chkSiteSalaryTypeValid.Checked = sitesalarytype.Valid;
                    txtSiteSalaryTypeSequence.Text = Convert.ToString(sitesalarytype.Sequence);

                    break;
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
            //Fail safe feature: We remove all the not valid records in the DB
            List<JXTPortal.Entities.SiteSalaryType> ToDeleteSiteSalaryTypes = SiteSalaryTypeService.GetBySiteId(SessionData.Site.SiteId).Where(c => !c.Valid).ToList();

            foreach (JXTPortal.Entities.SiteSalaryType t in ToDeleteSiteSalaryTypes)
            {
                SiteSalaryTypeService.Delete(t.SiteSalaryTypeId);
            }


            TextBox txtSiteSalaryTypeName = null;
            CheckBox chkSiteSalaryTypeValid = null;
            HiddenField hiddenSalaryTypeID = null;
            TextBox txtSiteSalaryTypeSequence = null;
            HiddenField hiddenSiteSalaryTypeID = null;


            //get the site salary types again
            List<JXTPortal.Entities.SiteSalaryType> SiteSalaryTypes = SiteSalaryTypeService.GetBySiteId(SessionData.Site.SiteId).ToList();

            foreach (RepeaterItem repeaterItem in rptSiteSalaryType.Items)
            {

                txtSiteSalaryTypeName = repeaterItem.FindControl("txtSiteSalaryTypeName") as TextBox;
                chkSiteSalaryTypeValid = repeaterItem.FindControl("chkSiteSalaryTypeValid") as CheckBox;
                hiddenSalaryTypeID = (HiddenField)repeaterItem.FindControl("hiddenSalaryTypeID");
                txtSiteSalaryTypeSequence = repeaterItem.FindControl("txtSiteSalaryTypeSequence") as TextBox;
                hiddenSiteSalaryTypeID = (HiddenField)repeaterItem.FindControl("hiddenSiteSalaryTypeID");

                JXTPortal.Entities.SiteSalaryType objSiteSalaryType = null;
                if (hiddenSiteSalaryTypeID != null && !string.IsNullOrEmpty(hiddenSiteSalaryTypeID.Value))
                {
                    int targetSiteSalaryTypeID = Convert.ToInt32(hiddenSiteSalaryTypeID.Value);
                    //verify target site salary type is for this site
                    objSiteSalaryType = SiteSalaryTypes.Where(c => c.SiteSalaryTypeId == targetSiteSalaryTypeID && c.SiteId == SessionData.Site.SiteId).SingleOrDefault();
                }

                if (chkSiteSalaryTypeValid.Checked == true)
                {
                    if (string.IsNullOrEmpty(txtSiteSalaryTypeName.Text))
                    {
                        lblErrorMsg.Text = "* Selected Site Salary Type Name cannot be empty";
                    }
                    else
                    {
                        //create a new one if 1: targetSiteSalaryTypeID is 0 OR 2: targetSiteSalaryTypeID is being hacked
                        if (objSiteSalaryType == null)
                        {
                            objSiteSalaryType = new JXTPortal.Entities.SiteSalaryType();
                            objSiteSalaryType.SiteId = SessionData.Site.SiteId;
                        }

                        objSiteSalaryType.SalaryTypeName = txtSiteSalaryTypeName.Text;
                        objSiteSalaryType.Valid = chkSiteSalaryTypeValid.Checked;

                        if (!string.IsNullOrEmpty(txtSiteSalaryTypeSequence.Text.Trim()))
                        {
                            objSiteSalaryType.Sequence = Convert.ToInt32(txtSiteSalaryTypeSequence.Text);
                        }

                        if (objSiteSalaryType.SiteSalaryTypeId > 0)
                        {
                            SiteSalaryTypeService.Update(objSiteSalaryType);
                        }
                        else
                        {
                            objSiteSalaryType.SalaryTypeId = Convert.ToInt32(hiddenSalaryTypeID.Value);
                            SiteSalaryTypeService.Insert(objSiteSalaryType);
                        }

                        lblErrorMsg.Text = "Site Salary Type has been saved";
                    }

                }
                else //valid checkbox is not checked
                {
                    if (objSiteSalaryType != null)
                    {
                        SiteSalaryTypeService.Delete(objSiteSalaryType);
                        txtSiteSalaryTypeName.Text = string.Empty;
                        txtSiteSalaryTypeSequence.Text = string.Empty;
                    }
                }

                //dispose object if used
                if( objSiteSalaryType != null )
                    objSiteSalaryType.Dispose();
            }


            loadForm();
        }
    }

    #endregion
}
