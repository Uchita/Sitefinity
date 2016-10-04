	

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
	/// An component type implementation of the 'IntegrationMappings' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class IntegrationMappingsService : JXTPortal.IntegrationMappingsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsService class.
		/// </summary>
		public IntegrationMappingsService() : base()
		{
		}
		#endregion Constructors


        public TList<IntegrationMappings> GetValidBySiteId(int siteId, int? IntegrationMappingTypeID)
        {
            TList<IntegrationMappings> sitemappings = GetBySiteId(siteId);
            if (IntegrationMappingTypeID.HasValue)
                sitemappings.Filter = "GlobalMapping = False AND Sync = 1 AND IntegrationMappingTypeID =" + IntegrationMappingTypeID;
            else
                sitemappings.Filter = "GlobalMapping = False AND Sync = 1";

            return sitemappings;            
        }
        
	}//End Class

} // end namespace
