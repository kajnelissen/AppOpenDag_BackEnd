using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebManager.Data;
using WebManager.Model;

namespace WebManager.Controllers
{
    public class StudyInformationController : Controller
    {
        //
        // GET: /StudyInformation/

        public ActionResult Index()
        {
            EFUnitOfWork ef = new EFUnitOfWork();

            Study study = new Study();
            study.Name = "Informatica";
            study.ShortName = "I";

            ef.Studies.Add(study);

            ViewBag.V = study;

            return View();
        }

    }
}
