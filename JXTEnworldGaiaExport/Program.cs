using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal;
using JXTPortal.Entities;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Xml.Linq;

namespace JXTEnworldGaiaExport
{
    class Program
    {
        /*
         * To have the program working you will need to update the following SP
         * 
         * CREATE PROCEDURE  [dbo].[Members_CustomGetNewValidMembers]         
(                   
 @SiteID INT,         
 @LastModifiedDate DateTime                
)                   
AS                   
BEGIN                   
          
SELECT Members.MemberID,          
  Members.Username,         
  Members.Title,         
  Members.FirstName,         
  Members.Surname,         
  Members.EmailAddress,         
  Members.HomePhone,         
  Members.WorkPhone,         
  Members.MobilePhone,         
  Members.Address1,         
  Members.PostCode,         
  Members.Suburb,         
  Members.States,         
  Members.EmailFormat,         
  Members.DateOfBirth,         
  Members.Gender,         
  Members.Fax,         
  Members.CountryID,         
  Members.EducationID,         
  Members.Tags,         
  Members.LastModifiedDate,         
  Members.Subscribed,         
  Members.PassportNo,         
  Members.PreferredCategoryID,         
  Members.PreferredSubCategoryID,   
  Members.ReferringSiteID,  
  Members.Validated,       
  Countries.Abbr,          
  Countries.CountryName,       
  COUNT(MemberFiles.MemberFileID) as MemberFilesCount         
 FROM Members (NOLOCK)          
  LEFT JOIN MemberFiles (NOLOCK) ON Members.MemberID = MemberFiles.MemberID          
  INNER JOIN Countries (NOLOCK) ON Members.CountryID = Countries.CountryID          
 WHERE SiteID = @SiteID --AND Members.Validated = 1         
 AND (Members.LastModifiedDate >= @LastModifiedDate OR MemberFiles.LastModifiedDate >= @LastModifiedDate)     
 GROUP by          
  Members.MemberID,          
  Members.Username,         
  Members.Title,         
  Members.FirstName,         
  Members.Surname,         
  Members.EmailAddress,         
  Members.HomePhone,         
  Members.WorkPhone,         
  Members.MobilePhone,         
  Members.Address1,         
  Members.PostCode,         
  Members.Suburb,         
  Members.States,         
  Members.EmailFormat,         
  Members.DateOfBirth,         
  Members.Gender,         
  Members.Fax,         
  Members.CountryID,         
  Members.EducationID,         
  Members.Tags,         
  Members.LastModifiedDate,         
  Members.Subscribed,         
  Members.PassportNo,         
  Members.PreferredCategoryID,         
  Members.PreferredSubCategoryID,     
  Members.ReferringSiteID,     
  Members.Validated,         
  Countries.Abbr,          
  Countries.CountryName         
            
            
 SELECT MemberFiles.MemberFileID,         
 MemberFiles.MemberID,         
 MemberFiles.DocumentTypeID as MemberFileTypeID,         
MemberFiles.MemberFileName,         
MemberFiles.MemberFileSearchExtension,         
-- MemberFiles.MemberFileContent,         
MemberFiles.MemberFileTitle,         
MemberFiles.LastModifiedDate         
             
 FROM Members (NOLOCK)          
  INNER JOIN MemberFiles (NOLOCK) ON Members.MemberID = MemberFiles.MemberID          
 WHERE SiteID = @SiteID AND Members.Validated = 1          
 AND MemberFiles.LastModifiedDate >= @LastModifiedDate         
             
END
         * */




