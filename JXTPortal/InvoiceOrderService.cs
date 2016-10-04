	

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
	/// An component type implementation of the 'InvoiceOrder' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class InvoiceOrderService : JXTPortal.InvoiceOrderServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the InvoiceOrderService class.
		/// </summary>
		public InvoiceOrderService() : base()
		{
		}
		#endregion Constructors

        public bool CreateInvoiceOrderForAdvertiserCredits(int advertiserUserID, bool currencyNeedRounding, List<CartItem> cart, decimal gst, int currencyID, bool paymentSucceed, string paymentResponse, out int invoiceOrderID)
        {
            decimal totalCost = CalculateTotalForCart(cart, currencyNeedRounding);
            decimal totalGST = totalCost * gst;

            InvoiceOrder newOrder = CreateInvoiceOrder(
                advertiserUserID,
                DateTime.Now,
                (int)PortalEnums.Payment.PaymentTypes.CreditCard,
                true,
                true, //depends on payment response
                DateTime.Now,
                advertiserUserID,
                totalCost,
                totalGST,
                currencyID,
                null,
                null,
                string.Empty,
                paymentResponse,
                string.Empty,
                string.Empty,
                paymentSucceed ? (int)PortalEnums.Payment.PaymentSuccessStatus.Success : (int)PortalEnums.Payment.PaymentSuccessStatus.Failed,
                "Cardname", "12213123", 12,2015, string.Empty); // Todo save the card details

            bool success = base.Insert(newOrder);

            invoiceOrderID = newOrder.OrderId;

            return success;

        }

        public bool CreateInvoiceOrderForCreditCardPayment(int advertiserUserID, bool currencyNeedRounding, List<CartItem> cart, decimal gst, int currencyID, bool paymentSucceed, string responseCode, string paymentResponse, string cardname, string cardno, int? expirymonth, int? expiryyear, string cvv, string banktransactionid, out int invoiceOrderID)
        {
            decimal totalCost = CalculateTotalForCart(cart, currencyNeedRounding);
            decimal totalGST = totalCost * gst;

            if (currencyNeedRounding)
                totalGST = (int)totalGST;

            // If free job then remove the month and year
            if (totalCost <= 0)
            {
                expirymonth = null;
                expiryyear = null;
            }

            InvoiceOrder newOrder = CreateInvoiceOrder(
                advertiserUserID,
                DateTime.Now,
                (totalCost > 0) ? (int)PortalEnums.Payment.PaymentTypes.CreditCard : (int)PortalEnums.Payment.PaymentTypes.Free,    // Free transaction if 0
                true,
                true, //depends on payment response
                DateTime.Now,
                advertiserUserID,
                totalCost,
                totalGST,
                currencyID,
                null,
                null,
                responseCode,
                paymentResponse,
                banktransactionid,
                string.Empty,
                paymentSucceed ? (int)PortalEnums.Payment.PaymentSuccessStatus.Success : (int)PortalEnums.Payment.PaymentSuccessStatus.Failed,
                cardname, cardno, 
                expirymonth, 
                expiryyear, 
                cvv); // Todo save the card details);

            bool success = base.Insert(newOrder);

            invoiceOrderID = newOrder.OrderId;

            return success;

        }

        public decimal CalculateTotalForCart(List<CartItem> cart, bool currencyNeedRounding)
        {
            decimal total = 0;

            foreach (CartItem i in cart)
            {
                if( currencyNeedRounding )
                    total += ((int) i.TotalAmount) * i.Number;
                else
                    total += i.TotalAmount * i.Number;
            }

            return total;
        }

	}//End Class

} // end namespace
