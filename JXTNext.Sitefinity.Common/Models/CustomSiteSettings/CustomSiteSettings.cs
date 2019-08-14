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

        protected virtual TextField GoogleTagManagerKey
        {
            get
            {
                return this.Container.GetControl<TextField>("googleTagManagerKey", true);
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

        protected virtual TextField DropboxClientAPIKey
        {
            get
            {
                return this.Container.GetControl<TextField>("dropboxClientAPIKey", true);
            }
        }

        #region Seek settings
        protected virtual TextField SeekClientId
        {
            get
            {
                return this.Container.GetControl<TextField>("seekClientId", true);
            }
        }

        protected virtual TextField SeekClientSecret
        {
            get
            {
                return this.Container.GetControl<TextField>("seekClientSecret", true);
            }
        }

        protected virtual TextField SeekClientAdvertiserId
        {
            get
            {
                return this.Container.GetControl<TextField>("SeekClientAdvertiserId", true);
            }
        }

        protected virtual TextField SeekRedirectUri
        {
            get
            {
                return this.Container.GetControl<TextField>("SeekRedirectUri", true);
            }
        }
        #endregion

        #region Indeed settings
        protected virtual TextField IndeedClientAPIToken
        {
            get
            {
                return this.Container.GetControl<TextField>("indeedClientAPIToken", true);
            }
        }

        protected virtual TextField IndeedClientSecret
        {
            get
            {
                return this.Container.GetControl<TextField>("indeedClientSecret", true);
            }
        }
        #endregion

        #region Instagram settings
        protected virtual TextField InstagramClientIdToken
        {
            get
            {
                return this.Container.GetControl<TextField>("instagramClientIdToken", true);
            }
        }

        protected virtual TextField InstagramClientSecret
        {
            get
            {
                return this.Container.GetControl<TextField>("instagramClientSecret", true);
            }
        }

        protected virtual TextField InstagramAccessToken
        {
            get
            {
                return this.Container.GetControl<TextField>("instagramAccessToken", true);
            }
        }

        protected virtual TextField InstagramExpiration
        {
            get
            {
                return this.Container.GetControl<TextField>("instagramExpiration", true);
            }
        }

        protected virtual TextField InstagramMaxItems
        {
            get
            {
                return this.Container.GetControl<TextField>("instagramMaxItems", true);
            }
        }



        #endregion

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