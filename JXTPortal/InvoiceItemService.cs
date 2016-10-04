	

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
	/// An component type implementation of the 'InvoiceItem' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class InvoiceItemService : JXTPortal.InvoiceItemServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the InvoiceItemService class.
		/// </summary>
		public InvoiceItemService() : base()
		{
		}
		#endregion Constructors


        public void CreateInvoiceItemsForInvoiceOrder(int invoiceOrderID)
        {
            InvoiceService _invoiceService = new InvoiceService();

            TList<Invoice> invoices = _invoiceService.GetByOrderId(invoiceOrderID);

            foreach (Invoice i in invoices)
            {
                for (int k = 0; k < i.TotalNumberOfJobs; k++)
                {
                    InvoiceItem newItem = new InvoiceItem
                    {
                        InvoiceId = i.InvoiceId,
                        JobId = null,
                        JobArchiveId = null,
                        CreatedDate = DateTime.Now,
                        AdvertiserUserId = i.AdvertiserUserId
                    };
                    base.Insert(newItem);
                }

            }

        }

    }//End Class

} // end namespace
