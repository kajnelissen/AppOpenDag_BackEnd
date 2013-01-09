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
    public class TimeTableController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /TimeTable/

        public ActionResult Index()
        {
            return View(db.TimeTables.ToList());
        }

        //
        // GET: /TimeTable/Details/5

        public ActionResult Details(int id = 0)
        {
            TimeTable timetable = db.TimeTables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        //
        // GET: /TimeTable/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TimeTable/Create

        [HttpPost]
        public ActionResult Create(TimeTable timetable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTables.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timetable);
        }

        //
        // GET: /TimeTable/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TimeTable timetable = db.TimeTables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        //
        // POST: /TimeTable/Edit/5

        [HttpPost]
        public ActionResult Edit(TimeTable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timetable);
        }

        //
        // GET: /TimeTable/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TimeTable timetable = db.TimeTables.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        //
        // POST: /TimeTable/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTable timetable = db.TimeTables.Find(id);
            db.TimeTables.Remove(timetable);
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