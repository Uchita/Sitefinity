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
    public interface IAdvertiserJobTemplateLogoRepository : IBaseEntityOperation<AdvertiserJobTemplateLogoEntity>
    {
    }

    public class AdvertiserJobTemplateLogoRepository : BaseEntityOperation<AdvertiserJobTemplateLogoEntity>, IAdvertiserJobTemplateLogoRepository
    {
        public AdvertiserJobTemplateLogoRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "AdvertiserJobTemplateLogo";
            ColumnNames = new List<string> { "AdvertiserID", "JobLogoName", "JobTemplateLogo", "JobTemplateLogoUrl" };
            IdColumnName = "AdvertiserJobTemplateLogoID";
        }
    }
}
