using Telerik.Sitefinity.Security.Sanitizers;

namespace JXTNext.Sitefinity.Custom.Security.Sanitizers
{
    public class CustomHtmlSanitizer : HtmlSanitizer
    {
        public CustomHtmlSanitizer()
        {
            base.AllowedSchemes.Add("tel");
            base.AllowedSchemes.Add("controlslist");
        }
    }
}