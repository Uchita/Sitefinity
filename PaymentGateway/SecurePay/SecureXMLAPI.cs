using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace PaymentGateway.SecurePay
{
    public class SecureXMLAPI
    {
        public string Pay()
        {
            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create("http://test.securepay.com.au/xmlapi/payment");
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <SecurePayMessage>
                                    <MessageInfo>
                                     <messageID>8af793f9af34bea0cf40f5fb5c630c</messageID>
                                     <messageTimestamp>20041803161306527000+660</messageTimestamp>
                                     <timeoutValue>60</timeoutValue>
                                     <apiVersion>xml-4.2</apiVersion>
                                    </MessageInfo>
                                    <MerchantInfo>
                                     <merchantID>ABC0001</merchantID>
                                     <password>changeit</password>
                                    </MerchantInfo>
                                    <RequestType>Payment</RequestType>
                                    <Payment>
                                     <TxnList count=""1"">
                                     <Txn ID=""1"">
                                     <txnType>0</txnType>
                                     <txnSource>0</txnSource>
                                     <amount>1000</amount>
                                     <purchaseOrderNo>test</purchaseOrderNo>
                                     <CreditCardInfo>
                                     <cardNumber>4444333322221111</cardNumber>
                                     <expiryDate>09/15</expiryDate>
                                     </CreditCardInfo>
                                     </Txn>
                                     </TxnList>
                                    </Payment>
                                    </SecurePayMessage>";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                System.Net.WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                return ex.Message;   
            }
        }
    }
}
