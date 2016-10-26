	

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
using System.Collections.Generic;
using JXTPortal.Common;
using System.Configuration;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Area' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AreaService : JXTPortal.AreaServiceBase
	{
        #region "Constants"
         const string xmlprefix = "{0}{2}_{1}_{3}.xml";
        #endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the AreaService class.
		/// </summary>
		public AreaService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"

        public List<Area> GetTranslatedAreas(int locationID, int languageID)
        {
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_AREA_FILENAME, locationID);
            return XMLLanguageService.Translate(GetByLocationId(locationID).ToList(), "AreaId", "AreaName", url);
        }

        public Area GetTranslatedArea(int areaID, int languageID)
        {
            Area area = GetByAreaId(areaID);

            string url = string.Format(xmlprefix,
                                      ConfigurationManager.AppSettings["XMLFilesPath"],
                                      languageID,
                                      PortalConstants.XMLTranslationFiles.XML_AREA_FILENAME, area.LocationId);
            return XMLLanguageService.Translate(area, "AreaId", "AreaName", url);
      
        }

        public string GetTranslatedStringArea(int areaID, int languageID)
        {
            Area area = GetByAreaId(areaID);
            string url = string.Format(xmlprefix,
                                          ConfigurationManager.AppSettings["XMLFilesPath"],
                                          languageID,
                                          PortalConstants.XMLTranslationFiles.XML_AREA_FILENAME, area.LocationId);
            return XMLLanguageService.TranslateString(areaID, "AreaId", "AreaName", url);
        }
        #endregion


        #region In Capital Letters "For Console Application"

        /// <summary>
        /// Use this for console applications
        /// </summary>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public List<Area> GetTranslatedAreas(int languageID, List<int> LocationIDs, string xmlFilesPath)
        {
            List<Area> fullAreaList = new List<Area>();

            foreach (int locationID in LocationIDs)
            {
                string url = string.Format(xmlprefix,
                                            xmlFilesPath,
                                            languageID,
                                            PortalConstants.XMLTranslationFiles.XML_AREA_FILENAME, locationID);
                fullAreaList.AddRange(XMLLanguageService.Translate(GetByLocationId(locationID).ToList(), "AreaId", "AreaName", url));
            }

            return fullAreaList;
        }


        #endregion
	}//End Class

} // end namespace
