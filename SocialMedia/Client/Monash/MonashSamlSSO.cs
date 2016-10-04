using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Collections;
using JXTPortal;
using JXTPortal.Entities;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Configuration;

namespace SocialMedia.Client.Monash
{
    public class MonashSamlSSO
    {
        public MonashSamlSSO()
        {
        }
        /*
         <attributestatement>
            <attribute name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname">
                <attributevalue>Adfs</attributevalue>
            </attribute>
            <attribute name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname">
                <attributevalue>Staff-Eight</attributevalue>
            </attribute>
            <attribute name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress">
                <attributevalue>Adfs.Staff08@monash.edu</attributevalue>
            </attribute>
        </attributestatement>
             
         */

        public class MonashMemberMapping
        {
            public string AttributeName { get; set; }
            public string AttributeValue { get; set; }
        }


        #region SAML

        public class ConsumeResponse
        {
            private XmlDocument xmlDoc;
            private Certificate certificate;

            public ConsumeResponse()
            {
                certificate = new Certificate();
                certificate.loadCert();
            }

            public void LoadXml(string xml)
            {
                xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.LoadXml(xml);
            }

            public string LoadXmlFromBase64(string response)
            {
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                LoadXml(enc.GetString(Convert.FromBase64String(response)));
                return response;
            }

            public bool isAuthenticated()
            {
                bool status = false;
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                XmlNodeList nodeList = xmlDoc.SelectNodes("//ds:Signature", manager);

                SignedXml signedXml = new SignedXml(xmlDoc);
                foreach (XmlNode node in nodeList)
                {
                    signedXml.LoadXml((XmlElement)node);
                    try
                    {
                        status = signedXml.CheckSignature(certificate.cert, true);
                    }
                    catch { }
                    if (!status)
                        return false;
                    return status;
                }
                return status;
            }

            public string getSubject()
            {
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
                manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

                XmlNode node = xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:Subject/saml:NameID", manager);
                return node.InnerText;
            }
            public string getUsername()
            {
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
                manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

                XmlNode node = xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='username']", manager);
                return node.InnerText;
            }

            public string getEmail()
            {
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
                manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

                XmlNode node = xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='email']", manager);
                return node.InnerText;
            }

