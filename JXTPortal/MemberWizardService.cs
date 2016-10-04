	

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
	/// An component type implementation of the 'MemberWizard' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class MemberWizardService : JXTPortal.MemberWizardServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the MemberWizardService class.
		/// </summary>
		public MemberWizardService() : base()
		{
		}
		#endregion Constructors


        /// <summary>
        /// Get By site ID else get the Global template 
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public MemberWizard GetMemberWizardBySite(int siteID)
        {
            MemberWizard memberWizard = GetAll().Find(s => s.SiteId.Equals(siteID) && s.GlobalTemplate.Equals(false));
            if (memberWizard == null)
                memberWizard = GetAll().Find(s => s.GlobalTemplate.Equals(true));

            return memberWizard;
        }


	}//End Class

} // end namespace
