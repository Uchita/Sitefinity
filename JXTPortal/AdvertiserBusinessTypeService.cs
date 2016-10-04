	

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
	/// An component type implementation of the 'AdvertiserBusinessType' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AdvertiserBusinessTypeService : JXTPortal.AdvertiserBusinessTypeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeService class.
		/// </summary>
		public AdvertiserBusinessTypeService() : base()
		{
		}
		#endregion Constructors

        #region "Methods"

        public List<AdvertiserBusinessType> GetTranslatedAdvertiserBusinessType(int languageID)
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_ADVERTISERBUSINESSTYPE_FILENAME);

            return XMLLanguageService.Translate(GetAll().ToList(), "AdvertiserBusinessTypeId", "AdvertiserBusinessTypeName", url);
        }

        public TList<Entities.AdvertiserBusinessType> GetDefaultBusinessTypes()
        {
            int count;
            return GetPaged("GlobalTemplate = 1 AND SiteID IS NULL ", "Sequence", 0, Int32.MaxValue, out count);
        }

        public TList<Entities.AdvertiserBusinessType> GetSiteBusinessTypes(int SiteID, out bool useDefault)
        {
            int count = 0;
            useDefault = false;

            TList<Entities.AdvertiserBusinessType> businesstypes = GetPaged(string.Format("GlobalTemplate = 0 AND SiteID = {0}", SiteID), "Sequence", 0, Int32.MaxValue, out count);

            if (businesstypes.Count > 0)
            {
                return businesstypes;
            }
            else
            {
                useDefault = true;
                return GetDefaultBusinessTypes();
            }
        }

        public Entities.AdvertiserBusinessType GetSiteBusinessTypeByParentID(int SiteID, int ParentID)
        {
            Entities.AdvertiserBusinessType businesstype = null;
            int count = 0;
            TList<Entities.AdvertiserBusinessType> businesstypes = GetPaged(string.Format("GlobalTemplate = 1 AND SiteID = {0} AND BusinessTypeParentID", SiteID, ParentID), "", 0, Int32.MaxValue, out count);

            if (businesstypes.Count > 0)
            {
                businesstype = businesstypes[0];
            }
            else
            {
                return GetByAdvertiserBusinessTypeId(ParentID);
            }

            return businesstype;
        }

        #endregion

    }//End Class

} // end namespace
