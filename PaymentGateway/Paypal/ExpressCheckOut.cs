using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayPal.PayPalAPIInterfaceService.Model;
using PayPal.PayPalAPIInterfaceService;
using JXTPortal.Entities;

namespace PaymentGateway.Paypal
{
    public class ExpressCheckOut
    {
        public string DoExpressCheckOut(bool isLive, string username, string password, string signature, string currencycode, List<CartItem> cartitems, bool currencyRounding, decimal taxrate, string siteurl, string sitename, out string errorMessage)
        {
            Dictionary<string, string> sdkConfig = new Dictionary<string, string>();

            string strRedirectURL = string.Empty;
            errorMessage = string.Empty;

            if (isLive)
            {
                sdkConfig.Add("mode", "live");
                strRedirectURL = "https://www.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=";
            }
            else
            {
                sdkConfig.Add("mode", "sandbox");
                strRedirectURL = "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=";
            }

            sdkConfig.Add("account1.apiUsername", username);
            sdkConfig.Add("account1.apiPassword", password);
            sdkConfig.Add("account1.apiSignature", signature);


            PaymentDetailsType paymentDetail = new PaymentDetailsType();
            CurrencyCodeType currency = (CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType));

            List<PaymentDetailsItemType> paymentItems = new List<PaymentDetailsItemType>();

            // Add products
            decimal total = 0.00m;
            decimal totaltax = 0.00m;
            string jobitemtypes = string.Empty;

            //============== Original Code
            //foreach (CartItem cartitem in cartitems)
            //{
            //    PaymentDetailsItemType paymentItem = new PaymentDetailsItemType();

            //    paymentItem.Name = string.Format("{0} {1}", cartitem.Number, cartitem.ProductDescription);
            //    paymentItem.Amount = new BasicAmountType(currency, (cartitem.TotalAmount).ToString("0.00"));
            //    paymentItem.Quantity = cartitem.Number;
            //    // paymentItem.Tax =  new BasicAmountType(currency, (cartitem.TotalAmount * taxrate).ToString("0.00"));
            //    paymentItem.ItemCategory = (ItemCategoryType)EnumUtils.GetValue("Digital", typeof(ItemCategoryType)); //ItemCategoryType.DIGITAL; // 
            //    total += cartitem.TotalAmount * cartitem.Number + (cartitem.TotalAmount * cartitem.Number * taxrate);
            //    //total += cartitem.TotalAmount * cartitem.Number;
            //    totaltax += (cartitem.TotalAmount * cartitem.Number * taxrate);
            //    jobitemtypes += cartitem.JobItemsTypeID.ToString() + ",";
            //    paymentItems.Add(paymentItem);
            //}

            foreach (CartItem cartitem in cartitems)
            {
                PaymentDetailsItemType paymentItem = new PaymentDetailsItemType();

                paymentItem.Name = string.Format("{0} {1}", cartitem.Number, cartitem.ProductDescription);

                if (currencyRounding)
                {
                    int roundedItemAmount = (int)(cartitem.TotalAmount);

                    paymentItem.Amount = new BasicAmountType(currency, roundedItemAmount.ToString("0.00"));
                    total += roundedItemAmount * cartitem.Number;
                }
                else
                {
                    paymentItem.Amount = new BasicAmountType(currency, (cartitem.TotalAmount).ToString("0.00"));
                    total += cartitem.TotalAmount * cartitem.Number;
                }

                paymentItem.Quantity = cartitem.Number;
                // paymentItem.Tax =  new BasicAmountType(currency, (cartitem.TotalAmount * taxrate).ToString("0.00"));
                //paymentItem.ItemCategory = (ItemCategoryType)EnumUtils.GetValue("Digital", typeof(ItemCategoryType)); //ItemCategoryType.DIGITAL; // 

                //total += cartitem.TotalAmount * cartitem.Number;
                jobitemtypes += cartitem.JobItemsTypeID.ToString() + ",";
                paymentItems.Add(paymentItem);
            }

            //total has already been rounded if needed
            totaltax = total * taxrate;

            //add tax back to total
            if (currencyRounding)
                totaltax = (int)totaltax;

            total = total + totaltax;

            paymentDetail.PaymentDetailsItem = paymentItems;

