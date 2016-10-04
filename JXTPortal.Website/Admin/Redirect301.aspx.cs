using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Web.UI;
using JXTPortal;

namespace JXTPortal.Website.Admin
{
    public partial class Redirect301 : System.Web.UI.Page
    {
        
        CacheObject CacheObject = new CacheObject();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            
            if (!Page.IsPostBack)
            {
                // Load the URLs from the file.
                LoadUrls();

                RefreshCache();
            }
        }

        private void LoadUrls()
        {
            try
            {
                List<RedirectUrl> redirecturllist = new List<RedirectUrl>();
                string fileurl = ConfigurationManager.AppSettings["301RedirectUrlFolder"] + "Site.xml";

                
                if (File.Exists(fileurl))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(fileurl);

                    XmlNodeList redirectnodes = xmldoc.GetElementsByTagName("redirection");
                    foreach (XmlNode redirectnode in redirectnodes)
                    {
                        XmlNode fromnode = redirectnode.SelectSingleNode("from");
                        XmlNode tonode = redirectnode.SelectSingleNode("to");

                        RedirectUrl redirecturl = new RedirectUrl();
                        redirecturl.From = fromnode.InnerText;
                        redirecturl.To = tonode.InnerText;

                        tbUrls.Text += fromnode.InnerText + "\t" + tonode.InnerText + "\n";
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "Failed to load file. - " + ex.Message;
                lblErrorMsg.Visible = true;
            }
        }

        protected void RefreshCache()
        {
            redirection[] redirect = CacheObject.GetCacheRedirects();

            if (redirect != null)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("<table class='grid' border='0'>");
                foreach (redirection item in redirect)
                {
                    strBuilder.AppendFormat("<tr><td>{0}</td><td>{1}</td></tr>", item.from, item.to);
                }
                strBuilder.Append("</table>");

                ltlCache.Text = strBuilder.ToString();
            }

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCache();

            lblErrorMsg.Text = "Refreshed cache on Server - " + JXTPortal.Common.Utils.GetHostName();
            lblErrorMsg.Visible = true;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {


            string fileurl = CacheObject.GET_REDIRECT_PATH;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" ?>");
            builder.AppendLine("<root><redirections>");

            string[] lines = tbUrls.Text.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] splits = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (splits.Length == 2 && !string.IsNullOrWhiteSpace(splits[0]) && !string.IsNullOrWhiteSpace(splits[1]))
                {
                    builder.AppendLine("<redirection>");
                    builder.AppendLine(string.Format("<from><![CDATA[{0}]]></from>", splits[0].Trim()));
                    builder.AppendLine(string.Format("<to><![CDATA[{0}]]></to>", splits[1].Trim()));
                    builder.AppendLine("</redirection>");

                }
                else
                {
                    // Error
                    lblErrorMsg.Text = "Error - Invalid Redirect Urls - " + line;
                    lblErrorMsg.Visible = true;

                    return;
                }
            }

            builder.AppendLine("</redirections></root>");
            File.WriteAllText(fileurl, builder.ToString());

            // Refresh cache
            CacheObject.SetCacheRedirects();

            RefreshCache();

            lblErrorMsg.Text = "Redirects saved successfully and refreshed cache on Server - " + JXTPortal.Common.Utils.GetHostName();
            lblErrorMsg.Visible = true;
        }

    }

    internal class RedirectUrl
    {
        public string From { get; set; }
        public string To { get; set; }

        public RedirectUrl() { }
    }
}