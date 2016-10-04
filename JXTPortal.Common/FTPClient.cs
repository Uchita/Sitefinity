using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace JXTPortal.Common
{
    public enum FtpDirectoryFormat
    {
        Unix,
        Windows,
        Unknown
    }

    public class FtpDirectoryEntryComparer : IComparer<FtpDirectoryEntry>
    {
        public int Compare(FtpDirectoryEntry a, FtpDirectoryEntry b)
        {
            if (b.IsDirectory && a.IsDirectory == false)
            {
                return 1;
            }
            else if (b.IsDirectory == false && a.IsDirectory)
            {
                return -1;
            }
            else
            {
                return string.Compare(a.Name, b.Name, true);
            }
        }
    }

    public class FtpDirectoryEntry
    {
        public string Name;
        public DateTime CreateTime;
        public bool IsDirectory;
        public Int64 Size;
        public string Group;    // UNIX only
        public string Owner;
        public string Flags;

    }

    /// <summary>
    /// General, easy-to-use FTP class.
    /// </summary>
    public class FtpClient
    {
        protected FtpDirectory _host;

        /// <summary>
        /// Gets or sets the current FTP domain and optional directory
        /// </summary>
        public string Host
        {
            set { _host.SetUrl(value); }
            get { return _host.GetUrl(); }
        }

        /// <summary>
        /// Gets or sets the login username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the login password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Indicates if the current directory is the
        /// root directory.
        /// </summary>

        public bool IsRootDirectory
        {
            get { return _host.IsRootDirectory; }
        }

        // Construction
        public FtpClient()
        {
            _host = new FtpDirectory();
        }

        /// <summary>
        /// Returns a directory listing of the current working directory.
        /// </summary>
        public long GetFileSize(string filename)
        {
            long filesize = 0;

            FtpWebRequest request = GetRequest(filename);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.UseBinary = true;

            using (FtpWebResponse response = request.GetResponse() as FtpWebResponse)
            {
                //filesize = response.ContentLength;    
            }

            return filesize;
        }

        /// <summary>
        /// Returns a directory listing of the current working directory.
        /// </summary>
        public List<FtpDirectoryEntry> ListDirectory(out string errormessage)
        {
            errormessage = string.Empty;
            try
            {
                FtpWebRequest request = GetRequest();
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                string listing;
                using (FtpWebResponse response = request.GetResponse() as FtpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(),
                                            System.Text.Encoding.UTF8);
                    listing = sr.ReadToEnd();

                    response.Close();
                }

                return ParseDirectoryListing(listing);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Changes the current working directory. If directory starts with "/" then it
        /// is relative to the root directory. If directory is ".." then it refers to
        /// the parent directory.</param>
        /// </summary>
        /// <param name="directory">Directory to make active.</param>
        public void ChangeDirectory(string directory, out string errormessage)
        {
            errormessage = string.Empty;
            try
            {
                _host.CurrentDirectory = directory;
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        /// <summary>
        /// Indicates if the specified directory exists. This function returns false
        /// if a filename existing with the given name.
        /// </summary>
        /// <param name="directory">Directory to test. May be relative or absolute.</param>
        /// <returns></returns>
        public bool DirectoryExists(string directory, out string errormessage)
        {
            errormessage = string.Empty;
            try
            {
                FtpWebRequest request = GetRequest(directory);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                using (FtpWebResponse response = request.GetResponse() as FtpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(),
                                                System.Text.Encoding.UTF8);
                    sr.ReadToEnd();
                    sr.Close();
                    response.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
            return false;
        }

        /// <summary>
        /// Creates the specified directory. This method will create multiple levels of
        /// subdirectories as needed.
        /// </summary>
        /// <param name="directory">Directory to create. May be relative or absolute.</param>
        public void CreateDirectory(string directory, out string errormessage)
        {
            errormessage = string.Empty;

            try
            {
                // Get absolute directory
                directory = _host.ApplyDirectory(directory);

                // Split into path components
                string[] steps = directory.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // Build list of full paths to each path component
                List<string> paths = new List<string>();
                for (int i = 1; i <= steps.Length; i++)
                    paths.Add(FtpDirectory.ForwardSlash + String.Join(FtpDirectory.ForwardSlash, steps, 0, i));

                // Find first path component that needs creating
                int createIndex;
                for (createIndex = paths.Count; createIndex > 0; createIndex--)
                {
                    if (DirectoryExists(paths[createIndex - 1], out errormessage))
                    {
                        if (!string.IsNullOrEmpty(errormessage))
                        {
                            return;
                        }
                        errormessage = "Folder already exists.";
                        break;
                    }
                }

                // Created needed paths

                for (; createIndex < paths.Count; createIndex++)
                {
                    ChangeDirectory(paths[createIndex - 1], out errormessage);

                    if (!string.IsNullOrEmpty(errormessage))
                    {
                        return;
                    }

                    string[] dirs = paths[createIndex].Split(new char[] { '/' });
                    string newDirName = dirs[dirs.Length - 1];

                    FtpWebRequest request = GetRequest(newDirName);
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();

                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        public void MoveFile(string oldname, string newname, out string errormessage)
        {
            errormessage = string.Empty;
            FtpWebRequest request = GetRequest(oldname);

            try
            {
                request.Method = WebRequestMethods.Ftp.Rename;
                request.RenameTo = newname;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                errormessage = ex.Message + string.Format("<input type='hidden' value='{0}' />", request.RequestUri.Host);
                errormessage = errormessage + string.Format("<input type='hidden' value='{0}' />", oldname);
                errormessage = errormessage + string.Format("<input type='hidden' value='{0}' />", newname);
            }
        }

        public void RenameFile(string oldname, ref string newname, out string errormessage)
        {
            errormessage = string.Empty;
            try
            {
                string extension = string.Empty;
                string[] parts = oldname.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                extension = parts[parts.Length - 1];

                FtpWebRequest request = GetRequest(oldname);
                request.Method = WebRequestMethods.Ftp.Rename;
                newname = string.Format("{0}.{1}", newname, extension);
                request.RenameTo = newname;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        public void RenameFolder(string oldname, ref string newname, out string errormessage)
        {
            errormessage = string.Empty;
            try
            {
                FtpWebRequest request = GetRequest(oldname);
                request.Method = WebRequestMethods.Ftp.Rename;
                request.RenameTo = newname;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        /// <summary>
        /// Uploads the given list of files to the current working directory.
        /// </summary>
        /// <param name="paths">List of local files to upload</param>
        public void UploadFiles(out string errormessage, params string[] paths)
        {
            errormessage = string.Empty;

            try
            {
                foreach (string path in paths)
                {
                    FtpWebRequest request = GetRequest(Path.GetFileName(path));
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.UseBinary = true;

                    FileInfo info = new FileInfo(path);
                    request.ContentLength = info.Length;

                    // Create buffer for file contents
                    int buffLength = 16384;
                    byte[] buff = new byte[buffLength];

                    // Upload this file
                    using (FileStream instream = info.OpenRead())
                    {
                        using (Stream outstream = request.GetRequestStream())
                        {
                            int bytesRead = instream.Read(buff, 0, buffLength);
                            while (bytesRead > 0)
                            {
                                outstream.Write(buff, 0, bytesRead);
                                bytesRead = instream.Read(buff, 0, buffLength);
                            }
                            outstream.Close();
                        }
                        instream.Close();
                    }

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        public void UploadFileFromStream(Stream streamFileToUpload, string strHostWithFilename, out string errormessage)
        {
            errormessage = string.Empty;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strHostWithFilename);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(Username, Password);

                streamFileToUpload.Position = 0;

                byte[] fileContents = new byte[streamFileToUpload.Length];
                streamFileToUpload.Seek(0, SeekOrigin.Begin);
                streamFileToUpload.Read(fileContents, 0, fileContents.Length);

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();
            }
            catch (Exception ex) { errormessage = ex.Message; }
        }

        /// <summary>
        /// Downloads the given list of files to the specified local target path
        /// </summary>
        /// <param name="path">Location where downloaded files will be saved</param>
        /// <param name="files">Names of files to download from current FTP directory</param>
        public void DownloadFiles(string path, out string errormessage, params string[] files)
        {
            errormessage = string.Empty;
            try
            {
                foreach (string file in files)
                {
                    FtpWebRequest request = GetRequest(file);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.UseBinary = true;

                    using (FileStream outstream = new FileStream(Path.Combine(path, file), FileMode.Create))
                    {
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        using (Stream instream = response.GetResponseStream())
                        {
                            int buffLength = 16384;
                            byte[] buffer = new byte[buffLength];

                            int bytesRead = instream.Read(buffer, 0, buffLength);
                            while (bytesRead > 0)
                            {
                                outstream.Write(buffer, 0, bytesRead);
                                bytesRead = instream.Read(buffer, 0, buffLength);
                            }
                            instream.Close();
                        }
                        outstream.Close();
                        response.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void DownloadFileToClient(string filepath, ref Stream downloadedfile, out string errormessage)
        {
            errormessage = string.Empty;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(filepath);
                request.Credentials = new NetworkCredential(Username, Password);
                request.Proxy = null;
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UseBinary = true;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();

                downloadedfile = new MemoryStream();
                s.CopyTo(downloadedfile);

                response.Close();
            }
            catch (Exception ex) { errormessage = ex.Message; }
        }

        /// <summary>
        /// Deletes the given list of files from the current working directory.
        /// </summary>
        /// <param name="files">List of files to delete.</param>
        public void DeleteFiles(out string errormessage, params string[] files)
        {
            errormessage = string.Empty;
            try
            {
                foreach (string file in files)
                {
                    FtpWebRequest request = GetRequest(file);
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        /// <summary>
        /// Deletes the specified directory. The directory should be empty.
        /// </summary>
        /// <param name="files">Directory to delete.</param>
        public void DeleteDirectory(string directory, out string errormessage)
        {
            errormessage = string.Empty;

            try
            {
                FtpWebRequest request = GetRequest(directory);
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
            }
        }

        #region Protected helper methods

        // Constructs an FTP web request
        protected FtpWebRequest GetRequest()
        {
            return GetRequest("");
        }

        // Constructs an FTP web request with the given filename
        protected FtpWebRequest GetRequest(string filename)
        {
            string url = _host.GetUrl(filename);
            FtpWebRequest request = WebRequest.Create(url) as FtpWebRequest;
            request.Credentials = new NetworkCredential(Username, Password);
            request.Proxy = null;
            request.KeepAlive = false;
            return request;
        }

        delegate FtpDirectoryEntry ParseLine(string lines);

        // Converts a directory listing to a list of FtpDirectoryEntrys
        protected List<FtpDirectoryEntry> ParseDirectoryListing(string listing)
        {
            ParseLine parseFunction = null;
            List<FtpDirectoryEntry> entries = new List<FtpDirectoryEntry>();
            string[] lines = listing.Split('\n');
            FtpDirectoryFormat format = GuessDirectoryFormat(lines);

            if (format == FtpDirectoryFormat.Windows)
                parseFunction = ParseWindowsDirectoryListing;
            else if (format == FtpDirectoryFormat.Unix)
                parseFunction = ParseUnixDirectoryListing;

            if (parseFunction != null)
            {
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        FtpDirectoryEntry entry = parseFunction(line);
                        if (entry.Name != "." && entry.Name != "..")
                        {
                            entries.Add(entry);
                        }
                    }
                }
            }
            return entries; ;
        }

        // Attempts to determine the directory format.
        protected FtpDirectoryFormat GuessDirectoryFormat(string[] lines)
        {
            foreach (string s in lines)
            {
                if (s.Length > 10 && Regex.IsMatch(s.Substring(0, 10),
                                        "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
                {
                    return FtpDirectoryFormat.Unix;
                }
                else if (s.Length > 8 && Regex.IsMatch(s.Substring(0, 8),
                    "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                {
                    return FtpDirectoryFormat.Windows;
                }
            }
            return FtpDirectoryFormat.Unknown;
        }

        // Parses a line from a Windows-format listing
        //
        // Assumes listing style as:
        // 02-03-04  07:46PM       <DIR>          Append
        protected FtpDirectoryEntry ParseWindowsDirectoryListing(string text)
        {
            FtpDirectoryEntry entry = new FtpDirectoryEntry();

            text = text.Trim();
            string dateStr = text.Substring(0, 8);
            text = text.Substring(8).Trim();
            string timeStr = text.Substring(0, 7);
            text = text.Substring(7).Trim();
            entry.CreateTime = DateTime.Parse(String.Format("{0} {1}", dateStr, timeStr));
            if (text.Substring(0, 5) == "<DIR>")
            {
                entry.IsDirectory = true;
                text = text.Substring(5).Trim();
            }
            else
            {
                entry.IsDirectory = false;
                int pos = text.IndexOf(' ');
                entry.Size = Int64.Parse(text.Substring(0, pos));
                text = text.Substring(pos).Trim();
            }
            entry.Name = text;  // Rest is name

            return entry;
        }

        // Parses a line from a UNIX-format listing
        //
        // Assumes listing style as:
        // dr-xr-xr-x   1 owner    group               0 Nov 25  2002 bussys
        protected FtpDirectoryEntry ParseUnixDirectoryListing(string text)
        {
            // Assuming record style as
            // dr-xr-xr-x   1 owner    group               0 Nov 25  2002 bussys
            FtpDirectoryEntry entry = new FtpDirectoryEntry();
            string processstr = text.Trim();
            entry.Flags = processstr.Substring(0, 9);
            entry.IsDirectory = (entry.Flags[0] == 'd');
            processstr = (processstr.Substring(11)).Trim();
            CutSubstringWithTrim(ref processstr, ' ', 0);   //skip one part
            entry.Owner = CutSubstringWithTrim(ref processstr, ' ', 0);
            entry.Group = CutSubstringWithTrim(ref processstr, ' ', 0);
            CutSubstringWithTrim(ref processstr, ' ', 0);   //skip one part
            string[] splits = CutSubstringWithTrim(ref processstr, ' ', 8).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            entry.Name = processstr;   //Rest of the part is name
            if (splits.Length == 3)
            {
                DateTime dt;

                if (DateTime.TryParse(string.Format("{0} {1} {2} {3}", splits[0], splits[1], DateTime.Now.Year, splits[2]), out dt))
                {
                    entry.CreateTime = dt;
                }
                else
                {
                    try
                    {
                        int month = DateTime.ParseExact(splits[0], "MMM", CultureInfo.CurrentCulture).Month;
                        int hour = DateTime.ParseExact(splits[2], "H:mm", CultureInfo.CurrentCulture).Hour;
                        int minute = DateTime.ParseExact(splits[2], "H:mm", CultureInfo.CurrentCulture).Minute;

                        entry.CreateTime = new DateTime(DateTime.Now.Year, month, Convert.ToInt32(splits[1]), hour, minute, 0);
                    }
                    catch
                    {
                        entry.CreateTime = DateTime.Now;
                    }
                }
            }
            if (!entry.IsDirectory)
            {
                long.TryParse(text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[4], out entry.Size);
            }
            return entry;
        }

        // Removes the token ending in the specified character
        protected string CutSubstringWithTrim(ref string s, char c, int startIndex)
        {
            int pos = s.IndexOf(c, startIndex);
            if (pos < 0) pos = s.Length;
            string retString = s.Substring(0, pos);
            s = (s.Substring(pos)).Trim();
            return retString;
        }

        #endregion

    }

    /// <summary>
    /// Helper class for managing current FTP directory.
    /// </summary>
    public class FtpDirectory
    {
        // Static members
        protected static char[] _slashes = { '/', '\\' };
        public static string BackSlash = "\\";
        public static string ForwardSlash = "/";

        // Member variables
        protected string _domain;    // No trailing slash
        protected string _cwd;        // Leading, no trailing slash
        public string Domain { get { return _domain; } }

        // Construction
        public FtpDirectory()
        {
            _domain = String.Empty;
            _cwd = ForwardSlash;    // Root directory
        }

        /// <summary>
        /// Determines if the current directory is the root directory.
        /// </summary>
        public bool IsRootDirectory
        {
            get { return _cwd == ForwardSlash; }
        }

        /// <summary>
        /// Gets or sets the current FTP directory.
        /// </summary>
        public string CurrentDirectory
        {
            get { return _cwd; }
            set { _cwd = ApplyDirectory(value); }
        }

        /// <summary>
        /// Sets the domain and current directory from a URL.
        /// </summary>
        /// <param name="url">URL to set to</param>
        public void SetUrl(string url)
        {
            // Separate domain from directory
            int pos = url.IndexOf("://");
            pos = url.IndexOfAny(_slashes, (pos < 0) ? 0 : pos + 3);
            if (pos < 0)
            {
                _domain = url;
                _cwd = ForwardSlash;
            }
            else
            {
                _domain = url.Substring(0, pos);
                // Normalize directory string
                _cwd = ApplyDirectory(url.Substring(pos));
            }
        }

        /// <summary>
        /// Returns the domain and current directory as a URL.
        /// </summary>
        public string GetUrl()
        {
            return GetUrl(String.Empty);
        }

        /// <summary>
        /// Returns the domain and specified directory as a URL.
        /// </summary>
        /// <param name="directory">Partial directory or filename applied to the
        /// current working directory.</param>
        public string GetUrl(string directory)
        {
            if (directory.Length == 0)
                return _domain + _cwd;
            return _domain + ApplyDirectory(directory);
        }

        /// <summary>
        /// Applies the given directory to the current directory and returns the
        /// result.
        ///
        /// If directory starts with "/", it replaces all of the current directory.
        /// If directory is "..", the top-most subdirectory is removed from
        /// the current directory.
        /// </summary>
        /// <param name="directory">The directory to apply</param>
        public string ApplyDirectory(string directory)
        {
            // Normalize directory
            directory = directory.Trim();
            directory = directory.Replace(BackSlash, ForwardSlash);
            directory = directory.TrimEnd(_slashes);

            if (directory == "..")
            {
                int pos = _cwd.LastIndexOf(ForwardSlash);
                return (pos <= 0) ? ForwardSlash : _cwd.Substring(0, pos);
            }
            else if (directory.StartsWith(ForwardSlash))
            {
                // Specifies complete directory path
                return directory;
            }
            else
            {
                // Relative to current directory
                if (_cwd == ForwardSlash)
                    return _cwd + directory;
                else
                    return _cwd + ForwardSlash + directory;
            }
        }

        /// <summary>
        /// Returns the domain and current directory as a URL
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetUrl();
        }
    }
}
