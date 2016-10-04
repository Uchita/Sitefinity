#region Using directives

using System;

#endregion

namespace JXTPortal.Entities
{	
	///<summary>
	/// An object representation of the 'AdminUsers' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class AdminUsers : AdminUsersBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="AdminUsers"/> instance.
		///</summary>
		public AdminUsers():base(){}	
		
		#endregion

        public bool isAdminUser { get; set; }
	}
}
