
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

public partial class JobsArchiveEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "JobsArchiveEdit.aspx?{0}", JobsArchiveDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "JobsArchiveEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "JobsArchive.aspx");
		FormUtil.SetDefaultMode(FormView1, "JobId");
	}
	protected void GridViewJobArea1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("JobAreaId={0}", GridViewJobArea1.SelectedDataKey.Values[0]);
		Response.Redirect("JobAreaEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewJobRoles2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("JobRoleId={0}", GridViewJobRoles2.SelectedDataKey.Values[0]);
		Response.Redirect("JobRolesEdit.aspx?" + urlParams, true);		
	}	
}


