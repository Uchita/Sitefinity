	

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
using JXTPortal.Common;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Advertisers' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AdvertisersService : JXTPortal.AdvertisersServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the AdvertisersService class.
		/// </summary>
		public AdvertisersService() : base()
		{
         
		}

 		#endregion Constructors

        public override bool Insert(Advertisers entity)
        {
            entity.RegisterDate = DateTime.Now.Date;

            return base.Insert(SearchIndex(entity));
        }

        public override bool Update(Advertisers entity)
        {
            return base.Update(SearchIndex(entity));
        }

        private Advertisers SearchIndex(Advertisers entity)
        {
            try
            {
                entity.SearchField = String.Format("{0} {1}",
                                                    Utils.SpecialCharsSearchField(entity.CompanyName),
                                                    Utils.CleanStringSpaces(Utils.StripHTML(Utils.SpecialCharsSearchField(entity.Profile))));
            }
            catch
            {
                entity.SearchField = string.Empty;
            }

            return entity;
        }

	}//End Class

} // end namespace
