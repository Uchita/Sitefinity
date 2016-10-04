using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace JXTPosterTransform.Website.Models
{
    public class ClientSetupLogDisplayModel
    {
        public int ClientSetupLogId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ClientSetupId { get; set; }
        public string ClientSetupName { get; set; }
        public int PosterTransformId { get; set; }
        public string PosterTransformName { get; set; }

        public string RawDataFileName { get; set; }
        public string RequestDataFileName { get; set; }
        public string ResponseDataFileName { get; set; }

        public string RawData
        {
            get
            {
                if (!string.IsNullOrEmpty(RawDataFileName))
                {
                    try
                    {
                        string path = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ClientSetupLogsFolderPath"] + RawDataFileName);
                        return File.ReadAllText(path);
                    }
                    catch (Exception e)
                    {
                        return "Could not open log file.";
                    }
                }
                else
                    return "File name is empty.";
            }
        }
        public string RequestData
        {
            get
            {
                if (!string.IsNullOrEmpty(RequestDataFileName))
                {
                    try
                    {
                        string path = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ClientSetupLogsFolderPath"] + RequestDataFileName);
                        return File.ReadAllText(path);
                    }
                    catch (Exception e)
                    {
                        return "Could not open log file.";
                    }
                }
                else
                    return "File name is empty.";
            }
        }
        public string ResponseData
        {
            get
            {
                if (!string.IsNullOrEmpty(ResponseDataFileName))
                {
                    try
                    {
                        string path = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ClientSetupLogsFolderPath"] + ResponseDataFileName);
                        return File.ReadAllText(path);
                    }
                    catch (Exception e)
                    {
                        return "Could not open log file.";
                    }
                }
                else
                    return "File name is empty.";
            }
        }

        public DateTime CreatedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public int Failed { get; set; }
    }
}