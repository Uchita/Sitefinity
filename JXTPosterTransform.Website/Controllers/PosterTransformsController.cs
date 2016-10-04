using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPosterTransform.Website.Models;
using JXTPosterTransform.Website.Logics;

namespace JXTPosterTransform.Website.Controllers
{
    public class PosterTransformsController : Controller
    {
        //
        // GET: /PosterTransforms/

        public ActionResult Index()
        {
            List<PTDisplayModel> pts = new PTLogics().PosterTransformsListingGet();

            return View(pts);
        }

        public ActionResult Edit(int id)
        {
            PTDisplayModel pt = new PTLogics().PosterTransformGet(id);
            return View(pt);
        }

        [HttpPost]
        public ActionResult Edit(PTDisplayModel pt)
        {

            if (ModelState.IsValid)
            {
                pt.Valid = Library.Common.PTCommonEnums.PosterTransform.Valid.Valid;
                bool updateSuccess = new PTLogics().PosterTransformUpdate(pt);
                if (updateSuccess)
                {
                    ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Poster Transform details updated successfully", FrontEndHelper.BootstrapAlertType.Success);
                }
                else
                {
                    ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Poster Transform details failed to update", FrontEndHelper.BootstrapAlertType.Danger);
                }
            }

            return View(pt);
        }

    }
}
