using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Data;

namespace JXTJobsXMLGenerator
{
    public partial class Form1 : Form
    {
        #region Declarations

        private AdvertisersService _advertisersservice;
        private AdvertiserUsersService _advertiserusersservice;
        private WebServiceLogService _webservicelogservice;
        private JobTemplatesService _jobtemplatesservice;
        private AdvertiserJobTemplateLogoService _advertiserjobtemplatelogoservice;
        private ProfessionService _professionservice;
        private RolesService _rolesservice;
        private SiteProfessionService _siteprofessionservice;
        private SiteRolesService _siterolesservice;
        private SiteWorkTypeService _siteworktypeservice;
        private CountriesService _countriesservice;
        private LocationService _locationservice;
        private AreaService _areaservice;
        private SiteCountriesService _sitecountriesservice;
        private SiteLocationService _sitelocationservice;
        private SiteAreaService _siteareaservice;
        private SalaryTypeService _salarytypeservice;
        private SiteSalaryTypeService _sitesalarytypeservice;
        private SalaryService _salaryservice;

        #endregion

        #region Properties

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersservice == null)
                {
                    _advertiserusersservice = new AdvertiserUsersService();
                }
                return _advertiserusersservice;
            }
        }

        private WebServiceLogService WebServiceLogService
        {
            get
            {
                if (_webservicelogservice == null)
                {
                    _webservicelogservice = new WebServiceLogService();
                }
                return _webservicelogservice;
            }
        }

        private JobTemplatesService JobTemplatesService
        {
            get
            {
                if (_jobtemplatesservice == null)
                {
                    _jobtemplatesservice = new JobTemplatesService();
                }
                return _jobtemplatesservice;
            }
        }

        private AdvertiserJobTemplateLogoService AdvertiserJobTemplateLogoService
        {
            get
            {
                if (_advertiserjobtemplatelogoservice == null)
                {
                    _advertiserjobtemplatelogoservice = new AdvertiserJobTemplateLogoService();
                }
                return _advertiserjobtemplatelogoservice;
            }
        }

        private ProfessionService ProfessionService
        {
            get
            {
                if (_professionservice == null)
                {
                    _professionservice = new ProfessionService();
                }
                return _professionservice;
            }
        }

        private RolesService RolesService
        {
            get
            {
                if (_rolesservice == null)
                {
                    _rolesservice = new RolesService();
                }
                return _rolesservice;
            }
        }

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionservice == null)
                {
                    _siteprofessionservice = new SiteProfessionService();
                }
                return _siteprofessionservice;
            }
        }

        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siterolesservice == null)
                {
                    _siterolesservice = new SiteRolesService();
                }
                return _siterolesservice;
            }
        }

        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeservice == null)
                {
                    _siteworktypeservice = new SiteWorkTypeService();
                }
                return _siteworktypeservice;
            }
        }

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesservice == null)
                {
                    _countriesservice = new CountriesService();
                }
                return _countriesservice;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationservice == null)
                {
                    _locationservice = new LocationService();
                }
                return _locationservice;
            }
        }
        private AreaService AreaService
        {
            get
            {
                if (_areaservice == null)
                {
                    _areaservice = new AreaService();
                }
                return _areaservice;
            }
        }

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesservice == null)
                {
                    _sitecountriesservice = new SiteCountriesService();
                }
                return _sitecountriesservice;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationservice == null)
                {
                    _sitelocationservice = new SiteLocationService();
                }
                return _sitelocationservice;
            }
        }

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaservice == null)
                {
                    _siteareaservice = new SiteAreaService();
                }
                return _siteareaservice;
            }
        }

        private SalaryTypeService SalaryTypeService
        {
            get
            {
                if (_salarytypeservice == null)
                {
                    _salarytypeservice = new SalaryTypeService();
                }
                return _salarytypeservice;
            }
        }

        private SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_sitesalarytypeservice == null)
                {
                    _sitesalarytypeservice = new SiteSalaryTypeService();
                }
                return _sitesalarytypeservice;
            }
        }


        private SalaryService SalaryService
        {
            get
            {
                if (_salaryservice == null)
                {
                    _salaryservice = new SalaryService();
                }
                return _salaryservice;
            }
        }

        Random random;
        #endregion

        public Form1()
        {
            InitializeComponent();

            random = new Random();
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int count = 0;
            int advertiserid = 0;
            int siteid = 65;


            if (int.TryParse(tbNumber.Text, out count))
            {
                if (count > 0)
                {
                    if (int.TryParse(tbAdvertiser.Text, out advertiserid))
                    {
                        if (advertiserid > 0)
                        {
                            if (cbExportAsSOAP.Checked)
                            {
                                if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text))
                                {
                                    lbMessage.Text = "Please fill in Username & Password";

                                    return;
                                }
                            }

                            bool exportassoap = cbExportAsSOAP.Checked;

                            DataSet ds = WebServiceLogService.CustomGetExportList(siteid, advertiserid);
                            // Profession Roles
                            List<ExportProfessionRoles> exportprofessionroles = new List<ExportProfessionRoles>();
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                ExportProfessionRoles epr = new ExportProfessionRoles();
                                epr.ProfessionID = Convert.ToInt32(dr["ProfessionID"]);
                                epr.ProfessionName = dr["SiteProfessionName"].ToString();
                                epr.RolesID = Convert.ToInt32(dr["RoleID"]);
                                epr.RolesName = dr["SiteRoleName"].ToString();

                                exportprofessionroles.Add(epr);
                            }

                            List<ExportWorkType> exportworktype = new List<ExportWorkType>();

                            foreach (DataRow dr in ds.Tables[3].Rows)
                            {
                                ExportWorkType ewt = new ExportWorkType();
                                ewt.WorkTypeID = Convert.ToInt32(dr["WorkTypeID"]);
                                ewt.WorkTypeName = dr["SiteWorkTypeName"].ToString();

                                exportworktype.Add(ewt);
                            }

                            List<ExportCountryLocationArea> exportcountrylocationarea = new List<ExportCountryLocationArea>();

                            foreach (DataRow dr in ds.Tables[4].Rows)
                            {
                                ExportCountryLocationArea ecla = new ExportCountryLocationArea();
                                ecla.CountryID = Convert.ToInt32(dr["CountryID"]);
                                ecla.CountryName = dr["SiteCountryName"].ToString();
                                ecla.LocationID = Convert.ToInt32(dr["LocationID"]);
                                ecla.LocationName = dr["SiteLocationName"].ToString();
                                ecla.AreaID = Convert.ToInt32(dr["AreaID"]);
                                ecla.AreaName = dr["SiteAreaName"].ToString();

                                exportcountrylocationarea.Add(ecla);
                            }

                            List<SalaryType> salarytypes = SalaryTypeService.Get_ValidList();
                            TList<Salary> salaries = SalaryService.Get_List();

                            TList<JXTPortal.Entities.AdvertiserUsers> advusers = AdvertiserUsersService.GetByAdvertiserId(advertiserid);
                            advusers.Filter = "Validated = true AND AccountStatus = " + ((int)PortalEnums.AdvertiserUser.AccountStatus.Approved).ToString();


                            TList<JXTPortal.Entities.AdvertiserJobTemplateLogo> logolist = AdvertiserJobTemplateLogoService.GetByAdvertiserId(advertiserid);
                            string refno = string.Empty;
                            try
                            {
                                using (StreamWriter writer = File.CreateText(ConfigurationManager.AppSettings["FileLocation"]))
                                {
                                    if (!exportassoap)
                                    {
                                        string ArchiveMissingJobs = (cbArchiveMissingJobs.Checked) ? "true" : "false";
                                        writer.WriteLine(@"<JobPostRequest xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.servicestack.net/types"">");
                                        writer.WriteLine(@"<UserName xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + tbUsername.Text + "</UserName>");
                                        writer.WriteLine(@"<Password xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + tbPassword.Text + "</Password>");
                                        writer.WriteLine(@"<AdvertiserId xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + tbAdvertiser.Text + "</AdvertiserId>");
                                        writer.WriteLine(@"<ArchiveMissingJobs xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + ArchiveMissingJobs + "</ArchiveMissingJobs>");
                                        writer.WriteLine(@"<Listings>");

                                        
                                        for (int i = 0; i < count; i++)
                                        {
                                            int? logoid = GetRandomAdvertiserJobTemplateLogo(logolist);
                                            int? advuserid = GetRandomAdvertiserUser(advusers);
                                            string refprefix = string.Format("{0}{1}", tbJobRefPrefix.Text, i + 1);
                                            ExportCountryLocationArea ecla = GetRandomCountryLocationArea(exportcountrylocationarea);
                                            RandomSalary rs = GetRandomSalary(salaries, salarytypes);
                                            refno = string.Format("{0}{1}", tbJobRefPrefix.Text, i + 1);

                                            writer.WriteLine(string.Format(Resource1.JobXML,
                                                            refno,
                                                            GetRandomProfessionRoles(exportprofessionroles),
                                                            GetRandomWorkType(exportworktype),
                                                            ecla.CountryID,
                                                            ecla.LocationID,
                                                            ecla.AreaID,
                                                            rs.SalaryTypeName,
                                                            rs.SalaryMin,
                                                            rs.SalaryMax,
                                                            Utils.UrlFriendlyName(refprefix),
                                                            refno,
                                                            (advuserid.HasValue)?advuserid.Value.ToString():string.Empty, (logoid.HasValue)?logoid.Value.ToString():string.Empty) // Consultant ID
                                            );
                                        }
                                        writer.WriteLine(@"</Listings></JobPostRequest>");
                                    }
                                    else
                                    {
                                        string ArchiveMissingJobs = (cbArchiveMissingJobs.Checked) ? "true" : "false";
                                        writer.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?><soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope""><soap12:Body>");
                                        writer.WriteLine(@"<JobPostRequest xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.servicestack.net/types"">");
                                        writer.WriteLine(@"<UserName xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + tbUsername.Text + "</UserName>");
                                        writer.WriteLine(@"<Password xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + tbPassword.Text + "</Password>");
                                        writer.WriteLine(@"<AdvertiserId xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + tbAdvertiser.Text + "</AdvertiserId>");
                                        writer.WriteLine(@"<ArchiveMissingJobs xmlns=""http://schemas.datacontract.org/2004/07/JXTPlatform.DTO.Base"">" + ArchiveMissingJobs + "</ArchiveMissingJobs>");
                                        writer.WriteLine(@"<Listings>");

                                        for (int i = 0; i < count; i++)
                                        {
                                            int? logoid = GetRandomAdvertiserJobTemplateLogo(logolist);
                                            int? advuserid = GetRandomAdvertiserUser(advusers);
                                            string refprefix = string.Format("{0}{1}", tbJobRefPrefix.Text, i + 1);
                                            ExportCountryLocationArea ecla = GetRandomCountryLocationArea(exportcountrylocationarea);
                                            RandomSalary rs = GetRandomSalary(salaries, salarytypes);
                                            refno = string.Format("{0}{1}", tbJobRefPrefix.Text, i + 1);
                                            writer.WriteLine(string.Format(Resource1.JobSOAP,
                                                            refno,
                                                            GetSOAPRandomProfessionRoles(exportprofessionroles),
                                                            GetRandomWorkType(exportworktype),
                                                            ecla.CountryID,
                                                            ecla.LocationID,
                                                            ecla.AreaID,
                                                            rs.SalaryTypeName,
                                                            rs.SalaryMin,
                                                            rs.SalaryMax,
                                                            Utils.UrlFriendlyName(refprefix),
                                                            (advuserid.HasValue)?advuserid.Value.ToString():string.Empty, (logoid.HasValue) ? logoid.Value.ToString() : string.Empty)  // Consultant ID
                                            );
                                        }
                                        writer.WriteLine(@"</Listings></JobPostRequest></soap12:Body></soap12:Envelope>");
                                    }

                                    lbMessage.Text = "Done.";
                                }
                            }
                            catch (Exception ex)
                            {
                                lbMessage.Text = ex.Message + "\n" + ex.StackTrace;
                            }
                        }
                        else
                        {
                            lbMessage.Text = "Invalid AdvertiserID. Please make sure it is numeric and greater than 0.";
                        }
                    }
                    else
                    {
                        lbMessage.Text = "Invalid AdvertiserID. Please make sure it is numeric and greater than 0.";
                    }
                }
                else
                {
                    lbMessage.Text = "Invalid No. of Jobs. Please make sure it is numeric and greater than 0.";
                }
            }
            else
            {
                lbMessage.Text = "Invalid No. of Jobs. Please make sure it is numeric and greater than 0.";
            }
        }

        private int? GetRandomAdvertiserUser(TList<JXTPortal.Entities.AdvertiserUsers> advusers)
        {
            int? advertiseruserid = (int?)null;

            if (advusers.Count > 0)
            {
                int index = random.Next(0, advusers.Count);
                advertiseruserid = advusers[index].AdvertiserUserId;
            }

            return advertiseruserid;
        }

        private int? GetRandomAdvertiserJobTemplateLogo(TList<JXTPortal.Entities.AdvertiserJobTemplateLogo> logolist)
        {
            int? logoid = (int?)null;

            if (logolist.Count > 0)
            {
                int index = random.Next(0, logolist.Count);
                logoid = logolist[index].AdvertiserJobTemplateLogoId;
            }

            return logoid;
        }



        private string GetRandomWorkType(List<ExportWorkType> exportworktype)
        {
            string resulttext = string.Empty;

            int index = random.Next(0, exportworktype.Count);

            return exportworktype[index].WorkTypeID.ToString();
        }

        private string GetRandomProfessionRoles(List<ExportProfessionRoles> exportprofessionroles)
        {
            string resulttext = string.Empty;
            List<RandomProfessionRoles> result = new List<RandomProfessionRoles>();

            int count = random.Next(1, 4);

            for (int i = 0; i < count && i < exportprofessionroles.Count; i++)
            {
                int index = random.Next(0, exportprofessionroles.Count);
                ExportProfessionRoles epr = exportprofessionroles[index];

                RandomProfessionRoles rpr = new RandomProfessionRoles();
                rpr.ProfessionID = epr.ProfessionID;
                rpr.RoleID = epr.RolesID;

                bool found = false;
                foreach (RandomProfessionRoles chosenrpr in result)
                {
                    if (rpr.ProfessionID == chosenrpr.ProfessionID && rpr.RoleID == chosenrpr.RoleID)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    result.Add(rpr);
                }
                else
                {
                    count--;
                }

            }

            foreach (RandomProfessionRoles rpr in result)
            {
                resulttext += string.Format("<Category><Classification>{0}</Classification><SubClassification>{1}</SubClassification></Category>\n", rpr.ProfessionID, rpr.RoleID);
            }

            return resulttext;
        }

        private string GetSOAPRandomProfessionRoles(List<ExportProfessionRoles> exportprofessionroles)
        {
            string resulttext = string.Empty;
            List<RandomProfessionRoles> result = new List<RandomProfessionRoles>();

            int count = random.Next(1, 4);

            for (int i = 0; i < count && i < exportprofessionroles.Count; i++)
            {
                int index = random.Next(0, exportprofessionroles.Count);
                ExportProfessionRoles epr = exportprofessionroles[index];

                RandomProfessionRoles rpr = new RandomProfessionRoles();
                rpr.ProfessionID = epr.ProfessionID;
                rpr.RoleID = epr.RolesID;

                bool found = false;
                foreach (RandomProfessionRoles chosenrpr in result)
                {
                    if (rpr.ProfessionID == chosenrpr.ProfessionID && rpr.RoleID == chosenrpr.RoleID)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    result.Add(rpr);
                }
                else
                {
                    count--;
                }

            }

            foreach (RandomProfessionRoles rpr in result)
            {
                resulttext += string.Format("<Category><Classification>{0}</Classification><SubClassification>{1}</SubClassification></Category>\n", rpr.ProfessionID, rpr.RoleID);
            }

            return resulttext;
        }

        private ExportCountryLocationArea GetRandomCountryLocationArea(List<ExportCountryLocationArea> exportcountrylocationarea)
        {
            string resulttext = string.Empty;

            List<RandomCountryLocationArea> result = new List<RandomCountryLocationArea>();
            int count = random.Next(0, exportcountrylocationarea.Count);

            ExportCountryLocationArea ecla = exportcountrylocationarea[count];

            return ecla;
        }

        private RandomSalary GetRandomSalary(TList<Salary> salaries, List<SalaryType> salarytypes)
        {
            RandomSalary rs = new RandomSalary();
            List<Salary> salarymaxlist = new List<Salary>();
            foreach (Salary s in salaries)
            {
                if (s.IsFrom == false)
                {
                    salarymaxlist.Add(s);
                }
            }

            int count = random.Next(0, salarymaxlist.Count());
            Salary salarymax = salarymaxlist[count];
            decimal max = salarymax.Amount;

            List<Salary> salaryminlist = new List<Salary>();
            foreach (Salary s in salaries)
            {
                if (s.IsFrom == true && s.SalaryTypeId == salarymaxlist[count].SalaryTypeId && s.Amount < salarymaxlist[count].Amount)
                {
                    salaryminlist.Add(s);
                }
            }

            rs.SalaryType = salarymax.SalaryTypeId.Value;
            foreach (JXTPortal.Entities.SalaryType sst in salarytypes)
            {
                if (sst.SalaryTypeId == rs.SalaryType)
                {
                    rs.SalaryTypeName = sst.SalaryTypeName;

                    break;
                }
            }
            rs.SalaryMax = salarymax.Amount;

            count = random.Next(0, salaryminlist.Count());

            Salary salarymin = salaryminlist[count];
            decimal min = salarymin.Amount;

            rs.SalaryMin = min;

            return rs;
        }

        internal class RandomProfessionRoles
        {
            public int ProfessionID { get; set; }
            public int RoleID { get; set; }
        }

        internal class RandomCountryLocationArea
        {
            public int CountryID { get; set; }
            public int LocationID { get; set; }
            public int AreaID { get; set; }
        }

        internal class RandomSalary
        {
            public int SalaryType { get; set; }
            public string SalaryTypeName { get; set; }
            public decimal SalaryMin { get; set; }
            public decimal SalaryMax { get; set; }
        }

        internal class ExportJobTemplates
        {
            public int JobTemplateID { get; set; }
            public string JobTemplateDescription { get; set; }

            public ExportJobTemplates() { }
        }

        internal class ExportAdvertiserJobTemplateLogo
        {
            public int AdvertiserJobTemplateLogoID { get; set; }
            public string JobLogoName { get; set; }

            public ExportAdvertiserJobTemplateLogo() { }
        }

        internal class ExportProfessionRoles
        {
            public int ProfessionID { get; set; }
            public string ProfessionName { get; set; }
            public int RolesID { get; set; }
            public string RolesName { get; set; }
        }

        internal class ExportWorkType
        {
            public int WorkTypeID { get; set; }
            public string WorkTypeName { get; set; }

            public ExportWorkType() { }
        }

        internal class ExportCountryLocationArea
        {
            public int CountryID { get; set; }
            public string CountryName { get; set; }
            public int LocationID { get; set; }
            public string LocationName { get; set; }
            public int AreaID { get; set; }
            public string AreaName { get; set; }
        }

        private void cbExportAsSOAP_CheckedChanged(object sender, EventArgs e)
        {

        }

    }


}
