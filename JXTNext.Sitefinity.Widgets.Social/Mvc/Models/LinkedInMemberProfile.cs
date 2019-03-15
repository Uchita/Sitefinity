using System.Collections.Generic;

/// <summary>
/// This class is same as unreleased JXTNext.SocialMedia.Models.LinkedIn.JobApplication
/// </summary>
namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models
{
    public class LinkedInMemberProfile
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string headline { get; set; }
        public string summary { get; set; }
        public Location location { get; set; }
        public string profileImageUrl { get; set; }
        public string publicProfileUrl { get; set; }
        public string specialities { get; set; }
        public List<Position> positions { get; set; }
        public List<object> skills { get; set; }
        public List<Education> educations { get; set; }
        public List<Patent> patents { get; set; }
        public List<Language> languages { get; set; }
        public List<Publication> publications { get; set; }
        public List<Certification> certifications { get; set; }
        public List<Honor> honors { get; set; }
        public List<RecommendationsReceived> recommendationsReceived { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
    }

    public class Location
    {
        public string locationName { get; set; }
        public string country { get; set; }
    }

    public class StartDate
    {
        public int month { get; set; }
        public int year { get; set; }
    }

    public class EndDate
    {
        public int month { get; set; }
        public int year { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string type { get; set; }
        public string ticker { get; set; }
    }

    public class Position
    {
        public string title { get; set; }
        public string summary { get; set; }
        public StartDate startDate { get; set; }
        public EndDate endDate { get; set; }
        public bool isCurrent { get; set; }
        public string companyName { get; set; }
        public Company company { get; set; }
    }

    public class Education
    {
        public string schoolName { get; set; }
        public string fieldOfStudy { get; set; }
        public StartDate startDate { get; set; }
        public EndDate endDate { get; set; }
        public string degree { get; set; }
        public string activities { get; set; }
        public string notes { get; set; }
    }

    public class Date
    {
        public int month { get; set; }
        public int year { get; set; }
        public int day { get; set; }
    }

    public class Patent
    {
        public string title { get; set; }
        public string summary { get; set; }
        public string number { get; set; }
        public int status { get; set; }
        public string statusName { get; set; }
        public Date date { get; set; }
        public object url { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string proficiency { get; set; }
    }

    public class Publication
    {
        public string title { get; set; }
        public string publisher { get; set; }
        public Date date { get; set; }
        public object url { get; set; }
        public string summary { get; set; }
    }

    public class Certification
    {
        public string name { get; set; }
        public string authority { get; set; }
        public string number { get; set; }
        public StartDate startDate { get; set; }
        public EndDate endDate { get; set; }
    }

    public class IssueDate
    {
        public int month { get; set; }
        public int year { get; set; }
    }

    public class Honor
    {
        public string title { get; set; }
        public string description { get; set; }
        public string issuer { get; set; }
        public IssueDate issueDate { get; set; }
    }

    public class Recommender
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class RecommendationsReceived
    {
        public string recommendationText { get; set; }
        public Recommender recommender { get; set; }
    }
}
