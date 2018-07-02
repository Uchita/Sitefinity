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
            if (dataItem.Fields == null || dataItem.Fields.Image == null 
                || dataItem.Fields.Image.Length == 0 || dataItem.Fields.Image.Length < imageIndex 
                || dataItem.Fields.Image[imageIndex] == null)
                return string.Empty;

            var imageDataItem = dataItem.Fields.Image[imageIndex].DataItem;

            return imageDataItem.Url;
        }

        public static string GetItemThumbnailImageUrl(this ItemViewModel dataItem, string targetField, int imageIndex)
        {
            if (dataItem.Fields == null || dataItem.Fields.Image == null
                  || dataItem.Fields.Image.Length == 0 || dataItem.Fields.Image.Length < imageIndex
                  || dataItem.Fields.Image[imageIndex] == null)
                return string.Empty;

            var imageDataItem = dataItem.Fields.Image[imageIndex].DataItem;

            return imageDataItem.ThumbnailUrl;
        }

    }
}
