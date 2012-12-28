using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebManager.Data;
using WebManager.Model;

namespace WebManager.Controllers
{
    public class StudyController : Controller
    {
        private EFUnitOfWork _EF;

        //
        // GET: /Study/

        private void createEF()
        {
            _EF = new EFUnitOfWork();
        }

        public ActionResult Index()
        {
            if (_EF == null)
            {
                createEF();
            }

            List<Study> studies = new List<Study>();
            List<Study> studiesCollection = _EF.Studies.GetAll().ToList();

            foreach (Study s in studiesCollection)
            {
                studies.Add(s);
            }

            ViewBag.studies = studies;

            return View();
        }

        public ActionResult newStudy()
        {
            return View();
        }

        public ActionResult AddStudy(string tbStudy, string tbShortName)
        {
            if (_EF == null)
            {
                createEF();
            }

            Study study = new Study();

            study.Name = "Inforamtica";
            study.ShortName = "I";

            _EF.Studies.Add(study);
            _EF.Commit();

            Index();
            return View("Index");
        }
    }
}
