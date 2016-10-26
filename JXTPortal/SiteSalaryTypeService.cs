	

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
using System.Configuration;
#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'SiteSalaryType' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SiteSalaryTypeService : JXTPortal.SiteSalaryTypeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeService class.
		/// </summary>
		public SiteSalaryTypeService() : base()
		{
		}
		#endregion Constructors


        public List<SiteSalaryType> Get_ValidList()
        {
            TList<SiteSalaryType> siteSalaryType = base.Get_List();
            //return siteSalaryType.Where(s => s.Valid == true).ToList();

            return siteSalaryType.Where(s => s.Valid == true && s.SalaryTypeId != 3).OrderBy(x => x.Sequence).ToList();
        }

        public List<SiteSalaryType> Get_ValidListBySiteID(int SiteId)
        {
            TList<SiteSalaryType> siteSalaryType = base.GetBySiteId(SiteId);

            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);
            return XMLLanguageService.Translate(siteSalaryType.Where(s => s.Valid == true).OrderBy(x => x.Sequence).ToList(), "SalaryTypeId", "SalaryTypeName", url);


        }

        public SiteSalaryType Get_TranslatedSalaryType(int SiteId, int SalaryTypeID)
        {
            TList<SiteSalaryType> siteSalaryType = base.GetBySiteId(SiteId);
            siteSalaryType.Filter = "SalaryTypeID = " + SalaryTypeID.ToString();

            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);
            return XMLLanguageService.Translate(siteSalaryType[0], "SalaryTypeId", "SalaryTypeName", url);

        }

        #region In Capital Letters "For Console Application"

        /// <summary>
        /// Use this for console applications
        /// </summary>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public List<SiteSalaryType> Get_TranslatedSalaryType(int languageID, int siteID, string xmlFilesPath)
        {
            List<SiteSalaryType> siteSalaryType = new List<SiteSalaryType>();

            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        xmlFilesPath,
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);

            foreach (SiteSalaryType thisSalaryType in  base.GetBySiteId(siteID))
            {
                siteSalaryType.Add(XMLLanguageService.Translate(thisSalaryType, "SalaryTypeId", "SalaryTypeName", url));
            }
            return siteSalaryType;
        }

        #endregion

	}//End Class

} // end namespace
