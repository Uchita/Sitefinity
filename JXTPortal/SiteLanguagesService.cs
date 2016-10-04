	

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
	/// An component type implementation of the 'SiteLanguages' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SiteLanguagesService : JXTPortal.SiteLanguagesServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SiteLanguagesService class.
		/// </summary>
		public SiteLanguagesService() : base()
		{
		}
		#endregion Constructors

        public bool DeleteSiteLanguage(int siteLanguageID, ref String strMessage)
        {
            try
            {
                using (SiteLanguages siteLanguage = GetBySiteLanguageId(siteLanguageID))
                {
                    
                    // Delete from Database
                    this.Delete(siteLanguage);

                    return true;
                }
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }

            return false;
        }
		
	}//End Class

} // end namespace
