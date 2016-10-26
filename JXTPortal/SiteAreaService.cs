	

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
	/// An component type implementation of the 'SiteArea' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SiteAreaService : JXTPortal.SiteAreaServiceBase
	{
        #region "Constants"
        const string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";
        #endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SiteAreaService class.
		/// </summary>
		public SiteAreaService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"

        //ToDo - GetByLocationID is returning Dataset instead of List<SiteArea>

        public List<SiteArea> GetTranslatedAreas(int locationID)
        {
            return GetTranslatedAreas(locationID, SessionData.Language.LanguageId);
        }

        public List<SiteArea> GetTranslatedAreas(int locationID, int languageID)
        {
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_SITEAREA_FILENAME, locationID, SessionData.Site.SiteId);
            return XMLLanguageService.Translate(GetByLocationID(SessionData.Site.SiteId, locationID).ToList(), "AreaId", "SiteAreaName", url);
        }

        public SiteArea GetTranslatedArea(int areaID, int locationID, int siteId)
        {
            return GetTranslatedArea(areaID, locationID, SessionData.Language.LanguageId, siteId);
        }

        public SiteArea GetTranslatedArea(int areaID, int locationID, int languageID, int siteID)
        {
            SiteArea area = null;
            TList<SiteArea> arealist = GetByAreaId(areaID);
            arealist.Filter = string.Format("SiteID = {0}", siteID);
            if (arealist.Count > 0)
            {
                area = arealist[0];

                string url = string.Format(xmlprefix,
                                          ConfigurationManager.AppSettings["XMLFilesPath"],
                                          languageID,
                                          PortalConstants.XMLTranslationFiles.XML_SITEAREA_FILENAME, locationID, SessionData.Site.SiteId);
                return XMLLanguageService.Translate(area, "AreaId", "SiteAreaName", url);
            }
            else
                return null;

        }
        #endregion
	}//End Class

} // end namespace
