using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using JXTPortal.Entities;
using JXTPortal;
using log4net;

namespace PaymentGateway.Paypal
{
    public class PayflowPaymentGateway
    {
        ILog logger;

        public PayflowPaymentGateway()
        {
            logger = LogManager.GetLogger(typeof(PayflowPaymentGateway));
        }

        public bool DoPayment(string user, string vendor, string partner, string password, string creditcardnumber, string cardholdername, int month, int year, string cvv, string currencycode, List<CartItem> cartitems, bool currencyRounding, decimal taxrate, string siteurl, string sitename, out string responseCode, out string errorMessage)
        {
            errorMessage = string.Empty;
            responseCode = string.Empty;
            String RequestID = PayflowUtility.RequestId;

            UserInfo User = new UserInfo(user, vendor, partner, password);

            // Obtain Host address from the app.config file and use default values for
            // timeout and proxy settings.

            PayflowConnectionData Connection = new PayflowConnectionData();

            // *** Create a new Invoice data object ***
            // Set Invoice object with the Amount, Billing & Shipping Address, etc. ***

             PayPal.Payments.DataObjects.Invoice Inv = new PayPal.Payments.DataObjects.Invoice();

             decimal total = 0.00m;
             decimal totaltax = 0.00m;
             string jobitemtypes = string.Empty;

             foreach (CartItem cartitem in cartitems)
             {
                 LineItem paymentItem = new LineItem();

                 paymentItem.Name = string.Format("{0} {1}", cartitem.Number, cartitem.ProductDescription);

                 if (currencyRounding)
                 {
                     int roundedItemAmount = (int)(cartitem.TotalAmount);

                     paymentItem.Amt = new Currency(roundedItemAmount, currencycode);
                     total += roundedItemAmount * cartitem.Number;
                 }
                 else
                 {
                     paymentItem.Amt = new Currency(cartitem.TotalAmount, currencycode);
                     total += cartitem.TotalAmount * cartitem.Number;
                 }

                 paymentItem.Qty = cartitem.Number;
                 // paymentItem.Tax =  new BasicAmountType(currency, (cartitem.TotalAmount * taxrate).ToString("0.00"));
                 //paymentItem.ItemCategory = (ItemCategoryType)EnumUtils.GetValue("Digital", typeof(ItemCategoryType)); //ItemCategoryType.DIGITAL; // 

                 //total += cartitem.TotalAmount * cartitem.Number;
                 jobitemtypes += cartitem.JobItemsTypeID.ToString() + ",";
             }

             //total has already been rounded if needed
             totaltax = total * taxrate;

             //add tax back to total
             if (currencyRounding)
                 totaltax = (int)totaltax;

             total = total + totaltax;
             Inv.Amt = new Currency(total, currencycode);
             Inv.TaxAmt = new Currency(totaltax, currencycode);
            

            // PONum, InvNum and CustRef are sent to the processors and could show up on a customers
            // or your bank statement. These fields are reportable but not searchable in PayPal Manager.
            string description = string.Format("PPAL{0} - {1}", sitename.Replace(" ", "").ToUpper(), DateTime.Now.ToString("yyyyMMddhhmmssfff"));
            Inv.InvNum = description;
            Inv.CustRef = description;
            
            // Set the BillTo object into invoice.
            BillTo billto = new BillTo();
            billto.BillToFirstName = cardholdername;

            DateTime now = DateTime.Now;
            Inv.InvoiceDate = string.Format("{0}{1}", now.Month.ToString("00"), (now.Year % 100).ToString("00"));
            
            // *** Create a new Payment Device - Credit Card data object. ***
            // The input parameters are Credit Card Number and Expiration Date of the Credit Card.
            // Note: Expiration date is in the format MMYY.
            CreditCard CC = new CreditCard(creditcardnumber, month.ToString("00") + (year % 100).ToString("00"));
            if (!string.IsNullOrEmpty(cvv)) CC.Cvv2 = cvv;
            // Name on Credit Card is optional and not used as part of the authorization.
            // Also, this field populates the NAME field which is the same as FIRSTNAME, so if you
            // are already populating first name, do not use this field.
            CC.Name = cardholdername;

            // *** Create a new Tender - Card Tender data object. ***
            CardTender Card = new CardTender(CC);  // credit card
            
            SaleTransaction Trans = new SaleTransaction(User, Connection, Inv, Card, RequestID);
            
            ClientInfo cInfo = new ClientInfo();
            cInfo.IntegrationProduct = "Test";
            cInfo.IntegrationVersion = "1.0";
            Trans.ClientInfo = cInfo;

            Trans.Verbosity = "HIGH";

            // Try to submit the transaction up to 3 times with 5 second delay.  This can be used
            // in case of network issues.  The idea here is since you are posting via HTTPS behind the scenes there
            // could be general network issues, so try a few times before you tell customer there is an issue.
            int trxCount = 1;
            bool RespRecd = false;
            try
            {
                while (trxCount <= 3 && !RespRecd)
                {
                    // Notice we set the request id earlier in the application and outside our loop.  This way if a response was not received
                    // but PayPal processed the original request, you'll receive the original response with DUPLICATE set.

                    // Submit the Transaction
                    Response Resp = Trans.SubmitTransaction();

                    // Uncomment line below to simulate "No Response"
                    //Resp = null;

                    // Display the transaction response parameters.
                    if (Resp != null)
                    {
                        RespRecd = true;  // Got a response.

                        // Get the Transaction Response parameters.
                        TransactionResponse TrxnResponse = Resp.TransactionResponse;
                        
                        // Refer to the Payflow Pro .NET API Reference Guide and the Payflow Pro Developer's Guide
                        // for explanation of the items returned and for additional information and parameters available.
                        if (TrxnResponse != null)
                        {
                            responseCode = TrxnResponse.Result.ToString();

                            if (TrxnResponse.CardType != null)
                            {
                                Console.Write("Card Type (CARDTYPE) = ");
                                switch (TrxnResponse.CardType)
                                {
                                    case "0":
                                        Console.WriteLine("Visa");
                                        break;
                                    case "1":
                                        Console.WriteLine("MasterCard");
                                        break;
                                    case "2":
                                        Console.WriteLine("Discover");
                                        break;
                                    case "3":
                                        Console.WriteLine("American Express");
                                        break;
                                    case "4":
                                        Console.WriteLine("Diner's Club");
                                        break;
                                    case "5":
                                        Console.WriteLine("JCB");
                                        break;
                                    case "6":
                                        Console.WriteLine("Maestro");
                                        break;
                                    case "S":
                                        Console.WriteLine("Solo");
                                        break;
                                }
                            }
                        }

                        // Get the Fraud Response parameters.
                        // All trial accounts come with basic Fraud Protection Services enabled.
                        // Review the PayPal Manager guide to set up your Fraud Filters prior to 
                        // running this sample code.
                        // If Fraud Filters are not set, you will receive a RESULT code 126.
                        FraudResponse FraudResp = Resp.FraudResponse;
                        if (FraudResp != null)
                        {
                            errorMessage = "Fraud Transaction";
                        }
                        string DupMsg;
                        if (TrxnResponse.Duplicate == "1")
                        {
                            errorMessage = "Fraud Transaction";
                        }
                        if (TrxnResponse.Result < 0)
                        {
                            // Transaction failed.
                            errorMessage = "There was an error processing your transaction. Please contact Customer Service." +
                                Environment.NewLine + "Error: " + TrxnResponse.Result.ToString();
                        }
                        else if (TrxnResponse.Result == 1 || TrxnResponse.Result == 26)
                        {
                            errorMessage = "Account configuration issue.  Please verify your login credentials.";
                        }
                        else if (TrxnResponse.Result == 0)
                        {
                            // Example of a message you might want to display with an approved transaction.
                            errorMessage = string.Empty;
                            return true;
                        }
                        else if (TrxnResponse.Result == 12)
                        {
                            // Hard decline from bank.  Customer will need to use another card or payment type.
                            errorMessage = "Your transaction was declined.";
                        }
                        else if (TrxnResponse.Result == 13)
                        {
                            // Voice authorization required.  You would need to contact your merchant bank to obtain a voice authorization.  If authorization is 
                            // given, you can manually enter it via Virtual Terminal in PayPal Manager or via the VoiceAuthTransaction object.
                            errorMessage = "Your Transaction is pending. Contact Customer Service to complete your order.";
                        }
                        else if (TrxnResponse.Result == 23 || TrxnResponse.Result == 24)
                        {
                            // Issue with credit card number or expiration date.
                            errorMessage = "Invalid credit card information. Please re-enter.";
                        }
                        else if (TrxnResponse.Result == 125)
                        {
                            // Using the Fraud Protection Service.
                            // This portion of code would be is you are using the Fraud Protection Service, this is for US merchants only.
                            // 125, 126 and 127 are Fraud Responses.
                            // Refer to the Payflow Pro Fraud Protection Services User's Guide or Website Payments Pro Payflow Edition - Fraud Protection Services User's Guide.
                            errorMessage = "Your Transactions has been declined. Contact Customer Service.";
                        }
                        else if (TrxnResponse.Result == 126)
                        {
                            // One of more filters were triggered.  Here you would check the fraud message returned if you
                            // want to validate data.  For example, you might have 3 filters set, but you'll allow 2 out of the
                            // 3 to consider this a valid transaction.  You would then send the request to the server to modify the
                            // status of the transaction.  Performing this function is outside the scope of this sample, refer
                            // to the Fraud Developer's Guide.
                            //
                            // Decline transaction if AVS fails.
                            if (TrxnResponse.AVSAddr != "Y" || TrxnResponse.AVSZip != "Y")
                            {
                                // Display message that transaction was not accepted.  At this time, you
                                // could display message that information is incorrect and redirect user 
                                // to re-enter STREET and ZIP information.  However, there should be some sort of
                                // strikes your out check.
                                errorMessage = "Your billing information does not match.  Please re-enter.";
                            }
                            else
                            {
                                errorMessage = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
                            }
                            errorMessage = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
                        }
                        else if (TrxnResponse.Result == 127)
                        {
                            // There is an issue with checking this transaction through the fraud service.
                            // You will need to manually approve.
                            errorMessage = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
                        }
                        else
                        {
                            // Error occurred, display normalized message returned.
                            errorMessage = TrxnResponse.RespMsg;
                        }
                    }
                    else
                    {
                        Thread.Sleep(5000); // let's wait 5 seconds to see if this is a temporary network issue.
                        // Console.WriteLine("Retry #: " + trxCount.ToString());
                        trxCount++;
                    }
                }
                if (!RespRecd)
                {
                    errorMessage = "There is a problem obtaining an authorization for your order.";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.GetBaseException());
            }

            return false;
        }
    }
}
