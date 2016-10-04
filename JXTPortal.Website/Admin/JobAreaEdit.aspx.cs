
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

public partial class JobAreaEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "JobAreaEdit.aspx?{0}", JobAreaDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "JobAreaEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "JobArea.aspx");
		FormUtil.SetDefaultMode(FormView1, "JobAreaId");
	}
}


