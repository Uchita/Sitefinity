using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.Registration
{
    public enum ActivationMethod
    {
        /// <summary>
        /// User account will be activated immediately after registration.
        /// </summary>
        Immediately,

        /// <summary>
        /// User account will be activated after confirmation
        /// </summary>
        AfterConfirmation
    }
}