            paymentDetail.PaymentAction = (PaymentActionCodeType)EnumUtils.GetValue("Sale", typeof(PaymentActionCodeType));

            // TODO - TAX
            paymentDetail.TaxTotal = new BasicAmountType((CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType)), (totaltax).ToString("0.00")); //;
            paymentDetail.ItemTotal = new BasicAmountType((CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType)), (total - totaltax).ToString("0.00")); //;
            paymentDetail.OrderTotal = new BasicAmountType((CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType)), (total).ToString("0.00")); //
            paymentDetail.OrderDescription = string.Format("PPAL{0} - {1}", sitename.Replace(" ", "").ToUpper(), DateTime.Now.ToString("yyyyMMddhhmmssfff"));
            paymentDetail.Custom = jobitemtypes.TrimEnd(new char[] { ',' });
            List<PaymentDetailsType> paymentDetails = new List<PaymentDetailsType>();
            paymentDetails.Add(paymentDetail);

            SetExpressCheckoutRequestDetailsType ecDetails = new SetExpressCheckoutRequestDetailsType();
            ecDetails.ReturnURL = siteurl + "/advertiser/paymentconfirmation.aspx?success=true"; //
            ecDetails.CancelURL = siteurl + "/advertiser/orderpayment.aspx?cancel=true"; //
            ecDetails.PaymentDetails = paymentDetails;

            SetExpressCheckoutRequestType request = new SetExpressCheckoutRequestType();
            request.Version = "104.0";
            request.SetExpressCheckoutRequestDetails = ecDetails;

            SetExpressCheckoutReq wrapper = new SetExpressCheckoutReq();
            wrapper.SetExpressCheckoutRequest = request;

            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(sdkConfig);
            SetExpressCheckoutResponseType setECResponse = service.SetExpressCheckout(wrapper);

            //Take the token value from the response, add it to the following URL, and redirect your user to Paypal:
            // Ex - https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-73H43630E23090329
            if (setECResponse.Ack.HasValue && setECResponse.Ack.Value == AckCodeType.SUCCESS)
            {
                // TODO - Redirect to this URL
                strRedirectURL = strRedirectURL + setECResponse.Token;
            }
            else
            {
                // TODO - display error.
                errorMessage = setECResponse.Errors[0].LongMessage;
            }

            return strRedirectURL;
        }

        public List<PayPalPayments> PaymentConfirmation(bool isLive, string username, string password, string signature, string payerid, string token, out string responseCode, out string errormessage, out string banktransactionid)
        {
            errormessage = string.Empty;
            responseCode = string.Empty;
            banktransactionid = string.Empty;
            
            List<PaymentDetailsType> paymentdetailstypes = GetExpressCheckoutDetails(isLive, username, password, signature, token, out errormessage);

            if (string.IsNullOrEmpty(errormessage))
            {
                List<PayPalPayments> payment = DoExpressCheckoutPayment(isLive, username, password, signature, payerid, token, paymentdetailstypes, out responseCode, out errormessage, out banktransactionid);
                if (string.IsNullOrEmpty(errormessage))
                {
                    return payment;
                }
            }

            return null;
        }

        private List<PayPalPayments> DoExpressCheckoutPayment(bool isLive, string username, string password, string signature, string payerid, string token, List<PaymentDetailsType> paymentdetailstypes,out string responseCode, out string errorMessage, out string banktransactionid)
        {
            Dictionary<string, string> sdkConfig = new Dictionary<string, string>();

            string strRedirectURL = string.Empty;
            errorMessage = string.Empty;
            responseCode = string.Empty;
            banktransactionid = string.Empty;

            if (isLive)
            {
                sdkConfig.Add("mode", "live");
            }
            else
            {
                sdkConfig.Add("mode", "sandbox");
            }

            sdkConfig.Add("account1.apiUsername", username);
            sdkConfig.Add("account1.apiPassword", password);
            sdkConfig.Add("account1.apiSignature", signature);

            DoExpressCheckoutPaymentRequestDetailsType ecDetails = new DoExpressCheckoutPaymentRequestDetailsType();
            ecDetails.PayerID = payerid;
            ecDetails.Token = token;
            ecDetails.PaymentAction = PaymentActionCodeType.SALE;
            ecDetails.PaymentDetails = paymentdetailstypes;

            DoExpressCheckoutPaymentRequestType request = new DoExpressCheckoutPaymentRequestType();
            request.Version = "104.0";
            request.DoExpressCheckoutPaymentRequestDetails = ecDetails;

            DoExpressCheckoutPaymentReq wrapper = new DoExpressCheckoutPaymentReq();
            wrapper.DoExpressCheckoutPaymentRequest = request;

            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(sdkConfig);
            DoExpressCheckoutPaymentResponseType setECResponse = service.DoExpressCheckoutPayment(wrapper);

            //Take the token value from the response, add it to the following URL, and redirect your user to Paypal:
            // Ex - https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-73H43630E23090329

            if (setECResponse.Ack.HasValue)
            {
                responseCode = ((int)setECResponse.Ack.Value).ToString();
            }

            if (setECResponse.Ack.HasValue && setECResponse.Ack.Value == AckCodeType.SUCCESS)
            {
                List<PayPalPayments> paypalpayments = new List<PayPalPayments>();
                banktransactionid = setECResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo[0].TransactionID;

                foreach (PaymentDetailsType payment in paymentdetailstypes)
                {
                    PayPalPayments paypalpayment = new PayPalPayments();
                    paypalpayment.OrderDescription = payment.OrderDescription;
                    paypalpayment.OrderTotal = payment.OrderTotal.value;
                    paypalpayment.TaxTotal = payment.TaxTotal.value;
                    paypalpayment.JobItemTypes = payment.Custom;

                    paypalpayment.PayPalPaymentsDetail = new List<PayPalPaymentsDetail>();

                    foreach (PaymentDetailsItemType paymentitem in payment.PaymentDetailsItem)
                    {
                        PayPalPaymentsDetail paymentdetail = new PayPalPaymentsDetail();
                        paymentdetail.Amount = paymentitem.Amount.value;
                        paymentdetail.Description = paymentitem.Name;
                        paymentdetail.Quantity = paymentitem.Quantity.Value;
                        paypalpayment.PayPalPaymentsDetail.Add(paymentdetail);
                    }

                    paypalpayments.Add(paypalpayment);
                }

                return paypalpayments;
            }
            else
            {
                // TODO - display error.
                errorMessage = setECResponse.Errors[0].LongMessage;
            }

            return null;
        }

        private List<PaymentDetailsType> GetExpressCheckoutDetails(bool isLive, string username, string password, string signature, string token, out string errorMessage)
        {
            Dictionary<string, string> sdkConfig = new Dictionary<string, string>();

            string strRedirectURL = string.Empty;
            errorMessage = string.Empty;

            if (isLive)
            {
                sdkConfig.Add("mode", "live");
            }
            else
            {
                sdkConfig.Add("mode", "sandbox");
            }

            sdkConfig.Add("account1.apiUsername", username);
            sdkConfig.Add("account1.apiPassword", password);
            sdkConfig.Add("account1.apiSignature", signature);

            GetExpressCheckoutDetailsRequestType request = new GetExpressCheckoutDetailsRequestType();
            request.Version = "104.0";
            request.Token = token;

            GetExpressCheckoutDetailsReq wrapper = new GetExpressCheckoutDetailsReq();
            wrapper.GetExpressCheckoutDetailsRequest = request;

            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(sdkConfig);
            GetExpressCheckoutDetailsResponseType setECResponse = service.GetExpressCheckoutDetails(wrapper);

            //Take the token value from the response, add it to the following URL, and redirect your user to Paypal:
            // Ex - https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-73H43630E23090329
            if (setECResponse.Ack.HasValue && setECResponse.Ack.Value == AckCodeType.SUCCESS)
            {
                return setECResponse.GetExpressCheckoutDetailsResponseDetails.PaymentDetails;
            }
            else
            {
                // TODO - display error.
                errorMessage = setECResponse.Errors[0].LongMessage;
            }

            return null;
        }
    }

    public class PayPalPayments
    {
        public string OrderTotal { get; set; }
        public string TaxTotal { get; set; }
        public string OrderDescription { get; set; }
        public string JobItemTypes { get; set; }
        public List<PayPalPaymentsDetail> PayPalPaymentsDetail { get; set; }
    }

    public class PayPalPaymentsDetail
    {
        public string Amount { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }

}
