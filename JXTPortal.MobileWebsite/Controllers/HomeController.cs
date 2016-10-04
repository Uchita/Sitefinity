using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPortal.Entities;
using JXTPortal.Domain.ViewModel;

namespace JXTPortal.MobileWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.SiteId = SessionData.Site.SiteId;

            SiteProfessionService _siteProfessionService = new SiteProfessionService();
            SiteLocationService _siteLocationService = new SiteLocationService();
            SiteWorkTypeService _siteWorkTypeService = new SiteWorkTypeService();
            //SalaryService _salaryService = new SalaryService();
            SiteSalaryTypeService _siteSalaryTypeService = new SiteSalaryTypeService();
            ViewSalaryService _salaryService = new ViewSalaryService();

            var model = new JobModel.Search();

            //Professions
           
            foreach (var profession in _siteProfessionService.GetBySiteId(SessionData.Site.SiteId))
            {
                model.Professions.Add(profession.ProfessionId.ToString(), profession.SiteProfessionName);
            }

            //Location
           
            foreach (var location in _siteLocationService.GetBySiteId(SessionData.Site.SiteId))
            {
                model.Locations.Add(location.LocationId.ToString(), location.SiteLocationName);
            }

            //Worktype
            
            foreach (var worktype in _siteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
            {
                model.WorkTypes.Add(worktype.WorkTypeId.ToString(), worktype.SiteWorkTypeName);
            }

            //Salary Types
            List<Entities.SiteSalaryType> salaryTypeList  = _siteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            foreach (Entities.SiteSalaryType salaryType in salaryTypeList)
            {
                model.SalaryTypes.Add(salaryType.SalaryTypeId.ToString(), salaryType.SalaryTypeName);                
            }

            // Salary
            if (salaryTypeList.Count > 0)
            {
                VList<ViewSalary> salaryFromList = _salaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salaryTypeList[0].SalaryTypeId);
                foreach (var salary in salaryFromList)
                {
                    model.SalaryFrom.Add(string.Format("{0};{1};{2}", salary.CurrencyId, salary.Amount, salary.SalaryId), salary.SalaryDisplay);
                }

                if (salaryFromList.Count > 0)
                {
                    ViewSalary vsFrom = salaryFromList[0];
                    salaryFromList.Clear();
                    salaryFromList = _salaryService.GetCustomSalaryTo(SessionData.Site.SiteId, vsFrom.CurrencyId, vsFrom.SalaryTypeId, vsFrom.Amount);
                    foreach (var salary in salaryFromList)
                    {
                        model.SalaryTo.Add(string.Format("{0};{1};{2}", salary.CurrencyId, salary.Amount,salary.SalaryId), salary.SalaryDisplay);
                    }

                }
            }

            salaryTypeList.Clear();

            _siteSalaryTypeService = null;
            _salaryService = null;

            _siteProfessionService = null;
            _siteLocationService = null;
            _siteWorkTypeService = null; ;
            return View(model);

        }

        public ActionResult Areas(int locationId)
        {
            SiteAreaService _siteAreaService = new SiteAreaService();
            Dictionary<string, string> areas = new Dictionary<string, string>();

            foreach (var area in _siteAreaService.GetByLocationID(SessionData.Site.SiteId, locationId))
            {
               areas.Add(area.AreaId.ToString(), area.SiteAreaName);
            }

            _siteAreaService = null;

            return Json(areas.Select(x => new {Id = x.Key, Name = x.Value}), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Roles(int professionId)
        {
            SiteRolesService _siteRolesService = new SiteRolesService();
            Dictionary<string, string> roles = new Dictionary<string, string>();

            foreach (var role in _siteRolesService.GetByProfessionID(SessionData.Site.SiteId, professionId))
            {
                roles.Add(role.RoleId.ToString(), role.SiteRoleName);
            }

            _siteRolesService = null;

            return Json(roles.Select(x => new { Id = x.Key, Name = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSalaryRangeFrom(int salaryTypeId, string SalaryValueSet)
        {
            string[] valueset = SalaryValueSet.Split(';');
            int currencyId = Convert.ToInt32(valueset[0]);
            decimal amount = Convert.ToDecimal(valueset[1]);

            ViewSalaryService viewSalaryService = new ViewSalaryService();
            VList<ViewSalary> salaryFromList = viewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salaryTypeId);
            viewSalaryService = null;

            return Json(salaryFromList.Select(x => new { Id = string.Format("{0};{1};{2}", x.CurrencyId, x.Amount, x.SalaryId), SalaryDisplay = x.SalaryDisplay }), JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult GetSalaryRangeTo(int salaryTypeId, string SalaryValueSet)
        {
            string[] valueset = SalaryValueSet.Split(';');
            int currencyId = Convert.ToInt32(valueset[0]);
            decimal amount = Convert.ToDecimal(valueset[1]);

            ViewSalaryService viewSalaryService = new ViewSalaryService();
            VList<ViewSalary> salaryToList = viewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, currencyId, salaryTypeId, amount);
            viewSalaryService = null;

            return Json(salaryToList.Select(x => new { Id = string.Format("{0};{1};{2}", x.CurrencyId, x.Amount, x.SalaryId), SalaryDisplay = x.SalaryDisplay }), JsonRequestBehavior.AllowGet);            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
    }
}
