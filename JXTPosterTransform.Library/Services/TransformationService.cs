using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPosterTransform.Library.Common;
using System.IO;
using System.Xml.Serialization;
using JXTPosterTransform.Library.Models;
using JXTPosterTransform.Data;
using System.Web.Script.Serialization;
using JXTPosterTransform.Website.Logics;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Xml;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using JXTPosterTransform.Library.Methods;
using JXTPosterTransform.Library.APIs.Invenias;

namespace JXTPosterTransform.Library.Services
{
    public class TransformationService : IDisposable
    {
        private PosterTransformEntities _context = new PosterTransformEntities();
        JavaScriptSerializer jss = new JavaScriptSerializer();

        bool enableShortDescriptionPullFromFullDescription = false;

        public void DoTransformationWithMappings(int setupId)
        {
            // Gets only the results which needs to run.
            //List<GetAllClientSetupsToRun_Result> clientSetupsList = _context.GetAllClientSetupsToRun().ToList();

            //TODO NAVEEN / HIMMY - REMOVE
            List<GetAllClientSetupsToRun_Result> clientSetupsList = null;

            if (setupId > 0)
                clientSetupsList = _context.GetAllClientSetupsToRun().Where(s => s.ClientSetupId == setupId).ToList();
            else
                clientSetupsList = _context.GetAllClientSetupsToRun().ToList();

            if (clientSetupsList != null && clientSetupsList.Count > 0)
            {

                ResponseClass response = new ResponseClass();

                DateTime dtStartTime = DateTime.Now;
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");

                try
                {
                    foreach (GetAllClientSetupsToRun_Result thisSetupItem in clientSetupsList)
                    {
                        dtStartTime = DateTime.Now;     // Set the start time
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");   // Set a new file name

                        Console.WriteLine("Client - {0}, Client Setup - {1}", thisSetupItem.ClientName, thisSetupItem.ClientSetupName);
                        response = new ResponseClass();

                        //below are for PullXmlFromRGF ONLY
                        long nextScheduledTimestamp = 0;
                        JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot rgfData = null;


                        bool postRequired = false;
                        // Find the type of Client setup Type and get credentials                    
                        switch (thisSetupItem.ClientSetupType)
                        {
                            case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromFTP):
                                {
                                    ClientSetupModels.PullXmlFromFTP FTP = jss.Deserialize<ClientSetupModels.PullXmlFromFTP>(thisSetupItem.ClientSetupTypeCredentials);
                                    response = Methods.PullXMLFromFTP.ProcessXML(FTP, fileName);
                                    postRequired = response.blnSuccess;
                                    break;
                                }
                            case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromSFTP):
                                {
                                    ClientSetupModels.PullXmlFromSFTP SFTP = jss.Deserialize<ClientSetupModels.PullXmlFromSFTP>(thisSetupItem.ClientSetupTypeCredentials);
                                    response = Methods.PullXMLFromSFTP.ProcessXML(SFTP, fileName);
                                    postRequired = response.blnSuccess;
                                    break;
                                }
                            case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrl):
                                {
                                    ClientSetupModels.PullXmlFromUrl URL = jss.Deserialize<ClientSetupModels.PullXmlFromUrl>(thisSetupItem.ClientSetupTypeCredentials);
                                    response = Methods.PullXMLFromURL.ProcessXML(URL.URL, fileName);
                                    postRequired = response.blnSuccess;
                                    break;
                                }
                            case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromUrlWithAuth):
                                {
                                    ClientSetupModels.PullXmlFromUrlWithAuth XmlAuth = jss.Deserialize<ClientSetupModels.PullXmlFromUrlWithAuth>(thisSetupItem.ClientSetupTypeCredentials);
                                    response = Methods.PullXMLWithWebAuthentication.ProcessXML(XmlAuth, fileName);
                                    postRequired = response.blnSuccess;
                                    break;
                                }
                            case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullFromInvenias):
                                {
                                    ClientSetupModels.PullFromInvenias invAuth = jss.Deserialize<ClientSetupModels.PullFromInvenias>(thisSetupItem.ClientSetupTypeCredentials);
                                    PullFromInvenias inveniaLogic = new PullFromInvenias(invAuth);
                                    List<InveniasPTModel> ptModel = inveniaLogic.PosterTransformModelsGet();
                                    response = inveniaLogic.ProcessInveniaModelToXML(ptModel, fileName);
                                    postRequired = response.blnSuccess;
                                    break;
                                }
                            case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullJsonFromUrl):
                                {
                                    //only enabled for this for now incase it breaks any other things
                                    enableShortDescriptionPullFromFullDescription = true;
                                    ClientSetupModels.PullJsonFromUrl jsonAuth = jss.Deserialize<ClientSetupModels.PullJsonFromUrl>(thisSetupItem.ClientSetupTypeCredentials);
                                    response = Methods.PullJsonFromURL.ProcessJsonToXML(jsonAuth.URL, fileName);
                                    postRequired = response.blnSuccess;
                                    break;
                                }
                            case ((int)PTCommonEnums.ClientSetup.ClientSetupType.PullXmlFromRGF):
                                {
                                    ClientSetupModels.PullXmlFromSalesforceRGF XmlAuthRGF = jss.Deserialize<ClientSetupModels.PullXmlFromSalesforceRGF>(thisSetupItem.ClientSetupTypeCredentials);
                                    long epochTime = ((long)((new DateTime(2016, 01, 01, 11, 0, 0)).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds);

                                    //set this value for update later
                                    nextScheduledTimestamp = ((long)((DateTime.UtcNow.AddMinutes(-5)) - new DateTime(1970, 1, 1)).TotalSeconds);

                                    Methods.Client.PullJsonFromRGF rgfLogic = new Methods.Client.PullJsonFromRGF(XmlAuthRGF);

                                    rgfData = rgfLogic.ProcessXML(XmlAuthRGF.JobBoardName, XmlAuthRGF.Host, XmlAuthRGF.Timestamp ?? epochTime, XmlAuthRGF.ApplicationURL, XmlAuthRGF.StripJobTitle);

                                    if (rgfData.success)
                                    {
                                        int count = 0, fileCount = 1;

                                        bool postSuccess = true;
                                        for (count = 0; count < rgfData.jobBoards.jobboardlisting.upserted.Count(); )
                                        {
                                            string thisFileName = fileName + "-" + fileCount;
                                            JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot currentQueue = DeepClone<JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot>(rgfData);
                                            currentQueue.jobBoards.jobboardlisting.upserted = currentQueue.jobBoards.jobboardlisting.upserted.Skip(count).Take(200).ToList();

                                            response = rgfLogic.ProcessRGFModelToXML(currentQueue, thisFileName);

                                            // Get the Credentials AND Pull the XML     AND     Post to JXT platform Webservice                            
                                            bool thisPostSuccess = PostTransformationWithMappings(thisSetupItem, response.ResponseXML, thisFileName, dtStartTime);

                                            if (!thisPostSuccess)
                                                postSuccess = false;

                                            count += currentQueue.jobBoards.jobboardlisting.upserted.Count();
                                            fileCount++;
                                        }

                                        bool jobsArchiveSuccess = ArchiveRGFJobs(thisSetupItem, rgfData);

                                        // Set the values - TODO move to a seperate function
                                        if (postSuccess && jobsArchiveSuccess)
                                        {
                                            // update the timestamp
                                            PT_ClientService clientService = new PT_ClientService();
                                            ClientSetup thisSetupToBeUpdated = clientService.ClientSetupGetBySetupID(thisSetupItem.ClientSetupId);
                                            if (thisSetupToBeUpdated != null)
                                            {
                                                //get setup credentials from json
                                                ClientSetupModels.PullXmlFromSalesforceRGF thisSetupCredentials = jss.Deserialize<ClientSetupModels.PullXmlFromSalesforceRGF>(thisSetupToBeUpdated.ClientSetupTypeCredentials);
                                                //assign new timestamp
                                                thisSetupCredentials.Timestamp = nextScheduledTimestamp;
                                                //serialize back to json again
                                                string newSetupCredentials = jss.Serialize(thisSetupCredentials);
                                                //update
                                                clientService.ClientSetupSetupCredentialsUpdate(thisSetupItem.ClientSetupId, newSetupCredentials);
                                            }
                                        }
                                    }
                                    postRequired = false;
                                    break;
                                }
                            default:
                                break;
                        }

