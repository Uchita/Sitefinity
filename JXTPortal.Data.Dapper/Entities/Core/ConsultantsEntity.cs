using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JXTPortal.Data.Dapper.Entities.Core
{
    public class ConsultantsEntity : BaseEntity
    {
        public int ConsultantID {get; set;}
        public int SiteID {get; set;}
        public int LanguageID {get; set;}
        public string Title {get; set;}
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string PositionTitle { get; set; }
        public string OfficeLocation { get; set; }
        public string Categories {get; set;}
        public string Location {get; set;}
        public string FriendlyURL { get; set; }
        public string ShortDescription { get; set; }
        public string Testimonial { get; set; }
        public string FullDescription { get; set; }
        public string ConsultantData { get; set; }
        public string LinkedInURL { get; set; }
        public string TwitterURL { get; set; }
        public string FacebookURL { get; set; }
        public string GoogleURL { get; set; }
        public string Link { get; set; }
        public string WechatURL { get; set; }
        public int FeaturedTeamMember {get; set;}
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public string BlogRSS { get; set; }
        public string NewsRSS { get; set; }
        public string JobRSS { get; set; }
        public string TestimonialsRSS { get; set; }
        public int Valid {get; set;}
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public int Sequence {get; set;}
        public string LastName { get; set; }
        public string ConsultantsXML { get; set; }
        public string ConsultantImageUrl { get; set; }
    }
}
