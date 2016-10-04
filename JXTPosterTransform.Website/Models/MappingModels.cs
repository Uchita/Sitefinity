using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using JXTPosterTransform.Library.Models;

namespace JXTPosterTransform.Website.Models
{
    public class MappingsXMLModel
    {
        public List<JobTemplateMap> JobTemplateMaps { get; set; }

        public List<JobTemplateLogoMap> JobTemplateLogoMaps { get; set; }

        public List<WorkTypeMap> WorkTypeMaps { get; set; }

        public List<CLAMap> CLAMaps { get; set; }

        public List<ProfessionRoleMap> ProfRoleMaps { get; set; }
    }

    #region Job Template Models
    public class JobTemplateMappingModel
    {
        public List<JobTemplateAvailable> availableJobTemplates { get; set; }
        public List<JobTemplateMap> Mappings { get; set; }
    }

    public class JobTemplateMap
    {
        public int MapToJobTemplateID { get; set; }
        public string ClientJobTemplateID { get; set; }

        public bool isValidRow()
        {
            if (!string.IsNullOrEmpty(ClientJobTemplateID))
            {
                return true;
            }

            return false;

        }
    }

    public class JobTemplateAvailable
    {
        public int MapToJobTemplateID { get; set; }
        public string MapToJobTemplateDescription { get; set; }
    }
    #endregion

    #region Job Template Logo Models
    public class JobTemplateLogoMappingModel
    {
        public List<JobTemplateLogoAvailable> availableJobTemplateLogos { get; set; }
        public List<JobTemplateLogoMap> Mappings { get; set; }
    }

    public class JobTemplateLogoMap
    {
        //[Range(0,9999, ErrorMessage="You must select a job template to map to")]
        public int MapToJobTemplateLogoID { get; set; }

        public string ClientJobTemplateLogoID { get; set; }

        public bool isValidRow()
        {
            if (!string.IsNullOrEmpty(ClientJobTemplateLogoID))
            {
                return true;
            }

            return false;

        }
    }

    public class JobTemplateLogoAvailable
    {
        public int MapToJobTemplateLogoID { get; set; }
        public string MapToJobTemplateLogoDescription { get; set; }
    }
    #endregion

    #region Profession Role Models

    public class ProfessionRoleMappingModel
    {
        public List<PRItem> availableProfessions { get; set; }
        public List<ProfessionRoleMap> Mappings { get; set; }
    }

    public class ProfessionRoleMap
    {
//        public int MapToProfessionID { get; set; }
        //[Range(0, 9999, ErrorMessage = "You must select a profession/role to map to")]
        public int MapToRoleID { get; set; }

        public string ClientProfessionID { get; set; }
        public string ClientRoleID { get; set; }

        public bool isValidRow()
        {
            if (!string.IsNullOrEmpty(ClientProfessionID) || !string.IsNullOrEmpty(ClientRoleID))
            {
                return true;
            }

            return false;

        }
    }

    public class PRItem
    {
        public int id { get; set; }
        public string description { get; set; }
        public List<PRItem> childs { get; set; }
    }


    #endregion

    #region Work Type Models
    public class WorkTypeMappingModel
    {
        public List<WorkTypeAvailable> availableWorkTypes { get; set; }
        public List<WorkTypeMap> Mappings { get; set; }
    }

    public class WorkTypeMap
    {
        //[Range(0, 9999, ErrorMessage = "You must select a work type to map to")]
        public int MapToWorkTypeID { get; set; }
        public string ClientWorkTypeID { get; set; }

        public bool isValidRow()
        {
            if (!string.IsNullOrEmpty(ClientWorkTypeID))
            {
                return true;
            }

            return false;

        }
    }

    public class WorkTypeAvailable
    {
        public int MapToWorkTypeID { get; set; }
        public string MapToWorkTypeDescription { get; set; }
    }
    #endregion

    #region Country Location Area Models
    public class CLAMappingModel
    {
        public List<CLAItem> availableCLA { get; set; }
        public List<CLAMap> Mappings { get; set; }
    }

    public class CLAMap
    {
        //public int MapToCountryID { get; set; }
        //public int MapToLocationID { get; set; }
        //[Range(0, 9999, ErrorMessage = "You must select a country/location/area to map to")]
        public int MapToAreaID { get; set; }

        public string ClientCountryID { get; set; }
        public string ClientLocationID { get; set; }
        public string ClientAreaID { get; set; }

        public bool isValidRow()
        {
            if (!string.IsNullOrEmpty(ClientCountryID) || !string.IsNullOrEmpty(ClientLocationID) || !string.IsNullOrEmpty(ClientAreaID))
            {
                return true;
            }

            return false;

        }

    }

    public class CLAItem
    {
        public int id { get; set; }
        public string description { get; set; }
        public List<CLAItem> childs { get; set; }
    }


    #endregion

}