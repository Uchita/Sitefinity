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
    public interface ISitesRepository : IBaseEntityOperation<SitesEntity>
    {
    }

    public class SitesRepository : BaseEntityOperation<SitesEntity>, ISitesRepository
    {
         public SitesRepository(IConnectionFactory connectionFactory, string connectionStringName)
            :base(connectionFactory, connectionStringName)
        {
            TableName = "Sites";
            ColumnNames = new List<string> { "SiteName", " SiteUrl", " SiteDescription", " SiteAdminLogo", " LastModified", " LastModifiedBy", " Live", " MobileEnabled", " MobileUrl", " SiteAdminLogoUrl" };
            IdColumnName = "SiteID";
        }
    }
}
