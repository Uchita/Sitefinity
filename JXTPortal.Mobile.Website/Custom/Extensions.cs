using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Web.Mvc.Html;
using System.Text;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Serializes an object to Javascript Object Notation.
        /// </summary>
        /// <param name="item">The item to serialize.</param>
        /// <returns>
        /// The item serialized as Json.
        /// </returns>
        public static string ToJson(this object item)
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(item);
        }

    }

    public static class CommonExtensions
    {
        public static IEnumerable<string> ToErrorString(this ModelStateDictionary model)
        {
            return model.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

        public static string ToSingleLine(this IEnumerable<string> stringcollection, string separator)
        {
            StringBuilder sb = new StringBuilder();

            if (stringcollection != null)
            {
                foreach (var item in stringcollection)
                {
                    sb.AppendFormat("{0}{1}", item, separator);
                }
            }

            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }
    }
}