        static void Main(string[] args)
        {
            List<SitesXML> siteXMLList = SettingsGet();

            foreach (SitesXML thisSite in siteXMLList)
            {
                //Generate Member Json and Stored into the Temp folder specified in App.Config 
                List<UploadTracker> memberTrackers;
                bool allMemberGeneratedSuccessfully = MemberGeneration.Start(thisSite.SiteId, thisSite.ReferringSiteIds, thisSite.MemberGenerationLastExecuted, out memberTrackers);

                if (!allMemberGeneratedSuccessfully)
                {
                    //send email?

                    return;
                }

                //Send member files
                bool allMemberJsonUploadedSuccessfully = SFTPProcessor.UploadJsonFilesToSFTP(thisSite.FTPDetails, memberTrackers, ConfigurationManager.AppSettings["SFTPTargetPath"] + "/members");

                //update xml with member id
                UploadTracker lastUploadedMember = memberTrackers.Where(c => c.processed).OrderBy(c => c.itemID).Last();
                if (lastUploadedMember != null)
                {
                    UpdateXML(thisSite, lastUploadedMember.itemID, null);
                }

                if (!allMemberJsonUploadedSuccessfully)
                {
                    //send email?

                    return;
                }


                //Generate Applications
                List<UploadTracker> applicationTrackers;
                MemberApplicationGeneration.Start(thisSite.SiteId, thisSite.LastJobApplicationId, out applicationTrackers);

                //Send application files
                bool allApplicationJsonUploadedSuccessfully = SFTPProcessor.UploadJsonFilesToSFTP(thisSite.FTPDetails, applicationTrackers, ConfigurationManager.AppSettings["SFTPTargetPath"] + "/applications");

                ////update xml with application id
                UploadTracker lastUploadedApplication = applicationTrackers.Where(c => c.processed).OrderBy(c => c.itemID).Last();
                if (lastUploadedMember != null)
                {
                    UpdateXML(thisSite, null, lastUploadedApplication.itemID);
                }

                //if (!allApplicationJsonUploadedSuccessfully)
                //{
                //    //send email?

                //    return;
                //}


            }
        }

        private static List<SitesXML> SettingsGet()
        {
            // Loading from a file, you can also load from a stream
            var xml = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);

            // Query the data and write out a subset of contacts
            return xml.Descendants("site").Select(c => new SitesXML()
            {
                SiteId = (int)c.Element("SiteId"),
                ReferringSiteIds = (string)c.Element("ReferringSiteIds"),
                FTPDetails = new FTPDetails{
                    host = (string)c.Element("host"),
                    username = (string)c.Element("username"),
                    password = (string)c.Element("password"),
                    sftp = (bool)c.Element("sftp"),
                    port = (int)c.Element("port")
                },
                MemberGenerationLastExecuted = (DateTime) c.Element("MemberGenerationLastExecuted"),

                LastJobApplicationId = (string)c.Element("LastJobApplicationId")
            }).ToList();

        }

        /// <summary>
        /// Update the Sites XML file with the last successful Application ID.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="strLastApplicationID"></param>
        protected static void UpdateXML(SitesXML siteXML, int? strLastMemberID, int? strLastApplicationID)
        {
            if ( strLastApplicationID != null  || strLastMemberID != null )
            {
                //string test = string.Empty;

                XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);
                //var query = from c in xmlFile.Elements(test).Elements(test)
                //            select c;
                foreach (XElement site in xmlFile.Elements("sites").Elements("site"))
                {
                    if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                    {
                        if ( strLastApplicationID != null)
                            site.Element("LastJobApplicationId").Value = strLastApplicationID.Value.ToString();

                        if (strLastMemberID != null )
                            site.Element("MemberGenerationLastExecuted").Value = strLastMemberID.Value.ToString();

                        break;
                    }
                }

                xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);
            }
        }


    }


    #region Classes

    public class SitesXML
    {
        public int SiteId;
        public string ReferringSiteIds;
        public DateTime MemberGenerationLastExecuted;
        public string LastJobApplicationId;
        public FTPDetails FTPDetails;
    }

    public class UploadTracker
    {
        public int itemID { get; set; }
        public string filePath { get; set; }
        public string fileName { get; set; }
        public bool processed { get; set; }
    }

    public class FTPDetails
    {
        public string host;
        public string username;
        public string password;
        public bool sftp;
        public int port;
    }

    public class FileNames
    {
        public string Id;
        public string fromFilename;
        public string toFilename;

        public FileNames(string _id, string _fromFilenames, string _toFilename)
        {
            Id = _id;
            fromFilename = _fromFilenames;
            toFilename = _toFilename;
        }
    }

    #endregion

}



