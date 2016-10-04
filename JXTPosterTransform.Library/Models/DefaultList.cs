using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPosterTransform.Library.Models
{

    [Serializable]
    public class DefaultResponse
    {
        public DefaultList DefaultList { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    [Serializable]
    public class DefaultList
    {
        
        public List<JobTemplate> JobTemplates { get; set; }

        public List<CountryLocationArea> CountryLocationAreas { get; set; }

        public List<ProfessionRole> ProfessionRoles { get; set; }

        public List<WorkType> WorkTypes { get; set; }

        public List<AdvertiserJobTemplateLogo> AdvertiserJobTemplateLogos { get; set; }

        public List<SalaryType> SalaryTypes { get; set; }

        
        public class JobTemplate
        {
            
            public string JobTemplateID { get; set; }
            
            public string JobTemplateDescription { get; set; }

            public JobTemplate() { }

            public JobTemplate(string _JobTemplateID, string _JobTemplateDescription)
            {
                JobTemplateID = _JobTemplateID;
                JobTemplateDescription = _JobTemplateDescription;
            }

        }

        
        public class AdvertiserJobTemplateLogo
        {
            
            public string AdvertiserJobTemplateLogoID { get; set; }
            
            public string LogoName { get; set; }

            public AdvertiserJobTemplateLogo() { }

            public AdvertiserJobTemplateLogo(string _AdvertiserJobTemplateLogoID, string _LogoName)
            {
                AdvertiserJobTemplateLogoID = _AdvertiserJobTemplateLogoID;
                LogoName = _LogoName;
            }
        }

        
        public class ProfessionRole
        {
            
            public string ProfessionID { get; set; }

            
            public string ProfessionName { get; set; }

            public string RoleID { get; set; }

            public string RoleName { get; set; }

            public ProfessionRole() { }

            public ProfessionRole(string _ProfessionID, string _ProfessionName, string _RoleID, string _RoleName)
            {
                ProfessionID = _ProfessionID;
                ProfessionName = _ProfessionName;
                RoleID = _RoleID;
                RoleName = _RoleName;
            }
        }

        
        public class WorkType
        {
            
            public string WorkTypeID { get; set; }
            
            public string WorkTypeName { get; set; }

            public WorkType() { }

            public WorkType(string _WorkTypeID, string _WorkTypeName)
            {
                WorkTypeID = _WorkTypeID;
                WorkTypeName = _WorkTypeName;
            }
        }


        public class SalaryType
        {

            public string SalaryTypeID { get; set; }

            public string SalaryTypeName { get; set; }

            public SalaryType() { }

            public SalaryType(string _SalaryTypeID, string _SalarykTypeName)
            {
                SalaryTypeID = _SalaryTypeID;
                SalaryTypeName = _SalarykTypeName;
            }
        }

        public class CountryLocationArea
        {
            
            public string CountryID { get; set; }
            
            public string CountryName { get; set; }

            
            public string LocationID { get; set; }
            
            public string LocationName { get; set; }

            public string AreaID { get; set; }

            public string AreaName { get; set; }

            public CountryLocationArea() { }

            public CountryLocationArea(string _CountryID, string _CountryName, string _LocationID, string _LocationName, string _AreaID, string _AreaName)
            {
                CountryID = _CountryID;
                CountryName = _CountryName;
                LocationID = _LocationID;
                LocationName = _LocationName;
                AreaID = _AreaID;
                AreaName = _AreaName;
            }
        }
    }
}
