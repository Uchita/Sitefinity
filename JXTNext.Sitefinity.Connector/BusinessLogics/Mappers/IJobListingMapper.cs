﻿using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Mappers
{
    public interface IJobListingMapper
    {
        IntegrationMapperType mapperType { get; }
        object ConvertToAPIEntity(JobDetailsModel jobDetails);
        T ConvertToLocalEntity<T>(dynamic data) where T : class;

        List<T> ConvertSearchResultsToLocal<T>(dynamic data) where T : class;
        List<T> ConvertSearchResultsFiltersToLocal<T>(dynamic data) where T : class;
    }
}
