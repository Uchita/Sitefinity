using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPortal.Entities;
using JXTPortal.Domain.Services;
using JXTPortal.MobileWebsite.Custom.Attributes;
using JXTPortal.Domain.ViewModel;

namespace JXTPortal.MobileWebsite.Controllers.Job
{
    public class JobController : Controller
    {
        //
        // GET: /Job/

        public ActionResult Index(int id)
        {
            JobService service = new JobService();

            return View(service.GetById(SessionData.Site.SiteId , id));
        }

        public ActionResult GetProfessions()
        {
            SiteProfessionService _siteProfessionService = new SiteProfessionService();
            var model = new JobModel.Search();

            model.Professions.Add("-All Profession-", "0");

            foreach (var profession in _siteProfessionService.GetBySiteId(SessionData.Site.SiteId))
            {
                model.Professions.Add(profession.ProfessionId.ToString(), profession.SiteProfessionName);
            }

            _siteProfessionService = null;
         
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(JobModel.Search model)
        {
            JobService JobService = new JobService();
            return View(JobService.Search(SessionData.Site.SiteId, model, 1));
        }

        public ActionResult Search(string keyword, int worktypeid, int professionid,
                                    IEnumerable<string> roleid, int locationid, IEnumerable<string> areaid, 
                                    int salarytypeid, string salaryfromid, string salarytoid, int pageno)
        {
            JobService JobService = new JobService();
            JobModel.Search  model = new JobModel.Search() {Keyword = keyword, WorkTypeId = worktypeid, 
                                                            ProfessionId = professionid, RoleId = roleid, 
                                                            LocationId = locationid, AreaId = areaid,
            SalaryTypeId = salarytypeid, SalaryFromId = salaryfromid, SalaryToId = salarytoid};
            JobModel.Result resultmodel = JobService.Search(SessionData.Site.SiteId, model, pageno);

            return Json(resultmodel.JobSearchResults, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorize]
        public ActionResult SaveJob(int jobid)
        {
            string message = string.Empty;
            bool successful = false;

            JobsSavedService JobsSavedService = new JobsSavedService();
            successful = JobsSavedService.SavedJobForMember(jobid, ref message);
            JobsSavedService = null;
            
            return Json(new { successful = successful, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}
