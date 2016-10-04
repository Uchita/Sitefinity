using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Collections;
using SocialMedia.Client.Monash;
using JXTPortal.Entities;
using System.Configuration;

namespace JXTPortal.Website.member.sso.monash
{
    public partial class login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request["logout"] != null)

            //Response.Redirect("https://login-qa.monash.edu/adfs/ls/?SAMLRequest=fZHRT8IwEMb%2flaXvXQuCjoYtQXmQBCOB6YMvpnQda7JeR68z%2fPlWphFjwuPX%2b767%2b13nKG3biUUfGtjqY68xJKtlTt5HdVWPJ1VG76RSdHKrpzRTs4yqWa1UNqqi4CR51R6Ng5yM06hWiL1eAQYJIT7x0ZTyGeWTknPBbwQfv5Fk411wyrX3BioDh5z0HoSTaFCAtBpFUGK3eFqL2FHsBxOKx7Lc0M3zriTJAlH7EIc%2bOMDear%2fT%2fsMo%2fbJd56QJoUPBWOuUbBuHgVlt99ozRMesA4lNrB0MpBK7E0mWkdeADGeG33A00KNMh0Cqq57JqkbWIiPJybaA4ny268t336SkmH%2b5xfk6%2fiJ%2fPS5%2fOEnxj2rOLjoWg%2fr7icUn");

            // If already logged in - then redirect to advanced search page.
            if (SessionData.Member != null)
                Response.Redirect("~/advancedsearch.aspx?search=1");

            string rawSamlData = Request["SAMLResponse"];

            if (!string.IsNullOrWhiteSpace(rawSamlData))
            {
                //Response.Write(Request["SAMLResponse"]);
                //Response.End();
                
                MonashSamlSSO monashSamlSSO = new MonashSamlSSO();

                string errormsg = string.Empty;

                bool blnSave = monashSamlSSO.SaveMemberAndLogin(rawSamlData, ref errormsg);

                // If logged in.
                if (blnSave && SessionData.Member != null)
                    Response.Redirect("~/advancedsearch.aspx?search=1");
                else
                {
                    // If not authorised to access Monash SSO - only staff can access.
                    Response.Write(@"<h1><a href='http://www.monash.edu' target='_blank'><img style='max-width: 100%;' alt='Monash University' src='http://images.jxt.net.au/monash-university/images/logo.png'></a></h1>

<div>
	<p style='font-family: Arial,Helvetica,sans-serif;'>Please note that only Monash University staff have access to this site.  If you are as staff member, please try again. 
    If you continue to receive this message please <a href='http://www.jobs-monash.jxt.net.au/contact' target='_blank'><strong>contact us</strong></a> with further information.  
    We apologise for any inconvenience caused.
 
	</p>
</div>");
                    //Response.Write(samlAssertion);                    
                    Response.End();
                }
            }
            else
            {
                // If not logged in - redirect to Monash SSO.
                MonashSamlSSO.AuthnRequest req = new MonashSamlSSO.AuthnRequest(bool.Parse(ConfigurationManager.AppSettings["MonashSAMLSSOLive"]));

                //Response.Write(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/member/sso/monash/login.aspx");
                //Response.Write(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority);
                //Response.End();
                Response.Redirect(req.idpIssuerUrl + "?SAMLRequest=" + Server.UrlEncode(req.GetRequest()));
            }

            // If not logged in.
            Response.Redirect("~/");
        }
         
        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] keys = Request.Form.AllKeys;

            for (int i = 0; i < keys.Length; i++)
            {
                // here you get the name eg test[0].quantity
                // keys[i];
                // to get the value you use
                Response.Write(string.Format("<br>{0} - {1}", keys[i], Request.Form[keys[i]]));
            }
            Response.Write(("<br><br><br>"));
            // spec says "SAMLResponse=" 
            string rawSamlData = Request["SAMLResponse"];

            // the sample data sent us may be already encoded, 
            // which results in double encoding
            if (!string.IsNullOrWhiteSpace(rawSamlData) && rawSamlData.Contains('%'))
            {
                rawSamlData = HttpUtility.UrlDecode(rawSamlData);
            }

            string samlAssertion = string.Empty;

            if (!string.IsNullOrWhiteSpace(rawSamlData))
            {
                // read the base64 encoded bytes
                byte[] samlData = Convert.FromBase64String(rawSamlData);

                // read back into a UTF string
                samlAssertion = System.Text.Encoding.UTF8.GetString(samlData);

                //Response.Write(samlAssertion);
            }

            string[] readText = System.IO.File.ReadAllLines(@"C:\\Temp\\monash_response.xml");
            System.Text.StringBuilder strbuild = new System.Text.StringBuilder();
            foreach (string s in readText)
            {
                strbuild.Append(s);
                strbuild.AppendLine();
            }


            MonashSamlSSO monashSamlSSO = new MonashSamlSSO();
            if (!monashSamlSSO.IsValidSignature(strbuild.ToString()))
            {
                Response.Write("Not a valid certificate");

            }
            else
                Response.Write("Valid certificate");

            Response.End();

            System.Xml.Linq.XDocument xDocument = System.Xml.Linq.XDocument.Parse(samlAssertion); //strbuild.ToString()

            xDocument = StripNamespace(xDocument);
            Response.Write(xDocument.ToString());


            var ns = string.Empty; // xDocument.Root.Name.Namespace;
            var roles = xDocument.Descendants(ns + "Attribute").Select(c => new MemberMapping()
                        {
                            AttributeName = c.Attribute(ns + "Name").Value,
                            AttributeValue = c.Element(ns + "AttributeValue").Value,
                        });

            if (roles.Count() > 0)
            {
                foreach (var item in roles)
                {
                    Response.Write(string.Format("<br>{0} - {1}", item.AttributeName, item.AttributeValue));
                }
            }
            else
            {
                Response.Write("Not found");
            }
        }



        public class MemberMapping
        {
            public string AttributeName { get; set; }
            public string AttributeValue { get; set; }
        }

        public XDocument StripNamespace(XDocument document)
        {
            if (document.Root == null)
            {
                return document;
            }
            foreach (var element in document.Root.DescendantsAndSelf())
            {
                element.Name = element.Name.LocalName;
                element.ReplaceAttributes(GetAttributes(element));
            }

            return document;
        }

        IEnumerable GetAttributes(XElement xElement)
        {
            return xElement.Attributes()
                .Where(x => !x.IsNamespaceDeclaration)
                .Select(x => new XAttribute(x.Name.LocalName, x.Value));
        }
        */
    }
}