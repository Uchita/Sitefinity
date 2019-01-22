using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.Registration
{
    public enum SuccessfulRegistrationAction
    {
        /// <summary>
        /// Specified message will be displayed on the same page.
        /// </summary>
        ShowMessage,

        /// <summary>
        /// Specially prepared page will be opened.
        /// </summary>
        RedirectToPage
    }
}