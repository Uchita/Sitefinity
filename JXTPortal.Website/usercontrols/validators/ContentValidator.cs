using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Common.Extensions;

namespace JXTPortal.Website.usercontrols.validators
{
    public class ContentValidator : RegularExpressionValidator
    {
        public ContentValidator()
        {
            
        }

        protected override bool ControlPropertiesValid()
        {
            Control ctrl = FindControl(this.ControlToValidate) as TextBox;
            return ctrl != null;
        }

        protected override bool EvaluateIsValid()
        {
            TextBox textBox = this.FindControl(ControlToValidate) as TextBox;
            if (textBox != null)
            {
                return textBox.Text.IsValidContent(textBox.TextMode == TextBoxMode.MultiLine);
            }

            return false;
        }
    }
}