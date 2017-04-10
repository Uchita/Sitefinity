using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPosterTransform.Library.Services;
using JXTPosterTransform.Library.Common;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using JXTPosterTransform.Library.Methods;
using log4net;
using log4net.Core;

namespace JXTPosterTransform.ConsoleApp
{
    class Program
    {
        static ILog _logger;

        static void Main(string[] args)
        {
            _logger = LogManager.GetLogger(typeof(Program));

            if( args.Count() == 0)
                _logger.Debug("Application started with no arguments");
            else
                _logger.DebugFormat("Application started with arguments: {0}", String.Join(" ", args));

            //Add 3072 (TLS1.2) for this application
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)3072;

            int setupId = 0;
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++) // Loop through array
                {
                    if (int.TryParse(args[i], out setupId))
                    {
                    }
                }
            }

            TransformationService TransformationService = new TransformationService();
            TransformationService.DoTransformationWithMappings(setupId);
            //PostJobsWithTransformation("", "");

            //JobxTest();

            //PullXMLFromFTPTest();

            //PullWithAuthenticationTest();

            //PullXMLFromUrlTest();

            _logger.DebugFormat("Application finished with arguments: {0}", String.Join(" ", args));            
            Console.WriteLine("Done");

            
            //Console.ReadKey();
        }

        #region Test Methods

        public static void PostJobsWithTransformation(string xsl, string xml)
        {
            //TransformationService tService = new TransformationService();

            //tService.PostTransformationWithMappings(xsl, xml);
        }

        public static void PullXMLFromFTPTest()
        {
            PullXMLFromFTP pull = new PullXMLFromFTP();
            //string strXML = pull.ProcessXML();

            //Console.WriteLine(service.TransformXML(XSL, XML));
        }

        public static void PullXMLFromSFTPTest()
        {
            PullXMLFromSFTP pull = new PullXMLFromSFTP();
            //string strXML = pull.ProcessXML();

            //Console.WriteLine(service.TransformXML(XSL, XML));
        }

        public static void PullXMLFromUrlTest()
        {
            PullXMLFromURL pull = new PullXMLFromURL();
            //string XML = pull.ProcessXML("https://webservices.dc2.pageuppeople.com/JobsRest/JobListing.svc/513/caw/en");


            string XSL = @"<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>

    <xsl:template match='/'>
    <root>
        <xsl:apply-templates/>
    </root>
    </xsl:template>

    <xsl:template match='bookstore'>
    <!-- Prices and books -->
        <bookstore>
            <xsl:apply-templates select='book'/>
        </bookstore>
    </xsl:template>

    <xsl:template match='book'>
        <book>
            <xsl:attribute name='ISBN'>
                <xsl:value-of select='@ISBN'/>
            </xsl:attribute>
            <price><xsl:value-of select='price'/></price><xsl:text>
            </xsl:text>
        </book>
    </xsl:template>

</xsl:stylesheet>";
        }
        /*
        public static void PullWithAuthenticationTest()
        {
            string source = "http://jobfeeds.jxt3.net/";
            string strFilenameStartsWith = "Aspect219";

            PullXMLWithWebAuthentication PullXMLWithAuthentication = new PullXMLWithWebAuthentication();
            //PullXMLWithAuthentication.Username = "jobfeed";
            //PullXMLWithAuthentication.Password = "3,]Q?%Pi]v_H";

            XmlUrlResolver xmlResolver = new XmlUrlResolver(); // { Credentials = _jobAdder.CurrentNetworkCredential };
            xmlResolver.Credentials = new NetworkCredential("aspect_personnel_advertiser", "3W2bIsfVrNFd");
            string fileName = PullXMLWithAuthentication.ProcessXML(source, "jobfeed", "3,]Q?%Pi]v_H", strFilenameStartsWith);

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings() { XmlResolver = xmlResolver };
            XDocument xDocument = XDocument.Load(XmlReader.Create(source + fileName, xmlReaderSettings));

            
        }*/

        #endregion


        #region Temp methods

        public static void RunPoster(string XSL, string XML)
        {
            Console.WriteLine(Utils.TransformXML(XSL, XML));

        }

        public static void Example()
        {
            string XML = @"<?xml version='1.0'?>
<!-- This file represents a fragment of a book store inventory database -->
<bookstore>
  <book genre='autobiography' publicationdate='1981' ISBN='1-861003-11-0'>
    <title>The Autobiography of Benjamin Franklin</title>
    <author>
      <first-name>Benjamin</first-name>
      <last-name>Franklin</last-name>
    </author>
    <price>8.99</price>
  </book>
  <book genre='novel' publicationdate='1967' ISBN='0-201-63361-2'>
    <title>The Confidence Man</title>
    <author>
      <first-name>Herman</first-name>
      <last-name>Melville</last-name>
    </author>
    <price>11.99</price>
  </book>
  <book genre='philosophy' publicationdate='1991' ISBN='1-861001-57-6'>
    <title>The Gorgias</title>
    <author>
      <name>Plato</name>
    </author>
    <price>9.99</price>
  </book>
</bookstore>
";

            string XSL = @"<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>

    <xsl:template match='/'>
    <root>
        <xsl:apply-templates/>
    </root>
    </xsl:template>

    <xsl:template match='bookstore'>
    <!-- Prices and books -->
        <bookstore>
            <xsl:apply-templates select='book'/>
        </bookstore>
    </xsl:template>

    <xsl:template match='book'>
        <book>
            <xsl:attribute name='ISBN'>
                <xsl:value-of select='@ISBN'/>
            </xsl:attribute>
            <price><xsl:value-of select='price'/></price><xsl:text>
            </xsl:text>
        </book>
    </xsl:template>

</xsl:stylesheet>";

            RunPoster(XSL, XML);
        }

        public static void JobxTest()
        {
            string XSL = @"
<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
<xsl:output method=""xml"" cdata-section-elements=""TITLE DESCRIPTION ADDETAILS CONTACTDETAILS""/> 

<xsl:template match=""/"">

<JOBXPOSTINGS Version=""1.0"">
<CLIENT>
<xsl:attribute name=""ID"">
<xsl:value-of select=""JOBXPOSTINGS/CLIENT/@ID"" />
</xsl:attribute>
<xsl:for-each select=""JOBXPOSTINGS/CLIENT/JOB"">

<JOB>
<xsl:attribute name=""Reference"">
<xsl:value-of select=""./@Reference"" />
</xsl:attribute>

<JOBADTYPE>Normal</JOBADTYPE>
<TITLE>
<xsl:value-of select=""TITLE"" />
</TITLE>

<DESCRIPTION>
<xsl:value-of select=""DESCRIPTION"" />
</DESCRIPTION>

<ADDETAILS>
<xsl:value-of select=""ADDETAILS"" />
</ADDETAILS>

<HIDELOCATIONDETAILS>NO</HIDELOCATIONDETAILS>
<TEMPLATEID>
<xsl:value-of select=""TEMPLATEID"" />
</TEMPLATEID>
<CURRENCYID>1</CURRENCYID>

<RESIDENTSONLY>
<xsl:choose>
<xsl:when test=""ResidentsOnly='YES'"">YES</xsl:when>
<xsl:when test=""ResidentsOnly='TRUE'"">YES</xsl:when>
<xsl:when test=""ResidentsOnly='NO'"">NO</xsl:when>
<xsl:when test=""ResidentsOnly='FALSE'"">NO</xsl:when>
<xsl:otherwise>YES</xsl:otherwise>
</xsl:choose>
</RESIDENTSONLY>

<ISQUALIFICATIONSRECOGNISED>
<xsl:value-of select=""ISQUALIFICATIONSRECOGNISED"" />
</ISQUALIFICATIONSRECOGNISED>

<LISTING>
<CLASSIFICATION Name=""WORKTYPE"">
<xsl:value-of select=""LISTING/CLASSIFICATION[@Name='WORKTYPE']"" /></CLASSIFICATION>

<CLASSIFICATION Name=""SECTOR""><xsl:value-of select=""LISTING/CLASSIFICATION[@Name='SECTOR']"" /></CLASSIFICATION>

<CLASSIFICATION Name=""INDUSTRY"">
<xsl:value-of select=""LISTING/CLASSIFICATION[@Name='INDUSTRY']"" />
</CLASSIFICATION>

<xsl:choose>
<xsl:when test=""LISTING/CLASSIFICATION[@Name='COUNTRY'] = ''"">
<CLASSIFICATION Name=""COUNTRY"">Australia</CLASSIFICATION>
</xsl:when>
<xsl:when test=""LISTING/CLASSIFICATION[@Name='COUNTRY'] = 'OTHER'"">
<CLASSIFICATION Name=""COUNTRY"">OVERSEAS</CLASSIFICATION>
</xsl:when>
<xsl:otherwise>
<CLASSIFICATION Name=""COUNTRY"">
<xsl:value-of select=""LISTING/CLASSIFICATION[@Name='COUNTRY']"" />
</CLASSIFICATION>
</xsl:otherwise>
</xsl:choose>

<xsl:choose>

<xsl:when test=""LISTING/CLASSIFICATION[@Name='POSTCODE'] = '0' or LISTING/CLASSIFICATION[@Name='POSTCODE'] = ''"">
<CLASSIFICATION Name=""POSTCODE"">9999</CLASSIFICATION>
</xsl:when>
<xsl:otherwise>
<CLASSIFICATION Name=""POSTCODE"">
<xsl:value-of select=""LISTING/CLASSIFICATION[@Name='POSTCODE']"" />
</CLASSIFICATION>
</xsl:otherwise>
</xsl:choose>

<CLASSIFICATION Name=""SUBURB"">
<xsl:value-of select=""LISTING/CLASSIFICATION[@Name='SUBURB']"" />
</CLASSIFICATION>

<CLASSIFICATION Name=""LOCATION"">
<xsl:value-of select=""LISTING/CLASSIFICATION[@Name='LOCATION']"" />
</CLASSIFICATION>

<CLASSIFICATION Name=""AREA"">
<xsl:value-of select=""LISTING/CLASSIFICATION[@Name='AREA']"" />
</CLASSIFICATION>

</LISTING>

<CATEGORIES>
<CATEGORY>
<CLASSIFICATION>
<xsl:value-of select=""CATEGORIES/CATEGORY/CLASSIFICATION"" />
</CLASSIFICATION>

<SUBCLASSIFICATION>
<xsl:value-of select=""CATEGORIES/CATEGORY/SUBCLASSIFICATION"" />
</SUBCLASSIFICATION>

</CATEGORY>
</CATEGORIES>

<SALARY>
<xsl:choose>
<xsl:when test=""SALARY/@type='yearly'"">
<xsl:attribute name=""type"">annual</xsl:attribute>
</xsl:when>
<xsl:when test=""SALARY/@type='Yearly'"">
<xsl:attribute name=""type"">annual</xsl:attribute>
</xsl:when>
<xsl:when test=""SALARY/@type='Hourly'"">
<xsl:attribute name=""type"">Hourly</xsl:attribute>
</xsl:when>
<xsl:otherwise>
<xsl:attribute name=""type"">NA</xsl:attribute>
</xsl:otherwise>
</xsl:choose>

<xsl:choose>
<xsl:when test=""concat(string(SALARY/@min), string(SALARY/@max)) = ''"">
<xsl:attribute name=""type"">NA</xsl:attribute>
</xsl:when>

<xsl:otherwise>

<xsl:attribute name=""min"">
<xsl:value-of select=""SALARY/@min"" />
</xsl:attribute>
<xsl:attribute name=""max"">
<xsl:value-of select=""SALARY/@max"" />
</xsl:attribute>

</xsl:otherwise>
</xsl:choose>

<xsl:attribute name=""amount"">
<xsl:value-of select=""SALARY/@amount"" />
</xsl:attribute>
<xsl:attribute name=""additionalText"">
<xsl:value-of select=""SALARY/@AdditionalText"" />
</xsl:attribute>
<xsl:attribute name=""hideSalary"">
<xsl:value-of select=""SALARY/@hideSalary"" />
</xsl:attribute>

</SALARY>

<APPLICATIONEMAIL>
<xsl:value-of select=""APPLICATIONEMAIL"" />
</APPLICATIONEMAIL>

<CONTACTDETAILS>
<xsl:value-of select=""CONTACTDETAILS"" />
</CONTACTDETAILS>

<APPLICATIONMETHOD>
<xsl:choose>
<xsl:when test=""string(APPLICATIONMETHOD[@type='url'])!=''"">
<xsl:attribute name=""type""><xsl:value-of select=""APPLICATIONMETHOD/@type"" /></xsl:attribute>
<xsl:value-of select=""APPLICATIONMETHOD"" />
</xsl:when>
<xsl:when test=""string(APPLICATIONMETHOD[@type='URL'])=''"">
<xsl:attribute name=""type"">JOBX</xsl:attribute>
</xsl:when>
<xsl:otherwise>
<xsl:attribute name=""type"">URL</xsl:attribute>
<xsl:value-of select=""APPLICATIONMETHOD[@type='URL']""/>
</xsl:otherwise>
</xsl:choose>
</APPLICATIONMETHOD>

<BULLETPOINTS>
   <BULLET1><xsl:value-of select=""BULLETPOINTS/BULLET1"" /></BULLET1>
   <BULLET2><xsl:value-of select=""BULLETPOINTS/BULLET2"" /></BULLET2>
   <BULLET3><xsl:value-of select=""BULLETPOINTS/BULLET3"" /></BULLET3>
</BULLETPOINTS>

<HOTJOB><xsl:value-of select=""HOTJOB"" /></HOTJOB>

</JOB>
</xsl:for-each>
</CLIENT>
</JOBXPOSTINGS>
</xsl:template>
</xsl:stylesheet>
";

            string XML = @"
<JOBXPOSTINGS Version='1.0' xmlns=''><CLIENT ID='17805'><JOB Reference='8915'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Group Financial Controller</TITLE><DESCRIPTION>Leverage your proven financial management skills in an environment seeking technical leadership and change management focused on best practice...</DESCRIPTION><ADDETAILS><![CDATA[
Highly regarded within its industry, our client is continuing the development of a top tier senior management team. Key to this strategy is the appointment of a seasoned, commercially savvy, Group Financial Controller seeking a new challenge - capable of delivering on senior management's mandate to create a value-add corporate finance function, establish best practices and 'lift the bar' in terms of the quality of reporting and commercial insight and decision support provided. <BR />
&nbsp;<BR />
Consequently, the role is best suited to a seasoned Group Financial Controller seeking a new challenge - capable of delivering on senior management's mandate to create a value-add corporate finance function that fully services the competing demands of a broad group of stakeholders. <BR />
&nbsp;<BR />
Specific responsibilities will include:&nbsp;&nbsp;<BR />
<UL>
<LI>
Statutory Reporting and Group Consolidation<BR />
<LI>
Management and corporate reporting&nbsp;&nbsp;<BR />
<LI>
Commercial and Decision Support&nbsp;&nbsp;<BR />
<LI>
Supervision, training and development of a&nbsp;team of qualified accountants and a&nbsp;shared services&nbsp;manager&nbsp;<BR /></LI></UL>
&nbsp;&nbsp;<BR />
Specific skills and personal attributes sought include: <BR />
<UL>
<LI>
A proactive, self starter who enjoys working autonomously, whilst still forming a key part of a very collegiate senior management team&nbsp;&nbsp;<BR />
<LI>
Excellent communication skills, both written and oral&nbsp;&nbsp;<BR />
<LI>
A hands-on approach to completing tasks and a preparedness to take on tasks outside of their core remit&nbsp;&nbsp;<BR />
<LI>
Proven commercial acumen and the ability to add commercial value across the group&nbsp;&nbsp;<BR /></LI></UL>
&nbsp;&nbsp;<BR />
Interested? <BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Matthew Crossley&nbsp;on (02) 8243 1306 for further information. <BR />
&nbsp;<BR />
For more opportunities please go to www.axr.com.au <BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Matthew Crossley</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Financial Controller</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Contract</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Healthcare</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='220000' max='250000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Focus on reporting &amp; decision support</BULLET1><BULLET2>Suit proven Group Financial Controller</BULLET2><BULLET3>$200K - $220K + Super</BULLET3></BULLETPOINTS></JOB><JOB Reference='8914'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Business Services Intermediate</TITLE><DESCRIPTION>Dynamic &amp; Collaborative Medium-Sized Chartered Firm; Great Training &amp; Study Support; Interesting &amp; Varied Work; Mentoring Program</DESCRIPTION><ADDETAILS><![CDATA[
This highly&nbsp;engaging Medium Sized Chartered Firm (8 Partners/75 staff) has&nbsp;an excellent role for a bright and ambitious Intermediate for its CBD Office.<BR />
The firm&nbsp;continues to grow and acquire new clients, based on a reputation of delivery of quality business, accounting and tax solutions. <BR />
The environment is positive, team-based and the Partners have a very open and inclusive communication policy. With a broad industry portfolio of SME's, large Family groups and High Net Worth Individuals you will be encouraged to 'take responsibility' and develop your technical and business skills.<BR />
&nbsp;<BR />
Working within a highly supportive team you will undertake mainly compliance matters,&nbsp;but have&nbsp;exposure to some advisory work. Your Partner and Manager will play an important part in your career development and will always encourage you to 'look outside the square' when dealing with client matters.<BR />
With a low staff turnover people enjoy the work structure, training &amp; professional development as well as the social aspects of the firm.<BR />
&nbsp;<BR />
You will have around&nbsp;2-4 years creditable Business Services experience gained in a Local Chartered Firm, and be looking to commence/currently studying&nbsp;your CA or CPA. This firm values and appreciates its staff and will always look to develop you as professional and strong business advisor.<BR />
&nbsp;<BR />
This is an outstanding opportunity to be nurtured, learn and enjoy going to work each day with like minded professionals.<BR />
&nbsp;<BR />
Looks interesting ?<BR />
&nbsp;<BR />
Please&nbsp;contact Graham Hollebon&nbsp;on (02) 8243 1311 or mobile (anytime) 0414 819 360 for further information.&nbsp;<BR />
Graham has over 20 years experience within Professional Services Recruitment and Career Management and is respected for his pragmatic,&nbsp;ethical and consultative approach to assisting you in your job search.<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A><BR />
&nbsp;<BR />
SK91504A<BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Graham Hollebon</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Accountant - Audit/Bus. Services</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Business &amp; Professional Services</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='60000-68000' min='55000' max='65000' hidesalary='0' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Suit around 2- 4 years Local Tax &amp; Accounting experience</BULLET1><BULLET2>Need an interactive and social Team plus Stimulating Work ?</BULLET2><BULLET3>Studying CA or CPA ?</BULLET3></BULLETPOINTS></JOB><JOB Reference='8913'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Tax Senior/Supervisor</TITLE><DESCRIPTION>Highly Dynamic National Chartered Firm; Vibrant and Forward Thinking; Prestigious &amp; Complex Clients; Great Client Interaction; Strong Advisory Focus</DESCRIPTION><ADDETAILS><![CDATA[
This role would suit an ambitious Tax&nbsp;professional who is looking to specialise and focus on Corporate Tax Advisory. <BR />
This&nbsp;prestigious Top 25 Chartered&nbsp;firm is very well regarded in the local market place for the quality of its staff and clients, plus the innovative and professional approach to client solutions.&nbsp;It has various practice areas, including&nbsp;Business Services/Advisory, Audit, Corporate Finance and Superannuation.<BR />
It has a strong collaboration within the Firm and continues to source new work and opportunities across the board. The Tax Group offers a full range of services - Direct/Indirect Tax, International Tax, Transfer Pricing, Consolidations and Tax Planning, to a range of Listed/Non Listed Corporate's and large Family groups. <BR />
&nbsp;<BR />
Working within this dedicated and supportive Tax team&nbsp;you will have alot of 'face-to-face' Client interaction. Your role will be split&nbsp;75% advisory and 25% compliance. You will&nbsp;be involved in Tax consolidations and restructuring;&nbsp;tax due diligence fieldwork and drafting of reports; conducting and documenting Tax research; drafting of specific and complex advice,&nbsp;and&nbsp;navigation around major tax structures.<BR />
&nbsp;<BR />
Ideally, you will have about 3-6&nbsp;years&nbsp;Chartered experience within a good quality&nbsp;Chartered firm (Big 4, National or Medium sized)&nbsp;and be highly knowledgeable on Australian Tax compliance issues. You may have already gained some exposure to Tax Advisory, but are keen to develop your knowledge and capacity in this area. You will be studying/completed your CA/CPA and&nbsp;look to study/completed&nbsp;Masters of Tax. This firm will look to support and pay for your post graduate Tax studies.<BR />
It is critical that you have the desire and intellectual capacity to progress your Tax advisory career.<BR />
&nbsp;<BR />
<STRONG>This is a highly supportive Firm -&nbsp;It has interesting and challenging work and you will have great Client exposure</STRONG><BR />
&nbsp;<BR />
Please contact Graham Hollebon on (02) 8243 1311 or his mobile 0414 819 360 (anytime) for further information. <BR />
&nbsp;<BR />
Graham has over 20 years experience within Chartered recruitment and provides an objective, consultative and highly ethical approach to your job search. <BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au'>www.axr.com.au</A><BR />
&nbsp;<BR />
SK91504A&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Graham Hollebon</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Accountant - Chartered/CPA (General)</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Business &amp; Professional Services</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='90000' AdditionalText='90000-100000' min='80000' max='100000' hidesalary='0' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Suit someone from Business Services wanting to Focus on Tax</BULLET1><BULLET2>Be Supported, Mentored and Trained by Experts</BULLET2><BULLET3>Suit Ambitious, Intelligent and Pragmatic Individual</BULLET3></BULLETPOINTS></JOB><JOB Reference='8909'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Finance Manager- Development</TITLE><DESCRIPTION>Join one of Australia's more progressive ASX listed businesses with an enviable record of organic and acquisitive growth reflected in a strong market share. A continuous commitment to innovation,</DESCRIPTION><ADDETAILS><![CDATA[
Join one of Australia's more progressive ASX listed businesses with an enviable record of organic and acquisitive growth reflected in a strong market share. A continuous commitment to innovation, insightful leadership, business strategy and the empowerment of employees have contributed to their success.&nbsp; <BR>&nbsp;<BR>This is a 12 months contract role with the&nbsp;possibility to move in to a permanent role. You will be a key member of finance team and have a broad and challenging mandate. This is a commercially focused role where you will be concentrating on preparing and presenting meaningful analysis to improve business performance and manage risk. This is a pivotal role in reviewing existing reporting processes and driving a successful team performance and culture through coaching and mentoring. <BR>&nbsp;<BR>Success in this outstanding role will be governed by your ability to have a strong financial acumen, the capability to partner with key stakeholders to build and maintain strong working relationships; and create a high performing team. <BR />
&nbsp;Please apply below or contact Matthew Crossley for more information on 02 8243 1316.&nbsp; <BR><BR>&nbsp;<BR><BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Matthew Crossley</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Finance Manager</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Contract</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Property</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='130000' max='140000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>ASX listed opportunity</BULLET1><BULLET2>12 months contract with the possibility to move into a permanent role.</BULLET2><BULLET3>CBD location</BULLET3></BULLETPOINTS></JOB><JOB Reference='8894'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Finance Manager</TITLE><DESCRIPTION>Overseas multi-national seeking Finance Manager to drive value and operational initiatives.</DESCRIPTION><ADDETAILS><![CDATA[
This overseas multi-national has its roots stretching back well over a century and is not only a company with a history, but a company with a strong heritage. They have a proud past and due to growth here in Australia, an exceptional opportunity has arisen to join their finance function as Finance Manager. <BR />
Reporting into the Regional CFO, your mandate will be broad; taking full group responsibility over the Financial Controls, Management Reporting and managing the group P&amp;L. Assessing areas for process improvement and streamlining controls will also be prominent in this position as well as exposure to statutory reporting and tax compliance. <BR />
The challenge of the role will be to increase divisional profitability through execution of intelligent commercial and operational initiatives; always seeking to add value and Controls to national P&amp;L owners within the business.<BR>&nbsp;<BR>You will need to be CA/CPA qualified and will have demonstrable commercial skills with a strong technical finance background. You may also have worked in an asset intensive business with globally exposure and have extensive people management experience.<BR>&nbsp;<BR>Please apply below or for a confidential discussion please contact Adam Neyenhuys on (02) 8243 1320 for further information. <BR>&nbsp;<BR>For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A> <BR><BR />
<BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Adam Neyenhuys</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Finance Manager</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Maritime</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='170000' max='200000' hidesalary='0' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Proactive ?value-add? finance executive</BULLET1><BULLET2>Strong technical and leadership skills</BULLET2><BULLET3>Exposure to global business</BULLET3></BULLETPOINTS></JOB><JOB Reference='8890'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Strategy and Corporate Finance - ASX 50 Group in Sydney (initial 12 month contract)</TITLE><DESCRIPTION>Join this leading ASX company based in the CBD as a business analyst. Partner the business and open the door to long term future opportunities.</DESCRIPTION><ADDETAILS><![CDATA[
A perfect opportunity to join&nbsp;a large listed organisation with a reputable brand name in the market, stepping into a strategy and portfolio focused role. They are looking for a strong candidate with a transaction services/corporate finance background, ideally with some experience in M&amp;A, who can bring skills around modelling decisions and tying them back to financial impacts.<BR />
&nbsp;<BR />
Liaising with key senior stakeholders within the business, you will be part of a team assisting in making key strategic financial decisions relating to the organisations prospective acquisitions, disposals, financings and hedgings. You will also be involved with the analysis of new deal feasibilities across different areas of the business and the preparation of internal reports including earnings, liquidity forecasts and balance sheets.<BR />
&nbsp;<BR />
You will have a strong accounting foundation of skills, but use this to support skills in financial modelling and investment appraisal.&nbsp;It is likely that you are coming from corporate finance, transaction services or a similar function. You should have experience in multi asset environmets like property, resources, retail or similar.&nbsp;<BR />
&nbsp;<BR />
This is initially a 12 month contract, however opportunities may arise to remain with the organisation or to promote on successful performance.<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A> <BR />
&nbsp;<BR><BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Matthew Crossley</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Analyst</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Contract</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Property</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='' max='' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>CBD location</BULLET1><BULLET2>12 month contract</BULLET2><BULLET3>Capital investments and planning focus</BULLET3></BULLETPOINTS></JOB><JOB Reference='8889'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Finance Manager</TITLE><DESCRIPTION>Join this well known organisation and take on a challenging and rewarding opportunity</DESCRIPTION><ADDETAILS><![CDATA[
This Private Equity backed global&nbsp;services business is undergoing a rapid period of expansion and growth. Through a renewed executive leadership team and an aggressive international growth strategy, the company will continue to expand, diversify revenue streams and strengthen its market share. In addition to organic growth and acquisitions, the company has a focus on strategic planning that will develop its further potential long into the future.&nbsp;<BR />
<BR>Reporting to the CFO, the core challenges coming into this role will include taking responsibility for the preparation of month end reporting and closure, in accordance with company policy. You will manage a team of 3 qualified accountants and&nbsp;take ownership over the statutory reporting requirements, assist with the preparation of monthly board papers, cash flow reporting, assist with the forecasting and provide monthly P&amp;L variance analysis.&nbsp;<BR />
&nbsp;<BR />
CA or CPA qualified you will be an experienced&nbsp;finance manager&nbsp;who possess a strong technical capability, excellent communication and interpersonal skills, superior time management skills coupled with the ability to learn systems and process very quickly. You will be able to develop strong internal relationships particularly with your&nbsp;staff,&nbsp;the commercial teams and quickly work towards being&nbsp;a contributing member of finance.&nbsp;&nbsp;<BR />
&nbsp;<BR />
As this is a 6 month contract role in conjunction with meeting the criteria mentioned you must also be on short notice to be considered.&nbsp;<BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Matthew Crossley&nbsp;on (02) 8243 1306 for further information&nbsp;<BR />
&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to www.axr.com.au <BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Matthew Crossley</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Finance Manager</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Contract</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Healthcare</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>North Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2060</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='140000' max='160000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Private Equity backed</BULLET1><BULLET2>North Sydney location</BULLET2><BULLET3>Immediate Start - 6 months</BULLET3></BULLETPOINTS></JOB><JOB Reference='8888'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Senior Financial Accountant</TITLE><DESCRIPTION>You will be joining a leading multinational organisation that is experiencing growth through acquisition and organic means.</DESCRIPTION><ADDETAILS><![CDATA[
You will be joining a leading multinational organisation that is experiencing growth through acquisition and organic means. Operating in a dynamic market sector this company has strong leadership, defined growth plans and a clear strategy for increasing its market share. <BR />
<BR>In this diverse role you will manage the month end reporting process for the business. You will pull together financial statements, and you will liaise closely with both internal and external stakeholders to ensure that accurate results are delivered within company timeframes. You will offer technical accounting input into commercial decision making and you will ensure adherence with statutory regulations and external reporting frameworks. The range of financial work outside of month end reporting is varied and will include tax, managing cash balances, reviewing capital expenditure requirements and providing analysis on variances in the P&amp;L.<BR />
<BR>This role offers an ideal opportunity for a dynamic qualified accountant to gain broad-ranging experience in a highly successful commercial operation. Your success in this role will be governed by your technical accounting skills, and your ability to forge strong relationships with both operational and financial staff within the business. This role would ideally suit a first mover from a top-tier chartered organisation, or a high performer in a large and complex corporate environment. Exposure to HFM will be highly regarded.<BR><BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Fraser Chapman&nbsp;on (02) 8243 1343 for further information.&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A>&nbsp;<BR />
&nbsp;<BR />
Learn more about us <A href='http://www.axr.com.au/page/resources/axr-videos/'>here</A><BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Fraser Chapman</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>No</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Accountant - Financial</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Chemical</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Macquarie Park</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2113</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='100000' max='120000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Market leading multinational organisation</BULLET1><BULLET2>Huge career opportunities</BULLET2><BULLET3>Varied role</BULLET3></BULLETPOINTS></JOB><JOB Reference='8886'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Senior Tax Accountant</TITLE><DESCRIPTION>Leading multinational currently looking for a technically strong Senior Tax Accountant to sit within their well-established tax team.</DESCRIPTION><ADDETAILS><![CDATA[
This leading multinational organisation has a huge global footprint and a high profile in the local market. They have dominated their sector and offer employees challenging and rewarding careers. They are currently looking for a technically strong Senior Tax Accountant to sit within their well-established tax team. <BR>&nbsp;<BR>Reporting to the Senior Tax Manager you will be responsible for a wide range of direct and indirect tax compliance and advisory work. This will include, preparing company tax returns and schedules for individual entities and consolidation tax returns. Assisting in statutory tax reporting requirements, including tax effect accounting, FBT and GST. Given the nature of their business there will also be exposure to international taxes and transfer pricing. Due to recent and upcoming acquisitions it is an exciting time to join their tax team!<BR>&nbsp;<BR>The successful candidate will be an excellent communicator and will be CA/CPA or Masters of Tax qualified. This position offers a fantastic opportunity for a first move from a Big4 accounting firm and would suit an experienced Manager or newly promoted Senior Manager. Those with both Big4 and commercial experience are also encouraged to apply.<BR><BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Fraser Chapman&nbsp;on (02) 8243 1343 for further information.&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A>&nbsp;<BR />
&nbsp;<BR />
Learn more about us <A href='http://www.axr.com.au/page/resources/axr-videos/'>here</A><BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Fraser Chapman</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>No</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Accountant - Tax</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Pharmaceutical</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>West Ryde</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2114</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='130000' max='150000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Global powerhouse</BULLET1><BULLET2>Great first move from Big 4</BULLET2><BULLET3>Exciting period of growth through acquisitions</BULLET3></BULLETPOINTS></JOB><JOB Reference='8885'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Finance Business Partner</TITLE><DESCRIPTION>This multinational organisation and leading Australian brand has defined their culture and success by an ongoing commitment to product excellence, innovation and customer satisfaction</DESCRIPTION><ADDETAILS><![CDATA[
This multinational organisation and leading Australian brand has defined their culture and success by an ongoing commitment to product excellence, innovation and customer satisfaction.&nbsp; <BR />
&nbsp;<BR />
The Division you will be joining is at the leading edge of innovation in maximising brand penetration and market development. Working within the business itself, your challenge will be to provide insightful analytical support to marketing, sales and operations to help to drive the division forward through the next phase of its lifecycle.&nbsp; <BR />
&nbsp;<BR />
Your main responsibilities will include assisting with effective business decision making by providing financial expertise, information and counsel; manage the accounting function for the areas of responsibility to ensure a true and fair reflection of financial performance; partner with the business to contribute to the budgeting and strategic planning process.&nbsp; <BR>&nbsp; <BR>To be successful you will be CPA/CA qualified and will ideally have previous experience with product based business. SAP experience is preferred and you will need to demonstrate excellent business acumen skills.&nbsp; <BR />
<BR>&nbsp;<BR />
Please apply below or contact Fraser Chapman on (02) 8243 1343 for further information. <BR />
&nbsp;<BR />
For more opportunities please go to www.axr.com.au <BR />
&nbsp;<BR />
Learn more about us here<BR />
&nbsp;<BR>






<BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Fraser Chapman</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>No</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Analyst</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Pharmaceutical</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>West Ryde</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2114</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='120000' max='130000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Global powerhouse</BULLET1><BULLET2>Growing business</BULLET2><BULLET3>Clear career development</BULLET3></BULLETPOINTS></JOB><JOB Reference='8875'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Financial Accountant</TITLE><DESCRIPTION>ASX 200 currently looking for a financial accountant to join one of their key divisions.</DESCRIPTION><ADDETAILS><![CDATA[
Our client is an ASX Top 200 company with a high profile brand and high performing finance team. About to embark on a period of strategic projects to broaden and strengthen their already dominant hold on their market. They have created a role for a Financial Accountant to join one of their key divisions.<BR>&nbsp;<BR>Reporting to the division's Accounting Manager you will work in a highly challenging and versatile role. You will engage with a wide range of stakeholders in a multi-faceted environment. This role will see you handling various process improvement and ad hoc projects, as well as delivery of month end financial and management reporting on the businesses activities.<BR>You will get involved in the budgeting and forecasting process, as well as, being responsible for the tax returns for the division.<BR />
&nbsp;<BR />
You are CA/CPA Qualified with a proven track record of success, coming out of a Big 4 or mid to large tier professional accounting firm. Working closely with the business you will have excellent relationship building skills as well as being a solutions focused team player. <BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Fraser Chapman&nbsp;on (02) 8243 1343 for further information.&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A>&nbsp;<BR />
&nbsp;<BR />
Learn more about us <A href='http://www.axr.com.au/page/resources/axr-videos/'>here</A><BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Fraser Chapman</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>No</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Accountant - Financial</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Property</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='85000' max='95000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Financial &amp; management reporting</BULLET1><BULLET2>ASX 200</BULLET2><BULLET3>Defined career path</BULLET3></BULLETPOINTS></JOB><JOB Reference='8855'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Group Financial Accountant</TITLE><DESCRIPTION>An opportunity to work with a large organisation with high level growth due to acquisitions.</DESCRIPTION><ADDETAILS><![CDATA[
This organisation is going through a period of high level growth. With a number of acquisitions in the pipeline they are looking for a Group Financial Accountant who can partner with executive level stakeholders and deliver on a number of key initiatives. <BR />
<BR>You will play a key role in a fast-paced environment with a collegiate team of like-minded individuals. Your responsibilities will include preparing monthly and quarterly consolidated reports, statutory accounts, responsibility for auditors, tax and involvement in various projects. You will have excellent communication skills, an eye for detail and approach things with a savvy commercial mind-set. This is a great opportunity for a high performer to partner with the business and build an internal brand for themselves within the finance function. <BR />
<BR>The successful candidate will be CA/CPA qualified with a track record of working in fast-paced, evolving environments. You will be able to perform under tight deadlines and have experience dealing with a variety of stakeholders. This is an excellent opportunity to advance your career with exposure to high-level work and responsibility. <BR>
















<BR />
Please apply below.&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A>&nbsp;<BR />
&nbsp;<BR />
Learn more about us <A href='http://www.axr.com.au/page/resources/axr-videos/'>here</A><BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Matthew Crossley</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Accountant - Financial</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Contract</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Property</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='0' max='0' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Nine month contract - CBD</BULLET1><BULLET2>Long term Opportunities</BULLET2><BULLET3>$100,000 - $120,000</BULLET3></BULLETPOINTS></JOB><JOB Reference='8829'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Marketing Analyst</TITLE><DESCRIPTION>A great opportunity for a career driven individual who has a strong presence who has cut their teeth in FP&amp;A to take their career to the next level &amp; join a high profile ASX listed Co.</DESCRIPTION><ADDETAILS><![CDATA[
This is a great opportunity for a career driven individual who has a strong presence who has cut their teeth in FP&amp;A to take their career to the next level and join a high profile ASX listed organisation. <BR />
Reporting to the General Manager of Planning and Analysis of this ASX 100 Corporation, you will be responsible for supporting Corporate and Group in the management of the group marketing budget. You will also be responsible for the monitoring the performance of group-wide marketing campaigns and perform monthly reporting and analysis to support management in achieving targets.<BR />
By necessity you will need to be an experienced Analyst with experience supporting non-finance stakeholders, well versed in all facets of budgeting, forecasting and preparation of month end financial reports. On top of these strong foundations, you should be able to take insights from the numbers to support key decisions and executives lead their space.<BR>&nbsp;<BR>Your natural systems bias will be complimented by the ability to: <BR>&#8226;&nbsp;Provide finance support to the Group Marketing team in relation to the development of marketing strategy.<BR>&#8226;&nbsp;Perform analysis and review of special marketing initiatives as required<BR>&#8226;&nbsp;Proactively create useable insights from market data and customer behaviours that will drive revenue growth. <BR />
Necessary skills, knowledge and personal attributes required will include:<BR>&#8226;&nbsp;Proficient with planning and data discovery tools (e.g. TM1); <BR>&#8226;&nbsp;Attention to detail;<BR>&#8226;&nbsp;Superior interpersonal skills encompassing strong influencing capabilities;<BR>&#8226;&nbsp;High level written and oral communication skills;<BR>&#8226;&nbsp;Strong work ethic.<BR />
Prospects of career advancement are very real and will only be limited by the successful candidate's ability to add value to the organisation and attract new opportunities.<BR />
Want to learn more? For a confidential discussion please contract Sonal Plush on (02) 8243 1337 or apply at <A href='http://www.axr.com.au'>www.axr.com.au</A> quoting Job ID 8829.<BR><BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Adam Neyenhuys</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Analyst</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Media</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='80000' max='100000' hidesalary='1' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>ASX Listed Organisation</BULLET1><BULLET2>Strong focus on career development</BULLET2><BULLET3>$100k package</BULLET3></BULLETPOINTS></JOB><JOB Reference='8782'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Tax Manager</TITLE><DESCRIPTION>The Tax Manager is a newly created role and offers the opportunity to make it your own.</DESCRIPTION><ADDETAILS><![CDATA[
While many organisations are seeking 'like for like' skills, this organisation has a track record of growing and promoting strong talent that demonstrate a desire to grow and track record for performance. The Tax&nbsp;Manager is a newly created role and offers the opportunity to make it your own.<BR />
<BR>Reporting to the Group Finance Manager you will be responsible for a wide range of direct and indirect taxes including; income tax, tax effect accounting, withholding tax, FBT, BAS and GST. The role is a great opportunity for someone looking to make their first move into a commercial business. The role will focus on ANZ, PNG and Fiji jurisdictions. The organisation is looking for a candidate with an eye for process improvement and there will also be the opportunity to get involved in the broader financial accounting and Treasury&nbsp;functions.<BR />
<BR>You will have or be working towards CA/CPA qualification, with experience gained in a Big4, large Mid-tier accounting firm or large corporate environment. The ideal candidate will come from a generalist tax background. You will have excellent communication skills and a proven ability to work across multiple tasks at the same time. <BR><BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Fraser Chapman&nbsp;on (02) 8243 1343 for further information.&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A>&nbsp;<BR />
&nbsp;<BR />
Learn more about us <A href='http://www.axr.com.au/page/resources/axr-videos/'>here</A><BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Fraser Chapman</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>No</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Accountant - Tax</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Chemical</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>North Ryde</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2113</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='80000' max='100000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Growth environment with real career opportunities</BULLET1><BULLET2>Suits candidates looking to make 1st move from chartered</BULLET2><BULLET3>Offers more than just a tax role</BULLET3></BULLETPOINTS></JOB><JOB Reference='8770'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Senior BA - FP&amp;A</TITLE><DESCRIPTION>Join one of Australia's largest companies with an iconic name and reputation for leadership in its industry as it undergoes a period of significant change and transformation</DESCRIPTION><ADDETAILS><![CDATA[
Join one of Australia's largest companies with an iconic name and reputation for leadership in its industry as it undergoes a period of significant change and transformation.<BR>&nbsp;<BR>As a specialist in the financial planning and analysis space, you will be presented with a number of challenges in this role that will see you partnering with senior stakeholders within the business to convert the business' overall strategy into the divisional planning, budgeting and forecasting process. <BR />
<BR>You will play a key role assisting the finance team through their annual budgeting and forecasting as well as being accountable for the division's weekly performance and CAPEX reporting. You will also be involved in delivering key strategic objectives for the business and ensuring they are aligned to the wider group. <BR />
<BR>The successful candidate will have a proven background in an ASX listed/large multinational FP&amp;A function. You will demonstrate key project management skills, excellent attention to detail and the hunger to work in a 'hands on' capacity to deliver results. Must have experience working within a construction focused organisation.<BR><BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Fraser Chapman&nbsp;on (02) 8243 1343 for further information.&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A>&nbsp;<BR />
&nbsp;<BR />
Learn more about us <A href='http://www.axr.com.au/page/resources/axr-videos/'>here</A><BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Fraser Chapman</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>No</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Analyst</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Construction</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Chatswood</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2057</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='130000' max='150000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Large Australian Organisation</BULLET1><BULLET2>Career growth opportunities</BULLET2><BULLET3>Business partnering</BULLET3></BULLETPOINTS></JOB><JOB Reference='8748'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Commercial Finance Manager</TITLE><DESCRIPTION>This is an opportunity to be part of a progressive organisation working through a period of transformation and growth. Under visionary leadership and in an industry presenting a high degree of opportu</DESCRIPTION><ADDETAILS><![CDATA[
This is an opportunity to be part of a progressive organisation working through a period of transformation and growth. Under visionary leadership and in an industry presenting a high degree of opportunity, this organisation will provide foundations for a strong career both within the group and beyond.<BR />
&nbsp;<BR />
As the Commercial Finance Manager, you will be aligned to the Divisional General Manager and their department with a focus leading your team to&nbsp;improve the quality, transparency and over value offering of finance as a &#8220;business partner&#8221;. In doing so, you will collaborate with the business unit to manage the budget process and develop more insightful reporting with a keen on identifying opportunities for performance improvement. You will work on a variety of business cases and be seen as a go-to person for key decisions.<BR />
&nbsp;<BR />
This is an opportunity where our client is not focused on industry experience, but on leadership and business partnership skills. As such, you will have a strong career and track record of adding value through running FP&amp;A functions, demonstrating initiative in solving key business challenges from a financial view point, and leading change mandates. Your experience&nbsp;could be in a growth or turn-around/ improvement focused environments, with a heavy focus on leading change. <BR />
&nbsp;<BR />
Apply below or&nbsp;contact Sonal Plush on 02 8243 1337 to discuss.<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Adam Neyenhuys</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Finance Manager</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Private</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Manufacturing</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='150000' max='170000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>Progressive and Exciting Opportunity</BULLET1><BULLET2>Excellent Career Development</BULLET2><BULLET3>Reputable and Growing Organization</BULLET3></BULLETPOINTS></JOB><JOB Reference='8728'><JOBADTYPE>Normal</JOBADTYPE><TITLE>Data &amp; Insights Manager</TITLE><DESCRIPTION>You will be joining one of the fastest growing companies in Australia</DESCRIPTION><ADDETAILS><![CDATA[
You will be joining one of the fastest growing companies in Australia. With an IPO date set, funding in place and a suite of new products ready to be released on the market, this is a great opportunity to join the business as a Data &amp; Insights Manager reporting to the CFO.<BR />
&nbsp;<BR />
As the Data&nbsp;&amp; Insights Manager&nbsp;you will partner with&nbsp;the key stakeholders across all business units to extract, organise and interpret statistical information. Working with large quantities of complex raw data you will provide insight to assist the business with strategies for driving innovation, improved customer engagement and increase overall business performance. In doing this, you will also be responsible for importing, cleaning, transforming, validating and modelling data. You will be&nbsp;develop meaningful insights to drive commercial decision making.<BR />
&nbsp;<BR />
To be successful in this role who will have experience creating insightful user friendly dashboards and reports. You will be a data manipulation expert with strong business partnering skills. You will also hold tertiary qualifications in either Finance, Mathematics/Statistics, Economics or Computer Science. Overall you will have advanced analysis and report writing skills, be an excellent communicator who is an ambitious individual who sees themselves as a pioneer and problem solver. Tableau and SQL experience will be highly regarded.<BR><BR />
&nbsp;<BR />
Please apply below or contact&nbsp;Fraser Chapman&nbsp;on (02) 8243 1343 for further information.&nbsp;<BR />
&nbsp;<BR />
For more opportunities please go to <A href='http://www.axr.com.au/'>www.axr.com.au</A>&nbsp;<BR />
&nbsp;<BR />
Learn more about us <A href='http://www.axr.com.au/page/resources/axr-videos/'>here</A><BR />
&nbsp;<BR />]]></ADDETAILS><APPLICATIONEMAIL>resman@axr.com.au</APPLICATIONEMAIL><CONTACTDETAILS>Fraser Chapman</CONTACTDETAILS><RESIDENTSONLY>Yes</RESIDENTSONLY><HIDELOCATIONDETAILS>Yes</HIDELOCATIONDETAILS><TEMPLATEID>3214</TEMPLATEID><COMPANYNAME>AXR</COMPANYNAME><CATEGORIES><CATEGORY><CLASSIFICATION>Accounting</CLASSIFICATION><SUBCLASSIFICATION>Analyst</SUBCLASSIFICATION></CATEGORY></CATEGORIES><LISTING><CLASSIFICATION Name='WORKTYPE'>Full Time</CLASSIFICATION><CLASSIFICATION Name='SECTOR'>Public</CLASSIFICATION><CLASSIFICATION Name='INDUSTRY'>Information Technology and Internet</CLASSIFICATION><CLASSIFICATION Name='COUNTRY'>Australia</CLASSIFICATION><CLASSIFICATION Name='SUBURB'>Sydney</CLASSIFICATION><CLASSIFICATION Name='POSTCODE'>2000</CLASSIFICATION></LISTING><SALARY type='Yearly' amount='' AdditionalText='' min='120000' max='140000' hidesalary='' /><APPLICATIONMETHOD type='JOBX' /><BULLETPOINTS><BULLET1>High growth company</BULLET1><BULLET2>Opportunity to be part of an IPO</BULLET2><BULLET3>Great exposure to key senior stakeholders</BULLET3></BULLETPOINTS></JOB></CLIENT></JOBXPOSTINGS>

";
            RunPoster(XSL, XML);
        }

        #endregion
    }
}
