	

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
	/// An component type implementation of the 'Sites' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SitesService : JXTPortal.SitesServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SitesService class.
		/// </summary>
		public SitesService() : base()
		{
		}
		#endregion Constructors

        public void InsertDefault(int MasterSiteID, int DefaultLanguageID, Sites entity)
        {
            base.Create(MasterSiteID, DefaultLanguageID, entity.SiteName, entity.SiteUrl, entity.SiteDescription, entity.LastModifiedBy);
            //return base.(entity);
            //base.Copy(entity.SiteId, en
        }
	}//End Class

} // end namespace
