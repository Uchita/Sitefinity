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
    public interface IJobTemplatesRepository : IBaseEntityOperation<JobTemplatesEntity>
    {
    }

    public class JobTemplatesRepository : BaseEntityOperation<JobTemplatesEntity>, IJobTemplatesRepository
    {
        public JobTemplatesRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "JobTemplates";
            ColumnNames = new List<string> { "SiteID", "JobTemplateDescription", "JobTemplateHTML", "GlobalTemplate", "LastModifiedBy", "LastModified", "JobTemplateLogo", "AdvertiserID", "JobTemplateLogoUrl" };
            IdColumnName = "JobTemplateID";
        }
    }
}
