using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace JXTPosterTransform.Library.Models
{
    #region Archive Job Request

    [Serializable]
    [DataContract]
    [XmlRoot(ElementName = "ArchiveJobRequest", Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Archive", IsNullable = true)] //, XmlType("http://schemas.servicestack.net/types")
    public class ArchiveJobRequest
    {
        //xmlns="http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"
        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base")]
        public string UserName { get; set; }

        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base")]
        public string Password { get; set; }

        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base")]
        public int AdvertiserId { get; set; }
        
        [DataMember]
        public List<Job> Listings { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Job
    {
        [DataMember]
        public string ReferenceNo { get; set; }
    }

    #endregion

    [Serializable]
    [DataContract]
    [XmlRoot(ElementName = "JobPostRequest", Namespace = "http://schemas.servicestack.net/types", IsNullable = true)] //, XmlType("http://schemas.servicestack.net/types")
    public class JobPostRequest
    {
         //xmlns="http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"
        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base")]
        public string UserName { get; set; }

        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base")]
        public string Password { get; set; }
        
        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base")]
        public int AdvertiserId { get; set; }
        
        [XmlElement(Namespace = "http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base")]
        public bool? ArchiveMissingJobs { get; set; }

        public List<JobListing> Listings { get; set; }
    }
    /*
    [Serializable]
    [DataContract]
    public class JobListings
    {
        public JobListings()
        {
            Listings = new List<JobListing>();
        }

        public List<JobListing> Listings { get; set; }
        public int AdvertiserId { get; set; }
        public bool ArchiveMissingJobs { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    */
    [Serializable]
    [DataContract]
    public class JobListing
    {
        public JobListing()
        {
            //Bulletpoints = new BulletPoints();
            //Categories = new List<Category>();
            //ListingClassification = new ListingClassifications();
            //ApplicationMethod = new ApplicationMethods();
            //Salary = new Salarys();
            //Referral = new ReferralFee();
        }

        [DataMember(Order = 1)]
        public string JobAdType { get; set; }

        [DataMember(Order = 2)]
        public string ReferenceNo { get; set; }

        [DataMember(Order = 3)]
        public string JobTitle { get; set; }

        [DataMember(Order = 4)]
        public string JobUrl { get; set; }

        [DataMember(Order = 5)]
        public string ShortDescription { get; set; }

        [DataMember(Order = 6)]
        public BulletPoints Bulletpoints { get; set; }

        [DataMember(Order = 7)]
        [XmlElement("JobFullDescription")]
        public string JobFullDescription { get; set; }

        [DataMember(Order = 8)]
        public string ContactDetails { get; set; }

        [DataMember(Order = 9)]
        public string CompanyName { get; set; }

        [DataMember(Order = 10)]
        public string ConsultantID { get; set; }

        [DataMember(Order = 11)]
        public string PublicTransport { get; set; }

        [DataMember(Order = 12)]
        public bool? ResidentsOnly { get; set; }

        [DataMember(Order = 13)]
        public bool? IsQualificationsRecognised { get; set; }

        [DataMember(Order = 14)]
        public bool? ShowLocationDetails { get; set; }

        [DataMember(Order = 15)]
        public string JobTemplateID { get; set; }

        [DataMember(Order = 16)]
        public string AdvertiserJobTemplateLogoID { get; set; }

        [DataMember(Order = 17)]
        public List<Category> Categories { get; set; }

        [DataMember(Order = 18)]
        public ListingClassifications ListingClassification { get; set; }

        [DataMember(Order = 19)]
        public Salarys Salary { get; set; }

        [DataMember(Order = 20)]
        public ApplicationMethods ApplicationMethod { get; set; }

        [DataMember(Order = 21)]
        public ReferralFee Referral { get; set; }

    }


    public class BulletPoints
    {
        //[XmlIgnore]
        [XmlElement("BulletPoint1")]
        public string BulletPoint1 { get; set; }

        [XmlElement("BulletPoint2")]
        public string BulletPoint2 { get; set; }

        [XmlElement("BulletPoint3")]
        public string BulletPoint3 { get; set; }
    }

    [XmlRoot(ElementName = "Categories")]
    public class Categorys
    {
        List<Category> Category { get; set; }
    }

    //[XmlRoot(ElementName = "Category")]
    public class Category
    {
        [DataMember(Order = 1)]
        public string Classification { get; set; }

        [DataMember(Order = 2)]
        public string SubClassification { get; set; }
    }

    //[XmlRoot(ElementName = "ListingClassification")]
    public class ListingClassifications
    {
        public string WorkType { get; set; }
        public string Sector { get; set; }
        public string StreetAddress { get; set; }
        public string Tags { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Area { get; set; }
    }

    //[XmlRoot(ElementName = "Salary")]
    public class Salarys
    {
        [DataMember(Order = 1)]
        [XmlElement("SalaryType")]
        public string SalaryType { get; set; }

        [DataMember(Order = 2)]
        public string Min { get; set; }

        [DataMember(Order = 3)]
        public string Max { get; set; }

        [DataMember(Order = 4)]
        public string AdditionalText { get; set; }

        [DataMember(Order = 5)]
        public bool? ShowSalaryDetails { get; set; }
    }

    //[XmlRoot(ElementName = "ApplicationMethod")]
    public class ApplicationMethods
    {
        [DataMember(Order = 1)]
        public string JobApplicationType { get; set; }

        [DataMember(Order = 2)]
        public string ApplicationUrl { get; set; }

        [DataMember(Order = 3)]
        public string ApplicationEmail { get; set; }
    }

    [XmlRoot(ElementName = "Referral")]
    public class ReferralFee
    {
        [DataMember(Order = 1)]
        public bool? HasReferralFee { get; set; }

        [DataMember(Order = 2)]
        public decimal Amount { get; set; }

        [DataMember(Order = 3)]
        public string ReferralUrl { get; set; }
    }
}
