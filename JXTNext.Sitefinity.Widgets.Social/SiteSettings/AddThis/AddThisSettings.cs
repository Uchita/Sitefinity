using System.Web.UI;
using Telerik.Sitefinity.Web.UI;

namespace JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis
{
    public class AddThisSettings : SimpleView
    {
        #region Properties

        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                //we use div wrapper tag to make easier common styling
                return HtmlTextWriterTag.Div;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return AddThisSettings.layoutTemplatePath;

                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        #endregion

        #region Control References

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container"></param>
        /// <remarks>
        /// Initialize your controls in this method. Do not override CreateChildControls method.
        /// </remarks>
        protected override void InitializeControls(GenericContainer container)
        {

        }

        #endregion

        #region Private members & constants

        public static readonly string layoutTemplatePath = "~/JXTNext/Social/JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis.Templates.AddThisSettings.ascx";

        #endregion
    }
}
