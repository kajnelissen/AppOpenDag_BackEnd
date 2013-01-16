using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenDagBackEnd.Models;

namespace OpenDagBackEnd.Controllers
{
    public class StudyController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /Study/

        public ActionResult Index()
        {
            return View(db.Studies.ToList());
        }

        //
        // GET: /Study/Details/5

        public ActionResult Details(int id = 0)
        {
            Study study = db.Studies.Find(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // GET: /Study/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Study/Create

        [HttpPost]
        public ActionResult Create(StudyStudyInformation model)
        {
            try
            {
                // TODO: Add insert logic here
                //db.StudyInfos.Add(model.StudyInformation);
                db.Studies.Add(model.Study);
                db.StudyInfos.Add(model.StudyInformation);
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Study/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Study study = db.Studies.Find(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // POST: /Study/Edit/5

        [HttpPost]
        public ActionResult Edit(Study study)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(study);
        }

        //
        // GET: /Study/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Study study = db.Studies.Find(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // POST: /Study/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Study study = db.Studies.Find(id);
            db.Studies.Remove(study);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StudyInformation()
        {
            return View(db.StudyInfos.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}