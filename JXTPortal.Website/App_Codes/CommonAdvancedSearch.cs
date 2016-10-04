using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using JXTPortal.Website.usercontrols.job;

namespace JXTPortal.Website
{
    public class CommonAdvancedSearch
    {

        public static string GetAdvancedSearchWidget(string strContent)
        {
            int widgetID = 0;
            if (!string.IsNullOrWhiteSpace(strContent))
            {
                Regex regex = new Regex("{widget-([0-9]+)}");
                MatchCollection collections = regex.Matches(strContent);
                if (collections.Count > 0)
                {
                    foreach (Match match in collections)
                    {
                        if (int.TryParse(match.Value.Replace("{widget-", string.Empty).Replace("}", string.Empty), out widgetID) && widgetID > 0)
                        {
                            ucAdvancedSearch ucAdvancedSearch = new usercontrols.job.ucAdvancedSearch();
                            ucAdvancedSearch.IsAdvancedSearch = false;
                            ucAdvancedSearch.IsDynamicWidget = "1";
                            ucAdvancedSearch.WidgetID = widgetID;

                            return strContent.Replace(match.Value, ucAdvancedSearch.LoadSearch());
                        }

                        //ltlResult.Text += match.Value + "<br />";
                    }
                }
            }

            return strContent;
        }
    }
}