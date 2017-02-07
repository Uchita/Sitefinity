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
        List<AdvertisersEntity> SelectAdvertiserIDs(List<int> advertiserIds);
        List<AdvertisersEntity> SelectBySiteId(int siteId);
    }

    public class AdvertisersRepository : BaseEntityOperation<AdvertisersEntity>, IAdvertisersRepository
    {
        public AdvertisersRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "Advertisers";
            ColumnNames = new List<string> { "SiteID", "AdvertiserAccountTypeID", "AdvertiserBusinessTypeID", "AdvertiserAccountStatusID", "CompanyName", "BusinessNumber", "StreetAddress1", "StreetAddress2", "LastModified", "LastModifiedBy", "PostalAddress1", "PostalAddress2", "WebAddress", "NoOfEmployees", "FirstApprovedDate", "Profile", "CharityNumber", "SearchField", "FreeTrialStartDate", "FreeTrialEndDate", "AccountsPayableEmail", "RequireLogonForExternalApplication", "AdvertiserLogo", "LinkedInLogo", "LinkedInCompanyId", "LinkedInEmail", "RegisterDate", "ExternalAdvertiserID", "VideoLink", "Industry", "NominatedCompanyRole", "NominatedCompanyFirstName", "NominatedCompanyLastName", "NominatedCompanyEmailAddress", "NominatedCompanyPhone", "PreferredContactMethod", "AdvertiserLogoUrl" };
            IdColumnName = "AdvertiserID";
        }

        #region IBaseEntityOperation<AdvertisersRepository> Members

        public List<AdvertisersEntity> SelectAdvertiserIDs(List<int> advertiserIds)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "AdvertiserID IN @Ids";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<AdvertisersEntity>(query, new { Ids = advertiserIds}).ToList();
                return entity as List<AdvertisersEntity>;
            }
        }

        public List<AdvertisersEntity> SelectBySiteId(int siteId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "SiteID = @Id";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<AdvertisersEntity>(query, new { Id = siteId }).ToList();
                return entity as List<AdvertisersEntity>;
            }
        }

        #endregion
    }
}
