	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'GlobalSettings' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class GlobalSettingsService : JXTPortal.GlobalSettingsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the GlobalSettingsService class.
		/// </summary>
		public GlobalSettingsService() : base()
		{
		}
		#endregion Constructors

        /// <summary>
        /// Get Global Setting for the Site
        /// </summary>
        /// <param name="siteID">Site ID</param>
        /// <returns></returns>
        public GlobalSettings GetGlobalSettingBySiteID(int siteID)
        {
            GlobalSettings globalSettings = null;
            using (TList<GlobalSettings> globalSettingsList = GetBySiteId(siteID))
            {
                if (globalSettingsList.Count > 0)
                {
                    globalSettings = globalSettingsList[0];
                }
            }

            return globalSettings;
        }
	}//End Class

} // end namespace