/* Member_386303.json
 {
	"JXTMemberID": 386303,
	"Domain": "enworld.co.in",
	"LastModifiedDate": "2015-11-27 10:55:46",
	"CreatedDate": "2015-11-27 10:55:46",
	"Resumes": [],
	"Id": "003O000000n8iraIAA",
	"FirstName": "aaaa",
	"LastName": "bbbb",
	"First_Name_Local__c": null,
	"Last_Name_Local__c": null,
	"Email": "h1@aaa.com",
	"RecordTypeId": "01210000000ZeUdAAK",
	"ts2__EEO_Gender__c": null,
	"Birthdate": null,
	"MobilePhone": null,
	"Phone": null,
	"Secondary_Email__c": "",
	"MailingStreet": null,
	"MailingCity": null,
	"MailingPostalCode": null,
	"MailingState": null,
	"MailingCountry": null,
	"Native_Language__c": null,
	"Second_Language__c": null,
	"Second_Language_Proficiency__c": null,
	"Current_Company__c": null,
	"Current_Position__c": null,
	"Industry__c": null,
	"Job_Category__c": null,
	"Job_Functions__c": null,
	"Employment_Type__c": null,
	"Salary_Period__c": null,
	"Current_Fixed_Salary__c": null,
	"Annual_Variable_Salary__c": null,
	"Desired_Country__c": null,
	"Desired_Locations__c": null,
	"Employment_Preference__c": null,
	"Desired_Industry__c": null,
	"Desired_Job_Category__c": null,
	"Desired_Job_Functions__c": null,
	"Desired_Other_Countries__c": null
}
 {
	"JXTMemberID": 386297,
	"Domain": "enworld.co.in",
	"LastModifiedDate": "2015-11-27 10:23:20",
	"CreatedDate": "2015-11-27 10:23:20",
	"Resumes": [],
	"Id": "003O000000nT0n5IAC",
	"FirstName": "9588 Mod Moo",
	"LastName": "1234 Mod",
	"First_Name_Local__c": null,
	"Last_Name_Local__c": null,
	"Email": "himmy@jjjxxxttt.com.au",
	"RecordTypeId": "01210000000ZeUdAAK",
	"ts2__EEO_Gender__c": "Male",
	"Birthdate": "2015-11-03",
	"MobilePhone": "1234",
	"Phone": "99999",
	"Secondary_Email__c": "naveen6@jxt.com.au",
	"MailingStreet": "55 Clarence St",
	"MailingCity": "Sydney",
	"MailingPostalCode": "2000",
	"MailingState": "New South Wales",
	"MailingCountry": "Australia",
	"Native_Language__c": "Other",
	"Second_Language__c": "English",
	"Second_Language_Proficiency__c": "Advanced",
	"Current_Company__c": "JXT",
	"Current_Position__c": ".Net Dev",
	"Industry__c": "IT-Software",
	"Job_Category__c": "IT \u0026 Telecoms",
	"Job_Functions__c": "Consulting;Development / Programming / SE;IT Management / CIO",
	"Employment_Type__c": "Permanent",
	"Salary_Period__c": "Annual",
	"Current_Fixed_Salary__c": "1000.0",
	"Annual_Variable_Salary__c": "10.0",
	"Desired_Country__c": "Australia",
	"Desired_Locations__c": "Sydney;Melbourne",
	"Employment_Preference__c": "Contract;Permanent",
	"Desired_Industry__c": "IT-Software",
	"Desired_Job_Category__c": "IT \u0026 Telecoms",
	"Desired_Job_Functions__c": "Development / Programming / SE;IT Management / CIO",
	"Desired_Other_Countries__c": "Australia;India"
}
 
 Application_461218.json
 {
  "application": {
    "JXTMemberID": 386297,
    "refno": "145119",
    "applicationid": "461218",
    "date": "2015-11-26 10:00:40",
    "firstname": "Candidate110520153",
    "lastname": "test",
    "email": "Candidate110520153@test.com",
    "resume": [
        {
            "FileName": "Resume2.txt",
            "FileContent": "aW5zdGFsbCBhcHAgZmFicmljDQpydW4gd2l6YXJkDQpzdGFydCBwb3dlcnNoZWxsDQpjbWQ6IG5ldCBzdGFydCBSZW1vdGVSZWdpc3RyeQ0KY21kOiB1c2UtY2FjaGVjbHVzdGVyDQpjbWQ6IG5ldy1jYWNoZQ=="         
        }
	]
  }
}
 */