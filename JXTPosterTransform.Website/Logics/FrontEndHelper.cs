using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Reflection;

namespace JXTPosterTransform.Website.Logics
{
    public class FrontEndHelper
    {
        public enum BootstrapAlertType
        {
            Success,
            Info,
            Warning,
            Danger
        }

        public static string MessageDisplayWrapper(string text, BootstrapAlertType alertType)
        {
            string wrapperClass = string.Empty;

            switch (alertType)
            {
                case BootstrapAlertType.Success:
                    wrapperClass = "alert-success";
                    break;
                case BootstrapAlertType.Info:
                    wrapperClass = "alert-info";
                    break;
                case BootstrapAlertType.Warning:
                    wrapperClass = "alert-warning";
                    break;
                case BootstrapAlertType.Danger:
                    wrapperClass = "alert-danger";
                    break;
            }

            return string.Format(@"<div class=""alert {0}"">{1}</div>", wrapperClass, text);
        }


        public static string GetEnumDescription(Enum currentEnum)
        {
            string description = String.Empty;
            DescriptionAttribute da;

            FieldInfo fi = currentEnum.GetType().
                        GetField(currentEnum.ToString());
            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();

            return description;
        }

    }
}