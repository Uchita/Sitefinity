using JXTNext.Sitefinity.Connector.Options.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Mvc.Proxy;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Logics
{
    public class JobFiltersLogics
    {
        // Getting the widget configuration settings
        public static dynamic GetWidgetConfigSettings(string pageTitle, string widgetControllerName)
        {
            dynamic widgetSettings = null;

            if (!pageTitle.IsNullOrEmpty() && !widgetControllerName.IsNullOrEmpty())
            {
                PageManager manager = PageManager.GetManager();
                var page = manager.GetPageNodes().
                    Where(p => p.Title.ToUpper() == pageTitle.ToUpper() && p.RootNodeId == SiteInitializer.CurrentFrontendRootNodeId).
                    FirstOrDefault();

                var pageData = page.GetPageData();
                var pageDraft = manager.EditPage(pageData.Id);
                var pageDraftControls = pageDraft.Controls
                    .Where(c => c.ObjectType == typeof(MvcControllerProxy).FullName)
                    .ToList();

                foreach (var draftControl in pageDraftControls)
                {
                    var control = manager.LoadControl(draftControl) as MvcControllerProxy;
                    if (control.ControllerName.ToUpper() == widgetControllerName.ToUpper())
                    {
                        widgetSettings = control.Settings;
                        break;
                    }
                }
            }

            return widgetSettings;
        }

        public static void ProcessFiltersCount(List<JobFilterRoot> selectedFilters, List<JobFilterRoot> filtersVMList)
        {
            if (selectedFilters != null && selectedFilters.Count > 0)
            {
                foreach (var rootItem in selectedFilters)
                {
                    if (rootItem != null)
                    {
                        if (filtersVMList != null && filtersVMList.Count > 0)
                        {
                            foreach (var filterVMRootItem in filtersVMList)
                            {
                                if (filterVMRootItem.Name == rootItem.Name)
                                {
                                    if (filterVMRootItem.Filters != null && filterVMRootItem.Filters.Count > 0)
                                    {
                                        foreach (var filterItem in filterVMRootItem.Filters)
                                        {
                                            MergeFiltersCount(filterItem, rootItem.Filters);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void MergeFiltersCount(JobFilter filterItem, List<JobFilter> values)
        {
            if (filterItem != null)
            {
                var itemFound = values.Where(x => x.ID.ToUpper() == filterItem.ID.ToUpper()).FirstOrDefault();
                if (itemFound != null)
                {
                    filterItem.Count = itemFound.Count;
                    if (filterItem.Filters != null && filterItem.Filters.Count > 0)
                    {
                        foreach (var innerVMItem in filterItem.Filters)
                        {
                            if (itemFound.Filters != null && itemFound.Filters.Count > 0)
                                MergeFiltersCount(innerVMItem, itemFound.Filters);
                        }
                    }
                }
                else // Need put zero for all these
                {
                    UpdateZeroForFilters(filterItem);
                }
            }
        }

        public static void UpdateZeroForFilters(JobFilter filterItem)
        {
            if (filterItem != null)
            {
                filterItem.Count = 0;
                if (filterItem.Filters != null && filterItem.Filters.Count > 0)
                {
                    foreach (var vmItem in filterItem.Filters)
                    {
                        UpdateZeroForFilters(vmItem);
                    }
                }
            }
        }
    }
}
