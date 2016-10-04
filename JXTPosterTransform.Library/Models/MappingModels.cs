using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPosterTransform.Library.Models;

namespace JXTPosterTransform.Library.Models
{
    public class MappingsXMLModel
    {
        public List<JobTemplateMap> JobTemplateMaps { get; set; }

        public List<JobTemplateLogoMap> JobTemplateLogoMaps { get; set; }

        public List<WorkTypeMap> WorkTypeMaps { get; set; }

        public List<CLAMap> CLAMaps { get; set; }

        public List<ProfessionRoleMap> ProfRoleMaps { get; set; }

        public List<SalaryTypeMap> SalaryTypeMaps { get; set; }

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

        public bool isDefaultSetting { get; set; }

        public bool isValidRow()
        {
            if (isDefaultSetting)
                return true;

            if (!string.IsNullOrEmpty(ClientJobTemplateID) && MapToJobTemplateID != -1)
            {
                return true;
            }

            return false;

        }

        public string MapToStringGet()
        {
            return (ClientJobTemplateID + "").ToLower();
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

        public bool isDefaultSetting { get; set; }

        public bool isValidRow()
        {
            if (isDefaultSetting)
                return true;

            if (!string.IsNullOrEmpty(ClientJobTemplateLogoID) && MapToJobTemplateLogoID != -1)
            {
                return true;
            }

            return false;

        }

        public string MapToStringGet()
        {
            return (ClientJobTemplateLogoID + "").ToLower();
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
        public int MapToProfessionID { get; set; }
        //[Range(0, 9999, ErrorMessage = "You must select a profession/role to map to")]
        public int MapToRoleID { get; set; }

        public string ClientProfessionID { get; set; }
        public string ClientRoleID { get; set; }

        public bool isDefaultSetting { get; set; }

        public bool isValidRow()
        {
            if (isDefaultSetting)
                return true;

            if (
                (!string.IsNullOrEmpty(ClientProfessionID) || !string.IsNullOrEmpty(ClientRoleID))
                && MapToRoleID != -1
                )
            {
                return true;
            }

            return false;

        }

        public string MapToStringGet()
        {
            return (ClientProfessionID + ClientRoleID).ToLower();
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

        public bool isDefaultSetting { get; set; }

        public bool isValidRow()
        {
            if (isDefaultSetting)
                return true;

            if (!string.IsNullOrEmpty(ClientWorkTypeID) && MapToWorkTypeID != -1)
            {
                return true;
            }

            return false;
        }

        public string MapToStringGet()
        {
            return (ClientWorkTypeID + "").ToLower();
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
        public int MapToCountryID { get; set; }
        public int MapToLocationID { get; set; }
        //[Range(0, 9999, ErrorMessage = "You must select a country/location/area to map to")]
        public int MapToAreaID { get; set; }

        public string ClientCountryID { get; set; }
        public string ClientLocationID { get; set; }
        public string ClientAreaID { get; set; }

        public bool isDefaultSetting { get; set; }

        public bool isValidRow()
        {
            if (isDefaultSetting)
            {
                return true;
            }

            if (
                (!string.IsNullOrEmpty(ClientCountryID) || !string.IsNullOrEmpty(ClientLocationID) || !string.IsNullOrEmpty(ClientAreaID))                
                && MapToAreaID != -1
                )
            {
                return true;
            }

            return false;
        }

        public string MapToStringGet()
        {
            return (ClientCountryID + ClientLocationID + ClientAreaID).ToLower();
        }

    }

    public class CLAItem
    {
        public int id { get; set; }
        public string description { get; set; }
        public List<CLAItem> childs { get; set; }
    }


    #endregion

    #region Salary Type Models
    public class SalaryTypeMappingModel
    {
        public List<SalaryTypeAvailable> availableSalaryTypes { get; set; }
        public List<SalaryTypeMap> Mappings { get; set; }
    }

    public class SalaryTypeMap
    {
        //[Range(0, 9999, ErrorMessage = "You must select a work type to map to")]
        public int MapToSalaryTypeID { get; set; }
        public string ClientSalaryTypeID { get; set; }

        public bool isValidRow()
        {
            if (!string.IsNullOrEmpty(ClientSalaryTypeID))
            {
                return true;
            }

            return false;

        }
    }

    public class SalaryTypeAvailable
    {
        public int MapToSalaryTypeID { get; set; }
        public string MapToSalaryTypeDescription { get; set; }
    }
    #endregion

}