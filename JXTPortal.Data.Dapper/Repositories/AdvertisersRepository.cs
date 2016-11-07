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
    public interface IAdvertisersRepository : IBaseEntityOperation<AdvertisersEntity>
    {
    }

    public class AdvertisersRepository : IAdvertisersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        private readonly string _connectionStringName;

        public AdvertisersRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        #region IBaseEntityOperation<AdvertisersRepository> Members

        public int Insert(AdvertisersEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {

                var sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.Advertisers (SiteID, AdvertiserAccountTypeID, AdvertiserBusinessTypeID, AdvertiserAccountStatusID, CompanyName, BusinessNumber, StreetAddress1, StreetAddress2, LastModified, LastModifiedBy, PostalAddress1, PostalAddress2, WebAddress, NoOfEmployees, FirstApprovedDate, Profile, CharityNumber, SearchField, FreeTrialStartDate, FreeTrialEndDate, AccountsPayableEmail, RequireLogonForExternalApplication, AdvertiserLogo, LinkedInLogo, LinkedInCompanyId, LinkedInEmail, RegisterDate, ExternalAdvertiserID, VideoLink, Industry, NominatedCompanyRole, NominatedCompanyFirstName, NominatedCompanyLastName, NominatedCompanyEmailAddress, NominatedCompanyPhone, PreferredContactMethod, AdvertiserLogoUrl)");
                sbQuery.Append(" VALUES(@SiteID, @AdvertiserAccountTypeID, @AdvertiserBusinessTypeID, @AdvertiserAccountStatusID, @CompanyName, @BusinessNumber, @StreetAddress1, @StreetAddress2, @LastModified, @LastModifiedBy, @PostalAddress1, @PostalAddress2, @WebAddress, @NoOfEmployees, @FirstApprovedDate, @Profile, @CharityNumber, @SearchField, @FreeTrialStartDate, @FreeTrialEndDate, @AccountsPayableEmail, @RequireLogonForExternalApplication, @AdvertiserLogo, @LinkedInLogo, @LinkedInCompanyId, @LinkedInEmail, @RegisterDate, @ExternalAdvertiserID, @VideoLink, @Industry, @NominatedCompanyRole, @NominatedCompanyFirstName, @NominatedCompanyLastName, @NominatedCompanyEmailAddress, @NominatedCompanyPhone, @PreferredContactMethod, @AdvertiserLogoUrl)");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Update(AdvertisersEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.Advertisers SET SiteID = @SiteID, AdvertiserAccountTypeID = @AdvertiserAccountTypeID, AdvertiserBusinessTypeID = @AdvertiserBusinessTypeID, AdvertiserAccountStatusID = @AdvertiserAccountStatusID, CompanyName = @CompanyName, BusinessNumber = @BusinessNumber, StreetAddress1 = @StreetAddress1, StreetAddress2 = @StreetAddress2, LastModified= @LastModified, LastModifiedBy = @LastModifiedBy, PostalAddress1 = @PostalAddress1, PostalAddress2 = @PostalAddress2, WebAddress = @WebAddress, NoOfEmployees = @NoOfEmployees, FirstApprovedDate = @FirstApprovedDate, Profile = @Profile, CharityNumber = @CharityNumber, SearchField = @SearchField, FreeTrialStartDate = @FreeTrialStartDate, FreeTrialEndDate = @FreeTrialEndDate, AccountsPayableEmail = @AccountsPayableEmail, RequireLogonForExternalApplication = @RequireLogonForExternalApplication, AdvertiserLogo = @AdvertiserLogo, LinkedInLogo = @LinkedInLogo, LinkedInCompanyId = @LinkedInCompanyId, LinkedInEmail = @LinkedInEmail, RegisterDate = @RegisterDate, ExternalAdvertiserID = @ExternalAdvertiserID, VideoLink = @VideoLink, Industry = @Industry, NominatedCompanyRole = @NominatedCompanyRole, NominatedCompanyFirstName = @NominatedCompanyFirstName, NominatedCompanyLastName = @NominatedCompanyLastName, NominatedCompanyEmailAddress = @NominatedCompanyEmailAddress, NominatedCompanyPhone = @NominatedCompanyPhone, PreferredContactMethod = @PreferredContactMethod, AdvertiserLogoUrl = @AdvertiserLogoUrl WHERE AdvertiserID = @AdvertiserID";
                dbConnection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.Advertisers WHERE AdvertiserID = @AdvertiserID";
                dbConnection.Execute(query, new { AdvertiserID = id });
            }
        }

        public AdvertisersEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT AdvertiserID, SiteID, AdvertiserAccountTypeID, AdvertiserBusinessTypeID, AdvertiserAccountStatusID, CompanyName, BusinessNumber, StreetAddress1, StreetAddress2, LastModified, LastModifiedBy, PostalAddress1, PostalAddress2, WebAddress, NoOfEmployees, FirstApprovedDate, Profile, CharityNumber, SearchField, FreeTrialStartDate, FreeTrialEndDate, AccountsPayableEmail, RequireLogonForExternalApplication, AdvertiserLogo, LinkedInLogo, LinkedInCompanyId, LinkedInEmail, RegisterDate, ExternalAdvertiserID, VideoLink, Industry, NominatedCompanyRole, NominatedCompanyFirstName, NominatedCompanyLastName, NominatedCompanyEmailAddress, NominatedCompanyPhone, PreferredContactMethod, AdvertiserLogoUrl FROM dbo.Advertisers WHERE SiteID = @SiteID";
                var entity = dbConnection.Query<AdvertisersEntity>(query, new { AdvertiserID = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<AdvertisersEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT AdvertiserID, SiteID, AdvertiserAccountTypeID, AdvertiserBusinessTypeID, AdvertiserAccountStatusID, CompanyName, BusinessNumber, StreetAddress1, StreetAddress2, LastModified, LastModifiedBy, PostalAddress1, PostalAddress2, WebAddress, NoOfEmployees, FirstApprovedDate, Profile, CharityNumber, SearchField, FreeTrialStartDate, FreeTrialEndDate, AccountsPayableEmail, RequireLogonForExternalApplication, AdvertiserLogo, LinkedInLogo, LinkedInCompanyId, LinkedInEmail, RegisterDate, ExternalAdvertiserID, VideoLink, Industry, NominatedCompanyRole, NominatedCompanyFirstName, NominatedCompanyLastName, NominatedCompanyEmailAddress, NominatedCompanyPhone, PreferredContactMethod, AdvertiserLogoUrl FROM dbo.Advertisers";
                var entities = dbConnection.Query<AdvertisersEntity>(query).ToList();
                return entities;
            }
        }

        #endregion
    }
}
