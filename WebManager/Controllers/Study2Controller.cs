using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebManager.Model;
using WebManager.Data;

namespace WebManager.Controllers
{
    public class Study2Controller : Controller
    {
        private EFUnitOfWork db = new EFUnitOfWork();

        //
        // GET: /Study2/

        public ActionResult Index()
        {
            return View(db.Studies.GetAll());
        }

        //
        // GET: /Study2/Details/5

        public ActionResult Details(int id = 0)
        {
            Study study = db.Studies.GetById(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // GET: /Study2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Study2/Create

        [HttpPost]
        public ActionResult Create(Study study)
        {
            if (ModelState.IsValid)
            {
                db.Studies.Add(study);
                db.Commit();
                return RedirectToAction("Index");
            }

            return View(study);
        }

        //
        // GET: /Study2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Study study = db.Studies.GetById(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // POST: /Study2/Edit/5

        [HttpPost]
        public ActionResult Edit(Study study)
        {
            if (ModelState.IsValid)
            {
                db.Studies.GetById(study.Id).Information = study.Information;
                db.Studies.GetById(study.Id).Name = study.Name;
                db.Studies.GetById(study.Id).ShortName = study.ShortName;
                db.Studies.GetById(study.Id).StudyInformationId = study.StudyInformationId;
                db.Commit();
                return RedirectToAction("Index");
            }
            return View(study);
        }

        //
        // GET: /Study2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Study study = db.Studies.GetById(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // POST: /Study2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Study study = db.Studies.GetById(id);
            db.Studies.Remove(study);
            db.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}