            public string getPortalUser()
            {
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
                manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

                XmlNode node = xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='is_portal_user']", manager);
                return node.InnerText;
            }
        }

        public class AuthnRequest
        {
            public string id;
            private string issueInstant;


            public String idpIssuerUrl;
            public String certificateFileName;
            public String issuer;
            public String assertionConsumerServiceUrl;
            public static String logoutUrl = "https://my.monash.edu";


            public AuthnRequest(bool isLive)
            {
                //SalesforceIdentity.LoadProperties.initProperties();
                id = "_" + System.Guid.NewGuid().ToString();
                issueInstant = System.DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                

                if (!isLive)
                {
                    //certificateFileName=SelfSignedCert_06Mar2013(1).cer

                    if (HttpContext.Current.Request.IsLocal)
                    {
                        assertionConsumerServiceUrl = "https://localhost/member/sso/monash/login.aspx";
                        issuer = "https://localhost";
                    }
                    else
                    {
                        assertionConsumerServiceUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/member/sso/monash/login.aspx";
                        issuer = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                    }

                    
                    idpIssuerUrl = "https://login-qa.monash.edu/adfs/ls/";
                    //https://login-qa.monash.edu/adfs/ls/?SAMLRequest=fZHNbsIwEIRfxfLd2EBAxCKRaDkUiaoI0h56qUzsEFexnXrtisdvflqJXjju7syuvtk1CNO0fBNDbY%2fqKyoIaLfN8EcyXZRzJhmZrdIpSc5SknQpZqSSlVSVSoVMVhi9KQ%2fa2QzPJgyjHUBUOwtB2NC12HRBWErYvGBLniw4W71jdPAuuNI1D9pKbS8Zjt5yJ0ADt8Io4KHkp83znncb%2bXkUAX8qigM5vJwKjDYAyofu6KOzEI3yJ%2bW%2fdalej%2fsM1yG0wCltXCma2kGgRpmz8hTAUeOsgLqbXbSdCGivGG07Xm1FGBh68%2bDt56N4omSkQlZAYbwCNPgIAaOraSzwIb37DO0vMM7XvZoPIfkb%2f327%2bMPFeS8mn9ewpjeL8rH6%2f8L8Bw%3d%3d
                }
                else
                {
                    assertionConsumerServiceUrl = "https://" + (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl + "/member/sso/monash/login.aspx";
                    issuer = "https://" + (SessionData.Site.WWWRedirect ? "www." : string.Empty) + SessionData.Site.SiteUrl;
                    idpIssuerUrl = "https://login.monash.edu/adfs/ls/";
                }

            }

            public static void Logout()
            {

                if (ConfigurationManager.AppSettings["MonashSAMLSSOSiteId"] != null
                        && ConfigurationManager.AppSettings["MonashSAMLSSOSiteId"].Contains(string.Format(" {0} ", JXTPortal.Entities.SessionData.Site.SiteId)))
                {
                    HttpContext.Current.Response.Redirect(logoutUrl);
                    return;
                }
            }

            public string GetRequest()
            {

                using (StringWriter writer = new StringWriter())
                {
                    XmlWriterSettings writerSetting = new XmlWriterSettings();
                    writerSetting.OmitXmlDeclaration = true;

                    using (XmlWriter xmlWriter = XmlWriter.Create(writer, writerSetting))
                    {
                        xmlWriter.WriteStartElement("samlp", "AuthnRequest", "urn:oasis:names:tc:SAML:2.0:protocol");
                        xmlWriter.WriteAttributeString("ID", id);
                        xmlWriter.WriteAttributeString("Version", "2.0");
                        xmlWriter.WriteAttributeString("IssueInstant", issueInstant);
                        xmlWriter.WriteAttributeString("ProtocolBinding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST");
                        xmlWriter.WriteAttributeString("AssertionConsumerServiceURL", assertionConsumerServiceUrl);
                        xmlWriter.WriteAttributeString("Destination", idpIssuerUrl);
                        xmlWriter.WriteStartElement("saml", "Issuer", "urn:oasis:names:tc:SAML:2.0:assertion");
                        xmlWriter.WriteString(issuer);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                    }

                    byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(writer.ToString());
                    using (MemoryStream output = new MemoryStream())
                    {
                        using (DeflateStream zip = new DeflateStream(output, CompressionMode.Compress))
                            zip.Write(toEncodeAsBytes, 0, toEncodeAsBytes.Length);
                        byte[] compressed = output.ToArray();
                        return System.Convert.ToBase64String(compressed);
                    }
                    return string.Empty;
                }
            }
        }

        public class Certificate
        {
            public X509Certificate2 cert;

            public void loadCert()
            {
                try
                {
                    cert = new X509Certificate2();
                    string strHttpRuntimePath = HttpRuntime.AppDomainAppPath;

                    //cert.Import(strHttpRuntimePath + LoadProperties.certificateFileName);

                }
                catch (CryptographicException e)
                {
                }

            }
        }

        #endregion




        #region Methods

        public bool SaveMemberAndLogin(string SAMLResponse, ref string errormsg)
        {
            // the sample data sent us may be already encoded, 
            // which results in double encoding
            if (!string.IsNullOrWhiteSpace(SAMLResponse) && SAMLResponse.Contains('%'))
            {
                SAMLResponse = HttpUtility.UrlDecode(SAMLResponse);
            }
            string samlAssertion = string.Empty;

            if (!string.IsNullOrWhiteSpace(SAMLResponse))
            {
                // read the base64 encoded bytes
                byte[] samlData = Convert.FromBase64String(SAMLResponse);

                // read back into a UTF string
                samlAssertion = System.Text.Encoding.UTF8.GetString(samlData);
                

                System.Xml.Linq.XDocument xDocument = System.Xml.Linq.XDocument.Parse(samlAssertion); //strbuild.ToString()

                xDocument = StripNamespace(xDocument);

                /*if (!IsValidSignature(xDocument.ToString()))
                {
                    throw new Exception("Not a valid certificate");
                    errormsg = "Not a valid certificate";

                    return false;
                }*/

                var ns = string.Empty; // xDocument.Root.Name.Namespace;
                IEnumerable<MonashMemberMapping> MemberAttributes = xDocument.Descendants(ns + "Attribute").Select(c => new MonashMemberMapping()
                {
                    AttributeName = c.Attribute(ns + "Name").Value,
                    AttributeValue = c.Element(ns + "AttributeValue").Value,
                });

                if (MemberAttributes.Count() > 0)
                {
                    /* http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname - Adfs
                     * http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname - Staff-Eight
                     * http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress - Adfs.Staff08@monash.edu
                    */

                    string firstName = GetAttributeValue(MemberAttributes, "givenname");
                    string lastName = GetAttributeValue(MemberAttributes, "surname");
                    string emailAddress = GetAttributeValue(MemberAttributes, "emailaddress");

                    if (!string.IsNullOrWhiteSpace(emailAddress))
                    {
                        // Save member
                        int memberid = 0;

                        MembersService memberservice = new MembersService();
                        bool blnResult = memberservice.SaveMemberAndLogin(SessionData.Site.SiteId, string.Empty, string.Empty,
                                                                            firstName, lastName, emailAddress, string.Empty, ref memberid, ref errormsg);

                        return blnResult;
                    }
                    else
                    {
                        // Failed
                        return false;
                    }
                    /*
                    foreach (var item in MemberAttributes)
                    {
                        Response.Write(string.Format("<br>{0} - {1}", item.AttributeName, item.AttributeValue));
                    }*/
                }
                else
                {
                    //Response.Write("Not found");
                }
            }

            return false;
        }

        #endregion

        #region Common Methods

        public bool IsValidSignature(string samlAssertion)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(samlAssertion);
            /*
            SignedXml signedXml = new SignedXml(xmlDoc);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("ds:Signature");

            if (nodeList != null && nodeList.Count > 0)
            {
                //signedXml.SigningKey = key;
                //signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

                signedXml.LoadXml((XmlElement)nodeList[0]);
                return signedXml.CheckSignature();
            }*/

            return false;
        }

        private XDocument StripNamespace(XDocument document)
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

        private string GetAttributeValue(IEnumerable<MonashMemberMapping> _MemberAttributes, string name)
        {
            if (_MemberAttributes.Where(s => s.AttributeName.Contains(name)).FirstOrDefault() != null)
            {
                return _MemberAttributes.Where(s => s.AttributeName.Contains(name)).FirstOrDefault().AttributeValue;
            }

            return string.Empty;
        }

        #endregion



        

    }



}
/*
<samlp:response id="_27176564-c718-4875-9b33-89ad9cdef740" version="2.0" issueinstant="2015-06-29T01:23:04.185Z" destination="https://localhost/member/sso/monash/login.aspx" consent="urn:oasis:names:tc:SAML:2.0:consent:unspecified" xmlns:samlp="urn:oasis:names:tc:SAML:2.0:protocol">
	<issuer xmlns="urn:oasis:names:tc:SAML:2.0:assertion">http://login-qa.monash.edu/adfs/services/trust</issuer>
	<samlp:status>
		<samlp:statuscode value="urn:oasis:names:tc:SAML:2.0:status:Success"/>
	</samlp:status>
	<assertion id="_877e04ef-7926-48a2-8815-95052b45ed2a" issueinstant="2015-06-29T01:23:04.185Z" version="2.0" xmlns="urn:oasis:names:tc:SAML:2.0:assertion">
		<issuer>http://login-qa.monash.edu/adfs/services/trust</issuer>
		<ds:signature xmlns:ds="http://www.w3.org/2000/09/xmldsig#">
			<ds:signedinfo>
				<ds:canonicalizationmethod algorithm="http://www.w3.org/2001/10/xml-exc-c14n#">
					<ds:signaturemethod algorithm="http://www.w3.org/2001/04/xmldsig-more#rsa-sha256">
						<ds:reference uri="#_877e04ef-7926-48a2-8815-95052b45ed2a">
							<ds:transforms>
								<ds:transform algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature">
									<ds:transform algorithm="http://www.w3.org/2001/10/xml-exc-c14n#"/>
								</ds:transform>
							</ds:transforms>
							<ds:digestmethod algorithm="http://www.w3.org/2001/04/xmlenc#sha256">
								<ds:digestvalue>yX8hnJPiowP06vWF1C4qSNAhN8Ol6+/LDPq/pLqsqpc=</ds:digestvalue>
							</ds:digestmethod>
						</ds:reference>
					</ds:signaturemethod>
				</ds:canonicalizationmethod>
			</ds:signedinfo>
			<ds:signaturevalue>gbNBNQHj1xC4vAF/oupcVRlZlyI/SNTvPfhXRnwnUodIeRZcnRo3HsEIXdFX5pCksmfvvu5WpKtwt/3P7MPrLIh0L3BKcUDh/YWFHT/rA0bHCHzUhH1/FQL3pKit7O50OitK5C8zeZZxnJLP+TArMjtN3WkBQpyTnqe8p0rZzcTiipYKnsUxvXQH71N5V7RQPDUX+vB0cBbgk9rkJc6uK+wOjNdpFYKEGp9ymIle0wDdxxBGLqPtLrLBGr4xzhX0pyLRsxk4cX+41kBSFXCCEBa7k8RB9ArtEloc++Ij8Isac5VraTVh18YIF5YptDBU3GtP++SWIjJZSah761Icpw==</ds:signaturevalue>
			<keyinfo xmlns="http://www.w3.org/2000/09/xmldsig#">
				<ds:x509data>
					<ds:x509certificate>MIIC4jCCAcqgAwIBAgIQZF5pUiOgspJDl6VtSCFKfzANBgkqhkiG9w0BAQsFADAtMSswKQYDVQQDEyJBREZTIFNpZ25pbmcgLSBsb2dpbi1xYS5tb25hc2guZWR1MB4XDTE0MTAzMTAyMzYzMVoXDTE1MTAzMTAyMzYzMVowLTErMCkGA1UEAxMiQURGUyBTaWduaW5nIC0gbG9naW4tcWEubW9uYXNoLmVkdTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAMEdpv9Qs2siKMC6EfI1sypvMlTd5HWrO6/CQgRJQIEIth3Tt040BStb5+jA9cXi5e62O87UWjRRhqBSSIrLU7J7SldzzDiM0aCchmZ/QDIZIL1w/bRZ6yrcvoYG2k+s37Qapj1aFXtwK330A9oHihr6wJFEDtjLA+/HnIaEI6AUWWjFKvqJmTvDMeGFAZSVHMCuMEGahjpYIBYNVZM7T5691d+PN8L/JK2TEMOSNFP4g6bq1Ll9Rq2Uy1/mLGJwlmNR30enrDk5RYaeDwoOBKyNlRWPhHnQE+Y7Zm7bjcgkJJ4NY739gAzLMRzoyJoQsLeo2Ru7fvNYHIIod8hCIdECAwEAATANBgkqhkiG9w0BAQsFAAOCAQEAqpTMAXkkoZ18MKVHDOnnjVsYaPG7Ql9TtXAi7JesnEIVeS0Az/z/WfCmZYomBZttblx3huLy6GUdK85KSsXjBzlloRL6RxUnpDI7BWSEdkpakKoy0RUQD9bix/l/O6M1QgxY7NbKipC55aEVH37WzFjzrgUgFHi5YTDPho4utuGH2LKREjgFGxTtPkYdMDQ1zp74osvfd2dUfLPOn2tldZT9YSaw8ivTe89gEtD4bGTwGaAXsEZaDMhq/nUM3KjYLjjC5ZS7j72bq1leKgPbmVkpdClYC+mSKQY5cUaVXZ+iQ4TK3sk2VtMExrUGfZEq1lw+fEDv2TH1gVAO/dC06Q==</ds:x509certificate>
				</ds:x509data>
			</keyinfo>
		</ds:signature>
		<subject>
			<subjectconfirmation method="urn:oasis:names:tc:SAML:2.0:cm:bearer">
				<subjectconfirmationdata notonorafter="2015-06-29T01:28:04.185Z" recipient="https://localhost/member/sso/monash/login.aspx"/>
			</subjectconfirmation>
		</subject>
		<conditions notbefore="2015-06-29T01:23:04.185Z" notonorafter="2015-06-29T02:23:04.185Z">
			<audiencerestriction>
				<audience>https://localhost/member/sso/monash/login.aspx</audience>
			</audiencerestriction>
		</conditions>
		<attributestatement>
			<attribute name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname">
				<attributevalue>Adfs</attributevalue>
			</attribute>
			<attribute name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname">
				<attributevalue>Staff-Eight</attributevalue>
			</attribute>
			<attribute name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress">
				<attributevalue>Adfs.Staff08@monash.edu</attributevalue>
			</attribute>
		</attributestatement>
		<authnstatement authninstant="2015-06-29T01:23:04.060Z">
			<authncontext>
				<authncontextclassref>urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport</authncontextclassref>
			</authncontext>
		</authnstatement>
	</assertion>
</samlp:response> 
 
 
 */