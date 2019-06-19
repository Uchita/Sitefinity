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
                var pageDraft = manager.GetPageDraft(pageData.Id);
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
    }
}
