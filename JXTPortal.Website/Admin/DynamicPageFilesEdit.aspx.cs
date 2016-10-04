
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

public partial class DynamicPageFilesEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DynamicPageFilesEdit.aspx?{0}", DynamicPageFilesDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DynamicPageFilesEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "DynamicPageFiles.aspx");
		FormUtil.SetDefaultMode(FormView1, "DynamicPageFileId");
	}
}


