using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPosterTransform.Library.Common;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using JXTPosterTransform.Library.Models;

namespace JXTPosterTransform.Website.Models
{
    public class ClientDisplayModel
    {
        [Required]
        public int clientID { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        public int siteID { get; set; }
        public string webURL { get; set; }
        [Required]
        public PTCommonEnums.Client.Valid valid { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime? lastModifiedDate { get; set; }
        public int? lastModifiedBy { get; set; }

        public bool hasClientSetups { get; set; }
    }

    public class ClientSetupDisplayModel
    {
        public int? setupID { get; set; }
        [Required]
        public string setupName { get; set; }
        public string setupDescription { get; set; }
        public int clientID { get; set; }
        public string clientName { get; set; }

        [Required]
        public int? posterTransformID { get; set; }
        public string posterTransformName { get; set; }
        public List<PosterTransformModel> available_PT { get; set; }

        [Required]
        public PTCommonEnums.ClientSetup.ClientSetupType setupType { get; set; }
        public string setupTypeText { get; set; }

        public string setupTypeCredentials { get; set; }
        public bool useJXTSiteMappings { get; set; }
        [Required]
        public int timeslot { get; set; }
        [Required]
        public int? advertiserID { get; set; }
        public string advertiserUsername { get; set; }
        public string advertiserPassword { get; set; }

        public bool ArchiveMissingJobs { get; set; }
        [Required]
        public PTCommonEnums.ClientSetup.Valid validStatus { get; set; }


        public ClientSetupModels.PullJsonFromUrl PullJsonFromUrl { get; set; }
        public ClientSetupModels.PullXmlFromFTP PullXmlFromFTP { get; set; }
        public ClientSetupModels.PullXmlFromSFTP PullXmlFromSFTP { get; set; }
        public ClientSetupModels.PullXmlFromUrl PullXmlFromUrl { get; set; }
        public ClientSetupModels.PullXmlFromUrlWithAuth PullXmlFromUrlWithAuth { get; set; }
        public ClientSetupModels.PullXmlFromSalesforceRGF PullXmlRGF { get; set; }
        public ClientSetupModels.PullFromInvenias PullFromInvenias { get; set; }

        public ClientSetupDisplayModel()
        {
            PullXmlFromUrl = new ClientSetupModels.PullXmlFromUrl();
            PullXmlFromFTP = new ClientSetupModels.PullXmlFromFTP();
            PullXmlFromSFTP = new ClientSetupModels.PullXmlFromSFTP();
            PullXmlFromUrlWithAuth = new ClientSetupModels.PullXmlFromUrlWithAuth();
            PullXmlRGF = new ClientSetupModels.PullXmlFromSalesforceRGF();
            PullFromInvenias = new ClientSetupModels.PullFromInvenias();
            PullJsonFromUrl = new ClientSetupModels.PullJsonFromUrl();
        }


    }

    public class PosterTransformModel
    {
        public int PTID { get; set; }
        [Required]
        public string PTName { get; set; }
        [Required]
        public string PTDesc { get; set; }
        [Required]
        public PTCommonEnums.PosterTransform.Valid PTValid { get; set; }
        [Required]
        public string XSL { get; set; }
        [Required]
        public string testXML { get; set; }
        public DateTime lastModified { get; set; }
        public int lastModifiedBy { get; set; }

    }


}