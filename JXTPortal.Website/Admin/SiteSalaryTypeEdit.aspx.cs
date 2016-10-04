
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

public partial class SiteSalaryTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SiteSalaryTypeEdit.aspx?{0}", SiteSalaryTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SiteSalaryTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SiteSalaryType.aspx");
		FormUtil.SetDefaultMode(FormView1, "SiteSalaryTypeId");
	}
}


