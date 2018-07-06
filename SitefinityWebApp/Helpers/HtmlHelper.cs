using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Frontend.Mvc.Models;

namespace JXTNext.Sitefinity.Common.Helpers
{
    public static class HtmlHelper
    {
        public static string GetItemImageUrl(this ItemViewModel dataItem, string targetField, int imageIndex)
        {
            if (dataItem.Fields != null)
            {
                DynamicDataItemFieldAccessor accessor = dataItem.Fields;
                ItemViewModel[] targetFieldValue = accessor.GetMemberValue(targetField) as ItemViewModel[];

                if (targetFieldValue == null
                        || targetFieldValue.Length == 0 || targetFieldValue.Length < imageIndex
                        || targetFieldValue[imageIndex] == null)
                    return string.Empty;

                Telerik.Sitefinity.Libraries.Model.Image imageDataItem = targetFieldValue[imageIndex].DataItem as Telerik.Sitefinity.Libraries.Model.Image;
                return imageDataItem.Url;
            }
            return string.Empty;
        }

        public static string GetItemThumbnailImageUrl(this ItemViewModel dataItem, string targetField, int imageIndex)
        {

            if (dataItem.Fields != null)
            {
                DynamicDataItemFieldAccessor accessor = dataItem.Fields;
                ItemViewModel[] targetFieldValue = accessor.GetMemberValue(targetField) as ItemViewModel[];

                if (targetFieldValue == null
                        || targetFieldValue.Length == 0 || targetFieldValue.Length < imageIndex
                        || targetFieldValue[imageIndex] == null)
                    return string.Empty;

                Telerik.Sitefinity.Libraries.Model.Image imageDataItem = targetFieldValue[imageIndex].DataItem as Telerik.Sitefinity.Libraries.Model.Image;
                return imageDataItem.ThumbnailUrl;
            }
            return string.Empty;
        }

    }
}
