using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace JXTPortal.Common
{

    public class FtpHelpers
    {
        public class FtpState
        {
            private ManualResetEvent wait;
            private FtpWebRequest request;
            private string fileName;
            private Exception operationException = null;
            string status;

            public FtpState()
            {
                wait = new ManualResetEvent(false);
            }

            public ManualResetEvent OperationComplete
            {
                get { return wait; }
            }

            public FtpWebRequest Request
            {
                get { return request; }
                set { request = value; }
            }

            public string FileName
            {
                get { return fileName; }
                set { fileName = value; }
            }
            public Exception OperationException
            {
                get { return operationException; }
                set { operationException = value; }
            }
            public string StatusDescription
            {
                get { return status; }
                set { status = value; }
            }
        }

        public void AsynchronousUpload(string destinationPath, string sourcePath, string userName, string password)
        {
            // Create a Uri instance with the specified URI string.
            // If the URI is not correctly formed, the Uri constructor
            // will throw an exception.
            ManualResetEvent waitObject;

            Uri target = new Uri(destinationPath);
            string fileName = sourcePath;
            FtpState state = new FtpState();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(target);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.KeepAlive = false;
            request.Proxy = null;

            // This example uses anonymous logon.
            // The request is anonymous by default; the credential does not have to be specified. 
            // The example specifies the credential only to
            // control how actions are logged on the server.

            if (!(string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password)))
            {
                request.Credentials = new NetworkCredential(userName, password);
            }

            // Store the request in the object that we pass into the
            // asynchronous operations.
            state.Request = request;
            state.FileName = fileName;

            // Get the event to wait on.
            waitObject = state.OperationComplete;

            // Asynchronously get the stream for the file contents.
            request.BeginGetRequestStream(
                new AsyncCallback(EndGetStreamCallback),
                state
            );

            // Block the current thread until all operations are complete.
            waitObject.WaitOne();

            // The operations either completed or threw an exception.
            if (state.OperationException != null)
            {
                throw state.OperationException;
            }

        }

        private static void EndGetStreamCallback(IAsyncResult ar)
        {
            FtpState state = (FtpState)ar.AsyncState;

            Stream requestStream = null;
            // End the asynchronous call to get the request stream.
            try
            {
                requestStream = state.Request.EndGetRequestStream(ar);
                // Copy the file contents to the request stream.
                const int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];
                int count = 0;
                int readBytes = 0;
                FileStream stream = File.OpenRead(state.FileName);
                do
                {
                    readBytes = stream.Read(buffer, 0, bufferLength);
                    requestStream.Write(buffer, 0, readBytes);
                    count += readBytes;
                }
                while (readBytes != 0);
                // IMPORTANT: Close the request stream before sending the request.
                requestStream.Close();
                // Asynchronously get the response to the upload request.
                state.Request.BeginGetResponse(
                    new AsyncCallback(EndGetResponseCallback),
                    state
                );
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                state.OperationException = e;
                state.OperationComplete.Set();
                return;
            }

        }

        // The EndGetResponseCallback method  
        // completes a call to BeginGetResponse.
        private static void EndGetResponseCallback(IAsyncResult ar)
        {
            FtpState state = (FtpState)ar.AsyncState;
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)state.Request.EndGetResponse(ar);
                response.Close();
                state.StatusDescription = response.StatusDescription;
                // Signal the main application thread that 
                // the operation is complete.
                state.OperationComplete.Set();
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                state.OperationException = e;
                state.OperationComplete.Set();
            }
        }

        public static bool UploadFile(Stream streamFileToUpload, String strHostWithFilename, String username, String password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strHostWithFilename);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(username, password);

                streamFileToUpload.Position = 0;

                byte[] fileContents = new byte[streamFileToUpload.Length];
                streamFileToUpload.Seek(0, SeekOrigin.Begin);
                streamFileToUpload.Read(fileContents, 0, fileContents.Length);

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();
            }
            catch
            {
                return false;
            }
            return true;

        }

        public static bool DownloadFile(String strHostWithFilename, String username, String password, ref Stream downloadedfile)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strHostWithFilename);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(username, password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();

                downloadedfile = new MemoryStream();
                s.CopyTo(downloadedfile);

                Console.WriteLine("Download File Complete, status {0}", response.StatusDescription);

                response.Close();
            }
            catch
            {
                return false;
            }
            return true;

        }

        public static bool DeleteFile(String strHostWithFilename, String username, String password)
        {
            try
            {
                FtpWebRequest ftpclientRequest = WebRequest.Create(strHostWithFilename) as FtpWebRequest;
                ftpclientRequest.Credentials = new System.Net.NetworkCredential(username, password);
                ftpclientRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpclientRequest.Proxy = null;
                FtpWebResponse response = ftpclientRequest.GetResponse() as FtpWebResponse;
                StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII);
                string Datastring = sr.ReadToEnd();
                response.Close();
            }
            catch
            {
                return false;
            }
            return true;

        }

        public static FileStruct[] GetFileList(String strPath, String username, String password, out string errormsg)
        {
            errormsg = string.Empty;
            try
            {
                FtpWebRequest ftpclientRequest = WebRequest.Create(strPath) as FtpWebRequest;
                ftpclientRequest.Credentials = new System.Net.NetworkCredential(username, password);
                ftpclientRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                ftpclientRequest.Proxy = null;
                FtpWebResponse response = ftpclientRequest.GetResponse() as FtpWebResponse;
                StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.ASCII);
                bool isMS = (response.BannerMessage.Contains("Microsoft"));
                string Datastring = sr.ReadToEnd();
                response.Close();

                string[] lines = Datastring.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                FileStruct[] fss = GetList(lines, isMS);

                return fss;
            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
                return new FileStruct[] { };
            }
        }

        private static FileStruct[] GetList(string[] lines, bool useMSSyntex)
        {
            List<FileStruct> fileArray = new List<FileStruct>();

            foreach (string line in lines)
            {
                string strLine = line;
                string[] groups = strLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                FileStruct fs = new FileStruct();

                if (useMSSyntex)
                {
                    if (groups.Length >= 4)
                    {
                        if (groups[2] != "<DIR>")
                        {
                            fs.CreateTime = string.Format("{0} {1}", groups[0], groups[1]);
                            fs.Name = groups[3];
                            if (groups.Length > 4)
                            {
                                for (int i = 4; i < groups.Length; i++)
                                {
                                    fs.Name += " " + groups[i];
                                }
                            }

                            fileArray.Add(fs);
                        }

                    }
                }
                else
                {
                    if (groups.Length >= 9)
                    {
                        fs.CreateTime = string.Format("{0} {1} {2}", groups[5], groups[6], groups[7]);
                        fs.Name = groups[8];
                        if (groups.Length > 9)
                        {
                            for (int i = 9; i < groups.Length; i++)
                            {
                                fs.Name += " " + groups[i];
                            }
                        }

                        if (!groups[0].StartsWith("d"))
                        {
                            fileArray.Add(fs);
                        }

                    }
                }

            }

            return fileArray.OrderByDescending(FileStruct => FileStruct.IsDirectory).ToArray();
        }
    }

    public struct FileStruct
    {
        public string Flags;
        public string Owner;
        public string Group;
        public bool IsDirectory;
        public string CreateTime;
        public string Name;
    }
}
