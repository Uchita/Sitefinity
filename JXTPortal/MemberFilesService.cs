	

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
	/// An component type implementation of the 'MemberFiles' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class MemberFilesService : JXTPortal.MemberFilesServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the MemberFilesService class.
		/// </summary>
		public MemberFilesService() : base()
		{
		}
		#endregion Constructors

        public override bool Insert(MemberFiles entity)
        {
            return base.Insert(SetDefaultValues(entity));
        }

        public override bool Update(MemberFiles entity)
        {
            return base.Update(SetDefaultValues(entity));
        }

        private MemberFiles SetDefaultValues(MemberFiles entity)
        {
            entity.LastModifiedDate = DateTime.Now;

            return entity;
        }

        public void MemberAccountClosure(int memberID)
        {
            TList<MemberFiles> filesToBeRemoved = GetByMemberId(memberID);

            if (filesToBeRemoved.Count > 0)
            {
                base.Delete(filesToBeRemoved);
            }
        }
    }//End Class

} // end namespace
