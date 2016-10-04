	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Linq;
using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Configuration;
using System.Collections.Generic;
using JXTPortal.Common;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'SiteCountries' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SiteCountriesService : JXTPortal.SiteCountriesServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SiteCountriesService class.
		/// </summary>
		public SiteCountriesService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"

        public List<SiteCountries> GetTranslatedCountries()
        {
            return GetTranslatedCountries(SessionData.Language.LanguageId);
        }

        public List<SiteCountries> GetTranslatedCountries(int languageid)
        {
            string xmlprefix = "{0}{2}_{3}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                        languageid,
                                        PortalConstants.XMLTranslationFiles.XML_SITECOUNTRY_FILENAME,
                                        SessionData.Site.SiteId);
            return XMLLanguageService.Translate(GetBySiteId(SessionData.Site.SiteId).ToList(), "CountryId", "SiteCountryName", url);
        }

        #endregion

	}//End Class

} // end namespace
