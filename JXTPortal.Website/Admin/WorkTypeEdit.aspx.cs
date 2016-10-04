
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
#endregion

public partial class WorkTypeEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int workTypeID = 0;

    #endregion

    #region Properties

    JXTPortal.WorkTypeService _workTypeService;
    JXTPortal.WorkTypeService WorkTypeService
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

    private int WorkTypeID
    {
        get
        {
            if ((Request.QueryString["WorkTypeId"] != null))
            {
                if (int.TryParse((Request.QueryString["WorkTypeId"].Trim()), out workTypeID))
                {
                    workTypeID = Convert.ToInt32(Request.QueryString["WorkTypeId"]);
                }
                return workTypeID;
            }
            return workTypeID;
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
    }

    #endregion

    #region Methods

    protected void loadForm()
    {
        if (WorkTypeID > 0)
        {
            using (JXTPortal.Entities.WorkType objWorkType = WorkTypeService.GetByWorkTypeId(WorkTypeID))
            {
                txtWorkTypeName.Text = objWorkType.WorkTypeName;
                chkWorkTypeValid.Checked = objWorkType.Valid;
            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.WorkType objWorkType = new JXTPortal.Entities.WorkType();

            try
            {
                if (WorkTypeID > 0)
                {
                    objWorkType = WorkTypeService.GetByWorkTypeId(WorkTypeID);
                }
                
                objWorkType.WorkTypeName = txtWorkTypeName.Text;
                objWorkType.Valid = chkWorkTypeValid.Checked;

                if (WorkTypeID > 0)
                {
                    WorkTypeService.Update(objWorkType);
                }
                else
                {
                    Response.Redirect("worktype.aspx");

                    // Insert is commented out for webservice purposes - Ditto 21/02/2013
                    // WorkTypeService.Insert(objWorkType);
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objWorkType.Dispose();
            }
            Response.Redirect("worktype.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("worktype.aspx");
    }

    #endregion
}


