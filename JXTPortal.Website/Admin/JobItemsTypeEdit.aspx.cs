
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

public partial class JobItemsTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "JobItemsTypeEdit.aspx?{0}", JobItemsTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "JobItemsTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "JobItemsType.aspx");
		FormUtil.SetDefaultMode(FormView1, "JobItemTypeId");
	}
	protected void GridViewJobs1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("JobId={0}", GridViewJobs1.SelectedDataKey.Values[0]);
		Response.Redirect("JobsEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewJobsArchive2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("JobId={0}", GridViewJobsArchive2.SelectedDataKey.Values[0]);
		Response.Redirect("JobsArchiveEdit.aspx?" + urlParams, true);		
	}	
}


