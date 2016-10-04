	

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
	/// An component type implementation of the 'AdvertiserUsers' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AdvertiserUsersService : JXTPortal.AdvertiserUsersServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersService class.
		/// </summary>
		public AdvertiserUsersService() : base()
		{
		}
		#endregion Constructors

        //Check if advertiserUserID belongs to advertiser
        public bool IsAdvertiserUserExists(int advertiserId, int advertiserUserid)
        {
            bool advertiserUserExists = false;

            AdvertiserUsers advertiserUser = GetByAdvertiserUserId(advertiserUserid);

            if (advertiserUser != null && advertiserUser.AdvertiserId == advertiserId)
            {
                advertiserUserExists = true;
            }

            return advertiserUserExists;
        }
		
	}//End Class

} // end namespace
