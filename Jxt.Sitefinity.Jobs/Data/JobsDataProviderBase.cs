using Jxt.Sitefinity.Jobs.Data.Model;
using System;
using System.Collections;
using System.Linq;
using Telerik.Sitefinity.Data;

namespace Jxt.Sitefinity.Jobs.Data
{
    public abstract class JobsDataProviderBase : DataProviderBase
    {
        public override string RootKey
        {
            get
            {
                return "JobsDataProvider";
            }
        }

        public abstract JobListing CreateJobListing();

        public abstract JobListing CreateJobListing(Guid id);

        public abstract IQueryable<JobListing> GetJobListings();

        public abstract JobListing GetJobListing(Guid id);

        public abstract void DeleteJobListing(JobListing listing);

        public override object CreateItem(Type itemType, Guid id)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(JobListing))
                return this.CreateJobListing(id);

            throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
        }

        public override object GetItem(Type itemType, Guid id)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(JobListing))
                return this.GetJobListing(id);

            return base.GetItem(itemType, id);
        }

        public override void DeleteItem(object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            var itemType = item.GetType();

            if (itemType == typeof(JobListing))
            {
                this.DeleteJobListing((JobListing)item);
                return;
            }

            throw GetInvalidItemTypeException(item.GetType(), this.GetKnownTypes());
        }

        public override IEnumerable GetItems(Type itemType, string filterExpression, string orderExpression, int skip, int take, ref int? totalCount)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");

            if (itemType == typeof(JobListing))
                return SetExpressions(this.GetJobListings(), filterExpression, orderExpression, skip, take, ref totalCount);

            throw GetInvalidItemTypeException(itemType, this.GetKnownTypes());
        }

        public override Type[] GetKnownTypes()
        {
            return new[] { typeof(JobListing) };
        }
    }
}