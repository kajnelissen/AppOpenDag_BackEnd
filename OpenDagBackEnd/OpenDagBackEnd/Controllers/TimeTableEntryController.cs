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
    public class TimeTableEntryController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //
        // GET: /TimeTableEntry/

        public ActionResult Index()
        {
            var timetableentries = db.TimeTableEntries.Include(t => t.TimeTable);
            return View(timetableentries.ToList());
        }

        //
        // GET: /TimeTableEntry/Details/5

        public ActionResult Details(int id = 0)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.Find(id);
            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            return View(timetableentry);
        }

        //
        // GET: /TimeTableEntry/Create

        public ActionResult Create()
        {
            //ViewBag.TimeTableId = new SelectList(db.TimeTables, "Id", "Id");
            ViewBag.TimeTableDate = new SelectList(db.TimeTables, "Date", "Date");
            return View();
        }

        //
        // POST: /TimeTableEntry/Create

        [HttpPost]
        public ActionResult Create(TimeTableEntry timetableentry, DateTime TimeTableDate)
        {
            int v = (from s in db.TimeTables
                    where s.Date == TimeTableDate
                    select s.Id).First();

            timetableentry.TimeTableId = Convert.ToInt32(v);

            if (ModelState.IsValid)
            {
                db.TimeTableEntries.Add(timetableentry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeTableId = new SelectList(db.TimeTables, "Id", "Id", timetableentry.TimeTableId);
            return View(timetableentry);
        }

        //
        // GET: /TimeTableEntry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.Find(id);
            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            ViewBag.TimeTableId = new SelectList(db.TimeTables, "Id", "Id", timetableentry.TimeTableId);
            return View(timetableentry);
        }

        //
        // POST: /TimeTableEntry/Edit/5

        [HttpPost]
        public ActionResult Edit(TimeTableEntry timetableentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetableentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TimeTableId = new SelectList(db.TimeTables, "Id", "Id", timetableentry.TimeTableId);
            return View(timetableentry);
        }

        //
        // GET: /TimeTableEntry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.Find(id);
            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            return View(timetableentry);
        }

        //
        // POST: /TimeTableEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTableEntry timetableentry = db.TimeTableEntries.Find(id);
            db.TimeTableEntries.Remove(timetableentry);
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