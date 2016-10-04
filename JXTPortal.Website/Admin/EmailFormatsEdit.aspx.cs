
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

public partial class EmailFormatsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "EmailFormatsEdit.aspx?{0}", EmailFormatsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "EmailFormatsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "EmailFormats.aspx");
		FormUtil.SetDefaultMode(FormView1, "EmailFormatId");
	}

}


