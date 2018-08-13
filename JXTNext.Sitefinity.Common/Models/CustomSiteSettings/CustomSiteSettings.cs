using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;

namespace JXTNext.Sitefinity.Common.Models.CustomSiteSettings
{
    public class CustomSiteSettings : SimpleView
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
                    return CustomSiteSettings.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        #endregion

        #region Control References
        protected virtual TextField GoogleAPIKey
        {
            get
            {
                return this.Container.GetControl<TextField>("googleAPIKey", true);
            }
        }

        protected virtual TextField GoogleClientId
        {
            get
            {
                return this.Container.GetControl<TextField>("googleClientId", true);
            }
        }

        protected virtual TextField GoogleClientSecret
        {
            get
            {
                return this.Container.GetControl<TextField>("googleClientSecret", true);
            }
        }

        protected virtual TextField GoogleClientAPIKey
        {
            get
            {
                return this.Container.GetControl<TextField>("googleClientAPIKey", true);
            }
        }

        protected virtual TextField DropboxAppId
        {
            get
            {
                return this.Container.GetControl<TextField>("dropboxAppId", true);
            }
        }

        protected virtual TextField DropboxAppSecret
        {
            get
            {
                return this.Container.GetControl<TextField>("dropboxAppSecret", true);
            }
        }

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
        public static readonly string layoutTemplatePath = "~/Views/CustomSiteSettings/CustomSiteSettings.ascx";
        #endregion
    }
}