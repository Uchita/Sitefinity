	

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
using System.Collections.Generic;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Invoice' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class InvoiceService : JXTPortal.InvoiceServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the InvoiceService class.
		/// </summary>
		public InvoiceService() : base()
		{
		}
		#endregion Constructors

        public void CreateInvoicesForCart(int invoiceOrderID, int advertiserUserID, List<CartItem> cart)
        {
            foreach (CartItem i in cart)
            {
                Invoice thisInvoice = CreateInvoice(advertiserUserID, invoiceOrderID, (int)i.JobItemType, i.JobsCountInclude, i.TotalAmount * i.Number, i.ProductDescription, i.Number);
                base.Insert(thisInvoice);
            }
        }

	}//End Class

} // end namespace
