using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace JXTPortal.MobileWebsite.Helpers
{
    public static class HtmlHelperExtensions
    {
        #region For View pages

        public static string FieldIdFor<T, TResult>(this HtmlHelper<T> html, Expression<Func<T, TResult>> expression)
        {
            var id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression));
            // because "[" and "]" aren't replaced with "_" in GetFullHtmlFieldId
            return id.Replace('[', '_').Replace(']', '_');
        }

        public static string FieldNameFor<T, TResult>(this HtmlHelper<T> html, Expression<Func<T, TResult>> expression)
        {
            return html.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
        }

        public static MvcHtmlString DropDownList(this HtmlHelper helper,
            string name, Dictionary<string, string> dictionary, string optionLabel, object objAttr)
        {
            var selectListItems = new SelectList(dictionary, "Key", "Value");
            return helper.DropDownList(name, selectListItems, optionLabel, objAttr);
        }

        public static MvcHtmlString DropDownList(this HtmlHelper helper,
            string name, Dictionary<string, string> dictionary, string optionLabel)
        {
            var selectListItems = new SelectList(dictionary, "Key", "Value");
            return helper.DropDownList(name, selectListItems, optionLabel);
        }

        public static MvcHtmlString DropDownList(this HtmlHelper helper,
            string name, Dictionary<string, string> dictionary)
        {
            var selectListItems = new SelectList(dictionary, "Key", "Value");
            return helper.DropDownList(name, selectListItems);
        }

        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, Dictionary<int, string> dictionary, IDictionary<string, object> htmlAttributes = null)
        {
            var selectListItems = new SelectList(dictionary, "Key", "Value");
            if (htmlAttributes != null)
                return helper.DropDownListFor(expression, selectListItems, htmlAttributes);
            return helper.DropDownListFor(expression, selectListItems);
        }

        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, Dictionary<string, string> dictionary, IDictionary<string, object> htmlAttributes = null)
        {
            var selectListItems = new SelectList(dictionary, "Key", "Value");
            if (htmlAttributes != null)
                return helper.DropDownListFor(expression, selectListItems, htmlAttributes);
            return helper.DropDownListFor(expression, selectListItems);
        }

        #endregion
    }
}