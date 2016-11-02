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

    public class ConsultantsRepository : IConsultantsRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        private readonly string _connectionStringName;

        public ConsultantsRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        #region IBaseEntityOperation<ConsultantsRepository> Members

        public int Insert(ConsultantsEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                var sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.Consultants (SiteID, LanguageID, Title, FirstName, Email, Phone, Mobile, PositionTitle, OfficeLocation, Categories, Location, FriendlyURL, ShortDescription, Testimonial, FullDescription, ConsultantData, LinkedInURL, TwitterURL, FacebookURL, GoogleURL, Link, WechatURL, FeaturedTeamMember, ImageURL, VideoURL, BlogRSS, NewsRSS, JobRSS, TestimonialsRSS, Valid, MetaTitle, MetaDescription, MetaKeywords, LastModifiedBy, LastModified, Sequence, LastName, ConsultantsXML, ConsultantImageURL)");
                sbQuery.Append(" VALUES(@SiteID, @LanguageID, @Title, @FirstName, @Email, @Phone, @Mobile, @PositionTitle, @OfficeLocation, @Categories, @Location, @FriendlyURL, @ShortDescription, @Testimonial, @FullDescription, @ConsultantData, @LinkedInURL, @TwitterURL, @FacebookURL, @GoogleURL, @Link, @WechatURL, @FeaturedTeamMember, @ImageURL, @VideoURL, @BlogRSS, @NewsRSS, @JobRSS, @TestimonialsRSS, @Valid, @MetaTitle, @MetaDescription, @MetaKeywords, @LastModifiedBy, @LastModified, @Sequence, @LastName, @ConsultantsXML, @ConsultantImageURL)");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Update(ConsultantsEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.Consultants SET SiteID = @SiteID, LanguageID = @LanguageID, Title = @Title, FirstName = @FirstName, Email = @Email, Phone = @Phone, Mobile = @Mobile, PositionTitle = @PositionTitle, OfficeLocation = @OfficeLocation, Categories = @Categories, Location = @Location, FriendlyURL = @FriendlyURL, ShortDescription = @ShortDescription, Testimonial = @Testimonial, FullDescription = @FullDescription, ConsultantData = @ConsultantData, LinkedInURL = @LinkedInURL, TwitterURL = @TwitterURL, FacebookURL = @FacebookURL, GoogleURL = @GoogleURL, Link = @Link, WechatURL = @WechatURL, FeaturedTeamMember = @FeaturedTeamMember, ImageURL = @ImageURL, VideoURL = @VideoURL, BlogRSS = @BlogRSS, NewsRSS = @NewsRSS, JobRSS = @JobRSS, TestimonialsRSS = @TestimonialsRSS, Valid = @Valid, MetaTitle = @MetaTitle, MetaDescription = @MetaDescription, MetaKeywords = @MetaKeywords, LastModifiedBy = @LastModifiedBy, LastModified = @LastModified, Sequence = @Sequence, LastName = @LastName, ConsultantsXML = @ConsultantsXML, ConsultantImageURL = @ConsultantImageURL WHERE ConsultantID = @ConsultantID";
                dbConnection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.Consultants WHERE ConsultantID = @ConsultantID";
                dbConnection.Execute(query, new { ConsultantID = id });
            }
        }

        public ConsultantsEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT ConsultantID, SiteID, LanguageID, Title, FirstName, Email, Phone, Mobile, PositionTitle, OfficeLocation, Categories, Location, FriendlyURL, ShortDescription, Testimonial, FullDescription, ConsultantData, LinkedInURL, TwitterURL, FacebookURL, GoogleURL, Link, WechatURL, FeaturedTeamMember, ImageURL, VideoURL, BlogRSS, NewsRSS, JobRSS, TestimonialsRSS, Valid, MetaTitle, MetaDescription, MetaKeywords, LastModifiedBy, LastModified, Sequence, LastName, ConsultantsXML, ConsultantImageURL FROM dbo.Consultants WHERE ConsultantID = @ConsultantID";
                var entity = dbConnection.Query<ConsultantsEntity>(query, new { ConsultantID = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<ConsultantsEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT ConsultantID, SiteID, LanguageID, Title, FirstName, Email, Phone, Mobile, PositionTitle, OfficeLocation, Categories, Location, FriendlyURL, ShortDescription, Testimonial, FullDescription, ConsultantData, LinkedInURL, TwitterURL, FacebookURL, GoogleURL, Link, WechatURL, FeaturedTeamMember, ImageURL, VideoURL, BlogRSS, NewsRSS, JobRSS, TestimonialsRSS, Valid, MetaTitle, MetaDescription, MetaKeywords, LastModifiedBy, LastModified, Sequence, LastName, ConsultantsXML, ConsultantImageURL FROM dbo.Consultants";
                var entities = dbConnection.Query<ConsultantsEntity>(query).ToList();
                return entities;
            }
        }

        #endregion
    }
}
