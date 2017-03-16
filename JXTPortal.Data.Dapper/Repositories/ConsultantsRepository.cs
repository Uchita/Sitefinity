using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;
using JXTPortal.Data.Dapper.Entities.Core;


namespace JXTPortal.Data.Dapper.Repositories
{
    public interface IConsultantsRepository : IBaseEntityOperation<ConsultantsEntity>
    {
    }

    public class ConsultantsRepository : BaseEntityOperation<ConsultantsEntity>, IConsultantsRepository
    {
         public ConsultantsRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "Consultants";
            ColumnNames = new List<string> { "SiteID", "LanguageID", "Title", "FirstName", "Email", "Phone", "Mobile", "PositionTitle", "OfficeLocation", "Categories", "Location", "FriendlyUrl", "ShortDescription", "Testimonial", "FullDescription", "ConsultantData", "LinkedInUrl", "TwitterUrl", "FacebookUrl", "GoogleUrl", "Link", "WechatUrl", "FeaturedTeamMember", "ImageUrl", "VideoUrl", "BlogRSS", "NewsRSS", "JobRSS", "TestimonialsRSS", "Valid", "MetaTitle", "MetaDescription", "MetaKeywords", "LastModifiedBy", "LastModified", "Sequence", "LastName", "ConsultantsXML", "ConsultantImageUrl" };
            IdColumnName = "ConsultantID";
        }
    }
}
