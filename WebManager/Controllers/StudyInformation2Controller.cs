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
    public class StudyInformation2Controller : Controller
    {
        private EFUnitOfWork db = new EFUnitOfWork();

        //
        // GET: /StudyInformation2/

        public ActionResult Index()
        {
            var studyinfos = db.StudyInfos.GetAll().ToList();
            // var studyinfos = db.StudyInfos.Include(s => s.Study);
            return View(studyinfos.ToList());
        }

        //
        // GET: /StudyInformation2/Details/5

        public ActionResult Details(int id = 0)
        {
            StudyInformation studyinformation = db.StudyInfos.GetById(id);
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation2/Create

        public ActionResult Create()
        {
            // ViewBag.StudyId = new SelectList(db.Studies, "Id", "Name");
            ViewBag.StudyId = new SelectList(db.Studies.GetAll(), "Id", "Name");
            return View();
        }

        //
        // POST: /StudyInformation2/Create

        [HttpPost]
        public ActionResult Create(StudyInformation studyinformation)
        {
            if (ModelState.IsValid)
            {
                db.StudyInfos.Add(studyinformation);
                db.Commit();
                return RedirectToAction("Index");
            }

            // ViewBag.StudyId = new SelectList(db.Studies, "Id", "Name", studyinformation.StudyId);
            ViewBag.StudyId = new SelectList(db.Studies.GetAll(), "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudyInformation studyinformation = db.StudyInfos.GetById(id);
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudyId = new SelectList(db.Studies.GetAll(), "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // POST: /StudyInformation2/Edit/5

        [HttpPost]
        public ActionResult Edit(StudyInformation studyinformation)
        {
            if (ModelState.IsValid)
            {
                db.StudyInfos.GetById(studyinformation.Id).Study = studyinformation.Study;
                db.StudyInfos.GetById(studyinformation.Id).Content = studyinformation.Content;
                db.StudyInfos.GetById(studyinformation.Id).StudyId = studyinformation.StudyId;
                db.StudyInfos.GetById(studyinformation.Id).Title = studyinformation.Title;
                db.StudyInfos.GetById(studyinformation.Id).Study = studyinformation.Study;
                
                // db.Entry(studyinformation).State = EntityState.Modified;
                db.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.StudyId = new SelectList(db.Studies.GetAll(), "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudyInformation studyinformation = db.StudyInfos.GetById(id);
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            return View(studyinformation);
        }

        //
        // POST: /StudyInformation2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyInformation studyinformation = db.StudyInfos.GetById(id);
            db.StudyInfos.Remove(studyinformation);
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