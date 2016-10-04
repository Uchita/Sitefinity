using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using JXTPortal;
using System.Web.Script.Serialization;
using System.Security.Cryptography;

public class WeVideo
{
    private string Domain { get; set; }
    private string Email { get; set; }
    private string ClientName { get; set; }
    private string APIKey { get; set; }
    private string APISecret { get; set; }

    string INSTANCE_USER_URL = "/api/3/instances/933/users?email={0}";
    string SSO_URL = "/api/3/sso/auth";
    string CREATE_USER_URL = "/api/3/users";
    string INSTANCE_ID = "933";
    public WeVideo(bool isLive, string email, string clientname, string apikey, string apisecret)
    {
        Domain = "http://awstest.wevideo.com";
        if (isLive)
        {
            Domain = "http://www.wevideo.com";
        }
        Email = email;
        ClientName = clientname;
        APIKey = apikey;
        APISecret = apisecret;
    }

    public bool CheckUserExists()
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(Domain + INSTANCE_USER_URL, Email));
            request.Method = "GET";
            request.Date = DateTime.Now;
            request.ContentType = "application/json";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string json = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                jsonuserwrapper token = jss.Deserialize<jsonuserwrapper>(json);

                if (token.data.Length >= 1)
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionTableService serviceException = new ExceptionTableService();
            serviceException.LogException(ex.GetBaseException());
        }

        return false;
    }

    public string Login()
    {
        try
        {
            DateTime datetime_now = DateTime.UtcNow;

            string date = datetime_now.ToString("ddd, dd MMM yyyy HH:mm:ss") + " GMT";

            JavaScriptSerializer js = new JavaScriptSerializer();
            var body = new { email = Email };
            string json_body = js.Serialize(body);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Domain + SSO_URL);
            request.Method = "POST";

            string signature = string.Empty;
            string md5Body;

            using (MD5 md5 = MD5.Create())
            {
                md5Body = GetMd5Hash(md5, js.Serialize(body));
            }

            string stringToSign = request.Method + "\n" + md5Body + "\n" + date + "\n" + Domain + SSO_URL;
            byte[] bytes = Encoding.ASCII.GetBytes(APISecret);

            using (HMACSHA256 hmac = new HMACSHA256(bytes))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(stringToSign);
                    writer.Flush();
                    stream.Position = 0;
                    signature = Convert.ToBase64String(hmac.ComputeHash(stream));
                }
            }

            string authorization = string.Format("WEV {0}:{1}", APIKey, signature);

            request.Headers[HttpRequestHeader.Authorization] = authorization;


            request.Date = datetime_now;
            request.ContentType = "application/json";
            request.Accept = "application/json";

            byte[] buffer = Encoding.ASCII.GetBytes(json_body);

            request.ContentLength = buffer.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            HttpWebResponse webresponse = (HttpWebResponse)response;
            using (var reader = new StreamReader(webresponse.GetResponseStream(), Encoding.UTF8))
            {
                string json = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                WeVideoAuthentication token = jss.Deserialize<WeVideoAuthentication>(json);

                return token.loginToken;

            }
        }
        catch (Exception ex)
        {
            ExceptionTableService serviceException = new ExceptionTableService();
            serviceException.LogException(ex.GetBaseException());
        }

        return string.Empty;
    }

    public string CreateUser(string firstname, string lastname, string username, string password)
    {
        try
        {
            DateTime datetime_now = DateTime.UtcNow;

            string date = datetime_now.ToString("ddd, dd MMM yyyy HH:mm:ss") + " GMT";

            JavaScriptSerializer js = new JavaScriptSerializer();
            var user = new {
                            firstName = firstname,
                            lastName= lastname,
                            password= password,
                            userName= username,
                            email= Email,
                            instanceId = INSTANCE_ID,
                            instanceName = ClientName
                           };
            string json_user = js.Serialize(user);



            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Domain + CREATE_USER_URL);
            request.Method = "POST";

            string signature = string.Empty;
            string md5Body;

            using (MD5 md5 = MD5.Create())
            {
                md5Body = GetMd5Hash(md5, js.Serialize(user));
            }

            string stringToSign = request.Method + "\n" + md5Body + "\n" + date + "\n" + Domain + CREATE_USER_URL;
            byte[] bytes = Encoding.ASCII.GetBytes(APISecret);

            using (HMACSHA256 hmac = new HMACSHA256(bytes))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(stringToSign);
                    writer.Flush();
                    stream.Position = 0;
                    signature = Convert.ToBase64String(hmac.ComputeHash(stream));
                }
            }

            string authorization = string.Format("WEV {0}:{1}", APIKey, signature);

            request.Headers[HttpRequestHeader.Authorization] = authorization;


            request.Date = datetime_now;
            request.ContentType = "application/json";
            request.Accept = "application/json";

            byte[] buffer = Encoding.ASCII.GetBytes(json_user);

            request.ContentLength = buffer.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            HttpWebResponse webresponse = (HttpWebResponse)response;
            using (var reader = new StreamReader(webresponse.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            ExceptionTableService serviceException = new ExceptionTableService();
            serviceException.LogException(ex.GetBaseException());
        }

        return string.Empty;
    }

    private string GetMd5Hash(MD5 md5Hash, string input)
    {

        // Convert the input string to a byte array and compute the hash. 
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes 
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data  
        // and format each one as a hexadecimal string. 
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string. 
        return sBuilder.ToString();
    }

    class jsonuserwrapper
    {
        public jsonuserdata[] data { get; set; }
        public jsonusermetadata metadata { get; set; }
    }

    class jsonuserdata
    {
        public string lastName { get; set; }
        public string groupName { get; set; }
        public string sessions { get; set; }
        public string instanceId { get; set; }
        public string groupId { get; set; }
        public string lastVisit { get; set; }
        public string joined { get; set; }
        public string email { get; set; }
        public string updated { get; set; }
        public string created { get; set; }
        public string userId { get; set; }
        public string role { get; set; }
        public string userName { get; set; }
        public string rootFolderId { get; set; }
        public string firstName { get; set; }
    }

    class jsonusermetadata
    {
        public int noResults { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

    }

    public class WeVideoAuthentication
    {
        public string email { get; set; }
        public string userId { get; set; }
        public string loginToken { get; set; }
        public string sessionId { get; set; }

        public WeVideoAuthentication() { }
    }

}
