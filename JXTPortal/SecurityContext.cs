#region Using directives
using System;
using System.ComponentModel;
using System.Security;
using System.Web.Security;
using System.Security.Principal;
using System.Web.Profile;
using JXTPortal.Entities;
using JXTPortal.Data;

using Microsoft.Practices.EnterpriseLibrary.Security;
#endregion Using directives

namespace JXTPortal
{
	/// <summary>
	/// The class that is available in case salarytype based security is required at runtime.  
	/// It will be made availabe through the entities themselves.
	/// </summary>
    public partial class SecurityContext<Entity> : SecurityContextBase<Entity> where Entity : IEntity, new()
    {
        #region Constructors

	///<summary>
        /// Creates a new <see cref="SecurityContext"/> instance.
	///</summary>
        public SecurityContext() : base() { }	
		
	#endregion
        
    }	
}
