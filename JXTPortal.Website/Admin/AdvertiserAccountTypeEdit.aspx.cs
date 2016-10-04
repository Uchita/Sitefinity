
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

public partial class AdvertiserAccountTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AdvertiserAccountTypeEdit.aspx?{0}", AdvertiserAccountTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AdvertiserAccountTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AdvertiserAccountType.aspx");
		FormUtil.SetDefaultMode(FormView1, "AdvertiserAccountTypeId");
	}
}


