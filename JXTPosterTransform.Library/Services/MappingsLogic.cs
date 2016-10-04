using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using JXTPosterTransform.Library.Models;

namespace JXTPosterTransform.Website.Logics
{
    public class MappingsLogic
    {
        /// <summary>
        /// Specifying either will only return the related XML model. To obtain the full XML model, you must specify both clientID and clientSetupID.
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="clientSetupID"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public MappingsXMLModel ClientMappingsGet(int? clientID, int? clientSetupID, out string errorMsg)
        {
            /*
             * NOTE that there are 2 locations for stores, 1 for CLA, WT and PR @ ClientMappingsFolderPath
             * second is for JT and JTL @ ClientSetupMappingsFolderPath
             * In here, we manage both and combine them
             * */

            string targetPath1 = string.Empty;
            string targetPath2 = string.Empty;

            if (HttpContext.Current != null)
            {
                targetPath1 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ClientMappingsFolderPath"] + clientID + ".xml");
                targetPath2 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ClientSetupMappingsFolderPath"] + clientSetupID + ".xml");
            }
            else
            {
                targetPath1 = ConfigurationManager.AppSettings["ClientMappingsFolderPath"] + clientID + ".xml";
                targetPath2 = ConfigurationManager.AppSettings["ClientSetupMappingsFolderPath"] + clientSetupID + ".xml";
            }
            


            if (clientID != null && clientSetupID != null)
            {
                //get full XML model

                if (File.Exists(targetPath1))
                {
                    MappingsXMLModel xmlMap1 = null, xmlMap2 = null;

                    string xmlText1 = File.ReadAllText(targetPath1);

                    string xmlText2 = string.Empty;
                    
                    if (File.Exists(targetPath2))
                     xmlText2 = File.ReadAllText(targetPath2);

                    using (TextReader sr = new StringReader(xmlText1))
                    using (TextReader sr2 = new StringReader(xmlText2))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(MappingsXMLModel));
                        xmlMap1 = (MappingsXMLModel)ser.Deserialize(sr);

                        if (!string.IsNullOrWhiteSpace(xmlText2))
                            xmlMap2 = (MappingsXMLModel)ser.Deserialize(sr2);
                        else
                            xmlMap2 = new MappingsXMLModel();
                    }

                    errorMsg = null;
                    //combine
                    return new MappingsXMLModel
                    {
                        CLAMaps = xmlMap1.CLAMaps,
                        ProfRoleMaps = xmlMap1.ProfRoleMaps,
                        WorkTypeMaps = xmlMap1.WorkTypeMaps,

                        JobTemplateLogoMaps = xmlMap2.JobTemplateLogoMaps,
                        JobTemplateMaps = xmlMap2.JobTemplateMaps
                    };
                }
                else
                {
                    errorMsg = "Client mapping files not found. Location searched: " + targetPath1 + " & " + targetPath2;
                    return null;
                }
            }
            else if (clientID != null)
            {
                //get partial XML model (CLA, PR, WT)
                if (File.Exists(targetPath1))
                {
                    string xmlText = File.ReadAllText(targetPath1);

                    using (TextReader sr = new StringReader(xmlText))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(MappingsXMLModel));

                        MappingsXMLModel thisXML = (MappingsXMLModel)ser.Deserialize(sr);

                        errorMsg = null;
                        return thisXML;
                    }
                }
                else
                {
                    errorMsg = "Client mapping 1 file not found. Location searched: " + targetPath1;
                    return null;
                }
            }
            else if (clientSetupID != null)
            {
                //get partial XML model (JT, JTL)
                if (File.Exists(targetPath2))
                {
                    string xmlText = File.ReadAllText(targetPath2);

                    using (TextReader sr = new StringReader(xmlText))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(MappingsXMLModel));

                        MappingsXMLModel thisXML = (MappingsXMLModel)ser.Deserialize(sr);

                        errorMsg = null;
                        return thisXML;
                    }
                }
                else
                {
                    errorMsg = "Client mapping 2 file not found. Location searched: " + targetPath1;
                    return null;
                }
            }

            errorMsg = "Unknown operation.";
            return null;
        }

        /// <summary>
        /// READ the notes for ClientMappingsGet, pretty much the same
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="clientSetupID"></param>
        /// <param name="model"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public bool ClientMappingsStore(int? clientID, int? clientSetupID, MappingsXMLModel model, out string errorMsg)
        {
            try
            {
                string targetPath1 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ClientMappingsFolderPath"] + "/" + clientID + ".xml");
                string targetPath2 = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ClientSetupMappingsFolderPath"] + "/" + clientSetupID + ".xml");

                if (clientID != null && clientSetupID != null)
                {
                    //update full XML model

                    FileStream fs;
                    XmlSerializer ser = new XmlSerializer(typeof(MappingsXMLModel));

                    if (File.Exists(targetPath1))
                    {
                        fs = File.Open(targetPath1, FileMode.Truncate);
                    }
                    else
                    {
                        fs = File.Open(targetPath1, FileMode.Create);
                    }

                    ser.Serialize(fs, new MappingsXMLModel{ CLAMaps = model.CLAMaps, ProfRoleMaps = model.ProfRoleMaps, WorkTypeMaps = model.WorkTypeMaps });
                    fs.Close();

                    if (File.Exists(targetPath2))
                    {
                        fs = File.Open(targetPath2, FileMode.Truncate);
                    }
                    else
                    {
                        fs = File.Open(targetPath2, FileMode.Create);
                    }

                    ser.Serialize(fs, new MappingsXMLModel { JobTemplateLogoMaps = model.JobTemplateLogoMaps, JobTemplateMaps = model.JobTemplateMaps });

                    fs.Close();

                    errorMsg = null;
                    return true;
                }
                else if (clientID != null)
                {
                    //update partial XML model (CLA, PR, WT)
                    FileStream fs;

                    if (File.Exists(targetPath1))
                    {
                        fs = File.Open(targetPath1, FileMode.Truncate);
                    }
                    else
                    {
                        fs = File.Open(targetPath1, FileMode.Create);
                    }

                    XmlSerializer ser = new XmlSerializer(typeof(MappingsXMLModel));
                    ser.Serialize(fs, model);

                    fs.Close();
                    errorMsg = null;
                    return true;
                }
                else if (clientSetupID != null)
                {
                    //update partial XML model (JT, JTL)
                    FileStream fs;

                    if (File.Exists(targetPath2))
                    {
                        fs = File.Open(targetPath2, FileMode.Truncate);
                    }
                    else
                    {
                        fs = File.Open(targetPath2, FileMode.Create);
                    }

                    XmlSerializer ser = new XmlSerializer(typeof(MappingsXMLModel));
                    ser.Serialize(fs, model);

                    fs.Close();
                    errorMsg = null;
                    return true;
                }

                errorMsg = "Unknown Operation.";
                return false;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
        }

    }
}