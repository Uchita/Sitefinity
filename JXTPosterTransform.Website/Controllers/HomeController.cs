using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPosterTransform.Website.Models;
using System.Web.Script.Serialization;
using JXTPosterTransform.Website.Logics;

namespace JXTPosterTransform.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";

            //new JXTPosterTransform.Library.Services.PosterTransformService().PosterTransformServiceTest();

            return View();
        }


    }
}