                        if (postRequired)
                        {
                            // Get the Credentials AND Pull the XML     AND     Post to JXT platform Webservice                            
                            PostTransformationWithMappings(thisSetupItem, response.ResponseXML, fileName, dtStartTime);
                        }
                        else
                        {
                            // Error display
                            Console.WriteLine(response.strMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex.Message); // TODO
                    Console.WriteLine("Error - " + ex.StackTrace); // TODO
                    Console.WriteLine("Error - " + ex.InnerException); // TODO
                }
                // Save the Response Log
            }
        }

        public bool PostTransformationWithMappings(GetAllClientSetupsToRun_Result clientSetup, string xml, string fileName, DateTime dtStartTime)
        {
            #region Temp XML

            /*
            xml = @"
<FastLanePlus UploaderID='20144' AgentID='' Version='1.1'>
<Client ID='20144' MinJobs='0' MaxJobs='9999999'>
<Job Reference='28777-1' TemplateID='3575' ScreenID=''>
<Title><![CDATA[Leading Hand Carpenter 1]]></Title>
<SearchTitle><![CDATA[Leading Hand Carpenter]]></SearchTitle>
<Description><![CDATA[Competitive Rates and Opportunity for Career Progression!]]></Description>
<AdDetails><![CDATA[<ul>
	<li><span style='color:rgb(0, 0, 128)'><strong>Competitive Salary</strong></span></li>
	<li><span style='color:rgb(0, 0, 128)'><strong>Friendly working team environment</strong></span></li>
	<li><span style='color:rgb(0, 0, 128)'><strong>Opportunity for career progression</strong></span></li>
</ul>

<p><br />
<span style='color:rgb(0, 0, 128)'>Stellar Recruitment are looking for ambitious, capable and energetic people with a good dose of common sense to join our team. We work hard to be the best, we give it our all and we take pride in what we do.<br />
<br />
We are actively seeking a <strong>Leading Hand Carpenter</strong> to join with our client to commence work on a new commercial project, with an immediate start. It is essential that applicants for this role have previous experience in the commercial sector, and a proven record of quality workmanship behind them.<br />
<br />
<strong>To be successful in this role you will have:</strong><br />
- 5+ years industry experience<br />
- Proven ability to manage a team onsite<br />
- To be confident reading &amp; working from technical specifications &amp; construction plans<br />
- Hold a current Site Safe Certificate<br />
- A clean full drivers licence (minimum of class 1)<br />
- Your own reliable transport in order to get yourself to and from site<br />
- Excellent communication and interpersonal skills<br />
- Able to provide your own hand and power tools<br />
<br />
Ideally we are looking for a highly health and safety aware, positive and hardworking attitude. We are prepared to wait for the right person for this role.<br />
<br />
To apply for this role or for further information please contact <strong>Nicky</strong> at Stellar Workforce.<br />
<br />
<strong>Nicky Sutherland<br />
DDI: 03 974 2440<br />
Cell phone: 021 224 1496<br />
Email: Nicky.s@stellarworkforce.co.nz</strong></span><br />
&nbsp;</p>
]]></AdDetails>
<ApplicationEmail>nicky.s@stellarworkforce.co.nz</ApplicationEmail>
<CONTACTDETAILS><CLASSIFICATION><![CDATA[Nicky Sutherland]]></CLASSIFICATION></CONTACTDETAILS>
<ApplicationURL><![CDATA[http://candidateportal.stellarrecruitment.com.au/adaptstellar/login/?jobref=1248071&src=WE]]></ApplicationURL>
<ResidentsOnly>Yes</ResidentsOnly>
<Items>
<Item Name='Jobtitle'><![CDATA[Leading Hand Carpenter]]></Item>
<Item Name='Bullet1'><![CDATA[A]]></Item>
<Item Name='Bullet2'><![CDATA[B]]></Item>
<Item Name='Bullet3'><![CDATA[C]]></Item>
</Items>
<Listing MarketSegments='Main'>
<Classification Name='Location'>Canterbury</Classification>
<Classification Name='Area'>Christchurch</Classification>
<Classification Name='Classification'>TradesServices</Classification>
<Classification Name='SubClassification'>CarpentryCabinetMaking</Classification>
<Classification Name='WorkType'>FullTime</Classification></Listing>
<Salary Type='HourlyRate' Min='25' Max='34.99' AdditionalText='' />
<StandOut IsStandOut='false' LogoID='' Bullet1='' Bullet2='' Bullet3='' />
</Job>

<Job Reference='28777-2' TemplateID='3575' ScreenID=''>
<Title><![CDATA[Leading Hand Carpenter 2]]></Title>
<SearchTitle><![CDATA[Leading Hand Carpenter]]></SearchTitle>
<Description><![CDATA[Competitive Rates and Opportunity for Career Progression!]]></Description>
<AdDetails><![CDATA[<ul>
	<li><span style='color:rgb(0, 0, 128)'><strong>Competitive Salary</strong></span></li>
	<li><span style='color:rgb(0, 0, 128)'><strong>Friendly working team environment</strong></span></li>
	<li><span style='color:rgb(0, 0, 128)'><strong>Opportunity for career progression</strong></span></li>
</ul>

<p><br />
<span style='color:rgb(0, 0, 128)'>Stellar Recruitment are looking for ambitious, capable and energetic people with a good dose of common sense to join our team. We work hard to be the best, we give it our all and we take pride in what we do.<br />
<br />
We are actively seeking a <strong>Leading Hand Carpenter</strong> to join with our client to commence work on a new commercial project, with an immediate start. It is essential that applicants for this role have previous experience in the commercial sector, and a proven record of quality workmanship behind them.<br />
<br />
<strong>To be successful in this role you will have:</strong><br />
- 5+ years industry experience<br />
- Proven ability to manage a team onsite<br />
- To be confident reading &amp; working from technical specifications &amp; construction plans<br />
- Hold a current Site Safe Certificate<br />
- A clean full drivers licence (minimum of class 1)<br />
- Your own reliable transport in order to get yourself to and from site<br />
- Excellent communication and interpersonal skills<br />
- Able to provide your own hand and power tools<br />
<br />
Ideally we are looking for a highly health and safety aware, positive and hardworking attitude. We are prepared to wait for the right person for this role.<br />
<br />
To apply for this role or for further information please contact <strong>Nicky</strong> at Stellar Workforce.<br />
<br />
<strong>Nicky Sutherland<br />
DDI: 03 974 2440<br />
Cell phone: 021 224 1496<br />
Email: Nicky.s@stellarworkforce.co.nz</strong></span><br />
&nbsp;</p>
]]></AdDetails>
<ApplicationEmail>nicky.s@stellarworkforce.co.nz</ApplicationEmail>
<CONTACTDETAILS><CLASSIFICATION><![CDATA[Nicky Sutherland]]></CLASSIFICATION></CONTACTDETAILS>
<ApplicationURL><![CDATA[http://candidateportal.stellarrecruitment.com.au/adaptstellar/login/?jobref=1248071&src=WE]]></ApplicationURL>
<ResidentsOnly>Yes</ResidentsOnly>
<Items>
<Item Name='Jobtitle'><![CDATA[Leading Hand Carpenter]]></Item>
<Item Name='Bullet1'><![CDATA[A]]></Item>
<Item Name='Bullet2'><![CDATA[B]]></Item>
<Item Name='Bullet3'><![CDATA[C]]></Item>
</Items>
<Listing MarketSegments='Main'>
<Classification Name='Location'>Canterbury</Classification>
<Classification Name='Area'>Christchurch</Classification>
<Classification Name='Classification'>TradesServices</Classification>
<Classification Name='SubClassification'>CarpentryCabinetMaking</Classification>
<Classification Name='WorkType'>FullTime</Classification></Listing>
<Salary Type='HourlyRate' Min='25' Max='34.99' AdditionalText='' />
<StandOut IsStandOut='false' LogoID='' Bullet1='' Bullet2='' Bullet3='' />
</Job>

<Job Reference='28777-3' TemplateID='3575' ScreenID=''>
<Title><![CDATA[Leading Hand Carpenter 3]]></Title>
<SearchTitle><![CDATA[Leading Hand Carpenter]]></SearchTitle>
<Description><![CDATA[Competitive Rates and Opportunity for Career Progression!]]></Description>
<AdDetails><![CDATA[<ul>
	<li><span style='color:rgb(0, 0, 128)'><strong>Competitive Salary</strong></span></li>
	<li><span style='color:rgb(0, 0, 128)'><strong>Friendly working team environment</strong></span></li>
	<li><span style='color:rgb(0, 0, 128)'><strong>Opportunity for career progression</strong></span></li>
</ul>

<p><br />
<span style='color:rgb(0, 0, 128)'>Stellar Recruitment are looking for ambitious, capable and energetic people with a good dose of common sense to join our team. We work hard to be the best, we give it our all and we take pride in what we do.<br />
<br />
We are actively seeking a <strong>Leading Hand Carpenter</strong> to join with our client to commence work on a new commercial project, with an immediate start. It is essential that applicants for this role have previous experience in the commercial sector, and a proven record of quality workmanship behind them.<br />
<br />
<strong>To be successful in this role you will have:</strong><br />
- 5+ years industry experience<br />
- Proven ability to manage a team onsite<br />
- To be confident reading &amp; working from technical specifications &amp; construction plans<br />
- Hold a current Site Safe Certificate<br />
- A clean full drivers licence (minimum of class 1)<br />
- Your own reliable transport in order to get yourself to and from site<br />
- Excellent communication and interpersonal skills<br />
- Able to provide your own hand and power tools<br />
<br />
Ideally we are looking for a highly health and safety aware, positive and hardworking attitude. We are prepared to wait for the right person for this role.<br />
<br />
To apply for this role or for further information please contact <strong>Nicky</strong> at Stellar Workforce.<br />
<br />
<strong>Nicky Sutherland<br />
DDI: 03 974 2440<br />
Cell phone: 021 224 1496<br />
Email: Nicky.s@stellarworkforce.co.nz</strong></span><br />
&nbsp;</p>
]]></AdDetails>
<ApplicationEmail>nicky.s@stellarworkforce.co.nz</ApplicationEmail>
<CONTACTDETAILS><CLASSIFICATION><![CDATA[Nicky Sutherland]]></CLASSIFICATION></CONTACTDETAILS>
<ApplicationURL><![CDATA[http://candidateportal.stellarrecruitment.com.au/adaptstellar/login/?jobref=1248071&src=WE]]></ApplicationURL>
<ResidentsOnly>Yes</ResidentsOnly>
<Items>
<Item Name='Jobtitle'><![CDATA[Leading Hand Carpenter]]></Item>
<Item Name='Bullet1'><![CDATA[A]]></Item>
<Item Name='Bullet2'><![CDATA[B]]></Item>
<Item Name='Bullet3'><![CDATA[C]]></Item>
</Items>
<Listing MarketSegments='Main'>
<Classification Name='Location'>Canterbury</Classification>
<Classification Name='Area'>Christchurch</Classification>
<Classification Name='Classification'>TradesServices</Classification>
<Classification Name='SubClassification'>CarpentryCabinetMaking</Classification>
<Classification Name='WorkType'>FullTime</Classification></Listing>
<Salary Type='HourlyRate' Min='25' Max='34.99' AdditionalText='' />
<StandOut IsStandOut='false' LogoID='' Bullet1='' Bullet2='' Bullet3='' />
</Job>
</Client></FastLanePlus>
";*/

            #endregion

            bool blnSuccess = false;

            string TransformedXML = Utils.TransformXML(clientSetup.PosterTransformXSL, xml);

            #region Temp transformed xml

            /*TransformedXML = @"

<JobPostRequest xmlns='http://schemas.servicestack.net/types'>
<UserName>Organisation</UserName>
<Password>Organisation123</Password>
<AdvertiserId>8249</AdvertiserId>
<ArchiveMissingJobs>true</ArchiveMissingJobs>
<Listings>
<JobListing>
	<JobAdType>Normal</JobAdType>
	<ReferenceNo>JO-1603-5197_145931830618774</ReferenceNo>
	<JobTitle>Contract Product Manager</JobTitle>
	<JobUrl>contract-product-manager</JobUrl>
	<ShortDescription>Join this dynamic financial services organisation and utilise your extensive experience to help drive project delivery across the business.</ShortDescription>
	<Bulletpoints>
		<BulletPoint1>Senior Business Analyst position</BulletPoint1>
		<BulletPoint2>Dynamic financial services organisation</BulletPoint2>
		<BulletPoint3>Initial 4-month contract role</BulletPoint3>
	</Bulletpoints>
	<JobFullDescription><![CDATA[<p><b>Operational Excellence for Monash / Southeast University Partnership</b></p><p><b>Three year fixed-term appointment</b></p><p>Monash University is a world-class, research-intensive, global institution active on four continents. It is the first Australian University to be granted a licence to operate in China and has set up with Southeast University a Joint Graduate School and a Joint Research Institute in Suzhou.</p><p>Outstanding professional leadership will be vital to this higher education enterprise and to Monash University's ambition to raise its stature in China and to improve research and teaching excellence in Australia and China. The General Manager, operating in Suzhou, reports to the Pro Vice-Chancellor and the President of Monash Suzhou and will be expected to participate actively as a key senior member of Monash Suzhou by providing professional expertise on all operational matters. <br /><br />Fluent in written and spoken Mandarin and English, the successful candidate will have a strong general management background and an ability to deal with HR, budgetary, facilities and financial matters in a complex environment. Previous experience in and expertise of Chinese and Australian higher education operating environments will be highly desirable.<br /><br />If you feel you have the skills and experience to make this role a success, your application is encouraged.</p><h3><b>Enquiries</b></h3><p>Janie Fung, Project Manager - China, 03 990 24383</p><h3><b>Position Description</b></h3><p><el><img src='https://az29734.vo.msecnd.net/static/people/icons/icon_file_small.gif' alt='Download File'>&nbsp;<a href='https://secure.dc2.pageuppeople.com/apply/TransferRichTextFile.ashx?sData=Fwg6i4Eli-CvqEttJIIpKM_TBF8QaWpPuT8Df-ERmNbf-aWtPSTS6XBlqvykXGaYQgor794Nwwg%7e'>Mar PD - General Manager, Monash Suzhou Facility .pdf</a></el><br /></p><h3><b>Closing Date</b></h3><p><b></b></p><p>Sunday 10 April 2016, 11:55pm AEST</p>]]></JobFullDescription>
	<ContactDetails>Emily Casey</ContactDetails>
	<CompanyName />
	<ConsultantID />
	<PublicTransport>JO-1603-5197_145931830618774</PublicTransport>
	<ResidentsOnly>false</ResidentsOnly>
	<IsQualificationsRecognised>false</IsQualificationsRecognised>
	<ShowLocationDetails>true</ShowLocationDetails>
	<JobTemplateID>846</JobTemplateID>
	<AdvertiserJobTemplateLogoID />
	<Categories>
		<Category>
			<Classification>21</Classification>
			<SubClassification>295</SubClassification>
		</Category>
	</Categories>
	<ListingClassification>
		<WorkType>4</WorkType>
		<Sector>0</Sector>
		<StreetAddress />
		<Tags>0</Tags>
		<Country>1</Country>
		<Location>6</Location>
		<Area>27</Area>
	</ListingClassification>
	<Salary>
		<SalaryType>Annual</SalaryType>
		<Min>0</Min>
		<Max>0</Max>
		<AdditionalText />
		<ShowSalaryDetails>true</ShowSalaryDetails>
	</Salary>
	<ApplicationMethod>
		<JobApplicationType>Default</JobApplicationType>
		<ApplicationUrl />
		<ApplicationEmail>emilyc.18774.7619@globalcareerlink.aplitrak.com</ApplicationEmail>
	</ApplicationMethod>
	<Referral>
		<HasReferralFee>false</HasReferralFee>
		<Amount>0</Amount>
		<ReferralUrl />
	</Referral>
</JobListing>
</Listings>
</JobPostRequest>
";
            */
            #endregion

            // Do the mapping 
            var serializer = new XmlSerializer(typeof(JobPostRequest));
            using (var reader = new StringReader(TransformedXML))
            {
                try
                {
                    JobPostRequest jobListings = (JobPostRequest)serializer.Deserialize(reader);
                    if (jobListings != null)
                    {
                        jobListings.AdvertiserId = clientSetup.AdvertiserId.Value;
                        jobListings.UserName = clientSetup.AdvertiserUsername;
                        jobListings.Password = clientSetup.AdvertiserPassword;
                        jobListings.ArchiveMissingJobs = clientSetup.ArchiveMissingJobs;

                        if (enableShortDescriptionPullFromFullDescription)
                        {
                            int trimLength = 1000; //shortDescription max length is 1000
                            foreach (JobListing job in jobListings.Listings.Where(c=> string.IsNullOrEmpty(c.ShortDescription) ))
                            {
                                if (!string.IsNullOrEmpty(job.JobFullDescription))
                                {
                                    string strContent = Common.Utils.StripHTML(job.JobFullDescription);
                                    if (strContent.Length > trimLength)
                                    {
                                        strContent = strContent.Substring(0, trimLength - 3) + "...";
                                    }
                                    job.ShortDescription = strContent;
                                }
                            }
                        }

                        // Mappings
                        MappingsLogic MappingsLogic = new MappingsLogic();
                        string errorMsg = string.Empty;
                        MappingsXMLModel MappingsXMLModel = MappingsLogic.ClientMappingsGet(clientSetup.ClientId, clientSetup.ClientSetupId, out errorMsg);
                        if (!string.IsNullOrWhiteSpace(errorMsg))
                        {
                            Console.WriteLine(errorMsg);
                            return false;
                        }

                        foreach (var item in MappingsXMLModel.CLAMaps)
                        {

                            if (!string.IsNullOrWhiteSpace(item.ClientCountryID) && !string.IsNullOrWhiteSpace(item.ClientLocationID) && !string.IsNullOrWhiteSpace(item.ClientAreaID))
                            {
                                foreach (var job in jobListings.Listings)
                                {

                                    if (job.ListingClassification.Country == item.ClientCountryID
                                                                    && job.ListingClassification.Location == item.ClientLocationID
                                                                    && job.ListingClassification.Area == item.ClientAreaID)
                                    {
                                        job.ListingClassification.Country = item.MapToCountryID.ToString();
                                        job.ListingClassification.Location = item.MapToLocationID.ToString();
                                        job.ListingClassification.Area = item.MapToAreaID.ToString();
                                    }

                                }
                                /*
                                jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                                && w.ListingClassification.Location == item.ClientLocationID
                                                                && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());

                                jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                                && w.ListingClassification.Location == item.ClientLocationID
                                                                && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                        .ForEach(i => i.ListingClassification.Location = item.MapToLocationID.ToString());

                                jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                                && w.ListingClassification.Location == item.ClientLocationID
                                                                && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                         .ForEach(i => i.ListingClassification.Area = item.MapToAreaID.ToString());*/
                                //.ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());
                            }
                            else if (!string.IsNullOrWhiteSpace(item.ClientLocationID) && !string.IsNullOrWhiteSpace(item.ClientAreaID))
                            {
                                foreach (var job in jobListings.Listings)
                                {

                                    if (job.ListingClassification.Location == item.ClientLocationID
                                                                    && job.ListingClassification.Area == item.ClientAreaID)
                                    {
                                        job.ListingClassification.Country = item.MapToCountryID.ToString();
                                        job.ListingClassification.Location = item.MapToLocationID.ToString();
                                        job.ListingClassification.Area = item.MapToAreaID.ToString();
                                    }

                                }
                                /*
                                jobListings.Listings.Where(w => w.ListingClassification.Location == item.ClientLocationID
                                                                && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                    .ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());

                                jobListings.Listings.Where(w => w.ListingClassification.Location == item.ClientLocationID
                                                                && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                    .ForEach(i => i.ListingClassification.Location = item.MapToLocationID.ToString());

                                jobListings.Listings.Where(w => w.ListingClassification.Location == item.ClientLocationID
                                                                && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                    .ForEach(i => i.ListingClassification.Area = item.MapToAreaID.ToString());*/
                            }
                            else if (!string.IsNullOrWhiteSpace(item.ClientCountryID) && !string.IsNullOrWhiteSpace(item.ClientLocationID))
                            {
                                foreach (var job in jobListings.Listings)
                                {

                                    if (job.ListingClassification.Location == item.ClientLocationID
                                                                    && job.ListingClassification.Country == item.ClientCountryID)
                                    {
                                        job.ListingClassification.Country = item.MapToCountryID.ToString();
                                        job.ListingClassification.Location = item.MapToLocationID.ToString();
                                        job.ListingClassification.Area = item.MapToAreaID.ToString();
                                    }

                                }

                            }
                            else if (!string.IsNullOrWhiteSpace(item.ClientAreaID))
                            {
                                foreach (var job in jobListings.Listings)
                                {

                                    if (job.ListingClassification.Area == item.ClientAreaID)
                                    {
                                        job.ListingClassification.Country = item.MapToCountryID.ToString();
                                        job.ListingClassification.Location = item.MapToLocationID.ToString();
                                        job.ListingClassification.Area = item.MapToAreaID.ToString();
                                    }

                                }
                                /*
                                jobListings.Listings.Where(w => w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                    .ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());
                                jobListings.Listings.Where(w => w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                     .ForEach(i => i.ListingClassification.Location = item.MapToLocationID.ToString());
                                jobListings.Listings.Where(w => w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                    .ForEach(i => i.ListingClassification.Area = item.MapToAreaID.ToString());*/
                                //.ForEach(i => i.ListingClassification.Country = item.MapToCountryID.ToString());
                            }
                            else if (!string.IsNullOrWhiteSpace(item.ClientLocationID))
                            {
                                foreach (var job in jobListings.Listings)
                                {

                                    if (job.ListingClassification.Location == item.ClientLocationID)
                                    {
                                        job.ListingClassification.Country = item.MapToCountryID.ToString();
                                        job.ListingClassification.Location = item.MapToLocationID.ToString();
                                        job.ListingClassification.Area = item.MapToAreaID.ToString();
                                    }

                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(item.ClientCountryID))
                            {
                                foreach (var job in jobListings.Listings)
                                {

                                    if (job.ListingClassification.Country == item.ClientCountryID)
                                    {
                                        job.ListingClassification.Country = item.MapToCountryID.ToString();
                                        job.ListingClassification.Location = item.MapToLocationID.ToString();
                                        job.ListingClassification.Area = item.MapToAreaID.ToString();
                                    }

                                }
                            }

                        }
                        if (MappingsXMLModel.JobTemplateLogoMaps != null)
                        {
                            foreach (var item in MappingsXMLModel.JobTemplateLogoMaps)
                            {
                                jobListings.Listings.Where(w => w.AdvertiserJobTemplateLogoID == item.ClientJobTemplateLogoID).ToList()
                                                        .ForEach(i => i.AdvertiserJobTemplateLogoID = item.MapToJobTemplateLogoID.ToString());
                            }
                        }

                        /*
                        // Default mappings
                        JobTemplateMap jobTemplateDefaultMapping = MappingsXMLModel.JobTemplateMaps.Where(s => s.isDefaultSetting == true).FirstOrDefault();
                        if (jobTemplateDefaultMapping != null)
                        {
                            jobListings.Listings.Where(w => w.JobTemplateID.Contains != item.ClientJobTemplateID).ToList()
                                                .ForEach(i => i.JobTemplateID = item.MapToJobTemplateID.ToString());
                        }
                        */

                        if (MappingsXMLModel.JobTemplateMaps != null)
                        {
                            foreach (var item in MappingsXMLModel.JobTemplateMaps)
                            {

                                jobListings.Listings.Where(w => w.JobTemplateID == item.ClientJobTemplateID).ToList()
                                                        .ForEach(i => i.JobTemplateID = item.MapToJobTemplateID.ToString());
                            }
                        }
                        foreach (var item in MappingsXMLModel.ProfRoleMaps)
                        {
                            // Need ProfessionID
                            /*foreach (var item in jobListings.Listings)
                            {
                                
                            }*/
                            /*
                            jobListings.Listings.Where(w => w.ListingClassification.Country == item.ClientCountryID
                                                            && w.ListingClassification.Location == item.ClientLocationID
                                                            && w.ListingClassification.Area == item.ClientAreaID).ToList()
                                                    .Select(c => { c.ListingClassification.Country = item.MapToCountryID.ToString(); return c; })
                                                    .Select(c => { c.ListingClassification.Location = item.MapToLocationID.ToString(); return c; })
                                                    .Select(c => { c.ListingClassification.Area = item.MapToAreaID.ToString(); return c; });*/



                            foreach (var job in jobListings.Listings)
                            {
                                if (job.Categories != null)
                                {
                                    for (int i = 0; i < job.Categories.Count; i++)
                                    {
                                        if (!string.IsNullOrWhiteSpace(job.Categories[i].Classification) &&
                                            !string.IsNullOrWhiteSpace(job.Categories[i].SubClassification) &&
                                            job.Categories[i].Classification == item.ClientProfessionID
                                                                && job.Categories[i].SubClassification == item.ClientRoleID)
                                        {
                                            job.Categories[i].Classification = item.MapToProfessionID.ToString();
                                            job.Categories[i].SubClassification = item.MapToRoleID.ToString();
                                        }
                                        else if (!string.IsNullOrWhiteSpace(job.Categories[i].Classification) &&
                                            job.Categories[i].Classification == item.ClientProfessionID)
                                        {
                                            job.Categories[i].Classification = item.MapToProfessionID.ToString();
                                            job.Categories[i].SubClassification = item.MapToRoleID.ToString();
                                        }
                                        else if (!string.IsNullOrWhiteSpace(job.Categories[i].SubClassification) &&
                                                job.Categories[i].SubClassification == item.ClientRoleID)
                                        {
                                            job.Categories[i].Classification = item.MapToProfessionID.ToString();
                                            job.Categories[i].SubClassification = item.MapToRoleID.ToString();
                                        }
                                    }

                                }

                                /*
                                job.Categories.Where(w => w.Classification == item.ClientProfessionID
                                                                && w.SubClassification == item.ClientRoleID).ToList()
                                                    .ForEach(i => i.Classification = item.MapToProfessionID.ToString());

                                job.Categories.Where(w => w.Classification == item.ClientProfessionID
                                                                && w.SubClassification == item.ClientRoleID).ToList()
                                                    .ForEach(i => i.SubClassification = item.MapToRoleID.ToString());*/
                            }
                        }
                        foreach (var item in MappingsXMLModel.WorkTypeMaps)
                        {
                            jobListings.Listings.Where(w => w.ListingClassification.WorkType == item.ClientWorkTypeID).ToList()
                                                    .ForEach(i => i.ListingClassification.WorkType = item.MapToWorkTypeID.ToString());

                        }

                        //foreach (var job in jobListings.Listings)
                        //{
                        //    job.ListingClassification.Country = "265";
                        //    job.ListingClassification.Location = "465";
                        //    job.ListingClassification.Area = "2235";

                        //    job.Categories.First().Classification = "3";
                        //    job.Categories.First().SubClassification = "1";
                        //}

                        // TODO Salary Types

                        // TODO LOW - Job Ad Type
                        // TODO LOW - Job application Type

                        serializer = new XmlSerializer(typeof(JobPostRequest));
                        //string transformedXML = string.Empty;

                        using (Utf8StringWriter sww = new Utf8StringWriter())
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            serializer.Serialize(writer, jobListings); //, ns

                            TransformedXML = sww.ToString(); // Your XML
                        }

                        // Save the transformed XML
                        System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Request.xml", TransformedXML);

                        string jobResponse = string.Empty;

                        // Only post when they are jobs - if not don't post.
                        if (jobListings != null && jobListings.Listings != null && jobListings.Listings.Count > 0)
                            jobResponse = Process(TransformedXML, ConfigurationManager.AppSettings["WebserviceURL"]);
                        else
                            jobResponse = "No jobs to post";

                        // Save the response XML
                        System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Response.xml", jobResponse);

                        blnSuccess = true;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex.Message); // TODO
                    Console.WriteLine("Error - " + ex.StackTrace); // TODO
                    Console.WriteLine("Error - " + ex.InnerException); // TODO
                }

            }



            // Save the POST XML.
            using (ClientSetupLogService _service = new ClientSetupLogService())
            {
                _service.CreateClientSetupLog(clientSetup, fileName + "_Raw.xml", fileName + "_Request.xml", fileName + "_Response.xml", dtStartTime);
            }

            return blnSuccess;
        }

        public bool ArchiveRGFJobs(GetAllClientSetupsToRun_Result clientSetup, JXTPosterTransform.Library.Methods.Client.PullJsonFromRGF.RGFJobBoardDataRoot data)
        {
            if (data == null || data.jobBoards == null || data.jobBoards.jobboardlisting == null || data.jobBoards.jobboardlisting.removedIds == null)
                return true;

            var listings = (from m in data.jobBoards.jobboardlisting.removedIds select new Job { ReferenceNo = m }).ToList();

            if (!listings.Any())
                return true;

            ArchiveJobRequest archiveJobRequest = new ArchiveJobRequest();
            archiveJobRequest.AdvertiserId = clientSetup.AdvertiserId.Value;
            archiveJobRequest.UserName = clientSetup.AdvertiserUsername;
            archiveJobRequest.Password = clientSetup.AdvertiserPassword;
            archiveJobRequest.Listings = listings; 
            
            string xmlToService = null;
            var serializer = new XmlSerializer(typeof(ArchiveJobRequest));
            try
            {
                using (Utf8StringWriter sww = new Utf8StringWriter())
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        serializer.Serialize(writer, archiveJobRequest); //, ns

                        xmlToService = sww.ToString(); // Your XML
                    }

                Process(xmlToService, ConfigurationManager.AppSettings["WebserviceArchiveURL"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message); // TODO
                Console.WriteLine("Error - " + ex.StackTrace); // TODO
                Console.WriteLine("Error - " + ex.InnerException); // TODO
                return false;
            }

            return true;
        }


        public string Process(string xml, string serviceURL)
        {

            string Response = string.Empty;

            try
            {
                string uri = serviceURL;
                //Console.WriteLine(serviceURL);

                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = "POST";
                req.Timeout = 500000;
                //if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
                {
                    //Console.WriteLine("Enter XML FilePath:");
                    //string FilePath = Console.ReadLine();
                    //content = (File.OpenText(@FilePath)).ReadToEnd();

                    byte[] buffer = Encoding.UTF8.GetBytes(xml);
                    req.ContentLength = buffer.Length;
                    req.ContentType = "text/xml";
                    Stream PostData = req.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();
                }

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

                Encoding enc = System.Text.Encoding.GetEncoding(1252);
                StreamReader loResponseStream =
                new StreamReader(resp.GetResponseStream(), enc);

                Response = loResponseStream.ReadToEnd();

                loResponseStream.Close();
                resp.Close();

                //Console.WriteLine(Response);
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    if (httpResponse != null && response != null)
                    {
                        Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data = response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                    }
                }

                Console.WriteLine("Error - " + e.Message); // TODO
                Console.WriteLine("Error - " + e.StackTrace); // TODO
                Console.WriteLine("Error - " + e.InnerException); // TODO
            }

            return Response;

            /*
            HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(coreURL);
            //Method type
            POSTRequest.Method = "PUT";
            // Data type - message body coming in xml
            POSTRequest.ContentType = "application/x-www-form-urlencoded";
            POSTRequest.KeepAlive = false;
            POSTRequest.Timeout = 5000;

            Stream POSTstream = POSTRequest.GetRequestStream();
            POSTstream.Close();
            //Get response from server
            HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();
            StreamReader reader = new StreamReader(POSTResponse.GetResponseStream(), Encoding.UTF8);
            Console.WriteLine("Response");
            Console.WriteLine(reader.ReadToEnd().ToString());
            */
            /*
                // Create HttpClient instance to use for the app 
                HttpClient aClient = new HttpClient();

                // Uri is where we are posting to: 
                Uri theUri = new Uri(accountDetail.MiniJxtRestApi);
                aClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string payload = JsonConvert.SerializeObject(listings, Formatting.Indented);

                // use the Http client to POST some content ( ‘theContent’ not yet defined). 
                var response = await aClient.PostAsync(accountDetail.MiniJxtRestApi, new StringContent(payload, Encoding.UTF8, "application/json"));
   
                string contentResponse = await response.Content.ReadAsStringAsync();

                JobResponse jobResponse = JObject.Parse(contentResponse).ToObject<JobResponse>();
                return jobResponse;*/
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        #endregion

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
    }
}
