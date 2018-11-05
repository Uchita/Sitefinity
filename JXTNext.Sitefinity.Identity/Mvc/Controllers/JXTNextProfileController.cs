using JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.JXTNextProfile;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.StringResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Telerik.OpenAccess.Exceptions;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Mvc;
using System.Configuration.Provider;
using Telerik.Sitefinity.Web;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Controllers
{
    [Localization(typeof(JXTNextProfileResources))]
    [ControllerToolboxItem(Name = "JXTNextProfile_MVC", Title = "JXTNext Profile", SectionName = "JXTNext.Users", CssClass = JXTNextProfileController.WidgetIconCssClass)]
    public class JXTNextProfileController : Controller
    {
        #region Properties

        /// <summary>
        /// Gets the Profile widget model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual IJXTNextProfileModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = this.InitializeModel();

                return this.model;
            }
        }

        /// <summary>
        /// Gets or sets the name of the edit mode template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string EditModeTemplateName
        {
            get
            {
                return this.editModeTemplateName;
            }

            set
            {
                this.editModeTemplateName = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the read mode template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string ReadModeTemplateName
        {
            get
            {
                return this.readModeTemplateName;
            }

            set
            {
                this.readModeTemplateName = value;
            }
        }

        /// <summary>
        /// Gets or sets the widget display mode.
        /// </summary>
        /// <value>
        /// The widget display mode.
        /// </value>
        public ViewMode Mode { get; set; }

        #endregion

        #region Actions

        /// <summary>
        /// Renders appropriate list view depending on the <see cref="TemplateName" />
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult" />.
        /// </returns>
        public ActionResult Index()
        {
            if (this.Mode == ViewMode.EditOnly && !this.Model.CanEdit())
            {
                return this.Content(Res.Get<JXTNextProfileResources>().EditNotAllowed);
            }

            this.RegisterCustomOutputCacheVariation();

            this.ViewBag.Mode = this.Mode;
            if (this.Mode == ViewMode.EditOnly)
            {
                return this.EditProfile();
            }
            else
            {
                return this.ReadProfile();
            }

        }

        /// <summary>
        /// Renders profile widget in edit mode.
        /// </summary>
        /// <returns></returns>
        public ActionResult EditProfile()
        {
            if (!this.Model.CanEdit())
            {
                return this.Content(Res.Get<JXTNextProfileResources>().EditNotAllowed);
            }

            var fullTemplateName = EditModeTemplatePrefix + this.EditModeTemplateName;
            var viewModel = this.Model.GetProfileEditViewModel();
            if (viewModel == null)
                return null;

            return this.View(fullTemplateName, viewModel);
        }

        /// <summary>
        /// Edit user's email.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditEmail(JXTNextProfileEmailEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isEmailUpdated = this.Model.EditUserEmail(viewModel);

                    if (!isEmailUpdated)
                    {
                        this.ViewBag.ErrorMessage = Res.Get<JXTNextProfileResources>().InvalidPassword;
                    }
                    else
                    {
                        switch (this.Model.SaveChangesAction)
                        {
                            case SaveAction.SwitchToReadMode:
                                return this.ReadProfile();
                            case SaveAction.ShowMessage:
                                viewModel.ShowProfileChangedMsg = true;
                                break;
                            case SaveAction.ShowPage:
                                return this.Redirect(this.Model.GetPageUrl(this.Model.ProfileSavedPageId));
                        }
                    }
                }
                catch (DuplicateKeyException)
                {
                    this.ViewBag.ErrorMessage = Res.Get<JXTNextProfileResources>().EmailExistsMessage;
                }
                catch (ProviderException ex)
                {
                    this.ViewBag.ErrorMessage = ex.Message;
                }
            }

            var fullTemplateName = ConfirmPasswordModeTemplatePrefix + this.EditModeTemplateName;
            return this.View(fullTemplateName, viewModel);
        }

        /// <summary>
        /// Posts the registration form.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>
        /// The <see cref="ActionResult" />.
        /// </returns>
        [HttpPost]
        public ActionResult Index(JXTNextProfileEditViewModel viewModel)
        {
            this.Model.ValidateProfileData(viewModel, this.ModelState);
            this.Model.InitializeUserRelatedData(viewModel, false);

            if (ModelState.IsValid)
            {
                try
                {
                    var isUpdated = this.Model.EditUserProfile(viewModel);
                    if (!isUpdated)
                    {
                        return this.Content(Res.Get<JXTNextProfileResources>().EditNotAllowed);
                    }

                    if (this.Model.IsEmailChanged(viewModel))
                    {
                        return this.View(ConfirmPasswordModeTemplatePrefix + this.EditModeTemplateName,
                            new JXTNextProfileEmailEditViewModel()
                            {
                                UserId = viewModel.User.Id,
                                Email = viewModel.Email
                            });
                    }

                    switch (this.Model.SaveChangesAction)
                    {
                        case SaveAction.SwitchToReadMode:
                            return this.ReadProfile();
                        case SaveAction.ShowMessage:
                            viewModel.ShowProfileChangedMsg = true;
                            break;
                        case SaveAction.ShowPage:
                            return this.Redirect(this.Model.GetPageUrl(this.Model.ProfileSavedPageId));
                    }
                }
                catch (ProviderException ex)
                {
                    this.ViewBag.ErrorMessage = ex.Message;
                }
                catch (DuplicateKeyException)
                {
                    this.ViewBag.ErrorMessage = Res.Get<JXTNextProfileResources>().EmailExistsMessage;
                }
                catch (Exception)
                {
                    this.ViewBag.ErrorMessage = Res.Get<JXTNextProfileResources>().ChangePasswordGeneralErrorMessage;
                }
            }

            this.ViewBag.HasPasswordErrors = !this.ModelState.IsValidField("OldPassword") ||
                                             !this.ModelState.IsValidField("NewPassword") ||
                                             !this.ModelState.IsValidField("RepeatPassword") ||
                                             !string.IsNullOrEmpty(this.ViewBag.ErrorMessage);

            var fullTemplateName = JXTNextProfileController.EditModeTemplatePrefix + this.EditModeTemplateName;
            return this.View(fullTemplateName, viewModel);
        }

        /// <inheritDocs/>
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the model.
        /// </summary>
        /// <returns>
        /// The <see cref="IProfileModel"/>.
        /// </returns>
        private IJXTNextProfileModel InitializeModel()
        {
            return ControllerModelFactory.GetModel<IJXTNextProfileModel>(this.GetType());
        }

        /// <summary>
        /// Retrieves view for read only mode of Profile widget.
        /// </summary>
        /// <returns></returns>
        private ActionResult ReadProfile()
        {
            var viewModel = this.Model.GetProfilePreviewViewModel();
            if (viewModel == null)
                return null;

            var fullTemplateName = ReadModeTemplatePrefix + this.ReadModeTemplateName;
            return this.View(fullTemplateName, viewModel);
        }

        private void RegisterCustomOutputCacheVariation()
        {
            PageRouteHandler.RegisterCustomOutputCacheVariation(new UserProfileMvcOutputCacheVariation());
        }

        #endregion

        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfProfilecn sfMvcIcn";
        internal const string RegisterOCVariationMethodName = "RegisterCustomOutputCacheVariation";

        private string readModeTemplateName = "ProfilePreview";
        private string editModeTemplateName = "ProfileEdit";

        private const string ReadModeTemplatePrefix = "Read.";
        private const string EditModeTemplatePrefix = "Edit.";
        private const string ConfirmPasswordModeTemplatePrefix = "ConfirmPassword.";

        private IJXTNextProfileModel model;

        #endregion
    }
}
