
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

public partial class FoldersEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "FoldersEdit.aspx?{0}", FoldersDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "FoldersEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Folders.aspx");
		FormUtil.SetDefaultMode(FormView1, "FolderId");
	}
	protected void GridViewFiles1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("FileId={0}", GridViewFiles1.SelectedDataKey.Values[0]);
		Response.Redirect("FilesEdit.aspx?" + urlParams, true);		
	}	
}


