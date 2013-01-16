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
    public class StudyInformationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /StudyInformation/

        public ActionResult Index()
        {
            var studyinfos = db.StudyInfos.Include(s => s.Study);
            return View(studyinfos.ToList());
        }

        //
        // GET: /StudyInformation/Details/5

        public ActionResult Details(int id = 0)
        {
            StudyInformation studyinformation = db.StudyInfos.Find(id);
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation/Create

        public ActionResult Create()
        {
            ViewBag.StudyId = new SelectList(db.Studies, "Id", "Name");
            return View();
        }

        //
        // POST: /StudyInformation/Create

        [HttpPost]
        public ActionResult Create(StudyInformation studyinformation)
        {
            if (ModelState.IsValid)
            {
                db.StudyInfos.Add(studyinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudyId = new SelectList(db.Studies, "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudyInformation studyinformation = db.StudyInfos.Find(id);
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudyId = new SelectList(db.Studies, "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // POST: /StudyInformation/Edit/5

        [HttpPost]
        public ActionResult Edit(StudyInformation studyinformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudyId = new SelectList(db.Studies, "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudyInformation studyinformation = db.StudyInfos.Find(id);
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            return View(studyinformation);
        }

        //
        // POST: /StudyInformation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyInformation studyinformation = db.StudyInfos.Find(id);
            db.StudyInfos.Remove(studyinformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}