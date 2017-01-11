	

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
using JXTPortal.Common;
using System.Configuration;
using System.Collections.Generic;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Countries' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CountriesService : JXTPortal.CountriesServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CountriesService class.
		/// </summary>
		public CountriesService() : base()
		{
		}
		#endregion Constructors


        #region "Methods"
        
        [Obsolete("GetTranslatedCountries should only be used on Member related purpose")]
        public List<Countries> GetTranslatedCountries(int languageID)
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_COUNTRY_FILENAME);
            return XMLLanguageService.Translate(GetAll().ToList(), "CountryId", "CountryName", url);
        }

        [Obsolete("GetTranslatedCountry should only be used on Member related purpose")]
        public Entities.Countries GetTranslatedCountry(int countryid, int languageID)
        {
            Entities.Countries country = GetByCountryId(countryid);

            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_COUNTRY_FILENAME);
            return XMLLanguageService.Translate(country, "CountryId", "CountryName", url);
        }

        #endregion

        #region In Capital Letters "For Console Application"

        /// <summary>
        /// Use this for console applications
        /// </summary>
        /// <param name="languageID"></param>
        /// <returns></returns>

        [Obsolete("GetTranslatedCountries should only be used on Member related purpose")]
        public List<Countries> GetTranslatedCountries(int languageID, string xmlFilesPath)
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        xmlFilesPath,
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_COUNTRY_FILENAME);
            return XMLLanguageService.Translate(GetAll().ToList(), "CountryId", "CountryName", url);
        }


        #endregion

    }//End Class

} // end namespace
