﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.JXTNextProfile
{
    /// <summary>
    /// Defines available action when changes to profile are saved.
    /// </summary>
    public enum SaveAction
    {
        /// <summary>
        /// After save will show message.
        /// </summary>
        ShowMessage,

        /// <summary>
        /// After save will switch to read mode view.
        /// </summary>
        SwitchToReadMode,

        /// <summary>
        /// After save will open specially prepared page.
        /// </summary>
        ShowPage
    }
}
