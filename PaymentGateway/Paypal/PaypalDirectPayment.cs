using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayPal.PayPalAPIInterfaceService.Model;
using PayPal.PayPalAPIInterfaceService;
using JXTPortal.Entities;
using JXTPortal;

namespace PaymentGateway.Paypal
{
    // https://devtools-paypal.com/guide/pay_creditcard/dotnet?interactive=ON&env=sandbox
    public class PaypalDirectPayment
    {
        public bool DoDirectPayment(bool isLive, string username, string password, string signature, string currencycode, List<CartItem> cartitems, bool currencyRounding, decimal taxrate, string siteurl, string sitename, string cardholdername, string creditcardno, int expirymonth, int expiryyear, string cvv, string cardtype, out string responseCode, out string errorMessage, out string banktransactionid)
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

            string lastname = cardholdername;
            string firstname = string.Empty;
            string middlename = string.Empty;

            string[] splits = cardholdername.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 2)
            {
                firstname = splits[0];
                lastname = splits[1];
            }

            if (splits.Length > 2)
            {
                firstname = splits[0];
                for (int i = 1; i < splits.Length - 1; i++)
                {
                    middlename += splits[i] + " ";
                }
                middlename.Trim();
                lastname = splits[splits.Length - 1];
            }

            PersonNameType personname = new PersonNameType();
            personname.FirstName = firstname;
            personname.MiddleName = middlename;
            personname.LastName = lastname;

            PayerInfoType payerinfo = new PayerInfoType();
            payerinfo.PayerName = personname;

            AddressType address = new AddressType();
            address.Street1 = "Clarence Street";
            address.CityName = "Sydney";
            address.StateOrProvince = "NSW";
            address.Country = CountryCodeType.AU;
            address.CountryName = "AUSTRALIA";
            address.PostalCode = "2000";

            payerinfo.Address = address;

            CreditCardDetailsType creditcard = new CreditCardDetailsType();
            creditcard.CardOwner = payerinfo;
            creditcard.CreditCardNumber = creditcardno;
            creditcard.ExpMonth = expirymonth;
            creditcard.ExpYear = expiryyear;
            creditcard.CVV2 = cvv;
            if (cardtype == "visa") creditcard.CreditCardType = CreditCardTypeType.VISA;
            if (cardtype == "amex") creditcard.CreditCardType = CreditCardTypeType.AMEX;
            if (cardtype == "mastercard") creditcard.CreditCardType = CreditCardTypeType.MASTERCARD;

            PaymentDetailsType paymentDetail = new PaymentDetailsType();
            CurrencyCodeType currency = (CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType));

            List<PaymentDetailsItemType> paymentItems = new List<PaymentDetailsItemType>();

            // Add products
            decimal total = 0.00m;
            decimal totaltax = 0.00m;
            string jobitemtypes = string.Empty;
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
                // total += cartitem.TotalAmount * cartitem.Number + (cartitem.TotalAmount * cartitem.Number * taxrate);
                //total += cartitem.TotalAmount * cartitem.Number;
                totaltax += (cartitem.TotalAmount * cartitem.Number * taxrate);
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

            paymentDetail.TaxTotal = new BasicAmountType((CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType)), (totaltax).ToString("0.00")); //;
            paymentDetail.ItemTotal = new BasicAmountType((CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType)), (total - totaltax).ToString("0.00")); //;
            paymentDetail.OrderTotal = new BasicAmountType((CurrencyCodeType)EnumUtils.GetValue(currencycode, typeof(CurrencyCodeType)), (total).ToString("0.00")); //
            paymentDetail.OrderDescription = string.Format("PPAL{0} - {1}", sitename.Replace(" ", "").ToUpper(), DateTime.Now.ToString("yyyyMMddhhmmssfff"));
            paymentDetail.Custom = jobitemtypes.TrimEnd(new char[] { ',' });
            List<PaymentDetailsType> paymentDetails = new List<PaymentDetailsType>();
            paymentDetails.Add(paymentDetail);


            DoDirectPaymentRequestDetailsType detail = new DoDirectPaymentRequestDetailsType();
            detail.CreditCard = creditcard;
            detail.PaymentDetails = paymentDetail;

            DoDirectPaymentRequestType request = new DoDirectPaymentRequestType();
            request.Version = "104.0";
            request.DoDirectPaymentRequestDetails = detail;

            DoDirectPaymentReq wrapper = new DoDirectPaymentReq();
            wrapper.DoDirectPaymentRequest = request;
            try
            {
                PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(sdkConfig);
                DoDirectPaymentResponseType setECResponse = service.DoDirectPayment(wrapper);

                //Take the token value from the response, add it to the following URL, and redirect your user to Paypal:
                // Ex - https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-73H43630E23090329
                if (setECResponse.Ack.HasValue)
                {
                    responseCode = ((int)setECResponse.Ack.Value).ToString();
                }

                if (setECResponse.Ack.HasValue && setECResponse.Ack.Value == AckCodeType.SUCCESS)
                {
                    banktransactionid = setECResponse.TransactionID;
                    return true;
                }
                else
                {
                    // TODO - display error.
                    errorMessage = setECResponse.Errors[0].LongMessage;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                ExceptionTableService serviceException = new ExceptionTableService();
                serviceException.LogException(ex.GetBaseException());
            }

            return false;
        }
    }
}
