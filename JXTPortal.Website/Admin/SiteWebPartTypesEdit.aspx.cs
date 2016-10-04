﻿
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

public partial class SiteWebPartTypesEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SiteWebPartTypesEdit.aspx?{0}", SiteWebPartTypesDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SiteWebPartTypesEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SiteWebPartTypes.aspx");
		FormUtil.SetDefaultMode(FormView1, "SiteWebPartTypeId");
	}

}


