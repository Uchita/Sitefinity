	

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
	/// An component type implementation of the 'Educations' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class EducationsService : JXTPortal.EducationsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the EducationsService class.
		/// </summary>
		public EducationsService() : base()
		{
		}
		#endregion Constructors

        #region Properties

        #endregion


        #region "Methods"

        public List<Educations> GetTranslatedEducations(int languageID)
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_EDUCATIONS_FILENAME);

            //return XMLLanguageService.Translate(GetBySiteId(SessionData.Site.SiteId).ToList(), "EducationID", "EducationName", url);

            TList<Educations> education = GetAll();
            education.Filter = "GlobalTemplate = 1";

            return XMLLanguageService.Translate(education.ToList(), "EducationId", "EducationName", url);
        }

        public List<Educations> GetTranslatedSiteEducations()
        {
            string xmlprefix = "{0}{2}_{1}.xml";
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        SessionData.Language.LanguageId,
                                        PortalConstants.XMLTranslationFiles.XML_EDUCATIONS_FILENAME);

            return XMLLanguageService.Translate(GetBySiteId(SessionData.Site.SiteId).ToList(), "EducationParentId", "EducationName", url);
        }


        #endregion

        //public string GetSiteEducationName(int intEducationID)
        //{
        //    EducationsService educationService = new EducationsService();
        //    Educations objEducations = educationService.GetByEducationId(intEducationID);

        //    if (objEducations != null)
        //    {
        //        return objEducations.EducationName;
        //    }

        //    return string.Empty;
        //}

        //public TList<JXTPortal.Entities.Educations> GetAllSiteEducations()
        //{
        //    EducationsService educationService = new EducationsService();

        //    using (TList<JXTPortal.Entities.Educations> objEducations = educationService.GetBySiteId(SessionData.Site.SiteId))
        //    {
        //        if (objEducations != null)
        //        {
        //            return objEducations;
        //        }                
        //    }
            
        //    return null;
        //}

		
	}//End Class

} // end namespace
