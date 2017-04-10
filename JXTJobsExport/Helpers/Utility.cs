using ICSharpCode.SharpZipLib.Zip;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace JXTJobsExport.Helpers
{
    /// <summary>
    ///	Class whith methods to help manage XML files. 
    /// </summary>
    public static class Utility
    {
        //Instance of log4net resource
        static ILog _logger = LogManager.GetLogger("JobsExport");

        /// <summary>
        ///	This method remove all invalids characters for a file path. 
        /// </summary>
        /// <param name="path"><c>System.String</c> instance.</param>
        /// <remark>Use to remove characters invalids from a path.</remark>
        public static string RemoveIvalidChars(string path)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                path = path.Replace(c.ToString(), "_");
            }

            path = path.Replace(" ", "_");

            return path;
        }

        /// <summary>
        ///	Find duplicate path with case insensitive . 
        /// </summary>
        /// <param name="path"><c>System.String</c> instance.</param>
        /// <param name="list"><c>List<System.String></System.String></c> instance.</param>
        /// <remark>Find duplicate path with case insensitive </remark>
        /// <returns>A <see cref="bool"/> true if exists.</returns>
        public static bool FindDuplicateStringPath(string path, List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToLower().Equals(path.ToLower()))
                    return true;
            }
            return false;
        }

        /// <summary>
        ///	Transform a XML file in zip file . 
        /// </summary>
        /// <param name="obj"> A <c>System.Object</c> XML instance.</param>
        /// <remark>Transform a XML file in zip file </remark>
        public static void SaveXML(object obj)
        {
            string path = string.Empty;

            try
            {
                XmlSaveType xst = (XmlSaveType)obj;
                xst.XMLDoc.Save(xst.Path);

                path = xst.Path;

                _logger.Info(string.Format("Generating {0}...", xst.Path.Replace(".xml", ".zip")));

                using (ZipOutputStream s = new ZipOutputStream(File.Create(xst.Path.Replace(".xml", ".zip"))))
                {
                    s.SetLevel(9);

                    byte[] buffer = new byte[4096];

                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    ZipEntry entry = new ZipEntry(Path.GetFileName(xst.Path));

                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(xst.Path))
                    {
                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }

                //Remove temporary XML file
                File.Delete(path);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("An error has occurred during the SaveXML process on path {0}", path), ex);
            }
        }
    }
    /// <summary>
    ///	Class to create a XML file. 
    /// </summary>
    internal class XmlSaveType
    {
        public XmlDocument XMLDoc { get; set; }
        public string Path { get; set; }

        //Constructor
        public XmlSaveType(XmlDocument xmldoc, string path)
        {
            XMLDoc = xmldoc;
            Path = path;
        }
    }
}
