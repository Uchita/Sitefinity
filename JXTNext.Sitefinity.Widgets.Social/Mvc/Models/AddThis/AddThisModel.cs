using JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Services;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models.AddThis
{
    public class AddThisModel : IAddThisModel
    {
        /// <inheritdoc />
        public string CssClass { get; set; }

        public string PublisherId { get; set; }

        /// <inheritdoc />
        public ICollection<AddThisButtonModel> ServiceButtons { get; } = new List<AddThisButtonModel>();

        public AddThisModel()
        {
            InitializeServiceButtons();
        }

        /// <inheritdoc />
        public virtual AddThisViewModel GetViewModel()
        {
            var settings = this.AddThisSettings;

            var buttons = ServiceButtons.Where(b => b.Enabled)
                                        .OrderBy(b => b.Position)
                                        .ToList();

            var viewModel = new AddThisViewModel()
            {
                PublisherId = string.IsNullOrWhiteSpace(this.PublisherId) ? settings.PublisherId : this.PublisherId,
                CssClass = string.IsNullOrWhiteSpace(this.CssClass) ? settings.CssClass : this.CssClass,
                ServiceButtons = buttons
            };

            return viewModel;
        }

        /// <inheritdoc />
        public bool IsEmpty()
        {
            return ServiceButtons.Where(b => b.Enabled).Count() == 0;
        }

        /// <inheritdoc />
        public virtual void InitializeServiceButtons()
        {
            var settings = this.AddThisSettings;

            ServiceButtons.Add(new AddThisButtonModel
            {
                Enabled = settings.FacebookEnabled,
                Service = "facebook",
                Name = "Facebook",
                Icon = settings.FacebookIcon,
                Image = settings.FacebookImage,
                Position = settings.FacebookPosition
            });

            ServiceButtons.Add(new AddThisButtonModel
            {
                Enabled = settings.TwitterEnabled,
                Service = "twitter",
                Name = "Twitter",
                Icon = settings.TwitterIcon,
                Image = settings.TwitterImage,
                Position = settings.TwitterPosition
            });

            ServiceButtons.Add(new AddThisButtonModel
            {
                Enabled = settings.LinkedInEnabled,
                Service = "linkedin",
                Name = "LinkedIn",
                Icon = settings.LinkedInIcon,
                Image = settings.LinkedInImage,
                Position = settings.LinkedInPosition
            });

            ServiceButtons.Add(new AddThisButtonModel
            {
                Enabled = settings.WeChatEnabled,
                Service = "wechat",
                Name = "WeChat",
                Icon = settings.WeChatIcon,
                Image = settings.WeChatImage,
                Position = settings.WeChatPosition
            });
        }

        /// <summary>
        /// Gets the AddThis settings.
        /// </summary>
        /// <value>The AddThis settings.</value>
        protected internal virtual IAddThisSettings AddThisSettings
        {
            get
            {
                return SystemManager.CurrentContext.GetSetting<AddThisSettingsContract, IAddThisSettings>();
            }
        }
    }
}
