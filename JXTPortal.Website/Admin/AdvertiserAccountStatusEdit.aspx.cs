
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

public partial class AdvertiserAccountStatusEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AdvertiserAccountStatusEdit.aspx?{0}", AdvertiserAccountStatusDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AdvertiserAccountStatusEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AdvertiserAccountStatus.aspx");
		FormUtil.SetDefaultMode(FormView1, "AdvertiserAccountStatusId");
	}
}


