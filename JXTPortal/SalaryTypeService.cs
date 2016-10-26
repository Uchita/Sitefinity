	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using JXTPortal.Common;


#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'SalaryType' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SalaryTypeService : JXTPortal.SalaryTypeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SalaryTypeService class.
		/// </summary>
		public SalaryTypeService() : base()
		{
		}
		#endregion Constructors

        #region "Constants"
        const string xmlprefix = "{0}{2}_{1}.xml";
        #endregion

        #region "Methods"

        public List<SalaryType> GetTranslatedSalaryTypes(int languageID)
        {
            string url = string.Format(xmlprefix,
                                        ConfigurationManager.AppSettings["XMLFilesPath"],
                                        languageID,
                                        PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);
            return XMLLanguageService.Translate(GetAll().ToList(), "SalaryTypeId", "SalaryTypeName", url);
        }

        public SalaryType GetTranslatedSalaryType(int salaryTypeID, int languageID)
        {
            SalaryType salarytype = GetBySalaryTypeId(salaryTypeID);
            string url = string.Format(xmlprefix,
                                      ConfigurationManager.AppSettings["XMLFilesPath"],
                                      languageID,
                                      PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);
            return XMLLanguageService.Translate(salarytype, "SalaryTypeId", "SalaryTypeName", url);

        }

        public string GetTranslatedStringRole(int salaryTypeID, int languageID)
        {
            SalaryType salarytype = GetBySalaryTypeId(salaryTypeID);

            string url = string.Format(xmlprefix,
                                          ConfigurationManager.AppSettings["XMLFilesPath"],
                                          languageID,
                                          PortalConstants.XMLTranslationFiles.XML_SALARY_FILENAME);
            return XMLLanguageService.TranslateString(salarytype.SalaryTypeId, "SalaryTypeId", "SalaryTypeName", url);
        }

        #endregion
        public List<SalaryType> Get_ValidList()
        {
            TList<SalaryType> salaryType = base.Get_List();

            //we only display Annual and Hourly for salaryType
            return salaryType.Where(s => s.Valid == true).ToList();
        }

	}//End Class

} // end namespace
