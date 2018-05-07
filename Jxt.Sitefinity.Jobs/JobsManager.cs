using Jxt.Sitefinity.Jobs.Configuration;
using Jxt.Sitefinity.Jobs.Data;
using Jxt.Sitefinity.Jobs.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.RelatedData;

namespace Jxt.Sitefinity.Jobs
{
    public class JobsManager : ManagerBase<WebJobsDataProvider>, IManager, IDisposable, IRelatedDataSource
    {
        public JobsManager()
            :base()
        {

        }

        public JobsManager(string providerName)
            :base(providerName)
        {

        }

        public override string ModuleName
        {
            get { return JobsModule.ModuleName; }
        }

        protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
        {
            get { return Config.Get<JobsConfig>().Providers; }
        }

        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get { return () => Config.Get<JobsConfig>().DefaultProvider; }
        }

        public IQueryable<T> GetRelatedItems<T>(string itemType, string itemProviderName, Guid itemId, string fieldName, ContentLifecycleStatus? status, string filterExpression, string orderExpression, int? skip, int? take, ref int? totalCount, RelationDirection relationDirection = RelationDirection.Child) where T : IDataItem
        {
            return null;
        }

        public IQueryable GetRelatedItems(string itemType, string itemProviderName, Guid itemId, string fieldName, Type relatedItemsType, ContentLifecycleStatus? status, string filterExpression, string orderExpression, int? skip, int? take, ref int? totalCount, RelationDirection relationDirection = RelationDirection.Child)
        {
            return null;
        }

        public Dictionary<Guid, List<IDataItem>> GetRelatedItems(string itemType, string itemProviderName, List<Guid> parentItemIds, string fieldName, Type relatedItemsType, ContentLifecycleStatus? status)
        {
            return null;
        }

        public static JobsManager GetManager()
        {
            return new JobsManager();
        }

        public static JobsManager GetManager(string providerName)
        {
            return new JobsManager(providerName);
        }

        public IQueryable<JobListing> GetJobListings()
        {
            return this.Provider.GetJobListings();
        }

        public JobListing GetJobListing(Guid id)
        {
            return this.Provider.GetJobListing(id);
        }
    }
}
