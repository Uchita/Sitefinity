using System.Linq;
using System.Xml.Linq;

namespace JXTJobsExport.Helpers
{
    public class XmlConfigurationFile
    {
        public string OutputPath;

        public int[] Sites;
        public int[] ExcludedSites;

        public bool AllJobs;
        public bool JobsByAdvertiser;
        public bool JobsByProfession;
        public bool IncludeIndeedIntegration;

        public XmlConfigurationFile(string configFilepath)
        {
            try
            {
                //Fill all properties
                GetConfiguration(configFilepath);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///	This method fill all configurations to the properties. 
        /// </summary>
        /// <param name="configFilepath"><c>System.String</c> folder where xml file is.</param>
        /// <remark>Fill all the properties.</remark>
        private void GetConfiguration(string configFilepath)
        {
            try
            {
                XDocument xml = null;

                xml = XDocument.Load(configFilepath);

                OutputPath = xml.Descendants("Configuration").Elements("OutputPath").FirstOrDefault().Value;
                Sites = SplitSites(xml.Descendants("Configuration").Elements("Sites").FirstOrDefault().Value);
                ExcludedSites = SplitSites(xml.Descendants("Configuration").Elements("ExcludedSites").FirstOrDefault().Value);
                AllJobs = bool.Parse(xml.Descendants("Configuration").Elements("AllJobs").FirstOrDefault().Value);
                JobsByProfession = bool.Parse(xml.Descendants("Configuration").Elements("JobsByProfession").FirstOrDefault().Value);
                JobsByAdvertiser = bool.Parse(xml.Descendants("Configuration").Elements("JobsByAdvertiser").FirstOrDefault().Value);
                IncludeIndeedIntegration = bool.Parse(xml.Descendants("Configuration").Elements("IncludeIndeedIntegration").FirstOrDefault().Value);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///	This method handle sitesId to fill as int collection.
        /// </summary>
        /// <param name="sites"><c>System.String</c> all sites separated per comma(,).</param>
        /// <remark>This method handle sitesId to fill as int collection.</remark>
        /// <return>List collection with siteId from configuration file.</return>
        private int[] SplitSites(string sites)
        {
            try
            {
                //In cases where nothing is informed
                if (string.IsNullOrWhiteSpace(sites))
                    return new int[0];
                else
                {
                    var cSites = sites.Split(',');

                    int[] sitesReturn = new int[cSites.Length];

                    for (int i = 0; i < cSites.Length; i++)
                    {
                        sitesReturn[i] = int.Parse(cSites[i]);
                    }

                    return sitesReturn;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
