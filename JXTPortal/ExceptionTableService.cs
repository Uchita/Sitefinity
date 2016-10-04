	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Web;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;
using System.Text;

using JXTPortal.Data;
using JXTPortal.Common;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'ExceptionTable' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ExceptionTableService : JXTPortal.ExceptionTableServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ExceptionTableService class.
		/// </summary>
		public ExceptionTableService() : base()
		{
		}

        public ExceptionTableService(string source, string message)
            : base()
        {
            LogException(source, message);
        }

        public int LogException(Exception ex)
        {
            using (ExceptionTable exTable = new ExceptionTable())
            {

                exTable.ClientIpAddress = Utils.GetClientIPAddress();
                exTable.HostIpAddress = Utils.GetHostName();
                exTable.ExceptionUrl = HttpContext.Current != null && HttpContext.Current.Request != null ? HttpContext.Current.Request.Url.ToString() : string.Empty;
                exTable.ExceptionApplicationSource = ex.Source;
                exTable.ExceptionMessage = ex.Message;
                exTable.ExceptionStackTrace = ex.StackTrace;
                exTable.ErrorParamsMessage = FormatErrorMessageTable(true);
                exTable.DateEntered = DateTime.Now;
                Insert(exTable);

                return exTable.ExceptionId;
            }
        }

        public int LogException(Exception ex, string additionalStackTrace)
        {

            using (ExceptionTable exTable = new ExceptionTable())
            {

                exTable.ClientIpAddress = Utils.GetClientIPAddress();
                exTable.HostIpAddress = Utils.GetHostName();
                exTable.ExceptionUrl = HttpContext.Current != null && HttpContext.Current.Request != null ? HttpContext.Current.Request.Url.ToString() : string.Empty;
                exTable.ExceptionApplicationSource = (ex.Source != null) ? ex.Source : string.Empty;
                exTable.ExceptionMessage = (ex.Message != null) ? ex.Message : string.Empty;
                exTable.ExceptionStackTrace = "==== Additional Stack Trace ====<br/><br/>" + additionalStackTrace + "<br/><br/>==============<br/><br/>" + ((ex.StackTrace != null) ? ex.StackTrace : string.Empty);
                exTable.ErrorParamsMessage = FormatErrorMessageTable(true);
                exTable.DateEntered = DateTime.Now;
                Insert(exTable);

                return exTable.ExceptionId;
            }
        }


        public int LogException(string source, string message)
        {
            if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(message))
            {
                using (ExceptionTable exTable = new ExceptionTable())
                {

                    exTable.ClientIpAddress = Utils.GetClientIPAddress();
                    exTable.HostIpAddress = Utils.GetHostName();
                    exTable.ExceptionUrl = HttpContext.Current != null && HttpContext.Current.Request != null ? HttpContext.Current.Request.Url.ToString() : string.Empty;
                    exTable.ExceptionApplicationSource = source;
                    exTable.ExceptionMessage = message;
                    exTable.ExceptionStackTrace = string.Empty;
                    exTable.ErrorParamsMessage = FormatErrorMessageTable(true);
                    exTable.DateEntered = DateTime.Now;
                    Insert(exTable);

                    return exTable.ExceptionId;
                }
            }

            return 0;
        }

        private string FormatErrorMessageTable(bool useHttpContext) //, ExceptionDataset.UserExceptionParameterDataTable userExceptionParameters
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table class='grid-err' border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tbody><tr class='grid-header'><th align=\"left\">Type</th><th align=\"left\">Key</th><th align=\"left\">Value</td></th>");
            // Retrieve all params
            // InsertApplicationParameterValues
            if (useHttpContext && HttpContext.Current != null)
            {
                if (HttpContext.Current.Application.AllKeys.Length > 0)
                {
                    sb.Append("<tr><td colspan=\"3\"><h2>Application</h2></tr>");

                    foreach (string strKey in HttpContext.Current.Application.AllKeys)
                    {
                        sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Application", strKey, HttpContext.Current.Application.Get(strKey).ToString().Replace("\n", "<br />")));
                    }
                }

                // InsertSessionParameterValues
                try
                {
                    System.Collections.Specialized.NameObjectCollectionBase.KeysCollection objKeys = HttpContext.Current.Session.Keys;
                    if (objKeys.Count > 0)
                    {
                        sb.Append("<tr><td colspan=\"3\"><h2>Session</h2></tr>");

                        for (int i = 0; i < objKeys.Count; i++)
                        {
                            string strKey = objKeys.Get(i);
                            object objValue = HttpContext.Current.Session[strKey];
                            sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Session", strKey, objValue.ToString().Replace("\n", "<br />")));
                        }
                    }
                }
                catch
                { };

                // Load request parameters
                if (HttpContext.Current.Request.Params.AllKeys.Length > 0)
                {
                    sb.Append("<tr><td colspan=\"3\"><h2>Request Params</h2></tr>");
                    foreach (string strKey in HttpContext.Current.Request.Params.AllKeys)
                    {
                        // We don't need __EVENTVALIDATION
                        if (strKey != null)
                        {
                            if (!strKey.Contains("VIEWSTATE") && !strKey.Contains("EVENTVALIDATION"))
                                sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Request Params", strKey, HttpContext.Current.Request.Params.Get(strKey).ToString().Replace("\n", "<br />")));
                        }
                    }
                }

                // Load Request cookies
                if (HttpContext.Current.Request.Cookies.AllKeys.Length > 0)
                {
                    sb.Append("<tr><td colspan=\"3\"><h2>Request Cookies</h2></tr>");
                    foreach (string strCookieName in HttpContext.Current.Request.Cookies.AllKeys)
                    {
                        HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(strCookieName);
                        sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Request Cookies", strCookieName, cookie.Value.Replace("\n", "<br />")));
                    }
                }

                // Load request query string
                if (HttpContext.Current.Request.QueryString.AllKeys.Length > 0)
                {
                    sb.Append("<tr><td colspan=\"3\"><h2>Request Query String</h2></tr>");
                    foreach (string strKey in HttpContext.Current.Request.QueryString.AllKeys)
                    {
                        sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Request Query String", strKey, HttpContext.Current.Request.QueryString.Get(strKey).ToString().Replace("\n", "<br />")));
                    }
                }

                // Load request form
                if (HttpContext.Current.Request.Form.AllKeys.Length > 0)
                {
                    sb.Append("<tr><td colspan=\"3\"><h2>Request Form</h2></tr>");
                    foreach (string strKey in HttpContext.Current.Request.Form.AllKeys)
                    {
                        if (strKey != null)
                        {
                            if (!strKey.Contains("VIEWSTATE") && !strKey.Contains("EVENTVALIDATION"))
                                sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Request Form", strKey, HttpContext.Current.Request.Form.Get(strKey).ToString().Replace("\n", "<br />")));
                        }
                    }
                }

                // Load Server Variables
                if (HttpContext.Current.Request.ServerVariables.AllKeys.Length > 0)
                {
                    sb.Append("<tr><td colspan=\"3\"><h2>Server Variables</h2></tr>");
                    foreach (string strServerVariableKey in HttpContext.Current.Request.ServerVariables.AllKeys)
                    {
                        string strServerVariableValue = HttpContext.Current.Request.ServerVariables.Get(strServerVariableKey);
                        sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "Server Variables", strServerVariableKey, strServerVariableValue.Replace("\n", "<br />")));
                    }
                }
            }

            /*
            if (userExceptionParameters != null)
            {
                if (userExceptionParameters.Rows.Count > 0)
                {
                    sb.Append("<tr><td colspan=\"3\"><h2>User</h2></tr>");
                    foreach (ExceptionDataset.UserExceptionParameterRow dr in userExceptionParameters.Rows)
                    {
                        sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", "User", dr.exceptionParameterKey, dr.exceptionParameterValue.Replace("\n", "<br />")));
                    }
                }
            }*/

            sb.Append("</tbody></table>");

            return sb.ToString();
        }
		#endregion Constructors
		
	}//End Class

} // end namespace
