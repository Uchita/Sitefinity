using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.Admin
{
    public partial class ExceptionView : System.Web.UI.Page
    {

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ExceptionID"]))
            {

                ExceptionTableService exceptionService = new ExceptionTableService();

                JXTPortal.Entities.ExceptionTable exceptionTable = exceptionService.GetByExceptionId(Convert.ToInt32(Request.QueryString["ExceptionID"]));

                if (exceptionTable != null)
                {
                    ltlException.Text = String.Format(@"
<table class='grid-err' cellpadding='0' cellspacing='0'>
    <tr><td>ExceptionID:</td><td>{0}</td></tr>
    <tr><td>DateEntered:</td><td>{1}</td></tr>
    <tr><td>ExceptionApplicationSource:</td><td>{2}</td></tr>
    <tr><td>ClientIPAddress:</td><td>{3}</td></tr>
    <tr><td>HostIPAddress:</td><td>{4}</td></tr>
    <tr><td>ExceptionUrl:</td><td>{5}</td></tr>
    <tr><td>ExceptionMessage:</td><td>{6}</td></tr>
    <tr><td>ExceptionStackTrace:</td><td>{7}</td></tr>
</table>
<br />
{8}
", 
         exceptionTable.ExceptionId, exceptionTable.DateEntered, exceptionTable.ExceptionApplicationSource, exceptionTable.ClientIpAddress,
            exceptionTable.HostIpAddress, exceptionTable.ExceptionUrl, exceptionTable.ExceptionMessage, exceptionTable.ExceptionStackTrace, 
            exceptionTable.ErrorParamsMessage);
                }
            }
        }

        #endregion

    }
}
