#region Using directives

using System;

#endregion

namespace JXTPortal.Entities
{	
	///<summary>
	/// An object representation of the 'Advertisers' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Advertisers : AdvertisersBase
	{
        //TODO: Move to portal enum
        public enum AdvertiserAccountStatus
        {
            ApprovedPending = 1,
            Approved = 2,
            Declined = 3,
            Suspended = 4,
        };

		#region Constructors

		///<summary>
		/// Creates a new <see cref="Advertisers"/> instance.
		///</summary>
		public Advertisers():base(){}	
		
		#endregion
	}
}
